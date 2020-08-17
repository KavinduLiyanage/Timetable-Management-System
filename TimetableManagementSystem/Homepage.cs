using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimetableManagementSystem.Lecturers;
using TimetableManagementSystem.Subjects;

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
            this.Hide();
            AddLecturer addLecturer = new AddLecturer();
            addLecturer.ShowDialog();
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
        }

        private void stuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students.Students stu = new Students.Students();
            stu.ShowDialog();
        }

        private void btnSideNavLecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddLecturer addLecturer = new AddLecturer();
            addLecturer.ShowDialog();
        }

        private void btnSideNavSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
        }

        private void locBtn_Click(object sender, EventArgs e)
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

        //executing
        private void locBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Locations.Location loc = new Locations.Location();
            loc.ShowDialog();
        }

        private void tagBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tags.Tags tag = new Tags.Tags();
            tag.ShowDialog();
        }

        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }
    }
}
