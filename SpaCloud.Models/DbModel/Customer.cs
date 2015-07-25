using System;
using System.Collections.Generic;
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
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerMobileNo { get; set; }
        public Nullable<System.DateTime> CustomerDOB { get; set; }
        public string CustomerEmailID { get; set; }
        public string CustomerAltMobileNo { get; set; }
        public string CustomerNotes { get; set; }
        public long CustomerCreatedBranchID { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCreatedBy { get; set; }
        public string CustomerIsActive { get; set; }
        public System.DateTime CustomerCreatedDt { get; set; }

        public virtual Company Company { get; set; }
        public virtual LookupCustomerType LookupCustomerType { get; set; }
    }
}
