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
    public partial class ThesisGroupControl : UserControl
    {
        DBce dbHandler;
        //private String currThesisGroupID; // currently selected thesis group

        List<TextBox>[] studentDetails;
        List<TextBox>[] panelistDetails;

        private int editmode = 0; // 0 nothing, 1 group details, 2-5 students/group members, 6-8 panel

        public ThesisGroupControl()
        {
            dbHandler = new DBce();
            InitializeComponent();

            initPanels();

            thesisGroupTreeView.BeginUpdate();
            AddPanelistsToTree(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }

        private void initPanels()
        {
            studentDetails = new List<TextBox>[4]; // up to 4 students in a group
            for (int i = 0; i < 4; i++)
            {
                studentDetails[i] = new List<TextBox>();
                for (int j = 0; j < 4; j++)
                {
                    studentDetails[i].Add(new TextBox()); // in the order of ID, first name, last name, MI
                    studentDetails[i].ElementAt(j).Enabled = false;
                    studentDetails[i].ElementAt(j).Location = new Point(79, 30 * j + 33);
                    studentDetails[i].ElementAt(j).Size = new Size(123, 20);
                }
            }

            for (int i = 0; i < 4; i++) student1.Controls.Add(studentDetails[0].ElementAt(i));
            for (int i = 0; i < 4; i++) student2.Controls.Add(studentDetails[1].ElementAt(i));
            for (int i = 0; i < 4; i++) student3.Controls.Add(studentDetails[2].ElementAt(i));
            for (int i = 0; i < 4; i++) student4.Controls.Add(studentDetails[3].ElementAt(i));

            panelistDetails = new List<TextBox>[3]; // 3 panelists
            for (int i = 0; i < 3; i++)
            {
                panelistDetails[i] = new List<TextBox>();
                for (int j = 0; j < 4; j++)
                {
                    panelistDetails[i].Add(new TextBox());
                    panelistDetails[i].ElementAt(j).Enabled = false;
                    panelistDetails[i].ElementAt(j).Location = new Point(79, 30 * j + 33);
                    panelistDetails[i].ElementAt(j).Size = new Size(133, 20);
                }
            }

            for (int i = 0; i < 4; i++) panelist1.Controls.Add(panelistDetails[0].ElementAt(i));
            for (int i = 0; i < 4; i++) panelist2.Controls.Add(panelistDetails[1].ElementAt(i));
            for (int i = 0; i < 4; i++) panelist3.Controls.Add(panelistDetails[2].ElementAt(i));
        }

        private void AddPanelistsToTree(TreeNodeCollection tree)
        {
            String query = "select distinct course from thesisgroup;";
            List<String>[] parentList = dbHandler.Select(query, 1);
            //List<String>[] parentInfo;
            List<String>[] childList;
            TreeNode parent;
            TreeNode[] child;
            TreeNodeCollection children;

            for (int i = 0; i < parentList[0].Count(); i++)
            {
                query = "Select thesisgroupid, title, section from thesisGroup where course = '" + parentList[0].ElementAt(i) + "';";
                childList = dbHandler.Select(query, 3);

                parent = new TreeNode();
                child = new TreeNode[childList[0].Count()];
                children = parent.Nodes;

                parent.Name = parent.Text = parentList[0].ElementAt(i);

                for (int j = 0; j < childList[0].Count(); j++)
                {
                    child[j] = new TreeNode();
                    child[j].Name = childList[0].ElementAt(j);
                    child[j].Text = childList[1].ElementAt(j) + " - " + childList[2].ElementAt(j);
                    children.Add(child[j]);

                }
                tree.Add(parent);
            }
        }

        private void thesisGroupTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                String query = "select title, course, section, startSY, startTerm from thesisgroup where thesisgroupid = " + e.Node.Name + ";";
                List<String>[] groupInfo = dbHandler.Select(query, 5);

                groupThesisTitle.Text = groupInfo[0].ElementAt(0);
                groupCourse.SelectedItem = groupInfo[1].ElementAt(0);
                groupSection.Text = groupInfo[2].ElementAt(0);
                groupStartSY.Text = groupInfo[3].ElementAt(0);
                groupStartTerm.SelectedItem = groupInfo[4].ElementAt(0);

                query = "select studentID, firstname, lastname, MI from student where thesisgroupid = " + e.Node.Name + ";";
                groupInfo = dbHandler.Select(query, 4);

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        studentDetails[i].ElementAt(j).Text = groupInfo[j].ElementAt(i);

                query = "select panelistID, firstname, lastname, MI from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + e.Node.Name + ");";
                groupInfo = dbHandler.Select(query, 4);

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                        panelistDetails[i].ElementAt(j).Text = groupInfo[j].ElementAt(i);

            }
        }

        private void editStudent1_Click(object sender, EventArgs e)
        {
            editmode = 2;
        }
    }
}
