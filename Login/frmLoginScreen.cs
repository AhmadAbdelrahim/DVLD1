using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace DVLD1
{
    public partial class frmLoginScreen : Form
    {     
        private Timer _lockoutTimer;

        private int _remainingSeconds;

        private bool _isPasswordVisible = false;

        private int _loginAttempts = 0;

        private DateTime _lockoutEndTime;

        //clsEncryptionDecryption _encryption;

        public string Username { get; private set; }
        public string Password { get; private set; }

        public frmLoginScreen()
        {
            InitializeComponent();
            //SetPlaceholder();

            //_encryption = new clsEncryptionDecryption();

            lblError.Text = " Please Enter Username and Password.";
            lblError.Visible = false; // إخفاء رسالة الخطأ في البداية
        }

        private void SetPlaceholder()
        {
            txtbUsername.Text = "Enter Username...";
            txtbUsername.ForeColor = Color.Gray;
            txtbPassword.Text = "Enter Password...";
            txtbPassword.ForeColor = Color.Gray;
        }

        /*
        private void InitializeEyeIcon()
        {
            // إعداد PictureBox داخل txtPassword
            pbEye.Image = Properties.Resources.hide; // أيقونة مغلقة في البداية
            pbEye.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEye.Size = new Size(22, 22);
            pbEye.Cursor = Cursors.Hand;
            pbEye.BackColor = Color.Transparent;
            pbEye.Location = new Point(txtbPassword.Width - pbEye.Width - 5, (txtbPassword.Height - pbEye.Height) / 2);
            txtbPassword.Controls.Add(pbEye);
            pbEye.BringToFront();

            // تعديل Padding لمنع النص من التداخل مع الأيقونة
            txtbPassword.Padding = new Padding(0, 0, pbEye.Width + 5, 0);
        }
        */

        private void _LoadData()
        {
            try
            {
                // تغيير شكل المؤشر إلى "انتظار"
                Cursor = Cursors.WaitCursor;

                if (DateTime.Now < _lockoutEndTime)
                {
                    lblError.Text = $"Too many failed attempts. Try again after {_remainingSeconds} seconds.";
                    lblError.Visible = true;
                    return;
                }

                Username = txtbUsername.Text.Trim();
                Password = txtbPassword.Text.Trim();

                //Password = _encryption.EncryptText(txtbPassword.Text.Trim());

                clsUsersBusiness _currentUser = clsUsersBusiness.Find(Username, Password);

                if (_currentUser == null || _currentUser.IsEmpty())
                {
                    _loginAttempts++;

                    if (_loginAttempts >= 3)
                    {
                        _lockoutEndTime = DateTime.Now.AddSeconds(15);
                        _remainingSeconds = 15;

                        // عرض العد التنازلي فورًا
                        lblError.Text = $"Too many failed attempts. Try again after {_remainingSeconds} seconds.";
                        lblError.Visible = true;

                        // بدء المؤقت
                        if (_lockoutTimer != null)
                        {
                            _lockoutTimer.Stop();
                            _lockoutTimer.Dispose();
                        }

                        _lockoutTimer = new Timer();
                        _lockoutTimer.Interval = 1000; // كل ثانية
                        _lockoutTimer.Tick += LockoutTimer_Tick;
                        _lockoutTimer.Start();
                    }
                    else
                    {
                        lblError.Text = $"Invalid Username or Password... Attempt {_loginAttempts} of 3.";
                        lblError.Visible = true;
                    }

                    txtbPassword.Clear();
                    txtbUsername.Focus();
                    return;
                }

                // Reset attempts on successful login
                _loginAttempts = 0;
                lblError.Visible = false;

                

                Session.Username = _currentUser.Username;
                frmMainScreen MainScreen = new frmMainScreen();

                MainScreen.Show();
                this.Hide();
            }
            finally
            {
                // إرجاع شكل المؤشر إلى الوضع الطبيعي
                Cursor = Cursors.Default;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;

            if (_remainingSeconds <= 0)
            {
                _lockoutTimer.Stop();
                _lockoutTimer.Dispose();
                _lockoutTimer = null;

                lblError.Text = "You can try logging in again.";
            }
            else
            {
                lblError.Text = $"Too many failed attempts. Try again after {_remainingSeconds} seconds.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // إغلاق التطبيق بالكامل
        }

        private void txtbPassword_Enter(object sender, EventArgs e)
        {
            if (txtbPassword.Text != null)
            {
                txtbPassword.UseSystemPasswordChar = true; // إظهار النص كنجوم
            }
        }

        /*
        private void pbEye_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible)
            {
                pbEye.Image = Properties.Resources.view; // أيقونة مفتوحة
                txtbPassword.UseSystemPasswordChar = false; // إظهار النص
            }
            else
            {
                pbEye.Image = Properties.Resources.hide; // أيقونة مغلقة
                txtbPassword.UseSystemPasswordChar = true; // إخفاء النص
            }
        }
        */

        private void frmLoginScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }        
      
        private void txtbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbUsername.Text.Trim()))
            {
                e.Cancel = true; // منع الخروج من الحقل
                txtbUsername.Focus();
                errorProvider1.SetError(txtbUsername, "Required...");
            }
            else
            {
                e.Cancel = false; // السماح بالخروج من الحقل
                errorProvider1.SetError(txtbUsername, ""); // إزالة رسالة الخطأ
            }
        }

        private void txtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtbPassword.Focus();
                errorProvider1.SetError(txtbPassword, "Required...");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbPassword, "");
            }
        }
    }
}
