using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD1
{
    public partial class frmManageUsers : Form
    {
        private Timer _searchTimer;
        private string Username { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        private string searchTerm { get; set; } // for radioButton3.Checked

        private clsUsersBusiness _currentUser;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void CountRows()
        {
            int Count = dataGridView1.Rows.Count;
            lblCount.Text = $"[{Count.ToString()}] User(s) Found";
        }

        private void _RefreshEmployeesList()
        {
            dataGridView1.DataSource = clsUsersBusiness.GetAllUsers();
            //dataGridView1.Columns[0].Visible = false; // إخفاء العمود الأول (ID)
            CountRows();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.CellClick += dataGridView1_CellClick;

            _RefreshEmployeesList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                textBox1.Visible = false;
            else
                textBox1.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // إعادة تعيين لون جميع رؤوس الأعمدة للون الافتراضي
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.BlueViolet;
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            // إذا كان هناك خلية حالية صالحة
            if (e.ColumnIndex >= 0)
            {
                // تلوين رأس العمود الذي حُددت إحدى خلاياه
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.Yellow;
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.Style.ForeColor = Color.Black;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addupdateuser = new frmAddUpdateUser();

            addupdateuser.ShowDialog();
        }
    }
}
