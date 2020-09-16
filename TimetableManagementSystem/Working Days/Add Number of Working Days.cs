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

namespace TimetableManagementSystem.Working_Days
{
    public partial class Add_Number_of_Working_Days : MetroFramework.Forms.MetroForm

    {

        

        public Add_Number_of_Working_Days()
        {
            InitializeComponent();
        }

        SqlConnection con = Config.con;
        public int EntryID;
        public int WorkingTimeID;
        public int WorkingTimeSlotID;
        public int WorkingDaysWDID;
        public int Count;

        private void Add_Number_of_Working_Days_Load(object sender, EventArgs e)
        {

            getNumberOfWorkingDays();
            getWorkingTime();
            getTimeSlot();
            getWorkingDays();
        }

        //working Days
        private void getWorkingDays()
        {
            SqlCommand cmd = new SqlCommand("select * from WorkingDaysWD ", con);
            DataTable wddt = new DataTable();

            con.Open();

            SqlDataReader wddr = cmd.ExecuteReader();
            wddt.Load(wddr);
            con.Close();

            dvgWKD.DataSource = wddt;
        }

        //Time Slot
        private void getTimeSlot()
        {
            SqlCommand cmd = new SqlCommand("select * from WorkingTimeSlot", con);
            DataTable wsdt = new DataTable();

            con.Open();

            SqlDataReader wsdr = cmd.ExecuteReader();
            wsdt.Load(wsdr);
            con.Close();

            dvgTS.DataSource = wsdt;

        }

        //Working Time
        private void getWorkingTime()
        {
            SqlCommand cmd = new SqlCommand("select * from WorkingTime", con);
            DataTable wdt = new DataTable();

            con.Open();

            SqlDataReader wdr = cmd.ExecuteReader();
            wdt.Load(wdr);
            con.Close();

            dgvWT.DataSource = wdt;

        }

