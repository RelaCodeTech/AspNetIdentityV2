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
    
    public partial class LookupCustomerType
    {
        public LookupCustomerType()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int CustomerTypeID { get; set; }
        public string CustomerType { get; set; }
        public string CustomerTypeDesc { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
