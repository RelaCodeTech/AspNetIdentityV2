using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class XrefPackageTreatment
    {
        public long PackageTreatmentXrefID { get; set; }
        public long PackageID { get; set; }
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }

        public virtual Package Package { get; set; }
        public virtual Treatment Treatment { get; set; }

        //public IList<Package> Packages { get; set; }
        //public IList<Treatment> Treatments { get; set; }

    }
}
