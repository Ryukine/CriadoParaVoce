using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Nivel
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CodigoNivel;
        private string _NomeNivel;
        private string _AbreviacaoNivel;
        private byte _StatusNivel;

        public int CodigoNivel
        {
            get
            {
                return _CodigoNivel;
            }

            set
            {
                _CodigoNivel = value;
            }
        }

        public string NomeNivel
        {
            get
            {
                return _NomeNivel;
            }

            set
            {
                _NomeNivel = value;
            }
        }

        public string AbreviacaoNivel
        {
            get
            {
                return _AbreviacaoNivel;
            }

            set
            {
                _AbreviacaoNivel = value;
            }
        }

        public byte StatusNivel
        {
            get
            {
                return _StatusNivel;
            }

            set
            {
                _StatusNivel = value;
            }
        }

        private static string instrucaoSql;

        public void CriarNivel()
        {
            try
            {
                _NomeNivel = "ADMINISTRADOR";
                _AbreviacaoNivel = "ADM";
                _StatusNivel = (byte)BLL.FuncoesGerais.NivelDeAcesso.Administrador;
                SqlParameter[] listaComParametros =
                    {
                  new SqlParameter("@NomeNivel",SqlDbType.VarChar) {Value = _NomeNivel },
                  new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel },
                  new SqlParameter("@StatusNivel",SqlDbType.VarChar) {Value = _StatusNivel }
                };
                instrucaoSql = "INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) VALUES (@NomeNivel, @AbreviacaoNivel, @StatusNivel)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
                /*
                listaComParametros.Initialize();
                listaComParametros[0].Value = "SUPERVISOR";
                listaComParametros[1].Value = "SUP";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Supervisor;

                instrucaoSql = "INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) VALUES (@NomeNivel, @AbreviacaoNivel, @StatusNivel)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "USUÁRIO";
                listaComParametros[1].Value = "USR";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Usuario;
                instrucaoSql = "INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) VALUES (@NomeNivel, @AbreviacaoNivel, @StatusNivel)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "ROOT";
                listaComParametros[1].Value = "ROT";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Root;
                instrucaoSql = "INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) VALUES (@NomeNivel, @AbreviacaoNivel, @StatusNivel)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
                */

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
                    new SqlParameter("@NomeNivel",SqlDbType.VarChar) {Value = _NomeNivel },
                    new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel },
                    new SqlParameter("@StatusNivel",SqlDbType.Bit) {Value = _StatusNivel }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                instrucaoSql = "INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) Values (@NomeNivel, @AbreviacaoNivel, @StatusNivel)";
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
                    new SqlParameter("@CodigoNivel",SqlDbType.Int) {Value = _CodigoNivel },
                    new SqlParameter("@NomeNivel",SqlDbType.VarChar) {Value = _NomeNivel },
                    new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel },
                    new SqlParameter("@StatusNivel",SqlDbType.Bit) {Value = _StatusNivel }
                };
                instrucaoSql = "UPDATE tbNivelAcesso SET NomeNivel =@NomeNivel, AbreviacaoNivel=@AbreviacaoNivel, StatusNivel=@StatusNivel";
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
        //            new SqlParameter("@CodigoNivel",SqlDbType.Int) {Value = _CodigoNivel },
        //            new SqlParameter("@AbreviacaoNivel",SqlDbType.VarChar) {Value = _AbreviacaoNivel }
        //        };
        //        instrucaoSql = "UPDATE tbNivelAcesso SET AbreviacaoNivel=@AbreviacaoNivel WHERE CodigoNivel=@CodigoNivel";
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
                instrucaoSql = "INSERT INTO TbUsuario(NomeNivel, AbreviacaoNivel, StatusNivel) Values ('" + _NomeNivel + "', '" + _AbreviacaoNivel + "'," + _StatusNivel + ")";
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
        //        instrucaoSql = "UPDATE tbNivelAcesso Set NomeNivel= '" + _NomeNivel + "', AbreviacaoNivel = '" + _AbreviacaoNivel + "', StatusNivel = " + _StatusNivel + " WHERE CodigoNivel = _CodigoNivel";
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
        //        instrucaoSql = "UPDATE tbNivelAcesso SET AbreviacaoNivel= '" + _AbreviacaoNivel + "' WHERE CodigoNivel = " + _CodigoNivel + "";
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
                instrucaoSql = "UPDATE tbNivelAcesso SET StatusNivel = 1 WHERE CodigoNivel = " + _CodigoNivel + "";
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
                instrucaoSql = "UPDATE tbNivelAcesso SET StatusNivel = 0 WHERE CodigoNivel = " + _CodigoNivel + "";
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
                instrucaoSql = "DELETE FROM tbNivelAcesso WHERE CodigoNivel = " + _CodigoNivel + "";
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
                instrucaoSql = "SELECT * FROM tbNivelAcesso WHERE CodigoNivel= " + _CodigoNivel + "";
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
                instrucaoSql = "SELECT codigoNivel, nomeNivel, StatusNivel FROM tbNivelAcesso";
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
                instrucaoSql = "SELECT CodigoNivel, NomeNivel, StatusNivel FROM tbNivelAcesso WHERE StatusNivel=1";
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
                instrucaoSql = "SELECT CodigoNivel, NomeNivel, StatusNivel FROM tbNivelAcesso WHERE StatusNivel=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
