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
                SqlDataAdapter da = new SqlDataAdapter("Select Tag, Room from Tag_Rooms where Tag = '"+tag_cmb.Text+ "' or Room = '" + tagroom_cmb.Text + "' ", con);
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
    }
}
