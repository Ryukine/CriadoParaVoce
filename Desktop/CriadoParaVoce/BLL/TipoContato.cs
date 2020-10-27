using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class TipoContato
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoTipoContato;
        private string _NomeTipoContato;
        private byte _StatusTipoContato;

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

        public string NomeTipoContato
        {
            get
            {
                return _NomeTipoContato;
            }

            set
            {
                _NomeTipoContato = value.Trim().ToUpper();
            }
        }

        public byte StatusTipoContato
        {
            get
            {
                return _StatusTipoContato;
            }

            set
            {
                _StatusTipoContato = value;
            }
        }

        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeTipoContato",SqlDbType.VarChar) {Value = _NomeTipoContato },
                   new SqlParameter("@StatusTipoContato",SqlDbType.Bit) {Value = _StatusTipoContato }
                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbTipoContato (NomeTipoContato,  StatusTipoContato) VALUES (@NomeTipoContato,  @StatusTipoContato)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoTipoContato",SqlDbType.Int) {Value = _CodigoTipoContato },
                   new SqlParameter("@NomeTipoContato",SqlDbType.VarChar) {Value = _NomeTipoContato },
                  
                   new SqlParameter("@StatusTipoContato",SqlDbType.Bit) {Value = _StatusTipoContato }
                };

                instrucaoSql = "UPDATE tbTipoContato SET NomeTipoContato=@NomeTipoContato, StatusTipoContato=@StatusTipoContato WHERE CodigoTipoContato=@CodigoTipoContato";
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
                instrucaoSql = "UPDATE tbTipoContato SET StatusTipoContato=1   WHERE CodigoTipoContato=" + _CodigoTipoContato;
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
                instrucaoSql = "UPDATE tbTipoContato SET StatusTipoContato=0   WHERE CodigoTipoContato=" + _CodigoTipoContato;
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
                instrucaoSql = "DELETE FROM tbTipoContato  WHERE CodigoTipoContato=" + _CodigoTipoContato;
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
                instrucaoSql = "SELECT * FROM tbTipoContato  WHERE CodigoTipoContato=" + _CodigoTipoContato;
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
                instrucaoSql = "SELECT CodigoTipoContato, NomeTipoContato, StatusTipoContato FROM tbTipoContato";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeTipoContato LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoTipoContato, NomeTipoContato, StatusTipoContato FROM tbTipoContato WHERE StatusTipoContato=1";
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
                instrucaoSql = "SELECT CodigoTipoContato, NomeTipoContato, StatusTipoContato FROM tbTipoContato WHERE StatusTipoContato=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }











    }
}
