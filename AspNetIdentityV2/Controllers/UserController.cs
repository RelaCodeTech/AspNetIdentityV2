using AspNetIdentityV2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpaCloud.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentityV2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var allUsers = context.Users.ToList();
            return View(allUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel NewUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = NewUser.UserName };
                user.EmailId = NewUser.EmailId;
                var account = new AccountController();
                var result = account.UserManager.Create(user, NewUser.Password);
                if (result.Succeeded)
                {
                    ViewBag.ResultMessage = "User added successfully with BasicAccess Role !";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.ResultMessage = "Error adding user. Please contact System Admin.";
                }
            }

            return RedirectToAction("Index", "User");
        }
	}
}