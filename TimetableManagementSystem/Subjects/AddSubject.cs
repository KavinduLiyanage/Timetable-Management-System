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
using TimetableManagementSystem.Tags;

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
        public int SubCodeValue = 0;


        private void AddSubject_Load(object sender, EventArgs e)
        {
            GetSubjects();
            tabControlSubjects.SelectedTab = tabPageSubView;
        }

        private void GetSubjects()
        {
            SqlCommand cmd = new SqlCommand("Select * from Subjects order by SubYear", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dgvSubjects.AutoGenerateColumns = false;
            dgvSubjects.DataSource = dt;

            this.dgvSubjects.Columns["SubName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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
            if ((txtSubCode.Text == string.Empty) || (txtSubName.Text == string.Empty)
                || (cmbSubYear.Text == string.Empty) || (cmbSubSem.Text == string.Empty) || (cmbSubLecHours.Text == string.Empty)
                || (cmbSubTuteHours.Text == string.Empty) || (cmbSubLabHours.Text == string.Empty) || (cmbSubEvaHours.Text == string.Empty))
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
            cmbSubLecHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[4].Value.ToString();
            cmbSubTuteHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[5].Value.ToString();
            cmbSubLabHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[6].Value.ToString();
            cmbSubEvaHoursEdit.SelectedItem = dgvSubjects.SelectedRows[0].Cells[7].Value.ToString();
            SubCodeValue = 1;
            tabControlSubjects.SelectedTab = tabPageSubEdit;

        }

        private void btnSubUpdate_Click(object sender, EventArgs e)
        {
            if (SubCodeValue > 0)
            {
                if (IsValidUpdate())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Subjects SET SubCode = @SubCodenew, SubName = @SubName, SubYear = @SubYear, SubSem = @SubSem, SubLecHours = @SubLecHours, SubTuteHours = @SubTuteHours, SubLabHours = @SubLabHours, SubEvaHours = @SubEvaHours WHERE SubCode = @SubCode", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@SubCodenew", txtSubCodeEdit.Text);
                    cmd.Parameters.AddWithValue("@SubName", txtSubNameEdit.Text);
                    cmd.Parameters.AddWithValue("@SubYear", cmbSubYearEdit.Text);
                    cmd.Parameters.AddWithValue("@SubSem", cmbSubSemEdit.Text);
                    cmd.Parameters.AddWithValue("@SubLecHours", cmbSubLecHoursEdit.Text);
                    cmd.Parameters.AddWithValue("@SubTuteHours", cmbSubTuteHoursEdit.Text);
                    cmd.Parameters.AddWithValue("@SubLabHours", cmbSubLabHoursEdit.Text);
                    cmd.Parameters.AddWithValue("@SubEvaHours", cmbSubEvaHoursEdit.Text);
                    cmd.Parameters.AddWithValue("@SubCode", this.SubCode);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Subject Details Updated", "Successfully");

                    GetSubjects();

                    ClearFieldsAfterUpdate();

                    tabControlSubjects.SelectedTab = tabPageSubView;
                }             
            }
            else
            {
                MessageBox.Show("Please Select a Subject to Update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidUpdate()
        {
            if ((txtSubCodeEdit.Text == string.Empty) || (txtSubNameEdit.Text == string.Empty)
                || (cmbSubYearEdit.Text == string.Empty) || (cmbSubSemEdit.Text == string.Empty) || (cmbSubLecHoursEdit.Text == string.Empty)
                || (cmbSubTuteHoursEdit.Text == string.Empty) || (cmbSubLabHoursEdit.Text == string.Empty) || (cmbSubEvaHoursEdit.Text == string.Empty))
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearFieldsAfterUpdate()
        {
            txtSubCodeEdit.Clear();
            txtSubNameEdit.Clear();
            cmbSubYearEdit.SelectedIndex = -1;
            cmbSubSemEdit.SelectedIndex = -1;
            cmbSubLecHoursEdit.SelectedIndex = -1;
            cmbSubTuteHoursEdit.SelectedIndex = -1;
            cmbSubLabHoursEdit.SelectedIndex = -1;
            cmbSubEvaHoursEdit.SelectedIndex = -1;
            SubCodeValue = 0;
        }

        private void btnSubDelete_Click(object sender, EventArgs e)
        {
            if (SubCodeValue > 0)
            {

                if (MessageBox.Show("Are You Sure You Want to Delete the Subject?", "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Subjects WHERE SubCode = @SubCode", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@SubCode", this.SubCode);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Subject is Deleted", "Successfully");

                    GetSubjects();

                    ClearFieldsAfterUpdate();

                    tabControlSubjects.SelectedTab = tabPageSubView;
                }

            }
            else
            {
                MessageBox.Show("Please Select a Subject to Delete ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSubSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSubSearch.Text != "")
            {
                cmbSubFilterYear.SelectedIndex = -1;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Subjects where SubName like '%" + txtSubSearch.Text + "%' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvSubjects.DataSource = dt;
                con.Close();
            }
            else if(txtSubSearch.Text == "")
            {
                GetSubjects();
            }
        }

        private void cmbSubFilterYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSubFilterYear.Text != "")
            {
                txtSubSearch.Clear();

                if (cmbSubFilterYear.Text == "Clear")
                {
                    cmbSubFilterYear.SelectedIndex = -1;
                }

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Subjects where SubYear like '%" + cmbSubFilterYear.Text + "%' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvSubjects.DataSource = dt;
                con.Close();
            }          
        }

        private void tabControlSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlSubjects.SelectedTab.Name == "tabPageSubEdit")
            {
                if (SubCodeValue == 0)
                {
                    MessageBox.Show("Please select a subject in subjects list ", "No subject selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlSubjects.SelectedTab = tabPageSubView;
                }
            }
        }

        //--------------------Header Buttons--------------------
        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }

        private void btnHeaderSessions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sessions.Sessions sessions = new Sessions.Sessions();
            sessions.ShowDialog();
        }

        private void btnHeaderRooms_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rooms.Rooms rooms = new Rooms.Rooms();
            rooms.ShowDialog();
        }

        private void btnHeaderAdvanced_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdvancedOp.Advanced advc = new AdvancedOp.Advanced();
            advc.ShowDialog();
        }

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerateTimetable.GenerateTimetable generatetimetable = new GenerateTimetable.GenerateTimetable();
            generatetimetable.ShowDialog();
        }

        //--------------------Side Nav Buttons--------------------
        private void btnSideNavWorking_Click(object sender, EventArgs e)
        {
            int TimetableType = -1;
            try
            {
                using (Form1 form = new Form1())
                {
                    form.ShowDialog();
                    TimetableType = form.getText();
                    if (!form.getClose())
                    {
                        Working_Days.Add_Number_of_Working_Days workingDays = new Working_Days.Add_Number_of_Working_Days(TimetableType);
                        this.Hide();
                        workingDays.ShowDialog();
                    }
                }
            }

            catch (Exception)
            {

            }
        }

        private void btnSideNavLecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lecturers.AddLecturer addLecturer = new Lecturers.AddLecturer();
            addLecturer.ShowDialog();
        }

        private void btnSideNavSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects.AddSubject addSubject = new Subjects.AddSubject();
            addSubject.ShowDialog();
        }

        private void btnSideNavStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students.Students stu = new Students.Students();
            stu.ShowDialog();
        }

        private void btnSideNavTags_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tags.Tags tag = new Tags.Tags();
            tag.ShowDialog();
        }

        private void btnSideNavLocations_Click(object sender, EventArgs e)
        {
            this.Hide();
            Locations.Location loc = new Locations.Location();
            loc.ShowDialog();
        }

        private void btnSideNavStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistics.Statistics stat = new Statistics.Statistics();
            stat.ShowDialog();
        }
    }
}
