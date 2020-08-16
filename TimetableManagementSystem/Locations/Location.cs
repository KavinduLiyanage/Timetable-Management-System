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


namespace TimetableManagementSystem.Locations
{
    public partial class Location : MetroFramework.Forms.MetroForm

    {
        public Location()
        {
            InitializeComponent();
            
        }

        SqlConnection con = new SqlConnection(@"Server=tcp:timetablemngsysdb.database.windows.net,1433;Initial Catalog=TimetableManageSystemDB;Persist Security Info=False;User ID=timetableadmin;Password=imb@manN0tbruce;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      

        private void addloc_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[locations] ([building],[room],[capacity],[room_type]) VALUES ('"+ building_cmb.Text + "','" + room_cmb.Text + "'," + capacity_cmb.Value + ",'" +roomtype_cmb.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted !");
            con.Close();
        }


        //fill combo box with database data
        private void building_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //building_cmb.Items.Clear();
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Building_Name FROM buildings";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);

            ////sqldr = cmd.ExecuteReader();

            ////while(sqldr.Read())
            ////{
            ////    building_cmb.Items.Add(sqldr["Building_Name"]);
            ////}
            ////DataTable dt = new DataTable();
            ////SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            ////sqlda.Fill(dt);

            //foreach(DataRow dr in dt.Rows)
            //{
            //  building_cmb.Items.Add(dr["Building_Name"].ToString());
            //}

            //con.Close();


            
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

            //sqldr = cmd.ExecuteReader();

            //while(sqldr.Read())
            //{
            //    building_cmb.Items.Add(sqldr["Building_Name"]);
            //}
            //DataTable dt = new DataTable();
            //SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            //sqlda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                building_cmb.Items.Add(dr["Building_Name"].ToString());
            }

            con.Close();
        }

        private void room_cmb_DropDown(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT room_num from rooms_tbl where building_name ='" + building_cmb.Text+"'", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            room_cmb.Items.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                room_cmb.Items.Add(dataRow["room_num"].ToString());
            }
        }

        private void clr_btn_Click(object sender, EventArgs e)
        {
            //foreach(var item in this.Controls)
            //{
            //    if(item.GetType().Equals(typeof(ComboBox)))
            //    {
            //        ComboBox cmb1 = item as ComboBox;
            //        cmb1.Text = string.Empty;
            //    }
            //}

            building_cmb.Text = String.Empty;
            room_cmb.Text = String.Empty;
            //capacity_cmb.Value = ValueType.Empty;
            roomtype_cmb.Text = String.Empty;


        }

        public void metroButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT building,room,capacity,room_type FROM locations", con);
            DataTable dtbl = new DataTable();
            sqlDataAdapter.Fill(dtbl);

            loc_dgridv.DataSource = dtbl;
            con.Close();
        }

        private void loc_dgridv_Click(object sender, EventArgs e)
        {
            Locations.UpdateLocationForm ulform = new Locations.UpdateLocationForm();

            ulform.editbuil_cmb.Text = loc_dgridv.CurrentRow.Cells[0].Value.ToString();
            ulform.editroom_cmb.Text = loc_dgridv.CurrentRow.Cells[1].Value.ToString();
            ulform.editcap_txtbox.Text= loc_dgridv.CurrentRow.Cells[2].Value.ToString();
            ulform.editroomtype_cmb.Text = loc_dgridv.CurrentRow.Cells[3].Value.ToString();
            ulform.ShowDialog();

        }
    }

    

}
