using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DbModel
{
    public class Product
    {
        public Product()
        {
            this.InventoryRqdForServices = new HashSet<InventoryRqdForService>();
            this.InventoryRqdForTreatments = new HashSet<InventoryRqdForTreatment>();
        }

        [Key]
        public long ProductID { get; set; }
        public long CompanyID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductWeight { get; set; }
        public int ProductUoMID { get; set; }
        public decimal ProductCurrMRP { get; set; }
        public Nullable<int> ProductBalanceQty { get; set; }
        public Nullable<int> ProductMinStockLvl { get; set; }
        public Nullable<long> ProductVendorID { get; set; }
        public Nullable<System.DateTime> ProductMfgDt { get; set; }
        public Nullable<System.DateTime> ProductExpDt { get; set; }
        public string ProductBarCode { get; set; }
        public string ProductIsActive { get; set; }
        public System.DateTime ProductCreatedDt { get; set; }
        public string ProductCreatedBy { get; set; }

        public virtual ICollection<InventoryRqdForService> InventoryRqdForServices { get; set; }
        public virtual ICollection<InventoryRqdForTreatment> InventoryRqdForTreatments { get; set; }
        public virtual LookUpProductUoM LookUpProductUoM { get; set; }
    }
}
