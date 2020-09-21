using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimetableManagementSystem.AdvancedOp
{
    public partial class Advanced : MetroFramework.Forms.MetroForm
    {

        public SqlConnection con = Config.con;

        public Advanced()
        {
            InitializeComponent();
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }

        private void btnSideNavWorking_Click(object sender, EventArgs e)
        {
            this.Hide();
            Working_Days.Add_Number_of_Working_Days workingDays = new Working_Days.Add_Number_of_Working_Days();
            workingDays.ShowDialog();
        }

        private void btnHeaderAdvanced_Click(object sender, EventArgs e)
        {
            this.Hide();
            Advanced advc = new Advanced();
            advc.ShowDialog();
        }

        private void btnHeaderRooms_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderSessions_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {

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

        private void noAvaBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void Advanced_Load(object sender, EventArgs e)
        {
            
            timeCmbBox.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from WorkingTimeSlot", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                timeCmbBox.Items.Add(dataRow["TimeSlot"].ToString());
            }

            sesCmb01.Items.Clear();
            parSesCmbBox01.Items.Clear();
            notOverlapSesCmbBox01.Items.Clear();
            SqlDataAdapter sda2 = new SqlDataAdapter("select * from Sessions", con);
            DataTable dataTable2 = new DataTable();
            sda2.Fill(dataTable2);
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                sesCmb01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                parSesCmbBox01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                notOverlapSesCmbBox01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
            }

            
            sesCmb02.Items.Clear();
            parSesCmbBox02.Items.Clear();
            notOverlapSesCmbBox02.Items.Clear();
            SqlDataAdapter sda3 = new SqlDataAdapter("select * from Sessions", con);
            DataTable dataTable3 = new DataTable();
            sda3.Fill(dataTable3);
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                sesCmb02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                parSesCmbBox02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                notOverlapSesCmbBox02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
            }
 
        }

        private void typeCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (typeCmbo.Text == "Lecturers") {
                itmLbl.Text = "Lecturer";
                itmCmbBox.PromptText = "Select Lecturer";
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Lecturers", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["LecName"].ToString());
                }
            }
            else if (typeCmbo.Text == "Sessions") {
                itmLbl.Text = "Session";
                itmCmbBox.PromptText = "Select Session";
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Sessions", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["SessionID"].ToString());
                }
            }
            else if (typeCmbo.Text == "Groups") {
                itmLbl.Text = "Group";
                itmCmbBox.PromptText = "Select Group";
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from GenGroupNumber;", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["GenGrpNum"].ToString());
                }
            }
            else if (typeCmbo.Text == "Sub-Groups") {
                itmLbl.Text = "Sub-Group";
                itmCmbBox.PromptText = "Select Sub-Group";
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from GenSubGroupNumber", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["GenSubGrpNum"].ToString());
                }
            }
        }
    }
}
