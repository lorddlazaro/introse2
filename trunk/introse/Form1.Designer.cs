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
            this.scheduleDefense = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.thesisGroupControl = new System.Windows.Forms.TabPage();
            this.freeTimeViewer1 = new CustomUserControl.FreeTimeViewer();
            this.thesisGroupControl1 = new CustomUserControl.ThesisGroupControl();
            this.scheduleDefense.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.thesisGroupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleDefense
            // 
            this.scheduleDefense.Controls.Add(this.freeTimeViewer1);
            this.scheduleDefense.Location = new System.Drawing.Point(4, 22);
            this.scheduleDefense.Name = "scheduleDefense";
            this.scheduleDefense.Size = new System.Drawing.Size(999, 679);
            this.scheduleDefense.TabIndex = 4;
            this.scheduleDefense.Text = "Schedule Defenses";
            this.scheduleDefense.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scheduleDefense);
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
            // freeTimeViewer1
            // 
            this.freeTimeViewer1.Location = new System.Drawing.Point(3, 22);
            this.freeTimeViewer1.Name = "freeTimeViewer1";
            this.freeTimeViewer1.Size = new System.Drawing.Size(1000, 600);
            this.freeTimeViewer1.TabIndex = 0;
            // 
            // thesisGroupControl1
            // 
            this.thesisGroupControl1.Location = new System.Drawing.Point(-4, -1);
            this.thesisGroupControl1.Name = "thesisGroupControl1";
            this.thesisGroupControl1.Size = new System.Drawing.Size(1000, 680);
            this.thesisGroupControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 706);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.scheduleDefense.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.thesisGroupControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUserControl.ScheduleEditor scheduleEditor1;
        private System.Windows.Forms.TabPage scheduleDefense;
        private CustomUserControl.FreeTimeViewer freeTimeViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage thesisGroupControl;
        private CustomUserControl.ThesisGroupControl thesisGroupControl1;


    }
}

