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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)// NO TE PERMITE ABRIR MAS VECES LA MISMA VENTANA SI ESTA ESTA ABIERTA
            {
                if (item.GetType() == typeof(MenuInicio))
                {

                    MessageBox.Show("YA EXISTE ESA VENTANA ABIERTA, TERMINE DE TRABAJAR ALLI");
                    return;
                }
            }

            MenuInicio ventana = new MenuInicio();
            ventana.MdiParent = this;
            ventana.Show(); // EL SHOWDIALOG NO FUNCIONA CON EL MDIPARENT
        }


    }
    
}
