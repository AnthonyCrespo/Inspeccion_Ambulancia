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
            g1.Text = dr[0].ToString();
            g2.Text = dr[1].ToString();
            g3.Text = dr[2].ToString();
            g4.Text = dr[3].ToString();
            g5.Text = dr[4].ToString();
            g6.Text = dr[5].ToString();
            g7.Text = dr[6].ToString();
            g8.Text = dr[7].ToString();
            g9.Text = dr[8].ToString();
            g10.Text = DateTime.Parse(dr[9].ToString()).ToString("dd-MM-yyyy");      
        }
    }
}
