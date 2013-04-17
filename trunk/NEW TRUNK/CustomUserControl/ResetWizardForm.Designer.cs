namespace CustomUserControl
{
    partial class FormResetWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResetWizard));
            this.tabControlResetWizard = new CustomUserControl.ResetWizardTabControl();
            this.tabPageStartPage = new System.Windows.Forms.TabPage();
            this.labelStartPageWarning = new System.Windows.Forms.Label();
            this.labelStartPageText = new System.Windows.Forms.Label();
            this.labelStartPageHeader = new System.Windows.Forms.Label();
            this.pictureBoxStartPage = new System.Windows.Forms.PictureBox();
            this.labelStartPageDivider = new System.Windows.Forms.Label();
            this.buttonStartPageNext = new System.Windows.Forms.Button();
            this.tabPageGroupSelection = new System.Windows.Forms.TabPage();
            this.buttonGroupSelectionBack = new System.Windows.Forms.Button();
            this.labelGroupSelectionDividerTop = new System.Windows.Forms.Label();
            this.labelGroupSelectionNote = new System.Windows.Forms.Label();
            this.labelGroupSelectionText = new System.Windows.Forms.Label();
            this.labelGroupSelectionHeader = new System.Windows.Forms.Label();
            this.labelGroupSelectionDividerBottom = new System.Windows.Forms.Label();
            this.treeViewGroupList3 = new System.Windows.Forms.TreeView();
            this.treeViewGroupList2 = new System.Windows.Forms.TreeView();
            this.treeViewGroupList1 = new System.Windows.Forms.TreeView();
            this.labelTreeView3 = new System.Windows.Forms.Label();
            this.labelTreeView2 = new System.Windows.Forms.Label();
            this.labelTreeView1 = new System.Windows.Forms.Label();
            this.buttonGroupSelectionNext = new System.Windows.Forms.Button();
            this.tabPageResetting = new System.Windows.Forms.TabPage();
            this.buttonResettingExit = new System.Windows.Forms.Button();
            this.labelResetting = new System.Windows.Forms.Label();
            this.progressBarResetting = new System.Windows.Forms.ProgressBar();
            this.tabControlResetWizard.SuspendLayout();
            this.tabPageStartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartPage)).BeginInit();
            this.tabPageGroupSelection.SuspendLayout();
            this.tabPageResetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlResetWizard
            // 
            this.tabControlResetWizard.Controls.Add(this.tabPageStartPage);
            this.tabControlResetWizard.Controls.Add(this.tabPageGroupSelection);
            this.tabControlResetWizard.Controls.Add(this.tabPageResetting);
            this.tabControlResetWizard.Location = new System.Drawing.Point(0, 0);
            this.tabControlResetWizard.Multiline = true;
            this.tabControlResetWizard.Name = "tabControlResetWizard";
            this.tabControlResetWizard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControlResetWizard.SelectedIndex = 0;
            this.tabControlResetWizard.Size = new System.Drawing.Size(722, 400);
            this.tabControlResetWizard.TabIndex = 0;
            this.tabControlResetWizard.SelectedIndexChanged += new System.EventHandler(this.tabControlResetWizard_SelectedIndexChanged);
            // 
            // tabPageStartPage
            // 
            this.tabPageStartPage.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStartPage.Controls.Add(this.labelStartPageWarning);
            this.tabPageStartPage.Controls.Add(this.labelStartPageText);
            this.tabPageStartPage.Controls.Add(this.labelStartPageHeader);
            this.tabPageStartPage.Controls.Add(this.pictureBoxStartPage);
            this.tabPageStartPage.Controls.Add(this.labelStartPageDivider);
            this.tabPageStartPage.Controls.Add(this.buttonStartPageNext);
            this.tabPageStartPage.Location = new System.Drawing.Point(4, 22);
            this.tabPageStartPage.Name = "tabPageStartPage";
            this.tabPageStartPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartPage.Size = new System.Drawing.Size(714, 374);
            this.tabPageStartPage.TabIndex = 0;
            this.tabPageStartPage.Text = "Start Page";
            // 
            // labelStartPageWarning
            // 
            this.labelStartPageWarning.AutoSize = true;
            this.labelStartPageWarning.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartPageWarning.ForeColor = System.Drawing.Color.Firebrick;
            this.labelStartPageWarning.Location = new System.Drawing.Point(211, 306);
            this.labelStartPageWarning.Name = "labelStartPageWarning";
            this.labelStartPageWarning.Size = new System.Drawing.Size(402, 19);
            this.labelStartPageWarning.TabIndex = 5;
            this.labelStartPageWarning.Text = "Warning: This process is completely irreversible once begun.";
            // 
            // labelStartPageText
            // 
            this.labelStartPageText.AutoSize = true;
            this.labelStartPageText.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartPageText.Location = new System.Drawing.Point(212, 64);
            this.labelStartPageText.Name = "labelStartPageText";
            this.labelStartPageText.Size = new System.Drawing.Size(465, 180);
            this.labelStartPageText.TabIndex = 4;
            this.labelStartPageText.Text = resources.GetString("labelStartPageText.Text");
            // 
            // labelStartPageHeader
            // 
            this.labelStartPageHeader.AutoSize = true;
            this.labelStartPageHeader.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartPageHeader.Location = new System.Drawing.Point(179, 10);
            this.labelStartPageHeader.Name = "labelStartPageHeader";
            this.labelStartPageHeader.Size = new System.Drawing.Size(460, 45);
            this.labelStartPageHeader.TabIndex = 3;
            this.labelStartPageHeader.Text = "Welcome to the Reset Wizard";
            // 
            // pictureBoxStartPage
            // 
            this.pictureBoxStartPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxStartPage.Image = global::CustomUserControl.Properties.Resources.wizard;
            this.pictureBoxStartPage.Location = new System.Drawing.Point(-4, -22);
            this.pictureBoxStartPage.Name = "pictureBoxStartPage";
            this.pictureBoxStartPage.Size = new System.Drawing.Size(177, 398);
            this.pictureBoxStartPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStartPage.TabIndex = 2;
            this.pictureBoxStartPage.TabStop = false;
            // 
            // labelStartPageDivider
            // 
            this.labelStartPageDivider.AutoSize = true;
            this.labelStartPageDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStartPageDivider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelStartPageDivider.Location = new System.Drawing.Point(179, 345);
            this.labelStartPageDivider.MaximumSize = new System.Drawing.Size(0, 3);
            this.labelStartPageDivider.MinimumSize = new System.Drawing.Size(525, 0);
            this.labelStartPageDivider.Name = "labelStartPageDivider";
            this.labelStartPageDivider.Size = new System.Drawing.Size(525, 3);
            this.labelStartPageDivider.TabIndex = 1;
            this.labelStartPageDivider.Text = "divider";
            // 
            // buttonStartPageNext
            // 
            this.buttonStartPageNext.Location = new System.Drawing.Point(587, 351);
            this.buttonStartPageNext.Name = "buttonStartPageNext";
            this.buttonStartPageNext.Size = new System.Drawing.Size(111, 23);
            this.buttonStartPageNext.TabIndex = 0;
            this.buttonStartPageNext.Text = "Next >";
            this.buttonStartPageNext.UseVisualStyleBackColor = true;
            this.buttonStartPageNext.Click += new System.EventHandler(this.buttonStartPageNext_Click);
            // 
            // tabPageGroupSelection
            // 
            this.tabPageGroupSelection.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGroupSelection.Controls.Add(this.buttonGroupSelectionBack);
            this.tabPageGroupSelection.Controls.Add(this.labelGroupSelectionDividerTop);
            this.tabPageGroupSelection.Controls.Add(this.labelGroupSelectionNote);
            this.tabPageGroupSelection.Controls.Add(this.labelGroupSelectionText);
            this.tabPageGroupSelection.Controls.Add(this.labelGroupSelectionHeader);
            this.tabPageGroupSelection.Controls.Add(this.labelGroupSelectionDividerBottom);
            this.tabPageGroupSelection.Controls.Add(this.treeViewGroupList3);
            this.tabPageGroupSelection.Controls.Add(this.treeViewGroupList2);
            this.tabPageGroupSelection.Controls.Add(this.treeViewGroupList1);
            this.tabPageGroupSelection.Controls.Add(this.labelTreeView3);
            this.tabPageGroupSelection.Controls.Add(this.labelTreeView2);
            this.tabPageGroupSelection.Controls.Add(this.labelTreeView1);
            this.tabPageGroupSelection.Controls.Add(this.buttonGroupSelectionNext);
            this.tabPageGroupSelection.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroupSelection.Name = "tabPageGroupSelection";
            this.tabPageGroupSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroupSelection.Size = new System.Drawing.Size(714, 374);
            this.tabPageGroupSelection.TabIndex = 1;
            this.tabPageGroupSelection.Text = "Group Selection";
            // 
            // buttonGroupSelectionBack
            // 
            this.buttonGroupSelectionBack.Location = new System.Drawing.Point(460, 351);
            this.buttonGroupSelectionBack.Name = "buttonGroupSelectionBack";
            this.buttonGroupSelectionBack.Size = new System.Drawing.Size(111, 23);
            this.buttonGroupSelectionBack.TabIndex = 15;
            this.buttonGroupSelectionBack.Text = "< Back";
            this.buttonGroupSelectionBack.UseVisualStyleBackColor = true;
            this.buttonGroupSelectionBack.Click += new System.EventHandler(this.buttonGroupSelectionBack_Click);
            // 
            // labelGroupSelectionDividerTop
            // 
            this.labelGroupSelectionDividerTop.AutoSize = true;
            this.labelGroupSelectionDividerTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGroupSelectionDividerTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGroupSelectionDividerTop.Location = new System.Drawing.Point(6, 77);
            this.labelGroupSelectionDividerTop.MaximumSize = new System.Drawing.Size(0, 3);
            this.labelGroupSelectionDividerTop.MinimumSize = new System.Drawing.Size(700, 0);
            this.labelGroupSelectionDividerTop.Name = "labelGroupSelectionDividerTop";
            this.labelGroupSelectionDividerTop.Size = new System.Drawing.Size(700, 3);
            this.labelGroupSelectionDividerTop.TabIndex = 14;
            this.labelGroupSelectionDividerTop.Text = "divider";
            // 
            // labelGroupSelectionNote
            // 
            this.labelGroupSelectionNote.AutoSize = true;
            this.labelGroupSelectionNote.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupSelectionNote.ForeColor = System.Drawing.Color.Firebrick;
            this.labelGroupSelectionNote.Location = new System.Drawing.Point(352, 62);
            this.labelGroupSelectionNote.Name = "labelGroupSelectionNote";
            this.labelGroupSelectionNote.Size = new System.Drawing.Size(346, 15);
            this.labelGroupSelectionNote.TabIndex = 13;
            this.labelGroupSelectionNote.Text = "Note: Thesis Groups to advance from THSST-3 will be removed.";
            // 
            // labelGroupSelectionText
            // 
            this.labelGroupSelectionText.AutoSize = true;
            this.labelGroupSelectionText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupSelectionText.Location = new System.Drawing.Point(22, 32);
            this.labelGroupSelectionText.Name = "labelGroupSelectionText";
            this.labelGroupSelectionText.Size = new System.Drawing.Size(407, 30);
            this.labelGroupSelectionText.TabIndex = 12;
            this.labelGroupSelectionText.Text = "Please select which Thesis Groups will move on to the next THSST Course.\r\nUncheck" +
                "ed groups will retain their current THSST course.";
            // 
            // labelGroupSelectionHeader
            // 
            this.labelGroupSelectionHeader.AutoSize = true;
            this.labelGroupSelectionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupSelectionHeader.Location = new System.Drawing.Point(5, 3);
            this.labelGroupSelectionHeader.Name = "labelGroupSelectionHeader";
            this.labelGroupSelectionHeader.Size = new System.Drawing.Size(288, 29);
            this.labelGroupSelectionHeader.TabIndex = 11;
            this.labelGroupSelectionHeader.Text = "Advancing Thesis Groups";
            // 
            // labelGroupSelectionDividerBottom
            // 
            this.labelGroupSelectionDividerBottom.AutoSize = true;
            this.labelGroupSelectionDividerBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGroupSelectionDividerBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGroupSelectionDividerBottom.Location = new System.Drawing.Point(6, 345);
            this.labelGroupSelectionDividerBottom.MaximumSize = new System.Drawing.Size(0, 3);
            this.labelGroupSelectionDividerBottom.MinimumSize = new System.Drawing.Size(700, 0);
            this.labelGroupSelectionDividerBottom.Name = "labelGroupSelectionDividerBottom";
            this.labelGroupSelectionDividerBottom.Size = new System.Drawing.Size(700, 3);
            this.labelGroupSelectionDividerBottom.TabIndex = 10;
            this.labelGroupSelectionDividerBottom.Text = "divider";
            // 
            // treeViewGroupList3
            // 
            this.treeViewGroupList3.CheckBoxes = true;
            this.treeViewGroupList3.FullRowSelect = true;
            this.treeViewGroupList3.HotTracking = true;
            this.treeViewGroupList3.Location = new System.Drawing.Point(478, 102);
            this.treeViewGroupList3.Name = "treeViewGroupList3";
            this.treeViewGroupList3.ShowRootLines = false;
            this.treeViewGroupList3.Size = new System.Drawing.Size(220, 235);
            this.treeViewGroupList3.TabIndex = 9;
            // 
            // treeViewGroupList2
            // 
            this.treeViewGroupList2.CheckBoxes = true;
            this.treeViewGroupList2.FullRowSelect = true;
            this.treeViewGroupList2.HotTracking = true;
            this.treeViewGroupList2.Location = new System.Drawing.Point(245, 102);
            this.treeViewGroupList2.Name = "treeViewGroupList2";
            this.treeViewGroupList2.ShowRootLines = false;
            this.treeViewGroupList2.Size = new System.Drawing.Size(220, 235);
            this.treeViewGroupList2.TabIndex = 8;
            // 
            // treeViewGroupList1
            // 
            this.treeViewGroupList1.CheckBoxes = true;
            this.treeViewGroupList1.FullRowSelect = true;
            this.treeViewGroupList1.HotTracking = true;
            this.treeViewGroupList1.Location = new System.Drawing.Point(10, 102);
            this.treeViewGroupList1.Name = "treeViewGroupList1";
            this.treeViewGroupList1.ShowRootLines = false;
            this.treeViewGroupList1.Size = new System.Drawing.Size(220, 235);
            this.treeViewGroupList1.TabIndex = 7;
            // 
            // labelTreeView3
            // 
            this.labelTreeView3.AutoSize = true;
            this.labelTreeView3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTreeView3.Location = new System.Drawing.Point(480, 80);
            this.labelTreeView3.Name = "labelTreeView3";
            this.labelTreeView3.Size = new System.Drawing.Size(203, 19);
            this.labelTreeView3.TabIndex = 6;
            this.labelTreeView3.Text = "THSST-3 Groups to be Deleted";
            // 
            // labelTreeView2
            // 
            this.labelTreeView2.AutoSize = true;
            this.labelTreeView2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTreeView2.Location = new System.Drawing.Point(290, 80);
            this.labelTreeView2.Name = "labelTreeView2";
            this.labelTreeView2.Size = new System.Drawing.Size(134, 19);
            this.labelTreeView2.TabIndex = 5;
            this.labelTreeView2.Text = "THSST-2 -> THSST-3";
            // 
            // labelTreeView1
            // 
            this.labelTreeView1.AutoSize = true;
            this.labelTreeView1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTreeView1.Location = new System.Drawing.Point(51, 80);
            this.labelTreeView1.Name = "labelTreeView1";
            this.labelTreeView1.Size = new System.Drawing.Size(134, 19);
            this.labelTreeView1.TabIndex = 4;
            this.labelTreeView1.Text = "THSST-1 -> THSST-2";
            // 
            // buttonGroupSelectionNext
            // 
            this.buttonGroupSelectionNext.Location = new System.Drawing.Point(587, 351);
            this.buttonGroupSelectionNext.Name = "buttonGroupSelectionNext";
            this.buttonGroupSelectionNext.Size = new System.Drawing.Size(111, 23);
            this.buttonGroupSelectionNext.TabIndex = 0;
            this.buttonGroupSelectionNext.Text = "Next >";
            this.buttonGroupSelectionNext.UseVisualStyleBackColor = true;
            this.buttonGroupSelectionNext.Click += new System.EventHandler(this.buttonGroupSelectionNext_Click);
            // 
            // tabPageResetting
            // 
            this.tabPageResetting.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageResetting.Controls.Add(this.buttonResettingExit);
            this.tabPageResetting.Controls.Add(this.labelResetting);
            this.tabPageResetting.Controls.Add(this.progressBarResetting);
            this.tabPageResetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageResetting.Name = "tabPageResetting";
            this.tabPageResetting.Size = new System.Drawing.Size(714, 374);
            this.tabPageResetting.TabIndex = 2;
            this.tabPageResetting.Text = "Resetting";
            // 
            // buttonResettingExit
            // 
            this.buttonResettingExit.Location = new System.Drawing.Point(587, 351);
            this.buttonResettingExit.Name = "buttonResettingExit";
            this.buttonResettingExit.Size = new System.Drawing.Size(111, 23);
            this.buttonResettingExit.TabIndex = 3;
            this.buttonResettingExit.Text = "Exit";
            this.buttonResettingExit.UseVisualStyleBackColor = true;
            this.buttonResettingExit.Click += new System.EventHandler(this.buttonResettingExit_Click);
            // 
            // labelResetting
            // 
            this.labelResetting.AutoSize = true;
            this.labelResetting.Location = new System.Drawing.Point(13, 19);
            this.labelResetting.Name = "labelResetting";
            this.labelResetting.Size = new System.Drawing.Size(106, 13);
            this.labelResetting.TabIndex = 2;
            this.labelResetting.Text = "Resetting in progress";
            // 
            // progressBarResetting
            // 
            this.progressBarResetting.Location = new System.Drawing.Point(16, 46);
            this.progressBarResetting.Name = "progressBarResetting";
            this.progressBarResetting.Size = new System.Drawing.Size(674, 23);
            this.progressBarResetting.TabIndex = 0;
            // 
            // FormResetWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 374);
            this.Controls.Add(this.tabControlResetWizard);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(730, 412);
            this.MinimizeBox = false;
            this.Name = "FormResetWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Wizard";
            this.TopMost = true;
            this.tabControlResetWizard.ResumeLayout(false);
            this.tabPageStartPage.ResumeLayout(false);
            this.tabPageStartPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartPage)).EndInit();
            this.tabPageGroupSelection.ResumeLayout(false);
            this.tabPageGroupSelection.PerformLayout();
            this.tabPageResetting.ResumeLayout(false);
            this.tabPageResetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ResetWizardTabControl tabControlResetWizard;
        private System.Windows.Forms.ProgressBar progressBarResetting;
        private System.Windows.Forms.PictureBox pictureBoxStartPage;
        private System.Windows.Forms.TabPage tabPageStartPage;
        private System.Windows.Forms.TabPage tabPageGroupSelection;
        private System.Windows.Forms.TabPage tabPageResetting;
        private System.Windows.Forms.Button buttonGroupSelectionNext;
        private System.Windows.Forms.Button buttonStartPageNext;
        private System.Windows.Forms.Button buttonResettingExit;
        private System.Windows.Forms.Button buttonGroupSelectionBack;
        private System.Windows.Forms.TreeView treeViewGroupList3;
        private System.Windows.Forms.TreeView treeViewGroupList2;
        private System.Windows.Forms.TreeView treeViewGroupList1;
        private System.Windows.Forms.Label labelResetting;
        private System.Windows.Forms.Label labelTreeView3;
        private System.Windows.Forms.Label labelTreeView2;
        private System.Windows.Forms.Label labelTreeView1;
        private System.Windows.Forms.Label labelStartPageDivider;
        private System.Windows.Forms.Label labelStartPageText;
        private System.Windows.Forms.Label labelStartPageHeader;
        private System.Windows.Forms.Label labelStartPageWarning;
        private System.Windows.Forms.Label labelGroupSelectionNote;
        private System.Windows.Forms.Label labelGroupSelectionText;
        private System.Windows.Forms.Label labelGroupSelectionHeader;
        private System.Windows.Forms.Label labelGroupSelectionDividerBottom;
        private System.Windows.Forms.Label labelGroupSelectionDividerTop;
    }
}