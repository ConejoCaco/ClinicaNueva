using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaNueva
{
    public partial class Form1 : Form
    {
        ControladorAdministrador ctrADM = new ControladorAdministrador();
        TextBox[] contenido;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ctrADM.VerificarContent(contenido))
            {
                MessageBox.Show("Debe llenar los campos");
            }
            else
            {
                ctrADM.Adm = textBox1.Text;
                ctrADM.Pass = textBox2.Text;
                if (ctrADM.Login())
                {
                    this.Hide();
                    Form2 fm2 = new Form2();
                    fm2.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales Incorrectas");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contenido = new TextBox[2] { textBox1, textBox2 };
        }
    }
}
