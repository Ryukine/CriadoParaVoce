using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Pedido
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*
         * CodigoPedido		INT				IDENTITY	Not null,
    Descricao	INT,
    Quantidade		INT,
    PrecoTotal		INT,
    CodigoProdutoFinal			INT,
    DataPedido			DATETIME,
    StatusPedido		INT,
         */

        private int _CodigoPedido;
        private string _Descricao;
        private int _Quantidade;
        private double _PrecoTotal;
        private int _CodigoProdutoFinal;

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

        public string Descricao
        {
            get
            {
                return _Descricao;
            }

            set
            {
                _Descricao = value.Trim();
            }
        }

        public int Quantidade
        {
            get
            {
                return _Quantidade;
            }

            set
            {
                _Quantidade = value;
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

        public int CodigoProdutoFinal
        {
            get
            {
                return _CodigoProdutoFinal;
            }

            set
            {
                _CodigoProdutoFinal = value;
            }
        }

        public void Incluir()
        {
            try
            {
                instrucaoSql = "INSERT INTO tbPedido (Descricao,Quantidade, DataPedido, CodigoProdutoFinal, PrecoTotal, StatusPedido) Values('" + _Descricao + "', " + _Quantidade + ", " + _CodigoProdutoFinal + ", '" + _PrecoTotal + "')";
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@Descricao",SqlDbType.VarChar) {Value = _Descricao },
                    new SqlParameter("@Quantidade",SqlDbType.Int) {Value = _Quantidade },
                    new SqlParameter("@CodigoProdutoFinal",SqlDbType.Int) {Value = _CodigoProdutoFinal },
                    new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal },
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um CodigoProdutoFinal '{Value = _....}'
                instrucaoSql = "INSERT INTO tbPedido (Descricao, Quantidade, CodigoProdutoFinal, PrecoTotal) Values (@Descricao, @Quantidade, @CodigoProdutoFinal, @PrecoTotal)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametro);


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


                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@Descricao",SqlDbType.VarChar) {Value = _Descricao },
                    new SqlParameter("@Quantidade",SqlDbType.Int) {Value = _Quantidade },
                    new SqlParameter("@CodigoProdutoFinal",SqlDbType.Int) {Value = _CodigoProdutoFinal },
                    new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal }
                };

                instrucaoSql = "INSERT INTO tbPedido (Descricao, Quantidade, CodigoProdutoFinal, PrecoTotal) Values (@Descricao, @Quantidade, @CodigoProdutoFinal, @PrecoTotal)";
                return c.ExecutarComandoParametroRetornarCodigo(instrucaoSql, listaComParametro);
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoPedido",SqlDbType.Int) {Value = _CodigoPedido },
                    new SqlParameter("@Descricao",SqlDbType.Int) {Value = _Descricao },
                    new SqlParameter("@Quantidade",SqlDbType.Int) {Value = _Quantidade },
                    new SqlParameter("@CodigoProdutoFinal",SqlDbType.Int) {Value = _CodigoProdutoFinal },
                    new SqlParameter("@PrecoTotal",SqlDbType.Decimal) {Value = _PrecoTotal },
                };
                instrucaoSql = "UPDATE tbPedido SET Descricao =@Descricao, Quantidade=@Quantidade, CodigoProdutoFinal=@CodigoProdutoFinal, PrecoTotal=@PrecoTotal, StatusPedido=@StatusPedido WHERE CodigoPedido=@CodigoPedido";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*public int IncluirRetornarNumeroAutomatico()
        {
            try
            {
                instrucaoSql = "INSERT INTO tbPedido(Descricao, Quantidade) Values ('" + _Descricao +
                    "', " + _Quantidade + ")";
                return c.RecuperarUltimoCodigoNumeracaoAutomatica(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */
        public void Alterar()
        {
            try
            {
                instrucaoSql = "UPDATE tbPedido Set Descricao= '" + _Descricao + "', Quantidade = " + _Quantidade + " WHERE CodigoProdutoFinal = _CodigoProdutoFinal";
                c.ExecutarComando(instrucaoSql);
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
                instrucaoSql = "UPDATE tbPedido SET Quantidade = 1 WHERE CodigoProdutoFinal = " + _CodigoProdutoFinal + "";
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
                instrucaoSql = "UPDATE tbPedido SET Quantidade = 0 WHERE CodigoProdutoFinal = " + _CodigoProdutoFinal + "";
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
                instrucaoSql = "DELETE FROM tbPedido WHERE CodigoPedido = " + _CodigoPedido + "";
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
                instrucaoSql = "SELECT * FROM tbPedido WHERE CodigoPedido= " + _CodigoPedido + "";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteDescricao, byte TipoQuantidade)
        {
            try
            {
                instrucaoSql = "SELECT CodigoProdutoFinal, Descricao, Quantidade FROM tbPedido";
                if (parteDescricao.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE Descricao LIKE '%" + parteDescricao + "%'";
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
                instrucaoSql = "SELECT CodigoProdutoFinal, Descricao, Quantidade FROM tbPedido WHERE Quantidade=1";
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
                instrucaoSql = "SELECT CodigoProdutoFinal, Descricao, Quantidade FROM tbPedido WHERE Quantidade=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
