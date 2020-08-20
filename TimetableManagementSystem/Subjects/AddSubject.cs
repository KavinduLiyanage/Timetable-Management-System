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
using TimetableManagementSystem.Lecturers;

namespace TimetableManagementSystem.Subjects
{
    public partial class AddSubject : MetroFramework.Forms.MetroForm
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        SqlConnection con = Config.con;

        public String SubCode;

        private void AddSubject_Load(object sender, EventArgs e)
        {
            GetSubjects();
        }

        private void GetSubjects()
        {
            SqlCommand cmd = new SqlCommand("Select * from Subjects", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dgvSubjects.AutoGenerateColumns = false;
            dgvSubjects.DataSource = dt;
        }

        private void btnSubSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Subjects VALUES (@SubCode, @SubName, @SubYear, @SubSem, @SubLecHours, @SubTuteHours, @SubLabHours, @SubEvaHours)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SubCode", txtSubCode.Text);
                cmd.Parameters.AddWithValue("@SubName", txtSubName.Text);
                cmd.Parameters.AddWithValue("@SubYear", cmbSubYear.Text);
                cmd.Parameters.AddWithValue("@SubSem", cmbSubSem.Text);
                cmd.Parameters.AddWithValue("@SubLecHours", cmbSubLecHours.Text);
                cmd.Parameters.AddWithValue("@SubTuteHours", cmbSubTuteHours.Text);
                cmd.Parameters.AddWithValue("@SubLabHours", cmbSubLabHours.Text);
                cmd.Parameters.AddWithValue("@SubEvaHours", cmbSubEvaHours.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetSubjects();

                ClearFieldsAfterAdd();

                tabControlSubjects.SelectedTab = tabPageSubView;
            }
        }

        private void ClearFieldsAfterAdd()
        {
            txtSubCode.Clear();
            txtSubName.Clear();
            cmbSubYear.SelectedIndex = -1;
            cmbSubSem.SelectedIndex = -1;
            cmbSubLecHours.SelectedIndex = -1;
            cmbSubTuteHours.SelectedIndex = -1;
            cmbSubLabHours.SelectedIndex = -1;
            cmbSubEvaHours.SelectedIndex = -1;
        }

        private bool IsValid()
        {
            if (txtSubCode.Text == string.Empty) 
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubClear_Click(object sender, EventArgs e)
        {
            ClearFieldsAfterAdd();
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SubCode = dgvSubjects.SelectedRows[0].Cells[0].Value.ToString();
            txtSubCodeEdit.Text = dgvSubjects.SelectedRows[0].Cells[0].Value.ToString();
            txtSubNameEdit.Text = dgvSubjects.SelectedRows[0].Cells[1].Value.ToString();
            cmbSubYearEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[2].Value;
            cmbSubSemEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[3].Value;
            cmbSubLecHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[4].Value;
            cmbSubTuteHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[5].Value;
            cmbSubLabHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[6].Value;
            cmbSubEvaHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[7].Value;

            tabControlSubjects.SelectedTab = tabPageSubEdit;

        }

        //----Side Nav Buttons----
        private void btnSideNavLecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lecturers.AddLecturer addLecturer = new Lecturers.AddLecturer();
            addLecturer.ShowDialog();
        }

        private void btnSideNavSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableManagementSystem.Subjects.AddSubject addSubject = new TimetableManagementSystem.Subjects.AddSubject();
            addSubject.ShowDialog();
        }

        //----Header Buttons----
        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }

        
    }
}
