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
            SqlConnection con = Config.con;
            SqlDataAdapter adapter1;

            DataSet ds1 = new DataSet();

            try
            {
                String query1 = "Select * from Tags";

                con.Open();
                adapter1 = new SqlDataAdapter(query1, con);

                adapter1.Fill(ds1);
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }
    }
}
