//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CriadoParaVoceWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbParametrosPagamento
    {
        public int CodigoParametroPagamento { get; set; }
        public Nullable<int> NumeroMinimoParcelasSemJurosCarnet { get; set; }
        public Nullable<int> NumeroMaximoParcelasCarnet { get; set; }
        public Nullable<decimal> TaxaJurosParcelasCarnet { get; set; }
        public Nullable<decimal> ValorParcelaMinimaCarnet { get; set; }
        public Nullable<int> NumeroParcelasCartaoCreditoSemJuros { get; set; }
        public Nullable<int> NumeroMaximoParcelasCartaoCredito { get; set; }
        public Nullable<decimal> TaxaJurosParcelasCartaoCredito { get; set; }
        public Nullable<decimal> ValorParcelaMinimaPagamentoCartaoCredito { get; set; }
        public Nullable<System.DateTime> DataAtualizacaoParametrosPagamento { get; set; }
        public Nullable<bool> StatusParametroPagamento { get; set; }
    }
}