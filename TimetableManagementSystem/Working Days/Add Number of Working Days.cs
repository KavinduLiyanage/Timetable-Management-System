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

namespace TimetableManagementSystem.Working_Days
{
    public partial class Add_Number_of_Working_Days : MetroFramework.Forms.MetroForm
    {

        int type, numOfWork, hour, minutes, hour1, minutes1, timeinMinutes, timeinMinutes1;
        bool firstCount = true;
        string[] ITDepartments = new string[] { "CSSE", "DS", "CSNE", "IT", "CS", "IM", "ISE" };
        string[] EngineeringDepartments = new string[] { "CE", "EEE", "ME", "QS" };
        string[] BusinessDepartments = new string[] { "AF", "BA", "HCM", "MM", "IM", "BM" };
        string[] HumanDepartments = new string[] { "MU", "ELT" };
        List<string> Lecturers = new List<string>();
        List<int> Sessions = new List<int>();
        List<String> ClassRooms = new List<String>();
        List<String> SelectedClassRooms = new List<String>();
        string[] timeTime;
        string[] daysArray;
        string lecturerName, selectedSession;
        string groupID = "";
        string curentRoom = "";
        int lecturerID;

        public Add_Number_of_Working_Days(int type)
        {

            InitializeComponent();
            metroComboBox1.Enabled = false;
            cmdsessiondepartment.Enabled = false;
            this.type = type;
            if (type == 0)
            {
                lblsessionlecturer.Text = "Lecturer";
                metroComboBox1.Enabled = true;
                cmdsessiondepartment.Enabled = true;
                cmdsessionfaculty.SelectedIndex = 0;
                //metroComboBox1.SelectedIndex = 0;
                cmdsessiondepartment.SelectedIndex = 0;
                cmdsessiondepartment.DataSource = ITDepartments;
                string initialQuery = "SELECT LecName FROM Lecturers WHERE LecFaculty = 'Computing' AND LecDepartment = 'CSSE'";

                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers;
                con.Close();

            }
            else if (type == 1)
            {
                lblsessionlecturer.Text = "Student Group";
                cmdsessiondepartment.Enabled = true;
                string initialQuery = "SELECT GenSubGrpNum FROM GenSubGroupNumber WHERE GenSubGrpNum LIKE '%CSSE%'";
                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers;
                con.Close();
            }
              
            else if (type == 2)
            {
                lblsessionlecturer.Text = "Building";
                cmdsessionfaculty.SelectedIndex = 0;
                metroLabelError.Visible = false;
                metroLabelremainerr.Visible = false;

                string initialQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Computing%'";
                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers;
                con.Close();
            }

            checkRecords();
        }

        SqlConnection con = Config.con;
        public int EntryID;
        public int WorkingTimeID;
        public int WorkingTimeSlotID;
        public int WorkingDaysWDID;
        public int Count;
        

        private void checkRecords()
        {
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM WorkingDays", con);
            con.Open();
            int UserExist = (int)check_User_Name.ExecuteScalar();
            con.Close();
            if (UserExist > 0)
            {
                firstCount = false;
            }
            else
            {
                firstCount = true;
            }
        }


