using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using System.IO;
using System.Net;

namespace WinForm
{
    public partial class Listado : Form
    {

        List<Articulo> listaArticulos = new List<Articulo>();

        public Listado()
        {

            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }
       
        
        //INICIALIZAMOS INDICE
        private int indiceImagenActual;
        private int imagenActual = 0;

        //LOAD DE LISTADO
        private void Listado_Load(object sender, EventArgs e)
        {
            cargar();
        }

        //CARGAMOS IMAGEN EN PBX
        private void cargarImagen(string imagen)
        {
            try
            {
                
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");


            }

        }

        //CAMBIA DE IMAGEN SEGUN FILA
        
        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaArticulos.CurrentRow != null)
            {
                int rowIndex = dgvListaArticulos.CurrentRow.Index;
                if (listaArticulos.Count > rowIndex && listaArticulos[rowIndex].imagenes.Count > 0)
                {
                    imagenActual = 0; // reiniciamos la imagen actual
                    string url = listaArticulos[rowIndex].imagenes[imagenActual];
                    string urlEscapada = Uri.EscapeUriString(url);
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            var imagenDescargada = webClient.DownloadData(urlEscapada);
                            using (var stream = new MemoryStream(imagenDescargada))
                            {
                                pbxArticulo.Image = Image.FromStream(stream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Construir la ruta de la imagen de respaldo 
                        string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                        // Cargar la imagen 
                        pbxArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo


                    }
                }
            }
        }



        //BOTONES
       


        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.CurrentRow != null)
            {
                int rowIndex = dgvListaArticulos.CurrentRow.Index;
                if (listaArticulos.Count > rowIndex && listaArticulos[rowIndex].imagenes.Count > 0)
                {
                    imagenActual--;
                    if (imagenActual < 0)
                    {
                        imagenActual = listaArticulos[rowIndex].imagenes.Count - 1;
                    }
                    string url = listaArticulos[rowIndex].imagenes[imagenActual];
                    string urlEscapada = Uri.EscapeUriString(url);
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            var imagenDescargada = webClient.DownloadData(urlEscapada);
                            using (var stream = new MemoryStream(imagenDescargada))
                            {
                                pbxArticulo.Image = Image.FromStream(stream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Construir la ruta de la imagen de respaldo 
                        string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                        // Cargar la imagen 
                        pbxArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo
                    }


                }
            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            

            if (dgvListaArticulos.CurrentRow != null)
            {
                int rowIndex = dgvListaArticulos.CurrentRow.Index;

                if (listaArticulos.Count > rowIndex && listaArticulos[rowIndex].imagenes.Count > 0)
                {
                    imagenActual++;
                    if (imagenActual >= listaArticulos[rowIndex].imagenes.Count)
                    {
                        imagenActual = 0;
                        
                        
                    }
                    string url = listaArticulos[rowIndex].imagenes[imagenActual];
                    string urlEscapada = Uri.EscapeUriString(url);
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            var imagenDescargada = webClient.DownloadData(urlEscapada);
                            using (var stream = new MemoryStream(imagenDescargada))
                            {
                                pbxArticulo.Image = Image.FromStream(stream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Construir la ruta de la imagen de respaldo 
                        string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                        // Cargar la imagen 
                        pbxArticulo.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo
                    }

                    
                }
            }
        }

        private void dgvListaArticulos_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("No hay nada por aqui...");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            AgregarArticulo agregarArticulo = new AgregarArticulo();
            agregarArticulo.ShowDialog();
            cargar();



            
        }

        private void cargar() {

            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();


            if (listaArticulos.Count > 0 && listaArticulos[0].imagenes.Count > 0)
            {
                string url = listaArticulos[0].imagenes[0];
                string urlEscapada = Uri.EscapeUriString(url);
                using (var webClient = new System.Net.WebClient())
                {
                    var imagenDescargada = webClient.DownloadData(urlEscapada);
                    using (var stream = new MemoryStream(imagenDescargada))
                    {
                        pbxArticulo.Image = Image.FromStream(stream);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay artículos o imágenes disponibles para mostrar.");
            }
            dgvListaArticulos.DataSource = listaArticulos;
            //dgvListaArticulos.Columns["Id"].Visible = false;


        }
    }
}
