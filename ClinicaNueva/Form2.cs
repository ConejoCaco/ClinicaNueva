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
        ControladorAdministrador ctrAdmin = new ControladorAdministrador();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctrAdmin.Mostrar(dataGridView1);
        }
    }
}
