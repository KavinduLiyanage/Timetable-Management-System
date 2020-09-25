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

namespace TimetableManagementSystem.Sessions
{
    public partial class Sessions : MetroFramework.Forms.MetroForm
    {
        public Sessions()
        {
            InitializeComponent();
        }

        SqlConnection con = Config.con;

        public String lecturers = "";
        public String tags = "";
        public String groups = "";
        public String subject = "";

        

        private void Sessions_Load(object sender, EventArgs e)
        {
            GetSessions();
            GetLecturers();
            GetTags();
            GetGroups();
            GetSubjects();
            GetLecturersToFilter();
            GetSubjectsToFilter();
            GetGroupsToFilter();
           
        }

        private void GetSessions()
        {
            SqlCommand cmd = new SqlCommand("Select * from Sessions", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            //dgvSessions.AutoGenerateColumns = false;
            dgvSessions.DataSource = dt;

            this.dgvSessions.Columns["SessionID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSessions.Columns["SubjectCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSessions.Columns["Duration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSessions.Columns["StudentCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void GetLecturers()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT LecName FROM Lecturers";

            cmd.ExecuteNonQuery();

            DataTable dtlecturers = new DataTable();

            SqlDataAdapter dalecturers = new SqlDataAdapter(cmd);

            dalecturers.Fill(dtlecturers);

            foreach (DataRow dr in dtlecturers.Rows)
            {
                cmbSessionLecturer.Items.Add(dr["LecName"].ToString());
            }

            con.Close();
        }

        public void GetTags()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT TagName FROM Tags";

            cmd.ExecuteNonQuery();

            DataTable dttags = new DataTable();

            SqlDataAdapter datags = new SqlDataAdapter(cmd);

            datags.Fill(dttags);

            foreach (DataRow dr in dttags.Rows)
            {
                cmbSessionTag.Items.Add(dr["TagName"].ToString());
            }

            con.Close();
        }

        public void GetGroups()
        {

            if (txtSelectedTags.Text == "Practical ")
            {
                con.Open();
                cmbSessionGroup.Items.Clear();
                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;

                cmd2.CommandText = "SELECT GenSubGrpNum FROM GenSubGroupNumber";

                cmd2.ExecuteNonQuery();

                DataTable dtgroups = new DataTable();

                SqlDataAdapter dagroups = new SqlDataAdapter(cmd2);

                dagroups.Fill(dtgroups);

                foreach (DataRow dr in dtgroups.Rows)
                {
                    cmbSessionGroup.Items.Add(dr["GenSubGrpNum"].ToString());
                }

                con.Close();
            }
            else
            {
                con.Open();
                cmbSessionGroup.Items.Clear();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT GenGrpNum FROM GenGroupNumber";

                cmd.ExecuteNonQuery();

                DataTable dtgroups = new DataTable();

                SqlDataAdapter dagroups = new SqlDataAdapter(cmd);

                dagroups.Fill(dtgroups);

                foreach (DataRow dr in dtgroups.Rows)
                {
                    cmbSessionGroup.Items.Add(dr["GenGrpNum"].ToString());
                }

                con.Close();
            }
        
        }

        public void GetSubjects()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT SubCode FROM Subjects";

            cmd.ExecuteNonQuery();

            DataTable dtsubjects = new DataTable();

            SqlDataAdapter dasubjects = new SqlDataAdapter(cmd);

            dasubjects.Fill(dtsubjects);

            foreach (DataRow dr in dtsubjects.Rows)
            {
                cmbSessionSubject.Items.Add(dr["SubCode"].ToString());
            }

            con.Close();
        }

        private void cmbSessionLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lecturers = lecturers + cmbSessionLecturer.Text + ", ";

            txtSelectedLecturers.Text = lecturers;        
        }

        private void cmbSessionTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            tags = tags + cmbSessionTag.Text + " ";

            txtSelectedTags.Text = tags;

            GetGroups();
        }

        private void cmbSessionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            groups = groups + cmbSessionGroup.Text + " ";

