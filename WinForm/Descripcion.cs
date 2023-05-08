using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Descripcion : Form
    {
        private Articulo articulo = null;
        //string rutaImagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1362px-Placeholder_view_vector.svg.png";
        string rutaImagen = "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";
        public Descripcion()
        {
            InitializeComponent();

        }

        public Descripcion(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//Limita el area para mover la ventana
        }

        private void Descripcion_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = articulo.CodigoArticulo;
            lblNombre.Text = articulo.Nombre;
            lblPrecio.Text = "$" + articulo.Precio.ToString();
            lblMarca.Text = articulo.Marcas.NombreMarca;
            lblCategoria.Text = articulo.Categorias.NombreCategoria;

            string url = articulo.imagenes[0];
            string urlEscapada = Uri.EscapeUriString(url);
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var imagenDescargada = webClient.DownloadData(urlEscapada);
                    using (var stream = new MemoryStream(imagenDescargada))
                    {
                        pcbArticulo.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception)
            {
                // Construir la ruta de la imagen de respaldo 
                //string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");
                //pcbArticulo.Load(rutaImagen);
                pcbArticulo.Load(rutaImagen);

                // Cargar la imagen 
                //pcbArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo


            }

            lblArticulo.Text = articulo.Nombre.ToUpper();
            rtbDescripcion.Text = articulo.Descripcion;



        }



        //MOVER VENTANA
        //Para que el panel superior maneje el movimiento de la ventana

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Iparam);

        private void pDescripcion_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void lblArticulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        //BOTONES
        int imagenActual = 0;
        private void btnIzquierda_Click_1(object sender, EventArgs e)
        {



            if (articulo.imagenes != null)
            {
                if (articulo.imagenes.Count > 0)
                {
                    imagenActual--;

                    if (imagenActual < 0)
                    {
                        imagenActual = articulo.imagenes.Count - 1;

                    }

                    string url = articulo.imagenes[imagenActual];
                    string urlEscapada = Uri.EscapeUriString(url);
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            var imagenDescargada = webClient.DownloadData(urlEscapada);
                            using (var stream = new MemoryStream(imagenDescargada))
                            {
                                pcbArticulo.Image = Image.FromStream(stream);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Construir la ruta de la imagen de respaldo 
                        string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                        // Cargar la imagen 
                        pcbArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo
                    }
                }

            }


        }

        private void btnDerecha_Click_1(object sender, EventArgs e)
        {



            if (articulo.imagenes != null)
            {
                if (articulo.imagenes.Count > 0)
                {
                    imagenActual++;
                    if (imagenActual >= articulo.imagenes.Count)
                    {
                        imagenActual = 0;


                    }
                    string url = articulo.imagenes[imagenActual];
                    string urlEscapada = Uri.EscapeUriString(url);
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            var imagenDescargada = webClient.DownloadData(urlEscapada);
                            using (var stream = new MemoryStream(imagenDescargada))
                            {
                                pcbArticulo.Image = Image.FromStream(stream);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Construir la ruta de la imagen de respaldo 
                        string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                        // Cargar la imagen 
                        pcbArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo
                    }


                }
            }




        }

      
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }



}
