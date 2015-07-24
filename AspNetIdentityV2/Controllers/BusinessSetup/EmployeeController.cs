using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SpaCloud.Models.DAL;

namespace AspNetIdentityV2.Controllers.BusinessSetup
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public EmployeeController()
        {
            this._employeeRepository = new EmployeeRepository(this._dbConnStringName);
        }

        //
        // GET: /Employee/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            return View(this._employeeRepository.GetEmployees(currentUser.CompanyID));
        }

        //
        // GET: /Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create
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
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Edit/5
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
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5
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
