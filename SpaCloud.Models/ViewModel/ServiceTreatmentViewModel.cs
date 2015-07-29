using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.ViewModel
{
    public class ServiceTreatmentViewModel
    {
        public IEnumerable<XrefServiceTreatment> SvcTrtmntMappings = new List<XrefServiceTreatment>();
        public List<Service> Services = new List<Service>();
        public List<Treatment> Treatments = new List<Treatment>();
    }
}
