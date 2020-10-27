using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Cargo
{
    public partial class FrmCargoCadastro : Telas.Modelo.FrmModeloCadastro
    {
        public FrmCargoCadastro()
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
                    BLL.Cargo cargo = new BLL.Cargo();
                    System.Data.SqlClient.SqlDataReader drr;
                    cargo.CodigoCargo = Codigo;
                    drr = cargo.Consultar();
                    if (drr.Read())
                    {
                        this.txtCodigo.Text = Convert.ToString(Codigo);
                        this.txtCodigo.Enabled = false;
                        this.txtNomeCargo.Text = drr["NomeCargo"].ToString();
                        this.txtDescricao.Text = drr["DescricaoCargo"].ToString();
                        if (drr["StatusCargo"].ToString() == "1")
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
                if (this.txtNomeCargo.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.txtNomeCargo, "O Nome é obrigatório");
                    this.txtNomeCargo.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtNomeCargo, String.Empty);
                }

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

                BLL.Cargo cargo = new BLL.Cargo();
                cargo.NomeCargo = this.txtNomeCargo.Text.ToUpper();
                cargo.DescricaoCargo = this.txtDescricao.Text.ToUpper();
                cargo.StatusCargo = 0;
                if (this.chkAtivo.Checked)
                {
                    cargo.StatusCargo = 1;
                }

                switch (TipoUso)
                {
                    case 0: //inclusao
                        cargo.IncluirComParametro();
                        break;
                    case 1: //alteracao
                        cargo.CodigoCargo = Codigo;
                        cargo.AlterarComParametro();
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
