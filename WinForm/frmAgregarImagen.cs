using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class frmAgregarImagen : Form
    {
        private Articulo articulo = null;

        public frmAgregarImagen()
        {
            InitializeComponent();
        }

        public frmAgregarImagen(Articulo art)
        {
            InitializeComponent();
            this.articulo = art;
            pbUrl2.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            lbNombre.Text = articulo.Nombre.ToString();
            

        }

        private void frmAgregarImagen_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                articulo.imagenes = new List<string>();
                articulo.imagenes.Add(txtUrl2.Text);

                articuloNegocio.AgregarMasImagenes(articulo.Id, txtUrl2.Text);
                MessageBox.Show("Imagen agregada exitosamente");

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUrl2_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl2.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbUrl2.Load(imagen);
            }
            catch (Exception)
            {
                pbUrl2.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }

        }



    }
}
