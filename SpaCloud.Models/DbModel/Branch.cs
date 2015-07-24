using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Branch
    {
        public Int64 BranchID { get; set; }
        public Int64 CompanyID { get; set; }
        public string BranchRegion { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchHotelName { get; set; }
        public string BranchSpaName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }
        public string BranchState { get; set; }
        public string BranchCountry { get; set; }
        public string BranchContactNo { get; set; }
        public string BranchComment { get; set; }
        public string BranchIsActive { get; set; }
        public string BranchCreatedBy { get; set; }
        public DateTime? BranchCreatedDt { get; set; }
    }
}
