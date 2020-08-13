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
    }
}
