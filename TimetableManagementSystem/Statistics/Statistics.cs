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

           //totalLecturerCount();
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

        private void totalLecturerCount()
        {
            SqlCommand command = new SqlCommand("getLecCount", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            command.Parameters.AddWithValue("@totalCountLec", total_lecturers.Text);

            dr.Read();
            total_lecturers.Text = dr["@totalCountLec"].ToString();
            con.Close();


        }
    }
}
