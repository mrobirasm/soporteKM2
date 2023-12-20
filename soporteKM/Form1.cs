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
            try
            {
                // Ruta completa al archivo ejecutable de TeamViewerQS_x64.exe
                string teamViewerPath =  Environment.CurrentDirectory +"\\App\\TeamViewerQS_x64.exe";

                // Agrega una declaración de depuración
                //MessageBox.Show("Serial obtenido: " + teamViewerPath);

                // Verifica si el archivo existe antes de intentar ejecutarlo
                if (System.IO.File.Exists(teamViewerPath))
                {
                    // Crea un proceso para ejecutar el programa externo
                    Process.Start(teamViewerPath);
                }
                else
                {
                    MessageBox.Show("El programa TeamViewerQS_x64.exe no se encuentra en la ubicación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ejecutar TeamViewer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
