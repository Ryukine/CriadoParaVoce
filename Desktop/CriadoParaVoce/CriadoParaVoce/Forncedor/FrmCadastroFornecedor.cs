using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Fornecedor
{
    public partial class FrmCadastroFornecedor : Telas.Modelo.FrmModeloCadastro
    {
        public FrmCadastroFornecedor()
        {
            InitializeComponent();
        }

        //Associar este metodo ao EVENTO LOAD do formulario
        private void CarregarCampos(object sender, EventArgs e)
        {
            try
            {
                CarregarComboCidade(sender, e);
                CarregarComboUF(sender, e);
                txtCodigo.Enabled = false;
                if (TipoUso != Convert.ToByte(BLL.FuncoesGerais.TipoUso.Inclusao))
                {
                    BLL.Fornecedor forn = new BLL.Fornecedor();
                    System.Data.SqlClient.SqlDataReader dr;
                    forn.FornecedorId = Codigo;
                    dr = forn.Consultar();
                    if (dr.Read())
                    {
                        this.txtCodigo.Text = Convert.ToString(Codigo);
                        this.txtCodigo.Enabled = false;
                        this.txtNome.Text = dr["DESCRICAO"].ToString();
                        this.txtNumero.Text = dr["NUMERO"].ToString();
                        this.txtBairro.Text = dr["BAIRRO"].ToString();
                        this.txtCep.Text = dr["Cep"].ToString();
                        this.cboCidade.Text = dr["Cidade"].ToString();
                        this.txtCnpj.Text = dr["CNPJ"].ToString();
                        this.txtComplemento.Text = dr["Complemento"].ToString();
                        this.txtContato.Text = dr["Contato"].ToString();
                        this.txtEmail.Text = dr["Email"].ToString();
                        this.txtEndereco.Text = dr["Endereco"].ToString();
                        this.txtIe.Text = dr["Inscricao"].ToString();
                        this.txtSite.Text = dr["Site"].ToString();
                        this.txtTelefoneCelular.Text = dr["TelefoneCelular"].ToString();
                        this.cboUF.Text = dr["Uf"].ToString();

                        // this.numVezesNoDia.Value = Convert.ToInt32(dr["VEZESNODIA"]);
                        if (dr["ATIVO"].ToString() == "1")
                        {
                            this.chkAtivo.Checked = true;
                        }
                        else
                        {
                            this.chkAtivo.Checked = false;
                        }
                        //this.picImagem.ImageLocation = @dr["LOCALIMAGEMTURMA"].ToString();
                    }
                    this.groupBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }


        private void Salvar(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNome.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.txtNome, "A descrição é obrigatória");
                    this.txtNome.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtNome, String.Empty);
                }

                BLL.Fornecedor forn = new BLL.Fornecedor();
                forn.Descricao = this.txtNome.Text.ToUpper();
                forn.Numero = this.txtNumero.Text.ToUpper();
                forn.Bairro = this.txtBairro.Text.ToUpper();
                forn.Cep = this.txtCep.Text;
                forn.Cidade = this.cboCidade.Text;
                forn.Cnpj = this.txtCnpj.Text;
                forn.Complemento = this.txtComplemento.Text;
                forn.Contato = this.txtContato.Text;
                forn.Email = this.txtEmail.Text;
                forn.Logradouro = this.txtEndereco.Text;
                forn.Inscricao = this.txtIe.Text;
                forn.Site = this.txtSite.Text;
                forn.TelefoneCelular = this.txtTelefoneCelular.Text;
                forn.Uf = this.cboUF.Text;




                //freq.VezesNoDia = Convert.ToInt32(this.numVezesNoDia.Value);
                //if (this.abrirArquivoPasta.FileName == "")
                //{
                //    objTurma.LocalImagemTurma = this.picImagem.ImageLocation;
                //}
                forn.StatusFornecedor = 0;
                if (this.chkAtivo.Checked)
                {
                    forn.StatusFornecedor = 1;
                }

                switch (TipoUso)
                {
                    case 0: //inclusao
                        forn.IncluirComParametro();
                        break;
                    case 1: //alteracao
                        forn.FornecedorId = Codigo;
                        forn.AlterarComParametro();
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

        private void Buscar(Object o, EventArgs e)
        {
            try
            {
                if (txtCep.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtCep, "Digite um Cep!");
                }
                else
                {
                    BLL.Postal post = new BLL.Postal();
                    if (txtCep.Text.Trim().Length > 0)
                    {
                        post.Cep = Convert.ToInt32(txtCep.Text.Replace("-", ""));
                        System.Data.SqlClient.SqlDataReader dr2;
                        dr2 = post.Consultar();
                        dr2.Read();
                        if (dr2.HasRows)
                        {
                            txtBairro.Text = dr2["Bairro"].ToString();
                            txtEndereco.Text = dr2["Descricao"].ToString();
                            cboUF.Text = dr2["UF"].ToString();
                            cboCidade.Text = dr2["Cidade"].ToString();

                        }
                        dr2.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CarregarComboCidade(Object o, EventArgs e)
        {
            if (cboUF.Text.ToUpper().Length != 0)
            {
                BLL.Postal post = new BLL.Postal();
                cboCidade.DataSource = post.ListarCidade(cboUF.Text).Tables[0];
                cboCidade.DisplayMember = "Cidade";
                cboCidade.ValueMember = "Cidade";
                cboCidade.SelectedIndex = -1;
            }

        }

        private void CarregarComboUF(Object o, EventArgs e)
        {
            BLL.Postal post = new BLL.Postal();
            cboUF.DataSource = post.ListarUF().Tables[0];
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "UF";
            cboUF.SelectedIndex = -1;
        }

        private void PreencherAuto(Object o, EventArgs e)
        {
            txtCodigo.Text = "2";
            txtNome.Text = "Vitor";
            chkAtivo.Checked = true;
            txtCep.Text = "06402150";
            txtEndereco.Text = "Rua Silverstone";
            txtBairro.Text = "Parque Santa Luzia";
            cboCidade.Text = "Barueri";
            cboUF.Text = "SP";
            txtNumero.Text = "138";
            txtCnpj.Text = "99999999999999";
            txtContato.Text = "11999999999";
            txtEmail.Text = "Vitor@Negocios.com";
        }
    }
}
