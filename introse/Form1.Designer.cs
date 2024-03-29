﻿namespace introse
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
            this.thesisGroupControl = new System.Windows.Forms.TabPage();
            this.thesisGroupControl1 = new CustomUserControl.ThesisGroupControl();
            this.freeTimeViewer1 = new CustomUserControl.FreeTimeViewer();
            this.freeTimeViewerControl = new System.Windows.Forms.TabPage();
            this.defSchedViewerControl = new System.Windows.Forms.TabPage();
            this.scheduleEditorControl = new System.Windows.Forms.TabPage();
            this.freeTimeViewer2 = new CustomUserControl.FreeTimeViewer();
            this.defenseSchedulesViewercs1 = new CustomUserControl.DefenseSchedulesViewercs();
            this.scheduleEditor2 = new CustomUserControl.ScheduleEditor();
            this.tabControl1.SuspendLayout();
            this.thesisGroupControl.SuspendLayout();
            this.freeTimeViewerControl.SuspendLayout();
            this.defSchedViewerControl.SuspendLayout();
            this.scheduleEditorControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.freeTimeViewerControl);
            this.tabControl1.Controls.Add(this.defSchedViewerControl);
            this.tabControl1.Controls.Add(this.scheduleEditorControl);
            this.tabControl1.Controls.Add(this.thesisGroupControl);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 705);
            this.tabControl1.TabIndex = 0;
            // 
            // thesisGroupControl
            // 
            this.thesisGroupControl.Controls.Add(this.thesisGroupControl1);
            this.thesisGroupControl.Location = new System.Drawing.Point(4, 22);
            this.thesisGroupControl.Name = "thesisGroupControl";
            this.thesisGroupControl.Size = new System.Drawing.Size(999, 679);
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
            // freeTimeViewer1
            // 
            this.freeTimeViewer1.Location = new System.Drawing.Point(3, 22);
            this.freeTimeViewer1.Name = "freeTimeViewer1";
            this.freeTimeViewer1.Size = new System.Drawing.Size(1000, 600);
            this.freeTimeViewer1.TabIndex = 0;
            // 
            // freeTimeViewerControl
            // 
            this.freeTimeViewerControl.Controls.Add(this.freeTimeViewer2);
            this.freeTimeViewerControl.Location = new System.Drawing.Point(4, 22);
            this.freeTimeViewerControl.Name = "freeTimeViewerControl";
            this.freeTimeViewerControl.Size = new System.Drawing.Size(999, 679);
            this.freeTimeViewerControl.TabIndex = 6;
            this.freeTimeViewerControl.Text = "Schedule Defenses";
            this.freeTimeViewerControl.UseVisualStyleBackColor = true;
            // 
            // defSchedViewerControl
            // 
            this.defSchedViewerControl.Controls.Add(this.defenseSchedulesViewercs1);
            this.defSchedViewerControl.Location = new System.Drawing.Point(4, 22);
            this.defSchedViewerControl.Name = "defSchedViewerControl";
            this.defSchedViewerControl.Size = new System.Drawing.Size(999, 679);
            this.defSchedViewerControl.TabIndex = 7;
            this.defSchedViewerControl.Text = "View Defense Schedules";
            this.defSchedViewerControl.UseVisualStyleBackColor = true;
            // 
            // scheduleEditorControl
            // 
            this.scheduleEditorControl.Controls.Add(this.scheduleEditor2);
            this.scheduleEditorControl.Location = new System.Drawing.Point(4, 22);
            this.scheduleEditorControl.Name = "scheduleEditorControl";
            this.scheduleEditorControl.Size = new System.Drawing.Size(999, 679);
            this.scheduleEditorControl.TabIndex = 8;
            this.scheduleEditorControl.Text = "View Class Schedules";
            this.scheduleEditorControl.UseVisualStyleBackColor = true;
            // 
            // freeTimeViewer2
            // 
            this.freeTimeViewer2.Location = new System.Drawing.Point(3, 52);
            this.freeTimeViewer2.Name = "freeTimeViewer2";
            this.freeTimeViewer2.Size = new System.Drawing.Size(1000, 600);
            this.freeTimeViewer2.TabIndex = 0;
            // 
            // defenseSchedulesViewercs1
            // 
            this.defenseSchedulesViewercs1.Location = new System.Drawing.Point(29, 26);
            this.defenseSchedulesViewercs1.Name = "defenseSchedulesViewercs1";
            this.defenseSchedulesViewercs1.Size = new System.Drawing.Size(940, 645);
            this.defenseSchedulesViewercs1.TabIndex = 0;
            // 
            // scheduleEditor2
            // 
            this.scheduleEditor2.Location = new System.Drawing.Point(0, 49);
            this.scheduleEditor2.Name = "scheduleEditor2";
            this.scheduleEditor2.Size = new System.Drawing.Size(1000, 600);
            this.scheduleEditor2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 706);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.thesisGroupControl.ResumeLayout(false);
            this.freeTimeViewerControl.ResumeLayout(false);
            this.defSchedViewerControl.ResumeLayout(false);
            this.scheduleEditorControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUserControl.ScheduleEditor scheduleEditor1;
        private System.Windows.Forms.TabPage scheduleDefense;
        private CustomUserControl.FreeTimeViewer freeTimeViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage thesisGroupControl;
        private CustomUserControl.ThesisGroupControl thesisGroupControl1;
        private System.Windows.Forms.TabPage freeTimeViewerControl;
        private CustomUserControl.FreeTimeViewer freeTimeViewer2;
        private System.Windows.Forms.TabPage defSchedViewerControl;
        private CustomUserControl.DefenseSchedulesViewercs defenseSchedulesViewercs1;
        private System.Windows.Forms.TabPage scheduleEditorControl;
        private CustomUserControl.ScheduleEditor scheduleEditor2;


    }
}

