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
            return View("Index2", this._svcTrtmntRepository.GetAllSvcTrtmnts2(currentUser.CompanyID));
            //return View(this._svcTrtmntRepository.GetAllSvcTrtmnts(currentUser.CompanyID));
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

            //perform db operation to delete svc
            this._svcTrtmntRepository.DeleteService(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes treatment-svc mapping
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RemoveTreatment(int id)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to delete treatment
            this._svcTrtmntRepository.RemoveTreatment(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Manage treatments
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageTrtmnt()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            CreateEditTrtmntViewModel objNewTrtmnt = new CreateEditTrtmntViewModel();
            objNewTrtmnt.ExistingTreatments = (IList<BasicTreatmentViewModel>)this._svcTrtmntRepository.GetAllTreatments(currentUser.CompanyID, -1);
            return PartialView("_ManageTreatment", objNewTrtmnt);
        }

        /// <summary>
        /// Deletes treatment permanantly
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteTreatment(Int64 id)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            //perform db operation to delete treatment
            this._svcTrtmntRepository.DeleteTreatment(id);

            return RedirectToAction("Index");
        }


        public ActionResult CreateTreatment2(string SvcDetails)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

            CreateEditTrtmntViewModel objNewTrtmnt = new CreateEditTrtmntViewModel();

            //getting service Id and name - associated with treatment
            objNewTrtmnt.SvcID = Convert.ToInt64(SvcDetails.Split(new char[] { '~' })[0]);
            objNewTrtmnt.SvcName = SvcDetails.Split(new char[] { '~' })[1];

            objNewTrtmnt.NewTreatment = new Treatment();
            objNewTrtmnt.ExistingTreatments = (IList<BasicTreatmentViewModel>)this._svcTrtmntRepository.GetAllTreatments(currentUser.CompanyID, objNewTrtmnt.SvcID);

            return PartialView("_CreateTreatment2", objNewTrtmnt);
        }

        /// <summary>
        /// Post method for - create new treatment
        /// </summary>
        /// <param name="NewCreatedTreatment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateTreatment2(CreateEditTrtmntViewModel NewCreatedTreatment)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            //perform db operation to add Treatment
            this._svcTrtmntRepository.CreateNewTreatment(currentUser.CompanyID, NewCreatedTreatment);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Post method for - Add/remove existings treatments mapped with Service
        /// </summary>
        /// <param name="NewCreatedTreatment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRmvExstngTrtmnts(CreateEditTrtmntViewModel NewCreatedTreatment)
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            //perform db operation to add Treatment
            this._svcTrtmntRepository.AddRmvExstngTrtmnts(currentUser.CompanyID, NewCreatedTreatment);

            return RedirectToAction("Index");
        }



        ///// <summary>
        ///// Create new treatment
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult CreateTreatment()
        //{
        //    var account = new AccountController();
        //    var currentUser = account.UserManager.FindById(User.Identity.GetUserId());

        //    CreateEditTrtmntViewModel objInvntryRqdFrTrtmntViewModel = new CreateEditTrtmntViewModel();
        //    objInvntryRqdFrTrtmntViewModel.NewTreatment = new Treatment();
        //    //objInvntryRqdFrTrtmntViewModel.ProductList = this._svcTrtmntRepository.GetAllProductsWithBasicDetails(currentUser.CompanyID);

        //    return PartialView("_CreateTreatment", objInvntryRqdFrTrtmntViewModel);
        //}

        ///// <summary>
        ///// Post method for - create new treatment
        ///// </summary>
        ///// <param name="NewCreatedTreatment"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult CreateTreatment(CreateEditTrtmntViewModel NewCreatedTreatment)
        //{
        //    var account = new AccountController();
        //    var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
        //    //NewTreatment.ListOfInvntryRqdFrTreatment = new List<InventoryRqdForTreatment>();
        //    List<InventoryRqdForTreatment> ListofInventoryRqdForTreatment = new List<InventoryRqdForTreatment>();

        //    //foreach (var productRqd in NewCreatedTreatment.ProductList)
        //    //{
        //    //    if (productRqd.CheckedStatus)
        //    //    {
        //    //        InventoryRqdForTreatment objInventoryRqdForTreatment = new InventoryRqdForTreatment();
        //    //        objInventoryRqdForTreatment.ProductID = productRqd.ProductID;
        //    //        objInventoryRqdForTreatment.QtyUsed = productRqd.QtyRqd;

        //    //        ListofInventoryRqdForTreatment.Add(objInventoryRqdForTreatment);
        //    //    }
        //    //}

        //    //NewCreatedTreatment.ListOfInvntryRqdFrTreatment = ListofInventoryRqdForTreatment;

        //    //perform db operation to add Treatment
        //    this._svcTrtmntRepository.AddNewTreatment(currentUser.CompanyID, NewCreatedTreatment);

        //    return RedirectToAction("Index");
        //}

    }
}