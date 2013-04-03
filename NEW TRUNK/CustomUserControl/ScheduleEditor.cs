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
    public partial class ScheduleEditor : UserControl
    {
        private String currStudent;
        private String currPanelist;
        const int DEFWEEK_DAYS = 6;
        private DBce dbHandler =new DBce();
        private BindingList<ClassTimePeriod> classSchedList = new BindingList<ClassTimePeriod>();
        private BindingList<Event> eventList = new BindingList<Event>();

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
                dataGridViewWeeklyTimeslot.DataSource = classSchedList;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewEvent.DataSource = eventList;
                dataGridViewEvent.Refresh();
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
                dataGridViewWeeklyTimeslot.DataSource = classSchedList;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewEvent.DataSource = eventList;
                dataGridViewEvent.Refresh();

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
        }

        private void buttonAddWeeklyTimeslot_Click(object sender, EventArgs e)
        {   
            String query;
            String day="";
            for(int i=0;i<6;i++)
            {
                if (listViewWeeklyTimeslotDay.Items[i].Checked == true) 
                {
                    switch (listViewWeeklyTimeslotDay.Items[i].Text) 
                    {
                        case "Monday": 
                            Console.WriteLine("Monday"); 
                            day = "M"; 
                            break;
                        case "Tuesday": 
                            Console.WriteLine("Tuesday"); 
                            day = "T";
                            break;
                        case "Wednesday": Console.WriteLine("Wednesday"); 
                            day = "W";
                            break;
                        case "Thursday": Console.WriteLine("Thursday"); 
                            day = "H";
                            break;
                        case "Friday": Console.WriteLine("Friday"); 
                            day = "F";
                            break;
                        case "Saturday": Console.WriteLine("Saturday"); 
                            day = "S";
                            break;
                        default: break;

                    }
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToString());
                    //query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse + "','" + textBoxWeeklyTimeslotSection + "','" + day + "'," + dateTimePickerWeeklyTimeslotStartTime + "," + dateTimePickerWeeklyTimeslotEndTime + ",'" + comboBoxPanelist + "');";
                    query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES(N'" + textBoxWeeklyTimeslotCourse.Text + "', N'" + textBoxWeeklyTimeslotSection.Text + "', N'" + day + "',CONVERT(DATETIME, '"+dateTimePickerWeeklyTimeslotStartTime.Value.ToString()+"', 102), CONVERT(DATETIME, '"+dateTimePickerWeeklyTimeslotEndTime.Value.ToString()+"', 102), N'" + comboBoxPanelist.Text + "')";
                    //query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES(" + textBoxWeeklyTimeslotCourse.Text + "', " + textBoxWeeklyTimeslotSection.Text + "', " + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), " + comboBoxPanelist.Text + "')";
                    Console.WriteLine(query);
                    dbHandler.Insert(query);
                    //query = "INSERT INTO StudentSchedule (timeslotID, studentID) VALUES ("", N'"+currStudent+"')";

                    if (studentTreeView.Enabled)
                    {
                        query = "SELECT timeslotID FROM Timeslot WHERE courseName = '"+textBoxWeeklyTimeslotCourse.Text+"' AND section = '"+textBoxWeeklyTimeslotSection.Text+"';";
                        Console.WriteLine(query);
                        List<String> timeSlots = dbHandler.Select(query, 1)[0];

                        foreach (String slots in timeSlots) 
                        {
                            
                            query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES(N'"+currStudent+"', "+slots+")";
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
        }

        private void buttonAddExistingWeeklyTimeslot_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            String selectedRowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString();
            Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currTimeslot = timeSlotTable[0][dataGridViewWeeklyTimeslot.SelectedRows[0].Index];
            if (studentTreeView.Enabled)
            {
                Console.WriteLine(currTimeslot + "-" + currStudent + "-");
                String query = "DELETE FROM StudentSchedule WHERE studentID = " + currStudent + " AND timeslotID = " + currTimeslot+";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshStudentClassScheds(currStudent);
                dataGridViewWeeklyTimeslot.DataSource = classSchedList;
                dataGridViewWeeklyTimeslot.Refresh();
            }
            else if (panelistTreeView.Enabled)
            {
                Console.WriteLine(currTimeslot + "-" + currPanelist + "-");
                String query = "UPDATE Timeslot SET panelistID = NULL WHERE panelistID = " + currPanelist + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Update(query);
                Console.WriteLine(query);
                RefreshPanelistClassScheds(currPanelist);
                dataGridViewWeeklyTimeslot.DataSource = classSchedList;
                dataGridViewWeeklyTimeslot.Refresh();
            }
            else 
            {
                return;
            }
            
             

        }

        private void buttonClearWeeklyTimeslot_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddExistingEvent_Click(object sender, EventArgs e)
        {

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
                dataGridViewEvent.DataSource = eventList;
                dataGridViewEvent.Refresh();
            }
            else if (panelistTreeView.Enabled)
            {
                Console.WriteLine(currEvent + "-" + currStudent + "-");
                String query = "DELETE FROM PanelistEventRecord WHERE panelistID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshPanelistEvents(currPanelist);
                dataGridViewEvent.DataSource = eventList;
                dataGridViewEvent.Refresh();
            }
            else
            {
                return;
            }
        }

        private void buttonClearEvent_Click(object sender, EventArgs e)
        {

        }

        private void buttonEventEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonWeeklyTimeslotEdit_Click(object sender, EventArgs e)
        {

        }

        private void update_panelists()
        {
        }

        private void update_courses()
        {
        }

        private void update_events()
        {
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


            query = "SELECT timeslotID, section, courseName, day, startTime, endTime FROM timeslot WHERE ";
            for (int i = 0; i < timeSlots.Count; i++)
            {
                query += " timeslotID = " + timeSlots.ElementAt(i) + " ";
                if (i == timeSlots.Count - 1)
                    query += " ORDER BY startTime;";
                else
                    query += " OR ";
            }

            timeSlotTable = dbHandler.Select(query, 6);

            //Convert Array of lists TO lists of classtimeperiod objects 
            //to make it usable for a datagridview
            int id;
            String section;
            String course;
            String day;
            DateTime startTime;
            DateTime endTime;
            for (int i = 0; i < timeSlotTable[0].Count; i++)
            {
                id = Convert.ToInt32(timeSlotTable[0][i]);
                section = timeSlotTable[1][i];
                course = timeSlotTable[2][i];
                day = timeSlotTable[3][i];
                startTime = Convert.ToDateTime(timeSlotTable[4][i]);
                endTime = Convert.ToDateTime(timeSlotTable[5][i]);
                classSchedList.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime));
            }

            //debugging
            for (int i = 0; i < 6; i++)
            {
                foreach (String j in timeSlotTable[i])
                {
                    Console.WriteLine(j);
                }
            }
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
            
        }

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

            
            
            for(int i=0;i<6;i++)
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
        }

    }
}
