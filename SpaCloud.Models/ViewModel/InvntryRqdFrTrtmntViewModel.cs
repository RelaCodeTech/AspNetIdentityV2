using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.ViewModel
{
    public class InvntryRqdFrTrtmntViewModel
    {
        public Treatment NewTreatment { get; set; }
        //public IEnumerable<ProductBasicDetailsViewModel> ProductList { get; set; }
        public IList<ProductBasicDetailsViewModel> ProductList { get; set; }
        public IEnumerable<InventoryRqdForTreatment> ListOfInvntryRqdFrTreatment { get; set; }
    }
}
