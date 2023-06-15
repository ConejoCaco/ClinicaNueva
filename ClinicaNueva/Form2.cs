using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaNueva
{
    public partial class Form2 : Form
    {
        ControladorAdministrador ctrAdmin;

        TextBox[] padm;
        public Form2(Object ctrADM)
        {
            InitializeComponent();
            ctrAdmin = (ControladorAdministrador)ctrADM;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!ctrAdmin.redirigir())
            {
                tabControl1.TabPages.Remove(tabPage3);
            }
            label1.Text = ctrAdmin.Name;
            padm = new TextBox[] { textBox1, textBox2, textBox3 };
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctrAdmin.Mostrar(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ctrAdmin.VerificarContent(padm))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                string run = ctrAdmin.AgregarGuion(textBox2.Text);
                ctrAdmin.Name = textBox1.Text;
                ctrAdmin.Rut = run;
                ctrAdmin.Pass = textBox3.Text;
                ctrAdmin.Registro();

            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 4 || textBox1.Text.Length > 8)
            {
                label5.Text = "El largo entre 5 y 8";
                if (!ctrAdmin.SonPalabras(textBox1.Text))
                {
                    label5.Text = "Solo letras";
                }
                button3.Enabled = false;

            }
            else
            {
                if (!ctrAdmin.SonPalabras(textBox1.Text))
                {
                    label5.Text = "Solo letras";
                }
                else
                {
                    button3.Enabled = true;
                    label5.Text = String.Empty;
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 4 || textBox1.Text.Length > 8)
            {
                label6.Text = "El largo entre 5 y 8";
                button3.Enabled = false;

            }
            else
            {
                label6.Text = String.Empty;
                button3.Enabled = true;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!ctrAdmin.RutT(textBox3.Text))
            {
                label7.Text = "eIngrese un rut valido";
                button1.Enabled = false;
            }
            else
            {
                label7.Text = String.Empty;
                button1.Enabled = true;
            }
        }
    }
}
