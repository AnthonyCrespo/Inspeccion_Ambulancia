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
    public partial class main : Form
    {
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            string str = "Server = 127.0.0.1;Port = 5432; Database=prueba_ambulancia; User Id = postgres; Password = 1234;";
            cn.ConnectionString = str;
            cn.Open();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new inspeccion_ambulancia(), "Inspección de Ambulancia");
        }
    }
}
