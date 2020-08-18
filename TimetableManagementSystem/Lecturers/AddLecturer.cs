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

                ClearFields();

                tabControlLecturers.SelectedTab = tabPageLecView;
            }
        }

        private void ClearFields()
        {
            txtLecName.Clear();
            txtLecDep.Clear();
            //cmbLecFac.SelectedIndex = -1;
            cmbLecBuilding.SelectedIndex = -1;
            cmbLecCenter.SelectedIndex = -1;
            cmbLecLevel.SelectedIndex = -1;
            LecturerID = 0;
            cmbLecDepartment.SelectedIndex = -1;

        }

        private bool IsValid()
        {
            if ((txtLecName.Text == string.Empty) && (txtLecDep.Text == string.Empty) && (cmbLecFac.Text == string.Empty)
                && (cmbLecCenter.Text == string.Empty) && (cmbLecBuilding.Text == string.Empty) && (cmbLecLevel.Text == string.Empty))
            {
                MessageBox.Show("Fill the all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvLectures_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            LecturerID = Convert.ToInt32(dgvLectures.SelectedRows[0].Cells[0].Value);
            txtLecNameEdit.Text = dgvLectures.SelectedRows[0].Cells[1].Value.ToString();
            cmbLecFacEdit.SelectedItem = dgvLectures.SelectedRows[0].Cells[2].Value;
            //txtLecDepEdit.Text = dgvLectures.SelectedRows[0].Cells[3].Value.ToString();
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
                cmd.Parameters.AddWithValue("@lecdepartment", txtLecDepEdit.Text);
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

                MessageBox.Show("Lecturer details Updated", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetLecturers();

                ClearFields();

                tabControlLecturers.SelectedTab = tabPageLecView;
            }
            else
            {
                MessageBox.Show("Please select a name to update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLecDelete_Click(object sender, EventArgs e)
        {
            if (LecturerID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Lecturers WHERE LecturerID = @LecturerID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@LecturerID", this.LecturerID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Name is Deleted", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetLecturers();

                ClearFields();

                tabControlLecturers.SelectedTab = tabPageLecView;
            }
            else
            {
                MessageBox.Show("Please select a name to delete ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSideNavLecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddLecturer addLecturer = new AddLecturer();
            addLecturer.ShowDialog();
        }

        private void btnSideNavSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }

        private void cmbLecFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLecDepartment.Items.Clear();

            if (cmbLecFac.SelectedItem.Equals("Engineering"))
            {
                cmbLecDepartment.Items.Add("CE");
                cmbLecDepartment.Items.Add("EE");
            }
            else if (cmbLecFac.SelectedItem.Equals("Computing"))
            {
                cmbLecDepartment.Items.Add("CSSE");
                cmbLecDepartment.Items.Add("DS");
                cmbLecDepartment.Items.Add("IT");
               
            }
            else if (cmbLecFac.SelectedItem.Equals("Business"))
            {
                cmbLecDepartment.Items.Add("IM");
                cmbLecDepartment.Items.Add("BM");
               
            }
            else
            {

            }

            //cmbLecFac.SelectedIndex = -1;
        }

        private void cmbLecFacEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
