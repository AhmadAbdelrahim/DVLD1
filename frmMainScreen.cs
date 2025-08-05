using DVLD1.Appliction.International_License;
using DVLD1.Appliction.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    public partial class frmMainScreen : Form
    {
        //private frmManagePeople MP = new frmManagePeople();

        public frmMainScreen()
        {
            InitializeComponent();
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Refresh();
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople MP = new frmManagePeople();
            
            //MP.MdiParent = this;
            //MP.Show();
            
            MP.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm1 = new frmAddUpdateLocalDrivingLicenseApplication();
            frm1.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm2 = new frmNewInternationalLicenseApplication();
            frm2.ShowDialog();
        }
    }
}
