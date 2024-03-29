﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomUserControl
{
    public partial class ThesisGroupControl : UserControl
    {
        private ThesisGroupDataManager tgDM;
        private String currThesisGroupID; // currently selected thesis group

        private TextBox[] groupDetails; // details (title, section, SY)
        private ComboBox[] groupDetails2; // dropdown details (course, term)
        private ComboBox[] selPanel; // panelist selection comboboxes
        private Button[] groupButtons; // buttons (edit, new, save, cancel)
        private List<TextBox>[] studentDetails;
        private List<TextBox>[] panelistDetails;
        private List<Button>[] studentButtons;
        private List<Button>[] panelistButtons;

        public ThesisGroupControl()
        {
            tgDM = new ThesisGroupDataManager();
            InitializeComponent();

            currThesisGroupID = "";

            InitDB();
            InitButtons();
            InitPanels();
            
            thesisGroupTreeView.BeginUpdate();
            tgDM.ShowGroups(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }

        //INITIALIZERS
        private void InitButtons()
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
            studentButtons[0].ElementAt(0).Click += new System.EventHandler(editStudent_Click);
            studentButtons[0].Add(saveStudent1);
            studentButtons[0].ElementAt(1).Click += new System.EventHandler(saveStudent_Click);
            studentButtons[0].Add(deleteStudent1);
            studentButtons[0].ElementAt(2).Click += new System.EventHandler(deleteStudent_Click);
            
            studentButtons[1] = new List<Button>();
            studentButtons[1].Add(editStudent2);
            studentButtons[1].ElementAt(0).Click += new System.EventHandler(editStudent_Click);
            studentButtons[1].Add(saveStudent2);
            studentButtons[1].ElementAt(1).Click += new System.EventHandler(saveStudent_Click);
            studentButtons[1].Add(deleteStudent2);
            studentButtons[1].ElementAt(2).Click += new System.EventHandler(deleteStudent_Click);
            
            studentButtons[2] = new List<Button>();
            studentButtons[2].Add(editStudent3);
            studentButtons[2].ElementAt(0).Click += new System.EventHandler(editStudent_Click);
            studentButtons[2].Add(saveStudent3);
            studentButtons[2].ElementAt(1).Click += new System.EventHandler(saveStudent_Click);
            studentButtons[2].Add(deleteStudent3);
            studentButtons[2].ElementAt(2).Click += new System.EventHandler(deleteStudent_Click);

            studentButtons[3] = new List<Button>();
            studentButtons[3].Add(editStudent4);
            studentButtons[3].ElementAt(0).Click += new System.EventHandler(editStudent_Click);
            studentButtons[3].Add(saveStudent4);
            studentButtons[3].ElementAt(1).Click += new System.EventHandler(saveStudent_Click);
            studentButtons[3].Add(deleteStudent4);
            studentButtons[3].ElementAt(2).Click += new System.EventHandler(deleteStudent_Click);

            // panelists

            panelistButtons = new List<Button>[4]; // 4 panelists

            panelistButtons[0] = new List<Button>();
            panelistButtons[0].Add(editPanelist1);
            panelistButtons[0].ElementAt(0).Click += new System.EventHandler(editPanel_Click);
            panelistButtons[0].Add(savePanelist1);
            panelistButtons[0].ElementAt(1).Click += new System.EventHandler(savePanel_Click);
            panelistButtons[0].Add(delPanelist1);
            panelistButtons[0].ElementAt(2).Click += new System.EventHandler(deletePanel_Click);
            panelistButtons[0].Add(selPanelist1);
            panelistButtons[0].ElementAt(3).Click += new System.EventHandler(selectPanel_Click);

            panelistButtons[1] = new List<Button>();
            panelistButtons[1].Add(editPanelist2);
            panelistButtons[1].ElementAt(0).Click += new System.EventHandler(editPanel_Click);
            panelistButtons[1].Add(savePanelist2);
            panelistButtons[1].ElementAt(1).Click += new System.EventHandler(savePanel_Click);
            panelistButtons[1].Add(delPanelist2);
            panelistButtons[1].ElementAt(2).Click += new System.EventHandler(deletePanel_Click);
            panelistButtons[1].Add(selPanelist2);
            panelistButtons[1].ElementAt(3).Click += new System.EventHandler(selectPanel_Click);

            panelistButtons[2] = new List<Button>();
            panelistButtons[2].Add(editPanelist3);
            panelistButtons[2].ElementAt(0).Click += new System.EventHandler(editPanel_Click);
            panelistButtons[2].Add(savePanelist3);
            panelistButtons[2].ElementAt(1).Click += new System.EventHandler(savePanel_Click);
            panelistButtons[2].Add(delPanelist3);
            panelistButtons[2].ElementAt(2).Click += new System.EventHandler(deletePanel_Click);
            panelistButtons[2].Add(selPanelist3);
            panelistButtons[2].ElementAt(3).Click += new System.EventHandler(selectPanel_Click);

            panelistButtons[3] = new List<Button>();
            panelistButtons[3].Add(editPanelist4);
            panelistButtons[3].ElementAt(0).Click += new System.EventHandler(editPanel_Click);
            panelistButtons[3].Add(savePanelist4);
            panelistButtons[3].ElementAt(1).Click += new System.EventHandler(savePanel_Click);
            panelistButtons[3].Add(delPanelist4);
            panelistButtons[3].ElementAt(2).Click += new System.EventHandler(deletePanel_Click);
            panelistButtons[3].Add(selPanelist4);
            panelistButtons[3].ElementAt(3).Click += new System.EventHandler(selectPanel_Click);
        }
        private void InitPanels()
        {
            // thesis groups
            groupDetails = new TextBox[3];
            groupDetails[0] = groupThesisTitle;
            groupDetails[1] = groupSection;
            groupDetails[2] = groupStartSY;

            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = false;

            groupDetails2 = new ComboBox[2];
            groupDetails2[0] = groupCourse;
            groupDetails2[1] = groupStartTerm;

            for (int i = 0; i < 2; i++)
                groupDetails2[i].Enabled = false;

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
        private void InitDB()
        {
            tgDM.FixRedefenseCol();
        }

        // UPDATES/REFRESHES
        public void RefreshAll() 
        {
            Cursor.Current = Cursors.WaitCursor;
            Refresh();
            UpdateTreeview();
            Cursor.Current = Cursors.Arrow;
        }
        private void UpdateTreeview()
        {
            thesisGroupTreeView.BeginUpdate();
            thesisGroupTreeView.Nodes.Clear();
            tgDM.ShowGroups(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
        }
        private void UpdateComponents()
        {
            // update thesis group details
            UpdateThesisGroup();
            // update student details (and the buttons too)
            UpdateStudents();
            // update panelist details (the buttons too why not)
            UpdatePanelists();
        }
        private void UpdateThesisGroup()
        {
            labelEligibleNeeds.Text = "";

            if (String.IsNullOrEmpty(currThesisGroupID))
            {
                for (int i = 0; i < 3; i++)
                {
                    groupDetails[i].Enabled = false;
                    groupDetails[i].Text = "";
                }
                for (int i = 0; i < 2; i++)
                {
                    groupDetails2[i].Enabled = false;
                    groupDetails2[i].SelectedItem = "";
                }

                groupButtons[0].Enabled = false;
                groupButtons[1].Enabled = true;
                groupButtons[2].Enabled = false;
                groupButtons[3].Enabled = false;
                groupButtons[4].Enabled = false;

                defenseCheckBox.Enabled = false;
                defenseCheckBox.Checked = false;
                redefenseCheckBox.Enabled = false;
                redefenseCheckBox.Checked = false;
                return;
            }

            List<String>[] groupInfo = tgDM.GetGroupInfo(currThesisGroupID);

            groupDetails[0].Text = groupInfo[0].ElementAt(0);
            groupDetails2[0].SelectedItem = groupInfo[1].ElementAt(0);
            groupDetails[1].Text = groupInfo[2].ElementAt(0);
            groupDetails[2].Text = groupInfo[3].ElementAt(0);
            groupDetails2[1].SelectedItem = groupInfo[4].ElementAt(0);

            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = false;

            for (int i = 0; i < 2; i++)
                groupDetails2[i].Enabled = false;

            groupButtons[0].Enabled = true;
            groupButtons[1].Enabled = true;
            groupButtons[2].Enabled = false;
            groupButtons[3].Enabled = false;
            groupButtons[4].Enabled = true;

            defenseCheckBox.Enabled = false;
            redefenseCheckBox.Enabled = false;

            int studentCount = tgDM.StudentCount(currThesisGroupID);
            int panelCount = tgDM.PanelistCount(currThesisGroupID);

            if (studentCount > 0 && panelCount >= 3)
            {
                defenseCheckBox.Enabled = true;
                redefenseCheckBox.Enabled = true;
            }
            
            if (studentCount == 0)
            {
                labelEligibleNeeds.Text += "No students in group.";
            }
            if (panelCount < 3)
            {
                labelEligibleNeeds.Text += "\nGroup must have at least 3 panelists.";
            }

            Boolean[] eligibility = tgDM.GetEligibilities(currThesisGroupID);

            Boolean eligible = eligibility[0];
            Boolean eligible_redef = eligibility[1];

            if (eligible)
            {
                defenseCheckBox.Checked = true;
            }
            else
            {
                defenseCheckBox.Checked = false;
            }

            if (eligible_redef)
            {
                redefenseCheckBox.Checked = true;
            }
            else
            {
                redefenseCheckBox.Checked = false;
            }

            groupDetails2[0].SelectedItem = "";
            groupDetails2[1].SelectedItem = "";
        }
        private void UpdateStudents()
        {
            if (String.IsNullOrEmpty(currThesisGroupID))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        studentDetails[i].ElementAt(j).Text = "";
                        studentDetails[i].ElementAt(j).Enabled = false;
                    }

                    studentButtons[i].ElementAt(0).Text = "Add";
                    studentButtons[i].ElementAt(0).Enabled = true;
                    studentButtons[i].ElementAt(1).Enabled = false;
                    studentButtons[i].ElementAt(2).Enabled = false;
                }
                return;
            }

            List<String>[] groupInfo;

            int memcount = tgDM.StudentCount(currThesisGroupID);
            groupInfo = tgDM.GetGroupMembers(currThesisGroupID);

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
                    studentButtons[i].ElementAt(0).Enabled = true;
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
                    studentButtons[i].ElementAt(0).Enabled = true;
                    studentButtons[i].ElementAt(1).Enabled = false;
                    studentButtons[i].ElementAt(2).Enabled = true;
                }
            }

        }
        private void UpdatePanelists()
        {
            if (String.IsNullOrEmpty(currThesisGroupID))
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

                    panelistButtons[i].ElementAt(0).Text = "Add";
                    panelistButtons[i].ElementAt(0).Enabled = true;
                    panelistButtons[i].ElementAt(1).Enabled = false;
                    panelistButtons[i].ElementAt(2).Enabled = false;
                    panelistButtons[i].ElementAt(3).Text = "Select Existing";
                    panelistButtons[i].ElementAt(3).Enabled = true;
                }
                return;
            }

            List<String>[] groupInfo;

            int memcount = tgDM.PanelistCount(currThesisGroupID);

            groupInfo = tgDM.GetGroupPanelistNames(currThesisGroupID);

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

                    panelistButtons[i].ElementAt(0).Text = "Add";
                    panelistButtons[i].ElementAt(0).Enabled = true;
                    panelistButtons[i].ElementAt(1).Enabled = false;
                    panelistButtons[i].ElementAt(2).Enabled = false;
                    panelistButtons[i].ElementAt(3).Text = "Select Existing";
                    panelistButtons[i].ElementAt(3).Enabled = true;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        panelistDetails[i].ElementAt(j).Text = groupInfo[j].ElementAt(i);
                        panelistDetails[i].ElementAt(j).Enabled = false;
                    }

                    panelistButtons[i].ElementAt(0).Text = "Edit";
                    panelistButtons[i].ElementAt(0).Enabled = true;
                    panelistButtons[i].ElementAt(1).Enabled = false;
                    panelistButtons[i].ElementAt(2).Enabled = true;
                    panelistButtons[i].ElementAt(3).Text = "Select Existing";
                    panelistButtons[i].ElementAt(3).Enabled = true;
                }
            }

            if (String.IsNullOrEmpty(currThesisGroupID))
            {
                selectAdviser.Enabled = false;
                return;
            }
            else
                selectAdviser.Enabled = true;

            selectAdviser.Items.Clear();
            selectAdviser.Items.Add("");

            List<String>[] panelists = tgDM.GetGroupPanelists(currThesisGroupID);
            for (int i = 0; i < panelists[0].Count; i++)
            {
                selectAdviser.Items.Add(tgDM.GetPanelistName(panelists[0].ElementAt(i)));
            }

            selectAdviser.SelectedItem = tgDM.GetPanelistName(tgDM.GetAdviserID(currThesisGroupID));
        }

        //STUDENT LISTENERS
        private void editStudent_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            if (pressed.Text.Equals("Edit")) // editing
            {
                UpdateStudents();

                for (int i = 0; i < studentDetails[studentIndex].Count; i++)
                    studentDetails[studentIndex].ElementAt(i).Enabled = true;
                
                studentButtons[studentIndex].ElementAt(1).Enabled = true;
                studentButtons[studentIndex].ElementAt(0).Text = "Cancel";
            }
            else if (pressed.Text.Equals("Add")) // duh
            {
                UpdateStudents();

                for (int i = 0; i < studentDetails[studentIndex].Count; i++)
                    studentDetails[studentIndex].ElementAt(i).Enabled = true;

                studentButtons[studentIndex].ElementAt(1).Enabled = true;
                studentButtons[studentIndex].ElementAt(0).Text = "Cancel";
            }
            else // cancel editing/adding
            {
                UpdateStudents();
            }
        }
        private void saveStudent_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

            String newID = studentDetails[studentIndex].ElementAt(0).Text;
            String newFirstName = studentDetails[studentIndex].ElementAt(1).Text;
            String newLastName = studentDetails[studentIndex].ElementAt(2).Text;
            String newMI = studentDetails[studentIndex].ElementAt(3).Text;

            List<String>[] result = tgDM.GetGroupMembers(currThesisGroupID);
            List<String>[] studentsInGroups = tgDM.GetAllStudents();

            if (String.IsNullOrEmpty(newID) || String.IsNullOrEmpty(newFirstName) || String.IsNullOrEmpty(newLastName))
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            //lolcode
            if (String.IsNullOrEmpty(newMI))
            {
            }
            else if (newMI[0] >= 'a' && newMI[0] <= 'z')
            {
                newMI = newMI.ToUpper();
            }
            else if (newMI[0] < 'A' || newMI[0] > 'Z')
            {
                MessageBox.Show("Invalid Middle Initial, Middle Initial must be a letter.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!Regex.IsMatch(newID, "\\d{8}$"))
            {
                MessageBox.Show("Invalid ID Number, ID must be a sequence of 8 numbers.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (tgDM.HasDefenseSchedule(currThesisGroupID))
            {
                DialogResult confirm = MessageBox.Show("This will cause the deletion of the currently selected group's defense schedule. Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            if (result[0].Count <= studentIndex)
            {
                for (int i = 0; i < studentsInGroups[0].Count; i++)
                {
                    if (studentsInGroups[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Duplicate Entry, Student already in another thesis group.", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);
                tgDM.InsertNewStudent(currThesisGroupID, newID, newFirstName, newMI, newLastName);
            }
            else if (result[0].ElementAt(studentIndex).Equals(newID))
            {
                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);
                tgDM.UpdateStudent(result[0].ElementAt(studentIndex), newFirstName, newMI, newLastName);
            }
            else
            {
                for (int i = 0; i < studentsInGroups[0].Count; i++)
                {
                    if (studentsInGroups[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Duplicate Entry, Student already in another thesis group.", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                String oldID = result[0].ElementAt(studentIndex);


                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);

                tgDM.DeleteStudent(oldID);
                tgDM.InsertNewStudent(currThesisGroupID, newID, newFirstName, newMI, newLastName);
            }

            UpdateComponents();
        }
        private void deleteStudent_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(13)) - 1;

            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            List<String>[] result = tgDM.GetStudentInfo(studentDetails[studentIndex].ElementAt(0).Text);

            String name = "Are you sure you want to delete student " + result[0].ElementAt(0) + " - " + result[1].ElementAt(0) + " " + result[2].ElementAt(0) + ". " + result[3].ElementAt(0) + "?";
            String defenseSked = "\nThe defense schedule assigned to this group will be deleted as well.";

            if (tgDM.HasDefenseSchedule(currThesisGroupID))
            {
                name += defenseSked;
            }

            DialogResult input = MessageBox.Show(name, "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                tgDM.DeleteStudent(studentDetails[studentIndex].ElementAt(0).Text);
                tgDM.DeleteDefenseSchedule(currThesisGroupID);
            }
            else
            {
                return;
            }

            UpdateComponents();
        }

        //PANELIST LISTENERS
        private void editPanel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12)) - 1;

            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            if (pressed.Text.Equals("Edit")) // editing
            {
                UpdatePanelists();

                for (int i = 0; i < studentDetails[panelIndex].Count; i++)
                    panelistDetails[panelIndex].ElementAt(i).Enabled = true;

                panelistButtons[panelIndex].ElementAt(1).Enabled = true;
                panelistButtons[panelIndex].ElementAt(0).Text = "Cancel";
            }
            else if (pressed.Text.Equals("Add")) // duh
            {
                UpdatePanelists();

                for (int i = 0; i < panelistDetails[panelIndex].Count; i++)
                    panelistDetails[panelIndex].ElementAt(i).Enabled = true;

                panelistButtons[panelIndex].ElementAt(1).Enabled = true;
                panelistButtons[panelIndex].ElementAt(0).Text = "Cancel";
            }
            else // cancel editing/adding
            {
                UpdatePanelists();
            }
        }
        private void savePanel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(12)) - 1;

            String newID = panelistDetails[panelIndex].ElementAt(0).Text;
            String newFirstName = panelistDetails[panelIndex].ElementAt(1).Text;
            String newLastName = panelistDetails[panelIndex].ElementAt(2).Text;
            String newMI = panelistDetails[panelIndex].ElementAt(3).Text;

            if (String.IsNullOrEmpty(newID) || String.IsNullOrEmpty(newFirstName) || String.IsNullOrEmpty(newLastName))
            {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (newMI.Length == 1)
            {
                if (newMI[0] >= 'a' && newMI[0] <= 'z')
                {
                    newMI = newMI.ToUpper();
                }
                else if (newMI[0] < 'A' || newMI[0] > 'Z')
                {
                    MessageBox.Show("Invalid Middle Initial, Middle Initial must be a letter.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            if (!Regex.IsMatch(newID, "\\d{8}$"))
            {
                MessageBox.Show("Invalid ID Number, ID must be a sequence of 8 numbers.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (tgDM.HasDefenseSchedule(currThesisGroupID))
            {
                DialogResult confirm = MessageBox.Show("This will cause the deletion of the currently selected group's defense schedule. Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            List<String>[] result = tgDM.GetGroupPanelists(currThesisGroupID);
            List<String>[] result2 = tgDM.GetPanelistsNotInGroup(currThesisGroupID);

            if (result[0].Count <= panelIndex) // NEW PANELIST
            {
                for (int i = 0; i < result[0].Count; i++)
                {
                    if (result[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Assigned to Thesis Group", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                for (int i = 0; i < result2[0].Count; i++)
                {
                    if (result2[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Exists, use select existing", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);
                tgDM.InsertNewPanelist(newID, newFirstName, newMI, newLastName);
                tgDM.AssignPanelistToGroup(currThesisGroupID, newID);
            }
            else if (result[0].ElementAt(panelIndex).Equals(newID))
            {
                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);
                tgDM.UpdatePanelist(newID, newFirstName, newMI, newLastName);
            }
            else
            {
                for (int i = 0; i < result[0].Count; i++)
                {
                    if (result[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Assigned to Thesis Group", "Error", MessageBoxButtons.OK);
                        UpdateComponents();
                        return;
                    }
                }

                for (int i = 0; i < result2[0].Count; i++)
                {
                    if (result2[0].ElementAt(i).Equals(newID))
                    {
                        MessageBox.Show("Panelist Already Exists, use select existing", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                tgDM.DeleteDefenseSchedule(currThesisGroupID);
                tgDM.RemoveAssignedPanelistFromGroup(currThesisGroupID, result[0].ElementAt(panelIndex));
                tgDM.InsertNewPanelist(newID, newFirstName, newMI, newLastName);
                tgDM.AssignPanelistToGroup(currThesisGroupID, newID);
            }

            UpdateComponents();
        }
        private void deletePanel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;
            String panelistID = panelistDetails[panelIndex].ElementAt(0).Text;

            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            List<String>[] result;

            result = tgDM.GetPanelistInfo(panelistID);

            String name = "Are you sure you want to remove panelist " + result[0].ElementAt(0) + " " + result[1].ElementAt(0) + ". " + result[2].ElementAt(0) + "?";
            String defenseSked = "\nThe defense schedule assigned to this group will be deleted as well.";

            if (tgDM.HasDefenseSchedule(currThesisGroupID))
            {
                name += defenseSked;
            }

            DialogResult input = MessageBox.Show(name, "Confirm", MessageBoxButtons.YesNo);

            if (input == DialogResult.Yes)
            {
                if (tgDM.GetAdviserID(currThesisGroupID) == panelistID)
                {
                    tgDM.RemoveAdviser(currThesisGroupID);
                    selectAdviser.SelectedIndex = 0;
                }

                tgDM.RemoveAssignedPanelistFromGroup(currThesisGroupID, panelistID);
                tgDM.DeleteDefenseSchedule(currThesisGroupID);
            }
            else
            {
                return;
            }

            UpdateComponents();
        }
        private void selectPanel_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int panelIndex = Convert.ToInt32(pressed.Name.Substring(11)) - 1;

            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            if (panelistButtons[panelIndex].ElementAt(3).Text.Equals("Select Existing"))
            {
                UpdateComponents();

                panelistButtons[panelIndex].ElementAt(3).Text = "Cancel Select";
                selPanel[panelIndex].Enabled = true;

                int memcount = tgDM.PanelistNotInGroupCount(currThesisGroupID);
                List<String>[] result = tgDM.GetPanelistsNotInGroup(currThesisGroupID);

                for (int i = 0; i < memcount; i++)
                    selPanel[panelIndex].Items.Add(result[1].ElementAt(i) + " " + result[2].ElementAt(i) + ". " + result[3].ElementAt(i));
            }
            else
            {
                panelistButtons[panelIndex].ElementAt(3).Text = "Select Existing";
                selPanel[panelIndex].Items.Clear();

                UpdateComponents();
            }
        }
        private void swapPanelists(object sender, EventArgs e) 
        {
            ComboBox currPanel = (ComboBox)sender;
            int panelIndex = Convert.ToInt32(currPanel.Name.Substring(14)) - 1;
            int selected = selPanel[panelIndex].SelectedIndex;

            if (String.IsNullOrEmpty(selPanel[panelIndex].SelectedItem + ""))
                return;

            String panelistID = panelistDetails[panelIndex].ElementAt(0).Text;
            String panelistName = selPanel[panelIndex].SelectedItem + "";

            if (tgDM.HasDefenseSchedule(currThesisGroupID)) {
                DialogResult confirm = MessageBox.Show("This will cause the deletion of the currently selected group's defense schedule. Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            if (String.IsNullOrEmpty(panelistID))
            {
                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.DeleteDefenseSchedule(currThesisGroupID);
                panelistID = tgDM.GetPanelistIDFromName(panelistName);
                tgDM.AssignPanelistToGroup(currThesisGroupID, panelistID);
            }
            else
            {
                if (panelistID.Equals(tgDM.GetAdviserID(currThesisGroupID))) {
                    DialogResult input = MessageBox.Show("Replacing adviser. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (input == DialogResult.No)
                    {
                        UpdateComponents();
                        return;
                    }
                    else
                    {
                        tgDM.RemoveAdviser(currThesisGroupID);
                    }
                }

                if (tgDM.HasDefenseSchedule(currThesisGroupID))
                    tgDM.RemoveAssignedPanelistFromGroup(currThesisGroupID, panelistID);
                tgDM.RemoveAssignedPanelistFromGroup(currThesisGroupID, panelistID);
                panelistID = tgDM.GetPanelistIDFromName(panelistName);
                tgDM.AssignPanelistToGroup(currThesisGroupID, panelistID);
            }

            UpdateComponents();
        }
        private void selectedAdviser(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(selectAdviser.SelectedItem + ""))
            {
                tgDM.RemoveAdviser(currThesisGroupID);
                return;
            }

            String adviserID = tgDM.GetPanelistIDFromName(selectAdviser.SelectedItem+"");

            tgDM.RemoveAdviser(currThesisGroupID);
            tgDM.UpdateAdviser(currThesisGroupID, adviserID);
        }

        //GROUP LISTENERS
        private void newThesisGroup_Click(object sender, EventArgs e)
        {
            currThesisGroupID = "";
            UpdateComponents();

            for (int i = 0; i < 3; i++)
            {
                groupDetails[i].Enabled = true;
                groupDetails[i].Text = "";
            }
            for (int i = 0; i < 2; i++)
            {
                groupDetails2[i].Enabled = true;
                groupDetails2[i].SelectedItem = null;
            }

            groupButtons[1].Enabled = false;
            groupButtons[2].Enabled = true;
            groupButtons[3].Enabled = true;

            defenseCheckBox.Enabled = false;
            defenseCheckBox.Checked = false;
            redefenseCheckBox.Enabled = false;
            redefenseCheckBox.Checked = false;
        }
        private void editGroupDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                groupDetails[i].Enabled = true;
            for (int i = 0; i < 2; i++)
                groupDetails2[i].Enabled = true;

            groupButtons[0].Enabled = false;
            groupButtons[2].Enabled = true;
            groupButtons[3].Enabled = true;

            int studentCount = tgDM.StudentCount(currThesisGroupID);
            int panelCount = tgDM.PanelistCount(currThesisGroupID);

            if (studentCount > 0 && panelCount >= 3)
            {
                defenseCheckBox.Enabled = true;
                redefenseCheckBox.Enabled = true;
            }
        }
        private void saveGroupDetails_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(groupDetails[0].Text)) {
                MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            for (int i = 0; i < 3; i++)
                if (String.IsNullOrEmpty(groupDetails[i].Text))
                {
                    MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                    return;
                }
            for (int i = 0; i < 2; i++)
                if (groupDetails2[i].SelectedItem == null)
                {
                    MessageBox.Show("Please fill incomplete fields.", "Error", MessageBoxButtons.OK);
                    return;
                }

            String newTitle = groupDetails[0].Text;
            String newSection = groupDetails[1].Text;
            String newSY = groupDetails[2].Text;
            String newCourse = (String)groupDetails2[0].SelectedItem;
            String newTerm = (String)groupDetails2[1].SelectedItem;
            if (!Regex.IsMatch(newSY, "\\d{4}-\\d{4}$"))
            {
                MessageBox.Show("Invalid school year format, format is <year>-<year+1>.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!Regex.IsMatch(newSection, "S\\d{2}$"))
            {
                MessageBox.Show("Invalid section format, format is S<section number>.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!currThesisGroupID.Equals(""))
            {
                Boolean duplicate = tgDM.CheckIfTitleAlreadyExists(currThesisGroupID, newTitle);

                if (!duplicate)
                {
                    tgDM.UpdateGroupDetails(currThesisGroupID, newTitle, newSection, newSY, newCourse, newTerm);
                }
                else
                {
                    MessageBox.Show("Thesis Title \"" + newTitle + "\" already taken.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                tgDM.InsertNewGroup(newTitle, newCourse, newSection, newSY, newTerm);
                currThesisGroupID = tgDM.GetGroupIDFromTitle(newTitle);
            }

            UpdateComponents();
            UpdateTreeview();
        }
        private void cancelEdits_Click(object sender, EventArgs e)
        {
            UpdateComponents();
        }
        private void deleteGroup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(currThesisGroupID))
                return;

            String thesisTitle = tgDM.GetGroupInfo(currThesisGroupID)[0].ElementAt(0);
            DialogResult input = MessageBox.Show("Deleting Thesis Group - " + thesisTitle + "\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (input == DialogResult.Yes) {
                tgDM.DeleteGroup(currThesisGroupID);
                currThesisGroupID = "";

                UpdateComponents();
                UpdateTreeview();
            }
        }
        private void defenseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            String eligible = defenseCheckBox.Checked + "";
            if (!String.IsNullOrEmpty(currThesisGroupID))
            {
                tgDM.UpdateEligible(currThesisGroupID, eligible, redefenseCheckBox.Checked + "");
            }
        }
        private void redefenseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            String eligible = redefenseCheckBox.Checked + "";
            if (!String.IsNullOrEmpty(currThesisGroupID))
                tgDM.UpdateEligible(currThesisGroupID, defenseCheckBox.Checked + "", eligible);
        }

        //TREEVIEW LISTENER
        private void changeSelectedGroup(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                currThesisGroupID = e.Node.Name;
                UpdateComponents();
            }
        }
    }
}