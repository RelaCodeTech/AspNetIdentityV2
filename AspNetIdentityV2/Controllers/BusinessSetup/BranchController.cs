using SpaCloud.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace AspNetIdentityV2.Controllers.BusinessSetup
{
    public class BranchController : Controller
    {
        private IBranchRepository _branchRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public BranchController()
        {
            this._branchRepository = new BranchRepository(this._dbConnStringName);
        }

        //
        // GET: /Branch/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            return View(this._branchRepository.GetBranches(currentUser.CompanyID));
        }

        //
        // GET: /Branch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Branch/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
