using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.People
{
    public partial class frmFindPerson : Form
    {
        public delegate void delBackData(object sender, int personID);
        public event delBackData BackData;

        public frmFindPerson()
        {
            InitializeComponent();
        }
        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string _nationalNo = textBox1.Text.ToString();

                ctrlPersonDetails1.LoadPersonInfoByNationalNo(_nationalNo);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                string input = textBox1.Text.Trim();
                if (input.Length > 10)
                {
                    MessageBox.Show("Please enter a valid person ID (maximum 10 digits).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int _personID = Convert.ToInt32(textBox1.Text);
                ctrlPersonDetails1.LoadPersonInfoByID(_personID);
            }
            else
            {
                MessageBox.Show("Please select a valid search criteria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(textBox1.Text);

            BackData?.Invoke(this, personID);

            this.Close();

        }
    }
}
