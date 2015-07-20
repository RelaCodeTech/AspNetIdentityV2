//using AspNetIdentityV2.Models.DbEfModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace AspNetIdentityV2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string EmailId { get; set; }

        //public virtual ICollection<Company> Companies { get; set; }
        public string CompanyID { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            //: base("DefaultConnection")
            : base("DbConnString")
        {
        }
    }
}