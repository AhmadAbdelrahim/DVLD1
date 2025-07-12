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
    public partial class frmManagePeople : Form
    {
        private int _personID { get; set; }

        clsPeopleBusiness _clsPeopleBusiness = new clsPeopleBusiness();

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dataGridView1.DataSource = clsPeopleBusiness.GetAllPeople();
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
        private void _ConfigureGridAppearance()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _ConfigureGridAppearance();
            _RefreshContactsList();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditInfoPerson addEditInfoPerson = new frmAddEditInfoPerson();
            addEditInfoPerson.ShowDialog();
            _RefreshContactsList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditInfoPerson addEditInfoPerson = new frmAddEditInfoPerson();
            addEditInfoPerson.ShowDialog();
            _RefreshContactsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditInfoPerson addEditInfoPerson = new frmAddEditInfoPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            addEditInfoPerson.ShowDialog();
            _RefreshContactsList();          
        }

       
    }
}
