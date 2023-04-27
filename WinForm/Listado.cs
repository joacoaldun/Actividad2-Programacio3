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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
          
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            MenuInicio principal = new MenuInicio();
            principal.Hide();



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
