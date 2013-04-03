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
        private TimeslotCreator timeslotAdder = new TimeslotCreator();
        private EventCreator eventAdder = new EventCreator();
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
            update_courses();
            update_events();
            timeslotAdder.Visible = false;
            eventAdder.Visible = false;
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
            }
            else if (e.Node.Level == 1)
            {
                buttonAddWeeklyTimeslot.Enabled = true;
                buttonDeleteWeeklyTimeslot.Enabled = true;
                buttondeleteEvent.Enabled = true;
                currStudent = e.Node.Name;
                RefreshStudentClassScheds(currStudent);
                RefreshStudentEvents(currStudent);
                
                
            }
            else
            {
                buttonAddWeeklyTimeslot.Enabled = false;
                buttonDeleteWeeklyTimeslot.Enabled = false;
                buttondeleteEvent.Enabled = false;
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
        // RefreshButton
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
        //Add
        private void buttonAddWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            timeslotAdder.Visible = true;
            timeslotAdder.initializePanel();
            /*
            if (buttonAddWeeklyTimeslot.Text == "Add New Timeslot")
            {
                textBoxWeeklyTimeslotCourse.Enabled = true;
                textBoxWeeklyTimeslotSection.Enabled = true;
                listViewWeeklyTimeslotDay.Enabled = true;
                dateTimePickerWeeklyTimeslotStartTime.Enabled = true;
                dateTimePickerWeeklyTimeslotEndTime.Enabled = true;
                comboBoxPanelist.Enabled = true;
                buttonAddWeeklyTimeslot.Text = "Save";
            }
            else if(true)
            {
                buttonAddWeeklyTimeslot.Text = "Add New";
                textBoxWeeklyTimeslotCourse.Enabled = false;
                textBoxWeeklyTimeslotSection.Enabled = false;
                listViewWeeklyTimeslotDay.Enabled = false;
                dateTimePickerWeeklyTimeslotStartTime.Enabled = false;
                dateTimePickerWeeklyTimeslotEndTime.Enabled = false;
                comboBoxPanelist.Enabled = false;*/
            
            
            /*
            
            

            String query;
            String day = "";
            for (int i = 0; i < 6; i++)
            {
                if (listViewWeeklyTimeslotDay.Items[i].Checked == true)
                {
                    switch (listViewWeeklyTimeslotDay.Items[i].Index)
                    {
                        case 0:
                            Console.WriteLine("Monday");
                            day = "M";
                            break;
                        case 1:
                            Console.WriteLine("Tuesday");
                            day = "T";
                            break;
                        case 2: Console.WriteLine("Wednesday");
                            day = "W";
                            break;
                        case 3: Console.WriteLine("Thursday");
                            day = "H";
                            break;
                        case 4: Console.WriteLine("Friday");
                            day = "F";
                            break;
                        case 5: Console.WriteLine("Saturday");
                            day = "S";
                            break;
                        default: break;

                    }*/
                    /*
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToString());*/
                    /*
                    query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES(N'" + textBoxWeeklyTimeslotCourse.Text + "', N'" + textBoxWeeklyTimeslotSection.Text + "', N'" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), N'" + comboBoxPanelist.Text + "')";
                    try
                    {
                        dbHandler.Insert(query);
                        Console.WriteLine("ADD NEW-INSERT SUCCESS");
                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Source != null)
                            Console.WriteLine("IOException source: {0}", sqlEx.Source);
                        Console.WriteLine("query= " + query);
                        //if(textBoxWeeklyTimeslotCourse.Text == null)
                    }
                    
                    if (studentTreeView.Enabled)
                    {
                        query = "SELECT timeslotID FROM Timeslot WHERE courseName = '" + textBoxWeeklyTimeslotCourse.Text + "' AND section = '" + textBoxWeeklyTimeslotSection.Text + "';";
                        Console.WriteLine(query);
                        List<String> timeSlots = dbHandler.Select(query, 1)[0];

                        foreach (String slots in timeSlots)
                        {

                            query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES(N'" + currStudent + "', " + slots + ")";
                            Console.WriteLine(query);
                            dbHandler.Insert(query);

                        }

                        RefreshStudentClassScheds(currStudent);


                    }
                    else if (panelistTreeView.Enabled)
                    {
                        RefreshStudentClassScheds(currPanelist);
                    }
                    dataGridViewWeeklyTimeslot.DataSource = classSchedList;
                    dataGridViewWeeklyTimeslot.Refresh();
                }
            }
            */
            
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            eventAdder.Visible = true;
        }
        //Add Existing
        private void buttonAddExistingWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            
            if(studentTreeView.Enabled)
            {
                
                Console.WriteLine("rowindex: "+rowIndex);
                /*Console.WriteLine("existingtimeslots: "+existingTimeslots[rowIndex][0].ToString());
                Console.WriteLine("existingtimeslots: " + existingTimeslots[rowIndex][1].ToString());
                Console.WriteLine("existingtimeslots: " + existingTimeslots[rowIndex][2].ToString());
                Console.WriteLine("existingtimeslots: " + existingTimeslots[rowIndex][3].ToString());
                Console.WriteLine("existingtimeslots: " + existingTimeslots[rowIndex][4].ToString());
                //Console.WriteLine("timeslotID: " + Convert.ToInt32(existingTimeslots[rowIndex][0].ToString()));
                Console.WriteLine(existingTimeslots[1][rowIndex]);
                Console.WriteLine(existingTimeslots[2][rowIndex]);
                Console.WriteLine(existingTimeslots[3][rowIndex]);*/
                //int timeslotID = Convert.ToInt32(existingTimeslots[rowIndex][0].ToString());
                String query = "SELECT timeslotID FROM StudentSchedule WHERE (studentID = '" + currStudent + "') AND (timeslotID ='" + existingTimeslots[0][rowIndex] + "');";

                List<String>[] duplicateCheck = dbHandler.Select(query, 1);

                if (duplicateCheck[0].Count == 1)
                {
                    MessageBox.Show("This timeslot is already a duplicate", "Duplicate Timeslot", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }

                query = "SELECT timeslotID FROM Timeslot WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND (section = '" + existingTimeslots[2][rowIndex] + "') AND (day = '" + existingTimeslots[3][rowIndex] + "');";
                Console.WriteLine(query);
                List<String> timeslotID = dbHandler.Select(query, 1)[0];
                String slot = timeslotID[0];
                query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES (N'"+currStudent+"', "+Convert.ToInt32(timeslotID[0])+")";
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
                RefreshStudentClassScheds(currStudent);

            }else if(panelistTreeView.Enabled)
            {

                String query;

                query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND ( section = '" + existingTimeslots[2][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";

                dbHandler.Update(query);
                Console.WriteLine(query);
                RefreshPanelistClassScheds(currPanelist);
            }
            

        }

        private void buttonAddExistingEvent_Click(object sender, EventArgs e)
        {

        }
        //Delete
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
        }

        private void buttonDeleteWeeklyTimeslot_Click(object sender, EventArgs e)
        {
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
        //Edit
        private void buttonEventEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonWeeklyTimeslotEdit_Click(object sender, EventArgs e)
        {

        }

        // Row Enter
        /*
        private void dataGridViewWeeklyTimeslot_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxWeeklyTimeslotCourse.Text = timeSlotTable[2][e.RowIndex];
            textBoxWeeklyTimeslotSection.Text = timeSlotTable[1][e.RowIndex];

            for (int i = 0; i < 6; i++)
            {
                listViewWeeklyTimeslotDay.Items[i].Checked = false;
            }

            switch (timeSlotTable[3][e.RowIndex])
            {
                case "M": listViewWeeklyTimeslotDay.Items[0].Checked = true; break;
                case "T": listViewWeeklyTimeslotDay.Items[1].Checked = true; break;
                case "W": listViewWeeklyTimeslotDay.Items[2].Checked = true; break;
                case "H": listViewWeeklyTimeslotDay.Items[3].Checked = true; break;
                case "F": listViewWeeklyTimeslotDay.Items[4].Checked = true; break;
                case "S": listViewWeeklyTimeslotDay.Items[5].Checked = true; break;
                default: break;
            }

            dateTimePickerWeeklyTimeslotStartTime.Value = Convert.ToDateTime(timeSlotTable[4][e.RowIndex]);
            dateTimePickerWeeklyTimeslotEndTime.Value = Convert.ToDateTime(timeSlotTable[5][e.RowIndex]);



            for (int i = 0; i < 6; i++)
            {
                if (listViewWeeklyTimeslotDay.Items[i].Checked == true)
                {
                    switch (listViewWeeklyTimeslotDay.Items[i].Text)
                    {
                        case "Monday": Console.WriteLine("Monday"); break;
                        case "Tuesday": break;
                        case "Wednesday": break;
                        case "Thursday": break;
                        case "Friday": break;
                        case "Saturday": break;
                        default: break;

                    }
                }
            }

        }

        private void dataGridViewEvent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxEventName.Text = eventTable[1][e.RowIndex];
            dateTimePickerEventStartTime.Value = Convert.ToDateTime(eventTable[2][e.RowIndex]);
            dateTimePickerEventEndTime.Value = Convert.ToDateTime(eventTable[3][e.RowIndex]);
        }*/

        // ComboBoxes
        private void update_courses()
        {
            String query = "SELECT Timeslot.timeslotID, Timeslot.section, Timeslot.courseName, Timeslot.day, Timeslot.startTime, Timeslot.endTime ,Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM Panelist INNER JOIN Timeslot ON Panelist.panelistID = Timeslot.panelistID;";
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
                panelistID = existingTimeslots[6][i];
                existingClassScheds.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime, panelistID));
            }


            dataGridViewExistingTimeslot.DataSource = existingClassScheds;
            dataGridViewExistingTimeslot.Columns[3].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Columns[4].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewExistingTimeslot.Refresh();
        }

        private void update_events()
        {
            String query = "SELECT eventID, name, eventStart, eventEnd FROM EVENT;";

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
            query = "SELECT Timeslot.timeslotID, Timeslot.section, Timeslot.courseName, Timeslot.day, Timeslot.startTime, Timeslot.endTime ,Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM Panelist INNER JOIN Timeslot ON Panelist.panelistID = Timeslot.panelistID AND";
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
            dataGridViewWeeklyTimeslot.Columns[3].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewWeeklyTimeslot.Columns[4].DefaultCellStyle.Format = "HH:mm:ss tt";
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
