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

        private ComboBox[] panelistList;
        private Button[] panelistButtons;
        
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
            //initButtons();

            thesisGroupTreeView.BeginUpdate();
            //AddPanelistsToTree(thesisGroupTreeView.Nodes);
            thesisGroupTreeView.EndUpdate();
            thesisGroupTreeView.ExpandAll();
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
        }

        private void changed_selected_index(object sender, EventArgs e)
        {

        }
    }
}