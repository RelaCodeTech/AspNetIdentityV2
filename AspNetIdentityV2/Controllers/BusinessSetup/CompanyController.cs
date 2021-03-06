﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SpaCloud.Models.DbModel;
using SpaCloud.Models.DAL;

namespace AspNetIdentityV2.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public CompanyController()
        {
            this._companyRepository = new CompanyRepository(this._dbConnStringName);
        }

        //
        // GET: /Company/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            if (currentUser.CompanyID < 0)
            {
                this._companyRepository.LoggedInUsersCompanyList(currentUser.CompanyID);
                return RedirectToAction("List", "Company");
            }

            return View();
        }

        public ActionResult List()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            Int64 companyID = -1;

            if (currentUser.CompanyID > 0)
            {
                companyID = currentUser.CompanyID;
            }

            return View(this._companyRepository.LoggedInUsersCompanyList(companyID));

        }

        public ActionResult Create()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            
            //user cannot create more than 1 company
            if (currentUser.CompanyID > 0)
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
            this._companyRepository.CreateCompany(NewCompany, User.Identity.GetUserId());

            return RedirectToAction("List", "Company");
        }

	}
}