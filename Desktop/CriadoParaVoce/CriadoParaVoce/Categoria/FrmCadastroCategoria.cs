    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Categoria
{
    public partial class FrmCadastroCategoria : Telas.Modelo.FrmModeloCadastro
    {
        public FrmCadastroCategoria()
        {
            InitializeComponent();
        }

        //Associar este metodo ao EVENTO LOAD do formulario
        private void CarregarCampos(object sender, EventArgs e)
        {
            try
            {
                if (TipoUso != Convert.ToByte(BLL.FuncoesGerais.TipoUso.Inclusao))
                {
                    BLL.Categoria cate = new BLL.Categoria();
                    System.Data.SqlClient.SqlDataReader drr;
                    cate.CategoriaId = Codigo;
                    drr = cate.Consultar();
                    if (drr.Read())
                    {
                        this.txtCodigo.Text = Convert.ToString(Codigo);
                        this.txtCodigo.Enabled = false;
                        this.txtDescricao.Text = drr["DescricaoCategoria"].ToString();
                        if (drr["StatusCategoria"].ToString() == "1")
                        {
                            this.chkAtivo.Checked = true;
                        }
                        else
                        {
                            this.chkAtivo.Checked = false;
                        }
                    }
                    this.groupBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }

        //associar ao CLICK do botao SALVAR
        private void Salvar(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDescricao.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.txtDescricao, "A descrição é obrigatória");
                    this.txtDescricao.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtDescricao, String.Empty);
                }

                BLL.Categoria cate = new BLL.Categoria();
                cate.DescricaoCategoria = this.txtDescricao.Text.ToUpper();
                cate.StatusCategoria = 0;
                if (this.chkAtivo.Checked)
                {
                    cate.StatusCategoria = 1;
                }

                switch (TipoUso)
                {
                    case 0: //inclusao
                        cate.IncluirComParametro();
                        break;
                    case 1: //alteracao
                        cate.CategoriaId = Codigo;
                        cate.AlterarComParametro();
                        break;
                }
                MessageBox.Show("Operação " + this.label1.Text + " realizada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
