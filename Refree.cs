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
    public partial class Refree : Form
    {
        public Refree()
        {
            InitializeComponent();
        }

        public void Look(int location) => MessageBox.Show($"Refree Look: {location.ToString()}");
    }
}
