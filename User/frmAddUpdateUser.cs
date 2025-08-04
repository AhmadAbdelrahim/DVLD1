using DVLD1.People;
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
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmFindPerson findperson = new frmFindPerson();

            findperson.BackData += DataBack_Delegate;

            findperson.ShowDialog();
        }

        private void DataBack_Delegate(object sender, int PersonID)
        {

        }
    }
}
