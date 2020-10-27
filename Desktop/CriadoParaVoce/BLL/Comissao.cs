using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Comissao
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoComissao;
        private double _Porcentagem;
        private int _CodigoVenda;
        private int _StatusComissao;
        public int CodigoComissao
        {
            get
            {
                return _CodigoComissao;
            }

            set
            {
                _CodigoComissao = value;
            }
        }

        public double Porcentagem
        {
            get
            {
                return _Porcentagem;
            }

            set
            {
                _Porcentagem = value;
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

        public int StatusComissao
        {
            get
            {
                return _StatusComissao;
            }

            set
            {
                _StatusComissao = value;
            }
        }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@Porcentagem",SqlDbType.Int) {Value = Porcentagem },
                   new SqlParameter("@StatusComissao",SqlDbType.Int) {Value = _StatusComissao }
                   ,
                   new SqlParameter("@CodigoVenda",SqlDbType.DateTime) {Value = _CodigoVenda }

                };

                instrucaoSql = "INSERT INTO tbVenda (Porcentagem, StatusComissao, , CodigoVenda) VALUES (@Porcentagem,  @StatusComissao, @CodigoVenda)";
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
                     new SqlParameter("@CodigoComissao",SqlDbType.Int) {Value = _CodigoComissao },

                   new SqlParameter("@Porcentagem",SqlDbType.Int) {Value = Porcentagem },
                   new SqlParameter("@StatusComissao",SqlDbType.Int) {Value = _StatusComissao }
                   ,
                   new SqlParameter("@CodigoVenda",SqlDbType.DateTime) {Value = _CodigoVenda }

                };

                instrucaoSql = "UPDATE tbVenda SET Porcentagem=@Porcentagem, StatusComissao=@StatusComissao, CodigoVenda=@CodigoVenda WHERE CodigoComissao=@CodigoComissao";
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
                instrucaoSql = "UPDATE tbVenda SET StatusComissao=1   WHERE CodigoComissao=" + _CodigoComissao;
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
                instrucaoSql = "UPDATE tbVenda SET StatusComissao=0   WHERE CodigoComissao=" + _CodigoComissao;
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
                instrucaoSql = "DELETE FROM tbVenda  WHERE CodigoComissao=" + _CodigoComissao;
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
                instrucaoSql = "SELECT tbVenda.CodigoVenda, tbVenda.CodigoVenda, tb.Venda.StatusComissao, tbPedido.CodigoFuncionario FROM tbVenda INNER JOIN tbPedido ON tbVenda.Porcentagem = tbPedido.Porcentagem WHERE CodigoComissao=" + _CodigoComissao;
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
                instrucaoSql = "SELECT CodigoVenda, Porcentagem, StatusComissao FROM tbVenda";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE Porcentagem LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoVenda, Porcentagem, StatusComissao FROM tbVenda WHERE StatusComissao=1";
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
                instrucaoSql = "SELECT CodigoComissao, Porcentagem, StatusComissao FROM tbVenda WHERE StatusComissao=0";
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

                instrucaoSql = "SELECT tbVenda.Porcentagem, tbCliente.NomeCliente FROM tbVenda INNER JOIN tbCliente ON tbVenda.Porcentagem = tbCliente.Porcentagem WHERE tbVenda.StatusComissao=1 AND tbVenda.CodigoComissao=" + _CodigoComissao;

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
                instrucaoSql = "SELECT Count(CodigoComissao), StatusComissao, Porcentagem FROM tbVenda WHERE StatusComissao=1 AND Porcentagem=" + _Porcentagem;
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
