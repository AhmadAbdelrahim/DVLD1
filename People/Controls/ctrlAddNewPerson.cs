using DVLD1_BusinessLayer;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    public partial class ctrlAddNewPerson : UserControl
    {
        private string lastSavedImagePath = null;

        public enum enMode { AddNewMode = 1, UpdateMode = 2 }
        public enum enGender { Male = 0, Female = 1}

        enMode _Mode;
        enGender _Gender;

        int _PersonID = -1;
        clsPeopleBusiness _people;
            
        public ctrlAddNewPerson()
        {
            InitializeComponent();
     
            if (_PersonID == -1)
                _Mode = enMode.AddNewMode;
            else
                _Mode = enMode.UpdateMode;
        }
    
        private void _FillAllCountriesInComboBox()
        {           
            DataTable dtCountries = clsCountriesBusiness.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
           
        }

        public void _LoadData()
        {
            _FillAllCountriesInComboBox();

            cbCountry.SelectedIndex = 50;

            if (_Mode == enMode.AddNewMode)
            {
                lblMode.Text = "Add New Person";
                _people = new clsPeopleBusiness();
                return;
            }

            _people = clsPeopleBusiness.Find(_PersonID);

            if (_people == null)
            {
                MessageBox.Show("Person Not Found");
                //this.Close();
                return;
            }

            lblMode.Text = "Update Person";
            lblPersonID.Text = _people.PersonID.ToString();

            txtbFirstName.Text = _people.FirstName;
            txtbSecondName.Text = _people.SecondName;
            txtbThirdName.Text = _people.ThirdName;
            txtbLastName.Text = _people.LastName;
            if (_people.Gender == 'M')
                rdbMale.Checked = true;
            if (_people.Gender == 'F')
                rdbFemale.Checked = true;
            dateTimePicker1.Value = _people.DateOfBirth;
            txtbPhone.Text = _people.Phone;
            txtbEmail.Text = _people.Email;

            if (_people.ImagePath != "")
            {
                pictureBox1.Load(_people.ImagePath);
            }

            lnklblRemove.Visible = (_people.ImagePath != "");

            // this will select the country in the Combobox
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountriesBusiness.Find(_people.Nationality).CountryName);
        }
        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {
            // منع اختيار تاريخ الميلاد إذا كان أصغر من 18 سنة
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            rdbMale.Checked = true;

            _LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountriesBusiness.Find(cbCountry.Text).CountryID;

            _people.NationalNo = txtbNationalNo.Text;

            _people.FirstName = txtbFirstName.Text;
            _people.SecondName = txtbSecondName.Text;
            _people.ThirdName = txtbThirdName.Text;
            _people.LastName = txtbLastName.Text;
            _people.Gender = (rdbMale.Checked) ? (short)enGender.Male : (short)enGender.Female;
            _people.Email = txtbEmail.Text;
            _people.Phone = txtbPhone.Text;
            _people.Address = txtbAddress.Text;
            _people.DateOfBirth = dateTimePicker1.Value;
            _people.Nationality = CountryID;

            if (pictureBox1.ImageLocation != null)
                _people.ImagePath = pictureBox1.ImageLocation;            
            else
                _people.ImagePath = "";
            
            if (_people.Save())
                MessageBox.Show("Person Info saved successfully", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            else
                MessageBox.Show("Error saving Person Info", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            _Mode = enMode.UpdateMode;
            lblMode.Text = "Edit Contact";
            lblPersonID.Text = _people.PersonID.ToString();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog1.FileName;

                string fileExtension = Path.GetExtension(sourcePath);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;

                string destinationFolder = @"C:\DVDL1-Photos";

                // إنشاء المجلد إذا لم يكن موجودًا
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // حذف الصورة السابقة إذا وُجدت
                if (!string.IsNullOrEmpty(lastSavedImagePath) && File.Exists(lastSavedImagePath))
                {
                    try
                    {
                        File.Delete(lastSavedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("تعذر حذف الصورة القديمة:\n" + ex.Message);
                    }
                }

                // تحديد مسار الصورة الجديدة
                string targetPath = Path.Combine(destinationFolder, newFileName);

                try
                {
                    File.Copy(sourcePath, targetPath, true);
                    lastSavedImagePath = targetPath;

                    MessageBox.Show("تم استبدال الصورة بنجاح!");
                    pictureBox1.Load(targetPath);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("حدث خطأ أثناء النسخ:\n" + ex.Message);
                }
            }
        }
        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            lnklblRemove.Visible = false;
        }
        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMale.Checked)
                pictureBox1.Image = Properties.Resources.UnknownMan72;
        }
        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFemale.Checked)
                pictureBox1.Image = Properties.Resources.UnknownFemale72;
        }

        //Validation
        private void CheckAllFields()
        {
            bool isEmailValid = IsValidEmail(txtbEmail.Text.Trim());
            bool NationalNoValid = IsNationalNo(txtbNationalNo.Text.Trim());

            bool FirstNameValid = !string.IsNullOrEmpty(txtbFirstName.Text);
            bool LasttNameValid = !string.IsNullOrEmpty(txtbLastName.Text);
            bool emailValid = !string.IsNullOrEmpty(txtbEmail.Text) && isEmailValid;
            bool phoneValid = txtbPhone.Text.Length == 11;

            btnSave.Enabled = NationalNoValid && FirstNameValid && LasttNameValid && phoneValid && emailValid;
        }

        private void txtbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtbFirstName.Text == "")
            {
                e.Cancel = true;
                txtbFirstName.Focus();
                errorProvider1.SetError(txtbFirstName, "First Name is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbFirstName, "");
            }
        }
        private void txtbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtbLastName.Text == "")
            {
                e.Cancel = true;
                txtbFirstName.Focus();
                errorProvider1.SetError(txtbLastName, "Last Name is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbLastName, "");
            }
        }              

        private bool IsNationalNo(string nationalNo)
        {
            if (!string.IsNullOrWhiteSpace(nationalNo)
                && nationalNo.Length == 14
                && nationalNo.All(char.IsDigit))
                return true;
            else
                return false;
        }
        private void txtbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNationalNo(txtbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                txtbPhone.Focus();
                errorProvider1.SetError(txtbNationalNo, "Required, 14 Numbers");
            }
            else if (clsPeopleBusiness.IsPersonExist(txtbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                txtbPhone.Focus();
                errorProvider1.SetError(txtbNationalNo, "This National Number Is Already Exists");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNationalNo, "");
            }
        }
        private void txtbNationalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام أو زر Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // تجاهل أي مفتاح غير مسموح به
        }

        private bool IsValidPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone)
                && phone.Length == 11
                && phone.All(char.IsDigit)
                && (phone.StartsWith("010")
                   || phone.StartsWith("011")
                   || phone.StartsWith("012")
                   || phone.StartsWith("015")))
                return true;
            else
                return false;
        }
        private void txtbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidPhone(txtbPhone.Text.Trim()))
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

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$";
            return Regex.IsMatch(email, pattern);
        }
        private void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(txtbEmail.Text.Trim()) && !string.IsNullOrEmpty(txtbEmail.Text.Trim()))
            {
                e.Cancel = true;
                txtbEmail.Focus();
                errorProvider1.SetError(txtbEmail, "Example@gmail.com");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbEmail, "");
            }
        }
    }
}