using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class XrefServiceTreatment
    {
        public long ServiceTreatmentXrefID { get; set; }
        public long ServiceID { get; set; }
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }

        public virtual Service Service { get; set; }
        public virtual Treatment Treatment { get; set; }

        //public IList<Service> Services { get; set; }
        //public IList<Treatment> Treatments { get; set; }

    }
}
