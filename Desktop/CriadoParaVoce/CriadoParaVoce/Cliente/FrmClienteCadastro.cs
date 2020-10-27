using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorretoraConvenios.Cliente
{
    public partial class FrmClienteCadastro : Telas.Modelo.FrmModeloCadastro
    {
        public FrmClienteCadastro()
        {
            InitializeComponent();
        }
        BLL.Cliente cli = new BLL.Cliente();

        private void CarregarForm(Object o, EventArgs e)
        {
            CarregarComboUF(o, e);
            CarregarComboCidade(o, e);

            if (TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
            {

                System.Data.SqlClient.SqlDataReader dr;
                cli.CodigoCliente = Codigo;
                dr = cli.Consultar();
                if (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["NomeCliente"]);
                    txtCpf.Text = Convert.ToString(dr["CpfCliente"]);
                    txtEmail.Text = Convert.ToString(dr["EmailCliente"]);
                    txtCep.Text = Convert.ToString(dr["CEP"]);
                    txtBairro.Text = Convert.ToString(dr["Bairro"]);
                    txtRuaAv.Text = Convert.ToString(dr["Logradouro"]);
                    cboCidade.Text = Convert.ToString(dr["Cidade"]);
                    cboUF.Text = Convert.ToString(dr["UF"]);
                    if (Convert.ToString(dr["Sexo"]) == "F")
                    {
                        rbtFeminino.Checked = true;
                    }
                    else
                    {
                        rbtMasculino.Checked = true;
                    }
                    txtTelefone.Text = Convert.ToString(dr["Telefone"]);
                    txtDataNasc.Text = Convert.ToString(dr["DataNascimento"]);
                    chkAtivo.Checked = Convert.ToBoolean(dr["StatusCliente"]);
                    txtNumero.Text = Convert.ToString(dr["Numero"]);
                    txtComplemento.Text = Convert.ToString(dr["Complemento"]);

                    /*if (Convert.ToString(dr["PerguntaUsuario"]) == String.Empty)
                    {
                        txtPergunta.Text = "Qual é o PIN?";
                        RespostaSecreta = Convert.ToString(dr["PinUsuario"]);
                    }
                    else*/
                    //{
                    //txtPergunta.Text = Convert.ToString(dr["PerguntaUsuario"]);

                    //}

                }
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

        private void CarregarCombo(Object o, EventArgs e)
        {

        }

        private void CarregarComboUF(Object o, EventArgs e)
        {
            BLL.Postal post = new BLL.Postal();
            cboUF.DataSource = post.ListarUF().Tables[0];
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "UF";
            cboUF.SelectedIndex = -1;
        }

        private void PermitirCampos(bool Valor)
        {
            txtBairro.Enabled = Valor;
            cboCidade.Enabled = Valor;
            txtRuaAv.Enabled = Valor;
            cboUF.Enabled = Valor;
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
                            PermitirCampos(true);
                            txtBairro.Text = dr2["Bairro"].ToString();
                            txtRuaAv.Text = dr2["Descricao"].ToString();
                            cboUF.Text = dr2["UF"].ToString();
                            cboCidade.Text = dr2["Cidade"].ToString();

                        }
                    }
                    else
                    {
                        PermitirCampos(true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Gravar(Object o, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtNome, "Informe o nome"); return;
                }
                else
                {
                    errorProvider1.SetError(txtNome, "");
                }

                if (!BLL.FuncoesGerais.IsCpf(txtCpf.Text))
                {
                    errorProvider1.SetError(txtCpf, "Informe um número de CPF válido."); return;
                }
                else
                {
                    errorProvider1.SetError(txtCpf, "");
                }

                if (!BLL.FuncoesGerais.IsDataValida(txtDataNasc.Text))
                {
                    errorProvider1.SetError(txtDataNasc, "Informe uma data válida."); return;
                }
                else
                {
                    errorProvider1.SetError(txtDataNasc, "");
                }

                //a data de nascimento precisa ser limitada com um valor mínimo e um valor máximo
                DateTime dataMinima, dataMaxima;
                dataMinima = DateTime.Today.AddYears(-110);
                dataMaxima = DateTime.Today.AddDays(+7);
                if (Convert.ToDateTime(txtDataNasc.Text) < dataMinima || Convert.ToDateTime(txtDataNasc.Text) > dataMaxima)
                {
                    errorProvider1.SetError(txtDataNasc, "A data informada não atende aos limites definidos de " + dataMinima.ToShortDateString() + " a " + dataMaxima.ToShortDateString());
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtDataNasc, "");
                }
                if (!BLL.FuncoesGerais.ValidarEmailRegEx(txtEmail.Text))
                {
                    errorProvider1.SetError(txtEmail, "Informe um e-mail."); return;
                }
                else
                {
                    errorProvider1.SetError(txtEmail, "");
                }

                if (rbtMasculino.Checked == false && rbtFeminino.Checked == false)
                {
                    errorProvider1.SetError(rbtMasculino, "Informe um Gênero."); return;
                }
                else
                {
                    errorProvider1.SetError(rbtMasculino, "");
                }
                if (chkAtivo.Checked)
                {
                    cli.StatusCliente = 1;
                }
                else
                {
                    cli.StatusCliente = 0;
                }
                if (rbtMasculino.Checked)
                {
                    cli.Sexo = "M";
                }
                else
                {
                    cli.Sexo = "F";
                }

                cli.NomeCliente = txtNome.Text;
                //cli.NomeMae = txtMae.Text;
                //cli.NomePai = txtPai.Text;
                cli.Cep = txtCep.Text;
                cli.Logradouro = txtRuaAv.Text;
                cli.Bairro = txtBairro.Text;
                cli.Cidade = cboCidade.Text;
                cli.Numero = txtNumero.Text;
                cli.UF = cboUF.Text;
                cli.DataNascimento = Convert.ToDateTime(txtDataNasc.Text);
                cli.Complemento = txtComplemento.Text;
                cli.EmailCliente = txtEmail.Text;
                cli.Telefone = txtTelefone.Text;
                cli.CpfCliente = txtCpf.Text;
                //cli.Naturalidade = txtNaturalidade.Text;

                cli.PastaFotoCliente = "atrintaedois";

                if (TipoUso == 0)
                {
                    cli.IncluirComParametro();
                    MessageBox.Show("Um Cliente foi Inserido com Sucesso");
                    Close();
                }
                if (TipoUso == 1)
                {
                    cli.AlterarComParametro();
                    MessageBox.Show("Um Cliente foi Alterado com Sucesso");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void PreencherAuto(Object o, EventArgs e)
        {
            txtNome.Text = "Joao";
            txtCpf.Text = "14513108894";
            rbtMasculino.Checked = true;
            txtDataNasc.Text = "12/10/2000";
            txtEmail.Text = "xxx@xxxx.xxx";
            txtTelefone.Text = "1148596712";
            //txtMae.Text = "Dona Marcia";
            //txtPai.Text = "Cléber";
            //txtNaturalidade.Text = "Brasileiro";
            chkAtivo.Checked = true;
        }

        private void BuscaCep(Object o, EventArgs e)
        {
            Sistema.FrmConsultaCep frmCo = new Sistema.FrmConsultaCep();
            frmCo.ShowDialog();
            txtCep.Text = Convert.ToString(frmCo.dataGridView1.CurrentRow.Cells[0].Value);
            txtCep.Focus();
            txtNumero.Focus();
        }
    }
}
