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
    public class BranchRepository : IBranchRepository
    {
        private SqlConnection _con;

        public BranchRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public IEnumerable<Branch> GetBranches(Int64 companyID)
        {
            string query = "select * from Branch where CompanyID = " + companyID;
            var result = this._con.Query<Branch>(query);
            return result;
        }

        /// <summary>
        /// Create New Branch
        /// </summary>
        /// <param name="NewBranch"></param>
        public void CreateBranch(Branch NewBranch)
        {
            string qryInsertBranch =
                            @"INSERT INTO [dbo].[Company]
                            ([BranchID]
                            , [CompanyID]
                            , [BranchRegion]
                            , [BranchCode]
                            , [BranchName]
                            , [BranchHotelName]
                            , [BranchSpaName]
                            , [BranchAddress]
                            , [BranchCity]
                            , [BranchState]
                            , [BranchCountry]
                            , [BranchContactNo]
                            , [BranchComment]
                            , [BranchCreatedBy])
                            values
                            (@BranchID, @CompanyID, @BranchRegion, @BranchCode, @BranchName, 
                            @BranchHotelName, @BranchSpaName, @BranchAddress, @BranchCity, 
                            @BranchState, @BranchCountry, @BranchContactNo, @BranchComment, @BranchCreatedBy)";

            //creates new Branch
            this._con.Query<int>(qryInsertBranch, NewBranch);

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
