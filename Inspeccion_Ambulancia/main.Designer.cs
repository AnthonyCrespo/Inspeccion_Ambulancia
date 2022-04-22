
namespace Inspeccion_Ambulancia
{
    partial class main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.btn_1 = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_escudo = new System.Windows.Forms.PictureBox();
            this.pic_msp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_1
            // 
            this.btn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.Location = new System.Drawing.Point(308, 216);
            this.btn_1.Name = "btn_1";
            this.btn_1.Padding = new System.Windows.Forms.Padding(1);
            this.btn_1.Size = new System.Drawing.Size(309, 49);
            this.btn_1.TabIndex = 0;
            this.btn_1.Text = "Inspección de Ambulancia";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // btn_2
            // 
            this.btn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2.Location = new System.Drawing.Point(308, 287);
            this.btn_2.Name = "btn_2";
            this.btn_2.Padding = new System.Windows.Forms.Padding(1);
            this.btn_2.Size = new System.Drawing.Size(309, 49);
            this.btn_2.TabIndex = 1;
            this.btn_2.Text = "Observar reporte";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 72);
            this.label1.TabIndex = 17;
            this.label1.Text = "DIRECCIÓN NACIONAL DE ATENCIÓN PREHOSPITALARIA\r\nINSPECCIÓN DIARIA AMBULANCIA SOPO" +
    "RTE VITAL AVANZADO\r\nCAMBIO DE TURNO\r\nMECÁNICO\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic_escudo
            // 
            this.pic_escudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_escudo.BackColor = System.Drawing.Color.Transparent;
            this.pic_escudo.Image = ((System.Drawing.Image)(resources.GetObject("pic_escudo.Image")));
            this.pic_escudo.Location = new System.Drawing.Point(789, 9);
            this.pic_escudo.Name = "pic_escudo";
            this.pic_escudo.Size = new System.Drawing.Size(68, 80);
            this.pic_escudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_escudo.TabIndex = 16;
            this.pic_escudo.TabStop = false;
            // 
            // pic_msp
            // 
            this.pic_msp.BackColor = System.Drawing.Color.Transparent;
            this.pic_msp.Image = ((System.Drawing.Image)(resources.GetObject("pic_msp.Image")));
            this.pic_msp.Location = new System.Drawing.Point(23, 9);
            this.pic_msp.Name = "pic_msp";
            this.pic_msp.Size = new System.Drawing.Size(159, 72);
            this.pic_msp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_msp.TabIndex = 15;
            this.pic_msp.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_escudo);
            this.Controls.Add(this.pic_msp);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.btn_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspección Diaria Ambulancia";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_escudo;
        private System.Windows.Forms.PictureBox pic_msp;
    }
}

