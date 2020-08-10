using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableManagementSystem
{
    public partial class Homepage : MetroFramework.Forms.MetroForm
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void wdhBtn_Click(object sender, EventArgs e)
        {

        }

        private void lecBtn_Click(object sender, EventArgs e)
        {

        }

        private void subBtn_Click(object sender, EventArgs e)
        {

        }

        private void stuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students.Students stu = new Students.Students();
            stu.ShowDialog();
        }
    }
}
