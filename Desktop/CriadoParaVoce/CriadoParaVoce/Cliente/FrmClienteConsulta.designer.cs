namespace CriadoParaVoce.Cliente
{
    partial class FrmClienteConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClienteConsulta));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIncluir
            // 
            this.btnIncluir.Click += new System.EventHandler(this.AbrirForm);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Click += new System.EventHandler(this.AbrirForm);
            // 
            // btnTornarAtivo
            // 
            this.btnTornarAtivo.Location = new System.Drawing.Point(349, 402);
            this.btnTornarAtivo.Click += new System.EventHandler(this.FixarStatus);
            // 
            // btnDesativar
            // 
            this.btnDesativar.Location = new System.Drawing.Point(462, 402);
            this.btnDesativar.Click += new System.EventHandler(this.FixarStatus);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(574, 402);
            this.btnConsultar.Click += new System.EventHandler(this.AbrirForm);
            // 
            // chkInativo
            // 
            this.chkInativo.CheckedChanged += new System.EventHandler(this.ExibirInativos);
            // 
            // chkAtivo
            // 
            this.chkAtivo.CheckedChanged += new System.EventHandler(this.ExibirAtivos);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Click += new System.EventHandler(this.Exibir);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.TextChanged += new System.EventHandler(this.MostrarDigitacao);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(686, 402);
            // 
            // FrmClienteConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 501);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClienteConsulta";
            this.Text = "Consulta de Cliente";
            this.Load += new System.EventHandler(this.Exibir);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}