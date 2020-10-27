using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class Contato
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        /*IdContato           INT             IDENTITY    not null,
    ConteudoContato     VARCHAR(200)                NOT NULL,
    StatusContato       Bit,
    CodigoCliente       Int,
    CodigoTipoContato   Int,*/

        private int _IdContato;
        private string _ConteudoContato;
        private byte _StatusContato;
        private int _CodigoCliente;
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
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@CodigoTipoContato",SqlDbType.Int) {Value = _CodigoTipoContato }

                };
          
                instrucaoSql = "INSERT INTO tbContato (ConteudoContato,  StatusContato, CodigoCliente, CodigoTipoContato) VALUES (@ConteudoContato,  @StatusContato, @CodigoCliente, @CodigoTipoContato)";
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
                   new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@CodigoTipoContato",SqlDbType.Int) {Value = _CodigoTipoContato }

                };

                instrucaoSql = "UPDATE tbContato SET ConteudoContato=@ConteudoContato, StatusContato=@StatusContato, CodigoCliente=@CodigoCliente, CodigoTipoContato=@CodigoTipoContato WHERE IdContato=@IdContato";
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
                instrucaoSql = "UPDATE tbContato SET StatusContato=1   WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "UPDATE tbContato SET StatusContato=0   WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "DELETE FROM tbContato  WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "SELECT * FROM tbContato  WHERE IdContato=" + _IdContato;
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato FROM tbContato";
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato, CodigoCliente FROM tbContato WHERE StatusContato=1";
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
                instrucaoSql = "SELECT IdContato, ConteudoContato, StatusContato, CodigoCliente FROM tbContato WHERE StatusContato=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet ListarContatosAtivosCliente()
        {
            try
            {
                
                instrucaoSql = "SELECT tbContato.ConteudoContato, tbCliente.NomeCliente FROM tbContato INNER JOIN tbCliente ON tbContato.CodigoCliente = tbCliente.CodigoCliente WHERE tbContato.StatusContato=1 AND tbContato.CodigoCliente="+_CodigoCliente;

                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int RetornarQuantidadeContatosAtivosCliente()
        {
            try
            {
                instrucaoSql = "SELECT Count(IdContato), StatusContato, CodigoCliente FROM tbContato WHERE StatusContato=1 AND CodigoCliente=" + _CodigoCliente;
                return Convert.ToInt32(c.RetornarDataReader(instrucaoSql)[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