        private void Add_Number_of_Working_Days_Load(object sender, EventArgs e)
        {

            getNumberOfWorkingDays();
            getWorkingTime();
            getWorkingDays();
            getTimeSlot();
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

        //Timeslot
        private void getTimeSlot()
        {
            SqlCommand cmd = new SqlCommand("select EntryID, Day , Timeslot from TimeSlot ", con);
            DataTable ts = new DataTable();

            con.Open();

            SqlDataReader tss = cmd.ExecuteReader();
            ts.Load(tss);
            con.Close();

            grdTs.DataSource = ts;
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
            int daysCount = -1;
            metroLabelError.Visible = false;
            if (isValid())
            {
                if(firstCount)
                {
                    avalibility(EntryID);
                    SqlCommand cmd = new SqlCommand("INSERT into WorkingDays values(@NumberOfWorkingDays)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NumberOfWorkingDays", numericUpDownNWD.Text);
                    numOfWork = Int32.Parse(numericUpDownNWD.Text);

                    Count = Convert.ToInt32(numericUpDownNWD.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Number of working Days is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getNumberOfWorkingDays();
                    ResetNWd();
                    avalibility(Count);
                    firstCount = false;
                }
                else
                {
                    string query = "SELECT  [Number Of Working Days] FROM WorkingDays";
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
               
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                daysCount =reader.GetInt32(0);
                        }
                        con.Close();

                    int temp = daysCount + Int32.Parse(numericUpDownNWD.Text);
                    if(temp <= 7)
                    {
                        avalibility(EntryID);
                        SqlCommand cmd = new SqlCommand("UPDATE WorkingDays SET [Number Of Working Days] = @NumberOfWorkingDays", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@NumberOfWorkingDays", temp);

                        Count = Convert.ToInt32(temp);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Number of working Days is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNumberOfWorkingDays();
                        ResetNWd();
                        avalibility(Count);
                    }
                    else
                    {
                        metroLabelError.Visible = true;
                    }

                }
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
                metroLabelError.Visible = false;
                int temp = Int32.Parse(numericUpDownNWD.Text);  
                if (temp <= 7)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE WorkingDays SET  [Number Of Working Days] = @NumberOfWorkingDays WHERE EntryID= @EntryID", con);
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
                    metroLabelError.Visible = true;
                }

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
                firstCount = true;
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
                hour = Int32.Parse(numericUpDownHours.Text);
                minutes = Int32.Parse(numericUpDownMinutes.Text);
                timeinMinutes = (hour * 60) + minutes;
                lblTSrt.Text = hour + "." + minutes;
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
            //this.Hide();
            //Working_Days.Add_Number_of_Working_Days workingDays = new Working_Days.Add_Number_of_Working_Days();
            //workingDays.ShowDialog();
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

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnGTlecadd_Click(object sender, EventArgs e)
        {

        }

        private void cmdGTlecsession_Click(object sender, EventArgs e)
        {

        }

        private void btnGTreset_Click(object sender, EventArgs e)
        {

        }

        private void dvgGT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //form 1
        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void lbGTtime_Click(object sender, EventArgs e)
        {

        }

        private void cmdGTlecDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdGTlec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void lblGTday_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGTlecadd_Click_1(object sender, EventArgs e)
        {
            SqlCommand AddtoLecTime = new SqlCommand("INSERT INTO Lecturer_Time VALUES(@LecID, @SessionID, @StartTime, @EndTime, @Dates)", con);
            AddtoLecTime.CommandType = CommandType.Text;
            AddtoLecTime.Parameters.AddWithValue("@LecID", lecturerID);
            AddtoLecTime.Parameters.AddWithValue("@SessionID", selectedSession);
            AddtoLecTime.Parameters.AddWithValue("@StartTime", timeTime[0]);
            AddtoLecTime.Parameters.AddWithValue("@EndTime", timeTime[1]);
            AddtoLecTime.Parameters.AddWithValue("@Dates", daysArray[0]);

            Console.WriteLine("Is this zer0? " + lecturerID);
            con.Open();
            AddtoLecTime.ExecuteNonQuery();
            con.Close();

            SqlCommand AddtoClassTime = new SqlCommand("INSERT INTO Classroom_Time VALUES(@ClassID, @SessionID, @StartTime, @EndTime, @Dates)", con);
            AddtoClassTime.CommandType = CommandType.Text;
            AddtoClassTime.Parameters.AddWithValue("@ClassID", curentRoom);
            AddtoClassTime.Parameters.AddWithValue("@SessionID", selectedSession);
            AddtoClassTime.Parameters.AddWithValue("@StartTime", timeTime[0]);
            AddtoClassTime.Parameters.AddWithValue("@EndTime", timeTime[1]);
            AddtoClassTime.Parameters.AddWithValue("@Dates", daysArray[0]);

            con.Open();
            AddtoClassTime.ExecuteNonQuery();
            con.Close();

            SqlCommand AddtoGroupTime = new SqlCommand("INSERT INTO Group_Time VALUES(@GroupID, @SessionID, @StartTime, @EndTime, @Dates)", con);
            AddtoGroupTime.CommandType = CommandType.Text;
            AddtoGroupTime.Parameters.AddWithValue("@GroupID", groupID);
            AddtoGroupTime.Parameters.AddWithValue("@SessionID", selectedSession);
            AddtoGroupTime.Parameters.AddWithValue("@StartTime", timeTime[0]);
            AddtoGroupTime.Parameters.AddWithValue("@EndTime", timeTime[1]);
            AddtoGroupTime.Parameters.AddWithValue("@Dates", daysArray[0]);

            con.Open();
            AddtoGroupTime.ExecuteNonQuery();
            con.Close();

            System.Windows.Forms.MessageBox.Show("Data added sucessfully");
        }

        private void cmdsessionfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassRooms.Clear();

            if (cmdsessionfaculty.SelectedIndex == 0)
            {
                cmdsessiondepartment.DataSource = ITDepartments;
                string getClassRoomQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Computing%'";

                con.Open();
                SqlCommand getClassRoomCommand = new SqlCommand(getClassRoomQuery, con);

                using (SqlDataReader reader = getClassRoomCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassRooms.Add(reader.GetString(0));
                    }
                }

                con.Close();
            }
            else if(cmdsessionfaculty.SelectedIndex == 1)
            {
                cmdsessiondepartment.DataSource = EngineeringDepartments;
                string getClassRoomQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Engineering%'";

                con.Open();
                SqlCommand getClassRoomCommand = new SqlCommand(getClassRoomQuery, con);

                using (SqlDataReader reader = getClassRoomCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassRooms.Add(reader.GetString(0));
                    }
                }

                con.Close();
            }
            else if (cmdsessionfaculty.SelectedIndex == 2)
            {
                cmdsessiondepartment.DataSource = BusinessDepartments;
                string getClassRoomQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Business%'";

                con.Open();
                SqlCommand getClassRoomCommand = new SqlCommand(getClassRoomQuery, con);

                using (SqlDataReader reader = getClassRoomCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassRooms.Add(reader.GetString(0));
                    }
                }

                con.Close();
            }
            else if (cmdsessionfaculty.SelectedIndex == 3)
            {
                cmdsessiondepartment.DataSource = HumanDepartments;
                string getClassRoomQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%New%'";

                con.Open();
                SqlCommand getClassRoomCommand = new SqlCommand(getClassRoomQuery, con);

                using (SqlDataReader reader = getClassRoomCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassRooms.Add(reader.GetString(0));
                    }
                }
                con.Close();
            }



