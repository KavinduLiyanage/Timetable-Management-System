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

namespace TimetableManagementSystem.Statistics
{
    public partial class Statistics : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = Config.con;

        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

            totalLecturerCount();
           // LoadLecFacChart();

        }

        private void LoadLecFacChart()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getLecEachFac";

            SqlParameter param1 = new SqlParameter("@faculty", SqlDbType.VarChar);
            //SqlParameter param2 = new SqlParameter("@totLecEachFac", SqlDbType.Int);

            command.Parameters.Add(param1);
            //command.Parameters.Add(param2);

            command.Parameters["@faculty"].Value = "Computing";
          // command.Parameters["@totLecEachFac"].Value = "@totLecEachFac";

            con.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            faclec_chart.DataSource = reader;

           
            //faclec_chart.Series[0].XValueMember = "LecFaculty";
            faclec_chart.Series[0].YValueMembers = "@totLecEachFac";

          
            faclec_chart.DataBind();

        }

        private void totalLecturerCount()
        {
            SqlCommand command = new SqlCommand("getLecCount", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            //command.Parameters.AddWithValue("@totCountLec", total_lecturers.Text);

            dr.Read();
            total_lecturers.Text = dr["@totCountLec"].ToString();


        }
    }
}
