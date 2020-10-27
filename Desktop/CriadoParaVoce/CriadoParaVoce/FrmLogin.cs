using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce
{
    public partial class FrmLogin : Telas.Modelo.FrmLogin
    { 

        public FrmLogin()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        //493; 311

        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        BLL.Usuario usu = new BLL.Usuario();
        BLL.Funcionario fuc = new BLL.Funcionario();

        //private int Tempo;

        private int _Nivel;

        private bool _FuncionamentoBancoDados;

        private int _CodigoLogado;

        private int _CodigoLogadoFunc;

        private string _Nome;

        public int CodigoLogado
        {
            get
            {
                return _CodigoLogado;
            }
            set
            {
                _CodigoLogado = value;
            }
        }

        public bool FuncionamentoBancoDados
        {
            get
            {
                return _FuncionamentoBancoDados;
            }
            set
            {
                _FuncionamentoBancoDados = value;
            }

        }

        public int Nivel
        {
            get
            {
                return _Nivel;
            }
            set
            {
                _Nivel = value;
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

        public string Nome
        {
            get
            {
                return _Nome;
            }

            set
            {
                _Nome = value;
            }
        }

        /*private void AbrirTroca(Object o, EventArgs e)
        {
            FrmTrocarDeSenha f = new FrmTrocarDeSenha();
            f.ShowDialog();
        }*/

        private void AcessarFormulario()
        {
            try
            {
                usu.NomeSistema = txtNome.Text;
                usu.SenhaSistema = txtSenha.Text;
                CodigoLogado = usu.CodigoLogado();
                CodigoLogadoFunc = fuc.CodigoLogadoFuncionario();
                if (CodigoLogado != 0)
                {
                    Nivel = usu.CodigoNivelAcesso;
                    Nome = usu.NomeUsuario;
                    if (txtSenha.Text == "123456")
                    {
                        MessageBox.Show("A senha inicial não foi trocada.\nVerifique os dados e altere a senha.", "Aviso");
                        Funcionário.FrmFuncionarioCadastro f = new Funcionário.FrmFuncionarioCadastro();
                        f.TipoUso = 1;//Alteração
                        f.Codigo = CodigoLogado;
                        f.CodigoLogadoFunc = CodigoLogadoFunc;
                        f.NivelAcesso = usu.CodigoNivelAcesso;
                        f.label1.Text = "Usuário do Sistema " + txtNome.Text.ToUpper();
                        f.txtSenha.Text = "123456";
                        f.txtUsuario.Enabled = false;
                        f.txtUsuario.Text = txtNome.Text.Trim().ToUpper();
                        //f.txtPergunta.Enabled = false;
                        f.chkAtivo.Checked = true;
                        f.btnSair.Visible = false;
                        f.ControlBox = false;
                        f.ShowDialog();
                        txtSenha.Clear();
                        txtNome.Focus();
                        f.Codigo = 0;
                        CodigoLogado = 0;
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }

        }

        private void Confirmar(Object o, EventArgs e)
        {

            if (VerificarDigitação())
            {
                try
                {
                    if (usu.ExistenciaAdministrador() == false)
                    {
                        usu.CriarUsuarioAdministrador();
                        MessageBox.Show("Criado o usuário Administrador do Sistema com sucesso.\nFaça o acesso ao sistema para alterar \na senha inicial e obter o PIN de usuário.", "Aviso");
                        txtNome.Clear();
                        txtSenha.Clear();
                        txtNome.Focus();
                        return;
                    }

                    AcessarFormulario();
                    if (CodigoLogado != 0)
                    {
                        MessageBox.Show("Seja Bem Vindo!!!");
                        Hide();
                        FrmSistema fs = new FrmSistema();
                        fs.Codigo = CodigoLogado;
                        fs.label6.Text = Nome.ToString();
                        //fs.NomeUsuario = Nome;
                        fs.NivelAcesso = Nivel;
                        fs.ShowDialog();
                        txtSenha.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Erro. Usuário/Senha");
                        txtSenha.Clear();
                        txtNome.Focus();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
            }

        }

        private void Sair(Object o, EventArgs e)
        {
            Application.Exit();
        }

        private void FormClose(Object o, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private Boolean VerificarDigitação()
        {
            Boolean Situacao = true;
            try
            {
                if (txtNome.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtNome, "Digite um nome");
                    Situacao = false;
                }
                else
                {
                    errorProvider1.SetError(txtNome, "");

                }

                if (txtSenha.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtSenha, "Digite a senha");
                    Situacao = false;
                }
                else
                {
                    errorProvider1.SetError(txtSenha, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            return Situacao;
        }

        private void ConfirmarKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    Confirmar(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }

            }
        }

    }
}
