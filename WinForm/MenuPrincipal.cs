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

namespace WinForm
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//Limita el area para mover la ventana
        }


        //Para que el panel superior maneje el movimiento de la ventana
         
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Iparam);



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "ARTICULOS";
            List<Form> formsACerrar = new List<Form>();

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Home))
                {   //Convertimos el item a form para poder agregarlo a la lista de FormsAcerrar
                    Form form = item as Form; 
                    if (form != null)
                    {
                        formsACerrar.Add(form); 
                    }
                }
                else if (item.GetType() == typeof(Listado))
                {
                    MessageBox.Show("YA EXISTE ESTA VENTANA ABIERTA");
                    return;
                }
            }

            foreach (Form form in formsACerrar)
            {   //Cerramos formularios que estan en la lista
                form.Close(); 
            }

           

            Listado ventana = new Listado();
            ventana.MdiParent = this;
            ventana.Show(); // EL SHOWDIALOG NO FUNCIONA CON EL MDIPARENT
            

        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Home ventana = new Home();
            ventana.MdiParent = this;
            ventana.Show(); // EL SHOWDIALOG NO FUNCIONA CON EL MDIPARENT
        }
        //MANEJO DE VENTANA
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //BOTONES
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMacimiced_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState=FormWindowState.Maximized;
            }
            else
            {
                this.WindowState=FormWindowState.Normal;
            }
        }

        private void btnMinimiced_Click(object sender, EventArgs e)
        {
           
                this.WindowState = FormWindowState.Minimized;
            
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "MENU PRINCIPAL";
            List<Form> formsACerrar = new List<Form>();

            foreach (var item in Application.OpenForms)
            {  //Convertimos el item a form para poder agregarlo a la lista de FormsAcerrar
                if (item.GetType() == typeof(Listado))
                {
                    Form form = item as Form; 
                    if (form != null)
                    {
                        formsACerrar.Add(form); 
                    }
                }
                else if (item.GetType() == typeof(Home))
                {
                    MessageBox.Show("YA EXISTE ESTA VENTANA ABIERTA");
                    return;
                }
            }

            foreach (Form form in formsACerrar)
            {   //Cerramos el formulario agregado a la lista
                form.Close(); 
            }

            Home ventana = new Home();
            ventana.MdiParent = this;
            ventana.Show(); // EL SHOWDIALOG NO FUNCIONA CON EL MDIPARENT
        }

       
    }
    
}
