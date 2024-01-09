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
using System.Reflection;

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
        //private string ObtenerVersionActual()
        //{
        //    return ConfigurationManager.AppSettings["Version"];
        //}
        
        private void Label1_Click(object sender, EventArgs e)
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

                foreach (ManagementObject obj in collection.Cast<ManagementObject>())
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
            string baseUrl = ConfigurationManager.AppSettings["UrlUpdate"]; // Declaramos la variable baseURL extraida del fichero de configuración
            string installUrl = $"{baseUrl}/downloads/soporteKM/installsoporteKM.msi"; // Declaramos la ruta y nombre del fichero de instalación
            string versionUrl = $"{baseUrl}/downloads/soporteKM/version"; // Declaramos la ruta y nombre del fichero que indica que version esta publicada

            
            btnComprobarVersion.Visible = EsNuevaVersionDisponible(versionUrl) && ExisteArchivoEnURL(installUrl);  


            // Obtén la versión desde el archivo de configuración
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Muestra la versión en el Label
            labelversion.Text = "v" + version;

            // Obtener el serial del ordenador
            string serial = ObtenerSerialOrdenador();

            // Mostrar el serial en el Label
            labelSerial.Text = serial;
        }





        private void BtnSolicitarSoporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta completa al archivo ejecutable de TeamViewerQS.exe
                string teamViewerPath =  Environment.CurrentDirectory +"\\App\\TeamViewerQS.exe";

                // Verifica si el archivo existe antes de intentar ejecutarlo
                if (System.IO.File.Exists(teamViewerPath))
                {
                    // Crea un proceso para ejecutar el programa externo
                    Process.Start(teamViewerPath);
                }
                else
                {
                    MessageBox.Show("El programa TeamViewerQS.exe no se encuentra en la ubicación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool EsNuevaVersionDisponible(string versionUrl)
        {
            // Ruta local del archivo "version"
            //string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string rutaArchivoVersion = Path.Combine(Path.GetTempPath(), "version");

            // Descargar el archivo "version" desde la URL
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(versionUrl, rutaArchivoVersion);
                }
            }
            catch (WebException)
            {
                // Si ocurre una excepción, asumimos que el archivo "version" no existe
                return false;
            }

            // Leer el contenido del archivo "version"
            string versionEnArchivo = File.ReadAllText(rutaArchivoVersion);

            // Obtener la versión actual de la aplicación
            Version versionActual = new Version(Application.ProductVersion);



            // Obtener la versión del archivo "version"
            if (Version.TryParse(versionEnArchivo, out Version versionEnArchivoObjeto))
            {
                // Comparar las versiones
                return versionEnArchivoObjeto > versionActual;
            }

            return false;
        }


        private void BtnComprobarVersion_Click(object sender, EventArgs e)
        {
            string baseUrl = ConfigurationManager.AppSettings["UrlUpdate"];
            string installUrl = $"{baseUrl}/installsoportekm.msi";
            string destino = Path.Combine(Path.GetTempPath(), "installsoportekm.msi");

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Intenta descargar el archivo a la carpeta temporal
                    client.DownloadFile(installUrl, destino);

                    // Si llega a este punto, la descarga fue exitosa

                    // Ejecutar el archivo descargado
                    Process.Start(destino);

                    // Cerrar la aplicación actual
                    Application.Exit();
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
