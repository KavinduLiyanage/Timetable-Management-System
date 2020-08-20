namespace TimetableManagementSystem.Tags
{
    partial class Tags
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tagNameSearchBox = new MetroFramework.Controls.MetroTextBox();
            this.tagNameData = new System.Windows.Forms.DataGridView();
            this.tagNameSrtDrpDwn = new MetroFramework.Controls.MetroComboBox();
            this.tagNameDltBtn = new MetroFramework.Controls.MetroButton();
            this.tagNameEditBtn = new MetroFramework.Controls.MetroButton();
            this.tagNameClrBtn = new MetroFramework.Controls.MetroButton();
            this.tagNameAddBtn = new MetroFramework.Controls.MetroButton();
            this.tagNameTxt = new MetroFramework.Controls.MetroTextBox();
            this.tagNameSrtBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.tagNameData)).BeginInit();
            this.SuspendLayout();
            // 
            // tagNameSearchBox
            // 
            // 
            // 
            // 
            this.tagNameSearchBox.CustomButton.Image = null;
            this.tagNameSearchBox.CustomButton.Location = new System.Drawing.Point(135, 2);
            this.tagNameSearchBox.CustomButton.Name = "";
            this.tagNameSearchBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tagNameSearchBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tagNameSearchBox.CustomButton.TabIndex = 1;
            this.tagNameSearchBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tagNameSearchBox.CustomButton.UseSelectable = true;
            this.tagNameSearchBox.CustomButton.Visible = false;
            this.tagNameSearchBox.DisplayIcon = true;
            this.tagNameSearchBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tagNameSearchBox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.tagNameSearchBox.Icon = global::TimetableManagementSystem.Properties.Resources.Search2;
            this.tagNameSearchBox.IconRight = true;
            this.tagNameSearchBox.Lines = new string[] {
        "Search"};
            this.tagNameSearchBox.Location = new System.Drawing.Point(515, 186);
            this.tagNameSearchBox.MaxLength = 32767;
            this.tagNameSearchBox.Name = "tagNameSearchBox";
            this.tagNameSearchBox.PasswordChar = '\0';
            this.tagNameSearchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tagNameSearchBox.SelectedText = "";
            this.tagNameSearchBox.SelectionLength = 0;
            this.tagNameSearchBox.SelectionStart = 0;
            this.tagNameSearchBox.ShortcutsEnabled = true;
            this.tagNameSearchBox.Size = new System.Drawing.Size(163, 30);
            this.tagNameSearchBox.TabIndex = 64;
            this.tagNameSearchBox.Text = "Search";
            this.tagNameSearchBox.UseSelectable = true;
            this.tagNameSearchBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tagNameSearchBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tagNameSearchBox.TextChanged += new System.EventHandler(this.tagNameSearchBox_TextChanged);
            this.tagNameSearchBox.Click += new System.EventHandler(this.tagNameSearchBox_Click);
            // 
            // tagNameData
            // 
            this.tagNameData.AllowUserToAddRows = false;
            this.tagNameData.AllowUserToDeleteRows = false;
            this.tagNameData.AllowUserToOrderColumns = true;
            this.tagNameData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tagNameData.BackgroundColor = System.Drawing.Color.White;
            this.tagNameData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tagNameData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tagNameData.ColumnHeadersHeight = 29;
            this.tagNameData.Location = new System.Drawing.Point(515, 220);
            this.tagNameData.MultiSelect = false;
            this.tagNameData.Name = "tagNameData";
            this.tagNameData.ReadOnly = true;
            this.tagNameData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tagNameData.RowHeadersWidth = 51;
            this.tagNameData.RowTemplate.Height = 24;
            this.tagNameData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tagNameData.Size = new System.Drawing.Size(390, 215);
            this.tagNameData.TabIndex = 58;
            // 
            // tagNameSrtDrpDwn
            // 
            this.tagNameSrtDrpDwn.FormattingEnabled = true;
            this.tagNameSrtDrpDwn.ItemHeight = 23;
            this.tagNameSrtDrpDwn.Items.AddRange(new object[] {
            "Building",
            "Capacity",
            "Room Type"});
            this.tagNameSrtDrpDwn.Location = new System.Drawing.Point(742, 186);
            this.tagNameSrtDrpDwn.Name = "tagNameSrtDrpDwn";
            this.tagNameSrtDrpDwn.Size = new System.Drawing.Size(94, 29);
            this.tagNameSrtDrpDwn.TabIndex = 56;
            this.tagNameSrtDrpDwn.UseSelectable = true;
            // 
            // tagNameDltBtn
            // 
            this.tagNameDltBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tagNameDltBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.tagNameDltBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tagNameDltBtn.Location = new System.Drawing.Point(742, 440);
            this.tagNameDltBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tagNameDltBtn.Name = "tagNameDltBtn";
            this.tagNameDltBtn.Size = new System.Drawing.Size(161, 40);
            this.tagNameDltBtn.TabIndex = 63;
            this.tagNameDltBtn.Text = "Delete";
            this.tagNameDltBtn.UseCustomBackColor = true;
            this.tagNameDltBtn.UseCustomForeColor = true;
            this.tagNameDltBtn.UseSelectable = true;
            // 
            // tagNameEditBtn
            // 
            this.tagNameEditBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tagNameEditBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.tagNameEditBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tagNameEditBtn.Location = new System.Drawing.Point(515, 440);
            this.tagNameEditBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tagNameEditBtn.Name = "tagNameEditBtn";
            this.tagNameEditBtn.Size = new System.Drawing.Size(161, 40);
            this.tagNameEditBtn.TabIndex = 62;
            this.tagNameEditBtn.Text = "Edit Details";
            this.tagNameEditBtn.UseCustomBackColor = true;
            this.tagNameEditBtn.UseCustomForeColor = true;
            this.tagNameEditBtn.UseSelectable = true;
            // 
            // tagNameClrBtn
            // 
            this.tagNameClrBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tagNameClrBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.tagNameClrBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tagNameClrBtn.Location = new System.Drawing.Point(193, 417);
            this.tagNameClrBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tagNameClrBtn.Name = "tagNameClrBtn";
            this.tagNameClrBtn.Size = new System.Drawing.Size(205, 40);
            this.tagNameClrBtn.TabIndex = 61;
            this.tagNameClrBtn.Text = "Clear";
            this.tagNameClrBtn.UseCustomBackColor = true;
            this.tagNameClrBtn.UseCustomForeColor = true;
            this.tagNameClrBtn.UseSelectable = true;
            this.tagNameClrBtn.Click += new System.EventHandler(this.tagNameClrBtn_Click);
            // 
            // tagNameAddBtn
            // 
            this.tagNameAddBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tagNameAddBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.tagNameAddBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tagNameAddBtn.Location = new System.Drawing.Point(193, 373);
            this.tagNameAddBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tagNameAddBtn.Name = "tagNameAddBtn";
            this.tagNameAddBtn.Size = new System.Drawing.Size(205, 40);
            this.tagNameAddBtn.TabIndex = 60;
            this.tagNameAddBtn.Text = "Add Tag Name";
            this.tagNameAddBtn.UseCustomBackColor = true;
            this.tagNameAddBtn.UseCustomForeColor = true;
            this.tagNameAddBtn.UseSelectable = true;
            this.tagNameAddBtn.Click += new System.EventHandler(this.tagNameAddBtn_Click);
            // 
            // tagNameTxt
            // 
            // 
            // 
            // 
            this.tagNameTxt.CustomButton.Image = null;
            this.tagNameTxt.CustomButton.Location = new System.Drawing.Point(177, 2);
            this.tagNameTxt.CustomButton.Name = "";
            this.tagNameTxt.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tagNameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tagNameTxt.CustomButton.TabIndex = 1;
            this.tagNameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tagNameTxt.CustomButton.UseSelectable = true;
            this.tagNameTxt.CustomButton.Visible = false;
            this.tagNameTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tagNameTxt.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.tagNameTxt.Lines = new string[] {
        "Tag Name"};
            this.tagNameTxt.Location = new System.Drawing.Point(193, 302);
            this.tagNameTxt.MaxLength = 32767;
            this.tagNameTxt.Name = "tagNameTxt";
            this.tagNameTxt.PasswordChar = '\0';
            this.tagNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tagNameTxt.SelectedText = "";
            this.tagNameTxt.SelectionLength = 0;
            this.tagNameTxt.SelectionStart = 0;
            this.tagNameTxt.ShortcutsEnabled = true;
            this.tagNameTxt.ShowClearButton = true;
            this.tagNameTxt.Size = new System.Drawing.Size(205, 30);
            this.tagNameTxt.TabIndex = 59;
            this.tagNameTxt.Text = "Tag Name";
            this.tagNameTxt.UseSelectable = true;
            this.tagNameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tagNameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tagNameTxt.Click += new System.EventHandler(this.tagNameTxt_Click);
            // 
            // tagNameSrtBtn
            // 
            this.tagNameSrtBtn.BackColor = System.Drawing.SystemColors.GrayText;
            this.tagNameSrtBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.tagNameSrtBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tagNameSrtBtn.Location = new System.Drawing.Point(841, 186);
            this.tagNameSrtBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tagNameSrtBtn.Name = "tagNameSrtBtn";
            this.tagNameSrtBtn.Size = new System.Drawing.Size(62, 29);
            this.tagNameSrtBtn.TabIndex = 57;
            this.tagNameSrtBtn.Text = "Sort";
            this.tagNameSrtBtn.UseCustomBackColor = true;
            this.tagNameSrtBtn.UseCustomForeColor = true;
            this.tagNameSrtBtn.UseSelectable = true;
            // 
            // Tags
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::TimetableManagementSystem.Properties.Resources.Background;
            this.BackMaxSize = 960;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.tagNameSearchBox);
            this.Controls.Add(this.tagNameData);
            this.Controls.Add(this.tagNameSrtDrpDwn);
            this.Controls.Add(this.tagNameDltBtn);
            this.Controls.Add(this.tagNameEditBtn);
            this.Controls.Add(this.tagNameClrBtn);
            this.Controls.Add(this.tagNameAddBtn);
            this.Controls.Add(this.tagNameTxt);
            this.Controls.Add(this.tagNameSrtBtn);
            this.MaximizeBox = false;
            this.Name = "Tags";
            this.Resizable = false;
            this.Text = "Tags";
            this.Load += new System.EventHandler(this.Tags_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagNameData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tagNameSearchBox;
        private System.Windows.Forms.DataGridView tagNameData;
        private MetroFramework.Controls.MetroComboBox tagNameSrtDrpDwn;
        private MetroFramework.Controls.MetroButton tagNameDltBtn;
        private MetroFramework.Controls.MetroButton tagNameEditBtn;
        private MetroFramework.Controls.MetroButton tagNameClrBtn;
        private MetroFramework.Controls.MetroButton tagNameAddBtn;
        private MetroFramework.Controls.MetroTextBox tagNameTxt;
        private MetroFramework.Controls.MetroButton tagNameSrtBtn;
    }
}