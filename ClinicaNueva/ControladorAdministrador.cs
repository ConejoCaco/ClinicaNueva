﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaNueva
{
    class ControladorAdministrador
    {
        public ModeloAdministrador M_ADMIN = new ModeloAdministrador();
        private string adm, pass;

        public string Adm
        {
            get { return adm; }
            set { adm = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public bool Rut(string rut)
        {

            rut = rut.Replace(".", "").Replace("-", "");


            if (!Regex.IsMatch(rut, @"^\d{7,8}[0-9Kk]$"))
            {
                return false;
            }


            char dv = rut[rut.Length - 1];


            string cuerpo = rut.Substring(0, rut.Length - 1);


            int suma = 0;
            int multiplicador = 2;

            for (int i = cuerpo.Length - 1; i >= 0; i--)
            {
                suma += int.Parse(cuerpo[i].ToString()) * multiplicador;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }

            int resto = suma % 11;
            int verificador = 11 - resto;


            if (verificador == 10 && (dv == 'K' || dv == 'k'))
            {
                return true;
            }
            else if (verificador == 11 && dv == '0')
            {
                return true;
            }
            else if (verificador == int.Parse(dv.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarContent(TextBox[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (string.IsNullOrEmpty(a[i].Text))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Login()
        {
            string[] datos = M_ADMIN.SolicitarAdmin(adm);
            if (datos[0].Equals(adm) && datos[1].Equals(pass))
            {
                return true;

            }
            return false;
            
        }

        /*public void Mostrar()
        {
            string[,] usuarios = M_ADMIN.SolicitandoDatosPorId();

            // Obtener la cantidad de filas y columnas del arreglo
            int rowCount = usuarios.GetLength(0);
            int columnCount = usuarios.GetLength(1);

            // Recorrer el arreglo e imprimir los datos de cada usuario
            for (int i = 0; i < rowCount; i++)
            {
                string usuario = usuarios[i, 0];
                string password = usuarios[i, 1];
                string rut = usuarios[i, 2];

                Console.WriteLine($"Usuario: {usuario}, Password: {password}, Rut: {rut}");
            }
        }*/
        public void Mostrar(DataGridView dataGridView)
        {
            string[,] usuarios = M_ADMIN.SolicitandoDatosPorId();

            // Obtener la cantidad de filas y columnas del arreglo
            int rowCount = usuarios.GetLength(0);
            int columnCount = usuarios.GetLength(1);

            // Limpiar el DataGridView
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Agregar las columnas al DataGridView con nombres personalizados
            dataGridView.Columns.Add("Usuario", "Usuario");
            dataGridView.Columns.Add("Contraseña", "Contraseña");
            dataGridView.Columns.Add("Rut", "Rut");

            // Agregar las filas al DataGridView
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                string[] rowData = new string[columnCount];
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    rowData[columnIndex] = usuarios[rowIndex, columnIndex];
                }

                dataGridView.Rows.Add(rowData);
            }
        }



    }
}
