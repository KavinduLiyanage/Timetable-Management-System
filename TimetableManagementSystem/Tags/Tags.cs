﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableManagementSystem.Tags
{
    public partial class Tags : MetroFramework.Forms.MetroForm
    {
        public Tags()
        {
            InitializeComponent();
        }

        private void tagNameTxt_Click(object sender, EventArgs e)
        {
            tagNameTxt.Text = "";
        }

        private void tagNameClrBtn_Click(object sender, EventArgs e)
        {
            tagNameTxt.Text = "";
        }

        private void tagNameSearchBox_Click(object sender, EventArgs e)
        {
            tagNameSearchBox.Text = "";
        }

        private void Tags_Load(object sender, EventArgs e)
        {
            String query1 = "Select * from Tags";

            SqlConnection con = Config.con;
            con.Open();

            SqlCommand cmd = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            tagNameData.AutoGenerateColumns = true;
            tagNameData.DataSource = dt;

            con.Close();
        }

        private void tagNameAddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Tags (TagName) VALUES ('" + tagNameTxt.Text + "');";
            cmd.ExecuteNonQuery();

            String query2 = "Select * from Tags";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tagNameData.DataSource = dt;

            con.Close();
        }

        private void tagNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Tags WHERE TagName LIKE '%" + tagNameSearchBox.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tagNameData.DataSource = dt;
            con.Close();
        }

        private void btnSideNavWorking_Click(object sender, EventArgs e)
        {

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
            Tags tag = new Tags();
            tag.ShowDialog();
        }

        private void btnSideNavLocations_Click(object sender, EventArgs e)
        {

        }

        private void btnSideNavStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistics.Statistics stat = new Statistics.Statistics();
            stat.ShowDialog();
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }

        private void btnHeaderSessions_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderRooms_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderAdvanced_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {

        }
    }
}
