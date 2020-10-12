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

namespace TimetableManagementSystem.GenerateTimetable
{
    public partial class GenerateTimetable : MetroFramework.Forms.MetroForm
    {

        SqlConnection con = Config.con;
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
    }
}
