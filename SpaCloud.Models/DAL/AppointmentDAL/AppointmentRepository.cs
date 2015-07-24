using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaCloud.Models.DbModel;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace SpaCloud.Models.DAL
{
    public class AppointmentRepository : IApppointmentRepository
    {
        private SqlConnection _con;

        public AppointmentRepository(string DbConnStringName)
        {
            this._con = new SqlConnection(ConfigurationManager.ConnectionStrings[DbConnStringName].ToString());
        }

        /// <summary>
        /// Create new appointment
        /// </summary>
        /// <param name="NewAppointment"></param>
        /// <returns></returns>
        public string CreateAppointment(Appointment NewAppointment)
        {
            string query = @"insert into [dbo].[AppointmentDiary]
                                ([Title]
                                ,[CompanyId]
                                ,[BranchId]
                                ,[CustomerId]
                                ,[PackageId]
                                ,[DateTimeScheduled]
                                ,[AppointmentLength]
                                ,[Notes]
                                ,[StatusENUM])
                                
                            values
                            (@Title, @CompanyId, @BranchId, @CustomerId, @PackageId, @DateTimeScheduled, @AppointmentLength, @Notes, @StatusENUM)";

            //create new appointment in db
            _con.Query<int>(query, NewAppointment);

            return "success";
        }

        /// <summary>
        /// get appointments in a given range from db
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> LoadAllAppointmentInRange(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            string query = "  select * from [DevTest].[dbo].[AppointmentDiary] where [DateTimeScheduled] between '" + fromDate.ToString() + "' and '" + toDate.ToString() + "'";
            var result = _con.Query<Appointment>(query);
            return result;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _con.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
