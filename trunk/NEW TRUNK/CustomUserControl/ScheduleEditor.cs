using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    public partial class ScheduleEditor : UserControl
    {
        private String currStudent;
        private String currPanelist;
        private ScheduleEditorDataManager schedEditorDM;

        public ScheduleEditor()
        {
            InitializeComponent();

            currStudent = "";
            currPanelist = "";
            schedEditorDM = new ScheduleEditorDataManager();
            studentTreeView.Show();
            panelistTreeView.Hide();
            InitStudentListBox();
        }

        private void InitStudentListBox() 
        {
            schedEditorDM.UpdateStudentList(studentTreeView.Nodes);
        }

        private void studentTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                currStudent = e.Node.Name;
                schedEditorDM.RefreshStudentClassScheds(currStudent);
                rtBoxClassScheds.Text = schedEditorDM.TextClassScheds;
                schedEditorDM.RefreshStudentEvents(e.Node.Name);
                rtBoxEvents.Text = schedEditorDM.TextEvents;
            }
        }

        private void panelistTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1) 
            {
                currPanelist = e.Node.Name;
                schedEditorDM.RefreshPanelistClassScheds(currPanelist);
                rtBoxClassScheds.Text = schedEditorDM.TextClassScheds;
                schedEditorDM.RefreshPanelistEvents(e.Node.Name);
                rtBoxEvents.Text = schedEditorDM.TextEvents;
            }
        }


        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                currPanelist = "";
                btnSwitchView.Text = "Switch to Students";
                studentTreeView.Hide();
                panelistTreeView.Show();
                schedEditorDM.UpdatePanelistList(panelistTreeView.Nodes);
            }
            else 
            {
                currStudent = "";
                btnSwitchView.Text = "Switch to Panelists";
                studentTreeView.Show();
                panelistTreeView.Hide();
                schedEditorDM.UpdateStudentList(studentTreeView.Nodes);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                schedEditorDM.RefreshStudentClassScheds(currStudent);
                rtBoxClassScheds.Text = schedEditorDM.TextClassScheds;
                schedEditorDM.RefreshStudentEvents(currStudent);
                rtBoxEvents.Text = schedEditorDM.TextEvents;
            }
            else 
            {
                schedEditorDM.RefreshPanelistClassScheds(currPanelist);
                rtBoxClassScheds.Text = schedEditorDM.TextClassScheds;
                schedEditorDM.RefreshPanelistEvents(currPanelist);
                rtBoxEvents.Text = schedEditorDM.TextEvents;
            }
        }

        
        

    }
}
