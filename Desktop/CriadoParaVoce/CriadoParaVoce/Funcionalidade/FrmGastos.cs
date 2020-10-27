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
    public partial class FrmGastos : Telas.Modelo.FrmModeloCadastro
    {
        public FrmGastos()
        {
            InitializeComponent();
            numPreco.DecimalPlaces = 2;
            numPreco.ThousandsSeparator = true;
        }

        int CodigoFunc;

        private void CarregarCampos(object sender, EventArgs e)
        {
            try
            {
                CarregarComboFuncionario(sender, e);
                if (TipoUso != Convert.ToByte(BLL.FuncoesGerais.TipoUso.Inclusao))
                {
                    BLL.Gastos gastos = new BLL.Gastos();
                    System.Data.SqlClient.SqlDataReader drr;
                    gastos.CodigoGastos = Codigo;
                    drr = gastos.Consultar();
                    if (drr.Read())
                    {
                        this.txtGasto.Text = Convert.ToString(drr["DescricaoGastos"]);
                        this.numPreco.Text = Convert.ToString(drr["ValorGasto"]);
                        if (Convert.ToInt32(drr["StatusGasto"]) == 1)
                        {
                            this.chkPago.Checked = true;
                        }
                        else
                        {
                            this.chkPago.Checked = false;
                        }
                        CodigoFunc = Convert.ToInt32(drr["CodigoFunc"]);
                    }

                    BLL.Funcionario func = new BLL.Funcionario();
                    System.Data.SqlClient.SqlDataReader dr;
                    func.CodigoFunc = CodigoFunc;
                    dr = func.Consultar();
                    if (dr.Read())
                    {
                        cboFuncionario.Text = Convert.ToString(dr["NomeFuncionario"]);
                    }

                    this.groupBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }

        private void CarregarComboFuncionario(Object o, EventArgs e)
        {
            try
            {
                BLL.Funcionario func = new BLL.Funcionario();
                cboFuncionario.DataSource = func.ListarAtivos().Tables[0];
                cboFuncionario.DisplayMember = "NomeFuncionario"; //texto
                cboFuncionario.ValueMember = "CodigoFunc"; //pk
                cboFuncionario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //associar ao CLICK do botao SALVAR
        private void Salvar(object sender, EventArgs e)
        {
            try
            {
                if (this.txtGasto.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.txtGasto, "O Nome é obrigatório");
                    this.txtGasto.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtGasto, String.Empty);
                }

                if (this.numPreco.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.numPreco, "A descrição é obrigatória");
                    this.numPreco.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.numPreco, String.Empty);
                }

                BLL.Gastos gastos = new BLL.Gastos();
                gastos.DescricaoGastos = this.txtGasto.Text.ToUpper();
                gastos.ValorGasto = Convert.ToDouble(this.numPreco.Text);
                gastos.CodigoFunc = Convert.ToInt32(cboFuncionario.SelectedValue);
                gastos.StatusGasto = 0; 
                if (this.chkPago.Checked)
                {
                    gastos.StatusGasto = 1;
                }

                switch (TipoUso)
                {
                    case 0: //inclusao
                        gastos.IncluirComParametro();
                        break;
                    case 1: //alteracao
                        gastos.CodigoGastos = Codigo;
                        gastos.AlterarComParametro();
                        break;
                }
                MessageBox.Show("Operação " + this.label1.Text + " realizada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
