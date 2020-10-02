using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableManagementSystem.Tags
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
       public int type;
        bool closeFlag = false;

        public Form1()
        {
            InitializeComponent();
            cmdtype.Items.Add("Lecturer");
            cmdtype.Items.Add("Student");
            cmdtype.Items.Add("Classroom");
            cmdtype.SelectedIndex = 0;
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnselecttype_Click(object sender, EventArgs e)
        {
                metroLabelerr.Visible = false;
                type = cmdtype.SelectedIndex;
                this.Close();
        }

        private void cmdtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public int getText()
        {
               return type;
        }

        public bool getClose()
        {
            return closeFlag;
        }

        private void btncanletype_Click(object sender, EventArgs e)
        {
            closeFlag = true;
            this.Close();
        }
    }
}
