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

namespace WinForm
{
    public partial class Listado : Form
    {

        List<Articulo> listaArticulos = new List<Articulo>();
        

        public Listado()
        {
            InitializeComponent();
          
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            MenuInicio principal = new MenuInicio();
            principal.Hide();



            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvListaArticulos.DataSource = listaArticulos;
           //dgvListaArticulos.Columns["imagen"].Visible = false;
            //cargarImagen(Listapokemon[0].UrlImagen);




        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuInicio listado = new MenuInicio();
            listado.ShowDialog();
            this.Close();
        }
    }
}
