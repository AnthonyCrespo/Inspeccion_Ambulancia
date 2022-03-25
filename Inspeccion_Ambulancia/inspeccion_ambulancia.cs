using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inspeccion_Ambulancia
{
    public partial class inspeccion_ambulancia : Form
    {
        public inspeccion_ambulancia()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void inspeccion_ambulancia_Load(object sender, EventArgs e)
        {

        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inspeccion_ambulancia_Load_1(object sender, EventArgs e)
        {
            Funciones.cargaComboBox("select provincia from provincias;", provincia);
        }
    }
}
