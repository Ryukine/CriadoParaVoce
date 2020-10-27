using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Arte
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*
         * IdArte	INT				   IDENTITY PRIMARY KEY not null,
	NomeArte	Varchar(80),
	arquivoArte	int,
	PrecoArte	DATETIME,
	Altura	DATETIME,
	Largura INT,
         */

        private int _IdArte;
        private string _NomeArte;
        private string _arquivoArte;
        private double _PrecoArte;
        private int _Altura;
        private int _Largura;

        public int IdArte
        {
            get
            {
                return _IdArte;
            }

            set
            {
                _IdArte = value;
            }
        }

        public string NomeArte
        {
            get
            {
                return _NomeArte;
            }

            set
            {
                _NomeArte = value;
            }
        }

        public string arquivoArte
        {
            get
            {
                return _arquivoArte;
            }

            set
            {
                _arquivoArte = value;
            }
        }

        public double PrecoArte
        {
            get
            {
                return _PrecoArte;
            }

            set
            {
                _PrecoArte = value;
            }
        }

        public int Altura
        {
            get
            {
                return _Altura;
            }

            set
            {
                _Altura = value;
            }
        }

        public int Largura
        {
            get
            {
                return _Largura;
            }

            set
            {
                _Largura = value;
            }
        }

        public void Incluir()
        {
            try
            {
                instrucaoSql = "INSERT INTO tbArte (NomeArte,arquivoArte, PrecoArte, Altura, Largura) Values('" + _NomeArte + "', " + _arquivoArte + ", '" + _PrecoArte + "', " + _Altura + ", '" + _Largura + "')";
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
                    new SqlParameter("@NomeArte",SqlDbType.VarChar) {Value = _NomeArte },
                    new SqlParameter("@arquivoArte",SqlDbType.VarChar) {Value = _arquivoArte },
                    new SqlParameter("@PrecoArte",SqlDbType.Decimal) {Value = _PrecoArte },
                    new SqlParameter("@Altura",SqlDbType.Int) {Value = _Altura },
                    new SqlParameter("@Largura",SqlDbType.Int) {Value = _Largura }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um Altura '{Value = _....}'
                instrucaoSql = "INSERT INTO tbArte (NomeArte, arquivoArte,  PrecoArte, Altura, Largura) Values (@NomeArte, @arquivoArte, @PrecoArte, @Altura, @Largura)";
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

                /*_NomeArte = "ZE";
                _PrecoArte = "M";
                _arquivoArte = 1;
                _Altura = "ZE@ZE.COM.BR";
                _DuracaoPlano = DateTime.Now.AddYears(-20);
                _Largura = "17097010800";
                _Logradouro = "RUA CAIM";
                _Cep = "06406200";
                _UF = "SP";
                _Cidade = "BARUERI";
                _Bairro = "JARDIM SAO PEDRO";
                _Numero = "112";
                _Complemento = "CASA 1";*/


                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@NomeArte",SqlDbType.VarChar) {Value = _NomeArte },
                    new SqlParameter("@PrecoArte",SqlDbType.Decimal) {Value = _PrecoArte },
                    new SqlParameter("@arquivoArte",SqlDbType.VarChar) {Value = _arquivoArte },
                    new SqlParameter("@Altura",SqlDbType.Int) {Value = _Altura },
                    new SqlParameter("@Largura",SqlDbType.Int) {Value = _Largura }
                };

                instrucaoSql = "INSERT INTO tbArte (NomeArte, PrecoArte, arquivoArte, Altura, Largura) Values (@NomeArte, @PrecoArte, @arquivoArte, @Altura,@Largura)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@IdArte",SqlDbType.Int) {Value = _IdArte },
                    new SqlParameter("@NomeArte",SqlDbType.VarChar) {Value = _NomeArte },
                    new SqlParameter("@arquivoArte",SqlDbType.VarChar) {Value = _arquivoArte },
                    new SqlParameter("@PrecoArte",SqlDbType.Decimal) {Value = _PrecoArte },
                    new SqlParameter("@Altura",SqlDbType.Int) {Value = _Altura },
                    new SqlParameter("@Largura",SqlDbType.Int) {Value = _Largura }
                };
                instrucaoSql = "UPDATE tbArte SET NomeArte =@NomeArte, arquivoArte=@arquivoArte, PrecoArte=@PrecoArte, Altura=@Altura, Largura=@Largura WHERE IdArte=@IdArte";
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
                instrucaoSql = "INSERT INTO tbArte(NomeArte, arquivoArte) Values ('" + _NomeArte +
                    "', " + _arquivoArte + ")";
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
                instrucaoSql = "UPDATE tbArte Set NomeArte= '" + _NomeArte + "', arquivoArte = " + _arquivoArte + " WHERE IdArte = _IdArte";
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
                instrucaoSql = "UPDATE tbArte SET arquivoArte = 1 WHERE IdArte = " + _IdArte + "";
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
                instrucaoSql = "UPDATE tbArte SET arquivoArte = 0 WHERE IdArte = " + _IdArte + "";
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
                instrucaoSql = "DELETE FROM tbArte WHERE IdArte = " + _IdArte + "";
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
                instrucaoSql = "SELECT * FROM tbArte WHERE IdArte= " + _IdArte + "";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNomeArte, byte TipoarquivoArte)
        {
            try
            {
                instrucaoSql = "SELECT IdArte, NomeArte, arquivoArte FROM tbArte";
                if (parteNomeArte.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeArte LIKE '%" + parteNomeArte + "%'";
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
                instrucaoSql = "SELECT tbOperadora.NomeOperadora FROM tbOperadora INNER JOIN tbCampanha ON  tbOperadora.Largura = tbCampanha.Largura WHERE tbCampanha.IdArte =" + _IdArte + "";
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
                instrucaoSql = "SELECT IdArte, NomeArte, arquivoArte FROM tbArte WHERE arquivoArte=1";
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
                instrucaoSql = "SELECT IdArte, NomeArte, arquivoArte FROM tbArte WHERE arquivoArte=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
