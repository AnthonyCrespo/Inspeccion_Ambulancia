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
    public partial class reporte : Form
    {
        public reporte()
        {
            InitializeComponent();
        }

        private void reporte_Load(object sender, EventArgs e)
        {
            grd.ColumnCount = 6;
            grd.Columns[0].HeaderText = "Nº de reporte";
            grd.Columns[1].HeaderText = "Entrega";
            grd.Columns[2].HeaderText = "Recibe";
            grd.Columns[3].HeaderText = "Base Operativa";
            grd.Columns[4].HeaderText = "Hora";

            grd.Columns[5].HeaderText = "Fecha";
            // Format for the data column
            grd.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (buscar_por.SelectedIndex == 0)
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                //Query
                string str = "select no_reporte, conductor_entrega, conductor_recibe, unidad_operativa, hora, fecha from datos_generales where no_reporte = " + numero_reporte.Value.ToString();
                cmd.CommandText = str;
                cmd.Connection = main.cn;
                grd.Rows.Clear(); //Grid Rows are always cleared
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    grd.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
                dr.Close();
            }   
            else if(buscar_por.SelectedIndex == 1)
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                //Query
                string str = "select no_reporte, conductor_entrega, conductor_recibe, unidad_operativa, hora, fecha from datos_generales where fecha = '" + fecha.Value.Date + "'";
                cmd.CommandText = str;
                cmd.Connection = main.cn;
                grd.Rows.Clear(); //Grid Rows are always cleared
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    grd.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
                dr.Close();
            }
        }
    }
}
