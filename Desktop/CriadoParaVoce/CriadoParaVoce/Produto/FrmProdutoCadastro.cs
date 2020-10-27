using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Produto
{
    public partial class FrmProdutoCadastro : Telas.Modelo.FrmModeloCadastro
    {
        public FrmProdutoCadastro()
        {
            InitializeComponent();
            pbxProduto.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int CodigoCategoria;
        private void CarregarCboCategoria()
        {
            try
            {
                BLL.Categoria cate = new BLL.Categoria();//CRIAR OBJ A PARTIR DA CLASSE
                this.cboCategoria.DataSource = cate.ListarAtivos().Tables[0];
                this.cboCategoria.DisplayMember = "DescricaoCategoria";
                this.cboCategoria.ValueMember = "CategoriaId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarCboFornecedor()
        {
            try
            {
                BLL.Fornecedor forn = new BLL.Fornecedor();
                this.cboFornecedor.DataSource = forn.Listar("").Tables[0];
                this.cboFornecedor.DisplayMember = "Descricao";
                this.cboFornecedor.ValueMember = "FornecedorId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void AbrirFornecedor(Object o, EventArgs e)
        {
            Negocio.Fornecedor.FrmConsultaFornecedor forn = new Negocio.Fornecedor.FrmConsultaFornecedor();
            forn.Text = "Cadastro de Fornecedor";
            forn.lblTitulo.Text = "Fornecedor ";
            forn.ShowDialog();
            CarregarCboFornecedor();
        }*/

        /*private void AbrirCategoria(Object o, EventArgs e)
        {
            Negocio.Categoria.FrmConsultaCategoria cat = new Negocio.Categoria.FrmConsultaCategoria();
            cat.Text = "Cadastro de Categoria Gastos Materiais Aplicados ao Residente";
            cat.lblTitulo.Text = "Categoria ";
            cat.ShowDialog();
            CarregarCboCategoria();
        }*/

        //Associar este metodo ao EVENTO LOAD do formulario
        private void CarregarCampos(object sender, EventArgs e)
        {
            try
            {
                CarregarCboCategoria();
                CarregarCboFornecedor();
                txtCodigo.Enabled = false;
                numPreco.DecimalPlaces = 2;
                numPreco.ThousandsSeparator = true;
                if (TipoUso != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    BLL.Produto prod = new BLL.Produto();
                    System.Data.SqlClient.SqlDataReader dr;
                    prod.CodigoProduto = Codigo;
                    dr = prod.Consultar();
                    if (dr.Read())
                    {
                        this.txtCodigo.Text = Convert.ToString(Codigo);
                        this.txtCodigo.Enabled = false;
                        this.txtDescricao.Text = dr["NomeProduto"].ToString();
                        this.chkAtivo.Checked = false;
                        /*if (Convert.ToString(dr["StatusProduto"]) == "1")
                        {
                            this.chkAtivo.Checked = true;
                        }*/


                        /*cboCategoria.SelectedValue = (Int32)dr["CategoriaId"];
                        cboFornecedor.SelectedValue = (Int32)dr["FornecedorId"];*/
                        numPreco.Value = Convert.ToDecimal(dr["PrecoProduto"]);
                        chkAtivo.Checked = Convert.ToBoolean(dr["StatusProduto"]);
                        txtImagem.Text = Convert.ToString(dr["FotoDoProduto"]);
                        pbxProduto.ImageLocation = Convert.ToString(dr["FotoDoProduto"]);
                        
                    }

                    System.Data.SqlClient.SqlDataReader drr;
                    drr = prod.RetornarCategoria();
                    if (drr.Read())
                    {
                        this.cboCategoria.Text = Convert.ToString(drr["DescricaoCategoria"]);
                    } 

                    System.Data.SqlClient.SqlDataReader dr2;
                    dr2 = prod.RetornarFornecedor();
                    if (dr2.Read())
                    {
                        this.cboFornecedor.Text = Convert.ToString(dr2["Descricao"]);
                    }
                    this.groupBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ex.Source);
            }
        }

        /*public void CarregaImagem(String imgCaminho)
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho))
                    return;
                //fornece propriedadese métodos de instância para criar, copiar,
                //excluir, mover, e abrir arquivos, e ajuda na criação de objetos FileStream
                FileInfo arqImagem = new FileInfo(imgCaminho);
                //Expõe um Stream ao redor de um arquivo de suporte
                //síncrono e assíncrono operações de leitura e gravar.
                FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
                //aloca memória para o vetor
                this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];
                //Lê um bloco de bytes do fluxo e grava osdados em um buffer fornecido.
                int iBytesRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }*/
        private void Salvar(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDescricao.Text == String.Empty)
                {
                    this.errorProvider1.SetError(this.txtDescricao, "A descrição é obrigatória");
                    this.txtDescricao.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtDescricao, String.Empty);
                }

                BLL.Produto prod = new BLL.Produto();
                prod.NomeProduto = this.txtDescricao.Text.ToUpper();
                //prod.QuantMinimaEstoque = (Int32)this.numQuantMin.Value;
                prod.FornecedorId = (Int32)this.cboFornecedor.SelectedValue;
                prod.PrecoProduto = (double)this.numPreco.Value;
                prod.CategoriaId = (Int32)this.cboCategoria.SelectedValue;
                prod.FotoProduto = Convert.ToString(txtImagem.Text);

                //prod.Controlado = 0;
                /*if (this.chkControlado.Checked)
                {
                    prod.Controlado = 1;
                }*/
                prod.StatusProduto = 0;
                if (this.chkAtivo.Checked)
                {
                    prod.StatusProduto = 1;
                }
                switch (TipoUso)
                {
                    case 0: //inclusao
                        prod.IncluirComParametro();
                        break;
                    case 1: //alteracao
                        prod.CodigoProduto = Codigo;
                        prod.AlterarComParametro();
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
                    txtImagem.Text = diretorio.FileName;

                    Bitmap bmp = new Bitmap(diretorio.FileName);

                    Bitmap bmp2 = new Bitmap(bmp, pbxProduto.Size);

                    pbxProduto.Image = bmp2;

                }

            }

            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Inserir imagem : " + erro);

            }
        }
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        private void AbrirCadastroForn(Object o, EventArgs e)
        {
            CriadoParaVoce.Fornecedor.FrmCadastroFornecedor frmCad = new Fornecedor.FrmCadastroFornecedor();
            frmCad.label1.Text = "Cadastro de Fornecedor";
            frmCad.ShowDialog();
            CarregarCboFornecedor();
        }

        private void AbrirCadastroCat(Object o, EventArgs e)
        {
            CriadoParaVoce.Categoria.FrmCadastroCategoria frmCadCat = new Categoria.FrmCadastroCategoria();
            frmCadCat.label1.Text = "Cadastro de Categoria";
            frmCadCat.ShowDialog();
            CarregarCboCategoria();
        }
    }
}
