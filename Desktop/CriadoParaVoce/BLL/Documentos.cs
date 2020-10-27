using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Documentos
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*
         * CodigoDco			INT             IDENTITY    not null,
	tipoDco				VARCHAR(50)					NOT NULL,
    caminhoDco			VARCHAR(50)					not null,
	CodigoCliente       int , -- FK
         */

        private int _CodigoDco;
        private string _tipoDco;
        private string _caminhoDco;
        private int _CodigoCliente;
        private int _StatusDco;

        public int CodigoDco
        {
            get
            {
                return _CodigoDco;
            }

            set
            {
                _CodigoDco = value;
            }
        }

        public string TipoDco
        {
            get
            {
                return _tipoDco;
            }

            set
            {
                _tipoDco = value;
            }
        }

        public int CodigoCliente
        {
            get
            {
                return _CodigoCliente;
            }

            set
            {
                _CodigoCliente = value;
            }
        }

        public int StatusDco
        {
            get
            {
                return _StatusDco;
            }

            set
            {
                _StatusDco = value;
            }
        }

        public string CaminhoDco
        {
            get
            {
                return _caminhoDco;
            }

            set
            {
                _caminhoDco = value;
            }
        }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@tipoDco",SqlDbType.VarChar) {Value = _tipoDco },
                   new SqlParameter("@StatusDco",SqlDbType.Int) {Value = _StatusDco }
                   ,
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@caminhoDco",SqlDbType.VarChar) {Value = _caminhoDco }

                };

                instrucaoSql = "INSERT INTO tbDocumentos (tipoDco, StatusDco, CodigoCliente, caminhoDco) VALUES (@tipoDco,  @StatusDco, @CodigoCliente, @caminhoDco)";
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
                     new SqlParameter("@CodigoDco",SqlDbType.Int) {Value = _CodigoDco },

                   new SqlParameter("@tipoDco",SqlDbType.VarChar) {Value = _tipoDco },
                   new SqlParameter("@StatusDco",SqlDbType.Int) {Value = _StatusDco }
                   ,
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@caminhoDco",SqlDbType.VarChar) {Value = _caminhoDco }

                };

                instrucaoSql = "UPDATE tbDocumentos SET tipoDco=@tipoDco, StatusDco=@StatusDco, CodigoCliente=@CodigoCliente, caminhoDco=@caminhoDco WHERE CodigoDco=@CodigoDco";
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
                instrucaoSql = "UPDATE tbDocumentos SET StatusDco=1   WHERE CodigoDco=" + _CodigoDco;
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
                instrucaoSql = "UPDATE tbDocumentos SET StatusDco=0   WHERE CodigoDco=" + _CodigoDco;
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
                instrucaoSql = "DELETE FROM tbDocumentos  WHERE CodigoDco=" + _CodigoDco;
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
                instrucaoSql = "SELECT * FROM tbDocumentos  WHERE CodigoDco=" + _CodigoDco;
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
                instrucaoSql = "SELECT CodigoDco, tipoDco, StatusDco FROM tbDocumentos";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE tipoDco LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoDco, tipoDco, StatusDco, CodigoCliente FROM tbDocumentos WHERE StatusDco=1";
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
                instrucaoSql = "SELECT CodigoDco, tipoDco, StatusDco, CodigoCliente FROM tbDocumentos WHERE StatusDco=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet ListarDocumentos()
        {
            try
            {

                instrucaoSql = "SELECT tbDocumentos.tipoDco, tbCliente.NomeCliente FROM tbDocumentos INNER JOIN tbCliente ON tbDocumentos.CodigoCliente = tbCliente.CodigoCliente WHERE tbDocumentos.StatusDco=1 AND tbDocumentos.CodigoDco=" + _CodigoDco;

                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RetornarQuantidadeDocumentos()
        {
            try
            {
                instrucaoSql = "SELECT Count(CodigoDco), StatusDco, CodigoCliente FROM tbDocumentos WHERE StatusDco=1 AND CodigoCliente=" + _CodigoCliente;
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
