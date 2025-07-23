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

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople MP = new frmManagePeople();
            MP.MdiParent = this;
            MP.Show();
        }

    }
}
