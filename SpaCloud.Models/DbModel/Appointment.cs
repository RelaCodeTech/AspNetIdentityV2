﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaCloud.Models.DbModel
{
    public class Appointment
    {
        public Int64 ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Company")]
        public Int64 CompanyId { get; set; }

        [Display(Name = "Branch")]
        public Int64 BranchId { get; set; }

        [Display(Name = "Customer")]
        public Int64 CustomerId { get; set; }

        [Display(Name = "Package")]
        public string PackageId { get; set; }

        [Display(Name = "Date and Time")]
        public string DateTimeScheduled { get; set; }

        [Display(Name = "Duration")]
        public string AppointmentLength { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
        public int StatusENUM { get; set; }
    }

    public enum AppointmentStatus
    {
        [Description("#FF850B")] // orange
        Booked = 0,
        [Description("#1D70FF")] // blue
        Confirmed,
        [Description("#34AD2C")] // green
        Visited

    }

}