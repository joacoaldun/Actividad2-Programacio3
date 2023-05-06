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
    public partial class AgregarMarcaYCategoria : Form
    {
        List<Marca> listaMarcas = new List<Marca>();
        List<Categoria> listaCategorias = new List<Categoria>();
        public AgregarMarcaYCategoria()
        {
            InitializeComponent();
        }

        private void AgregarMarcaYCategoria_Load(object sender, EventArgs e)
        {
            cargar();



        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Marca marca = new Marca();


            try
            {
                marca.NombreMarca = txtAgregarMarca.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            negocio.agregar(marca);
            MessageBox.Show("¡Marca: " + txtAgregarMarca.Text + " agregada con exito!");
            cargar();

        }

        private void cargar() {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();


            //Traemos el metodo listar tanto de MarcaNegocio como de CategoriaNegocio

            listaMarcas = marcaNegocio.listar();
            listaCategorias = categoriaNegocio.listar();

            dgvMarcas.DataSource = listaMarcas;
            dgvCategorias.DataSource = listaCategorias;

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();


            try
            {
                categoria.NombreCategoria = txtAgregarCategoria.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            negocio.agregar(categoria);
            MessageBox.Show("¡Categoria: " + txtAgregarCategoria.Text + " agregada con exito!");
            cargar();

        }
    }
}
