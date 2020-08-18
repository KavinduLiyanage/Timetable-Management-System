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

        private void Students_Load(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            SqlDataAdapter adapter1;
            SqlDataAdapter adapter2;
            SqlDataAdapter adapter3;
            SqlDataAdapter adapter4;
            SqlDataAdapter adapter5;
            SqlDataAdapter adapter6;
            SqlDataAdapter adapter7;

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            DataSet ds4 = new DataSet();
            DataSet ds5 = new DataSet();
            DataSet ds6 = new DataSet();
            DataSet ds7 = new DataSet();

            try
            {
                String query1 = "Select * from YearSemester";
                String query2 = "Select * from Programme";
                String query3 = "Select * from GroupNumber";
                String query4 = "Select * from SubGroupNumber";
                String query5 = "Select * from GenGroupNumber";
                String query6 = "Select * from GenSubGroupNumber";
                String query7 = "Select * from YearSemester";

                con.Open();
                adapter1 = new SqlDataAdapter(query1, con);
                adapter2 = new SqlDataAdapter(query2, con);
                adapter3 = new SqlDataAdapter(query3, con);
                adapter4 = new SqlDataAdapter(query4, con);
                adapter5 = new SqlDataAdapter(query5, con);
                adapter6 = new SqlDataAdapter(query6, con);
                adapter7 = new SqlDataAdapter(query7, con);

                adapter1.Fill(ds1);
                adapter2.Fill(ds2);
                adapter3.Fill(ds3);
                adapter4.Fill(ds4);
                adapter5.Fill(ds5);
                adapter6.Fill(ds6);
                adapter7.Fill(ds7);

                yrSemData.AutoGenerateColumns = true;
                yrSemData.DataSource = ds1;
                //string ConName = ds1.Tables[0].Rows[0]["ds1"].ToString();
                //Console.WriteLine(ConName);

                prgData.AutoGenerateColumns = true;
                prgData.DataSource = ds2;
                //string ConName2 = ds2.Tables[0].Rows[0]["ds2"].ToString();
                //Console.WriteLine(ConName2);

                grpNumData.AutoGenerateColumns = true;
                grpNumData.DataSource = ds3;
                //string ConName3 = ds3.Tables[0].Rows[0]["ds3"].ToString();
                //Console.WriteLine(ConName3);

                genIdData.AutoGenerateColumns = true;
                genIdData.DataSource = ds4;
                //string ConName4 = ds4.Tables[0].Rows[0]["ds4"].ToString();
                //Console.WriteLine(ConName4);

                subGrpNumData.AutoGenerateColumns = true;
                subGrpNumData.DataSource = ds5;
                //string ConName5 = ds5.Tables[0].Rows[0]["ds5"].ToString();
                //Console.WriteLine(ConName5);

                genSubIdData.AutoGenerateColumns = true;
                genSubIdData.DataSource = ds6;
                //string ConName6 = ds6.Tables[0].Rows[0]["ds6"].ToString();
                //Console.WriteLine(ConName6);

                viewData.AutoGenerateColumns = true;
                viewData.DataSource = ds7;
                //string ConName7 = ds7.Tables[0].Rows[0]["ds7"].ToString();
                //Console.WriteLine(ConName7);

            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally {
                con.Close();
            }
        }
    }
}
