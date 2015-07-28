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
    public class PkgTrtmntRepository : IPkgTrtmntRepository
    {
        private SqlConnection _con;

        public PkgTrtmntRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public PackageTreatmentViewModel GetAllPkgTrtmnts(Int64 companyID)
        {
            StringBuilder sbAllQueries = new StringBuilder();
            PackageTreatmentViewModel ViewModelData = new PackageTreatmentViewModel();

            string qryAllPackages = @"select * from [dbo].[Package] where CompanyID = " + companyID;
            string qryAllTreatments = @"select * from [dbo].[Treatment] where CompanyID = " + companyID;

            string qryAllMappingData = @"select xref.*, 
                                    pkg.PackageID, pkg.PackageName, 
                                    trmt.TreatmentID, trmt.TreatmentName
                                from 
                                    [DevTest].[dbo].[XrefPackageTreatment] as xref,
                                    [DevTest].[dbo].[Treatment] as trmt,
                                    [DevTest].[dbo].[Package] as pkg

                                where 

                                    xref.TreatmentID = trmt.TreatmentID
                                    and
                                    xref.PackageID = pkg.PackageID
                                    and
                                    xref.CompanyID = " + companyID + " order by pkg.PackageID, pkg.PackageName";

            sbAllQueries.Append(qryAllPackages);
            sbAllQueries.Append(qryAllTreatments);
            sbAllQueries.Append(qryAllMappingData);

            var FuncQry2ReadAllMappings = new Func<XrefPackageTreatment, Package, Treatment, XrefPackageTreatment>(
                    (xref, pkg, trtmnt) =>
                    {
                        xref.Package = pkg;
                        xref.Treatment = trtmnt;
                        return xref;
                    });

            using (var multi = this._con.QueryMultiple(sbAllQueries.ToString()))
            {
                ViewModelData.Packages = multi.Read<Package>().ToList();
                ViewModelData.Treatments = multi.Read<Treatment>().ToList();
                ViewModelData.PkgTrtmntMappings = multi.Read(FuncQry2ReadAllMappings, "PackageID,TreatmentID").ToList();
            }

            //var resultList = this._con.Query<XrefPackageTreatment, Package, Treatment, XrefPackageTreatment>(
            //                    qryAllMappingData, (xref, pkg, trtmnt) =>
            //                    {
            //                        xref.Package = pkg;
            //                        xref.Treatment = trtmnt;
            //                        return xref;
            //                    },
            //                     splitOn: "PackageID,TreatmentID"
            //                     ).AsQueryable();
            return ViewModelData;

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
