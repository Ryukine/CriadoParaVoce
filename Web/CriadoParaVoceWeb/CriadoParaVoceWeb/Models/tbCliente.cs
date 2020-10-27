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
    
    public partial class tbCliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCliente()
        {
            this.tbContatoCliente = new HashSet<tbContatoCliente>();
            this.USUARIOWEB = new HashSet<USUARIOWEB>();
            this.tbVenda = new HashSet<tbVenda>();
        }
    
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Sexo { get; set; }
        public string EmailCliente { get; set; }
        public string CpfCliente { get; set; }
        public string Telefone { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string ObsCliente { get; set; }
        public Nullable<bool> StatusCliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbContatoCliente> tbContatoCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIOWEB> USUARIOWEB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbVenda> tbVenda { get; set; }
    }
}