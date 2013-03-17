namespace CustomUserControl
{
    partial class DefenseSchedulesViewercs
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
            this.labelDisplayMsg = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.buttonViewDefScheds = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelDisplayMsg
            // 
            this.labelDisplayMsg.AutoSize = true;
            this.labelDisplayMsg.Location = new System.Drawing.Point(182, 81);
            this.labelDisplayMsg.Name = "labelDisplayMsg";
            this.labelDisplayMsg.Size = new System.Drawing.Size(0, 13);
            this.labelDisplayMsg.TabIndex = 11;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(185, 48);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "to";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(185, 9);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 8;
            // 
            // buttonViewDefScheds
            // 
            this.buttonViewDefScheds.Location = new System.Drawing.Point(3, 9);
            this.buttonViewDefScheds.Name = "buttonViewDefScheds";
            this.buttonViewDefScheds.Size = new System.Drawing.Size(163, 26);
            this.buttonViewDefScheds.TabIndex = 7;
            this.buttonViewDefScheds.Text = "Generate Schedules From";
            this.buttonViewDefScheds.UseVisualStyleBackColor = true;
            this.buttonViewDefScheds.Click += new System.EventHandler(this.buttonViewDefScheds_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 97);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(932, 545);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // DefenseSchedulesViewercs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDisplayMsg);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonViewDefScheds);
            this.Controls.Add(this.richTextBox1);
            this.Name = "DefenseSchedulesViewercs";
            this.Size = new System.Drawing.Size(940, 645);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDisplayMsg;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button buttonViewDefScheds;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
