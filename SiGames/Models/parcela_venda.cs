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
    
    public partial class parcela_venda
    {
        public Nullable<System.DateTime> DataBaixa { get; set; }
        public short ParcelaIdParcela { get; set; }
        public System.DateTime DataVencimento { get; set; }
        public int VendaIdVenda { get; set; }
    
        public virtual parcela parcela { get; set; }
        public virtual venda venda { get; set; }
    }
}
