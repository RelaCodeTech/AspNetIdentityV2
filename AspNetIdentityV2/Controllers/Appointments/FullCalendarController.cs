using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetIdentityV2.Utilities;
using SpaCloud.Models.DAL;

namespace AspNetIdentityV2.Controllers
{
    public class FullCalendarController : Controller
    {
        private IApppointmentRepository _appointmentRepository;
        private string _dbConnStringName = AspNetIdentityV2.Utilities.AppReadOnlyVar.DbConnString;

        public FullCalendarController()
        {
            this._appointmentRepository = new AppointmentRepository(this._dbConnStringName);
        }

        //
        // GET: /FullCalendar/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets appointment data for a given period
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>JsonResult</returns>
        public JsonResult GetAppointments(double start, double end)
        {
            var AppointmentListInRange = this.LoadAllAppointmentInRange(start, end);

            var eventList = from e in AppointmentListInRange
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.DateTimeScheduled,
                                end = Convert.ToDateTime(e.DateTimeScheduled).AddMinutes(Convert.ToDouble(e.AppointmentLength)).ToString(),
                                color = Enums.GetEnumDescription<AppointmentStatus>(Enums.GetName<AppointmentStatus>((AppointmentStatus)e.StatusENUM)),
                                //className = "ENQUIRY",
                                someKey = e.CustomerId,
                                allDay = false
                            };

            var rows = eventList.ToArray();

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// gets all appointments (from repository) for given date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private IEnumerable<Appointment> LoadAllAppointmentInRange(double start, double end)
        {
            return this._appointmentRepository.LoadAllAppointmentInRange(start, end);
        }
	}
}