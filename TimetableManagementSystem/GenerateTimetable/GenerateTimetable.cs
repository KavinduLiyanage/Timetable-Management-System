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
using TimetableManagementSystem.Tags;

namespace TimetableManagementSystem.GenerateTimetable
{
    public partial class GenerateTimetable : MetroFramework.Forms.MetroForm
    {

        SqlConnection con = Config.con;
        //public int TimetableID;

        public GenerateTimetable()
        {
            InitializeComponent();
        }
        
           

        private void lblNWD_Click(object sender, EventArgs e)
        {

        }

        private void cmdGTlecsession_Click(object sender, EventArgs e)
        {

        }

        private void dvgGTstudentgroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GenerateTimetable_Load(object sender, EventArgs e)
        {
            //generateTimetable();
        }

        //private void generateTimetable()
        //{
        //    SqlCommand cmd = new SqlCommand("select * from Timetable", con);
        //    DataTable generatedt = new DataTable();

        //    con.Open();

        //    SqlDataReader gTT = cmd.ExecuteReader();
        //    generatedt.Load(gTT);
        //    con.Close();

        //    dvgGT.DataSource = generatedt;

        //}

        private void btnGTlecadd_Click(object sender, EventArgs e)
        {
            //if (iswTimeTableValid())
            //{
            //    SqlCommand cmd = new SqlCommand("INSERT INTO WorkingTime VALUES( @lecturer, @room_num, @subject, @day, @startTime ,@endTime , @sessionType, @sessionID , @range , @timeslot )", con);
            //    cmd.CommandType = CommandType.Text;

            //    cmd.Parameters.AddWithValue("@lecturer", numericUpDownMinutes.Text);
            //    cmd.Parameters.AddWithValue("@room_num", numericUpDownMinutes.Text);
            //    cmd.Parameters.AddWithValue("@subject", numericUpDownMinutes.Text);
            //    cmd.Parameters.AddWithValue("@day", cmdGTlec.Text);
            //    cmd.Parameters.AddWithValue("@startTime", cmdGTclassroom.Text);
            //    cmd.Parameters.AddWithValue("@endTime", cmdGTlecSubject.Text);
            //    cmd.Parameters.AddWithValue("@sessionType", numericUpDownMinutes.Text);
            //    cmd.Parameters.AddWithValue("@sessionID", cmdGTlecDay.Text);
                
                
                
                
            //    cmd.Parameters.AddWithValue("@room_num", numericUpDownMinutes.Text);
            //    cmd.Parameters.AddWithValue("@room_num", numericUpDownMinutes.Text);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //    MessageBox.Show(" Data is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    generateTimetable();
            //    ResetGT();

            //}
        }

        //working Time checking valid
        //private bool iswTimeTableValid()
        //{
        //    if (cmdGTlec.Text == "" || cmdGTclassroom.Text == "" || cmdGTlecSubject.Text == "" || cmdGTlecDay.Text == ""
        //        || cmdGTclassroom.Text == "" || cmdGTclassroom.Text == "" || cmdGTclassroom.Text == "" || cmdGTclassroom.Text == ""
        //        || cmdGTclassroom.Text == "" || cmdGTclassroom.Text == "")
        //    {
        //        MessageBox.Show("This Field Can not be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;
        //}



        //generate timetable 
        private void btnGTreset_Click(object sender, EventArgs e)
        {
        //    ResetGT();

        }

        //cancle
        //private void ResetGT()
        //{

        //    numericUpDownHours.Text = "0";
        //    numericUpDownMinutes.Text = "0";

        //}

        //private void dvgGT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //WorkingTimeID = Convert.ToInt32(dgvWT.SelectedRows[0].Cells[0].Value);
        //    //numericUpDownHours.Text = dgvWT.SelectedRows[0].Cells[1].Value.ToString();
        //    //numericUpDownMinutes.Text = dgvWT.SelectedRows[0].Cells[2].Value.ToString();
        //}

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdGTlecDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbGTtime_Click(object sender, EventArgs e)
        {

        }

        private void lblGTday_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

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