            if (type == 2)
            {
                string buildingQuery = "";
                List<string> Lecturers1 = new List<string>();
                string faculty = cmdsessionfaculty.SelectedItem.ToString();
                if (faculty.Equals("Humanities and Science"))
                    buildingQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%New%'";
                else if(faculty.Equals("Computing"))
                    buildingQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Computing%'";
                else if(faculty.Equals("Engineering"))
                    buildingQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Engineering%'";
                else if (faculty.Equals("Business"))
                    buildingQuery = "SELECT room_num FROM rooms WHERE building_name LIKE '%Business%'";
             

                con.Open();
                SqlCommand RoomCommand = new SqlCommand(buildingQuery, con);

                using (SqlDataReader reader = RoomCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers1.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers1;
                con.Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdsessiondepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> Lecturers1 = new List<string>();
            if (type == 0)
            {
                string faculty = cmdsessionfaculty.SelectedItem.ToString();
                string department = cmdsessiondepartment.SelectedItem.ToString();
                string initialQuery = "SELECT LecName FROM Lecturers WHERE LecFaculty = '"+ faculty + "' AND LecDepartment = '" + department + "' AND LecCenter = 'Malabe'";

                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers1.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers1;
                con.Close();

            }

            else if (type == 1)
            {
                string department = cmdsessiondepartment.SelectedItem.ToString();
                string initialQuery = "SELECT GenSubGrpNum FROM GenSubGroupNumber WHERE GenSubGrpNum LIKE '%" + department + "%'";
                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers1.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers1;
                con.Close();
            }

        }

        private void metroComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<string> Lecturers1 = new List<string>();
            if (type == 0)
            {
                string faculty = cmdsessionfaculty.SelectedItem.ToString();
                string department = cmdsessiondepartment.SelectedItem.ToString();
                string center = metroComboBox1.SelectedItem.ToString();
                string CenterQuery = "SELECT LecName FROM Lecturers WHERE LecFaculty = '" + faculty + "' AND LecDepartment = '" + department + "' AND LecCenter = '" + center +"'";

                con.Open();
                SqlCommand LecCenterCommand = new SqlCommand(CenterQuery, con);

                using (SqlDataReader reader = LecCenterCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers1.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers1;
                con.Close();
            }

            else if (type == 1)
            {
                string faculty = cmdsessionfaculty.SelectedItem.ToString();
                string department = cmdsessiondepartment.SelectedItem.ToString();
                string center = metroComboBox1.SelectedItem.ToString();
                string CenterQuery = "SELECT LecName FROM Lecturers WHERE LecFaculty = '" + faculty + "' AND LecDepartment = '" + department + "' AND LecCenter = '" + center + "'";

                con.Open();
                SqlCommand LecCenterCommand = new SqlCommand(CenterQuery, con);

                using (SqlDataReader reader = LecCenterCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturers1.Add(reader.GetString(0));
                    }
                }
                cmdsessionlecturer.DataSource = Lecturers1;
                con.Close();
            }
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdsessionlecturer_SelectedIndexChanged(object sender, EventArgs e)
        {

            lecturerName = cmdsessionlecturer.SelectedItem.ToString();

            con.Close();
            con.Open();
            String LecIDQuery = "SELECT LecturerID FROM Lecturers WHERE LecName = '" + lecturerName + "'";
            SqlCommand LecIDCommand = new SqlCommand(LecIDQuery, con);
            using (SqlDataReader reader = LecIDCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    lecturerID = reader.GetInt32(0);
                }
            }
            con.Close();
        }

