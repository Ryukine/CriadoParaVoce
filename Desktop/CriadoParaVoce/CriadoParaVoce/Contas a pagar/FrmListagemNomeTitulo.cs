using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva.ContasPagar
{
    public partial class FrmListagemNomeTitulo: Telas.Modelo.FrmModeloConsulta
    {
        public FrmListagemNomeTitulo()
        {
            InitializeComponent();
        }

        BLL.Titulo tit = new BLL.Titulo();

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

        private void Fixar(Object o, EventArgs e)
        {
            try
            {
                //dataGridView1.CurrentRow.Cells[0].Value
                //  if (dataGridView1.CurrentRow.Selected)
                //  {
                var b = (Button)o;
                if (MessageBox.Show(b.Text + " " + label1.Text.Substring(0, label1.Text.Length - 1) + " " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Código " + dataGridView1.CurrentRow.Cells[0].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
                tit.CodigoTitulo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                switch (b.Text)
                {
                    case "Excluir":
                        tit.Excluir();
                        break;
                    case "Ativar":
                        tit.ModificarStatus((byte)BLL.FuncoesGerais.TipoStatus.Ativo);
                        break;
                    case "Desativar":
                        tit.ModificarStatus((byte)BLL.FuncoesGerais.TipoStatus.Inativo);
                        break;
                }
                MessageBox.Show("Procedimento " + b.Text + " realizado com sucesso!");
                CarregarDadosGrid(o, e);
                // }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }
               
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

            dataGridView1.DataSource = tit.Listar(txtPesquisa.Text.Trim().ToUpper(), TipoStatus).Tables[0];

            dataGridView1.Columns[0].HeaderText = "Cód";
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "Titulo";
            dataGridView1.AutoResizeColumn(1);
            //dataGridView1.Columns[2].HeaderText = "Status";
            //dataGridView1.AutoResizeColumn(2);

            if (o == btnFiltrar)
            {
                txtPesquisa.Clear();
            }

            txtPesquisa.Focus();
         

        }

        private void AbrirFormulario(Object o, EventArgs e)
        {
            try
            {
                FrmCadastroNomeTitulo fcu = new FrmCadastroNomeTitulo ();
                fcu.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Inclusao;
                fcu.statusStrip1.Visible = false;
                if (o == btnIncluir)
                {
                    fcu.chkAtivo.Checked = false;
                }

                if (o == this.btnAlterar || o == this.btnConsultar)
                {
                    fcu.Codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    fcu.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Alteracao;
                    if (o == btnConsultar)
                    {
                        fcu.groupBox1.Enabled = false;
                        fcu.btnGravar.Visible = false;
                        fcu.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Consulta;
                    }
                }
                var b = (Button)o;
                fcu.label1.Text = label1.Text.PadRight(1) + " > " + b.Text;
                fcu.ShowDialog();

                CarregarDadosGrid(o, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListagemNomeTitulo));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIncluir
            // 
            this.btnIncluir.Click += new System.EventHandler(this.AbrirFormulario);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Click += new System.EventHandler(this.AbrirFormulario);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Click += new System.EventHandler(this.Fixar);
            // 
            // btnTornarAtivo
            // 
            this.btnTornarAtivo.Click += new System.EventHandler(this.Fixar);
            // 
            // btnDesativar
            // 
            this.btnDesativar.Click += new System.EventHandler(this.Fixar);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Click += new System.EventHandler(this.AbrirFormulario);
            // 
            // chkInativo
            // 
            this.chkInativo.CheckedChanged += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // chkAtivo
            // 
            this.chkAtivo.CheckedChanged += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Click += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.TextChanged += new System.EventHandler(this.MostrarDigitacao);
            // 
            // FrmListagemNomeTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(917, 497);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListagemNomeTitulo";
            this.Load += new System.EventHandler(this.CarregarDadosGrid);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }




}
