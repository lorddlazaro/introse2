using System.Windows.Forms;

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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
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
            this.labelDate1 = new System.Windows.Forms.Label();
            this.labelDate2 = new System.Windows.Forms.Label();
            this.labelDate3 = new System.Windows.Forms.Label();
            this.labelDate4 = new System.Windows.Forms.Label();
            this.labelDate5 = new System.Windows.Forms.Label();
            this.labelDate6 = new System.Windows.Forms.Label();
            this.treeViewIsolatedGroups = new System.Windows.Forms.TreeView();
            this.groupBoxDefenseInfo = new System.Windows.Forms.GroupBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelPanelists = new System.Windows.Forms.Label();
            this.textBoxPanelists = new System.Windows.Forms.TextBox();
            this.deleteDefenseButton = new System.Windows.Forms.Button();
            this.saveDefenseButton = new System.Windows.Forms.Button();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.labelVenue = new System.Windows.Forms.Label();
            this.labelSectionCourse = new System.Windows.Forms.Label();
            this.labelThesisTitle = new System.Windows.Forms.Label();
            this.defenseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.courseSectionTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.addDefenseButton = new System.Windows.Forms.Button();
            this.venueTextBox = new System.Windows.Forms.TextBox();
            this.labelNoEligibleGroups = new System.Windows.Forms.Label();
            this.groupBoxTopRight = new System.Windows.Forms.GroupBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.comboBoxDefenseType = new System.Windows.Forms.ComboBox();
            this.labelDefenseType = new System.Windows.Forms.Label();
            this.groupBoxDefenseInfo.SuspendLayout();
            this.groupBoxTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCalendar
            // 
            this.panelCalendar.BackColor = System.Drawing.SystemColors.Info;
            this.panelCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCalendar.Location = new System.Drawing.Point(80, 38);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(590, 585);
            this.panelCalendar.TabIndex = 0;
            this.panelCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalendar_Paint);
            // 
            // label8AM
            // 
            this.label8AM.AutoSize = true;
            this.label8AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8AM.Location = new System.Drawing.Point(4, 27);
            this.label8AM.Name = "label8AM";
            this.label8AM.Size = new System.Drawing.Size(76, 23);
            this.label8AM.TabIndex = 0;
            this.label8AM.Text = "8:00 AM";
            // 
            // label9AM
            // 
            this.label9AM.AutoSize = true;
            this.label9AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9AM.Location = new System.Drawing.Point(4, 72);
            this.label9AM.Name = "label9AM";
            this.label9AM.Size = new System.Drawing.Size(76, 23);
            this.label9AM.TabIndex = 1;
            this.label9AM.Text = "9:00 AM";
            // 
            // label8PM
            // 
            this.label8PM.AutoSize = true;
            this.label8PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8PM.Location = new System.Drawing.Point(5, 567);
            this.label8PM.Name = "label8PM";
            this.label8PM.Size = new System.Drawing.Size(75, 23);
            this.label8PM.TabIndex = 2;
            this.label8PM.Text = "8:00 PM";
            // 
            // label10AM
            // 
            this.label10AM.AutoSize = true;
            this.label10AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10AM.Location = new System.Drawing.Point(-6, 117);
            this.label10AM.Name = "label10AM";
            this.label10AM.Size = new System.Drawing.Size(86, 23);
            this.label10AM.TabIndex = 3;
            this.label10AM.Text = "10:00 AM";
            // 
            // label11AM
            // 
            this.label11AM.AutoSize = true;
            this.label11AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11AM.Location = new System.Drawing.Point(-6, 162);
            this.label11AM.Name = "label11AM";
            this.label11AM.Size = new System.Drawing.Size(86, 23);
            this.label11AM.TabIndex = 4;
            this.label11AM.Text = "11:00 AM";
            // 
            // label12AM
            // 
            this.label12AM.AutoSize = true;
            this.label12AM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12AM.Location = new System.Drawing.Point(-5, 207);
            this.label12AM.Name = "label12AM";
            this.label12AM.Size = new System.Drawing.Size(85, 23);
            this.label12AM.TabIndex = 5;
            this.label12AM.Text = "12:00 PM";
            // 
            // label1PM
            // 
            this.label1PM.AutoSize = true;
            this.label1PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1PM.Location = new System.Drawing.Point(5, 252);
            this.label1PM.Name = "label1PM";
            this.label1PM.Size = new System.Drawing.Size(75, 23);
            this.label1PM.TabIndex = 6;
            this.label1PM.Text = "1:00 PM";
            // 
            // label2PM
            // 
            this.label2PM.AutoSize = true;
            this.label2PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2PM.Location = new System.Drawing.Point(5, 297);
            this.label2PM.Name = "label2PM";
            this.label2PM.Size = new System.Drawing.Size(75, 23);
            this.label2PM.TabIndex = 7;
            this.label2PM.Text = "2:00 PM";
            // 
            // label3PM
            // 
            this.label3PM.AutoSize = true;
            this.label3PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3PM.Location = new System.Drawing.Point(5, 342);
            this.label3PM.Name = "label3PM";
            this.label3PM.Size = new System.Drawing.Size(75, 23);
            this.label3PM.TabIndex = 8;
            this.label3PM.Text = "3:00 PM";
            // 
            // label4PM
            // 
            this.label4PM.AutoSize = true;
            this.label4PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4PM.Location = new System.Drawing.Point(5, 387);
            this.label4PM.Name = "label4PM";
            this.label4PM.Size = new System.Drawing.Size(75, 23);
            this.label4PM.TabIndex = 9;
            this.label4PM.Text = "4:00 PM";
            // 
            // label5PM
            // 
            this.label5PM.AutoSize = true;
            this.label5PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5PM.Location = new System.Drawing.Point(5, 432);
            this.label5PM.Name = "label5PM";
            this.label5PM.Size = new System.Drawing.Size(75, 23);
            this.label5PM.TabIndex = 10;
            this.label5PM.Text = "5:00 PM";
            // 
            // label6PM
            // 
            this.label6PM.AutoSize = true;
            this.label6PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6PM.Location = new System.Drawing.Point(5, 477);
            this.label6PM.Name = "label6PM";
            this.label6PM.Size = new System.Drawing.Size(75, 23);
            this.label6PM.TabIndex = 11;
            this.label6PM.Text = "6:00 PM";
            // 
            // label7PM
            // 
            this.label7PM.AutoSize = true;
            this.label7PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7PM.Location = new System.Drawing.Point(5, 522);
            this.label7PM.Name = "label7PM";
            this.label7PM.Size = new System.Drawing.Size(75, 23);
            this.label7PM.TabIndex = 12;
            this.label7PM.Text = "7:00 PM";
            // 
            // label9PM
            // 
            this.label9PM.AutoSize = true;
            this.label9PM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9PM.Location = new System.Drawing.Point(5, 611);
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
            this.treeViewClusters.Location = new System.Drawing.Point(675, 110);
            this.treeViewClusters.Name = "treeViewClusters";
            this.treeViewClusters.ShowNodeToolTips = true;
            this.treeViewClusters.Size = new System.Drawing.Size(306, 513);
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
            this.comboBoxView.Location = new System.Drawing.Point(675, 82);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(306, 23);
            this.comboBoxView.TabIndex = 15;
            this.comboBoxView.SelectedIndexChanged += new System.EventHandler(this.comboBoxView_SelectedIndexChanged);
            // 
            // labelDate1
            // 
            this.labelDate1.AutoSize = true;
            this.labelDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate1.Location = new System.Drawing.Point(90, -5);
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
            this.labelDate2.Location = new System.Drawing.Point(188, -5);
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
            this.labelDate3.Location = new System.Drawing.Point(287, -5);
            this.labelDate3.Name = "labelDate3";
            this.labelDate3.Size = new System.Drawing.Size(89, 38);
            this.labelDate3.TabIndex = 20;
            this.labelDate3.Text = "Wednesday\r\nmm/dd/yyyy";
            // 
            // labelDate4
            // 
            this.labelDate4.AutoSize = true;
            this.labelDate4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate4.Location = new System.Drawing.Point(383, -5);
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
            this.labelDate5.Location = new System.Drawing.Point(483, -5);
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
            this.labelDate6.Location = new System.Drawing.Point(578, -5);
            this.labelDate6.Name = "labelDate6";
            this.labelDate6.Size = new System.Drawing.Size(89, 38);
            this.labelDate6.TabIndex = 22;
            this.labelDate6.Text = "Saturday\r\nmm/dd/yyyy";
            this.labelDate6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeViewIsolatedGroups
            // 
            this.treeViewIsolatedGroups.CheckBoxes = true;
            this.treeViewIsolatedGroups.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewIsolatedGroups.FullRowSelect = true;
            this.treeViewIsolatedGroups.HideSelection = false;
            this.treeViewIsolatedGroups.HotTracking = true;
            this.treeViewIsolatedGroups.Location = new System.Drawing.Point(675, 110);
            this.treeViewIsolatedGroups.Name = "treeViewIsolatedGroups";
            this.treeViewIsolatedGroups.Size = new System.Drawing.Size(280, 513);
            this.treeViewIsolatedGroups.TabIndex = 25;
            this.treeViewIsolatedGroups.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewIsolatedGroups_BeforeCheck);
            this.treeViewIsolatedGroups.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewIsolatedGroups_NodeMouseClick);
            // 
            // groupBoxDefenseInfo
            // 
            this.groupBoxDefenseInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBoxDefenseInfo.Controls.Add(this.labelDuration);
            this.groupBoxDefenseInfo.Controls.Add(this.labelPanelists);
            this.groupBoxDefenseInfo.Controls.Add(this.textBoxPanelists);
            this.groupBoxDefenseInfo.Controls.Add(this.deleteDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.saveDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.labelDateTime);
            this.groupBoxDefenseInfo.Controls.Add(this.labelVenue);
            this.groupBoxDefenseInfo.Controls.Add(this.labelSectionCourse);
            this.groupBoxDefenseInfo.Controls.Add(this.labelThesisTitle);
            this.groupBoxDefenseInfo.Controls.Add(this.defenseDateTimePicker);
            this.groupBoxDefenseInfo.Controls.Add(this.courseSectionTextBox);
            this.groupBoxDefenseInfo.Controls.Add(this.titleTextBox);
            this.groupBoxDefenseInfo.Controls.Add(this.addDefenseButton);
            this.groupBoxDefenseInfo.Controls.Add(this.venueTextBox);
            this.groupBoxDefenseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxDefenseInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDefenseInfo.ForeColor = System.Drawing.Color.Gold;
            this.groupBoxDefenseInfo.Location = new System.Drawing.Point(675, 411);
            this.groupBoxDefenseInfo.Name = "groupBoxDefenseInfo";
            this.groupBoxDefenseInfo.Size = new System.Drawing.Size(306, 212);
            this.groupBoxDefenseInfo.TabIndex = 26;
            this.groupBoxDefenseInfo.TabStop = false;
            this.groupBoxDefenseInfo.Text = "Selected Thesis Group";
            this.groupBoxDefenseInfo.Visible = false;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.ForeColor = System.Drawing.Color.Gold;
            this.labelDuration.Location = new System.Drawing.Point(4, 187);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(108, 18);
            this.labelDuration.TabIndex = 13;
            this.labelDuration.Text = "Duration: 1 hour";
            // 
            // labelPanelists
            // 
            this.labelPanelists.AutoSize = true;
            this.labelPanelists.BackColor = System.Drawing.Color.Transparent;
            this.labelPanelists.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelists.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelPanelists.Location = new System.Drawing.Point(4, 71);
            this.labelPanelists.Name = "labelPanelists";
            this.labelPanelists.Size = new System.Drawing.Size(64, 18);
            this.labelPanelists.TabIndex = 12;
            this.labelPanelists.Text = "Panelists";
            // 
            // textBoxPanelists
            // 
            this.textBoxPanelists.Enabled = false;
            this.textBoxPanelists.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPanelists.Location = new System.Drawing.Point(121, 71);
            this.textBoxPanelists.Multiline = true;
            this.textBoxPanelists.Name = "textBoxPanelists";
            this.textBoxPanelists.Size = new System.Drawing.Size(180, 58);
            this.textBoxPanelists.TabIndex = 11;
            // 
            // deleteDefenseButton
            // 
            this.deleteDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDefenseButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteDefenseButton.Location = new System.Drawing.Point(120, 184);
            this.deleteDefenseButton.Name = "deleteDefenseButton";
            this.deleteDefenseButton.Size = new System.Drawing.Size(87, 23);
            this.deleteDefenseButton.TabIndex = 9;
            this.deleteDefenseButton.Text = "Delete";
            this.deleteDefenseButton.UseVisualStyleBackColor = true;
            this.deleteDefenseButton.Click += new System.EventHandler(this.deleteDefenseButton_Click);
            // 
            // saveDefenseButton
            // 
            this.saveDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDefenseButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveDefenseButton.Location = new System.Drawing.Point(215, 184);
            this.saveDefenseButton.Name = "saveDefenseButton";
            this.saveDefenseButton.Size = new System.Drawing.Size(87, 23);
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
            this.labelDateTime.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDateTime.Location = new System.Drawing.Point(4, 162);
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
            this.labelVenue.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelVenue.Location = new System.Drawing.Point(4, 136);
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
            this.labelSectionCourse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectionCourse.Location = new System.Drawing.Point(4, 48);
            this.labelSectionCourse.Name = "labelSectionCourse";
            this.labelSectionCourse.Size = new System.Drawing.Size(110, 18);
            this.labelSectionCourse.TabIndex = 5;
            this.labelSectionCourse.Text = "Section - Course ";
            // 
            // labelThesisTitle
            // 
            this.labelThesisTitle.AutoSize = true;
            this.labelThesisTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelThesisTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThesisTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelThesisTitle.Location = new System.Drawing.Point(4, 25);
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
            this.defenseDateTimePicker.Location = new System.Drawing.Point(121, 158);
            this.defenseDateTimePicker.MaximumSize = new System.Drawing.Size(180, 23);
            this.defenseDateTimePicker.MinimumSize = new System.Drawing.Size(180, 23);
            this.defenseDateTimePicker.Name = "defenseDateTimePicker";
            this.defenseDateTimePicker.Size = new System.Drawing.Size(180, 23);
            this.defenseDateTimePicker.TabIndex = 3;
            // 
            // courseSectionTextBox
            // 
            this.courseSectionTextBox.Enabled = false;
            this.courseSectionTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseSectionTextBox.Location = new System.Drawing.Point(121, 45);
            this.courseSectionTextBox.MaximumSize = new System.Drawing.Size(180, 23);
            this.courseSectionTextBox.MinimumSize = new System.Drawing.Size(180, 23);
            this.courseSectionTextBox.Name = "courseSectionTextBox";
            this.courseSectionTextBox.Size = new System.Drawing.Size(180, 23);
            this.courseSectionTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Enabled = false;
            this.titleTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(121, 19);
            this.titleTextBox.MaximumSize = new System.Drawing.Size(180, 20);
            this.titleTextBox.MinimumSize = new System.Drawing.Size(180, 20);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(180, 23);
            this.titleTextBox.TabIndex = 0;
            // 
            // addDefenseButton
            // 
            this.addDefenseButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDefenseButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addDefenseButton.Location = new System.Drawing.Point(119, 132);
            this.addDefenseButton.Name = "addDefenseButton";
            this.addDefenseButton.Size = new System.Drawing.Size(184, 23);
            this.addDefenseButton.TabIndex = 10;
            this.addDefenseButton.Text = "Schedule Defense";
            this.addDefenseButton.UseVisualStyleBackColor = true;
            this.addDefenseButton.Visible = false;
            this.addDefenseButton.Click += new System.EventHandler(this.addDefenseButton_Click);
            // 
            // venueTextBox
            // 
            this.venueTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venueTextBox.Location = new System.Drawing.Point(121, 132);
            this.venueTextBox.MaximumSize = new System.Drawing.Size(180, 23);
            this.venueTextBox.MaxLength = 16;
            this.venueTextBox.MinimumSize = new System.Drawing.Size(180, 23);
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(180, 23);
            this.venueTextBox.TabIndex = 2;
            // 
            // labelNoEligibleGroups
            // 
            this.labelNoEligibleGroups.AutoSize = true;
            this.labelNoEligibleGroups.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoEligibleGroups.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelNoEligibleGroups.Location = new System.Drawing.Point(712, 165);
            this.labelNoEligibleGroups.Name = "labelNoEligibleGroups";
            this.labelNoEligibleGroups.Size = new System.Drawing.Size(227, 23);
            this.labelNoEligibleGroups.TabIndex = 30;
            this.labelNoEligibleGroups.Text = "There are no eligible groups.";
            this.labelNoEligibleGroups.Visible = false;
            // 
            // groupBoxTopRight
            // 
            this.groupBoxTopRight.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBoxTopRight.Controls.Add(this.datePicker);
            this.groupBoxTopRight.Controls.Add(this.labelStartDate);
            this.groupBoxTopRight.Controls.Add(this.comboBoxDefenseType);
            this.groupBoxTopRight.Controls.Add(this.labelDefenseType);
            this.groupBoxTopRight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTopRight.ForeColor = System.Drawing.Color.Gold;
            this.groupBoxTopRight.Location = new System.Drawing.Point(675, -4);
            this.groupBoxTopRight.Name = "groupBoxTopRight";
            this.groupBoxTopRight.Size = new System.Drawing.Size(306, 82);
            this.groupBoxTopRight.TabIndex = 31;
            this.groupBoxTopRight.TabStop = false;
            this.groupBoxTopRight.Text = "Settings";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "MMM d, yyyy (dddd)";
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(107, 18);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(187, 23);
            this.datePicker.TabIndex = 32;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelStartDate.Location = new System.Drawing.Point(1, 22);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(83, 19);
            this.labelStartDate.TabIndex = 31;
            this.labelStartDate.Text = "Start Date:";
            // 
            // comboBoxDefenseType
            // 
            this.comboBoxDefenseType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDefenseType.FormattingEnabled = true;
            this.comboBoxDefenseType.Items.AddRange(new object[] {
            "Defense",
            "Re-Defense"});
            this.comboBoxDefenseType.Location = new System.Drawing.Point(107, 49);
            this.comboBoxDefenseType.Name = "comboBoxDefenseType";
            this.comboBoxDefenseType.Size = new System.Drawing.Size(187, 23);
            this.comboBoxDefenseType.TabIndex = 30;
            this.comboBoxDefenseType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDefenseType_SelectedIndexChanged);
            // 
            // labelDefenseType
            // 
            this.labelDefenseType.AutoSize = true;
            this.labelDefenseType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefenseType.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDefenseType.Location = new System.Drawing.Point(1, 51);
            this.labelDefenseType.Name = "labelDefenseType";
            this.labelDefenseType.Size = new System.Drawing.Size(104, 19);
            this.labelDefenseType.TabIndex = 29;
            this.labelDefenseType.Text = "Defense Type:";
            // 
            // FreeTimeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxTopRight);
            this.Controls.Add(this.labelNoEligibleGroups);
            this.Controls.Add(this.groupBoxDefenseInfo);
            this.Controls.Add(this.labelDate6);
            this.Controls.Add(this.labelDate5);
            this.Controls.Add(this.labelDate4);
            this.Controls.Add(this.labelDate3);
            this.Controls.Add(this.labelDate2);
            this.Controls.Add(this.labelDate1);
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
            this.Controls.Add(this.label8AM);
            this.Controls.Add(this.panelCalendar);
            this.Controls.Add(this.treeViewClusters);
            this.Controls.Add(this.treeViewIsolatedGroups);
            this.Controls.Add(this.label9AM);
            this.Name = "FreeTimeViewer";
            this.Size = new System.Drawing.Size(984, 676);
            this.groupBoxDefenseInfo.ResumeLayout(false);
            this.groupBoxDefenseInfo.PerformLayout();
            this.groupBoxTopRight.ResumeLayout(false);
            this.groupBoxTopRight.PerformLayout();
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
        private System.Windows.Forms.Label labelDate1;
        private System.Windows.Forms.Label labelDate2;
        private System.Windows.Forms.Label labelDate3;
        private System.Windows.Forms.Label labelDate4;
        private System.Windows.Forms.Label labelDate5;
        private System.Windows.Forms.Label labelDate6;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.TreeView treeViewIsolatedGroups;
        private System.Windows.Forms.GroupBox groupBoxDefenseInfo;
        private System.Windows.Forms.DateTimePicker datePicker;
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
        private System.Windows.Forms.Label labelNoEligibleGroups;
        private System.Windows.Forms.GroupBox groupBoxTopRight;
        private System.Windows.Forms.ComboBox comboBoxDefenseType;
        private System.Windows.Forms.Label labelDefenseType;
        private System.Windows.Forms.Label labelPanelists;
        private System.Windows.Forms.TextBox textBoxPanelists;
        private System.Windows.Forms.Label labelDuration;
    }
}
