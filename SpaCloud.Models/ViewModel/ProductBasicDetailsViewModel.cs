using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.ViewModel
{
    public class ProductBasicDetailsViewModel
    {
        [Key]
        public long ProductID { get; set; }
        public long CompanyID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductWeight { get; set; }
        public string ProductUoM { get; set; }
    }
}
