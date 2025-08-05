using DVLD1.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainScreen());

            //Application.Run(new Test1());

            //Application.Run(new Form1());

            //Application.Run(new frmManagePeople());
            //Application.Run(new frmLoginScreen());
            //Application.Run(new frmManageUsers());
            //Application.Run(new frmAddNewUser());
            //Application.Run(new frmFindPerson());
            //Application.Run(new frmManageDrivers());

        }

    }
}
