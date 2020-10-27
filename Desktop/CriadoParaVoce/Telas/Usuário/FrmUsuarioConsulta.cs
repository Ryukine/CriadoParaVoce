using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas.Usuário
{
    public partial class FrmUsuarioConsulta : Modelo.FrmModeloConsulta
    {
        public FrmUsuarioConsulta()
        {
            InitializeComponent();
        }

        private void ExibirAtivos(Object o, EventArgs e)
        {
            try
            {
                BLL.Usuario usu = new BLL.Usuario();
                dataGridView1.DataSource = usu.ListarAtivos().Tables[0];
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
                BLL.Usuario usu = new BLL.Usuario();
                dataGridView1.DataSource = usu.ListarInativos().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CarregarDadosGrid()
        {
            try
            {
                BLL.Usuario usu = new BLL.Usuario();
                dataGridView1.DataSource = usu.Listar(txtPesquisa.Text.Trim().ToUpper(), 1).Tables[0];
                txtPesquisa.Focus();
                //a propriedade DataSource do DataGrid é a fonte de dados. Esta propriedade recebe (=) do objeto USU o método LISTAR usando como parâmetro o texto TEXT.TRIM().TOUPPER() digitado no TEXTBOX1. Esse DATASOURCE usará a tabela zero TABLES[0] do método LISTAR
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Exibir(Object o, EventArgs e)
        {
            CarregarDadosGrid();
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
                FrmUsuarioCadastro fuc = new FrmUsuarioCadastro();
                fuc.Funcionalidade = 0; // 0 = Inclusao
                if (o == btnAlterar || o == btnConsultar)
                {
                    fuc.Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    //Objeto 'fuc' tem a propriedade 'codigo' recebendo '=' a conversão em inteiro do conteúdo 'Value' da coluna zero 'Cells[0]' da linha selecionada 'CurrentRow' do grid 'dataGridView1'
                    if (o == btnConsultar)
                    {
                        fuc.groupBox1.Enabled = false;
                        fuc.btnGravar.Visible = false;
                        fuc.Funcionalidade = 2; //2 = Consultar
                    }
                }
                var b = (Button)o;
                //variavel 'b' recebe '=' a conversão '(button)' do objeto 'o'
                fuc.label1.Text = b.Text;
                //o label1 do 'fuc' recebe o texto do botão clicado
                fuc.ShowDialog();
                //abre como diálogo o formulário 'fuc'
                CarregarDadosGrid();
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
                BLL.Usuario usu = new BLL.Usuario();
                usu.CodigoUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //propriedade '.codigo' do objeto 'usu' recebe '=' o valor 'value' da primeira coluna 'cells[0]' da linha atual 'currentrow' do grid 'datagridview1'
                switch (b.Text)
                {
                    case "Excluir": usu.Excluir(); break;
                    case "Ativar": usu.Ativar(); break;
                    case "Desativar": usu.Desativar(); break;

                }
                MessageBox.Show(b.Text, "Sucesso");
                CarregarDadosGrid();



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
