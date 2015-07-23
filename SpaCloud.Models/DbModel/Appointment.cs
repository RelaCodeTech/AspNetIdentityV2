using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaCloud.Models.DbModel
{
    public class Appointment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string CustomerId { get; set; }
        public string DateTimeScheduled { get; set; }
        public string AppointmentLength { get; set; }
        public string Notes { get; set; }
        public int StatusENUM { get; set; }
    }
}