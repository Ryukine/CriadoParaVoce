namespace CriadoParaVoce.Empresa
{
    partial class FrmEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpresa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnAdministrativo = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnFaleConosco = new System.Windows.Forms.Button();
            this.btnCargo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelAdm = new System.Windows.Forms.Panel();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnConsultaVenda = new System.Windows.Forms.Button();
            this.btnFuncionario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelAdm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CriadoParaVoce.Properties.Resources.WhatsApp_Image_2019_02_09_at_18_29_53;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 106);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFornecedor);
            this.panel2.Controls.Add(this.btnAdministrativo);
            this.panel2.Controls.Add(this.btnProduto);
            this.panel2.Controls.Add(this.btnFaleConosco);
            this.panel2.Controls.Add(this.btnCargo);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 707);
            this.panel2.TabIndex = 2;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.FlatAppearance.BorderSize = 0;
            this.btnFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFornecedor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.ForeColor = System.Drawing.Color.White;
            this.btnFornecedor.Location = new System.Drawing.Point(3, 367);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(194, 58);
            this.btnFornecedor.TabIndex = 7;
            this.btnFornecedor.Text = "Fornecedor";
            this.btnFornecedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFornecedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.Fornecedor);
            // 
            // btnAdministrativo
            // 
            this.btnAdministrativo.FlatAppearance.BorderSize = 0;
            this.btnAdministrativo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdministrativo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrativo.ForeColor = System.Drawing.Color.White;
            this.btnAdministrativo.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministrativo.Image")));
            this.btnAdministrativo.Location = new System.Drawing.Point(3, 303);
            this.btnAdministrativo.Name = "btnAdministrativo";
            this.btnAdministrativo.Size = new System.Drawing.Size(194, 58);
            this.btnAdministrativo.TabIndex = 6;
            this.btnAdministrativo.Text = "Administrativo";
            this.btnAdministrativo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdministrativo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdministrativo.UseVisualStyleBackColor = true;
            this.btnAdministrativo.Click += new System.EventHandler(this.Admin);
            // 
            // btnProduto
            // 
            this.btnProduto.FlatAppearance.BorderSize = 0;
            this.btnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduto.ForeColor = System.Drawing.Color.White;
            this.btnProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProduto.Image")));
            this.btnProduto.Location = new System.Drawing.Point(3, 239);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(194, 58);
            this.btnProduto.TabIndex = 4;
            this.btnProduto.Text = "Produtos";
            this.btnProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.ConsultaProd);
            // 
            // btnFaleConosco
            // 
            this.btnFaleConosco.FlatAppearance.BorderSize = 0;
            this.btnFaleConosco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFaleConosco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFaleConosco.ForeColor = System.Drawing.Color.White;
            this.btnFaleConosco.Location = new System.Drawing.Point(3, 175);
            this.btnFaleConosco.Name = "btnFaleConosco";
            this.btnFaleConosco.Size = new System.Drawing.Size(194, 58);
            this.btnFaleConosco.TabIndex = 3;
            this.btnFaleConosco.Text = "Fale Conosco";
            this.btnFaleConosco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFaleConosco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFaleConosco.UseVisualStyleBackColor = true;
            this.btnFaleConosco.Click += new System.EventHandler(this.FaleConosco);
            // 
            // btnCargo
            // 
            this.btnCargo.FlatAppearance.BorderSize = 0;
            this.btnCargo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargo.ForeColor = System.Drawing.Color.White;
            this.btnCargo.Location = new System.Drawing.Point(3, 111);
            this.btnCargo.Name = "btnCargo";
            this.btnCargo.Size = new System.Drawing.Size(194, 58);
            this.btnCargo.TabIndex = 1;
            this.btnCargo.Text = "Cargo";
            this.btnCargo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCargo.UseVisualStyleBackColor = true;
            this.btnCargo.Click += new System.EventHandler(this.Cargo);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::CriadoParaVoce.Properties.Resources.WhatsApp_Image_2019_02_09_at_18_29_53;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 106);
            this.panel3.TabIndex = 0;
            // 
            // panelAdm
            // 
            this.panelAdm.Controls.Add(this.btnCategoria);
            this.panelAdm.Controls.Add(this.btnConsultaVenda);
            this.panelAdm.Controls.Add(this.btnFuncionario);
            this.panelAdm.Location = new System.Drawing.Point(203, 303);
            this.panelAdm.Name = "panelAdm";
            this.panelAdm.Size = new System.Drawing.Size(209, 194);
            this.panelAdm.TabIndex = 3;
            // 
            // btnCategoria
            // 
            this.btnCategoria.FlatAppearance.BorderSize = 0;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoria.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.ForeColor = System.Drawing.Color.White;
            this.btnCategoria.Location = new System.Drawing.Point(3, 128);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(194, 58);
            this.btnCategoria.TabIndex = 13;
            this.btnCategoria.Text = "Categoria de Produtos";
            this.btnCategoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.ConsultarCategoria);
            // 
            // btnConsultaVenda
            // 
            this.btnConsultaVenda.FlatAppearance.BorderSize = 0;
            this.btnConsultaVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultaVenda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaVenda.ForeColor = System.Drawing.Color.White;
            this.btnConsultaVenda.Location = new System.Drawing.Point(3, 3);
            this.btnConsultaVenda.Name = "btnConsultaVenda";
            this.btnConsultaVenda.Size = new System.Drawing.Size(194, 58);
            this.btnConsultaVenda.TabIndex = 11;
            this.btnConsultaVenda.Text = "Consultar Vendas";
            this.btnConsultaVenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultaVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConsultaVenda.UseVisualStyleBackColor = true;
            this.btnConsultaVenda.Click += new System.EventHandler(this.ConsultaVenda);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.FlatAppearance.BorderSize = 0;
            this.btnFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFuncionario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncionario.ForeColor = System.Drawing.Color.White;
            this.btnFuncionario.Location = new System.Drawing.Point(3, 67);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(194, 58);
            this.btnFuncionario.TabIndex = 12;
            this.btnFuncionario.Text = "Funcionários";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFuncionario.UseVisualStyleBackColor = true;
            this.btnFuncionario.Click += new System.EventHandler(this.ConsultarFunc);
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 729);
            this.Controls.Add(this.panelAdm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEmpresa";
            this.Text = "";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panelAdm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelAdm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnAdministrativo;
        public System.Windows.Forms.Button btnProduto;
        public System.Windows.Forms.Button btnFaleConosco;
        public System.Windows.Forms.Button btnCargo;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Panel panelAdm;
        public System.Windows.Forms.Button btnCategoria;
        public System.Windows.Forms.Button btnConsultaVenda;
        public System.Windows.Forms.Button btnFuncionario;
    }
}