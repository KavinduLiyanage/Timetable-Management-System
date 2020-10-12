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
using TimetableManagementSystem.Tags;

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
        public int SID;
        public String tagEdit = "";
        public String lecturersEdit = "";
        public String tagsEdit = "";
        public String groupsEdit = "";
        public String subjectEdit = "";

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
            
            tabControlLSessions.SelectedTab = tabPageSessionView;
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

            cmd.CommandText = "SELECT LecName FROM Lecturers order by LecName";

            cmd.ExecuteNonQuery();

            DataTable dtlecturers = new DataTable();

            SqlDataAdapter dalecturers = new SqlDataAdapter(cmd);

            dalecturers.Fill(dtlecturers);

            foreach (DataRow dr in dtlecturers.Rows)
            {
                cmbSessionLecturer.Items.Add(dr["LecName"].ToString());
            }

            foreach (DataRow dr in dtlecturers.Rows)
            {
                cmbSessionLecturerEdit.Items.Add(dr["LecName"].ToString()+", ");
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

            foreach (DataRow dr in dttags.Rows)
            {
                cmbSessionTagEdit.Items.Add(dr["TagName"].ToString());
            }

            con.Close();
        }

        public void GetGroups()
        {

            if (cmbSessionTag.Text == "Practical")
            {
                con.Open();
                cmbSessionGroup.Items.Clear();
                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;

                cmd2.CommandText = "SELECT GenSubGrpNum FROM GenSubGroupNumber order by GenSubGrpNum";

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

                cmd.CommandText = "SELECT GenGrpNum FROM GenGroupNumber order by GenGrpNum";

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

            cmd.CommandText = "SELECT SubCode, SubYear FROM Subjects order by SubYear";

            cmd.ExecuteNonQuery();

            DataTable dtsubjects = new DataTable();

            SqlDataAdapter dasubjects = new SqlDataAdapter(cmd);

            dasubjects.Fill(dtsubjects);

            foreach (DataRow dr in dtsubjects.Rows)
            {
                cmbSessionSubject.Items.Add(dr["SubCode"].ToString());
            }

            foreach (DataRow dr in dtsubjects.Rows)
            {
                cmbSessionSubjectEdit.Items.Add(dr["SubCode"].ToString());
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
            //tags = tags + cmbSessionTag.Text + " ";

            //txtSelectedTags.Text = tags;

            GetGroups();
        }

        private void cmbSessionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //groups = groups + cmbSessionGroup.Text + " ";

            //txtSelectedGroups.Text = groups;
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
            //tags = txtSelectedTags.Text;
        }

        private void txtSelectedLecturers_TextChanged(object sender, EventArgs e)
        {
            lecturers = txtSelectedLecturers.Text;
        }

        private void txtSelectedGroups_TextChanged(object sender, EventArgs e)
        {
            //groups = txtSelectedGroups.Text;
        }

        //----------Clear Lables----------
        private void lblClearLecs_Click(object sender, EventArgs e)
        {
            cmbSessionLecturer.SelectedIndex = -1;
            txtSelectedLecturers.Clear();           
        }

        private void lblClearTags_Click(object sender, EventArgs e)
        {
            //cmbSessionTag.SelectedIndex = -1;
            //txtSelectedTags.Clear();
        }

        private void lblClearGroups_Click(object sender, EventArgs e)
        {
            //cmbSessionGroup.SelectedIndex = -1;
            //txtSelectedGroups.Clear();
        }

        private void lblClearSubs_Click(object sender, EventArgs e)
        {
            //cmbSessionSubject.SelectedIndex = -1;
            //txtSelectedSubject.Clear();
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
                cmd.Parameters.AddWithValue("@Tag", cmbSessionTag.Text);
                cmd.Parameters.AddWithValue("@GroupID", cmbSessionGroup.Text);    
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
            if ((lecturers == string.Empty) || (cmbSessionTag.Text == string.Empty) || (cmbSessionGroup.Text == string.Empty) || 
                (txtSelectedSubject.Text == string.Empty) || (cmbSessionSubject.Text == string.Empty) ||
                (Int32.Parse(nmudSessionNoStudents.Text) == 0) || (Int32.Parse(nmudSessionDuration.Text) == 0))
            {
                MessageBox.Show("Please fill the all fields", "Adding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //tags = "";
            //txtSelectedTags.Clear();

            cmbSessionGroup.SelectedIndex = -1;
            //groups = "";
            //txtSelectedGroups.Clear();

            cmbSessionSubject.SelectedIndex = -1;
            txtSelectedSubject.Clear();

            nmudSessionNoStudents.Value = 0;

            nmudSessionDuration.Value = 0;

            SID = 0;

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

            cmd.CommandText = "SELECT LecName FROM Lecturers order by LecName";

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

            cmd.CommandText = "SELECT SubName, SubYear FROM Subjects order by SubYear";

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

            cmd.CommandText = "SELECT GenGrpNum FROM GenGroupNumber order by GenGrpNum";

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
            /*
            if (cmbSesFilterLecturer.Text == "Clear")
            {
                cmbSesFilterLecturer.SelectedIndex = -1;
            }
            */

            if (cmbSesFilterLecturer.Text != "")
            {
                cmbSesFilterSubject.SelectedIndex = -1;
                cmbSesFilterGroup.SelectedIndex = -1;

                if (cmbSesFilterLecturer.Text == "Clear Selected Lecturer")
                {
                    cmbSesFilterLecturer.SelectedIndex = -1;
                }

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
        }

        private void cmbSesFilterSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSesFilterSubject.Text != "")
            {
                cmbSesFilterLecturer.SelectedIndex = -1;
                cmbSesFilterGroup.SelectedIndex = -1;

                if (cmbSesFilterSubject.Text == "Clear Selected Subject")
                {
                    cmbSesFilterSubject.SelectedIndex = -1;
                }

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
        }

        private void cmbSesFilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSesFilterGroup.Text != "")
            {
                cmbSesFilterLecturer.SelectedIndex = -1;
                cmbSesFilterSubject.SelectedIndex = -1;

                if (cmbSesFilterGroup.Text == "Clear Selected")
                {
                    cmbSesFilterGroup.SelectedIndex = -1;
                }

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
        }

        private void dgvSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ClearFieldsAfterUpdate();

            cmbSessionLecturerEdit.SelectedIndex = -1;
            lecturersEdit = "";
            txtSelectedLecturersEdit.Clear();

            SID = Convert.ToInt32(dgvSessions.SelectedRows[0].Cells[0].Value);

            txtSelectedLecturersEdit.Text = dgvSessions.SelectedRows[0].Cells[1].Value.ToString();
            
            cmbSessionLecturerEdit.SelectedItem = dgvSessions.SelectedRows[0].Cells[1].Value;

            lecturersEdit = dgvSessions.SelectedRows[0].Cells[1].Value.ToString();

            /*
            if (cmbSessionLecturerEdit.SelectedItem.ToString().Equals(dgvSessions.SelectedRows[0].Cells[1].Value.ToString()))
            { }
            else
            {
                cmbSessionLecturerEdit.SelectedIndex = -1;
            }
            */

            txtSelectedSubjectEdit.Text = dgvSessions.SelectedRows[0].Cells[2].Value.ToString();
            cmbSessionSubjectEdit.SelectedItem = dgvSessions.SelectedRows[0].Cells[3].Value;

            //tagEdit = dgvSessions.SelectedRows[0].Cells[4].Value.ToString();

            cmbSessionTagEdit.SelectedItem = dgvSessions.SelectedRows[0].Cells[4].Value;
            
            //txtSelectedTagsEdit.Text = dgvSessions.SelectedRows[0].Cells[4].Value.ToString();
            //tagsEdit = dgvSessions.SelectedRows[0].Cells[4].Value.ToString();

            //txtSelectedGroupsEdit.Text = dgvSessions.SelectedRows[0].Cells[5].Value.ToString();
            cmbSessionGroupEdit.SelectedItem = dgvSessions.SelectedRows[0].Cells[5].Value;

            nmudSessionNoStudentsEdit.Value = Convert.ToInt32(dgvSessions.SelectedRows[0].Cells[6].Value);
            nmudSessionDurationEdit.Value = Convert.ToInt32(dgvSessions.SelectedRows[0].Cells[7].Value);

            tabControlLSessions.SelectedTab = tabPageSessionEdit;

        }

        private void cmbSessionLecturerEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lecturersEdit = lecturersEdit + cmbSessionLecturerEdit.Text;

            txtSelectedLecturersEdit.Text = lecturersEdit;
        }

        private void cmbSessionTagEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tagsEdit = tagsEdit + cmbSessionTagEdit.Text + " ";

            //txtSelectedTagsEdit.Text = tagsEdit;

            GetGroupsToUpdate();
            cmbSessionGroupEdit.SelectedIndex = -1;
        }

        private void cmbSessionGroupEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //groupsEdit = groupsEdit + cmbSessionGroupEdit.Text;

            //txtSelectedGroupsEdit.Text = groupsEdit;
        }

        public void GetGroupsToUpdate()
        {

            if (cmbSessionTagEdit.Text == "Practical")
            {
                con.Open();
                cmbSessionGroupEdit.Items.Clear();
                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;

                cmd2.CommandText = "SELECT GenSubGrpNum FROM GenSubGroupNumber order by GenSubGrpNum";

                cmd2.ExecuteNonQuery();

                DataTable dtgroups = new DataTable();

                SqlDataAdapter dagroups = new SqlDataAdapter(cmd2);

                dagroups.Fill(dtgroups);

                foreach (DataRow dr in dtgroups.Rows)
                {
                    cmbSessionGroupEdit.Items.Add(dr["GenSubGrpNum"].ToString());
                }

                con.Close();
            }
            else
            {
                con.Open();
                cmbSessionGroupEdit.Items.Clear();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT GenGrpNum FROM GenGroupNumber order by GenGrpNum";

                cmd.ExecuteNonQuery();

                DataTable dtgroups = new DataTable();

                SqlDataAdapter dagroups = new SqlDataAdapter(cmd);

                dagroups.Fill(dtgroups);

                foreach (DataRow dr in dtgroups.Rows)
                {
                    cmbSessionGroupEdit.Items.Add(dr["GenGrpNum"].ToString());
                }

                con.Close();
            }
        }

        private void cmbSessionSubjectEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            subjectEdit = cmbSessionSubjectEdit.Text;

            if (subjectEdit != "")
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT SubName FROM Subjects Where SubCode = '" + subjectEdit + "'", con);

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                string data = reader["SubName"].ToString();

                reader.Close();

                con.Close();

                txtSelectedSubjectEdit.Text = data;
            }
        }

        private void ClearFieldsAfterUpdate()
        {
            cmbSessionLecturerEdit.SelectedIndex = -1;
            lecturersEdit = "";
            txtSelectedLecturersEdit.Clear();

            cmbSessionTagEdit.SelectedIndex = -1;
            //tagsEdit = "";
            //txtSelectedTagsEdit.Clear();

            cmbSessionGroupEdit.SelectedIndex = -1;
            //groupsEdit = "";
            //txtSelectedGroupsEdit.Clear();

            cmbSessionSubjectEdit.SelectedIndex = -1;
            txtSelectedSubjectEdit.Clear();

            nmudSessionNoStudentsEdit.Value = 0;

            nmudSessionDurationEdit.Value = 0;

            SID = 0;

        }

        private void lblClearLecsEdit_Click(object sender, EventArgs e)
        {
            cmbSessionLecturerEdit.SelectedIndex = -1;
            txtSelectedLecturersEdit.Clear();
            lecturersEdit = "";
        }

        private void lblClearTagsEdit_Click(object sender, EventArgs e)
        {
            //cmbSessionTagEdit.SelectedIndex = -1;
            //txtSelectedTagsEdit.Clear();
            //tagsEdit = "";
        }

        private void lblClearGroupsEdit_Click(object sender, EventArgs e)
        {
            //cmbSessionGroupEdit.SelectedIndex = -1;
            //txtSelectedGroupsEdit.Clear();
            //groupsEdit = "";
        }

        private void lblClearSubsEdit_Click(object sender, EventArgs e)
        {
            //cmbSessionSubjectEdit.SelectedIndex = -1;
            //txtSelectedSubjectEdit.Clear();
        }

        private void btnSessionUpdate_Click(object sender, EventArgs e)
        {
            if (SID > 0)
            {
                if (IsValidUpdate())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Sessions SET Lecturer = @Lecturer, Subject = @Subject, SubjectCode = @SubjectCode, Tag = @Tag, GroupID = @GroupID, StudentCount = @StudentCount, Duration = @Duration WHERE SessionID = @SID", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Lecturer", lecturersEdit);
                    cmd.Parameters.AddWithValue("@Subject", txtSelectedSubjectEdit.Text);
                    cmd.Parameters.AddWithValue("@SubjectCode", cmbSessionSubjectEdit.Text);
                    cmd.Parameters.AddWithValue("@Tag", cmbSessionTagEdit.Text);
                    cmd.Parameters.AddWithValue("@GroupID", cmbSessionGroupEdit.Text);
                    cmd.Parameters.AddWithValue("@StudentCount", nmudSessionNoStudentsEdit.Text);
                    cmd.Parameters.AddWithValue("@Duration", nmudSessionDurationEdit.Text);

                    cmd.Parameters.AddWithValue("@SID", this.SID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Session Details Updated", "Successfully");

                    GetSessions();

                    ClearFieldsAfterUpdate();

                    tabControlLSessions.SelectedTab = tabPageSessionView;
                }
               
            }
            else
            {
                MessageBox.Show("Please Select a session to Update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidUpdate()
        {
            if ((lecturersEdit == string.Empty) || (cmbSessionTagEdit.Text == string.Empty) || (cmbSessionGroupEdit.Text == string.Empty) ||
                (txtSelectedSubjectEdit.Text == string.Empty) || (cmbSessionSubjectEdit.Text == string.Empty) ||
                (Int32.Parse(nmudSessionNoStudentsEdit.Text) == 0) || (Int32.Parse(nmudSessionDurationEdit.Text) == 0))
            {
                MessageBox.Show("Please fill the all fields", "Updating Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSessionDelete_Click(object sender, EventArgs e)
        {
            if (SID > 0)
            {
                if (MessageBox.Show("Are You Sure You Want to Delete the Session?", "Delete Session", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sessions WHERE SessionID = @SID", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@SID", this.SID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Session is Deleted", "Successfully");

                    GetSessions();

                    ClearFieldsAfterUpdate();

                    tabControlLSessions.SelectedTab = tabPageSessionView;
                }
            }
            else
            {
                MessageBox.Show("Please Select a session to Delete ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControlLSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlLSessions.SelectedTab.Name == "tabPageSessionEdit")
            {
                if (SID == 0)
                {
                    MessageBox.Show("Please select a session in sessions list ", "No session selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlLSessions.SelectedTab = tabPageSessionView;
                }
            }
            /*
            if (tabControlLSessions.SelectedTab.Name == "tabPageSessionView")
            {
                cmbSessionLecturerEdit.SelectedIndex = -1;
                lecturersEdit = "";
                txtSelectedLecturersEdit.Clear();

                cmbSessionTagEdit.SelectedIndex = -1;
                //tagsEdit = "";
                //txtSelectedTagsEdit.Clear();

                cmbSessionGroupEdit.SelectedIndex = -1;
                //groupsEdit = "";
                //txtSelectedGroupsEdit.Clear();

                cmbSessionSubjectEdit.SelectedIndex = -1;
                txtSelectedSubjectEdit.Clear();

                nmudSessionNoStudentsEdit.Value = 0;

                nmudSessionDurationEdit.Value = 0;

                SID = 0;
            }
            */
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
