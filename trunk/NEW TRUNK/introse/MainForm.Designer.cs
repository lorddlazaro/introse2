using System.Windows.Forms;

namespace introse
{
    partial class MainForm
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

        // Reduce Flicker
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageScheduleDefenses = new System.Windows.Forms.TabPage();
            this.freeTimeViewerControl = new CustomUserControl.FreeTimeViewer();
            this.tabPageClassSchedulesAndEvents = new System.Windows.Forms.TabPage();
            this.scheduleEditorControl = new CustomUserControl.ScheduleEditor();
            this.tabPageThesisGroups = new System.Windows.Forms.TabPage();
            this.customUserControl_ThesisGroupControl = new CustomUserControl.ThesisGroupControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewDefenseSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageScheduleDefenses.SuspendLayout();
            this.tabPageClassSchedulesAndEvents.SuspendLayout();
            this.tabPageThesisGroups.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageScheduleDefenses);
            this.tabControl.Controls.Add(this.tabPageClassSchedulesAndEvents);
            this.tabControl.Controls.Add(this.tabPageThesisGroups);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(1, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1007, 682);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageScheduleDefenses
            // 
            this.tabPageScheduleDefenses.Controls.Add(this.freeTimeViewerControl);
            this.tabPageScheduleDefenses.Location = new System.Drawing.Point(4, 22);
            this.tabPageScheduleDefenses.Name = "tabPageScheduleDefenses";
            this.tabPageScheduleDefenses.Size = new System.Drawing.Size(999, 656);
            this.tabPageScheduleDefenses.TabIndex = 6;
            this.tabPageScheduleDefenses.Text = "Schedule Defenses";
            this.tabPageScheduleDefenses.UseVisualStyleBackColor = true;
            // 
            // freeTimeViewerControl
            // 
            this.freeTimeViewerControl.BackColor = System.Drawing.SystemColors.Window;
            this.freeTimeViewerControl.Location = new System.Drawing.Point(21, 16);
            this.freeTimeViewerControl.Name = "freeTimeViewerControl";
            this.freeTimeViewerControl.Size = new System.Drawing.Size(970, 637);
            this.freeTimeViewerControl.TabIndex = 0;
            // 
            // tabPageClassSchedulesAndEvents
            // 
            this.tabPageClassSchedulesAndEvents.Controls.Add(this.scheduleEditorControl);
            this.tabPageClassSchedulesAndEvents.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassSchedulesAndEvents.Name = "tabPageClassSchedulesAndEvents";
            this.tabPageClassSchedulesAndEvents.Size = new System.Drawing.Size(999, 656);
            this.tabPageClassSchedulesAndEvents.TabIndex = 8;
            this.tabPageClassSchedulesAndEvents.Text = "Class Schedules and Events";
            this.tabPageClassSchedulesAndEvents.UseVisualStyleBackColor = true;
            // 
            // scheduleEditorControl
            // 
            this.scheduleEditorControl.Location = new System.Drawing.Point(-1, 0);
            this.scheduleEditorControl.Name = "scheduleEditorControl";
            this.scheduleEditorControl.Size = new System.Drawing.Size(1000, 679);
            this.scheduleEditorControl.TabIndex = 0;
            // 
            // tabPageThesisGroups
            // 
            this.tabPageThesisGroups.Controls.Add(this.customUserControl_ThesisGroupControl);
            this.tabPageThesisGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageThesisGroups.Name = "tabPageThesisGroups";
            this.tabPageThesisGroups.Size = new System.Drawing.Size(999, 656);
            this.tabPageThesisGroups.TabIndex = 5;
            this.tabPageThesisGroups.Text = "Thesis Groups";
            this.tabPageThesisGroups.UseVisualStyleBackColor = true;
            // 
            // customUserControl_ThesisGroupControl
            // 
            this.customUserControl_ThesisGroupControl.Location = new System.Drawing.Point(-4, -1);
            this.customUserControl_ThesisGroupControl.Name = "customUserControl_ThesisGroupControl";
            this.customUserControl_ThesisGroupControl.Size = new System.Drawing.Size(1000, 680);
            this.customUserControl_ThesisGroupControl.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(43, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Reset,
            this.toolStripMenuItem_ViewDefenseSchedules,
            this.toolStripMenuItem_Exit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem_File.Text = "File";
            // 
            // toolStripMenuItem_Reset
            // 
            this.toolStripMenuItem_Reset.Name = "toolStripMenuItem_Reset";
            this.toolStripMenuItem_Reset.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem_Reset.Text = "Reset Wizard";
            this.toolStripMenuItem_Reset.Click += new System.EventHandler(this.toolStripMenuItem_Reset_Click);
            // 
            // toolStripMenuItem_ViewDefenseSchedules
            // 
            this.toolStripMenuItem_ViewDefenseSchedules.Name = "toolStripMenuItem_ViewDefenseSchedules";
            this.toolStripMenuItem_ViewDefenseSchedules.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem_ViewDefenseSchedules.Text = "Summary of Defense Schedules";
            this.toolStripMenuItem_ViewDefenseSchedules.Click += new System.EventHandler(this.toolStripMenuItem_ViewDefenseSchedules_Click);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem_Exit.Text = "Exit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 706);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thesis Defense Scheduling Aid";
            this.tabControl.ResumeLayout(false);
            this.tabPageScheduleDefenses.ResumeLayout(false);
            this.tabPageClassSchedulesAndEvents.ResumeLayout(false);
            this.tabPageThesisGroups.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageScheduleDefenses;
        private System.Windows.Forms.TabPage tabPageClassSchedulesAndEvents;
        private System.Windows.Forms.TabPage tabPageThesisGroups;
        private CustomUserControl.FreeTimeViewer freeTimeViewerControl;
        private CustomUserControl.ThesisGroupControl customUserControl_ThesisGroupControl;
        private CustomUserControl.ScheduleEditor scheduleEditorControl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Reset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ViewDefenseSchedules;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
    }
}

