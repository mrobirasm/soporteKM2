using System;
using System.Drawing;
using System.Windows.Forms;

namespace soporteKM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelSerial = new System.Windows.Forms.Label();
            this.btnSolicitarSoporte = new System.Windows.Forms.Button();
            this.labelversion = new System.Windows.Forms.Label();
            this.btnComprobarVersion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSerial
            // 
            this.labelSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerial.Location = new System.Drawing.Point(18, 139);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(331, 32);
            this.labelSerial.TabIndex = 0;
            this.labelSerial.Text = "serial";
            this.labelSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSerial.Click += new System.EventHandler(this.Label1_Click);
            // 
            // btnSolicitarSoporte
            // 
            this.btnSolicitarSoporte.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSolicitarSoporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSolicitarSoporte.FlatAppearance.BorderSize = 0;
            this.btnSolicitarSoporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarSoporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitarSoporte.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarSoporte.Location = new System.Drawing.Point(17, 243);
            this.btnSolicitarSoporte.Name = "btnSolicitarSoporte";
            this.btnSolicitarSoporte.Size = new System.Drawing.Size(331, 32);
            this.btnSolicitarSoporte.TabIndex = 2;
            this.btnSolicitarSoporte.Text = "Espera a que se abra la aplicación de soporte.";
            this.btnSolicitarSoporte.UseVisualStyleBackColor = false;
            this.btnSolicitarSoporte.Click += new System.EventHandler(this.BtnSolicitarSoporte_Click);
            // 
            // labelversion
            // 
            this.labelversion.AutoSize = true;
            this.labelversion.Location = new System.Drawing.Point(296, 60);
            this.labelversion.Name = "labelversion";
            this.labelversion.Size = new System.Drawing.Size(52, 13);
            this.labelversion.TabIndex = 4;
            this.labelversion.Text = "lblVersion";
            this.labelversion.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnComprobarVersion
            // 
            this.btnComprobarVersion.BackColor = System.Drawing.Color.IndianRed;
            this.btnComprobarVersion.FlatAppearance.BorderSize = 0;
            this.btnComprobarVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobarVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobarVersion.ForeColor = System.Drawing.Color.White;
            this.btnComprobarVersion.Location = new System.Drawing.Point(17, 197);
            this.btnComprobarVersion.Margin = new System.Windows.Forms.Padding(0);
            this.btnComprobarVersion.Name = "btnComprobarVersion";
            this.btnComprobarVersion.Padding = new System.Windows.Forms.Padding(3);
            this.btnComprobarVersion.Size = new System.Drawing.Size(331, 32);
            this.btnComprobarVersion.TabIndex = 5;
            this.btnComprobarVersion.Text = "Nueva Versión";
            this.btnComprobarVersion.UseVisualStyleBackColor = false;
            this.btnComprobarVersion.Visible = false;
            this.btnComprobarVersion.Click += new System.EventHandler(this.BtnComprobarVersion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::soporteKM.Properties.Resources.logo_konica;
            this.pictureBox1.Image = global::soporteKM.Properties.Resources.logo_konica;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Número de serie:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 230);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(331, 5);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(367, 287);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelversion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnComprobarVersion);
            this.Controls.Add(this.btnSolicitarSoporte);
            this.Controls.Add(this.labelSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SoporteKM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Button btnSolicitarSoporte;
        private System.Windows.Forms.Label labelversion;
        private System.Windows.Forms.Button btnComprobarVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ProgressBar progressBar1;
    }
}

