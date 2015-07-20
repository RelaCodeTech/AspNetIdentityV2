using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentityV2.Models.ViewModels
{
    public class Company
    {
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebSite { get; set; }
        public string CompanyDetails { get; set; }
        public string CompanyDesc { get; set; }
    }
}