using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimetableManagementSystem.Subjects;

namespace TimetableManagementSystem.Lecturers
{
    public partial class AddLecturer : MetroFramework.Forms.MetroForm
    {
        public AddLecturer()
        {
            InitializeComponent();
        }

        private void AddLecturer_Load(object sender, EventArgs e)
        {

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
