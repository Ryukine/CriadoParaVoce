using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce.Empresa
{
    public partial class FrmEmpresa : Telas.Modelo.FrmModelo
    {
        public FrmEmpresa()
        {
            InitializeComponent();
            panelAdm.Visible = false;
        }

        private int _CodigoUsuario;

        public int CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }

        private void Cargo(object o, EventArgs e)
        {
            panelAdm.Visible = false;
            CriadoParaVoce.Cargo.FrmCargoConsulta frmCargoConsul = new Cargo.FrmCargoConsulta();
            frmCargoConsul.label1.Text = "Cargo";
            frmCargoConsul.ShowDialog();
        }
        
        private void ConsultaVenda(Object o, EventArgs e)
        {
            panelAdm.Visible = false;
            CriadoParaVoce.Funcionalidade.FrmConsultaVenda frmConVenda = new Funcionalidade.FrmConsultaVenda();
            frmConVenda.label1.Text = "Consulta da Venda";
            frmConVenda.ShowDialog();
        }

        private void ConsultarFunc(Object o, EventArgs e)
        {
            panelAdm.Visible = false;
            CorretoraConvenios.Funcionário.FrmFuncionarioConsulta ffc = new CorretoraConvenios.Funcionário.FrmFuncionarioConsulta();
            ffc.label1.Text = "Consulta Funcionário";
            ffc.ShowDialog();
        }

        private void ConsultarCategoria(Object o, EventArgs e)
        {
            panelAdm.Visible = false;
            ControleFarmacia.Negocio.Categoria.FrmConsultaCategoria frmConCat = new ControleFarmacia.Negocio.Categoria.FrmConsultaCategoria();
            frmConCat.label1.Text = "Consulta Categoria do Produto";
            frmConCat.ShowDialog();
        }

        private void Fornecedor(Object o, EventArgs e)
        {
            panelAdm.Visible = false;
            ControleFarmacia.Negocio.Fornecedor.FrmConsultaFornecedor frmConsForn = new ControleFarmacia.Negocio.Fornecedor.FrmConsultaFornecedor();
            frmConsForn.label1.Text = "Consulta Fornecedor";
            frmConsForn.ShowDialog();
        }

        private void Admin(Object o, EventArgs e)
        {
            panelAdm.Visible = true;
        }

        private void ConsultaProd(Object o, EventArgs e)
        {
            panelAdm.Visible = false;
            Produto.FrmProdutoConsulta prodCon = new Produto.FrmProdutoConsulta();
            prodCon.label1.Text = "Consulta Produto";
            prodCon.ShowDialog();
        }

        private void FaleConosco(Object o, EventArgs e)
        {
            Funcionalidade.FrmFaleConosco fale = new Funcionalidade.FrmFaleConosco();
            fale.label1.Text = "Fale Conosco";
            fale.CodigoUsuario = CodigoUsuario;
            fale.ShowDialog();
        }
    }
}