            txtSelectedGroups.Text = groups;
        }

        private void cmbSessionSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject = cmbSessionSubject.Text;

            if (subject != "")
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT SubName FROM Subjects Where SubCode = '" + subject + "'", con);

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                string data = reader["SubName"].ToString();

                reader.Close();

                con.Close();

                txtSelectedSubject.Text = data;
            }

            
        }

        private void txtSelectedTags_TextChanged(object sender, EventArgs e)
        {
            tags = txtSelectedTags.Text;
        }

        private void txtSelectedLecturers_TextChanged(object sender, EventArgs e)
        {
            lecturers = txtSelectedLecturers.Text;
        }

        private void txtSelectedGroups_TextChanged(object sender, EventArgs e)
        {
            groups = txtSelectedGroups.Text;
        }

        private void btnSessionSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Sessions VALUES (@Lecturer, @Subject, @SubjectCode, @Tag, @GroupID, @StudentCount, @Duration)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Lecturer", lecturers);
                cmd.Parameters.AddWithValue("@Subject", txtSelectedSubject.Text);
                cmd.Parameters.AddWithValue("@SubjectCode", cmbSessionSubject.Text);
                cmd.Parameters.AddWithValue("@Tag", tags);
                cmd.Parameters.AddWithValue("@GroupID", groups);    
                cmd.Parameters.AddWithValue("@StudentCount", nmudSessionNoStudents.Text);
                cmd.Parameters.AddWithValue("@Duration", nmudSessionDuration.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetSessions();

                ClearFieldsAfterAdd();

                tabControlLSessions.SelectedTab = tabPageSessionView;
            }
        }

        private bool IsValid()
        {
            if (cmbSessionLecturer.Text == string.Empty)
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearFieldsAfterAdd()
        {
            cmbSessionLecturer.SelectedIndex = -1;
            lecturers = "";
            txtSelectedLecturers.Clear();

            cmbSessionTag.SelectedIndex = -1;
            tags = "";
            txtSelectedTags.Clear();

            cmbSessionGroup.SelectedIndex = -1;
            groups = "";
            txtSelectedGroups.Clear();

            cmbSessionSubject.SelectedIndex = -1;
            txtSelectedSubject.Clear();

            nmudSessionNoStudents.Value = 0;

            nmudSessionDuration.Value = 0;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFieldsAfterAdd();

        }

        public void GetLecturersToFilter()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT LecName FROM Lecturers";

            cmd.ExecuteNonQuery();

            DataTable dtlecturers = new DataTable();

            SqlDataAdapter dalecturers = new SqlDataAdapter(cmd);

            dalecturers.Fill(dtlecturers);

            foreach (DataRow dr in dtlecturers.Rows)
            {
                cmbSesFilterLecturer.Items.Add(dr["LecName"].ToString());
            }

            con.Close();
        }

        public void GetSubjectsToFilter()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT SubName FROM Subjects";

            cmd.ExecuteNonQuery();

            DataTable dtsubjects = new DataTable();

            SqlDataAdapter dasubjects = new SqlDataAdapter(cmd);

            dasubjects.Fill(dtsubjects);

            foreach (DataRow dr in dtsubjects.Rows)
            {
                cmbSesFilterSubject.Items.Add(dr["SubName"].ToString());
            }

            con.Close();
        }

        public void GetGroupsToFilter()
        {
            con.Open();
            
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT GenGrpNum FROM GenGroupNumber";

            cmd.ExecuteNonQuery();

            DataTable dtgroups = new DataTable();

            SqlDataAdapter dagroups = new SqlDataAdapter(cmd);

            dagroups.Fill(dtgroups);

            foreach (DataRow dr in dtgroups.Rows)
            {
                cmbSesFilterGroup.Items.Add(dr["GenGrpNum"].ToString());
            }

            con.Close();
        }

        private void cmbSesFilterLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sessions where Lecturer like '%" + cmbSesFilterLecturer.Text + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvSessions.DataSource = dt;
            con.Close();
        }

        private void cmbSesFilterSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sessions where Subject like '%" + cmbSesFilterSubject.Text + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvSessions.DataSource = dt;
            con.Close();
        }

        private void cmbSesFilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sessions where GroupID like '%" + cmbSesFilterGroup.Text + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvSessions.DataSource = dt;
            con.Close();
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
            Sessions sessions = new Sessions();
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

        }


        //--------------------Side Nav Buttons--------------------

        private void btnSideNavWorking_Click(object sender, EventArgs e)
        {
            this.Hide();
            Working_Days.Add_Number_of_Working_Days workingDays = new Working_Days.Add_Number_of_Working_Days();
            workingDays.ShowDialog();
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
