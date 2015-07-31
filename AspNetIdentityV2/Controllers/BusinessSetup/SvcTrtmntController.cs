using SpaCloud.Models.DAL;
using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SpaCloud.Models.ViewModel;

namespace AspNetIdentityV2.Controllers.BusinessSetup
{
    [Authorize]
    public class SvcTrtmntController : Controller
    {
        private ISvcTrtmntRepository _svcTrtmntRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public SvcTrtmntController()
        {
            this._svcTrtmntRepository = new SvcTrtmntRepository(this._dbConnStringName);
        }


        //
        // GET: /PkgTrtmnt/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            return View(this._svcTrtmntRepository.GetAllSvcTrtmnts(currentUser.CompanyID));
        }

        public ActionResult EditSvc(int id)
        {
            return PartialView("_EditSvc", this._svcTrtmntRepository.GetSvcByID(id));
        }

        [HttpPost]
        public ActionResult EditSvc(Service UpdatedService)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to add svc
            this._svcTrtmntRepository.UpdateService(currentUser.CompanyID, UpdatedService);

            return RedirectToAction("Index");
        }

        public ActionResult CreateSvc()
        {
            return PartialView("_CreateSvc", new Service());
        }

        [HttpPost]
        public ActionResult CreateSvc(Service NewService)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to add svc
            this._svcTrtmntRepository.AddNewService(currentUser.CompanyID, NewService);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveSvc(int id)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to add svc
            this._svcTrtmntRepository.DeleteService(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Create new treatment
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateTreatment()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            InvntryRqdFrTrtmntViewModel objInvntryRqdFrTrtmntViewModel = new InvntryRqdFrTrtmntViewModel();
            objInvntryRqdFrTrtmntViewModel.NewTreatment = new Treatment();
            objInvntryRqdFrTrtmntViewModel.ProductList = this._svcTrtmntRepository.GetAllProductsWithBasicDetails(currentUser.CompanyID);

            return PartialView("_CreateTreatment", objInvntryRqdFrTrtmntViewModel);
        }

        [HttpPost]
        public ActionResult CreateTreatment(Treatment NewTreatment)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to add Treatment
            //this._svcTrtmntRepository.AddNewTreatment(currentUser.CompanyID, NewService);

            return RedirectToAction("Index");
        }

    }
}