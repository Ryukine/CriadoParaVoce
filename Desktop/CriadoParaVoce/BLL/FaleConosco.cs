using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class FaleConosco
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _IDMSG;
        private string _EMAIL;
        private string _NOME;
        private byte _STATUS_MSG;
        private string _Assunto;
        private string _TELEFONE;
        private DateTime _DATA_MSG;
        private int _CodigoUsuario;
        private DateTime _DATA_RESP_MSG;
        private string _RESP_MSG;
        private string _ObsOperadora;

        public int IDMSG { get => _IDMSG; set => _IDMSG = value; }
        public string EMAIL { get => _EMAIL; set => _EMAIL = value; }
        public string NOME { get => _NOME; set => _NOME = value; }
        public byte STATUS_MSG { get => _STATUS_MSG; set => _STATUS_MSG = value; }
        public string Assunto { get => _Assunto; set => _Assunto = value; }
        public string TELEFONE { get => _TELEFONE; set => _TELEFONE = value; }
        public DateTime DATA_MSG { get => _DATA_MSG; set => _DATA_MSG = value; }
        public int CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }
        public DateTime DATA_RESP_MSG { get => _DATA_RESP_MSG; set => _DATA_RESP_MSG = value; }
        public string RESP_MSG { get => _RESP_MSG; set => _RESP_MSG = value; }
        public string ObsOperadora { get => _ObsOperadora; set => _ObsOperadora = value; }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@EMAIL",SqlDbType.VarChar) {Value = _EMAIL },
                   new SqlParameter("@NOME",SqlDbType.VarChar) {Value = _NOME },
                   new SqlParameter("@RESP_MSG",SqlDbType.VarChar) {Value = _RESP_MSG },
                   new SqlParameter("@STATUS_MSG",SqlDbType.Bit) {Value = _STATUS_MSG },
                   new SqlParameter("@Assunto",SqlDbType.VarChar) {Value = _Assunto },
                   new SqlParameter("@TELEFONE",SqlDbType.VarChar) {Value = _TELEFONE },
                   new SqlParameter("@DATA_MSG",SqlDbType.DateTime) {Value = _DATA_MSG },
                   new SqlParameter("@CodigoUsuario",SqlDbType.Int) {Value = _CodigoUsuario },
                   new SqlParameter("@DATA_RESP_MSG",SqlDbType.DateTime) {Value = _DATA_RESP_MSG },

                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbFALE_CONOSCO (EMAIL, NOME, RESP_MSG, STATUS_MSG, Assunto, TELEFONE, DATA_MSG, CodigoUsuario, DATA_RESP_MSG) VALUES (@EMAIL, @NOME, @RESP_MSG, @ObsOperadora, @STATUS_MSG, @Assunto, @TELEFONE, @DATA_MSG, @CodigoUsuario, @DATA_RESP_MSG)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@IDMSG",SqlDbType.Int) {Value = _IDMSG },
                   new SqlParameter("@EMAIL",SqlDbType.VarChar) {Value = _EMAIL },
                   new SqlParameter("@NOME",SqlDbType.VarChar) {Value = _NOME },
                   new SqlParameter("@RESP_MSG",SqlDbType.VarChar) {Value = _RESP_MSG },
                   new SqlParameter("@STATUS_MSG",SqlDbType.Bit) {Value = _STATUS_MSG },
                   new SqlParameter("@Assunto",SqlDbType.VarChar) {Value = _Assunto },
                   new SqlParameter("@TELEFONE",SqlDbType.VarChar) {Value = _TELEFONE },
                   new SqlParameter("@DATA_MSG",SqlDbType.DateTime) {Value = _DATA_MSG },
                   new SqlParameter("@CodigoUsuario",SqlDbType.Int) {Value = _CodigoUsuario },
                   new SqlParameter("@DATA_RESP_MSG",SqlDbType.DateTime) {Value = _DATA_RESP_MSG },

                };

                instrucaoSql = "UPDATE tbFALE_CONOSCO SET EMAIL=@EMAIL, NOME=@NOME, RESP_MSG=@RESP_MSG, STATUS_MSG=@STATUS_MSG, Assunto=@Assunto, TELEFONE=@TELEFONE, DATA_MSG=@DATA_MSG, CodigoUsuario=@CodigoUsuario, DATA_RESP_MSG=@DATA_RESP_MSG WHERE IDMSG=@IDMSG ";
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
                instrucaoSql = "UPDATE tbFALE_CONOSCO SET STATUS_MSG=1   WHERE IDMSG=" + _IDMSG;
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
                instrucaoSql = "UPDATE tbFALE_CONOSCO SET STATUS_MSG=0   WHERE IDMSG=" + _IDMSG;
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
                instrucaoSql = "DELETE FROM tbFALE_CONOSCO  WHERE IDMSG=" + _IDMSG;
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
                instrucaoSql = "SELECT * FROM tbFALE_CONOSCO WHERE IDMSG =" + _IDMSG;
                return c.RetornarDataReader(instrucaoSql);
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
                instrucaoSql = "SELECT IDMSG, EMAIL, NOME, Assunto, CodigoUsuario, DATA_MSG FROM tbFALE_CONOSCO";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NOME LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }
                return c.RetornarDataSet(instrucaoSql);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet Listar2(string parteNomeUsuario, byte TipoStatusUsuario)
        {
            try
            {
                instrucaoSql = "SELECT IDMSG, EMAIL, NOME, Assunto, DATA_MSG FROM tbFALE_CONOSCO";
                if (parteNomeUsuario.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NOME LIKE '%" + parteNomeUsuario + "%'";
                }
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
                instrucaoSql = "SELECT IDMSG, EMAIL, NOME, Assunto, DATA_MSG, STATUS_MSG FROM tbFALE_CONOSCO WHERE STATUS_MSG=1";
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
                instrucaoSql = "SELECT IDMSG, EMAIL, NOME, Assunto, DATA_MSG, STATUS_MSG FROM tbFALE_CONOSCO WHERE STATUS_MSG=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
