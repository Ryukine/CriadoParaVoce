using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva.ContasPagar
{
    public partial class FrmGestaoContasPagar : Telas.Modelo.FrmModeloConsulta
    {

        public FrmGestaoContasPagar()
        {
            InitializeComponent();
            CarregarComboPeriodo();
            RecuperarDatasInicializar();
           
        }

        BLL.Periodo peri = new BLL.Periodo();
        private void CarregarComboPeriodo()
        {
            try
            {
                cboPeriodo.DataSource = peri.Listar("", 1).Tables[0];
                cboPeriodo.DisplayMember = "DescricaoPeriodo";
                cboPeriodo.ValueMember = "ValorPeriodo";
                cboPeriodo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboPeriodo_SelectionChangeCommitted(Object o, EventArgs e)
        {

            RecuperarDatasInicializar();
            // CarregarComboPeriodo();
            CarregarDadosGrid(o, e );
        }

        private void AtualizarFonteGrid()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Courier New", 8.5F, GraphicsUnit.Pixel);
            }
        }

        private void RecuperarDatasInicializar()
        {
            //mskDataInicial.Text = DateTime.Today.ToShortDateString();
            //mskDataFinal.Text = DateTime.Today.AddMonths(1).ToShortDateString();
            if (Convert.ToInt32(cboPeriodo.SelectedValue) > 0)
            {
                mskDataInicial.Text = DateTime.Today.ToShortDateString();
                mskDataFinal.Text = DateTime.Today.AddMonths(Convert.ToInt32(cboPeriodo.SelectedValue)).ToShortDateString();
            }
            else
            {
                mskDataInicial.Text = DateTime.Today.AddMonths(Convert.ToInt32(cboPeriodo.SelectedValue)).ToShortDateString();
                mskDataFinal.Text = DateTime.Today.ToShortDateString();
            }

        }

        private Label label4;
        private TextBox txtInformativo;
        private ComboBox cboPeriodo;
        private Label label6;
        BLL.Lancamento lcm = new BLL.Lancamento();

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
            }

        }

        private void Fixar(Object o, EventArgs e)
        {
            try
            {
                var b = (Button)o;

                if (MessageBox.Show(dataGridView1.CurrentRow.Cells["DescricaoTitulo"].Value.ToString() + "\n" + "Vencimento " + String.Format("{0:d}", dataGridView1.CurrentRow.Cells["DataVencimento"].Value) + "\n" + "Valor " + String.Format("{0:C}", dataGridView1.CurrentRow.Cells["ValorTitulo"].Value), b.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

                lcm.CodigoLancamento = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CodigoLancamento"].Value);

                switch (b.Text)
                {

                    case "Excluir":
                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["StatusPagTitulo"].Value) == 1)
                        {
                            MessageBox.Show("Não é possível excluir uma conta com pagamento já efetuado.");
                            return;
                        }
                        lcm.Excluir();
                        break;

                    case "Pagar Baixar":

                        if (Convert.ToByte(dataGridView1.CurrentRow.Cells["StatusPagTitulo"].Value) == 1)
                        {
                            MessageBox.Show("Conta já estava paga.");
                            return;
                        }

                        lcm.ValorPagamento = Convert.ToDouble(dataGridView1.CurrentRow.Cells["ValorTitulo"].Value);

                        if (Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DataVencimento"].Value) < DateTime.Today)
                        {
                            MessageBox.Show("Conta encontra-se vencida.");
                            CriarFormularioDigitarValorPago();

                            if (ValorDigitadoPagamento < Convert.ToDouble(dataGridView1.CurrentRow.Cells["ValorTitulo"].Value))
                            {
                                ValorDigitadoPagamento = 0;
                                return;
                            }
                            else
                            {
                                lcm.ValorPagamento = ValorDigitadoPagamento;
                            }
                        }

                        lcm.CodigoTitulo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Codigotitulo"].Value);
                        lcm.StatusPagTitulo = 1;
                        lcm.CodigoUsuario = Codigo;
                        lcm.ValorTitulo = Convert.ToDouble(dataGridView1.CurrentRow.Cells["ValorTitulo"].Value);
                        lcm.DataPagamento = DateTime.Today;
                        lcm.DataVencimento = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DataVencimento"].Value);
                        lcm.Pagar();
                        break;

                    case "Cancelar":
                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["StatusPagTitulo"].Value) == 0)
                        {
                            MessageBox.Show("Não é possível cancelar uma conta que não foi paga.");
                            return;
                        }
                        lcm.CancelarPagamento();
                        break;
                }
                MessageBox.Show("Procedimento " + b.Text + " realizado com sucesso!");
                CarregarDadosGrid(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }

        private void ChecarDigitacaoDatas()
        {
            try
            {
                if (Convert.ToDateTime(mskDataInicial.Text) > Convert.ToDateTime(mskDataFinal.Text))
                {
                    mskDataInicial.Text = mskDataFinal.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarDadosGrid(Object o, EventArgs e)
        {
            ChecarDigitacaoDatas();
            if (chkInativo.Checked && chkAtivo.Checked)
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Todos;
            }
            else if (chkInativo.Checked && !chkInativo.Checked)
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Inativo;
            }
            else
            {
                TipoStatus = (byte)BLL.FuncoesGerais.TipoStatus.Ativo;
            }

            dataGridView1.DataSource = lcm.ListarContas(TipoStatus, Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text)).Tables[0];

            //dataGridView1.Columns[0].HeaderText = "Cód";
            //dataGridView1.AutoResizeColumn(0);
            //dataGridView1.AutoResizeColumn(1);
            //dataGridView1.AutoResizeColumn(2);

            dataGridView1.AutoResizeColumns();

            dataGridView1.Columns["Codigotitulo"].Visible = false;
            dataGridView1.Columns["CodigoLancamento"].Visible = false;

            dataGridView1.Columns["ValorTitulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ValorPagamento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (o == btnFiltrar)
            {
                //txtPesquisa.Clear();
            }

            //  dataGridView1.Sort(dataGridView1.Columns["DescricaoTitulo"], ListSortDirection.Ascending);

            //txtPesquisa.Focus();
            AtualizaLblAPagar();
            AtualizaLblPagas();
            AtualizarLblSaldo();
            AtualizaLblAberto();
            // AtualizarFonteGrid();
            AtualizarLblInformativo();
        }

        private void AtualizarLblInformativo()
        {
            try
            {
                txtInformativo.Clear();
                System.Data.SqlClient.SqlDataReader ddr;
                ddr = lcm.ObterTituloEmAberto(DateTime.Today);
                ddr.Read();
                if (ddr.HasRows)
                {
                    if (Convert.ToInt32(ddr["Qtde"]) == 1)
                    {
                        txtInformativo.Text = "Desde " + Convert.ToDateTime(ddr["PrimeiraData"]).ToShortDateString() + " até " + DateTime.Today.AddDays(-1).ToShortDateString() + " existe " + Convert.ToInt32(ddr["Qtde"]).ToString() + " conta";
                    }
                    else
                    {
                        txtInformativo.Text = "Desde " + Convert.ToDateTime(ddr["PrimeiraData"]).ToShortDateString() + " até " + DateTime.Today.AddDays(-1).ToShortDateString() + " existem " + Convert.ToInt32(ddr["Qtde"]).ToString() + " contas"; 
                    }

                    txtInformativo.Text = txtInformativo.Text+ " sem pagamento totalizando " + String.Format("{0:c}", Convert.ToDouble(ddr["ValorTotal"])) + " sem juros ou correção.";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void AtualizaLblAPagar()
        {
            //lblValorPagar.Text = String.Format("{0:c}", lcm.ValorContas(0, Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text)));

            //lblValorPagar.Text= lcm.ValorContas(0, Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text)).ToString();
            lblValorPagar.Text = String.Format("{0:n2}", lcm.ValorContas(0, Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text)));

        }
        private void AtualizaLblPagas()
        {
            lblValorPagas.Text = lcm.ValorContas(1, Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text)).ToString();
        }

        private void AtualizarLblSaldo()
        {
            lblSaldo.Text = (Convert.ToDouble(lblValorPagar.Text) - Convert.ToDouble(lblValorPagas.Text)).ToString();
        }

        private void AtualizaLblAberto() { }

        private void AbrirFormulario(Object o, EventArgs e)
        {
            try
            {
                if (o == btnAlterar && Convert.ToByte(dataGridView1.CurrentRow.Cells["StatusPagTitulo"].Value) == 1)
                {
                    MessageBox.Show("A conta já foi paga. Não é possível alterar os dados.");
                    return;
                }

                FrmCadastroLancamentoContas fcc = new FrmCadastroLancamentoContas();
                fcc.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Inclusao;
                fcc.statusStrip1.Visible = false;
                fcc.Codigo = Codigo; //quem está logado
                if (o == btnIncluir)
                {
                    //fcc.chkAtivo.Checked = false;
                }

                if (o == this.btnAlterar || o == this.btnConsultar)
                {
                    fcc.CodigoLancamento = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CodigoLancamento"].Value);
                    fcc.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Alteracao;

                    fcc.lblRepetir.Visible = false;
                    fcc.lblRepetirMeses.Visible = false;
                    fcc.numVezes.Visible = false;
                    fcc.dgv.Visible = false;
                    fcc.lblProximas.Visible = false;
                    fcc.cboTitulo.Enabled = false;

                    if (o == btnConsultar)
                    {
                        fcc.groupBox1.Enabled = false;
                        fcc.btnGravar.Visible = false;
                        fcc.chkRestrigir.Visible = false;
                        fcc.TipoUso = (byte)BLL.FuncoesGerais.TipoUso.Consulta;
                    }
                }
                var b = (Button)o;
                fcc.label1.Text = label1.Text.PadRight(1) + " > " + b.Text;
                fcc.ShowDialog();

                CarregarDadosGrid(o, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }

       public double ValorDigitadoPagamento;

        Form fValor = new Form();
        TextBox txtDigitarValor = new TextBox();
        private void CriarFormularioDigitarValorPago()
        {
            fValor.Text = "Informe valor com juros e multa da conta vencida desde " + String.Format("{0:d}", dataGridView1.CurrentRow.Cells["DataVencimento"].Value);
            fValor.FormBorderStyle = FormBorderStyle.FixedSingle;
            fValor.AutoSize = false;
            fValor.KeyPreview = true;
            fValor.MinimizeBox = false;
            fValor.MaximizeBox = false;
            fValor.Size = new Size(500, 190);
            fValor.ShowIcon = false;
            fValor.StartPosition = FormStartPosition.CenterParent;

            Label lblTitulo = new Label();
            lblTitulo.Location = new Point(12, 4);
            lblTitulo.Font = new Font(lblTitulo.Font.FontFamily, 16);
            lblTitulo.AutoSize = true;
            lblTitulo.Text = dataGridView1.CurrentRow.Cells["DescricaoTitulo"].Value.ToString();
            fValor.Controls.Add(lblTitulo);

            Label lblValorOriginal = new Label();
            lblValorOriginal.Location = new Point(12, 34);
            lblValorOriginal.Font = new Font(lblValorOriginal.Font.FontFamily, 12);
            lblValorOriginal.AutoSize = true;
            lblValorOriginal.Text = "Valor Original " + String.Format("{0:c}", dataGridView1.CurrentRow.Cells["ValorTitulo"].Value);
            fValor.Controls.Add(lblValorOriginal);

           // TextBox txtDigitarValor = new TextBox();
            txtDigitarValor.Clear();
            txtDigitarValor.Location = new Point(12, 64);
            txtDigitarValor.Font = new Font(txtDigitarValor.Font.FontFamily, 16);
            txtDigitarValor.TextAlign = HorizontalAlignment.Right;
            txtDigitarValor.Text = String.Format("{0:n2}", dataGridView1.CurrentRow.Cells["ValorTitulo"].Value);
            fValor.Controls.Add(txtDigitarValor);

            Button btnOk = new Button();
            btnOk.Location = new Point(12, 104);
            btnOk.Font = new Font(txtDigitarValor.Font.FontFamily, 16);
            btnOk.Size = new Size(94, 37);
            btnOk.Visible = true;
            btnOk.Text = "OK";
            btnOk.ForeColor = System.Drawing.Color.Black;
           btnOk.Click += new System.EventHandler(this.ConfirmarValor);
            fValor.Controls.Add(btnOk);
            fValor.ShowDialog();
            if (Convert.ToDouble(txtDigitarValor.Text) < Convert.ToDouble(dataGridView1.CurrentRow.Cells["ValorTitulo"].Value))
            {
                MessageBox.Show("Valor para pagamento informado não pode ser menor que o valor do título.");
            }
            ValorDigitadoPagamento = Convert.ToDouble(txtDigitarValor.Text);
        }

        public void ConfirmarValor(Object o, EventArgs e)
        {
            fValor.Close();
        }

        private Label label3;
        private Label label2;
        private MaskedTextBox mskDataFinal;
        private Label lblValorPagas;
        private Label lblValorPagar;
        private Label lblPagarAberto;
        private Label lblSaldo;
        private Label label5;
        private MaskedTextBox mskDataInicial;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestaoContasPagar));
            this.mskDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mskDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.lblValorPagas = new System.Windows.Forms.Label();
            this.lblPagarAberto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInformativo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
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
            this.btnTornarAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTornarAtivo.Text = "Pagar/Baixar";
            this.btnTornarAtivo.Click += new System.EventHandler(this.Fixar);
            // 
            // btnDesativar
            // 
            this.btnDesativar.Text = "Cancelar";
            this.btnDesativar.Click += new System.EventHandler(this.Fixar);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Click += new System.EventHandler(this.AbrirFormulario);
            // 
            // chkInativo
            // 
            this.chkInativo.Location = new System.Drawing.Point(144, 41);
            this.chkInativo.Size = new System.Drawing.Size(95, 28);
            this.chkInativo.Text = "A pagar";
            this.chkInativo.Click += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // chkAtivo
            // 
            this.chkAtivo.Location = new System.Drawing.Point(142, 12);
            this.chkAtivo.Size = new System.Drawing.Size(104, 28);
            this.chkAtivo.Text = "Já pagas";
            this.chkAtivo.Click += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(448, 37);
            this.btnFiltrar.Click += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(544, 47);
            this.txtPesquisa.Size = new System.Drawing.Size(208, 29);
            this.txtPesquisa.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPeriodo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSaldo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblValorPagas);
            this.groupBox1.Controls.Add(this.lblValorPagar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mskDataFinal);
            this.groupBox1.Controls.Add(this.mskDataInicial);
            this.groupBox1.Text = "Período";
            this.groupBox1.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkAtivo, 0);
            this.groupBox1.Controls.SetChildIndex(this.chkInativo, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtPesquisa, 0);
            this.groupBox1.Controls.SetChildIndex(this.mskDataInicial, 0);
            this.groupBox1.Controls.SetChildIndex(this.mskDataFinal, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblValorPagar, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblValorPagas, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblSaldo, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.Controls.SetChildIndex(this.cboPeriodo, 0);
            // 
            // mskDataInicial
            // 
            this.mskDataInicial.Location = new System.Drawing.Point(45, 19);
            this.mskDataInicial.Mask = "00/00/0000";
            this.mskDataInicial.Name = "mskDataInicial";
            this.mskDataInicial.Size = new System.Drawing.Size(83, 29);
            this.mskDataInicial.TabIndex = 5;
            this.mskDataInicial.ValidatingType = typeof(System.DateTime);
            this.mskDataInicial.Leave += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // mskDataFinal
            // 
            this.mskDataFinal.Location = new System.Drawing.Point(45, 46);
            this.mskDataFinal.Mask = "00/00/0000";
            this.mskDataFinal.Name = "mskDataFinal";
            this.mskDataFinal.Size = new System.Drawing.Size(83, 29);
            this.mskDataFinal.TabIndex = 6;
            this.mskDataFinal.ValidatingType = typeof(System.DateTime);
            this.mskDataFinal.Leave += new System.EventHandler(this.CarregarDadosGrid);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "De";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Até";
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.AutoSize = true;
            this.lblValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagar.ForeColor = System.Drawing.Color.White;
            this.lblValorPagar.Location = new System.Drawing.Point(799, 19);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(74, 25);
            this.lblValorPagar.TabIndex = 9;
            this.lblValorPagar.Text = "Pagar";
            // 
            // lblValorPagas
            // 
            this.lblValorPagas.AutoSize = true;
            this.lblValorPagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagas.ForeColor = System.Drawing.Color.White;
            this.lblValorPagas.Location = new System.Drawing.Point(792, 53);
            this.lblValorPagas.Name = "lblValorPagas";
            this.lblValorPagas.Size = new System.Drawing.Size(81, 18);
            this.lblValorPagas.TabIndex = 10;
            this.lblValorPagas.Text = "R$ Pagas";
            this.lblValorPagas.Visible = false;
            // 
            // lblPagarAberto
            // 
            this.lblPagarAberto.AutoSize = true;
            this.lblPagarAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagarAberto.ForeColor = System.Drawing.Color.Red;
            this.lblPagarAberto.Location = new System.Drawing.Point(751, 466);
            this.lblPagarAberto.Name = "lblPagarAberto";
            this.lblPagarAberto.Size = new System.Drawing.Size(112, 18);
            this.lblPagarAberto.TabIndex = 11;
            this.lblPagarAberto.Text = "R$ Em aberto";
            this.lblPagarAberto.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Saldo no período";
            this.label5.Visible = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(605, 14);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(77, 18);
            this.lblSaldo.TabIndex = 13;
            this.lblSaldo.Text = "R$ Saldo";
            this.lblSaldo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(752, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "R$";
            // 
            // txtInformativo
            // 
            this.txtInformativo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtInformativo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInformativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformativo.ForeColor = System.Drawing.Color.Red;
            this.txtInformativo.Location = new System.Drawing.Point(278, 3);
            this.txtInformativo.Multiline = true;
            this.txtInformativo.Name = "txtInformativo";
            this.txtInformativo.Size = new System.Drawing.Size(400, 34);
            this.txtInformativo.TabIndex = 12;
            this.txtInformativo.Text = "Não há mensagem";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Escolha um período";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(245, 37);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(179, 32);
            this.cboPeriodo.TabIndex = 16;
            this.cboPeriodo.SelectionChangeCommitted += new System.EventHandler(this.cboPeriodo_SelectionChangeCommitted);
            // 
            // FrmGestaoContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(946, 524);
            this.Controls.Add(this.txtInformativo);
            this.Controls.Add(this.lblPagarAberto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestaoContasPagar";
            this.Text = "Gestão de Contas";
            this.Load += new System.EventHandler(this.CarregarDadosGrid);
            this.Controls.SetChildIndex(this.btnGravar, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnIncluir, 0);
            this.Controls.SetChildIndex(this.btnTornarAtivo, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.lblPagarAberto, 0);
            this.Controls.SetChildIndex(this.btnDesativar, 0);
            this.Controls.SetChildIndex(this.txtInformativo, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
    }
}
