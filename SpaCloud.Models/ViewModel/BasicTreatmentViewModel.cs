using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.ViewModel
{
    [Table("Treatment")]
    public class BasicTreatmentViewModel
    {
        [Key]
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }

        public bool CheckedStatus { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string TreatmentName { get; set; }

        [Display(Name = "Duration (mins)")]
        public int TreatmentDuration { get; set; }

    }
}
