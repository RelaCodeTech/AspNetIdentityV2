﻿using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface ICompanyRepository: IDisposable
    {
        IEnumerable<Company> LoggedInUsersCompanyList(Int64 companyID);
        string CreateCompany(Company NewCompany, string UserID);
    }
}
