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
    public partial class FrmConsultaDaVenda : Telas.Modelo.FrmModeloCadastro
    {
        public FrmConsultaDaVenda()
        {
            InitializeComponent();
        }

        private int _TipoUso;

        public int TipoUso { get => _TipoUso; set => _TipoUso = value; }

        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                /* CarregarComboDepartamento(o, e);
                 CarregarComboCargo(o, e);*/
                //txtTelAdd2.Visible = false;
                //txtTelAdd3.Visible = false;
                /*label19.Visible = false;
                label21.Visible = false;
                label22.Visible = false;*/
                btnGravar.Visible = false;

                    BLL.Venda venda = new BLL.Venda();
                    System.Data.SqlClient.SqlDataReader dr;
                    venda.CodigoVenda = Codigo;
                    CarregarDadosGrid(o, e);
                    dr = venda.Consultar();
                    if (dr.Read())
                    {
                        txtCodigo.Text = Convert.ToString(dr["CodigoVenda"]);
                        txtDataVenda.Text = Convert.ToString(dr["DataVenda"]);
                        txtFuncionario.Text = Convert.ToString(dr["NomeFuncionario"]);
                        txtCliente.Text = Convert.ToString(dr["NomeCliente"]);
                        txtValorVenda.Text = Convert.ToString(dr["PrecoTotal"]);
                        txtTroco.Text = Convert.ToString(dr["Troco"]);
                        /*txtUsuario.Text = Convert.ToString(dr["NomeSistema"]);
                        txtUsuario.Enabled = false;
                        txtSenha.Text = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["SenhaSistema"]));
                        txtNome.Text = Convert.ToString(dr["NomeUsuario"]);
                        PinUsuario = Convert.ToString(dr["PinUsuario"]);
                        chkAtivo.Checked = Convert.ToBoolean(dr["StatusUsuario"]);

                        /*if (Convert.ToString(dr["PerguntaUsuario"]) == String.Empty)
                        {
                            txtPergunta.Text = "Qual é o PIN?";
                            RespostaSecreta = Convert.ToString(dr["PinUsuario"]);
                        }
                        else*/
                        //{
                        //txtPergunta.Text = Convert.ToString(dr["PerguntaUsuario"]);
                        //RespostaSecreta = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["RespostaUsuario"]));
                        //}

                    }

                txtValorPago.Text = Convert.ToString(Convert.ToDouble(txtTroco.Text) + Convert.ToDouble(txtValorVenda.Text));

                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }

        private void CarregarDadosGrid(Object o, EventArgs e)
        {
            BLL.Venda venda = new BLL.Venda();
            venda.CodigoVenda = Codigo;
            dataGridView1.DataSource = venda.ListarItensVendidos().Tables[0];

            dataGridView1.Columns[0].HeaderText = "Cód";
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "Nome Produto";
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Columns[2].HeaderText = "Preco Produto";
            dataGridView1.AutoResizeColumn(2);
            dataGridView1.Columns[3].HeaderText = "Id Arte";
            dataGridView1.AutoResizeColumn(3);
            dataGridView1.Columns[4].HeaderText = "Nome Arte";
            dataGridView1.AutoResizeColumn(4);
            dataGridView1.Columns[5].HeaderText = "Preco Arte";
            dataGridView1.AutoResizeColumn(5);

        }
    }
}
