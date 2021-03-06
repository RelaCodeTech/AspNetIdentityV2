﻿using SpaCloud.Models.DbModel;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _con;

        public EmployeeRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        public IEnumerable<Employee> GetAllEmployees(Int64 companyID)
        {
            string query = String.Format("select * from [dbo].[Employee] where CompanyID = {0}", companyID);
            var result = this._con.Query<Employee>(query);
            return result;
        }

        public IEnumerable<Employee> GetBranchEmployees(Int64 companyID, Int64 branchID)
        {
            string query = String.Format("select * from [dbo].[Employee] where CompanyID = {0} and BaseBranchID = {1}", companyID, branchID);
            var result = this._con.Query<Employee>(query);
            return result;
        }

        /// <summary>
        /// Create New Employee
        /// </summary>
        /// <param name="NewEmployee"></param>
        public void CreateEmployee(Employee NewEmployee)
        {
            string qryInsertEmployee =
                            @"INSERT INTO [dbo].[Employee]
                            ([EmpID]
                            , [CompanyID]
                            , [BranchID]
                            , [EmpCode]
                            , [EmpFName]
                            , [EmpLName]
                            , [EmpGender]
                            , [EmpTypeID]
                            , [IsOnPayRoll]
                            , [EmpContactNo]
                            , [IsActive]
                            , [EmpCreatedDt]
                            , [EmpCreatedBy]
                            )
                            values
                            (@EmpID, @CompanyID, @BranchID, @EmpCode, @EmpFName, 
                            @EmpLName, @EmpGender, @EmpTypeID, @IsOnPayRoll, 
                            @EmpContactNo, @IsActive, @EmpCreatedDt, @EmpCreatedBy)";

            //creates new Branch
            this._con.Query<int>(qryInsertEmployee, NewEmployee);

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
