namespace CriadoParaVoce.Funcionalidade
{
    partial class FrmConsultaGasto
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
            // btnExcluir
            // 
            this.btnExcluir.Click += new System.EventHandler(this.Fixar);
            // 
            // btnTornarAtivo
            // 
            this.btnTornarAtivo.Click += new System.EventHandler(this.Fixar);
            // 
            // btnDesativar
            // 
            this.btnDesativar.Click += new System.EventHandler(this.Fixar);
            // 
            // btnConsultar
            // 
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
            // FrmConsultaGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 494);
            this.Name = "FrmConsultaGasto";
            this.Text = "";
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