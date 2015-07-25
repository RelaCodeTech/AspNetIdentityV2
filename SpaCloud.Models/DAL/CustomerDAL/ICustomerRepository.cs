using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL.CustomerDAL
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetCustomers(Int64 companyID);
        void CreateCustomer(Customer NewCustomer);
    }
}
