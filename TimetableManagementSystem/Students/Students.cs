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
using TimetableManagementSystem.Tags;

namespace TimetableManagementSystem.Students
{
    public partial class Students : MetroFramework.Forms.MetroForm
    {

        public string[] allOutcome;
        public List<string[]> list = new List<string[]>();
        public string[] allOutcome2;
        public List<string> list2 = new List<string>();
        public string[] sortedOutcome;
        public List<string[]> list3 = new List<string[]>();

        public string[] allOutcome3;
        public List<string[]> list4 = new List<string[]>();
        public string[] allOutcome4;
        public List<string> list5 = new List<string>();
        public string[] sortedOutcome2;
        public List<string[]> list6 = new List<string[]>();

        int grpNumID;
        int subGrpNumID;
        int YrSemID;
        int prgID;
        int genGrpID1;
        int genSubGrpID1;
        int no1 = 1;
        int no2 = 1;

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
            //prgBtn.Text = "";
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
            //yearTxt.Text = "";
        }

        private void semTxt_Click(object sender, EventArgs e)
        {
            //semTxt.Text = "";
        }

        private void yrSemClrBtn_Click(object sender, EventArgs e)
        {
            yearTxt.Text = "";
            semTxt.Text = "";
        }

        private void grpNumTxt_Click(object sender, EventArgs e)
        {
            //grpNumTxt.Text = "";
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
            //subGrpNumTxt.Text = "";
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

            if ((yearTxt.Text != string.Empty) && (semTxt.Text != string.Empty))
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

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;

                con.Close();

                MessageBox.Show("Year and Semester Added Successfully", "Added Successful");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addPrgBtn_Click(object sender, EventArgs e)
        {
            if ((prgBtn.Text != string.Empty))
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
                prgData.DataSource = dt;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;

                con.Close();

                MessageBox.Show("Programme Added Successfully", "Added Successful");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grpNumAddBtn_Click(object sender, EventArgs e)
        {

            if ((grpNumTxt.Text != string.Empty))
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
                grpNumData.DataSource = dt;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Group Number Added Successfully", "Added Successful");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subGrpNumAddBtn_Click(object sender, EventArgs e)
        {

            if ((subGrpNumTxt.Text != string.Empty))
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
                subGrpNumData.DataSource = dt;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;

                con.Close();

                MessageBox.Show("Sub-Group Added Successfully", "Added Successful");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Students_Load(object sender, EventArgs e)
        {
            String query1 = "Select * from YearSemester";
            String query2 = "Select * from Programme";
            String query3 = "Select * from GroupNumber";
            String query4 = "select id,GenGrpNum from GenGroupNumber";
            String query5 = "Select * from SubGroupNumber";
            String query6 = "select id,GenSubGrpNum from GenSubGroupNumber";
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

            if (srtDrpDwn.Text=="") {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and YS.Year LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Year")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and YS.Year LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Semester")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and YS.Semester LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Programme")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and P.Programme LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Group No")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and GNo.GrpNum LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Generated Group No")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and GS.GenGrpNum LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Sub Group No")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and SubGNo.SubGrpNum LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
            else if (srtDrpDwn.Text == "Generated Sub Group No")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id and GSG.GenSubGrpNum LIKE '%" + searchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                viewData.DataSource = dt;
                con.Close();
            }
        }

        private void yrSemSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (yrSemSrtDrpDwn.Text == "Year")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM YearSemester WHERE Year LIKE '%" + yrSemSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                yrSemData.DataSource = dt;
                con.Close();
            }
            else if (yrSemSrtDrpDwn.Text == "Semester")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM YearSemester WHERE Semester LIKE '%" + yrSemSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                yrSemData.DataSource = dt;
                con.Close();
            }
            else if (yrSemSrtDrpDwn.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM YearSemester WHERE id LIKE '%" + yrSemSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                yrSemData.DataSource = dt;
                con.Close();
            }
            else if (yrSemSrtDrpDwn.Text == "") {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM YearSemester WHERE Year LIKE '%" + yrSemSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                yrSemData.DataSource = dt;
                con.Close();
            }
        }

        private void conAddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            foreach (string[] allItem in list3)
            {
                cmd.CommandText = "INSERT INTO [dbo].[GenGroupNumber] ([GenGrpNum],[yearSemRef],[programmeRef],[GroupNumber]) VALUES('" + allItem[0] + "'," + allItem[1] + "," + allItem[2] + "," + allItem[3] + ")";
                cmd.ExecuteNonQuery();
            }

            String query1 = "select id,GenGrpNum from GenGroupNumber";

            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            genIdData.DataSource = dt;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();

            MessageBox.Show("IDs Added Successfully", "Added Successful");
        }

        private void conSubAddBtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = Config.con;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            foreach (string[] allItem in list6)
            {
                cmd.CommandText = "INSERT INTO [dbo].[GenSubGroupNumber]([GenSubGrpNum],[GenGroupNumberRef],[SubGroupNumberRef]) VALUES('" + allItem[0] + "'," + allItem[1] + "," + allItem[2] + ")";
                cmd.ExecuteNonQuery();
            }

            String query6 = "select id,GenSubGrpNum from GenSubGroupNumber";
            SqlDataAdapter sda = new SqlDataAdapter(query6, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            genSubIdData.DataSource = dt;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();


            MessageBox.Show("IDs Added Successfully", "Added Successful");
        }

        private void subGrpNumSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (subGrpNumSrtDrpDwn.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SubGroupNumber WHERE SubGrpNum LIKE '%" + subGrpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
            else if (subGrpNumSrtDrpDwn.Text == "Group Number")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SubGroupNumber WHERE SubGrpNum LIKE '%" + subGrpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
            else if (subGrpNumSrtDrpDwn.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SubGroupNumber WHERE id LIKE '%" + subGrpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
        }

        private void prgSearchBox_TextChanged(object sender, EventArgs e)
        {

            if (prgSrtDrpDwn.Text == "Programme")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Programme WHERE Programme LIKE '%" + prgSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                prgData.DataSource = dt;
                con.Close();
            }
            else if (prgSrtDrpDwn.Text == "ID") {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Programme WHERE id LIKE '%" + prgSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                prgData.DataSource = dt;
                con.Close();
            }
            else if (prgSrtDrpDwn.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Programme WHERE Programme LIKE '%" + prgSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                prgData.DataSource = dt;
                con.Close();
            }
        }

        private void grpNumSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (grpNumSrtDrpDwn.Text == "Group Number")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GroupNumber WHERE GrpNum LIKE '%" + grpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grpNumData.DataSource = dt;
                con.Close();
            }
            else if (grpNumSrtDrpDwn.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GroupNumber WHERE id LIKE '%" + grpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grpNumData.DataSource = dt;
                con.Close();
            }
            else if (grpNumSrtDrpDwn.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GroupNumber WHERE GrpNum LIKE '%" + grpNumSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grpNumData.DataSource = dt;
                con.Close();
            }
        }

        private void genIdSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (genIdSrtDrpDwn.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenGrpNum FROM GenGroupNumber WHERE GenGrpNum LIKE '%" + genIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                genIdData.DataSource = dt;
                con.Close();
            }
            else if (genIdSrtDrpDwn.Text == "Group Number")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenGrpNum FROM GenGroupNumber WHERE GenGrpNum LIKE '%" + genIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                genIdData.DataSource = dt;
                con.Close();
            }
            else if (genIdSrtDrpDwn.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenGrpNum FROM GenGroupNumber WHERE id LIKE '%" + genIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                genIdData.DataSource = dt;
                con.Close();
            }
        }

        private void genSubIdSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (genIdSrtDrpDwn.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenSubGrpNum FROM GenSubGroupNumber WHERE GenSubGrpNum LIKE '%" + genSubIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
            else if (genIdSrtDrpDwn.Text == "Group Number")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenSubGrpNum FROM GenSubGroupNumber WHERE GenSubGrpNum LIKE '%" + genSubIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
            else if (genIdSrtDrpDwn.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id,GenSubGrpNum FROM GenSubGroupNumber WHERE id LIKE '%" + genSubIdSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;
                con.Close();
            }
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
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
            Students stu = new Students();
            stu.ShowDialog();
        }

        private void btnSideNavTags_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tags.Tags tag = new Tags.Tags();
            tag.ShowDialog();
        }

        private void btnSideNavStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistics.Statistics stat = new Statistics.Statistics();
            stat.ShowDialog();
        }

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

        private void btnSideNavLocations_Click(object sender, EventArgs e)
        {
            this.Hide();
            Locations.Location loc = new Locations.Location();
            loc.ShowDialog();
        }

        private void grpNumEditBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE GroupNumber SET GrpNum = '" + grpNumTxt.Text + "' WHERE id = '" + grpNumID + "'";
            cmd.ExecuteNonQuery();

            String query2 = "Select * from GroupNumber";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            grpNumData.DataSource = dt;

            String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

            SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
            DataTable dt22 = new DataTable();
            sda22.Fill(dt22);
            genSubIdData.DataSource = dt22;

            String query4 = "select id, GenGrpNum from GenGroupNumber";

            SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
            DataTable dt33 = new DataTable();
            sda33.Fill(dt33);
            genIdData.DataSource = dt33;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();

            MessageBox.Show("Group Number Updated Successfully","Update Successfully");
        }

        private void grpNumDltBtn_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from GroupNumber where id = '" + grpNumID + "'";
                cmd.ExecuteNonQuery();


                String query2 = "Select * from GroupNumber";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grpNumData.DataSource = dt;

                String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
                DataTable dt22 = new DataTable();
                sda22.Fill(dt22);
                genSubIdData.DataSource = dt22;

                String query4 = "select id, GenGrpNum from GenGroupNumber";

                SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
                DataTable dt33 = new DataTable();
                sda33.Fill(dt33);
                genIdData.DataSource = dt33;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Group Number Deleted Succesfully", "Delete Successful");

                grpNumTxt.Text = "";
            }
        }

        private void grpNumData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = grpNumData.Rows[index];
                grpNumID = Int32.Parse(selectRow.Cells[0].Value.ToString());
                grpNumTxt.Text = selectRow.Cells[1].Value.ToString();
            }
        }

        private void subGrpNumData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = subGrpNumData.Rows[index];
                subGrpNumID = Int32.Parse(selectRow.Cells[0].Value.ToString());
                subGrpNumTxt.Text = selectRow.Cells[1].Value.ToString();
            }
        }

        private void subGrpNumEditBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE SubGroupNumber SET SubGrpNum = '" + subGrpNumTxt.Text + "' WHERE id = '" + subGrpNumID + "'";
            cmd.ExecuteNonQuery();

            String query2 = "Select * from SubGroupNumber";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            subGrpNumData.DataSource = dt;

            String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

            SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
            DataTable dt22 = new DataTable();
            sda22.Fill(dt22);
            genSubIdData.DataSource = dt22;

            String query4 = "select id, GenGrpNum from GenGroupNumber";

            SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
            DataTable dt33 = new DataTable();
            sda33.Fill(dt33);
            genIdData.DataSource = dt33;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();

            MessageBox.Show("Sub-Group Updated Successfully","Update Successfully");
        }

        private void subGrpNumDltBtn_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from SubGroupNumber where id = '" + subGrpNumID + "'";
                cmd.ExecuteNonQuery();


                String query2 = "Select * from SubGroupNumber";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                subGrpNumData.DataSource = dt;

                String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
                DataTable dt22 = new DataTable();
                sda22.Fill(dt22);
                genSubIdData.DataSource = dt22;

                String query4 = "select id, GenGrpNum from GenGroupNumber";

                SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
                DataTable dt33 = new DataTable();
                sda33.Fill(dt33);
                genIdData.DataSource = dt33;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Sub-Group Number Deleted Successfully", "Delete Successful");

                subGrpNumTxt.Text = "";
            }

        }

        private void yrSemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = yrSemData.Rows[index];
                YrSemID = Int32.Parse(selectRow.Cells[0].Value.ToString());
                yearTxt.Text = selectRow.Cells[1].Value.ToString();
                semTxt.Text = selectRow.Cells[2].Value.ToString();
            }
        }

        private void yrSemEditBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE YearSemester SET Year = '" + yearTxt.Text + "', Semester = '" + semTxt.Text + "' WHERE id = '" + YrSemID + "'";
            cmd.ExecuteNonQuery();

            String query2 = "Select * from YearSemester";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            yrSemData.DataSource = dt;

            String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

            SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
            DataTable dt22 = new DataTable();
            sda22.Fill(dt22);
            genSubIdData.DataSource = dt22;

            String query4 = "select id, GenGrpNum from GenGroupNumber";

            SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
            DataTable dt33 = new DataTable();
            sda33.Fill(dt33);
            genIdData.DataSource = dt33;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();

            MessageBox.Show("Year and Semester Updated Successfully", "Update Successful");
        }

        private void yrSemDltBtn_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from YearSemester where id = '" + YrSemID + "'";
                cmd.ExecuteNonQuery();


                String query2 = "Select * from YearSemester";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                yrSemData.DataSource = dt;

                String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
                DataTable dt22 = new DataTable();
                sda22.Fill(dt22);
                genSubIdData.DataSource = dt22;

                String query4 = "select id, GenGrpNum from GenGroupNumber";

                SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
                DataTable dt33 = new DataTable();
                sda33.Fill(dt33);
                genIdData.DataSource = dt33;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Year and Semester Deleted Successfully", "Delete Successful");

                yearTxt.Text = "";
                semTxt.Text = "";
            }
        }

        private void prgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = prgData.Rows[index];
                prgID = Int32.Parse(selectRow.Cells[0].Value.ToString());
                prgBtn.Text = selectRow.Cells[1].Value.ToString();
            }
        }

        private void prgEditBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Programme SET Programme = '" + prgBtn.Text + "' WHERE id = '" + prgID + "'";
            cmd.ExecuteNonQuery();

            String query2 = "Select * from Programme";

            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            prgData.DataSource = dt;

            String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

            SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
            DataTable dt22 = new DataTable();
            sda22.Fill(dt22);
            genSubIdData.DataSource = dt22;

            String query4 = "select id, GenGrpNum from GenGroupNumber";

            SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
            DataTable dt33 = new DataTable();
            sda33.Fill(dt33);
            genIdData.DataSource = dt33;

            String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

            SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
            DataTable dt77 = new DataTable();
            sda77.Fill(dt77);
            viewData.DataSource = dt77;

            con.Close();

            MessageBox.Show("Programme Updated Successfully", "Update Successful");
        }

        private void prgDltBtn_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Programme where id = '" + prgID + "'";
                cmd.ExecuteNonQuery();


                String query2 = "Select * from Programme";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                prgData.DataSource = dt;

                String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
                DataTable dt22 = new DataTable();
                sda22.Fill(dt22);
                genSubIdData.DataSource = dt22;

                String query4 = "select id, GenGrpNum from GenGroupNumber";

                SqlDataAdapter sda33 = new SqlDataAdapter(query4, con);
                DataTable dt33 = new DataTable();
                sda33.Fill(dt33);
                genIdData.DataSource = dt33;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Programme Deleted Successfully", "Delete Successful");

                prgBtn.Text = "";
            }
        }

        private void genIdBtn_Click(object sender, EventArgs e)
        {
            String query1 = "Select Year,Semester,Programme,GrpNum,YS.id,P.id,GNo.id from YearSemester YS, Programme P, GroupNumber GNo";

            SqlConnection con = Config.con;
            con.Open();

            SqlCommand cmd = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            string res = string.Join(Environment.NewLine,
                dt.Rows.OfType<DataRow>()
                .Select(x => string.Join(".", x.ItemArray)));


            string[] allList = res.Split('\n');

            string last = allList.Last();

            foreach (string res22 in allList)
            {

                string reeee;
                if (res22.Equals(last))
                {
                    reeee = res22;
                }
                else
                {
                    reeee = res22.Substring(0, res22.Length - 1);
                }

                string[] idList = reeee.Split('.');


                int i = 0;
                string newStr = "";
                string pID = "";
                string yrSemID = "";
                string grpNoId = "";
                foreach (string id in idList)
                {
                    if (i == 0)
                    {
                        newStr = newStr + "Y" + id + ".";
                    }
                    else if (i == 1)
                    {
                        newStr = newStr + "S" + id + ".";
                    }
                    else if (i == 2)
                    {
                        newStr = newStr + id + ".";
                    }
                    else if (i == 3)
                    {
                        newStr = newStr + int.Parse(id).ToString("00");
                    }
                    else if (i == 4)
                    {
                        yrSemID = id;
                    }
                    else if (i == 5)
                    {
                        pID = id;
                    }
                    else if (i == 6)
                    {
                        grpNoId = id;
                    }
                    i++;
                }
                string[] innerResult = { newStr, yrSemID, pID, grpNoId };
                list.Add(innerResult);
            }

            String query2 = "Select GenGrpNum from GenGroupNumber";
            con.Open();

            SqlCommand cmd2 = new SqlCommand(query2, con);
            DataTable dt2 = new DataTable();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);
            con.Close();
            string res2 = string.Join(Environment.NewLine,
                dt2.Rows.OfType<DataRow>()
                .Select(x => string.Join(".", x.ItemArray)));


            string[] allList2 = res2.Split('\n');
            string last2 = allList2.Last();

            foreach (string res22 in allList2)
            {

                string reeee;
                if (res22.Equals(last2))
                {
                    reeee = res22;
                }
                else
                {
                    reeee = res22.Substring(0, res22.Length - 1);
                }
                list2.Add(reeee);
            }
            allOutcome2 = list2.ToArray();

            listView2.View = View.Details;
            listView2.Columns.Add("Name");

            listView2.Items.Clear();

            foreach (string[] listItem in list)
            {
                Boolean found = false;
                foreach (string innerItem in list2)
                {
                    if (listItem[0].Equals(innerItem))
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    list3.Add(listItem);
                    listView2.Items.Add(new ListViewItem(listItem[0]));
                }
            }

            listView2.GridLines = true;
            listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        }

        private void genIdEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void genIdDltBtn_Click(object sender, EventArgs e)
        {
            
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM [dbo].[GenGroupNumber] WHERE id=" + genGrpID1 + "";
                cmd.ExecuteNonQuery();


                String query2 = "select id, GenGrpNum from GenGroupNumber";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                genIdData.DataSource = dt;

                String query3 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda22 = new SqlDataAdapter(query3, con);
                DataTable dt22 = new DataTable();
                sda22.Fill(dt22);
                genSubIdData.DataSource = dt22;

                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Generated Group Number Deleted Successfully", "Delete Successful");
            }
            
        }

        private void genSubIdEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void genSubIdBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = Config.con;
            String query1 = "select GGN.GenGrpNum, SGN.SubGrpNum, GGN.id, SGN.id from GenGroupNumber GGN, SubGroupNumber SGN";
            con.Open();

            SqlCommand cmd = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            string res = string.Join(Environment.NewLine,
                dt.Rows.OfType<DataRow>()
                .Select(x => string.Join(".", x.ItemArray)));


            string[] allList = res.Split('\n');

            string last = allList.Last();

            foreach (string res22 in allList)
            {

                string reeee;
                if (res22.Equals(last))
                {
                    reeee = res22;
                }
                else
                {
                    reeee = res22.Substring(0, res22.Length - 1);
                }

                string[] idList = reeee.Split('.');


                int i = 0;
                string newStr = "";
                string pID = "";
                string yrSemID = "";
                string grpNoId = "";
                foreach (string id in idList)
                {
                    if (i == 0)
                    {
                        newStr = newStr + id + ".";
                    }
                    else if (i == 1)
                    {
                        newStr = newStr + id + ".";
                    }
                    else if (i == 2)
                    {
                        newStr = newStr + id + ".";
                    }
                    else if (i == 3)
                    {
                        newStr = newStr + id + ".";
                    }
                    else if (i == 4)
                    {
                        newStr = newStr + int.Parse(id).ToString("00");
                    }
                    else if (i == 5)
                    {
                        pID = id;
                    }
                    else if (i == 6)
                    {
                        grpNoId = id;
                    }
                    i++;
                }
                string[] innerResult = { newStr, pID, grpNoId };
                list4.Add(innerResult);
            }

            String query2 = "select GenSubGrpNum from GenSubGroupNumber";
            con.Open();

            SqlCommand cmd2 = new SqlCommand(query2, con);
            DataTable dt2 = new DataTable();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);
            con.Close();
            string res2 = string.Join(Environment.NewLine,
                dt2.Rows.OfType<DataRow>()
                .Select(x => string.Join(".", x.ItemArray)));


            string[] allList2 = res2.Split('\n');
            string last2 = allList2.Last();

            foreach (string res22 in allList2)
            {

                string reeee;
                if (res22.Equals(last2))
                {
                    reeee = res22;
                }
                else
                {
                    reeee = res22.Substring(0, res22.Length - 1);
                }
                list5.Add(reeee);
            }
            allOutcome2 = list5.ToArray();

            listView1.View = View.Details;
            listView1.Columns.Add("Name");

            listView1.Items.Clear();

            foreach (string[] listItem in list4)
            {
                Boolean found = false;
                foreach (string innerItem in list5)
                {
                    if (listItem[0].Equals(innerItem))
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    list6.Add(listItem);
                    listView1.Items.Add(new ListViewItem(listItem[0]));
                }
            }

            listView1.GridLines = true;
            listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        }

        private void gentedSubIdNumTxt_Click(object sender, EventArgs e)
        {

        }

        private void genIdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = genIdData.Rows[index];
                genGrpID1 = Int32.Parse(selectRow.Cells[0].Value.ToString());
            }
        }

        private void genSubIdDltBtn_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlgResult == DialogResult.Yes)
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM [dbo].[GenSubGroupNumber] WHERE id=" + genSubGrpID1 + "";
                cmd.ExecuteNonQuery();


                String query2 = "select id,GenSubGrpNum from GenSubGroupNumber";

                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                genSubIdData.DataSource = dt;


                String query7 = "Select YS.Year, YS.Semester, P.Programme, GNo.GrpNum, GS.GenGrpNum, SubGNo.SubGrpNum, GSG.GenSubGrpNum from GenSubGroupNumber GSG, GenGroupNumber GS, YearSemester YS, Programme P, GroupNumber GNo, SubGroupNumber SubGNo where GSG.GenGroupNumberRef=GS.id and GS.yearSemRef=YS.id and GS.programmeRef=P.id and GS.GroupNumber=GNo.id and GSG.SubGroupNumberRef=SubGNo.id";

                SqlDataAdapter sda77 = new SqlDataAdapter(query7, con);
                DataTable dt77 = new DataTable();
                sda77.Fill(dt77);
                viewData.DataSource = dt77;


                con.Close();

                MessageBox.Show("Sub-Group Deleted Successfully","Delete Successful");
            }
        }

        private void genSubIdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int index = e.RowIndex;
            if (index > 0)
            {
                DataGridViewRow selectRow = genSubIdData.Rows[index];
                genSubGrpID1 = Int32.Parse(selectRow.Cells[0].Value.ToString());
            }    
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
    }

}
