using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaCloud.Models.DbModel;
using SpaCloud.Models.DAL;

namespace AspNetIdentityV2.Controllers.Appointments
{
    public class AppointmentController : Controller
    {
        private IApppointmentRepository _appointmentRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public AppointmentController()
        {
            this._appointmentRepository = new AppointmentRepository(this._dbConnStringName);
        }

        //
        // GET: /Appointment/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Appointment/Create
        [HttpPost]
        public ActionResult Create(Appointment NewAppointment)
        {
            try
            {
                this._appointmentRepository.CreateAppointment(NewAppointment);
                return RedirectToAction("Index", "FullCalendar");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Appointment/Edit/5
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
        // GET: /Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Appointment/Delete/5
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
