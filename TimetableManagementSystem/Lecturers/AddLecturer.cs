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
                cmd.Parameters.AddWithValue("@lecdepartment", txtLecDep.Text);
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
            LecturerID = 0;
            txtLecName.Focus();
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

        
    }
}
