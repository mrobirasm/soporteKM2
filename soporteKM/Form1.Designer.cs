using System;

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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSolicitarSoporte = new System.Windows.Forms.Button();
            this.labelversion = new System.Windows.Forms.Label();
            this.btnComprobarVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerial.Location = new System.Drawing.Point(12, 23);
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
            // labelversion
            // 
            this.labelversion.AutoSize = true;
            this.labelversion.Location = new System.Drawing.Point(284, 144);
            this.labelversion.Name = "labelversion";
            this.labelversion.Size = new System.Drawing.Size(52, 13);
            this.labelversion.TabIndex = 4;
            this.labelversion.Text = "lblVersion";
            this.labelversion.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnComprobarVersion
            // 
            this.btnComprobarVersion.Location = new System.Drawing.Point(62, 127);
            this.btnComprobarVersion.Name = "btnComprobarVersion";
            this.btnComprobarVersion.Size = new System.Drawing.Size(147, 23);
            this.btnComprobarVersion.TabIndex = 5;
            this.btnComprobarVersion.Text = "Nueva Version";
            this.btnComprobarVersion.UseVisualStyleBackColor = true;
            this.btnComprobarVersion.Visible = false;
            this.btnComprobarVersion.Click += new System.EventHandler(this.btnComprobarVersion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 162);
            this.Controls.Add(this.btnComprobarVersion);
            this.Controls.Add(this.labelversion);
            this.Controls.Add(this.btnSolicitarSoporte);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.labelSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SoporteKM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnSolicitarSoporte;
        private System.Windows.Forms.Label labelversion;
        private System.Windows.Forms.Button btnComprobarVersion;
    }
}

