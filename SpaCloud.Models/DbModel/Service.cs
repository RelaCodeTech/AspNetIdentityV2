using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Service
    {
        public Service()
        {
            this.XrefServiceTreatments = new HashSet<XrefServiceTreatment>();
        }

        [Key]
        public long ServiceID { get; set; }
        public long CompanyID { get; set; }

        [Display(Name="Name")]
        [Required]
        [DataType(DataType.Text)]
        public string ServiceName { get; set; }

        [Display(Name = "Description")]
        public string ServiceDesc { get; set; }

        [ReadOnly(true)]
        public System.DateTime CreatedDt { get; set; }

        public virtual ICollection<XrefServiceTreatment> XrefServiceTreatments { get; set; }

    }
}
