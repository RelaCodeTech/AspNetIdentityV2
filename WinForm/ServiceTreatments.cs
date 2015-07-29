using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaCloud.Models;
using SpaCloud.Models.ViewModel;
using SpaCloud.Models.DbModel;
using SpaCloud.Models.DAL;
using Dapper;
using System.Data.SqlClient;

namespace WinForm
{
    public partial class ServiceTreatments : Form
    {
        private SqlConnection _con;

        public ServiceTreatments()
        {
            InitializeComponent();
            string _connectionString = "data source=Sandeep;initial catalog=DevTest;integrated security=true";
            this._con = new SqlConnection(_connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryMappingData = @"select xref.*, 
                                    pkg.ServiceID, pkg.ServiceName, 
                                    trmt.TreatmentID, trmt.TreatmentName
                                from 
                                    [dbo].[XrefServiceTreatment] as xref,
                                    [dbo].[Treatment] as trmt,
                                    [dbo].[Service] as pkg

                                where 

                                    xref.TreatmentID = trmt.TreatmentID
                                    and
                                    xref.ServiceID = pkg.ServiceID
                                    and
                                    xref.CompanyID = 1 order by pkg.ServiceID, pkg.ServiceName";


            string qryGetPkgAndTreatments = @"select * from [dbo].[Service] where CompanyID = 1
                                              select * from [dbo].[Treatment] where CompanyID = 1 " + queryMappingData;


            var FuncQryReadAllMappings = new Func<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
                                (xref, pkg, trtmnt) =>
                                {
                                    xref.Service = pkg;
                                    xref.Treatment = trtmnt;
                                    return xref;
                                });

            ServiceTreatmentViewModel ptVM = new ServiceTreatmentViewModel();

            using (var multi = this._con.QueryMultiple(qryGetPkgAndTreatments))
            {
                ptVM.Services = multi.Read<Service>().ToList();
                ptVM.Treatments = multi.Read<Treatment>().ToList();
                ptVM.SvcTrtmntMappings = multi.Read(FuncQryReadAllMappings, "ServiceID,TreatmentID").ToList();
            }

            //var resultList = this._con.Query<XrefServiceTreatment, Service, Treatment, XrefServiceTreatment>(
            //                    queryMappingData, (xref, pkg, trtmnt) =>
            //                    {
            //                        xref.Service = pkg;
            //                        xref.Treatment = trtmnt;
            //                        return xref;
            //                    },
            //                     splitOn: "ServiceID,TreatmentID"
            //                     ).AsQueryable();
            this._con.Close();
            

            this.dgMappedData.DataSource = ptVM.SvcTrtmntMappings;
            this.dgServices.DataSource = ptVM.Services;
            this.dgTreatments.DataSource = ptVM.Treatments;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
