using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControleFarmacia.Negocio.Fornecedor
{
    public partial class FrmConsultaFornecedor : Telas.Modelo.FrmModeloConsulta
    {
        public FrmConsultaFornecedor()
        {
            InitializeComponent();
        }

        private void Exibir(object sender, EventArgs e)
        {//LOAD FORM E CLICK BTNPESQUISAR
            chkAtivo.Visible = false;
            chkInativo.Visible = false;
            CarregarGrid();
            if (sender == this.btnFiltrar)
            {
                this.txtPesquisa.Text = string.Empty;
            }
            this.txtPesquisa.Focus();
        }

        private void CarregarGrid()
        {
            try
            {
                BLL.Fornecedor obj = new BLL.Fornecedor(); // <<<<<<<<<<<<<<<<
                this.dataGridView1.DataSource = obj.Listar(this.txtPesquisa.Text.Trim().ToUpper()).Tables[0];
                //this.dgv.AutoResizeColumns();
                this.dataGridView1.AutoResizeColumn(0);
                this.dataGridView1.AutoResizeColumn(1);
                this.txtPesquisa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }

        private void FixarStatus(Object o, EventArgs e) //DESATIVAR REATIVAR
        {
            try
            {
                var b = (Button)o;
                if (MessageBox.Show(b.Text + " " + this.label1.Text.Substring(0, this.label1.Text.Length - 1) + " " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Código " + this.dataGridView1.CurrentRow.Cells[0].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
                BLL.Fornecedor obj = new BLL.Fornecedor(); //<<<<<<<<<<<<<
                obj.FornecedorId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); //<<<<<<<<
                switch (b.Text)
                {
                    case "Excluir":
                        obj.Excluir();
                        break;
                    case "Desativar":
                        obj.Ativar(0);
                        break;
                    case "Reativar":
                        obj.Ativar(1);
                        break;
                }
                MessageBox.Show("Procedimento " + b.Text + " realizado com sucesso!");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbrirFormulario(object sender, EventArgs e)
        {//INCLUIR ALTERAR CONSULTAR
            try
            {
                CriadoParaVoce.Fornecedor.FrmCadastroFornecedor f = new CriadoParaVoce.Fornecedor.FrmCadastroFornecedor();
                f.TipoUso = Convert.ToByte(BLL.FuncoesGerais.TipoUso.Inclusao);
                f.txtCodigo.Enabled = false;
                if (sender == this.btnAlterar || sender == this.btnConsultar)
                {
                    f.Codigo = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                    f.TipoUso = Convert.ToByte(BLL.FuncoesGerais.TipoUso.Alteracao);
                    if (sender == this.btnConsultar)
                    {
                        f.groupBox1.Enabled = false;
                        f.btnGravar.Visible = false;
                        //ffreq.btnImagem.Visible = false;
                        f.TipoUso = Convert.ToByte(BLL.FuncoesGerais.TipoUso.Consulta);
                    }
                }
                var b = (Button)sender;
                f.label1.Text = this.label1.Text.PadRight(1) + " > " + b.Text;
                f.ShowDialog();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }


        /*private void Cabecalho(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Ágape Instituição de Longa Permanência para Pessoas Idosas", _FonteNegrito, Brushes.Black, _MargemEsquerda, 25, new StringFormat());
            e.Graphics.DrawString("Rua Roma, 138 • Granja Viana • Chácara dos Lagos • Cotia • SP • CEP 06708-640  • 11 4321-3707 • 11 96692-6052 • www.agaperesidencial.com.br • CNPJ 19.667.478/0001-06", _FonteRodape, Brushes.Black, _MargemEsquerda, 45, new StringFormat());
            e.Graphics.DrawString("Relatório: " + this.lblTitulo.Text, _FonteNormal, Brushes.Black, _MargemEsquerda, 65, new StringFormat());
            e.Graphics.DrawString("Emitido em " + DateTime.Now.ToString() + " • Página: " + _Pagina, _FonteNormal, Brushes.Black, _MargemEsquerda, 85, new StringFormat());

            //Título dos Cabeçalhos de Colunas
            e.Graphics.DrawString("Código", _FonteRodape, Brushes.Black, _MargemEsquerda, 105, new StringFormat());
            e.Graphics.DrawString("Nome", _FonteRodape, Brushes.Black, _MargemEsquerda + 40, 105, new StringFormat());
            e.Graphics.DrawString("Documento", _FonteRodape, Brushes.Black, _MargemEsquerda + 100, 105, new StringFormat());
            e.Graphics.DrawLine(_CanetaDaImpressora, _MargemEsquerda, 125, _MargemDireita, 125);
        }*/

        /*private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //_MargemEsquerda = e.MarginBounds.Left;
            _MargemDireita = e.MarginBounds.Right + 80;
            _MargemSuperior = e.MarginBounds.Top + 10; //teste 10
            _MargemInferior = e.MarginBounds.Bottom + 45;//teste 45

            Cabecalho(e);

            float AlturaDaLinha = _FonteNormal.GetHeight(e.Graphics) + 4;

            float yLinhaTopo = e.MarginBounds.Top + 40; //40 <<<<<< acrescimo marcos

            for (; _Linha < this.dgv.Rows.Count; _Linha++)
            {
                if (yLinhaTopo + AlturaDaLinha > _MargemInferior) //if (yLinhaTopo + AlturaDaLinha > e.MarginBounds.Bottom)
                {
                    Rodape(e);
                    e.HasMorePages = true;
                    _Pagina = _Pagina + 1;
                    return;
                }

                //e.Graphics.DrawString("Seq.: " + _Linha + "  Nome:" + Convert.ToString(this.dgv.Rows[_Linha].Cells[1].Value), _FonteNormal, Brushes.Black, new PointF(_MargemEsquerda, yLinhaTopo));

                //Conteúdo do DataGrid
                e.Graphics.DrawString(Convert.ToString(this.dgv.Rows[_Linha].Cells[0].Value), _FonteNormal, Brushes.Black, new PointF(_MargemEsquerda, yLinhaTopo));
                e.Graphics.DrawString(Convert.ToString(this.dgv.Rows[_Linha].Cells[1].Value), _FonteNormal, Brushes.Black, new PointF(_MargemEsquerda + 40, yLinhaTopo));

                yLinhaTopo = yLinhaTopo + AlturaDaLinha;
            }
            Rodape(e); //rodapé da ultima página
            e.HasMorePages = false;
        }

        private void Rodape(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawLine(_CanetaDaImpressora, _MargemEsquerda, _MargemInferior, _MargemDireita, _MargemInferior);
            e.Graphics.DrawString("(C)Soluções em Tecnologia da Informação +55 11 98147-9374 • Página " + _Pagina, _FonteRodape, Brushes.Blue, _MargemEsquerda, _MargemInferior, new StringFormat());
        }*/








    }
}
