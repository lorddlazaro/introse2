using System.Windows.Forms;

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
            this.treeViewStudentGroup = new System.Windows.Forms.TreeView();
            this.groupBoxTimeslot = new System.Windows.Forms.GroupBox();
            this.buttonDeleteTimeslot = new System.Windows.Forms.Button();
            this.buttonAddTimeslot = new System.Windows.Forms.Button();
            this.labelSelectedPersonTimeslot = new System.Windows.Forms.Label();
            this.dataGridViewExistingTimeslot = new System.Windows.Forms.DataGridView();
            this.labelWeeklyTimeslot = new System.Windows.Forms.Label();
            this.dataGridViewWeeklyTimeslot = new System.Windows.Forms.DataGridView();
            this.buttonTimeslotEdit = new System.Windows.Forms.Button();
            this.buttonAssignTimeslot = new System.Windows.Forms.Button();
            this.buttonUnassignTimeslot = new System.Windows.Forms.Button();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.labelAvailableEvents = new System.Windows.Forms.Label();
            this.labelSelectedPersonEvent = new System.Windows.Forms.Label();
            this.dataGridViewExistingEvent = new System.Windows.Forms.DataGridView();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.buttonAssignEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttonUnassignEvent = new System.Windows.Forms.Button();
            this.treeViewPanelistGroup = new System.Windows.Forms.TreeView();
            this.treeViewStudents = new System.Windows.Forms.TreeView();
            this.treeViewPanelists = new System.Windows.Forms.TreeView();
            this.treeViewUngroupedPanelists = new System.Windows.Forms.TreeView();
            this.comboBoxSortType = new System.Windows.Forms.ComboBox();
            this.buttonDeletePanelist = new System.Windows.Forms.Button();
            this.groupBoxTimeslot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).BeginInit();
            this.groupBoxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewStudentGroup
            // 
            this.treeViewStudentGroup.Location = new System.Drawing.Point(3, 36);
            this.treeViewStudentGroup.Name = "treeViewStudentGroup";
            this.treeViewStudentGroup.Size = new System.Drawing.Size(191, 327);
            this.treeViewStudentGroup.TabIndex = 6;
            this.treeViewStudentGroup.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewStudentGroup_NodeMouseClick);
            // 
            // groupBoxTimeslot
            // 
            this.groupBoxTimeslot.Controls.Add(this.buttonDeleteTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.buttonAddTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.labelSelectedPersonTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.dataGridViewExistingTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.labelWeeklyTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.dataGridViewWeeklyTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.buttonTimeslotEdit);
            this.groupBoxTimeslot.Controls.Add(this.buttonAssignTimeslot);
            this.groupBoxTimeslot.Controls.Add(this.buttonUnassignTimeslot);
            this.groupBoxTimeslot.Location = new System.Drawing.Point(3, 369);
            this.groupBoxTimeslot.Name = "groupBoxTimeslot";
            this.groupBoxTimeslot.Size = new System.Drawing.Size(994, 284);
            this.groupBoxTimeslot.TabIndex = 10;
            this.groupBoxTimeslot.TabStop = false;
            this.groupBoxTimeslot.Text = "Class Schedule";
            // 
            // buttonDeleteTimeslot
            // 
            this.buttonDeleteTimeslot.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteTimeslot.Location = new System.Drawing.Point(473, 193);
            this.buttonDeleteTimeslot.Name = "buttonDeleteTimeslot";
            this.buttonDeleteTimeslot.Size = new System.Drawing.Size(49, 26);
            this.buttonDeleteTimeslot.TabIndex = 24;
            this.buttonDeleteTimeslot.Text = "Delete";
            this.buttonDeleteTimeslot.UseVisualStyleBackColor = true;
            this.buttonDeleteTimeslot.Click += new System.EventHandler(this.buttonDeleteTimeslot_Click);
            // 
            // buttonAddTimeslot
            // 
            this.buttonAddTimeslot.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTimeslot.Location = new System.Drawing.Point(930, 14);
            this.buttonAddTimeslot.Name = "buttonAddTimeslot";
            this.buttonAddTimeslot.Size = new System.Drawing.Size(57, 23);
            this.buttonAddTimeslot.TabIndex = 12;
            this.buttonAddTimeslot.Text = "Add";
            this.buttonAddTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddTimeslot.Click += new System.EventHandler(this.buttonAddTimeslot_Click);
            // 
            // labelSelectedPersonTimeslot
            // 
            this.labelSelectedPersonTimeslot.AutoSize = true;
            this.labelSelectedPersonTimeslot.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedPersonTimeslot.Location = new System.Drawing.Point(5, 13);
            this.labelSelectedPersonTimeslot.Name = "labelSelectedPersonTimeslot";
            this.labelSelectedPersonTimeslot.Size = new System.Drawing.Size(212, 26);
            this.labelSelectedPersonTimeslot.TabIndex = 23;
            this.labelSelectedPersonTimeslot.Text = "Person\'s Class Schedule";
            // 
            // dataGridViewExistingTimeslot
            // 
            this.dataGridViewExistingTimeslot.AllowUserToAddRows = false;
            this.dataGridViewExistingTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewExistingTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingTimeslot.Location = new System.Drawing.Point(527, 40);
            this.dataGridViewExistingTimeslot.MultiSelect = false;
            this.dataGridViewExistingTimeslot.Name = "dataGridViewExistingTimeslot";
            this.dataGridViewExistingTimeslot.ReadOnly = true;
            this.dataGridViewExistingTimeslot.RowHeadersVisible = false;
            this.dataGridViewExistingTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistingTimeslot.Size = new System.Drawing.Size(460, 238);
            this.dataGridViewExistingTimeslot.TabIndex = 22;
            this.dataGridViewExistingTimeslot.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewExistingTimeslot_RowEnter);
            // 
            // labelWeeklyTimeslot
            // 
            this.labelWeeklyTimeslot.AutoSize = true;
            this.labelWeeklyTimeslot.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeeklyTimeslot.Location = new System.Drawing.Point(527, 14);
            this.labelWeeklyTimeslot.Name = "labelWeeklyTimeslot";
            this.labelWeeklyTimeslot.Size = new System.Drawing.Size(154, 26);
            this.labelWeeklyTimeslot.TabIndex = 17;
            this.labelWeeklyTimeslot.Text = "Available Classes";
            // 
            // dataGridViewWeeklyTimeslot
            // 
            this.dataGridViewWeeklyTimeslot.AllowUserToAddRows = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToResizeColumns = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToResizeRows = false;
            this.dataGridViewWeeklyTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeeklyTimeslot.Location = new System.Drawing.Point(6, 40);
            this.dataGridViewWeeklyTimeslot.MultiSelect = false;
            this.dataGridViewWeeklyTimeslot.Name = "dataGridViewWeeklyTimeslot";
            this.dataGridViewWeeklyTimeslot.ReadOnly = true;
            this.dataGridViewWeeklyTimeslot.RowHeadersVisible = false;
            this.dataGridViewWeeklyTimeslot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewWeeklyTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeeklyTimeslot.Size = new System.Drawing.Size(460, 238);
            this.dataGridViewWeeklyTimeslot.TabIndex = 15;
            this.dataGridViewWeeklyTimeslot.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWeeklyTimeslot_RowEnter);
            // 
            // buttonTimeslotEdit
            // 
            this.buttonTimeslotEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimeslotEdit.Location = new System.Drawing.Point(473, 162);
            this.buttonTimeslotEdit.Name = "buttonTimeslotEdit";
            this.buttonTimeslotEdit.Size = new System.Drawing.Size(49, 25);
            this.buttonTimeslotEdit.TabIndex = 20;
            this.buttonTimeslotEdit.Text = "Edit";
            this.buttonTimeslotEdit.UseVisualStyleBackColor = true;
            this.buttonTimeslotEdit.Click += new System.EventHandler(this.buttonEditTimeslot_Click);
            // 
            // buttonAssignTimeslot
            // 
            this.buttonAssignTimeslot.Enabled = false;
            this.buttonAssignTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignTimeslot.Location = new System.Drawing.Point(473, 98);
            this.buttonAssignTimeslot.Name = "buttonAssignTimeslot";
            this.buttonAssignTimeslot.Size = new System.Drawing.Size(49, 26);
            this.buttonAssignTimeslot.TabIndex = 16;
            this.buttonAssignTimeslot.Text = "<--";
            this.buttonAssignTimeslot.UseVisualStyleBackColor = true;
            this.buttonAssignTimeslot.Click += new System.EventHandler(this.buttonAssignTimeslot_Click);
            // 
            // buttonUnassignTimeslot
            // 
            this.buttonUnassignTimeslot.Enabled = false;
            this.buttonUnassignTimeslot.Location = new System.Drawing.Point(473, 130);
            this.buttonUnassignTimeslot.Name = "buttonUnassignTimeslot";
            this.buttonUnassignTimeslot.Size = new System.Drawing.Size(49, 26);
            this.buttonUnassignTimeslot.TabIndex = 13;
            this.buttonUnassignTimeslot.Text = "-->";
            this.buttonUnassignTimeslot.UseVisualStyleBackColor = true;
            this.buttonUnassignTimeslot.Click += new System.EventHandler(this.buttonUnassignTimeslot_Click);
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.buttonEditEvent);
            this.groupBoxEvent.Controls.Add(this.buttonDeleteEvent);
            this.groupBoxEvent.Controls.Add(this.labelAvailableEvents);
            this.groupBoxEvent.Controls.Add(this.labelSelectedPersonEvent);
            this.groupBoxEvent.Controls.Add(this.dataGridViewExistingEvent);
            this.groupBoxEvent.Controls.Add(this.dataGridViewEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAssignEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddEvent);
            this.groupBoxEvent.Controls.Add(this.buttonUnassignEvent);
            this.groupBoxEvent.Location = new System.Drawing.Point(200, 3);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(797, 360);
            this.groupBoxEvent.TabIndex = 11;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Events";
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteEvent.Location = new System.Drawing.Point(373, 229);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(49, 26);
            this.buttonDeleteEvent.TabIndex = 27;
            this.buttonDeleteEvent.Text = "Delete";
            this.buttonDeleteEvent.UseVisualStyleBackColor = true;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // labelAvailableEvents
            // 
            this.labelAvailableEvents.AutoSize = true;
            this.labelAvailableEvents.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailableEvents.Location = new System.Drawing.Point(422, 12);
            this.labelAvailableEvents.Name = "labelAvailableEvents";
            this.labelAvailableEvents.Size = new System.Drawing.Size(149, 26);
            this.labelAvailableEvents.TabIndex = 26;
            this.labelAvailableEvents.Text = "Available Events";
            // 
            // labelSelectedPersonEvent
            // 
            this.labelSelectedPersonEvent.AutoSize = true;
            this.labelSelectedPersonEvent.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedPersonEvent.Location = new System.Drawing.Point(0, 12);
            this.labelSelectedPersonEvent.Name = "labelSelectedPersonEvent";
            this.labelSelectedPersonEvent.Size = new System.Drawing.Size(143, 26);
            this.labelSelectedPersonEvent.TabIndex = 25;
            this.labelSelectedPersonEvent.Text = "Person\'s Events";
            // 
            // dataGridViewExistingEvent
            // 
            this.dataGridViewExistingEvent.AllowUserToAddRows = false;
            this.dataGridViewExistingEvent.AllowUserToDeleteRows = false;
            this.dataGridViewExistingEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExistingEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingEvent.Location = new System.Drawing.Point(427, 41);
            this.dataGridViewExistingEvent.MultiSelect = false;
            this.dataGridViewExistingEvent.Name = "dataGridViewExistingEvent";
            this.dataGridViewExistingEvent.ReadOnly = true;
            this.dataGridViewExistingEvent.RowHeadersVisible = false;
            this.dataGridViewExistingEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistingEvent.Size = new System.Drawing.Size(365, 313);
            this.dataGridViewExistingEvent.TabIndex = 24;
            this.dataGridViewExistingEvent.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewExistingEvent_RowEnter);
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditEvent.Location = new System.Drawing.Point(373, 197);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(49, 26);
            this.buttonEditEvent.TabIndex = 23;
            this.buttonEditEvent.Text = "Edit";
            this.buttonEditEvent.UseVisualStyleBackColor = true;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AllowUserToAddRows = false;
            this.dataGridViewEvent.AllowUserToDeleteRows = false;
            this.dataGridViewEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.Location = new System.Drawing.Point(4, 41);
            this.dataGridViewEvent.MultiSelect = false;
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersVisible = false;
            this.dataGridViewEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvent.Size = new System.Drawing.Size(365, 313);
            this.dataGridViewEvent.TabIndex = 16;
            this.dataGridViewEvent.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewEvent_RowEnter);
            // 
            // buttonAssignEvent
            // 
            this.buttonAssignEvent.Enabled = false;
            this.buttonAssignEvent.Location = new System.Drawing.Point(373, 134);
            this.buttonAssignEvent.Name = "buttonAssignEvent";
            this.buttonAssignEvent.Size = new System.Drawing.Size(49, 25);
            this.buttonAssignEvent.TabIndex = 20;
            this.buttonAssignEvent.Text = "<--";
            this.buttonAssignEvent.UseVisualStyleBackColor = true;
            this.buttonAssignEvent.Click += new System.EventHandler(this.buttonAssignEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddEvent.Location = new System.Drawing.Point(735, 14);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(57, 24);
            this.buttonAddEvent.TabIndex = 17;
            this.buttonAddEvent.Text = "Add";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttonUnassignEvent
            // 
            this.buttonUnassignEvent.Enabled = false;
            this.buttonUnassignEvent.Location = new System.Drawing.Point(373, 165);
            this.buttonUnassignEvent.Name = "buttonUnassignEvent";
            this.buttonUnassignEvent.Size = new System.Drawing.Size(49, 26);
            this.buttonUnassignEvent.TabIndex = 18;
            this.buttonUnassignEvent.Text = "-->";
            this.buttonUnassignEvent.UseVisualStyleBackColor = true;
            this.buttonUnassignEvent.Click += new System.EventHandler(this.buttonUnassignEvent_Click);
            // 
            // treeViewPanelistGroup
            // 
            this.treeViewPanelistGroup.Location = new System.Drawing.Point(3, 36);
            this.treeViewPanelistGroup.Name = "treeViewPanelistGroup";
            this.treeViewPanelistGroup.Size = new System.Drawing.Size(191, 327);
            this.treeViewPanelistGroup.TabIndex = 7;
            this.treeViewPanelistGroup.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPanelistGroup_NodeMouseClick);
            // 
            // treeViewStudents
            // 
            this.treeViewStudents.Location = new System.Drawing.Point(3, 36);
            this.treeViewStudents.Name = "treeViewStudents";
            this.treeViewStudents.Size = new System.Drawing.Size(191, 327);
            this.treeViewStudents.TabIndex = 12;
            this.treeViewStudents.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewStudents_NodeMouseClick);
            // 
            // treeViewPanelists
            // 
            this.treeViewPanelists.Location = new System.Drawing.Point(3, 36);
            this.treeViewPanelists.Name = "treeViewPanelists";
            this.treeViewPanelists.Size = new System.Drawing.Size(191, 327);
            this.treeViewPanelists.TabIndex = 13;
            this.treeViewPanelists.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPanelists_NodeMouseClick);
            // 
            // treeViewUngroupedPanelists
            // 
            this.treeViewUngroupedPanelists.Location = new System.Drawing.Point(3, 36);
            this.treeViewUngroupedPanelists.Name = "treeViewUngroupedPanelists";
            this.treeViewUngroupedPanelists.Size = new System.Drawing.Size(191, 327);
            this.treeViewUngroupedPanelists.TabIndex = 14;
            this.treeViewUngroupedPanelists.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewUngroupedPanelists_NodeMouseClick);
            // 
            // comboBoxSortType
            // 
            this.comboBoxSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortType.FormattingEnabled = true;
            this.comboBoxSortType.Items.AddRange(new object[] {
            "Students (By Thesis Group)",
            "Students",
            "Panelists (By Thesis Group)",
            "Panelists",
            "Panelists (Ungrouped)"});
            this.comboBoxSortType.Location = new System.Drawing.Point(4, 9);
            this.comboBoxSortType.Name = "comboBoxSortType";
            this.comboBoxSortType.Size = new System.Drawing.Size(119, 21);
            this.comboBoxSortType.TabIndex = 15;
            this.comboBoxSortType.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSortType_SelectionChangeCommitted);
            // 
            // buttonDeletePanelist
            // 
            this.buttonDeletePanelist.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeletePanelist.Location = new System.Drawing.Point(129, 9);
            this.buttonDeletePanelist.Name = "buttonDeletePanelist";
            this.buttonDeletePanelist.Size = new System.Drawing.Size(65, 23);
            this.buttonDeletePanelist.TabIndex = 16;
            this.buttonDeletePanelist.Text = "Delete";
            this.buttonDeletePanelist.UseVisualStyleBackColor = true;
            this.buttonDeletePanelist.Click += new System.EventHandler(this.buttonDeletePanelist_Click);
            // 
            // ScheduleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeletePanelist);
            this.Controls.Add(this.comboBoxSortType);
            this.Controls.Add(this.groupBoxTimeslot);
            this.Controls.Add(this.groupBoxEvent);
            this.Controls.Add(this.treeViewStudentGroup);
            this.Controls.Add(this.treeViewUngroupedPanelists);
            this.Controls.Add(this.treeViewPanelists);
            this.Controls.Add(this.treeViewStudents);
            this.Controls.Add(this.treeViewPanelistGroup);
            this.Name = "ScheduleEditor";
            this.Size = new System.Drawing.Size(1000, 656);
            this.groupBoxTimeslot.ResumeLayout(false);
            this.groupBoxTimeslot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).EndInit();
            this.groupBoxEvent.ResumeLayout(false);
            this.groupBoxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewStudentGroup;
        private System.Windows.Forms.GroupBox groupBoxTimeslot;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.Button buttonAddTimeslot;
        private System.Windows.Forms.Button buttonUnassignTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewWeeklyTimeslot;
        private System.Windows.Forms.Button buttonAssignTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewEvent;
        private System.Windows.Forms.Button buttonAssignEvent;
        private System.Windows.Forms.Button buttonUnassignEvent;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Label labelWeeklyTimeslot;
        private System.Windows.Forms.Button buttonTimeslotEdit;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.DataGridView dataGridViewExistingTimeslot;
        private System.Windows.Forms.DataGridView dataGridViewExistingEvent;
        private System.Windows.Forms.TreeView treeViewPanelistGroup;
        private System.Windows.Forms.Label labelSelectedPersonTimeslot;
        private System.Windows.Forms.Label labelAvailableEvents;
        private System.Windows.Forms.Label labelSelectedPersonEvent;
        private System.Windows.Forms.TreeView treeViewStudents;
        private System.Windows.Forms.TreeView treeViewPanelists;
        private System.Windows.Forms.TreeView treeViewUngroupedPanelists;
        private System.Windows.Forms.ComboBox comboBoxSortType;
        private System.Windows.Forms.Button buttonDeletePanelist;
        private System.Windows.Forms.Button buttonDeleteTimeslot;
        private System.Windows.Forms.Button buttonDeleteEvent;
    }
}
