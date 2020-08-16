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
    public partial class UpdateLocationForm : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = Config.con;

        public UpdateLocationForm()
        {
            InitializeComponent();
        }

        private void editroom_cmb_DropDown(object sender, EventArgs e)
        {

           
        }

        private void editloc_btn_Click(object sender, EventArgs e)
        {
            Locations.Location locform= new Locations.Location();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE locations SET building = '"+editbuil_cmb.Text+"' ,capacity ='"+editcap_txtbox.Text+"',room_type = '"+editroomtype_cmb+ "' WHERE room ='" + editroom_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated!");
            locform.ShowDialog();
            con.Close();
        }
    }
       
   
}

