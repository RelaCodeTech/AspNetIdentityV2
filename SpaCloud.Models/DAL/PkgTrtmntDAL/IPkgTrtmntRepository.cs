using SpaCloud.Models.DbModel;
using SpaCloud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface IPkgTrtmntRepository
    {
        PackageTreatmentViewModel GetAllPkgTrtmnts(Int64 companyID);
    }
}
