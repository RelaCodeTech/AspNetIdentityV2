//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaCloud.EF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public long OrderID { get; set; }
        public long CompanyID { get; set; }
        public long BranchID { get; set; }
        public long CustomerID { get; set; }
        public System.DateTime OrderDt { get; set; }
        public Nullable<decimal> OrderDiscount { get; set; }
        public Nullable<decimal> OrderGrossAmt { get; set; }
        public Nullable<decimal> OrderNetAmt { get; set; }
        public string OrderCreatedBy { get; set; }
    }
}