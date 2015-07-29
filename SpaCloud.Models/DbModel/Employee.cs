using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Employee
    {
        public Int64 EmpID { get; set; }
        public Int64 CompanyID { get; set; }
        public Int64 BaseBranchID { get; set; }
        public string EmpCode { get; set; }
        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public string EmpGender { get; set; }
        public int EmpTypeID { get; set; }
        public char IsOnPayRoll { get; set; }
        public string EmpContactNo { get; set; }
        public char IsActive { get; set; }
        public DateTime EmpCreatedDt { get; set; }
        public string EmpCreatedBy { get; set; }

        //public LookupEmployeeType LookupEmployeeType { get; set; }
    }
}
