using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CustomUserControl;

namespace introse
{
    public partial class Form1 : Form
    {
        private FormResetWizard formResetWizard;
        private DefenseSchedulesViewerForm defenseSchedulesViewerForm;
     
        public Form1()
        {
            InitializeComponent();
            scheduleEditor2.containerParent = this;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex) 
            {
                case 0: freeTimeViewer.RefreshAll(); break;
                case 1: scheduleEditor2.RefreshAll(); break;
                //case 2: thesisGroupControl1.RefreshAll(); break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewDefenseSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                defenseSchedulesViewerForm.Close();
            }
            catch (Exception ex1) { }
            defenseSchedulesViewerForm = new DefenseSchedulesViewerForm();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                formResetWizard.Close();
            }
            catch (Exception ex2) { }
            formResetWizard = new FormResetWizard();
        }

        private void freeTimeViewer_Load(object sender, EventArgs e)
        {

        }
    }
}