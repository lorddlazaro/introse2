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
    public partial class ThesisGroupControl2 : UserControl
    {
        DBce dbHandler;
        private String currThesisGroupID; // currently selected thesis group

        TextBox[] groupDetails; // details (title, section, SY)
        ComboBox[] groupStuff; // stuff (course, term)
        Button[] groupButtons; // buttons (edit, new, save, cancel)
        RadioButton[] eligible;

        List<TextBox>[] studentDetails;
        List<Button>[] studentButtons;
        
        List<TextBox>[] panelistDetails;
        List<Button>[] panelButtons;
        ComboBox[] selPanel;

        public ThesisGroupControl2()
        {
            dbHandler = new DBce();
            InitializeComponent();

            currThesisGroupID = "";

            initPanels();
            initButtons();

            thesisGroupTreeView.BeginUpdate();
            AddPanelistsToTree(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }

        private void initButtons()
        {
            // group
            groupButtons = new Button[5];
            groupButtons[0] = editThesisGroup;
            groupButtons[1] = newThesisGroup;
            groupButtons[2] = saveDetails;
            groupButtons[3] = cancelEdits;
            groupButtons[4] = deleteGroup;

            for (int i = 0; i < 5; i++)
                groupButtons[i].Enabled = false;
            groupButtons[1].Enabled = true;

            eligible = new RadioButton[2];
            eligible[0] = eligibleN;
            eligible[1] = eligibleY;

            eligibleY.Enabled = false;
            eligibleN.Enabled = false;
            eligibleN.Checked = true;

            // students
            studentButtons = new List<Button>[4]; // 4 students
            for (int i = 0; i < 4; i++)
            {
                studentButtons[i] = new List<Button>();
                
                studentButtons[i].Add(new Button());
                studentButtons[i].ElementAt(0).Name = "editStudent" + i;
                studentButtons[i].ElementAt(0).Enabled = true;
                studentButtons[i].ElementAt(0).Location = new Point(3, 153);
                studentButtons[i].ElementAt(0).Size = new Size(58, 23);
                studentButtons[i].ElementAt(0).Text = "Edit";
                studentButtons[i].ElementAt(0).Click += new System.EventHandler(edit_student_Click);

                studentButtons[i].Add(new Button());
                studentButtons[i].ElementAt(1).Name = "saveStudent" + i;
                studentButtons[i].ElementAt(1).Enabled = false;
                studentButtons[i].ElementAt(1).Location = new Point(66, 153);
                studentButtons[i].ElementAt(1).Size = new Size(60, 23);
                studentButtons[i].ElementAt(1).Text = "Save";
                studentButtons[i].ElementAt(1).Click += new System.EventHandler(save_student_Click);

                studentButtons[i].Add(new Button());
                studentButtons[i].ElementAt(2).Name = "delStudent" + i;
                studentButtons[i].ElementAt(2).Enabled = true;
                studentButtons[i].ElementAt(2).Location = new Point(129, 153);
                studentButtons[i].ElementAt(2).Size = new Size(79, 23);
                studentButtons[i].ElementAt(2).Text = "Clear/Delete";
                studentButtons[i].ElementAt(2).Click += new System.EventHandler(delete_student_Click);
            }

            for (int i = 0; i < 3; i++) student1.Controls.Add(studentButtons[0].ElementAt(i));
            for (int i = 0; i < 3; i++) student2.Controls.Add(studentButtons[1].ElementAt(i));
            for (int i = 0; i < 3; i++) student3.Controls.Add(studentButtons[2].ElementAt(i));
            for (int i = 0; i < 3; i++) student4.Controls.Add(studentButtons[3].ElementAt(i));

            // panelists
            panelButtons = new List<Button>[3]; // 3 panelists
            for (int i = 0; i < 3; i++)
            {
                panelButtons[i] = new List<Button>();

                panelButtons[i].Add(new Button());
                panelButtons[i].ElementAt(0).Name = "editPanelist" + i;
                panelButtons[i].ElementAt(0).Enabled = true;
                panelButtons[i].ElementAt(0).Location = new Point(3, 152);
                panelButtons[i].ElementAt(0).Size = new Size(49, 23);
                panelButtons[i].ElementAt(0).Text = "Edit";
                panelButtons[i].ElementAt(0).Click += new System.EventHandler(edit_panel_Click);

                panelButtons[i].Add(new Button());
                panelButtons[i].ElementAt(1).Name = "savePanelist" + i;
                panelButtons[i].ElementAt(1).Enabled = false;
                panelButtons[i].ElementAt(1).Location = new Point(54, 153);
                panelButtons[i].ElementAt(1).Size = new Size(45, 23);
                panelButtons[i].ElementAt(1).Text = "Save";
                panelButtons[i].ElementAt(1).Click += new System.EventHandler(save_panel_Click);

                panelButtons[i].Add(new Button());
                panelButtons[i].ElementAt(2).Name = "delPanelist" + i;
                panelButtons[i].ElementAt(2).Enabled = true;
                panelButtons[i].ElementAt(2).Location = new Point(100, 153);
                panelButtons[i].ElementAt(2).Size = new Size(45, 23);
                panelButtons[i].ElementAt(2).Text = "Clear";
                panelButtons[i].ElementAt(2).Click += new System.EventHandler(delete_panel_Click);

                panelButtons[i].Add(new Button());
                panelButtons[i].ElementAt(3).Name = "selPanelist" + i;
                panelButtons[i].ElementAt(3).Enabled = true;
                panelButtons[i].ElementAt(3).Location = new Point(148, 153);
                panelButtons[i].ElementAt(3).Size = new Size(88, 23);
                panelButtons[i].ElementAt(3).Text = "Select Existing";
                panelButtons[i].ElementAt(3).Click += new System.EventHandler(select_panel_Click);
            }

            for (int i = 0; i < 4; i++) panelist1.Controls.Add(panelButtons[0].ElementAt(i));
            for (int i = 0; i < 4; i++) panelist2.Controls.Add(panelButtons[1].ElementAt(i));
            for (int i = 0; i < 4; i++) panelist3.Controls.Add(panelButtons[2].ElementAt(i));

        }

        private void initPanels()
        {
            // thesis groups
            groupDetails = new TextBox[3];
            groupDetails[0] = groupThesisTitle;
            groupDetails[1] = groupSection;
            groupDetails[2] = groupStartSY;

            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = false;

            groupStuff = new ComboBox[2];
            groupStuff[0] = groupCourse;
            groupStuff[1] = groupStartTerm;

            for (int i = 0; i < 2; i++)
                groupStuff[i].Enabled = false;

            // students
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

            // panelists
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

            selPanel = new ComboBox[3]; // 3 panelists
            for (int i = 0; i < 3; i++)
            {
                selPanel[i] = new ComboBox();
                selPanel[i].Enabled = false;
                selPanel[i].Location = new Point(79, 8);
                selPanel[i].Size = new Size(154, 21);
                selPanel[i].Name = "selPanelist" + i;
                selPanel[i].SelectedIndexChanged += new System.EventHandler(selPanel_Selected_Index_Changed);
            }

            panelist1.Controls.Add(selPanel[0]);
            panelist2.Controls.Add(selPanel[1]);
            panelist3.Controls.Add(selPanel[2]);
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

        private void update_treeview()
        {
            thesisGroupTreeView.BeginUpdate();
            thesisGroupTreeView.Nodes.Clear();
            AddPanelistsToTree(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }

        private void update_components()
        {
            // update thesis group details
            update_thesisgroup();
            // update student details (and the buttons too)
            update_students();
            // update panelist details (the buttons too why not)
            update_panelists();
        }

        private void update_thesisgroup()
        {
            if (currThesisGroupID == "")
            {
                for (int i = 0; i < 3; i++)
                    groupDetails[i].Text = "";
                for (int i = 0; i < 2; i++)
                    groupStuff[i].SelectedItem = "";
                
                groupButtons[0].Enabled = false;
                groupButtons[1].Enabled = true;
                groupButtons[2].Enabled = false;
                groupButtons[3].Enabled = false;
                groupButtons[4].Enabled = false;

                eligibleY.Enabled = false;
                eligibleN.Enabled = true;
                return;
            }

            String query = "select title, course, section, startSY, startTerm, eligiblefordefense from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            List<String>[] groupInfo = dbHandler.Select(query, 5);

            groupDetails[0].Text = groupInfo[0].ElementAt(0);
            groupStuff[0].SelectedItem = groupInfo[1].ElementAt(0);
            groupDetails[1].Text = groupInfo[2].ElementAt(0);
            groupDetails[2].Text = groupInfo[3].ElementAt(0);
            groupStuff[1].SelectedItem = groupInfo[4].ElementAt(0);

            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = false;

            for (int i = 0; i < 2; i++)
                groupStuff[i].Enabled = false;

            groupButtons[0].Enabled = true;
            groupButtons[1].Enabled = true;
            groupButtons[2].Enabled = false;
            groupButtons[3].Enabled = false;
            groupButtons[4].Enabled = false;

            eligibleY.Enabled = false;
            eligibleN.Enabled = false;

            query = "select eligiblefordefense from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            String q2 = "select count(*) from student where thesisgroupid = " + currThesisGroupID + ";";
            String q3 = "select count(*) from panelassignment where thesisgroupid = " + currThesisGroupID + ";";
            Boolean eligible = Convert.ToBoolean(dbHandler.Select(query, 1)[0].ElementAt(0)) && (Convert.ToInt32(dbHandler.Select(q2, 1)[0].ElementAt(0)) >= 1) && (Convert.ToInt32(dbHandler.Select(q3, 1)[0].ElementAt(0)) >= 3);

            if (eligible)
            {
                eligibleY.Checked = true;
            }
            else
            {
                eligibleN.Checked = true;
                if (Convert.ToBoolean(dbHandler.Select(query, 1)[0].ElementAt(0))) {
                    String update = "update thesisgroup set eligiblefordefense = 'false' where thesisgroupid = " + currThesisGroupID + ";";
                    dbHandler.Update(update);
                }
            }
        }

        private void update_students()
        {
            if (currThesisGroupID == "")
            {
                for (int i = 0; i < 4; i++) 
                {
                    for (int j = 0; j < 4; j++)
                    {
                        studentDetails[i].ElementAt(j).Text = "";
                        studentDetails[i].ElementAt(j).Enabled = false;
                    }

                    studentButtons[i].ElementAt(0).Text = "Add";
                    studentButtons[i].ElementAt(1).Enabled = false;
                    studentButtons[i].ElementAt(2).Enabled = false;
                }
                return;
            }

            String query;
            List<String>[] groupInfo;

            query = "select count(*) from student where thesisgroupid = " + currThesisGroupID + ";";
            int memcount = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            query = "select studentID, firstname, lastname, MI from student where thesisgroupid = " + currThesisGroupID + ";";
            groupInfo = dbHandler.Select(query, 4);

            for (int i = 0; i < 4; i++)
            {
                if (i >= memcount)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        studentDetails[i].ElementAt(j).Text = "";
                        studentDetails[i].ElementAt(j).Enabled = false;
                    }

                    studentButtons[i].ElementAt(0).Text = "Add";
                    studentButtons[i].ElementAt(1).Enabled = false;
                    studentButtons[i].ElementAt(2).Enabled = false;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        studentDetails[i].ElementAt(j).Text = groupInfo[j].ElementAt(i);
                        studentDetails[i].ElementAt(j).Enabled = false;
                    }

                    studentButtons[i].ElementAt(0).Text = "Edit";
                    studentButtons[i].ElementAt(1).Enabled = false;
                    studentButtons[i].ElementAt(2).Enabled = true;
                }
            }

        }

        private void update_panelists()
        {
            if (currThesisGroupID == "")
            {
                for (int i = 0; i < 3; i++)
                {
                    selPanel[i].Enabled = false;
                    selPanel[i].Items.Clear();

                        for (int j = 0; j < 4; j++)
                        {
                            panelistDetails[i].ElementAt(j).Text = null;
                            panelistDetails[i].ElementAt(j).Enabled = false;
                        }

                    panelButtons[i].ElementAt(0).Text = "Add";
                    panelButtons[i].ElementAt(1).Enabled = false;
                    panelButtons[i].ElementAt(2).Enabled = false;
                    panelButtons[i].ElementAt(3).Text = "Select Existing";
                }
                return;
            }

            String query;
            List<String>[] groupInfo;

            query = "select count(*) from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid =  " + currThesisGroupID + ");";
            int memcount = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            query = "select panelistID, firstname, lastname, MI from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ") order by lastname;";
            groupInfo = dbHandler.Select(query, 4);

            for (int i = 0; i < 3; i++)
            {
                selPanel[i].Enabled = false;
                selPanel[i].Items.Clear();

                if (i >= memcount)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        panelistDetails[i].ElementAt(j).Text = null;
                        panelistDetails[i].ElementAt(j).Enabled = false;
                    }

                    panelButtons[i].ElementAt(0).Text = "Add";
                    panelButtons[i].ElementAt(1).Enabled = false;
                    panelButtons[i].ElementAt(2).Enabled = false;
                    panelButtons[i].ElementAt(3).Text = "Select Existing";
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        panelistDetails[i].ElementAt(j).Text = groupInfo[j].ElementAt(i);
                        panelistDetails[i].ElementAt(j).Enabled = false;
                    }

                    panelButtons[i].ElementAt(0).Text = "Edit";
                    panelButtons[i].ElementAt(1).Enabled = false;
                    panelButtons[i].ElementAt(2).Enabled = true;
                    panelButtons[i].ElementAt(3).Text = "Select Existing";
                }
            }
        }

        private void thesisGroupTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                currThesisGroupID = e.Node.Name;
                update_components();
            }
        }

        private void edit_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11));

            if (currThesisGroupID == "")
                return;

            if (pressed.Text == "Edit") // editing
            {
                update_students();

                for (int i = 0; i < studentDetails[studentIndex].Count; i++)
                    studentDetails[studentIndex].ElementAt(i).Enabled = true;
                
                studentButtons[studentIndex].ElementAt(1).Enabled = true;
                studentButtons[studentIndex].ElementAt(0).Text = "Cancel";
            }
            else if (pressed.Text == "Add") // duh
            {
                update_students();

                for (int i = 0; i < studentDetails[studentIndex].Count; i++)
                    studentDetails[studentIndex].ElementAt(i).Enabled = true;

                studentButtons[studentIndex].ElementAt(1).Enabled = true;
                studentButtons[studentIndex].ElementAt(0).Text = "Cancel";
            }
            else // cancel editing/adding
            {
                update_students();
            }
        }

        private void save_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11));

            String newID = studentDetails[studentIndex].ElementAt(0).Text;
            String newFirstName = studentDetails[studentIndex].ElementAt(1).Text;
            String newLastName = studentDetails[studentIndex].ElementAt(2).Text;
            String newMI = studentDetails[studentIndex].ElementAt(3).Text;

            String query = "select studentID from student where thesisgroupid = " + currThesisGroupID + ";";
            List<String>[] result = dbHandler.Select(query, 1);

            if (newID == "" || newFirstName == "" || newLastName == "")
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (result[0].Count <= studentIndex)
            {
                query = "select studentID from student;";
                List<String>[] result2 = dbHandler.Select(query, 1);

                Boolean duplicate = false;

                for (int i = 0; i < result2[0].Count && !duplicate; i++)
                {
                    if (result2[0].ElementAt(i) == newID)
                        duplicate = true;
                }

                if (!duplicate)
                {
                    query = "insert into student values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                    query += newLastName + "', " + currThesisGroupID + ");";
                    dbHandler.Insert(query);
                }
                else
                {
                    MessageBox.Show("Duplicate Entry, Student already in another thesis group.", "Error", MessageBoxButtons.OK);

                }
            }
            else if (result[0].ElementAt(studentIndex) == newID)
            {
                query = "update student set firstname = '" + newFirstName + "', lastname = '" + newLastName + "', MI = '" + newMI + "' ";
                query += "where studentid = " + newID + ";";

                dbHandler.Update(query);
            }
            else
            {
                query = "select studentID from student;";
                List<String>[] result2 = dbHandler.Select(query, 1);

                Boolean duplicate = false;

                for (int i = 0; i < result2[0].Count && !duplicate; i++)
                {
                    if (result2[0].ElementAt(i) == newID)
                        duplicate = true;
                }

                if (!duplicate)
                {
                    String oldID = result[0].ElementAt(studentIndex);

                    query = "delete from student where studentID = " + oldID + ";";
                    dbHandler.Delete(query);

                    query = "insert into student values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                    query += newLastName + "', " + currThesisGroupID + ");";
                    dbHandler.Insert(query);
                }
                else
                {
                    MessageBox.Show("Duplicate Input, Student already in another thesis group.", "Error", MessageBoxButtons.OK);
                }
            }


            update_students();
        }

        private void delete_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(10));

            if (currThesisGroupID == "")
                return;

            String query = "select studentid, firstname, mi, lastname from student where studentid = " + studentDetails[studentIndex].ElementAt(0).Text + ";";
            List<String>[] result = dbHandler.Select(query, 4);

            String name = result[0].ElementAt(0) + " - " + result[1].ElementAt(0) + " " + result[2].ElementAt(0) + ". " + result[3].ElementAt(0);

            DialogResult input = MessageBox.Show("Are you sure you want to delete student " + name + "?", "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                query = "delete from student where studentid = " + studentDetails[studentIndex].ElementAt(0).Text + ";";
                dbHandler.Delete(query);
            }

            update_components();
        }

        private void edit_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12));

            if (currThesisGroupID == "")
                return;

            if (pressed.Text == "Edit") // editing
            {
                update_panelists();

                for (int i = 0; i < studentDetails[panelIndex].Count; i++)
                    panelistDetails[panelIndex].ElementAt(i).Enabled = true;

                panelButtons[panelIndex].ElementAt(1).Enabled = true;
                panelButtons[panelIndex].ElementAt(0).Text = "Cancel";
            }
            else if (pressed.Text == "Add") // duh
            {
                update_panelists();

                for (int i = 0; i < panelistDetails[panelIndex].Count; i++)
                    panelistDetails[panelIndex].ElementAt(i).Enabled = true;

                panelButtons[panelIndex].ElementAt(1).Enabled = true;
                panelButtons[panelIndex].ElementAt(0).Text = "Cancel";
            }
            else // cancel editing/adding
            {
                update_panelists();
            }
        }

        private void save_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12));

            String newID = panelistDetails[panelIndex].ElementAt(0).Text;
            String newFirstName = panelistDetails[panelIndex].ElementAt(1).Text;
            String newLastName = panelistDetails[panelIndex].ElementAt(2).Text;
            String newMI = panelistDetails[panelIndex].ElementAt(3).Text;

            String query = "select panelistID from panelassignment where thesisgroupid = " + currThesisGroupID + " order by panelistID;";
            List<String>[] result = dbHandler.Select(query, 1);

            if (newID == "" || newFirstName == "" || newLastName == "")
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (result[0].Count <= panelIndex)
            {
                Boolean duplicate = false;

                for (int i = 0; i < result[0].Count && !duplicate; i++)
                {
                    if (result[0].ElementAt(i) == newID)
                        duplicate = true;
                }

                if (!duplicate)
                {
                    query = "insert into panelist values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                    query += newLastName + "');";
                    dbHandler.Insert(query);

                    query = "insert into panelassignment values(" + currThesisGroupID + ", " + newID + ");";
                    dbHandler.Insert(query);
                }
                else
                {
                    MessageBox.Show("Panelist Already Assigned to Thesis Group", "Error", MessageBoxButtons.OK);
                }
            }
            else if (result[0].ElementAt(panelIndex) == newID)
            {

                query = "update panelist set firstname = '" + newFirstName + "', lastname = '" + newLastName + "', MI = '" + newMI + "' ";
                query += "where panelistid = " + newID + ";";

                dbHandler.Update(query);
            }
            else
            {
                Boolean duplicate = false;

                for (int i = 0; i < result[0].Count && !duplicate; i++)
                {
                    if (result[0].ElementAt(i) == newID)
                        duplicate = true;
                }

                if (!duplicate)
                {
                    query = "delete from panelassignment where thesisgroupid = " + currThesisGroupID + " and panelistid = " + result[0].ElementAt(panelIndex) + ";";
                    dbHandler.Delete(query);

                    query = "insert into panelist values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                    query += newLastName + "');";
                    dbHandler.Insert(query);

                    query = "insert into panelassignment values(" + currThesisGroupID + ", " + newID + ");";
                    dbHandler.Insert(query);
                   // Console.WriteLine(dbHandler.Select("select count(*) from panelassignment where thesisgroupid = " + currThesisGroupID + ";", 1)[0].ElementAt(0) + " look here duke");
                }
                else
                {
                    MessageBox.Show("Panelist already in thesis group", "Error", MessageBoxButtons.OK);
                }
            }

            update_components();
        }

        private void delete_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11));

            if (currThesisGroupID == "")
                return;

            String query;
            List<String>[] result;

            query = "select firstname, MI, lastname from panelist where panelistid = " + panelistDetails[panelIndex].ElementAt(0).Text + ";";
            result = dbHandler.Select(query, 3);

            String name = result[0].ElementAt(0) + " " + result[1].ElementAt(0) + ". " + result[2].ElementAt(0);

            DialogResult input = MessageBox.Show("Are you sure you want to remove panelist " + name + "?", "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                query = "delete from panelassignment where panelistid = " + panelistDetails[panelIndex].ElementAt(0).Text + " and thesisgroupid = " + currThesisGroupID + ";";
                dbHandler.Delete(query);
            }

            update_components();
        }

        private void select_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11));

            if (currThesisGroupID == "")
                return;

            if (panelButtons[panelIndex].ElementAt(3).Text == "Select Existing")
            {
                update_components();

                panelButtons[panelIndex].ElementAt(3).Text = "Cancel Select";
                selPanel[panelIndex].Enabled = true;

                String query = "select count(*) from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
                List<String>[] result = dbHandler.Select(query, 1);

                int memcount = Convert.ToInt32(result[0].ElementAt(0));

                query = "select firstname, MI, lastname from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
                result = dbHandler.Select(query, 3);

                for (int i = 0; i < memcount; i++)
                    selPanel[panelIndex].Items.Add(result[0].ElementAt(i) + " " + result[1].ElementAt(i) + ". " + result[2].ElementAt(i));
            }
            else
            {
                panelButtons[panelIndex].ElementAt(3).Text = "Select Existing";
                selPanel[panelIndex].Items.Clear();

                update_components();
            }
        }

        private void selPanel_Selected_Index_Changed(object sender, EventArgs e)
        {
            ComboBox currPanel = (ComboBox)sender;
            int panelIndex = Convert.ToInt32(currPanel.Name.Substring(11));
            int selected = selPanel[panelIndex].SelectedIndex;

            if (selPanel[panelIndex].SelectedItem + "" == "")
                return;

            String[] name = ((String)selPanel[panelIndex].SelectedItem).Split(' ');

            int middleIndex = 0;
            while (name[middleIndex].Length != 2)
                middleIndex++;

            String newFirstName = "";
            String newMI = "";
            String newLastName = "";
            for (int i = 0; i < middleIndex; i++) {
                newFirstName += name[i];
                if (i != middleIndex - 1)
                    newFirstName += " ";
            }

            newMI = name[middleIndex];
            newMI = newMI.Substring(0, newMI.Length - 1);
            for (int i = middleIndex + 1; i <= name.GetUpperBound(0); i++)
            {
                newLastName += name[i];
                if (i != name.GetUpperBound(0))
                    newLastName += " ";
            }

            String query;
            List<String>[] result;


            if (panelistDetails[panelIndex].ElementAt(0).Text == "")
            {
                query = "select panelistid from panelist where firstname = '" + newFirstName + "' and MI = '" + newMI + "' and lastname = '" + newLastName + "';";
                result = dbHandler.Select(query, 1);

                query = "insert into panelassignment values(" + currThesisGroupID + ", " + result[0].ElementAt(0) + ");";
                dbHandler.Insert(query);
            }
            else
            {
                query = "delete from panelassignment where thesisgroupid = " + currThesisGroupID + " and panelistid = " + panelistDetails[panelIndex].ElementAt(0).Text + ";";
                dbHandler.Delete(query);

                query = "select panelistid from panelist where firstname = '" + newFirstName + "' and MI = '" + newMI + "' and lastname = '" + newLastName + "';";
                result = dbHandler.Select(query, 1);

                query = "insert into panelassignment values(" + currThesisGroupID + ", " + result[0].ElementAt(0) + ");";
                dbHandler.Insert(query);
            }

            update_components();
        }

        private void new_thesisGroup_Click(object sender, EventArgs e)
        {
            currThesisGroupID = "";
            update_components();

            for (int i = 0; i < 3; i++)
            {
                groupDetails[i].Enabled = true;
                groupDetails[i].Text = "";
            }
            for (int i = 0; i < 2; i++)
            {
                groupStuff[i].Enabled = true;
                groupStuff[i].SelectedItem = null;
            }

            groupButtons[1].Enabled = false;
            groupButtons[2].Enabled = true;
        }

        private void edit_groupDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = true;
            for (int i = 0; i < 2; i++)
                groupStuff[i].Enabled = true;

            groupButtons[0].Enabled = false;
            groupButtons[2].Enabled = true;
            groupButtons[3].Enabled = true;

            eligibleN.Enabled = true;
            eligibleY.Enabled = true;
        }

        private void save_groupDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                if (groupDetails[i].Text == "")
                {
                    MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                    return;
                }
            for (int i = 0; i < 2; i++)
                if (groupStuff[i].SelectedItem == null)
                {
                    MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                    return;
                }

            String newTitle = groupDetails[0].Text;
            String newSection = groupDetails[1].Text;
            String newSY = groupDetails[2].Text;
            String newCourse = (String)groupStuff[0].SelectedItem;
            String newTerm = (String)groupStuff[1].SelectedItem;
            Boolean eligibility = eligibleY.Checked;

            String query;

            if (!currThesisGroupID.Equals(""))
            {
                query = "select count(*) from thesisgroup where title = '" + newTitle + "' and thesisgroupid != " + currThesisGroupID + ";";
                int duplicate = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

                if (duplicate == 0)
                {
                    query = "update thesisgroup set title = '" + newTitle + "', course = '" + newCourse + "', section = '" + newSection + "', startSY = '" + newSY + "', startTerm = '" + newTerm + "', eligiblefordefense = '" + eligibility + "' ";
                    
                    query += "where thesisgroupid = " + currThesisGroupID + ";";
                    Console.WriteLine("Edit: "+query);
                    dbHandler.Update(query);
                }
                else
                {
                    MessageBox.Show("Thesis Title \"" + newTitle + "\" already taken.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                List<String>[] result;

                String insert = "('" + newTitle + "', '" + newCourse + "', '" + newSection + "', '" + newSY + "', '" + newTerm + "', '" + eligibility + "')";
                query = "insert into thesisgroup (title, course, section, startsy, startterm, eligiblefordefense) values" + insert + ";";
                dbHandler.Insert(query);

                query = "select thesisgroupid from thesisgroup where title = '" + newTitle + "';";
                result = dbHandler.Select(query, 1);

                currThesisGroupID = result[0].ElementAt(0);
            }

            update_components();
            update_treeview();
        }

        private void cancelEdits_Click(object sender, EventArgs e)
        {
            if (!groupButtons[0].Enabled)
            {
                for (int i = 0; i < 3; i++)
                    groupDetails[i].Enabled = false;

                for (int i = 0; i < 2; i++)
                    groupStuff[i].Enabled = false;

                groupButtons[0].Enabled = true;
                groupButtons[1].Enabled = true;
                groupButtons[2].Enabled = false;
                groupButtons[3].Enabled = false;
                return;
            }

            for (int i = 0; i < 3; i++)
                if (groupDetails[i].Text == "")
                    return;
            for (int i = 0; i < 2; i++)
                if (groupStuff[i].SelectedItem == null)
                    return;

            update_components();
        }

        private void deleteGroup_Click(object sender, EventArgs e)
        {
            if (currThesisGroupID == "")
                return;

            String query = "delete from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            dbHandler.Delete(query);

            update_components();
            update_treeview();
        }
    }
}