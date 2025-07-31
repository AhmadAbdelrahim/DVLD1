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
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void Test1_Load(object sender, EventArgs e)
        {
            Player player = new Player();
            Refree refree = new Refree();
            Audience audience = new Audience();

            ball11.OnBallLocationChanged += player.Kick;
            ball11.OnBallLocationChanged += refree.Look;
            ball11.OnBallLocationChanged += audience.Cheer;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball11.Location = (int)numericUpDown1.Value;
        }
    }
}
