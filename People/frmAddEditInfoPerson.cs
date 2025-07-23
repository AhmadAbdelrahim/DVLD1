using DVLD1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD1_BusinessLayer;

namespace DVLD1
{
    public partial class frmAddEditInfoPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNewMode = 1, UpdateMode = 2 }
        public enum enGender { Male = 0, Female = 1 }

        enMode _Mode;
        int _PersonID = -1;
        clsPeopleBusiness _Person;

        public frmAddEditInfoPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNewMode;
        }

        public frmAddEditInfoPerson(int personID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateMode;
            _PersonID = personID;
        }

        private void _FillAllCountriesInComboBox()
        {
            DataTable dtCountries = clsCountriesBusiness.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefaultValues()
        {
            //This will initialize the reset the default values
            _FillAllCountriesInComboBox();

            if (_Mode == enMode.AddNewMode)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPeopleBusiness();
                rdbMale.Checked = true;
                //cbCountry.SelectedIndex = 50;

            }
            else
            {
                lblMode.Text = "Edit Person Data";
            }

            //Set default image for the person
            if (rdbMale.Checked)
                pictureBox1.Image = Resources.UnknownMan72;
            else
                pictureBox1.Image = Resources.UnknownFemale72;

            //Hide/Show the remove link incase there is no image for the person
            lnklblRemove.Visible = (pictureBox1.ImageLocation != null);

            // منع اختيار تاريخ الميلاد إذا كان أصغر من 18 سنة
            //We set the max date to 18 years from today, and set default value the same
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;

            //Should not allow adding age more than 100 years
            dateTimePicker1.MinDate = DateTime.Today.AddYears(-100);

            //This will set default country to Egypt
            cbCountry.SelectedIndex = 50;

            txtbFirstName.Text = "";
            txtbSecondName.Text = "";
            txtbThirdName.Text = "";
            txtbLastName.Text = "";
            txtbNationalNo.Text = "";            
            rdbMale.Checked = true;
            txtbPhone.Text = "";
            txtbEmail.Text = "";
            txtbAddress.Text = "";
        }    
        public void _LoadData()
        {

            _Person = clsPeopleBusiness.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"Person {_PersonID} Not Found");
                this.Close();
                return;
            }

            //The following code will not be executed if the person wan not found
            lblPersonID.Text = _PersonID.ToString();
            txtbNationalNo.Text = _Person.NationalNo;
            txtbFirstName.Text = _Person.FirstName;
            txtbSecondName.Text = _Person.SecondName;
            txtbThirdName.Text = _Person.ThirdName;
            txtbLastName.Text = _Person.LastName;
            if (_Person.Gender == 0)
                rdbMale.Checked = true;
            else
                rdbFemale.Checked = true;
            dateTimePicker1.Value = _Person.DateOfBirth;
            txtbPhone.Text = _Person.Phone;
            txtbEmail.Text = _Person.Email;
            // this will select the country in the Combobox
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            txtbAddress.Text = _Person.Address;

            //Load person image incase it was set
            if (_Person.ImagePath != "")
            {
                pictureBox1.ImageLocation = _Person.ImagePath;
            }

            //Hide/Show the remove link incase there is no image for the person
            lnklblRemove.Visible = (_Person.ImagePath != "");            
        }
        private void frmAddEditInfoPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.UpdateMode)
                _LoadData();
        }
        private bool _HandlePersonImage()
        {
            /* This procedure will handle the person image,
                it will take care of deleting the old image from the folder in case the image changed.
                and it will rename the new image with GUID and place it in the images folder.
            */

            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pictureBox1.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later
                    }
                }
            }
            if (pictureBox1.ImageLocation != null)
            {
                //then we copy the new image to the image folder after we rename it
                string sourceImageFile = pictureBox1.ImageLocation.ToString();

                if (clsUtilities.CopyImageToProjectFolderImages(ref sourceImageFile))
                {
                    pictureBox1.ImageLocation = sourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not validated!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;

            int CountryID = clsCountriesBusiness.Find(cbCountry.Text).CountryID;

            _Person.NationalNo = txtbNationalNo.Text.Trim();            
            _Person.FirstName = txtbFirstName.Text.Trim();
            _Person.SecondName = txtbSecondName.Text.Trim();
            _Person.ThirdName = txtbThirdName.Text.Trim();
            _Person.LastName = txtbLastName.Text.Trim();
            _Person.Gender = (rdbMale.Checked) ? (short)enGender.Male : (short)enGender.Female;
            _Person.Email = txtbEmail.Text.Trim();
            _Person.Phone = txtbPhone.Text.Trim();
            _Person.Address = txtbAddress.Text.Trim();
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.Nationality = CountryID;

            if (pictureBox1.ImageLocation != null)
                _Person.ImagePath = pictureBox1.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //Change form mode to UpdateMode
                _Mode = enMode.UpdateMode;
                lblMode.Text = "Edit Person Data";

                MessageBox.Show("Data saved successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Trigger the event to send data back to the caller form
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error saving Person Data", "Error Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void lnklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            openFileDialog1.Title = "Select an Image for the Person";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Process the selected image file
                string selectedImagePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedImagePath);
                lnklblRemove.Visible = true; // Show the remove link if an image is set
            }
        }
        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;

            //return default value
            if(rdbMale.Checked)
                pictureBox1.Image = Resources.UnknownMan72;
            else
                pictureBox1.Image = Resources.UnknownFemale72;

            lnklblRemove.Visible = false;
        }     
        private void rdbMale_Click(object sender, EventArgs e)
        {
            //Change the default image to male incase there is no image set
            if (pictureBox1.ImageLocation == null)
                pictureBox1.Image = Resources.UnknownMan72;
        }      
        private void rdbFemale_Click(object sender, EventArgs e)
        {
            //Change the default image to female incase there is no image set
            if (pictureBox1.ImageLocation == null)
                pictureBox1.Image = Resources.UnknownFemale72;
        }

        //Validation     
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(temp, null);
            }
        }      
        private void txtbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.IsNationalNo(txtbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                txtbPhone.Focus();
                errorProvider1.SetError(txtbNationalNo, "Required, 14 Numbers");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (clsPeopleBusiness.IsPersonExist(txtbNationalNo.Text.Trim()) && txtbNationalNo.Text.Trim() != _Person.NationalNo)
            {
                e.Cancel = true;
                txtbPhone.Focus();
                errorProvider1.SetError(txtbNationalNo, "This National Number is used by another person");
            } 
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNationalNo, null);
            }
        }
        private void txtbNationalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام أو زر Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // تجاهل أي مفتاح غير مسموح به
        }       
        private void txtbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.IsValidPhone(txtbPhone.Text.Trim()))
            {
                e.Cancel = true;
                txtbPhone.Focus();
                errorProvider1.SetError(txtbPhone, "Required, 11 Numbers, start with 010 or 011 or 012 or 015");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbPhone, "");
            }
        }
        private void txtbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام أو زر Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // تجاهل أي مفتاح غير مسموح به
        }
        
        private void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            //No need to validate the email incase it's empty or null
            if (txtbEmail.Text.Trim() == "")
                return;

            //Validate the email format
            if (!clsValidation.IsValidEmail(txtbEmail.Text.Trim()))
            {
                e.Cancel = true;
                txtbEmail.Focus();
                errorProvider1.SetError(txtbEmail, "Invalid Email, Example@gmail.com");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbEmail, null);
            }
        }

      
    }
}
