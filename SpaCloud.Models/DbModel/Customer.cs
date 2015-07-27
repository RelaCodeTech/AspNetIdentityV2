using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public long CompanyID { get; set; }
        public int CustomerTypeID { get; set; }

        [Display(Name="First name")]
        public string CustomerFname { get; set; }

        [Display(Name = "Last name")]
        public string CustomerLname { get; set; }

        [Display(Name = "Gender")]
        public string CustomerGender { get; set; }

        [Display(Name = "Mobile no")]
        public string CustomerMobileNo { get; set; }

        [Display(Name = "DOB")]
        public Nullable<System.DateTime> CustomerDOB { get; set; }


        [Display(Name = "Email ID")]
        public string CustomerEmailID { get; set; }

        [Display(Name = "Alt Mobile no")]
        public string CustomerAltMobileNo { get; set; }

        [Display(Name = "Notes")]
        public string CustomerNotes { get; set; }
        public long CustomerCreatedBranchID { get; set; }

        [Display(Name = "Country")]
        public string CustomerCountry { get; set; }
        public string CustomerCreatedBy { get; set; }
        public string CustomerIsActive { get; set; }
        public System.DateTime CustomerCreatedDt { get; set; }

        public virtual Company Company { get; set; }
        public virtual LookupCustomerType LookupCustomerType { get; set; }
    }
}
