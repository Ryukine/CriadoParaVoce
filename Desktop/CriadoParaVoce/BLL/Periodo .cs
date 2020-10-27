using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Periodo
    {
        public string instrucaoSql;
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        /// <summary>
        /// CodigoPeriodo    int IDENTITY primary KEY Not null,
        /// DescricaoPeriodo       VARCHAR(50),
        /// ValorPeriodo VARCHAR(3),
        /// StatusPeriodo     int
        /// </summary>

        private int _CodigoPeriodo;
        private string _DescricaoPeriodo;
        private int _ValorPeriodo;
        private byte _StatusPeriodo;
        private string _SinalPeriodo;

        public int CodigoPeriodo
        {
            get
            {
                return _CodigoPeriodo;
            }

            set
            {
                _CodigoPeriodo = value;
            }
        }

        public string DescricaoPeriodo
        {
            get
            {
                return _DescricaoPeriodo;
            }

            set
            {
                _DescricaoPeriodo = value;
            }
        }

        public int ValorPeriodo
        {
            get
            {
                return _ValorPeriodo;
            }

            set
            {
                _ValorPeriodo = value;
            }
        }

        public byte StatusPeriodo
        {
            get
            {
                return _StatusPeriodo;
            }

            set
            {
                _StatusPeriodo = value;
            }
        }

        public string SinalPeriodo
        {
            get
            {
                return _SinalPeriodo;
            }

            set
            {
                _SinalPeriodo = value;
            }
        }

        /*public int CodigoPeriodo { get => _CodigoPeriodo; set => _CodigoPeriodo = value; }
        public string DescricaoPeriodo { get => _DescricaoPeriodo; set => _DescricaoPeriodo = value.Trim().ToUpper();
        }
        public int ValorPeriodo {
            get => _ValorPeriodo;
            set => _ValorPeriodo = value;

            //get { return _ValorPeriodo; }
            //set {
            //    _ValorPeriodo = value;
            //    if (_SinalPeriodo=="-")
            //    {
            //        _ValorPeriodo = value * -1;
            //    }
            //}


        }
        public byte StatusPeriodo { get => _StatusPeriodo; set => _StatusPeriodo = value; }
        public string SinalPeriodo { get => _SinalPeriodo; set => _SinalPeriodo = value; }*/

        public void Incluir()
        {
            try
            {
                if (SinalPeriodo=="-")
                {
                    ValorPeriodo = ValorPeriodo * -1;
                }

                SqlParameter[] listaComParametros =
                    {
                  new SqlParameter("@DescricaoPeriodo",SqlDbType.VarChar) {Value = DescricaoPeriodo },
                   new SqlParameter("@SinalPeriodo",SqlDbType.VarChar) {Value = SinalPeriodo },
                  new SqlParameter("@ValorPeriodo",SqlDbType.Int) {Value = ValorPeriodo },
                  new SqlParameter("@StatusPeriodo",SqlDbType.Bit) {Value = StatusPeriodo }
                };
                instrucaoSql = "INSERT INTO tbPeriodo (DescricaoPeriodo, ValorPeriodo, StatusPeriodo, SinalPeriodo) VALUES (@DescricaoPeriodo, @ValorPeriodo, @StatusPeriodo, @SinalPeriodo)";
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
                SqlParameter[] listaComParametros =
                    {
                    new SqlParameter("@CodigoPeriodo",SqlDbType.Int) {Value = CodigoPeriodo },
                  new SqlParameter("@DescricaoPeriodo",SqlDbType.VarChar) {Value = DescricaoPeriodo },
                     new SqlParameter("@SinalPeriodo",SqlDbType.VarChar) {Value = SinalPeriodo },
                  new SqlParameter("@ValorPeriodo",SqlDbType.Int) {Value = ValorPeriodo },
                  new SqlParameter("@StatusPeriodo",SqlDbType.VarChar) {Value = StatusPeriodo }
                };
                instrucaoSql = "UPDATE tbPeriodo SET DescricaoPeriodo=@DescricaoPeriodo, ValorPeriodo=@ValorPeriodo, StatusPeriodo=@StatusPeriodo, SinalPeriodo=@SinalPeriodo WHERE CodigoPeriodo=@CodigoPeriodo";
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
                SqlParameter[] listaComParametros =
                    {
                    new SqlParameter("@CodigoPeriodo",SqlDbType.Int) {Value = CodigoPeriodo }
                };
                instrucaoSql = "DELETE FROM tbPeriodo WHERE CodigoPeriodo=@CodigoPeriodo";
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
                SqlParameter[] listaComParametros =
                    {
                    new SqlParameter("@CodigoPeriodo",SqlDbType.Int) {Value = CodigoPeriodo }, 
                    new SqlParameter("@StatusPeriodo",SqlDbType.Bit) {Value = novostatus }
                };
                instrucaoSql = "UPDATE tbPeriodo SET StatusPeriodo=@StatusPeriodo WHERE CodigoPeriodo=@CodigoPeriodo";
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
                instrucaoSql = "SELECT * FROM tbPeriodo WHERE CodigoPeriodo=" + CodigoPeriodo;
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
                instrucaoSql = "SELECT CodigoPeriodo,  DescricaoPeriodo, SinalPeriodo, ValorPeriodo FROM tbPeriodo ";
                if (parteNome.Trim().Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE DescricaoPeriodo LIKE '%" + parteNome + "%' ";
                }
                if (tipostatus != 2)
                {
                    if (parteNome.Trim().Length == 0)
                    {
                        instrucaoSql = instrucaoSql + " WHERE StatusPeriodo = " + tipostatus;
                    }
                    else
                    {
                        instrucaoSql = instrucaoSql + " AND StatusPeriodo = " + tipostatus;
                    }
                }
                instrucaoSql = instrucaoSql + " ORDER BY DescricaoPeriodo";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
