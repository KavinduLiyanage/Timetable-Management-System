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
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rooms", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session_cmb.Items.Add(dataRow["SessionID"].ToString());
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

        //adding consecutive session fields
        private void newsession2_btn_Click(object sender, EventArgs e)
        {
            if(session1_cmb.Text != String.Empty) 
            {
                session2_lbl.Visible = true;
                session2_cmb.Visible = true;
                newsession3_btn.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a session");
            }
        }

        private void newsession3_btn_Click(object sender, EventArgs e)
        {
            if (session2_cmb.Text != String.Empty)
            {
                session3_lbl.Visible = true;
                session3_cmb.Visible = true;
                newsession4_btn.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a session");
            }
   
        }

        private void newsession4_btn_Click(object sender, EventArgs e)
        {
            if (session3_cmb.Text != String.Empty)
            {
                session4_lbl.Visible = true;
                session4_cmb.Visible = true;
                newsession5_btn.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a session");
            }
            
        }

        private void newsession6_btn_Click(object sender, EventArgs e)
        {
            if (session4_cmb.Text != String.Empty)
            {
                session5_lbl.Visible = true;
                session5_cmb.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a session");
            }
            
        }

        //selecting a room
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

        //dropdown session 1
        private void session1_cmb_DropDown(object sender, EventArgs e)
        {
            session1_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session1_cmb.Items.Add(dataRow["SessionID"].ToString());
            }
        }
        //dropdown session 2
        private void session2_cmb_DropDown(object sender, EventArgs e)
        {
            //check on the above drop down for duplicate

            session2_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
               session2_cmb.Items.Add(dataRow["SessionID"].ToString());
              
            }   
        }
        //dropdown session 3
        private void session3_cmb_Click(object sender, EventArgs e)
        {
            session3_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session3_cmb.Items.Add(dataRow["SessionID"].ToString());

            }
        }
        //dropdown session 4
        private void session4_cmb_Click(object sender, EventArgs e)
        {
            session4_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session4_cmb.Items.Add(dataRow["SessionID"].ToString());

            }
        }
        //dropdown session 5
        private void session5_cmb_Click(object sender, EventArgs e)
        {
            session5_cmb.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select SessionID from Sessions ", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                session5_cmb.Items.Add(dataRow["SessionID"].ToString());

            }
        }
        //allocating room for consective session
        private void allocateroomconsecsession_btn_Click(object sender, EventArgs e)
        {
            if (consec_room_cmb.Text != string.Empty) 
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Room, ConsecSession1,ConsecSession2,ConsecSession3,ConsecSession4,ConsecSession5 from ConsecSession_Rooms" +
                    " where Room = '" + consec_room_cmb.Text + "' and  ConsecSession1 = '" + session1_cmb.Text + "' and  ConsecSession2 = '" + session2_cmb.Text + "'" +
                    "and  ConsecSession3 = '" + session3_cmb.Text + "'and  ConsecSession4 = '" + session4_cmb.Text + "'" +
                    "and  ConsecSession5 = '" + session5_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Already Exists");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[ConsecSession_Rooms] ([Room],[ConsecSession1],[ConsecSession2],[ConsecSession3],[ConsecSession4],[ConsecSession5]) " +
                        "VALUES ('" + consec_room_cmb.Text + "','" + session1_cmb.Text + "','" + session2_cmb.Text + "','" + session3_cmb.Text + "','" + session4_cmb.Text + "','" + session5_cmb.Text + "' )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Allocated!");
                    con.Close();
                    
                }

            }
            else
            {
                MessageBox.Show("Please add a room", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clr_consec_btn_Click(object sender, EventArgs e)
        {
            consec_room_cmb.SelectedIndex = -1;
            session1_cmb.SelectedIndex = -1;
            session2_cmb.SelectedIndex = -1;
            session3_cmb.SelectedIndex = -1;
            session4_cmb.SelectedIndex = -1;
            session5_cmb.SelectedIndex = -1;
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

        private void non_reserv_room_time_btn_Click(object sender, EventArgs e)
        {
            if ((non_res_room_cmb.Text != string.Empty) && (day_cmb.Text != string.Empty) && (timeslot_cmb.Text != string.Empty))
            {
                //check duplicate before save
                SqlDataAdapter da = new SqlDataAdapter("Select Room, Day,Time from NonReservableTime_Rooms where Room = '" + non_res_room_cmb.Text + "' " +
                    "and  Day = '" + day_cmb.Text + "' and Time = '" + timeslot_cmb.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Time is already allocated as non reservable!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[NonReservableTime_Rooms] ([Room],[Day],[Time]) VALUES ('" + non_res_room_cmb.Text + "','" + day_cmb.Text + "','" + timeslot_cmb.Text + "'  )";
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
            timeslot_cmb.SelectedIndex = -1;
        }

        private void clrnonreserve_btn_Click(object sender, EventArgs e)
        {
            non_res_room_cmb.SelectedIndex = -1;
            clearDayTimeFields();
        }
    }
}
