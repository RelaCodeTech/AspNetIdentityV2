using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class InventoryRqdForService
    {
        [Key]
        public long InventoryRqdForServiceID { get; set; }
        public long ServiceID { get; set; }
        public long ProductID { get; set; }
        public Nullable<decimal> QtyUsed { get; set; }

        public virtual Product Product { get; set; }
        public virtual Service Service { get; set; }
    }

}
