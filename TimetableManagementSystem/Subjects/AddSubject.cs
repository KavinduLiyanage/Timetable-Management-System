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
    }
}
