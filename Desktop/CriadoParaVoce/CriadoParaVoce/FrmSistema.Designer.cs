namespace CriadoParaVoce
{
    partial class FrmSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSistema));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnGerente = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pbxFuncionario = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDashBoard = new System.Windows.Forms.Panel();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultarCli = new System.Windows.Forms.Button();
            this.btnCadastrarCli = new System.Windows.Forms.Button();
            this.panelProduto = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnCadastrarProd = new System.Windows.Forms.Button();
            this.panelGerente = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConsultarGerencia = new System.Windows.Forms.Button();
            this.btnGerenciar = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBackGround = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFuncionario)).BeginInit();
            this.panelCliente.SuspendLayout();
            this.panelProduto.SuspendLayout();
            this.panelGerente.SuspendLayout();
            this.panelBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnVenda);
            this.panel1.Controls.Add(this.btnGerente);
            this.panel1.Controls.Add(this.btnProduto);
            this.panel1.Controls.Add(this.btnCliente);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 707);
            this.panel1.TabIndex = 1;
            // 
            // btnVenda
            // 
            this.btnVenda.FlatAppearance.BorderSize = 0;
            this.btnVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenda.ForeColor = System.Drawing.Color.Black;
            this.btnVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnVenda.Image")));
            this.btnVenda.Location = new System.Drawing.Point(3, 372);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(194, 144);
            this.btnVenda.TabIndex = 7;
            this.btnVenda.Text = "Venda";
            this.btnVenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.AbrirVenda);
            // 
            // btnGerente
            // 
            this.btnGerente.FlatAppearance.BorderSize = 0;
            this.btnGerente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerente.ForeColor = System.Drawing.Color.Black;
            this.btnGerente.Image = ((System.Drawing.Image)(resources.GetObject("btnGerente.Image")));
            this.btnGerente.Location = new System.Drawing.Point(3, 308);
            this.btnGerente.Name = "btnGerente";
            this.btnGerente.Size = new System.Drawing.Size(194, 58);
            this.btnGerente.TabIndex = 5;
            this.btnGerente.Text = "Gerente";
            this.btnGerente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGerente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGerente.UseVisualStyleBackColor = true;
            this.btnGerente.Click += new System.EventHandler(this.Gerencia);
            // 
            // btnProduto
            // 
            this.btnProduto.FlatAppearance.BorderSize = 0;
            this.btnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduto.ForeColor = System.Drawing.Color.Black;
            this.btnProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProduto.Image")));
            this.btnProduto.Location = new System.Drawing.Point(3, 244);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(194, 58);
            this.btnProduto.TabIndex = 4;
            this.btnProduto.Text = "Produto";
            this.btnProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.Produto);
            // 
            // btnCliente
            // 
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.Black;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.Location = new System.Drawing.Point(3, 175);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(194, 58);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.Cliente);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(3, 111);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(194, 58);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "DashBoard";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.Home);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.pbxFuncionario);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 106);
            this.panel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "label6";
            // 
            // pbxFuncionario
            // 
            this.pbxFuncionario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxFuncionario.Location = new System.Drawing.Point(0, 0);
            this.pbxFuncionario.Name = "pbxFuncionario";
            this.pbxFuncionario.Size = new System.Drawing.Size(200, 105);
            this.pbxFuncionario.TabIndex = 0;
            this.pbxFuncionario.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(200, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 193);
            this.panel2.TabIndex = 2;
            // 
            // panelDashBoard
            // 
            this.panelDashBoard.Location = new System.Drawing.Point(213, 3);
            this.panelDashBoard.Name = "panelDashBoard";
            this.panelDashBoard.Size = new System.Drawing.Size(243, 230);
            this.panelDashBoard.TabIndex = 0;
            // 
            // panelCliente
            // 
            this.panelCliente.Controls.Add(this.label1);
            this.panelCliente.Controls.Add(this.btnConsultarCli);
            this.panelCliente.Controls.Add(this.btnCadastrarCli);
            this.panelCliente.Location = new System.Drawing.Point(262, 0);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(256, 233);
            this.panelCliente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // btnConsultarCli
            // 
            this.btnConsultarCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConsultarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarCli.Location = new System.Drawing.Point(11, 87);
            this.btnConsultarCli.Name = "btnConsultarCli";
            this.btnConsultarCli.Size = new System.Drawing.Size(219, 36);
            this.btnConsultarCli.TabIndex = 1;
            this.btnConsultarCli.Text = "Consultar";
            this.btnConsultarCli.UseVisualStyleBackColor = false;
            this.btnConsultarCli.Click += new System.EventHandler(this.ConsultaCli);
            // 
            // btnCadastrarCli
            // 
            this.btnCadastrarCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCadastrarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarCli.Location = new System.Drawing.Point(11, 45);
            this.btnCadastrarCli.Name = "btnCadastrarCli";
            this.btnCadastrarCli.Size = new System.Drawing.Size(219, 36);
            this.btnCadastrarCli.TabIndex = 0;
            this.btnCadastrarCli.Text = "Cadastrar";
            this.btnCadastrarCli.UseVisualStyleBackColor = false;
            this.btnCadastrarCli.Click += new System.EventHandler(this.CadastroCli);
            // 
            // panelProduto
            // 
            this.panelProduto.Controls.Add(this.label3);
            this.panelProduto.Controls.Add(this.btnConsultar);
            this.panelProduto.Controls.Add(this.btnCadastrarProd);
            this.panelProduto.Location = new System.Drawing.Point(206, 239);
            this.panelProduto.Name = "panelProduto";
            this.panelProduto.Size = new System.Drawing.Size(256, 233);
            this.panelProduto.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Produto";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Location = new System.Drawing.Point(17, 91);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(219, 36);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.ConsultaProduto);
            // 
            // btnCadastrarProd
            // 
            this.btnCadastrarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCadastrarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarProd.Location = new System.Drawing.Point(17, 49);
            this.btnCadastrarProd.Name = "btnCadastrarProd";
            this.btnCadastrarProd.Size = new System.Drawing.Size(219, 36);
            this.btnCadastrarProd.TabIndex = 2;
            this.btnCadastrarProd.Text = "Cadastrar";
            this.btnCadastrarProd.UseVisualStyleBackColor = false;
            this.btnCadastrarProd.Click += new System.EventHandler(this.CadastroProduto);
            // 
            // panelGerente
            // 
            this.panelGerente.Controls.Add(this.label4);
            this.panelGerente.Controls.Add(this.btnConsultarGerencia);
            this.panelGerente.Controls.Add(this.btnGerenciar);
            this.panelGerente.Location = new System.Drawing.Point(468, 239);
            this.panelGerente.Name = "panelGerente";
            this.panelGerente.Size = new System.Drawing.Size(256, 233);
            this.panelGerente.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gerente";
            // 
            // btnConsultarGerencia
            // 
            this.btnConsultarGerencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConsultarGerencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarGerencia.Location = new System.Drawing.Point(11, 91);
            this.btnConsultarGerencia.Name = "btnConsultarGerencia";
            this.btnConsultarGerencia.Size = new System.Drawing.Size(219, 36);
            this.btnConsultarGerencia.TabIndex = 3;
            this.btnConsultarGerencia.Text = "Gastos";
            this.btnConsultarGerencia.UseVisualStyleBackColor = false;
            this.btnConsultarGerencia.Click += new System.EventHandler(this.ConsultaGerencia);
            // 
            // btnGerenciar
            // 
            this.btnGerenciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGerenciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciar.Location = new System.Drawing.Point(11, 49);
            this.btnGerenciar.Name = "btnGerenciar";
            this.btnGerenciar.Size = new System.Drawing.Size(219, 36);
            this.btnGerenciar.TabIndex = 2;
            this.btnGerenciar.Text = "Empresa";
            this.btnGerenciar.UseVisualStyleBackColor = false;
            this.btnGerenciar.Click += new System.EventHandler(this.Gerencia);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelLeft.Location = new System.Drawing.Point(200, 111);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(7, 50);
            this.panelLeft.TabIndex = 5;
            // 
            // panelBackGround
            // 
            this.panelBackGround.BackgroundImage = global::CriadoParaVoce.Properties.Resources.WhatsApp_Image_2019_02_09_at_18_29_53;
            this.panelBackGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBackGround.Controls.Add(this.panelCliente);
            this.panelBackGround.Location = new System.Drawing.Point(206, 3);
            this.panelBackGround.Name = "panelBackGround";
            this.panelBackGround.Size = new System.Drawing.Size(824, 512);
            this.panelBackGround.TabIndex = 6;
            // 
            // FrmSistema
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 729);
            this.Controls.Add(this.panelProduto);
            this.Controls.Add(this.panelGerente);
            this.Controls.Add(this.panelDashBoard);
            this.Controls.Add(this.panelBackGround);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Fechar);
            this.Load += new System.EventHandler(this.FormLoad);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panelLeft, 0);
            this.Controls.SetChildIndex(this.panelBackGround, 0);
            this.Controls.SetChildIndex(this.panelDashBoard, 0);
            this.Controls.SetChildIndex(this.panelGerente, 0);
            this.Controls.SetChildIndex(this.panelProduto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFuncionario)).EndInit();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.panelProduto.ResumeLayout(false);
            this.panelProduto.PerformLayout();
            this.panelGerente.ResumeLayout(false);
            this.panelGerente.PerformLayout();
            this.panelBackGround.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.Button btnGerente;
        public System.Windows.Forms.Button btnProduto;
        public System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Panel panelDashBoard;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Button btnConsultarCli;
        private System.Windows.Forms.Button btnCadastrarCli;
        private System.Windows.Forms.Panel panelProduto;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Panel panelGerente;
        private System.Windows.Forms.Button btnConsultarGerencia;
        private System.Windows.Forms.Button btnGerenciar;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnVenda;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelBackGround;
        public System.Windows.Forms.PictureBox pbxFuncionario;
        private System.Windows.Forms.Button btnCadastrarProd;
    }
}