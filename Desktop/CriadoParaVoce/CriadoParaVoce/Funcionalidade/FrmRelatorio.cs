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
    public partial class FrmRelatorio : Telas.Modelo.FrmModeloCadastro
    {
        public FrmRelatorio()
        {
            InitializeComponent();
        }

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
                int VendasHj;

                BLL.Venda venda = new BLL.Venda();
                //System.Data.SqlClient.SqlDataReader dr;
                venda.CodigoVenda = Codigo;
                VendasHj = venda.ConsultarVendidoHoje();
                txtDia.Text = Convert.ToString(VendasHj);
                //if (dr.Read())
                //{
                    //txtCodigo.Text = Convert.ToString(dr["CodigoVenda"]);
                    //txtDataVenda.Text = Convert.ToString(dr["DataVenda"]);
                    //txtFuncionario.Text = Convert.ToString(dr["NomeFuncionario"]);
                    //txtCliente.Text = Convert.ToString(dr["NomeCliente"]);
                    //txtValorVenda.Text = Convert.ToString(dr["PrecoTotal"]);
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

                //}

                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }
    }
}
