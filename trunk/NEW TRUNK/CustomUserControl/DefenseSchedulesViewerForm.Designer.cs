namespace CustomUserControl
{
    partial class DefenseSchedulesViewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefenseSchedulesViewerForm));
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridViewDefSchedInfo = new System.Windows.Forms.DataGridView();
            this.columnCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAdvisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPanels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxIncludeTHSST1 = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeTHSST3 = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelNoSchedulesFound = new System.Windows.Forms.Label();
            this.labelInclude = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefSchedInfo)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "MMM d, yyyy (ddd)";
            this.dateTimePickerEndDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(173, 37);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(152, 23);
            this.dateTimePickerEndDate.TabIndex = 10;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "MMM d, yyyy (ddd)";
            this.dateTimePickerStartDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(16, 37);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(151, 23);
            this.dateTimePickerStartDate.TabIndex = 8;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(43, 8);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(163, 26);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh Table";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridViewDefSchedInfo
            // 
            this.dataGridViewDefSchedInfo.AllowUserToAddRows = false;
            this.dataGridViewDefSchedInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewDefSchedInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewDefSchedInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDefSchedInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDefSchedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDefSchedInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCourse,
            this.columnTitle,
            this.columnDate,
            this.columnTime,
            this.columnVenue,
            this.columnAdvisor,
            this.columnPanels});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDefSchedInfo.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewDefSchedInfo.Location = new System.Drawing.Point(2, 74);
            this.dataGridViewDefSchedInfo.Name = "dataGridViewDefSchedInfo";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDefSchedInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewDefSchedInfo.Size = new System.Drawing.Size(934, 456);
            this.dataGridViewDefSchedInfo.TabIndex = 12;
            // 
            // columnCourse
            // 
            this.columnCourse.HeaderText = "Course";
            this.columnCourse.Name = "columnCourse";
            this.columnCourse.ReadOnly = true;
            this.columnCourse.Width = 60;
            // 
            // columnTitle
            // 
            this.columnTitle.HeaderText = "Title";
            this.columnTitle.Name = "columnTitle";
            this.columnTitle.ReadOnly = true;
            this.columnTitle.Width = 300;
            // 
            // columnDate
            // 
            this.columnDate.HeaderText = "Date";
            this.columnDate.Name = "columnDate";
            this.columnDate.ReadOnly = true;
            this.columnDate.Width = 70;
            // 
            // columnTime
            // 
            this.columnTime.HeaderText = "Time";
            this.columnTime.Name = "columnTime";
            this.columnTime.ReadOnly = true;
            this.columnTime.Width = 90;
            // 
            // columnVenue
            // 
            this.columnVenue.HeaderText = "Venue";
            this.columnVenue.Name = "columnVenue";
            this.columnVenue.ReadOnly = true;
            this.columnVenue.Width = 70;
            // 
            // columnAdvisor
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnAdvisor.DefaultCellStyle = dataGridViewCellStyle9;
            this.columnAdvisor.HeaderText = "Advisor";
            this.columnAdvisor.Name = "columnAdvisor";
            this.columnAdvisor.ReadOnly = true;
            this.columnAdvisor.Width = 150;
            // 
            // columnPanels
            // 
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnPanels.DefaultCellStyle = dataGridViewCellStyle10;
            this.columnPanels.HeaderText = "Panelists";
            this.columnPanels.Name = "columnPanels";
            this.columnPanels.ReadOnly = true;
            this.columnPanels.Width = 150;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "DefenseSchedules";
            this.saveFileDialog.Filter = resources.GetString("saveFileDialog.Filter");
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(43, 40);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(163, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save Table Content";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxIncludeTHSST1
            // 
            this.checkBoxIncludeTHSST1.AutoSize = true;
            this.checkBoxIncludeTHSST1.Checked = true;
            this.checkBoxIncludeTHSST1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeTHSST1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeTHSST1.Location = new System.Drawing.Point(483, 40);
            this.checkBoxIncludeTHSST1.Name = "checkBoxIncludeTHSST1";
            this.checkBoxIncludeTHSST1.Size = new System.Drawing.Size(68, 19);
            this.checkBoxIncludeTHSST1.TabIndex = 14;
            this.checkBoxIncludeTHSST1.Text = "THSST-1";
            this.checkBoxIncludeTHSST1.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeTHSST3
            // 
            this.checkBoxIncludeTHSST3.AutoSize = true;
            this.checkBoxIncludeTHSST3.Checked = true;
            this.checkBoxIncludeTHSST3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeTHSST3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeTHSST3.Location = new System.Drawing.Point(570, 40);
            this.checkBoxIncludeTHSST3.Name = "checkBoxIncludeTHSST3";
            this.checkBoxIncludeTHSST3.Size = new System.Drawing.Size(68, 19);
            this.checkBoxIncludeTHSST3.TabIndex = 15;
            this.checkBoxIncludeTHSST3.Text = "THSST-3";
            this.checkBoxIncludeTHSST3.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelNoSchedulesFound);
            this.groupBoxSettings.Controls.Add(this.labelInclude);
            this.groupBoxSettings.Controls.Add(this.labelEndDate);
            this.groupBoxSettings.Controls.Add(this.labelStartDate);
            this.groupBoxSettings.Controls.Add(this.dateTimePickerStartDate);
            this.groupBoxSettings.Controls.Add(this.checkBoxIncludeTHSST3);
            this.groupBoxSettings.Controls.Add(this.dateTimePickerEndDate);
            this.groupBoxSettings.Controls.Add(this.checkBoxIncludeTHSST1);
            this.groupBoxSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSettings.Location = new System.Drawing.Point(241, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(656, 68);
            this.groupBoxSettings.TabIndex = 16;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelNoSchedulesFound
            // 
            this.labelNoSchedulesFound.AutoSize = true;
            this.labelNoSchedulesFound.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoSchedulesFound.ForeColor = System.Drawing.Color.Firebrick;
            this.labelNoSchedulesFound.Location = new System.Drawing.Point(331, 37);
            this.labelNoSchedulesFound.Name = "labelNoSchedulesFound";
            this.labelNoSchedulesFound.Size = new System.Drawing.Size(146, 19);
            this.labelNoSchedulesFound.TabIndex = 19;
            this.labelNoSchedulesFound.Text = "No Schedules found";
            this.labelNoSchedulesFound.Visible = false;
            // 
            // labelInclude
            // 
            this.labelInclude.AutoSize = true;
            this.labelInclude.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInclude.Location = new System.Drawing.Point(480, 20);
            this.labelInclude.Name = "labelInclude";
            this.labelInclude.Size = new System.Drawing.Size(57, 15);
            this.labelInclude.TabIndex = 18;
            this.labelInclude.Text = "Includes:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(170, 20);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(58, 15);
            this.labelEndDate.TabIndex = 17;
            this.labelEndDate.Text = "End Date:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(13, 20);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(64, 15);
            this.labelStartDate.TabIndex = 16;
            this.labelStartDate.Text = "Start Date:";
            // 
            // DefenseSchedulesViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 531);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewDefSchedInfo);
            this.Controls.Add(this.buttonRefresh);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefenseSchedulesViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defense Schedule Viewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DefenseSchedulesViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefSchedInfo)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridViewDefSchedInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxIncludeTHSST1;
        private System.Windows.Forms.CheckBox checkBoxIncludeTHSST3;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelInclude;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelNoSchedulesFound;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAdvisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPanels;
    }
}
