using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Funcionalidade
{
    public partial class FrmFaleConosco : Telas.Modelo.FrmModeloConsulta
    {
        public FrmFaleConosco()
        {
            InitializeComponent();
        }

        private int _CodigoUsuario;

        BLL.FaleConosco fale = new BLL.FaleConosco();
        BLL.Funcionario fuc = new BLL.Funcionario();

        public int CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }

        private void MostrarDigitacao(Object o, EventArgs e)
        {
            //https://pt.stackoverflow.com/questions/204686/consulta-%C3%A1-base-de-dados-atrav%C3%A9s-de-uma-text-box
            //evento TEXTCHANGED do textbox
            try
            {
                CarregarDadosGrid(o, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void ExibirAtivos(Object o, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = fale.ListarAtivos().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void ExibirInativos(Object o, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = fale.ListarInativos().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        /*private void CarregarDadosGrid()
        {
            try
            {
                dataGridView1.DataSource = usu.Listar(textBox1.Text.Trim().ToUpper(), 1).Tables[0];
                textBox1.Focus();
                //a propriedade DataSource do DataGrid é a fonte de dados. Esta propriedade recebe (=) do objeto USU o método LISTAR usando como parâmetro o texto TEXT.TRIM().TOUPPER() digitado no TEXTBOX1. Esse DATASOURCE usará a tabela zero TABLES[0] do método LISTAR
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }*/

        private void CarregarDadosGrid(Object o, EventArgs e)
        {

            if (chkAtivo.Checked && chkInativo.Checked)
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Todos;
            }
            else if (chkAtivo.Checked && !chkInativo.Checked)
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Ativo;
            }
            else
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Inativo;
            }
            BLL.FaleConosco fale = new BLL.FaleConosco();

            dataGridView1.DataSource = fale.Listar2(txtPesquisa.Text.Trim(), TipoStatus).Tables[0];

            dataGridView1.Columns[0].HeaderText = "IDMSG";
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "EMAIL";
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Columns[2].HeaderText = "NOME";
            dataGridView1.AutoResizeColumn(2);
            dataGridView1.Columns[3].HeaderText = "Assunto";
            dataGridView1.AutoResizeColumn(3);
            dataGridView1.Columns[4].HeaderText = "DATA_MSG";
            dataGridView1.AutoResizeColumn(4);

            if (o == btnFiltrar)
            {
                txtPesquisa.Clear();
            }

            txtPesquisa.Focus();

        }

        private void Exibir(Object o, EventArgs e)
        {
            CarregarDadosGrid(o, e);
            btnAlterar.Visible = false;
            btnTornarAtivo.Visible = false;
            btnDesativar.Visible = false;
            btnExcluir.Visible = false;
            btnGravar.Visible = false;
            if (o == btnFiltrar)
            {
                txtPesquisa.Text = String.Empty;
            }
            txtPesquisa.Focus();
        }



        private void AbrirForm(Object o, EventArgs e)
        {
            try
            {
                TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
                Telas_Inf2DM.Funcionalidades.FrmVender funcionalidades = new Telas_Inf2DM.Funcionalidades.FrmVender();
                //funcionalidades.Funcionalidade = 0; // 0 = Inclusao
                /*if (o == btnAlterar || o == btnConsultar)
                {
                    funcionalidades.Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    funcionalidades.CodigoLogadoFunc = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                    //Objeto 'ffc' tem a propriedade 'codigo' recebendo '=' a conversão em inteiro do conteúdo 'Value' da coluna zero 'Cells[0]' da linha selecionada 'CurrentRow' do grid 'dataGridView1'
                    funcionalidades.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Alteracao;
                    if (o == btnConsultar)
                    {
                        ffc.tabGeral.Enabled = false;
                        //ffc.tabEndereco.Enabled = false;
                        ffc.tabPessoais.Enabled = false;
                        ffc.btnGravar.Visible = false;
                        ffc.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Consulta;
                        ffc.Funcionalidade = 2; //2 = Consultar
                    }
                    /*if (o == btnAlterar)
                    {

                        /*ffc.txtNome.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        ffc.txtCpf.Text = Convert.ToInt32()*/
                /*dataGridView1.DataSource = usu.Listar(textBox1.Text.Trim().ToUpper(), 1).Tables[0];
        textBox1.Focus();
                ffc.TipoUso = 1;

            }*//*
            }*/
                var b = (Button)o;
                CodigoUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                BLL.FaleConosco fale = new BLL.FaleConosco();
                fale.IDMSG = Codigo;
                //variavel 'b' recebe '=' a conversão '(button)' do objeto 'o'
                //funcionalidades.label1.Text = label1.Text.PadRight(1) + " > " + b.Text;
                //o label1 do 'ffc' recebe o texto do botão clicado
                funcionalidades.ShowDialog();
                //abre como diálogo o formulário 'ffc'
                CarregarDadosGrid(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
        private void ConsultarVenda(Object o, EventArgs e)
        {
            //CodigoFunc = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //CodigoUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            fale.CodigoUsuario = CodigoUsuario;
            fale.IDMSG = Codigo;
            CriadoParaVoce.Funcionalidade.FrmFaleConsulta ConsulFale = new FrmFaleConsulta();
            ConsulFale.CodigoUsuario = CodigoUsuario;
            ConsulFale.Codigo = Codigo;
            ConsulFale.ShowDialog();
        }

        private void ConsultarResposta(Object o, EventArgs e)
        {
            Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            CriadoParaVoce.Funcionalidade.FrmFaleConsulta FrmFale = new FrmFaleConsulta();
            FrmFale.Codigo = Codigo;
            FrmFale.txtResposta.Enabled = false;
            FrmFale.txtDataResp.Enabled = false;
            FrmFale.ShowDialog();
        }

        private void Fixar(Object o, EventArgs e)
        {
            try
            {
                //o é objeto que foi clicado
                var b = (Button)o;
                //variávl 'b' é o botão 'o'
                if (MessageBox.Show(b.Text, "Atencao", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                fale.IDMSG = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //propriedade '.codigo' do objeto 'usu' recebe '=' o valor 'value' da primeira coluna 'cells[0]' da linha atual 'currentrow' do grid 'datagridview1'
                switch (b.Text)
                {
                    case "Excluir": fale.Excluir(); break;
                    case "Tornar Ativo": fale.Ativar(); break;
                    case "Desativar": fale.Desativar(); break;

                }
                MessageBox.Show(b.Text, "Sucesso");
                CarregarDadosGrid(o, e);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Fechar(Object o, EventArgs e)
        {
            Close();
        }
    }
}
