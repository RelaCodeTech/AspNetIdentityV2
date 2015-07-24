using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaCloud.Models.DbModel
{
    public class Company
    {
        public Int64 CompanyID { get; set; }

        [Required]
        [Display(Name="Name")]
        public string CompanyName { get; set; }

        [Display(Name = "E mail")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Website")]
        public string CompanyWebSite { get; set; }

        [Display(Name = "Details")]
        public string CompanyDetails { get; set; }

        [Display(Name = "Description")]
        public string CompanyDesc { get; set; }
    }
}