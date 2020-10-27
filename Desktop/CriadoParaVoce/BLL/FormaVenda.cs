using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class FormaVenda
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoFormaVenda;
        private int _CodigoPagamento;
        private int _CodigoVenda;

        public int CodigoFormaVenda
        {
            get
            {
                return _CodigoFormaVenda;
            }

            set
            {
                _CodigoFormaVenda = value;
            }
        }

        public int CodigoPagamento
        {
            get
            {
                return _CodigoPagamento;
            }

            set
            {
                _CodigoPagamento = value;
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

        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoPagamento",SqlDbType.Int) {Value = _CodigoPagamento },
                   new SqlParameter("@CodigoVenda",SqlDbType.Int) {Value = _CodigoVenda }
                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbFormaDeVenda (CodigoPagamento, CodigoVenda) VALUES (@CodigoPagamento, @CodigoVenda)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoFormaVenda",SqlDbType.Int) {Value = _CodigoFormaVenda },
                   new SqlParameter("@CodigoPagamento",SqlDbType.Int) {Value = _CodigoPagamento },
                   new SqlParameter("@CodigoVenda",SqlDbType.Int) {Value = _CodigoVenda }
                };

                instrucaoSql = "UPDATE tbFormaDeVenda SET CodigoPagamento=@CodigoPagamento, CodigoVenda=@CodigoVenda, StatusCargo=@StatusCargo WHERE CodigoFormaVenda=@CodigoFormaVenda";
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
                instrucaoSql = "UPDATE tbFormaDeVenda SET StatusCargo=1   WHERE CodigoFormaVenda=" + _CodigoFormaVenda;
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
                instrucaoSql = "UPDATE tbFormaDeVenda SET StatusCargo=0   WHERE CodigoFormaVenda=" + _CodigoFormaVenda;
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
                instrucaoSql = "DELETE FROM tbFormaDeVenda  WHERE CodigoFormaVenda=" + _CodigoFormaVenda;
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
                instrucaoSql = "SELECT * FROM tbFormaDeVenda  WHERE CodigoFormaVenda=" + _CodigoFormaVenda;
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
                instrucaoSql = "SELECT CodigoFormaVenda, CodigoPagamento, StatusCargo FROM tbFormaDeVenda";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE CodigoPagamento LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoFormaVenda, CodigoPagamento, StatusCargo FROM tbFormaDeVenda WHERE StatusCargo=1";
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
                instrucaoSql = "SELECT CodigoFormaVenda, CodigoPagamento, StatusCargo FROM tbFormaDeVenda WHERE StatusCargo=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
