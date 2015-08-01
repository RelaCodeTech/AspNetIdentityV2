using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SpaCloud.Models.ViewModel;

namespace SpaCloud.Models.DAL
{
    public class SvcTrtmntRepository : ISvcTrtmntRepository
    {
        private SqlConnection _con;

        public SvcTrtmntRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public IEnumerable<XrefServiceTreatment> GetAllSvcTrtmnts2(Int64 companyID)
        {
            string qryAllMappingData = String.Format(@"
                                            select trt2.ServiceTreatmentXrefID, svc.*, 
                                                   trt2.TreatmentID, trt2.TreatmentName, trt2.TreatmentDuration
                                            from
                                            (
	                                            --get all services for a company
	                                            SELECT distinct ServiceID, ServiceName
	                                            from [DevTest].[dbo].[Service]
	                                            where CompanyID = {0}

                                            ) as svc 
                                            left outer join
                                            (
		                                            -- get all trtmnts for a company which are mapped
	                                               SELECT xref.ServiceTreatmentXrefID, xref.ServiceID, trt.TreatmentID, trt.TreatmentName, trt.TreatmentDuration
		                                             FROM 
		                                             [DevTest].[dbo].[XrefServiceTreatment] as xref,
		                                             [DevTest].[dbo].Treatment as trt
		                                             where 
		                                             xref.TreatmentID = trt.TreatmentID
		                                             and xref.CompanyID = {0}
                                            )
                                            as trt2
                                            on svc.ServiceID = trt2.ServiceID
                                            order by svc.ServiceID, trt2.TreatmentID", companyID);

            //var FuncQry2ReadAllMappings = new Func<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
            //        (xref, pkg, trtmnt) =>
            //        {
            //            xref.Service = pkg;
            //            xref.Treatment = trtmnt;
            //            return xref;
            //        });

            //using (var multi = this._con.QueryMultiple(sbAllQueries.ToString()))
            //{
            //    ViewModelData.Services = multi.Read<Service>().ToList();
            //    ViewModelData.Treatments = multi.Read<Treatment>().ToList();
            //    ViewModelData.SvcTrtmntMappings = multi.Read(FuncQry2ReadAllMappings, "ServiceID,TreatmentID").ToList();
            //}

            var resultList = this._con.Query<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
                                qryAllMappingData, (xref, pkg, trtmnt) =>
                                {
                                    xref.Service = pkg;
                                    xref.Treatment = trtmnt;
                                    return xref;
                                },
                                 splitOn: "ServiceID,TreatmentID"
                                 ).AsQueryable();
            return resultList;
        }

        /// <summary>
        /// Get app Service and treatments data for a company
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public ServiceTreatmentViewModel GetAllSvcTrtmnts(Int64 companyID)
        {
            StringBuilder sbAllQueries = new StringBuilder();
            ServiceTreatmentViewModel ViewModelData = new ServiceTreatmentViewModel();

            string qryAllServices = @"select * from [dbo].[Service] where CompanyID = " + companyID;
            string qryAllTreatments = @"select * from [dbo].[Treatment] where CompanyID = " + companyID;

            string qryAllMappingData = @"select xref.*, 
                                    pkg.ServiceID, pkg.ServiceName, 
                                    trmt.TreatmentID, trmt.TreatmentName, trmt.TreatmentDuration
                                from 
                                    [DevTest].[dbo].[XrefServiceTreatment] as xref,
                                    [DevTest].[dbo].[Treatment] as trmt,
                                    [DevTest].[dbo].[Service] as pkg

                                where 

                                    xref.TreatmentID = trmt.TreatmentID
                                    and
                                    xref.ServiceID = pkg.ServiceID
                                    and
                                    xref.CompanyID = " + companyID + " order by pkg.ServiceID, pkg.ServiceName";

            sbAllQueries.Append(qryAllServices);
            sbAllQueries.Append(qryAllTreatments);
            sbAllQueries.Append(qryAllMappingData);

            var FuncQry2ReadAllMappings = new Func<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
                    (xref, pkg, trtmnt) =>
                    {
                        xref.Service = pkg;
                        xref.Treatment = trtmnt;
                        return xref;
                    });

            using (var multi = this._con.QueryMultiple(sbAllQueries.ToString()))
            {
                ViewModelData.Services = multi.Read<Service>().ToList();
                ViewModelData.Treatments = multi.Read<Treatment>().ToList();
                ViewModelData.SvcTrtmntMappings = multi.Read(FuncQry2ReadAllMappings, "ServiceID,TreatmentID").ToList();
            }

