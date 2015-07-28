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
    public partial class PackageTreatments : Form
    {
        private SqlConnection _con;

        public PackageTreatments()
        {
            InitializeComponent();
            string _connectionString = "data source=Sandeep;initial catalog=DevTest;integrated security=true";
            this._con = new SqlConnection(_connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryMappingData = @"select xref.*, 
                                    pkg.PackageID, pkg.PackageName, 
                                    trmt.TreatmentID, trmt.TreatmentName
                                from 
                                    [dbo].[XrefPackageTreatment] as xref,
                                    [dbo].[Treatment] as trmt,
                                    [dbo].[Package] as pkg

                                where 

                                    xref.TreatmentID = trmt.TreatmentID
                                    and
                                    xref.PackageID = pkg.PackageID
                                    and
                                    xref.CompanyID = 1 order by pkg.PackageID, pkg.PackageName";


            string qryGetPkgAndTreatments = @"select * from [dbo].[Package] where CompanyID = 1
                                              select * from [dbo].[Treatment] where CompanyID = 1 " + queryMappingData;


            var FuncQryReadAllMappings = new Func<XrefPackageTreatment, Package, Treatment, XrefPackageTreatment>(
                                (xref, pkg, trtmnt) =>
                                {
                                    xref.Package = pkg;
                                    xref.Treatment = trtmnt;
                                    return xref;
                                });

            PackageTreatmentViewModel ptVM = new PackageTreatmentViewModel();

            using (var multi = this._con.QueryMultiple(qryGetPkgAndTreatments))
            {
                ptVM.Packages = multi.Read<Package>().ToList();
                ptVM.Treatments = multi.Read<Treatment>().ToList();
                ptVM.PkgTrtmntMappings = multi.Read(FuncQryReadAllMappings, "PackageID,TreatmentID").ToList();
            }

            //var resultList = this._con.Query<XrefPackageTreatment, Package, Treatment, XrefPackageTreatment>(
            //                    queryMappingData, (xref, pkg, trtmnt) =>
            //                    {
            //                        xref.Package = pkg;
            //                        xref.Treatment = trtmnt;
            //                        return xref;
            //                    },
            //                     splitOn: "PackageID,TreatmentID"
            //                     ).AsQueryable();
            this._con.Close();
            

            this.dgMappedData.DataSource = ptVM.PkgTrtmntMappings;
            this.dgPackages.DataSource = ptVM.Packages;
            this.dgTreatments.DataSource = ptVM.Treatments;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
