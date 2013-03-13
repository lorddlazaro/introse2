namespace CustomUserControl
{
    partial class FreeTimeViewer
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
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.treeViewClusters = new System.Windows.Forms.TreeView();
            this.comboBoxView = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelDate1 = new System.Windows.Forms.Label();
            this.labelDate2 = new System.Windows.Forms.Label();
            this.labelDate3 = new System.Windows.Forms.Label();
            this.labelDate4 = new System.Windows.Forms.Label();
            this.labelDate5 = new System.Windows.Forms.Label();
            this.labelDate6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelSelectedGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelCalendar
            // 
            this.panelCalendar.BackColor = System.Drawing.SystemColors.Menu;
            this.panelCalendar.Location = new System.Drawing.Point(115, 44);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(600, 510);
            this.panelCalendar.TabIndex = 0;
            this.panelCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalendar_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "8:00 AM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "9:00 AM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "8:00 PM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "10:00 AM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "11:00 AM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "12:00 PM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "1:00 PM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "2:00 PM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "3:00 PM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "4:00 PM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 24);
            this.label11.TabIndex = 10;
            this.label11.Text = "5:00 PM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 430);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "6:00 PM";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 470);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 24);
            this.label13.TabIndex = 12;
            this.label13.Text = "7:00 PM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 550);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 24);
            this.label14.TabIndex = 13;
            this.label14.Text = "9:00 PM";
            // 
            // treeViewClusters
            // 
            this.treeViewClusters.Location = new System.Drawing.Point(732, 70);
            this.treeViewClusters.Name = "treeViewClusters";
            this.treeViewClusters.ShowNodeToolTips = true;
            this.treeViewClusters.Size = new System.Drawing.Size(254, 484);
            this.treeViewClusters.TabIndex = 14;
            this.treeViewClusters.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewClusters_NodeMouseClick);
            // 
            // comboBoxView
            // 
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Location = new System.Drawing.Point(732, 44);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(254, 21);
            this.comboBoxView.TabIndex = 15;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(790, 9);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(196, 20);
            this.datePicker.TabIndex = 16;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(732, 574);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(254, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // labelDate1
            // 
            this.labelDate1.AutoSize = true;
            this.labelDate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate1.Location = new System.Drawing.Point(112, 5);
            this.labelDate1.Name = "labelDate1";
            this.labelDate1.Size = new System.Drawing.Size(82, 32);
            this.labelDate1.TabIndex = 18;
            this.labelDate1.Text = "Monday\r\nmm/dd/yyyy\r\n";
            this.labelDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate2
            // 
            this.labelDate2.AutoSize = true;
            this.labelDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate2.Location = new System.Drawing.Point(212, 5);
            this.labelDate2.Name = "labelDate2";
            this.labelDate2.Size = new System.Drawing.Size(82, 32);
            this.labelDate2.TabIndex = 19;
            this.labelDate2.Text = "Tuesday\r\nmm/dd/yyyy";
            this.labelDate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate3
            // 
            this.labelDate3.AutoSize = true;
            this.labelDate3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate3.Location = new System.Drawing.Point(312, 5);
            this.labelDate3.Name = "labelDate3";
            this.labelDate3.Size = new System.Drawing.Size(82, 32);
            this.labelDate3.TabIndex = 20;
            this.labelDate3.Text = "Wednesday\r\nmm/dd/yyyy";
            // 
            // labelDate4
            // 
            this.labelDate4.AutoSize = true;
            this.labelDate4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate4.Location = new System.Drawing.Point(412, 5);
            this.labelDate4.Name = "labelDate4";
            this.labelDate4.Size = new System.Drawing.Size(82, 32);
            this.labelDate4.TabIndex = 21;
            this.labelDate4.Text = "Thursday\r\nmm/dd/yyyy";
            this.labelDate4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate5
            // 
            this.labelDate5.AutoSize = true;
            this.labelDate5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate5.Location = new System.Drawing.Point(512, 5);
            this.labelDate5.Name = "labelDate5";
            this.labelDate5.Size = new System.Drawing.Size(82, 32);
            this.labelDate5.TabIndex = 22;
            this.labelDate5.Text = "Friday\r\nmm/dd/yyyy";
            this.labelDate5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate6
            // 
            this.labelDate6.AutoSize = true;
            this.labelDate6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate6.Location = new System.Drawing.Point(612, 5);
            this.labelDate6.Name = "labelDate6";
            this.labelDate6.Size = new System.Drawing.Size(82, 32);
            this.labelDate6.TabIndex = 22;
            this.labelDate6.Text = "Saturday\r\nmm/dd/yyyy";
            this.labelDate6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(703, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Start Date:";
            // 
            // labelSelectedGroup
            // 
            this.labelSelectedGroup.AutoSize = true;
            this.labelSelectedGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedGroup.Location = new System.Drawing.Point(111, 574);
            this.labelSelectedGroup.Name = "labelSelectedGroup";
            this.labelSelectedGroup.Size = new System.Drawing.Size(125, 20);
            this.labelSelectedGroup.TabIndex = 24;
            this.labelSelectedGroup.Text = "Selected Group:";
            // 
            // FreeTimeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelectedGroup);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelDate6);
            this.Controls.Add(this.labelDate5);
            this.Controls.Add(this.labelDate4);
            this.Controls.Add(this.labelDate3);
            this.Controls.Add(this.labelDate2);
            this.Controls.Add(this.labelDate1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.comboBoxView);
            this.Controls.Add(this.treeViewClusters);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelCalendar);
            this.Name = "FreeTimeViewer";
            this.Size = new System.Drawing.Size(1000, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TreeView treeViewClusters;
        private System.Windows.Forms.ComboBox comboBoxView;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelDate1;
        private System.Windows.Forms.Label labelDate2;
        private System.Windows.Forms.Label labelDate3;
        private System.Windows.Forms.Label labelDate4;
        private System.Windows.Forms.Label labelDate5;
        private System.Windows.Forms.Label labelDate6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelSelectedGroup;
    }
}
