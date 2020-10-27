using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BLL
{
    public class Produto
    {
        private static string SQL;
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CodigoProduto;

        public int CodigoProduto
        {
            get { return _CodigoProduto; }
            set { _CodigoProduto = value; }
        }
        private int _CategoriaId;

        public int CategoriaId
        {
            get { return _CategoriaId; }
            set { _CategoriaId = value; }
        }
        private int _FornecedorId;

        public int FornecedorId
        {
            get { return _FornecedorId; }
            set { _FornecedorId = value; }
        }
        private string _NomeProduto;

        public string NomeProduto
        {
            get { return _NomeProduto; }
            set { _NomeProduto = value; }
        }
        private int _QuantMinimaEstoque;

        public int QuantMinimaEstoque
        {
            get { return _QuantMinimaEstoque; }
            set { _QuantMinimaEstoque = value; }
        }
        private int _QuantEstoque;

        public int QuantEstoque
        {
            get { return _QuantEstoque; }
            set { _QuantEstoque = value; }
        }
        private int _StatusProduto;

        public int StatusProduto
        {
            get { return _StatusProduto; }
            set { _StatusProduto = value; }
        }

        public double PrecoProduto
        {
            get { return _PrecoProduto; }
            set { _PrecoProduto = value; }
        }

        public string FotoProduto
        {
            get { return _FotoProduto; }
            set { _FotoProduto = value; }
        }

        public int Tamanho
        {
            get { return _Tamanho; }
            set { _Tamanho = value; }
        }

        private int _Tamanho;
        private double _PrecoProduto;

        private string _FotoProduto;

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeProduto",SqlDbType.VarChar) {Value = _NomeProduto },
                   new SqlParameter("@StatusProduto",SqlDbType.Int) {Value = _StatusProduto }                 
                   ,
                    new SqlParameter("@FotoDoProduto",SqlDbType.VarChar) {Value = _FotoProduto },
                   new SqlParameter("@CategoriaId",SqlDbType.Int) {Value = _CategoriaId },
                   new SqlParameter("@FornecedorId",SqlDbType.Int) {Value = _FornecedorId },        
                   new SqlParameter("@PrecoProduto",SqlDbType.Decimal) {Value = _PrecoProduto }

                };

                SQL = "INSERT INTO tbProduto (NomeProduto,  StatusProduto, FotoDoProduto, CategoriaId, FornecedorId, PrecoProduto) VALUES (@NomeProduto,  @StatusProduto, @FotoDoProduto, @CategoriaId, @FornecedorId, @PrecoProduto)";
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
                     new SqlParameter("@CodigoProduto",SqlDbType.Int) {Value = _CodigoProduto },

                   new SqlParameter("@CategoriaId",SqlDbType.Int) {Value = _CategoriaId },
                   new SqlParameter("@StatusProduto",SqlDbType.Int) {Value = _StatusProduto }
                   ,
                   new SqlParameter("@FotoDoProduto",SqlDbType.VarChar) {Value = _FotoProduto },
                   new SqlParameter("@NomeProduto",SqlDbType.VarChar) {Value = _NomeProduto },
                   new SqlParameter("@FornecedorId",SqlDbType.Int) {Value = _FornecedorId },
                   new SqlParameter("@PrecoProduto",SqlDbType.Decimal) {Value = _PrecoProduto }

                };

                SQL = "UPDATE tbProduto SET CategoriaId=@CategoriaId, StatusProduto=@StatusProduto, FotoDoProduto=@FotoDoProduto, NomeProduto=@NomeProduto,  FornecedorId=@FornecedorId, PrecoProduto=@PrecoProduto WHERE CodigoProduto=@CodigoProduto";
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
                SQL = "INSERT INTO TBPRODUTO (CATEGORIAID, FORNECEDORID, NomeProduto, QuantEstoque, QuantMinimaEstoque, StatusProduto, PrecoProduto, FotoDoProduto) VALUES (" + _CategoriaId + ", " + _FornecedorId + ", '" + _NomeProduto + "', " + _QuantEstoque + ", " + _QuantMinimaEstoque + ", " + _StatusProduto + ", "+ _PrecoProduto + ", "+ _FotoProduto + ")";
                c.ExecutarComando(SQL);
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
                SQL = "INSERT INTO TBPRODUTO (CATEGORIAID, FORNECEDORID, NomeProduto, QuantMinimaEstoque, QuantEstoque, StatusProduto) VALUES (" + _CategoriaId + ", " + _FornecedorId + ", '" + _NomeProduto + "', " + _QuantMinimaEstoque + ", " + _QuantEstoque + ", " + _StatusProduto + ")";
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
                SQL = "UPDATE TBPRODUTO SET NomeProduto = '" + _NomeProduto + "', StatusProduto = " + _StatusProduto + ", Tamanho = " + _Tamanho +", CATEGORIAID = " + _CategoriaId+", FORNECEDORID = "+_FornecedorId+", QuantMinimaEstoque = "+_QuantMinimaEstoque+", QuantEstoque = "+_QuantEstoque+" WHERE CodigoProduto = " + _CodigoProduto + " ";
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
                SQL = "UPDATE TBPRODUTO SET StatusProduto = 0  WHERE CodigoProduto=" + _CodigoProduto;
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
                SQL = "UPDATE TBPRODUTO SET StatusProduto =1   WHERE CodigoProduto=" + _CodigoProduto;
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
                SQL = "DELETE FROM TBPRODUTO WHERE CodigoProduto = " + _CodigoProduto + " ";
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
                SQL = "SELECT * FROM TBPRODUTO WHERE CodigoProduto = " + _CodigoProduto + " ";
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
                SQL = "SELECT CodigoProduto, NomeProduto, PrecoProduto FROM tbProduto";

                if (parteNome.Length != 0)
                {
                    if (BLL.FuncoesGerais.IsNumeric(parteNome))
                    {
                        _CodigoProduto = Convert.ToInt32(parteNome);
                        SQL = "SELECT CodigoProduto, NomeProduto, PrecoProduto FROM tbProduto WHERE CodigoProduto =" + _CodigoProduto;
                    }
                    else
                    {
                        SQL = SQL + " WHERE NomeProduto LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                    }
                }

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public SqlDataReader RetornarCategoria()
        {
            try
            {
                SQL = "SELECT c.DescricaoCategoria FROM tbProduto p JOIN tbCategoria c ON p.CategoriaId = c.CategoriaId WHERE p.CodigoProduto = " + _CodigoProduto + "";
                return c.RetornarDataReader(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader RetornarFornecedor()
        {
            try
            {
                SQL = "SELECT f.Descricao FROM tbProduto p JOIN tbFornecedor f ON p.FornecedorId = f.FornecedorId WHERE p.CodigoProduto =" + _CodigoProduto + "";
                return c.RetornarDataReader(SQL);
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
                SQL = "SELECT CodigoProduto, NomeProduto, PrecoProduto FROM tbProduto";

                if (parteNome != 0)
                {
                    if (BLL.FuncoesGerais.IsNumeric(parteNome))
                    {
                        _CategoriaId = Convert.ToInt32(parteNome);
                        SQL = "SELECT CodigoProduto, NomeProduto, PrecoProduto FROM tbProduto WHERE CategoriaId =" + _CategoriaId;
                    }
                    else
                    {
                        SQL = SQL + " WHERE NomeProduto LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                SQL = "SELECT CodigoProduto, NomeProduto, StatusProduto FROM tbProduto WHERE StatusProduto= 1 ORDER BY NomeProduto";
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
                SQL = "SELECT CodigoProduto, NomeProduto, StatusProduto FROM tbProduto WHERE StatusProduto= 0 ORDER BY NomeProduto";
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

                SQL = "SELECT CodigoProduto, NomeProduto, QuantEstoque, (100-(QuantMaximaEstoque-QuantEstoque)*100/QuantMaximaEstoque) As PercMaximo FROM tbProduto";

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
