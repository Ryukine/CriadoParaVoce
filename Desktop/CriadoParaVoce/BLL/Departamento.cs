using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Departamento
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoDepartamento;
        private string _NomeDepartamento;
        private string _DescricaoDepartamento;
        private byte _StatusDepartamento;

        public int CodigoDepartamento
        {
            get
            {
                return _CodigoDepartamento;
            }

            set
            {
                _CodigoDepartamento = value;
            }
        }

        public string NomeDepartamento
        {
            get
            {
                return _NomeDepartamento;
            }

            set
            {
                _NomeDepartamento = value.Trim().ToUpper();
            }
        }

        public byte StatusDepartamento
        {
            get
            {
                return _StatusDepartamento;
            }

            set
            {
                _StatusDepartamento = value;
            }
        }

        public string DescricaoDepartamento
        {
            get
            {
                return _DescricaoDepartamento;
            }

            set
            {
                _DescricaoDepartamento = value.Trim().ToUpper();
            }
        }

        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeDepartamento",SqlDbType.VarChar) {Value = _NomeDepartamento },
                   new SqlParameter("@DescricaoDepartamento",SqlDbType.VarChar) {Value = _DescricaoDepartamento },
                   new SqlParameter("@StatusDepartamento",SqlDbType.Bit) {Value = _StatusDepartamento }
                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbDepartamento (NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES (@NomeDepartamento, @DescricaoDepartamento,  @StatusDepartamento)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoDepartamento",SqlDbType.Int) {Value = _CodigoDepartamento },
                   new SqlParameter("@NomeDepartamento",SqlDbType.VarChar) {Value = _NomeDepartamento },
                   new SqlParameter("@DescricaoDepartamento",SqlDbType.VarChar) {Value = _DescricaoDepartamento },
                   new SqlParameter("@StatusDepartamento",SqlDbType.Bit) {Value = _StatusDepartamento }
                };

                instrucaoSql = "UPDATE tbDepartamento SET NomeDepartamento=@NomeDepartamento, DescricaoDepartamento=@DescricaoDepartamento, StatusDepartamento=@StatusDepartamento WHERE CodigoDepartamento=@CodigoDepartamento";
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
                instrucaoSql = "UPDATE tbDepartamento SET StatusDepartamento=1   WHERE CodigoDepartamento=" + _CodigoDepartamento;
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
                instrucaoSql = "UPDATE tbDepartamento SET StatusDepartamento=0   WHERE CodigoDepartamento=" + _CodigoDepartamento;
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
                instrucaoSql = "DELETE FROM tbDepartamento  WHERE CodigoDepartamento=" + _CodigoDepartamento;
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
                instrucaoSql = "SELECT * FROM tbDepartamento  WHERE CodigoDepartamento=" + _CodigoDepartamento;
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
                instrucaoSql = "SELECT CodigoDepartamento, NomeDepartamento, StatusDepartamento FROM tbDepartamento";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeDepartamento LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoDepartamento, NomeDepartamento, StatusDepartamento FROM tbDepartamento WHERE StatusDepartamento=1";
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
                instrucaoSql = "SELECT CodigoDepartamento, NomeDepartamento, StatusDepartamento FROM tbDepartamento WHERE StatusDepartamento=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}