﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaNueva
{
    class ModeloAdministrador
    {
        private Conexion conexion = new Conexion();

        //Las Conexiones siempre se deben cerrar!

        public void RegistrarAdmin(string valor1,string valor2,string valor3)
        {
            using (SqlConnection connection = conexion.AbrirConexion())
            {
                string query = $"INSERT INTO Administrador (Usuario,Password,Rut) VALUES ('{valor1}', '{valor2}','{valor3}')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                conexion.CerrarConexion(connection);
            }
        }

        public string[] SolicitarAdmin(string a)
        {
            string[] result;
            using (SqlConnection connection = conexion.AbrirConexion())
            {
                string query = $"SELECT Password, Rut FROM Administrador WHERE Rut = '{a}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string password = reader.GetString(0);
                            string rut = reader.GetString(1);

                            result = new string[2] {rut,password};
                        }
                        else
                        {
                            result = new string[0];
                        }
                    }
                }
                conexion.CerrarConexion(connection);
                
            }
            return result;
        }

        public int ContarAdministradores()
        {
            int total = 0;
            using (SqlConnection connection = conexion.AbrirConexion())
            {
                string query = "SELECT COUNT (Rut) FROM Administrador";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            total = reader.GetInt32(0);
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron datos");
                        }
                    }
                }
                conexion.CerrarConexion(connection);
                return total;
            }
        }
        public string[] SolicitandoDatosPorId(int a)
        {
            string[] result;
            using (SqlConnection connection = conexion.AbrirConexion())
            {
                string query = $"SELECT Usuario, Password, Rut FROM Administrador WHERE id = {a}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string usuario = reader.GetString(0);
                            string password = reader.GetString(1);
                            string rut = reader.GetString(2);

                            result = new string[3] { usuario, rut, password };
                        }
                        else
                        {
                            result = new string[0];
                        }
                    }
                }
                conexion.CerrarConexion(connection);

            }
            return result;
        }


    }
}