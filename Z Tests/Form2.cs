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
    public partial class Form2 : Form
    {
        public delegate void Koko (object sender, int PersonID);
        public event Koko OnKokoEvent;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _PersonID = int.Parse(textBox1.Text);

            OnKokoEvent?.Invoke(this, _PersonID);

            this.Close();
        }
    }
}
