using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForm
{
    public partial class AgregarArticulo : Form
    {
        
        private Articulo articulo = null;
        private List<string> lista = new List<string>();

        int posicionLeave = 0;
        public AgregarArticulo()
        {

            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//Limita el area para mover la ventana
            btnModificarImagen.Visible = false;
            
            //MOVER VENTANA                   
        
        }

        public AgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.articulo = articulo;
            txtUrlImagenes.Visible = false;
            lblUrl.Visible = false;
            btnAgregarImagen.Visible = false;
            label8.Text = "MODIFICAR ARTICULO";




        }

        //MOVER VENTANA
        //Para que el panel superior maneje el movimiento de la ventana

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Iparam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //CARGAR/MOSTRAR FORMULARIO
        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            string imagenUrl = "https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png\");\r\n            }";

            try
            {
                cbxMarca.DataSource = marcaNegocio.listar();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "NombreMarca";

                cbxCategoria.DataSource = categoriaNegocio.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "NombreCategoria";
              
                pbxImagen.Load(imagenUrl);

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.CodigoArticulo.ToString();
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtUrlImagenes.Text = articulo.imagenes[0].ToString();
                    cargarImagen(articulo.imagenes[0].ToString());
                    cbxCategoria.SelectedValue = articulo.Categorias.Id;
                    cbxMarca.SelectedValue = articulo.Marcas.Id;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
           
            try
            {
                articulo.CodigoArticulo = txtCodigo.Text;
                
                articulo.Nombre = txtNombre.Text;
                
                articulo.Descripcion = txtDescripcion.Text;

                articulo.Precio = decimal.Parse(txtPrecio.Text);    

                articulo.Marcas = (Marca)cbxMarca.SelectedItem;

                articulo.Categorias = (Categoria)cbxCategoria.SelectedItem;


                //CARGO TODAS LAS URLS EN UN MISMO TEXTBOX Y LAS SEPARO POR COMAS, LUEGO LAS GUARDO EN UN ARRAY.
                           
              if(lista.Count == 0)
                {
                     articulo.imagenes = new List<string>();
                     articulo.imagenes.Add(txtUrlImagenes.Text);
                }
              else 
                {
                    articulo.imagenes = lista;                
                }
              
                //string urlsText = txtUrlImagenes.Text;

                //string[] urls = urlsText.Split(',');

                // Agregar cada URL a la lista de URLs de Articulo
                //foreach (string url in urls)
                //{
                //CON EL METODO TRIM() QUITO LOS ESPACIOS QUE QUEDAN LUEGO DEL SPLIT
                //    string cleanUrl = url.Trim();
                //    articulo.imagenes.Add(cleanUrl);
                //}


                if (articulo.Id != 0)
                {
                    articuloNegocio.Modificar(articulo);
                    MessageBox.Show("Articulo modificado exitosamente");

                }
                else
                {
                    articuloNegocio.Agregar(articulo);
                    articuloNegocio.AgregarImagenes(articulo);
                    MessageBox.Show("Articulo agregado exitosamente");
                }

                Close();

               
              }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o un punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                // Cancelar el evento si la tecla no es un número o un punto decimal
                e.Handled = true;
            }
            // Si la tecla es un punto decimal, verificar que el TextBox no tenga ya un punto decimal
            else if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains('.'))
            {
                // Cancelar el evento si el TextBox ya tiene un punto decimal
                e.Handled = true;
            }
        }

        private void txtUrlImagenes_Leave(object sender, EventArgs e)
        {
            string url;
            string urlEscapada;

            if (posicionLeave == 0)
            { 
            url = txtUrlImagenes.Text;
            urlEscapada = Uri.EscapeUriString(url);
            }
            else {
                url = lista[posicionLeave].ToString();
                urlEscapada = Uri.EscapeUriString(url);
            }   
            
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var imagenDescargada = webClient.DownloadData(urlEscapada);
                    using (var stream = new MemoryStream(imagenDescargada))
                    {
                        pbxImagen.Image = Image.FromStream(stream);
                    }
                }

                posicionLeave += 1;
            }
            catch (Exception ex)
            {
                // Construir la ruta de la imagen de respaldo 
                string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpeg");

                // Cargar la imagen 
                pbxImagen.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo


            }

            //Enviar mensaje a General

        }

        private void cargarImagen(string imagen)
        {

            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbxImagen.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }

        }

        private void btnSalirAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            lista.Add(txtUrlImagenes.Text);
            txtUrlImagenes.Clear();
            
            
        }

    }
}
