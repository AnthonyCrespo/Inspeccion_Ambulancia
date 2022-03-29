using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

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
            Funciones.cargaComboBox("select nombre from provincias;", provincia);
            kilometraje.Controls[0].Visible = false;
            fecha.CustomFormat = " dd/MM/yyyy";
            provincia.SelectedIndex = provincia.Items.IndexOf("Imbabura");


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

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------------
            // ------ Comprobar si todos los campos obligatorios han sido llenados --------
            // ------------------------------------------------------------------------------
            foreach (Control c in Datos_generales.Controls)
            {
                if (string.IsNullOrEmpty(c.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Datos Generales");
                    return;

                }
            }

            foreach (ComboBox cb in Limpieza.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Limpieza");
                    return;
                }
            }

            foreach (ComboBox cb in Cabina_Interior.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Cabina Interior");
                    return;
                }
            }

            foreach (ComboBox cb in Documentos.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Documentos");
                    return;
                }
            }

            foreach (ComboBox cb in Cabina_Exterior.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Cabina Exterior");
                    return;
                }
            }


            // ------ Daños -----
            // Comprobar si se ha subido una foto
            if (pic_ambulancia.Image == null)
            {
                MessageBox.Show("Daños foto");
                return;
            }

            //Funciones.Mensaje_Llenar_Campos();



            // Otros datos

            foreach (Control c in Otros_datos.Controls)

            {
                if (c.GetType() != typeof(PictureBox) && string.IsNullOrEmpty(c.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Otros datos");
                    return;
                }

                if (c.GetType() == typeof(PictureBox) && (pic_combustible.Image == null || pic_temperatura.Image == null))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    MessageBox.Show("Otros datos imagenes de combustible y/o temperatura");
                    return;
                }
            }



            //------------------------------------------------------------------------------
            //-----------------------Insertar la informacion en la base de datos -----------
            //------------------------------------------------------------------------------
            //-----------------Datos Generales----------------------
             NpgsqlCommand cmd = new NpgsqlCommand();
            string strSQL = "insert into datos_generales values ";
            strSQL += "(" + no_reporte.Text;
            strSQL += ", " + coordinacion_zonal.Value.ToString();
            strSQL += ", trim('" + conductor_entrega.Text + "'), trim('" + conductor_recibe.Text + "')";
            strSQL += ", '" + provincia.Text + "'";
            strSQL += ", '" + unidad_operativa.Text + "'";
            strSQL += ", " + alfa.Value.ToString();
            strSQL += ", '" + base_operativa.Text + "'";
            strSQL += ", '" + hora.Text + "', '";
            strSQL += fecha.Value.Date + "')";
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Limpieza ----------------------
            List<ComboBox> combolist = new List<ComboBox>(){
                             comboBox1, comboBox2
                         };

            List<TextBox> textlist = new List<TextBox>() {
                             textBox1, textBox2
                         };
            strSQL = "insert into limpieza values ";


            char estado;
            for (int i = 1; i < 3; i++)
            {
                estado = (combolist[i - 1].Text.Equals("Si")) ? 'y' : 'n';
                strSQL += "('" + no_reporte.Text + "','" + i + "','" + estado + "','" + textlist[i - 1].Text + "')";
                if (i != 2) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();



            // -------------- Cabina Interior ----------------------
            combolist = new List<ComboBox>(){
                             comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12,
                             comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20, comboBox21
                         };

            textlist = new List<TextBox>() {
                             textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                             textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21
                         };
            strSQL = "insert into cabina_interior values ";

            for (int i = 3; i < 22; i++)
            {
                estado = (combolist[i - 3].Text.Equals("Bueno")) ? 'y' : 'n';
                strSQL += "('" + no_reporte.Text + "','" + i + "','" + estado + "','" + textlist[i - 3].Text + "')";
                if (i != 21) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Documentos ----------------------
            combolist = new List<ComboBox>(){
                             comboBox22, comboBox23, comboBox24, comboBox25
                         };

            textlist = new List<TextBox>() {
                             textBox22, textBox23, textBox24, textBox25
                         };
            strSQL = "insert into documentos values ";


            for (int i = 22; i < 26; i++)
            {
                estado = (combolist[i - 22].Text.Equals("Si")) ? 'y' : 'n';
                strSQL += "('" + no_reporte.Text + "','" + i + "','" + estado + "','" + textlist[i - 22].Text + "')";
                if (i != 25) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Cabina Exterior  ----------------
            combolist = new List<ComboBox>(){
                             comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32, comboBox33, comboBox34, comboBox35,
                             comboBox36, comboBox37, comboBox38, comboBox39, comboBox40, comboBox41, comboBox42, comboBox43, comboBox44, comboBox45, comboBox46
                         };

            textlist = new List<TextBox>() {
                             textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36,
                             textBox37, textBox38, textBox39, textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46
                         };
            strSQL = "insert into cabina_interior values ";

            for (int i = 26; i < 47; i++)
            {
                estado = (combolist[i - 26].Text.Equals("Bueno")) ? 'y' : 'n';
                strSQL += "('" + no_reporte.Text + "','" + i + "','" + estado + "','" + textlist[i - 26].Text + "')";
                if (i != 46) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Daños  ----------------
            string nombre = @"C:\Users\Anthony\Pictures\Hospital\" + no_reporte.Text + "_ambulancia.jpg";
            strSQL = "insert into danos values ";
            strSQL += "('" + no_reporte.Text + "','" + nombre + "')";

            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            //Save image
            int width = pic_ambulancia.Size.Width;
            int height = pic_ambulancia.Size.Height;
            Bitmap bm = new Bitmap(width, height);

            pic_ambulancia.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(nombre);




            // ----------------- Otros datos  ----------------

        }
    }
}
