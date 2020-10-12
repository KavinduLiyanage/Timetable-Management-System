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
using System.Collections;

namespace TimetableManagementSystem.GenerateTimetable
{
    public partial class GenerateTimetable : MetroFramework.Forms.MetroForm
    {

        public SqlConnection con = Config.con;
        public int hr = 8;
        public int min = 30;
        public int sec = 0;
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

            this.genGrpCmb.DataSource = null;
            genGrpCmb.Items.Clear();

            string query2 = "select id, GenGrpNum FROM GenGroupNumber";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            con.Open();
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "GenGroupNumber");

            genGrpCmb.DisplayMember = "GenGrpNum";
            genGrpCmb.ValueMember = "id";
            genGrpCmb.DataSource = ds2.Tables["GenGroupNumber"];

            con.Close();
            genGrpCmb.SelectedIndex = -1;



            this.genLecCmb.DataSource = null;
            genLecCmb.Items.Clear();

            string query3 = "select LecturerID, LecName FROM Lecturers";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            con.Open();
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "Lecturers");

            genLecCmb.DisplayMember = "LecName";
            genLecCmb.ValueMember = "LecturerID";
            genLecCmb.DataSource = ds3.Tables["Lecturers"];

            con.Close();
            genLecCmb.SelectedIndex = -1;



            this.genRoomCmb.DataSource = null;
            genRoomCmb.Items.Clear();

            string query4 = "select room_num FROM Rooms";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            con.Open();
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "Rooms");

            genRoomCmb.DisplayMember = "room_num";
            genRoomCmb.ValueMember = "room_num";
            genRoomCmb.DataSource = ds4.Tables["Rooms"];

            con.Close();
            genRoomCmb.SelectedIndex = -1;

            daege.SelectedTab = metroTabPage3;

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

        private void button2_Click(object sender, EventArgs e)
        {

            hr = 8;
            min = 30;
            sec = 0;

        String query1 = "select Subject,GroupID,SubjectCode,Tag,Duration,'1' from sessions where Lecturer LIKE '%" + genLecCmb.Text + "%'";

            SqlCommand cmd = new SqlCommand(query1, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            dvgGTstudentgroup.ColumnCount = 8;
            dvgGTstudentgroup.Columns[0].Name = "";
            dvgGTstudentgroup.Columns[1].Name = "Monday";
            dvgGTstudentgroup.Columns[2].Name = "Tuesday";
            dvgGTstudentgroup.Columns[3].Name = "Wednesday";
            dvgGTstudentgroup.Columns[4].Name = "Thursday";
            dvgGTstudentgroup.Columns[5].Name = "Friday";
            dvgGTstudentgroup.Columns[6].Name = "Saturday";
            dvgGTstudentgroup.Columns[7].Name = "Sunday";

            System.IO.StringWriter sw;
            string output;
            int xCount = 1;
            int yCount = 0;
            string[,] Tablero = new string[5, 8];


            for (int k = 0; k < Tablero.GetLength(0); k++)
            {
                for (int l = 0; l < Tablero.GetLength(1); l++)
                {
                    Tablero[k, l] = " --- ";
                }
            }

            // Loop through each row in the table.
            foreach (DataRow row in dt.Rows)
            {
                sw = new System.IO.StringWriter();

                // Loop through each column.
                foreach (DataColumn col in dt.Columns)
                {
                    // Output the value of each column's data.
                    sw.Write(row[col].ToString() + "\n");
                }

                output = sw.ToString();

                // Trim off the trailing ", ", so the output looks correct.
                if (output.Length > 2)
                    output = output.Substring(0, output.Length - 2);


                if (yCount == 5)
                {
                    yCount = 0;
                    xCount++;
                }
                try
                {

                    Tablero[yCount, xCount] = output;
                    yCount++;
                }
                catch (Exception ex)
                {
                }
            }

            do
            {
                foreach (DataGridViewRow row in dvgGTstudentgroup.Rows)
                {
                    try
                    {
                        dvgGTstudentgroup.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dvgGTstudentgroup.Rows.Count > 1);


            for (int k = 0; k < Tablero.GetLength(0); k++)
            {
                var arlist1 = new ArrayList();

                for (int l = 0; l < Tablero.GetLength(1); l++)
                {
                    arlist1.Add(Tablero[k, l]);
                }

                string srrr = (string)arlist1[1];
                string srrr2 = srrr.Substring(srrr.Length - 2);

                string[] row = new string[] {
                    hr + "." + min,
                    (string) arlist1[1],
                    (string) arlist1[2],
                    (string) arlist1[3],
                    (string) arlist1[4],
                    (string) arlist1[5],
                    (string) arlist1[6],
                    (string) arlist1[7]
                };

                try
                {
                    timeCalc(int.Parse(srrr2.Trim()), 0, 0);
                }
                catch (Exception ex) {
                
                }

                dvgGTstudentgroup.Rows.Add(row);
            }
        }

        private void btnGTCRgenerate_Click(object sender, EventArgs e)
        {
            hr = 8;
            min = 30;
            sec = 0;

            String query1 = "select Lecturer,Subject,SubjectCode,Tag,Duration,'1' from sessions where GroupID LIKE '%" + genGrpCmb.Text + "%'";

            SqlCommand cmd = new SqlCommand(query1, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            dgvWT.ColumnCount = 8;
            dgvWT.Columns[0].Name = "";
            dgvWT.Columns[1].Name = "Monday";
            dgvWT.Columns[2].Name = "Tuesday";
            dgvWT.Columns[3].Name = "Wednesday";
            dgvWT.Columns[4].Name = "Thursday";
            dgvWT.Columns[5].Name = "Friday";
            dgvWT.Columns[6].Name = "Saturday";
            dgvWT.Columns[7].Name = "Sunday";

            System.IO.StringWriter sw;
            string output;
            int xCount = 1;
            int yCount = 0;
            string[,] Tablero = new string[5, 8];


            for (int k = 0; k < Tablero.GetLength(0); k++)
            {
                for (int l = 0; l < Tablero.GetLength(1); l++)
                {
                    Tablero[k, l] = " --- ";
                }
            }

            // Loop through each row in the table.
            foreach (DataRow row in dt.Rows)
            {
                sw = new System.IO.StringWriter();

                // Loop through each column.
                foreach (DataColumn col in dt.Columns)
                {
                    // Output the value of each column's data.
                    sw.Write(row[col].ToString() + "\n");
                }

                output = sw.ToString();

                // Trim off the trailing ", ", so the output looks correct.
                if (output.Length > 2)
                    output = output.Substring(0, output.Length - 2);


                if (yCount == 5)
                {
                    yCount = 0;
                    xCount++;
                }
                try
                {

                    Tablero[yCount, xCount] = output;
                    yCount++;
                }
                catch (Exception ex)
                {
                }
            }

            do
            {
                foreach (DataGridViewRow row in dgvWT.Rows)
                {
                    try
                    {
                        dgvWT.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dgvWT.Rows.Count > 1);


            for (int k = 0; k < Tablero.GetLength(0); k++)
            {
                var arlist1 = new ArrayList();

                for (int l = 0; l < Tablero.GetLength(1); l++)
                {
                    arlist1.Add(Tablero[k, l]);
                }

                string srrr = (string)arlist1[1];
                string srrr2 = srrr.Substring(srrr.Length - 2);

                string[] row = new string[] {
                    hr + "." + min,
                    (string) arlist1[1],
                    (string) arlist1[2],
                    (string) arlist1[3],
                    (string) arlist1[4],
                    (string) arlist1[5],
                    (string) arlist1[6],
                    (string) arlist1[7]
                };

                try
                {
                    timeCalc(int.Parse(srrr2.Trim()), 0, 0);
                }
                catch (Exception ex) {
                }

                dgvWT.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timeCalc(int hr1, int min1, int sec1) {

            sec += sec1;

            if (sec > 60)
            {
                min++;
                sec -= 60;
            }

            min += min1;

            if (min > 60)
            {
                hr++;
                min -= 60;
            }

            hr += hr1;
        }

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerateTimetable generatetimetable = new GenerateTimetable();
            generatetimetable.ShowDialog();
        }
    }
}
