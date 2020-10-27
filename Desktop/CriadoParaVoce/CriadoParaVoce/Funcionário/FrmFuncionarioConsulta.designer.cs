namespace CorretoraConvenios.Funcionário
{
    partial class FrmFuncionarioConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncionarioConsulta));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIncluir
            // 
            this.btnIncluir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnIncluir.Click += new System.EventHandler(this.AbrirForm);
            // 
            // btnAlterar
            // 
            this.btnAlterar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAlterar.Click += new System.EventHandler(this.AbrirForm);
            // 
            // btnExcluir
            // 
            this.btnExcluir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnExcluir.Click += new System.EventHandler(this.Fixar);
            // 
            // btnTornarAtivo
            // 
            this.btnTornarAtivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnTornarAtivo.Click += new System.EventHandler(this.Fixar);
            // 
            // btnDesativar
            // 
            this.btnDesativar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnDesativar.Click += new System.EventHandler(this.Fixar);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnConsultar.Click += new System.EventHandler(this.AbrirForm);
            // 
            // chkInativo
            // 
            this.chkInativo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkInativo.CheckedChanged += new System.EventHandler(this.ExibirInativos);
            // 
            // chkAtivo
            // 
            this.chkAtivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkAtivo.CheckedChanged += new System.EventHandler(this.ExibirAtivos);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Click += new System.EventHandler(this.Exibir);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(4, 28);
            this.txtPesquisa.TextChanged += new System.EventHandler(this.MostrarDigitacao);
            // 
            // btnGravar
            // 
            this.btnGravar.ForeColor = System.Drawing.Color.RoyalBlue;
            // 
            // btnSair
            // 
            this.btnSair.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSair.Click += new System.EventHandler(this.Fechar);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            // 
            // FrmFuncionarioConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(930, 501);
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFuncionarioConsulta";
            this.Text = "Consulta Funcionário";
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