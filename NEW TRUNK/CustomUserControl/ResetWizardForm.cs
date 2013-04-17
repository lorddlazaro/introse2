using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    public partial class FormResetWizard : Form
    {
        DBce DBHandler;

        public FormResetWizard()
        {
            InitializeComponent();
            DBHandler = new DBce();
            Show();
        }

        // Initialization Methods
        private void PrepareListData()
        {
            FillCheckedBoxList(treeViewGroupList1, 1);
            FillCheckedBoxList(treeViewGroupList2, 2);
            FillCheckedBoxList(treeViewGroupList3, 3);
        }
        private void FillCheckedBoxList(TreeView tree, int course)
        {
            List<String>[] list;
            TreeNode tempNode;

            String query = "select thesisgroupid, title from thesisgroup where course = 'THSST-" + course + "';";
            list = DBHandler.Select(query, 2);

            TreeNodeCollection nodes = tree.Nodes;
            nodes.Clear();

            for (int i = 0; i < list[0].Count(); i++)
            {
                tempNode = new TreeNode();

                tempNode.Checked = true;
                tempNode.Name = list[0].ElementAt(i);
                tempNode.Text = list[1].ElementAt(i);

                nodes.Add(tempNode);
            }
        }

        // Refreshers
        private int RefreshProgressLabel(String labelText, int stepsLeft) 
        {
            labelResetting.Text = labelText;
            return stepsLeft - 1;
        }

        // Event Listeners
        private void buttonResettingExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonGroupSelectionNext_Click(object sender, EventArgs e)
        {
            tabControlResetWizard.SelectedIndex = 2;
            buttonResettingExit.Enabled = false;
            ResetData();
        }
        private void buttonStartPageNext_Click(object sender, EventArgs e)
        {
            PrepareListData();
            tabControlResetWizard.SelectedIndex = 1;
        }
        private void buttonGroupSelectionBack_Click(object sender, EventArgs e)
        {
            tabControlResetWizard.SelectedIndex = 0;
        }
        private void tabControlResetWizard_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlResetWizard.SelectedIndex)
            {
                case 0: tabPageStartPage.Refresh(); break;
                case 1: tabPageGroupSelection.Refresh(); break;
                case 2: tabPageResetting.Refresh(); break;
            }
        }

        // Resetting Methods
        private void ResetData()
        {
            String query;
            int stepsLeft = 6; // amount of steps left + 1

            // Legend: Task (Database table/s involved)

            // FIRST STEP
            stepsLeft = RefreshProgressLabel("Resetting in progress (Step 1 of 5): Clearing Student Schedules", stepsLeft);

            // Delete all class schedule assignments (StudentSchedule)
            query = "delete from studentschedule;";
            DBHandler.Delete(query);

            // Delete all class schedules (Timeslot)
            query = "delete from timeslot;";
            DBHandler.Delete(query);

            progressBarResetting.Value = progressBarResetting.Maximum / stepsLeft;

            // SECOND STEP
            stepsLeft = RefreshProgressLabel("Resetting in progress (Step 2 of 5): Clearing Events", stepsLeft);

            // Delete all event assignments (StudentEventRecord & PanelistEventRecord)
            query = "delete from studenteventrecord;";
            DBHandler.Delete(query);

            query = "delete from panelisteventrecord;";
            DBHandler.Delete(query);

            // Delete all events (Event)
            query = "delete from event;";
            DBHandler.Delete(query);

            progressBarResetting.Value = progressBarResetting.Maximum / stepsLeft;

            // THIRD STEP
            stepsLeft = RefreshProgressLabel("Resetting in progress (Step 3 of 5): Clearing Defense Schedules", stepsLeft);

            // Delete all defense/redefense schedules (DefenseSchedule)
            query = "delete from defenseschedule;";
            DBHandler.Delete(query);

            progressBarResetting.Value = progressBarResetting.Maximum / stepsLeft;

            // FOURTH STEP
            stepsLeft = RefreshProgressLabel("Resetting in progress (Step 4 of 5): Resetting Group Eligibility", stepsLeft);

            // Reset eligibility for defense/redefense (ThesisGroup)
            query = "update thesisgroup set eligiblefordefense = 'false', eligibleforredefense = 'false';";
            DBHandler.Update(query);

            progressBarResetting.Value = progressBarResetting.Maximum / stepsLeft;

            // FIFTH STEP
            stepsLeft = RefreshProgressLabel("Resetting in progress (Step 5 of 5): Moving Thesis Groups", stepsLeft);

            // Groups proceed to next course (ThesisGroup)
            AdvanceThesisGroups();

            progressBarResetting.Value = progressBarResetting.Maximum / stepsLeft;

            // RESET COMPLETE
            RefreshProgressLabel("Reset Complete", stepsLeft);
            buttonResettingExit.Enabled = true;
        }
        private void AdvanceThesisGroups() 
        {
            UpdateGroupsCourse("THSST-2", treeViewGroupList1);
            UpdateGroupsCourse("THSST-3", treeViewGroupList2);
            DeleteGroups(treeViewGroupList3);
        }
        private void UpdateGroupsCourse(String newCourse, TreeView treeView)
        {
            String inlist = "";
            String query;

            foreach (TreeNode node in treeView.Nodes)
                if (node.Checked)
                    inlist += node.Name + ",";

            if (!String.IsNullOrEmpty(inlist))
            {
                inlist = inlist.Substring(0, inlist.Length - 1);
                query = "update thesisgroup set course = '" + newCourse + "' where thesisgroupid in (" + inlist + ");";
                DBHandler.Update(query);
            }
        }
        private void DeleteGroups(TreeView treeView)
        {
            String inlist = "";
            String query;
            List<String> groupIDs = new List<String>();

            foreach (TreeNode node in treeView.Nodes)
                if (node.Checked)
                {
                    inlist += node.Name + ",";
                    groupIDs.Add(node.Name);
                }

            if (!String.IsNullOrEmpty(inlist))
            {
                inlist = inlist.Substring(0, inlist.Length - 1);
                query = "delete from thesisgroup where thesisgroupid in (" +inlist+ ");";
                DBHandler.Delete(query);

                foreach (String groupID in groupIDs) 
                {
                    query = "delete from student where thesisgroupid = "+ groupID+" ;";
                    DBHandler.Delete(query);
                }
            }
        }
    }
}
