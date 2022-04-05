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


        // -------------------------- Carga del Formulario ---------------------------------
        private void inspeccion_ambulancia_Load_1(object sender, EventArgs e)
        {
            Funciones.cargaComboBox("select nombre from provincias;", provincia);
            kilometraje.Controls[0].Visible = false;
            fecha.CustomFormat = " dd/MM/yyyy";
            provincia.SelectedIndex = provincia.Items.IndexOf("Imbabura");


            // Cargar número de reporte
            NpgsqlCommand cmd = new NpgsqlCommand();
            string strSQL = "select max(no_reporte)+1 from datos_generales";
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            no_reporte.Value = (int)dr[0];
        }

        //------------------------------------------------------------------------------
        //----------------------- Carga de imagenes -------------------------------------
        //------------------------------------------------------------------------------


        // ---------------------- Cargar imagen de la ambulancia --------------------------------
        private void btn_3_Click(object sender, EventArgs e)
        {
            Funciones.cargar_foto(pic_ambulancia);
        }

        // ---------------------- Cargar imagen de combustible --------------------------------
        private void btn_4_Click_1(object sender, EventArgs e)
        {
            Funciones.cargar_foto(pic_combustible);
        }


        // ---------------------- Cargar imagen de temperatura --------------------------------
        private void btn_5_Click(object sender, EventArgs e)
        {
            Funciones.cargar_foto(pic_temperatura);
        }



        //--------------------------------------------------------------------------
        // ---------------------- Enviar formulario --------------------------------
        //--------------------------------------------------------------------------

        private void btn_enviar_Click(object sender, EventArgs e)
        {

            // ------------------------------------------------------------------------------
            // ------ Comprobar si todos los campos obligatorios han sido llenados --------
            // ------------------------------------------------------------------------------
            foreach (Control c in Datos_generales.Controls)
            {
                if (string.IsNullOrEmpty(c.Text))
                {
                    Funciones.Mensaje_Llenar_Campos("'Datos Generales'");
                    return;

                }
            }

            foreach (ComboBox cb in Limpieza.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    //Funciones.Mensaje_Llenar_Campos();
                    Funciones.Mensaje_Llenar_Campos("'Limpieza'");
                    return;
                }
            }

            foreach (ComboBox cb in Cabina_Interior.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    Funciones.Mensaje_Llenar_Campos("'Cabina Interior'");
                    return;
                }
            }

            foreach (ComboBox cb in Documentos.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    Funciones.Mensaje_Llenar_Campos("'Documentos'");
                    return;
                }
            }

            foreach (ComboBox cb in Cabina_Exterior.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    Funciones.Mensaje_Llenar_Campos("'Cabina Exterior'");
                    return;
                }
            }


            // ------ Daños -----
            // Comprobar si se ha subido una foto
            if (pic_ambulancia.Image == null)
            {
                MessageBox.Show("Es obligatorio cargar la imagen en la sección 'Daños'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            // Otros datos

            foreach (Control c in Otros_datos.Controls)

            {
                if (c.GetType() != typeof(PictureBox) && string.IsNullOrEmpty(c.Text))
                {
                    Funciones.Mensaje_Llenar_Campos("'Otros datos'");
                    return;
                }

                if (c.GetType() == typeof(PictureBox))
                {
                    if (pic_combustible.Image == null)
                        MessageBox.Show("Es obligatorio cargar la imagen de Combustible en 'Otros datos'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (pic_temperatura.Image == null)
                        MessageBox.Show("Es obligatorio cargar la imagen de Temperatura en 'Otros datos'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            //------------------------------------------------------------------------------
            //-----------------------Insertar la informacion en la base de datos -----------
            //------------------------------------------------------------------------------



            //-----------------Datos Generales----------------------
            //--------------------------------------------------------------------------
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
            //--------------------------------------------------------------------------


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
                strSQL += "(" + no_reporte.Text + ",'" + i + "','" + estado + "','" + textlist[i - 1].Text + "')";
                if (i != 2) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();



            // -------------- Cabina Interior ----------------------
            //--------------------------------------------------------------------------


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
                strSQL += "(" + no_reporte.Text + ",'" + i + "','" + estado + "','" + textlist[i - 3].Text + "')";
                if (i != 21) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Documentos ----------------------
            //--------------------------------------------------------------------------
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
                strSQL += "(" + no_reporte.Text + ",'" + i + "','" + estado + "','" + textlist[i - 22].Text + "')";
                if (i != 25) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ----------------- Cabina Exterior  ----------------
            //--------------------------------------------------------------------------
            combolist = new List<ComboBox>(){
                             comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32, comboBox33, comboBox34, comboBox35,
                             comboBox36, comboBox37, comboBox38, comboBox39, comboBox40, comboBox41, comboBox42, comboBox43, comboBox44, comboBox45, comboBox46, comboBox47
                         };

            textlist = new List<TextBox>() {
                             textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36,
                             textBox37, textBox38, textBox39, textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47
                         };
            strSQL = "insert into cabina_exterior values ";

            for (int i = 26; i < 48; i++)
            {
                estado = (combolist[i - 26].Text.Equals("Bueno")) ? 'y' : 'n';
                strSQL += "('" + no_reporte.Text + "','" + i + "','" + estado + "','" + textlist[i - 26].Text + "')";
                if (i != 47) strSQL += ", ";
            }
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            // ---------------------------- Daños  -------------------------------------
            //--------------------------------------------------------------------------
            string nombre = @"C:\Users\Anthony\Pictures\Hospital\" + no_reporte.Text + "_ambulancia.jpg";
            strSQL = "insert into danos values ";
            strSQL += "(" + no_reporte.Text + ",'" + nombre + "')";

            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            //Save image
            int width = pic_ambulancia.Size.Width;
            int height = pic_ambulancia.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            pic_ambulancia.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(nombre);


            //Guardar observaciones
            //Si no se ha escrito nada en los textbox, no se guarda nada, de lo contrario
            //se guardan tantas observaciones como textboxes tengan informacion

            textlist = new List<TextBox>(){
            textBox48, textBox49, textBox50, textBox51, textBox52, textBox53, textBox54, textBox55,
            textBox56, textBox57, textBox58, textBox59, textBox60, textBox61, textBox62, textBox63, textBox64, textBox65
            };

            int j = 48;
            int k = 1; //contador id observacion: 1 - 18
            strSQL = "";

            while (j < 66 && !string.IsNullOrEmpty(textlist[j - 48].Text))
            {
                strSQL += "('" + no_reporte.Text + "'," + k + ",'" + textlist[j - 48].Text + "')";
                if (j < 65 && !string.IsNullOrEmpty(textlist[j - 47].Text))
                    strSQL += ", ";
                j++; k++;
            }

            //Si hay al menos una observacion, se inserta a la tabla danos_observaciones
            if (string.Compare(strSQL, "") != 0)
            {
                strSQL = "insert into descripcion_danos values " + strSQL;
                cmd.CommandText = strSQL;
                cmd.Connection = main.cn;
                cmd.ExecuteNonQuery();
            }




            // ----------------- Otros datos  ----------------

            string nombre1 = @"C:\Users\Anthony\Pictures\Hospital\" + no_reporte.Text + "_combustible.jpg";
            string nombre2 = @"C:\Users\Anthony\Pictures\Hospital\" + no_reporte.Text + "_temperatura.jpg";
            strSQL = "insert into otros_datos values ";
            strSQL += "(" + no_reporte.Text + ",'" + nombre1 + "','" + nombre2 + "'," + kilometraje.Text +  ",'" + observaciones_generales.Text +"')";
            cmd.CommandText = strSQL;
            cmd.Connection = main.cn;
            cmd.ExecuteNonQuery();


            //Guardar imagen combustible
            width = pic_combustible.Size.Width;
            height = pic_combustible.Size.Height;
            bm = new Bitmap(width, height);
            pic_combustible.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(nombre1);


            //Guardar imagen_temperatura
            width = pic_temperatura.Size.Width;
            height = pic_temperatura.Size.Height;
            bm = new Bitmap(width, height);
            pic_temperatura.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(nombre2);


            Funciones.Mensaje_Registro_Insertado();
            Close();
        }
    }
}
