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

        public ScheduleEditor()
        {
            InitializeComponent();
            currStudent = "";
            currPanelist = "";
            studentTreeView.Show();
            panelistTreeView.Hide();
            InitStudentListBox();
        }
        //Tree View
        private void InitStudentListBox() 
        {
            UpdateStudentList(studentTreeView.Nodes);
        }
        private void studentTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.Expand();
                buttonAddExistingEvent.Enabled = false;
                buttonAddExistingWeeklyTimeslot.Enabled = false;
                buttonDeleteWeeklyTimeslot.Enabled = false;
                buttondeleteEvent.Enabled = false;
                dataGridViewWeeklyTimeslot.DataSource = null;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewEvent.DataSource = null;
                dataGridViewEvent.Refresh();
            }
            else if (e.Node.Level == 1)
            {
                buttonAddExistingEvent.Enabled = true;
                buttonAddExistingWeeklyTimeslot.Enabled = true;
                buttonDeleteWeeklyTimeslot.Enabled = true;
                buttondeleteEvent.Enabled = true;
                currStudent = e.Node.Name;
                RefreshStudentClassScheds(currStudent);
                RefreshStudentEvents(currStudent);
                update_courses();
                update_events();
                
                
            }
            else
            {
                
            }
        }
        private void panelistTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.Expand();
            }
            else if (e.Node.Level == 1)
            {
                buttonAddWeeklyTimeslot.Enabled = true;
                buttonDeleteWeeklyTimeslot.Enabled = true;
                buttondeleteEvent.Enabled = true;
                currPanelist = e.Node.Name;
                RefreshPanelistClassScheds(currPanelist);
                RefreshPanelistEvents(currPanelist);
            }
            else
            {
                buttonAddWeeklyTimeslot.Enabled = false;
                buttonDeleteWeeklyTimeslot.Enabled = false;
                buttondeleteEvent.Enabled = false;
            }
        }
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                currPanelist = "";
                btnSwitchView.Text = "Switch to Students";
                studentTreeView.Hide();
                panelistTreeView.Show();
                panelistTreeView.Enabled = true;
                studentTreeView.Enabled = false;
                UpdatePanelistList(panelistTreeView.Nodes);
            }
            else 
            {
                currStudent = "";
                btnSwitchView.Text = "Switch to Panelists";
                studentTreeView.Show();
                panelistTreeView.Hide();
                panelistTreeView.Enabled = false;
                studentTreeView.Enabled = true;
                UpdateStudentList(studentTreeView.Nodes);
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                RefreshStudentClassScheds(currStudent);
                RefreshStudentEvents(currStudent);
                
            }
            else 
            {
                RefreshPanelistClassScheds(currPanelist);
                RefreshPanelistEvents(currPanelist);
            }
            update_courses();
            update_events();
        }
        //WEEKLY TIMESLOT
        private void buttonAddWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            //timeslotAdder.Visible = true;
            //timeslotAdder.initializePanel();
            timeslotAdder = new TimeslotCreator(false);
            timeslotAdder.Visible = true;
        }
        private void buttonAddExistingWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            
            if(studentTreeView.Enabled)
            {
                
                Console.WriteLine("rowindex: "+rowIndex);
                String query;
                int slot = Convert.ToInt32(dataGridViewExistingTimeslot["Id", rowIndex].Value.ToString());
                //CHECK------------
                query = "SELECT timeslotID FROM StudentSchedule WHERE (studentID = '" + currStudent + "') AND (timeslotID =" + slot + ");";

                List<String>[] duplicateCheck = dbHandler.Select(query, 1);

                if (duplicateCheck[0].Count == 1)
                {
                    MessageBox.Show("This timeslot is already a duplicate", "Duplicate Timeslot", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }

                //query = "SELECT timeslotID FROM Timeslot WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND (section = '" + existingTimeslots[2][rowIndex] + "') AND (day = '" + existingTimeslots[3][rowIndex] + "');";
                //Console.WriteLine(query);
                //List<String> timeslotID = dbHandler.Select(query, 1)[0];

                

                //String slot = timeslotID[0];
                
                Console.WriteLine("slot: "+slot);
                
                query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES ('"+currStudent+"', "+Convert.ToInt32(slot)+")";
                Console.WriteLine("escape qqq" + query);
                try
                {
                    dbHandler.Insert(query);
                }
                catch (SqlException sqlEx) 
                {
                    if (sqlEx.Source != null)
                        Console.WriteLine("IOException source: {0}", sqlEx.Source);
                    Console.WriteLine(query);
                }
                Console.WriteLine("success!");
                RefreshStudentClassScheds(currStudent);

            }else if(panelistTreeView.Enabled)
            {
                if (timeSlotTable[6][rowIndex] != null)
                {
                    DialogResult response = MessageBox.Show("This Timeslot already has a Professor. Overwrite?", "Panelist Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (response == DialogResult.Yes)
                    {

                        String query;

                        query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[2][rowIndex] + "') AND ( section = '" + existingTimeslots[1][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";

                        dbHandler.Update(query);
                        Console.WriteLine(query);
                        RefreshPanelistClassScheds(currPanelist);
                    }
                }
            }
            update_courses();
                
            

        }
        private void buttonDeleteWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            //NO VALIDATION NEEDED

            String selectedRowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString();
            Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currTimeslot = timeSlotTable[0][dataGridViewWeeklyTimeslot.SelectedRows[0].Index];
            if (studentTreeView.Enabled)
            {
                Console.WriteLine(currTimeslot + "-" + currStudent + "-");
                String query = "DELETE FROM StudentSchedule WHERE studentID = " + currStudent + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshStudentClassScheds(currStudent);
            }
            else if (panelistTreeView.Enabled)
            {
                Console.WriteLine(currTimeslot + "-" + currPanelist + "-");
                String query = "UPDATE Timeslot SET panelistID = NULL WHERE panelistID = " + currPanelist + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Update(query);
                Console.WriteLine(query);
                RefreshPanelistClassScheds(currPanelist);
            }
            else
            {
                return;
            }
        }
        private void buttonWeeklyTimeslotEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            timeslotAdder = new TimeslotCreator(true);
            for(int i=0;i<dataGridViewExistingTimeslot.Columns.Count;i++)
            {
                timeslotAdder.forEditing.Add(dataGridViewExistingTimeslot[i,rowIndex].Value.ToString());

            }
            timeslotAdder.initializeTextBoxes();
            timeslotAdder.Visible = true;
            
        }
        //EVENTS
        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            eventAdder = new EventCreator(false);
            eventAdder.Visible = true;
        }
        private void buttonAddExistingEvent_Click(object sender, EventArgs e)
        {
            String query;

            //CHECKING
                //Duplicate
                //Conflict with defense
            //ADD 
            if (existingEvents[0].Count == 0)
            { 
                
                dataGridViewExistingEvent.DataSource = null;
                dataGridViewExistingEvent.Refresh();
                Console.WriteLine("cleared");
                return;
            }
                
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            if (studentTreeView.Enabled)
            {
                
                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                    //SelectedRows[0].Cells[0].Value.ToString();
                Console.WriteLine(eventID);
                Console.WriteLine(currStudent);
                query = "INSERT INTO StudentEventRecord(studentID,eventID) VALUES('"+currStudent+"',"+eventID+");";
                Console.WriteLine(query);
                dbHandler.Insert(query);
                RefreshStudentEvents(currStudent);
            }
            else if (panelistTreeView.Enabled) 
            {
                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                //SelectedRows[0].Cells[0].Value.ToString();
                Console.WriteLine(eventID);
                Console.WriteLine(currPanelist);
                query = "INSERT INTO PanelistEventRecord(panelistID,eventID) VALUES('" + currPanelist + "'," + eventID + ");";
                Console.WriteLine(query);
                dbHandler.Insert(query);
                RefreshPanelistEvents(currPanelist);
                
            }
            update_events();
            if (existingEvents[0].Count == 0)
            {

                dataGridViewExistingEvent.DataSource = null;
                dataGridViewExistingEvent.Refresh();
                Console.WriteLine("cleared");
                return;
            }
            
        }
        private void buttondeleteEvent_Click(object sender, EventArgs e)
        {
            String selectedRowIndex = dataGridViewEvent.SelectedRows[0].Index.ToString();
            Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currEvent = eventTable[0][dataGridViewEvent.SelectedRows[0].Index];
            if (studentTreeView.Enabled)
            {
                Console.WriteLine(currEvent + "-" + currStudent + "-");
                String query = "DELETE FROM StudentEventRecord WHERE studentID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshStudentEvents(currStudent);
            }
            else if (panelistTreeView.Enabled)
            {
                Console.WriteLine(currEvent + "-" + currStudent + "-");
                String query = "DELETE FROM PanelistEventRecord WHERE panelistID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshPanelistEvents(currPanelist);
            }
            else
            {
                return;
            }
            update_events();
        }
        private void buttonEventEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            eventAdder = new EventCreator(true);
            for (int i = 0; i < dataGridViewExistingEvent.Columns.Count; i++)
            {
                eventAdder.forEditing.Add(dataGridViewExistingEvent[i,rowIndex].Value.ToString());
            }
            eventAdder.initializeTextBoxes();
            eventAdder.Visible = true;
        }
        // Student's or Panelist's timeslots and events
        private void update_courses()
        {
            /*
            String query2 = "SELECT  timeslotID, courseName,section, day, startTime , endTime FROM Timeslot WHERE (panelistID IS NULL)";
            existingTimeslots = dbHandler.Select(query2, 6);

            if (existingTimeslots[0].Count == 0)
            {
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
                panelistID = null;
                existingClassScheds.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));
            }
            
            String query = "SELECT Timeslot.timeslotID,  Timeslot.courseName, Timeslot.section,Timeslot.day, Timeslot.startTime, Timeslot.endTime ,Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM Panelist INNER JOIN Timeslot ON Panelist.panelistID = Timeslot.panelistID;";

            if (studentTreeView.Enabled)
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime, Panelist.firstName +' '+ Panelist.MI+'. '+ Panelist.lastName FROM Timeslot INNER JOIN StudentSchedule ON Timeslot.timeslotID = StudentSchedule.timeslotID INNER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE (Timeslot.timeslotID NOT IN (SELECT timeslotID FROM StudentSchedule AS StudentSchedule_1 WHERE(studentID = '"+currStudent+"')));";
                Console.WriteLine(query);
            }
            existingTimeslots = dbHandler.Select(query, 7);

            if (existingTimeslots[0].Count == 0)
            {
                return;
            }

            
            for (int i = 0; i < existingTimeslots[0].Count; i++)
            {
                id = Convert.ToInt32(existingTimeslots[0][i]);
                course = existingTimeslots[1][i];
                section = existingTimeslots[2][i];
                day = existingTimeslots[3][i];
                startTime = Convert.ToDateTime(existingTimeslots[4][i]);
                //endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                endTime = Convert.ToDateTime(existingTimeslots[5][i]);
                panelistID = existingTimeslots[6][i];
                existingClassScheds.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));


            } */


            String query = "SELECT Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime, Panelist.firstName +' '+ Panelist.MI +'. '+ Panelist.lastName as Professor FROM Timeslot INNER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID";
            existingTimeslots = dbHandler.Select(query, 7);

            if (existingTimeslots[0].Count == 0)
            {
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
                panelistID = existingTimeslots[6][i] ;
                existingClassScheds.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));
            }

            

            dataGridViewExistingTimeslot.DataSource = existingClassScheds;
            dataGridViewExistingTimeslot.Columns[4].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Columns[5].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Refresh();
            Console.WriteLine("existingtimeslot refreshed");
        }
        private void update_events()
        {
            String query = "SELECT eventID, name, eventStart, eventEnd FROM Event";
            if (studentTreeView.Enabled) 
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '"+currStudent+"');";
                Console.WriteLine(query);
            }
            else if (panelistTreeView.Enabled) 
            {
                Console.WriteLine(currPanelist);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '"+currPanelist+"');";
                Console.WriteLine(query);
            }
            

            existingEvents = dbHandler.Select(query, 4);

            if (existingEvents[0].Count == 0)
            {
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
        }
        //Algorithm for both students and panelists
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

                if (idColumnName.Equals("studentID"))
                    query = "select " + idColumnName + ", lastName, firstName, MI FROM student WHERE thesisGroupID = " + groupsTable[0].ElementAt(i) + " ORDER BY lastName ;";
                else if (idColumnName.Equals("panelistID"))
                    query = "SELECT " + idColumnName + ", lastName, firstName, MI FROM panelist WHERE panelistID IN (SELECT panelistID FROM panelAssignment WHERE thesisGroupID = " + groupsTable[0].ElementAt(i) + ") ORDER BY lastName;";
                else
                    return;

                studentTable = dbHandler.Select(query, 4);
                for (int j = 0; j < studentTable[0].Count; j++)
                {
                    currChild = new TreeNode();
                    currChild.Name = studentTable[0].ElementAt(j);
                    currChild.Text = studentTable[1].ElementAt(j) + ", " + studentTable[2].ElementAt(j) + " " + studentTable[3].ElementAt(j) + ".";
                    children.Add(currChild);
                }
                tree.Add(parent);
            }
        }
        private void RefreshClassScheds(String ID, String columnName)
        {
            classSchedList.Clear();

            String query;
            if (columnName.Equals("studentID"))
                query = "SELECT timeslotID from studentSchedule where studentID = '" + ID + "';";
            else if (columnName.Equals("panelistID"))
                query = "SELECT timeslotID from timeslot where panelistID = '" + ID + "';";
            else
                return;
            List<String> timeSlots = dbHandler.Select(query, 1)[0];
            if (timeSlots.Count == 0)
            {
                return;
            }
            query = "SELECT Timeslot.timeslotID, Timeslot.section, Timeslot.courseName, Timeslot.day, Timeslot.startTime, Timeslot.endTime ,Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM Panelist INNER JOIN Timeslot ON Panelist.panelistID = Timeslot.panelistID WHERE ";
            for (int i = 0; i < timeSlots.Count; i++)
            {
                query += " timeslotID = " + timeSlots.ElementAt(i) + " ";
                if (i == timeSlots.Count - 1)
                    query += " ORDER BY startTime;";
                else
                    query += " OR ";
            }

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
                section = timeSlotTable[1][i];
                course = timeSlotTable[2][i];
                day = timeSlotTable[3][i];
                startTime = Convert.ToDateTime(timeSlotTable[4][i]);
                //endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                panelistID = timeSlotTable[6][i];
                classSchedList.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime,panelistID));
            }
            
            dataGridViewWeeklyTimeslot.DataSource = classSchedList;
            //dataGridViewWeeklyTimeslot.Columns[4].ValueType = 
            //dataGridViewExistingTimeslot.Columns.Add(n
            dataGridViewWeeklyTimeslot.Columns[4].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewWeeklyTimeslot.Columns[5].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewWeeklyTimeslot.Refresh();


        }
        private void RefreshEvents(String ID, String columnName, String tableName)
        {
            eventList.Clear();

            String query = "SELECT Event.eventID, name, eventStart, eventEnd from Event INNER JOIN " + tableName + " ON Event.eventID = " + tableName+ ".eventID WHERE " + columnName + " = '" + ID + "' ORDER BY eventStart, eventEnd;";
            eventTable = dbHandler.Select(query, 4);

            if (eventTable[0].Count == 0)
            {
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

            //debugging
            for (int i = 0; i < 4; i++)
            {
                foreach (String j in eventTable[i])
                {
                    Console.WriteLine(j);
                }
            }

            dataGridViewEvent.DataSource = eventList;
            dataGridViewEvent.Columns["Id"].Visible = false;
            dataGridViewEvent.Refresh();
            
        }
        //STUDENTS
        public void UpdateStudentList(TreeNodeCollection tree)
        {
            UpdateTreeView(tree, "studentID", "student");
        }
        public void RefreshStudentClassScheds(String studentID)
        {
            RefreshClassScheds(studentID, "studentID");
        }
        public void RefreshStudentEvents(String studentID)
        {
            RefreshEvents(studentID, "studentID", "StudentEventRecord");
        }
        //PANELISTS
        public void UpdatePanelistList(TreeNodeCollection tree)
        {
            UpdateTreeView(tree, "panelistID", "panelist");
        }
        public void RefreshPanelistClassScheds(String panelistID)
        {
            RefreshClassScheds(panelistID, "panelistID");
        }
        public void RefreshPanelistEvents(String panelistID)
        {
            RefreshEvents(panelistID, "panelistID", "PanelistEventRecord");
        }
    }
}
