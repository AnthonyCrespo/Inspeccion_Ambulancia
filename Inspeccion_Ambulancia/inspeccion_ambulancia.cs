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
            kilometraje.Controls[0].Visible = false;
            Fecha.CustomFormat = " dd/MM/yyyy";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    OpenFileDialog abrirImagen = new OpenFileDialog();
            //    abrirImagen.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";


            //    //abrir el explorador de archivos
            //    if (abrirImagen.ShowDialog() == DialogResult.OK)
            //    {
            //        pic_ambulancia.ImageLocation = abrirImagen.FileName;
            //        pic_ambulancia.SizeMode = PictureBoxSizeMode.StretchImage;
            //    }
            //}

            //catch(Exception)
            //{
            //    MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            Funciones.cargar_foto(pic_ambulancia);

        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (pic_ambulancia.Image != null)
            {
                int width = pic_ambulancia.Size.Width;
                int height = pic_ambulancia.Size.Height;
                Bitmap bm = new Bitmap(width, height);
                //string h = DateTime.Now.ToString("HH:mm");

                pic_ambulancia.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                bm.Save(@"C:\Users\Anthony\Documents\image_1.jpg");
                MessageBox.Show("Imagen guardada con éxito!");
            }
            else
            {
                MessageBox.Show("Es necesario que suba una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox66_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_4_Click_1(object sender, EventArgs e)
        {
            Funciones.cargar_foto(pic_combustible);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            Funciones.cargar_foto(pic_temperatura);
        }
    }
}
