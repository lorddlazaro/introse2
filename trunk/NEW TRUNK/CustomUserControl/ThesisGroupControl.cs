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
        private ThesisGroupDataManager tgDM;
        private String currThesisGroupID; // currently selected thesis group

        TextBox[] groupDetails; // details (title, section, SY)
        ComboBox[] groupStuff; // stuff (course, term)
        Button[] groupButtons; // buttons (edit, new, save, cancel)

        List<TextBox>[] studentDetails;
        List<Button>[] studentButtons;
        
        List<TextBox>[] panelistDetails;
        List<Button>[] panelButtons;
        ComboBox[] selPanel;

        public ThesisGroupControl()
        {
            tgDM = new ThesisGroupDataManager();
            InitializeComponent();

            currThesisGroupID = "";

            initDB();
            initButtons();
            initPanels();

            sortStudents.SelectedIndex = 0;
            
            thesisGroupTreeView.BeginUpdate();
            tgDM.showGroups(thesisGroupTreeView.Nodes);
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

            defenseCheckBox.Enabled = false;
            redefenseCheckBox.Enabled = false;

            // students
            studentButtons = new List<Button>[4]; // 4 students

            studentButtons[0] = new List<Button>();
            studentButtons[0].Add(editStudent1);
            studentButtons[0].ElementAt(0).Click += new System.EventHandler(edit_student_Click);
            studentButtons[0].Add(saveStudent1);
            studentButtons[0].ElementAt(1).Click += new System.EventHandler(save_student_Click);
            studentButtons[0].Add(deleteStudent1);
            studentButtons[0].ElementAt(2).Click += new System.EventHandler(delete_student_Click);
            
            studentButtons[1] = new List<Button>();
            studentButtons[1].Add(editStudent2);
            studentButtons[1].ElementAt(0).Click += new System.EventHandler(edit_student_Click);
            studentButtons[1].Add(saveStudent2);
            studentButtons[1].ElementAt(1).Click += new System.EventHandler(save_student_Click);
            studentButtons[1].Add(deleteStudent2);
            studentButtons[1].ElementAt(2).Click += new System.EventHandler(delete_student_Click);
            
            studentButtons[2] = new List<Button>();
            studentButtons[2].Add(editStudent3);
            studentButtons[2].ElementAt(0).Click += new System.EventHandler(edit_student_Click);
            studentButtons[2].Add(saveStudent3);
            studentButtons[2].ElementAt(1).Click += new System.EventHandler(save_student_Click);
            studentButtons[2].Add(deleteStudent3);
            studentButtons[2].ElementAt(2).Click += new System.EventHandler(delete_student_Click);

            studentButtons[3] = new List<Button>();
            studentButtons[3].Add(editStudent4);
            studentButtons[3].ElementAt(0).Click += new System.EventHandler(edit_student_Click);
            studentButtons[3].Add(saveStudent4);
            studentButtons[3].ElementAt(1).Click += new System.EventHandler(save_student_Click);
            studentButtons[3].Add(deleteStudent4);
            studentButtons[3].ElementAt(2).Click += new System.EventHandler(delete_student_Click);

            // panelists

            panelButtons = new List<Button>[4]; // 4 panelists

            panelButtons[0] = new List<Button>();
            panelButtons[0].Add(editPanelist1);
            panelButtons[0].ElementAt(0).Click += new System.EventHandler(edit_panel_Click);
            panelButtons[0].Add(savePanelist1);
            panelButtons[0].ElementAt(1).Click += new System.EventHandler(save_panel_Click);
            panelButtons[0].Add(delPanelist1);
            panelButtons[0].ElementAt(2).Click += new System.EventHandler(delete_panel_Click);
            panelButtons[0].Add(selPanelist1);
            panelButtons[0].ElementAt(3).Click += new System.EventHandler(select_panel_Click);

            panelButtons[1] = new List<Button>();
            panelButtons[1].Add(editPanelist2);
            panelButtons[1].ElementAt(0).Click += new System.EventHandler(edit_panel_Click);
            panelButtons[1].Add(savePanelist2);
            panelButtons[1].ElementAt(1).Click += new System.EventHandler(save_panel_Click);
            panelButtons[1].Add(delPanelist2);
            panelButtons[1].ElementAt(2).Click += new System.EventHandler(delete_panel_Click);
            panelButtons[1].Add(selPanelist2);
            panelButtons[1].ElementAt(3).Click += new System.EventHandler(select_panel_Click);

            panelButtons[2] = new List<Button>();
            panelButtons[2].Add(editPanelist3);
            panelButtons[2].ElementAt(0).Click += new System.EventHandler(edit_panel_Click);
            panelButtons[2].Add(savePanelist3);
            panelButtons[2].ElementAt(1).Click += new System.EventHandler(save_panel_Click);
            panelButtons[2].Add(delPanelist3);
            panelButtons[2].ElementAt(2).Click += new System.EventHandler(delete_panel_Click);
            panelButtons[2].Add(selPanelist3);
            panelButtons[2].ElementAt(3).Click += new System.EventHandler(select_panel_Click);

            panelButtons[3] = new List<Button>();
            panelButtons[3].Add(editPanelist4);
            panelButtons[3].ElementAt(0).Click += new System.EventHandler(edit_panel_Click);
            panelButtons[3].Add(savePanelist4);
            panelButtons[3].ElementAt(1).Click += new System.EventHandler(save_panel_Click);
            panelButtons[3].Add(delPanelist4);
            panelButtons[3].ElementAt(2).Click += new System.EventHandler(delete_panel_Click);
            panelButtons[3].Add(selPanelist4);
            panelButtons[3].ElementAt(3).Click += new System.EventHandler(select_panel_Click);
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

            studentDetails[0] = new List<TextBox>();
            studentDetails[0].Add(studentID1);
            studentDetails[0].Add(studentFN1);
            studentDetails[0].Add(studentLN1);
            studentDetails[0].Add(studentMI1);
            studentDetails[1] = new List<TextBox>();
            studentDetails[1].Add(studentID2);
            studentDetails[1].Add(studentFN2);
            studentDetails[1].Add(studentLN2);
            studentDetails[1].Add(studentMI2);
            studentDetails[2] = new List<TextBox>();
            studentDetails[2].Add(studentID3);
            studentDetails[2].Add(studentFN3);
            studentDetails[2].Add(studentLN3);
            studentDetails[2].Add(studentMI3);
            studentDetails[3] = new List<TextBox>();
            studentDetails[3].Add(studentID4);
            studentDetails[3].Add(studentFN4);
            studentDetails[3].Add(studentLN4);
            studentDetails[3].Add(studentMI4);

            // panelists
            panelistDetails = new List<TextBox>[4];

            panelistDetails[0] = new List<TextBox>();
            panelistDetails[0].Add(panelistID1);
            panelistDetails[0].Add(panelistFN1);
            panelistDetails[0].Add(panelistLN1);
            panelistDetails[0].Add(panelistMI1);
            panelistDetails[1] = new List<TextBox>();
            panelistDetails[1].Add(panelistID2);
            panelistDetails[1].Add(panelistFN2);
            panelistDetails[1].Add(panelistLN2);
            panelistDetails[1].Add(panelistMI2);
            panelistDetails[2] = new List<TextBox>();
            panelistDetails[2].Add(panelistID3);
            panelistDetails[2].Add(panelistFN3);
            panelistDetails[2].Add(panelistLN3);
            panelistDetails[2].Add(panelistMI3);
            panelistDetails[3] = new List<TextBox>();
            panelistDetails[3].Add(panelistID4);
            panelistDetails[3].Add(panelistFN4);
            panelistDetails[3].Add(panelistLN4);
            panelistDetails[3].Add(panelistMI4);

            selPanel = new ComboBox[4];
            selPanel[0] = selectPanelist1;
            selPanel[1] = selectPanelist2;
            selPanel[2] = selectPanelist3;
            selPanel[3] = selectPanelist4;
            selPanel[0].SelectedIndexChanged += new System.EventHandler(swapPanelists);
            selPanel[1].SelectedIndexChanged += new System.EventHandler(swapPanelists);
            selPanel[2].SelectedIndexChanged += new System.EventHandler(swapPanelists);
            selPanel[3].SelectedIndexChanged += new System.EventHandler(swapPanelists);

            selectAdviser.Items.Add("");
            selectAdviser.Enabled = false;
        }
        private void initDB()
        {
            tgDM.fixRedefenseCol();
        }

        private void update_treeview()
        {
            thesisGroupTreeView.BeginUpdate();
            thesisGroupTreeView.Nodes.Clear();
            tgDM.showGroups(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }
        private void changeSelectedGroup(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                currThesisGroupID = e.Node.Name;
                update_components();
            }
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

                defenseCheckBox.Enabled = false;
                redefenseCheckBox.Enabled = false;
                return;
            }

            List<String>[] groupInfo = tgDM.getGroupInfo(currThesisGroupID);

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
            groupButtons[4].Enabled = true;

            defenseCheckBox.Enabled = false;
            redefenseCheckBox.Enabled = false;

            int studentCount = tgDM.studentCount(currThesisGroupID);
            int panelCount = tgDM.panelistCount(currThesisGroupID);

            Boolean[] eligibility = tgDM.getEligibilities(currThesisGroupID);

            Boolean eligible = eligibility[0] && (studentCount >= 1 && panelCount >= 3);
            Boolean eligible_redef = eligibility[1] && (studentCount >= 1 && panelCount >= 3);

            if (eligible)
            {
                defenseCheckBox.Checked = true;
            }
            else
            {
                defenseCheckBox.Checked = false;
                if (eligibility[0])
                {
                    tgDM.updateEligible(currThesisGroupID, "Defense");
                }
            }

            if (eligible_redef)
            {
                redefenseCheckBox.Checked = true;
            }
            else
            {
                redefenseCheckBox.Checked = false;
                if (eligibility[1])
                {
                    tgDM.updateEligible(currThesisGroupID, "Redefense");
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

            List<String>[] groupInfo;

            int memcount = tgDM.studentCount(currThesisGroupID);
            groupInfo = tgDM.getGroupMembers(currThesisGroupID, sortStudents.SelectedItem + "");

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
                for (int i = 0; i < 4; i++)
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

            List<String>[] groupInfo;

            int memcount = tgDM.panelistCount(currThesisGroupID);

            groupInfo = tgDM.getGroupPanelistNames(currThesisGroupID);

            for (int i = 0; i < 4; i++)
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

            if (currThesisGroupID == "")
            {
                selectAdviser.Enabled = false;
                return;
            }
            else
                selectAdviser.Enabled = true;

            selectAdviser.Items.Clear();
            selectAdviser.Items.Add("");

            List<String>[] panelists = tgDM.getGroupPanelists(currThesisGroupID);
            for (int i = 0; i < panelists[0].Count; i++)
            {
                selectAdviser.Items.Add(tgDM.getPanelistName(panelists[0].ElementAt(i)));
            }
        }

        //STUDENT LISTENERS
        private void edit_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

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
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

            String newID = studentDetails[studentIndex].ElementAt(0).Text;
            String newFirstName = studentDetails[studentIndex].ElementAt(1).Text;
            String newLastName = studentDetails[studentIndex].ElementAt(2).Text;
            String newMI = studentDetails[studentIndex].ElementAt(3).Text;

            List<String>[] result = tgDM.getGroupMembers(currThesisGroupID);
            List<String>[] studentsInGroups = tgDM.getAllStudents();

            if (newID == "" || newFirstName == "" || newLastName == "")
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (newMI.Length != 1)
            {
                MessageBox.Show("Invalid Middle Initial.", "Error", MessageBoxButtons.OK);
            }

            if (result[0].Count <= studentIndex)
            {
                for (int i = 0; i < studentsInGroups[0].Count; i++)
                {
                    if (studentsInGroups[0].ElementAt(i) == newID)
                    {
                        MessageBox.Show("Duplicate Entry, Student already in another thesis group.", "Error", MessageBoxButtons.OK);
                        update_students();
                        return;
                    }
                }

                tgDM.insertNewStudent(currThesisGroupID, newID, newFirstName, newMI, newLastName);
            }
            else if (result[0].ElementAt(studentIndex) == newID)
            {
                tgDM.updateStudent(result[0].ElementAt(studentIndex), newFirstName, newMI, newLastName);
            }
            else
            {
                for (int i = 0; i < studentsInGroups[0].Count; i++)
                {
                    if (studentsInGroups[0].ElementAt(i) == newID)
                    {
                        MessageBox.Show("Duplicate Entry, Student already in another thesis group.", "Error", MessageBoxButtons.OK);
                        update_students();
                        return;
                    }
                }

                String oldID = result[0].ElementAt(studentIndex);

                tgDM.deleteStudent(oldID);
                tgDM.insertNewStudent(currThesisGroupID, newID, newFirstName, newMI, newLastName); 
            }


            update_students();
        }
        private void delete_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(13)) - 1;

            if (currThesisGroupID == "")
                return;

            List<String>[] result = tgDM.getStudentInfo(studentDetails[studentIndex].ElementAt(0).Text);

            String name = result[0].ElementAt(0) + " - " + result[1].ElementAt(0) + " " + result[2].ElementAt(0) + ". " + result[3].ElementAt(0);

            DialogResult input = MessageBox.Show("Are you sure you want to delete student " + name + "?", "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                tgDM.deleteStudent(studentDetails[studentIndex].ElementAt(0).Text);
            }

            update_components();
        }
        private void changeStudentSort(object sender, EventArgs e)
        {
            update_components();
        }

        //PANELIST LISTENERS
        private void edit_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12)) - 1;

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
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12)) - 1;

            String query;

            String newID = panelistDetails[panelIndex].ElementAt(0).Text;
            String newFirstName = panelistDetails[panelIndex].ElementAt(1).Text;
            String newLastName = panelistDetails[panelIndex].ElementAt(2).Text;
            String newMI = panelistDetails[panelIndex].ElementAt(3).Text;

            List<String>[] result = tgDM.getGroupPanelists(currThesisGroupID);
            List<String>[] result2 = tgDM.getAllPanelists();

            if (newID == "" || newFirstName == "" || newLastName == "")
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (result[0].Count <= panelIndex)
            {
                for (int i = 0; i < result[0].Count; i++)
                {
                    if (result[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Assigned to Thesis Group", "Error", MessageBoxButtons.OK);
                        update_components();
                        return;
                    }
                }

                for (int i = 0; i < result2[0].Count; i++)
                {
                    if (result2[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Exists, use select existing", "Error", MessageBoxButtons.OK);
                        update_components();
                        return;
                    }
                }

                tgDM.insertNewPanelist(newID, newFirstName, newMI, newLastName);
                tgDM.assignPanelistToGroup(currThesisGroupID, newID);
            }
            else if (result[0].ElementAt(panelIndex).Equals(newID))
            {
                tgDM.updatePanelist(newID, newFirstName, newMI, newLastName);
            }
            else
            {
                for (int i = 0; i < result[0].Count; i++)
                {
                    if (result[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Assigned to Thesis Group", "Error", MessageBoxButtons.OK);
                        update_components();
                        return;
                    }
                }

                tgDM.removeAssignedPanelistFromGroup(currThesisGroupID, result[0].ElementAt(panelIndex));
                tgDM.insertNewPanelist(newID, newFirstName, newMI, newLastName);
                tgDM.assignPanelistToGroup(currThesisGroupID, newID);
            }

            update_components();
        }
        private void delete_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;
            String panelistID = panelistDetails[panelIndex].ElementAt(0).Text;

            if (currThesisGroupID == "")
                return;

            String query;
            List<String>[] result;

            result = tgDM.getPanelistInfo(panelistID);

            String name = result[0].ElementAt(0) + " " + result[1].ElementAt(0) + ". " + result[2].ElementAt(0);

            DialogResult input = MessageBox.Show("Are you sure you want to remove panelist " + name + "?", "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                tgDM.removeAssignedPanelistFromGroup(currThesisGroupID, panelistID);
            }

            update_components();
        }
        private void select_panel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

            if (currThesisGroupID == "")
                return;

            if (panelButtons[panelIndex].ElementAt(3).Text == "Select Existing")
            {
                update_components();

                panelButtons[panelIndex].ElementAt(3).Text = "Cancel Select";
                selPanel[panelIndex].Enabled = true;

                int memcount = tgDM.panelistNotInGroupCount(currThesisGroupID);
                List<String>[] result = tgDM.getPanelistsNotInGroup(currThesisGroupID);

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
        private void swapPanelists(object sender, EventArgs e)
        {
            ComboBox currPanel = (ComboBox)sender;
            int panelIndex = Convert.ToInt32(currPanel.Name.Substring(14)) - 1;
            int selected = selPanel[panelIndex].SelectedIndex;

            if (selPanel[panelIndex].SelectedItem + "" == "")
                return;

            String panelistID = panelistDetails[panelIndex].ElementAt(0).Text;
            String panelistName = selPanel[panelIndex].SelectedItem + "";

            if (panelistID == "")
            {
                panelistID = tgDM.getPanelistIDFromName(panelistName);
                tgDM.assignPanelistToGroup(currThesisGroupID, panelistID);
            }
            else
            {
                tgDM.removeAssignedPanelistFromGroup(currThesisGroupID, panelistID);
                panelistID = tgDM.getPanelistIDFromName(panelistName);
                tgDM.assignPanelistToGroup(currThesisGroupID, panelistID);
            }

            update_components();
        }
        private void selectedAdviser(object sender, EventArgs e)
        {
            if (selectAdviser.SelectedItem + "" == "")
            {
                tgDM.removeAdviser(currThesisGroupID);
                return;
            }

            String adviserID = tgDM.getPanelistIDFromName(selectAdviser.SelectedItem+"");

            tgDM.removeAdviser(currThesisGroupID);
            tgDM.updateAdviser(currThesisGroupID, adviserID);
        }

        //GROUP LISTENERS
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

            defenseCheckBox.Enabled = false;
            redefenseCheckBox.Enabled = false;
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

            int studentCount = tgDM.studentCount(currThesisGroupID);
            int panelCount = tgDM.panelistCount(currThesisGroupID);

            if (studentCount > 0 && panelCount >= 3)
            {
                defenseCheckBox.Enabled = true;
                redefenseCheckBox.Enabled = true;
            }
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
            String eligibility = defenseCheckBox.Checked + "";
            String eligibility_redef = redefenseCheckBox.Checked + "";

            String query;

            if (!currThesisGroupID.Equals(""))
            {
                Boolean duplicate = tgDM.checkIfTitleAlreadyExists(currThesisGroupID, newTitle);

                if (!duplicate)
                {
                    tgDM.updateGroup(currThesisGroupID, newTitle, newSection, newSY, newCourse, newTerm, eligibility, eligibility_redef);
                }
                else
                {
                    MessageBox.Show("Thesis Title \"" + newTitle + "\" already taken.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                currThesisGroupID = tgDM.getGroupIDFromTitle(newTitle);
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

                defenseCheckBox.Enabled = false;
                redefenseCheckBox.Enabled = false;
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

            tgDM.deleteGroup(currThesisGroupID);
            currThesisGroupID = "";

            update_components();
            update_treeview();
        }
    }
}