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
    public partial class FrmSistema : Telas.Modelo.FrmModelo
    {
        public FrmSistema()
        {
            InitializeComponent();
            panelDashBoard.Visible = false;
            panelCliente.Visible = false;
            //panelFuncionario.Visible = false;
            panelProduto.Visible = false;
            panelGerente.Visible = false;
            pbxFuncionario.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private string _NomeUsuario;

        private int _NivelAcesso;

        private int _Codigo;

        public int NivelAcesso
        {
            get
            {
                return _NivelAcesso;

            }
            set
            {
                _NivelAcesso = value;
            }
        }

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        public string NomeUsuario
        {
            get
            {
                return _NomeUsuario;
            }

            set
            {
                _NomeUsuario = value;
            }
        }

        private void Fechar(Object o, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormLoad(Object o, EventArgs e)
        {
            BLL.Funcionario fuc = new BLL.Funcionario();
            System.Data.SqlClient.SqlDataReader drr;
            fuc.CodigoFunc = Codigo;
            drr = fuc.ConsultarImg();
            if (drr.Read())
            {
                pbxFuncionario.ImageLocation = Convert.ToString(drr["FotoFuncionario"]);
            }

            if (NivelAcesso != 1)
            {
                btnGerente.Visible = false;
            }

            System.Data.SqlClient.SqlDataReader dr;
            BLL.FaleConosco fale = new BLL.FaleConosco();
            dr = fale.Consultar();
            if (dr.Read())
            {
                if (MessageBox.Show("Você possui mensagem, deseja ver ?" , "Atencao", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {

                }
                
            }

        }

        private void Home(Object o, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
            panelCliente.Visible = false;
            panelProduto.Visible = false;
            panelGerente.Visible = false;
        }

        private void Cliente(Object o, EventArgs e)
        {
            panelLeft.Height = btnCliente.Height;
            panelLeft.Top = btnCliente.Top;
            panelProduto.Visible = false;
            panelGerente.Visible = false;
            //panelCliente.Visible = true;
            CriadoParaVoce.Cliente.FrmClienteConsulta frmCliCon = new Cliente.FrmClienteConsulta();
            frmCliCon.ShowDialog();
        }

        private void Funcionario(Object o, EventArgs e)
        {
            //panelFuncionario.Visible = true;
            panelCliente.Visible = false;
            panelProduto.Visible = false;
            panelGerente.Visible = false;
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta frmFunCon = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            frmFunCon.ShowDialog();
        }

        private void Produto(Object o, EventArgs e)
        {
            panelLeft.Height = btnProduto.Height;
            panelLeft.Top = btnProduto.Top;
            //panelProduto.Visible = true;
            panelCliente.Visible = false;
            panelGerente.Visible = false;
            CriadoParaVoce.Produto.FrmProdutoConsulta frmProCon = new Produto.FrmProdutoConsulta();
            frmProCon.ShowDialog();
        }

        private void Gerente(Object o, EventArgs e)
        {
            panelLeft.Height = btnGerente.Height;
            panelLeft.Top = btnGerente.Top;
            panelCliente.Visible = false;
            panelProduto.Visible = false;
            //panelGerente.Visible = true;
            Empresa.FrmEmpresa frmEmpresa = new Empresa.FrmEmpresa();
            frmEmpresa.CodigoUsuario = Codigo;
            frmEmpresa.ShowDialog();
        }

        private void Administrativo(Object o, EventArgs e)
        {
            panelCliente.Visible = false;
            panelProduto.Visible = false;
            panelGerente.Visible = false;
        }

        private void ConsultarFunc (Object o, EventArgs e)
        {
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta ffc = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            ffc.label1.Text = "Consulta Funcionário";
            ffc.ShowDialog();
        }

        private void CadastroCli(Object o, EventArgs e)
        {
             CorretoraConvenios.Cliente.FrmClienteCadastro ffc = new CorretoraConvenios.Cliente.FrmClienteCadastro();
            ffc.label1.Text = "Cadastro Cliente";
            ffc.ShowDialog();
        }
        private void ConsultaCli(Object o, EventArgs e)
        {
            CriadoParaVoce.Cliente.FrmClienteConsulta ffc = new CriadoParaVoce.Cliente.FrmClienteConsulta();
            ffc.label1.Text = "Consulta Cliente";
            ffc.ShowDialog();
        }
        private void CadastroFunc(Object o, EventArgs e)
        {
            CriadoParaVoce.Funcionário.FrmFuncionarioCadastro ffc = new Funcionário.FrmFuncionarioCadastro();
            ffc.label1.Text = "Cadastro Funcionário";
            ffc.ShowDialog();
        }
        private void CadastroProduto(Object o, EventArgs e)
        {
            CriadoParaVoce.Produto.FrmProdutoCadastro ffc = new CriadoParaVoce.Produto.FrmProdutoCadastro();
            ffc.label1.Text = "Cadastro Produto";
            ffc.ShowDialog();
        }
        private void ConsultaProduto(Object o, EventArgs e)
        {
            CriadoParaVoce.Produto.FrmProdutoConsulta ffc = new CriadoParaVoce.Produto.FrmProdutoConsulta();
            ffc.label1.Text = "Consulta Produto";
            ffc.ShowDialog();
        }
        private void Gerencia(Object o, EventArgs e)
        {
            Empresa.FrmEmpresa ffc = new Empresa.FrmEmpresa();
            ffc.CodigoUsuario = Codigo;
            ffc.ShowDialog();
        }
        private void ConsultaGerencia(Object o, EventArgs e)
        {
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta ffc = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            ffc.label1.Text = "Gerencia";
            ffc.ShowDialog();
        }
        private void CadastroAdministracao(Object o, EventArgs e)
        {
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta ffc = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            ffc.ShowDialog();
        }
        private void ConsultaAdministracao(Object o, EventArgs e)
        {
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta ffc = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            ffc.ShowDialog();
        }

        private void AbrirVenda(Object o, EventArgs e)
        {
            Funcionalidade.FrmVenda frmVenda = new Funcionalidade.FrmVenda();
            frmVenda.ShowDialog();
        }
       
    }
}
