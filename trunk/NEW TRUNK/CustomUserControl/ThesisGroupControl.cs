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

        TextBox[] groupDetails; // details (title, section, SY)
        ComboBox[] groupStuff; // stuff (course, term)
        Button[] groupButtons; // buttons (edit, new, save, cancel)

        List<TextBox>[] studentDetails;
        List<Button>[] studentButtons;
        
        ComboBox[] selPanel;

        public ThesisGroupControl()
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
            /*
            for (int i = 0; i < 3; i++) student2.Controls.Add(studentButtons[1].ElementAt(i));
            for (int i = 0; i < 3; i++) student3.Controls.Add(studentButtons[2].ElementAt(i));
            for (int i = 0; i < 3; i++) student4.Controls.Add(studentButtons[3].ElementAt(i));
            */
            //panelists


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
            /*
            for (int i = 0; i < 4; i++) student2.Controls.Add(studentDetails[1].ElementAt(i));
            for (int i = 0; i < 4; i++) student3.Controls.Add(studentDetails[2].ElementAt(i));
            for (int i = 0; i < 4; i++) student4.Controls.Add(studentDetails[3].ElementAt(i));
             * */
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
                return;
            }

            String query = "select title, course, section, startSY, startTerm from thesisgroup where thesisgroupid = " + currThesisGroupID + ";";
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
                return;

            if (result[0].Count <= studentIndex)
            {
                query = "insert into student values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                query += newLastName + "', " + currThesisGroupID + ");";
                dbHandler.Insert(query);
            }
            else if (result[0].ElementAt(studentIndex) == newID)
            {
                query = "update student set firstname = '" + newFirstName + "', lastname = '" + newLastName + "', MI = '" + newMI + "' ";
                query += "where studentid = " + newID + ";";

                dbHandler.Update(query);
            }
            else
            {
                String oldID = result[0].ElementAt(studentIndex);

                query = "delete from student where studentID = " + oldID + ";";
                dbHandler.Delete(query);

                query = "insert into student values(" + newID + ", '" + newFirstName + "', '" + newMI + "', '";
                query += newLastName + "', " + currThesisGroupID + ");";
                dbHandler.Insert(query);
            }


            update_students();
        }

        private void delete_student_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            int studentIndex = Convert.ToInt32(pressed.Name.Substring(10));

            if (currThesisGroupID == "")
                return;

            String query;

            query = "delete from student where studentid = " + studentDetails[studentIndex].ElementAt(0).Text + ";";
            dbHandler.Delete(query);

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
        }

        private void save_groupDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                if (groupDetails[i].Text == "")
                    return;
            for (int i = 0; i < 2; i++)
                if (groupStuff[i].SelectedItem == null)
                    return;

            String newTitle = groupDetails[0].Text;
            String newSection = groupDetails[1].Text;
            String newSY = groupDetails[2].Text;
            String newCourse = (String)groupStuff[0].SelectedItem;
            String newTerm = (String)groupStuff[1].SelectedItem;

            if (currThesisGroupID != "")
            {
                String query = "update thesisgroup set title = '" + newTitle + "', course = '" + newCourse + "', section = '" + newSection + "', startSY = '" + newSY + "', startTerm = '" + newTerm + "' ";
                query += "where thesisgroupid = " + currThesisGroupID + ";";

                dbHandler.Update(query);
            }
            else
            {
                String query;
                List<String>[] result;

                String insert = "('" + newTitle + "', '" + newCourse + "', '" + newSection + "', '" + newSY + "', '" + newTerm + "')";
                query = "insert into thesisgroup (title, course, section, startsy, startterm) values" + insert + ";";
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