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
    
    public partial class login
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string nivel_acesso { get; set; }
        public Nullable<int> CodigoUsuario { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
    }
}