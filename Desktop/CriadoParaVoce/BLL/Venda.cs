using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Venda
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;


        private int _CodigoVenda;
        private int _CodigoPedido;
        private int _CodigoCliente;
        private int _CodigoFunc;
        private DateTime _DataVenda;
        private double _PrecoTotal;
        private DateTime _DataSelecionada;
        private double _Troco;

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

        public int CodigoPedido
        {
            get
            {
                return _CodigoPedido;
            }

            set
            {
                _CodigoPedido = value;
            }
        }

        public DateTime DataVenda
        {
            get
            {
                return _DataVenda;
            }

            set
            {
                _DataVenda = value;
            }
        }

        public int CodigoCliente
        {
            get
            {
                return _CodigoCliente;
            }
            set
            {
                _CodigoCliente = value;
            }
        }

        public int CodigoFunc
        {
            get
            {
                return _CodigoFunc;
            }
            set
            {
                _CodigoFunc = value;
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

        public DateTime DataSelecionada
        {
            get
            {
                return _DataSelecionada;
            }
            set
            {
                _DataSelecionada = value;
            }
            
        }

        public double Troco { get => _Troco; set => _Troco = value; }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoPedido",SqlDbType.Int) {Value = _CodigoPedido },
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc },     
                   new SqlParameter("@DataVenda",SqlDbType.DateTime) {Value = _DataVenda },
                   new SqlParameter("@Troco",SqlDbType.Decimal) {Value = _Troco },
                   new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }

                };

                instrucaoSql = "INSERT INTO tbVenda (CodigoPedido, CodigoCliente, CodigoFunc, DataVenda, Troco, PrecoTotal) VALUES (@CodigoPedido,  @CodigoCliente, @CodigoFunc, @DataVenda, @Troco, @PrecoTotal)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int IncluirRetornarNumeroAutomatico()
        {
            try
            {

                /*_Descricao = "ZE";
                _DataPedido = "M";
                _Quantidade = 1;
                _CodigoProdutoFinal = "ZE@ZE.COM.BR";
                _StatusPedido = DateTime.Now.AddYears(-20);
                _PrecoTotal = "17097010800";
                _Logradouro = "RUA CAIM";
                _Cep = "06406200";
                _UF = "SP";
                _Cidade = "BARUERI";
                _Bairro = "JARDIM SAO PEDRO";
                _Numero = "112";
                _Complemento = "CASA 1";*/


                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoPedido",SqlDbType.Int) {Value = _CodigoPedido },
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc },
                   new SqlParameter("@DataVenda",SqlDbType.DateTime) {Value = _DataVenda },
                   new SqlParameter("@Troco",SqlDbType.Decimal) {Value = _Troco },
                   new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }

                };

                instrucaoSql = "INSERT INTO tbVenda (CodigoPedido, CodigoCliente, CodigoFunc, DataVenda, Troco, PrecoTotal) Values (@CodigoPedido, @CodigoCliente, @CodigoFunc, @DataVenda, @Troco, @PrecoTotal)";
                return c.ExecutarComandoParametroRetornarCodigo(instrucaoSql, listaComParametros);
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
                     new SqlParameter("@CodigoVenda",SqlDbType.Int) {Value = _CodigoVenda },
                     new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc },
                   new SqlParameter("@CodigoPedido",SqlDbType.Int) {Value = CodigoPedido },
                   new SqlParameter("@DataVenda",SqlDbType.DateTime) {Value = _DataVenda },
                   new SqlParameter("@Troco",SqlDbType.Decimal) {Value = _Troco },
                   new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }

                };

                instrucaoSql = "UPDATE tbVenda SET CodigoPedido=@CodigoPedido, CodigoCliente=@CodigoCliente, CodigoFunc=@CodigoFunc, DataVenda=@DataVenda, Troco=@Troco, PrecoTotal=@PrecoTotal WHERE CodigoVenda=@CodigoVenda";
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
                instrucaoSql = "UPDATE tbVenda SET StatusVenda=1   WHERE CodigoVenda=" + _CodigoVenda;
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
                instrucaoSql = "UPDATE tbVenda SET StatusVenda=0   WHERE CodigoVenda=" + _CodigoVenda;
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
                instrucaoSql = "DELETE FROM tbVenda  WHERE CodigoVenda=" + _CodigoVenda;
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
                instrucaoSql = "SELECT tbVenda.CodigoVenda, tbVenda.DataVenda, tbVenda.Troco, tbItem_Venda.PrecoTotal, tbFuncionario.NomeFuncionario, tbCliente.NomeCliente FROM tbVenda  INNER JOIN tbItem_Venda ON tbVenda.CodigoVenda = tbItem_Venda.CodigoVenda INNER JOIN tbFuncionario ON tbVenda.CodigoFunc = tbFuncionario.CodigoFunc INNER JOIN tbCliente ON tbVenda.CodigoCliente = tbCliente.CodigoCliente WHERE tbVenda.CodigoVenda=" + _CodigoVenda;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ConsultarVendidoHoje()
        {
            try
            {
                instrucaoSql = "SELECT SUM(PrecoTotal) FROM tbVenda WHERE DataVenda = " + System.DateTime.Today;
                return Convert.ToInt32(c.RetornarTotal(instrucaoSql));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader ConsultarVendidoMes()
        {
            try
            {
                instrucaoSql = "SELECT SUM(PrecoTotal) FROM tbVenda WHERE DataVenda = " + System.DateTime.Now;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader ConsultarVendidoAno()
        {
            try
            {
                instrucaoSql = "SELECT SUM(PrecoTotal) FROM tbVenda WHERE DataVenda = " + System.DateTime.Now;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarItensVendidos()
        {
            try
            {
                instrucaoSql = "SELECT p.CodigoProduto ,p.NomeProduto, p.PrecoProduto, a.IdArte, a.NomeArte, a.PrecoArte,  iv.Quantidade FROM tbItem_Venda iv Join tbProduto p on iv.CodigoProduto = p.CodigoProduto JOIN tbArte a on iv.CodigoArte = a.IdArte WHERE iv.CodigoVenda =" + _CodigoVenda;
                /*if (parteNome != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE CodigoVenda LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }*/
                return c.RetornarDataSet(instrucaoSql);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar()
        {
            try
            {
                instrucaoSql = "SELECT CodigoVenda, DataVenda, CodigoCliente, CodigoFunc FROM tbVenda";
                /*if (parteNome != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE CodigoVenda LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }*/
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
                instrucaoSql = "SELECT CodigoVenda, CodigoPedido, StatusVenda FROM tbVenda WHERE StatusVenda=1";
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
                instrucaoSql = "SELECT CodigoVenda, CodigoPedido, StatusVenda FROM tbVenda WHERE StatusVenda=0";
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

                instrucaoSql = "SELECT tbVenda.CodigoPedido, tbCliente.NomeCliente FROM tbVenda INNER JOIN tbCliente ON tbVenda.CodigoPedido = tbCliente.CodigoPedido WHERE tbVenda.StatusVenda=1 AND tbVenda.CodigoVenda=" + _CodigoVenda;

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
                instrucaoSql = "SELECT Count(CodigoVenda), StatusVenda, CodigoPedido FROM tbVenda WHERE StatusVenda=1 AND CodigoPedido=" + _CodigoPedido;
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
                instrucaoSql = "SELECT Count(CodigoVenda), StatusVenda, CodigoPedido FROM tbVenda WHERE StatusVenda=1";
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
