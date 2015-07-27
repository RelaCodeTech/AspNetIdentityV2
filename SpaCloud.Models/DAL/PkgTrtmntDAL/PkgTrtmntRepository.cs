using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SpaCloud.Models.DAL
{
    public class PkgTrtmntRepository : IPkgTrtmntRepository
    {
        private SqlConnection _con;

        public PkgTrtmntRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public IEnumerable<XrefPackageTreatment> GetAllPkgTrtmnts(Int64 companyID)
        {

            string query = @"select xref.*, 
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

            var resultList = this._con.Query<XrefPackageTreatment, Package, Treatment, XrefPackageTreatment>(
                                query, (xref, pkg, trtmnt) =>
                                {
                                    xref.Package = pkg;
                                    xref.Treatment = trtmnt;
                                    return xref;
                                },
                                 splitOn: "PackageID,TreatmentID"
                                 ).AsQueryable();
            return resultList;


            //var result = this._con.Query<XrefPackageTreatment>(query);
            //return result;
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
