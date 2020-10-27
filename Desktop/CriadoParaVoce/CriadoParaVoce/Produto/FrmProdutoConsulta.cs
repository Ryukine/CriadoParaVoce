using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Produto
{
    public partial class FrmProdutoConsulta : Telas.Modelo.FrmModeloConsulta
    {
        public FrmProdutoConsulta()
        {
            InitializeComponent();
        }

        BLL.Produto pro = new BLL.Produto();
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
                dataGridView1.DataSource = pro.ListarAtivos().Tables[0];
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
                dataGridView1.DataSource = pro.ListarInativos().Tables[0];
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

            dataGridView1.DataSource = pro.Listar(txtPesquisa.Text.Trim().ToUpper()).Tables[0];

            dataGridView1.Columns[0].HeaderText = "Cód";
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "Nome Produto";
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Columns[2].HeaderText = "Preco";
            dataGridView1.AutoResizeColumn(2);

            if (o == btnFiltrar)
            {
                txtPesquisa.Clear();
            }

            txtPesquisa.Focus();

        }

        private void Exibir(Object o, EventArgs e)
        {
            try
            {
                if (NivelAcesso > 1)
                {
                    btnAlterar.Visible = false;
                    btnIncluir.Visible = false;
                    btnExcluir.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            CarregarDadosGrid(o, e);
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
                FrmProdutoCadastro ffc = new FrmProdutoCadastro();
                ffc.Funcionalidade = 0; // 0 = Inclusao
                if (o == btnAlterar || o == btnConsultar)
                {
                    ffc.Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    //Objeto 'ffc' tem a propriedade 'codigo' recebendo '=' a conversão em inteiro do conteúdo 'Value' da coluna zero 'Cells[0]' da linha selecionada 'CurrentRow' do grid 'dataGridView1'
                    ffc.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Alteracao;
                    if (o == btnConsultar)
                    {
                        ffc.groupBox1.Enabled = false;
                        ffc.btnGravar.Visible = false;
                        ffc.btnAdicionarFoto.Visible = false;
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

                }*/
                }
                var b = (Button)o;
                //variavel 'b' recebe '=' a conversão '(button)' do objeto 'o'
                ffc.label1.Text = b.Text;
                //o label1 do 'ffc' recebe o texto do botão clicado
                ffc.ShowDialog();
                //abre como diálogo o formulário 'ffc'
                CarregarDadosGrid(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void Fixar(Object o, EventArgs e)
        {
            try
            {
                //o é objeto que foi clicado
                var b = (Button)o;
                //variávl 'b' é o botão 'o'
                if (MessageBox.Show(b.Text, "Atencao", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                pro.CodigoProduto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //propriedade '.codigo' do objeto 'usu' recebe '=' o valor 'value' da primeira coluna 'cells[0]' da linha atual 'currentrow' do grid 'datagridview1'
                switch (b.Text)
                {
                    case "Excluir": pro.Excluir(); break;
                    case "Tornar Ativo": pro.Ativar(); break;
                    case "Desativar": pro.Desativar(); break;

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
