using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class LookupEmployeeType
    {
        public Int64 EmpID { get; set; }
        public string EmpType { get; set; }
        public string TypeDesc { get; set; }
    }
}
