using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface IBranchRepository : IDisposable
    {
        IEnumerable<Branch> GetBranches(Int64 companyID);
        void CreateBranch(Branch NewBranch);
    }
}
