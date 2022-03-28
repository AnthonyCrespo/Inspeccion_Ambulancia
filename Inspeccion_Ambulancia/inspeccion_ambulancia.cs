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


        private void inspeccion_ambulancia_Load_1(object sender, EventArgs e)
        {
            Funciones.cargaComboBox("select provincia from provincias;", provincia);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog abrirImagen = new OpenFileDialog();
                abrirImagen.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";


                //abrir el explorador de archivos
                if (abrirImagen.ShowDialog() == DialogResult.OK)
                {
                    pic_ambulancia.ImageLocation = abrirImagen.FileName;
                    pic_ambulancia.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
