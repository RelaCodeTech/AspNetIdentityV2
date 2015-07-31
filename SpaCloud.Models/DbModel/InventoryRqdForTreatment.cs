using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public partial class InventoryRqdForTreatment
    {
        [Key]
        public long InventoryRqdForTreatmentID { get; set; }
        public long TreatmentID { get; set; }
        public long ProductID { get; set; }
        public Nullable<decimal> QtyUsed { get; set; }

        public virtual Product Product { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
