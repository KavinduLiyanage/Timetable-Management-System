namespace TimetableManagementSystem.Locations
{
    partial class UpdateLocationForm
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
            this.cancel_btn = new MetroFramework.Controls.MetroButton();
            this.editloc_btn = new MetroFramework.Controls.MetroButton();
            this.editroomtype_cmb = new MetroFramework.Controls.MetroComboBox();
            this.editroom_cmb = new MetroFramework.Controls.MetroComboBox();
            this.editbuil_cmb = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.editcap_txtbox = new MetroFramework.Controls.MetroTextBox();
            this.deleteloc_btn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.cancel_btn.Location = new System.Drawing.Point(619, 470);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(2);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(150, 40);
            this.cancel_btn.TabIndex = 49;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseCustomBackColor = true;
            this.cancel_btn.UseCustomForeColor = true;
            this.cancel_btn.UseSelectable = true;
            // 
            // editloc_btn
            // 
            this.editloc_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.editloc_btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.editloc_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.editloc_btn.Location = new System.Drawing.Point(292, 470);
            this.editloc_btn.Margin = new System.Windows.Forms.Padding(2);
            this.editloc_btn.Name = "editloc_btn";
            this.editloc_btn.Size = new System.Drawing.Size(150, 40);
            this.editloc_btn.TabIndex = 48;
            this.editloc_btn.Text = "Update Location";
            this.editloc_btn.UseCustomBackColor = true;
            this.editloc_btn.UseCustomForeColor = true;
            this.editloc_btn.UseSelectable = true;
            this.editloc_btn.Click += new System.EventHandler(this.editloc_btn_Click);
            // 
            // editroomtype_cmb
            // 
            this.editroomtype_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editroomtype_cmb.FormattingEnabled = true;
            this.editroomtype_cmb.ItemHeight = 23;
            this.editroomtype_cmb.Items.AddRange(new object[] {
            "Lecture Hall",
            "PC Lab",
            "Engineering Lab"});
            this.editroomtype_cmb.Location = new System.Drawing.Point(523, 393);
            this.editroomtype_cmb.Name = "editroomtype_cmb";
            this.editroomtype_cmb.PromptText = "Select Room Type";
            this.editroomtype_cmb.Size = new System.Drawing.Size(216, 29);
            this.editroomtype_cmb.TabIndex = 46;
            this.editroomtype_cmb.UseSelectable = true;
            // 
            // editroom_cmb
            // 
            this.editroom_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editroom_cmb.FormattingEnabled = true;
            this.editroom_cmb.ItemHeight = 23;
            this.editroom_cmb.Location = new System.Drawing.Point(523, 271);
            this.editroom_cmb.Name = "editroom_cmb";
            this.editroom_cmb.PromptText = "Select Room";
            this.editroom_cmb.Size = new System.Drawing.Size(216, 29);
            this.editroom_cmb.TabIndex = 45;
            this.editroom_cmb.UseSelectable = true;
            this.editroom_cmb.DropDown += new System.EventHandler(this.editroom_cmb_DropDown);
            // 
            // editbuil_cmb
            // 
            this.editbuil_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editbuil_cmb.FormattingEnabled = true;
            this.editbuil_cmb.ItemHeight = 23;
            this.editbuil_cmb.Items.AddRange(new object[] {
            "Main Building",
            "Faculty of Business Building",
            "Faculty of Engineering Building",
            "New Building"});
            this.editbuil_cmb.Location = new System.Drawing.Point(523, 214);
            this.editbuil_cmb.Name = "editbuil_cmb";
            this.editbuil_cmb.PromptText = "Select Building";
            this.editbuil_cmb.Size = new System.Drawing.Size(216, 29);
            this.editbuil_cmb.TabIndex = 44;
            this.editbuil_cmb.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(302, 393);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(180, 30);
            this.metroLabel6.TabIndex = 43;
            this.metroLabel6.Text = "Room Type";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel7
            // 
            this.metroLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(302, 332);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(180, 30);
            this.metroLabel7.TabIndex = 42;
            this.metroLabel7.Text = "Capacity";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel8
            // 
            this.metroLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(302, 270);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(180, 30);
            this.metroLabel8.TabIndex = 41;
            this.metroLabel8.Text = "Room";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel9.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel9.Location = new System.Drawing.Point(448, 114);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(152, 25);
            this.metroLabel9.TabIndex = 40;
            this.metroLabel9.Text = "Update Location";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(302, 213);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(180, 30);
            this.metroLabel10.TabIndex = 39;
            this.metroLabel10.Text = "Building";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editcap_txtbox
            // 
            // 
            // 
            // 
            this.editcap_txtbox.CustomButton.Image = null;
            this.editcap_txtbox.CustomButton.Location = new System.Drawing.Point(47, 2);
            this.editcap_txtbox.CustomButton.Name = "";
            this.editcap_txtbox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.editcap_txtbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.editcap_txtbox.CustomButton.TabIndex = 1;
            this.editcap_txtbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.editcap_txtbox.CustomButton.UseSelectable = true;
            this.editcap_txtbox.CustomButton.Visible = false;
            this.editcap_txtbox.Lines = new string[0];
            this.editcap_txtbox.Location = new System.Drawing.Point(523, 332);
            this.editcap_txtbox.MaxLength = 32767;
            this.editcap_txtbox.Name = "editcap_txtbox";
            this.editcap_txtbox.PasswordChar = '\0';
            this.editcap_txtbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.editcap_txtbox.SelectedText = "";
            this.editcap_txtbox.SelectionLength = 0;
            this.editcap_txtbox.SelectionStart = 0;
            this.editcap_txtbox.ShortcutsEnabled = true;
            this.editcap_txtbox.Size = new System.Drawing.Size(75, 30);
            this.editcap_txtbox.TabIndex = 50;
            this.editcap_txtbox.UseSelectable = true;
            this.editcap_txtbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.editcap_txtbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // deleteloc_btn
            // 
            this.deleteloc_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.deleteloc_btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.deleteloc_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteloc_btn.Location = new System.Drawing.Point(456, 470);
            this.deleteloc_btn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteloc_btn.Name = "deleteloc_btn";
            this.deleteloc_btn.Size = new System.Drawing.Size(150, 40);
            this.deleteloc_btn.TabIndex = 51;
            this.deleteloc_btn.Text = "Delete Location";
            this.deleteloc_btn.UseCustomBackColor = true;
            this.deleteloc_btn.UseCustomForeColor = true;
            this.deleteloc_btn.UseSelectable = true;
            // 
            // UpdateLocationForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::TimetableManagementSystem.Properties.Resources.Background;
            this.BackMaxSize = 960;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.deleteloc_btn);
            this.Controls.Add(this.editcap_txtbox);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.editloc_btn);
            this.Controls.Add(this.editroomtype_cmb);
            this.Controls.Add(this.editroom_cmb);
            this.Controls.Add(this.editbuil_cmb);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel10);
            this.MaximizeBox = false;
            this.Name = "UpdateLocationForm";
            this.Resizable = false;
            this.Text = "UpdateLocation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton cancel_btn;
        private MetroFramework.Controls.MetroButton editloc_btn;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        public MetroFramework.Controls.MetroComboBox editroomtype_cmb;
        public MetroFramework.Controls.MetroComboBox editroom_cmb;
        public MetroFramework.Controls.MetroComboBox editbuil_cmb;
        public MetroFramework.Controls.MetroTextBox editcap_txtbox;
        public MetroFramework.Controls.MetroButton deleteloc_btn;
    }
}