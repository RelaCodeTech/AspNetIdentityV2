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
    public class CompanyDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnString"].ToString());

        /// <summary>
        /// Get List of Companies associated with Logged In User
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public IEnumerable<Company> LoggedInUsersCompanyList(string companyID)
        {
            string query = "select * from Company where CompanyID = '" + companyID + "'";
            var result = con.Query<Company>(query);
            return result;
        }  

        /// <summary>
        /// Create new company
        /// </summary>
        /// <param name="NewCompany"></param>
        /// <returns></returns>
        public string CreateCompany(Company NewCompany, string UserID)
        {
            string newCompanyID = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            NewCompany.CompanyID = newCompanyID;

            string queryInsertCompany = @"INSERT INTO [dbo].[Company]
           ([CompanyID]
           ,[CompanyName]
           ,[CompanyEmail]
           ,[CompanyWebSite]
           ,[CompanyDetails]
           ,[CompanyDesc])
     VALUES
           (@CompanyID, @CompanyName, @CompanyEmail, @CompanyWebSite, @CompanyDetails, @CompanyDesc)";


            //creates new company
            con.Query<int>(queryInsertCompany, NewCompany);

            string queryUpdateUser = @"update [dbo].[AspNetUsers] set [CompanyID] = '" + newCompanyID +
                         @"' where [Id] = '" + UserID + "'";

            //associates new company with logged in user
            con.Query<int>(queryUpdateUser, null);

            return "success";
        }
    }
}