        //Number of Working days
        private void getNumberOfWorkingDays()
        {
            SqlCommand cmd = new SqlCommand("select * from WorkingDays", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dgvNWD.DataSource = dt;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void numberOfWorkingDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timeSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void workingTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblFoodID_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void Dvgfood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void btnaddWD_Click(object sender, EventArgs e)
        {

        }

        private void TPNoOfWorkingDays_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        //Number of working Days add
        private void btnAddNWD_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                avalibility(EntryID);
                SqlCommand cmd = new SqlCommand("INSERT INTO WorkingDays VALUES(@NumberOfWorkingDays)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NumberOfWorkingDays", numericUpDownNWD.Text);

                Count = Convert.ToInt32(numericUpDownNWD.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Number of working Days is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getNumberOfWorkingDays();
                ResetNWd();
                avalibility(Count);


            }

        
        }

        //number of days checking
        private bool isValid()
        {
            if (numericUpDownNWD.Text == "")
            {
                MessageBox.Show("This Field Can not be empty", "Failed" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtSearchNWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchNWD_Click(object sender, EventArgs e)
        {
           

        }

        //Number of Working Days reset btn
        private void btnresetNWD_Click(object sender, EventArgs e)
        {
            ResetNWd();
        }

        //Number of Working Days reset method
        private void ResetNWd()
        {
            numericUpDownNWD.Text = "0";
            numericUpDownNWD.Focus();
        }

        //Number of Working Days data grid
        private void dgvNWD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EntryID = Convert.ToInt32(dgvNWD.SelectedRows[0].Cells[0].Value);
            numericUpDownNWD.Text = dgvNWD.SelectedRows[0].Cells[1].Value.ToString();
        }

        //Number of Working Days edit btn
        private void btneditNWD_Click(object sender, EventArgs e)
        {
            if (EntryID > 0)
            {

                SqlCommand cmd = new SqlCommand("UPDATE WorkingDays SET  NumberOfWorkingDays = @NumberOfWorkingDays WHERE EntryID= @EntryID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NumberOfWorkingDays", numericUpDownNWD.Text);
                cmd.Parameters.AddWithValue("@EntryID", this.EntryID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Number of working Days is sucessfully Updated ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getNumberOfWorkingDays();
                ResetNWd();

                Count = Convert.ToInt32(numericUpDownNWD.Text);
                avalibility(Count);

            }
            else
            {

                MessageBox.Show("Plesae select data to update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //Number of Working Days delete btn
        private void btndeleteNWD_Click(object sender, EventArgs e)
        {
            if (EntryID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM WorkingDays WHERE EntryID = @EntryID", con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@EntryID", this.EntryID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Number of working Days is sucessfully Deleted ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getNumberOfWorkingDays();
                ResetNWd();
            }
            else 
            {
                MessageBox.Show("Plesae select Corret data to delete ", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //working Time add 
        private void btnaddWT_Click(object sender, EventArgs e)
        {
            if (iswTimeValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO WorkingTime VALUES(@Hours, @Minutes)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Hours", numericUpDownHours.Text);
                cmd.Parameters.AddWithValue("@Minutes", numericUpDownMinutes.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working Time is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingTime();
                ResetWT();

            }
        }

        //working Time checking valid
        private bool iswTimeValid()
        {
            if (numericUpDownHours.Text == "" || numericUpDownMinutes.Text == "" )
            {
                MessageBox.Show("This Field Can not be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Working Time edit
        private void btneditWT_Click(object sender, EventArgs e)
        {
            if (WorkingTimeID > 0)
            {

                SqlCommand cmd = new SqlCommand("UPDATE WorkingTime SET  Hours = @Hours , Minutes = @Minutes WHERE WorkingTimeID= @WorkingTimeID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Hours", numericUpDownHours.Text);
                cmd.Parameters.AddWithValue("@Minutes", numericUpDownMinutes.Text);
                cmd.Parameters.AddWithValue("@WorkingTimeID", this.WorkingTimeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working Time is sucessfully Updated ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingTime();
                ResetWT();

            }
            else
            {

                MessageBox.Show("Plesae select data to update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Working Time Reset
        private void btnresetWT_Click(object sender, EventArgs e)
        {
            ResetWT();
        }

        private void ResetWT()
        {
            numericUpDownHours.Text = "0";
            numericUpDownMinutes.Text = "0";
           
        }

        //Working Time data grid 
        private void dgvWT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkingTimeID = Convert.ToInt32(dgvWT.SelectedRows[0].Cells[0].Value);
            numericUpDownHours.Text = dgvWT.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDownMinutes.Text = dgvWT.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btndeleteWT_Click(object sender, EventArgs e)
        {
            if (WorkingTimeID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM WorkingTime WHERE WorkingTimeID = @WorkingTimeID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@WorkingTimeID", this.WorkingTimeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working Time is sucessfully Deleted ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingTime();
                ResetWT();
            }
            else
            {
                MessageBox.Show("Plesae select Corret data to delete ", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Time Slot add
        private void btnaddTS_Click(object sender, EventArgs e)
        {
            if (isTimeSlotValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO WorkingTimeSlot VALUES(@TimeSlot)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TimeSlot", cmbTS.Text);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working TimeSlot is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getTimeSlot();
                ResetTS();

            }
        }

        //Time slot

        private bool isTimeSlotValid()
        {
            if (cmbTS.Text == "" )
            {
                MessageBox.Show("This Field Can not be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Time Slot reset btn
        private void btnresetTimeSlot_Click(object sender, EventArgs e)
        {
            ResetTS();
        }

        //Time Slot Reset Method
        private void ResetTS()
        {
            cmbTS.Text = "";
        }

        //Time Slot data grid
        private void dvgTS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkingTimeSlotID = Convert.ToInt32(dvgTS.SelectedRows[0].Cells[0].Value);
            cmbTS.Text = dvgTS.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        //working days
        private void btnaddWD_Click_1(object sender, EventArgs e)
        {
            if (isWorkingDaysValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO WorkingDaysWD VALUES(@Day1, @Day2, @Day3, @Day4, @Day5, @Day6, @Day7)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Day1", cmbWd1.Text);
                cmd.Parameters.AddWithValue("@Day2", cmbWd2.Text);
                cmd.Parameters.AddWithValue("@Day3", cmbWd3.Text);
                cmd.Parameters.AddWithValue("@Day4", cmbWd4.Text);
                cmd.Parameters.AddWithValue("@Day5", cmbWd5.Text);
                cmd.Parameters.AddWithValue("@Day6", cmbWd6.Text);
                cmd.Parameters.AddWithValue("@Day7", cmbWd7.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working Day is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingDays();
                ResetWD();

            }
        }

        private bool isWorkingDaysValid()
        {
            if (cmbWd1.Text == "" && cmbWd2.Text == "" && cmbWd3.Text == "" && cmbWd4.Text == "" && cmbWd5.Text == "" && cmbWd6.Text == "" &&
                cmbWd7.Text == "")
            {
                MessageBox.Show("This Field Can not be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnresetWD_Click(object sender, EventArgs e)
        {
            ResetWD();
        }

        private void ResetWD()
        {
            cmbWd1.Text = "";
            cmbWd2.Text = "";
            cmbWd3.Text = "";
            cmbWd4.Text = "";
            cmbWd5.Text = "";
            cmbWd6.Text = "";
            cmbWd7.Text = "";
        }

        private void avalibility(int value)
        {
            if (value == 1)
            {
                cmbWd1.Enabled = true;
                cmbWd2.Enabled = false;
                cmbWd3.Enabled = false;
                cmbWd4.Enabled = false;
                cmbWd5.Enabled = false;
                cmbWd6.Enabled = false;
                cmbWd7.Enabled = false;
            }
            else if (value == 2)
            {
                cmbWd1.Enabled = true;
                cmbWd2.Enabled = true;
                cmbWd3.Enabled = false;
                cmbWd4.Enabled = false;
                cmbWd5.Enabled = false;
                cmbWd6.Enabled = false;
                cmbWd7.Enabled = false;
            }
            else if (value == 3)
            {
                cmbWd1.Enabled = true;
                cmbWd2.Enabled = true;
                cmbWd3.Enabled = true;
                cmbWd4.Enabled = false;
                cmbWd5.Enabled = false;
                cmbWd6.Enabled = false;
                cmbWd7.Enabled = false;
            }
            else if (value == 4)
            {

                cmbWd1.Enabled = true;
                cmbWd2.Enabled = true;
                cmbWd3.Enabled = true;
                cmbWd4.Enabled = true;
                cmbWd5.Enabled = false;
                cmbWd6.Enabled = false;
                cmbWd7.Enabled = false;
            }
            else if (value == 5)
            {
                cmbWd1.Enabled = true;
                cmbWd2.Enabled = true;
                cmbWd3.Enabled = true;
                cmbWd4.Enabled = true;
                cmbWd5.Enabled = true;
                cmbWd6.Enabled = false;
                cmbWd7.Enabled = false;

            }
            else if (value == 6)
            {
                cmbWd1.Enabled = true;
                cmbWd2.Enabled = true;
                cmbWd3.Enabled = true;
                cmbWd4.Enabled = true;
                cmbWd5.Enabled = true;
                cmbWd6.Enabled = true;
                cmbWd7.Enabled = false;
            }

        }

        private void dvgWKD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkingDaysWDID = Convert.ToInt32(dvgWKD.SelectedRows[0].Cells[0].Value);
            cmbWd1.Text = dvgWKD.SelectedRows[0].Cells[1].Value.ToString();
            cmbWd2.Text = dvgWKD.SelectedRows[0].Cells[2].Value.ToString();
            cmbWd3.Text = dvgWKD.SelectedRows[0].Cells[3].Value.ToString();
            cmbWd4.Text = dvgWKD.SelectedRows[0].Cells[4].Value.ToString();
            cmbWd5.Text = dvgWKD.SelectedRows[0].Cells[5].Value.ToString();
            cmbWd6.Text = dvgWKD.SelectedRows[0].Cells[6].Value.ToString();
            cmbWd7.Text = dvgWKD.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btneditWD_Click(object sender, EventArgs e)
        {
            if (WorkingDaysWDID > 0)
            {

                SqlCommand cmd = new SqlCommand("UPDATE WorkingDaysWD SET  Day1 = @Day1, Day2 = @Day2, Day3 = @Day3, Day4 = @Day4, Day5 = @Day5, Day6 = @Day6 , Day7 = @Day7 WHERE WorkingDaysWDID= @WorkingDaysWDID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Day1", cmbWd1.Text);
                cmd.Parameters.AddWithValue("@Day2", cmbWd2.Text);
                cmd.Parameters.AddWithValue("@Day3", cmbWd3.Text);
                cmd.Parameters.AddWithValue("@Day4", cmbWd4.Text);
                cmd.Parameters.AddWithValue("@Day5", cmbWd5.Text);
                cmd.Parameters.AddWithValue("@Day6", cmbWd6.Text);
                cmd.Parameters.AddWithValue("@Day7", cmbWd7.Text);
                cmd.Parameters.AddWithValue("@WorkingDaysWDID", this.WorkingDaysWDID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Number of working Days is sucessfully Updated ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingDays();
                ResetWD();

            }
            else
            {

                MessageBox.Show("Plesae select data to update ", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndeleteWD_Click(object sender, EventArgs e)
        {
            if (WorkingDaysWDID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM WorkingDaysWD  WHERE WorkingDaysWDID = @WorkingDaysWDID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@WorkingDaysWDID", this.WorkingDaysWDID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" Working Day is sucessfully Deleted ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getWorkingDays();
                ResetWD();
            }
            else
            {
                MessageBox.Show("Plesae select Corret data to delete ", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //--------------------Header Buttons--------------------

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homePage = new Homepage();
            homePage.ShowDialog();
        }

        private void btnHeaderSessions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sessions.Sessions sessions = new Sessions.Sessions();
            sessions.ShowDialog();
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
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
