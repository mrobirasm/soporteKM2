﻿namespace soporteKM
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
            this.labelSerial = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSolicitarSoporte = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgreso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerial.Location = new System.Drawing.Point(110, 33);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(70, 26);
            this.labelSerial.TabIndex = 0;
            this.labelSerial.Text = "serial";
            this.labelSerial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelSerial.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(201, 98);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSolicitarSoporte
            // 
            this.btnSolicitarSoporte.Location = new System.Drawing.Point(62, 98);
            this.btnSolicitarSoporte.Name = "btnSolicitarSoporte";
            this.btnSolicitarSoporte.Size = new System.Drawing.Size(118, 23);
            this.btnSolicitarSoporte.TabIndex = 2;
            this.btnSolicitarSoporte.Text = "Solicitar soporte";
            this.btnSolicitarSoporte.UseVisualStyleBackColor = true;
            this.btnSolicitarSoporte.Click += new System.EventHandler(this.btnSolicitarSoporte_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(62, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 10);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // labelProgreso
            // 
            this.labelProgreso.AutoSize = true;
            this.labelProgreso.Location = new System.Drawing.Point(152, 129);
            this.labelProgreso.Name = "labelProgreso";
            this.labelProgreso.Size = new System.Drawing.Size(35, 13);
            this.labelProgreso.TabIndex = 4;
            this.labelProgreso.Text = "label1";
            this.labelProgreso.Visible = false;
            this.labelProgreso.Click += new System.EventHandler(this.labelProgreso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Número de serie";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSolicitarSoporte);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.labelSerial);
            this.Name = "Form1";
            this.Text = "SoporteKM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnSolicitarSoporte;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgreso;
        private System.Windows.Forms.Label label1;
    }
}
