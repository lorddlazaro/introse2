namespace CustomUserControl
{
    partial class FreeTimeViewer
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
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.label8AM = new System.Windows.Forms.Label();
            this.label9AM = new System.Windows.Forms.Label();
            this.label8PM = new System.Windows.Forms.Label();
            this.label10AM = new System.Windows.Forms.Label();
            this.label11AM = new System.Windows.Forms.Label();
            this.label12AM = new System.Windows.Forms.Label();
            this.label1PM = new System.Windows.Forms.Label();
            this.label2PM = new System.Windows.Forms.Label();
            this.label3PM = new System.Windows.Forms.Label();
            this.label4PM = new System.Windows.Forms.Label();
            this.label5PM = new System.Windows.Forms.Label();
            this.label6PM = new System.Windows.Forms.Label();
            this.label7PM = new System.Windows.Forms.Label();
            this.label9PM = new System.Windows.Forms.Label();
            this.treeViewClusters = new System.Windows.Forms.TreeView();
            this.comboBoxView = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.labelDate1 = new System.Windows.Forms.Label();
            this.labelDate2 = new System.Windows.Forms.Label();
            this.labelDate3 = new System.Windows.Forms.Label();
            this.labelDate4 = new System.Windows.Forms.Label();
            this.labelDate5 = new System.Windows.Forms.Label();
            this.labelDate6 = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelGroupInfo = new System.Windows.Forms.Label();
            this.treeViewIsolatedGroups = new System.Windows.Forms.TreeView();
            this.groupBoxDefenseInfo = new System.Windows.Forms.GroupBox();
            this.addDefenseButton = new System.Windows.Forms.Button();
            this.deleteDefenseButton = new System.Windows.Forms.Button();
            this.saveDefenseButton = new System.Windows.Forms.Button();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.labelVenue = new System.Windows.Forms.Label();
            this.labelSectionCourse = new System.Windows.Forms.Label();
            this.labelThesisTitle = new System.Windows.Forms.Label();
            this.defenseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.venueTextBox = new System.Windows.Forms.TextBox();
            this.courseSectionTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxDefenseType = new System.Windows.Forms.ComboBox();
            this.labelDefenseType = new System.Windows.Forms.Label();
            this.labelDefDuration = new System.Windows.Forms.Label();
            this.groupBoxDefenseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCalendar
            // 
            this.panelCalendar.BackColor = System.Drawing.SystemColors.Info;
            this.panelCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCalendar.Location = new System.Drawing.Point(84, 83);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(590, 507);
            this.panelCalendar.TabIndex = 0;
            this.panelCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalendar_Paint);
            // 
            // label8AM
            // 
            this.label8AM.AutoSize = true;
            this.label8AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8AM.Location = new System.Drawing.Point(8, 72);
            this.label8AM.Name = "label8AM";
            this.label8AM.Size = new System.Drawing.Size(76, 23);
            this.label8AM.TabIndex = 0;
            this.label8AM.Text = "8:00 AM";
            // 
            // label9AM
            // 
            this.label9AM.AutoSize = true;
            this.label9AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9AM.Location = new System.Drawing.Point(8, 111);
            this.label9AM.Name = "label9AM";
            this.label9AM.Size = new System.Drawing.Size(76, 23);
            this.label9AM.TabIndex = 1;
            this.label9AM.Text = "9:00 AM";
            // 
            // label8PM
            // 
            this.label8PM.AutoSize = true;
            this.label8PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8PM.Location = new System.Drawing.Point(9, 541);
            this.label8PM.Name = "label8PM";
            this.label8PM.Size = new System.Drawing.Size(75, 23);
            this.label8PM.TabIndex = 2;
            this.label8PM.Text = "8:00 PM";
            // 
            // label10AM
            // 
            this.label10AM.AutoSize = true;
            this.label10AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10AM.Location = new System.Drawing.Point(-2, 150);
            this.label10AM.Name = "label10AM";
            this.label10AM.Size = new System.Drawing.Size(86, 23);
            this.label10AM.TabIndex = 3;
            this.label10AM.Text = "10:00 AM";
            // 
            // label11AM
            // 
            this.label11AM.AutoSize = true;
            this.label11AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11AM.Location = new System.Drawing.Point(-2, 189);
            this.label11AM.Name = "label11AM";
            this.label11AM.Size = new System.Drawing.Size(86, 23);
            this.label11AM.TabIndex = 4;
            this.label11AM.Text = "11:00 AM";
            // 
            // label12AM
            // 
            this.label12AM.AutoSize = true;
            this.label12AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12AM.Location = new System.Drawing.Point(-1, 228);
            this.label12AM.Name = "label12AM";
            this.label12AM.Size = new System.Drawing.Size(85, 23);
            this.label12AM.TabIndex = 5;
            this.label12AM.Text = "12:00 PM";
            // 
            // label1PM
            // 
            this.label1PM.AutoSize = true;
            this.label1PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1PM.Location = new System.Drawing.Point(9, 268);
            this.label1PM.Name = "label1PM";
            this.label1PM.Size = new System.Drawing.Size(75, 23);
            this.label1PM.TabIndex = 6;
            this.label1PM.Text = "1:00 PM";
            // 
            // label2PM
            // 
            this.label2PM.AutoSize = true;
            this.label2PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2PM.Location = new System.Drawing.Point(9, 307);
            this.label2PM.Name = "label2PM";
            this.label2PM.Size = new System.Drawing.Size(75, 23);
            this.label2PM.TabIndex = 7;
            this.label2PM.Text = "2:00 PM";
            // 
            // label3PM
            // 
            this.label3PM.AutoSize = true;
            this.label3PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3PM.Location = new System.Drawing.Point(9, 346);
            this.label3PM.Name = "label3PM";
            this.label3PM.Size = new System.Drawing.Size(75, 23);
            this.label3PM.TabIndex = 8;
            this.label3PM.Text = "3:00 PM";
            // 
            // label4PM
            // 
            this.label4PM.AutoSize = true;
            this.label4PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4PM.Location = new System.Drawing.Point(9, 385);
            this.label4PM.Name = "label4PM";
            this.label4PM.Size = new System.Drawing.Size(75, 23);
            this.label4PM.TabIndex = 9;
            this.label4PM.Text = "4:00 PM";
            // 
            // label5PM
            // 
            this.label5PM.AutoSize = true;
            this.label5PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5PM.Location = new System.Drawing.Point(9, 424);
            this.label5PM.Name = "label5PM";
            this.label5PM.Size = new System.Drawing.Size(75, 23);
            this.label5PM.TabIndex = 10;
            this.label5PM.Text = "5:00 PM";
            // 
            // label6PM
            // 
            this.label6PM.AutoSize = true;
            this.label6PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6PM.Location = new System.Drawing.Point(9, 463);
            this.label6PM.Name = "label6PM";
            this.label6PM.Size = new System.Drawing.Size(75, 23);
            this.label6PM.TabIndex = 11;
            this.label6PM.Text = "6:00 PM";
            // 
            // label7PM
            // 
            this.label7PM.AutoSize = true;
            this.label7PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7PM.Location = new System.Drawing.Point(9, 502);
            this.label7PM.Name = "label7PM";
            this.label7PM.Size = new System.Drawing.Size(75, 23);
            this.label7PM.TabIndex = 12;
            this.label7PM.Text = "7:00 PM";
            // 
            // label9PM
            // 
            this.label9PM.AutoSize = true;
            this.label9PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9PM.Location = new System.Drawing.Point(9, 578);
            this.label9PM.Name = "label9PM";
            this.label9PM.Size = new System.Drawing.Size(75, 23);
            this.label9PM.TabIndex = 13;
            this.label9PM.Text = "9:00 PM";
            // 
            // treeViewClusters
            // 
            this.treeViewClusters.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewClusters.CheckBoxes = true;
            this.treeViewClusters.FullRowSelect = true;
            this.treeViewClusters.HideSelection = false;
            this.treeViewClusters.HotTracking = true;
            this.treeViewClusters.Location = new System.Drawing.Point(696, 109);
            this.treeViewClusters.Name = "treeViewClusters";
            this.treeViewClusters.ShowNodeToolTips = true;
            this.treeViewClusters.Size = new System.Drawing.Size(269, 477);
            this.treeViewClusters.TabIndex = 14;
            this.treeViewClusters.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewClusters_BeforeCheck);
            this.treeViewClusters.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewClusters_NodeMouseClick);
            // 
            // comboBoxView
            // 
            this.comboBoxView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Items.AddRange(new object[] {
            "Clustered Groups (According to Panelist)",
            "Thesis Groups"});
            this.comboBoxView.Location = new System.Drawing.Point(685, 83);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(280, 23);
            this.comboBoxView.TabIndex = 15;
            this.comboBoxView.SelectedIndexChanged += new System.EventHandler(this.comboBoxView_SelectedIndexChanged);
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Location = new System.Drawing.Point(150, 2);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(185, 26);
            this.datePicker.TabIndex = 16;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // labelDate1
            // 
            this.labelDate1.AutoSize = true;
            this.labelDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate1.Location = new System.Drawing.Point(94, 42);
            this.labelDate1.Name = "labelDate1";
            this.labelDate1.Size = new System.Drawing.Size(89, 38);
            this.labelDate1.TabIndex = 18;
            this.labelDate1.Text = "Monday\r\nmm/dd/yyyy\r\n";
            this.labelDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate2
            // 
            this.labelDate2.AutoSize = true;
            this.labelDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate2.Location = new System.Drawing.Point(192, 42);
            this.labelDate2.Name = "labelDate2";
            this.labelDate2.Size = new System.Drawing.Size(89, 38);
            this.labelDate2.TabIndex = 19;
            this.labelDate2.Text = "Tuesday\r\nmm/dd/yyyy";
            this.labelDate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate3
            // 
            this.labelDate3.AutoSize = true;
            this.labelDate3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate3.Location = new System.Drawing.Point(291, 42);
            this.labelDate3.Name = "labelDate3";
            this.labelDate3.Size = new System.Drawing.Size(89, 38);
            this.labelDate3.TabIndex = 20;
            this.labelDate3.Text = "Wednesday\r\nmm/dd/yyyy";
            // 
            // labelDate4
            // 
            this.labelDate4.AutoSize = true;
            this.labelDate4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate4.Location = new System.Drawing.Point(387, 42);
            this.labelDate4.Name = "labelDate4";
            this.labelDate4.Size = new System.Drawing.Size(89, 38);
            this.labelDate4.TabIndex = 21;
            this.labelDate4.Text = "Thursday\r\nmm/dd/yyyy";
            this.labelDate4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate5
            // 
            this.labelDate5.AutoSize = true;
            this.labelDate5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate5.Location = new System.Drawing.Point(487, 42);
            this.labelDate5.Name = "labelDate5";
            this.labelDate5.Size = new System.Drawing.Size(89, 38);
            this.labelDate5.TabIndex = 22;
            this.labelDate5.Text = "Friday\r\nmm/dd/yyyy";
            this.labelDate5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate6
            // 
            this.labelDate6.AutoSize = true;
            this.labelDate6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate6.Location = new System.Drawing.Point(582, 42);
            this.labelDate6.Name = "labelDate6";
            this.labelDate6.Size = new System.Drawing.Size(89, 38);
            this.labelDate6.TabIndex = 22;
            this.labelDate6.Text = "Saturday\r\nmm/dd/yyyy";
            this.labelDate6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(-1, -5);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(145, 36);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelGroupInfo
            // 
            this.labelGroupInfo.AutoSize = true;
            this.labelGroupInfo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupInfo.Location = new System.Drawing.Point(80, 595);
            this.labelGroupInfo.Name = "labelGroupInfo";
            this.labelGroupInfo.Size = new System.Drawing.Size(0, 23);
            this.labelGroupInfo.TabIndex = 24;
            // 
            // treeViewIsolatedGroups
            // 
            this.treeViewIsolatedGroups.CheckBoxes = true;
            this.treeViewIsolatedGroups.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewIsolatedGroups.FullRowSelect = true;
            this.treeViewIsolatedGroups.HideSelection = false;
            this.treeViewIsolatedGroups.HotTracking = true;
            this.treeViewIsolatedGroups.Location = new System.Drawing.Point(685, 109);
            this.treeViewIsolatedGroups.Name = "treeViewIsolatedGroups";
            this.treeViewIsolatedGroups.Size = new System.Drawing.Size(280, 481);
            this.treeViewIsolatedGroups.TabIndex = 25;
            this.treeViewIsolatedGroups.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewIsolatedGroups_BeforeCheck);
            this.treeViewIsolatedGroups.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewIsolatedGroups_NodeMouseClick);
            // 
            // groupBoxDefenseInfo
            // 
            this.groupBoxDefenseInfo.BackColor = System.Drawing.Color.Tomato;
            this.groupBoxDefenseInfo.Controls.Add(this.addDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.deleteDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.saveDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.labelDateTime);
            this.groupBoxDefenseInfo.Controls.Add(this.labelVenue);
            this.groupBoxDefenseInfo.Controls.Add(this.labelSectionCourse);
            this.groupBoxDefenseInfo.Controls.Add(this.labelThesisTitle);
            this.groupBoxDefenseInfo.Controls.Add(this.defenseDateTimePicker);
            this.groupBoxDefenseInfo.Controls.Add(this.venueTextBox);
            this.groupBoxDefenseInfo.Controls.Add(this.courseSectionTextBox);
            this.groupBoxDefenseInfo.Controls.Add(this.titleTextBox);
            this.groupBoxDefenseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxDefenseInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDefenseInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxDefenseInfo.Location = new System.Drawing.Point(685, 437);
            this.groupBoxDefenseInfo.Name = "groupBoxDefenseInfo";
            this.groupBoxDefenseInfo.Size = new System.Drawing.Size(280, 153);
            this.groupBoxDefenseInfo.TabIndex = 26;
            this.groupBoxDefenseInfo.TabStop = false;
            this.groupBoxDefenseInfo.Text = "Selected Thesis Group";
            this.groupBoxDefenseInfo.Visible = false;
            // 
            // addDefenseButton
            // 
            this.addDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDefenseButton.Location = new System.Drawing.Point(116, 71);
            this.addDefenseButton.Name = "addDefenseButton";
            this.addDefenseButton.Size = new System.Drawing.Size(156, 23);
            this.addDefenseButton.TabIndex = 10;
            this.addDefenseButton.Text = "Schedule Defense";
            this.addDefenseButton.UseVisualStyleBackColor = true;
            this.addDefenseButton.Visible = false;
            this.addDefenseButton.Click += new System.EventHandler(this.addDefenseButton_Click);
            // 
            // deleteDefenseButton
            // 
            this.deleteDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDefenseButton.Location = new System.Drawing.Point(115, 124);
            this.deleteDefenseButton.Name = "deleteDefenseButton";
            this.deleteDefenseButton.Size = new System.Drawing.Size(75, 23);
            this.deleteDefenseButton.TabIndex = 9;
            this.deleteDefenseButton.Text = "Delete";
            this.deleteDefenseButton.UseVisualStyleBackColor = true;
            this.deleteDefenseButton.Click += new System.EventHandler(this.deleteDefenseButton_Click);
            // 
            // saveDefenseButton
            // 
            this.saveDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDefenseButton.Location = new System.Drawing.Point(197, 124);
            this.saveDefenseButton.Name = "saveDefenseButton";
            this.saveDefenseButton.Size = new System.Drawing.Size(75, 23);
            this.saveDefenseButton.TabIndex = 8;
            this.saveDefenseButton.Text = "Save";
            this.saveDefenseButton.UseVisualStyleBackColor = true;
            this.saveDefenseButton.Click += new System.EventHandler(this.saveDefenseButton_Click);
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.BackColor = System.Drawing.Color.Transparent;
            this.labelDateTime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateTime.Location = new System.Drawing.Point(5, 101);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(97, 18);
            this.labelDateTime.TabIndex = 7;
            this.labelDateTime.Text = "Date and Time";
            // 
            // labelVenue
            // 
            this.labelVenue.AutoSize = true;
            this.labelVenue.BackColor = System.Drawing.Color.Transparent;
            this.labelVenue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVenue.Location = new System.Drawing.Point(5, 74);
            this.labelVenue.Name = "labelVenue";
            this.labelVenue.Size = new System.Drawing.Size(48, 18);
            this.labelVenue.TabIndex = 6;
            this.labelVenue.Text = "Venue";
            // 
            // labelSectionCourse
            // 
            this.labelSectionCourse.AutoSize = true;
            this.labelSectionCourse.BackColor = System.Drawing.Color.Transparent;
            this.labelSectionCourse.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectionCourse.Location = new System.Drawing.Point(5, 49);
            this.labelSectionCourse.Name = "labelSectionCourse";
            this.labelSectionCourse.Size = new System.Drawing.Size(108, 18);
            this.labelSectionCourse.TabIndex = 5;
            this.labelSectionCourse.Text = "Section/ Course ";
            // 
            // labelThesisTitle
            // 
            this.labelThesisTitle.AutoSize = true;
            this.labelThesisTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelThesisTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThesisTitle.Location = new System.Drawing.Point(5, 23);
            this.labelThesisTitle.Name = "labelThesisTitle";
            this.labelThesisTitle.Size = new System.Drawing.Size(78, 18);
            this.labelThesisTitle.TabIndex = 4;
            this.labelThesisTitle.Text = "Thesis Title";
            // 
            // defenseDateTimePicker
            // 
            this.defenseDateTimePicker.CustomFormat = "MMM d, yyyy  h:mm tt";
            this.defenseDateTimePicker.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defenseDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.defenseDateTimePicker.Location = new System.Drawing.Point(117, 97);
            this.defenseDateTimePicker.Name = "defenseDateTimePicker";
            this.defenseDateTimePicker.Size = new System.Drawing.Size(154, 23);
            this.defenseDateTimePicker.TabIndex = 3;
            // 
            // venueTextBox
            // 
            this.venueTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venueTextBox.Location = new System.Drawing.Point(117, 71);
            this.venueTextBox.MaxLength = 3;
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(154, 23);
            this.venueTextBox.TabIndex = 2;
            // 
            // courseSectionTextBox
            // 
            this.courseSectionTextBox.Enabled = false;
            this.courseSectionTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseSectionTextBox.Location = new System.Drawing.Point(117, 45);
            this.courseSectionTextBox.Name = "courseSectionTextBox";
            this.courseSectionTextBox.Size = new System.Drawing.Size(154, 23);
            this.courseSectionTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Enabled = false;
            this.titleTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(117, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(154, 23);
            this.titleTextBox.TabIndex = 0;
            // 
            // comboBoxDefenseType
            // 
            this.comboBoxDefenseType.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDefenseType.FormattingEnabled = true;
            this.comboBoxDefenseType.Items.AddRange(new object[] {
            "Defense",
            "Re-Defense"});
            this.comboBoxDefenseType.Location = new System.Drawing.Point(553, 2);
            this.comboBoxDefenseType.Name = "comboBoxDefenseType";
            this.comboBoxDefenseType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxDefenseType.TabIndex = 27;
            this.comboBoxDefenseType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDefenseType_SelectedIndexChanged);
            // 
            // labelDefenseType
            // 
            this.labelDefenseType.AutoSize = true;
            this.labelDefenseType.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefenseType.Location = new System.Drawing.Point(360, -5);
            this.labelDefenseType.Name = "labelDefenseType";
            this.labelDefenseType.Size = new System.Drawing.Size(187, 36);
            this.labelDefenseType.TabIndex = 28;
            this.labelDefenseType.Text = "Defense Type:";
            // 
            // labelDefDuration
            // 
            this.labelDefDuration.AutoSize = true;
            this.labelDefDuration.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefDuration.Location = new System.Drawing.Point(697, 6);
            this.labelDefDuration.Name = "labelDefDuration";
            this.labelDefDuration.Size = new System.Drawing.Size(0, 19);
            this.labelDefDuration.TabIndex = 29;
            // 
            // FreeTimeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.labelDefDuration);
            this.Controls.Add(this.labelDefenseType);
            this.Controls.Add(this.comboBoxDefenseType);
            this.Controls.Add(this.groupBoxDefenseInfo);
            this.Controls.Add(this.labelGroupInfo);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelDate6);
            this.Controls.Add(this.labelDate5);
            this.Controls.Add(this.labelDate4);
            this.Controls.Add(this.labelDate3);
            this.Controls.Add(this.labelDate2);
            this.Controls.Add(this.labelDate1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.comboBoxView);
            this.Controls.Add(this.label9PM);
            this.Controls.Add(this.label7PM);
            this.Controls.Add(this.label6PM);
            this.Controls.Add(this.label5PM);
            this.Controls.Add(this.label4PM);
            this.Controls.Add(this.label3PM);
            this.Controls.Add(this.label2PM);
            this.Controls.Add(this.label1PM);
            this.Controls.Add(this.label12AM);
            this.Controls.Add(this.label11AM);
            this.Controls.Add(this.label10AM);
            this.Controls.Add(this.label8PM);
            this.Controls.Add(this.label9AM);
            this.Controls.Add(this.label8AM);
            this.Controls.Add(this.panelCalendar);
            this.Controls.Add(this.treeViewIsolatedGroups);
            this.Controls.Add(this.treeViewClusters);
            this.Name = "FreeTimeViewer";
            this.Size = new System.Drawing.Size(984, 676);
            this.groupBoxDefenseInfo.ResumeLayout(false);
            this.groupBoxDefenseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.Label label8AM;
        private System.Windows.Forms.Label label9AM;
        private System.Windows.Forms.Label label8PM;
        private System.Windows.Forms.Label label10AM;
        private System.Windows.Forms.Label label11AM;
        private System.Windows.Forms.Label label12AM;
        private System.Windows.Forms.Label label1PM;
        private System.Windows.Forms.Label label2PM;
        private System.Windows.Forms.Label label3PM;
        private System.Windows.Forms.Label label4PM;
        private System.Windows.Forms.Label label5PM;
        private System.Windows.Forms.Label label6PM;
        private System.Windows.Forms.Label label7PM;
        private System.Windows.Forms.Label label9PM;
        private System.Windows.Forms.TreeView treeViewClusters;
        private System.Windows.Forms.ComboBox comboBoxView;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label labelDate1;
        private System.Windows.Forms.Label labelDate2;
        private System.Windows.Forms.Label labelDate3;
        private System.Windows.Forms.Label labelDate4;
        private System.Windows.Forms.Label labelDate5;
        private System.Windows.Forms.Label labelDate6;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelGroupInfo;
        private System.Windows.Forms.TreeView treeViewIsolatedGroups;
        private System.Windows.Forms.GroupBox groupBoxDefenseInfo;
        private System.Windows.Forms.DateTimePicker defenseDateTimePicker;
        private System.Windows.Forms.TextBox venueTextBox;
        private System.Windows.Forms.TextBox courseSectionTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label labelVenue;
        private System.Windows.Forms.Label labelSectionCourse;
        private System.Windows.Forms.Label labelThesisTitle;
        private System.Windows.Forms.Button deleteDefenseButton;
        private System.Windows.Forms.Button saveDefenseButton;
        private System.Windows.Forms.Button addDefenseButton;
        private System.Windows.Forms.ComboBox comboBoxDefenseType;
        private System.Windows.Forms.Label labelDefenseType;
        private System.Windows.Forms.Label labelDefDuration;
    }
}
