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
        private String selectedPanelist; // currently selected panelist
        private String selectedStudent; // currently selected student

        private TextBox[] groupTextBox;
        private ComboBox[] groupSelection;
        private Button[] groupButtons;

        private Label[] selectPanelists;
        private TextBox[] panelistInfo;
        private ComboBox[] panelistList;
        private Button[] panelistButtons;

        private TextBox[] studentInfo;
        private ComboBox[] studentList;
        private Button[] studentButtons;

        public ThesisGroupControl()
        {
            dbHandler = new DBce();
            InitializeComponent();

            currThesisGroupID = "";
            selectedPanelist = "";
            selectedStudent = "";

            initPanels();
            initButtons();

            thesisGroupTreeView.NodeMouseClick += thesisGroupTreeView_NodeMouseClick;

            for (int i = 0; i < 4; i++)
            {
                panelistList[i].SelectedIndexChanged += changed_selected_index;
            }

            thesisGroupTreeView.BeginUpdate();
            AddPanelistsToTree(thesisGroupTreeView.Nodes);
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
            }

            panelistInfo = new TextBox[4];

            panelistInfo[0] = panelID;
            panelistInfo[1] = panelFN;
            panelistInfo[2] = panelLN;
            panelistInfo[3] = panelMI;

            selectPanelists = new Label[4];

            selectPanelists[0] = selectPanel1;
            selectPanelists[1] = selectPanel2;
            selectPanelists[2] = selectPanel3;
            selectPanelists[3] = selectPanel4;

            for (int i = 0; i < 4; i++)
            {
                selectPanelists[i].Click += select_panel_click;
            }

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
                currThesisGroupID = e.Node.Name;
                update_components();
            }
        }

        private void update_components()
        {
            selectedStudent = "";

            update_panelist();
        }

        private void update_panelist()
        {
            if (currThesisGroupID == "")
            {
                for (int i = 0; i < 4; i++)
                {
                    panelistList[i].Items.Clear();
                    panelistList[i].Items.Add("");
                    panelistList[i].Enabled = false;
                    panelistInfo[i].Enabled = false;
                }

                for (int i = 0; i < 5; i++)
                {
                    panelistButtons[i].Enabled = false;
                }


                return;
            }

            String query;
            List<String>[] resultSet;

            query = "select count(*) from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            int memcount = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            query = "select firstname, MI, lastname from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ") order by lastname;";
            resultSet = dbHandler.Select(query, 3);

            String[] groupPanelists = new String[4];

            for (int i = 0; i < 4; i++)
            {
                if (i < memcount)
                    groupPanelists[i] = resultSet[0].ElementAt(i) + " " + resultSet[1].ElementAt(i) + ". " + resultSet[2].ElementAt(i);
                else
                    groupPanelists[i] = "";
            }

            for (int i = 0; i < 4; i++)
            {
                panelistList[i].Enabled = false;
                panelistList[i].Items.Clear();
                if (groupPanelists[i] != "")
                {
                    panelistList[i].Items.Add(groupPanelists[i]);
                }
                panelistList[i].Items.Add("");
                panelistList[i].SelectedIndex = 0;
            }


            query = "select count(*) from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            memcount = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            query = "select firstname, MI, lastname from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            resultSet = dbHandler.Select(query, 3);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < memcount; j++)
                    panelistList[i].Items.Add(resultSet[0].ElementAt(j) + " " + resultSet[1].ElementAt(j) + ". " + resultSet[2].ElementAt(j));

            for (int i = 0; i < 4; i++)
                panelistInfo[i].Text = "";

            if (selectedPanelist == "") return;

            query = "select firstname, MI, lastname from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + currThesisGroupID + ");";
            resultSet = dbHandler.Select(query, 3);

            String panelist = resultSet[0].ElementAt(0) + " " + resultSet[1].ElementAt(0) + ". " + resultSet[2].ElementAt(0);
            int panelIndex = -1;

            for (int i = 0; i < 4; i++) 
            {
                if (panelistList[i].SelectedItem.Equals(panelist))
                    panelIndex = i;
            }

            setSelectedPanelist(panelIndex, panelist);

            panelistInfo[0].Text = selectedPanelist;
            panelistInfo[1].Text = resultSet[0].ElementAt(0);
            panelistInfo[2].Text = resultSet[1].ElementAt(0);
            panelistInfo[3].Text = resultSet[2].ElementAt(0);

            panelistInfo[0].Enabled = true;
            panelistInfo[1].Enabled = true;
            panelistInfo[2].Enabled = true;
            panelistInfo[3].Enabled = true;
        }

        private void select_panel_click(object sender, EventArgs e)
        {
            if (currThesisGroupID == "") return;
            
            int panelIndex = Convert.ToInt32(((Label)sender).Name.Substring(11)) - 1;

            Console.WriteLine(panelistList[panelIndex].SelectedIndex);
            setSelectedPanelist(panelIndex, panelistList[panelIndex].SelectedItem + "");

            update_components();

            panelistList[panelIndex].Enabled = true;

            if (panelistList[panelIndex].SelectedItem + "" == "")
            {
                panelistInfo[0].Enabled = true;
                panelistInfo[1].Enabled = true;
                panelistInfo[2].Enabled = true;
                panelistInfo[3].Enabled = true;

                return;
            }
        }

        private void setSelectedPanelist(int panelIndex, String panelistName)
        {
            if (panelistList[panelIndex].SelectedItem+"" == "")
            {
                selectedPanelist = "";
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
            selectedPanelist = dbHandler.Select(query, 1)[0].ElementAt(0);
        }

        private void changed_selected_index(object sender, EventArgs e)
        {
            int panelIndex = Convert.ToInt32(((ComboBox)sender).Name.Substring(11)) - 1;

            if (selectedPanelist == "")
                return;

            if (panelistList[panelIndex].SelectedItem.Equals(""))
            {
                String query = "delete from panelassignment where panelistid = " + selectedPanelist + " and thesisgroupid = " + currThesisGroupID + ";";
                dbHandler.Delete(query);

            }
            else
            {
                Console.WriteLine("pasowks");
                String query = "delete from panelassignment where panelistid = " + selectedPanelist + " and thesisgroupid = " + currThesisGroupID + ";";
                dbHandler.Delete(query);

                setSelectedPanelist(panelIndex, panelistList[panelIndex].SelectedItem + "");

                query = "insert into panelassignment values (" + currThesisGroupID + ", " + selectedPanelist + ");";
                dbHandler.Insert(query);

                panelistInfo[0].Enabled = true;
                panelistInfo[1].Enabled = true;
                panelistInfo[2].Enabled = true;
                panelistInfo[3].Enabled = true;
            }
        }
    }
}