using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class LookupCustomerType
    {
        public LookupCustomerType()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int CustomerTypeID { get; set; }
        public string CustomerType { get; set; }
        public string CustomerTypeDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
