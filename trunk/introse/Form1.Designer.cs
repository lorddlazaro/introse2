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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.freeTimeViewer1 = new CustomUserControl.FreeTimeViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.freeTimeViewer1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(999, 679);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "DefScheds v2";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // freeTimeViewer1
            // 
            this.freeTimeViewer1.Location = new System.Drawing.Point(3, 22);
            this.freeTimeViewer1.Name = "freeTimeViewer1";
            this.freeTimeViewer1.Size = new System.Drawing.Size(1000, 600);
            this.freeTimeViewer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 705);
            this.tabControl1.TabIndex = 0;
      
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 706);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUserControl.ScheduleEditor scheduleEditor1;
        private System.Windows.Forms.TabPage tabPage5;
        private CustomUserControl.FreeTimeViewer freeTimeViewer1;
        private System.Windows.Forms.TabControl tabControl1;


    }
}

