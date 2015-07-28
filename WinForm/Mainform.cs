using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PackageTreatments FormPkgTrtmnt = new PackageTreatments();
            FormPkgTrtmnt.MdiParent = this;
            FormPkgTrtmnt.Show();
        }
    }
}
