namespace TimetableManagementSystem.Tags
{
    partial class Form1
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
            this.lblType = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnselecttype = new System.Windows.Forms.Button();
            this.btncanletype = new System.Windows.Forms.Button();
            this.cmdtype = new MetroFramework.Controls.MetroComboBox();
            this.metroLabelerr = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblType.Location = new System.Drawing.Point(63, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 19);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(10, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(215, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Please select  a Timetable type";
            // 
            // btnselecttype
            // 
            this.btnselecttype.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnselecttype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselecttype.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnselecttype.Location = new System.Drawing.Point(179, 122);
            this.btnselecttype.Name = "btnselecttype";
            this.btnselecttype.Size = new System.Drawing.Size(92, 26);
            this.btnselecttype.TabIndex = 21;
            this.btnselecttype.Text = "Select";
            this.btnselecttype.UseVisualStyleBackColor = false;
            this.btnselecttype.Click += new System.EventHandler(this.btnselecttype_Click);
            // 
            // btncanletype
            // 
            this.btncanletype.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btncanletype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncanletype.ForeColor = System.Drawing.Color.FloralWhite;
            this.btncanletype.Location = new System.Drawing.Point(303, 122);
            this.btncanletype.Name = "btncanletype";
            this.btncanletype.Size = new System.Drawing.Size(104, 26);
            this.btncanletype.TabIndex = 22;
            this.btncanletype.Text = "Cancel";
            this.btncanletype.UseVisualStyleBackColor = false;
            this.btncanletype.Click += new System.EventHandler(this.btncanletype_Click);
            // 
            // cmdtype
            // 
            this.cmdtype.FormattingEnabled = true;
            this.cmdtype.ItemHeight = 23;
            this.cmdtype.Location = new System.Drawing.Point(167, 63);
            this.cmdtype.Name = "cmdtype";
            this.cmdtype.Size = new System.Drawing.Size(192, 29);
            this.cmdtype.TabIndex = 23;
            this.cmdtype.UseSelectable = true;
            // 
            // metroLabelerr
            // 
            this.metroLabelerr.AutoSize = true;
            this.metroLabelerr.BackColor = System.Drawing.Color.White;
            this.metroLabelerr.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelerr.ForeColor = System.Drawing.SystemColors.Info;
            this.metroLabelerr.Location = new System.Drawing.Point(167, 95);
            this.metroLabelerr.Name = "metroLabelerr";
            this.metroLabelerr.Size = new System.Drawing.Size(140, 19);
            this.metroLabelerr.TabIndex = 24;
            this.metroLabelerr.Text = "Please select a type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 171);
            this.Controls.Add(this.metroLabelerr);
            this.Controls.Add(this.cmdtype);
            this.Controls.Add(this.btncanletype);
            this.Controls.Add(this.btnselecttype);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblType);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblType;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button btnselecttype;
        private System.Windows.Forms.Button btncanletype;
        private MetroFramework.Controls.MetroComboBox cmdtype;
        private MetroFramework.Controls.MetroLabel metroLabelerr;
    }
}