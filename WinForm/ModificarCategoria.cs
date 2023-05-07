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
    public partial class ModificarCategoria : Form
    {
        CategoriaNegocio negocio = new CategoriaNegocio();
        private string categoria;
        private int id;

        public ModificarCategoria()
        {
            InitializeComponent();
        }


        public ModificarCategoria(string marca, int id)
        {
            InitializeComponent();
            this.categoria = marca;
            this.id = id;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoriaModif.Text))
            {

                negocio.modificar(id, txtCategoriaModif.Text);
                MessageBox.Show("La marca se ha modificado correctamente");
                this.Close();

            }
            else
            {

                MessageBox.Show("Ingresá los campos requeridos");


            }
        }

        private void ModificarCategoria_Load(object sender, EventArgs e)
        {
            txtCategoriaModif.Text = categoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
