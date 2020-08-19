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
using System.Windows.Forms.DataVisualization.Charting;

namespace TimetableManagementSystem.Statistics
{
    public partial class Statistics : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = Config.con;
        private DataSet dataTable;

        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

           totalLecturerCount();
            totalSubjectCount();
          LoadLecFacChart();
            LoadLecDeptChart();
            //LoadLecCentreChart();
        }

        private void LoadLecFacChart()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
      
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select LecFaculty,COUNT(LecturerID) as c from Lecturers GROUP BY LecFaculty", con);
            adapt.Fill(ds, "LecFaculty");
            faclec_chart.DataSource = ds.Tables["LecFaculty"];

            faclec_chart.Series["Series1"].XValueMember = "LecFaculty";
            faclec_chart.Series["Series1"].YValueMembers = "c";
            faclec_chart.Series["Series1"].ChartType = SeriesChartType.Bar;


            faclec_chart.DataBind();
            con.Close();

        }


        private void LoadLecDeptChart()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
           
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select LecDepartment,COUNT(LecturerID) as countlec from Lecturers GROUP BY LecDepartment", con);
            adapt.Fill(ds, "countlec");
            deptLec_chart.DataSource = ds.Tables["countlec"];


            deptLec_chart.Series["Series1"].XValueMember = "LecDepartment";
            deptLec_chart.Series["Series1"].YValueMembers = "countlec";
            deptLec_chart.Series["Series1"].ChartType = SeriesChartType.Pie;


            deptLec_chart.DataBind();
            con.Close();
        }

        //private void LoadLecCentreChart()
        //{
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = con;

        //    DataSet ds = new DataSet();
        //    con.Open();
        //    SqlDataAdapter adapt = new SqlDataAdapter("Select LecCenter,COUNT(LecturerID) as countcentlec from Lecturers GROUP BY LecCenter", con);
        //    adapt.Fill(ds, "countcentlec");
        //    centreLec_chart.DataSource = ds.Tables["countcentlec"];


        //    centreLec_chart.Series["Series1"].XValueMember = "LecCenter";
        //    centreLec_chart.Series["Series1"].YValueMembers = "countcentlec";
        //    centreLec_chart.Series["Series1"].ChartType = SeriesChartType.Pie;


        //    centreLec_chart.DataBind();
        //    con.Close();
        //}



        //Calculating total lecturer count
        private void totalLecturerCount()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(LecturerID) as lecCount FROM Lecturers";
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string lec_count = (string)dr["lecCount"].ToString();
                total_lecturers.Text = lec_count;
                

            }
            con.Close();

        }

        //Calculating total subject count
        private void totalSubjectCount()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(id) as subCount FROM Programme";
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string sub_count = (string)dr["subCount"].ToString();
                subject_count_txt.Text = sub_count;


            }
            con.Close();

        }


        //---------------------------------Side Nav Bar Buttons' Links--------------------------------------------------------
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
            Statistics stat = new Statistics();
            stat.ShowDialog();
        }

      

       
    }
}
