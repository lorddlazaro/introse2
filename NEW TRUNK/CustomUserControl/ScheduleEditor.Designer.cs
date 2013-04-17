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
            this.studentTreeView = new System.Windows.Forms.TreeView();
            this.groupBoxWeeklyTimeslot = new System.Windows.Forms.GroupBox();
            this.labelSelectedPersonTimeslot = new System.Windows.Forms.Label();
            this.dataGridViewExistingTimeslot = new System.Windows.Forms.DataGridView();
            this.labelWeeklyTimeslot = new System.Windows.Forms.Label();
            this.dataGridViewWeeklyTimeslot = new System.Windows.Forms.DataGridView();
            this.buttonWeeklyTimeslotEdit = new System.Windows.Forms.Button();
            this.buttonAddExistingWeeklyTimeslot = new System.Windows.Forms.Button();
            this.buttonDeleteWeeklyTimeslot = new System.Windows.Forms.Button();
            this.buttonAddWeeklyTimeslot = new System.Windows.Forms.Button();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.labelAvailableEvents = new System.Windows.Forms.Label();
            this.labelSelectedPersonEvent = new System.Windows.Forms.Label();
            this.dataGridViewExistingEvent = new System.Windows.Forms.DataGridView();
            this.buttonEventEdit = new System.Windows.Forms.Button();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.buttonAddExistingEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttondeleteEvent = new System.Windows.Forms.Button();
            this.panelistTreeView = new System.Windows.Forms.TreeView();
            this.treeViewStudents = new System.Windows.Forms.TreeView();
            this.treeViewPanelists = new System.Windows.Forms.TreeView();
            this.treeViewUngroupedPanelists = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonDeletePanelist = new System.Windows.Forms.Button();
            this.groupBoxWeeklyTimeslot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).BeginInit();
            this.groupBoxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // studentTreeView
            // 
            this.studentTreeView.Location = new System.Drawing.Point(3, 36);
            this.studentTreeView.Name = "studentTreeView";
            this.studentTreeView.Size = new System.Drawing.Size(245, 327);
            this.studentTreeView.TabIndex = 6;
            this.studentTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.studentTreeView_NodeMouseClick);
            // 
            // groupBoxWeeklyTimeslot
            // 
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelSelectedPersonTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dataGridViewExistingTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dataGridViewWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonWeeklyTimeslotEdit);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddExistingWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonDeleteWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Location = new System.Drawing.Point(3, 369);
            this.groupBoxWeeklyTimeslot.Name = "groupBoxWeeklyTimeslot";
            this.groupBoxWeeklyTimeslot.Size = new System.Drawing.Size(994, 307);
            this.groupBoxWeeklyTimeslot.TabIndex = 10;
            this.groupBoxWeeklyTimeslot.TabStop = false;
            this.groupBoxWeeklyTimeslot.Text = "Class Schedule";
            // 
            // labelSelectedPersonTimeslot
            // 
            this.labelSelectedPersonTimeslot.AutoSize = true;
            this.labelSelectedPersonTimeslot.Location = new System.Drawing.Point(6, 24);
            this.labelSelectedPersonTimeslot.Name = "labelSelectedPersonTimeslot";
            this.labelSelectedPersonTimeslot.Size = new System.Drawing.Size(123, 13);
            this.labelSelectedPersonTimeslot.TabIndex = 23;
            this.labelSelectedPersonTimeslot.Text = "Person\'s Class Schedule";
            // 
            // dataGridViewExistingTimeslot
            // 
            this.dataGridViewExistingTimeslot.AllowUserToAddRows = false;
            this.dataGridViewExistingTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewExistingTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingTimeslot.Location = new System.Drawing.Point(524, 40);
            this.dataGridViewExistingTimeslot.MultiSelect = false;
            this.dataGridViewExistingTimeslot.Name = "dataGridViewExistingTimeslot";
            this.dataGridViewExistingTimeslot.ReadOnly = true;
            this.dataGridViewExistingTimeslot.RowHeadersVisible = false;
            this.dataGridViewExistingTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistingTimeslot.Size = new System.Drawing.Size(460, 261);
            this.dataGridViewExistingTimeslot.TabIndex = 22;
            this.dataGridViewExistingTimeslot.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExistingTimeslot_RowEnter);
            // 
            // labelWeeklyTimeslot
            // 
            this.labelWeeklyTimeslot.AutoSize = true;
            this.labelWeeklyTimeslot.Location = new System.Drawing.Point(521, 24);
            this.labelWeeklyTimeslot.Name = "labelWeeklyTimeslot";
            this.labelWeeklyTimeslot.Size = new System.Drawing.Size(131, 13);
            this.labelWeeklyTimeslot.TabIndex = 17;
            this.labelWeeklyTimeslot.Text = "Available Class Schedules";
            // 
            // dataGridViewWeeklyTimeslot
            // 
            this.dataGridViewWeeklyTimeslot.AllowUserToAddRows = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewWeeklyTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeeklyTimeslot.Location = new System.Drawing.Point(9, 40);
            this.dataGridViewWeeklyTimeslot.MultiSelect = false;
            this.dataGridViewWeeklyTimeslot.Name = "dataGridViewWeeklyTimeslot";
            this.dataGridViewWeeklyTimeslot.ReadOnly = true;
            this.dataGridViewWeeklyTimeslot.RowHeadersVisible = false;
            this.dataGridViewWeeklyTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeeklyTimeslot.Size = new System.Drawing.Size(460, 261);
            this.dataGridViewWeeklyTimeslot.TabIndex = 15;
            this.dataGridViewWeeklyTimeslot.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWeeklyTimeslot_RowEnter);
            // 
            // buttonWeeklyTimeslotEdit
            // 
            this.buttonWeeklyTimeslotEdit.Location = new System.Drawing.Point(941, 8);
            this.buttonWeeklyTimeslotEdit.Name = "buttonWeeklyTimeslotEdit";
            this.buttonWeeklyTimeslotEdit.Size = new System.Drawing.Size(43, 29);
            this.buttonWeeklyTimeslotEdit.TabIndex = 20;
            this.buttonWeeklyTimeslotEdit.Text = "Edit";
            this.buttonWeeklyTimeslotEdit.UseVisualStyleBackColor = true;
            this.buttonWeeklyTimeslotEdit.Click += new System.EventHandler(this.buttonWeeklyTimeslotEdit_Click);
            // 
            // buttonAddExistingWeeklyTimeslot
            // 
            this.buttonAddExistingWeeklyTimeslot.Enabled = false;
            this.buttonAddExistingWeeklyTimeslot.Location = new System.Drawing.Point(475, 107);
            this.buttonAddExistingWeeklyTimeslot.Name = "buttonAddExistingWeeklyTimeslot";
            this.buttonAddExistingWeeklyTimeslot.Size = new System.Drawing.Size(43, 29);
            this.buttonAddExistingWeeklyTimeslot.TabIndex = 16;
            this.buttonAddExistingWeeklyTimeslot.Text = "<--";
            this.buttonAddExistingWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddExistingWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddExistingWeeklyTimeslot_Click);
            // 
            // buttonDeleteWeeklyTimeslot
            // 
            this.buttonDeleteWeeklyTimeslot.Enabled = false;
            this.buttonDeleteWeeklyTimeslot.Location = new System.Drawing.Point(475, 164);
            this.buttonDeleteWeeklyTimeslot.Name = "buttonDeleteWeeklyTimeslot";
            this.buttonDeleteWeeklyTimeslot.Size = new System.Drawing.Size(43, 29);
            this.buttonDeleteWeeklyTimeslot.TabIndex = 13;
            this.buttonDeleteWeeklyTimeslot.Text = "-->";
            this.buttonDeleteWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonDeleteWeeklyTimeslot.Click += new System.EventHandler(this.buttonDeleteWeeklyTimeslot_Click);
            // 
            // buttonAddWeeklyTimeslot
            // 
            this.buttonAddWeeklyTimeslot.Location = new System.Drawing.Point(892, 8);
            this.buttonAddWeeklyTimeslot.Name = "buttonAddWeeklyTimeslot";
            this.buttonAddWeeklyTimeslot.Size = new System.Drawing.Size(43, 29);
            this.buttonAddWeeklyTimeslot.TabIndex = 12;
            this.buttonAddWeeklyTimeslot.Text = "Add";
            this.buttonAddWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddWeeklyTimeslot_Click);
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.labelAvailableEvents);
            this.groupBoxEvent.Controls.Add(this.labelSelectedPersonEvent);
            this.groupBoxEvent.Controls.Add(this.dataGridViewExistingEvent);
            this.groupBoxEvent.Controls.Add(this.buttonEventEdit);
            this.groupBoxEvent.Controls.Add(this.dataGridViewEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddExistingEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddEvent);
            this.groupBoxEvent.Controls.Add(this.buttondeleteEvent);
            this.groupBoxEvent.Location = new System.Drawing.Point(254, 3);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(743, 360);
            this.groupBoxEvent.TabIndex = 11;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Events";
            // 
            // labelAvailableEvents
            // 
            this.labelAvailableEvents.AutoSize = true;
            this.labelAvailableEvents.Location = new System.Drawing.Point(391, 25);
            this.labelAvailableEvents.Name = "labelAvailableEvents";
            this.labelAvailableEvents.Size = new System.Drawing.Size(86, 13);
            this.labelAvailableEvents.TabIndex = 26;
            this.labelAvailableEvents.Text = "Available Events";
            // 
            // labelSelectedPersonEvent
            // 
            this.labelSelectedPersonEvent.AutoSize = true;
            this.labelSelectedPersonEvent.Location = new System.Drawing.Point(3, 25);
            this.labelSelectedPersonEvent.Name = "labelSelectedPersonEvent";
            this.labelSelectedPersonEvent.Size = new System.Drawing.Size(83, 13);
            this.labelSelectedPersonEvent.TabIndex = 25;
            this.labelSelectedPersonEvent.Text = "Person\'s Events";
            // 
            // dataGridViewExistingEvent
            // 
            this.dataGridViewExistingEvent.AllowUserToAddRows = false;
            this.dataGridViewExistingEvent.AllowUserToDeleteRows = false;
            this.dataGridViewExistingEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExistingEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingEvent.Location = new System.Drawing.Point(394, 41);
            this.dataGridViewExistingEvent.MultiSelect = false;
            this.dataGridViewExistingEvent.Name = "dataGridViewExistingEvent";
            this.dataGridViewExistingEvent.ReadOnly = true;
            this.dataGridViewExistingEvent.RowHeadersVisible = false;
            this.dataGridViewExistingEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistingEvent.Size = new System.Drawing.Size(333, 313);
            this.dataGridViewExistingEvent.TabIndex = 24;
            this.dataGridViewExistingEvent.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExistingEvent_RowEnter);
            // 
            // buttonEventEdit
            // 
            this.buttonEventEdit.Location = new System.Drawing.Point(684, 9);
            this.buttonEventEdit.Name = "buttonEventEdit";
            this.buttonEventEdit.Size = new System.Drawing.Size(43, 29);
            this.buttonEventEdit.TabIndex = 23;
            this.buttonEventEdit.Text = "Edit";
            this.buttonEventEdit.UseVisualStyleBackColor = true;
            this.buttonEventEdit.Click += new System.EventHandler(this.buttonEventEdit_Click);
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AllowUserToAddRows = false;
            this.dataGridViewEvent.AllowUserToDeleteRows = false;
            this.dataGridViewEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.Location = new System.Drawing.Point(6, 41);
            this.dataGridViewEvent.MultiSelect = false;
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersVisible = false;
            this.dataGridViewEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvent.Size = new System.Drawing.Size(333, 313);
            this.dataGridViewEvent.TabIndex = 16;
            this.dataGridViewEvent.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvent_RowEnter);
            // 
            // buttonAddExistingEvent
            // 
            this.buttonAddExistingEvent.Enabled = false;
            this.buttonAddExistingEvent.Location = new System.Drawing.Point(345, 145);
            this.buttonAddExistingEvent.Name = "buttonAddExistingEvent";
            this.buttonAddExistingEvent.Size = new System.Drawing.Size(43, 30);
            this.buttonAddExistingEvent.TabIndex = 20;
            this.buttonAddExistingEvent.Text = "<--";
            this.buttonAddExistingEvent.UseVisualStyleBackColor = true;
            this.buttonAddExistingEvent.Click += new System.EventHandler(this.buttonAddExistingEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(635, 9);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(43, 29);
            this.buttonAddEvent.TabIndex = 17;
            this.buttonAddEvent.Text = "Add";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttondeleteEvent
            // 
            this.buttondeleteEvent.Enabled = false;
            this.buttondeleteEvent.Location = new System.Drawing.Point(345, 208);
            this.buttondeleteEvent.Name = "buttondeleteEvent";
            this.buttondeleteEvent.Size = new System.Drawing.Size(43, 29);
            this.buttondeleteEvent.TabIndex = 18;
            this.buttondeleteEvent.Text = "-->";
            this.buttondeleteEvent.UseVisualStyleBackColor = true;
            this.buttondeleteEvent.Click += new System.EventHandler(this.buttondeleteEvent_Click);
            // 
            // panelistTreeView
            // 
            this.panelistTreeView.Location = new System.Drawing.Point(3, 36);
            this.panelistTreeView.Name = "panelistTreeView";
            this.panelistTreeView.Size = new System.Drawing.Size(245, 327);
            this.panelistTreeView.TabIndex = 7;
            this.panelistTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.panelistTreeView_NodeMouseClick);
            // 
            // treeViewStudents
            // 
            this.treeViewStudents.Location = new System.Drawing.Point(3, 36);
            this.treeViewStudents.Name = "treeViewStudents";
            this.treeViewStudents.Size = new System.Drawing.Size(245, 327);
            this.treeViewStudents.TabIndex = 12;
            this.treeViewStudents.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewStudents_NodeMouseClick);
            // 
            // treeViewPanelists
            // 
            this.treeViewPanelists.Location = new System.Drawing.Point(3, 36);
            this.treeViewPanelists.Name = "treeViewPanelists";
            this.treeViewPanelists.Size = new System.Drawing.Size(245, 327);
            this.treeViewPanelists.TabIndex = 13;
            this.treeViewPanelists.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPanelists_NodeMouseClick);
            // 
            // treeViewUngroupedPanelists
            // 
            this.treeViewUngroupedPanelists.Location = new System.Drawing.Point(3, 36);
            this.treeViewUngroupedPanelists.Name = "treeViewUngroupedPanelists";
            this.treeViewUngroupedPanelists.Size = new System.Drawing.Size(245, 327);
            this.treeViewUngroupedPanelists.TabIndex = 14;
            this.treeViewUngroupedPanelists.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewUngroupedPanelists_NodeMouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Students (By Thesis Group)",
            "Students",
            "Panelists (By Thesis Group)",
            "Panelists",
            "Panelists (Ungrouped)"});
            this.comboBox1.Location = new System.Drawing.Point(4, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonDeletePanelist
            // 
            this.buttonDeletePanelist.Location = new System.Drawing.Point(183, 9);
            this.buttonDeletePanelist.Name = "buttonDeletePanelist";
            this.buttonDeletePanelist.Size = new System.Drawing.Size(65, 23);
            this.buttonDeletePanelist.TabIndex = 16;
            this.buttonDeletePanelist.Text = "Delete";
            this.buttonDeletePanelist.UseVisualStyleBackColor = true;
            // 
            // ScheduleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeletePanelist);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBoxWeeklyTimeslot);
            this.Controls.Add(this.groupBoxEvent);
            this.Controls.Add(this.panelistTreeView);
            this.Controls.Add(this.studentTreeView);
            this.Controls.Add(this.treeViewUngroupedPanelists);
            this.Controls.Add(this.treeViewPanelists);
            this.Controls.Add(this.treeViewStudents);
            this.Name = "ScheduleEditor";
            this.Size = new System.Drawing.Size(1000, 679);
            this.groupBoxWeeklyTimeslot.ResumeLayout(false);
            this.groupBoxWeeklyTimeslot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).EndInit();
            this.groupBoxEvent.ResumeLayout(false);
            this.groupBoxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView studentTreeView;
        private System.Windows.Forms.GroupBox groupBoxWeeklyTimeslot;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.Button buttonAddWeeklyTimeslot;
        private System.Windows.Forms.Button buttonDeleteWeeklyTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewWeeklyTimeslot;
        private System.Windows.Forms.Button buttonAddExistingWeeklyTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewEvent;
        private System.Windows.Forms.Button buttonAddExistingEvent;
        private System.Windows.Forms.Button buttondeleteEvent;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Label labelWeeklyTimeslot;
        private System.Windows.Forms.Button buttonWeeklyTimeslotEdit;
        private System.Windows.Forms.Button buttonEventEdit;
        private System.Windows.Forms.DataGridView dataGridViewExistingTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewExistingEvent;
        private System.Windows.Forms.TreeView panelistTreeView;
        private System.Windows.Forms.Label labelSelectedPersonTimeslot;
        private System.Windows.Forms.Label labelAvailableEvents;
        private System.Windows.Forms.Label labelSelectedPersonEvent;
        private System.Windows.Forms.TreeView treeViewStudents;
        private System.Windows.Forms.TreeView treeViewPanelists;
        private System.Windows.Forms.TreeView treeViewUngroupedPanelists;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonDeletePanelist;
    }
}
