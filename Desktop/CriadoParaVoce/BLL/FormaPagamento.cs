using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class FormaPagamento
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CodigoPagamento;
        private string _DescricaoPagamento;
        private byte _StatusPagamento;

        public int CodigoPagamento
        {
            get
            {
                return _CodigoPagamento;
            }

            set
            {
                _CodigoPagamento = value;
            }
        }

        public string DescricaoPagamento
        {
            get
            {
                return _DescricaoPagamento;
            }

            set
            {
                _DescricaoPagamento = value;
            }
        }

        public byte StatusPagamento
        {
            get
            {
                return _StatusPagamento;
            }

            set
            {
                _StatusPagamento = value;
            }
        }

        private static string instrucaoSql;

        /*public void CriarNivel()
        {
            try
            {
                _DescricaoPagamento = "ADMINISTRADOR";
                _AbreviacaoNivel = "ADM";
                _StatusPagamento = (byte)BLL.FuncoesGerais.NivelDeAcesso.Administrador;
                SqlParameter[] listaComParametros =
                    {
                  new SqlParameter("@DescricaoPagamento",SqlDbType.VarChar) {Value = _DescricaoPagamento },
                  new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel },
                  new SqlParameter("@StatusPagamento",SqlDbType.VarChar) {Value = _StatusPagamento }
                };
                instrucaoSql = "INSERT INTO tbFormasDePagamento (DescricaoPagamento, AbreviacaoNivel, StatusPagamento) VALUES (@DescricaoPagamento, @AbreviacaoNivel, @StatusPagamento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
                /*
                listaComParametros.Initialize();
                listaComParametros[0].Value = "SUPERVISOR";
                listaComParametros[1].Value = "SUP";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Supervisor;

                instrucaoSql = "INSERT INTO tbFormasDePagamento (DescricaoPagamento, AbreviacaoNivel, StatusPagamento) VALUES (@DescricaoPagamento, @AbreviacaoNivel, @StatusPagamento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "USUÁRIO";
                listaComParametros[1].Value = "USR";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Usuario;
                instrucaoSql = "INSERT INTO tbFormasDePagamento (DescricaoPagamento, AbreviacaoNivel, StatusPagamento) VALUES (@DescricaoPagamento, @AbreviacaoNivel, @StatusPagamento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "ROOT";
                listaComParametros[1].Value = "ROT";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Root;
                instrucaoSql = "INSERT INTO tbFormasDePagamento (DescricaoPagamento, AbreviacaoNivel, StatusPagamento) VALUES (@DescricaoPagamento, @AbreviacaoNivel, @StatusPagamento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }*/

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@DescricaoPagamento",SqlDbType.VarChar) {Value = _DescricaoPagamento },
                    new SqlParameter("@StatusPagamento",SqlDbType.Bit) {Value = _StatusPagamento }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                instrucaoSql = "INSERT INTO tbFormasDePagamento (DescricaoPagamento, StatusPagamento) Values (@DescricaoPagamento, @StatusPagamento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametro);


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
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@CodigoPagamento",SqlDbType.Int) {Value = _CodigoPagamento },
                    new SqlParameter("@DescricaoPagamento",SqlDbType.VarChar) {Value = _DescricaoPagamento },
                    new SqlParameter("@StatusPagamento",SqlDbType.Bit) {Value = _StatusPagamento }
                };
                instrucaoSql = "UPDATE tbFormasDePagamento SET DescricaoPagamento =@DescricaoPagamento, StatusPagamento=@StatusPagamento";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void TrocarSenhaComParametro()
        //{
        //    try
        //    {
        //        SqlParameter[] listaComParametro =
        //        {
        //            new SqlParameter("@CodigoPagamento",SqlDbType.Int) {Value = _CodigoPagamento },
        //            new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel }
        //        };
        //        instrucaoSql = "UPDATE tbFormasDePagamento SET AbreviacaoNivel=@AbreviacaoNivel WHERE CodigoPagamento=@CodigoPagamento";
        //        c.ExecutarComandoParametro(instrucaoSql, listaComParametro);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public int IncluirRetornarNumeroAutomatico()
        {
            try
            {
                instrucaoSql = "INSERT INTO TbUsuario(DescricaoPagamento, AbreviacaoNivel, StatusPagamento) Values ('" + _DescricaoPagamento + "', " + _StatusPagamento + ")";
                return c.RecuperarUltimoCodigoNumeracaoAutomatica(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void Alterar()
        //{
        //    try
        //    {
        //        instrucaoSql = "UPDATE tbFormasDePagamento Set DescricaoPagamento= '" + _DescricaoPagamento + "', AbreviacaoNivel = '" + _AbreviacaoNivel + "', StatusPagamento = " + _StatusPagamento + " WHERE CodigoPagamento = _CodigoPagamento";
        //        c.ExecutarComando(instrucaoSql);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public void TrocarSenha()
        //{
        //    try
        //    {
        //        instrucaoSql = "UPDATE tbFormasDePagamento SET AbreviacaoNivel= '" + _AbreviacaoNivel + "' WHERE CodigoPagamento = " + _CodigoPagamento + "";
        //        c.ExecutarComando(instrucaoSql);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public void Ativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbFormasDePagamento SET StatusPagamento = 1 WHERE CodigoPagamento = " + _CodigoPagamento + "";
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
                instrucaoSql = "UPDATE tbFormasDePagamento SET StatusPagamento = 0 WHERE CodigoPagamento = " + _CodigoPagamento + "";
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
                instrucaoSql = "DELETE FROM tbFormasDePagamento WHERE CodigoPagamento = " + _CodigoPagamento + "";
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
                instrucaoSql = "SELECT * FROM tbFormasDePagamento WHERE CodigoPagamento= " + _CodigoPagamento + "";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNome, byte TipoStatus)
        {
            try
            {
                instrucaoSql = "SELECT CodigoPagamento, DescricaoPagamento, StatusPagamento FROM tbFormasDePagamento";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE nome LIKE '%" + parteNome + "%'";
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
                instrucaoSql = "SELECT CodigoPagamento, DescricaoPagamento, StatusPagamento FROM tbFormasDePagamento WHERE StatusPagamento=1";
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
                instrucaoSql = "SELECT CodigoPagamento, DescricaoPagamento, StatusPagamento FROM tbFormasDePagamento WHERE StatusPagamento=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
