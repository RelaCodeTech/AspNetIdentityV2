using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Package
    {
        public Package()
        {
            this.XrefPackageTreatments = new HashSet<XrefPackageTreatment>();
        }

        public long PackageID { get; set; }
        public long CompanyID { get; set; }
        public string PackageName { get; set; }
        public string PackageDesc { get; set; }
        public System.DateTime CreatedDt { get; set; }

        public virtual ICollection<XrefPackageTreatment> XrefPackageTreatments { get; set; }

    }
}
