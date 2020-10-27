using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Cliente
{
    public partial class FrmClienteConsulta : Telas.Modelo.FrmModeloConsulta
    {
        public FrmClienteConsulta()
        {
            InitializeComponent();
        }

        BLL.Cliente cli = new BLL.Cliente();

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
                dataGridView1.DataSource = cli.ListarAtivos().Tables[0];
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
                dataGridView1.DataSource = cli.ListarInativos().Tables[0];
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

            dataGridView1.DataSource = cli.Listar(txtPesquisa.Text.Trim().ToUpper(), TipoStatus).Tables[0];

            dataGridView1.Columns[0].HeaderText = "Cód";
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Columns[2].HeaderText = "CPF";
            dataGridView1.AutoResizeColumn(2);
            dataGridView1.Columns[3].HeaderText = "Status";
            dataGridView1.AutoResizeColumn(3);

            if (o == btnFiltrar)
            {
                txtPesquisa.Clear();
            }

            txtPesquisa.Focus();

        }

        private void Exibir(Object o, EventArgs e)
        {
            CarregarDadosGrid(o, e);
            btnExcluir.Visible = false;
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
                CorretoraConvenios.Cliente.FrmClienteCadastro ffc = new CorretoraConvenios.Cliente.FrmClienteCadastro();
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
                ffc.label1.Text = label1.Text.PadRight(1) + " > " + b.Text;
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
        private void FixarStatus(Object o, EventArgs e) //DESATIVAR REATIVAR
        {
            try
            {
                var b = (Button)o;
                if (MessageBox.Show(b.Text + " " + this.label1.Text.Substring(0, this.label1.Text.Length - 1) + " " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Código " + this.dataGridView1.CurrentRow.Cells[0].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
                BLL.Cliente cli = new BLL.Cliente(); //<<<<<<<<<<<<<
                cli.CodigoCliente = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); //<<<<<<<<
                switch (b.Text)
                {
                    case "Excluir":
                        cli.Excluir();
                        break;
                    case "Desativar":
                        cli.Desativar();
                        break;
                    case "Reativar":
                        cli.Ativar();
                        break;
                }
                MessageBox.Show("Procedimento " + b.Text + " realizado com sucesso!");
                CarregarDadosGrid(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fechar(Object o, EventArgs e)
        {
            Close();
        }

    }
}
