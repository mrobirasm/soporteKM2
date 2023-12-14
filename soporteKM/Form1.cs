using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soporteKM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Obtener el serial del ordenador
            string serial = ObtenerSerialOrdenador();

            // Mostrar el serial en el Label
            labelSerial.Text = serial;
        }

        private string ObtenerSerialOrdenador()
        {
            string serial = "";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    serial = obj["SerialNumber"].ToString();
                    break; // Solo obtenemos el primer resultado
                }

                // Agrega una declaración de depuración
                //MessageBox.Show("Serial obtenido: " + serial);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el serial del ordenador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return serial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Obtener el serial del ordenador
            string serial = ObtenerSerialOrdenador();

            // Mostrar el serial en el Label
            labelSerial.Text = serial;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cierra la ventana Actual
            this.Close();
        }

        private void btnSolicitarSoporte_Click(object sender, EventArgs e)
        {
            // Establece la visibilidad de los controles
            labelProgreso.Visible = true;
            progressBar1.Visible = true;

            // Detección de arquitectura del sistema
            string url;
            string programaDescargado;

            if (Environment.Is64BitOperatingSystem)
            {
                url = "https://download.teamviewer.com/download/TeamViewerQS_x64.exe";
                programaDescargado = "TeamViewerQS_x64.exe";
            }
            else
            {
                url = "https://download.teamviewer.com/download/TeamViewerQS.exe";
                programaDescargado = "TeamViewerQS.exe";
            }

            // Descarga del archivo
            string carpetaTemporal = Path.GetTempPath();
            string rutaDescarga = Path.Combine(carpetaTemporal, programaDescargado);

            using (WebClient client = new WebClient())
            {
                client.DownloadFileCompleted += (s, args) =>
                {
                    // Ejecución del programa descargado
                    EjecutarProgramaDescargado(rutaDescarga);

                    // Eliminar el archivo descargado después de ejecutarlo (opcional)
                    // File.Delete(rutaDescarga);
                };

                // Muestra la barra de progreso y la etiqueta
                progressBar1.Visible = true;
                labelProgreso.Visible = true;

                client.DownloadProgressChanged += (s, args) =>
                {
                    // Actualiza la barra de progreso
                    progressBar1.Value = args.ProgressPercentage;
                    labelProgreso.Text = $"Descargando... {args.ProgressPercentage}%";
                };

                // Descarga el archivo
                client.DownloadFileAsync(new Uri(url), rutaDescarga);
            }
        }

        private void EjecutarProgramaDescargado(string rutaArchivo)
        {
            // Ejecuta el programa descargado
            Process.Start(rutaArchivo);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelProgreso_Click(object sender, EventArgs e)
        {

        }
    }
}
