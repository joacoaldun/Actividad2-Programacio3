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

        //VALIDACIONES
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if ((char.IsNumber(caracter)))
                    return true;
            }
            return false;
        }

        private bool validarAgregarModificar()
        {   
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text) || cbxMarca.SelectedIndex<0 || cbxCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor ingresá los campos obligatorios");
                return false;
            }

            if (!soloNumeros(txtPrecio.Text))
            {
                MessageBox.Show("Solo se aceptan números para filtrar un campo numerico");
                return false;
            }

            return true;
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

            //if (validarAgregarModificar())
            
                try
                {
                    if (validarAgregarModificar())
                    {

                    articulo.CodigoArticulo = txtCodigo.Text;

                    articulo.Nombre = txtNombre.Text;

                    articulo.Descripcion = txtDescripcion.Text;

                    articulo.Precio = decimal.Parse(txtPrecio.Text);

                    articulo.Marcas = (Marca)cbxMarca.SelectedItem;

                    articulo.Categorias = (Categoria)cbxCategoria.SelectedItem;


                    if (lista.Count == 0)
                    {
                        articulo.imagenes = new List<string>();
                        articulo.imagenes.Add(txtUrlImagenes.Text);
                    }
                    else
                    {
                        articulo.imagenes = lista;
                    }





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

           

            //Validamos que el textbox tenga algo cargado para agregarlo a la lista, si no no lo agregamos
            if (!string.IsNullOrEmpty(txtUrlImagenes.Text))
            {

                lista.Add(txtUrlImagenes.Text);

                url = lista[posicionLeave];
                urlEscapada = Uri.EscapeUriString(url);

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
                    posicionLeave++;
                    //posicionLeave ++;
                }
                catch (Exception ex)
                {
                    // Construir la ruta de la imagen de respaldo 
                    string rutaImagenRespaldo = Path.Combine(Application.StartupPath, "placeHolder.jpg");

                    // Cargar la imagen 
                    pbxImagen.Image = Image.FromFile(rutaImagenRespaldo);// Si ocurre un error al descargar la imagen, cargar una imagen de respaldo

                }

              

            }


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
            
            txtUrlImagenes.Clear();
            
        }

        private void btnModificarImagen_Click(object sender, EventArgs e)
        {
           
        }
    }



}
