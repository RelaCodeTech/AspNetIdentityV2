using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SpaCloud.Models.DbModel;

namespace SpaCloud.Models.DAL
{
    public class CompanyRepository: ICompanyRepository
    {
        private SqlConnection _con;

        public CompanyRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }


        /// <summary>
        /// Get List of Companies associated with Logged In User
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public IEnumerable<Company> LoggedInUsersCompanyList(Int64 companyID)
        {
            string query = "select * from Company where CompanyID = " + companyID;
            var result = this._con.Query<Company>(query);
            return result;
        }  

        /// <summary>
        /// Create new company
        /// </summary>
        /// <param name="NewCompany"></param>
        /// <returns></returns>
        public string CreateCompany(Company NewCompany, string UserID)
        {
            //string newCompanyID = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            //NewCompany.CompanyID = newCompanyID;

            string queryInsertCompany = @"INSERT INTO [dbo].[Company]
           ([CompanyName]
           ,[CompanyEmail]
           ,[CompanyWebSite]
           ,[CompanyDetails]
           ,[CompanyDesc])
     VALUES
           (@CompanyName, @CompanyEmail, @CompanyWebSite, @CompanyDetails, @CompanyDesc)";


            //creates new company
            this._con.Query<int>(queryInsertCompany, NewCompany);

            //string queryUpdateUser = @"update [dbo].[AspNetUsers] set [CompanyID] = '" + newCompanyID +
            //             @"' where [Id] = '" + UserID + "'";

            ////associates new company with logged in user
            //this._con.Query<int>(queryUpdateUser, null);

            return "success";
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