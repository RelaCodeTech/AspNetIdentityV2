using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface IPkgTrtmntRepository
    {
        IEnumerable<XrefPackageTreatment> GetAllPkgTrtmnts(Int64 companyID);
    }
}
