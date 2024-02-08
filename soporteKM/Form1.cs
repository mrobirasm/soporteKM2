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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32;


namespace soporteKM
{
    public partial class Form1 : Form
    {

        private readonly System.Windows.Forms.ProgressBar progressBar;


        public Form1()
        {
            InitializeComponent();

            // Configuración para ocultar la barra de título
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;  // o cualquier otro estilo de borde que desees
            MaximizeBox = false; // Deshabilitar el botón de maximizar

            // Crear y configurar la barra de progreso
            progressBar = new System.Windows.Forms.ProgressBar
            {
                Size = new Size(331, 5),  // Ajustar el tamaño
                Location = new Point(17, 230),  // Ajustar las coordenadas
                Visible = false
            };




            // Agregar el botón al formulario
            Controls.Add(btnComprobarVersion);

            // Agregar la barra de progreso al formulario
            Controls.Add(progressBar);

            // Suscribir el evento Click del botón al método auxiliar
            btnComprobarVersion.Click += BtnComprobarVersion_Click;

            // Suscribir el evento Click del Label al método para copiar el serial
            labelSerial.Click += LabelSerial_Click;

            // Suscribir el evento Click del Label al método para copiar el nombre del host al portapapeles
            labelHostname.Click += LabelHostname_Click;

            
        }

        private void LabelSerial_Click(object sender, EventArgs e)
        {
            // Copiar el serial al portapapeles cuando se hace clic en el Label
            Clipboard.SetText(labelSerial.Text);
            MessageBox.Show("Serial copiado al portapapeles.");
        }

        private void LabelHostname_Click(object sender, EventArgs e)
        {
                     
            // Copiar el nombre del host al portapapeles cuando se hace clic en el Label
            Clipboard.SetText(labelHostname.Text);
            MessageBox.Show("Nombre del host copiado al portapapeles.");
        
        }


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

        private string ObtenerNombreHost()
        {
            // Obtener y retornar el nombre del host del equipo
            return System.Net.Dns.GetHostName();

        }

        private void Form1_Load(object sender, EventArgs e)

        {

            // Verificar si .NET Framework 4.7.2 está instalado
            if (!VerificarNETFramework472())
            {
                // Si no está instalado, ejecutar el instalador incluido en la carpeta de la aplicación
                string netFrameworkInstallerPath = Environment.CurrentDirectory + "\\App\\ndp472-kb4054530-x86-x64-allos-enu.exe";
                Process.Start(netFrameworkInstallerPath);
                return; // No es necesario continuar cargando la aplicación
            }

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

            // Obtener el hostname del ordenador
            string hostname = ObtenerNombreHost();

            // Mostrar el hostname en el label
            labelHostname.Text = hostname;


            // Ruta completa al archivo ejecutable de TeamViewerQS.exe
            string teamViewerPath = Environment.CurrentDirectory + "\\App\\TeamViewerQS.exe";

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

//        private string ObtenerNombreHost()
//        {
//            return System.Net.Dns.GetHostName();
//        }

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

        private bool VerificarNETFramework472()
        {
            try
            {
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                    .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
                {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    return releaseKey >= 461808;
                }
            }
            catch
            {
                return false;
            }
        }


        private async void BtnComprobarVersion_Click(object sender, EventArgs e)
        {
            string baseUrl = ConfigurationManager.AppSettings["UrlUpdate"];
            string installUrl = $"{baseUrl}/downloads/soporteKM/installsoporteKM.msi";
            string destino = Path.Combine(Path.GetTempPath(), "installsoporteKM.msi");

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Mostrar la barra de progreso
                    progressBar.Visible = true;

                    // Asociar el evento DownloadProgressChanged
                    client.DownloadProgressChanged += WebClientDownloadProgressChanged;

                    // Intenta descargar el archivo a la carpeta temporal
                    await client.DownloadFileTaskAsync(new Uri(installUrl), destino);

                    // Restablecer la visibilidad de la barra de progreso después de la descarga
                    progressBar.Visible = false;

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
                if (webEx.Response is HttpWebResponse response)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // El archivo no existe en la URL especificada
                        MessageBox.Show("No hay nuevas versiones disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Mostrar detalles adicionales sobre la excepción específica de WebException
                        MessageBox.Show($" 1 Error al intentar comprobar la versión: {webEx.Message}\nDetalles: {webEx.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar detalles adicionales sobre la excepción específica de WebException
                    //MessageBox.Show($"2 Error al intentar comprobar la versión: {webEx.Message}\nDetalles: {webEx.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Mostrar detalles adicionales sobre la excepción general
                MessageBox.Show($"3 Error general al intentar comprobar la versión: {ex.Message}\nDetalles: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }





        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Actualizar la barra de progreso durante la descarga
            progressBar.Value = e.ProgressPercentage;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
