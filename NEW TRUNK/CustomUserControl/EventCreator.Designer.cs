namespace CustomUserControl
{
    partial class EventCreator
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
            this.labelEventName = new System.Windows.Forms.Label();
            this.dateTimePickerEventEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEventStartTime = new System.Windows.Forms.DateTimePicker();
            this.labelEventEndTime = new System.Windows.Forms.Label();
            this.labelEventStartTime = new System.Windows.Forms.Label();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.buttonSaveEvent = new System.Windows.Forms.Button();
            this.buttonCancelEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(26, 10);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(35, 13);
            this.labelEventName.TabIndex = 22;
            this.labelEventName.Text = "Name";
            // 
            // dateTimePickerEventEndTime
            // 
            this.dateTimePickerEventEndTime.CustomFormat = "MMMM dd, yyyy   hh:mm  tt";
            this.dateTimePickerEventEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEventEndTime.Location = new System.Drawing.Point(62, 64);
            this.dateTimePickerEventEndTime.Name = "dateTimePickerEventEndTime";
            this.dateTimePickerEventEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerEventEndTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEventEndTime.TabIndex = 21;
            // 
            // dateTimePickerEventStartTime
            // 
            this.dateTimePickerEventStartTime.CustomFormat = "MMMM dd, yyyy   hh:mm  tt";
            this.dateTimePickerEventStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEventStartTime.Location = new System.Drawing.Point(62, 35);
            this.dateTimePickerEventStartTime.Name = "dateTimePickerEventStartTime";
            this.dateTimePickerEventStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerEventStartTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEventStartTime.TabIndex = 20;
            // 
            // labelEventEndTime
            // 
            this.labelEventEndTime.AutoSize = true;
            this.labelEventEndTime.Location = new System.Drawing.Point(9, 67);
            this.labelEventEndTime.Name = "labelEventEndTime";
            this.labelEventEndTime.Size = new System.Drawing.Size(52, 13);
            this.labelEventEndTime.TabIndex = 19;
            this.labelEventEndTime.Text = "End Time";
            // 
            // labelEventStartTime
            // 
            this.labelEventStartTime.AutoSize = true;
            this.labelEventStartTime.Location = new System.Drawing.Point(6, 40);
            this.labelEventStartTime.Name = "labelEventStartTime";
            this.labelEventStartTime.Size = new System.Drawing.Size(55, 13);
            this.labelEventStartTime.TabIndex = 18;
            this.labelEventStartTime.Text = "Start Time";
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(62, 6);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(218, 20);
            this.textBoxEventName.TabIndex = 17;
            // 
            // buttonSaveEvent
            // 
            this.buttonSaveEvent.Location = new System.Drawing.Point(125, 90);
            this.buttonSaveEvent.Name = "buttonSaveEvent";
            this.buttonSaveEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveEvent.TabIndex = 23;
            this.buttonSaveEvent.Text = "Save";
            this.buttonSaveEvent.UseVisualStyleBackColor = true;
            // 
            // buttonCancelEvent
            // 
            this.buttonCancelEvent.Location = new System.Drawing.Point(206, 90);
            this.buttonCancelEvent.Name = "buttonCancelEvent";
            this.buttonCancelEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelEvent.TabIndex = 24;
            this.buttonCancelEvent.Text = "Cancel";
            this.buttonCancelEvent.UseVisualStyleBackColor = true;
            // 
            // EventCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.buttonCancelEvent);
            this.Controls.Add(this.buttonSaveEvent);
            this.Controls.Add(this.labelEventName);
            this.Controls.Add(this.dateTimePickerEventEndTime);
            this.Controls.Add(this.dateTimePickerEventStartTime);
            this.Controls.Add(this.labelEventEndTime);
            this.Controls.Add(this.labelEventStartTime);
            this.Controls.Add(this.textBoxEventName);
            this.Name = "EventCreator";
            this.Text = "EventCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventStartTime;
        private System.Windows.Forms.Label labelEventEndTime;
        private System.Windows.Forms.Label labelEventStartTime;
        private System.Windows.Forms.TextBox textBoxEventName;
        private System.Windows.Forms.Button buttonSaveEvent;
        private System.Windows.Forms.Button buttonCancelEvent;
    }
}