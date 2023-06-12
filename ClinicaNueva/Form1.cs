using ClinicaNueva.Controladores;
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
        ControladorMedico ctrMed = new ControladorMedico();
        ControladorSecretario ctrSecre = new ControladorSecretario();

        
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
                int x = LoginGlobal();
                switch (x)
                {
                    case 0:
                        this.Hide();
                        Form2 fm2 = new Form2(ctrADM);
                        fm2.Show();
                        break;
                    case 1:
                        this.Hide();
                        Form6 fm6 = new Form6();
                        fm6.Show();
                        break;
                    case 2:
                        this.Hide();
                        Form11 fm11 = new Form11();
                        fm11.Show();
                        break;
                    default:
                        textBox2.Text = string.Empty;
                        MessageBox.Show("Credenciales Incorrectas");
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contenido = new TextBox[2] { textBox1, textBox2 };
        }

        public int LoginGlobal()
        {
            dynamic[] objetos = new dynamic[3] { ctrADM, ctrMed, ctrSecre };

            for(int i = 0; i < objetos.Length; i++)
            {
                
                if (objetos[i].GetType().GetMethod("Login") != null)
                {
                    objetos[i].Rut = textBox1.Text;
                    objetos[i].Pass = textBox2.Text;
                    try
                    {
                        if (objetos[i].Login())
                        {
                            return i;
                        }
                    }catch (Exception ex) { }
                    
                }
            }
            return 4;
        }
    }
}
