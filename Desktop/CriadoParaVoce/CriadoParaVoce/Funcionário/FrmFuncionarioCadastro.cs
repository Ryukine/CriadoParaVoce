using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Funcionário
{
    public partial class FrmFuncionarioCadastro : Telas.Modelo.FrmModeloCadastro
    {
        public FrmFuncionarioCadastro()
        {
            InitializeComponent();
            txtCodigo.ReadOnly = true;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //This line of code will help you to 
                //change the apperance like size,name,style.
                Font f;
                //For background color
                Brush backBrush;
                //For forground color
                Brush foreBrush;
                //This construct will hell you to decide 
                //which tab page have current focus
                //to change the style.
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    //This line of code will help you to 
                    //change the apperance like size,name,style.
                    f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    f = new Font(e.Font, FontStyle.Bold);
                    backBrush = new System.Drawing.SolidBrush(Color.DarkGray);
                    foreBrush = Brushes.White;
                }
                else
                {
                    f = e.Font;
                    backBrush = new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                }
                //To set the alignment of the caption.
                string tabName = this.tabControl1.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                //Continue.........
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        BLL.Usuario usu = new BLL.Usuario();
        BLL.Funcionario fuc = new BLL.Funcionario();

        private string _RespostaSecreta;
        private string _PinUsuario;
        private int _CodigoNivelAcesso;
        private byte _status;
        private int _CodigoLogadoFunc;
        private string _Sexo;

        public string RespostaSecreta
        {
            get
            {
                return _RespostaSecreta;
            }

            set
            {
                _RespostaSecreta = value.ToUpper().Trim();
            }
        }

        public string PinUsuario
        {
            get
            {
                return _PinUsuario;
            }

            set
            {
                _PinUsuario = value;
            }
        }

        public byte Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public int CodigoNivelAcesso
        {
            get
            {
                return _CodigoNivelAcesso;
            }
            set
            {
                _CodigoNivelAcesso = value;
            }
        }

        public int CodigoLogadoFunc
        {
            get
            {
                return _CodigoLogadoFunc;
            }

            set
            {
                _CodigoLogadoFunc = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }

        private int Click = 0;

        private void AbrirForm(Object o, EventArgs e)
        {
            CarregarComboNivel(o, e);
        }



        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                CarregarComboNivel(o, e);
                //CarregarComboDepartamento(o, e);
                CarregarComboCargo(o, e);
                CarregarComboUF(o, e);
                //txtTelAdd2.Visible = false;
                //txtTelAdd3.Visible = false;
                /*label19.Visible = false;
                label21.Visible = false;
                label22.Visible = false;*/
                if (TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {

                    System.Data.SqlClient.SqlDataReader dr;
                    usu.CodigoUsuario = Codigo;
                    usu.CodigoFunc = CodigoLogadoFunc;
                    
                    dr = usu.Consultar();
                    if (dr.Read())
                    {
                        txtUsuario.Text = Convert.ToString(dr["NomeSistema"]);
                        txtUsuario.Enabled = false;
                        txtSenha.Text = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["SenhaSistema"]));
                        txtNome.Text = Convert.ToString(dr["NomeUsuario"]);
                        PinUsuario = Convert.ToString(dr["PinUsuario"]);
                        chkAtivo.Checked = Convert.ToBoolean(dr["StatusUsuario"]);

                        /*if (Convert.ToString(dr["PerguntaUsuario"]) == String.Empty)
                        {
                            txtPergunta.Text = "Qual é o PIN?";
                            RespostaSecreta = Convert.ToString(dr["PinUsuario"]);
                        }
                        else*/
                        //{
                        //txtPergunta.Text = Convert.ToString(dr["PerguntaUsuario"]);
                        RespostaSecreta = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["RespostaUsuario"]));
                        //}

                    }

                    System.Data.SqlClient.SqlDataReader dr1;
                    dr1 = usu.RetornarNivelAcesso();
                    if (dr1.Read())
                    {
                        cboNivel.Text = Convert.ToString(dr1["NomeNivel"]);
                    }

                    System.Data.SqlClient.SqlDataReader drr;
                    fuc.CodigoFunc = CodigoLogadoFunc;
                    txtCodigo.Text = CodigoLogadoFunc.ToString();
                    drr = fuc.Consultar();
                    if (drr.Read())
                    {
                        if (Convert.ToString(drr["Sexo"]) == "F")
                        {
                            rbtFeminino.Checked = true;
                        }
                        else
                        {
                            rbtMasculino.Checked = true;
                        }
                        txtCpf.Text = Convert.ToString(drr["CpfFuncionario"]);
                        txtEmail.Text = Convert.ToString(drr["EmailFuncionario"]);
                        txtDataNasc.Text = Convert.ToString(drr["NascimentoFuncionario"]);
                        txtBairro.Text = Convert.ToString(drr["Bairro"]);
                        txtCep.Text = Convert.ToString(drr["CEP"]);
                        txtLogradouro.Text = Convert.ToString(drr["Logradouro"]);
                        cboUF.Text = Convert.ToString(drr["UF"]);
                        cboCidade.Text = Convert.ToString(drr["Cidade"]);
                        txtNumero.Text = Convert.ToString(drr["Numero"]);
                        txtComplemento.Text = Convert.ToString(drr["Complemento"]);
                        txtImagem.Text = Convert.ToString(drr["FotoFuncionario"]);
                        pbxFuncionario.ImageLocation = Convert.ToString(drr["FotoFuncionario"]);
                    }

                    System.Data.SqlClient.SqlDataReader dr2;
                    dr2 = fuc.RetornarCargo();
                    if (dr2.Read())
                    {
                        cboCargo.Text = Convert.ToString(dr2["NomeCargo"]);
                    }

                    System.Data.SqlClient.SqlDataReader dr3;
                    dr3 = fuc.RetornarDepartamento();
                    if (dr2.Read())
                    {
                        //cboDepartamento.Text = Convert.ToString(dr3["NomeDepartamento"]);
                    }

                }

                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }

        private void CarregarComboNivel(Object o, EventArgs e)
        {
            BLL.Nivel nv = new BLL.Nivel();
            cboNivel.DataSource = nv.ListarAtivos().Tables[0];
            cboNivel.DisplayMember = "NomeNivel"; //texto
            cboNivel.ValueMember = "CodigoNivel"; //pk
            cboNivel.SelectedIndex = -1;
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

        private void CarregarComboCargo(Object o, EventArgs e)
        {
            BLL.Cargo cargo = new BLL.Cargo();
            cboCargo.DataSource = cargo.ListarAtivos().Tables[0];
            cboCargo.DisplayMember = "NomeCargo";
            cboCargo.ValueMember = "CodigoCargo";
            cboCargo.SelectedIndex = -1;
        }

        /*private void CarregarComboDepartamento(Object o, EventArgs e)
        {
            BLL.Departamento departamento = new BLL.Departamento();
            cboDepartamento.DataSource = departamento.ListarAtivos().Tables[0];
            cboDepartamento.DisplayMember = "NomeDepartamento";
            cboDepartamento.ValueMember = "CodigoDepartamento";
            cboDepartamento.SelectedIndex = -1;
        }*/

        private void PermitirCampos(bool Valor)
        {
            txtBairro.Enabled = Valor;
            cboUF.Enabled = Valor;
            txtLogradouro.Enabled = Valor;
            cboUF.Enabled = Valor;
        }

        private void SalvarImagem(Object o, EventArgs e)
        {
            try
            {
                SaveFileDialog diretorio = new SaveFileDialog();

                FileDialog file = new SaveFileDialog();

                diretorio.ShowDialog();

                diretorio.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";

                if (diretorio.FileName != null)
                {
                    txtImagem.Text = diretorio.FileName;

                    Bitmap bmp = new Bitmap(diretorio.FileName);

                    Bitmap bmp2 = new Bitmap(bmp, pbxFuncionario.Size);

                    pbxFuncionario.Image = bmp2;

                }

            }

            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Inserir imagem : " + erro);

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
                            PermitirCampos(true);
                            txtBairro.Text = dr2["Bairro"].ToString();
                            txtLogradouro.Text = dr2["Descricao"].ToString();
                            cboUF.Text = dr2["UF"].ToString();
                            cboCidade.Text = dr2["Cidade"].ToString();

                        }
                        dr2.Close();
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

        /*private void MostarPin(Object o, MouseEventArgs m)
        {
            dica.SetToolTip(lblPin, PinUsuario);
        }*/

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
                if (!BLL.FuncoesGerais.IsPasswordStrong(txtSenha.Text) && TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    errorProvider1.SetError(txtSenha, "A senha deve possuir ao menos \n uma letra minúscula \n uma letra maiúscula \n um número \n um caractere especial \n e tamanho mínimo de 6 caracteres.");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtSenha, "");
                }

                if (rbtMasculino.Checked == false && rbtFeminino.Checked == false)
                {
                    errorProvider1.SetError(rbtMasculino, "Informe um Gênero."); return;
                }
                else
                {
                    errorProvider1.SetError(rbtMasculino, "");
                }

                if (txtUsuario.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtUsuario, "Informe o nome do Usuario de Login"); return;
                }
                else
                {
                    errorProvider1.SetError(txtUsuario, "");
                }
                if (chkAtivo.Checked)
                {
                    usu.StatusUsuario = 1;
                }
                else
                {
                    usu.StatusUsuario = 0;
                }
                if (chkAtivo.Checked)
                {
                    fuc.StatusFuncionario = 1;
                }
                else
                {
                    fuc.StatusFuncionario = 0;
                }
                if (rbtMasculino.Checked)
                {
                    fuc.Sexo = "M";
                }
                else
                {
                    fuc.Sexo = "F";
                }

                /*if (txtResposta.Text.Trim().ToUpper() != RespostaSecreta && TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    errorProvider1.SetError(txtResposta, "A resposta não está correta.\n Não será possível atualizar os dados.");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtResposta, "");
                }*/

                usu.CodigoNivelAcesso = Convert.ToInt32(cboNivel.SelectedValue);
                usu.NomeUsuario = txtNome.Text;
                fuc.NomeFuncionario = txtNome.Text;
                usu.SenhaSistema = txtSenha.Text;
                fuc.Cep = txtCep.Text;
                fuc.FotoFuncionario = txtImagem.Text;
                fuc.NomeFoto = txtNomeFoto.Text;
                fuc.Logradouro = txtLogradouro.Text;
                fuc.Bairro = txtBairro.Text;
                fuc.Cidade = cboCidade.Text;
                fuc.Numero = txtNumero.Text;
                fuc.UF = cboUF.Text;
                usu.PerguntaUsuario = "";
                usu.RespostaUsuario = "";
                fuc.NascimentoFuncionario = Convert.ToDateTime(txtDataNasc.Text);
                fuc.Complemento = txtComplemento.Text;
                fuc.EmailFuncionario = txtEmail.Text;
                usu.NomeSistema = txtUsuario.Text;
                fuc.CpfFuncionario = txtCpf.Text;
                fuc.CodigoCargo = Convert.ToInt32(cboCargo.SelectedValue);
                fuc.CodigoDepartamento = Convert.ToInt32(1);
                if (TipoUso == 0)
                {
                    usu.CodigoFunc = fuc.IncluirRetornarNumeroAutomatico();
                    usu.IncluirComParametro();

                    MessageBox.Show("Um Funcionário foi Inserido com Sucesso");
                    Close();
                }
                if (TipoUso == 1)
                {
                    fuc.AlterarComParametro();
                    usu.AlterarComParametro();
                    MessageBox.Show("Um Funcionário foi Alterado com Sucesso");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Mostrar_Senha(object sender, EventArgs e)
        {
            if (this.cbMostrarSenha.Checked)
            {
                this.txtSenha.PasswordChar = '\0';
            }
            else
            {
                this.txtSenha.PasswordChar = '•';
            }
        }

        private void PreencherAuto(Object o, EventArgs e)
        {
            txtCep.Text = "06402150";
            txtCpf.Text = "48920327866";
            txtDataNasc.Text = "19101996";
            txtEmail.Text = "t@oul.com";
            txtNome.Text = "Thiago Gomes de Araújo";
            txtNumero.Text = "138";
            //txtPergunta.Text = "Vaca";
            //txtResposta.Text = "Vaco";
            txtSenha.Text = "123456";
            rbtMasculino.Checked = true;
            chkAtivo.Checked = true;
            txtLogradouro.Text = "Rua Silverstone";
            txtBairro.Text = "Parque Santa Luzia";
            cboCidade.Text = "Barueri";
            cboUF.Text = "SP";
        }

        /*private void AdicinarTelefone(Object o, EventArgs e)
        {
            /*Click = Click + 1;
            switch (Click)
            {
                case 1: label19.Visible = true; txtTelAdd1.Visible = true; break;
                case 2: label19.Visible = true; txtTelAdd1.Visible = true; label21.Visible =
                case 4: MessageBox.Show("Não é possível cadastrar mais de 3 telefones adicionais"); break;

            }*/
            /*if (Click == 1)
            {
                txtTelAdd1.Visible = true;
            }
            if (Click == 2)
            {
                txtTelAdd2.Visible = true;
            }
            if (Click == 3)
            {
                txtTelAdd3.Visible = true;
            }
        }*/

        private void BuscaCep(Object o, EventArgs e)
        {
            CorretoraConvenios.Sistema.FrmConsultaCep frmCo = new CorretoraConvenios.Sistema.FrmConsultaCep();
            frmCo.ShowDialog();
            txtCep.Text = Convert.ToString(frmCo.dataGridView1.CurrentRow.Cells[0].Value);
            txtCep.Focus();
            txtNumero.Focus();
        }
    }
}
