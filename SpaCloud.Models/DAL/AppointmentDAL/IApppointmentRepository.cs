using SpaCloud.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaCloud.Models.DAL
{
    public interface IApppointmentRepository: IDisposable
    {
        string CreateAppointment(Appointment NewAppointment);
        IEnumerable<Appointment> LoadAllAppointmentInRange(double start, double end);
    }
}
