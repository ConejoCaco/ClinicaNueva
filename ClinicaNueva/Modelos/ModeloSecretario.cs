using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaNueva.Modelos
{
    class ModeloSecretario
    {
        private Conexion conexion = new Conexion();
        public string[] Solicitar(string a)
        {
            string[] result;
            using (SqlConnection connection = conexion.AbrirConexion())
            {
                string query = $"SELECT Rut, Password FROM Secretarios WHERE Rut = '{a}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string rut = reader.GetString(0);
                            string password = reader.GetString(1);


                            result = new string[2] { rut, password };
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
