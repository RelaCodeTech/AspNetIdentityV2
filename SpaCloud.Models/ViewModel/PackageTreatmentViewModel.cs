using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.ViewModel
{
    public class PackageTreatmentViewModel
    {
        public IEnumerable<XrefPackageTreatment> PkgTrtmntMappings = new List<XrefPackageTreatment>();
        public List<Package> Packages = new List<Package>();
        public List<Treatment> Treatments = new List<Treatment>();
    }
}
