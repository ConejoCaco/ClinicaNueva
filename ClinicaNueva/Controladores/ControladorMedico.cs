using ClinicaNueva.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicaNueva.Controladores
{
    class ControladorMedico
    {
        ModeloMedico M_Medico = new ModeloMedico();

        private string rut, pass;

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

        public bool Login()
        {
            string[] datos = M_Medico.Solicitar(rut);
            if (datos[0].Equals(rut) && datos[1].Equals(pass))
            {
                return true;
            }
            return false;

        }
    }
}
