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
using TimetableManagementSystem.Tags;

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
            LoadSubjectYearChart();
            LoadProgrammeStdGroupChart();
            totalStdGrpCount();
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

            faclec_chart.Series["Faculty"].XValueMember = "LecFaculty";
            faclec_chart.Series["Faculty"].YValueMembers = "c";
            faclec_chart.Series["Faculty"].ChartType = SeriesChartType.Bar;


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
        private void totalStdGrpCount()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT count(GenGrpNum) as grpcount from GenGroupNumber group by ProgrammeRef ";
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string grp_count = (string)dr["grpcount"].ToString();
                stdgrpcount_txt.Text = grp_count;


            }
            con.Close();

        }


        // Chart for Programme vs Student Group Count 
        private void LoadProgrammeStdGroupChart()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;

            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select p.Programme as Programme, count(g.GenGrpNum) as Grpcount  from Programme p, GenGroupNumber g where p.id = g.programmeRef group by p.Programme", con);
            adapt.Fill(ds, "Grpcount");
            progrpcount_chart.DataSource = ds.Tables["Grpcount"];


            progrpcount_chart.Series["Programme"].XValueMember = "Programme";
            progrpcount_chart.Series["Programme"].YValueMembers = "Grpcount";
            progrpcount_chart.Series["Programme"].ChartType = SeriesChartType.Bar;


            progrpcount_chart.DataBind();
            con.Close();
        }

        // Chart for Subject Count vs Year
        private void LoadSubjectYearChart()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;

            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select SubYear,COUNT(SubCode) as subyrcount from Subjects GROUP BY SubYear", con);
            adapt.Fill(ds, "subyrcount");
            subyear_chart.DataSource = ds.Tables["subyrcount"];


            subyear_chart.Series["Academic Year"].XValueMember = "SubYear";
            subyear_chart.Series["Academic Year"].YValueMembers = "subyrcount";
            subyear_chart.Series["Academic Year"].ChartType = SeriesChartType.Bar;


            subyear_chart.DataBind();
            con.Close();
        }

        


        //Calculating total subject count
        private void totalSubjectCount()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(SubCode) as subCount FROM Subjects";
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
            Tags.Tags tag = new Tags.Tags();
            tag.ShowDialog();
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


        //-----------------header nav buttons--------------------------------------------
        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
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
