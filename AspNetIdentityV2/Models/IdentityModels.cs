//using AspNetIdentityV2.Models.DbEfModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace AspNetIdentityV2.Models
{
    /// <summary>
    /// Application Users
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// Company ID
        /// </summary>
        public Int64 CompanyID { get; set; }

        /// <summary>
        /// User is associated with this Branch
        /// </summary>
        public Int64 BaseBranchID { get; set; }

        /// <summary>
        /// BaseBranchID + Additional Branch IDs : Concatenated by appending .
        /// </summary>
        public string AddnlBranchIDs { get; set; }

        /// <summary>
        /// Employee ID
        /// </summary>
        public Int64 EmployeeID { get; set; }

        /// <summary>
        /// Created Date Time
        /// </summary>
        public DateTime? CreatedDt { get; set; }
    }

    /// <summary>
    /// Application User Roles
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string RoleName, string RoleDesc)
        {
            base.Name = RoleName;
            this.RoleDesc = RoleDesc;
        }

        /// <summary>
        /// Role Description
        /// </summary>
        public string RoleDesc { get; set; }

        /// <summary>
        /// IF visible to Application = Y else is Internal = N
        /// </summary>
        public string IsPublic { get; set; }
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