using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva.ContasPagar
{
   public class FrmCadastroNomeTitulo: Telas.Modelo.FrmModeloCadastro
    {

        public FrmCadastroNomeTitulo()
        {
            InitializeComponent();
        }



        public CheckBox chkAtivo;
        private Label label2;
        public TextBox txtNome;


        BLL.Titulo tit = new BLL.Titulo();


        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                if (TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    System.Data.SqlClient.SqlDataReader dr;
                    tit.CodigoTitulo = Codigo;
                    dr = tit.Consultar();
                    if (dr.Read())
                    {
                        txtNome.Text = dr["DescricaoTitulo"].ToString();
                     
                        chkAtivo.Checked = Convert.ToBoolean(dr["StatusTitulo"]);

                    }

                }

                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }

        private void Gravar(Object o, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtNome, "Informe o nome."); return;
                }
                else
                {
                    errorProvider1.SetError(txtNome, "");
                }

                tit.CodigoTitulo = Codigo;
                tit.DescricaoTitulo = txtNome.Text;
               

                tit.StatusTitulo = 0;
                if (chkAtivo.Checked == true)
                {
                    tit.StatusTitulo = 1;
                }

                if (TipoUso == (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                 
                    tit.Incluir();
                    MessageBox.Show("Inclusão realizada com sucesso.", "Aviso");
                }

                if (TipoUso == (byte)BLL.FuncoesGerais.TipoUso.Alteracao)
                {
                    tit.DescricaoTitulo = txtNome.Text;
                    tit.Atualizar();
                    MessageBox.Show("Dados atualizados com sucesso.", "Aviso");
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }




        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroNomeTitulo));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAtivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Size = new System.Drawing.Size(529, 143);
            this.groupBox1.Text = "";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(326, 189);
            this.btnGravar.Click += new System.EventHandler(this.Gravar);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(438, 189);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(17, 61);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(443, 29);
            this.txtNome.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do Título";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(19, 91);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(70, 28);
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // FrmCadastroNomeTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(584, 276);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCadastroNomeTitulo";
            this.Text = "Cadastro de Título";
            this.Load += new System.EventHandler(this.CarregarCampos);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
