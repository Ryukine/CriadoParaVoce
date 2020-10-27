using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Plano
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*
         * CodigoPlano		INT					IDENTITY	Not null,
	NomePlano		Varchar(80),
	DuracaoPlano	DATETIME,
	FaixaEtaria		Varchar(80),
	Valor			Decimal(10,2),
	CodigoOperadora INT,
         */

        private int _CodigoPlano;
        private string _NomePlano;
        private DateTime _DuracaoPlano;
        private string _FaixaEtaria;
        private int _StatusPlano;
        private double _Valor;
        private int _CodigoOperadora;

        public int CodigoPlano
        {
            get
            {
                return _CodigoPlano;
            }

            set
            {
                _CodigoPlano = value;
            }
        }

        public string NomePlano
        {
            get
            {
                return _NomePlano;
            }

            set
            {
                _NomePlano = value;
            }
        }

        public DateTime DuracaoPlano
        {
            get
            {
                return _DuracaoPlano;
            }

            set
            {
                _DuracaoPlano = value;
            }
        }

        public string FaixaEtaria
        {
            get
            {
                return _FaixaEtaria;
            }

            set
            {
                _FaixaEtaria = value;
            }
        }

        public double Valor
        {
            get
            {
                return _Valor;
            }

            set
            {
                _Valor = value;
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

        public int StatusPlano
        {
            get
            {
                return _StatusPlano;
            }

            set
            {
                _StatusPlano = value;
            }
        }

        public void Incluir()
        {
            try
            {
                instrucaoSql = "INSERT INTO tbPlano (NomePlano,StatusPlano, FaixaEtaria, Valor, CodigoOperadora) Values('" + _NomePlano + "', " + _StatusPlano + ", '" + _FaixaEtaria + "', " + _Valor + ", '" + _CodigoOperadora + "')";
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
                    new SqlParameter("@NomePlano",SqlDbType.VarChar) {Value = _NomePlano },
                    new SqlParameter("@StatusPlano",SqlDbType.Int) {Value = _StatusPlano },
                    new SqlParameter("@FaixaEtaria",SqlDbType.VarChar) {Value = _FaixaEtaria },
                    new SqlParameter("@Valor",SqlDbType.Decimal) {Value = _Valor },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora },
                    new SqlParameter("@DuracaoPlano",SqlDbType.Decimal) {Value = _DuracaoPlano }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                instrucaoSql = "INSERT INTO tbPlano (NomePlano, StatusPlano,  FaixaEtaria, Valor, CodigoOperadora, DuracaoPlano) Values (@NomePlano, @StatusPlano, @FaixaEtaria, @Valor, @CodigoOperadora, @DuracaoPlano)";
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

                /*_NomePlano = "ZE";
                _FaixaEtaria = "M";
                _StatusPlano = 1;
                _Valor = "ZE@ZE.COM.BR";
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
                    new SqlParameter("@NomePlano",SqlDbType.VarChar) {Value = _NomePlano },
                    new SqlParameter("@FaixaEtaria",SqlDbType.Char) {Value = _FaixaEtaria },
                    new SqlParameter("@StatusPlano",SqlDbType.Int) {Value = _StatusPlano },
                    new SqlParameter("@Valor",SqlDbType.Decimal) {Value = _Valor },
                    new SqlParameter("@DuracaoPlano",SqlDbType.Decimal) {Value = _DuracaoPlano },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora }
                };

                instrucaoSql = "INSERT INTO tbPlano (NomePlano, FaixaEtaria, StatusPlano, Valor, CodigoOperadora, DuracaoPlano) Values (@NomePlano, @FaixaEtaria, @StatusPlano, @Valor,@CodigoOperadora, @DuracaoPlano)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoPlano",SqlDbType.Int) {Value = _CodigoPlano },
                    new SqlParameter("@NomePlano",SqlDbType.VarChar) {Value = _NomePlano },
                    new SqlParameter("@StatusPlano",SqlDbType.Int) {Value = _StatusPlano },
                    new SqlParameter("@FaixaEtaria",SqlDbType.VarChar) {Value = _FaixaEtaria },
                    new SqlParameter("@Valor",SqlDbType.Decimal) {Value = _Valor },
                    new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora },
                    new SqlParameter("@DuracaoPlano",SqlDbType.Decimal) {Value = _DuracaoPlano }
                };
                instrucaoSql = "UPDATE tbPlano SET NomePlano =@NomePlano, StatusPlano=@StatusPlano, FaixaEtaria=@FaixaEtaria, Valor=@Valor, CodigoOperadora=@CodigoOperadora, DuracaoPlano=@DuracaoPlano WHERE CodigoPlano=@CodigoPlano";
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
                instrucaoSql = "INSERT INTO tbPlano(NomePlano, StatusPlano) Values ('" + _NomePlano +
                    "', " + _StatusPlano + ")";
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
                instrucaoSql = "UPDATE tbPlano Set NomePlano= '" + _NomePlano + "', StatusPlano = " + _StatusPlano + " WHERE CodigoPlano = _CodigoPlano";
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
                instrucaoSql = "UPDATE tbPlano SET StatusPlano = 1 WHERE CodigoPlano = " + _CodigoPlano + "";
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
                instrucaoSql = "UPDATE tbPlano SET StatusPlano = 0 WHERE CodigoPlano = " + _CodigoPlano + "";
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
                instrucaoSql = "DELETE FROM tbPlano WHERE CodigoPlano = " + _CodigoPlano + "";
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
                instrucaoSql = "SELECT * FROM tbPlano WHERE CodigoPlano= " + _CodigoPlano + "";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNomePlano, byte TipoStatusPlano)
        {
            try
            {
                instrucaoSql = "SELECT CodigoPlano, NomePlano, StatusPlano FROM tbPlano";
                if (parteNomePlano.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomePlano LIKE '%" + parteNomePlano + "%'";
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
                instrucaoSql = "SELECT CodigoPlano, NomePlano, StatusPlano FROM tbPlano WHERE StatusPlano=1";
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
                instrucaoSql = "SELECT CodigoPlano, NomePlano, StatusPlano FROM tbPlano WHERE StatusPlano=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
