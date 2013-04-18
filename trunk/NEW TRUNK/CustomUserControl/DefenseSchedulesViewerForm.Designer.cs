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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefenseSchedulesViewerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewDefSchedInfo = new System.Windows.Forms.DataGridView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxTHSST1 = new System.Windows.Forms.CheckBox();
            this.checkBoxTHSST3 = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxRedefense = new System.Windows.Forms.CheckBox();
            this.checkBoxDefense = new System.Windows.Forms.CheckBox();
            this.labelNotice = new System.Windows.Forms.Label();
            this.columnCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAdvisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPanels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefSchedInfo)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDefSchedInfo
            // 
            this.dataGridViewDefSchedInfo.AllowUserToAddRows = false;
            this.dataGridViewDefSchedInfo.AllowUserToDeleteRows = false;
            this.dataGridViewDefSchedInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDefSchedInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDefSchedInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDefSchedInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDefSchedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDefSchedInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCourse,
            this.columnTitle,
            this.columnDate,
            this.columnTime,
            this.columnVenue,
            this.columnAdvisor,
            this.columnPanels,
            this.ColumnType});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDefSchedInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDefSchedInfo.Location = new System.Drawing.Point(2, 56);
            this.dataGridViewDefSchedInfo.Name = "dataGridViewDefSchedInfo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDefSchedInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDefSchedInfo.Size = new System.Drawing.Size(934, 474);
            this.dataGridViewDefSchedInfo.TabIndex = 12;
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
            this.buttonSave.Location = new System.Drawing.Point(43, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(163, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxTHSST1
            // 
            this.checkBoxTHSST1.AutoSize = true;
            this.checkBoxTHSST1.Checked = true;
            this.checkBoxTHSST1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTHSST1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTHSST1.Location = new System.Drawing.Point(268, 22);
            this.checkBoxTHSST1.Name = "checkBoxTHSST1";
            this.checkBoxTHSST1.Size = new System.Drawing.Size(68, 19);
            this.checkBoxTHSST1.TabIndex = 14;
            this.checkBoxTHSST1.Text = "THSST-1";
            this.checkBoxTHSST1.UseVisualStyleBackColor = true;
            this.checkBoxTHSST1.CheckStateChanged += new System.EventHandler(this.DefenseSchedulesViewerForm_Load);
            // 
            // checkBoxTHSST3
            // 
            this.checkBoxTHSST3.AutoSize = true;
            this.checkBoxTHSST3.Checked = true;
            this.checkBoxTHSST3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTHSST3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTHSST3.Location = new System.Drawing.Point(351, 22);
            this.checkBoxTHSST3.Name = "checkBoxTHSST3";
            this.checkBoxTHSST3.Size = new System.Drawing.Size(68, 19);
            this.checkBoxTHSST3.TabIndex = 15;
            this.checkBoxTHSST3.Text = "THSST-3";
            this.checkBoxTHSST3.UseVisualStyleBackColor = true;
            this.checkBoxTHSST3.CheckStateChanged += new System.EventHandler(this.DefenseSchedulesViewerForm_Load);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxRedefense);
            this.groupBoxSettings.Controls.Add(this.checkBoxDefense);
            this.groupBoxSettings.Controls.Add(this.checkBoxTHSST3);
            this.groupBoxSettings.Controls.Add(this.checkBoxTHSST1);
            this.groupBoxSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSettings.Location = new System.Drawing.Point(255, 1);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(467, 49);
            this.groupBoxSettings.TabIndex = 16;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Include";
            // 
            // checkBoxRedefense
            // 
            this.checkBoxRedefense.AutoSize = true;
            this.checkBoxRedefense.Checked = true;
            this.checkBoxRedefense.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRedefense.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRedefense.Location = new System.Drawing.Point(138, 22);
            this.checkBoxRedefense.Name = "checkBoxRedefense";
            this.checkBoxRedefense.Size = new System.Drawing.Size(81, 19);
            this.checkBoxRedefense.TabIndex = 20;
            this.checkBoxRedefense.Text = "Redefense";
            this.checkBoxRedefense.UseVisualStyleBackColor = true;
            this.checkBoxRedefense.CheckStateChanged += new System.EventHandler(this.DefenseSchedulesViewerForm_Load);
            // 
            // checkBoxDefense
            // 
            this.checkBoxDefense.AutoSize = true;
            this.checkBoxDefense.Checked = true;
            this.checkBoxDefense.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDefense.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDefense.Location = new System.Drawing.Point(55, 22);
            this.checkBoxDefense.Name = "checkBoxDefense";
            this.checkBoxDefense.Size = new System.Drawing.Size(69, 19);
            this.checkBoxDefense.TabIndex = 19;
            this.checkBoxDefense.Text = "Defense";
            this.checkBoxDefense.UseVisualStyleBackColor = true;
            this.checkBoxDefense.CheckStateChanged += new System.EventHandler(this.DefenseSchedulesViewerForm_Load);
            // 
            // labelNotice
            // 
            this.labelNotice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.labelNotice.Location = new System.Drawing.Point(728, 20);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(208, 19);
            this.labelNotice.TabIndex = 19;
            this.labelNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnCourse
            // 
            this.columnCourse.HeaderText = "Course";
            this.columnCourse.MinimumWidth = 60;
            this.columnCourse.Name = "columnCourse";
            this.columnCourse.ReadOnly = true;
            this.columnCourse.Width = 60;
            // 
            // columnTitle
            // 
            this.columnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnTitle.HeaderText = "Title";
            this.columnTitle.MinimumWidth = 235;
            this.columnTitle.Name = "columnTitle";
            this.columnTitle.ReadOnly = true;
            this.columnTitle.Width = 235;
            // 
            // columnDate
            // 
            this.columnDate.HeaderText = "Date";
            this.columnDate.MinimumWidth = 75;
            this.columnDate.Name = "columnDate";
            this.columnDate.ReadOnly = true;
            this.columnDate.Width = 75;
            // 
            // columnTime
            // 
            this.columnTime.HeaderText = "Time";
            this.columnTime.MinimumWidth = 75;
            this.columnTime.Name = "columnTime";
            this.columnTime.ReadOnly = true;
            this.columnTime.Width = 75;
            // 
            // columnVenue
            // 
            this.columnVenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnVenue.HeaderText = "Venue";
            this.columnVenue.MinimumWidth = 50;
            this.columnVenue.Name = "columnVenue";
            this.columnVenue.ReadOnly = true;
            this.columnVenue.Width = 64;
            // 
            // columnAdvisor
            // 
            this.columnAdvisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnAdvisor.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnAdvisor.HeaderText = "Advisor";
            this.columnAdvisor.MinimumWidth = 150;
            this.columnAdvisor.Name = "columnAdvisor";
            this.columnAdvisor.ReadOnly = true;
            this.columnAdvisor.Width = 150;
            // 
            // columnPanels
            // 
            this.columnPanels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnPanels.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnPanels.HeaderText = "Panelists";
            this.columnPanels.MinimumWidth = 150;
            this.columnPanels.Name = "columnPanels";
            this.columnPanels.ReadOnly = true;
            this.columnPanels.Width = 150;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.MinimumWidth = 80;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 80;
            // 
            // DefenseSchedulesViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 531);
            this.Controls.Add(this.labelNotice);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewDefSchedInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefenseSchedulesViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defense Schedule Viewer";
            this.Load += new System.EventHandler(this.DefenseSchedulesViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefSchedInfo)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridViewDefSchedInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxTHSST1;
        private System.Windows.Forms.CheckBox checkBoxTHSST3;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.CheckBox checkBoxRedefense;
        private System.Windows.Forms.CheckBox checkBoxDefense;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAdvisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPanels;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
    }
}
