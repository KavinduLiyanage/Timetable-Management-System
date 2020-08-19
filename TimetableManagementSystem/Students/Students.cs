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

            String query1 = "Select * from YearSemester";

            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;

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

            String query2 = "Select * from Programme";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;

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

            String query3 = "Select * from GroupNumber";

            SqlDataAdapter sda = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;


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

            String query4 = "Select * from SubGroupNumber";

            SqlDataAdapter sda = new SqlDataAdapter(query4, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;

            con.Close();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            String query1 = "Select * from YearSemester";
            String query2 = "Select * from Programme";
            String query3 = "Select * from GroupNumber";
            String query4 = "Select * from SubGroupNumber";
            String query5 = "Select * from GenGroupNumber";
            String query6 = "Select * from GenSubGroupNumber";
            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlConnection con = Config.con;
            con.Open();

            SqlCommand cmd = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            SqlCommand cmd2 = new SqlCommand(query2, con);
            DataTable dt2 = new DataTable();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);

            SqlCommand cmd3 = new SqlCommand(query3, con);
            DataTable dt3 = new DataTable();
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            dt3.Load(sdr3);

            SqlCommand cmd4 = new SqlCommand(query4, con);
            DataTable dt4 = new DataTable();
            SqlDataReader sdr4 = cmd4.ExecuteReader();
            dt4.Load(sdr4);

            SqlCommand cmd5 = new SqlCommand(query5, con);
            DataTable dt5 = new DataTable();
            SqlDataReader sdr5 = cmd5.ExecuteReader();
            dt5.Load(sdr5);

            SqlCommand cmd6 = new SqlCommand(query6, con);
            DataTable dt6 = new DataTable();
            SqlDataReader sdr6 = cmd6.ExecuteReader();
            dt6.Load(sdr6);

            SqlCommand cmd7 = new SqlCommand(query7, con);
            DataTable dt7 = new DataTable();
            SqlDataReader sdr7 = cmd7.ExecuteReader();
            dt7.Load(sdr7);



            yrSemData.AutoGenerateColumns = true;
            yrSemData.DataSource = dt;

            prgData.AutoGenerateColumns = true;
            prgData.DataSource = dt2;

            grpNumData.AutoGenerateColumns = true;
            grpNumData.DataSource = dt3;

            genIdData.AutoGenerateColumns = true;
            genIdData.DataSource = dt4;

            subGrpNumData.AutoGenerateColumns = true;
            subGrpNumData.DataSource = dt5;

            genSubIdData.AutoGenerateColumns = true;
            genSubIdData.DataSource = dt6;

            viewData.AutoGenerateColumns = true;
            viewData.DataSource = dt7;

            con.Close();
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM locations WHERE building LIKE '%" + searchBox.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;
            con.Close();
        }

        private void yrSemSearchBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM YearSemester WHERE Year LIKE '%" + yrSemSearchBox.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;
            con.Close();
        }

        private void conAddBtn_Click(object sender, EventArgs e)
        {

            String query5 = "Select * from GenGroupNumber";


            SqlConnection con = Config.con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query5, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;
            con.Close();
        }

        private void conSubAddBtn_Click(object sender, EventArgs e)
        {

            String query6 = "Select * from GenSubGroupNumber";


            SqlConnection con = Config.con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query6, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;
            con.Close();
        }
    }
}
