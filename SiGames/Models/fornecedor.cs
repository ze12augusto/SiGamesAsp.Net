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
    
    public partial class fornecedor
    {
        public fornecedor()
        {
            this.produto = new HashSet<produto>();
        }
    
        public int IdPessoa { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        public virtual ICollection<produto> produto { get; set; }
    }
}
