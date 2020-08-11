namespace TimetableManagementSystem.Subjects
{
    partial class AddSubject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.cmbSubEvaHours = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubLabHours = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubTuteHours = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubYear = new MetroFramework.Controls.MetroComboBox();
            this.txtSubCode = new MetroFramework.Controls.MetroTextBox();
            this.txtSubName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnSaveSub = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.cmbSubSem = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubLecHours = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(426, 81);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(158, 25);
            this.metroLabel7.TabIndex = 27;
            this.metroLabel7.Text = "Add New Subject";
            // 
            // cmbSubEvaHours
            // 
            this.cmbSubEvaHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubEvaHours.FormattingEnabled = true;
            this.cmbSubEvaHours.ItemHeight = 23;
            this.cmbSubEvaHours.Items.AddRange(new object[] {
            "Professor",
            "Assistant Professor",
            "Senior Lecturer(HG)",
            "Senior Lecturer",
            "Lecturer",
            "Assistant Lecturer",
            "Instructors"});
            this.cmbSubEvaHours.Location = new System.Drawing.Point(530, 477);
            this.cmbSubEvaHours.Name = "cmbSubEvaHours";
            this.cmbSubEvaHours.PromptText = "Select Eva Hours";
            this.cmbSubEvaHours.Size = new System.Drawing.Size(200, 29);
            this.cmbSubEvaHours.TabIndex = 26;
            this.cmbSubEvaHours.UseSelectable = true;
            // 
            // cmbSubLabHours
            // 
            this.cmbSubLabHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubLabHours.FormattingEnabled = true;
            this.cmbSubLabHours.ItemHeight = 23;
            this.cmbSubLabHours.Items.AddRange(new object[] {
            "Main Building",
            "New Building",
            "D-Block"});
            this.cmbSubLabHours.Location = new System.Drawing.Point(530, 427);
            this.cmbSubLabHours.Name = "cmbSubLabHours";
            this.cmbSubLabHours.PromptText = "Select Lab Hours";
            this.cmbSubLabHours.Size = new System.Drawing.Size(200, 29);
            this.cmbSubLabHours.TabIndex = 25;
            this.cmbSubLabHours.UseSelectable = true;
            // 
            // cmbSubTuteHours
            // 
            this.cmbSubTuteHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubTuteHours.FormattingEnabled = true;
            this.cmbSubTuteHours.ItemHeight = 23;
            this.cmbSubTuteHours.Items.AddRange(new object[] {
            "Malabe",
            "Metro",
            "Matara",
            "Kandy",
            "Kurunagala",
            "Jaffna"});
            this.cmbSubTuteHours.Location = new System.Drawing.Point(530, 377);
            this.cmbSubTuteHours.Name = "cmbSubTuteHours";
            this.cmbSubTuteHours.PromptText = "Select Tute Hours";
            this.cmbSubTuteHours.Size = new System.Drawing.Size(200, 29);
            this.cmbSubTuteHours.TabIndex = 24;
            this.cmbSubTuteHours.UseSelectable = true;
            // 
            // cmbSubYear
            // 
            this.cmbSubYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubYear.FormattingEnabled = true;
            this.cmbSubYear.ItemHeight = 23;
            this.cmbSubYear.Items.AddRange(new object[] {
            "Computing",
            "Engineering",
            "Business",
            "Humanities and Science"});
            this.cmbSubYear.Location = new System.Drawing.Point(530, 130);
            this.cmbSubYear.Name = "cmbSubYear";
            this.cmbSubYear.PromptText = "Select Year";
            this.cmbSubYear.Size = new System.Drawing.Size(200, 29);
            this.cmbSubYear.TabIndex = 23;
            this.cmbSubYear.UseSelectable = true;
            // 
            // txtSubCode
            // 
            // 
            // 
            // 
            this.txtSubCode.CustomButton.Image = null;
            this.txtSubCode.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.txtSubCode.CustomButton.Name = "";
            this.txtSubCode.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtSubCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSubCode.CustomButton.TabIndex = 1;
            this.txtSubCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSubCode.CustomButton.UseSelectable = true;
            this.txtSubCode.CustomButton.Visible = false;
            this.txtSubCode.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtSubCode.Lines = new string[0];
            this.txtSubCode.Location = new System.Drawing.Point(530, 279);
            this.txtSubCode.MaxLength = 32767;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.PasswordChar = '\0';
            this.txtSubCode.PromptText = "Enter Code";
            this.txtSubCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSubCode.SelectedText = "";
            this.txtSubCode.SelectionLength = 0;
            this.txtSubCode.SelectionStart = 0;
            this.txtSubCode.ShortcutsEnabled = true;
            this.txtSubCode.Size = new System.Drawing.Size(200, 30);
            this.txtSubCode.TabIndex = 22;
            this.txtSubCode.UseSelectable = true;
            this.txtSubCode.WaterMark = "Enter Code";
            this.txtSubCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSubCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtSubName
            // 
            // 
            // 
            // 
            this.txtSubName.CustomButton.Image = null;
            this.txtSubName.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.txtSubName.CustomButton.Name = "";
            this.txtSubName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtSubName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSubName.CustomButton.TabIndex = 1;
            this.txtSubName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSubName.CustomButton.UseSelectable = true;
            this.txtSubName.CustomButton.Visible = false;
            this.txtSubName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtSubName.Lines = new string[0];
            this.txtSubName.Location = new System.Drawing.Point(530, 230);
            this.txtSubName.MaxLength = 32767;
            this.txtSubName.Name = "txtSubName";
            this.txtSubName.PasswordChar = '\0';
            this.txtSubName.PromptText = "Enter Name";
            this.txtSubName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSubName.SelectedText = "";
            this.txtSubName.SelectionLength = 0;
            this.txtSubName.SelectionStart = 0;
            this.txtSubName.ShortcutsEnabled = true;
            this.txtSubName.Size = new System.Drawing.Size(200, 30);
            this.txtSubName.TabIndex = 21;
            this.txtSubName.UseSelectable = true;
            this.txtSubName.WaterMark = "Enter Name";
            this.txtSubName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSubName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(311, 327);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(180, 30);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "No of Lecture Hours";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel3
            // 
            this.metroLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(311, 279);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(180, 30);
            this.metroLabel3.TabIndex = 18;
            this.metroLabel3.Text = "Subject Code";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel4
            // 
            this.metroLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(311, 180);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(180, 30);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Offered Semester";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel2
            // 
            this.metroLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(311, 230);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(180, 30);
            this.metroLabel2.TabIndex = 16;
            this.metroLabel2.Text = "Subject Name";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel1
            // 
            this.metroLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(311, 130);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(180, 30);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Offered Year";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveSub
            // 
            this.btnSaveSub.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSaveSub.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSaveSub.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveSub.Location = new System.Drawing.Point(434, 529);
            this.btnSaveSub.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSub.Name = "btnSaveSub";
            this.btnSaveSub.Size = new System.Drawing.Size(150, 40);
            this.btnSaveSub.TabIndex = 14;
            this.btnSaveSub.Text = "Save Details";
            this.btnSaveSub.UseCustomBackColor = true;
            this.btnSaveSub.UseCustomForeColor = true;
            this.btnSaveSub.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(311, 377);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(180, 30);
            this.metroLabel5.TabIndex = 28;
            this.metroLabel5.Text = "No of Tutorial Hours";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel8
            // 
            this.metroLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(311, 427);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(180, 30);
            this.metroLabel8.TabIndex = 29;
            this.metroLabel8.Text = "No of Lab Hours";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel9
            // 
            this.metroLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(311, 477);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(180, 30);
            this.metroLabel9.TabIndex = 30;
            this.metroLabel9.Text = "No of Evaluation Hours";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSubSem
            // 
            this.cmbSubSem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubSem.FormattingEnabled = true;
            this.cmbSubSem.ItemHeight = 23;
            this.cmbSubSem.Items.AddRange(new object[] {
            "Computing",
            "Engineering",
            "Business",
            "Humanities and Science"});
            this.cmbSubSem.Location = new System.Drawing.Point(530, 180);
            this.cmbSubSem.Name = "cmbSubSem";
            this.cmbSubSem.PromptText = "Select Semester";
            this.cmbSubSem.Size = new System.Drawing.Size(200, 29);
            this.cmbSubSem.TabIndex = 31;
            this.cmbSubSem.UseSelectable = true;
            // 
            // cmbSubLecHours
            // 
            this.cmbSubLecHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubLecHours.FormattingEnabled = true;
            this.cmbSubLecHours.ItemHeight = 23;
            this.cmbSubLecHours.Items.AddRange(new object[] {
            "Computing",
            "Engineering",
            "Business",
            "Humanities and Science"});
            this.cmbSubLecHours.Location = new System.Drawing.Point(530, 327);
            this.cmbSubLecHours.Name = "cmbSubLecHours";
            this.cmbSubLecHours.PromptText = "Select Lec Hours";
            this.cmbSubLecHours.Size = new System.Drawing.Size(200, 29);
            this.cmbSubLecHours.TabIndex = 32;
            this.cmbSubLecHours.UseSelectable = true;
            // 
            // AddSubject
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::TimetableManagementSystem.Properties.Resources.Background;
            this.BackMaxSize = 960;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.cmbSubLecHours);
            this.Controls.Add(this.cmbSubSem);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.cmbSubEvaHours);
            this.Controls.Add(this.cmbSubLabHours);
            this.Controls.Add(this.cmbSubTuteHours);
            this.Controls.Add(this.cmbSubYear);
            this.Controls.Add(this.txtSubCode);
            this.Controls.Add(this.txtSubName);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnSaveSub);
            this.MaximizeBox = false;
            this.Name = "AddSubject";
            this.Resizable = false;
            this.Text = "AddSubject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox cmbSubEvaHours;
        private MetroFramework.Controls.MetroComboBox cmbSubLabHours;
        private MetroFramework.Controls.MetroComboBox cmbSubTuteHours;
        private MetroFramework.Controls.MetroComboBox cmbSubYear;
        private MetroFramework.Controls.MetroTextBox txtSubCode;
        private MetroFramework.Controls.MetroTextBox txtSubName;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnSaveSub;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroComboBox cmbSubSem;
        private MetroFramework.Controls.MetroComboBox cmbSubLecHours;
    }
}