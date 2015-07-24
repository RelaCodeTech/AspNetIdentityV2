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
        IEnumerable<Employee> GetEmployees(Int64 companyID);
        void CreateEmployee(Employee NewEmployee);
    }
}
