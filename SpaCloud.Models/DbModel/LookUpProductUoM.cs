using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class LookUpProductUoM
    {
        public LookUpProductUoM()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int ProductUoMID { get; set; }
        public string ProductUoM { get; set; }
        public string ProductUoMDesc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
