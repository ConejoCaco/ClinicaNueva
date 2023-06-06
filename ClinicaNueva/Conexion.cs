using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaNueva
{
    class Conexion
    {
        //Aca solo cambien el Data Source con su direccion de base de datos local
        string direccionBD = "Data Source=GERSON\\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True";
        public SqlConnection AbrirConexion()
        {
            SqlConnection connection = new SqlConnection(direccionBD);
            connection.Open();
            return connection;
        }

        public void CerrarConexion(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
