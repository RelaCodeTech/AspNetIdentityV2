using SpaCloud.Models.DbModel;
using SpaCloud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface ISvcTrtmntRepository
    {
        ServiceTreatmentViewModel GetAllSvcTrtmnts(Int64 companyID);
        IEnumerable<XrefServiceTreatment> GetAllSvcTrtmnts2(Int64 companyID);

        void AddNewService(Int64 companyID, Service NewService);
        Service GetSvcByID(int SvcId);
        void UpdateService(Int64 companyID, Service UpdatedService);
        void DeleteService(int id);

        IList<ProductBasicDetailsViewModel> GetAllProductsWithBasicDetails(Int64 companyID);

        void CreateNewTreatment(Int64 companyID, CreateEditTrtmntViewModel NewCreatedTreatment);
        void AddRmvExstngTrtmnts(Int64 companyID, CreateEditTrtmntViewModel NewCreatedTreatment);

        IEnumerable<BasicTreatmentViewModel> GetAllTreatments(Int64 companyID, Int64 serviceID);

        void RemoveTreatment(int id);

        void DeleteTreatment(long id);
    }
}
