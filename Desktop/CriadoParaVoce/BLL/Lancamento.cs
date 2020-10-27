using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BLL
{
    public class Lancamento
    {
        
        private int _CodigoLancamento;
        private int _CodigoTitulo;
        private SqlDateTime _DataVencimento;
        private double _ValorTitulo;
        private byte _StatusPagTitulo;
        private SqlDateTime _DataPagamento;
        private double _ValorPagamento;
        private int _CodigoUsuario;



        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        public string instrucaoSql;

        public int CodigoLancamento
        {
            get
            {
                return _CodigoLancamento;
            }

            set
            {
                _CodigoLancamento = value;
            }
        }

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

        public SqlDateTime DataVencimento
        {
            get
            {
                return _DataVencimento;
            }

            set
            {
                _DataVencimento = value;
            }
        }

        public double ValorTitulo
        {
            get
            {
                return _ValorTitulo;
            }

            set
            {
                _ValorTitulo = value;
            }
        }

        public byte StatusPagTitulo
        {
            get
            {
                return _StatusPagTitulo;
            }

            set
            {
                _StatusPagTitulo = value;
            }
        }

        public SqlDateTime DataPagamento
        {
            get
            {
                return _DataPagamento;
            }

            set
            {
                _DataPagamento = value;
            }
        }

        public double ValorPagamento
        {
            get
            {
                return _ValorPagamento;
            }

            set
            {
                _ValorPagamento = value;
            }
        }

        public int CodigoUsuario
        {
            get
            {
                return _CodigoUsuario;
            }

            set
            {
                _CodigoUsuario = value;
            }
        }

        /*public int CodigoLancamento { get => _CodigoLancamento; set => _CodigoLancamento = value; }
        public int CodigoTitulo { get => _CodigoTitulo; set => _CodigoTitulo = value; }
        public SqlDateTime DataVencimento { get => _DataVencimento; set => _DataVencimento = value; }
        public double ValorTitulo { get => _ValorTitulo; set => _ValorTitulo = value; }
        public byte StatusPagTitulo { get => _StatusPagTitulo; set => _StatusPagTitulo = value; }
        public SqlDateTime DataPagamento { get => _DataPagamento; set => _DataPagamento = value; }
        public double ValorPagamento { get => _ValorPagamento; set => _ValorPagamento = value; }
        public int CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }*/

        public void Incluir()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                    new SqlParameter("@codtit", SqlDbType.Int) {Value=CodigoTitulo},
                    new SqlParameter("@datavenc", SqlDbType.DateTime){Value =DataVencimento},
                    new SqlParameter("@valortitulo", SqlDbType.Decimal) {Value=ValorTitulo},
                    new SqlParameter("@codusu", SqlDbType.Int) {Value=CodigoUsuario}

                };
                instrucaoSql = "INSERT INTO tbLancamento (CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, CodigoUsuario) VALUES (@codtit, @datavenc, @valortitulo, 0, @codusu)";
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
                    SqlParameter[] listaComParametros = {
                    new SqlParameter("@codlanc", SqlDbType.Int){Value =CodigoLancamento},
                    new SqlParameter("@codtit", SqlDbType.Int) {Value=CodigoTitulo},
                    new SqlParameter("@datavenc", SqlDbType.DateTime){Value =DataVencimento},
                    new SqlParameter("@valortitulo", SqlDbType.Decimal) {Value=ValorTitulo},
                    new SqlParameter("@status", SqlDbType.Bit){Value =StatusPagTitulo},
                    new SqlParameter("@datapag", SqlDbType.DateTime) {Value=DataPagamento},
                    new SqlParameter("@valorpag", SqlDbType.Decimal){Value =ValorPagamento},
                    new SqlParameter("@codigousuario", SqlDbType.Int) {Value=CodigoUsuario}
                };

                instrucaoSql = "UPDATE tbLancamento SET CodigoTitulo=@codtit, DataVencimento=@datavenc, ValorTitulo=@valortitulo, StatusPagTitulo=@status, DataPagamento=@datapag, ValorPagamento=@valorpag, CodigoUsuario=@codigousuario WHERE CodigoLancamento=@codlanc";
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
                SqlParameter[] listaComParametros = {new SqlParameter("@CodigoLancamento",SqlDbType.Int) {Value = CodigoLancamento }
                };
                instrucaoSql = "DELETE FROM tblancamento WHERE CodigoLancamento=@CodigoLancamento AND StatusPagTitulo=0";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Pagar()
        {
            try
            {
                //pin não é atualizado
                SqlParameter[] listaComParametros = {
                    new SqlParameter("@codlanc", SqlDbType.Int){Value =CodigoLancamento},
                    new SqlParameter("@codtit", SqlDbType.Int) {Value=CodigoTitulo},
                    new SqlParameter("@datavenc", SqlDbType.DateTime){Value =DataVencimento},
                    new SqlParameter("@valortitulo", SqlDbType.Decimal) {Value=ValorTitulo},

                    new SqlParameter("@status", SqlDbType.Bit){Value =1},
                    new SqlParameter("@datapag", SqlDbType.DateTime) {Value=DataPagamento},
                    new SqlParameter("@valorpag", SqlDbType.Decimal){Value =ValorPagamento},
                    new SqlParameter("@codigousuario", SqlDbType.Int) {Value=CodigoUsuario}

                };


                instrucaoSql = "UPDATE tbLancamento SET CodigoTitulo=@codtit, DataVencimento=@datavenc, ValorTitulo=@valortitulo, StatusPagTitulo=@status, DataPagamento=@datapag, ValorPagamento=@valorpag, CodigoUsuario=@codigousuario WHERE CodigoLancamento=@codlanc";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarPagamento()
        {
            try
            {
                //pin não é atualizado
                SqlParameter[] listaComParametros = {
                    new SqlParameter("@codlanc", SqlDbType.Int){Value =CodigoLancamento},
                    new SqlParameter("@codtit", SqlDbType.Int) {Value=CodigoTitulo},
                    new SqlParameter("@datavenc", SqlDbType.DateTime){Value =DataVencimento},
                    new SqlParameter("@valortitulo", SqlDbType.Decimal) {Value=ValorTitulo},

                    new SqlParameter("@status", SqlDbType.Bit){Value =0},
                    new SqlParameter("@datapag", SqlDbType.DateTime) {Value= DBNull.Value },
                    new SqlParameter("@valorpag", SqlDbType.Decimal){Value = 0 },
                    new SqlParameter("@codigousuario", SqlDbType.Int) {Value= 0 }

                };


                instrucaoSql = "UPDATE tbLancamento SET CodigoTitulo=@codtit, DataVencimento=@datavenc, ValorTitulo=@valortitulo, StatusPagTitulo=@status, DataPagamento=@datapag, ValorPagamento=@valorpag, CodigoUsuario=@codigousuario WHERE CodigoLancamento=@codlanc";
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
                instrucaoSql = "SELECT * FROM tbLancamento WHERE CodigoLancamento=" + CodigoLancamento;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ValorContas(byte tipostatus, DateTime datainicial, DateTime datafinal)
        {
            try
            {
                instrucaoSql = "SELECT sum(ValorTitulo) from tblancamento WHERE StatusPagTitulo="+tipostatus+" AND (DataVencimento BETWEEN '" + datainicial + "' and '" + datafinal + "')";
                return c.RetornarTotal(instrucaoSql);



                //SqlDataReader ddr;
                //ddr=c.RetornarDataReader(instrucaoSql);
                //ddr.Read();
                //if (ddr.HasRows)
                //{
                //    return Convert.ToDouble(ddr[0].ToString());
                //}
                //else
                //{
                //    return 0;
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet ListarContas(byte tipostatus, DateTime datainicial, DateTime datafinal)
        {
            try
            {
                if (tipostatus == 0) //não pagas
                {
                    instrucaoSql = "SELECT l.DataVencimento, t.DescricaoTitulo,  l.ValorTitulo, l.StatusPagTitulo, l.DataPagamento, l.ValorPagamento, l.Codigotitulo, l.CodigoLancamento FROM tbTipoTitulo as t INNER JOIN tbLancamento as l ON t.CodigoTitulo=l.CodigoTitulo WHERE l.StatusPagTitulo = 0 AND (DataVencimento BETWEEN '" + datainicial + "' and '" + datafinal + "') ORDER by l.DataVencimento, t.DescricaoTitulo";

                }
                else if(tipostatus == 1) //pagas
                {
                    instrucaoSql = "SELECT l.DataVencimento, t.DescricaoTitulo,  l.ValorTitulo, l.StatusPagTitulo, l.DataPagamento, l.ValorPagamento, l.Codigotitulo,  l.CodigoLancamento FROM tbTipoTitulo as t INNER JOIN tbLancamento as l ON t.CodigoTitulo=l.CodigoTitulo WHERE l.StatusPagTitulo = 1 AND (DataVencimento BETWEEN '" + datainicial + "' and '" + datafinal + "') ORDER by l.DataVencimento, t.DescricaoTitulo";

                }
                else //tudo
                {
                    instrucaoSql = "SELECT l.DataVencimento, t.DescricaoTitulo,  l.ValorTitulo, l.StatusPagTitulo, l.DataPagamento, l.ValorPagamento, l.Codigotitulo,  l.CodigoLancamento FROM tbTipoTitulo as t INNER JOIN tbLancamento as l ON t.CodigoTitulo=l.CodigoTitulo WHERE (DataVencimento BETWEEN '" + datainicial + "' and '" + datafinal + "') ORDER by l.DataVencimento, t.DescricaoTitulo";
                }

                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarTitulosEmAberto(int codigoTipoTitulo)
        {
            try
            {
                instrucaoSql = "SELECT DataVencimento, ValorTitulo from tbLancamento where codigotitulo = "+codigoTipoTitulo+" and StatusPagTitulo = 0 ORDER by DataVencimento";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public SqlDataReader ObterTituloEmAberto(SqlDateTime DataLimite)
        {
            try
            {
                instrucaoSql = "SELECT Count(DataVencimento) As Qtde, Sum(ValorTitulo) As ValorTotal, Min(DataVencimento) As PrimeiraData from tbLancamento where StatusPagTitulo = 0 AND dataVencimento > '" + DataLimite+"'";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
