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
    
    public partial class Company
    {
        public Company()
        {
            this.Branches = new HashSet<Branch>();
            this.Customers = new HashSet<Customer>();
        }
    
        public long CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebSite { get; set; }
        public string CompanyDetails { get; set; }
        public string CompanyDesc { get; set; }
    
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
