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
    
    public partial class GiftCert
    {
        public long GiftCertID { get; set; }
        public long CompanyID { get; set; }
        public long IssuedAtBranchID { get; set; }
        public string GiftCertCode { get; set; }
        public string GiftCertDesc { get; set; }
        public Nullable<System.DateTime> GiftCertStartDt { get; set; }
        public Nullable<System.DateTime> GiftCertEndDt { get; set; }
        public string IsGiftCertActive { get; set; }
        public Nullable<decimal> GiftCertAmount { get; set; }
        public string CreatedBy { get; set; }
    }
}