using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        public AgregarArticulo()
        {
            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//Limita el area para mover la ventana
            //MOVER VENTANA
            
         
            
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
            try
            {
              cbxMarca.DataSource = marcaNegocio.listar();
              cbxMarca.ValueMember = "Id";
              cbxMarca.DisplayMember = "NombreMarca";

              cbxCategoria.DataSource = categoriaNegocio.listar();
              cbxCategoria.ValueMember = "Id";
              cbxCategoria.DisplayMember = "NombreCategoria";
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
                articulo.imagenes = new List<string>();
                articulo.imagenes.Add(txtUrlImagenes.Text);
                
                
                //string urlsText = txtUrlImagenes.Text;
                
                //string[] urls = urlsText.Split(',');
               
                // Agregar cada URL a la lista de URLs de Articulo
                //foreach (string url in urls)
                //{
                    //CON EL METODO TRIM() QUITO LOS ESPACIOS QUE QUEDAN LUEGO DEL SPLIT
                //    string cleanUrl = url.Trim();
                //    articulo.imagenes.Add(cleanUrl);
                //}







                articuloNegocio.Agregar(articulo);
                articuloNegocio.AgregarImagenes(articulo);
                MessageBox.Show("Articulo agregado exitosamente");
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
            cargarImagen(txtUrlImagenes.Text);
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
    }
}
