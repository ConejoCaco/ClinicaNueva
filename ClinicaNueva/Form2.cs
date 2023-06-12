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
    public partial class Form2 : Form
    {
        ControladorAdministrador ctrAdmin;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctrAdmin.Mostrar(dataGridView1);
        }
    }
}
