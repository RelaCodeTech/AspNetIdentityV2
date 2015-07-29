﻿using System;
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
            this.XrefServiceTreatments = new HashSet<XrefServiceTreatment>();
        }

        [Key]
        public long TreatmentID { get; set; }
        public long CompanyID { get; set; }
        public string TreatmentName { get; set; }
        public string TreatmentDesc { get; set; }
        public int TreatmentDuration { get; set; }
        public System.DateTime CreatedDt { get; set; }

        public virtual ICollection<XrefServiceTreatment> XrefServiceTreatments { get; set; }
    }
}
