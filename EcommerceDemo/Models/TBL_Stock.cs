//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Stock
    {
        public long ID { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<long> OutStock { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}