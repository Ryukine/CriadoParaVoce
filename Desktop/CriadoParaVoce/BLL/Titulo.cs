using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Titulo
    {
        private int _CodigoTitulo;
        private string _DescricaoTitulo;
        private byte _StatusTitulo;

        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        public string instrucaoSql;

        public int CodigoTitulo
        {
            get
            {
                return _CodigoTitulo;
            }

            set
            {
                _CodigoTitulo = value;
            }
        }

        public string DescricaoTitulo
        {
            get
            {
                return _DescricaoTitulo;
            }

            set
            {
                _DescricaoTitulo = value;
            }
        }

        public byte StatusTitulo
        {
            get
            {
                return _StatusTitulo;
            }

            set
            {
                _StatusTitulo = value;
            }
        }

        /*public int CodigoTitulo { get => _CodigoTitulo; set => _CodigoTitulo = value; }
        public string DescricaoTitulo { get => _DescricaoTitulo; set => _DescricaoTitulo = value.ToUpper(); }
        public byte StatusTitulo { get => _StatusTitulo; set => _StatusTitulo = value; }*/


        public void Incluir()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@DescricaoTitulo",SqlDbType.VarChar) {Value = DescricaoTitulo },
                   new SqlParameter("@StatusTitulo",SqlDbType.Bit) {Value = StatusTitulo }
                };
                instrucaoSql = "INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES (@DescricaoTitulo, @StatusTitulo)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar()
        {
            try
            {
                //pin não é atualizado
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoTitulo",SqlDbType.Int) {Value = CodigoTitulo },
                   new SqlParameter("@DescricaoTitulo",SqlDbType.VarChar) {Value = DescricaoTitulo },
                   new SqlParameter("@StatusTitulo",SqlDbType.Bit) {Value = StatusTitulo }
                };


                instrucaoSql = "UPDATE tbTipoTitulo SET DescricaoTitulo=@DescricaoTitulo, StatusTitulo=@StatusTitulo WHERE CodigoTitulo=@CodigoTitulo";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

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
                SqlParameter[] listaComParametros = {new SqlParameter("@CodigoTitulo",SqlDbType.Int) {Value = CodigoTitulo }
                };
                instrucaoSql = "DELETE FROM tbTipoTitulo WHERE CodigoTitulo=@CodigoTitulo";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarStatus(byte novostatus)
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@CodigoTitulo",SqlDbType.Int) {Value = CodigoTitulo },
                   new SqlParameter("@StatusTitulo",SqlDbType.Bit) {Value = novostatus }
                };
                instrucaoSql = "UPDATE tbTipoTitulo SET StatusTitulo=@StatusTitulo WHERE CodigoTitulo=@CodigoTitulo";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
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
                SqlParameter[] listaComParametros = {new SqlParameter("@CodigoTitulo",SqlDbType.Int) {Value = CodigoTitulo }
                };
                instrucaoSql = "SELECT * FROM tbTipoTitulo WHERE CodigoTitulo=" + CodigoTitulo;
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
                instrucaoSql = "SELECT CodigoTitulo, DescricaoTitulo FROM tbTipoTitulo ";
                if (parteNome.Trim().Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE DescricaoTitulo LIKE '%" + parteNome + "%' ";
                }
                if (tipostatus != 2)
                {
                    if (parteNome.Trim().Length == 0)
                    {
                        instrucaoSql = instrucaoSql + " WHERE StatusTitulo = " + tipostatus;
                    }
                    else
                    {
                        instrucaoSql = instrucaoSql + " AND   StatusTitulo = " + tipostatus;
                    }
                }
                instrucaoSql = instrucaoSql + " ORDER BY DescricaoTitulo";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







    }
}
