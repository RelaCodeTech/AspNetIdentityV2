using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.XrefServiceTreatments = new HashSet<XrefServiceTreatment>();
        }

        [Key]
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string TreatmentName { get; set; }

        [Display(Name = "Description")]
        public string TreatmentDesc { get; set; }

        [Display(Name = "Duration")]
        public int TreatmentDuration { get; set; }

        [ReadOnly(true)]
        public System.DateTime CreatedDt { get; set; }

        public virtual ICollection<XrefServiceTreatment> XrefServiceTreatments { get; set; }
    }
}
