//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiGames.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pessoa
    {
        public pessoa()
        {
            this.documento = new HashSet<documento>();
            this.endereco = new HashSet<endereco>();
            this.telefone = new HashSet<telefone>();
        }
    
        public int IdPessoa { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual ICollection<documento> documento { get; set; }
        public virtual ICollection<endereco> endereco { get; set; }
        public virtual fornecedor fornecedor { get; set; }
        public virtual ICollection<telefone> telefone { get; set; }
    }
}