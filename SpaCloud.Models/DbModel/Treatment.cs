using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Treatment
    {
        public Treatment()
        {
            this.XrefPackageTreatments = new HashSet<XrefPackageTreatment>();
        }

        [Key]
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }
        public string TreatmentName { get; set; }
        public string TreatmentDesc { get; set; }
        public System.DateTime CreatedDt { get; set; }

        public virtual ICollection<XrefPackageTreatment> XrefPackageTreatments { get; set; }
    }
}
