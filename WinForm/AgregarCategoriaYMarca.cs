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
    public partial class AgregarCategoriaYMarca : Form
    {
        List<Marca> listaMarcas = new List<Marca>();
        List<Categoria> listaCategorias=new List<Categoria>();
        
        public AgregarCategoriaYMarca()
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
            List<Categoria> listaCategorias = new List<Categoria>();
            Categoria categoria = new Categoria();


            try
            {   
               
                marca.NombreMarca = txtAgregarMarca.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            if (!string.IsNullOrEmpty(txtAgregarMarca.Text))
            {
                negocio.agregar(marca);
                MessageBox.Show("¡Marca: " + txtAgregarMarca.Text + " agregada con exito!");
                txtAgregarMarca.Clear();
                cargar();

            }
            else
            {
                MessageBox.Show("Ingrese el campo requerido");
            }
           

        }

        private void cargar() {

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
     


            //Traemos el metodo listar tanto de MarcaNegocio como de CategoriaNegocio

            listaMarcas = marcaNegocio.listar();
            listaCategorias = categoriaNegocio.listar();
            dgvCategorias.DataSource = listaCategorias;
            dgvMarcas.DataSource = listaMarcas;
            

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
            if (!string.IsNullOrEmpty(txtAgregarCategoria.Text))
            {
                negocio.agregar(categoria);
                MessageBox.Show("¡Categoria: " + txtAgregarCategoria.Text + " agregada con exito!");
                txtAgregarCategoria.Clear();
                cargar();
            }
            else
            {
                MessageBox.Show("Ingrese el campo requerido");
            }

        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio=new MarcaNegocio();
            Marca seleccionada;


            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro que desea eliminarla?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionada.Id);
                    cargar();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
           Marca seleccionada;
           ModificarMarca modif;
           MarcaNegocio negocio = new MarcaNegocio();


            try
            {

                seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

                string nuevoNombre = seleccionada.NombreMarca;
                modif=new ModificarMarca(nuevoNombre, seleccionada.Id);
                modif.ShowDialog();
                listaMarcas = negocio.listar();
                          
                dgvMarcas.DataSource = listaMarcas;
                cargar();
               


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            Categoria seleccionada;
            ModificarCategoria modif;
            CategoriaNegocio negocio = new CategoriaNegocio();


            try
            {

                seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                string nuevoNombre = seleccionada.NombreCategoria;
                modif = new ModificarCategoria(nuevoNombre, seleccionada.Id);
                modif.ShowDialog();
                listaCategorias = negocio.listar();

                dgvMarcas.DataSource = listaCategorias;
                cargar();



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria seleccionada;


            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro que desea eliminarla?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionada.Id);
                    cargar();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
