using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Campanha
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*
         * CodigoCampanha	INT				   IDENTITY PRIMARY KEY not null,
	NomeCampanha	Varchar(80),
	StatusCampanha	int,
	InicioCampanha	DATETIME,
	FinalCampanha	DATETIME,
	CodigoOperadora INT,
         */

        private int _CodigoCampanha;
        private string _NomeCampanha;
        private int _StatusCampanha;
        private DateTime _InicioCampanha;
        private DateTime _FinalCampanha;
        private int _CodigoOperadora;

        public int CodigoCampanha
        {
            get
            {
                return _CodigoCampanha;
            }

            set
            {
                _CodigoCampanha = value;
            }
        }

        public string NomeCampanha
        {
            get
            {
                return _NomeCampanha;
            }

            set
            {
                _NomeCampanha = value;
            }
        }

        public int StatusCampanha
        {
            get
            {
                return _StatusCampanha;
            }

            set
            {
                _StatusCampanha = value;
            }
        }

        public DateTime InicioCampanha
        {
            get
            {
                return _InicioCampanha;
            }

            set
            {
                _InicioCampanha = value;
            }
        }

        public DateTime FinalCampanha
        {
            get
            {
                return _FinalCampanha;
            }

            set
            {
                _FinalCampanha = value;
            }
        }

        public int CodigoOperadora
        {
            get
            {
                return _CodigoOperadora;
            }

            set
            {
                _CodigoOperadora = value;
            }
        }

        public void Incluir()
        {
            try
            {
                instrucaoSql = "INSERT INTO tbPlano (NomeCampanha,StatusCampanha, InicioCampanha, FinalCampanha, CodigoOperadora) Values('" + _NomeCampanha + "', " + _StatusCampanha + ", '" + _InicioCampanha + "', " + _FinalCampanha + ", '" + _CodigoOperadora + "')";
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
                    new SqlParameter("@NomeCampanha",SqlDbType.VarChar) {Value = _NomeCampanha },
                    new SqlParameter("@StatusCampanha",SqlDbType.Int) {Value = _StatusCampanha },
                    new SqlParameter("@InicioCampanha",SqlDbType.VarChar) {Value = _InicioCampanha },
                    new SqlParameter("@FinalCampanha",SqlDbType.Decimal) {Value = _FinalCampanha },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um FinalCampanha '{Value = _....}'
                instrucaoSql = "INSERT INTO tbPlano (NomeCampanha, StatusCampanha,  InicioCampanha, FinalCampanha, CodigoOperadora) Values (@NomeCampanha, @StatusCampanha, @InicioCampanha, @FinalCampanha, @CodigoOperadora)";
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

                /*_NomeCampanha = "ZE";
                _InicioCampanha = "M";
                _StatusCampanha = 1;
                _FinalCampanha = "ZE@ZE.COM.BR";
                _DuracaoPlano = DateTime.Now.AddYears(-20);
                _CodigoOperadora = "17097010800";
                _Logradouro = "RUA CAIM";
                _Cep = "06406200";
                _UF = "SP";
                _Cidade = "BARUERI";
                _Bairro = "JARDIM SAO PEDRO";
                _Numero = "112";
                _Complemento = "CASA 1";*/


                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@NomeCampanha",SqlDbType.VarChar) {Value = _NomeCampanha },
                    new SqlParameter("@InicioCampanha",SqlDbType.Char) {Value = _InicioCampanha },
                    new SqlParameter("@StatusCampanha",SqlDbType.Int) {Value = _StatusCampanha },
                    new SqlParameter("@FinalCampanha",SqlDbType.Decimal) {Value = _FinalCampanha },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora }
                };

                instrucaoSql = "INSERT INTO tbPlano (NomeCampanha, InicioCampanha, StatusCampanha, FinalCampanha, CodigoOperadora) Values (@NomeCampanha, @InicioCampanha, @StatusCampanha, @FinalCampanha,@CodigoOperadora)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoCampanha",SqlDbType.Int) {Value = _CodigoCampanha },
                    new SqlParameter("@NomeCampanha",SqlDbType.VarChar) {Value = _NomeCampanha },
                    new SqlParameter("@StatusCampanha",SqlDbType.Int) {Value = _StatusCampanha },
                    new SqlParameter("@InicioCampanha",SqlDbType.VarChar) {Value = _InicioCampanha },
                    new SqlParameter("@FinalCampanha",SqlDbType.Decimal) {Value = _FinalCampanha },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora }
                };
                instrucaoSql = "UPDATE tbPlano SET NomeCampanha =@NomeCampanha, StatusCampanha=@StatusCampanha, InicioCampanha=@InicioCampanha, FinalCampanha=@FinalCampanha, CodigoOperadora=@CodigoOperadora WHERE CodigoCampanha=@CodigoCampanha";
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
                instrucaoSql = "INSERT INTO tbPlano(NomeCampanha, StatusCampanha) Values ('" + _NomeCampanha +
                    "', " + _StatusCampanha + ")";
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
                instrucaoSql = "UPDATE tbPlano Set NomeCampanha= '" + _NomeCampanha + "', StatusCampanha = " + _StatusCampanha + " WHERE CodigoCampanha = _CodigoCampanha";
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
                instrucaoSql = "UPDATE tbPlano SET StatusCampanha = 1 WHERE CodigoCampanha = " + _CodigoCampanha + "";
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
                instrucaoSql = "UPDATE tbPlano SET StatusCampanha = 0 WHERE CodigoCampanha = " + _CodigoCampanha + "";
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
                instrucaoSql = "DELETE FROM tbPlano WHERE CodigoCampanha = " + _CodigoCampanha + "";
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
                instrucaoSql = "SELECT * FROM tbPlano WHERE CodigoCampanha= " + _CodigoCampanha + "";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNomeCampanha, byte TipoStatusCampanha)
        {
            try
            {
                instrucaoSql = "SELECT CodigoCampanha, NomeCampanha, StatusCampanha FROM tbPlano";
                if (parteNomeCampanha.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeCampanha LIKE '%" + parteNomeCampanha + "%'";
                }
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader RetornarNivelAcesso()
        {
            try
            {
                instrucaoSql = "SELECT tbOperadora.NomeOperadora FROM tbOperadora INNER JOIN tbCampanha ON  tbOperadora.CodigoOperadora = tbCampanha.CodigoOperadora WHERE tbCampanha.CodigoCampanha =" + _CodigoCampanha + "";
                return c.RetornarDataReader(instrucaoSql);
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
                instrucaoSql = "SELECT CodigoCampanha, NomeCampanha, StatusCampanha FROM tbPlano WHERE StatusCampanha=1";
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
                instrucaoSql = "SELECT CodigoCampanha, NomeCampanha, StatusCampanha FROM tbPlano WHERE StatusCampanha=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
