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
    
    public partial class cliente
    {
        public cliente()
        {
            this.venda = new HashSet<venda>();
        }
    
        public int IdPessoa { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        public virtual ICollection<venda> venda { get; set; }
    }
}
