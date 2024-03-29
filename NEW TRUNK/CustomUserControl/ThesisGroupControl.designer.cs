﻿using System.Windows.Forms;

namespace CustomUserControl
{
    partial class ThesisGroupControl
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        } 

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentsPanel = new System.Windows.Forms.Panel();
            this.student4 = new System.Windows.Forms.Panel();
            this.labelMemberComma4 = new System.Windows.Forms.Label();
            this.studentLN4 = new System.Windows.Forms.TextBox();
            this.studentMI4 = new System.Windows.Forms.TextBox();
            this.studentFN4 = new System.Windows.Forms.TextBox();
            this.deleteStudent4 = new System.Windows.Forms.Button();
            this.saveStudent4 = new System.Windows.Forms.Button();
            this.editStudent4 = new System.Windows.Forms.Button();
            this.studentID4 = new System.Windows.Forms.TextBox();
            this.labelMemberID4 = new System.Windows.Forms.Label();
            this.labelMemberName4 = new System.Windows.Forms.Label();
            this.student3 = new System.Windows.Forms.Panel();
            this.labelMemberComma3 = new System.Windows.Forms.Label();
            this.studentLN3 = new System.Windows.Forms.TextBox();
            this.studentMI3 = new System.Windows.Forms.TextBox();
            this.studentFN3 = new System.Windows.Forms.TextBox();
            this.deleteStudent3 = new System.Windows.Forms.Button();
            this.saveStudent3 = new System.Windows.Forms.Button();
            this.editStudent3 = new System.Windows.Forms.Button();
            this.studentID3 = new System.Windows.Forms.TextBox();
            this.labelMemberID3 = new System.Windows.Forms.Label();
            this.labelMemberName3 = new System.Windows.Forms.Label();
            this.student2 = new System.Windows.Forms.Panel();
            this.labelMemberComma2 = new System.Windows.Forms.Label();
            this.studentLN2 = new System.Windows.Forms.TextBox();
            this.studentMI2 = new System.Windows.Forms.TextBox();
            this.studentFN2 = new System.Windows.Forms.TextBox();
            this.deleteStudent2 = new System.Windows.Forms.Button();
            this.saveStudent2 = new System.Windows.Forms.Button();
            this.editStudent2 = new System.Windows.Forms.Button();
            this.studentID2 = new System.Windows.Forms.TextBox();
            this.labelMemberID2 = new System.Windows.Forms.Label();
            this.labelMemberName2 = new System.Windows.Forms.Label();
            this.student1 = new System.Windows.Forms.Panel();
            this.labelMemberComma1 = new System.Windows.Forms.Label();
            this.studentLN1 = new System.Windows.Forms.TextBox();
            this.studentMI1 = new System.Windows.Forms.TextBox();
            this.deleteStudent1 = new System.Windows.Forms.Button();
            this.saveStudent1 = new System.Windows.Forms.Button();
            this.editStudent1 = new System.Windows.Forms.Button();
            this.studentID1 = new System.Windows.Forms.TextBox();
            this.studentFN1 = new System.Windows.Forms.TextBox();
            this.labelMemberID1 = new System.Windows.Forms.Label();
            this.labelMemberName1 = new System.Windows.Forms.Label();
            this.labelMemberControl = new System.Windows.Forms.Label();
            this.panelistControl = new System.Windows.Forms.Panel();
            this.labelSelectAdviser = new System.Windows.Forms.Label();
            this.selectAdviser = new System.Windows.Forms.ComboBox();
            this.panelist4 = new System.Windows.Forms.Panel();
            this.selPanelist4 = new System.Windows.Forms.Button();
            this.selectPanelist4 = new System.Windows.Forms.ComboBox();
            this.labelPanelistComma4 = new System.Windows.Forms.Label();
            this.panelistLN4 = new System.Windows.Forms.TextBox();
            this.panelistMI4 = new System.Windows.Forms.TextBox();
            this.delPanelist4 = new System.Windows.Forms.Button();
            this.savePanelist4 = new System.Windows.Forms.Button();
            this.editPanelist4 = new System.Windows.Forms.Button();
            this.panelistID4 = new System.Windows.Forms.TextBox();
            this.panelistFN4 = new System.Windows.Forms.TextBox();
            this.labelPanelistID4 = new System.Windows.Forms.Label();
            this.labelPanelistName4 = new System.Windows.Forms.Label();
            this.panelist3 = new System.Windows.Forms.Panel();
            this.selPanelist3 = new System.Windows.Forms.Button();
            this.selectPanelist3 = new System.Windows.Forms.ComboBox();
            this.labelPanelistComma3 = new System.Windows.Forms.Label();
            this.panelistLN3 = new System.Windows.Forms.TextBox();
            this.panelistMI3 = new System.Windows.Forms.TextBox();
            this.delPanelist3 = new System.Windows.Forms.Button();
            this.savePanelist3 = new System.Windows.Forms.Button();
            this.editPanelist3 = new System.Windows.Forms.Button();
            this.panelistID3 = new System.Windows.Forms.TextBox();
            this.panelistFN3 = new System.Windows.Forms.TextBox();
            this.labelPanelistID3 = new System.Windows.Forms.Label();
            this.labelPanelistName3 = new System.Windows.Forms.Label();
            this.panelist2 = new System.Windows.Forms.Panel();
            this.selPanelist2 = new System.Windows.Forms.Button();
            this.selectPanelist2 = new System.Windows.Forms.ComboBox();
            this.labelPanelistComma2 = new System.Windows.Forms.Label();
            this.panelistLN2 = new System.Windows.Forms.TextBox();
            this.panelistMI2 = new System.Windows.Forms.TextBox();
            this.delPanelist2 = new System.Windows.Forms.Button();
            this.savePanelist2 = new System.Windows.Forms.Button();
            this.editPanelist2 = new System.Windows.Forms.Button();
            this.panelistID2 = new System.Windows.Forms.TextBox();
            this.panelistFN2 = new System.Windows.Forms.TextBox();
            this.labelPanelistID2 = new System.Windows.Forms.Label();
            this.labelPanelistName2 = new System.Windows.Forms.Label();
            this.labelPanelistControl = new System.Windows.Forms.Label();
            this.panelist1 = new System.Windows.Forms.Panel();
            this.selPanelist1 = new System.Windows.Forms.Button();
            this.selectPanelist1 = new System.Windows.Forms.ComboBox();
            this.labelPanelistComma1 = new System.Windows.Forms.Label();
            this.panelistLN1 = new System.Windows.Forms.TextBox();
            this.panelistMI1 = new System.Windows.Forms.TextBox();
            this.delPanelist1 = new System.Windows.Forms.Button();
            this.savePanelist1 = new System.Windows.Forms.Button();
            this.editPanelist1 = new System.Windows.Forms.Button();
            this.panelistID1 = new System.Windows.Forms.TextBox();
            this.panelistFN1 = new System.Windows.Forms.TextBox();
            this.labelPanelistID1 = new System.Windows.Forms.Label();
            this.labelPanelistName1 = new System.Windows.Forms.Label();
            this.labelGroupView = new System.Windows.Forms.Label();
            this.thesisGroupPanel = new System.Windows.Forms.Panel();
            this.redefenseCheckBox = new System.Windows.Forms.CheckBox();
            this.defenseCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteGroup = new System.Windows.Forms.Button();
            this.cancelEdits = new System.Windows.Forms.Button();
            this.saveDetails = new System.Windows.Forms.Button();
            this.editThesisGroup = new System.Windows.Forms.Button();
            this.groupStartSY = new System.Windows.Forms.TextBox();
            this.newThesisGroup = new System.Windows.Forms.Button();
            this.groupStartTerm = new System.Windows.Forms.ComboBox();
            this.groupSection = new System.Windows.Forms.TextBox();
            this.groupCourse = new System.Windows.Forms.ComboBox();
            this.groupThesisTitle = new System.Windows.Forms.TextBox();
            this.labelGroupStartTerm = new System.Windows.Forms.Label();
            this.labelGroupStartSY = new System.Windows.Forms.Label();
            this.labelGroupSection = new System.Windows.Forms.Label();
            this.labelGroupCourse = new System.Windows.Forms.Label();
            this.labelGroupThesisTitle = new System.Windows.Forms.Label();
            this.labelGroupControl = new System.Windows.Forms.Label();
            this.labelEligibleNeeds = new System.Windows.Forms.Label();
            this.thesisGroupTreeView = new System.Windows.Forms.TreeView();
            this.studentsPanel.SuspendLayout();
            this.student4.SuspendLayout();
            this.student3.SuspendLayout();
            this.student2.SuspendLayout();
            this.student1.SuspendLayout();
            this.panelistControl.SuspendLayout();
            this.panelist4.SuspendLayout();
            this.panelist3.SuspendLayout();
            this.panelist2.SuspendLayout();
            this.panelist1.SuspendLayout();
            this.thesisGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsPanel
            // 
            this.studentsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentsPanel.Controls.Add(this.student4);
            this.studentsPanel.Controls.Add(this.student3);
            this.studentsPanel.Controls.Add(this.student2);
            this.studentsPanel.Controls.Add(this.student1);
            this.studentsPanel.Controls.Add(this.labelMemberControl);
            this.studentsPanel.Location = new System.Drawing.Point(277, 185);
            this.studentsPanel.Name = "studentsPanel";
            this.studentsPanel.Size = new System.Drawing.Size(358, 463);
            this.studentsPanel.TabIndex = 18;
            // 
            // student4
            // 
            this.student4.BackColor = System.Drawing.Color.Transparent;
            this.student4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.student4.Controls.Add(this.labelMemberComma4);
            this.student4.Controls.Add(this.studentLN4);
            this.student4.Controls.Add(this.studentMI4);
            this.student4.Controls.Add(this.studentFN4);
            this.student4.Controls.Add(this.deleteStudent4);
            this.student4.Controls.Add(this.saveStudent4);
            this.student4.Controls.Add(this.editStudent4);
            this.student4.Controls.Add(this.studentID4);
            this.student4.Controls.Add(this.labelMemberID4);
            this.student4.Controls.Add(this.labelMemberName4);
            this.student4.Location = new System.Drawing.Point(3, 364);
            this.student4.Name = "student4";
            this.student4.Size = new System.Drawing.Size(350, 94);
            this.student4.TabIndex = 37;
            // 
            // labelMemberComma4
            // 
            this.labelMemberComma4.AutoSize = true;
            this.labelMemberComma4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberComma4.Location = new System.Drawing.Point(112, 33);
            this.labelMemberComma4.Name = "labelMemberComma4";
            this.labelMemberComma4.Size = new System.Drawing.Size(10, 15);
            this.labelMemberComma4.TabIndex = 29;
            this.labelMemberComma4.Text = ",";
            // 
            // studentLN4
            // 
            this.studentLN4.Enabled = false;
            this.studentLN4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLN4.Location = new System.Drawing.Point(2, 29);
            this.studentLN4.Name = "studentLN4";
            this.studentLN4.Size = new System.Drawing.Size(104, 23);
            this.studentLN4.TabIndex = 23;
            // 
            // studentMI4
            // 
            this.studentMI4.Enabled = false;
            this.studentMI4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentMI4.Location = new System.Drawing.Point(232, 29);
            this.studentMI4.MaxLength = 1;
            this.studentMI4.Name = "studentMI4";
            this.studentMI4.Size = new System.Drawing.Size(24, 23);
            this.studentMI4.TabIndex = 25;
            // 
            // studentFN4
            // 
            this.studentFN4.Enabled = false;
            this.studentFN4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentFN4.Location = new System.Drawing.Point(126, 29);
            this.studentFN4.Name = "studentFN4";
            this.studentFN4.Size = new System.Drawing.Size(100, 23);
            this.studentFN4.TabIndex = 24;
            // 
            // deleteStudent4
            // 
            this.deleteStudent4.Enabled = false;
            this.deleteStudent4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStudent4.Location = new System.Drawing.Point(263, 64);
            this.deleteStudent4.Name = "deleteStudent4";
            this.deleteStudent4.Size = new System.Drawing.Size(82, 23);
            this.deleteStudent4.TabIndex = 22;
            this.deleteStudent4.Text = "Delete";
            this.deleteStudent4.UseVisualStyleBackColor = true;
            // 
            // saveStudent4
            // 
            this.saveStudent4.Enabled = false;
            this.saveStudent4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStudent4.Location = new System.Drawing.Point(263, 35);
            this.saveStudent4.Name = "saveStudent4";
            this.saveStudent4.Size = new System.Drawing.Size(82, 23);
            this.saveStudent4.TabIndex = 27;
            this.saveStudent4.Text = "Save";
            this.saveStudent4.UseVisualStyleBackColor = true;
            // 
            // editStudent4
            // 
            this.editStudent4.Enabled = false;
            this.editStudent4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudent4.Location = new System.Drawing.Point(263, 6);
            this.editStudent4.Name = "editStudent4";
            this.editStudent4.Size = new System.Drawing.Size(82, 23);
            this.editStudent4.TabIndex = 22;
            this.editStudent4.Text = "Edit";
            this.editStudent4.UseVisualStyleBackColor = true;
            // 
            // studentID4
            // 
            this.studentID4.Enabled = false;
            this.studentID4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentID4.Location = new System.Drawing.Point(65, 59);
            this.studentID4.MaxLength = 8;
            this.studentID4.Name = "studentID4";
            this.studentID4.Size = new System.Drawing.Size(192, 23);
            this.studentID4.TabIndex = 26;
            // 
            // labelMemberID4
            // 
            this.labelMemberID4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberID4.Location = new System.Drawing.Point(3, 59);
            this.labelMemberID4.Name = "labelMemberID4";
            this.labelMemberID4.Size = new System.Drawing.Size(85, 20);
            this.labelMemberID4.TabIndex = 17;
            this.labelMemberID4.Text = "ID Number:";
            this.labelMemberID4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberName4
            // 
            this.labelMemberName4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberName4.Location = new System.Drawing.Point(1, 6);
            this.labelMemberName4.Name = "labelMemberName4";
            this.labelMemberName4.Size = new System.Drawing.Size(120, 20);
            this.labelMemberName4.TabIndex = 10;
            this.labelMemberName4.Text = "Member 4 Name:";
            this.labelMemberName4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // student3
            // 
            this.student3.BackColor = System.Drawing.Color.Transparent;
            this.student3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.student3.Controls.Add(this.labelMemberComma3);
            this.student3.Controls.Add(this.studentLN3);
            this.student3.Controls.Add(this.studentMI3);
            this.student3.Controls.Add(this.studentFN3);
            this.student3.Controls.Add(this.deleteStudent3);
            this.student3.Controls.Add(this.saveStudent3);
            this.student3.Controls.Add(this.editStudent3);
            this.student3.Controls.Add(this.studentID3);
            this.student3.Controls.Add(this.labelMemberID3);
            this.student3.Controls.Add(this.labelMemberName3);
            this.student3.Location = new System.Drawing.Point(3, 266);
            this.student3.Name = "student3";
            this.student3.Size = new System.Drawing.Size(350, 94);
            this.student3.TabIndex = 37;
            // 
            // labelMemberComma3
            // 
            this.labelMemberComma3.AutoSize = true;
            this.labelMemberComma3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberComma3.Location = new System.Drawing.Point(109, 33);
            this.labelMemberComma3.Name = "labelMemberComma3";
            this.labelMemberComma3.Size = new System.Drawing.Size(10, 15);
            this.labelMemberComma3.TabIndex = 29;
            this.labelMemberComma3.Text = ",";
            // 
            // studentLN3
            // 
            this.studentLN3.Enabled = false;
            this.studentLN3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLN3.Location = new System.Drawing.Point(2, 29);
            this.studentLN3.Name = "studentLN3";
            this.studentLN3.Size = new System.Drawing.Size(104, 23);
            this.studentLN3.TabIndex = 17;
            // 
            // studentMI3
            // 
            this.studentMI3.Enabled = false;
            this.studentMI3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentMI3.Location = new System.Drawing.Point(232, 30);
            this.studentMI3.MaxLength = 1;
            this.studentMI3.Name = "studentMI3";
            this.studentMI3.Size = new System.Drawing.Size(24, 23);
            this.studentMI3.TabIndex = 19;
            // 
            // studentFN3
            // 
            this.studentFN3.Enabled = false;
            this.studentFN3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentFN3.Location = new System.Drawing.Point(125, 30);
            this.studentFN3.Name = "studentFN3";
            this.studentFN3.Size = new System.Drawing.Size(101, 23);
            this.studentFN3.TabIndex = 18;
            // 
            // deleteStudent3
            // 
            this.deleteStudent3.Enabled = false;
            this.deleteStudent3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStudent3.Location = new System.Drawing.Point(263, 64);
            this.deleteStudent3.Name = "deleteStudent3";
            this.deleteStudent3.Size = new System.Drawing.Size(82, 23);
            this.deleteStudent3.TabIndex = 22;
            this.deleteStudent3.Text = "Delete";
            this.deleteStudent3.UseVisualStyleBackColor = true;
            // 
            // saveStudent3
            // 
            this.saveStudent3.Enabled = false;
            this.saveStudent3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStudent3.Location = new System.Drawing.Point(263, 35);
            this.saveStudent3.Name = "saveStudent3";
            this.saveStudent3.Size = new System.Drawing.Size(82, 23);
            this.saveStudent3.TabIndex = 21;
            this.saveStudent3.Text = "Save";
            this.saveStudent3.UseVisualStyleBackColor = true;
            // 
            // editStudent3
            // 
            this.editStudent3.Enabled = false;
            this.editStudent3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudent3.Location = new System.Drawing.Point(263, 6);
            this.editStudent3.Name = "editStudent3";
            this.editStudent3.Size = new System.Drawing.Size(82, 23);
            this.editStudent3.TabIndex = 16;
            this.editStudent3.Text = "Edit";
            this.editStudent3.UseVisualStyleBackColor = true;
            // 
            // studentID3
            // 
            this.studentID3.Enabled = false;
            this.studentID3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentID3.Location = new System.Drawing.Point(65, 59);
            this.studentID3.MaxLength = 8;
            this.studentID3.Name = "studentID3";
            this.studentID3.Size = new System.Drawing.Size(192, 23);
            this.studentID3.TabIndex = 20;
            // 
            // labelMemberID3
            // 
            this.labelMemberID3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberID3.Location = new System.Drawing.Point(3, 59);
            this.labelMemberID3.Name = "labelMemberID3";
            this.labelMemberID3.Size = new System.Drawing.Size(85, 20);
            this.labelMemberID3.TabIndex = 17;
            this.labelMemberID3.Text = "ID Number:";
            this.labelMemberID3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberName3
            // 
            this.labelMemberName3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberName3.Location = new System.Drawing.Point(1, 6);
            this.labelMemberName3.Name = "labelMemberName3";
            this.labelMemberName3.Size = new System.Drawing.Size(120, 20);
            this.labelMemberName3.TabIndex = 10;
            this.labelMemberName3.Text = "Member 3 Name:";
            this.labelMemberName3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // student2
            // 
            this.student2.BackColor = System.Drawing.Color.Transparent;
            this.student2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.student2.Controls.Add(this.labelMemberComma2);
            this.student2.Controls.Add(this.studentLN2);
            this.student2.Controls.Add(this.studentMI2);
            this.student2.Controls.Add(this.studentFN2);
            this.student2.Controls.Add(this.deleteStudent2);
            this.student2.Controls.Add(this.saveStudent2);
            this.student2.Controls.Add(this.editStudent2);
            this.student2.Controls.Add(this.studentID2);
            this.student2.Controls.Add(this.labelMemberID2);
            this.student2.Controls.Add(this.labelMemberName2);
            this.student2.Location = new System.Drawing.Point(3, 169);
            this.student2.Name = "student2";
            this.student2.Size = new System.Drawing.Size(350, 94);
            this.student2.TabIndex = 37;
            // 
            // labelMemberComma2
            // 
            this.labelMemberComma2.AutoSize = true;
            this.labelMemberComma2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberComma2.Location = new System.Drawing.Point(109, 35);
            this.labelMemberComma2.Name = "labelMemberComma2";
            this.labelMemberComma2.Size = new System.Drawing.Size(10, 15);
            this.labelMemberComma2.TabIndex = 29;
            this.labelMemberComma2.Text = ",";
            // 
            // studentLN2
            // 
            this.studentLN2.Enabled = false;
            this.studentLN2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLN2.Location = new System.Drawing.Point(2, 29);
            this.studentLN2.Name = "studentLN2";
            this.studentLN2.Size = new System.Drawing.Size(104, 23);
            this.studentLN2.TabIndex = 11;
            // 
            // studentMI2
            // 
            this.studentMI2.Enabled = false;
            this.studentMI2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentMI2.Location = new System.Drawing.Point(232, 29);
            this.studentMI2.MaxLength = 1;
            this.studentMI2.Name = "studentMI2";
            this.studentMI2.Size = new System.Drawing.Size(24, 23);
            this.studentMI2.TabIndex = 13;
            // 
            // studentFN2
            // 
            this.studentFN2.Enabled = false;
            this.studentFN2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentFN2.Location = new System.Drawing.Point(125, 29);
            this.studentFN2.Name = "studentFN2";
            this.studentFN2.Size = new System.Drawing.Size(100, 23);
            this.studentFN2.TabIndex = 12;
            // 
            // deleteStudent2
            // 
            this.deleteStudent2.Enabled = false;
            this.deleteStudent2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStudent2.Location = new System.Drawing.Point(263, 64);
            this.deleteStudent2.Name = "deleteStudent2";
            this.deleteStudent2.Size = new System.Drawing.Size(82, 23);
            this.deleteStudent2.TabIndex = 22;
            this.deleteStudent2.Text = "Delete";
            this.deleteStudent2.UseVisualStyleBackColor = true;
            // 
            // saveStudent2
            // 
            this.saveStudent2.Enabled = false;
            this.saveStudent2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStudent2.Location = new System.Drawing.Point(263, 35);
            this.saveStudent2.Name = "saveStudent2";
            this.saveStudent2.Size = new System.Drawing.Size(82, 23);
            this.saveStudent2.TabIndex = 15;
            this.saveStudent2.Text = "Save";
            this.saveStudent2.UseVisualStyleBackColor = true;
            // 
            // editStudent2
            // 
            this.editStudent2.Enabled = false;
            this.editStudent2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudent2.Location = new System.Drawing.Point(263, 6);
            this.editStudent2.Name = "editStudent2";
            this.editStudent2.Size = new System.Drawing.Size(82, 23);
            this.editStudent2.TabIndex = 10;
            this.editStudent2.Text = "Edit";
            this.editStudent2.UseVisualStyleBackColor = true;
            // 
            // studentID2
            // 
            this.studentID2.Enabled = false;
            this.studentID2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentID2.Location = new System.Drawing.Point(65, 59);
            this.studentID2.MaxLength = 8;
            this.studentID2.Name = "studentID2";
            this.studentID2.Size = new System.Drawing.Size(192, 23);
            this.studentID2.TabIndex = 14;
            // 
            // labelMemberID2
            // 
            this.labelMemberID2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberID2.Location = new System.Drawing.Point(3, 59);
            this.labelMemberID2.Name = "labelMemberID2";
            this.labelMemberID2.Size = new System.Drawing.Size(85, 20);
            this.labelMemberID2.TabIndex = 17;
            this.labelMemberID2.Text = "ID Number:";
            this.labelMemberID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberName2
            // 
            this.labelMemberName2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberName2.Location = new System.Drawing.Point(1, 6);
            this.labelMemberName2.Name = "labelMemberName2";
            this.labelMemberName2.Size = new System.Drawing.Size(120, 20);
            this.labelMemberName2.TabIndex = 10;
            this.labelMemberName2.Text = "Member 2 Name:";
            this.labelMemberName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // student1
            // 
            this.student1.BackColor = System.Drawing.Color.Transparent;
            this.student1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.student1.Controls.Add(this.labelMemberComma1);
            this.student1.Controls.Add(this.studentLN1);
            this.student1.Controls.Add(this.studentMI1);
            this.student1.Controls.Add(this.deleteStudent1);
            this.student1.Controls.Add(this.saveStudent1);
            this.student1.Controls.Add(this.editStudent1);
            this.student1.Controls.Add(this.studentID1);
            this.student1.Controls.Add(this.studentFN1);
            this.student1.Controls.Add(this.labelMemberID1);
            this.student1.Controls.Add(this.labelMemberName1);
            this.student1.Location = new System.Drawing.Point(3, 72);
            this.student1.Name = "student1";
            this.student1.Size = new System.Drawing.Size(350, 94);
            this.student1.TabIndex = 36;
            // 
            // labelMemberComma1
            // 
            this.labelMemberComma1.AutoSize = true;
            this.labelMemberComma1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberComma1.Location = new System.Drawing.Point(110, 32);
            this.labelMemberComma1.Name = "labelMemberComma1";
            this.labelMemberComma1.Size = new System.Drawing.Size(10, 15);
            this.labelMemberComma1.TabIndex = 25;
            this.labelMemberComma1.Text = ",";
            // 
            // studentLN1
            // 
            this.studentLN1.Enabled = false;
            this.studentLN1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLN1.Location = new System.Drawing.Point(2, 29);
            this.studentLN1.Name = "studentLN1";
            this.studentLN1.Size = new System.Drawing.Size(104, 23);
            this.studentLN1.TabIndex = 6;
            // 
            // studentMI1
            // 
            this.studentMI1.Enabled = false;
            this.studentMI1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentMI1.Location = new System.Drawing.Point(232, 29);
            this.studentMI1.MaxLength = 1;
            this.studentMI1.Name = "studentMI1";
            this.studentMI1.Size = new System.Drawing.Size(24, 23);
            this.studentMI1.TabIndex = 8;
            // 
            // deleteStudent1
            // 
            this.deleteStudent1.Enabled = false;
            this.deleteStudent1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStudent1.Location = new System.Drawing.Point(263, 64);
            this.deleteStudent1.Name = "deleteStudent1";
            this.deleteStudent1.Size = new System.Drawing.Size(82, 23);
            this.deleteStudent1.TabIndex = 22;
            this.deleteStudent1.Text = "Delete";
            this.deleteStudent1.UseVisualStyleBackColor = true;
            // 
            // saveStudent1
            // 
            this.saveStudent1.Enabled = false;
            this.saveStudent1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStudent1.Location = new System.Drawing.Point(263, 35);
            this.saveStudent1.Name = "saveStudent1";
            this.saveStudent1.Size = new System.Drawing.Size(82, 23);
            this.saveStudent1.TabIndex = 10;
            this.saveStudent1.Text = "Save";
            this.saveStudent1.UseVisualStyleBackColor = true;
            // 
            // editStudent1
            // 
            this.editStudent1.Enabled = false;
            this.editStudent1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudent1.Location = new System.Drawing.Point(263, 6);
            this.editStudent1.Name = "editStudent1";
            this.editStudent1.Size = new System.Drawing.Size(82, 23);
            this.editStudent1.TabIndex = 6;
            this.editStudent1.Text = "Edit";
            this.editStudent1.UseVisualStyleBackColor = true;
            // 
            // studentID1
            // 
            this.studentID1.Enabled = false;
            this.studentID1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentID1.Location = new System.Drawing.Point(65, 59);
            this.studentID1.MaxLength = 8;
            this.studentID1.Name = "studentID1";
            this.studentID1.Size = new System.Drawing.Size(192, 23);
            this.studentID1.TabIndex = 9;
            // 
            // studentFN1
            // 
            this.studentFN1.Enabled = false;
            this.studentFN1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentFN1.Location = new System.Drawing.Point(125, 29);
            this.studentFN1.Name = "studentFN1";
            this.studentFN1.Size = new System.Drawing.Size(101, 23);
            this.studentFN1.TabIndex = 7;
            // 
            // labelMemberID1
            // 
            this.labelMemberID1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberID1.Location = new System.Drawing.Point(3, 59);
            this.labelMemberID1.Name = "labelMemberID1";
            this.labelMemberID1.Size = new System.Drawing.Size(85, 20);
            this.labelMemberID1.TabIndex = 17;
            this.labelMemberID1.Text = "ID Number:";
            this.labelMemberID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberName1
            // 
            this.labelMemberName1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberName1.Location = new System.Drawing.Point(1, 6);
            this.labelMemberName1.Name = "labelMemberName1";
            this.labelMemberName1.Size = new System.Drawing.Size(120, 20);
            this.labelMemberName1.TabIndex = 10;
            this.labelMemberName1.Text = "Member 1 Name:";
            this.labelMemberName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberControl
            // 
            this.labelMemberControl.AutoSize = true;
            this.labelMemberControl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemberControl.Location = new System.Drawing.Point(1, 10);
            this.labelMemberControl.Name = "labelMemberControl";
            this.labelMemberControl.Size = new System.Drawing.Size(177, 29);
            this.labelMemberControl.TabIndex = 35;
            this.labelMemberControl.Text = "Member Control";
            // 
            // panelistControl
            // 
            this.panelistControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelistControl.Controls.Add(this.labelSelectAdviser);
            this.panelistControl.Controls.Add(this.selectAdviser);
            this.panelistControl.Controls.Add(this.panelist4);
            this.panelistControl.Controls.Add(this.panelist3);
            this.panelistControl.Controls.Add(this.panelist2);
            this.panelistControl.Controls.Add(this.labelPanelistControl);
            this.panelistControl.Controls.Add(this.panelist1);
            this.panelistControl.Location = new System.Drawing.Point(639, 185);
            this.panelistControl.Name = "panelistControl";
            this.panelistControl.Size = new System.Drawing.Size(358, 463);
            this.panelistControl.TabIndex = 29;
            // 
            // labelSelectAdviser
            // 
            this.labelSelectAdviser.AutoSize = true;
            this.labelSelectAdviser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectAdviser.Location = new System.Drawing.Point(4, 48);
            this.labelSelectAdviser.Name = "labelSelectAdviser";
            this.labelSelectAdviser.Size = new System.Drawing.Size(86, 15);
            this.labelSelectAdviser.TabIndex = 41;
            this.labelSelectAdviser.Text = "Select Adviser:";
            // 
            // selectAdviser
            // 
            this.selectAdviser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectAdviser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAdviser.FormattingEnabled = true;
            this.selectAdviser.Location = new System.Drawing.Point(90, 45);
            this.selectAdviser.Name = "selectAdviser";
            this.selectAdviser.Size = new System.Drawing.Size(172, 23);
            this.selectAdviser.TabIndex = 40;
            this.selectAdviser.SelectedIndexChanged += new System.EventHandler(this.selectedAdviser);
            // 
            // panelist4
            // 
            this.panelist4.BackColor = System.Drawing.Color.Transparent;
            this.panelist4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelist4.Controls.Add(this.selPanelist4);
            this.panelist4.Controls.Add(this.selectPanelist4);
            this.panelist4.Controls.Add(this.labelPanelistComma4);
            this.panelist4.Controls.Add(this.panelistLN4);
            this.panelist4.Controls.Add(this.panelistMI4);
            this.panelist4.Controls.Add(this.delPanelist4);
            this.panelist4.Controls.Add(this.savePanelist4);
            this.panelist4.Controls.Add(this.editPanelist4);
            this.panelist4.Controls.Add(this.panelistID4);
            this.panelist4.Controls.Add(this.panelistFN4);
            this.panelist4.Controls.Add(this.labelPanelistID4);
            this.panelist4.Controls.Add(this.labelPanelistName4);
            this.panelist4.Location = new System.Drawing.Point(3, 363);
            this.panelist4.Name = "panelist4";
            this.panelist4.Size = new System.Drawing.Size(350, 93);
            this.panelist4.TabIndex = 39;
            // 
            // selPanelist4
            // 
            this.selPanelist4.Enabled = false;
            this.selPanelist4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selPanelist4.Location = new System.Drawing.Point(0, 59);
            this.selPanelist4.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.selPanelist4.Name = "selPanelist4";
            this.selPanelist4.Size = new System.Drawing.Size(96, 23);
            this.selPanelist4.TabIndex = 27;
            this.selPanelist4.Text = "Select Existing:";
            this.selPanelist4.UseVisualStyleBackColor = true;
            // 
            // selectPanelist4
            // 
            this.selectPanelist4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectPanelist4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPanelist4.FormattingEnabled = true;
            this.selectPanelist4.Location = new System.Drawing.Point(100, 59);
            this.selectPanelist4.Name = "selectPanelist4";
            this.selectPanelist4.Size = new System.Drawing.Size(158, 23);
            this.selectPanelist4.TabIndex = 26;
            this.selectPanelist4.SelectedIndexChanged += new System.EventHandler(this.swapPanelists);
            // 
            // labelPanelistComma4
            // 
            this.labelPanelistComma4.AutoSize = true;
            this.labelPanelistComma4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistComma4.Location = new System.Drawing.Point(208, 7);
            this.labelPanelistComma4.Name = "labelPanelistComma4";
            this.labelPanelistComma4.Size = new System.Drawing.Size(10, 15);
            this.labelPanelistComma4.TabIndex = 25;
            this.labelPanelistComma4.Text = ",";
            // 
            // panelistLN4
            // 
            this.panelistLN4.Enabled = false;
            this.panelistLN4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistLN4.Location = new System.Drawing.Point(101, 4);
            this.panelistLN4.Name = "panelistLN4";
            this.panelistLN4.Size = new System.Drawing.Size(104, 23);
            this.panelistLN4.TabIndex = 43;
            // 
            // panelistMI4
            // 
            this.panelistMI4.Enabled = false;
            this.panelistMI4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistMI4.Location = new System.Drawing.Point(321, 4);
            this.panelistMI4.MaxLength = 1;
            this.panelistMI4.Name = "panelistMI4";
            this.panelistMI4.Size = new System.Drawing.Size(24, 23);
            this.panelistMI4.TabIndex = 45;
            // 
            // delPanelist4
            // 
            this.delPanelist4.Enabled = false;
            this.delPanelist4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delPanelist4.Location = new System.Drawing.Point(264, 68);
            this.delPanelist4.MaximumSize = new System.Drawing.Size(80, 20);
            this.delPanelist4.Name = "delPanelist4";
            this.delPanelist4.Size = new System.Drawing.Size(80, 20);
            this.delPanelist4.TabIndex = 22;
            this.delPanelist4.Text = "Remove";
            this.delPanelist4.UseVisualStyleBackColor = true;
            // 
            // savePanelist4
            // 
            this.savePanelist4.Enabled = false;
            this.savePanelist4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePanelist4.Location = new System.Drawing.Point(264, 48);
            this.savePanelist4.MaximumSize = new System.Drawing.Size(80, 20);
            this.savePanelist4.Name = "savePanelist4";
            this.savePanelist4.Size = new System.Drawing.Size(80, 20);
            this.savePanelist4.TabIndex = 47;
            this.savePanelist4.Text = "Save";
            this.savePanelist4.UseVisualStyleBackColor = true;
            // 
            // editPanelist4
            // 
            this.editPanelist4.Enabled = false;
            this.editPanelist4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPanelist4.Location = new System.Drawing.Point(264, 28);
            this.editPanelist4.MaximumSize = new System.Drawing.Size(80, 20);
            this.editPanelist4.Name = "editPanelist4";
            this.editPanelist4.Size = new System.Drawing.Size(80, 20);
            this.editPanelist4.TabIndex = 20;
            this.editPanelist4.Text = "Edit";
            this.editPanelist4.UseVisualStyleBackColor = true;
            // 
            // panelistID4
            // 
            this.panelistID4.Enabled = false;
            this.panelistID4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistID4.Location = new System.Drawing.Point(64, 30);
            this.panelistID4.MaxLength = 8;
            this.panelistID4.Name = "panelistID4";
            this.panelistID4.Size = new System.Drawing.Size(194, 23);
            this.panelistID4.TabIndex = 46;
            // 
            // panelistFN4
            // 
            this.panelistFN4.Enabled = false;
            this.panelistFN4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistFN4.Location = new System.Drawing.Point(218, 4);
            this.panelistFN4.Name = "panelistFN4";
            this.panelistFN4.Size = new System.Drawing.Size(101, 23);
            this.panelistFN4.TabIndex = 44;
            // 
            // labelPanelistID4
            // 
            this.labelPanelistID4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistID4.Location = new System.Drawing.Point(2, 30);
            this.labelPanelistID4.Name = "labelPanelistID4";
            this.labelPanelistID4.Size = new System.Drawing.Size(132, 20);
            this.labelPanelistID4.TabIndex = 17;
            this.labelPanelistID4.Text = "ID Number:";
            this.labelPanelistID4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPanelistName4
            // 
            this.labelPanelistName4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistName4.Location = new System.Drawing.Point(1, 6);
            this.labelPanelistName4.Name = "labelPanelistName4";
            this.labelPanelistName4.Size = new System.Drawing.Size(120, 20);
            this.labelPanelistName4.TabIndex = 10;
            this.labelPanelistName4.Text = "Panelist 4 Name:";
            this.labelPanelistName4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelist3
            // 
            this.panelist3.BackColor = System.Drawing.Color.Transparent;
            this.panelist3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelist3.Controls.Add(this.selPanelist3);
            this.panelist3.Controls.Add(this.selectPanelist3);
            this.panelist3.Controls.Add(this.labelPanelistComma3);
            this.panelist3.Controls.Add(this.panelistLN3);
            this.panelist3.Controls.Add(this.panelistMI3);
            this.panelist3.Controls.Add(this.delPanelist3);
            this.panelist3.Controls.Add(this.savePanelist3);
            this.panelist3.Controls.Add(this.editPanelist3);
            this.panelist3.Controls.Add(this.panelistID3);
            this.panelist3.Controls.Add(this.panelistFN3);
            this.panelist3.Controls.Add(this.labelPanelistID3);
            this.panelist3.Controls.Add(this.labelPanelistName3);
            this.panelist3.Location = new System.Drawing.Point(3, 266);
            this.panelist3.Name = "panelist3";
            this.panelist3.Size = new System.Drawing.Size(350, 93);
            this.panelist3.TabIndex = 39;
            // 
            // selPanelist3
            // 
            this.selPanelist3.Enabled = false;
            this.selPanelist3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selPanelist3.Location = new System.Drawing.Point(0, 59);
            this.selPanelist3.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.selPanelist3.Name = "selPanelist3";
            this.selPanelist3.Size = new System.Drawing.Size(96, 23);
            this.selPanelist3.TabIndex = 27;
            this.selPanelist3.Text = "Select Existing:";
            this.selPanelist3.UseVisualStyleBackColor = true;
            // 
            // selectPanelist3
            // 
            this.selectPanelist3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectPanelist3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPanelist3.FormattingEnabled = true;
            this.selectPanelist3.Location = new System.Drawing.Point(100, 59);
            this.selectPanelist3.Name = "selectPanelist3";
            this.selectPanelist3.Size = new System.Drawing.Size(158, 23);
            this.selectPanelist3.TabIndex = 26;
            this.selectPanelist3.SelectedIndexChanged += new System.EventHandler(this.swapPanelists);
            // 
            // labelPanelistComma3
            // 
            this.labelPanelistComma3.AutoSize = true;
            this.labelPanelistComma3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistComma3.Location = new System.Drawing.Point(208, 7);
            this.labelPanelistComma3.Name = "labelPanelistComma3";
            this.labelPanelistComma3.Size = new System.Drawing.Size(10, 15);
            this.labelPanelistComma3.TabIndex = 25;
            this.labelPanelistComma3.Text = ",";
            // 
            // panelistLN3
            // 
            this.panelistLN3.Enabled = false;
            this.panelistLN3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistLN3.Location = new System.Drawing.Point(101, 4);
            this.panelistLN3.Name = "panelistLN3";
            this.panelistLN3.Size = new System.Drawing.Size(104, 23);
            this.panelistLN3.TabIndex = 38;
            // 
            // panelistMI3
            // 
            this.panelistMI3.Enabled = false;
            this.panelistMI3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistMI3.Location = new System.Drawing.Point(321, 4);
            this.panelistMI3.MaxLength = 1;
            this.panelistMI3.Name = "panelistMI3";
            this.panelistMI3.Size = new System.Drawing.Size(24, 23);
            this.panelistMI3.TabIndex = 40;
            // 
            // delPanelist3
            // 
            this.delPanelist3.Enabled = false;
            this.delPanelist3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delPanelist3.Location = new System.Drawing.Point(264, 68);
            this.delPanelist3.MaximumSize = new System.Drawing.Size(80, 20);
            this.delPanelist3.Name = "delPanelist3";
            this.delPanelist3.Size = new System.Drawing.Size(80, 20);
            this.delPanelist3.TabIndex = 22;
            this.delPanelist3.Text = "Remove";
            this.delPanelist3.UseVisualStyleBackColor = true;
            // 
            // savePanelist3
            // 
            this.savePanelist3.Enabled = false;
            this.savePanelist3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePanelist3.Location = new System.Drawing.Point(264, 48);
            this.savePanelist3.MaximumSize = new System.Drawing.Size(80, 20);
            this.savePanelist3.Name = "savePanelist3";
            this.savePanelist3.Size = new System.Drawing.Size(80, 20);
            this.savePanelist3.TabIndex = 42;
            this.savePanelist3.Text = "Save";
            this.savePanelist3.UseVisualStyleBackColor = true;
            // 
            // editPanelist3
            // 
            this.editPanelist3.Enabled = false;
            this.editPanelist3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPanelist3.Location = new System.Drawing.Point(264, 28);
            this.editPanelist3.MaximumSize = new System.Drawing.Size(80, 20);
            this.editPanelist3.Name = "editPanelist3";
            this.editPanelist3.Size = new System.Drawing.Size(80, 20);
            this.editPanelist3.TabIndex = 20;
            this.editPanelist3.Text = "Edit";
            this.editPanelist3.UseVisualStyleBackColor = true;
            // 
            // panelistID3
            // 
            this.panelistID3.Enabled = false;
            this.panelistID3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistID3.Location = new System.Drawing.Point(64, 30);
            this.panelistID3.MaxLength = 8;
            this.panelistID3.Name = "panelistID3";
            this.panelistID3.Size = new System.Drawing.Size(194, 23);
            this.panelistID3.TabIndex = 41;
            // 
            // panelistFN3
            // 
            this.panelistFN3.Enabled = false;
            this.panelistFN3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistFN3.Location = new System.Drawing.Point(218, 4);
            this.panelistFN3.Name = "panelistFN3";
            this.panelistFN3.Size = new System.Drawing.Size(101, 23);
            this.panelistFN3.TabIndex = 39;
            // 
            // labelPanelistID3
            // 
            this.labelPanelistID3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistID3.Location = new System.Drawing.Point(2, 30);
            this.labelPanelistID3.Name = "labelPanelistID3";
            this.labelPanelistID3.Size = new System.Drawing.Size(109, 20);
            this.labelPanelistID3.TabIndex = 17;
            this.labelPanelistID3.Text = "ID Number:";
            this.labelPanelistID3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPanelistName3
            // 
            this.labelPanelistName3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistName3.Location = new System.Drawing.Point(1, 6);
            this.labelPanelistName3.Name = "labelPanelistName3";
            this.labelPanelistName3.Size = new System.Drawing.Size(120, 20);
            this.labelPanelistName3.TabIndex = 10;
            this.labelPanelistName3.Text = "Panelist 3 Name:";
            this.labelPanelistName3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelist2
            // 
            this.panelist2.BackColor = System.Drawing.Color.Transparent;
            this.panelist2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelist2.Controls.Add(this.selPanelist2);
            this.panelist2.Controls.Add(this.selectPanelist2);
            this.panelist2.Controls.Add(this.labelPanelistComma2);
            this.panelist2.Controls.Add(this.panelistLN2);
            this.panelist2.Controls.Add(this.panelistMI2);
            this.panelist2.Controls.Add(this.delPanelist2);
            this.panelist2.Controls.Add(this.savePanelist2);
            this.panelist2.Controls.Add(this.editPanelist2);
            this.panelist2.Controls.Add(this.panelistID2);
            this.panelist2.Controls.Add(this.panelistFN2);
            this.panelist2.Controls.Add(this.labelPanelistID2);
            this.panelist2.Controls.Add(this.labelPanelistName2);
            this.panelist2.Location = new System.Drawing.Point(3, 169);
            this.panelist2.Name = "panelist2";
            this.panelist2.Size = new System.Drawing.Size(350, 93);
            this.panelist2.TabIndex = 39;
            // 
            // selPanelist2
            // 
            this.selPanelist2.Enabled = false;
            this.selPanelist2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selPanelist2.Location = new System.Drawing.Point(0, 59);
            this.selPanelist2.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.selPanelist2.Name = "selPanelist2";
            this.selPanelist2.Size = new System.Drawing.Size(96, 23);
            this.selPanelist2.TabIndex = 27;
            this.selPanelist2.Text = "Select Existing:";
            this.selPanelist2.UseVisualStyleBackColor = true;
            // 
            // selectPanelist2
            // 
            this.selectPanelist2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectPanelist2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPanelist2.FormattingEnabled = true;
            this.selectPanelist2.Location = new System.Drawing.Point(100, 59);
            this.selectPanelist2.Name = "selectPanelist2";
            this.selectPanelist2.Size = new System.Drawing.Size(158, 23);
            this.selectPanelist2.TabIndex = 26;
            this.selectPanelist2.SelectedIndexChanged += new System.EventHandler(this.swapPanelists);
            // 
            // labelPanelistComma2
            // 
            this.labelPanelistComma2.AutoSize = true;
            this.labelPanelistComma2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistComma2.Location = new System.Drawing.Point(208, 7);
            this.labelPanelistComma2.Name = "labelPanelistComma2";
            this.labelPanelistComma2.Size = new System.Drawing.Size(10, 15);
            this.labelPanelistComma2.TabIndex = 25;
            this.labelPanelistComma2.Text = ",";
            // 
            // panelistLN2
            // 
            this.panelistLN2.Enabled = false;
            this.panelistLN2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistLN2.Location = new System.Drawing.Point(101, 4);
            this.panelistLN2.Name = "panelistLN2";
            this.panelistLN2.Size = new System.Drawing.Size(104, 23);
            this.panelistLN2.TabIndex = 33;
            // 
            // panelistMI2
            // 
            this.panelistMI2.Enabled = false;
            this.panelistMI2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistMI2.Location = new System.Drawing.Point(321, 4);
            this.panelistMI2.MaxLength = 1;
            this.panelistMI2.Name = "panelistMI2";
            this.panelistMI2.Size = new System.Drawing.Size(24, 23);
            this.panelistMI2.TabIndex = 35;
            // 
            // delPanelist2
            // 
            this.delPanelist2.Enabled = false;
            this.delPanelist2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delPanelist2.Location = new System.Drawing.Point(264, 68);
            this.delPanelist2.MaximumSize = new System.Drawing.Size(80, 20);
            this.delPanelist2.Name = "delPanelist2";
            this.delPanelist2.Size = new System.Drawing.Size(80, 20);
            this.delPanelist2.TabIndex = 22;
            this.delPanelist2.Text = "Remove";
            this.delPanelist2.UseVisualStyleBackColor = true;
            // 
            // savePanelist2
            // 
            this.savePanelist2.Enabled = false;
            this.savePanelist2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePanelist2.Location = new System.Drawing.Point(264, 48);
            this.savePanelist2.MaximumSize = new System.Drawing.Size(80, 20);
            this.savePanelist2.Name = "savePanelist2";
            this.savePanelist2.Size = new System.Drawing.Size(80, 20);
            this.savePanelist2.TabIndex = 37;
            this.savePanelist2.Text = "Save";
            this.savePanelist2.UseVisualStyleBackColor = true;
            // 
            // editPanelist2
            // 
            this.editPanelist2.Enabled = false;
            this.editPanelist2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPanelist2.Location = new System.Drawing.Point(264, 28);
            this.editPanelist2.MaximumSize = new System.Drawing.Size(80, 20);
            this.editPanelist2.Name = "editPanelist2";
            this.editPanelist2.Size = new System.Drawing.Size(80, 20);
            this.editPanelist2.TabIndex = 20;
            this.editPanelist2.Text = "Edit";
            this.editPanelist2.UseVisualStyleBackColor = true;
            // 
            // panelistID2
            // 
            this.panelistID2.Enabled = false;
            this.panelistID2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistID2.Location = new System.Drawing.Point(64, 30);
            this.panelistID2.MaxLength = 8;
            this.panelistID2.Name = "panelistID2";
            this.panelistID2.Size = new System.Drawing.Size(194, 23);
            this.panelistID2.TabIndex = 36;
            // 
            // panelistFN2
            // 
            this.panelistFN2.Enabled = false;
            this.panelistFN2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistFN2.Location = new System.Drawing.Point(218, 4);
            this.panelistFN2.Name = "panelistFN2";
            this.panelistFN2.Size = new System.Drawing.Size(101, 23);
            this.panelistFN2.TabIndex = 34;
            // 
            // labelPanelistID2
            // 
            this.labelPanelistID2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistID2.Location = new System.Drawing.Point(2, 30);
            this.labelPanelistID2.Name = "labelPanelistID2";
            this.labelPanelistID2.Size = new System.Drawing.Size(132, 20);
            this.labelPanelistID2.TabIndex = 17;
            this.labelPanelistID2.Text = "ID Number:";
            this.labelPanelistID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPanelistName2
            // 
            this.labelPanelistName2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistName2.Location = new System.Drawing.Point(1, 6);
            this.labelPanelistName2.Name = "labelPanelistName2";
            this.labelPanelistName2.Size = new System.Drawing.Size(115, 20);
            this.labelPanelistName2.TabIndex = 10;
            this.labelPanelistName2.Text = "Panelist 2 Name:";
            this.labelPanelistName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPanelistControl
            // 
            this.labelPanelistControl.AutoSize = true;
            this.labelPanelistControl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistControl.Location = new System.Drawing.Point(3, 8);
            this.labelPanelistControl.Name = "labelPanelistControl";
            this.labelPanelistControl.Size = new System.Drawing.Size(169, 29);
            this.labelPanelistControl.TabIndex = 36;
            this.labelPanelistControl.Text = "Panelist Control";
            // 
            // panelist1
            // 
            this.panelist1.BackColor = System.Drawing.Color.Transparent;
            this.panelist1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelist1.Controls.Add(this.selPanelist1);
            this.panelist1.Controls.Add(this.selectPanelist1);
            this.panelist1.Controls.Add(this.labelPanelistComma1);
            this.panelist1.Controls.Add(this.panelistLN1);
            this.panelist1.Controls.Add(this.panelistMI1);
            this.panelist1.Controls.Add(this.delPanelist1);
            this.panelist1.Controls.Add(this.savePanelist1);
            this.panelist1.Controls.Add(this.editPanelist1);
            this.panelist1.Controls.Add(this.panelistID1);
            this.panelist1.Controls.Add(this.panelistFN1);
            this.panelist1.Controls.Add(this.labelPanelistID1);
            this.panelist1.Controls.Add(this.labelPanelistName1);
            this.panelist1.Location = new System.Drawing.Point(3, 72);
            this.panelist1.Name = "panelist1";
            this.panelist1.Size = new System.Drawing.Size(350, 93);
            this.panelist1.TabIndex = 38;
            // 
            // selPanelist1
            // 
            this.selPanelist1.Enabled = false;
            this.selPanelist1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selPanelist1.Location = new System.Drawing.Point(0, 59);
            this.selPanelist1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.selPanelist1.Name = "selPanelist1";
            this.selPanelist1.Size = new System.Drawing.Size(96, 23);
            this.selPanelist1.TabIndex = 27;
            this.selPanelist1.Text = "Select Existing:";
            this.selPanelist1.UseVisualStyleBackColor = true;
            // 
            // selectPanelist1
            // 
            this.selectPanelist1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectPanelist1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPanelist1.FormattingEnabled = true;
            this.selectPanelist1.Location = new System.Drawing.Point(100, 59);
            this.selectPanelist1.Name = "selectPanelist1";
            this.selectPanelist1.Size = new System.Drawing.Size(158, 23);
            this.selectPanelist1.TabIndex = 26;
            this.selectPanelist1.SelectedIndexChanged += new System.EventHandler(this.swapPanelists);
            // 
            // labelPanelistComma1
            // 
            this.labelPanelistComma1.AutoSize = true;
            this.labelPanelistComma1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistComma1.Location = new System.Drawing.Point(208, 7);
            this.labelPanelistComma1.Name = "labelPanelistComma1";
            this.labelPanelistComma1.Size = new System.Drawing.Size(10, 15);
            this.labelPanelistComma1.TabIndex = 25;
            this.labelPanelistComma1.Text = ",";
            // 
            // panelistLN1
            // 
            this.panelistLN1.Enabled = false;
            this.panelistLN1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistLN1.Location = new System.Drawing.Point(101, 4);
            this.panelistLN1.Name = "panelistLN1";
            this.panelistLN1.Size = new System.Drawing.Size(104, 23);
            this.panelistLN1.TabIndex = 28;
            // 
            // panelistMI1
            // 
            this.panelistMI1.Enabled = false;
            this.panelistMI1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistMI1.Location = new System.Drawing.Point(321, 4);
            this.panelistMI1.MaxLength = 1;
            this.panelistMI1.Name = "panelistMI1";
            this.panelistMI1.Size = new System.Drawing.Size(24, 23);
            this.panelistMI1.TabIndex = 30;
            // 
            // delPanelist1
            // 
            this.delPanelist1.Enabled = false;
            this.delPanelist1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delPanelist1.Location = new System.Drawing.Point(264, 68);
            this.delPanelist1.MaximumSize = new System.Drawing.Size(80, 20);
            this.delPanelist1.Name = "delPanelist1";
            this.delPanelist1.Size = new System.Drawing.Size(80, 20);
            this.delPanelist1.TabIndex = 22;
            this.delPanelist1.Text = "Remove";
            this.delPanelist1.UseVisualStyleBackColor = true;
            // 
            // savePanelist1
            // 
            this.savePanelist1.Enabled = false;
            this.savePanelist1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePanelist1.Location = new System.Drawing.Point(264, 48);
            this.savePanelist1.MaximumSize = new System.Drawing.Size(80, 20);
            this.savePanelist1.Name = "savePanelist1";
            this.savePanelist1.Size = new System.Drawing.Size(80, 20);
            this.savePanelist1.TabIndex = 32;
            this.savePanelist1.Text = "Save";
            this.savePanelist1.UseVisualStyleBackColor = true;
            // 
            // editPanelist1
            // 
            this.editPanelist1.Enabled = false;
            this.editPanelist1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPanelist1.Location = new System.Drawing.Point(264, 28);
            this.editPanelist1.MaximumSize = new System.Drawing.Size(80, 20);
            this.editPanelist1.Name = "editPanelist1";
            this.editPanelist1.Size = new System.Drawing.Size(80, 20);
            this.editPanelist1.TabIndex = 20;
            this.editPanelist1.Text = "Edit";
            this.editPanelist1.UseVisualStyleBackColor = true;
            // 
            // panelistID1
            // 
            this.panelistID1.Enabled = false;
            this.panelistID1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistID1.Location = new System.Drawing.Point(64, 30);
            this.panelistID1.MaxLength = 8;
            this.panelistID1.Name = "panelistID1";
            this.panelistID1.Size = new System.Drawing.Size(194, 23);
            this.panelistID1.TabIndex = 31;
            // 
            // panelistFN1
            // 
            this.panelistFN1.Enabled = false;
            this.panelistFN1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelistFN1.Location = new System.Drawing.Point(218, 4);
            this.panelistFN1.Name = "panelistFN1";
            this.panelistFN1.Size = new System.Drawing.Size(101, 23);
            this.panelistFN1.TabIndex = 29;
            // 
            // labelPanelistID1
            // 
            this.labelPanelistID1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistID1.Location = new System.Drawing.Point(2, 30);
            this.labelPanelistID1.Name = "labelPanelistID1";
            this.labelPanelistID1.Size = new System.Drawing.Size(132, 20);
            this.labelPanelistID1.TabIndex = 17;
            this.labelPanelistID1.Text = "ID Number:";
            this.labelPanelistID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPanelistName1
            // 
            this.labelPanelistName1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelistName1.Location = new System.Drawing.Point(1, 6);
            this.labelPanelistName1.Name = "labelPanelistName1";
            this.labelPanelistName1.Size = new System.Drawing.Size(116, 20);
            this.labelPanelistName1.TabIndex = 10;
            this.labelPanelistName1.Text = "Panelist 1 Name:";
            this.labelPanelistName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGroupView
            // 
            this.labelGroupView.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupView.Location = new System.Drawing.Point(8, 21);
            this.labelGroupView.Name = "labelGroupView";
            this.labelGroupView.Size = new System.Drawing.Size(263, 35);
            this.labelGroupView.TabIndex = 32;
            this.labelGroupView.Text = "Thesis Groups";
            this.labelGroupView.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // thesisGroupPanel
            // 
            this.thesisGroupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thesisGroupPanel.Controls.Add(this.redefenseCheckBox);
            this.thesisGroupPanel.Controls.Add(this.defenseCheckBox);
            this.thesisGroupPanel.Controls.Add(this.deleteGroup);
            this.thesisGroupPanel.Controls.Add(this.cancelEdits);
            this.thesisGroupPanel.Controls.Add(this.saveDetails);
            this.thesisGroupPanel.Controls.Add(this.editThesisGroup);
            this.thesisGroupPanel.Controls.Add(this.groupStartSY);
            this.thesisGroupPanel.Controls.Add(this.newThesisGroup);
            this.thesisGroupPanel.Controls.Add(this.groupStartTerm);
            this.thesisGroupPanel.Controls.Add(this.groupSection);
            this.thesisGroupPanel.Controls.Add(this.groupCourse);
            this.thesisGroupPanel.Controls.Add(this.groupThesisTitle);
            this.thesisGroupPanel.Controls.Add(this.labelGroupStartTerm);
            this.thesisGroupPanel.Controls.Add(this.labelGroupStartSY);
            this.thesisGroupPanel.Controls.Add(this.labelGroupSection);
            this.thesisGroupPanel.Controls.Add(this.labelGroupCourse);
            this.thesisGroupPanel.Controls.Add(this.labelGroupThesisTitle);
            this.thesisGroupPanel.Controls.Add(this.labelGroupControl);
            this.thesisGroupPanel.Controls.Add(this.labelEligibleNeeds);
            this.thesisGroupPanel.Location = new System.Drawing.Point(277, 3);
            this.thesisGroupPanel.Name = "thesisGroupPanel";
            this.thesisGroupPanel.Size = new System.Drawing.Size(720, 176);
            this.thesisGroupPanel.TabIndex = 33;
            // 
            // redefenseCheckBox
            // 
            this.redefenseCheckBox.BackColor = System.Drawing.Color.Silver;
            this.redefenseCheckBox.Enabled = false;
            this.redefenseCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redefenseCheckBox.Location = new System.Drawing.Point(358, 124);
            this.redefenseCheckBox.Name = "redefenseCheckBox";
            this.redefenseCheckBox.Size = new System.Drawing.Size(176, 28);
            this.redefenseCheckBox.TabIndex = 44;
            this.redefenseCheckBox.Text = "Eligible For Redefense";
            this.redefenseCheckBox.UseVisualStyleBackColor = false;
            this.redefenseCheckBox.CheckedChanged += new System.EventHandler(this.redefenseCheckBox_CheckedChanged);
            // 
            // defenseCheckBox
            // 
            this.defenseCheckBox.BackColor = System.Drawing.Color.Silver;
            this.defenseCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defenseCheckBox.Location = new System.Drawing.Point(358, 97);
            this.defenseCheckBox.Name = "defenseCheckBox";
            this.defenseCheckBox.Size = new System.Drawing.Size(176, 26);
            this.defenseCheckBox.TabIndex = 43;
            this.defenseCheckBox.Text = "Eligible For Defense";
            this.defenseCheckBox.UseVisualStyleBackColor = false;
            this.defenseCheckBox.CheckedChanged += new System.EventHandler(this.defenseCheckBox_CheckedChanged);
            // 
            // deleteGroup
            // 
            this.deleteGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteGroup.Location = new System.Drawing.Point(596, 142);
            this.deleteGroup.Name = "deleteGroup";
            this.deleteGroup.Size = new System.Drawing.Size(117, 27);
            this.deleteGroup.TabIndex = 38;
            this.deleteGroup.Text = "Delete Group";
            this.deleteGroup.UseVisualStyleBackColor = true;
            this.deleteGroup.Click += new System.EventHandler(this.deleteGroup_Click);
            // 
            // cancelEdits
            // 
            this.cancelEdits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelEdits.Location = new System.Drawing.Point(596, 42);
            this.cancelEdits.Name = "cancelEdits";
            this.cancelEdits.Size = new System.Drawing.Size(117, 27);
            this.cancelEdits.TabIndex = 37;
            this.cancelEdits.Text = "Cancel Changes";
            this.cancelEdits.UseVisualStyleBackColor = true;
            this.cancelEdits.Click += new System.EventHandler(this.cancelEdits_Click);
            // 
            // saveDetails
            // 
            this.saveDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDetails.Location = new System.Drawing.Point(596, 109);
            this.saveDetails.Name = "saveDetails";
            this.saveDetails.Size = new System.Drawing.Size(117, 27);
            this.saveDetails.TabIndex = 5;
            this.saveDetails.Text = "Save Group Details";
            this.saveDetails.UseVisualStyleBackColor = true;
            this.saveDetails.Click += new System.EventHandler(this.saveGroupDetails_Click);
            // 
            // editThesisGroup
            // 
            this.editThesisGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editThesisGroup.Location = new System.Drawing.Point(596, 75);
            this.editThesisGroup.Name = "editThesisGroup";
            this.editThesisGroup.Size = new System.Drawing.Size(117, 27);
            this.editThesisGroup.TabIndex = 35;
            this.editThesisGroup.Text = "Edit Thesis Group";
            this.editThesisGroup.UseVisualStyleBackColor = true;
            this.editThesisGroup.Click += new System.EventHandler(this.editGroupDetails_Click);
            // 
            // groupStartSY
            // 
            this.groupStartSY.Enabled = false;
            this.groupStartSY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupStartSY.Location = new System.Drawing.Point(91, 112);
            this.groupStartSY.MaxLength = 9;
            this.groupStartSY.Name = "groupStartSY";
            this.groupStartSY.Size = new System.Drawing.Size(240, 23);
            this.groupStartSY.TabIndex = 3;
            // 
            // newThesisGroup
            // 
            this.newThesisGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newThesisGroup.Location = new System.Drawing.Point(596, 8);
            this.newThesisGroup.Name = "newThesisGroup";
            this.newThesisGroup.Size = new System.Drawing.Size(117, 27);
            this.newThesisGroup.TabIndex = 34;
            this.newThesisGroup.Text = "New Thesis Group";
            this.newThesisGroup.UseVisualStyleBackColor = true;
            this.newThesisGroup.Click += new System.EventHandler(this.newThesisGroup_Click);
            // 
            // groupStartTerm
            // 
            this.groupStartTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupStartTerm.Enabled = false;
            this.groupStartTerm.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupStartTerm.FormattingEnabled = true;
            this.groupStartTerm.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.groupStartTerm.Location = new System.Drawing.Point(91, 138);
            this.groupStartTerm.Name = "groupStartTerm";
            this.groupStartTerm.Size = new System.Drawing.Size(240, 23);
            this.groupStartTerm.TabIndex = 4;
            // 
            // groupSection
            // 
            this.groupSection.Enabled = false;
            this.groupSection.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSection.Location = new System.Drawing.Point(91, 86);
            this.groupSection.MaxLength = 3;
            this.groupSection.Name = "groupSection";
            this.groupSection.Size = new System.Drawing.Size(240, 23);
            this.groupSection.TabIndex = 2;
            // 
            // groupCourse
            // 
            this.groupCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupCourse.Enabled = false;
            this.groupCourse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCourse.FormattingEnabled = true;
            this.groupCourse.Items.AddRange(new object[] {
            "THSST-1",
            "THSST-2",
            "THSST-3"});
            this.groupCourse.Location = new System.Drawing.Point(91, 59);
            this.groupCourse.Name = "groupCourse";
            this.groupCourse.Size = new System.Drawing.Size(240, 23);
            this.groupCourse.TabIndex = 1;
            // 
            // groupThesisTitle
            // 
            this.groupThesisTitle.Enabled = false;
            this.groupThesisTitle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThesisTitle.Location = new System.Drawing.Point(91, 34);
            this.groupThesisTitle.Name = "groupThesisTitle";
            this.groupThesisTitle.Size = new System.Drawing.Size(474, 23);
            this.groupThesisTitle.TabIndex = 0;
            // 
            // labelGroupStartTerm
            // 
            this.labelGroupStartTerm.AutoSize = true;
            this.labelGroupStartTerm.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupStartTerm.Location = new System.Drawing.Point(3, 141);
            this.labelGroupStartTerm.Name = "labelGroupStartTerm";
            this.labelGroupStartTerm.Size = new System.Drawing.Size(65, 15);
            this.labelGroupStartTerm.TabIndex = 5;
            this.labelGroupStartTerm.Text = "Start Term:";
            // 
            // labelGroupStartSY
            // 
            this.labelGroupStartSY.AutoSize = true;
            this.labelGroupStartSY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupStartSY.Location = new System.Drawing.Point(3, 117);
            this.labelGroupStartSY.Name = "labelGroupStartSY";
            this.labelGroupStartSY.Size = new System.Drawing.Size(50, 15);
            this.labelGroupStartSY.TabIndex = 4;
            this.labelGroupStartSY.Text = "Start SY:";
            // 
            // labelGroupSection
            // 
            this.labelGroupSection.AutoSize = true;
            this.labelGroupSection.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupSection.Location = new System.Drawing.Point(3, 89);
            this.labelGroupSection.Name = "labelGroupSection";
            this.labelGroupSection.Size = new System.Drawing.Size(87, 15);
            this.labelGroupSection.TabIndex = 3;
            this.labelGroupSection.Text = "Thesis Section:";
            // 
            // labelGroupCourse
            // 
            this.labelGroupCourse.AutoSize = true;
            this.labelGroupCourse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupCourse.Location = new System.Drawing.Point(3, 64);
            this.labelGroupCourse.Name = "labelGroupCourse";
            this.labelGroupCourse.Size = new System.Drawing.Size(86, 15);
            this.labelGroupCourse.TabIndex = 2;
            this.labelGroupCourse.Text = "Thesis Course:";
            // 
            // labelGroupThesisTitle
            // 
            this.labelGroupThesisTitle.AutoSize = true;
            this.labelGroupThesisTitle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupThesisTitle.Location = new System.Drawing.Point(3, 37);
            this.labelGroupThesisTitle.Name = "labelGroupThesisTitle";
            this.labelGroupThesisTitle.Size = new System.Drawing.Size(72, 15);
            this.labelGroupThesisTitle.TabIndex = 1;
            this.labelGroupThesisTitle.Text = "Thesis Title:";
            // 
            // labelGroupControl
            // 
            this.labelGroupControl.AutoSize = true;
            this.labelGroupControl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupControl.Location = new System.Drawing.Point(5, 2);
            this.labelGroupControl.Name = "labelGroupControl";
            this.labelGroupControl.Size = new System.Drawing.Size(154, 29);
            this.labelGroupControl.TabIndex = 0;
            this.labelGroupControl.Text = "Group Control";
            // 
            // labelEligibleNeeds
            // 
            this.labelEligibleNeeds.BackColor = System.Drawing.Color.Silver;
            this.labelEligibleNeeds.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEligibleNeeds.ForeColor = System.Drawing.Color.Firebrick;
            this.labelEligibleNeeds.Location = new System.Drawing.Point(341, 65);
            this.labelEligibleNeeds.Name = "labelEligibleNeeds";
            this.labelEligibleNeeds.Size = new System.Drawing.Size(224, 95);
            this.labelEligibleNeeds.TabIndex = 45;
            this.labelEligibleNeeds.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // thesisGroupTreeView
            // 
            this.thesisGroupTreeView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thesisGroupTreeView.Location = new System.Drawing.Point(8, 50);
            this.thesisGroupTreeView.Name = "thesisGroupTreeView";
            this.thesisGroupTreeView.Size = new System.Drawing.Size(263, 598);
            this.thesisGroupTreeView.TabIndex = 35;
            this.thesisGroupTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.changeSelectedGroup);
            // 
            // ThesisGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.thesisGroupPanel);
            this.Controls.Add(this.thesisGroupTreeView);
            this.Controls.Add(this.panelistControl);
            this.Controls.Add(this.labelGroupView);
            this.Controls.Add(this.studentsPanel);
            this.DoubleBuffered = true;
            this.Name = "ThesisGroupControl";
            this.Size = new System.Drawing.Size(1000, 665);
            this.studentsPanel.ResumeLayout(false);
            this.studentsPanel.PerformLayout();
            this.student4.ResumeLayout(false);
            this.student4.PerformLayout();
            this.student3.ResumeLayout(false);
            this.student3.PerformLayout();
            this.student2.ResumeLayout(false);
            this.student2.PerformLayout();
            this.student1.ResumeLayout(false);
            this.student1.PerformLayout();
            this.panelistControl.ResumeLayout(false);
            this.panelistControl.PerformLayout();
            this.panelist4.ResumeLayout(false);
            this.panelist4.PerformLayout();
            this.panelist3.ResumeLayout(false);
            this.panelist3.PerformLayout();
            this.panelist2.ResumeLayout(false);
            this.panelist2.PerformLayout();
            this.panelist1.ResumeLayout(false);
            this.panelist1.PerformLayout();
            this.thesisGroupPanel.ResumeLayout(false);
            this.thesisGroupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // thesis group
        private System.Windows.Forms.Panel thesisGroupPanel;

        private System.Windows.Forms.Label labelGroupView; // treeview
        private System.Windows.Forms.Label labelGroupStartSY;
        private System.Windows.Forms.Label labelGroupStartTerm;
        private System.Windows.Forms.Label labelGroupControl;
        private System.Windows.Forms.Label labelGroupThesisTitle;
        private System.Windows.Forms.Label labelGroupCourse;
        private System.Windows.Forms.Label labelGroupSection;

        private System.Windows.Forms.TextBox groupThesisTitle;
        private System.Windows.Forms.ComboBox groupCourse;
        private System.Windows.Forms.TextBox groupSection;
        private System.Windows.Forms.TextBox groupStartSY;
        private System.Windows.Forms.ComboBox groupStartTerm;
        
        private System.Windows.Forms.TreeView thesisGroupTreeView;

        private System.Windows.Forms.Button newThesisGroup;
        private System.Windows.Forms.Button editThesisGroup;
        private System.Windows.Forms.Button cancelEdits;
        private System.Windows.Forms.Button saveDetails;
        private System.Windows.Forms.Button deleteGroup;

        private System.Windows.Forms.CheckBox defenseCheckBox;
        private System.Windows.Forms.CheckBox redefenseCheckBox;

        // student panels
        private System.Windows.Forms.Panel studentsPanel; // main panel
        private System.Windows.Forms.Panel student1; // per student
        private System.Windows.Forms.Panel student2;
        private System.Windows.Forms.Panel student3;
        private System.Windows.Forms.Panel student4;

        // student labels
        private System.Windows.Forms.Label labelMemberControl; // big font size label saying "Student Control"
        private System.Windows.Forms.Label labelMemberComma1;
        private System.Windows.Forms.Label labelMemberComma2;
        private System.Windows.Forms.Label labelMemberComma3;
        private System.Windows.Forms.Label labelMemberComma4;
        private System.Windows.Forms.Label labelMemberName1;
        private System.Windows.Forms.Label labelMemberName2;
        private System.Windows.Forms.Label labelMemberName3;
        private System.Windows.Forms.Label labelMemberName4;
        private System.Windows.Forms.Label labelMemberID1;
        private System.Windows.Forms.Label labelMemberID2;
        private System.Windows.Forms.Label labelMemberID3;
        private System.Windows.Forms.Label labelMemberID4;

        // student textboxes
        private System.Windows.Forms.TextBox studentID1;
        private System.Windows.Forms.TextBox studentFN1;
        private System.Windows.Forms.TextBox studentMI1;
        private System.Windows.Forms.TextBox studentLN1;

        private System.Windows.Forms.TextBox studentID2;
        private System.Windows.Forms.TextBox studentFN2;
        private System.Windows.Forms.TextBox studentMI2;
        private System.Windows.Forms.TextBox studentLN2;

        private System.Windows.Forms.TextBox studentID3;
        private System.Windows.Forms.TextBox studentFN3;
        private System.Windows.Forms.TextBox studentMI3;
        private System.Windows.Forms.TextBox studentLN3;

        private System.Windows.Forms.TextBox studentID4;
        private System.Windows.Forms.TextBox studentFN4;
        private System.Windows.Forms.TextBox studentMI4;
        private System.Windows.Forms.TextBox studentLN4;

        // student buttons
        private System.Windows.Forms.Button saveStudent1;
        private System.Windows.Forms.Button editStudent1;
        private System.Windows.Forms.Button deleteStudent1;

        private System.Windows.Forms.Button saveStudent2;
        private System.Windows.Forms.Button editStudent2;
        private System.Windows.Forms.Button deleteStudent2;

        private System.Windows.Forms.Button saveStudent3;
        private System.Windows.Forms.Button editStudent3;
        private System.Windows.Forms.Button deleteStudent3;

        private System.Windows.Forms.Button saveStudent4;
        private System.Windows.Forms.Button editStudent4;
        private System.Windows.Forms.Button deleteStudent4;

        // panelist panels lelz
        private System.Windows.Forms.Panel panelistControl; // main panel
        private System.Windows.Forms.Panel panelist1; // per panelist
        private System.Windows.Forms.Panel panelist2;
        private System.Windows.Forms.Panel panelist3;
        private System.Windows.Forms.Panel panelist4;

        // panelist labels
        private System.Windows.Forms.Label labelPanelistControl; // big font size label saying "Panelist Control"
        private System.Windows.Forms.Label labelPanelistComma1;
        private System.Windows.Forms.Label labelPanelistComma2;
        private System.Windows.Forms.Label labelPanelistComma3;
        private System.Windows.Forms.Label labelPanelistComma4;
        private System.Windows.Forms.Label labelPanelistName1;
        private System.Windows.Forms.Label labelPanelistName2;
        private System.Windows.Forms.Label labelPanelistName3;
        private System.Windows.Forms.Label labelPanelistName4;
        private System.Windows.Forms.Label labelPanelistID1;
        private System.Windows.Forms.Label labelPanelistID2;
        private System.Windows.Forms.Label labelPanelistID3;
        private System.Windows.Forms.Label labelPanelistID4;
        private System.Windows.Forms.Label labelSelectAdviser;

        // panelist textboxes
        private System.Windows.Forms.TextBox panelistID1;
        private System.Windows.Forms.TextBox panelistFN1;
        private System.Windows.Forms.TextBox panelistMI1;
        private System.Windows.Forms.TextBox panelistLN1;

        private System.Windows.Forms.TextBox panelistID2;
        private System.Windows.Forms.TextBox panelistFN2;
        private System.Windows.Forms.TextBox panelistMI2;
        private System.Windows.Forms.TextBox panelistLN2;

        private System.Windows.Forms.TextBox panelistID3;
        private System.Windows.Forms.TextBox panelistFN3;
        private System.Windows.Forms.TextBox panelistMI3;
        private System.Windows.Forms.TextBox panelistLN3;

        private System.Windows.Forms.TextBox panelistID4;
        private System.Windows.Forms.TextBox panelistFN4;
        private System.Windows.Forms.TextBox panelistMI4;
        private System.Windows.Forms.TextBox panelistLN4;


        // panelist buttons
        private System.Windows.Forms.Button selPanelist1;
        private System.Windows.Forms.Button delPanelist1;
        private System.Windows.Forms.Button savePanelist1;
        private System.Windows.Forms.Button editPanelist1;

        private System.Windows.Forms.Button selPanelist2;
        private System.Windows.Forms.Button delPanelist2;
        private System.Windows.Forms.Button savePanelist2;
        private System.Windows.Forms.Button editPanelist2;

        private System.Windows.Forms.Button selPanelist3;
        private System.Windows.Forms.Button delPanelist3;
        private System.Windows.Forms.Button savePanelist3;
        private System.Windows.Forms.Button editPanelist3;

        private System.Windows.Forms.Button selPanelist4;
        private System.Windows.Forms.Button delPanelist4;
        private System.Windows.Forms.Button savePanelist4;
        private System.Windows.Forms.Button editPanelist4;

        // select panelist comboboxes
        private System.Windows.Forms.ComboBox selectPanelist1;
        private System.Windows.Forms.ComboBox selectPanelist2;
        private System.Windows.Forms.ComboBox selectPanelist3;
        private System.Windows.Forms.ComboBox selectPanelist4;
        private System.Windows.Forms.ComboBox selectAdviser;
        private Label labelEligibleNeeds;
    }
}
