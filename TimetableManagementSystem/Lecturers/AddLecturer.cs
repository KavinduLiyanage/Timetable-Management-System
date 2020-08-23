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
                    LecturerRank = 4;
                }
                else if (cmbLecLevel.Text.Equals("Senior Lecturer"))
                {
                    LecturerRank = 5;
                }
                else if (cmbLecLevel.Text.Equals("Lecturer"))
                {
                    LecturerRank = 3;
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
            if ((txtLecName.Text == string.Empty) && (cmbLecFac.Text == string.Empty)
                && (cmbLecCenter.Text == string.Empty) && (cmbLecBuilding.Text == string.Empty) && (cmbLecLevel.Text == string.Empty))
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
                    LecturerRank = 4;
                }
                else if (cmbLecLevelEdit.Text.Equals("Senior Lecturer"))
                {
                    LecturerRank = 5;
                }
                else if (cmbLecLevelEdit.Text.Equals("Lecturer"))
                {
                    LecturerRank = 3;
                }
                else if (cmbLecLevelEdit.Text.Equals("Assistant Lecturer"))
                {
                    LecturerRank = 6;
                }
                else
                {
                    LecturerRank = 7;
                }
                cmd.Parameters.AddWithValue("@lecrank", LecturerRank);
                cmd.Parameters.AddWithValue("@LecturerID", this.LecturerID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Lecturer Details Updated", "Successfully");

                GetLecturers();

                ClearFieldsAfterUpdate();

                tabControlLecturers.SelectedTab = tabPageLecView;
            }
            else
            {
                MessageBox.Show("Please Select a lecturer to Update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //----Header Buttons----
        private void btnHeaderHome_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
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

        private void txtLecSearch_TextChanged(object sender, EventArgs e)
        {
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
            

        }

        private void cmbLecFilterFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLecSearch.Clear();
            cmbLecFilterLevel.SelectedIndex = -1;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Lecturers where LecFaculty like '%" + cmbLecFilterFaculty.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvLectures.DataSource = dt;
            con.Close();
            
        }

        private void cmbLecFilterLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLecSearch.Clear();
            cmbLecFilterFaculty.SelectedIndex = -1;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Lecturers where LecLevel like '%" + cmbLecFilterLevel.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvLectures.DataSource = dt;
            con.Close();
            
        }
    }
}
