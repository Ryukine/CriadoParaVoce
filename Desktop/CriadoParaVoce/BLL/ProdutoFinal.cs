using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ProdutoFinal
    {
        private static string SQL;
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CodigoProdutoFinal;

        public int CodigoProdutoFinal
        {
            get { return _CodigoProdutoFinal; }
            set { _CodigoProdutoFinal = value; }
        }
        private int _CategoriaId;

        public int CategoriaId
        {
            get { return _CategoriaId; }
            set { _CategoriaId = value; }
        }
        private int _CodigoProduto;

        public int CodigoProduto
        {
            get { return _CodigoProduto; }
            set { _CodigoProduto = value; }
        }
        private string _NomeProdutoFinal;

        public string NomeProdutoFinal
        {
            get { return _NomeProdutoFinal; }
            set { _NomeProdutoFinal = value; }
        }

        private string _DescricaoProd;

        private int _IdArte;

        public int IdArte
        {
            get { return _IdArte; }
            set { _IdArte = value; }
        }
        private int _StatusProdutoFinal;

        public int StatusProdutoFinal
        {
            get { return _StatusProdutoFinal; }
            set { _StatusProdutoFinal = value; }
        }

        public double PrecoProdutoFinal
        {
            get { return _PrecoProdutoFinal; }
            set { _PrecoProdutoFinal = value; }
        }

        public string DescricaoProd
        {
            get
            {
                return _DescricaoProd;
            }
            set
            {
                _DescricaoProd = value;
            }
        }

        private double _PrecoProdutoFinal;


        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeProdutoFinal",SqlDbType.VarChar) {Value = _NomeProdutoFinal },
                   new SqlParameter("@StatusProdutoFinal",SqlDbType.Int) {Value = _StatusProdutoFinal }
                   ,//
                   new SqlParameter("@DescricaoProd",SqlDbType.VarChar) {Value = _DescricaoProd }
                   ,//
                   new SqlParameter("@CategoriaId",SqlDbType.Int) {Value = _CategoriaId },//
                   new SqlParameter("@CodigoProduto",SqlDbType.Int) {Value = _CodigoProduto },//
                   new SqlParameter("@IdArte",SqlDbType.Int) {Value =  _IdArte },//
                   new SqlParameter("@PrecoProdutoFinal",SqlDbType.Decimal) {Value = _PrecoProdutoFinal }//

                };

                SQL = "INSERT INTO tbProdutoFinal (NomeProdutoFinal,  StatusProdutoFinal, DescricaoProd, CategoriaId, CodigoProduto, IdArte, PrecoProdutoFinal) VALUES (@NomeProdutoFinal,  @StatusProdutoFinal, @DescricaoProd, @CategoriaId, @CodigoProduto, @IdArte, @PrecoProdutoFinal)";
                c.ExecutarComandoParametro(SQL, listaComParametros);
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
                     new SqlParameter("@CodigoProdutoFinal",SqlDbType.Int) {Value = _CodigoProdutoFinal },
                   new SqlParameter("@CategoriaId",SqlDbType.Int) {Value = _CategoriaId },
                   new SqlParameter("@StatusProdutoFinal",SqlDbType.Int) {Value = _StatusProdutoFinal }
                   ,
                   new SqlParameter("@NomeProdutoFinal",SqlDbType.VarChar) {Value = _NomeProdutoFinal },
                   new SqlParameter("@CodigoProduto",SqlDbType.Int) {Value = _CodigoProduto },
                   new SqlParameter("@DescricaoProd",SqlDbType.VarChar) {Value = _DescricaoProd }
                   ,//
                   //new SqlParameter("@QuantMinimaEstoque",SqlDbType.Int) {Value =  _QuantMinimaEstoque },
                   new SqlParameter("@IdArte",SqlDbType.Int) {Value = _IdArte },
                   new SqlParameter("@PrecoProdutoFinal",SqlDbType.Decimal) {Value = _PrecoProdutoFinal }

                };

                SQL = "UPDATE tbProdutoFinal SET CategoriaId=@CategoriaId, StatusProdutoFinal=@StatusProdutoFinal, NomeProdutoFinal=@NomeProdutoFinal,  CodigoProduto=@CodigoProduto, DescricaoProd=@DescricaoProd, IdArte=@IdArte, PrecoProdutoFinal=@PrecoProdutoFinal WHERE CodigoProdutoFinal=@CodigoProdutoFinal";
                c.ExecutarComandoParametro(SQL, listaComParametros);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Incluir()
        {
            try
            {
                SQL = "INSERT INTO tbProdutoFinal (CATEGORIAID, CodigoProduto, NomeProdutoFinal, IdArte,StatusProdutoFinal, PrecoProdutoFinal, FotoDoProduto) VALUES (" + _CategoriaId + ", " + _CodigoProduto + ", '" + _NomeProdutoFinal + "', " + _IdArte + ", " + _StatusProdutoFinal + ", " + _PrecoProdutoFinal + ")";
                c.ExecutarComando(SQL);
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
                   new SqlParameter("@CategoriaId",SqlDbType.Int) {Value = _CategoriaId },
                   new SqlParameter("@StatusProdutoFinal",SqlDbType.Int) {Value = _StatusProdutoFinal }
                   ,
                   new SqlParameter("@NomeProdutoFinal",SqlDbType.VarChar) {Value = _NomeProdutoFinal },
                   new SqlParameter("@CodigoProduto",SqlDbType.Int) {Value = _CodigoProduto },
                   new SqlParameter("@DescricaoProd",SqlDbType.VarChar) {Value = _DescricaoProd }
                   ,//
                   //new SqlParameter("@QuantMinimaEstoque",SqlDbType.Int) {Value =  _QuantMinimaEstoque },
                   new SqlParameter("@IdArte",SqlDbType.Int) {Value = _IdArte },
                   new SqlParameter("@PrecoProdutoFinal",SqlDbType.Decimal) {Value = _PrecoProdutoFinal }
                };

                SQL = "INSERT INTO tbProdutoFinal ( CategoriaId, StatusProdutoFinal, NomeProdutoFinal, CodigoProduto, DescricaoProd, IdArte, PrecoProdutoFinal) Values (@CategoriaId, @StatusProdutoFinal, @NomeProdutoFinal,@CodigoProduto, @DescricaoProd, @IdArte, @PrecoProdutoFinal)";
                return c.ExecutarComandoParametroRetornarCodigo(SQL, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*public int IncluirRetornoCodigo()
        {
            try
            {
                SQL = "INSERT INTO tbProdutoFinal (CATEGORIAID, CodigoProduto, NomeProdutoFinal, QuantMinimaEstoque, IdArte, StatusProdutoFinal) VALUES (" + _CategoriaId + ", " + _CodigoProduto + ", '" + _NomeProdutoFinal + "', " + _QuantMinimaEstoque + ", " + _IdArte + ", " + _StatusProdutoFinal + ")";
                return c.executarComandoRetorno(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public void Alterar()
        {
            try
            {
                SQL = "UPDATE tbProdutoFinal SET NomeProdutoFinal = '" + _NomeProdutoFinal + "', StatusProdutoFinal = " + _StatusProdutoFinal + ", CATEGORIAID = " + _CategoriaId + ", CodigoProduto = " + _CodigoProduto + ", IdArte = " + _IdArte + " WHERE CodigoProdutoFinal = " + _CodigoProdutoFinal + " ";
                c.ExecutarComando(SQL);
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
                SQL = "UPDATE tbProdutoFinal SET StatusProdutoFinal = 0  WHERE CodigoProdutoFinal=" + _CodigoProdutoFinal;
                c.ExecutarComando(SQL);
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
                SQL = "UPDATE tbProdutoFinal SET StatusProdutoFinal =1   WHERE CodigoProdutoFinal=" + _CodigoProdutoFinal;
                c.ExecutarComando(SQL);
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
                SQL = "DELETE FROM tbProdutoFinal WHERE CodigoProdutoFinal = " + _CodigoProdutoFinal + " ";
                c.ExecutarComando(SQL);

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
                SQL = "SELECT * FROM tbProdutoFinal WHERE CodigoProdutoFinal = " + _CodigoProdutoFinal + " ";
                return c.RetornarDataReader(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Listar(string parteNome)
        {
            try
            {
                SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, PrecoProdutoFinal, CategoriaId FROM tbProdutoFinal";

                if (parteNome.Length != 0)
                {
                    if (BLL.FuncoesGerais.IsNumeric(parteNome))
                    {
                        _CategoriaId = Convert.ToInt32(parteNome);
                        SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, PrecoProdutoFinal, CategoriaId FROM tbProdutoFinal WHERE CategoriaId =" + _CategoriaId;
                    }
                    else
                    {
                        SQL = SQL + " WHERE NomeProdutoFinal LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                    }
                }

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarCbo(int parteNome)
        {
            try
            {
                SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, PrecoProdutoFinal, CategoriaId FROM tbProdutoFinal";

                if (parteNome != 0)
                {
                    if (BLL.FuncoesGerais.IsNumeric(parteNome))
                    {
                        _CategoriaId = Convert.ToInt32(parteNome);
                        SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, PrecoProdutoFinal, CategoriaId FROM tbProdutoFinal WHERE CategoriaId =" + _CategoriaId;
                    }
                    else
                    {
                        _CategoriaId = Convert.ToInt32(parteNome);
                        SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, PrecoProdutoFinal, CategoriaId FROM tbProdutoFinal WHERE CategoriaId =" + _CategoriaId;
                    }
                }

                return c.RetornarDataSet(SQL);

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
                SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, StatusProdutoFinal FROM tbProdutoFinal WHERE StatusProdutoFinal= 1 ORDER BY NomeProdutoFinal";
                return c.RetornarDataSet(SQL);
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
                SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, StatusProdutoFinal FROM tbProdutoFinal WHERE StatusProdutoFinal= 0 ORDER BY NomeProdutoFinal";
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ObterSituacaoEstoque()
        {
            try
            {

                SQL = "SELECT CodigoProdutoFinal, NomeProdutoFinal, IdArte, (100-(QuantMaximaEstoque-IdArte)*100/QuantMaximaEstoque) As PercMaximo FROM tbProdutoFinal";

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
