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
    
    public partial class Tax
    {
        public int TaxID { get; set; }
        public long CompanyID { get; set; }
        public long BranchID { get; set; }
        public string TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public string TaxDesc { get; set; }
    }
}
