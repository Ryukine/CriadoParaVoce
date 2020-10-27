using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ContatoFuncionario
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*IdContato           INT             IDENTITY    not null,
    ConteudoContato     VARCHAR(200)                NOT NULL,
    StatusContato       Bit,
    CodigoFunc       Int,
    CodigoTipoContato   Int,*/

        private int _IdContato;
        private string _ConteudoContato;
        private byte _StatusContato;
        private int _CodigoFunc;
        private int _CodigoTipoContato;

        public int IdContato
        {
            get
            {
                return _IdContato;
            }

            set
            {
                _IdContato = value;
            }
        }

        public string ConteudoContato
        {
            get
            {
                return _ConteudoContato;
            }

            set
            {
                _ConteudoContato = value.ToUpper().Trim();
            }
        }

        public byte StatusContato
        {
            get
            {
                return _StatusContato;
            }

            set
            {
                _StatusContato = value;
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

        public int CodigoTipoContato
        {
            get
            {
                return _CodigoTipoContato;
            }

            set
            {
                _CodigoTipoContato = value;
            }
        }


        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@ConteudoContato",SqlDbType.VarChar) {Value = _ConteudoContato },
                   new SqlParameter("@StatusContato",SqlDbType.Bit) {Value = _StatusContato }
                   ,
                   new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc },
                   new SqlParameter("@CodigoTipoContato",SqlDbType.Int) {Value = _CodigoTipoContato }

                };

                instrucaoSql = "INSERT INTO tbContatoFuncionarioFuncionario (ConteudoContato,  StatusContato, CodigoFunc, CodigoTipoContato) VALUES (@ConteudoContato,  @StatusContato, @CodigoFunc, @CodigoTipoContato)";
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
                     new SqlParameter("@IdContato",SqlDbType.Int) {Value = _IdContato },

                   new SqlParameter("@ConteudoContato",SqlDbType.VarChar) {Value = _ConteudoContato },
                   new SqlParameter("@StatusContato",SqlDbType.Bit) {Value = _StatusContato }
                   ,
                   new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc },
                   new SqlParameter("@CodigoTipoContato",SqlDbType.Int) {Value = _CodigoTipoContato }

                };

                instrucaoSql = "UPDATE tbContatoFuncionario SET ConteudoContato=@ConteudoContato, StatusContato=@StatusContato, CodigoFunc=@CodigoFunc, CodigoTipoContato=@CodigoTipoContato WHERE IdContato=@IdContato";
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
                instrucaoSql = "UPDATE tbContatoFuncionario SET StatusContato=1   WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "UPDATE tbContatoFuncionario SET StatusContato=0   WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "DELETE FROM tbContatoFuncionario  WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "SELECT * FROM tbContatoFuncionario  WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato FROM tbContatoFuncionario";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE ConteudoContato LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato, CodigoFunc FROM tbContatoFuncionario WHERE StatusContato=1";
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato, CodigoFunc FROM tbContatoFuncionario WHERE StatusContato=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet ListarContatosAtivosFuncionario()
        {
            try
            {

                instrucaoSql = "SELECT tbContatoFuncionario.ConteudoContato, tbFuncionario.NomeFuncionario FROM tbContatoFuncionario INNER JOIN tbFuncionario ON tbContatoFuncionario.CodigoFunc = tbFuncionario.CodigoFunc WHERE tbContatoFuncionario.StatusContato=1 AND tbContatoFuncionario.CodigoFunc=" + _CodigoFunc;

                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RetornarQuantidadeContatosAtivosFuncionario()
        {
            try
            {
                instrucaoSql = "SELECT Count(IdContato), StatusContato, CodigoFunc FROM tbContatoFuncionario WHERE StatusContato=1 AND CodigoFunc=" + _CodigoFunc;
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}