        private void cmdGTlecsessiontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sessions.Clear();
            if (type == 0)
            {
                string initialQuery = "";
                int sessionType = cmdGTlecsessiontype.SelectedIndex;
                if (sessionType == 0)
                    initialQuery = "SELECT SessionID FROM Sessions WHERE Lecturer = '" + lecturerName + ", '";
                else if (sessionType == 1)
                    initialQuery = "SELECT SessionID, GroupID, Duration FROM Sessions WHERE Lecturer = '" + lecturerName + ", '";
                else if (sessionType == 2)
                    initialQuery = "SELECT SessionID, GroupID, Duration FROM Sessions WHERE Lecturer = '" + lecturerName + ", '";
                else if (sessionType == 3)
                    initialQuery = "SELECT SessionID, GroupID, Duration FROM Sessions WHERE Lecturer = '" + lecturerName + ", '";
                con.Open();
                SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                using (SqlDataReader reader = LecCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Sessions.Add(reader.GetInt32(0));
                    }
                }
                cmdGTlecsession.DataSource = Sessions;
                con.Close();
            }

            else if (type == 2)
            {

            }

            else if (type == 3)
            {

            }
        }

        private void cmdGTlecsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool lectureFlag = false, groupFlag = false, subGroupFlag = false, sessionFlag = false, noLecFlag = false,
                noGroup = false, noRoom = false;
            selectedSession = cmdGTlecsession.SelectedItem.ToString();
      
              string groupQuery = "SELECT GroupID from Sessions WHERE SessionID ='" + selectedSession + "'";
            con.Close();
            con.Open();
            SqlCommand groupCommand = new SqlCommand(groupQuery, con);

                    using (SqlDataReader reader = groupCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groupID = reader.GetString(0);
                        }
                    }

            con.Close();


            List<string> day = new List<string>();
            List<string> selectedDay = new List<string>();

            if (numOfWork == 1)
                day.Add("Monday");
            if (numOfWork == 2)
            {
                day.Add("Monday");
                day.Add("Tuesday");
            }
            if (numOfWork == 3)
            {
                day.Add("Monday");
                day.Add("Tuesday");
                day.Add("Wednesday");
            }
            if (numOfWork == 4)
            {
                day.Add("Monday");
                day.Add("Tuesday");
                day.Add("Wednesday");
                day.Add("Thursday");
            }
            if (numOfWork == 5)
            {
                day.Add("Monday");
                day.Add("Tuesday");
                day.Add("Wednesday");
                day.Add("Thursday");
                day.Add("Friday");
            }
            if (numOfWork == 6)
            {
                day.Add("Monday");
                day.Add("Tuesday");
                day.Add("Wednesday");
                day.Add("Thursday");
                day.Add("Friday");
                day.Add("Saturday");
            }
            if (numOfWork == 7)
            {
                day.Add("Monday");
                day.Add("Tuesday");
                day.Add("Wednesday");
                day.Add("Thursday");
                day.Add("Friday");
                day.Add("Saturday");
                day.Add("Sunday");
            }

            List<string> hours = new List<string>();
            hours.Add("08.30 am,09.30 am");
            hours.Add("09.30 am,10.30 am");
            hours.Add("10.30 am,11.30 am");
            hours.Add("11.30 am,12.30 pm");
            hours.Add("12.30 pm,01.30 pm");
            hours.Add("01.30 pm,02.30 pm");
            hours.Add("02.30 pm,03.30 pm");
            hours.Add("03.30 pm,04.30 pm");
            hours.Add("04.30 pm,05.30 pm");

            foreach (String days in day)
            {
                foreach (String hour in hours)
                {
                    string[] timeArray = hour.Split(',');
                    string initialQuery = "SELECT COUNT(id) FROM NotAvailableTime WHERE SelectedType = 'Lecturers' " +
                        "AND Item = '" + lecturerName + "' AND StartTime = '"+ timeArray[0]+"' AND EndTIme = '"+ timeArray[1]+"'" +
                        " AND Day = '"+ days +"'";
                    con.Open();
                    SqlCommand LecCommand = new SqlCommand(initialQuery, con);

                    using (SqlDataReader reader = LecCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 0)
                                lectureFlag = true;
                        }
                    }

                    con.Close();

                    if (lectureFlag)
                    {
                        string selectSessionQuery = "SELECT COUNT(id) FROM NotAvailableTime WHERE SelectedType = 'Sessions' " +
                       "AND Item = " + selectedSession + "AND StartTime = '" + timeArray[0] + "' AND EndTIme = '" + timeArray[1] + "'" +
                       " AND Day = '" + days + "'";
                        con.Open();
                        SqlCommand sessCommand = new SqlCommand(selectSessionQuery, con);

                        using (SqlDataReader reader = sessCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) == 0)
                                    sessionFlag = true;
                            }
                        }

                        con.Close();

                        if (sessionFlag)
                        {
                            string selectGroupQuery = "SELECT COUNT(id) FROM NotAvailableTime WHERE SelectedType = 'Groups' " +
                           "AND Item = " + groupID + "AND StartTime = '" + timeArray[0] + "' AND EndTIme = '" + timeArray[1] + "'" +
                           " AND Day = '" + days + "'";
                            con.Open();
                            SqlCommand  selectGroupCommand = new SqlCommand(selectSessionQuery, con);

                            using (SqlDataReader reader = selectGroupCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetInt32(0) == 0)
                                        groupFlag = true;
                                }
                            }

                            con.Close();

                            if (groupFlag)
                            {
                                string selectSubGroupQuery = "SELECT COUNT(id) FROM NotAvailableTime WHERE SelectedType = 'Sub-Groups' " +
                               "AND Item = '" + groupID + "' AND StartTime = '" + timeArray[0] + "' AND EndTIme = '" + timeArray[1] + "'" +
                               " AND Day = '" + days + "'";
                                con.Open();
                                SqlCommand subGroupCommand = new SqlCommand(selectSubGroupQuery, con);

                                using (SqlDataReader reader = subGroupCommand.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if (reader.GetInt32(0) == 0)
                                            subGroupFlag = true;
                                    }
                                }

                                con.Close();
                                if (subGroupFlag)
                                {
                                    string checkLecSQL = "SELECT COUNT(Lecturer_Time_ID) FROM Lecturer_Time WHERE StartTime = '"+ timeArray[0] + "' " +
                                        "AND EndTime = '"+ timeArray[1] + "' AND Dates = '"+ days + "' AND LecID ='"+ lecturerID+"'";
                                    con.Open();
                                    SqlCommand checkLecCommand = new SqlCommand(checkLecSQL, con);

                                    using (SqlDataReader reader = checkLecCommand.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            if (reader.GetInt32(0) == 0)
                                                noLecFlag = true;
                                        }
                                    }
                                    con.Close();

                                    if (noLecFlag)
                                    {
                                        string checkGroupSQL = "SELECT COUNT(Group_Time_ID) FROM Group_Time WHERE StartTime = '" + timeArray[0] + "' " +
                                        "AND EndTime = '" + timeArray[1] + "' AND Dates = '" + days + "' AND GroupID ='" + groupID + "'";
                                        con.Open();
                                        SqlCommand checkGroupCommand = new SqlCommand(checkGroupSQL, con);

                                        using (SqlDataReader reader = checkGroupCommand.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                if (reader.GetInt32(0) == 0)
                                                    noGroup = true;
                                            }
                                        }
                                        con.Close();

                                        if (noGroup)
                                        {
                 
                                            string datess = days + "-" + timeArray[0] + "," + timeArray[1];
                                            selectedDay.Add(datess);
                                        }
                                    }
                                    else
                                    {
                                        System.Windows.Forms.MessageBox.Show("Lecturer currently has a session during that time");
                      
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Sub group group is unable to attend");
                                }


                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Main group is unable to attend");
                            }
                        }

                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Session is unable to attend");
                        }

                    }

                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Lecturer is occupied");
                    }
                    con.Close();
                }

            }

            cmdsessionday.DataSource = selectedDay;

        }

        private void cmdsessionday_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cmdsessionday.SelectedItem.ToString();
            daysArray = s.Split('-');
            timeTime = daysArray[1].Split(',');

            bool chooseFlag = false;
            SelectedClassRooms.Clear();
            List<string> tempClass = new List<string>();
            string checkClassSQL = "SELECT ClassID FROM Classroom_Time WHERE StartTime = '" + timeTime[0] + "' " +
             "AND EndTime = '" + timeTime[1] + "' AND Dates = '" + daysArray[0] + "'";
            con.Open();
            SqlCommand checkClassCommand = new SqlCommand(checkClassSQL, con);

            using (SqlDataReader reader = checkClassCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    tempClass.Add(reader.GetString(0));
                }
            }
            con.Close();



            foreach (String room in ClassRooms)
            {
                chooseFlag = false;
                foreach (String room1 in tempClass)
                {
                    if (room.Equals(room1))
                        chooseFlag = true;

                }
                if (!chooseFlag)
                    SelectedClassRooms.Add(room);

            }

            cmdGTclassroom.DataSource = SelectedClassRooms;
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

        private void cmdGTclassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            curentRoom = cmdGTclassroom.SelectedItem.ToString();
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnTSaddts_Click(object sender, EventArgs e)
        {
            metroLabelremainerr.Visible = false;

            if (isValidTs())
            {

                if(timeinMinutes >= 0)
                {
                    if (cmdTSts.SelectedItem.Equals("1 Hour"))
                        timeinMinutes1 = 60;
                    else
                        timeinMinutes1 = 30;
                    int temp;

                    if (timeinMinutes1 <= timeinMinutes)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO TimeSlot VALUES(@Day, @Timeslot, @Occupied)", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Day", cmdTSday.SelectedItem);
                        cmd.Parameters.AddWithValue("@Timeslot", cmdTSts.SelectedItem);
                        cmd.Parameters.AddWithValue("@Occupied", 0);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("  TimeSlot is sucessfully saved ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTimeSlot();
                        temp = timeinMinutes - timeinMinutes1;
                        lblTSrt.Text = temp / 60 + "." + temp % 60;
                        timeinMinutes = temp;
                    }

                    else
                        metroLabelremainerr.Visible = true;
                }

                else
                    metroLabelremainerr.Visible = true;

            }
        }

        private bool isValidTs()
        {
            if (cmdTSday.Text == "" || cmdTSts.Text == "")
            {
                MessageBox.Show("This Field Can not be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void grdTs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EntryID = Convert.ToInt32(grdTs.SelectedRows[0].Cells[0].Value);
            cmdTSday.Text = grdTs.SelectedRows[0].Cells[1].Value.ToString();
            cmdTSts.Text = grdTs.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dgvNWD_Click(object sender, EventArgs e)
        {

        }

        private void dgvNWD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
