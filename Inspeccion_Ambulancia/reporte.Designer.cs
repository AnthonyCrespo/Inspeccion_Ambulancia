﻿
namespace Inspeccion_Ambulancia
{
    partial class reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporte));
            this.Informe = new System.Windows.Forms.TabControl();
            this.Buscador = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pic_escudo = new System.Windows.Forms.PictureBox();
            this.pic_msp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grd = new System.Windows.Forms.DataGridView();
            this.buscar_por = new System.Windows.Forms.ComboBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.numero_reporte = new System.Windows.Forms.NumericUpDown();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.Informe.SuspendLayout();
            this.Buscador.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numero_reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // Informe
            // 
            this.Informe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Informe.Controls.Add(this.Buscador);
            this.Informe.Controls.Add(this.tabPage2);
            this.Informe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Informe.Location = new System.Drawing.Point(12, 12);
            this.Informe.Name = "Informe";
            this.Informe.SelectedIndex = 0;
            this.Informe.Size = new System.Drawing.Size(1285, 783);
            this.Informe.TabIndex = 0;
            // 
            // Buscador
            // 
            this.Buscador.Controls.Add(this.btn_buscar);
            this.Buscador.Controls.Add(this.numero_reporte);
            this.Buscador.Controls.Add(this.fecha);
            this.Buscador.Controls.Add(this.buscar_por);
            this.Buscador.Controls.Add(this.grd);
            this.Buscador.Controls.Add(this.label2);
            this.Buscador.Location = new System.Drawing.Point(4, 27);
            this.Buscador.Name = "Buscador";
            this.Buscador.Padding = new System.Windows.Forms.Padding(3);
            this.Buscador.Size = new System.Drawing.Size(1277, 752);
            this.Buscador.TabIndex = 0;
            this.Buscador.Text = "Buscador";
            this.Buscador.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pic_escudo);
            this.tabPage2.Controls.Add(this.pic_msp);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1277, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informe";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pic_escudo
            // 
            this.pic_escudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_escudo.Image = ((System.Drawing.Image)(resources.GetObject("pic_escudo.Image")));
            this.pic_escudo.Location = new System.Drawing.Point(1099, -7);
            this.pic_escudo.Name = "pic_escudo";
            this.pic_escudo.Size = new System.Drawing.Size(82, 92);
            this.pic_escudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_escudo.TabIndex = 9;
            this.pic_escudo.TabStop = false;
            // 
            // pic_msp
            // 
            this.pic_msp.Image = ((System.Drawing.Image)(resources.GetObject("pic_msp.Image")));
            this.pic_msp.Location = new System.Drawing.Point(94, -2);
            this.pic_msp.Name = "pic_msp";
            this.pic_msp.Size = new System.Drawing.Size(153, 77);
            this.pic_msp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_msp.TabIndex = 8;
            this.pic_msp.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 72);
            this.label1.TabIndex = 7;
            this.label1.Text = "DIRECCIÓN NACIONAL DE ATENCIÓN PREHOSPITALARIA\r\nINSPECCIÓN DIARIA AMBULANCIA SOPO" +
    "RTE VITAL AVANZADO\r\nCAMBIO DE TURNO\r\nMECÁNICO\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar por:";
            // 
            // grd
            // 
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Location = new System.Drawing.Point(189, 75);
            this.grd.Name = "grd";
            this.grd.RowHeadersWidth = 51;
            this.grd.RowTemplate.Height = 24;
            this.grd.Size = new System.Drawing.Size(925, 623);
            this.grd.TabIndex = 3;
            // 
            // buscar_por
            // 
            this.buscar_por.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buscar_por.FormattingEnabled = true;
            this.buscar_por.Items.AddRange(new object[] {
            "No. de Reporte",
            "Fecha"});
            this.buscar_por.Location = new System.Drawing.Point(132, 19);
            this.buscar_por.Name = "buscar_por";
            this.buscar_por.Size = new System.Drawing.Size(152, 26);
            this.buscar_por.TabIndex = 4;
            // 
            // fecha
            // 
            this.fecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha.CustomFormat = "";
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(312, 21);
            this.fecha.Margin = new System.Windows.Forms.Padding(4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(149, 24);
            this.fecha.TabIndex = 63;
            // 
            // numero_reporte
            // 
            this.numero_reporte.Location = new System.Drawing.Point(483, 21);
            this.numero_reporte.Name = "numero_reporte";
            this.numero_reporte.Size = new System.Drawing.Size(120, 24);
            this.numero_reporte.TabIndex = 64;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(626, 11);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(174, 42);
            this.btn_buscar.TabIndex = 65;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 807);
            this.Controls.Add(this.Informe);
            this.Name = "reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.reporte_Load);
            this.Informe.ResumeLayout(false);
            this.Buscador.ResumeLayout(false);
            this.Buscador.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numero_reporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Informe;
        private System.Windows.Forms.TabPage Buscador;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pic_escudo;
        private System.Windows.Forms.PictureBox pic_msp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.ComboBox buscar_por;
        private System.Windows.Forms.NumericUpDown numero_reporte;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Button btn_buscar;
    }
}