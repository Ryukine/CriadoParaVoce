using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Gastos
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CodigoGastos;
        private string _DescricaoGastos;
        private double _ValorGasto;
        private byte _StatusGasto;
        private int _CodigoFunc;

        public int CodigoGastos
        {
            get
            {
                return _CodigoGastos;
            }

            set
            {
                _CodigoGastos = value;
            }
        }

        public string DescricaoGastos
        {
            get
            {
                return _DescricaoGastos;
            }

            set
            {
                _DescricaoGastos = value;
            }
        }

        public double ValorGasto
        {
            get
            {
                return _ValorGasto;
            }

            set
            {
                _ValorGasto = value;
            }
        }

        public byte StatusGasto
        {
            get
            {
                return _StatusGasto;
            }

            set
            {
                _StatusGasto = value;
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

        private static string instrucaoSql;

        /*public void CriarNivel()
        {
            try
            {
                _DescricaoGastos = "ADMINISTRADOR";
                _ValorGasto = "ADM";
                _StatusGasto = (byte)BLL.FuncoesGerais.NivelDeAcesso.Administrador;
                SqlParameter[] listaComParametros =
                    {
                  new SqlParameter("@DescricaoGastos",SqlDbType.VarChar) {Value = _DescricaoGastos },
                  new SqlParameter("@ValorGasto",SqlDbType.VarChar) {Value = _ValorGasto },
                  new SqlParameter("@StatusGasto",SqlDbType.VarChar) {Value = _StatusGasto }
                };
                instrucaoSql = "INSERT INTO tbGastos (DescricaoGastos, ValorGasto, StatusGasto) VALUES (@DescricaoGastos, @ValorGasto, @StatusGasto)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
                /*
                listaComParametros.Initialize();
                listaComParametros[0].Value = "SUPERVISOR";
                listaComParametros[1].Value = "SUP";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Supervisor;

                instrucaoSql = "INSERT INTO tbGastos (DescricaoGastos, ValorGasto, StatusGasto) VALUES (@DescricaoGastos, @ValorGasto, @StatusGasto)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "USUÁRIO";
                listaComParametros[1].Value = "USR";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Usuario;
                instrucaoSql = "INSERT INTO tbGastos (DescricaoGastos, ValorGasto, StatusGasto) VALUES (@DescricaoGastos, @ValorGasto, @StatusGasto)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                listaComParametros[0].Value = "ROOT";
                listaComParametros[1].Value = "ROT";
                listaComParametros[2].Value = (byte)Negocio.FuncoesGerais.NivelDeAcesso.Root;
                instrucaoSql = "INSERT INTO tbGastos (DescricaoGastos, ValorGasto, StatusGasto) VALUES (@DescricaoGastos, @ValorGasto, @StatusGasto)";
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
                    new SqlParameter("@DescricaoGastos",SqlDbType.VarChar) {Value = _DescricaoGastos },
                    new SqlParameter("@ValorGasto",SqlDbType.Decimal) {Value = _ValorGasto },
                    new SqlParameter("@StatusGasto",SqlDbType.Bit) {Value = _StatusGasto },
                    new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                instrucaoSql = "INSERT INTO tbGastos (DescricaoGastos, ValorGasto, StatusGasto, CodigoFunc) Values (@DescricaoGastos, @ValorGasto, @StatusGasto, @CodigoFunc)";
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
                    new SqlParameter("@CodigoGastos",SqlDbType.Int) {Value = _CodigoGastos },
                    new SqlParameter("@DescricaoGastos",SqlDbType.VarChar) {Value = _DescricaoGastos },
                    new SqlParameter("@ValorGasto",SqlDbType.VarChar) {Value = _ValorGasto },
                    new SqlParameter("@StatusGasto",SqlDbType.Bit) {Value = _StatusGasto },
                    new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc }
                };
                instrucaoSql = "UPDATE tbGastos SET DescricaoGastos=@DescricaoGastos, ValorGasto=@ValorGasto, StatusGasto=@StatusGasto, CodigoFunc=@CodigoFunc WHERE CodigoGastos=@CodigoGastos";
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
        //            new SqlParameter("@CodigoGastos",SqlDbType.Int) {Value = _CodigoGastos },
        //            new SqlParameter("@ValorGasto",SqlDbType.VarChar) {Value = _ValorGasto }
        //        };
        //        instrucaoSql = "UPDATE tbGastos SET ValorGasto=@ValorGasto WHERE CodigoGastos=@CodigoGastos";
        //        c.ExecutarComandoParametro(instrucaoSql, listaComParametro);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        /*public int IncluirRetornarNumeroAutomatico()
        {
            try
            {
                instrucaoSql = "INSERT INTO TbUsuario(DescricaoGastos, ValorGasto, StatusGasto) Values ('" + _DescricaoGastos + "', '" + _ValorGasto + "'," + _StatusGasto + ")";
                return c.RecuperarUltimoCodigoNumeracaoAutomatica(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/

        //public void Alterar()
        //{
        //    try
        //    {
        //        instrucaoSql = "UPDATE tbGastos Set DescricaoGastos= '" + _DescricaoGastos + "', ValorGasto = '" + _ValorGasto + "', StatusGasto = " + _StatusGasto + " WHERE CodigoGastos = _CodigoGastos";
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
        //        instrucaoSql = "UPDATE tbGastos SET ValorGasto= '" + _ValorGasto + "' WHERE CodigoGastos = " + _CodigoGastos + "";
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
                instrucaoSql = "UPDATE tbGastos SET StatusGasto = 1 WHERE CodigoGastos = " + _CodigoGastos + "";
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
                instrucaoSql = "UPDATE tbGastos SET StatusGasto = 0 WHERE CodigoGastos = " + _CodigoGastos + "";
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
                instrucaoSql = "DELETE FROM tbGastos WHERE CodigoGastos = " + _CodigoGastos + "";
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
                instrucaoSql = "SELECT * FROM tbGastos WHERE CodigoGastos= " + _CodigoGastos + "";
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
                instrucaoSql = "SELECT CodigoGastos, DescricaoGastos, StatusGasto FROM tbGastos";
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

        public DataSet Listar1()
        {
            try
            {
                instrucaoSql = "SELECT CodigoGastos, DescricaoGastos, ValorGasto, StatusGasto, CodigoFunc FROM tbGastos";
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
                instrucaoSql = "SELECT CodigoGastos, DescricaoGastos, StatusGasto FROM tbGastos WHERE StatusGasto=1";
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
                instrucaoSql = "SELECT CodigoGastos, DescricaoGastos, StatusGasto FROM tbGastos WHERE StatusGasto=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
