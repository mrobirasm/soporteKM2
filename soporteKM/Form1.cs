using System;
using System.Configuration;
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

            // Configuración para ocultar la barra de título
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;  // o cualquier otro estilo de borde que desees
            MaximizeBox = false; // Deshabilitar el botón de maximizar



        }

        // Configuración de la aplicación
        private string ObtenerVersionActual()
        {
            return ConfigurationManager.AppSettings["Version"];
        }
        
        private string ObtenerUrlInstalador()
        {
            return ConfigurationManager.AppSettings["UrlInstalador"];
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
            // Al cargar el formulario, comprueba si hay un archivo en la URL y ajusta la visibilidad del botón
            btnComprobarVersion.Visible = ExisteArchivoEnURL(ObtenerUrlInstalador());


            // Obtén la versión desde el archivo de configuración
            string version = ConfigurationManager.AppSettings["Version"];

            // Muestra la versión en el Label
            labelversion.Text = "v" + version;

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

        private bool ExisteArchivoEnURL(string url)
        {
            try
            {
                // Intenta realizar una solicitud HEAD para verificar la existencia del archivo
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                // Si ocurre una excepción, asumimos que el archivo no existe
                return false;
            }
        }


        private void btnComprobarVersion_Click(object sender, EventArgs e)
        {
            string url = ObtenerUrlInstalador();
            string destino = Path.Combine(Path.GetTempPath(), "installsoporteKM.msi");

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Intenta descargar el archivo a la carpeta temporal
                    client.DownloadFile(url, destino);

                    // Si llega a este punto, la descarga fue exitosa

                    // Puedes ejecutar el archivo descargado aquí si es necesario
                    Process.Start(destino);

                    // Cerrar la aplicación actual
                    Application.Exit();


                    //MessageBox.Show("La descarga y ejecución fueron exitosas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (WebException webEx)
            {
                // Si ocurre una excepción, significa que la descarga falló
                if (webEx.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.NotFound)
                {
                    // El archivo no existe en la URL especificada
                    MessageBox.Show("No hay nuevas versiones disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al intentar comprobar la versión: " + webEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
