namespace introse
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.freeTimeViewerControl = new System.Windows.Forms.TabPage();
            this.freeTimeViewer = new CustomUserControl.FreeTimeViewer();
            this.scheduleEditorControl = new System.Windows.Forms.TabPage();
            this.scheduleEditor2 = new CustomUserControl.ScheduleEditor();
            this.thesisGroupControl = new System.Windows.Forms.TabPage();
            this.thesisGroupControl1 = new CustomUserControl.ThesisGroupControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDefenseSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.freeTimeViewerControl.SuspendLayout();
            this.scheduleEditorControl.SuspendLayout();
            this.thesisGroupControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.freeTimeViewerControl);
            this.tabControl1.Controls.Add(this.scheduleEditorControl);
            this.tabControl1.Controls.Add(this.thesisGroupControl);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(1, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 682);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // freeTimeViewerControl
            // 
            this.freeTimeViewerControl.Controls.Add(this.freeTimeViewer);
            this.freeTimeViewerControl.Location = new System.Drawing.Point(4, 22);
            this.freeTimeViewerControl.Name = "freeTimeViewerControl";
            this.freeTimeViewerControl.Size = new System.Drawing.Size(999, 656);
            this.freeTimeViewerControl.TabIndex = 6;
            this.freeTimeViewerControl.Text = "Schedule Defenses";
            this.freeTimeViewerControl.UseVisualStyleBackColor = true;
            // 
            // freeTimeViewer
            // 
            this.freeTimeViewer.BackColor = System.Drawing.SystemColors.Window;
            this.freeTimeViewer.Location = new System.Drawing.Point(21, 16);
            this.freeTimeViewer.Name = "freeTimeViewer";
            this.freeTimeViewer.Size = new System.Drawing.Size(970, 637);
            this.freeTimeViewer.TabIndex = 0;
            // 
            // scheduleEditorControl
            // 
            this.scheduleEditorControl.Controls.Add(this.scheduleEditor2);
            this.scheduleEditorControl.Location = new System.Drawing.Point(4, 22);
            this.scheduleEditorControl.Name = "scheduleEditorControl";
            this.scheduleEditorControl.Size = new System.Drawing.Size(999, 656);
            this.scheduleEditorControl.TabIndex = 8;
            this.scheduleEditorControl.Text = "View Class Schedules";
            this.scheduleEditorControl.UseVisualStyleBackColor = true;
            // 
            // scheduleEditor2
            // 
            this.scheduleEditor2.Location = new System.Drawing.Point(-1, 0);
            this.scheduleEditor2.Name = "scheduleEditor2";
            this.scheduleEditor2.Size = new System.Drawing.Size(1000, 679);
            this.scheduleEditor2.TabIndex = 0;
            // 
            // thesisGroupControl
            // 
            this.thesisGroupControl.Controls.Add(this.thesisGroupControl1);
            this.thesisGroupControl.Location = new System.Drawing.Point(4, 22);
            this.thesisGroupControl.Name = "thesisGroupControl";
            this.thesisGroupControl.Size = new System.Drawing.Size(999, 656);
            this.thesisGroupControl.TabIndex = 5;
            this.thesisGroupControl.Text = "Thesis Groups";
            this.thesisGroupControl.UseVisualStyleBackColor = true;
            // 
            // thesisGroupControl1
            // 
            this.thesisGroupControl1.Location = new System.Drawing.Point(-4, -1);
            this.thesisGroupControl1.Name = "thesisGroupControl1";
            this.thesisGroupControl1.Size = new System.Drawing.Size(1000, 680);
            this.thesisGroupControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(43, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.viewDefenseSchedulesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // viewDefenseSchedulesToolStripMenuItem
            // 
            this.viewDefenseSchedulesToolStripMenuItem.Name = "viewDefenseSchedulesToolStripMenuItem";
            this.viewDefenseSchedulesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.viewDefenseSchedulesToolStripMenuItem.Text = "View Defense Schedules";
            this.viewDefenseSchedulesToolStripMenuItem.Click += new System.EventHandler(this.viewDefenseSchedulesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 706);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thesis Scheduling Aid";
            this.tabControl1.ResumeLayout(false);
            this.freeTimeViewerControl.ResumeLayout(false);
            this.scheduleEditorControl.ResumeLayout(false);
            this.thesisGroupControl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUserControl.ScheduleEditor scheduleEditor1;
        private System.Windows.Forms.TabPage scheduleDefense;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage thesisGroupControl;
        private CustomUserControl.ThesisGroupControl thesisGroupControl1;
        private System.Windows.Forms.TabPage scheduleEditorControl;
        private CustomUserControl.ScheduleEditor scheduleEditor2;
        private System.Windows.Forms.TabPage freeTimeViewerControl;
        private CustomUserControl.FreeTimeViewer freeTimeViewer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDefenseSchedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;


    }
}

