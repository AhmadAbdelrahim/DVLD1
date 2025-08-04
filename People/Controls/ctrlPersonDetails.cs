using DVLD1_BusinessLayer;
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
    public partial class ctrlPersonDetails : UserControl
    {
       
        clsPeopleBusiness personInfo = new clsPeopleBusiness();

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
        }

        public void LoadPersonInfoByID(int PersonID)
        {
            personInfo = clsPeopleBusiness.Find(PersonID);

            if (personInfo != null)
            {
                lblPersonID.Text = personInfo.PersonID.ToString();
                lblNationalNo.Text = personInfo.NationalNo;
                lblName.Text = personInfo.FullName;
                lblDateOfBirth.Text = personInfo.DateOfBirth.ToShortDateString();
                
                if (personInfo.Gender == 0)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";
                
                lblAddress.Text = personInfo.Address;
                lblPhone.Text = personInfo.Phone;
                lblEmail.Text = personInfo.Email;
                lblCountry.Text = personInfo.CountryInfo.CountryName;
                pictureBox1.Image = personInfo.ImagePath != "" ? Image.FromFile(personInfo.ImagePath) : null;

            }
            else
                MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void LoadPersonInfoByNationalNo(string nationalNo)
        {
            personInfo = clsPeopleBusiness.Find(nationalNo);

            if (personInfo != null)
            {
                lblPersonID.Text = personInfo.PersonID.ToString();
                lblNationalNo.Text = personInfo.NationalNo;
                lblName.Text = personInfo.FullName;
                lblDateOfBirth.Text = personInfo.DateOfBirth.ToShortDateString();

                if (personInfo.Gender == 0)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";

                lblAddress.Text = personInfo.Address;
                lblPhone.Text = personInfo.Phone;
                lblEmail.Text = personInfo.Email;
                lblCountry.Text = personInfo.CountryInfo.CountryName;
                pictureBox1.Image = personInfo.ImagePath != "" ? Image.FromFile(personInfo.ImagePath) : null;

            }
            else
                MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
