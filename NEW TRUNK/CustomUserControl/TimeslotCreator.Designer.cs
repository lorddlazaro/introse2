﻿namespace CustomUserControl
{
    partial class TimeslotCreator
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
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("Monday");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("Tuesday");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("Wednesday");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("Thursday");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("Friday");
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("Saturday");
            this.textBoxWeeklyTimeslotCourse = new System.Windows.Forms.TextBox();
            this.listViewWeeklyTimeslotDay = new System.Windows.Forms.ListView();
            this.labelWeeklyTimeslotCourse = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotSection = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotStartTime = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotEndTime = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotDay = new System.Windows.Forms.Label();
            this.textBoxWeeklyTimeslotSection = new System.Windows.Forms.TextBox();
            this.labelWeeklyTimeslotPanelist = new System.Windows.Forms.Label();
            this.dateTimePickerWeeklyTimeslotStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWeeklyTimeslotEndTime = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPanelist = new System.Windows.Forms.ComboBox();
            this.buttonSaveTimeslot = new System.Windows.Forms.Button();
            this.buttonCancelTimeslot = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWeeklyTimeslotCourse
            // 
            this.textBoxWeeklyTimeslotCourse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxWeeklyTimeslotCourse.Location = new System.Drawing.Point(56, 8);
            this.textBoxWeeklyTimeslotCourse.MaxLength = 7;
            this.textBoxWeeklyTimeslotCourse.Name = "textBoxWeeklyTimeslotCourse";
            this.textBoxWeeklyTimeslotCourse.Size = new System.Drawing.Size(85, 20);
            this.textBoxWeeklyTimeslotCourse.TabIndex = 27;
            // 
            // listViewWeeklyTimeslotDay
            // 
            this.listViewWeeklyTimeslotDay.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewWeeklyTimeslotDay.BackColor = System.Drawing.SystemColors.Control;
            this.listViewWeeklyTimeslotDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWeeklyTimeslotDay.CheckBoxes = true;
            this.listViewWeeklyTimeslotDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewWeeklyTimeslotDay.HotTracking = true;
            this.listViewWeeklyTimeslotDay.HoverSelection = true;
            listViewItem19.StateImageIndex = 0;
            listViewItem20.StateImageIndex = 0;
            listViewItem21.StateImageIndex = 0;
            listViewItem22.StateImageIndex = 0;
            listViewItem23.StateImageIndex = 0;
            listViewItem24.StateImageIndex = 0;
            this.listViewWeeklyTimeslotDay.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24});
            this.listViewWeeklyTimeslotDay.Location = new System.Drawing.Point(56, 59);
            this.listViewWeeklyTimeslotDay.Name = "listViewWeeklyTimeslotDay";
            this.listViewWeeklyTimeslotDay.Scrollable = false;
            this.listViewWeeklyTimeslotDay.Size = new System.Drawing.Size(202, 59);
            this.listViewWeeklyTimeslotDay.TabIndex = 33;
            this.listViewWeeklyTimeslotDay.UseCompatibleStateImageBehavior = false;
            this.listViewWeeklyTimeslotDay.View = System.Windows.Forms.View.SmallIcon;
            this.listViewWeeklyTimeslotDay.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewWeeklyTimeslotDay_ItemChecked);
            // 
            // labelWeeklyTimeslotCourse
            // 
            this.labelWeeklyTimeslotCourse.AutoSize = true;
            this.labelWeeklyTimeslotCourse.Location = new System.Drawing.Point(13, 11);
            this.labelWeeklyTimeslotCourse.Name = "labelWeeklyTimeslotCourse";
            this.labelWeeklyTimeslotCourse.Size = new System.Drawing.Size(40, 13);
            this.labelWeeklyTimeslotCourse.TabIndex = 22;
            this.labelWeeklyTimeslotCourse.Text = "Course";
            // 
            // labelWeeklyTimeslotSection
            // 
            this.labelWeeklyTimeslotSection.AutoSize = true;
            this.labelWeeklyTimeslotSection.Location = new System.Drawing.Point(10, 38);
            this.labelWeeklyTimeslotSection.Name = "labelWeeklyTimeslotSection";
            this.labelWeeklyTimeslotSection.Size = new System.Drawing.Size(43, 13);
            this.labelWeeklyTimeslotSection.TabIndex = 23;
            this.labelWeeklyTimeslotSection.Text = "Section";
            // 
            // labelWeeklyTimeslotStartTime
            // 
            this.labelWeeklyTimeslotStartTime.AutoSize = true;
            this.labelWeeklyTimeslotStartTime.Location = new System.Drawing.Point(150, 11);
            this.labelWeeklyTimeslotStartTime.Name = "labelWeeklyTimeslotStartTime";
            this.labelWeeklyTimeslotStartTime.Size = new System.Drawing.Size(55, 13);
            this.labelWeeklyTimeslotStartTime.TabIndex = 24;
            this.labelWeeklyTimeslotStartTime.Text = "Start Time";
            // 
            // labelWeeklyTimeslotEndTime
            // 
            this.labelWeeklyTimeslotEndTime.AutoSize = true;
            this.labelWeeklyTimeslotEndTime.Location = new System.Drawing.Point(153, 38);
            this.labelWeeklyTimeslotEndTime.Name = "labelWeeklyTimeslotEndTime";
            this.labelWeeklyTimeslotEndTime.Size = new System.Drawing.Size(52, 13);
            this.labelWeeklyTimeslotEndTime.TabIndex = 25;
            this.labelWeeklyTimeslotEndTime.Text = "End Time";
            // 
            // labelWeeklyTimeslotDay
            // 
            this.labelWeeklyTimeslotDay.AutoSize = true;
            this.labelWeeklyTimeslotDay.Location = new System.Drawing.Point(24, 64);
            this.labelWeeklyTimeslotDay.Name = "labelWeeklyTimeslotDay";
            this.labelWeeklyTimeslotDay.Size = new System.Drawing.Size(26, 13);
            this.labelWeeklyTimeslotDay.TabIndex = 26;
            this.labelWeeklyTimeslotDay.Text = "Day";
            // 
            // textBoxWeeklyTimeslotSection
            // 
            this.textBoxWeeklyTimeslotSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxWeeklyTimeslotSection.Location = new System.Drawing.Point(56, 35);
            this.textBoxWeeklyTimeslotSection.MaxLength = 3;
            this.textBoxWeeklyTimeslotSection.Name = "textBoxWeeklyTimeslotSection";
            this.textBoxWeeklyTimeslotSection.Size = new System.Drawing.Size(85, 20);
            this.textBoxWeeklyTimeslotSection.TabIndex = 28;
            // 
            // labelWeeklyTimeslotPanelist
            // 
            this.labelWeeklyTimeslotPanelist.AutoSize = true;
            this.labelWeeklyTimeslotPanelist.Location = new System.Drawing.Point(2, 124);
            this.labelWeeklyTimeslotPanelist.Name = "labelWeeklyTimeslotPanelist";
            this.labelWeeklyTimeslotPanelist.Size = new System.Drawing.Size(51, 13);
            this.labelWeeklyTimeslotPanelist.TabIndex = 32;
            this.labelWeeklyTimeslotPanelist.Text = "Professor";
            // 
            // dateTimePickerWeeklyTimeslotStartTime
            // 
            this.dateTimePickerWeeklyTimeslotStartTime.CustomFormat = "hh:mm tt";
            this.dateTimePickerWeeklyTimeslotStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWeeklyTimeslotStartTime.Location = new System.Drawing.Point(206, 8);
            this.dateTimePickerWeeklyTimeslotStartTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerWeeklyTimeslotStartTime.Name = "dateTimePickerWeeklyTimeslotStartTime";
            this.dateTimePickerWeeklyTimeslotStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotStartTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotStartTime.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerWeeklyTimeslotStartTime.TabIndex = 29;
            this.dateTimePickerWeeklyTimeslotStartTime.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerWeeklyTimeslotEndTime
            // 
            this.dateTimePickerWeeklyTimeslotEndTime.CustomFormat = "hh:mm tt";
            this.dateTimePickerWeeklyTimeslotEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWeeklyTimeslotEndTime.Location = new System.Drawing.Point(206, 35);
            this.dateTimePickerWeeklyTimeslotEndTime.Name = "dateTimePickerWeeklyTimeslotEndTime";
            this.dateTimePickerWeeklyTimeslotEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotEndTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotEndTime.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerWeeklyTimeslotEndTime.TabIndex = 30;
            this.dateTimePickerWeeklyTimeslotEndTime.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // comboBoxPanelist
            // 
            this.comboBoxPanelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPanelist.FormattingEnabled = true;
            this.comboBoxPanelist.Location = new System.Drawing.Point(56, 121);
            this.comboBoxPanelist.Name = "comboBoxPanelist";
            this.comboBoxPanelist.Size = new System.Drawing.Size(235, 21);
            this.comboBoxPanelist.TabIndex = 31;
            // 
            // buttonSaveTimeslot
            // 
            this.buttonSaveTimeslot.Location = new System.Drawing.Point(135, 148);
            this.buttonSaveTimeslot.Name = "buttonSaveTimeslot";
            this.buttonSaveTimeslot.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTimeslot.TabIndex = 34;
            this.buttonSaveTimeslot.Text = "Save";
            this.buttonSaveTimeslot.UseVisualStyleBackColor = true;
            this.buttonSaveTimeslot.Click += new System.EventHandler(this.buttonSaveTimeslot_Click);
            // 
            // buttonCancelTimeslot
            // 
            this.buttonCancelTimeslot.Location = new System.Drawing.Point(216, 148);
            this.buttonCancelTimeslot.Name = "buttonCancelTimeslot";
            this.buttonCancelTimeslot.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelTimeslot.TabIndex = 35;
            this.buttonCancelTimeslot.Text = "Cancel";
            this.buttonCancelTimeslot.UseVisualStyleBackColor = true;
            this.buttonCancelTimeslot.Click += new System.EventHandler(this.buttonCancelTimeslot_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(7, 146);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 13);
            this.labelWarning.TabIndex = 36;
            // 
            // TimeslotCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 179);
            this.Controls.Add(this.comboBoxPanelist);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.buttonCancelTimeslot);
            this.Controls.Add(this.buttonSaveTimeslot);
            this.Controls.Add(this.textBoxWeeklyTimeslotCourse);
            this.Controls.Add(this.listViewWeeklyTimeslotDay);
            this.Controls.Add(this.labelWeeklyTimeslotCourse);
            this.Controls.Add(this.labelWeeklyTimeslotSection);
            this.Controls.Add(this.labelWeeklyTimeslotStartTime);
            this.Controls.Add(this.labelWeeklyTimeslotEndTime);
            this.Controls.Add(this.labelWeeklyTimeslotDay);
            this.Controls.Add(this.textBoxWeeklyTimeslotSection);
            this.Controls.Add(this.labelWeeklyTimeslotPanelist);
            this.Controls.Add(this.dateTimePickerWeeklyTimeslotStartTime);
            this.Controls.Add(this.dateTimePickerWeeklyTimeslotEndTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimeslotCreator";
            this.Text = "Timeslot Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWeeklyTimeslotCourse;
        private System.Windows.Forms.ListView listViewWeeklyTimeslotDay;
        private System.Windows.Forms.Label labelWeeklyTimeslotCourse;
        private System.Windows.Forms.Label labelWeeklyTimeslotSection;
        private System.Windows.Forms.Label labelWeeklyTimeslotStartTime;
        private System.Windows.Forms.Label labelWeeklyTimeslotEndTime;
        private System.Windows.Forms.Label labelWeeklyTimeslotDay;
        private System.Windows.Forms.TextBox textBoxWeeklyTimeslotSection;
        private System.Windows.Forms.Label labelWeeklyTimeslotPanelist;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeeklyTimeslotStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeeklyTimeslotEndTime;
        private System.Windows.Forms.ComboBox comboBoxPanelist;
        private System.Windows.Forms.Button buttonSaveTimeslot;
        private System.Windows.Forms.Button buttonCancelTimeslot;
        private System.Windows.Forms.Label labelWarning;
    }
}