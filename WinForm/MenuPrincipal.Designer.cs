namespace WinForm
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMarcasYCategorias = new System.Windows.Forms.Button();
            this.btnListado = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnMinimiced = new System.Windows.Forms.Button();
            this.btnMacimiced = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnMarcasYCategorias);
            this.panelMenu.Controls.Add(this.btnListado);
            this.panelMenu.Controls.Add(this.flowLayoutPanel1);
            this.panelMenu.Controls.Add(this.btnSalir);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(145, 557);
            this.panelMenu.TabIndex = 1;
            // 
            // btnMarcasYCategorias
            // 
            this.btnMarcasYCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMarcasYCategorias.FlatAppearance.BorderSize = 0;
            this.btnMarcasYCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcasYCategorias.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcasYCategorias.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMarcasYCategorias.Image = global::WinForm.Properties.Resources.icons8_search_20;
            this.btnMarcasYCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcasYCategorias.Location = new System.Drawing.Point(0, 174);
            this.btnMarcasYCategorias.Name = "btnMarcasYCategorias";
            this.btnMarcasYCategorias.Size = new System.Drawing.Size(145, 69);
            this.btnMarcasYCategorias.TabIndex = 2;
            this.btnMarcasYCategorias.Text = " Marcas y Categorias";
            this.btnMarcasYCategorias.UseVisualStyleBackColor = true;
            this.btnMarcasYCategorias.Click += new System.EventHandler(this.btnMarcasYCategorias_Click);
            // 
            // btnListado
            // 
            this.btnListado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnListado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListado.FlatAppearance.BorderSize = 0;
            this.btnListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListado.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnListado.Image = global::WinForm.Properties.Resources.icons8_regular_document_20;
            this.btnListado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListado.Location = new System.Drawing.Point(0, 127);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(145, 47);
            this.btnListado.TabIndex = 1;
            this.btnListado.Text = "Listado";
            this.btnListado.UseVisualStyleBackColor = false;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnHome);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 47);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHome.Image = global::WinForm.Properties.Resources.icons8_home_20;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(3, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(145, 47);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(34)))), ((int)(((byte)(101)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Image = global::WinForm.Properties.Resources.icons8_arrow_20;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 500);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 57);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(145, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(196)))), ((int)(((byte)(164)))));
            this.label2.Location = new System.Drawing.Point(45, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "M.G.";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelSuperior.Controls.Add(this.btnMinimiced);
            this.panelSuperior.Controls.Add(this.btnMacimiced);
            this.panelSuperior.Controls.Add(this.btnClose);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(145, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1015, 51);
            this.panelSuperior.TabIndex = 2;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // btnMinimiced
            // 
            this.btnMinimiced.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimiced.FlatAppearance.BorderSize = 0;
            this.btnMinimiced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimiced.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimiced.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnMinimiced.Image = global::WinForm.Properties.Resources.icons8_subtract_25;
            this.btnMinimiced.Location = new System.Drawing.Point(886, 8);
            this.btnMinimiced.Name = "btnMinimiced";
            this.btnMinimiced.Size = new System.Drawing.Size(38, 35);
            this.btnMinimiced.TabIndex = 5;
            this.btnMinimiced.UseVisualStyleBackColor = true;
            this.btnMinimiced.Click += new System.EventHandler(this.btnMinimiced_Click);
            // 
            // btnMacimiced
            // 
            this.btnMacimiced.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMacimiced.FlatAppearance.BorderSize = 0;
            this.btnMacimiced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMacimiced.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMacimiced.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnMacimiced.Image = global::WinForm.Properties.Resources.icons8_expand_25;
            this.btnMacimiced.Location = new System.Drawing.Point(930, 7);
            this.btnMacimiced.Name = "btnMacimiced";
            this.btnMacimiced.Size = new System.Drawing.Size(38, 35);
            this.btnMacimiced.TabIndex = 4;
            this.btnMacimiced.UseVisualStyleBackColor = true;
            this.btnMacimiced.Click += new System.EventHandler(this.btnMacimiced_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnClose.Image = global::WinForm.Properties.Resources.icons8_xbox_x_25;
            this.btnClose.Location = new System.Drawing.Point(974, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(385, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MENU PRINCIPAL";
            this.lblTitulo.Click += new System.EventHandler(this.label1_Click);
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1160, 557);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1160, 557);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMarcasYCategorias;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimiced;
        private System.Windows.Forms.Button btnMacimiced;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnHome;
    }
}