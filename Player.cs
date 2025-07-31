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
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        public void Kick(int location) => MessageBox.Show($"Player Kick: {location.ToString()}");
    }
}
