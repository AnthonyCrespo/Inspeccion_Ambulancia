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
    public partial class documento : Form
    {
        reporte frm1;
        public documento(reporte f)
        {
            InitializeComponent();
            frm1 = f;
        }

        private void documento_Load(object sender, EventArgs e)
        {
            int no_reporte = Convert.ToInt32(frm1.grd.CurrentRow.Cells[0].Value);

            Text = "Reporte No. " + no_reporte.ToString();
            MaximizeBox = false;

            //Cargar datos generales de la base de datos
            NpgsqlCommand cmd = new NpgsqlCommand();
            //Query
            string str = "select * from datos_generales where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            List<Label> label_list = new List<Label>(){
            g1, g2, g3, g4, g5, g6, g7, g8, g9, g10
            };

            for (int i = 0; i < 9; i++)
                label_list[i].Text = dr[i].ToString();
            //g1.Text = dr[0].ToString();
            //g2.Text = dr[1].ToString();
            //g3.Text = dr[2].ToString();
            //g4.Text = dr[3].ToString();
            //g5.Text = dr[4].ToString();
            //g6.Text = dr[5].ToString();
            //g7.Text = dr[6].ToString();
            //g8.Text = dr[7].ToString();
            //g9.Text = dr[8].ToString();
            g10.Text = DateTime.Parse(dr[9].ToString()).ToString("dd-MM-yyyy");
            dr.Close();


            label_list = new List<Label>(){
            l1, l2, l3, l4
            };

            List<Label> observaciones = new List<Label>(){
            lo_1, lo_2
            };


            // Limpieza
            str = "select * from limpieza where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            int j = 0; //Numero de pregunta
            int k = 0; //Numero de observación
            while (dr.Read()) {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j+=2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();

            // Cabina Interior
            label_list = new List<Label>(){ 
                ci1, ci2, ci3, ci4, ci5, ci6, ci7, ci8, ci9, ci10, ci11, ci12, ci13, ci14, ci15, ci16, ci17, ci18, ci19, ci20,
                ci21, ci22, ci23, ci24, ci25, ci26, ci27, ci28, ci29, ci30, ci31, ci32, ci33, ci34, ci35, ci36, ci37, ci38
            };
            observaciones = new List<Label>(){
                 cio1, cio2, cio3, cio4, cio5, cio6, cio7, cio8, cio9, cio10, cio11, cio12, cio13, cio14, cio15, cio16, cio17, cio18, cio19
            };

            str = "select * from cabina_interior where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            while (dr.Read())
            {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j += 2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();
            

            //Documentos

            label_list = new List<Label>(){
                d1, d2, d3, d4, d5, d6, d7, d8
            };

            observaciones = new List<Label>(){
                 do1, do2, do3, do4
            };

            str = "select * from documentos where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            while (dr.Read())
            {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j += 2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();

            // Otros datos
            // -- Combustible

            str = "select * from otros_datos where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            dr.Read();
            pic_combustible.Image = Image.FromFile(dr[1].ToString());
            pic_combustible.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_temperatura.Image = Image.FromFile(dr[2].ToString());
            pic_temperatura.SizeMode = PictureBoxSizeMode.StretchImage;
            kilometraje.Text = dr[3].ToString() + " KM";
            observaciones_generales.Text = dr[4].ToString();
        }

    }
}
