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

namespace TimetableManagementSystem.Rooms
{
    public partial class Rooms : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = Config.con;

        public Rooms()
        {
            InitializeComponent();
        }

        // SUITABLE ROOMS FOR TAG

        private void tag_cmb_DropDown(object sender, EventArgs e)
        {
            tag_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TagName from Tags", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            //room_cmb.Items.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                tag_cmb.Items.Add(dataRow["TagName"].ToString());
            }
        }

        private void tagroom_cmb_DropDown(object sender, EventArgs e)
        {
            //concatenating rom number and building name
            //SqlCommand sqlcmd = new SqlCommand("select * from Rooms", con);
            //con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    tagroom_cmb.Items.Add(ds.Tables[0].Rows[1][0] + "-" + ds.Tables[0].Rows[1][1]);
            //}
            //con.Close();
            tagroom_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                tagroom_cmb.Items.Add(dataRow["room_num"].ToString());
            }
            
        }

        //allocating suitable room for a tag
        private void allocate_tag_btn_Click(object sender, EventArgs e)
        {

            //add with validation duplicate

            if ((tag_cmb.Text != string.Empty) && (tagroom_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Tag, Room from Tag_Rooms where Tag = '"+tag_cmb.Text+ "' and Room = '" + tagroom_cmb.Text + "' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The selected room is already allocated!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Tag_Rooms] ([Tag],[Room]) VALUES ('" + tag_cmb.Text + "','" + tagroom_cmb.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    clearRoomFieldForTag();
                }
        
            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //add without validation duplicate

            //if ((tag_cmb.Text != string.Empty) && (tagroom_cmb.Text != string.Empty) )
            //{

            //    con.Open();
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "INSERT INTO [dbo].[Tag_Rooms] ([Tag],[Room]) VALUES ('" + tag_cmb.Text + "','" + tagroom_cmb.Text + "')";
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Room Allocated!");
            //    con.Close();

            //    clearRoomFieldForTag();
            //}
            //else
            //{
            //    MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        //clear room combo box after very allocation of a room
        public void clearRoomFieldForTag()
        {
            tagroom_cmb.SelectedIndex = -1;
        }
        
        //clearing all fields of Tag-Room 

        private void clear_tag_btn_Click(object sender, EventArgs e)
        {
            tag_cmb.SelectedIndex = -1;
            tagroom_cmb.SelectedIndex = -1;
        }


        //SUITABLE ROOMS FOR SUBJECT AND TAG

        //drop down for selecting a subject
        private void sub_cmb_DropDown(object sender, EventArgs e)
        {
            sub_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SubName from Subjects ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);           
            foreach (DataRow dataRow in dataTable.Rows)
            {
                sub_cmb.Items.Add(dataRow["SubName"].ToString());
            }
        }
        
        //drop down for selecting a tag
        private void tagsub_cmb_DropDown(object sender, EventArgs e)
        {
            tagsub_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select TagName from Tags", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);           
            foreach (DataRow dataRow in dataTable.Rows)
            {
                tagsub_cmb.Items.Add(dataRow["TagName"].ToString());
            }
        }

        //drop down for selecting a room
        private void tagsub_room_cmb_DropDown(object sender, EventArgs e)
        {
            tagsub_room_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                tagsub_room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //allocating room for subject and tag
        private void allocatetagsub_btn_Click(object sender, EventArgs e)
        {
            if ((sub_cmb.Text != string.Empty) && (tagsub_cmb.Text != string.Empty) && (tagsub_room_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Subject, Tag, Room from SubjectTag_Rooms where Subject = '" + sub_cmb.Text + "'and (Tag = '" + tagsub_cmb.Text + "'  and Room = '" + tagsub_room_cmb.Text + "')", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The room is already allocated for the selected subject and tag");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[SubjectTag_Rooms] ([Subject],[Tag],[Room]) VALUES ('" + sub_cmb.Text + "','" + tagsub_cmb.Text + "','" + tagsub_room_cmb.Text + "' )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    clearRoomFieldForTagSub();
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //clear room field for tag and sub
        public void clearRoomFieldForTagSub()
        {
            tagsub_room_cmb.SelectedIndex = -1;
        }

        //clear all fields in tag_sub
        private void clrtagsub_btn_Click(object sender, EventArgs e)
        {
            sub_cmb.SelectedIndex = -1;
            tagsub_cmb.SelectedIndex = -1;
            tagsub_room_cmb.SelectedIndex = -1;
        }

        //SUITABLE ROOM FOR LECTURER

        //selecting a lecturer
        private void lecturer_cmb_DropDown(object sender, EventArgs e)
        {
            lecturer_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select LecName from Lecturers ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                lecturer_cmb.Items.Add(dataRow["LecName"].ToString());
            }
        }

        //selecting a room for a lecturer
        private void lecroom_cmb_DropDown(object sender, EventArgs e)
        {
            lecroom_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                lecroom_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //allocating room for a lecturer
        private void allocatelecturer_room_btn_Click(object sender, EventArgs e)
        {
            if ((lecturer_cmb.Text != string.Empty) && (lecroom_cmb.Text != string.Empty) )
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select LecturerName, Room from Lecturer_Rooms where LecturerName = '" + lecturer_cmb.Text + "' and  Room = '" + lecroom_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The room is already allocated for the selected lecturer");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Lecturer_Rooms] ([LecturerName],[Room]) VALUES ('" + lecturer_cmb.Text + "','" + lecroom_cmb.Text + "' )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    clearRoomFieldForLecturer();
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearRoomFieldForLecturer()
        {
            
            lecroom_cmb.SelectedIndex = -1;
        }

        private void clrLecturerroom_btn_Click(object sender, EventArgs e)
        {
            lecturer_cmb.SelectedIndex = -1;
            lecroom_cmb.SelectedIndex = -1;
        }


        //SUITABLE ROOM FOR A SESSION

        //selecting a session
        private void session_cmb_DropDown(object sender, EventArgs e)
        {
            session_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID,Lecturer,Subject,Tag from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //session_cmb.Items.Add(dataRow["SessionID"].ToString());
                session_cmb.Items.Add(dataRow["SessionID"].ToString() + " - " + dataRow["Lecturer"].ToString() + " - " + dataRow["Subject"].ToString() + " - " + dataRow["Tag"].ToString());
            }
        }

        //selecting a room
        private void session_room_cmb_DropDown(object sender, EventArgs e)
        {
            session_room_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session_room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //allocating a room
        private void allocatesession_room_btn_Click(object sender, EventArgs e)
        {
            if ((session_cmb.Text != string.Empty) && (session_room_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select SessionID, Room from Session_Rooms where SessionID = '" + session_cmb.Text + "' and  Room = '" + session_room_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The room is already allocated for the selected session");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Session_Rooms] ([SessionID],[Room]) VALUES ('" + session_cmb.Text + "','" + session_room_cmb.Text + "' )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    clearRoomFieldForSession();
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //clear Room Field For Session
        public void clearRoomFieldForSession()
        {
            session_room_cmb.SelectedIndex = -1;
        }

        // clear all fields in session
        private void clr_session_btn_Click(object sender, EventArgs e)
        {
            session_cmb.SelectedIndex = -1;
            session_room_cmb.SelectedIndex = -1;
        }

        //SUITBLE ROOM FOR CONSECUTIVE SESSIONS

        //drop down for a room
        private void consec_room_cmb_DropDown(object sender, EventArgs e)
        {
            consec_room_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                consec_room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //dropdown for consecutive session 
        private void session1_cmb_DropDown(object sender, EventArgs e)
        {
            session1_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select id,Session01, Session02 from ConsecutiveSession ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session1_cmb.Items.Add(dataRow["id"].ToString() + " - " + dataRow["Session01"].ToString() +" - " + dataRow["Session02"].ToString());
                
            }
        }
      
        //allocating room for consective session
        private void allocateroomconsecsession_btn_Click(object sender, EventArgs e)
        {
            if ((consec_room_cmb.Text != string.Empty) && (session1_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Room,ConsecutiveSessionId from ConsecutiveSession_Rooms where Room = '" + consec_room_cmb.Text + "' and  ConsecutiveSessionId = '" + session1_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Room is already allocated for the selected consecutive session! Please choose another");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO[dbo].[ConsecutiveSession_Rooms] ([Room],[ConsecutiveSessionId]) VALUES ('" + consec_room_cmb.Text + "', '" + session1_cmb.Text + "')";                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    session1_cmb.SelectedIndex = -1;
                }

            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clr_consec_btn_Click(object sender, EventArgs e)
        {
            consec_room_cmb.SelectedIndex = -1;
            session1_cmb.SelectedIndex = -1;
            
        }

        // ALLOCATING NON RESERVABLE TIME FOR A ROOM

        //drop down for room
        private void non_res_room_cmb_DropDown(object sender, EventArgs e)
        {
            non_res_room_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                non_res_room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //selecting a time slot
        private void timeslot_cmb_DropDown(object sender, EventArgs e)
        {
        //    starttime_cmb.Items.Clear();
        //    SqlDataAdapter sda = new SqlDataAdapter("select TimeSlot from WorkingTimeSlot", con);
        //    DataTable dataTable = new DataTable();
        //    sda.Fill(dataTable);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        starttime_cmb.Items.Add(dataRow["TimeSlot"].ToString());
        //    }
        }

        private void non_reserv_room_time_btn_Click(object sender, EventArgs e)
        {
            if ((non_res_room_cmb.Text != string.Empty) && (day_cmb.Text != string.Empty) && (starttime_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Room, Day,StartTime,EndTime from NonReservableTime_Rooms where Room = '" + non_res_room_cmb.Text + "' " +
                    "and  Day = '" + day_cmb.Text + "' and StartTime = '" + starttime_cmb.Text + "' and EndTime = '"+endtime_cmb.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Time is already allocated as non reservable!");
                    clearDayTimeFields();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[NonReservableTime_Rooms] ([Room],[Day],[StartTime],[EndTime]) VALUES ('" + non_res_room_cmb.Text + "','" + day_cmb.Text + "','" + starttime_cmb.Text + "','" + endtime_cmb.Text + "'   )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Time is allocated as non reservable for the selected room !");
                    con.Close();
                    clearDayTimeFields();
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearDayTimeFields()
        {
            day_cmb.SelectedIndex = -1;
            starttime_cmb.SelectedIndex = -1;
            endtime_cmb.SelectedIndex = -1;
        }

        private void clrnonreserve_btn_Click(object sender, EventArgs e)
        {
            non_res_room_cmb.SelectedIndex = -1;
            clearDayTimeFields();
        }

        //SUITABLE ROOM FOR GROUP/SUB GROUP

        //selecing a group
        private void grp_cmb_DropDown(object sender, EventArgs e)
        {
            grp_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select GenGrpNum from GenGroupNumber", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                grp_cmb.Items.Add(dataRow["GenGrpNum"].ToString());
            }
        }

        //selecting a sub group
        private void subgrp_cmb_DropDown(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT s.GenSubGrpNum from GenSubGroupNumber s, GenGroupNumber g" +
                " where  g.id = s.GenGroupNumberRef and g.GenGrpNum ='" + grp_cmb.Text + "'", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            subgrp_cmb.Items.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                subgrp_cmb.Items.Add(dataRow["GenSubGrpNum"].ToString());
            }
        }

        //selecting a room
        private void grproom_cmb_DropDown(object sender, EventArgs e)
        {
            grproom_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                grproom_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        //allocating a room for a group/sub group
        private void grpallocateroom_btn_Click(object sender, EventArgs e)
        {
            if ((grp_cmb.Text != string.Empty) && (subgrp_cmb.Text != string.Empty) && (grproom_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select GroupNum, SubGroupNum, Room from GroupSubGroup_Rooms" +
                    " where GroupNum = '" + grp_cmb.Text + "' and  SubGroupNum = '" + subgrp_cmb.Text + "'and  Room = '" + grproom_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The room is already allocated for the selected group and sub group!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[GroupSubGroup_Rooms] ([GroupNum],[SubGroupNum],[Room]) " +
                        "VALUES ('" + grp_cmb.Text + "','" + subgrp_cmb.Text + "','" + grproom_cmb.Text + "'  )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated Successfully!");
                    con.Close();
                    grproom_cmb.SelectedIndex = -1;
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //clear all data in group/sub group
        private void clr_grp_btn_Click(object sender, EventArgs e)
        {
            grp_cmb.SelectedIndex = -1;
            subgrp_cmb.SelectedIndex = -1;
            grproom_cmb.SelectedIndex = -1;
        }


        //SIDE NAV BAR - BUTTON LINKS

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

        //HEADER NAAV BAR - BUTTON LINKS

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
            Rooms rooms = new Rooms();
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
    }
}
