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

namespace TimetableManagementSystem.Locations
{
    public partial class Location : MetroFramework.Forms.MetroForm

    {
        public Location()
        {
            InitializeComponent();

        }

        SqlConnection con = Config.con;

        private void LoadLocations()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from locations", con);
            DataTable dt = new DataTable();



            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);


            loc_dgridv.AutoGenerateColumns = true;
            loc_dgridv.DataSource = dt;
            con.Close();
        }

        private void addloc_btn_Click(object sender, EventArgs e)
        {
            if ((building_cmb.Text != string.Empty) && (room_cmb.Text != string.Empty) && (capacity_cmb.Text != string.Empty)
                && (roomtype_cmb.Text != string.Empty) )
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [dbo].[locations] ([building],[room],[capacity],[room_type]) VALUES ('" + building_cmb.Text + "','" + room_cmb.Text + "'," + capacity_cmb.Value + ",'" + roomtype_cmb.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Location Added!");
                con.Close();

                LoadLocations();
                ClearLocationData();
                ClearUpdateLocDetails();
                loc_tabcontrol.SelectedTab = viewloc_tab;                

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //fill combo box with database data
        private void building_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void building_cmb_DropDown(object sender, EventArgs e)
        {
            building_cmb.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Building_Name FROM buildings";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                building_cmb.Items.Add(dr["Building_Name"].ToString());
            }

            con.Close();
        }

        private void room_cmb_DropDown(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT room_num from rooms where building_name ='" + building_cmb.Text + "'", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            room_cmb.Items.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        private void ClearLocationData()
        {
            building_cmb.SelectedIndex = -1;
            room_cmb.SelectedIndex = -1;
            capacity_cmb.Value = 0;
            roomtype_cmb.SelectedIndex = -1;

        }

        private void clr_btn_Click(object sender, EventArgs e)
        {

            ClearLocationData();

        }

        private void ClearUpdateLocDetails()
        {
            editroom_cmb.SelectedIndex = -1;
            edit_building_txt_box.Clear();
            editcap_cmb.Value = 0;
            room_type_txt_box.SelectedIndex = -1;
        }

        

        private void editroom_cmb_DropDown(object sender, EventArgs e)
        {
    
            editroom_cmb.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT room FROM locations";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                editroom_cmb.Items.Add(dr["room"].ToString());
            }

            con.Close();

        }

        private void editloc_btn_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE locations SET capacity ='" + editcap_cmb.Text + "',room_type = '" + room_type_txt_box.Text + "' WHERE room ='" + editroom_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Location Updated!");
            con.Close();

            LoadLocations();
            ClearUpdateLocDetails();
            loc_tabcontrol.SelectedTab = viewloc_tab;

        }

        private void Location_Load(object sender, EventArgs e)
        {
            LoadLocations();

        }

        private void loc_dgridv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edit_building_txt_box.Text = loc_dgridv.CurrentRow.Cells[0].Value.ToString();
            editroom_cmb.Text = loc_dgridv.CurrentRow.Cells[1].Value.ToString();
            editcap_cmb.Text = loc_dgridv.CurrentRow.Cells[2].Value.ToString();
            room_type_txt_box.Text = loc_dgridv.CurrentRow.Cells[3].Value.ToString();
        }


        private void editroom_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM locations WHERE room = '" + editroom_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string r_building = (string)dr["building"].ToString();
                edit_building_txt_box.Text = r_building;
                //editbuil_cmb.Text= r_building;

                string r_capacity = (string)dr["capacity"].ToString();
                editcap_cmb.Text = r_capacity;

                string r_type = (string)dr["room_type"].ToString();
                room_type_txt_box.Text = r_type;
                //editbuil_cmb.Text = r_type;
            }
            con.Close();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM locations WHERE room = '" + editroom_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Location Deleted!");
            con.Close();

            LoadLocations();
            loc_tabcontrol.SelectedTab = viewloc_tab;


        }


        private void search_txt_box_TextChanged(object sender, EventArgs e)
        {
            

            if (search_by_cmb.Text == "Building")
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM locations WHERE building LIKE '%" + search_txt_box.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                loc_dgridv.DataSource = dt;
                con.Close();

            }


            if (search_by_cmb.Text == "Room")
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM locations WHERE room LIKE '%"+ search_txt_box .Text+ "%'",con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                loc_dgridv.DataSource = dt;
                con.Close();

            }

            if (search_by_cmb.Text == "Capacity")
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM locations WHERE capacity LIKE '%" + search_txt_box.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                loc_dgridv.DataSource = dt;
                con.Close();

            }

            if (search_by_cmb.Text == "Room Type")
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM locations WHERE room_type LIKE '%" + search_txt_box.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                loc_dgridv.DataSource = dt;
                con.Close();

            }


        }

        private void loc_dgridv_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            loc_dgridv.Sort(loc_dgridv.Columns[0], ListSortDirection.Ascending);
            loc_dgridv.Sort(loc_dgridv.Columns[1], ListSortDirection.Ascending);
            loc_dgridv.Sort(loc_dgridv.Columns[2], ListSortDirection.Descending);
            loc_dgridv.Sort(loc_dgridv.Columns[3], ListSortDirection.Ascending);
        }


        //----------------------------Side Nav Bar Buttons' Links------------------------------------------

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


        //-----------------header nav buttons--------------------------------------------
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

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerateTimetable.GenerateTimetable generatetimetable = new GenerateTimetable.GenerateTimetable();
            generatetimetable.ShowDialog();
        }

        //-------------events not in use---------------
        public void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void loc_dgridv_Click(object sender, EventArgs e)
        {


        }

        private void editbuil_cmb_DropDown(object sender, EventArgs e)
        {

        }

        private void loc_dgridv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}

