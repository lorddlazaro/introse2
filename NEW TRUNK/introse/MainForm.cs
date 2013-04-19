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
    public partial class MainForm : Form
    {
        private FormResetWizard formResetWizard;
        private DefenseSchedulesViewerForm defenseSchedulesViewerForm;
     
        public MainForm()
        {
            InitializeComponent();
            scheduleEditorControl.containerParent = this;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: freeTimeViewerControl.RefreshAll(); break;
                case 1: scheduleEditorControl.RefreshAll(); break;
                case 2: thesisGroupControl.RefreshAll(); break;
            }
        }
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripMenuItem_ViewDefenseSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                defenseSchedulesViewerForm.Close();
            }
            catch (Exception ex1) { }
            defenseSchedulesViewerForm = new DefenseSchedulesViewerForm();
        }
        private void toolStripMenuItem_Reset_Click(object sender, EventArgs e)
        {
            try 
            {
                formResetWizard.Close();
            }
            catch (Exception ex2) { }
            formResetWizard = new FormResetWizard(freeTimeViewerControl, scheduleEditorControl, thesisGroupControl);
        }
    }
}