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
    
    public partial class tbProduto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbProduto()
        {
            this.tbItem_Venda = new HashSet<tbItem_Venda>();
            this.tbProdutoFinal = new HashSet<tbProdutoFinal>();
        }
    
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public Nullable<bool> StatusProduto { get; set; }
        public Nullable<decimal> PrecoProduto { get; set; }
        public Nullable<int> FornecedorID { get; set; }
        public string FotoDoProduto { get; set; }
    
        public virtual tbCategoria tbCategoria { get; set; }
        public virtual tbFornecedor tbFornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbItem_Venda> tbItem_Venda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProdutoFinal> tbProdutoFinal { get; set; }
    }
}