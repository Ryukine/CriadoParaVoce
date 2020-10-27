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
    public partial class FrmVenda : Telas.Modelo.FrmModelo
    {
        public FrmVenda()
        {
            InitializeComponent();
        }

        double ValorTotal;
        public double ValorFinalPagamento;
        public double PagamentoVenda;
        public double ValorTotalQuant;
        private void AbrirForm(Object o, EventArgs e)
        {
            //Associar ao evento LOAD do formulário
            try
            {
                CarregarComboCliente(o, e);
                CarregarComboVendedor(o, e);         
                CarregarComboCategoria(o, e);
                numQuant.Value = 1;
                numPreco.DecimalPlaces = 2;
                numPreco.ThousandsSeparator = true;
                label30.Visible = false;
                label31.Visible = false;
                label34.Visible = false;
                label32.Visible = false;
                txtNumMaximoParcelas.Visible = false;
                txtNumMaxParcelaBD.Visible = false;
                txtValorMinimoParcela.Visible = false;
                txtValMinParcBD.Visible = false;
                txtJurosCarnet.Visible = false;
                txtJurosCarnetBD.Visible = false;
                cboPagamentoCarnet.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FecharProduto(Object o, EventArgs e)
        {
            if (cboProduto.Text.Trim().Length != 0)
            {
                if (chkFecharProduto.Checked)
                {
                    txtDescricao.Enabled = false;
                    cboProduto.Enabled = false;
                    cboCategoria.Enabled = false;
                }
                else
                {
                    //tabControl1.Visible = true;
                    //btnAdicionarPedido.Visible = true;
                    //dataGridView2.Enabled = true;
                    cboCliente.Enabled = true;
                    cboVendedor.Enabled = true;
                    btnIncluirCliente.Enabled = true;
                    txtDescricao.Enabled = true;
                    cboProduto.Enabled = true;
                    cboCategoria.Enabled = true;
                    //txtValorPagar.Text = string.Format("{0:N2}", ValorTotal);
                }
                /*tabControl1.Visible = chkFecharPedido.Checked;
                btnAdicionarPedido.Visible = !chkFecharPedido.Checked;
                dataGridView2.Enabled= !chkFecharPedido.Checked;
                cboCliente.Enabled= !chkFecharPedido.Checked;
                cboVendedor.Enabled= !chkFecharPedido.Checked;
                btnIncluirCliente.Enabled= !chkFecharPedido.Checked;
                txtValorPagar.Text = string.Format("{0:N2}",ValorTotal);*/
            }
            else
            {
                MessageBox.Show("Selecione um Produto");
            }
            /*if (dataGridView2.RowCount <= 1)
            {
                MessageBox.Show("Escolha o produto");
                return;
            }*/
        }

        public double ValorMaximoDesconto;

        //AplicarDesconto usando os textbox da tabpage pagamento
        private void LiberarTextBox(Object o, EventArgs e)
        {
            //o objeto aqui é radiobutton
            //alterei a propriedade TAG de cada radiobutton informando um texto 'Valor'  ou 'Percentual'
            var r = (RadioButton)o;
            if (r.Tag.ToString() == "Percentual")
            {
                ValorMaximoDesconto = 100;
            }
            else
            {
                ValorMaximoDesconto = ValorTotal;
            }

            switch (r.Name.ToString())
            {
                case "rbtPercDesc":
                    txtPercDesconto.Enabled = r.Checked;
                    txtPercDesconto.Focus();
                    if (r.Checked == false)
                    {
                        txtPercDesconto.Text = "0";
                        AplicarDesconto(txtPercDesconto, e);
                    }
                    break;

                case "rbtDescReal":
                    txtDescontoReal.Enabled = r.Checked;
                    txtDescontoReal.Focus();
                    if (r.Checked == false)
                    {
                        txtDescontoReal.Text = "0";
                        AplicarDesconto(txtDescontoReal, e);
                    }
                    break;

                case "rbtPercCupom":
                    txtCupomPerc.Enabled = r.Checked;
                    txtCupomPerc.Focus();
                    if (r.Checked == false)
                    {
                        txtCupomPerc.Text = "0";
                        AplicarDesconto(txtCupomPerc, e);
                    }
                    break;

                case "rbtCupomReal":
                    txtCupomReal.Enabled = r.Checked;
                    txtCupomReal.Focus();
                    if (r.Checked == false)
                    {
                        txtCupomReal.Text = "0";
                        AplicarDesconto(txtCupomReal, e);
                    }
                    break;

                case "rbtCredito":
                    txtCreditoReal.Enabled = r.Checked;
                    txtCreditoReal.Focus();
                    if (r.Checked == false)
                    {
                        txtCreditoReal.Text = "0";
                        AplicarDesconto(txtCreditoReal, e);
                    }
                    break;
            }


            //TextBox txtTipo = new TextBox();
            //txtTipo.Enabled = r.Checked;
            //txtTipo.Focus();
            //if (r.Checked == false)
            //{
            //    txtTipo.Text = "0";
            //    AplicarDesconto(txtTipo, e);
            //}

            //Type t = txtTipo.GetType();
            //PropertyInfo[] props = t.GetProperties();

            //foreach (PropertyInfo controlProperty in props)
            //{
            //    MessageBox.Show(controlProperty.Name.ToString() + " = " + GetPropertyValue(controlProperty.Name, txtTipo));
            //}



            //switch (r.Name.ToString())
            //{
            //    case "rbtPercDesc":
            //        //txtPercDesconto
            //        //txtPercDesconto.GetType().GetProperty("Enabled").SetValue(txtTipo, txtTipo.Enabled, null);
            //        //txtPercDesconto.GetType().GetProperty("Text").SetValue(txtTipo, txtTipo.Text, null);
            //        //>>>>>txtPercDesconto.GetType().GetProperties().SetValue(t,1,props[]);

            //        break;

            //    case "rbtDescReal":
            //        //txtDescontoReal
            //        txtDescontoReal.GetType().GetProperty("Enabled").SetValue(txtTipo, txtTipo.Enabled, null);
            //        txtDescontoReal.GetType().GetProperty("Text").SetValue(txtTipo, txtTipo.Text, null);
            //        break;
            //}



        }

        private void LiberarTextBoxPagar(Object o, EventArgs e)
        {
            //o objeto aqui é radiobutton
            //alterei a propriedade TAG de cada radiobutton informando um texto 'Valor'  ou 'Percentual'
            var r = (RadioButton)o;
            if (r.Tag.ToString() == "Percentual")
            {
                ValorMaximoDesconto = 100;
            }
            else
            {
                ValorMaximoDesconto = ValorTotal;
            }

            switch (r.Name.ToString())
            {
                case "rbtDinheiro":
                    txtDinheiro.Enabled = r.Checked;
                    txtDinheiro.Focus();
                    /*if (r.Checked == false)
                    {
                        txtPercDesconto.Text = "0";
                        AplicarDesconto(txtPercDesconto, e);
                    }*/
                    break;

                case "rbtCartaoDebito":
                    txtCartaoDebito.Enabled = r.Checked;
                    txtCartaoDebito.Focus();
                    /*if (r.Checked == false)
                    {
                        txtDescontoReal.Text = "0";
                        AplicarDesconto(txtDescontoReal, e);
                    }*/
                    break;
            }


            //TextBox txtTipo = new TextBox();
            //txtTipo.Enabled = r.Checked;
            //txtTipo.Focus();
            //if (r.Checked == false)
            //{
            //    txtTipo.Text = "0";
            //    AplicarDesconto(txtTipo, e);
            //}

            //Type t = txtTipo.GetType();
            //PropertyInfo[] props = t.GetProperties();

            //foreach (PropertyInfo controlProperty in props)
            //{
            //    MessageBox.Show(controlProperty.Name.ToString() + " = " + GetPropertyValue(controlProperty.Name, txtTipo));
            //}



            //switch (r.Name.ToString())
            //{
            //    case "rbtPercDesc":
            //        //txtPercDesconto
            //        //txtPercDesconto.GetType().GetProperty("Enabled").SetValue(txtTipo, txtTipo.Enabled, null);
            //        //txtPercDesconto.GetType().GetProperty("Text").SetValue(txtTipo, txtTipo.Text, null);
            //        //>>>>>txtPercDesconto.GetType().GetProperties().SetValue(t,1,props[]);

            //        break;

            //    case "rbtDescReal":
            //        //txtDescontoReal
            //        txtDescontoReal.GetType().GetProperty("Enabled").SetValue(txtTipo, txtTipo.Enabled, null);
            //        txtDescontoReal.GetType().GetProperty("Text").SetValue(txtTipo, txtTipo.Text, null);
            //        break;
            //}



        }

        private void AplicarDesconto(Object o, EventArgs e)
        {
            var t = (TextBox)o;
            //evento LEAVE do textbox que contem o percentual/valor do desconto
            if (BLL.FuncoesGerais.IsNumeric(t.Text))
            {
                if (Convert.ToDouble(t.Text) > ValorMaximoDesconto)
                {
                    MessageBox.Show("Desconto acima do limite permitido.");
                    t.Text = "0";
                    return;
                }
                Double TaxaDesconto = 0;
                if (rbtPercDesc.Checked || rbtPercCupom.Checked)
                {
                    TaxaDesconto = 1 - Convert.ToDouble(t.Text) / 100;
                    txtValorPagar.Text = string.Format("{0:n2}", ValorTotal * TaxaDesconto);
                    ValorFinalPagamento = ValorTotal * TaxaDesconto;
                    Math.Round(ValorFinalPagamento, 2);
                    txtValorParaPagamento.Text = Convert.ToString(ValorFinalPagamento);
                    PagamentoVenda = ValorFinalPagamento;
                }
                else
                {
                    TaxaDesconto = ValorTotal - Convert.ToDouble(t.Text);
                    txtValorPagar.Text = string.Format("{0:n2}", TaxaDesconto);
                    ValorFinalPagamento = TaxaDesconto;
                    Math.Round(ValorFinalPagamento, 2);
                    txtValorParaPagamento.Text = Convert.ToString(ValorFinalPagamento);
                    PagamentoVenda = ValorFinalPagamento;
                }
                //  ValorTotal = ValorTotal * TaxaDesconto;
            }
            else
            {
                MessageBox.Show("Informe o desconto");
                txtPercDesconto.Text = "0";
                txtPercDesconto.Focus();
            }
        }

        private void PreencherComZeroTextBox()
        {
            if (txtDinheiro.Text == "")
            {
                txtDinheiro.Text = "0";
            }
            if (txtCartaoDebito.Text == "")
            {
                txtCartaoDebito.Text = "0";
            }
            /*if (txtCheque.Text == "")
            {
                txtCheque.Text = "0";
            }
            if (txtJurosCarnet.Text == "")
            {
                txtJurosCarnet.Text = "0";
            }
            if (txtNumMaximoParcelas.Text == "")
            {
                txtNumMaximoParcelas.Text = "0";
            }
            if (txtValorMinimoParcela.Text == "0")
            {
                txtValorMinimoParcela.Text = "0";
            }*/

        }
        double Troco;
        private void CalcularTroco(Object o, EventArgs e)
        {
            //txtValorParaPagamento.Text = ValorFinalPagamento.ToString();
            txtValorParaPagamento.Text = string.Format("{0:c}", ValorFinalPagamento);
            //txtCheque.Enabled = false;
            txtCartaoDebito.Enabled = false;
            btnConcluirVendaPagamento.Visible = false;
            if (!BLL.FuncoesGerais.IsNumeric(txtDinheiro.Text))
            {
                MessageBox.Show("Digite o valor em dinheiro recebido");
                return;
            }
            //cboPagamentoCarnet.Visible = false;
            PreencherComZeroTextBox();
            if (Convert.ToDouble(txtDinheiro.Text) > ValorFinalPagamento)
            {
                txtMensagem.Text = "Troco " + string.Format("{0:c}", Convert.ToDouble(txtDinheiro.Text) - ValorFinalPagamento);
                Troco = Convert.ToDouble(txtDinheiro.Text) - ValorFinalPagamento;
            }
            else if (Convert.ToDouble(txtDinheiro.Text) == ValorFinalPagamento)
            {
                txtMensagem.Text = "Sem Troco";
                btnConcluirVendaPagamento.Visible = true;
            }
            else
            {
                txtMensagem.Text = "Faltam " + string.Format("{0:c}", ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text));
                //txtCheque.Enabled = true;
                txtCartaoDebito.Enabled = true;
            }
        }

        private void TrocoPago(Object o, EventArgs e)
        {
            try
            {
                if (chkTroco.Checked)
                {
                    if (txtDinheiro.Text == String.Empty)
                    {
                        MessageBox.Show("Insira um Valor a Pagar");
                    }
                    if (txtMensagem.Text == "Sem Troco")
                    {
                        MessageBox.Show("Não Possui Troco");
                    }

                    btnConcluirVendaPagamento.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CalcularUsandoCartaoDebito(Object o, EventArgs e)
        {
            btnConcluirVendaPagamento.Visible = false;
            if (!BLL.FuncoesGerais.IsNumeric(txtCartaoDebito.Text))
            {
                MessageBox.Show("Digite o valor recebido");
                return;
            }
            cboPagamentoCarnet.Visible = false;
            PreencherComZeroTextBox();
            Double SaldoAPagar = 0;
            SaldoAPagar = ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text);
            if (Convert.ToDouble(txtCartaoDebito.Text) > SaldoAPagar)
            {
                txtMensagem.Text = "Atenção ao valor do cartão débito";
                txtCartaoDebito.Text = SaldoAPagar.ToString();
            }
            else if (Convert.ToDouble(txtCartaoDebito.Text) == SaldoAPagar)
            {
                txtMensagem.Text = "Sem Troco";
                btnConcluirVendaPagamento.Visible = true;
            }
            else
            {
                txtMensagem.Text = "Faltam " + string.Format("{0:c}", SaldoAPagar - Convert.ToDouble(txtCartaoDebito.Text));
                //txtCheque.Enabled = true;
            }
        }

        private void LiberarCartaoDeCredito(Object o, EventArgs e)
        {
            if (chkPagarCartaoCre.Checked)
            {
                label30.Visible = true;
                label31.Visible = true;
                label34.Visible = true;
                label32.Visible = true;
                txtNumMaximoParcelas.Visible = true;
                txtNumMaxParcelaBD.Visible = true;
                txtValorMinimoParcela.Visible = true;
                txtValMinParcBD.Visible = true;
                txtJurosCarnet.Visible = true;
                txtJurosCarnetBD.Visible = true;
                cboPagamentoCarnet.Visible = true;
                txtDinheiro.Enabled = false;
                txtDinheiro.Clear();
                txtCartaoDebito.Enabled = false;
                txtCartaoDebito.Clear();
            }
            else
            {
                label30.Visible = false;
                label31.Visible = false;
                label34.Visible = false;
                label32.Visible = false;
                txtNumMaximoParcelas.Visible = false;
                txtNumMaxParcelaBD.Visible = false;
                txtValorMinimoParcela.Visible = false;
                txtValMinParcBD.Visible = false;
                txtJurosCarnet.Visible = false;
                txtJurosCarnetBD.Visible = false;
                cboPagamentoCarnet.Visible = false;
            }
        }

        private void CarregarCboPagamentoCarnet(Object o, EventArgs e)
        {
            PreencherComZeroTextBox();
            cboPagamentoCarnet.Visible = true;
            cboPagamentoCarnet.Items.Clear();
            cboPagamentoCarnet.Items.Add("1X " + string.Format("{0:c}", ValorFinalPagamento));
            cboPagamentoCarnet.Items.Add("2X " + string.Format("{0:c}", (ValorFinalPagamento / 2.00)));
            cboPagamentoCarnet.Items.Add("3X " + string.Format("{0:c}", (ValorFinalPagamento / 3.00)));
            btnConcluirVendaPagamento.Enabled = true;
            if (!BLL.FuncoesGerais.IsNumeric(txtNumMaximoParcelas.Text) || !BLL.FuncoesGerais.IsNumeric(txtValorMinimoParcela.Text) || !BLL.FuncoesGerais.IsNumeric(txtJurosCarnet.Text))
            {
                MessageBox.Show("Digite apenas números");
                return;
            }
            if (Convert.ToInt32(txtNumMaximoParcelas.Text) > 3 && Convert.ToInt32(txtValorMinimoParcela.Text) > 0)
            {
                cboPagamentoCarnet.Items.Clear();
                for (int i = 1; i <= Convert.ToInt32(txtNumMaximoParcelas.Text); i++)
                {
                    if ((ValorFinalPagamento / i) < Convert.ToInt32(txtValorMinimoParcela.Text))
                    {
                        return;
                    }
                    if (i <= 3)
                    {
                        cboPagamentoCarnet.Items.Add(i + "X sem juros " + string.Format("{0:c}", (ValorFinalPagamento / i)));
                    }
                    else
                    {
                        if (Convert.ToDouble(txtJurosCarnet.Text) > 0)
                        {
                            cboPagamentoCarnet.Items.Add(i + "X com juros de " + txtJurosCarnet.Text + "% " + string.Format("{0:c}", (ValorFinalPagamento / i) * (1 + Convert.ToDouble(txtJurosCarnet.Text) / 100)));
                        }
                        else
                        {
                            cboPagamentoCarnet.Items.Add(i + "X sem juros " + string.Format("{0:c}", (ValorFinalPagamento / i)));
                        }
                    }
                }
            }
        }

        private void cboParcelasTextChanged(Object o, EventArgs e)
        {
            txtMensagem.Text = "Sem Troco";
            btnConcluirVendaPagamento.Visible = true;
        }

        private void SalvarImagem(Object o, EventArgs e)
        {
            try
            {
                SaveFileDialog diretorio = new SaveFileDialog();

                FileDialog file = new SaveFileDialog();

                diretorio.ShowDialog();
                diretorio.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";

                if (diretorio.FileName != null)
                {
                    txtImage.Text = diretorio.FileName;

                    Bitmap bmp = new Bitmap(diretorio.FileName);

                    Bitmap bmp2 = new Bitmap(bmp, pbxImagem.Size);

                    pbxImagem.Image = bmp2;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CarregarComboVendedor(Object o, EventArgs e)
        {
            try
            {
                BLL.Usuario usu = new BLL.Usuario();
                cboVendedor.DataSource = usu.ListaVendedorAtivo().Tables[0];
                cboVendedor.DisplayMember = "NomeUsuario"; //texto
                cboVendedor.ValueMember = "CodigoUsuario"; //pk
                cboVendedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarComboCategoria(Object o, EventArgs e)
        {
            try
            {
                BLL.Categoria categoria = new BLL.Categoria();
                cboCategoria.DataSource = categoria.ListarAtivos().Tables[0];
                cboCategoria.DisplayMember = "DescricaoCategoria";
                cboCategoria.ValueMember = "CategoriaID";
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarComboProduto(Object o, EventArgs e)
        {
            try
            {
                if (cboCategoria.Text.Trim().Length != 0)
                {
                    BLL.Produto produto = new BLL.Produto();
                    cboProduto.DataSource = produto.ListarCbo(Convert.ToInt32(cboCategoria.SelectedValue)).Tables[0];
                    cboProduto.DisplayMember = "NomeProduto";
                    cboProduto.ValueMember = "CodigoProduto";
                    cboProduto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarComboCliente(Object o, EventArgs e)
        {
            try
            {
                BLL.Cliente cli = new BLL.Cliente();
                cboCliente.DataSource = cli.ListarAtivos().Tables[0];
                cboCliente.DisplayMember = "NomeCliente"; //texto
                cboCliente.ValueMember = "CodigoCliente"; //pk
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IncluirNovoCliente(Object o, EventArgs e)
        {
            //associar ao evento CLICK do botão incluir
            try
            {
                CorretoraConvenios.Cliente.FrmClienteCadastro fcc = new CorretoraConvenios.Cliente.FrmClienteCadastro();
                fcc.ShowDialog();
                CarregarComboCliente(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemSelecionado(Object o, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboProduto.SelectedValue) != 0)
                {
                    BLL.Produto prod = new BLL.Produto();
                    System.Data.SqlClient.SqlDataReader dr;
                    prod.CodigoProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    dr = prod.Consultar();
                    if (dr.Read())
                    {
                        txtPrecoProd.Text = dr["PrecoProduto"].ToString();
                        txtPrecoProd.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void AdicionarProdutoFinal(Object o, EventArgs e)
        {
            if (Convert.ToInt32(cboProduto.SelectedValue) == 0)
            {
                errorProvider1.SetError(cboProduto, "Selecione um Produto");
            }
            else
            {
                if (pbxImagem.Image == null)
                {
                    if (MessageBox.Show("Deseja o continuar sem arte ?", "Atencao", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {

                    }

                }
                else
                {
                    int CodigoArte;
                    BLL.Arte arte = new BLL.Arte();
                    arte.NomeArte = txtNomeArte.Text;
                    arte.PrecoArte = Convert.ToDouble(numPreco.Value);
                    arte.Largura = Convert.ToInt32(txtLargura.Text);
                    arte.Altura = Convert.ToInt32(txtAltura.Text);
                    arte.arquivoArte = txtImage.Text;
                    CodigoArte = arte.IncluirRetornarNumeroAutomatico();
                    /*
                     * 
                    errorProvider1.SetError(cboProduto, "");
                    pbxImagem2.Image = pbxImagem.Image;
                    txtProdutoFinal.Text = cboProduto.Text;
                    txtProdutoFinal.ReadOnly = true;
                    txtProdutoFinal.Enabled = false;
                    ValorTotal = Convert.ToDouble(txtPrecoProd.Text) + Convert.ToDouble(numPreco.Value);
                    txtValorTotal.Text = ValorTotal.ToString();
                    txtValorTotal.ReadOnly = true;
                    txtValorTotal.Enabled = false;
                    txtLarguraFinal.Text = txtLargura.Text;
                    txtLarguraFinal.ReadOnly = true;
                    txtLarguraFinal.Enabled = false;
                    txtAlturaFinal.Text = txtAltura.Text;
                    txtAlturaFinal.ReadOnly = true;
                    txtAlturaFinal.Enabled = false;*/
                    ValorTotal = (ValorTotal + (Convert.ToInt32(numQuant.Text) * Convert.ToDouble(txtPrecoProd.Text)) + (Convert.ToInt32(numQuant.Text) * Convert.ToDouble(numPreco.Value)));
                    txtValorTotal.Text = Convert.ToString(ValorTotal);
                    ValorFinalPagamento = ValorTotal;

                    if (dataGridView2.ColumnCount == 0)
                {
                    dataGridView2.Columns.Add("Quantidade", "Qte");
                    dataGridView2.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["Quantidade"].Width = 60;

                    dataGridView2.Columns.Add("Produto", "Nome Produto");

                    dataGridView2.Columns.Add("Preco Unitario", "R$ Unit");
                    dataGridView2.Columns["Preco Unitario"].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns["Preco Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.Columns.Add("Total", "R$ Total");
                    dataGridView2.Columns["Total"].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.Columns.Add("Codigo Produto", "CodProd");
                    dataGridView2.Columns["Codigo Produto"].Visible = false;

                    dataGridView2.Columns.Add("Codigo Arte", "CodArte");
                    dataGridView2.Columns["Codigo Arte"].Visible = false;

                    dataGridView2.Columns.Add("Preco Arte", "R$ Arte");
                    dataGridView2.Columns["Preco Arte"].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns["Preco Arte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                var index = dataGridView2.Rows.Add();

                    double PrecoArte;
                    PrecoArte = Convert.ToDouble(numPreco.Value) * Convert.ToDouble(numQuant.Value);

                    double PrecoProduto;
                    PrecoProduto = Convert.ToDouble(txtPrecoProd.Text) * Convert.ToDouble(numQuant.Value);

                // dataGridView2.Rows[index].Cells["Quantidade"].Value = (Int32)numQuant.Value;

                dataGridView2.Rows[index].Cells["Quantidade"].Value = Convert.ToInt32(numQuant.Text);

                dataGridView2.Rows[index].Cells["Produto"].Value = Convert.ToString(cboProduto.Text);

                dataGridView2.Rows[index].Cells["Preco Unitario"].Value = Convert.ToDecimal(numPreco.Text);

                dataGridView2.Rows[index].Cells["Preco Arte"].Value = Convert.ToDecimal(PrecoArte);

                    // dataGridView2.Rows[index].Cells["Total"].Value = Convert.ToDecimal(numQuant.Value*Convert.ToDecimal(txtValorUnitario.Text));

                dataGridView2.Rows[index].Cells["Total"].Value = Convert.ToDecimal(PrecoProduto);

                dataGridView2.Rows[index].Cells["Codigo Produto"].Value = Convert.ToString(cboProduto.SelectedValue);

                dataGridView2.Rows[index].Cells["Codigo Arte"].Value = CodigoArte;

                numPreco.Text = "0"; //Clear irá gerar erro
                //numQuant.Value = 0;
                numQuant.Text = "1";
                
                }
                /*errorProvider1.SetError(cboProduto, "");
                pbxImagem2.Image = pbxImagem.Image;
                txtProdutoFinal.Text = cboProduto.Text;
                txtProdutoFinal.ReadOnly = true;
                resultado = Convert.ToDouble(txtPrecoProd.Text) + Convert.ToDouble(numPreco.Value);
                txtValorTotal.Text = resultado.ToString();
                txtValorTotal.ReadOnly = true;
                txtLarguraFinal.Text = txtLargura.Text;
                txtLarguraFinal.ReadOnly = true;
                txtAlturaFinal.Text = txtAltura.Text;
                txtAlturaFinal.ReadOnly = true;*/
                }
            }

        private void RemoverProdutoPedido(Object o, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        ValorTotal = ValorTotal - ((Convert.ToDouble(dataGridView2.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView2.CurrentRow.Cells["Preco Unitario"].Value)) - (Convert.ToDouble(dataGridView2.CurrentRow.Cells["Quantidade"].Value)) * (Convert.ToDouble(dataGridView2.CurrentRow.Cells["Preco Arte"].Value)));
                        txtValorTotal.Text = string.Format("{0:c}", Convert.ToDecimal(ValorTotal));
                        txtValorPedido.Text = txtValorTotal.Text;
                        dataGridView2.Rows.Remove(row);
                    }
                }
                if (dataGridView2.RowCount <= 1)
                {
                    //tabControl1.Visible = false;
                    chkFecharPedido.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NaoInformarCliente(Object o, EventArgs e)
        {
            if (chkNaoCliente.Checked)
            {
                cboCliente.Enabled = false;
                cboCliente.Text = "";
            }
            else
            {
                cboCliente.Enabled = true;
            }
        }

        private void NaoInformarVendedor(Object o, EventArgs e)
        {
            if (chkNaoVendedor.Checked)
            {
                cboVendedor.Enabled = false;
                cboVendedor.Text = "";
            }
            else
            {
                cboVendedor.Enabled = true;
            }
        }

        private void FecharPedido(Object o, EventArgs e)
        {
            if (cboProduto.Text.Trim().Length != 0)
            {
                errorProvider1.SetError(cboProduto, "");
                if (chkFecharPedido.Checked)
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    txtValorParaPagamento.Text = ValorFinalPagamento.ToString();
                    txtValorPedido.Text = ValorTotal.ToString();
                }
                else
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                }
            }
            else
            {
                errorProvider1.SetError(cboProduto, "Selecione o Produto");
                MessageBox.Show("Selecione um Produto");
            }
         
        }

        private void cboCategoria_TextChanged(Object o, EventArgs e)
        {
            if (cboCategoria.ValueMember == String.Empty)
            {
                return;
            }
            cboProduto.SelectedIndex = -1;
            CarregarComboProduto(o, e);
        }

        private void cboProduto_TextChanged(Object o, EventArgs e)
        {
            if (cboProduto.ValueMember == String.Empty)
            {
                return;
            }
            txtPrecoProd.Clear();
            ItemSelecionado(o, e);
        }

        private void ConcluirVenda(Object o, EventArgs e)
        {
            try
            {
               if (txtMensagem.Text != "Sem Troco")
               {
                 errorProvider1.SetError(txtMensagem, "Coloque o Valor Total do Pagamento"); return;
               }

                BLL.Venda venda = new BLL.Venda();
                BLL.Item_Venda item = new BLL.Item_Venda();
                BLL.Arte arte = new BLL.Arte();
                BLL.Pedido pedido = new BLL.Pedido();
                BLL.ProdutoFinal produtoFinal = new BLL.ProdutoFinal();
                BLL.FormaPagamento forma = new BLL.FormaPagamento();
                BLL.FormaVenda formaVenda = new BLL.FormaVenda();

                arte.arquivoArte = txtImage.Text;
                arte.Altura = Convert.ToInt32(txtAltura.Text);
                arte.Largura = Convert.ToInt32(txtLargura.Text);
                arte.NomeArte = txtNomeArte.Text;
                arte.PrecoArte = Convert.ToDouble(numPreco.Value);

                produtoFinal.CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue);
                produtoFinal.CodigoProduto = Convert.ToInt32(cboProduto.SelectedValue);
                produtoFinal.DescricaoProd = cboProduto.Text + " " + cboCategoria.Text;
                produtoFinal.NomeProdutoFinal = cboProduto.Text + " " + txtNomeArte.Text;
                produtoFinal.PrecoProdutoFinal = Convert.ToDouble(txtValorTotal.Text);
                produtoFinal.StatusProdutoFinal = 1;
                if (chkPagarCartaoCre.Checked)
                {
                    formaVenda.CodigoPagamento = 2;
                }
                else
                {
                    if (txtCartaoDebito.Text.Trim().Length != 0 && txtDinheiro.Text.Trim().Length != 0)
                    {
                        formaVenda.CodigoPagamento = 4;
                    }
                    if (txtDinheiro.Text.Trim().Length != 0)
                    {
                        formaVenda.CodigoPagamento = 1;
                    }

                    if (txtCartaoDebito.Text.Trim().Length != 0)
                    {
                        formaVenda.CodigoPagamento = 3;
                    }
                }

                //item.PrecoTotal = Convert.ToDouble(ValorFinalPagamento);

                venda.CodigoCliente = Convert.ToInt32(cboCliente.SelectedValue);
                venda.CodigoFunc = Convert.ToInt32(cboVendedor.SelectedValue);
                pedido.Descricao = cboProduto.Text + " " + cboCategoria.Text;
                pedido.PrecoTotal = Convert.ToDouble(txtValorTotal.Text);
                pedido.Quantidade = Convert.ToInt32(numQuant.Value);
                venda.DataVenda = DateTime.Now;
                if (chkNaoCliente.Checked)
                {
                    venda.CodigoCliente = 1;
                }
                else
                {
                    venda.CodigoCliente = Convert.ToInt32(cboCliente.SelectedValue);
                }

                if (chkNaoVendedor.Checked)
                {
                    venda.CodigoFunc = 1;
                }
                else
                {
                    venda.CodigoFunc = Convert.ToInt32(cboVendedor.SelectedValue);
                }

                produtoFinal.IdArte = arte.IncluirRetornarNumeroAutomatico();
                pedido.CodigoProdutoFinal = produtoFinal.IncluirRetornarNumeroAutomatico();
                venda.CodigoPedido = pedido.IncluirRetornarNumeroAutomatico();
                formaVenda.CodigoVenda = venda.IncluirRetornarNumeroAutomatico();
                formaVenda.IncluirComParametro();
                MessageBox.Show("Venda Concluida Com Sucesso");
                FrmSistema frmsistema = new FrmSistema();
                Hide();
                frmsistema.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void numQuant_ValueChanged(Object o, EventArgs e)
        {
            ValorTotalQuant = Convert.ToInt32(numQuant.Value) * Convert.ToInt32(numPreco.Value);
            ValorTotal = ValorTotalQuant + ValorTotal;
            txtValorTotal.Text = ValorTotal.ToString();
        }

        private void btnConcluirVendaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoVenda;
                if (!chkTroco.Checked)
                {
                    if (txtMensagem.Text != "Sem Troco")
                    {
                        errorProvider1.SetError(txtMensagem, "Coloque o Valor Total do Pagamento"); return;
                    }
                }

                BLL.Venda venda = new BLL.Venda();
                BLL.Item_Venda item = new BLL.Item_Venda();
                BLL.Pedido pedido = new BLL.Pedido();
                BLL.FormaPagamento forma = new BLL.FormaPagamento();
                BLL.FormaVenda formaVenda = new BLL.FormaVenda();

                if (chkPagarCartaoCre.Checked == true)
                {
                    formaVenda.CodigoPagamento = 2;
                }
                else if (txtDinheiro.Text.Trim().Length != 0 && txtDinheiro.Text != "0")
                {
                    formaVenda.CodigoPagamento = 1;
                }
                else if (txtCartaoDebito.Text.Trim().Length != 0 && txtDinheiro.Text.Trim().Length != 0 && txtCartaoDebito.Text != "0" && txtDinheiro.Text != "0")
                {
                    formaVenda.CodigoPagamento = 4;
                }
                else if (txtCartaoDebito.Text.Trim().Length != 0)
                {
                    formaVenda.CodigoPagamento = 3;
                }


                item.PrecoTotal = Convert.ToDouble(ValorFinalPagamento);
                pedido.PrecoTotal = Convert.ToDouble(ValorFinalPagamento);
                pedido.Quantidade = Convert.ToInt32(dataGridView2.Columns.Count);
                venda.DataVenda = DateTime.Now;
                if (chkNaoCliente.Checked)
                {
                    venda.CodigoCliente = 1;
                }
                else
                {
                    venda.CodigoCliente = Convert.ToInt32(cboCliente.SelectedValue);
                }

                if (chkNaoVendedor.Checked)
                {
                    venda.CodigoFunc = 1;
                }
                else
                {
                    venda.CodigoFunc = Convert.ToInt32(cboVendedor.SelectedValue);
                }

                venda.CodigoPedido = 1;
                venda.Troco = Troco;
                CodigoVenda = venda.IncluirRetornarNumeroAutomatico();
                item.CodigoVenda = CodigoVenda;
                item.PrecoTotal = ValorFinalPagamento;
                for (int i = 0; i < (dataGridView2.Rows.Count - 1); i++)
                {
                    item.CodigoProduto = Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
                    item.CodigoArte = Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
                    item.Quantidade = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                    pedido.CodigoProdutoFinal = Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
                    item.IncluirComParametro();
                }
                formaVenda.CodigoVenda = CodigoVenda;
                formaVenda.IncluirComParametro();
                MessageBox.Show("Venda Concluida Com Sucesso");
                Hide();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
    }
}
