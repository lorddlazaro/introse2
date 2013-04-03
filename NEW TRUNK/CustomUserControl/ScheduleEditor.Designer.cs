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
            this.personLabel = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.studentTreeView = new System.Windows.Forms.TreeView();
            this.btnSwitchView = new System.Windows.Forms.Button();
            this.groupBoxWeeklyTimeslot = new System.Windows.Forms.GroupBox();
            this.dataGridViewExistingTimeslot = new System.Windows.Forms.DataGridView();
            this.labelWeeklyTimeslot = new System.Windows.Forms.Label();
            this.dataGridViewWeeklyTimeslot = new System.Windows.Forms.DataGridView();
            this.buttonWeeklyTimeslotEdit = new System.Windows.Forms.Button();
            this.buttonAddExistingWeeklyTimeslot = new System.Windows.Forms.Button();
            this.buttonDeleteWeeklyTimeslot = new System.Windows.Forms.Button();
            this.buttonAddWeeklyTimeslot = new System.Windows.Forms.Button();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.dataGridViewExistingEvent = new System.Windows.Forms.DataGridView();
            this.buttonEventEdit = new System.Windows.Forms.Button();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.buttonAddExistingEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttondeleteEvent = new System.Windows.Forms.Button();
            this.panelistTreeView = new System.Windows.Forms.TreeView();
            this.groupBoxWeeklyTimeslot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).BeginInit();
            this.groupBoxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).BeginInit();
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
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dataGridViewExistingTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.labelWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.dataGridViewWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonWeeklyTimeslotEdit);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddExistingWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonDeleteWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Controls.Add(this.buttonAddWeeklyTimeslot);
            this.groupBoxWeeklyTimeslot.Location = new System.Drawing.Point(254, 3);
            this.groupBoxWeeklyTimeslot.Name = "groupBoxWeeklyTimeslot";
            this.groupBoxWeeklyTimeslot.Size = new System.Drawing.Size(743, 338);
            this.groupBoxWeeklyTimeslot.TabIndex = 10;
            this.groupBoxWeeklyTimeslot.TabStop = false;
            this.groupBoxWeeklyTimeslot.Text = "Weekly Timeslot";
            // 
            // dataGridViewExistingTimeslot
            // 
            this.dataGridViewExistingTimeslot.AllowUserToAddRows = false;
            this.dataGridViewExistingTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewExistingTimeslot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExistingTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingTimeslot.Location = new System.Drawing.Point(92, 182);
            this.dataGridViewExistingTimeslot.MultiSelect = false;
            this.dataGridViewExistingTimeslot.Name = "dataGridViewExistingTimeslot";
            this.dataGridViewExistingTimeslot.ReadOnly = true;
            this.dataGridViewExistingTimeslot.RowHeadersVisible = false;
            this.dataGridViewExistingTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistingTimeslot.Size = new System.Drawing.Size(645, 149);
            this.dataGridViewExistingTimeslot.TabIndex = 22;
            // 
            // labelWeeklyTimeslot
            // 
            this.labelWeeklyTimeslot.AutoSize = true;
            this.labelWeeklyTimeslot.Location = new System.Drawing.Point(89, 166);
            this.labelWeeklyTimeslot.Name = "labelWeeklyTimeslot";
            this.labelWeeklyTimeslot.Size = new System.Drawing.Size(90, 13);
            this.labelWeeklyTimeslot.TabIndex = 17;
            this.labelWeeklyTimeslot.Text = "Existing Timeslots";
            // 
            // dataGridViewWeeklyTimeslot
            // 
            this.dataGridViewWeeklyTimeslot.AllowUserToAddRows = false;
            this.dataGridViewWeeklyTimeslot.AllowUserToDeleteRows = false;
            this.dataGridViewWeeklyTimeslot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWeeklyTimeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeeklyTimeslot.Location = new System.Drawing.Point(92, 9);
            this.dataGridViewWeeklyTimeslot.MultiSelect = false;
            this.dataGridViewWeeklyTimeslot.Name = "dataGridViewWeeklyTimeslot";
            this.dataGridViewWeeklyTimeslot.ReadOnly = true;
            this.dataGridViewWeeklyTimeslot.RowHeadersVisible = false;
            this.dataGridViewWeeklyTimeslot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeeklyTimeslot.Size = new System.Drawing.Size(645, 151);
            this.dataGridViewWeeklyTimeslot.TabIndex = 15;
            // 
            // buttonWeeklyTimeslotEdit
            // 
            this.buttonWeeklyTimeslotEdit.Location = new System.Drawing.Point(6, 223);
            this.buttonWeeklyTimeslotEdit.Name = "buttonWeeklyTimeslotEdit";
            this.buttonWeeklyTimeslotEdit.Size = new System.Drawing.Size(71, 44);
            this.buttonWeeklyTimeslotEdit.TabIndex = 20;
            this.buttonWeeklyTimeslotEdit.Text = "Edit Timeslot";
            this.buttonWeeklyTimeslotEdit.UseVisualStyleBackColor = true;
            this.buttonWeeklyTimeslotEdit.Click += new System.EventHandler(this.buttonWeeklyTimeslotEdit_Click);
            // 
            // buttonAddExistingWeeklyTimeslot
            // 
            this.buttonAddExistingWeeklyTimeslot.Location = new System.Drawing.Point(6, 166);
            this.buttonAddExistingWeeklyTimeslot.Name = "buttonAddExistingWeeklyTimeslot";
            this.buttonAddExistingWeeklyTimeslot.Size = new System.Drawing.Size(71, 51);
            this.buttonAddExistingWeeklyTimeslot.TabIndex = 16;
            this.buttonAddExistingWeeklyTimeslot.Text = "Add Existing Timeslot";
            this.buttonAddExistingWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddExistingWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddExistingWeeklyTimeslot_Click);
            // 
            // buttonDeleteWeeklyTimeslot
            // 
            this.buttonDeleteWeeklyTimeslot.Enabled = false;
            this.buttonDeleteWeeklyTimeslot.Location = new System.Drawing.Point(6, 98);
            this.buttonDeleteWeeklyTimeslot.Name = "buttonDeleteWeeklyTimeslot";
            this.buttonDeleteWeeklyTimeslot.Size = new System.Drawing.Size(71, 62);
            this.buttonDeleteWeeklyTimeslot.TabIndex = 13;
            this.buttonDeleteWeeklyTimeslot.Text = "Remove from Schedule";
            this.buttonDeleteWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonDeleteWeeklyTimeslot.Click += new System.EventHandler(this.buttonDeleteWeeklyTimeslot_Click);
            // 
            // buttonAddWeeklyTimeslot
            // 
            this.buttonAddWeeklyTimeslot.Location = new System.Drawing.Point(6, 41);
            this.buttonAddWeeklyTimeslot.Name = "buttonAddWeeklyTimeslot";
            this.buttonAddWeeklyTimeslot.Size = new System.Drawing.Size(71, 51);
            this.buttonAddWeeklyTimeslot.TabIndex = 12;
            this.buttonAddWeeklyTimeslot.Text = "Add New Timeslot";
            this.buttonAddWeeklyTimeslot.UseVisualStyleBackColor = true;
            this.buttonAddWeeklyTimeslot.Click += new System.EventHandler(this.buttonAddWeeklyTimeslot_Click);
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.dataGridViewExistingEvent);
            this.groupBoxEvent.Controls.Add(this.buttonEventEdit);
            this.groupBoxEvent.Controls.Add(this.dataGridViewEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddExistingEvent);
            this.groupBoxEvent.Controls.Add(this.buttonAddEvent);
            this.groupBoxEvent.Controls.Add(this.buttondeleteEvent);
            this.groupBoxEvent.Location = new System.Drawing.Point(254, 340);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(743, 257);
            this.groupBoxEvent.TabIndex = 11;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Event";
            // 
            // dataGridViewExistingEvent
            // 
            this.dataGridViewExistingEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExistingEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExistingEvent.Location = new System.Drawing.Point(407, 14);
            this.dataGridViewExistingEvent.Name = "dataGridViewExistingEvent";
            this.dataGridViewExistingEvent.RowHeadersVisible = false;
            this.dataGridViewExistingEvent.Size = new System.Drawing.Size(330, 237);
            this.dataGridViewExistingEvent.TabIndex = 24;
            // 
            // buttonEventEdit
            // 
            this.buttonEventEdit.Location = new System.Drawing.Point(330, 213);
            this.buttonEventEdit.Name = "buttonEventEdit";
            this.buttonEventEdit.Size = new System.Drawing.Size(71, 38);
            this.buttonEventEdit.TabIndex = 23;
            this.buttonEventEdit.Text = "Edit Event";
            this.buttonEventEdit.UseVisualStyleBackColor = true;
            this.buttonEventEdit.Click += new System.EventHandler(this.buttonEventEdit_Click);
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AllowUserToAddRows = false;
            this.dataGridViewEvent.AllowUserToDeleteRows = false;
            this.dataGridViewEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.Location = new System.Drawing.Point(6, 14);
            this.dataGridViewEvent.MultiSelect = false;
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersVisible = false;
            this.dataGridViewEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvent.Size = new System.Drawing.Size(318, 237);
            this.dataGridViewEvent.TabIndex = 16;
            // 
            // buttonAddExistingEvent
            // 
            this.buttonAddExistingEvent.Location = new System.Drawing.Point(330, 141);
            this.buttonAddExistingEvent.Name = "buttonAddExistingEvent";
            this.buttonAddExistingEvent.Size = new System.Drawing.Size(71, 66);
            this.buttonAddExistingEvent.TabIndex = 20;
            this.buttonAddExistingEvent.Text = "Add Existing Event";
            this.buttonAddExistingEvent.UseVisualStyleBackColor = true;
            this.buttonAddExistingEvent.Click += new System.EventHandler(this.buttonAddExistingEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(330, 14);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(71, 51);
            this.buttonAddEvent.TabIndex = 17;
            this.buttonAddEvent.Text = "Add New Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttondeleteEvent
            // 
            this.buttondeleteEvent.Enabled = false;
            this.buttondeleteEvent.Location = new System.Drawing.Point(330, 71);
            this.buttondeleteEvent.Name = "buttondeleteEvent";
            this.buttondeleteEvent.Size = new System.Drawing.Size(71, 64);
            this.buttondeleteEvent.TabIndex = 18;
            this.buttondeleteEvent.Text = "Remove Event from Schedule";
            this.buttondeleteEvent.UseVisualStyleBackColor = true;
            this.buttondeleteEvent.Click += new System.EventHandler(this.buttondeleteEvent_Click);
            // 
            // panelistTreeView
            // 
            this.panelistTreeView.Location = new System.Drawing.Point(3, 36);
            this.panelistTreeView.Name = "panelistTreeView";
            this.panelistTreeView.Size = new System.Drawing.Size(245, 561);
            this.panelistTreeView.TabIndex = 7;
            this.panelistTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.panelistTreeView_NodeMouseClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingTimeslot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeklyTimeslot)).EndInit();
            this.groupBoxEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistingEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TreeView studentTreeView;
        private System.Windows.Forms.Button btnSwitchView;
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
    }
}
