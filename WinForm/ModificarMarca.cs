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
    public partial class ModificarMarca : Form

    {   
        MarcaNegocio negocio=new MarcaNegocio();
        private string marca;
        private int id;

        public ModificarMarca()
        {
            InitializeComponent();

        }

        public ModificarMarca(string marca, int id)
        {
            InitializeComponent();
            this.marca = marca;
            this.id = id;
        }

        private void ModificarMarca_Load(object sender, EventArgs e)
        {
            txtMarcaModif.Text= marca;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMarcaModif.Text))
            {

                negocio.modificar(id, txtMarcaModif.Text);
                MessageBox.Show("La marca se ha modificado correctamente");
                this.Close();

            }
            else
            {

                MessageBox.Show("Ingresá los campos requeridos");


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
