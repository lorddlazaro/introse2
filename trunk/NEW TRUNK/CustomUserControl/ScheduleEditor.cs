using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomUserControl
{
    public partial class ScheduleEditor : UserControl
    {
        private String currStudent;
        private String currPanelist;
        const int DEFWEEK_DAYS = 6;
        private DBce dbHandler = new DBce();
        private BindingList<ClassTimePeriod> classSchedList = new BindingList<ClassTimePeriod>();
        private BindingList<Event> eventList = new BindingList<Event>();
        private TimeslotCreator timeslotAdder;
        private EventCreator eventAdder;
        List<String>[] existingTimeslots;
        List<String>[] existingEvents;
        List<String>[] timeSlotTable;
        List<String>[] eventTable;
        public Form containerParent; //Form1 pointer
        private String selectedEventDGV; // either contains the values ("existing","current")
        private String selectedTimeslotDGV;  // either contains the values ("existing","current")
        private SchedulingDataManager schedulingDM;

        //Constructor
        public ScheduleEditor()
        {
            InitializeComponent();
            currStudent = "";
            currPanelist = "";
            treeViewStudentGroup.Show();
            treeViewPanelistGroup.Hide();
            UpdateStudentGroupTreeView();
            UpdateAvailableTimeslot();
            UpdateAvailableEvents();
            comboBoxSortType.SelectedIndex = 0;
            schedulingDM = new SchedulingDataManager();
        }

        //REFRESHERS
        public void RefreshAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            Refresh();
            if (IsTreeViewSetToStudents())
            {
                RefreshStudentClassScheds();
                RefreshStudentEvents();
            }
            else
            {
                RefreshPanelistClassScheds();
                RefreshPanelistEvents();
            }
            UpdateAvailableTimeslot();
            UpdateAvailableEvents();
            RefreshTreeView();
            Cursor.Current = Cursors.Arrow;
        }
        public void RefreshTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxSortType.SelectedIndex != 4)
                buttonDeletePanelist.Hide();
            else
                buttonDeletePanelist.Show();

            if (comboBoxSortType.SelectedIndex == 0)
            {
                treeViewStudentGroup.Show();
                treeViewStudents.Hide();
                treeViewPanelistGroup.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();

                currPanelist = "";
                UpdateStudentGroupTreeView();
            }
            else if (comboBoxSortType.SelectedIndex == 1)
            {
                treeViewStudentGroup.Hide();
                treeViewStudents.Show();
                treeViewPanelistGroup.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();
                UpdateStudentTreeView(treeViewStudents.Nodes);
                currPanelist = "";
            }
            else if (comboBoxSortType.SelectedIndex == 2)
            {
                treeViewStudentGroup.Hide();
                treeViewStudents.Hide();
                treeViewPanelistGroup.Show();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();
                currStudent = "";
                UpdatePanelistGroupTreeView();
            }
            else if (comboBoxSortType.SelectedIndex == 3)
            {
                treeViewStudentGroup.Hide();
                treeViewStudents.Hide();
                treeViewPanelistGroup.Hide();
                treeViewPanelists.Show();
                treeViewUngroupedPanelists.Hide();
                currStudent = "";
                UpdatePanelistTreeView(treeViewPanelists.Nodes);
            }
            else if (comboBoxSortType.SelectedIndex == 4)
            {
                treeViewStudentGroup.Hide();
                treeViewStudents.Hide();
                treeViewPanelistGroup.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Show();
                UpdateUngroupedPanelistTreeView(treeViewUngroupedPanelists.Nodes);
                currStudent = "";
            }
            Cursor.Current = Cursors.Arrow;
        }

        //Students
        public void RefreshStudentClassScheds()
        {
            UpdateTimeslot(currStudent, "studentID");
        }
        public void RefreshStudentEvents()
        {
            UpdateEvent(currStudent, "studentID", "StudentEventRecord");
        }

        //Panelist
        public void RefreshPanelistClassScheds()
        {
            UpdateTimeslot(currPanelist, "panelistID");
        }
        public void RefreshPanelistEvents()
        {
            UpdateEvent(currPanelist, "panelistID", "PanelistEventRecord");
        }


        //Tree Views
        public void UpdateStudentGroupTreeView()
        {
            treeViewStudentGroup.BeginUpdate();
            UpdateTreeView(treeViewStudentGroup.Nodes, "studentID", "student");
            treeViewStudentGroup.EndUpdate();
            treeViewStudentGroup.Refresh();
        }
        public void UpdatePanelistGroupTreeView()
        {
            treeViewPanelistGroup.BeginUpdate();
            UpdateTreeView(treeViewPanelistGroup.Nodes, "panelistID", "panelist");
            treeViewPanelistGroup.EndUpdate();
            treeViewPanelistGroup.Refresh();
        }
        public void UpdateStudentTreeView(TreeNodeCollection tree)
        {
            tree.Clear();
            List<String>[] studentTable;
            TreeNode node;
            String query = "select studentID, lastName+', '+firstName+ ' '+MI+'.' FROM student ORDER BY lastName ;";

            studentTable = dbHandler.Select(query, 2);
            for (int j = 0; j < studentTable[0].Count; j++)
            {
                node = new TreeNode();
                node.Name = studentTable[0].ElementAt(j);
                node.Text = studentTable[1].ElementAt(j);
                if (!isScheduled(studentTable[0].ElementAt(j), "student"))
                {
                    node.BackColor = Color.LightPink;

                }
                tree.Add(node);
            }
        }
        public void UpdatePanelistTreeView(TreeNodeCollection tree)
        {
            tree.Clear();
            List<String>[] studentTable;
            TreeNode node;
            String query = "select panelistID, lastName+', '+firstName+ ' '+MI+'.' FROM panelist ORDER BY lastName ;";

            studentTable = dbHandler.Select(query, 2);
            for (int j = 0; j < studentTable[0].Count; j++)
            {
                node = new TreeNode();
                node.Name = studentTable[0].ElementAt(j);
                node.Text = studentTable[1].ElementAt(j);
                if (!isScheduled(studentTable[0].ElementAt(j), "panelist"))
                {
                    node.BackColor = Color.LightPink;

                }
                tree.Add(node);
            }
        }
        public void UpdateUngroupedPanelistTreeView(TreeNodeCollection tree)
        {
            tree.Clear();
            List<String>[] studentTable;
            TreeNode node;
            String query = "select panelistID, lastName+', '+firstName+ ' '+MI+'.' FROM panelist WHERE panelistID NOT IN (SELECT distinct panelistID FROM panelAssignment)  ORDER BY lastName ;";

            studentTable = dbHandler.Select(query, 2);
            for (int j = 0; j < studentTable[0].Count; j++)
            {
                node = new TreeNode();
                node.Name = studentTable[0].ElementAt(j);
                node.Text = studentTable[1].ElementAt(j);
                if (!isScheduled(studentTable[0].ElementAt(j), "panelist"))
                {
                    node.BackColor = Color.LightPink;

                }
                tree.Add(node);
            }
        }
        //Extra
        public void UpdateTreeView(TreeNodeCollection tree, String idColumnName, String tableName)
        {
            tree.Clear();
            String query = "select thesisgroupID, title FROM thesisgroup ORDER BY title;";
            List<String>[] groupsTable = dbHandler.Select(query, 2);

            int size = groupsTable[0].Count;
            if (size == 0)
                return;

            List<String>[] studentTable;
            TreeNode parent;
            TreeNodeCollection children;
            TreeNode currChild;

            for (int i = 0; i < size; i++)
            {
                parent = new TreeNode();
                parent.Name = groupsTable[0].ElementAt(i);
                parent.Text = groupsTable[1].ElementAt(i);
                children = parent.Nodes;
                children.Clear();

                String personType = "";
                if (idColumnName.Equals("studentID"))
                {
                    query = "select " + idColumnName + ", lastName, firstName, MI FROM student WHERE thesisGroupID = " + groupsTable[0].ElementAt(i) + " ORDER BY lastName ;";
                    personType = "student";
                }
                else if (idColumnName.Equals("panelistID"))
                {
                    query = "SELECT " + idColumnName + ", lastName, firstName, MI FROM panelist WHERE panelistID IN (SELECT panelistID FROM panelAssignment WHERE thesisGroupID = " + groupsTable[0].ElementAt(i) + ") ORDER BY lastName;";
                    personType = "panelist";
                }
                else
                    return;
                int numUnscheduled = 0; ;
                studentTable = dbHandler.Select(query, 4);
                for (int j = 0; j < studentTable[0].Count; j++)
                {
                    currChild = new TreeNode();
                    currChild.Name = studentTable[0].ElementAt(j);
                    currChild.Text = studentTable[1].ElementAt(j) + ", " + studentTable[2].ElementAt(j) + " " + studentTable[3].ElementAt(j) + ".";
                    if (!isScheduled(studentTable[0].ElementAt(j), personType))
                    {
                        currChild.BackColor = Color.LightPink;
                        numUnscheduled++;
                    }
                    children.Add(currChild);
                }
                if (numUnscheduled > 0)
                    parent.BackColor = Color.LightPink;

                tree.Add(parent);
            }
        }
        private bool isScheduled(String ID, String personType)
        {
            String query = "";
            String query2 = "";

            if (personType.Equals("student"))
            {
                query = "SELECT timeslotID FROM StudentSchedule WHERE studentID ='" + ID + "'";
                query2 = "SELECT eventID FROM StudentEventRecord WHERE studentID ='" + ID + "'";
            }
            else if (personType.Equals("panelist"))
            {
                query = "SELECT timeslotID FROM Timeslot WHERE panelistID ='" + ID + "'";
                query2 = "SELECT eventID FROM PanelistEventRecord WHERE panelistID ='" + ID + "'";
            }

            if (dbHandler.Select(query, 1)[0].Count > 0 || dbHandler.Select(query2, 1)[0].Count > 0)
                return true;
            else
                return false;
        }

        //Datagridview Tables Refresh
        private void UpdateAvailableTimeslot()
        {

            String query = "";
            if (IsTreeViewSetToStudents())
                query = "SELECT DISTINCT  Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM StudentSchedule RIGHT OUTER JOIN Timeslot ON StudentSchedule.timeslotID = Timeslot.timeslotID LEFT OUTER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE (Timeslot.timeslotID NOT IN (SELECT        timeslotID FROM            StudentSchedule AS StudentSchedule_1 WHERE        (studentID = '" + currStudent + "'))) ORDER BY Timeslot.courseName, Timeslot.section";
            else
                query = "SELECT        Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM            Timeslot LEFT OUTER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE        (NOT (Timeslot.panelistID = '" + currPanelist + "')) OR (Timeslot.panelistID IS NULL) ORDER BY Timeslot.courseName, Timeslot.section";

            existingTimeslots = dbHandler.Select(query, 7);
            if (existingTimeslots[0].Count == 0)
            {
                dataGridViewExistingTimeslot.DataSource = null;
                dataGridViewExistingTimeslot.Refresh();
                dataGridViewExistingTimeslot.ClearSelection();
                selectedTimeslotDGV = "current";
                return;
            }

            BindingList<ClassTimePeriod> existingClassScheds = new BindingList<ClassTimePeriod>();
            int id;
            String section;
            String course;
            String day;
            DateTime startTime;
            DateTime endTime;
            String panelistID;

            for (int i = 0; i < existingTimeslots[0].Count; i++)
            {
                id = Convert.ToInt32(existingTimeslots[0][i]);
                course = existingTimeslots[1][i];
                section = existingTimeslots[2][i];
                day = existingTimeslots[3][i];
                startTime = Convert.ToDateTime(existingTimeslots[4][i]);
                //endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                endTime = Convert.ToDateTime(existingTimeslots[5][i]);
                panelistID = existingTimeslots[6][i] + "";
                existingClassScheds.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));
            }

            dataGridViewExistingTimeslot.DataSource = existingClassScheds;
            dataGridViewExistingTimeslot.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dataGridViewExistingTimeslot.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            dataGridViewExistingTimeslot.Columns["Id"].Visible = false;

            dataGridViewExistingTimeslot.Columns["Course"].Width = 70;
            dataGridViewExistingTimeslot.Columns["Section"].Width = 50;
            dataGridViewExistingTimeslot.Columns["Day"].Width = 30;
            dataGridViewExistingTimeslot.Columns["Panelist"].Width = 130;
            dataGridViewExistingTimeslot.Columns["StartTime"].Width = 80;
            dataGridViewExistingTimeslot.Columns["EndTime"].Width = 80;

            dataGridViewExistingTimeslot.Refresh();
        }
        private void UpdateAvailableEvents()
        {
            String query = "";
            if (IsTreeViewSetToStudents())
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '" + currStudent + "');";
            else
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM PanelistEventRecord WHERE panelistID = '" + currPanelist + "');";

            existingEvents = dbHandler.Select(query, 4);

            if (existingEvents[0].Count == 0)
            {
                dataGridViewExistingEvent.DataSource = null;
                dataGridViewExistingEvent.Refresh();
                dataGridViewExistingEvent.ClearSelection();
                selectedEventDGV = "current";
                return;
            }

            BindingList<Event> existingEventList = new BindingList<Event>();
            //Convert from 2D list to list of events
            int id;
            String name;
            DateTime eventStart;
            DateTime eventEnd;
            for (int i = 0; i < existingEvents[0].Count; i++)
            {
                id = Convert.ToInt32(existingEvents[0][i]);
                name = existingEvents[1][i];
                eventStart = Convert.ToDateTime(existingEvents[2][i]);
                eventEnd = Convert.ToDateTime(existingEvents[3][i]);
                existingEventList.Add(new Event(id, name, eventStart, eventEnd));
            }
            dataGridViewExistingEvent.DataSource = existingEventList;
            dataGridViewExistingEvent.Columns["Id"].Visible = false;
            dataGridViewExistingEvent.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd hh:mm tt";
            dataGridViewExistingEvent.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd hh:mm tt";
        }
        private void UpdateTimeslot(String ID, String columnName)
        {
            classSchedList.Clear();
            String query;
            if (columnName.Equals("studentID"))
                query = "SELECT timeslotID from studentSchedule where studentID = '" + ID + "';";
            else if (columnName.Equals("panelistID"))
            {
                query = "SELECT timeslotID from timeslot where panelistID = '" + ID + "';";
            }
            else
            {
                return;
            }
            List<String> timeSlots = dbHandler.Select(query, 1)[0];
            if (timeSlots.Count == 0)
            {
                dataGridViewWeeklyTimeslot.DataSource = null;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewWeeklyTimeslot.ClearSelection();
                selectedTimeslotDGV = "existing";
                return;
            }
            query = "SELECT Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime, Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM            Panelist RIGHT OUTER JOIN Timeslot ON Panelist.panelistID = Timeslot.panelistID WHERE ";
            for (int i = 0; i < timeSlots.Count; i++)
            {
                query += " timeslotID = " + timeSlots.ElementAt(i) + " ";
                if (i == timeSlots.Count - 1)
                    query += "";
                else
                    query += " OR ";
            }
            query += " ORDER BY Timeslot.courseName, Timeslot.section";

            timeSlotTable = dbHandler.Select(query, 7);

            //Convert Array of lists TO lists of classtimeperiod objects 
            //to make it usable for a datagridview
            int id;
            String section;
            String course;
            String day;
            DateTime startTime;
            DateTime endTime;
            String panelistID;
            for (int i = 0; i < timeSlotTable[0].Count; i++)
            {
                id = Convert.ToInt32(timeSlotTable[0][i]);
                course = timeSlotTable[1][i];
                section = timeSlotTable[2][i];
                day = timeSlotTable[3][i];
                startTime = Convert.ToDateTime(timeSlotTable[4][i]);
                //endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                panelistID = timeSlotTable[6][i] + "";
                classSchedList.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));
            }

            dataGridViewWeeklyTimeslot.DataSource = classSchedList;
            dataGridViewWeeklyTimeslot.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dataGridViewWeeklyTimeslot.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            dataGridViewWeeklyTimeslot.Columns["Id"].Visible = false;

            dataGridViewWeeklyTimeslot.Columns["Course"].Width = 70;
            dataGridViewWeeklyTimeslot.Columns["Section"].Width = 50;
            dataGridViewWeeklyTimeslot.Columns["Day"].Width = 30;
            dataGridViewWeeklyTimeslot.Columns["Panelist"].Width = 130;
            dataGridViewWeeklyTimeslot.Columns["StartTime"].Width = 80;
            dataGridViewWeeklyTimeslot.Columns["EndTime"].Width = 80;

            dataGridViewWeeklyTimeslot.Refresh();
        }
        private void UpdateEvent(String ID, String columnName, String tableName)
        {
            eventList.Clear();

            String query = "SELECT Event.eventID, name, eventStart, eventEnd from Event INNER JOIN " + tableName + " ON Event.eventID = " + tableName + ".eventID WHERE " + columnName + " = '" + ID + "' ORDER BY eventStart, eventEnd;";
            eventTable = dbHandler.Select(query, 4);

            if (eventTable[0].Count == 0)
            {
                dataGridViewEvent.DataSource = null;
                dataGridViewEvent.Refresh();
                dataGridViewEvent.ClearSelection();
                selectedEventDGV = "existing";
                return;
            }

            //Convert from 2D list to list of events
            int id;
            String name;
            DateTime eventStart;
            DateTime eventEnd;
            for (int i = 0; i < eventTable[0].Count; i++)
            {
                id = Convert.ToInt32(eventTable[0][i]);
                name = eventTable[1][i];
                eventStart = Convert.ToDateTime(eventTable[2][i]);
                eventEnd = Convert.ToDateTime(eventTable[3][i]);
                eventList.Add(new Event(id, name, eventStart, eventEnd));
            }

            dataGridViewEvent.DataSource = eventList;
            dataGridViewEvent.Columns["Id"].Visible = false;

            dataGridViewEvent.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd hh:mm tt";
            dataGridViewEvent.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd hh:mm tt";

            dataGridViewEvent.Refresh();

        }

        //EVENT LISTENERS------------------------------------------------------------------
        private void comboBoxSortType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshTreeView();
        }
        private void buttonDeletePanelist_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(currPanelist))
            {
                MessageBox.Show("No Panelist Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DialogResult.Cancel == MessageBox.Show("Are you sure you want to delete this panelist?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                return;

            String query = "DELETE FROM panelist WHERE panelistID = '" + currPanelist + "';";
            dbHandler.Delete(query);
            query = "DELETE FROM panelAssignment WHERE panelistID = '" + currPanelist + "';";
            dbHandler.Delete(query);
            query = "UPDATE timeslot SET panelist = NULL WHERE panelistID = '" + currPanelist + "';";
            currPanelist = "";
            ClearEverything();
            UpdateUngroupedPanelistTreeView(treeViewUngroupedPanelists.Nodes);
        }

        //List Nodes
        private void treeViewStudentGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewStudentGroup.SelectedNode = e.Node;
            if (e.Node.Level == 0)
            {
                //e.Node.Expand();
                ClearEverything();
            }
            else if (e.Node.Level == 1)
            {
                SwitchToStudentMode(e.Node);
            }
        }
        private void treeViewPanelistGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewPanelistGroup.SelectedNode = e.Node;
            if (e.Node.Level == 0)
            {
                ClearEverything();
            }
            else if (e.Node.Level == 1)
            {
                SwitchToPanelistMode(e.Node);
            }
        }
        private void treeViewStudents_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewStudents.SelectedNode = e.Node;
            SwitchToStudentMode(e.Node);
        }
        private void treeViewPanelists_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewPanelists.SelectedNode = e.Node;
            SwitchToPanelistMode(e.Node);
        }
        private void treeViewUngroupedPanelists_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewUngroupedPanelists.SelectedNode = e.Node;
            SwitchToPanelistMode(e.Node);
        }
        //Extra
        private void SwitchToPanelistMode(TreeNode selectedNode)
        {
            //enable buttons
            buttonAssignEvent.Enabled = true;
            buttonAssignTimeslot.Enabled = true;
            buttonUnassignTimeslot.Enabled = true;
            buttonUnassignEvent.Enabled = true;

            //updates tables
            labelSelectedPersonEvent.Text = selectedNode.Text + "'s Events";
            labelSelectedPersonTimeslot.Text = selectedNode.Text + "'s Class Schedule";
            currPanelist = selectedNode.Name;

            //?  --replace by refresher all
            RefreshPanelistClassScheds();
            RefreshPanelistEvents();
            UpdateAvailableTimeslot();
            UpdateAvailableEvents();
            //?
        }
        private void SwitchToStudentMode(TreeNode selectedNode)
        {
            //enable buttons
            buttonAssignEvent.Enabled = true;
            buttonAssignTimeslot.Enabled = true;
            buttonUnassignTimeslot.Enabled = true;
            buttonUnassignEvent.Enabled = true;
            //updates tables
            labelSelectedPersonEvent.Text = selectedNode.Text + "'s Events";
            labelSelectedPersonTimeslot.Text = selectedNode.Text + "'s Class Schedule";
            currStudent = selectedNode.Name;


            RefreshStudentClassScheds();
            RefreshStudentEvents();
            UpdateAvailableTimeslot();
            UpdateAvailableEvents();

        }
        private void ClearEverything()
        {
            currPanelist = "";
            currStudent = "";
            //disables buttons
            buttonAssignEvent.Enabled = false;
            buttonAssignTimeslot.Enabled = false;
            buttonUnassignTimeslot.Enabled = false;
            buttonUnassignEvent.Enabled = false;
            //clears the tables
            dataGridViewWeeklyTimeslot.DataSource = null;
            dataGridViewWeeklyTimeslot.Refresh();
            dataGridViewEvent.DataSource = null;
            dataGridViewEvent.Refresh();

            //selection
            if (dataGridViewExistingEvent.DataSource != null)
                dataGridViewExistingEvent.Rows[0].Selected = true;
            if (dataGridViewExistingTimeslot.DataSource != null)
                dataGridViewExistingTimeslot.Rows[0].Selected = true;

            labelSelectedPersonEvent.Text = "";
            labelSelectedPersonTimeslot.Text = "";
        }

        //Timeslot
        private void buttonAddTimeslot_Click(object sender, EventArgs e)
        {
            //timeslotAdder.Visible = true;
            //timeslotAdder.initializePanel();
            timeslotAdder = new TimeslotCreator(false, containerParent, this);
            containerParent.Enabled = false;
            timeslotAdder.Visible = true;

        }
        private void buttonEditTimeslot_Click(object sender, EventArgs e)
        {
            timeslotAdder = new TimeslotCreator(true, containerParent, this);
            int rowIndex = 0;
            if (selectedTimeslotDGV.Equals("existing"))
            {
                rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
                for (int i = 0; i < dataGridViewExistingTimeslot.Columns.Count; i++)
                {
                    timeslotAdder.forEditing.Add(dataGridViewExistingTimeslot[i, rowIndex].Value.ToString());

                }
            }
            else if (selectedTimeslotDGV.Equals("current"))
            {
                rowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index;
                for (int i = 0; i < dataGridViewWeeklyTimeslot.Columns.Count; i++)
                {
                    timeslotAdder.forEditing.Add(dataGridViewWeeklyTimeslot[i, rowIndex].Value.ToString());

                }
            }



            timeslotAdder.initializeTextBoxes();
            containerParent.Enabled = false;
            timeslotAdder.Visible = true;


        }
        private void buttonDeleteTimeslot_Click(object sender, EventArgs e)
        {
            //GET timeslotID
            int timeslotID = 0;
            if (selectedTimeslotDGV.Equals("existing"))
            {
                int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
                timeslotID = Convert.ToInt32(dataGridViewExistingTimeslot[0, rowIndex].Value);
            }
            else if (selectedTimeslotDGV.Equals("current"))
            {
                int rowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index;
                timeslotID = Convert.ToInt32(dataGridViewWeeklyTimeslot[0, rowIndex].Value);
            }

            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove this timeslot for all student/panelist schedules?", "Delete confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {   //delete timeslot in student schedule table
                String query = "DELETE FROM StudentSchedule WHERE timeslotID = " + timeslotID + "";
                dbHandler.Delete(query);

                //delete timeslot from timeslot table
                query = "DELETE FROM Timeslot WHERE timeslotID = " + timeslotID + "";
                dbHandler.Delete(query);
                RefreshAll();
            }
            else
                return;
        }
        private void buttonAssignTimeslot_Click(object sender, EventArgs e)
        {
            if (dataGridViewExistingTimeslot.DataSource == null || dataGridViewExistingTimeslot.SelectedRows.Count == 0)
            {
                return;
            }

            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            TimePeriod classTimePeriod = new TimePeriod(Convert.ToDateTime(existingTimeslots[4][rowIndex]), Convert.ToDateTime(existingTimeslots[5][rowIndex]));
            String dayOfWeek = existingTimeslots[3][rowIndex];


            //CONFLICT WITH SAME COURSES
            for(int i=0;i<timeSlotTable[0].Count;i++)
            {
                if(existingTimeslots[1][rowIndex].Equals(timeSlotTable[1][i]))
                {
                    MessageBox.Show("The course is already in the schedule", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



            //CONFLICT WITH SAME COURSES
            
            
            if (IsTreeViewSetToStudents())
            {
                String query;
                int slot = Convert.ToInt32(dataGridViewExistingTimeslot["Id", rowIndex].Value.ToString());

                //START: Check for conflicts with other classes
                if (!schedulingDM.IsNewClassTimePeriodConflictFreeStudent(currStudent, classTimePeriod, dayOfWeek))
                {
                    MessageBox.Show("The new class schedule conflicts with another.", "Conflict with Other Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //START: Defense Schedule Validation

                query = "SELECT thesisGroupID FROM student where studentID = '" + currStudent + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ClassAssignmentConflictFreeWithDefScheds(thesisGroupID, classTimePeriod);

                // END: Defense Schedule Validation
                if (shouldProceed)
                {
                    query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES ('" + currStudent + "', " + Convert.ToInt32(slot) + ")";
                    dbHandler.Insert(query);
                    RefreshStudentClassScheds();
                }
            }
            else
            {
                //START: Check for conflicts with other classes
                if (!schedulingDM.IsNewClassTimePeriodConflictFreePanelist(currPanelist, classTimePeriod, dayOfWeek))
                {
                    MessageBox.Show("The new class schedule conflicts with another.", "Conflict with Other Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                String query;

                query = "SELECT thesisGroupID FROM panelAssignment where panelistID = '" + currPanelist + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ClassAssignmentConflictFreeWithDefScheds(thesisGroupID, classTimePeriod);
                if (shouldProceed)
                {
                    if (existingTimeslots[6][rowIndex] != "")
                    {
                        DialogResult response = MessageBox.Show("This Timeslot already has a Professor. Overwrite?", "Panelist Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (response == DialogResult.Yes)
                        {
                            query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND ( section = '" + existingTimeslots[2][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";
                            dbHandler.Update(query);
                            RefreshPanelistClassScheds();
                        }
                    }
                    else
                    {
                        query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND ( section = '" + existingTimeslots[2][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";
                        dbHandler.Update(query);
                        RefreshPanelistClassScheds();
                    }
                }
                else 
                {
                    DialogResult result = MessageBox.Show("Class conflicts with a defense of the panelist.", "Conflict with Defense", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //? ADD error message here

            }
            UpdateAvailableTimeslot();
            //RefreshTreeView();
        }
        private void buttonUnassignTimeslot_Click(object sender, EventArgs e)
        {

            if (dataGridViewWeeklyTimeslot.DataSource == null || dataGridViewWeeklyTimeslot.SelectedRows.Count == 0)
            {
                return;
            }
            //NO VALIDATION NEEDED



            String selectedRowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString();

            String currTimeslot = timeSlotTable[0][dataGridViewWeeklyTimeslot.SelectedRows[0].Index];
            if (IsTreeViewSetToStudents())
            {
                String query = "DELETE FROM StudentSchedule WHERE studentID = " + currStudent + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Delete(query);
                RefreshStudentClassScheds();
            }
            else
            {
                String query = "UPDATE Timeslot SET panelistID = NULL WHERE timeslotID = " + currTimeslot + ";";
                dbHandler.Update(query);
                RefreshPanelistClassScheds();
            }

            UpdateAvailableTimeslot();
            //RefreshTreeView();
            if (dataGridViewWeeklyTimeslot.Rows.Count > 0 && (dataGridViewWeeklyTimeslot.DataSource == null || dataGridViewWeeklyTimeslot.SelectedRows.Count == 0))
            {
                dataGridViewWeeklyTimeslot.Rows[0].Selected = true;
                dataGridViewExistingTimeslot.ClearSelection();
                return;
            }

        }
        //Extra
        public bool ClassAssignmentConflictFreeWithDefScheds(String thesisGroupID, TimePeriod classTimePeriod)
        {
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index; // removed from the parameter to be used outside scheduleeditor

            DefenseSchedule defSched = schedulingDM.GetDefSched(thesisGroupID, Constants.DEFENSE_TYPE);
            DefenseSchedule redefSched = schedulingDM.GetDefSched(thesisGroupID, Constants.REDEFENSE_TYPE);

            String defDayOfWeek;
            String redefDayOfWeek;

            bool conflictWithDefense = false;
            bool conflictWithRedefense = false;

            if (defSched != null)
            {
                defDayOfWeek = schedulingDM.ConvertDayOfWeekToString(defSched.StartTime.DayOfWeek);
                conflictWithDefense = defDayOfWeek.Equals(existingTimeslots[3][rowIndex]) && classTimePeriod.IntersectsExclusive(defSched);
            }
            if (redefSched != null)
            {
                redefDayOfWeek = schedulingDM.ConvertDayOfWeekToString(redefSched.StartTime.DayOfWeek);
                conflictWithRedefense = redefDayOfWeek.Equals(existingTimeslots[3][rowIndex]) && classTimePeriod.IntersectsExclusive(redefSched);
            }

            if (conflictWithDefense || conflictWithRedefense)
            {
                String warningMsg;
                if (conflictWithDefense && conflictWithRedefense)
                    warningMsg = "There are conflicts with this group's defense and re-defense schedule. ";
                else if (conflictWithDefense)
                    warningMsg = "There is conflict with this group's defense schedule. ";
                else
                    warningMsg = "There is conflict with this group's re-defense schedule. ";
                warningMsg += "Proceeding will unschedule said schedule";


                if (MessageBox.Show(warningMsg, "Conflict with Defense", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    return false;
                else
                {

                    String query = "DELETE FROM defenseSchedule WHERE ";

                    if (conflictWithDefense && conflictWithRedefense)
                        query += " defenseID = " + defSched.DefenseID + " OR defenseID = " + redefSched.DefenseID + ";";
                    else if (conflictWithDefense)
                        query += " defenseID = " + defSched.DefenseID + ";";
                    else// if(conflictWithRedefense)
                        query += " defenseID = " + redefSched.DefenseID + ";";

                    dbHandler.Delete(query);
                }
            }
            return true;
        }

        //Event
        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            eventAdder = new EventCreator(false, containerParent, this);
            containerParent.Enabled = false;
            eventAdder.Visible = true;


        }
        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            eventAdder = new EventCreator(true, containerParent, this);
            int rowIndex = 0;
            if (selectedEventDGV.Equals("existing"))
            {
                rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
                for (int i = 0; i < dataGridViewExistingEvent.Columns.Count; i++)
                {
                    eventAdder.forEditing.Add(dataGridViewExistingEvent[i, rowIndex].Value.ToString());
                }
            }

            else if (selectedEventDGV.Equals("current"))
            {
                rowIndex = dataGridViewEvent.SelectedRows[0].Index;
                for (int i = 0; i < dataGridViewEvent.Columns.Count; i++)
                {
                    eventAdder.forEditing.Add(dataGridViewEvent[i, rowIndex].Value.ToString());
                }
            }


            eventAdder.initializeTextBoxes();
            containerParent.Enabled = false;
            eventAdder.Visible = true;

        }
        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            //GET EVENT ID
            int eventID = 0;
            if (selectedEventDGV.Equals("existing"))
            {
                int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
                eventID = Convert.ToInt32(dataGridViewExistingEvent[0, rowIndex].Value);
            }
            else if (selectedEventDGV.Equals("current"))
            {
                int rowIndex = dataGridViewEvent.SelectedRows[0].Index;
                eventID = Convert.ToInt32(dataGridViewEvent[0, rowIndex].Value);
            }
            //ASK FOR DELETE CONFIRMATION
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove this event for all student/panelist schedules?", "Delete confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //REMOVE From eventrecord tables
                String query = "DELETE FROM StudentEventRecord WHERE eventID =" + eventID + "";
                dbHandler.Delete(query);
                query = "DELETE FROM PanelistEventRecord WHERE eventID =" + eventID + "";
                dbHandler.Delete(query);
                //delete from event table
                query = "DELETE FROM Event WHERE eventID = " + eventID + "";
                dbHandler.Delete(query);
                RefreshAll();
            }
            else
                return;
        }
        private void buttonAssignEvent_Click(object sender, EventArgs e)
        {
            String query;
            if (dataGridViewExistingEvent.DataSource == null || dataGridViewExistingEvent.SelectedRows.Count == 0)
            {
                return;
            }
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            //VALIDATION

            //-Conflict of Defense Checking
            if (IsTreeViewSetToStudents())
            {
                query = "SELECT        DefenseSchedule.defenseDateTime, DefenseSchedule.defenseID, ThesisGroup.course FROM            DefenseSchedule INNER JOIN ThesisGroup ON DefenseSchedule.thesisGroupID = ThesisGroup.thesisGroupID INNER JOIN Student ON ThesisGroup.thesisGroupID = Student.thesisGroupID WHERE        (Student.studentID = '" + currStudent + "')";
            }
            else
                query = "SELECT        DefenseSchedule.defenseID, DefenseSchedule.defenseDateTime, ThesisGroup.course FROM            PanelAssignment INNER JOIN Panelist ON PanelAssignment.panelistID = Panelist.panelistID INNER JOIN ThesisGroup ON PanelAssignment.thesisGroupID = ThesisGroup.thesisGroupID INNER JOIN DefenseSchedule ON ThesisGroup.thesisGroupID = DefenseSchedule.thesisGroupID WHERE        (Panelist.panelistID = '" + currPanelist + "')";

            List<String>[] defenseOfSelected = dbHandler.Select(query, 3);




            if (defenseOfSelected[0].Count > 0)
            {

                for (int i = 0; i < defenseOfSelected[0].Count; i++)
                {
                    DateTime maxStart;
                    DateTime minEnd;
                    DateTime defenseEndtime;
                    //get start of conflict
                    Console.WriteLine(defenseOfSelected[0][i]);
                    Console.WriteLine(existingEvents[2][rowIndex]);
                    if (Convert.ToDateTime(defenseOfSelected[0][i]) > Convert.ToDateTime(existingEvents[2][rowIndex]))
                        maxStart = Convert.ToDateTime(defenseOfSelected[0][i]);
                    else
                        maxStart = Convert.ToDateTime(existingEvents[2][rowIndex]);

                    //GET endtime of defense


                    if (defenseOfSelected[2][i].Equals("THSST-1"))
                        defenseEndtime = Convert.ToDateTime(defenseOfSelected[0][i]).AddMinutes(Constants.THSST1_DEFDURATION_MINS);
                    else
                        defenseEndtime = Convert.ToDateTime(defenseOfSelected[0][i]).AddMinutes(Constants.THSST3_DEFDURATION_MINS);

                    //get end of conflict
                    if (defenseEndtime > Convert.ToDateTime(existingEvents[3][rowIndex]))
                        minEnd = Convert.ToDateTime(existingEvents[3][rowIndex]);
                    else
                        minEnd = defenseEndtime;

                    if (maxStart < minEnd)
                    {
                        DialogResult result;
                        if (IsTreeViewSetToStudents())
                            result = MessageBox.Show("Event conflicts with selected student defense" + System.Environment.NewLine + "Unschedule conflicting defense?", "Conflict with Defense", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        else
                            result = MessageBox.Show("Event conflicts with selected panelists defense" + System.Environment.NewLine + "Unschedule conflicting defense?", "Conflict with Defense", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            query = "DELETE FROM DefenseSchedule WHERE defenseID = " + Convert.ToInt32(defenseOfSelected[1][0]) + "";
                            dbHandler.Delete(query);
                            MessageBox.Show("Conflicting defense removed", "Conflict with Defense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            return;

                    }
                }



            }


            //ADD 

            if (IsTreeViewSetToStudents())
            {

                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                query = "INSERT INTO StudentEventRecord(studentID,eventID) VALUES('" + currStudent + "'," + eventID + ");";
                dbHandler.Insert(query);
                RefreshStudentEvents();
            }
            else
            {
                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                query = "INSERT INTO PanelistEventRecord(panelistID,eventID) VALUES('" + currPanelist + "'," + eventID + ");";
                dbHandler.Insert(query);
                RefreshPanelistEvents();

            }
            UpdateAvailableEvents();
            //RefreshTreeView();

        }
        private void buttonUnassignEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.DataSource == null || dataGridViewEvent.SelectedRows.Count == 0)
            {
                return;
            }
            String selectedRowIndex = dataGridViewEvent.SelectedRows[0].Index.ToString();

            String currEvent = eventTable[0][dataGridViewEvent.SelectedRows[0].Index];
            if (IsTreeViewSetToStudents())
            {
                String query = "DELETE FROM StudentEventRecord WHERE studentID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                RefreshStudentEvents();
            }
            else
            {
                String query = "DELETE FROM PanelistEventRecord WHERE panelistID = " + currPanelist + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);

                RefreshPanelistEvents();
            }

            UpdateAvailableEvents();
            //RefreshTreeView();

            if (dataGridViewEvent.Rows.Count > 0 && (dataGridViewEvent.DataSource == null || dataGridViewEvent.SelectedRows.Count == 0))
            {
                dataGridViewEvent.Rows[0].Selected = true;
                dataGridViewExistingEvent.ClearSelection();
                return;
            }
        }

        //Datagridview Table Row Selection
        private void DataGridViewExistingEvent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewEvent.ClearSelection();
            selectedEventDGV = "existing";
        }
        private void DataGridViewEvent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewExistingEvent.ClearSelection();
            selectedEventDGV = "current";
        }
        private void DataGridViewExistingTimeslot_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWeeklyTimeslot.ClearSelection();
            selectedTimeslotDGV = "existing";
        }
        private void DataGridViewWeeklyTimeslot_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewExistingTimeslot.ClearSelection();
            selectedTimeslotDGV = "current";
        }


        //Extra Methods
        private bool IsTreeViewSetToStudents()
        {
            return comboBoxSortType.SelectedIndex == 0 || comboBoxSortType.SelectedIndex == 1;
        }
    }
}
