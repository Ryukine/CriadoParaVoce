using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva.ContasPagar
{
    public partial class FrmCadastroLancamentoContas : Telas.Modelo.FrmModeloCadastro
    {

        //http://www.csharp-examples.net/string-format-datetime/

        public FrmCadastroLancamentoContas()
        {
            InitializeComponent();
            CarregarComboTitulo();
        }

        public DataGridView dgv;
        public Label lblProximas;
        public Label lblRepetirMeses;
        public NumericUpDown numVezes;
        public Label lblRepetir;
        BLL.Lancamento lcm = new BLL.Lancamento();
        public CheckBox chkRestrigir;
        private int _CodigoLancamento;

        private void CarregarComboTitulo()
        {
            try
            {
                BLL.Titulo tit = new BLL.Titulo();
                cboTitulo.DataSource = tit.Listar("", 1).Tables[0];
                cboTitulo.DisplayMember = "DescricaoTitulo"; //texto
                cboTitulo.ValueMember = "CodigoTitulo"; //pk
                if (TipoUso == (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    cboTitulo.SelectedIndex = -1;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarGrid(Object o, EventArgs e)
        {

            dgv.DataSource = lcm.ListarTitulosEmAberto(Convert.ToInt32(cboTitulo.SelectedValue)).Tables[0];
            dgv.AutoResizeColumns();

        }

        public bool IsDigitacaoCorreta()
        {
            if (cboTitulo.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboTitulo, "Escolha a conta");
                cboTitulo.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cboTitulo, "");
            }

            if (!BLL.FuncoesGerais.IsDataValida(mskDataVencTitulo.Text))
            {
                errorProvider1.SetError(mskDataVencTitulo, "Informe uma data válida");
                mskDataVencTitulo.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(mskDataVencTitulo, "");
            }

            if (chkRestrigir.Checked)
            {
                if (Convert.ToDateTime(mskDataVencTitulo.Text) < DateTime.Today)
                {
                    errorProvider1.SetError(mskDataVencTitulo, "Data de vencimento não permitida");
                    mskDataVencTitulo.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(mskDataVencTitulo, "");
                }
            }

            if (!BLL.FuncoesGerais.IsNumeric(txtValorTitulo.Text))
            {
                errorProvider1.SetError(txtValorTitulo, "Informe um valor");
                txtValorTitulo.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtValorTitulo, "");
            }

            return true;

        }


        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                if (TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    System.Data.SqlClient.SqlDataReader dr;
                  
                    lcm.CodigoLancamento = CodigoLancamento;
                    dr = lcm.Consultar();
                    if (dr.Read())
                    {
                     
                        cboTitulo.SelectedValue = (Int32)dr["codigotitulo"];
                        txtValorTitulo.Text = Convert.ToDouble(dr["ValorTitulo"]).ToString();
                        mskDataVencTitulo.Text = Convert.ToDateTime(dr["DataVencimento"]).ToString();
                    }

                }

                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }

        private void Gravar(Object o, EventArgs e)
        {
            try
            {
                if (!IsDigitacaoCorreta())
                {
                    return;
                }

                lcm.CodigoUsuario = Codigo; 
                lcm.CodigoTitulo = (Int32)cboTitulo.SelectedValue;
                lcm.DataVencimento = Convert.ToDateTime(mskDataVencTitulo.Text);
                lcm.ValorTitulo = Convert.ToDouble(txtValorTitulo.Text);

                if (TipoUso == (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    if (numVezes.Value == 1)
                    {
                        lcm.Incluir();
                    }
                    else
                    {
                        for (int i = 0; i <= numVezes.Value; i++)
                        {
                            lcm.Incluir();
                            lcm.DataVencimento = Convert.ToDateTime(mskDataVencTitulo.Text).AddMonths(i + 1);
                        }
                    }
                    MessageBox.Show("Inclusão realizada com sucesso.", "Aviso");
                }

                if (TipoUso == (byte)BLL.FuncoesGerais.TipoUso.Alteracao)
                {
                    lcm.Atualizar();
                    MessageBox.Show("Dados atualizados com sucesso.", "Aviso");
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }
        
















        public TextBox txtValorTitulo;
        private Label label4;
        public MaskedTextBox mskDataVencTitulo;
        private Label label3;
        public ComboBox cboTitulo;
        private Label label2;

        public int CodigoLancamento
        {
            get
            {
                return _CodigoLancamento;
            }

            set
            {
                _CodigoLancamento = value;
            }
        }

        //public int CodigoLancamento { get => _CodigoLancamento; set => _CodigoLancamento = value; }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroLancamentoContas));
            this.label2 = new System.Windows.Forms.Label();
            this.cboTitulo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mskDataVencTitulo = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorTitulo = new System.Windows.Forms.TextBox();
            this.lblProximas = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblRepetir = new System.Windows.Forms.Label();
            this.numVezes = new System.Windows.Forms.NumericUpDown();
            this.lblRepetirMeses = new System.Windows.Forms.Label();
            this.chkRestrigir = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVezes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRepetirMeses);
            this.groupBox1.Controls.Add(this.numVezes);
            this.groupBox1.Controls.Add(this.lblRepetir);
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Controls.Add(this.lblProximas);
            this.groupBox1.Controls.Add(this.txtValorTitulo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mskDataVencTitulo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTitulo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkRestrigir);
            this.groupBox1.Size = new System.Drawing.Size(529, 246);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(327, 292);
            this.btnGravar.Click += new System.EventHandler(this.Gravar);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(439, 292);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Conta";
            // 
            // cboTitulo
            // 
            this.cboTitulo.FormattingEnabled = true;
            this.cboTitulo.Location = new System.Drawing.Point(8, 39);
            this.cboTitulo.Name = "cboTitulo";
            this.cboTitulo.Size = new System.Drawing.Size(471, 32);
            this.cboTitulo.TabIndex = 1;
            this.cboTitulo.SelectionChangeCommitted += new System.EventHandler(this.CarregarGrid);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Vencimento";
            // 
            // mskDataVencTitulo
            // 
            this.mskDataVencTitulo.Location = new System.Drawing.Point(8, 97);
            this.mskDataVencTitulo.Mask = "00/00/0000";
            this.mskDataVencTitulo.Name = "mskDataVencTitulo";
            this.mskDataVencTitulo.Size = new System.Drawing.Size(91, 29);
            this.mskDataVencTitulo.TabIndex = 3;
            this.mskDataVencTitulo.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor R$";
            // 
            // txtValorTitulo
            // 
            this.txtValorTitulo.Location = new System.Drawing.Point(8, 151);
            this.txtValorTitulo.Name = "txtValorTitulo";
            this.txtValorTitulo.Size = new System.Drawing.Size(91, 29);
            this.txtValorTitulo.TabIndex = 5;
            this.txtValorTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblProximas
            // 
            this.lblProximas.AutoSize = true;
            this.lblProximas.Location = new System.Drawing.Point(231, 87);
            this.lblProximas.Name = "lblProximas";
            this.lblProximas.Size = new System.Drawing.Size(216, 24);
            this.lblProximas.TabIndex = 6;
            this.lblProximas.Text = "Próximas contas a pagar";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(233, 107);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(284, 122);
            this.dgv.TabIndex = 7;
            // 
            // lblRepetir
            // 
            this.lblRepetir.AutoSize = true;
            this.lblRepetir.Location = new System.Drawing.Point(6, 180);
            this.lblRepetir.Name = "lblRepetir";
            this.lblRepetir.Size = new System.Drawing.Size(173, 24);
            this.lblRepetir.TabIndex = 8;
            this.lblRepetir.Text = "Repetir lançamento";
            // 
            // numVezes
            // 
            this.numVezes.Location = new System.Drawing.Point(8, 201);
            this.numVezes.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numVezes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVezes.Name = "numVezes";
            this.numVezes.Size = new System.Drawing.Size(91, 29);
            this.numVezes.TabIndex = 9;
            this.numVezes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVezes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRepetirMeses
            // 
            this.lblRepetirMeses.AutoSize = true;
            this.lblRepetirMeses.Location = new System.Drawing.Point(105, 203);
            this.lblRepetirMeses.Name = "lblRepetirMeses";
            this.lblRepetirMeses.Size = new System.Drawing.Size(66, 24);
            this.lblRepetirMeses.TabIndex = 10;
            this.lblRepetirMeses.Text = "Meses";
            // 
            // chkRestrigir
            // 
            this.chkRestrigir.AutoSize = true;
            this.chkRestrigir.Checked = true;
            this.chkRestrigir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestrigir.Location = new System.Drawing.Point(117, 102);
            this.chkRestrigir.Name = "chkRestrigir";
            this.chkRestrigir.Size = new System.Drawing.Size(108, 28);
            this.chkRestrigir.TabIndex = 11;
            this.chkRestrigir.Text = "Restringir";
            this.chkRestrigir.UseVisualStyleBackColor = true;
            // 
            // FrmCadastroLancamentoContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(600, 364);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCadastroLancamentoContas";
            this.Text = "Lançamento de Contas";
            this.Load += new System.EventHandler(this.CarregarCampos);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVezes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
