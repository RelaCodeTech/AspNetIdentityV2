using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AspNetIdentityV2.Models.DAL;
using AspNetIdentityV2.Models.ViewModels;

namespace AspNetIdentityV2.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            if (!String.IsNullOrEmpty(currentUser.CompanyID))
            {
                CompanyDAL objCompanyDAL = new CompanyDAL();
                objCompanyDAL.LoggedInUsersCompanyList(currentUser.CompanyID);
                return RedirectToAction("List", "Company");
            }

            return View();
        }

        public ActionResult List()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            string companyID = String.Empty;

            if (!String.IsNullOrEmpty(currentUser.CompanyID))
            {
                companyID = currentUser.CompanyID;
            }

            CompanyDAL objCompanyDAL = new CompanyDAL();
            return View(objCompanyDAL.LoggedInUsersCompanyList(companyID));

        }

        public ActionResult Create()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            
            //user cannot create more than 1 company
            if (!String.IsNullOrEmpty(currentUser.CompanyID))
            {
                TempData["NoAdditionalCompanyMsg"] = "Sorry. Cannot create additional Companies. Please contact support - support@myapp.com";
                return RedirectToAction("List", "Company");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company NewCompany)
        {
            CompanyDAL objCompanyDAL = new CompanyDAL();
            objCompanyDAL.CreateCompany(NewCompany, User.Identity.GetUserId());

            return RedirectToAction("List", "Company");
        }

	}
}