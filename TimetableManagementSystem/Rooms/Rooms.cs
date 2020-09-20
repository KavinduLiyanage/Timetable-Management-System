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
    }
}
