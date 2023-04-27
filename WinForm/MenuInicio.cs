using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MenuInicio : Form
    {
        public MenuInicio()
        {
            InitializeComponent();
          
        }

        private void btnListado_Click(object sender, EventArgs e)
        {

            this.Hide();
            Listado listado= new Listado();
            listado.ShowDialog();
            this.Close();











        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
