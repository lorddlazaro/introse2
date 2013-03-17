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
            this.rtBoxClassScheds = new System.Windows.Forms.RichTextBox();
            this.rtBoxEvents = new System.Windows.Forms.RichTextBox();
            this.personLabel = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.studentTreeView = new System.Windows.Forms.TreeView();
            this.panelistTreeView = new System.Windows.Forms.TreeView();
            this.btnSwitchView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtBoxClassScheds
            // 
            this.rtBoxClassScheds.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtBoxClassScheds.Location = new System.Drawing.Point(254, 58);
            this.rtBoxClassScheds.Name = "rtBoxClassScheds";
            this.rtBoxClassScheds.ReadOnly = true;
            this.rtBoxClassScheds.Size = new System.Drawing.Size(371, 528);
            this.rtBoxClassScheds.TabIndex = 2;
            this.rtBoxClassScheds.Text = "";
            // 
            // rtBoxEvents
            // 
            this.rtBoxEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtBoxEvents.Location = new System.Drawing.Point(631, 58);
            this.rtBoxEvents.Name = "rtBoxEvents";
            this.rtBoxEvents.ReadOnly = true;
            this.rtBoxEvents.Size = new System.Drawing.Size(366, 528);
            this.rtBoxEvents.TabIndex = 3;
            this.rtBoxEvents.Text = "";
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Location = new System.Drawing.Point(10, 39);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(52, 13);
            this.personLabel.TabIndex = 4;
            this.personLabel.Text = "Students:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(407, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
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
            this.panelistTreeView.Location = new System.Drawing.Point(13, 58);
            this.panelistTreeView.Name = "panelistTreeView";
            this.panelistTreeView.Size = new System.Drawing.Size(235, 528);
            this.panelistTreeView.TabIndex = 7;
            this.panelistTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.panelistTreeView_NodeMouseClick);
            // 
            // btnSwitchView
            // 
            this.btnSwitchView.Location = new System.Drawing.Point(68, 33);
            this.btnSwitchView.Name = "btnSwitchView";
            this.btnSwitchView.Size = new System.Drawing.Size(131, 23);
            this.btnSwitchView.TabIndex = 8;
            this.btnSwitchView.Text = "Switch to Panelists";
            this.btnSwitchView.UseVisualStyleBackColor = true;
            this.btnSwitchView.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // ScheduleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSwitchView);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.personLabel);
            this.Controls.Add(this.rtBoxEvents);
            this.Controls.Add(this.rtBoxClassScheds);
            this.Controls.Add(this.panelistTreeView);
            this.Controls.Add(this.studentTreeView);
            this.Name = "ScheduleEditor";
            this.Size = new System.Drawing.Size(1000, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtBoxClassScheds;
        private System.Windows.Forms.RichTextBox rtBoxEvents;
        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TreeView studentTreeView;
        private System.Windows.Forms.TreeView panelistTreeView;
        private System.Windows.Forms.Button btnSwitchView;
    }
}
