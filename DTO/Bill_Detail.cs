//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3CodeDemo.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill_Detail
    {
        public int ID { get; set; }
        public Nullable<int> ID_Bill { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> Flag { get; set; }
        public Nullable<bool> Flag_Merge { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
