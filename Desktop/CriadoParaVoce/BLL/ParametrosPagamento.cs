using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
   public class ParametrosPagamento
    {
        /*
         NumeroMinimoParcelasSemJurosCarnet         INT,
    NumeroMaximoParcelasCarne                 INT,
    TaxaJurosParcelasCarnet                    DECIMAL(5,3),
    ValorParcelaMinimaCarnet                   DECIMAL(7,3),
     StatusParametroPagamento                   BIT,
       CodigoParametroPagamento                   INT   

            []       ,[]       ,[]       ,[]       ,[]

    */

        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoParametroPagamento;
        private byte _StatusParametroPagamento;
        private double _ValorParcelaMinimaCarnet;
        private double _TaxaJurosParcelasCarnet;
        private int _NumeroMaximoParcelasCarnet;
        private int _NumeroMinimoParcelasSemJurosCarnet;
        private int _NumeroParcelasCartaoCreditoSemJuros;
        private int _NumeroMaximoParcelasCartaoCredito;
        private double _TaxaJurosParcelasCartaoCredito;
        private double _ValorParcelaMinimaPagamentoCartaoCredito;
        private DateTime _DataAtualizacaoParametrosPagamento;

        public int CodigoParametroPagamento
        {
            get
            {
                return _CodigoParametroPagamento;
            }

            set
            {
                _CodigoParametroPagamento = value;
            }
        }

        public byte StatusParametroPagamento
        {
            get
            {
                return _StatusParametroPagamento;
            }

            set
            {
                _StatusParametroPagamento = value;
            }
        }

        public double ValorParcelaMinimaCarnet
        {
            get
            {
                return _ValorParcelaMinimaCarnet;
            }

            set
            {
                _ValorParcelaMinimaCarnet = value;
            }
        }

        public double TaxaJurosParcelasCarnet
        {
            get
            {
                return _TaxaJurosParcelasCarnet;
            }

            set
            {
                _TaxaJurosParcelasCarnet = value;
            }
        }

        public int NumeroMaximoParcelasCarnet
        {
            get
            {
                return _NumeroMaximoParcelasCarnet;
            }

            set
            {
                _NumeroMaximoParcelasCarnet = value;
            }
        }

        public int NumeroMinimoParcelasSemJurosCarnet
        {
            get
            {
                return _NumeroMinimoParcelasSemJurosCarnet;
            }

            set
            {
                _NumeroMinimoParcelasSemJurosCarnet = value;
            }
        }

        public int NumeroParcelasCartaoCreditoSemJuros
        {
            get
            {
                return _NumeroParcelasCartaoCreditoSemJuros;
            }

            set
            {
                _NumeroParcelasCartaoCreditoSemJuros = value;
            }
        }

        public int NumeroMaximoParcelasCartaoCredito
        {
            get
            {
                return _NumeroMaximoParcelasCartaoCredito;
            }

            set
            {
                _NumeroMaximoParcelasCartaoCredito = value;
            }
        }

        public double TaxaJurosParcelasCartaoCredito
        {
            get
            {
                return _TaxaJurosParcelasCartaoCredito;
            }

            set
            {
                _TaxaJurosParcelasCartaoCredito = value;
            }
        }

        public double ValorParcelaMinimaPagamentoCartaoCredito
        {
            get
            {
                return _ValorParcelaMinimaPagamentoCartaoCredito;
            }

            set
            {
                _ValorParcelaMinimaPagamentoCartaoCredito = value;
            }
        }

        public DateTime DataAtualizacaoParametrosPagamento
        {
            get
            {
                return _DataAtualizacaoParametrosPagamento;
            }

            set
            {
                _DataAtualizacaoParametrosPagamento = value;
            }
        }



        //public int CodigoParametroPagamento { get => _CodigoParametroPagamento; set => _CodigoParametroPagamento = value; }
        //public byte StatusParametroPagamento { get => _StatusParametroPagamento; set => _StatusParametroPagamento = value; }
        //public double ValorParcelaMinimaCarnet { get => _ValorParcelaMinimaCarnet; set => _ValorParcelaMinimaCarnet = value; }
        //public double TaxaJurosParcelasCarnet { get => _TaxaJurosParcelasCarnet; set => _TaxaJurosParcelasCarnet = value; }
        //public int NumeroMaximoParcelasCarnet { get => _NumeroMaximoParcelasCarnet; set => _NumeroMaximoParcelasCarnet = value; }
        //public int NumeroMinimoParcelasSemJurosCarnet { get => _NumeroMinimoParcelasSemJurosCarnet; set => _NumeroMinimoParcelasSemJurosCarnet = value; }
        //public int NumeroParcelasCartaoCreditoSemJuros { get => _NumeroParcelasCartaoCreditoSemJuros; set => _NumeroParcelasCartaoCreditoSemJuros = value; }
        //public int NumeroMaximoParcelasCartaoCredito { get => _NumeroMaximoParcelasCartaoCredito; set => _NumeroMaximoParcelasCartaoCredito = value; }
        //public double TaxaJurosParcelasCartaoCredito { get => _TaxaJurosParcelasCartaoCredito; set => _TaxaJurosParcelasCartaoCredito = value; }
        //public double ValorParcelaMinimaPagamentoCartaoCredito { get => _ValorParcelaMinimaPagamentoCartaoCredito; set => _ValorParcelaMinimaPagamentoCartaoCredito = value; }
        //public DateTime DataAtualizacaoParametrosPagamento { get => _DataAtualizacaoParametrosPagamento; set => _DataAtualizacaoParametrosPagamento = value; }

        public SqlDataReader Consultar()
        {
            try
            {
                instrucaoSql = "SELECT  [CodigoParametroPagamento]       ,[NumeroMinimoParcelasSemJurosCarnet]       ,[NumeroMaximoParcelasCarnet]       ,[TaxaJurosParcelasCarnet]       ,[ValorParcelaMinimaCarnet]       ,[NumeroParcelasCartaoCreditoSemJuros]       ,[NumeroMaximoParcelasCartaoCredito]       ,[TaxaJurosParcelasCartaoCredito]       ,[ValorParcelaMinimaPagamentoCartaoCredito]       ,[DataAtualizacaoParametrosPagamento]       ,[StatusParametroPagamento]         FROM[PROJETO].[dbo].[tbParametrosPagamento]         where CodigoParametroPagamento = " + CodigoParametroPagamento + " AND StatusParametroPagamento = "+ StatusParametroPagamento;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
