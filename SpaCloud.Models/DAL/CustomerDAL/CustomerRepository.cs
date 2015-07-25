using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SpaCloud.Models.DAL.CustomerDAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private SqlConnection _con;

        public CustomerRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public IEnumerable<Customer> GetCustomers(Int64 companyID)
        {
            string query = "select * from Customer where CompanyID = " + companyID;
            var result = this._con.Query<Customer>(query);
            return result;
        }

        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="NewCustomer"></param>
        public void CreateCustomer(Customer NewCustomer)
        {
            string qryInsertCustomer =
                            @"INSERT INTO [dbo].[Customer]
                            (
                                [CustomerID]
                                , [CompanyID]
                                , [CustomerTypeID]
                                , [CustomerFname]
                                , [CustomerLname]
                                , [CustomerGender]
                                , [CustomerMobileNo]
                                , [CustomerDOB]
                                , [CustomerEmailID]
                                , [CustomerAltMobileNo]
                                , [CustomerNotes]
                                , [CustomerCreatedBranchID]
                                , [CustomerCountry]
                                , [CustomerCreatedBy]
                                , [CustomerIsActive]
                                , [CustomerCreatedDt]
                            )
                            values
                            (@CustomerID, @CompanyID, @CustomerTypeID, @CustomerFname, @CustomerLname, 
                            @CustomerGender, @CustomerMobileNo, @CustomerDOB, @CustomerEmailID, 
                            @CustomerAltMobileNo, @CustomerNotes, @CustomerCreatedBranchID, 
                            @CustomerCountry, @CustomerCreatedBy, @CustomerIsActive, @CustomerCreatedDt)";

            //creates new Branch
            this._con.Query<int>(qryInsertCustomer, NewCustomer);

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
