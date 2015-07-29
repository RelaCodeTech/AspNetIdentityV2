using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetAllEmployees(Int64 companyID);
        IEnumerable<Employee> GetBranchEmployees(Int64 companyID, Int64 branchID);
        void CreateEmployee(Employee NewEmployee);
    }
}
