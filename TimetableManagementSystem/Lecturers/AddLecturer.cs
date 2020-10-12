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
using TimetableManagementSystem.Subjects;
using TimetableManagementSystem.Tags;

namespace TimetableManagementSystem.Lecturers
{
    public partial class AddLecturer : MetroFramework.Forms.MetroForm
    {
        public AddLecturer()
        {
            InitializeComponent();
        }

        SqlConnection con = Config.con;

        public int LecturerID;
        public float LecturerRank;

        private void AddLecturer_Load(object sender, EventArgs e)
        {
            GetLecturers();
            tabControlLecturers.SelectedTab = tabPageLecView;
        }

        private void GetLecturers()
        {
            SqlCommand cmd = new SqlCommand("Select * from Lecturers", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dgvLectures.AutoGenerateColumns = false;
            dgvLectures.DataSource = dt;

            this.dgvLectures.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLectures.Columns["LecDepartment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLectures.Columns["LecRank"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnLecSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Lecturers VALUES (@lecname, @lecfaculty, @lecdepartment, @leccenter, @lecbuilding, @leclevel, @lecrank)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@lecname", txtLecName.Text);
                cmd.Parameters.AddWithValue("@lecfaculty", cmbLecFac.Text);
                cmd.Parameters.AddWithValue("@lecdepartment", cmbLecDepartment.Text);
                cmd.Parameters.AddWithValue("@leccenter", cmbLecCenter.Text);
                cmd.Parameters.AddWithValue("@lecbuilding", cmbLecBuilding.Text);
                cmd.Parameters.AddWithValue("@leclevel", cmbLecLevel.Text);

                if(cmbLecLevel.Text.Equals("Professor"))
                {
                    LecturerRank = 1;
                }
                else if(cmbLecLevel.Text.Equals("Assistant Professor"))
                {
                    LecturerRank = 2;
                }
                else if (cmbLecLevel.Text.Equals("Senior Lecturer(HG)"))
                {
                    LecturerRank = 3;
                }
                else if (cmbLecLevel.Text.Equals("Senior Lecturer"))
                {
                    LecturerRank = 4;
                }
                else if (cmbLecLevel.Text.Equals("Lecturer"))
                {
                    LecturerRank = 5;
                }
                else if (cmbLecLevel.Text.Equals("Assistant Lecturer"))
                {
                    LecturerRank = 6;
                }
                else
                {
                    LecturerRank = 7;
                }
                cmd.Parameters.AddWithValue("@lecrank", LecturerRank);

                con.Open();
                cmd.ExecuteNonQuery();

                SqlCommand command = new SqlCommand("SELECT TOP(1) LecturerID FROM Lecturers ORDER BY 1 DESC", con);

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                string data = reader["LecturerID"].ToString();

                reader.Close();

                con.Close();

                SqlCommand command2 = new SqlCommand("UPDATE Lecturers SET LecRank = @LecRank Where LecturerID = @LecturerID ", con);
                command2.CommandType = CommandType.Text;

                command2.Parameters.AddWithValue("@LecRank", LecturerRank+"."+data);

                command2.Parameters.AddWithValue("@LecturerID", data);

                con.Open();

                command2.ExecuteNonQuery();

                con.Close();

                GetLecturers();

                ClearFieldsAfterAdd();

                tabControlLecturers.SelectedTab = tabPageLecView;
            }
        }

        private void ClearFieldsAfterAdd()
        {
            txtLecName.Clear();
            //cmbLecFac.SelectedIndex = -1;
            cmbLecDepartment.SelectedIndex = -1;
            cmbLecCenter.SelectedIndex = -1;
            cmbLecBuilding.SelectedIndex = -1;
            cmbLecLevel.SelectedIndex = -1;
            LecturerID = 0;
        }

        private bool IsValid()
        {
            if ((txtLecName.Text == string.Empty) || (cmbLecFac.Text == string.Empty)
                || (cmbLecDepartment.Text == string.Empty) || (cmbLecCenter.Text == string.Empty) || (cmbLecBuilding.Text == string.Empty)
                || (cmbLecLevel.Text == string.Empty))
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFieldsAfterAdd();
        }

        private void dgvLectures_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            LecturerID = Convert.ToInt32(dgvLectures.SelectedRows[0].Cells[0].Value);
            txtLecNameEdit.Text = dgvLectures.SelectedRows[0].Cells[1].Value.ToString();
            cmbLecFacEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[2].Value;
            cmbLecDepartmentEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[3].Value;
            cmbLecCenterEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[4].Value;
            cmbLecBuildingEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[6].Value;
            cmbLecLevelEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[5].Value;

