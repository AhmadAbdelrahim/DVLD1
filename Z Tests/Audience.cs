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
    public partial class Audience : Form
    {
        public Audience()
        {
            InitializeComponent();
        }

        public void Cheer(int location) => MessageBox.Show($"Audience Cheer: {location.ToString()}");
    }
}
