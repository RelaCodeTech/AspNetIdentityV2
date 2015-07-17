using AspNetIdentityV2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentityV2.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var allRoles = context.Roles.ToList();

            Dictionary<string, string> ReadableRoles = new Dictionary<string, string>();

            foreach(var role in allRoles)
            {
                ReadableRoles.Add(role.Id, role.Name);
            }

            ViewData["Roles"] = ReadableRoles;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string roleName)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roleresult = roleManager.Create(new IdentityRole(roleName));

            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(string id)
        {
            var context = new ApplicationDbContext();

            var thisRole = context.Roles.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

                // GET: /Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                var context = new ApplicationDbContext();
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

	}
}