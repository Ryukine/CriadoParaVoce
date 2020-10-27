using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Telas_Inf2DM.Funcionalidades
{
    public partial class FrmVender : Form
    {
        public FrmVender()
        {
            InitializeComponent();
        }
        
        //alterar a propriedade KEYPREVIEW do formulário para TRUE

        public int QuantItensPedido;
        public double ValorTotal;
        public int LinhaAnterior;
        public double ValorFinalPagamento;
        public int QuantProduto;
        public byte TipoStatus = 1;

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

        private void CarregarComboVendedor(Object o, EventArgs e )
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

        private void CarregarDadosGridProduto(Object o, EventArgs e)
        {
            try
            {
                BLL.Produto pro = new BLL.Produto();
                dataGridView1.DataSource = pro.Listar(txtPesquisa.Text).Tables[0];

                dataGridView1.Columns[0].HeaderText = "Cod";
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridView1.Columns[1].HeaderText = "Produto";
                dataGridView1.AutoResizeColumn(1);

                dataGridView1.Columns[2].HeaderText = "R$ Unit";
                dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridView1.Columns[3].HeaderText = "Quant";
                dataGridView1.AutoResizeColumn(3);
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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

        private void AbrirForm(Object o, EventArgs e)
        {
            //Associar ao evento LOAD do formulário
            try
            {
                CarregarComboCliente(o,e);
                CarregarComboVendedor(o,e);
                CarregarDadosGridProduto(o,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void EscolherProduto(Object o, DataGridViewCellEventArgs e)
        {
            //associar ao evento CELLCLICK do datagridview1
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) > 0)
            {
                QuantProduto++;
                //numQuant.Value++;
                txtNumQuant.Text = QuantProduto.ToString();
                LinhaAnterior = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.CurrentRow.Cells[3].Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) - 1;
                txtValorUnitario.Text = string.Format("{0:N2}", Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value));
            }
        }
        
        private void ReiniciarProduto(Object o,DataGridViewCellEventArgs e)
        {
            //associar ao evento CELLENTER do datagridview1
            if (LinhaAnterior > -1)
            {
                //dataGridView1.Rows[LinhaAnterior].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[LinhaAnterior].Cells[3].Value) + Convert.ToInt32(numQuant.Value);
                //numQuant.Value = 0;
                dataGridView1.Rows[LinhaAnterior].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[LinhaAnterior].Cells[3].Value) + QuantProduto;
                QuantProduto = 0;
            }
        }

        private void PermitirCombo(bool Status)
        {
            cboCliente.Enabled = Status;
            cboVendedor.Enabled = Status;
            btnIncluirCliente.Visible = Status;
        }

        private void IncluirProdutoListaVenda(Object o, EventArgs e)
        {
            //Evento CLICK do botão adicionar ao pedido  = CarrinhoCompra   FazerPedido
            try
            {
                if (cboCliente.SelectedIndex==-1 && !chkNaoCliente.Checked)
                {
                    MessageBox.Show("Escolha Cliente");
                    return;
                }
                if (cboVendedor.SelectedIndex==-1 && !chkNaoVendedor.Checked)
                {
                    MessageBox.Show("Escolha Vendedor");
                    return;
                }
                //if (numQuant.Value == 0 )
                //{
                //    MessageBox.Show("Escolha o produto");
                //    return;
                //}
                if (QuantProduto == 0)
                {
                    MessageBox.Show("Escolha o produto");
                    return;
                }
                //ValorTotal = ValorTotal + ((Double)numQuant.Value * Convert.ToDouble(txtValorUnitario.Text));
                //QuantItensPedido = (Int32)numQuant.Value + QuantItensPedido;

                ValorTotal = (ValorTotal + (Convert.ToInt32(txtNumQuant.Text)* Convert.ToDouble(txtValorUnitario.Text)));
                QuantItensPedido = Convert.ToInt32(txtNumQuant.Text) + QuantItensPedido;

                System.Math.Round(ValorTotal, 1);

                ValorFinalPagamento = ValorTotal;

                txtValorTotal.Text = string.Format("{0:c}", Convert.ToDecimal(ValorTotal));
                txtValorPedido.Text = txtValorTotal.Text;
                txtQuantItens.Text = QuantItensPedido.ToString();
                //if (QuantItensPedido > 0)
                //{
                //    PermitirCombo(false);
                //}
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
                }

                var index = dataGridView2.Rows.Add();

                // dataGridView2.Rows[index].Cells["Quantidade"].Value = (Int32)numQuant.Value;

                dataGridView2.Rows[index].Cells["Quantidade"].Value = Convert.ToInt32(txtNumQuant.Text);

                dataGridView2.Rows[index].Cells["Produto"].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

                dataGridView2.Rows[index].Cells["Preco Unitario"].Value = Convert.ToDecimal(txtValorUnitario.Text);

               // dataGridView2.Rows[index].Cells["Total"].Value = Convert.ToDecimal(numQuant.Value*Convert.ToDecimal(txtValorUnitario.Text));

                dataGridView2.Rows[index].Cells["Total"].Value = Convert.ToDecimal(Convert.ToInt32(txtNumQuant.Text)* Convert.ToDecimal(txtValorUnitario.Text));

                dataGridView2.Rows[index].Cells["Codigo Produto"].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);

                txtValorUnitario.Text = "0"; //Clear irá gerar erro
                //numQuant.Value = 0;
                txtNumQuant.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FecharPedido(Object o, EventArgs e)
        {
            if (ValorTotal > 0)
            {
                if (chkFecharPedido.Checked)
                {
                    tabControl1.Visible = true;
                    btnAdicionarPedido.Visible = false;
                    dataGridView2.Enabled = false;
                    cboCliente.Enabled = false;
                    cboVendedor.Enabled = false;
                    btnIncluirCliente.Enabled = false;
                    txtValorPagar.Text = string.Format("{0:N2}", ValorTotal);
                }
                else
                {
                    tabControl1.Visible = true;
                    btnAdicionarPedido.Visible = true;
                    dataGridView2.Enabled = true;
                    cboCliente.Enabled = true;
                    cboVendedor.Enabled = true;
                    btnIncluirCliente.Enabled = true;
                    txtValorPagar.Text = string.Format("{0:N2}", ValorTotal);
                }
                /*tabControl1.Visible = chkFecharPedido.Checked;
                btnAdicionarPedido.Visible = !chkFecharPedido.Checked;
                dataGridView2.Enabled= !chkFecharPedido.Checked;
                cboCliente.Enabled= !chkFecharPedido.Checked;
                cboVendedor.Enabled= !chkFecharPedido.Checked;
                btnIncluirCliente.Enabled= !chkFecharPedido.Checked;
                txtValorPagar.Text = string.Format("{0:N2}",ValorTotal);*/
            }
            if (dataGridView2.RowCount <= 1)
            {
                MessageBox.Show("Escolha o produto");
                return;
            }
        }
        
        private void LocalizarProdutoGridDevolverQuantidadeRemovida()
        {
            //https://stackoverflow.com/questions/13173915/search-for-value-in-datagridview-in-a-column
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(dataGridView2.CurrentRow.Cells["Codigo Produto"].Value))
                    {
                        //row.Selected = true; //marca a linha no grid em que houve a devolução
                        row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["Quantidade"].Value);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void RemoverProdutoPedido(Object o, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows )
                {
                    if (!row.IsNewRow)
                    {
                        ValorTotal = ValorTotal - ((Convert.ToDouble(dataGridView2.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView2.CurrentRow.Cells["Preco Unitario"].Value)));
                        txtValorTotal.Text = string.Format("{0:c}", Convert.ToDecimal(ValorTotal));
                        txtValorPedido.Text = txtValorTotal.Text;
                        QuantItensPedido = QuantItensPedido - Convert.ToInt32(dataGridView2.CurrentRow.Cells["Quantidade"].Value);
                        txtQuantItens.Text = QuantItensPedido.ToString();
                        if (QuantItensPedido == 0)
                        {
                            PermitirCombo(true);
                        }
                        LocalizarProdutoGridDevolverQuantidadeRemovida();
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

        private void PesquisarProduto(Object o, EventArgs e)
        {
            //associar ao evento LEAVE do textbox de pesquisa - o método LISTAR da classe PRODUTO foi alterada para diferenciar quando é um código ou para quando é um nome do produto
            try
            {
                  CarregarDadosGridProduto(o, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    t.Text ="0";
                    return;
                }
                Double TaxaDesconto = 0;
                if (rbtPercDesc.Checked || rbtPercCupom.Checked)
                {
                    TaxaDesconto = 1 - Convert.ToDouble(t.Text) / 100;
                    txtValorPagar.Text = string.Format("{0:n2}", ValorTotal * TaxaDesconto);
                    ValorFinalPagamento = ValorTotal * TaxaDesconto;
                }
                else
                {
                    TaxaDesconto = ValorTotal - Convert.ToDouble(t.Text);
                    txtValorPagar.Text = string.Format("{0:n2}", TaxaDesconto);
                    ValorFinalPagamento = TaxaDesconto;
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

        private void CancelarPedido(Object o, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            ValorTotal = 0;
            QuantItensPedido = 0;
            LinhaAnterior = -1;
            cboCliente.SelectedIndex = -1;
            cboVendedor.SelectedIndex = -1;

            //numQuant.Value = 0;
            txtNumQuant.Text = "0";
            QuantProduto = 0;

            txtValorUnitario.Clear();
            txtValorTotal.Clear();
                txtValorPedido.Clear();
        }

        private void BloquearGuiaDesconto(Object o, EventArgs e)
        {
            if (chkNaoVendedor.Checked)
            {
                tabControl1.TabPages.Remove(tabPageValor);
            }
            else
            {
                //tabControl1.TabPages.Add(tabPageValor);
                tabControl1.TabPages.Insert(1, tabPageValor);
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
                    if ((ValorFinalPagamento/i) < Convert.ToInt32(txtValorMinimoParcela.Text))
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
        
        /// <summary>
        /// Método BuscarParametros - realiza consulta na tabela de parametros de pagamentos
        /// </summary>
        private void BuscarParametros()
        {
            try
            {
                BLL.ParametrosPagamento pag = new BLL.ParametrosPagamento();
                pag.StatusParametroPagamento = 1;
                pag.CodigoParametroPagamento = 1;
                System.Data.SqlClient.SqlDataReader dr;
                dr = pag.Consultar();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNumMaxParcelaBD.Text = Convert.ToString(dr["NumeroMaximoParcelasCarnet"]);
                    txtJurosCarnetBD.Text = Convert.ToString(dr["TaxaJurosParcelasCarnet"]);
                    txtValMinParcBD.Text = Convert.ToString(dr["ValorParcelaMinimaCarnet"]);
                    /*
                    CodigoParametroPagamento
                    StatusParametroPagamento
                    NumeroMinimoParcelasSemJurosCarnet
                    NumeroMaximoParcelasCarnet
                    TaxaJurosParcelasCarnet
                    ValorParcelaMinimaCarnet
                    TaxaJurosParcelasCarnet
                    NumeroMaximoParcelasCarnet
                    NumeroMinimoParcelasSemJurosCarnet
                    NumeroParcelasCartaoCreditoSemJuros
                    NumeroMaximoParcelasCartaoCredito
                    TaxaJurosParcelasCartaoCredito;
                    ValorParcelaMinimaPagamentoCartaoCredito
                    DataAtualizacaoParametrosPagamento 
                    */
                }
                else
                {
                    txtNumMaxParcelaBD.Text = "0";
                    txtJurosCarnetBD.Text = "0";
                    txtValMinParcBD.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        
        private void CriarFormularioDigitarQuantidade()
        {
            //dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) + numQuant.Value);
            //numQuant.Value = 0;

            dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) + Convert.ToInt32(txtNumQuant.Text));
            txtValorUnitario.Text = string.Format("{0:N2}", Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value));

            txtNumQuant.Text = "0";
            QuantProduto = 0;
            Form fQuant = new Form();
            fQuant.Text = "Informe quantidade do produto. Em estoque há " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fQuant.FormBorderStyle = FormBorderStyle.FixedSingle;
            fQuant.AutoSize = false;
            fQuant.KeyPreview = true;
            fQuant.MinimizeBox = false;
            fQuant.MaximizeBox = false;
            fQuant.Size = new Size(500, 150);
            fQuant.StartPosition = FormStartPosition.CenterParent;
            Label lblProduto = new Label();
            lblProduto.Location = new Point(12, 12);
            lblProduto.Font = new Font(lblProduto.Font.FontFamily, 16);
            lblProduto.AutoSize = true;
            lblProduto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fQuant.Controls.Add(lblProduto);

            TextBox txtDigitarQuant = new TextBox();
            txtDigitarQuant.Location = new Point(12, 50);
            txtDigitarQuant.Font = new Font(txtDigitarQuant.Font.FontFamily, 16);
            txtDigitarQuant.TextAlign = HorizontalAlignment.Right;
            txtDigitarQuant.Text = "0";
            fQuant.Controls.Add(txtDigitarQuant);

            fQuant.ShowDialog();

            if (Convert.ToInt32(txtDigitarQuant.Text) > Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value))
            {
                MessageBox.Show("A quantidade informada não há em estoque");
                txtDigitarQuant.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            }
            //numQuant.Value = Convert.ToInt32(txtDigitarQuant.Text);
            txtNumQuant.Text = txtDigitarQuant.Text;
            QuantProduto = Convert.ToInt32(txtDigitarQuant.Text);
            // dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) - numQuant.Value);
            dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) - Convert.ToInt32(txtNumQuant.Text));
            QuantProduto = 0;
        }

        private void LiberarCartão(Object o, EventArgs e)
        {
            if (QuantItensPedido > 0 && tabControl1.SelectedTab == tabControl1.TabPages["tabPagePagamentos"])
            {
                txtCartaoDebito.Enabled = true;
                txtCheque.Enabled = true;
            }
        }

        private void LiberarCarnet(Object o, EventArgs e)
        {
            
            if (QuantItensPedido > 0 && tabControl1.SelectedTab == tabControl1.TabPages["tabPagePagamento"])
            {
                txtValorMinimoParcela.Visible = true;
                txtNumMaximoParcelas.Visible = true;
                txtJurosCarnet.Visible = true;
                txtNumMaximoParcelas.Focus();
                BuscarParametros();
            }
        }
        
        private void AtivarTeclaFuncao(Object o, KeyEventArgs e)
        {
            //evento KEYDOWN do formulário
            if (e.KeyCode == Keys.F4 && QuantItensPedido > 0 && tabControl1.SelectedTab == tabControl1.TabPages["tabPagePagamento"])
            {
                txtValorMinimoParcela.Visible = true;
                txtNumMaximoParcelas.Visible = true;
                txtJurosCarnet.Visible = true;
                txtNumMaximoParcelas.Focus();
                BuscarParametros();
            }
            if (e.KeyCode == Keys.F3 && QuantItensPedido > 0 && tabControl1.SelectedTab == tabControl1.TabPages["tabPagePagamentos"]) 
            {
                txtCartaoDebito.Enabled = true;
                txtCheque.Enabled = true;
            }
            if (e.KeyCode == Keys.F2 && QuantProduto > 0 && tabControl1.SelectedTab == tabControl1.TabPages["tabPagePedido"])
            {
                CriarFormularioDigitarQuantidade();
            }
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

        private string GetPropertyValue(string pName, Control control)
        {
            Type type = control.GetType();
            string propertyName = pName;
            BindingFlags flags = BindingFlags.GetProperty;
            Binder binder = null;
            object[] args = null;
            object value = type.InvokeMember(propertyName,flags,binder,control,args);
            if (value == null)
            {
                value = "";
            }
            return value.ToString();
        }
                
        private void IrParaPagamento(Object o, EventArgs e)
        {
            //aplicar o(s) desconto(s) 
            txtValorParaPagamento.Text = string.Format("{0:c}", ValorFinalPagamento);


        }
        
        private void Finalizar(Object o, EventArgs e)
        {
            //try
            //{
            //    txtValorPagar.Text = ValorFinalPagamento.ToString();


            //    //Double SaldoPagamento = 0;

            //    //if (BLL.FuncoesGerais.IsNumeric(txtDinheiro.Text))
            //    //{
            //    //    txtCreditoReal.Text = "";
            //    //    if (Convert.ToDouble(txtDinheiro.Text) >= ValorFinalPagamento)
            //    //    {
                        
            //    //        txtTroco.Text = "Troco "+string.Format("{0:c}", (Convert.ToDouble(txtDinheiro.Text) - ValorFinalPagamento));
            //    //        txtTroco.Text = "0";
            //    //        btnConcluirVendaPagamento.Visible = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        SaldoPagamento = ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text);

            //    //        txtTroco.Text = "Faltam " + string.Format("{0:c}", (SaldoPagamento));

            //    //        txtCheque.Enabled = true;
            //    //        txtCartaoDebito.Enabled = true;

            //    //        btnConcluirVendaPagamento.Visible = false;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    txtTroco.Text = "0";
            //    //    txtCheque.Enabled = false;
            //    //    txtCartaoDebito.Enabled = false;
            //    //    btnConcluirVendaPagamento.Visible = false;
            //    //}

              

            //    //if (BLL.FuncoesGerais.IsNumeric(txtCartaoDebito.Text))
            //    //{
            //    //    if (Convert.ToDouble(txtCartaoDebito.Text) > SaldoPagamento)
            //    //    {
            //    //        txtCartaoDebito.Text = string.Format("{0:c}",SaldoPagamento);
            //    //    }

            //    //    if (Convert.ToDouble(txtCartaoDebito.Text) == SaldoPagamento)
            //    //    {
            //    //        txtTroco.Text = "0";
            //    //        btnConcluirVendaPagamento.Visible = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        SaldoPagamento = ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text)-Convert.ToDouble(txtCartaoDebito.Text);

            //    //        txtTroco.Text = "Faltam " + string.Format("{0:c}", (SaldoPagamento));

            //    //       // txtCheque.Enabled = true;
            //    //       // txtCartaoDebito.Enabled = true;
            //    //
            //    //        btnConcluirVendaPagamento.Visible = false;
            //    //    }
            //   // }




            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //throw;
            //}
        }

        private void CalcularTroco(Object o, EventArgs e)
        {
            //txtValorParaPagamento.Text = ValorFinalPagamento.ToString();
            txtValorParaPagamento.Text = string.Format("{0:c}",ValorFinalPagamento);
            txtCheque.Enabled = false;
            txtCartaoDebito.Enabled = false;
            btnConcluirVendaPagamento.Visible = false;
            if (!BLL.FuncoesGerais.IsNumeric(txtDinheiro.Text))
            {
                MessageBox.Show("Digite o valor em dinheiro recebido");
                return;
            }
            cboPagamentoCarnet.Visible = false;
            PreencherComZeroTextBox();
            if (Convert.ToDouble(txtDinheiro.Text) > ValorFinalPagamento)
            {
                txtMensagem.Text = "Troco " + string.Format("{0:c}", Convert.ToDouble(txtDinheiro.Text) - ValorFinalPagamento);
            }
            else if(Convert.ToDouble(txtDinheiro.Text) == ValorFinalPagamento)
            {
                txtMensagem.Text = "Sem troco";
                btnConcluirVendaPagamento.Visible = true;
            }
            else
            {
                txtMensagem.Text = "Faltam " + string.Format("{0:c}",ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text));
                txtCheque.Enabled = true;
                txtCartaoDebito.Enabled = true;
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
                txtMensagem.Text = "Sem troco";
                btnConcluirVendaPagamento.Visible = true;
            }
            else
            {
                txtMensagem.Text = "Faltam " + string.Format("{0:c}", SaldoAPagar - Convert.ToDouble(txtCartaoDebito.Text));
                txtCheque.Enabled = true;
            }
        }

        private void CalcularPagamentoUsandoCheque(Object o, EventArgs e)
        {
            btnConcluirVendaPagamento.Visible = false;
            if (!BLL.FuncoesGerais.IsNumeric(txtCheque.Text))
            {
                MessageBox.Show("Digite o valor recebido");
                return;
            }
            cboPagamentoCarnet.Visible = false;
            PreencherComZeroTextBox();
            Double SaldoAPagar = 0;
            SaldoAPagar = ValorFinalPagamento - Convert.ToDouble(txtDinheiro.Text)-Convert.ToDouble(txtCartaoDebito.Text);
            if (Convert.ToDouble(txtCheque.Text) > SaldoAPagar)
            {
                txtMensagem.Text = "Atenção ao valor do cheque";
                txtCheque.Text = SaldoAPagar.ToString();
            }
            else if (Convert.ToDouble(txtCheque.Text) == SaldoAPagar)
            {
                txtMensagem.Text = "Sem troco";
                btnConcluirVendaPagamento.Visible = true;
            }
            else
            {
                txtMensagem.Text = "Faltam " + string.Format("{0:c}", SaldoAPagar - Convert.ToDouble(txtCheque.Text));
                txtCheque.Enabled = true;
            }
        }

        private void PreencherComZeroTextBox()
        {
            if (txtDinheiro.Text=="")
            {
                txtDinheiro.Text = "0";
            }
            if (txtCartaoDebito.Text=="")
            {
                txtCartaoDebito.Text = "0";
            }
            if (txtCheque.Text == "")
            {
                txtCheque.Text = "0";
            }
            if (txtJurosCarnet.Text=="")
            {
                txtJurosCarnet.Text = "0";
            }
            if (txtNumMaximoParcelas.Text=="")
            {
                txtNumMaximoParcelas.Text = "0";
            }
            if (txtValorMinimoParcela.Text=="0")
            {
                txtValorMinimoParcela.Text = "0";
            }

        }

        private void LiberarBotaoConcluirVendaPagamento(Object o, EventArgs e)
        {
            btnConcluirVendaPagamento.Visible = true;
        }
      
        public decimal valorAnteriorQuantidade;

        private void MudarValorQuantidade(Object o, EventArgs e)
        {
            //if (numQuant.Value > valorAnteriorQuantidade)
            //{
            //    dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) - 1);
            //}
            //else
            //{
            //    dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value) + 1);
            //}
            //valorAnteriorQuantidade = numQuant.Value;
        }

        //LINKS UTILIZADOS
        //https://stackoverflow.com/questions/10267034/keydown-event-is-not-firing-keypreview-set-to-true
        //https://docs.microsoft.com/pt-br/dotnet/framework/winforms/how-to-handle-keyboard-input-at-the-form-level
        //https://pt.stackoverflow.com/questions/149885/textbox-aceitar-n%C3%BAmeros-e-v%C3%ADrgulas
        
            //EXEMPLOS UTILIZADOS
        private void ManipularTecla(Object o, KeyPressEventArgs e)
        {
            //evento KEYPRESS do formulário - propriedade KEYPREVIEW = true
            //https://docs.microsoft.com/pt-br/dotnet/framework/winforms/how-to-handle-keyboard-input-at-the-form-level
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }

        private void AbrirConsultaProd(Object o, EventArgs e)
        {
            CriadoParaVoce.Produto.FrmProdutoConsulta frmConsProd = new CriadoParaVoce.Produto.FrmProdutoConsulta();
            frmConsProd.label1.Text = "Consulta Produto";
            frmConsProd.ShowDialog();
        }


    }
}
