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
    
    public partial class CustomerMembership
    {
        public long CustomerMembershipID { get; set; }
        public long CustomerID { get; set; }
        public long CreatedAtBranchID { get; set; }
        public long MembershipID { get; set; }
        public string IsMembershipActive { get; set; }
        public System.DateTime MembershipStartDt { get; set; }
        public string CreatedBy { get; set; }
    }
}