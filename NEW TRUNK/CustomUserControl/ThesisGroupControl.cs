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
        private String currThesisGroupID; // currently selected thesis group
        private String selectedPanelistID; // currently selected panelist
        private String selectedStudentID; // currently selected student
        private String selected; // most recently selected item, format: [gps] <id> (g for group, p for panelist, s for student, and id for the selected unit's id)

        private TextBox[] groupTextBox; // textboxes for the group; title, section, SY
        private ComboBox[] groupSelection; // comboboxes; course, term
        private Button[] groupButtons; // buttons; new group, edit, save, cancel, delete

        private TextBox[] panelistInfo; // textboxes hold details for panelists
        private ComboBox[] panelistList; // selection dropdown menus for panelists
        private Button[] panelistButtons; // action buttons; import, edit, save, cancel, delete

        private TextBox[] studentInfo; // student stuff same as panelists
        private ComboBox[] studentList;
        private Button[] studentButtons;

        public ThesisGroupControl()
        {
            dbHandler = new DBce();
            InitializeComponent();

            currThesisGroupID = "";
            selectedPanelistID = "";
            selectedStudentID = "";

            initPanels();
            initButtons();

            thesisGroupTreeView.NodeMouseClick += changeSelectedGroup;

            thesisGroupTreeView.BeginUpdate();
            fillTree(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();

            update_components();
        }

        private void initPanels()
        {
            //group
            groupTextBox = new TextBox[3]; // title, section, sy
            groupSelection = new ComboBox[2]; // course, term

            groupTextBox[0] = groupThesisTitle;
            groupTextBox[1] = groupSection;
            groupTextBox[2] = groupStartSY;

            groupSelection[0] = groupCourse;
            groupSelection[1] = groupStartTerm;

            for (int i = 0; i < 3; i++)
                groupTextBox[i].Enabled = false;
            for (int i = 0; i < 2; i++)
                groupSelection[i].Enabled = false;

            defenseCheckBox.Enabled = false;
            //redefenseCheckBox.Enabled = false;

            //panelists
            panelistList = new ComboBox[4];

            panelistList[0] = panelistBox1;
            panelistList[1] = panelistBox2;
            panelistList[2] = panelistBox3;
            panelistList[3] = panelistBox4;

            for (int i = 0; i < 4; i++)
            {
                panelistList[i].Items.Clear();
                panelistList[i].Items.Add("");
                panelistList[i].Enabled = false;
            }

            panelistInfo = new TextBox[4];

            panelistInfo[0] = panelID;
            panelistInfo[1] = panelFN;
            panelistInfo[2] = panelLN;
            panelistInfo[3] = panelMI;

            //students
            studentList = new ComboBox[4];

            studentList[0] = studentBox1;
            studentList[1] = studentBox2;
            studentList[2] = studentBox3;
            studentList[3] = studentBox4;

            for (int i = 0; i < 4; i++)
            {
                studentList[i].Items.Clear();
                studentList[i].Items.Add("");
                studentList[i].Enabled = false;
            }

            studentInfo = new TextBox[4];

            studentInfo[0] = studentID;
            studentInfo[1] = studentFN;
            studentInfo[2] = studentLN;
            studentInfo[3] = studentMI;
        }

        private void initButtons()
        {
            //button order: new, edit, save, cancel, delete

            //group
            groupButtons = new Button[5];

            groupButtons[0] = newThesisGroup;
            groupButtons[1] = editThesisGroup;
            groupButtons[2] = saveDetails;
            groupButtons[3] = cancelEdits;
            groupButtons[4] = deleteGroup;

            //panelist
            panelistButtons = new Button[5];

            panelistButtons[0] = newPanelist;
            panelistButtons[1] = editPanelist;
            panelistButtons[2] = savePanelist;
            panelistButtons[3] = cancelPanelist;
            panelistButtons[4] = deletePanelist;

            //student
            studentButtons = new Button[5];

            studentButtons[0] = newStudent;
            studentButtons[1] = editStudent;
            studentButtons[2] = saveStudent;
            studentButtons[3] = cancelStudent;
            studentButtons[4] = deleteStudent;
        }
        
        private void fillTree(TreeNodeCollection tree)
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

        private void changeSelectedGroup(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                currThesisGroupID = e.Node.Name;
                selectedPanelistID = "";
                selectedStudentID = "";
                update_components();
            }
        }

        private void update_components()
        {
            update_thesisgroup();
            update_panelist();
            update_student();
        }

        // TAPOS NA PO
        private void update_thesisgroup()
        {
            for (int i = 0; i < 3; i++)
                groupTextBox[i].Enabled = false;
            for (int i = 0; i < 2; i++)
                groupSelection[i].Enabled = false;
            for (int i = 0; i < 5; i++)
                groupButtons[i].Enabled = false;
            defenseCheckBox.Enabled = false;
            defenseCheckBox.Checked = false;
            //redefenseCheckBox.Enabled = false;
            //redefenseCheckBox.Checked = false;

            groupButtons[0].Enabled = true;

            if (currThesisGroupID == "")
                return;

            String query = "select * from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            List<String>[] groupInfo = dbHandler.Select(query, 8);

            groupTextBox[0].Text = groupInfo[1].ElementAt(0);
            groupTextBox[1].Text = groupInfo[3].ElementAt(0);
            groupTextBox[2].Text = groupInfo[4].ElementAt(0);

            groupSelection[0].SelectedIndex = groupSelection[0].Items.IndexOf(groupInfo[2].ElementAt(0));
            groupSelection[1].SelectedIndex = groupSelection[1].Items.IndexOf(groupInfo[5].ElementAt(0));

            if (groupInfo[6].ElementAt(0) != "")
                defenseCheckBox.Checked = Convert.ToBoolean(groupInfo[6].ElementAt(0));
            else
                defenseCheckBox.Checked = false;
            /*
            if (groupInfo[7].ElementAt(0) != "")
                redefenseCheckBox.Checked = Convert.ToBoolean(groupInfo[7].ElementAt(0));
            else
                redefenseCheckBox.Checked = false;
            */

            groupButtons[0].Enabled = true;
            groupButtons[1].Enabled = true;
            groupButtons[4].Enabled = false;
        }

        private void update_panelist()
        {
            for (int i = 0; i < 4; i++)
            {
                panelistInfo[i].Enabled = false;
                panelistList[i].Enabled = false;
            }

            for (int i = 0; i < 5; i++)
                panelistButtons[i].Enabled = false;

            if (currThesisGroupID == "")
                return;

            String query = "select count(*) from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            int panelCount = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            query = "select firstname, mi, lastname from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            List<String>[] resultSet = dbHandler.Select(query, 3);

            for (int i = 0; i < 4; i++)
            {
                panelistList[i].Items.Clear();
                if (i < panelCount)
                {
                    panelistList[i].Items.Add(resultSet[0].ElementAt(i) + " " + resultSet[1].ElementAt(i) + ". " + resultSet[2].ElementAt(i));
                }

                panelistList[i].Items.Add("");
                panelistList[i].SelectedIndex = 0;
            }

            if (selectedPanelistID == "")
                return;

            query = "select * from panelist where panelistid = " + selectedPanelistID + ";";
            resultSet = dbHandler.Select(query, 4);

            panelistInfo[0].Text = resultSet[0].ElementAt(0);
            panelistInfo[1].Text = resultSet[1].ElementAt(0);
            panelistInfo[2].Text = resultSet[2].ElementAt(0);
            panelistInfo[3].Text = resultSet[3].ElementAt(0);

            panelistButtons[0].Enabled = true;
            panelistButtons[1].Enabled = true;
            panelistButtons[2].Enabled = false;
            panelistButtons[3].Enabled = false;
            panelistButtons[4].Enabled = true;
        }

        private void update_student()
        {

        }

        // given which panelist (panelindex) and panelist's name
        private void setSelectedPanelist(int panelIndex, String panelistName)
        {
            if (panelistList[panelIndex].SelectedItem + "" == "")
            {
                selectedPanelistID = "";
                return;
            }

            String[] name = ((String)panelistList[panelIndex].SelectedItem).Split(' ');

            int middleIndex = 0;
            while (name[middleIndex].Length != 2)
                middleIndex++;

            String firstName = "";
            String middleInit = "";
            String lastName = "";
            for (int i = 0; i < middleIndex; i++)
            {
                firstName += name[i];
                if (i != middleIndex - 1)
                    firstName += " ";
            }

            middleInit = name[middleIndex];
            middleInit = middleInit.Substring(0, middleInit.Length - 1);
            for (int i = middleIndex + 1; i <= name.GetUpperBound(0); i++)
            {
                lastName += name[i];
                if (i != name.GetUpperBound(0))
                    lastName += " ";
            }

            String query = "select panelistID from panelist where firstname = '" + firstName + "' and MI = '" + middleInit + "' and lastname = '" + lastName + "';";
            selectedPanelistID = dbHandler.Select(query, 1)[0].ElementAt(0);
        }
        private void setSelectedStudent(int studentIndex, String studentName)
        {

        }

        // TAPOS NA RIN TO
        private void mouseEnter(object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
        }
        private void mouseLeave(object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.None;
        }
        private void clickPanel(object sender, EventArgs e)
        {
            if (currThesisGroupID == "")
                return;

            int panelIndex = Convert.ToInt32(((Panel)sender).Name.Substring(8)) - 1;

            for (int i = 0; i < 4; i++)
            {
                panelistList[i].Enabled = i == panelIndex;
                if (i == panelIndex)
                {
                    setSelectedPanelist(panelIndex, panelistList[i].SelectedItem + "");
                    Console.WriteLine(selectedPanelistID);
                }
            }
            update_components();
            panelistList[panelIndex].Enabled = true;
        }

        private void newGroupClick(object sender, EventArgs e)
        {
            currThesisGroupID = "";
            update_components();

            for (int i = 0; i < 3; i++)
            {
                groupTextBox[i].Enabled = true;
                groupTextBox[i].Text = "";
            }
            for (int i = 0; i < 2; i++)
            {
                groupSelection[i].Enabled = true;
                groupSelection[i].SelectedIndex = 0;
            }

            groupButtons[0].Enabled = false;
            groupButtons[1].Enabled = false;
            groupButtons[2].Enabled = true;
            groupButtons[3].Enabled = true;
            groupButtons[4].Enabled = false;
        }
        private void editGroupClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                groupTextBox[i].Enabled = true;
            for (int i = 0; i < 2; i++)
                groupSelection[i].Enabled = true;

            groupButtons[0].Enabled = false;
            groupButtons[1].Enabled = false;
            groupButtons[2].Enabled = true;
            groupButtons[3].Enabled = true;
            groupButtons[4].Enabled = false;

            String q1 = "select count(*) from student where thesisgroupid = " + currThesisGroupID + ";";
            String q2 = "select count(*) from panelassignment where thesisgroupid = " + currThesisGroupID + ";";

            if (Convert.ToInt32(dbHandler.Select(q1, 1)[0].ElementAt(0)) >= 1 && Convert.ToInt32(dbHandler.Select(q2, 1)[0].ElementAt(0)) >= 3)
            {
                defenseCheckBox.Enabled = true;
               // redefenseCheckBox.Enabled = true;
            }
        }
        private void saveGroupClick(object sender, EventArgs e)
        {
            String newTitle = groupThesisTitle.Text;
            String newCourse = groupCourse.SelectedItem + "";
            String newSection = groupSection.Text;
            String newSY = groupStartSY.Text;
            String newTerm = groupStartTerm.Text;
            String newDefEligible = defenseCheckBox.Checked + "";
            //String newRedefEligible = redefenseCheckBox.Checked + "";

            String query;
            List<String>[] resultSet;
            
            if (currThesisGroupID == "")
            {
                if (newTitle == "" || newCourse == "" || newSection == "" || newSY == "" || newTerm == "")
                {
                    MessageBox.Show("Please fill the incomplete fields.", "Error", MessageBoxButtons.OK);
                    return;
                }

                query = "insert into thesisgroup (title, course, section, startSY, startTerm, eligibleForDefense) values";
                query += "('" + newTitle + "', '" + newCourse + "', '" + newSection + "', '" + newSY + "', '" + newTerm + "', '" + newDefEligible + "');";
                dbHandler.Insert(query);

                query = "select thesisgroupid from thesisgroup where title = '" + newTitle + "';";
                currThesisGroupID = dbHandler.Select(query, 1)[0].ElementAt(0);
                update_components();
                return;
            }

            query = "select * from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            resultSet = dbHandler.Select(query, 8);

            String oldTitle = resultSet[1].ElementAt(0);
            String oldCourse = resultSet[2].ElementAt(0);
            String oldSection = resultSet[3].ElementAt(0);
            String oldSY = resultSet[4].ElementAt(0);
            String oldTerm = resultSet[5].ElementAt(0);
            String oldDefEligible = resultSet[6].ElementAt(0) + "";
            String oldRedefEligible = resultSet[7].ElementAt(0) + "";

            String showChanges = "Please review changes:\n";

            if (oldTitle != newTitle)
                showChanges += "Title: " + oldTitle + " -> " + newTitle + "\n";
            if (oldCourse != newCourse)
                showChanges += "Course: " + oldCourse + " -> " + newCourse + "\n";
            if (oldSection != newSection)
                showChanges += "Section: " + oldSection + " -> " + newSection + "\n";
            if (oldSY != newSY)
                showChanges += "Start SY: " + oldSY + " -> " + newSY + "\n";
            if (oldTerm != newTerm)
                showChanges += "Start Term: " + oldTerm + " -> " + newTerm + "\n";
            if (oldDefEligible != newDefEligible || oldDefEligible+"" == "")
                showChanges += "Eligibile for Defense: " + oldDefEligible + " -> " + newDefEligible + "\n";
            //if (oldRedefEligible != newRedefEligible || oldRedefEligible+"" == "")
              //  showChanges += "Eligible for Redefense: " + oldRedefEligible + " -> " + newRedefEligible + "\n";

            if (showChanges.Length != 0)
            {
                DialogResult result1 = MessageBox.Show(showChanges, "Saving Group", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    query = "update thesisgroup set title = '" + newTitle + "', course = '" + newCourse + "', section = '" + newSection + "', startSY = '" + newSY + "', startTerm = '" + newTerm + "'";
                    query += ", eligiblefordefense = '" + newDefEligible + "', where thesisgroupid = " + currThesisGroupID + ";";

                    dbHandler.Update(query);
                }
            }

            update_components();
        }
        private void cancelGroupClick(object sender, EventArgs e)
        {
            update_components();
        }
        // DI GUMAGANA YET
        /* private void deleteGroupClick(object sender, EventArgs e)
        {
            String query = "insert into defenseschedule (thesisgroupid) values (" + currThesisGroupID + ");";
            dbHandler.Insert(query);

            query = "delete from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
            dbHandler.Delete(query);

            currThesisGroupID = "";
            update_components();
        }
        */


        private void newPanelistClick(object sender, EventArgs e)
        {

        }
        private void editPanelistClick(object sender, EventArgs e)
        {

        }
        private void savePanelistClick(object sender, EventArgs e)
        {

        }
        private void cancelPanelistClick(object sender, EventArgs e)
        {

        }
        private void deletePanelistClick(object sender, EventArgs e)
        {

        }

        private void comboBoxListenerPanelist(object sender, EventArgs e)
        {
            int panelIndex = Convert.ToInt32(((Panel)sender).Name.Substring(11)) - 1;

        }

        /* todo list:
         * listeners for panelist & student buttons
         * listeners for panelist & student comboboxes
         * do something about repeated thesis titles
         */
    }
}