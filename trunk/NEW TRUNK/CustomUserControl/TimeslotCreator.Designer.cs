namespace CustomUserControl
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Monday");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Tuesday");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Wednesday");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Thursday");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Friday");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Saturday");
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
            this.SuspendLayout();
            // 
            // textBoxWeeklyTimeslotCourse
            // 
            this.textBoxWeeklyTimeslotCourse.Location = new System.Drawing.Point(66, 30);
            this.textBoxWeeklyTimeslotCourse.Name = "textBoxWeeklyTimeslotCourse";
            this.textBoxWeeklyTimeslotCourse.Size = new System.Drawing.Size(134, 20);
            this.textBoxWeeklyTimeslotCourse.TabIndex = 27;
            // 
            // listViewWeeklyTimeslotDay
            // 
            this.listViewWeeklyTimeslotDay.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewWeeklyTimeslotDay.CheckBoxes = true;
            this.listViewWeeklyTimeslotDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewWeeklyTimeslotDay.HotTracking = true;
            this.listViewWeeklyTimeslotDay.HoverSelection = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.listViewWeeklyTimeslotDay.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listViewWeeklyTimeslotDay.Location = new System.Drawing.Point(206, 3);
            this.listViewWeeklyTimeslotDay.Name = "listViewWeeklyTimeslotDay";
            this.listViewWeeklyTimeslotDay.Size = new System.Drawing.Size(85, 122);
            this.listViewWeeklyTimeslotDay.TabIndex = 33;
            this.listViewWeeklyTimeslotDay.UseCompatibleStateImageBehavior = false;
            this.listViewWeeklyTimeslotDay.View = System.Windows.Forms.View.SmallIcon;
            this.listViewWeeklyTimeslotDay.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewWeeklyTimeslotDay_ItemChecked);
            // 
            // labelWeeklyTimeslotCourse
            // 
            this.labelWeeklyTimeslotCourse.AutoSize = true;
            this.labelWeeklyTimeslotCourse.Location = new System.Drawing.Point(20, 33);
            this.labelWeeklyTimeslotCourse.Name = "labelWeeklyTimeslotCourse";
            this.labelWeeklyTimeslotCourse.Size = new System.Drawing.Size(40, 13);
            this.labelWeeklyTimeslotCourse.TabIndex = 22;
            this.labelWeeklyTimeslotCourse.Text = "Course";
            // 
            // labelWeeklyTimeslotSection
            // 
            this.labelWeeklyTimeslotSection.AutoSize = true;
            this.labelWeeklyTimeslotSection.Location = new System.Drawing.Point(17, 56);
            this.labelWeeklyTimeslotSection.Name = "labelWeeklyTimeslotSection";
            this.labelWeeklyTimeslotSection.Size = new System.Drawing.Size(43, 13);
            this.labelWeeklyTimeslotSection.TabIndex = 23;
            this.labelWeeklyTimeslotSection.Text = "Section";
            // 
            // labelWeeklyTimeslotStartTime
            // 
            this.labelWeeklyTimeslotStartTime.AutoSize = true;
            this.labelWeeklyTimeslotStartTime.Location = new System.Drawing.Point(5, 86);
            this.labelWeeklyTimeslotStartTime.Name = "labelWeeklyTimeslotStartTime";
            this.labelWeeklyTimeslotStartTime.Size = new System.Drawing.Size(55, 13);
            this.labelWeeklyTimeslotStartTime.TabIndex = 24;
            this.labelWeeklyTimeslotStartTime.Text = "Start Time";
            // 
            // labelWeeklyTimeslotEndTime
            // 
            this.labelWeeklyTimeslotEndTime.AutoSize = true;
            this.labelWeeklyTimeslotEndTime.Location = new System.Drawing.Point(8, 111);
            this.labelWeeklyTimeslotEndTime.Name = "labelWeeklyTimeslotEndTime";
            this.labelWeeklyTimeslotEndTime.Size = new System.Drawing.Size(52, 13);
            this.labelWeeklyTimeslotEndTime.TabIndex = 25;
            this.labelWeeklyTimeslotEndTime.Text = "End Time";
            // 
            // labelWeeklyTimeslotDay
            // 
            this.labelWeeklyTimeslotDay.AutoSize = true;
            this.labelWeeklyTimeslotDay.Location = new System.Drawing.Point(176, 9);
            this.labelWeeklyTimeslotDay.Name = "labelWeeklyTimeslotDay";
            this.labelWeeklyTimeslotDay.Size = new System.Drawing.Size(26, 13);
            this.labelWeeklyTimeslotDay.TabIndex = 26;
            this.labelWeeklyTimeslotDay.Text = "Day";
            // 
            // textBoxWeeklyTimeslotSection
            // 
            this.textBoxWeeklyTimeslotSection.Location = new System.Drawing.Point(66, 53);
            this.textBoxWeeklyTimeslotSection.Name = "textBoxWeeklyTimeslotSection";
            this.textBoxWeeklyTimeslotSection.Size = new System.Drawing.Size(134, 20);
            this.textBoxWeeklyTimeslotSection.TabIndex = 28;
            // 
            // labelWeeklyTimeslotPanelist
            // 
            this.labelWeeklyTimeslotPanelist.AutoSize = true;
            this.labelWeeklyTimeslotPanelist.Location = new System.Drawing.Point(12, 134);
            this.labelWeeklyTimeslotPanelist.Name = "labelWeeklyTimeslotPanelist";
            this.labelWeeklyTimeslotPanelist.Size = new System.Drawing.Size(51, 13);
            this.labelWeeklyTimeslotPanelist.TabIndex = 32;
            this.labelWeeklyTimeslotPanelist.Text = "Professor";
            // 
            // dateTimePickerWeeklyTimeslotStartTime
            // 
            this.dateTimePickerWeeklyTimeslotStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerWeeklyTimeslotStartTime.Location = new System.Drawing.Point(66, 79);
            this.dateTimePickerWeeklyTimeslotStartTime.Name = "dateTimePickerWeeklyTimeslotStartTime";
            this.dateTimePickerWeeklyTimeslotStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotStartTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotStartTime.Size = new System.Drawing.Size(134, 20);
            this.dateTimePickerWeeklyTimeslotStartTime.TabIndex = 29;
            // 
            // dateTimePickerWeeklyTimeslotEndTime
            // 
            this.dateTimePickerWeeklyTimeslotEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerWeeklyTimeslotEndTime.Location = new System.Drawing.Point(66, 105);
            this.dateTimePickerWeeklyTimeslotEndTime.Name = "dateTimePickerWeeklyTimeslotEndTime";
            this.dateTimePickerWeeklyTimeslotEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotEndTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotEndTime.Size = new System.Drawing.Size(134, 20);
            this.dateTimePickerWeeklyTimeslotEndTime.TabIndex = 30;
            // 
            // comboBoxPanelist
            // 
            this.comboBoxPanelist.FormattingEnabled = true;
            this.comboBoxPanelist.Location = new System.Drawing.Point(66, 131);
            this.comboBoxPanelist.Name = "comboBoxPanelist";
            this.comboBoxPanelist.Size = new System.Drawing.Size(225, 21);
            this.comboBoxPanelist.TabIndex = 31;
            // 
            // buttonSaveTimeslot
            // 
            this.buttonSaveTimeslot.Location = new System.Drawing.Point(135, 158);
            this.buttonSaveTimeslot.Name = "buttonSaveTimeslot";
            this.buttonSaveTimeslot.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTimeslot.TabIndex = 34;
            this.buttonSaveTimeslot.Text = "Save";
            this.buttonSaveTimeslot.UseVisualStyleBackColor = true;
            this.buttonSaveTimeslot.Click += new System.EventHandler(this.buttonSaveTimeslot_Click);
            // 
            // buttonCancelTimeslot
            // 
            this.buttonCancelTimeslot.Location = new System.Drawing.Point(216, 158);
            this.buttonCancelTimeslot.Name = "buttonCancelTimeslot";
            this.buttonCancelTimeslot.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelTimeslot.TabIndex = 35;
            this.buttonCancelTimeslot.Text = "Cancel";
            this.buttonCancelTimeslot.UseVisualStyleBackColor = true;
            this.buttonCancelTimeslot.Click += new System.EventHandler(this.buttonCancelTimeslot_Click);
            // 
            // TimeslotCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 186);
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
            this.Controls.Add(this.comboBoxPanelist);
            this.Name = "TimeslotCreator";
            this.Text = "New Timeslot";
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
    }
}