using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableManagementSystem.Students
{
    public partial class Students : MetroFramework.Forms.MetroForm
    {
        public Students()
        {
            InitializeComponent();
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            yrSemSearchBox.Text = "";
        }

        private void prgBtn_Click(object sender, EventArgs e)
        {
            prgBtn.Text = "";
        }

        private void prgClrBtn_Click(object sender, EventArgs e)
        {
            prgBtn.Text = "";
        }

        private void prgSearchBox_Click(object sender, EventArgs e)
        {
            prgSearchBox.Text = "";
        }

        private void yearTxt_Click(object sender, EventArgs e)
        {
            yearTxt.Text = "";
        }

        private void semTxt_Click(object sender, EventArgs e)
        {
            semTxt.Text = "";
        }

        private void yrSemClrBtn_Click(object sender, EventArgs e)
        {
            yearTxt.Text = "";
            semTxt.Text = "";
        }

        private void grpNumTxt_Click(object sender, EventArgs e)
        {
            grpNumTxt.Text = "";
        }

        private void grpNumClrBtn_Click(object sender, EventArgs e)
        {
            grpNumTxt.Text = "";
        }

        private void grpNumSearchBox_Click(object sender, EventArgs e)
        {
            grpNumSearchBox.Text = "";
        }

        private void gentedIdNumTxt_Click(object sender, EventArgs e)
        {

        }

        private void genIdSearchBox_Click(object sender, EventArgs e)
        {
            genIdSearchBox.Text = "";
        }

        private void subGrpNumTxt_Click(object sender, EventArgs e)
        {
            subGrpNumTxt.Text = "";
        }

        private void subGrpNumClrBtn_Click(object sender, EventArgs e)
        {
            subGrpNumTxt.Text = "";
        }

        private void subGrpNumSearchBox_Click(object sender, EventArgs e)
        {
            subGrpNumSearchBox.Text = "";
        }

        private void genSubIdSearchBox_Click(object sender, EventArgs e)
        {
            genSubIdSearchBox.Text = "";
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }

        private void yrSemAddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO YearSemester (Year, Semester) VALUES (" + yearTxt.Text + ", '" + semTxt.Text + "');";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void addPrgBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Programme (Programme) VALUES ('" + prgBtn.Text + "');";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void grpNumAddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO GroupNumber (GrpNum) VALUES ('" + grpNumTxt.Text + "');";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void subGrpNumAddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO SubGroupNumber (SubGrpNum) VALUES ('" + subGrpNumTxt.Text + "');";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