            tabControlLecturers.SelectedTab = tabPageLecEdit;
        }

        private void btnLecUpdate_Click(object sender, EventArgs e)
        {
            if (LecturerID > 0)
            {
                if (IsValidUpdate())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Lecturers SET LecName = @LecName, LecFaculty = @LecFaculty, LecDepartment = @LecDepartment, LecCenter = @LecCenter, LecBuilding = @LecBuilding, LecLevel = @LecLevel, LecRank = @LecRank WHERE LecturerID = @LecturerID", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@LecName", txtLecNameEdit.Text);
                    cmd.Parameters.AddWithValue("@lecfaculty", cmbLecFacEdit.Text);
                    cmd.Parameters.AddWithValue("@lecdepartment", cmbLecDepartmentEdit.Text);
                    cmd.Parameters.AddWithValue("@leccenter", cmbLecCenterEdit.Text);
                    cmd.Parameters.AddWithValue("@lecbuilding", cmbLecBuildingEdit.Text);
                    cmd.Parameters.AddWithValue("@leclevel", cmbLecLevelEdit.Text);

                    if (cmbLecLevelEdit.Text.Equals("Professor"))
                    {
                        LecturerRank = 1;
                    }
                    else if (cmbLecLevelEdit.Text.Equals("Assistant Professor"))
                    {
                        LecturerRank = 2;
                    }
                    else if (cmbLecLevelEdit.Text.Equals("Senior Lecturer(HG)"))
                    {
                        LecturerRank = 3;
                    }
                    else if (cmbLecLevelEdit.Text.Equals("Senior Lecturer"))
                    {
                        LecturerRank = 4;
                    }
                    else if (cmbLecLevelEdit.Text.Equals("Lecturer"))
                    {
                        LecturerRank = 5;
                    }
                    else if (cmbLecLevelEdit.Text.Equals("Assistant Lecturer"))
                    {
                        LecturerRank = 6;
                    }
                    else
                    {
                        LecturerRank = 7;
                    }
                    cmd.Parameters.AddWithValue("@lecrank", LecturerRank + "." + this.LecturerID);
                    cmd.Parameters.AddWithValue("@LecturerID", this.LecturerID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Lecturer Details Updated", "Successfully");

                    GetLecturers();

                    ClearFieldsAfterUpdate();

                    tabControlLecturers.SelectedTab = tabPageLecView;
                }       
            }
            else
            {
                MessageBox.Show("Please Select a lecturer to Update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidUpdate()
        {
            if ((txtLecNameEdit.Text == string.Empty) || (cmbLecFacEdit.Text == string.Empty)
                || (cmbLecDepartmentEdit.Text == string.Empty) || (cmbLecCenterEdit.Text == string.Empty) || (cmbLecBuildingEdit.Text == string.Empty)
                || (cmbLecLevelEdit.Text == string.Empty))
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearFieldsAfterUpdate()
        {
            txtLecNameEdit.Clear();
            //cmbLecFac.SelectedIndex = -1;
            cmbLecDepartmentEdit.SelectedIndex = -1;
            cmbLecCenterEdit.SelectedIndex = -1;
            cmbLecBuildingEdit.SelectedIndex = -1;
            cmbLecLevelEdit.SelectedIndex = -1;
            LecturerID = 0;
        }

        private void btnLecDelete_Click(object sender, EventArgs e)
        {
            if (LecturerID > 0)
            {

                if(MessageBox.Show("Are You Sure You Want to Delete the Lecturer?","Delete Lecturer",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Lecturers WHERE LecturerID = @LecturerID", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@LecturerID", this.LecturerID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Lecturer is Deleted", "Successfully");

                    GetLecturers();

                    ClearFieldsAfterUpdate();

                    tabControlLecturers.SelectedTab = tabPageLecView;
                }              
            }
            else
            {
                MessageBox.Show("Please Select a lecturer to Delete ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLecFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLecDepartment.Items.Clear();

            if (cmbLecFac.SelectedItem.Equals("Engineering"))
            {
                cmbLecDepartment.Items.Add("CE");
                cmbLecDepartment.Items.Add("EEE");
                cmbLecDepartment.Items.Add("ME");
                cmbLecDepartment.Items.Add("QS");
            }
            else if (cmbLecFac.SelectedItem.Equals("Computing"))
            {
                cmbLecDepartment.Items.Add("CSSE");
                cmbLecDepartment.Items.Add("DS");
                cmbLecDepartment.Items.Add("CSNE");
                cmbLecDepartment.Items.Add("IT");
                cmbLecDepartment.Items.Add("CS");
                cmbLecDepartment.Items.Add("IM");
                cmbLecDepartment.Items.Add("ISE");
            }
            else if (cmbLecFac.SelectedItem.Equals("Business"))
            {
                cmbLecDepartment.Items.Add("AF");
                cmbLecDepartment.Items.Add("BA");
                cmbLecDepartment.Items.Add("HCM");
                cmbLecDepartment.Items.Add("MM");
                cmbLecDepartment.Items.Add("IM");
                cmbLecDepartment.Items.Add("BM");             
            }
            else if (cmbLecFac.SelectedItem.Equals("Humanities and Science"))
            {
                cmbLecDepartment.Items.Add("MU");
                cmbLecDepartment.Items.Add("ELT");              
            }
            //cmbLecFac.SelectedIndex = -1;
        }

        private void cmbLecFacEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLecDepartmentEdit.Items.Clear();

            if (cmbLecFacEdit.SelectedItem.Equals("Engineering"))
            {
                cmbLecDepartmentEdit.Items.Add("CE");
                cmbLecDepartmentEdit.Items.Add("EEE");
                cmbLecDepartmentEdit.Items.Add("ME");
                cmbLecDepartmentEdit.Items.Add("QS");
            }
            else if (cmbLecFacEdit.SelectedItem.Equals("Computing"))
            {
                cmbLecDepartmentEdit.Items.Add("CSSE");
                cmbLecDepartmentEdit.Items.Add("DS");
                cmbLecDepartmentEdit.Items.Add("CSNE");
                cmbLecDepartmentEdit.Items.Add("IT");
                cmbLecDepartmentEdit.Items.Add("CS");
                cmbLecDepartmentEdit.Items.Add("IM");
                cmbLecDepartmentEdit.Items.Add("ISE");

            }
            else if (cmbLecFacEdit.SelectedItem.Equals("Business"))
            {
                cmbLecDepartmentEdit.Items.Add("AF");
                cmbLecDepartmentEdit.Items.Add("BA");
                cmbLecDepartmentEdit.Items.Add("HCM");
                cmbLecDepartmentEdit.Items.Add("MM");
                cmbLecDepartmentEdit.Items.Add("IM");
                cmbLecDepartmentEdit.Items.Add("BM");
            }
            else if (cmbLecFacEdit.SelectedItem.Equals("Humanities and Science"))
            {
                cmbLecDepartmentEdit.Items.Add("MU");
                cmbLecDepartmentEdit.Items.Add("ELT");
            }
        }

        private void txtLecSearch_TextChanged(object sender, EventArgs e)
        {
            /*
            cmbLecFilterFaculty.SelectedIndex = -1;
            cmbLecFilterLevel.SelectedIndex = -1;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Lecturers where LecName like '%" + txtLecSearch.Text + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvLectures.DataSource = dt;
            con.Close();
            */

            if (txtLecSearch.Text != "")
            {
                cmbLecFilterFaculty.SelectedIndex = -1;
                cmbLecFilterLevel.SelectedIndex = -1;

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Lecturers WHERE LecName LIKE '%" + txtLecSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvLectures.DataSource = dt;
                con.Close();
            }
            else if (txtLecSearch.Text == "")
            {
                GetLecturers();
            }
        }

        private void cmbLecFilterFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLecFilterFaculty.Text != "")
            {
                txtLecSearch.Clear();
                cmbLecFilterLevel.SelectedIndex = -1;

                if (cmbLecFilterFaculty.Text == "Clear Selected")
                {
                    cmbLecFilterFaculty.SelectedIndex = -1;
                }

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Lecturers where LecFaculty like '%" + cmbLecFilterFaculty.Text + "%' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvLectures.DataSource = dt;
                con.Close();
            }        
        }

        private void cmbLecFilterLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLecFilterLevel.Text != "")
            {
                txtLecSearch.Clear();
                cmbLecFilterFaculty.SelectedIndex = -1;

                if (cmbLecFilterLevel.Text == "Clear Selected")
                {
                    cmbLecFilterLevel.SelectedIndex = -1;
                }

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Lecturers where LecLevel like '%" + cmbLecFilterLevel.Text + "%' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvLectures.DataSource = dt;
                con.Close();
            }       
        }

        private void tabControlLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlLecturers.SelectedTab.Name == "tabPageLecEdit")
            {
                if (LecturerID == 0)
                {
                    MessageBox.Show("Please select a lecturer in lecturers list ", "No lecturer selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlLecturers.SelectedTab = tabPageLecView;
                }
            }
        }

        //--------------------Header Buttons--------------------
        private void btnHeaderHome_Click_1(object sender, EventArgs e)
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
