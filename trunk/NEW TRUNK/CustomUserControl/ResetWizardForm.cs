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
    public partial class ResetWizardForm : Form
    {
        DBce DBHandler;

        public ResetWizardForm()
        {
            InitializeComponent();
            DBHandler = new DBce();
        }

        private void ResetData() 
        {
            string query;
            int stepsLeft = 8;

            // Note: Task (Database table/s involved)

            // Delete all class schedule assignments (StudentSchedule)
            label1.Text = "Resetting in progress (Step 1 of 5): Clearing Student Schedules";
            query = "delete from studentschedule;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;

            // Delete all class schedules (Timeslot)
            query = "delete from timeslot;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;
            
            // Delete all event assignments (StudentEventRecord & PanelistEventRecord)
            label1.Text = "Resetting in progress (Step 2 of 5): Clearing Events";
            query = "delete from studenteventrecord;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;

            query = "delete from panelisteventrecord;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;
            // Delete all events (Event)
            query = "delete from event;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;

            // Delete all defense/redefense schedules (DefenseSchedule)
            label1.Text = "Resetting in progress (Step 3 of 5): Clearing Defense and Redefense Schedules.";
            query = "delete from defenseschedule;";
            DBHandler.Delete(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;

            // Reset eligibility for defense/redefense (ThesisGroup)
            label1.Text = "Resetting in progress (Step 4 of 5): Resetting Group Eligibility";
            query = "update thesisgroup set eligiblefordefense = 'false', eligibleforredefense = 'false';";
            DBHandler.Update(query);

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;
            // Groups proceed to next course (ThesisGroup)
            label1.Text = "Resetting in progress (Step 5 of 5): Moving Thesis Groups";
            ProcessTreeData();

            progressBar1.Value = progressBar1.Maximum / stepsLeft--;
            label1.Text = "Resetting Complete";
            ExitButton.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetWizardTabControl1.SelectedIndex = 2;
            Refresh();
            ExitButton.Enabled = false;
            ResetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrepareListData();
            resetWizardTabControl1.SelectedIndex = 1;
            Refresh();
        }

        private void ProcessTreeData() 
        {
            UpdateGroupsCourse("THSST-2", treeView1);
            UpdateGroupsCourse("THSST-3", treeView2);
            DeleteGroups(treeView3);
        }

        private void DeleteGroups(TreeView treeView)
        {
            string inlist = "";
            string query;
            List<String> groupIDs = new List<string>();

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

        private void UpdateGroupsCourse(String newCourse, TreeView treeView)
        {
            string inlist = "";
            string query;

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

        private void PrepareListData() 
        {
            FillCheckedBoxList(treeView1, 1);
            FillCheckedBoxList(treeView2, 2);
            FillCheckedBoxList(treeView3, 3);
        }

        private void FillCheckedBoxList(TreeView tree, int course)
        {
            List<string>[] list;
            TreeNode tempNode;

            string query = "select thesisgroupid, title from thesisgroup where course = 'THSST-" + course + "';";
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