            //var resultList = this._con.Query<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
            //                    qryAllMappingData, (xref, pkg, trtmnt) =>
            //                    {
            //                        xref.Service = pkg;
            //                        xref.Treatment = trtmnt;
            //                        return xref;
            //                    },
            //                     splitOn: "ServiceID,TreatmentID"
            //                     ).AsQueryable();
            return ViewModelData;

        }

        /// <summary>
        /// Add new service
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="NewService"></param>
        public void AddNewService(Int64 companyID, Service NewService)
        {
            this._con.Insert(new Service { CompanyID = companyID, ServiceName = NewService.ServiceName, ServiceDesc = NewService.ServiceDesc });
        }

        /// <summary>
        /// Add new treatment and its reqd products
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="NewCreatedTreatment"></param>
        public void AddNewTreatment(Int64 companyID, InvntryRqdFrTrtmntViewModel NewCreatedTreatment)
        {
            // newTrtmntID = newly created treatment id
            long newTrtmntID = this._con.Insert<long>(new Treatment
            {
                CompanyID = companyID,
                TreatmentName = NewCreatedTreatment.NewTreatment.TreatmentName,
                TreatmentDesc = NewCreatedTreatment.NewTreatment.TreatmentDesc,
                TreatmentDuration = NewCreatedTreatment.NewTreatment.TreatmentDuration
            });

            //filling in new treatment id
            foreach (var invtryRqd in NewCreatedTreatment.ListOfInvntryRqdFrTreatment)
            {
                invtryRqd.TreatmentID = newTrtmntID;
                //this._con.Insert(invtryRqd);  //using dapper.simpleCRUD
            }

            //using dapper.net
            string qryInsertListIntoInventoryRqdForTreatment = @"insert into [dbo].[InventoryRqdForTreatment] values (@TreatmentID, @ProductID, @QtyUsed)";
            
            //insert List using dapper.net
            this._con.Execute(qryInsertListIntoInventoryRqdForTreatment, NewCreatedTreatment.ListOfInvntryRqdFrTreatment);

        }

        /// <summary>
        /// Get Service by id
        /// </summary>
        /// <param name="SvcId"></param>
        /// <returns></returns>
        public Service GetSvcByID(int SvcId)
        {
            var Svc = this._con.Get<Service>(SvcId);
            if (Svc == null)
                return new Service();

            return (Service)Svc;
        }

        /// <summary>
        /// update svc
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="UpdatedService"></param>
        public void UpdateService(Int64 companyID, Service UpdatedService)
        {
            //this._con.Update(UpdatedService); Issue with update - it deletes record :-|
            string qryUpdate = String.Format(@"update [dbo].[Service] set ServiceName = '{0}', ServiceDesc = '{1}' where ServiceID = {2} and CompanyID = {3}"
                                                , UpdatedService.ServiceName
                                                , UpdatedService.ServiceDesc
                                                , UpdatedService.ServiceID
                                                , companyID
                                                );

            this._con.Execute(qryUpdate, UpdatedService);
        }

        /// <summary>
        /// Deletes a Service
        /// </summary>
        /// <param name="id"></param>
        public void DeleteService(int id)
        {
            //string qryDeleteSvc = String.Format("Delete from [dbo].[Service] where ServiceID = {0}", id);
            this._con.Delete<Service>(id);
        }

        /// <summary>
        /// delete a treatment
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTreatment(int id)
        {
            //delete dependant table data - InventoryRqdForTreatment
            this._con.DeleteList<InventoryRqdForTreatment>(" where TreatmentID = " + id);

            //delete Treatment
            this._con.Delete<Treatment>(id);
        }

        /// <summary>
        /// gets list of all proudcts with basic details
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public IList<ProductBasicDetailsViewModel> GetAllProductsWithBasicDetails(Int64 companyID)
        {
            string qryGetProducts = String.Format(@"select a.[ProductID]
                                          ,a.[CompanyID]
                                          ,a.[ProductName]
                                          ,a.[ProductCode]
                                          ,a.[ProductDesc]
	                                      ,b.[ProductUoM]
                                          ,a.[ProductWeight]

	                                      from [dbo].[Product] as a,
	                                      [dbo].[LookupProductUoM] as b

	                                      where 
	                                      a.[ProductUoMID] = b.[ProductUoMID]
                                          and a.[CompanyID] = {0}      
                                                    ", companyID);

            return (IList<ProductBasicDetailsViewModel>) this._con.Query<ProductBasicDetailsViewModel>(qryGetProducts);

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._con.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
