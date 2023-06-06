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

        public void Listando(DataGridView x)
        {
            int total = M_ADMIN.ContarAdministradores();

            for (int i = 0;i < total;i++) { }
        }
    }
}
