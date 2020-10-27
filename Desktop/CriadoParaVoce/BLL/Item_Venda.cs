using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Item_Venda
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;


        private int _CodigoItemVenda;
        private int _CodigoVenda;
        private int _CodigoProduto;
        private int _Quantidade;
        private double _PrecoTotal;
        private int _CodigoArte;

        public int CodigoItemVenda
        {
            get
            {
                return _CodigoItemVenda;
            }

            set
            {
                _CodigoItemVenda = value;
            }
        }

        public double PrecoTotal
        {
            get
            {
                return _PrecoTotal;
            }

            set
            {
                _PrecoTotal = value;
            }
        }

        public int CodigoVenda
        {
            get
            {
                return _CodigoVenda;
            }

            set
            {
                _CodigoVenda = value;
            }
        }

        public int CodigoProduto
        {
            get
            {
                return _CodigoProduto;
            }

            set
            {
                _CodigoProduto = value;
            }
        }

        public int CodigoArte { get => _CodigoArte; set => _CodigoArte = value; }
        public int Quantidade { get => _Quantidade; set => _Quantidade = value; }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoVenda",SqlDbType.Int) {Value = CodigoVenda },
                   new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }
                   ,
                    new SqlParameter("@CodigoArte",SqlDbType.Int) {Value = _CodigoArte }
                   ,
                    new SqlParameter("@Quantidade",SqlDbType.Int) {Value = _Quantidade }
                   ,
                   new SqlParameter("@CodigoProduto",SqlDbType.Int) {Value = _CodigoProduto }

                };

                instrucaoSql = "INSERT INTO tbItem_Venda (CodigoVenda, PrecoTotal, CodigoArte, Quantidade, CodigoProduto) VALUES (@CodigoVenda,  @PrecoTotal, @CodigoArte, @Quantidade, @CodigoProduto)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AlterarComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                     new SqlParameter("@CodigoItemVenda",SqlDbType.Int) {Value = _CodigoItemVenda },

                   new SqlParameter("@CodigoVenda",SqlDbType.Int) {Value = CodigoVenda },
                   new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }
                   ,
                   new SqlParameter("@CodigoArte",SqlDbType.Int) {Value = _CodigoArte }
                   ,
                   new SqlParameter("@Quantidade",SqlDbType.Int) {Value = _Quantidade }
                   ,
                   new SqlParameter("@CodigoProduto",SqlDbType.DateTime) {Value = _CodigoProduto }

                };

                instrucaoSql = "UPDATE tbItem_Venda SET CodigoVenda=@CodigoVenda, PrecoTotal=@PrecoTotal, CodigoArte=@CodigoArte, Quantidade=@Quantidade, CodigoProduto=@CodigoProduto WHERE CodigoItemVenda=@CodigoItemVenda";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Ativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbItem_Venda SET PrecoTotal=1   WHERE CodigoItemVenda=" + _CodigoItemVenda;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Desativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbItem_Venda SET PrecoTotal=0   WHERE CodigoItemVenda=" + _CodigoItemVenda;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir()
        {
            try
            {
                instrucaoSql = "DELETE FROM tbItem_Venda  WHERE CodigoItemVenda=" + _CodigoItemVenda;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader Consultar()
        {
            try
            {
                instrucaoSql = "SELECT tbItem_Venda.CodigoItemVenda, tbItem_Venda.CodigoProduto, tb.Venda.PrecoTotal, tbPedido.CodigoFuncionario FROM tbItem_Venda INNER JOIN tbPedido ON tbItem_Venda.CodigoVenda = tbPedido.CodigoVenda WHERE CodigoItemVenda=" + _CodigoItemVenda;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNome, byte tipostatus)
        {
            try
            {
                instrucaoSql = "SELECT CodigoItemVenda, CodigoVenda, PrecoTotal FROM tbItem_Venda";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE CodigoVenda LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }
                return c.RetornarDataSet(instrucaoSql);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarAtivos()
        {
            try
            {
                instrucaoSql = "SELECT CodigoItemVenda, CodigoVenda, PrecoTotal FROM tbItem_Venda WHERE PrecoTotal=1";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarInativos()
        {
            try
            {
                instrucaoSql = "SELECT CodigoItemVenda, CodigoVenda, PrecoTotal FROM tbItem_Venda WHERE PrecoTotal=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet ListarVendas()
        {
            try
            {

                instrucaoSql = "SELECT tbItem_Venda.CodigoVenda, tbCliente.NomeCliente FROM tbItem_Venda INNER JOIN tbCliente ON tbItem_Venda.CodigoVenda = tbCliente.CodigoVenda WHERE tbItem_Venda.PrecoTotal=1 AND tbItem_Venda.CodigoItemVenda=" + _CodigoItemVenda;

                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RetornarQuantidadeVendas()
        {
            try
            {
                instrucaoSql = "SELECT Count(CodigoItemVenda), PrecoTotal, CodigoVenda FROM tbItem_Venda WHERE PrecoTotal=1 AND CodigoVenda=" + _CodigoVenda;
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int RetornarTodasQuantidadeVendas()
        {
            try
            {
                instrucaoSql = "SELECT Count(CodigoItemVenda), PrecoTotal, CodigoVenda FROM tbItem_Venda WHERE PrecoTotal=1";
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
