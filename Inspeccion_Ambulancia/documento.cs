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
            this.Text = "Reporte No. " + (frm1.grd.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
