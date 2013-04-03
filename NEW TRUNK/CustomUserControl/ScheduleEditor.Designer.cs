namespace CustomUserControl
{
    partial class ScheduleEditor
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

        #region Component Designer generated code

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
            this.personLabel = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.studentTreeView = new System.Windows.Forms.TreeView();
            this.panelistTreeView = new System.Windows.Forms.TreeView();
            this.btnSwitchView = new System.Windows.Forms.Button();
            this.groupBoxWeeklyTimeslot = new System.Windows.Forms.GroupBox();
            this.buttonWeeklyTimeslotEdit = new System.Windows.Forms.Button();
            this.labelWeeklyTimeslot = new System.Windows.Forms.Label();
            this.comboBoxWeeklyTimeslot = new System.Windows.Forms.ComboBox();
            this.labelWeeklyTimeslotPanelist = new System.Windows.Forms.Label();
            this.comboBoxPanelist = new System.Windows.Forms.ComboBox();
            this.buttonAddExistingWeeklyTimeslot = new System.Windows.Forms.Button();
            this.buttonClearWeeklyTimeslot = new System.Windows.Forms.Button();
            this.dateTimePickerWeeklyTimeslotEndTime = new System.Windows.Forms.DateTimePicker();
            this.buttonDeleteWeeklyTimeslot = new System.Windows.Forms.Button();
            this.dateTimePickerWeeklyTimeslotStartTime = new System.Windows.Forms.DateTimePicker();
            this.textBoxWeeklyTimeslotSection = new System.Windows.Forms.TextBox();
            this.buttonAddWeeklyTimeslot = new System.Windows.Forms.Button();
            this.textBoxWeeklyTimeslotCourse = new System.Windows.Forms.TextBox();
            this.labelWeeklyTimeslotDay = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotEndTime = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotStartTime = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotSection = new System.Windows.Forms.Label();
            this.labelWeeklyTimeslotCourse = new System.Windows.Forms.Label();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.buttonEventEdit = new System.Windows.Forms.Button();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.labelEvent = new System.Windows.Forms.Label();
            this.buttonAddExistingEvent = new System.Windows.Forms.Button();
            this.buttonClearEvent = new System.Windows.Forms.Button();
            this.buttondeleteEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.labelEventName = new System.Windows.Forms.Label();
            this.dateTimePickerEventEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEventStartTime = new System.Windows.Forms.DateTimePicker();
            this.labelEventEndTime = new System.Windows.Forms.Label();
            this.labelEventStartTime = new System.Windows.Forms.Label();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.dataGridViewWeeklyTimeslot = new System.Windows.Forms.DataGridView();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.listViewWeeklyTimeslotDay = new System.Windows.Forms.ListView();
            this.groupBoxWeeklyTimeslot.SuspendLayout();
            this.groupBoxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Location = new System.Drawing.Point(3, 12);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(52, 13);
            this.personLabel.TabIndex = 4;
            this.personLabel.Text = "Students:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(166, 7);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(82, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // studentTreeView
            // 
            this.studentTreeView.Location = new System.Drawing.Point(13, 58);
            this.studentTreeView.Name = "studentTreeView";
            this.studentTreeView.Size = new System.Drawing.Size(235, 528);
            this.studentTreeView.TabIndex = 6;
            this.studentTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.studentTreeView_NodeMouseClick);
            // 
            // panelistTreeView
            // 
            this.panelistTreeView.Location = new System.Drawing.Point(3, 36);
            this.panelistTreeView.Name = "panelistTreeView";
            this.panelistTreeView.Size = new System.Drawing.Size(245, 561);
            this.panelistTreeView.TabIndex = 7;
            this.panelistTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.panelistTreeView_NodeMouseClick);
            // 
            // btnSwitchView
            // 
            this.btnSwitchView.Location = new System.Drawing.Point(52, 7);
            this.btnSwitchView.Name = "btnSwitchView";
            this.btnSwitchView.Size = new System.Drawing.Size(108, 23);
            this.btnSwitchView.TabIndex = 8;
            this.btnSwitchView.Text = "Switch to Panelists";
            this.btnSwitchView.UseVisualStyleBackColor = true;
            this.btnSwitchView.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // groupBoxWeeklyTimeslot
            // 
            this.groupBoxWeeklyTimeslot.Controls.Add(this.listViewWeeklyTimeslotDay);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonWeeklyTimeslotEdit);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dataGridViewWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.comboBoxWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotPanelist);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.comboBoxPanelist);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddExistingWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonClearWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dateTimePickerWeeklyTimeslotEndTime);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonDeleteWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dateTimePickerWeeklyTimeslotStartTime);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.textBoxWeeklyTimeslotSection);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.textBoxWeeklyTimeslotCourse);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotDay);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotEndTime);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotStartTime);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotSection);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslotCourse);
            this.groupBoxWeeklyTimeslot.Location = new System.Drawing.Point(254, 3);
            this.groupBoxWeeklyTimeslot.Name = "groupBoxWeeklyTimeslot";
            this.groupBoxWeeklyTimeslot.Size = new System.Drawing.Size(730, 424);
            this.groupBoxWeeklyTimeslot.TabIndex = 10;
            this.groupBoxWeeklyTimeslot.TabStop = false;
            this.groupBoxWeeklyTimeslot.Text = "Weekly Timeslot";
            // 
            // buttonWeeklyTimeslotEdit
            // 
            this.buttonWeeklyTimeslotEdit.Location = new System.Drawing.Point(619, 81);
            this.buttonWeeklyTimeslotEdit.Name = "buttonWeeklyTimeslotEdit";
            this.buttonWeeklyTimeslotEdit.Size = new System.Drawing.Size(87, 23);
            this.buttonWeeklyTimeslotEdit.TabIndex = 20;
            this.buttonWeeklyTimeslotEdit.Text = "Edit";
            this.buttonWeeklyTimeslotEdit.UseVisualStyleBackColor = true;
            this.buttonWeeklyTimeslotEdit.Click += new System.EventHandler(this.buttonWeeklyTimeslotEdit_Click);
            // 
            // labelWeeklyTimeslot
            // 
            this.labelWeeklyTimeslot.AutoSize = true;
            this.labelWeeklyTimeslot.Location = new System.Drawing.Point(9, 23);
            this.labelWeeklyTimeslot.Name = "labelWeeklyTimeslot";
            this.labelWeeklyTimeslot.Size = new System.Drawing.Size(43, 13);
            this.labelWeeklyTimeslot.TabIndex = 17;
            this.labelWeeklyTimeslot.Text = "Existing";
            // 
            // comboBoxWeeklyTimeslot
            // 
            this.comboBoxWeeklyTimeslot.FormattingEnabled = true;
            this.comboBoxWeeklyTimeslot.Location = new System.Drawing.Point(55, 19);
            this.comboBoxWeeklyTimeslot.Name = "comboBoxWeeklyTimeslot";
            this.comboBoxWeeklyTimeslot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWeeklyTimeslot.TabIndex = 19;
            // 
            // labelWeeklyTimeslotPanelist
            // 
            this.labelWeeklyTimeslotPanelist.AutoSize = true;
            this.labelWeeklyTimeslotPanelist.Location = new System.Drawing.Point(342, 67);
            this.labelWeeklyTimeslotPanelist.Name = "labelWeeklyTimeslotPanelist";
            this.labelWeeklyTimeslotPanelist.Size = new System.Drawing.Size(51, 13);
            this.labelWeeklyTimeslotPanelist.TabIndex = 18;
            this.labelWeeklyTimeslotPanelist.Text = "Professor";
            // 
            // comboBoxPanelist
            // 
            this.comboBoxPanelist.FormattingEnabled = true;
            this.comboBoxPanelist.Location = new System.Drawing.Point(399, 64);
            this.comboBoxPanelist.Name = "comboBoxPanelist";
            this.comboBoxPanelist.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPanelist.TabIndex = 17;
            // 
            // buttonAddExistingWeeklyTimeslot
            // 
            this.buttonAddExistingWeeklyTimeslot.Location = new System.Drawing.Point(526, 23);
            this.buttonAddExistingWeeklyTimeslot.Name = "buttonAddExistingWeeklyTimeslot";
            this.buttonAddExistingWeeklyTimeslot.Size = new System.Drawing.Size(87, 23);
            this.buttonAddExistingWeeklyTimeslot.TabIndex = 16;
            this.buttonAddExistingWeeklyTimeslot.Text = "Add Existing";
            this.buttonAddExistingWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddExistingWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddExistingWeeklyTimeslot_Click);
            // 
            // buttonClearWeeklyTimeslot
            // 
            this.buttonClearWeeklyTimeslot.Location = new System.Drawing.Point(526, 52);
            this.buttonClearWeeklyTimeslot.Name = "buttonClearWeeklyTimeslot";
            this.buttonClearWeeklyTimeslot.Size = new System.Drawing.Size(87, 23);
            this.buttonClearWeeklyTimeslot.TabIndex = 14;
            this.buttonClearWeeklyTimeslot.Text = "Clear";
            this.buttonClearWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonClearWeeklyTimeslot.Click += new System.EventHandler(this.buttonClearWeeklyTimeslot_Click);
            // 
            // dateTimePickerWeeklyTimeslotEndTime
            // 
            this.dateTimePickerWeeklyTimeslotEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerWeeklyTimeslotEndTime.Location = new System.Drawing.Point(400, 38);
            this.dateTimePickerWeeklyTimeslotEndTime.Name = "dateTimePickerWeeklyTimeslotEndTime";
            this.dateTimePickerWeeklyTimeslotEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotEndTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotEndTime.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerWeeklyTimeslotEndTime.TabIndex = 10;
            // 
            // buttonDeleteWeeklyTimeslot
            // 
            this.buttonDeleteWeeklyTimeslot.Enabled = false;
            this.buttonDeleteWeeklyTimeslot.Location = new System.Drawing.Point(619, 52);
            this.buttonDeleteWeeklyTimeslot.Name = "buttonDeleteWeeklyTimeslot";
            this.buttonDeleteWeeklyTimeslot.Size = new System.Drawing.Size(87, 23);
            this.buttonDeleteWeeklyTimeslot.TabIndex = 13;
            this.buttonDeleteWeeklyTimeslot.Text = "Delete";
            this.buttonDeleteWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonDeleteWeeklyTimeslot.Click += new System.EventHandler(this.buttonDeleteWeeklyTimeslot_Click);
            // 
            // dateTimePickerWeeklyTimeslotStartTime
            // 
            this.dateTimePickerWeeklyTimeslotStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerWeeklyTimeslotStartTime.Location = new System.Drawing.Point(400, 12);
            this.dateTimePickerWeeklyTimeslotStartTime.Name = "dateTimePickerWeeklyTimeslotStartTime";
            this.dateTimePickerWeeklyTimeslotStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerWeeklyTimeslotStartTime.ShowUpDown = true;
            this.dateTimePickerWeeklyTimeslotStartTime.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerWeeklyTimeslotStartTime.TabIndex = 9;
            // 
            // textBoxWeeklyTimeslotSection
            // 
            this.textBoxWeeklyTimeslotSection.Location = new System.Drawing.Point(56, 69);
            this.textBoxWeeklyTimeslotSection.Name = "textBoxWeeklyTimeslotSection";
            this.textBoxWeeklyTimeslotSection.Size = new System.Drawing.Size(120, 20);
            this.textBoxWeeklyTimeslotSection.TabIndex = 6;
            // 
            // buttonAddWeeklyTimeslot
            // 
            this.buttonAddWeeklyTimeslot.Enabled = false;
            this.buttonAddWeeklyTimeslot.Location = new System.Drawing.Point(619, 23);
            this.buttonAddWeeklyTimeslot.Name = "buttonAddWeeklyTimeslot";
            this.buttonAddWeeklyTimeslot.Size = new System.Drawing.Size(87, 23);
            this.buttonAddWeeklyTimeslot.TabIndex = 12;
            this.buttonAddWeeklyTimeslot.Text = "Add New";
            this.buttonAddWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddWeeklyTimeslot_Click);
            // 
            // textBoxWeeklyTimeslotCourse
            // 
            this.textBoxWeeklyTimeslotCourse.Location = new System.Drawing.Point(56, 46);
            this.textBoxWeeklyTimeslotCourse.Name = "textBoxWeeklyTimeslotCourse";
            this.textBoxWeeklyTimeslotCourse.Size = new System.Drawing.Size(120, 20);
            this.textBoxWeeklyTimeslotCourse.TabIndex = 5;
            // 
            // labelWeeklyTimeslotDay
            // 
            this.labelWeeklyTimeslotDay.AutoSize = true;
            this.labelWeeklyTimeslotDay.Location = new System.Drawing.Point(181, 21);
            this.labelWeeklyTimeslotDay.Name = "labelWeeklyTimeslotDay";
            this.labelWeeklyTimeslotDay.Size = new System.Drawing.Size(26, 13);
            this.labelWeeklyTimeslotDay.TabIndex = 4;
            this.labelWeeklyTimeslotDay.Text = "Day";
            // 
            // labelWeeklyTimeslotEndTime
            // 
            this.labelWeeklyTimeslotEndTime.AutoSize = true;
            this.labelWeeklyTimeslotEndTime.Location = new System.Drawing.Point(342, 44);
            this.labelWeeklyTimeslotEndTime.Name = "labelWeeklyTimeslotEndTime";
            this.labelWeeklyTimeslotEndTime.Size = new System.Drawing.Size(52, 13);
            this.labelWeeklyTimeslotEndTime.TabIndex = 3;
            this.labelWeeklyTimeslotEndTime.Text = "End Time";
            // 
            // labelWeeklyTimeslotStartTime
            // 
            this.labelWeeklyTimeslotStartTime.AutoSize = true;
            this.labelWeeklyTimeslotStartTime.Location = new System.Drawing.Point(339, 19);
            this.labelWeeklyTimeslotStartTime.Name = "labelWeeklyTimeslotStartTime";
            this.labelWeeklyTimeslotStartTime.Size = new System.Drawing.Size(55, 13);
            this.labelWeeklyTimeslotStartTime.TabIndex = 2;
            this.labelWeeklyTimeslotStartTime.Text = "Start Time";
            // 
            // labelWeeklyTimeslotSection
            // 
            this.labelWeeklyTimeslotSection.AutoSize = true;
            this.labelWeeklyTimeslotSection.Location = new System.Drawing.Point(7, 72);
            this.labelWeeklyTimeslotSection.Name = "labelWeeklyTimeslotSection";
            this.labelWeeklyTimeslotSection.Size = new System.Drawing.Size(43, 13);
            this.labelWeeklyTimeslotSection.TabIndex = 1;
            this.labelWeeklyTimeslotSection.Text = "Section";
            // 
            // labelWeeklyTimeslotCourse
            // 
            this.labelWeeklyTimeslotCourse.AutoSize = true;
            this.labelWeeklyTimeslotCourse.Location = new System.Drawing.Point(10, 49);
            this.labelWeeklyTimeslotCourse.Name = "labelWeeklyTimeslotCourse";
            this.labelWeeklyTimeslotCourse.Size = new System.Drawing.Size(40, 13);
            this.labelWeeklyTimeslotCourse.TabIndex = 0;
            this.labelWeeklyTimeslotCourse.Text = "Course";
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.buttonEventEdit);
            this.groupBoxEvent.Controls.Add(this.dataGridViewEvent);
            this.groupBoxEvent.Controls.Add(this.comboBoxEvent);
            this.groupBoxEvent.Controls.Add(this.labelEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddExistingEvent);
            this.groupBoxEvent.Controls.Add(this.buttonClearEvent);
            this.groupBoxEvent.Controls.Add(this.buttondeleteEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddEvent);
            this.groupBoxEvent.Controls.Add(this.labelEventName);
            this.groupBoxEvent.Controls.Add(this.dateTimePickerEventEndTime);
            this.groupBoxEvent.Controls.Add(this.dateTimePickerEventStartTime);
            this.groupBoxEvent.Controls.Add(this.labelEventEndTime);
            this.groupBoxEvent.Controls.Add(this.labelEventStartTime);
            this.groupBoxEvent.Controls.Add(this.textBoxEventName);
            this.groupBoxEvent.Location = new System.Drawing.Point(254, 433);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(743, 164);
            this.groupBoxEvent.TabIndex = 11;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Event";
            // 
            // buttonEventEdit
            // 
            this.buttonEventEdit.Location = new System.Drawing.Point(293, 103);
            this.buttonEventEdit.Name = "buttonEventEdit";
            this.buttonEventEdit.Size = new System.Drawing.Size(87, 23);
            this.buttonEventEdit.TabIndex = 23;
            this.buttonEventEdit.Text = "Edit";
            this.buttonEventEdit.UseVisualStyleBackColor = true;
            this.buttonEventEdit.Click += new System.EventHandler(this.buttonEventEdit_Click);
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Location = new System.Drawing.Point(70, 17);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(218, 21);
            this.comboBoxEvent.TabIndex = 22;
            // 
            // labelEvent
            // 
            this.labelEvent.AutoSize = true;
            this.labelEvent.Location = new System.Drawing.Point(26, 21);
            this.labelEvent.Name = "labelEvent";
            this.labelEvent.Size = new System.Drawing.Size(43, 13);
            this.labelEvent.TabIndex = 21;
            this.labelEvent.Text = "Existing";
            // 
            // buttonAddExistingEvent
            // 
            this.buttonAddExistingEvent.Location = new System.Drawing.Point(293, 16);
            this.buttonAddExistingEvent.Name = "buttonAddExistingEvent";
            this.buttonAddExistingEvent.Size = new System.Drawing.Size(87, 23);
            this.buttonAddExistingEvent.TabIndex = 20;
            this.buttonAddExistingEvent.Text = "Add Existing";
            this.buttonAddExistingEvent.UseVisualStyleBackColor = true;
            this.buttonAddExistingEvent.Click += new System.EventHandler(this.buttonAddExistingEvent_Click);
            // 
            // buttonClearEvent
            // 
            this.buttonClearEvent.Location = new System.Drawing.Point(293, 132);
            this.buttonClearEvent.Name = "buttonClearEvent";
            this.buttonClearEvent.Size = new System.Drawing.Size(87, 23);
            this.buttonClearEvent.TabIndex = 19;
            this.buttonClearEvent.Text = "Clear";
            this.buttonClearEvent.UseVisualStyleBackColor = true;
            this.buttonClearEvent.Click += new System.EventHandler(this.buttonClearEvent_Click);
            // 
            // buttondeleteEvent
            // 
            this.buttondeleteEvent.Enabled = false;
            this.buttondeleteEvent.Location = new System.Drawing.Point(293, 74);
            this.buttondeleteEvent.Name = "buttondeleteEvent";
            this.buttondeleteEvent.Size = new System.Drawing.Size(87, 23);
            this.buttondeleteEvent.TabIndex = 18;
            this.buttondeleteEvent.Text = "Delete";
            this.buttondeleteEvent.UseVisualStyleBackColor = true;
            this.buttondeleteEvent.Click += new System.EventHandler(this.buttondeleteEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Enabled = false;
            this.buttonAddEvent.Location = new System.Drawing.Point(293, 45);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(87, 23);
            this.buttonAddEvent.TabIndex = 17;
            this.buttonAddEvent.Text = "Add New";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(34, 50);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(35, 13);
            this.labelEventName.TabIndex = 16;
            this.labelEventName.Text = "Name";
            // 
            // dateTimePickerEventEndTime
            // 
            this.dateTimePickerEventEndTime.CustomFormat = "MMMM dd, yyyy   hh:mm  tt";
            this.dateTimePickerEventEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEventEndTime.Location = new System.Drawing.Point(70, 104);
            this.dateTimePickerEventEndTime.Name = "dateTimePickerEventEndTime";
            this.dateTimePickerEventEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerEventEndTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEventEndTime.TabIndex = 14;
            // 
            // dateTimePickerEventStartTime
            // 
            this.dateTimePickerEventStartTime.CustomFormat = "MMMM dd, yyyy   hh:mm  tt";
            this.dateTimePickerEventStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEventStartTime.Location = new System.Drawing.Point(70, 75);
            this.dateTimePickerEventStartTime.Name = "dateTimePickerEventStartTime";
            this.dateTimePickerEventStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerEventStartTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEventStartTime.TabIndex = 13;
            // 
            // labelEventEndTime
            // 
            this.labelEventEndTime.AutoSize = true;
            this.labelEventEndTime.Location = new System.Drawing.Point(17, 107);
            this.labelEventEndTime.Name = "labelEventEndTime";
            this.labelEventEndTime.Size = new System.Drawing.Size(52, 13);
            this.labelEventEndTime.TabIndex = 12;
            this.labelEventEndTime.Text = "End Time";
            // 
            // labelEventStartTime
            // 
            this.labelEventStartTime.AutoSize = true;
            this.labelEventStartTime.Location = new System.Drawing.Point(14, 80);
            this.labelEventStartTime.Name = "labelEventStartTime";
            this.labelEventStartTime.Size = new System.Drawing.Size(55, 13);
            this.labelEventStartTime.TabIndex = 11;
            this.labelEventStartTime.Text = "Start Time";
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(70, 46);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(218, 20);
            this.textBoxEventName.TabIndex = 6;
            // 
            // dataGridViewWeeklyTimeslot
            // 
            this.dataGridViewWeeklyTimeslot.AllowUserToAddRows = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewWeeklyTimeslot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWeeklyTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeeklyTimeslot.Location = new System.Drawing.Point(6, 121);
            this.dataGridViewWeeklyTimeslot.MultiSelect = false;
            this.dataGridViewWeeklyTimeslot.Name = "dataGridViewWeeklyTimeslot";
            this.dataGridViewWeeklyTimeslot.ReadOnly = true;
            this.dataGridViewWeeklyTimeslot.RowHeadersVisible = false;
            this.dataGridViewWeeklyTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeeklyTimeslot.Size = new System.Drawing.Size(718, 297);
            this.dataGridViewWeeklyTimeslot.TabIndex = 15;
            this.dataGridViewWeeklyTimeslot.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWeeklyTimeslot_RowEnter);
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AllowUserToAddRows = false;
            this.dataGridViewEvent.AllowUserToDeleteRows = false;
            this.dataGridViewEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.Location = new System.Drawing.Point(386, 14);
            this.dataGridViewEvent.MultiSelect = false;
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersVisible = false;
            this.dataGridViewEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvent.Size = new System.Drawing.Size(351, 144);
            this.dataGridViewEvent.TabIndex = 16;
            this.dataGridViewEvent.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvent_RowEnter);
            // 
            // listViewWeeklyTimeslotDay
            // 
            this.listViewWeeklyTimeslotDay.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewWeeklyTimeslotDay.CheckBoxes = true;
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
            this.listViewWeeklyTimeslotDay.Location = new System.Drawing.Point(213, 8);
            this.listViewWeeklyTimeslotDay.Name = "listViewWeeklyTimeslotDay";
            this.listViewWeeklyTimeslotDay.Size = new System.Drawing.Size(109, 112);
            this.listViewWeeklyTimeslotDay.TabIndex = 21;
            this.listViewWeeklyTimeslotDay.UseCompatibleStateImageBehavior = false;
            this.listViewWeeklyTimeslotDay.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ScheduleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxWeeklyTimeslot);
            this.Controls.Add(this.groupBoxEvent);
            this.Controls.Add(this.btnSwitchView);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.personLabel);
            this.Controls.Add(this.panelistTreeView);
            this.Controls.Add(this.studentTreeView);
            this.Name = "ScheduleEditor";
            this.Size = new System.Drawing.Size(1000, 600);
            this.groupBoxWeeklyTimeslot.ResumeLayout(false);
            this.groupBoxWeeklyTimeslot.PerformLayout();
            this.groupBoxEvent.ResumeLayout(false);
            this.groupBoxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TreeView studentTreeView;
        private System.Windows.Forms.TreeView panelistTreeView;
        private System.Windows.Forms.Button btnSwitchView;
        private System.Windows.Forms.GroupBox groupBoxWeeklyTimeslot;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeeklyTimeslotStartTime;
        private System.Windows.Forms.TextBox textBoxWeeklyTimeslotSection;
        private System.Windows.Forms.TextBox textBoxWeeklyTimeslotCourse;
        private System.Windows.Forms.Label labelWeeklyTimeslotDay;
        private System.Windows.Forms.Label labelWeeklyTimeslotEndTime;
        private System.Windows.Forms.Label labelWeeklyTimeslotStartTime;
        private System.Windows.Forms.Label labelWeeklyTimeslotSection;
        private System.Windows.Forms.Label labelWeeklyTimeslotCourse;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeeklyTimeslotEndTime;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.TextBox textBoxEventName;
        private System.Windows.Forms.Button buttonAddWeeklyTimeslot;
        private System.Windows.Forms.Button buttonDeleteWeeklyTimeslot;
        private System.Windows.Forms.Button buttonClearWeeklyTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewWeeklyTimeslot;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventStartTime;
        private System.Windows.Forms.Label labelEventEndTime;
        private System.Windows.Forms.Label labelEventStartTime;
        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.Button buttonAddExistingWeeklyTimeslot;
        private System.Windows.Forms.Label labelWeeklyTimeslotPanelist;
        private System.Windows.Forms.ComboBox comboBoxPanelist;
        private System.Windows.Forms.DataGridView dataGridViewEvent;
        private System.Windows.Forms.Button buttonAddExistingEvent;
        private System.Windows.Forms.Button buttonClearEvent;
        private System.Windows.Forms.Button buttondeleteEvent;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Label labelWeeklyTimeslot;
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.ComboBox comboBoxWeeklyTimeslot;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.Button buttonWeeklyTimeslotEdit;
        private System.Windows.Forms.Button buttonEventEdit;
        private System.Windows.Forms.ListView listViewWeeklyTimeslotDay;
    }
}
