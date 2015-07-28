using SpaCloud.Models.DAL;
using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AspNetIdentityV2.Controllers.BusinessSetup
{
    [Authorize]
    public class PkgTrtmntController : Controller
    {
        private IPkgTrtmntRepository _pkgTrtmntRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public PkgTrtmntController()
        {
            this._pkgTrtmntRepository = new PkgTrtmntRepository(this._dbConnStringName);
        }


        //
        // GET: /PkgTrtmnt/
        public ActionResult Index()
        {
            var account = new AccountController();
            var currentUser = account.UserManager.FindById(User.Identity.GetUserId());
            return View(this._pkgTrtmntRepository.GetAllPkgTrtmnts(currentUser.CompanyID));
        }
	}
}