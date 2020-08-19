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

namespace TimetableManagementSystem.Subjects
{
    public partial class AddSubject : MetroFramework.Forms.MetroForm
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        //----Side Nav Buttons----
        private void btnSideNavLecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lecturers.AddLecturer addLecturer = new Lecturers.AddLecturer();
            addLecturer.ShowDialog();
        }

        private void btnSideNavSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableManagementSystem.Subjects.AddSubject addSubject = new TimetableManagementSystem.Subjects.AddSubject();
            addSubject.ShowDialog();
        }

        //----Header Buttons----
        private void btnHeaderHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.ShowDialog();
        }
    }
}
