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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        public void form2_OnKokoEvent(object sender, int PersonID)
        {
            textBox1.Text = PersonID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.OnKokoEvent += form2_OnKokoEvent;

            form2.ShowDialog();
        }
    }
}
