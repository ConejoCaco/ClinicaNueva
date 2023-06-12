using System;
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
        ModeloAdministrador M_ADMIN = new ModeloAdministrador();
        private string rut, pass, name;

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool RutT(string rut)
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
            string[] datos = M_ADMIN.Solicitar(rut);
            if (datos[0].Equals(rut) && datos[1].Equals(pass))
            {
                Name = datos[2];
                return true;

            }
            return false;
            
        }

        public bool redirigir ()
        {
            int a = M_ADMIN.solicitarID(Rut);
            if(a == 1)
            {
                return true;
            }
            return false;
        }

        
        public void Mostrar(DataGridView dataGridView)
        {
            string[,] usuarios = M_ADMIN.SolicitandoDatosTabla();

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
