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
using System.Diagnostics;
using TimetableManagementSystem.Tags;

namespace TimetableManagementSystem.AdvancedOp
{
    public partial class Advanced : MetroFramework.Forms.MetroForm
    {

        public SqlConnection con = Config.con;

        public Advanced()
        {
            InitializeComponent();
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
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

        private void btnHeaderAdvanced_Click(object sender, EventArgs e)
        {
            this.Hide();
            Advanced advc = new Advanced();
            advc.ShowDialog();
        }

        private void btnHeaderRooms_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rooms.Rooms rooms = new Rooms.Rooms();
            rooms.ShowDialog();
        }

        private void btnHeaderSessions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sessions.Sessions sessions = new Sessions.Sessions();
            sessions.ShowDialog();
        }

        private void btnHeaderGenerate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerateTimetable.GenerateTimetable generatetimetable = new GenerateTimetable.GenerateTimetable();
            generatetimetable.ShowDialog();
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
            Statistics.Statistics stat = new Statistics.Statistics();
            stat.ShowDialog();
        }

        private void noAvaBtn_Click(object sender, EventArgs e)
        {
            if ((typeCmbo.Text != string.Empty) && (itmCmbBox.Text != string.Empty) && (timeCmbBoxStart.Text != string.Empty))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (typeCmbo.Text == "Lecturers")
                {
                    String ID="";

                    if (itmCmbBox.SelectedItem != null)
                    {
                        DataRowView drv = itmCmbBox.SelectedItem as DataRowView;
                        ID = drv.Row["LecturerID"].ToString();
                    }

                    cmd.CommandText = "INSERT INTO [dbo].[NotAvailableTime] ([SelectedType],[Item],[StartTime],[EndTime],[Day],[GenGroupNumberRef],[SubGroupNumberRef],[LecturerRef],[SessionRef]) VALUES ('" + typeCmbo.Text + "','" + itmCmbBox.Text + "','" + timeCmbBoxStart.Text + "','" + timeCmbBoxEnd.Text + "','" + notAvaTimeDateCmb.Text + "',null,null," + ID + ",null)";
                }
                else if (typeCmbo.Text == "Sessions")
                {
                    String ID = "";

                    if (itmCmbBox.SelectedItem != null)
                    {
                        DataRowView drv = itmCmbBox.SelectedItem as DataRowView;
                        ID = drv.Row["SessionID"].ToString();
                    }

                    cmd.CommandText = "INSERT INTO [dbo].[NotAvailableTime] ([SelectedType],[Item],[StartTime],[EndTime],[Day],[GenGroupNumberRef],[SubGroupNumberRef],[LecturerRef],[SessionRef]) VALUES ('" + typeCmbo.Text + "','" + itmCmbBox.Text + "','" + timeCmbBoxStart.Text + "','" + timeCmbBoxEnd.Text + "','" + notAvaTimeDateCmb.Text + "',null,null,null," + ID + ")";
                }
                else if (typeCmbo.Text == "Groups")
                {
                    String ID = "";

                    if (itmCmbBox.SelectedItem != null)
                    {
                        DataRowView drv = itmCmbBox.SelectedItem as DataRowView;
                        ID = drv.Row["id"].ToString();
                    }

                    cmd.CommandText = "INSERT INTO [dbo].[NotAvailableTime] ([SelectedType],[Item],[StartTime],[EndTime],[Day],[GenGroupNumberRef],[SubGroupNumberRef],[LecturerRef],[SessionRef]) VALUES ('" + typeCmbo.Text + "','" + itmCmbBox.Text + "','" + timeCmbBoxStart.Text + "','" + timeCmbBoxEnd.Text + "','" + notAvaTimeDateCmb.Text + "'," + ID + ",null,null,null)";
                }
                else if (typeCmbo.Text == "Sub-Groups")
                {
                    String ID = "";

                    if (itmCmbBox.SelectedItem != null)
                    {
                        DataRowView drv = itmCmbBox.SelectedItem as DataRowView;
                        ID = drv.Row["id"].ToString();
                    }

                    cmd.CommandText = "INSERT INTO [dbo].[NotAvailableTime] ([SelectedType],[Item],[StartTime],[EndTime],[GenGroupNumberRef],[SubGroupNumberRef],[LecturerRef],[SessionRef]) VALUES ('" + typeCmbo.Text + "','" + itmCmbBox.Text + "','" + timeCmbBoxStart.Text + "','" + timeCmbBoxEnd.Text + "',null," + ID + ",null,null)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Not Available Time Added");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String query1 = "select id,SelectedType,Item,Day,StartTime,EndTime from NotAvailableTime";

            SqlCommand cmd2 = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd2.ExecuteReader();
            dt.Load(sdr);

            notAvaData.AutoGenerateColumns = true;
            notAvaData.DataSource = dt;

            con.Close();
        }

        private void Advanced_Load(object sender, EventArgs e)
        {

            /*
            timeCmbBox.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select * from WorkingTimeSlot", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                timeCmbBox.Items.Add(dataRow["TimeSlot"].ToString());
            }
            */


            //Input time
            /*
            this.itmCmbBox.DataSource = null;
            timeCmbBox.Items.Clear();
            string query = "select * from WorkingTime";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TimeSlot");
            timeCmbBox.DisplayMember = "TimeSlot";
            timeCmbBox.ValueMember = "WorkingTimeSlotID";
            timeCmbBox.DataSource = ds.Tables["TimeSlot"];
            con.Close();
            timeCmbBox.SelectedIndex = -1;
            */



            /*
            sesCmb01.Items.Clear();
            parSesCmbBox01.Items.Clear();
            notOverlapSesCmbBox01.Items.Clear();
            SqlDataAdapter sda2 = new SqlDataAdapter("select * from Sessions", con);
            DataTable dataTable2 = new DataTable();
            sda2.Fill(dataTable2);
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                sesCmb01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                parSesCmbBox01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                notOverlapSesCmbBox01.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
            }
            */


            this.sesCmb01.DataSource = null;
            sesCmb01.Items.Clear();

            this.parSesCmbBox01.DataSource = null;
            parSesCmbBox01.Items.Clear();

            this.notOverlapSesCmbBox01.DataSource = null;
            notOverlapSesCmbBox01.Items.Clear();

            string query2 = "select SessionID, (SubjectCode + ' ' + Tag + ' By ' + Lecturer + ' for ' + GroupID) AS NAME from sessions";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            con.Open();
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Sessions");

            sesCmb01.DisplayMember = "NAME";
            sesCmb01.ValueMember = "SessionID";
            sesCmb01.DataSource = ds2.Tables["Sessions"];

            parSesCmbBox01.DisplayMember = "NAME";
            parSesCmbBox01.ValueMember = "SessionID";
            parSesCmbBox01.DataSource = ds2.Tables["Sessions"];

            notOverlapSesCmbBox01.DisplayMember = "NAME";
            notOverlapSesCmbBox01.ValueMember = "SessionID";
            notOverlapSesCmbBox01.DataSource = ds2.Tables["Sessions"];

            con.Close();
            sesCmb01.SelectedIndex = -1;
            parSesCmbBox01.SelectedIndex = -1;
            notOverlapSesCmbBox01.SelectedIndex = -1;


            /*
            sesCmb02.Items.Clear();
            parSesCmbBox02.Items.Clear();
            notOverlapSesCmbBox02.Items.Clear();
            SqlDataAdapter sda3 = new SqlDataAdapter("select * from Sessions", con);
            DataTable dataTable3 = new DataTable();
            sda3.Fill(dataTable3);
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                sesCmb02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                parSesCmbBox02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                notOverlapSesCmbBox02.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
            }
            */

            this.sesCmb02.DataSource = null;
            sesCmb02.Items.Clear();

            this.parSesCmbBox02.DataSource = null;
            parSesCmbBox02.Items.Clear();

            this.notOverlapSesCmbBox02.DataSource = null;
            notOverlapSesCmbBox02.Items.Clear();

            string query3 = "select SessionID, (SubjectCode + ' ' + Tag + ' By ' + Lecturer + ' for ' + GroupID) AS NAME from sessions";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            con.Open();
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "Sessions");

            sesCmb02.DisplayMember = "NAME";
            sesCmb02.ValueMember = "SessionID";
            sesCmb02.DataSource = ds3.Tables["Sessions"];

            parSesCmbBox02.DisplayMember = "NAME";
            parSesCmbBox02.ValueMember = "SessionID";
            parSesCmbBox02.DataSource = ds3.Tables["Sessions"];

            notOverlapSesCmbBox02.DisplayMember = "NAME";
            notOverlapSesCmbBox02.ValueMember = "SessionID";
            notOverlapSesCmbBox02.DataSource = ds3.Tables["Sessions"];

            sesCmb02.SelectedIndex = -1;
            parSesCmbBox02.SelectedIndex = -1;
            notOverlapSesCmbBox02.SelectedIndex = -1;


            String query1 = "select id,SelectedType,Item,Day,StartTime,EndTime from NotAvailableTime";
            String query5 = "select id,Session01,Session02 from ConsecutiveSession";

            SqlCommand cmd = new SqlCommand(query1, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            SqlCommand cmd2 = new SqlCommand(query5, con);
            DataTable dt2 = new DataTable();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);

            notAvaData.AutoGenerateColumns = true;
            notAvaData.DataSource = dt;

            consecData.AutoGenerateColumns = true;
            consecData.DataSource = dt2;

            con.Close();

        }

        private void typeCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (typeCmbo.Text == "Lecturers") {
                /*
                itmLbl.Text = "Lecturer";
                itmCmbBox.PromptText = "Select Lecturer";
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Lecturers", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["LecName"].ToString());
                }
                */

                itmCmbBox.PromptText = "Select Lecturer";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                string query = "select * from Lecturers";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Lecturers");
                itmCmbBox.DisplayMember = "LecName";
                itmCmbBox.ValueMember = "LecturerID";
                itmCmbBox.DataSource = ds.Tables["Lecturers"];
                itmCmbBox.PromptText = "Select Lecturer";
                con.Close();
                itmCmbBox.SelectedIndex = -1;

            }
            else if (typeCmbo.Text == "Sessions") {
                /*
                itmLbl.Text = "Session";
                itmCmbBox.PromptText = "Select Session";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Sessions", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["SubjectCode"].ToString() + " " + dataRow["Tag"].ToString() + " By " + dataRow["Lecturer"].ToString() + " for " + dataRow["GroupID"].ToString());
                }
                */

                itmCmbBox.PromptText = "Select Session";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                string query = "select SessionID, (SubjectCode + ' ' + Tag + ' By ' + Lecturer + ' for ' + GroupID) AS NAME from sessions";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Sessions");
                itmCmbBox.DisplayMember = "NAME";
                itmCmbBox.ValueMember = "SessionID";
                itmCmbBox.DataSource = ds.Tables["Sessions"];
                con.Close();
                itmCmbBox.SelectedIndex = -1;

            }
            else if (typeCmbo.Text == "Groups") {
                /*
                itmLbl.Text = "Group";
                itmCmbBox.PromptText = "Select Group";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from GenGroupNumber;", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["GenGrpNum"].ToString());
                }
                */

                itmCmbBox.PromptText = "Select Group";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                string query = "select * from GenGroupNumber";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GroupNumber");
                itmCmbBox.DisplayMember = "GenGrpNum";
                itmCmbBox.ValueMember = "id";
                itmCmbBox.DataSource = ds.Tables["GroupNumber"];
                con.Close();
                itmCmbBox.SelectedIndex = -1;
            }
            else if (typeCmbo.Text == "Sub-Groups") {
                /*
                itmLbl.Text = "Sub-Group";
                itmCmbBox.PromptText = "Select Sub-Group";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("select * from GenSubGroupNumber", con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    itmCmbBox.Items.Add(dataRow["GenSubGrpNum"].ToString());
                }
                */

                itmCmbBox.PromptText = "Select Sub-Group";
                this.itmCmbBox.DataSource = null;
                itmCmbBox.Items.Clear();
                string query = "select * from GenSubGroupNumber";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "SubGroupNumber");
                itmCmbBox.DisplayMember = "GenSubGrpNum";
                itmCmbBox.ValueMember = "id";
                itmCmbBox.DataSource = ds.Tables["SubGroupNumber"];
                con.Close();
                itmCmbBox.SelectedIndex = -1;
            }
        }

        private void day_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addConBtn_Click(object sender, EventArgs e)
        {
            if ((sesCmb01.Text != string.Empty) && (sesCmb02.Text != string.Empty))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                String ID = "";

                if (sesCmb01.SelectedItem != null)
                {
                    DataRowView drv = sesCmb01.SelectedItem as DataRowView;
                    ID = drv.Row["SessionID"].ToString();
                }

                String ID2 = "";

                if (sesCmb02.SelectedItem != null)
                {
                    DataRowView drv = sesCmb02.SelectedItem as DataRowView;
                    ID2 = drv.Row["SessionID"].ToString();
                }

                cmd.CommandText = "INSERT INTO [dbo].[ConsecutiveSession] ([Session01],[Session02],[Session01Ref],[Session02Ref]) VALUES('" + sesCmb01.Text + "','" + sesCmb02.Text + "'," + ID + "," + ID2 + ")";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Consecutive Session Added");

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String query5 = "select id,Session01,Session02 from ConsecutiveSession";

            SqlCommand cmd2 = new SqlCommand(query5, con);
            DataTable dt2 = new DataTable();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);

            consecData.AutoGenerateColumns = true;
            consecData.DataSource = dt2;

            con.Close();
        }

        private void itmCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (itmCmbBox.SelectedItem != null)
            {
                DataRowView drv = itmCmbBox.SelectedItem as DataRowView;

                Debug.WriteLine("Item: " + drv.Row["LecName"].ToString());
                Debug.WriteLine("Value: " + drv.Row["LecturerID"].ToString());
                Debug.WriteLine("Value: " + itmCmbBox.SelectedValue.ToString());
            }
            */
        }

        private void addParBtn_Click(object sender, EventArgs e)
        {
            if ((parSesCmbBox01.Text != string.Empty) && (parSesCmbBox02.Text != string.Empty) && (parSesDurationCmb.Text != string.Empty) && (parSesDayCmb.Text != string.Empty) && (parSesTimeSlotCmbStart.Text != string.Empty))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                String ID = "";

                if (parSesCmbBox01.SelectedItem != null)
                {
                    DataRowView drv = parSesCmbBox01.SelectedItem as DataRowView;
                    ID = drv.Row["SessionID"].ToString();
                }

                String ID2 = "";

                if (parSesCmbBox02.SelectedItem != null)
                {
                    DataRowView drv = parSesCmbBox02.SelectedItem as DataRowView;
                    ID2 = drv.Row["SessionID"].ToString();
                }

                cmd.CommandText = "INSERT INTO [dbo].[ParallelSession] ([Session01] ,[Session02] ,[Duration] ,[Day] ,[StartTime] ,[EndTime],[Session01Ref] ,[Session02Ref]) VALUES ('" + parSesCmbBox01.Text + "' ,'" + parSesCmbBox02.Text + "' , " + parSesDurationCmb.Text + " ,'" + parSesDayCmb.Text + "' ,'" + parSesTimeSlotCmbStart.Text + "','" + parSesTimeSlotCmbEnd.Text + "' ," + ID + " ," + ID2 + ")";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Parallel Session Added");
                con.Close();

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNotOverlapSesBtn_Click(object sender, EventArgs e)
        {
            if ((notOverlapSesCmbBox01.Text != string.Empty) && (notOverlapSesCmbBox02.Text != string.Empty) && (notOverlapSesDurationCmbBox.Text != string.Empty) && (notOverlapSesDayCmbBox.Text != string.Empty) && (notOverlapSesTimeSlotCmbBoxStart.Text != string.Empty))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                String ID = "";

                if (notOverlapSesCmbBox01.SelectedItem != null)
                {
                    DataRowView drv = notOverlapSesCmbBox01.SelectedItem as DataRowView;
                    ID = drv.Row["SessionID"].ToString();
                }

                String ID2 = "";

                if (notOverlapSesCmbBox02.SelectedItem != null)
                {
                    DataRowView drv = notOverlapSesCmbBox02.SelectedItem as DataRowView;
                    ID2 = drv.Row["SessionID"].ToString();
                }

                cmd.CommandText = "INSERT INTO [dbo].[NotOverlapSession] ([Session01],[Session02],[Duration],[Day],[StartTime],[EndTime],[Session01Ref],[Session02Ref]) VALUES ('" + notOverlapSesCmbBox01.Text + "' ,'" + notOverlapSesCmbBox02.Text + "' , " + notOverlapSesDurationCmbBox.Text + " ,'" + notOverlapSesDayCmbBox.Text + "' ,'" + notOverlapSesTimeSlotCmbBoxStart.Text + "','" + notOverlapSesTimeSlotCmbBoxEnd.Text + "' ," + ID + " ," + ID2 + ")";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Should Not Overlap Session Added");
                con.Close();

            }
            else
            {
                MessageBox.Show("All fields must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timeCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yrSemClrBtn_Click(object sender, EventArgs e)
        {
            typeCmbo.SelectedIndex = -1;
            itmCmbBox.SelectedIndex = -1;
            timeCmbBoxStart.SelectedIndex = -1;
        }

        private void notAvaSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (notAvaSearchDrpDown.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,SelectedType,Item,TimeSlot from NotAvailableTime where SelectedType LIKE '%"+notAvaSearchBox.Text+"%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                notAvaData.DataSource = dt;
                con.Close();
            }
            if (notAvaSearchDrpDown.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,SelectedType,Item,TimeSlot from NotAvailableTime where id LIKE '%" + notAvaSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                notAvaData.DataSource = dt;
                con.Close();
            }
            if (notAvaSearchDrpDown.Text == "Type")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,SelectedType,Item,TimeSlot from NotAvailableTime where SelectedType LIKE '%" + notAvaSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                notAvaData.DataSource = dt;
                con.Close();
            }
            if (notAvaSearchDrpDown.Text == "Item")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,SelectedType,Item,TimeSlot from NotAvailableTime where Item LIKE '%" + notAvaSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                notAvaData.DataSource = dt;
                con.Close();
            }
            if (notAvaSearchDrpDown.Text == "Time Slot")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,SelectedType,Item,TimeSlot from NotAvailableTime where TimeSlot LIKE '%" + notAvaSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                notAvaData.DataSource = dt;
                con.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            sesCmb01.SelectedIndex = -1;
            sesCmb02.SelectedIndex = -1;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            parSesCmbBox01.SelectedIndex = -1;
            parSesCmbBox02.SelectedIndex = -1;
            parSesDayCmb.SelectedIndex = -1;
            parSesDurationCmb.SelectedIndex = -1;
            parSesTimeSlotCmbStart.SelectedIndex = -1;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            notOverlapSesCmbBox01.SelectedIndex = -1;
            notOverlapSesCmbBox02.SelectedIndex = -1;
            notOverlapSesDayCmbBox.SelectedIndex = -1;
            notOverlapSesDurationCmbBox.SelectedIndex = -1;
            notOverlapSesTimeSlotCmbBoxStart.SelectedIndex = -1;
        }

        private void consecSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (consecSearchDrpDown.Text == "")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,Session01,Session02 from ConsecutiveSession where Session01 LIKE '%" + consecSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                consecData.DataSource = dt;
                con.Close();
            }
            if (consecSearchDrpDown.Text == "ID")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,Session01,Session02 from ConsecutiveSession where id LIKE '%" + consecSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                consecData.DataSource = dt;
                con.Close();
            }
            if (consecSearchDrpDown.Text == "Session01")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,Session01,Session02 from ConsecutiveSession where Session01 LIKE '%" + consecSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                consecData.DataSource = dt;
                con.Close();
            }
            if (consecSearchDrpDown.Text == "Session02")
            {
                SqlConnection con = Config.con;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select id,Session01,Session02 from ConsecutiveSession where Session02 LIKE '%" + consecSearchBox.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                consecData.DataSource = dt;
                con.Close();
            }
        }
    }
}
