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
        public Form containerParent;
        private SchedulingDataManager schedulingDM;

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
            schedulingDM = new SchedulingDataManager();
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
                //e.Node.Expand();

                //disables buttons
                buttonAddExistingEvent.Enabled = false;
                buttonAddExistingWeeklyTimeslot.Enabled = false;
                buttonDeleteWeeklyTimeslot.Enabled = false;
                buttondeleteEvent.Enabled = false;
                //clears the tables
                dataGridViewWeeklyTimeslot.DataSource = null;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewEvent.DataSource = null;
                dataGridViewEvent.Refresh();
            }
            else if (e.Node.Level == 1)
            {
                //enable buttons
                buttonAddExistingEvent.Enabled = true;
                buttonAddExistingWeeklyTimeslot.Enabled = true;
                buttonDeleteWeeklyTimeslot.Enabled = true;
                buttondeleteEvent.Enabled = true;
                //updates tables
                currStudent = e.Node.Name;
                RefreshStudentClassScheds();
                RefreshStudentEvents();
                update_courses();
                update_events();
                
                
            }
        }
        private void panelistTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                //disables buttons
                buttonAddExistingEvent.Enabled = false;
                buttonAddExistingWeeklyTimeslot.Enabled = false;
                buttonDeleteWeeklyTimeslot.Enabled = false;
                buttondeleteEvent.Enabled = false;
                //clears the tables
                dataGridViewWeeklyTimeslot.DataSource = null;
                dataGridViewWeeklyTimeslot.Refresh();
                dataGridViewEvent.DataSource = null;
                dataGridViewEvent.Refresh();
            }
            else if (e.Node.Level == 1)
            {
                //enable buttons
                buttonAddExistingEvent.Enabled = true;
                buttonAddExistingWeeklyTimeslot.Enabled = true;
                buttonDeleteWeeklyTimeslot.Enabled = true;
                buttondeleteEvent.Enabled = true;
                //updates tables
                currPanelist = e.Node.Name;
                RefreshPanelistClassScheds();
                RefreshPanelistEvents();
                update_courses();
                update_events();
            }
        }
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                currPanelist = "";
                personLabel.Text = "Panelists:";
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
                personLabel.Text = "Students:";
                btnSwitchView.Text = "Switch to Panelists";
                studentTreeView.Show();
                panelistTreeView.Hide();
                panelistTreeView.Enabled = false;
                studentTreeView.Enabled = true;
                UpdateStudentList(studentTreeView.Nodes);
            }
        }
        public void refreshAll()
        {
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                RefreshStudentClassScheds();
                RefreshStudentEvents();
                
            }
            else 
            {
                RefreshPanelistClassScheds();
                RefreshPanelistEvents();
            }
            update_courses();
            update_events();
        }
        //WEEKLY TIMESLOT
        private void buttonAddWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            //timeslotAdder.Visible = true;
            //timeslotAdder.initializePanel();
            timeslotAdder = new TimeslotCreator(false,containerParent,this);
            containerParent.Enabled = false;
            timeslotAdder.Visible = true;
            
        }
        private void buttonAddExistingWeeklyTimeslot_Click(object sender, EventArgs e)
        {
            if(dataGridViewExistingTimeslot.DataSource==null)
            {
                return;
            }
            
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;

            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                
                Console.WriteLine("rowindex: "+rowIndex);
                String query;
                int slot = Convert.ToInt32(dataGridViewExistingTimeslot["Id", rowIndex].Value.ToString());
                
                //VALIDATION-DUPLICATION
                /*
                query = "SELECT timeslotID FROM StudentSchedule WHERE (studentID = '" + currStudent + "') AND (timeslotID =" + slot + ");";

                List<String>[] duplicateCheck = dbHandler.Select(query, 1);

                if (duplicateCheck[0].Count == 1)
                {
                    MessageBox.Show("This timeslot is already a duplicate", "Duplicate Timeslot", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
                Console.WriteLine("slot: "+slot);
                */
                
                //START: Defense Schedule Validation

                query = "SELECT thesisGroupID FROM student where studentID = '" + currStudent + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ValidateClassAssignment(thesisGroupID, rowIndex);
                
                // END: Defense Schedule Validation
                if (shouldProceed)
                {
                    query = "INSERT INTO StudentSchedule(studentID, timeslotID)VALUES ('" + currStudent + "', " + Convert.ToInt32(slot) + ")";
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
                    RefreshStudentClassScheds();
                }

            }
            else
            {
                String query;
                


                query = "SELECT thesisGroupID FROM panelAssignment where panelistID = '" + currPanelist + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ValidateClassAssignment(thesisGroupID, rowIndex);
                if (shouldProceed) 
                {
                    if (existingTimeslots[6][rowIndex] != null)
                    {
                        DialogResult response = MessageBox.Show("This Timeslot already has a Professor. Overwrite?", "Panelist Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (response == DialogResult.Yes)
                        {
                            query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[2][rowIndex] + "') AND ( section = '" + existingTimeslots[1][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";
                            Console.WriteLine("*********HERE***********" + query);
                            dbHandler.Update(query);
                            Console.WriteLine(query);
                            RefreshPanelistClassScheds();

                        }
                    }
                }

            }

            update_courses();
                
            

        }


        private bool ValidateClassAssignment(String thesisGroupID, int rowIndex) 
        {            
            DefenseSchedule defSched = schedulingDM.GetDefSched(thesisGroupID, Constants.DEFENSE_TYPE);
            DefenseSchedule redefSched = schedulingDM.GetDefSched(thesisGroupID, Constants.REDEFENSE_TYPE);

            TimePeriod classTimePeriod = new TimePeriod(Convert.ToDateTime(existingTimeslots[4][rowIndex]), Convert.ToDateTime(existingTimeslots[5][rowIndex]));

            String defDayOfWeek;
            String redefDayOfWeek;
            
            bool conflictWithDefense = false; 
            bool conflictWithRedefense = false;

            if(defSched!=null)
            {
                defDayOfWeek = schedulingDM.ConvertDayOfWeekToString(defSched.StartTime.DayOfWeek);
                conflictWithDefense =  defDayOfWeek.Equals(existingTimeslots[3][rowIndex]) && classTimePeriod.IntersectsExclusive(defSched);
            }
            if(redefSched!=null)
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




        private void buttonDeleteWeeklyTimeslot_Click(object sender, EventArgs e)
        {

            if (dataGridViewWeeklyTimeslot.DataSource==null) 
            {
                return;
            }
            //NO VALIDATION NEEDED

            

            String selectedRowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString();
            Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currTimeslot = timeSlotTable[0][dataGridViewWeeklyTimeslot.SelectedRows[0].Index];
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                Console.WriteLine(currTimeslot + "-" + currStudent + "-");
                String query = "DELETE FROM StudentSchedule WHERE studentID = " + currStudent + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshStudentClassScheds();
            }
            else
            {
                Console.WriteLine(currTimeslot + "-" + currPanelist + "-");
                String query = "UPDATE Timeslot SET panelistID = NULL WHERE panelistID = " + currPanelist + " AND timeslotID = " + currTimeslot + ";";
                dbHandler.Update(query);
                Console.WriteLine(query);
                RefreshPanelistClassScheds();
            }

            update_courses();
        }
        private void buttonWeeklyTimeslotEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            timeslotAdder = new TimeslotCreator(true,containerParent,this);
            for(int i=0;i<dataGridViewExistingTimeslot.Columns.Count;i++)
            {
                timeslotAdder.forEditing.Add(dataGridViewExistingTimeslot[i,rowIndex].Value.ToString());

            }
            timeslotAdder.initializeTextBoxes();
            containerParent.Enabled = false;
            timeslotAdder.Visible = true;
            
            
        }
        //EVENTS
        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            eventAdder = new EventCreator(false,containerParent,this);
            containerParent.Enabled = false;
            eventAdder.Visible = true;
            
            
        }
        private void buttonAddExistingEvent_Click(object sender, EventArgs e)
        {
            String query;

            
            if (dataGridViewExistingEvent.DataSource==null)
            { 
                return;
            }
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            //VALIDATION
            //-Conflict of Defense Checking
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                query = "SELECT        DefenseSchedule.defenseDateTime, DefenseSchedule.defenseID, ThesisGroup.course FROM            DefenseSchedule INNER JOIN ThesisGroup ON DefenseSchedule.thesisGroupID = ThesisGroup.thesisGroupID INNER JOIN Student ON ThesisGroup.thesisGroupID = Student.thesisGroupID WHERE        (Student.studentID = '"+currStudent+"')";
            }
            else
                query = "SELECT        DefenseSchedule.defenseID, DefenseSchedule.defenseDateTime, ThesisGroup.course FROM            PanelAssignment INNER JOIN Panelist ON PanelAssignment.panelistID = Panelist.panelistID INNER JOIN ThesisGroup ON PanelAssignment.thesisGroupID = ThesisGroup.thesisGroupID INNER JOIN DefenseSchedule ON ThesisGroup.thesisGroupID = DefenseSchedule.thesisGroupID WHERE        (Panelist.panelistID = '"+currPanelist+"')";
            Console.WriteLine("Conflict of Defense Checking for AddExistingEvent query: "+query);

            List<String>[] defenseOfSelected = dbHandler.Select(query, 3);
            Console.WriteLine("count of defense: "+defenseOfSelected[0].Count);
            
            if (defenseOfSelected[0].Count > 0)
            {

                for (int i = 0; i < defenseOfSelected[0].Count; i++)
                {
                    DateTime maxStart;
                    DateTime minEnd;
                    DateTime defenseEndtime;
                    //get start of conflict
                    if (Convert.ToDateTime(defenseOfSelected[0][i]) > Convert.ToDateTime(existingEvents[2][rowIndex]))
                        maxStart = Convert.ToDateTime(defenseOfSelected[0][i]);
                    else
                        maxStart = Convert.ToDateTime(existingEvents[2][rowIndex]);

                    Console.WriteLine(maxStart);
                    //GET endtime of defense
                    if (defenseOfSelected[2][i].Equals("THSST-1"))
                        defenseEndtime = Convert.ToDateTime(defenseOfSelected[0][i]).AddMinutes(Constants.THSST1_DEFDURATION_MINS);
                    else
                        defenseEndtime = Convert.ToDateTime(defenseOfSelected[0][i]).AddMinutes(Constants.THSST3_DEFDURATION_MINS);
                    Console.WriteLine(defenseEndtime);
                    //get end of conflict
                    if (defenseEndtime > Convert.ToDateTime(existingEvents[3][rowIndex]))
                        minEnd = Convert.ToDateTime(existingEvents[3][rowIndex]);
                    else
                        minEnd = defenseEndtime;
                    Console.WriteLine(minEnd);
                    if (maxStart < minEnd)
                    {
                        DialogResult result;
                        if (btnSwitchView.Text.Equals("Switch to Panelists"))
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
            
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                
                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                    //SelectedRows[0].Cells[0].Value.ToString();
                Console.WriteLine(eventID);
                Console.WriteLine(currStudent);
                query = "INSERT INTO StudentEventRecord(studentID,eventID) VALUES('"+currStudent+"',"+eventID+");";
                Console.WriteLine(query);
                dbHandler.Insert(query);
                RefreshStudentEvents();
            }
            else
            {
                int eventID = Convert.ToInt32(existingEvents[0][rowIndex]);
                //SelectedRows[0].Cells[0].Value.ToString();
                Console.WriteLine(eventID);
                Console.WriteLine(currPanelist);
                query = "INSERT INTO PanelistEventRecord(panelistID,eventID) VALUES('" + currPanelist + "'," + eventID + ");";
                Console.WriteLine(query);
                dbHandler.Insert(query);
                RefreshPanelistEvents();
                
            }
            update_events();
            
        }
        private void buttondeleteEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.DataSource==null) 
            {
                return;
            }
            String selectedRowIndex = dataGridViewEvent.SelectedRows[0].Index.ToString();
            //Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currEvent = eventTable[0][dataGridViewEvent.SelectedRows[0].Index];
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                Console.WriteLine(currEvent + "-" + currStudent + "-");
                String query = "DELETE FROM StudentEventRecord WHERE studentID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshStudentEvents();
            }
            else
            {
                Console.WriteLine(currEvent + "-" + currStudent + "-");
                String query = "DELETE FROM PanelistEventRecord WHERE panelistID = " + currStudent + " AND eventID = " + currEvent + ";";
                dbHandler.Delete(query);
                Console.WriteLine(query);
                RefreshPanelistEvents();
            }

            update_events();
        }
        private void buttonEventEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            eventAdder = new EventCreator(true, containerParent,this);
            for (int i = 0; i < dataGridViewExistingEvent.Columns.Count; i++)
            {
                eventAdder.forEditing.Add(dataGridViewExistingEvent[i,rowIndex].Value.ToString());
            }
            eventAdder.initializeTextBoxes();
            containerParent.Enabled = false;
            eventAdder.Visible = true;
            
        }
        // Student's or Panelist's timeslots and events
        public void update_courses() 
        {

            String query = "";
            if (btnSwitchView.Text.Equals("Switch to Panelists"))
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT  StudentSchedule.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM StudentSchedule INNER JOIN Timeslot ON StudentSchedule.timeslotID = Timeslot.timeslotID LEFT OUTER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE (StudentSchedule.timeslotID NOT IN (SELECT        timeslotID FROM            StudentSchedule AS StudentSchedule_1 WHERE        (studentID = '"+currStudent+"'))) ORDER BY Timeslot.courseName, Timeslot.section";
                Console.WriteLine(query);
            }
            else 
            {
                Console.WriteLine(currPanelist);
                query = "SELECT        Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM            Timeslot INNER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE        (NOT (Timeslot.panelistID = '"+currPanelist+"')) OR (Timeslot.panelistID IS NULL) ORDER BY Timeslot.courseName, Timeslot.section";
                Console.WriteLine(query);
            }
            Console.WriteLine("QUERY FOR UPDATE_COURSES: "+query);
            existingTimeslots = dbHandler.Select(query, 7);
            if (existingTimeslots[0].Count == 0)
            {
                dataGridViewExistingTimeslot.DataSource = null;
                dataGridViewExistingTimeslot.Refresh();
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
            dataGridViewExistingTimeslot.Columns[5].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Columns[6].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewExistingTimeslot.Columns["Id"].Visible = false;

            dataGridViewExistingTimeslot.Columns["Course"].Width = 70;
            dataGridViewExistingTimeslot.Columns["Section"].Width = 50;
            dataGridViewExistingTimeslot.Columns["Day"].Width = 30;
            dataGridViewExistingTimeslot.Columns["Panelist"].Width = 130;
            dataGridViewExistingTimeslot.Columns["StartTime"].Width = 80;
            dataGridViewExistingTimeslot.Columns["EndTime"].Width = 80;

            
            //dataGridViewExistingTimeslot.Sort(dataGridViewExistingTimeslot.Columns[1], ListSortDirection.Ascending);
            dataGridViewExistingTimeslot.Refresh();
            Console.WriteLine("existingtimeslot refreshed");
        }
        public void update_events()
        {
            String query = "";
            if (btnSwitchView.Text.Equals("Switch to Panelists")) 
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '"+currStudent+"');";
                Console.WriteLine(query);
            }
            else
            {
                Console.WriteLine(currPanelist);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '"+currPanelist+"');";
                Console.WriteLine(query);
            }
            

            existingEvents = dbHandler.Select(query, 4);

            if (existingEvents[0].Count == 0)
            {
                dataGridViewExistingEvent.DataSource = null;
                dataGridViewExistingEvent.Refresh();
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
        public void RefreshTreeView() 
        {
            Console.WriteLine("IM BEING CALLED IM BEING CALLED");
            UpdateStudentList(studentTreeView.Nodes);
            
            UpdatePanelistList(panelistTreeView.Nodes);
        }
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
            Console.WriteLine("Starting RefreshClassScheds with columname:" + columnName);
            String query;
            if (columnName.Equals("studentID"))
                query = "SELECT timeslotID from studentSchedule where studentID = '" + ID + "';";
            else if (columnName.Equals("panelistID"))
            {
                query = "SELECT timeslotID from timeslot where panelistID = '" + ID + "';";
                Console.WriteLine("querying panelist timeslots...");
            }
            else
            {
                Console.WriteLine("RefreshClassScheds returning...");
                return;
            }
            List<String> timeSlots = dbHandler.Select(query, 1)[0];
            if (timeSlots.Count == 0)
            {
                dataGridViewWeeklyTimeslot.DataSource = null;
                dataGridViewWeeklyTimeslot.Refresh();
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
            Console.WriteLine("refreshClassScheds 1stquery: "+query);
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
                panelistID = timeSlotTable[6][i];
                classSchedList.Add(new ClassTimePeriod(id, section, course, day, startTime, endTime,panelistID));
            }

            dataGridViewWeeklyTimeslot.DataSource = classSchedList;
            dataGridViewWeeklyTimeslot.Columns[5].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewWeeklyTimeslot.Columns[6].DefaultCellStyle.Format = "HH:mm:ss tt";
            dataGridViewWeeklyTimeslot.Columns["Id"].Visible = false;

            dataGridViewWeeklyTimeslot.Columns["Course"].Width = 70;
            dataGridViewWeeklyTimeslot.Columns["Section"].Width = 50;
            dataGridViewWeeklyTimeslot.Columns["Day"].Width = 30;
            dataGridViewWeeklyTimeslot.Columns["Panelist"].Width = 130;
            dataGridViewWeeklyTimeslot.Columns["StartTime"].Width = 80;
            dataGridViewWeeklyTimeslot.Columns["EndTime"].Width = 80;

            dataGridViewWeeklyTimeslot.Refresh();
            Console.WriteLine("RefreshClassScheds finished, now returning..");

        }
        private void RefreshEvents(String ID, String columnName, String tableName)
        {
            eventList.Clear();

            String query = "SELECT Event.eventID, name, eventStart, eventEnd from Event INNER JOIN " + tableName + " ON Event.eventID = " + tableName+ ".eventID WHERE " + columnName + " = '" + ID + "' ORDER BY eventStart, eventEnd;";
            eventTable = dbHandler.Select(query, 4);

            if (eventTable[0].Count == 0)
            {
                dataGridViewEvent.DataSource = null;
                dataGridViewEvent.Refresh();
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
            studentTreeView.BeginUpdate();
            UpdateTreeView(tree, "studentID", "student");
            studentTreeView.EndUpdate();
            studentTreeView.Refresh();
        }
        public void RefreshStudentClassScheds()
        {
            RefreshClassScheds(currStudent, "studentID");
        }
        public void RefreshStudentEvents()
        {
            RefreshEvents(currStudent, "studentID", "StudentEventRecord");
        }
        //PANELISTS
        public void UpdatePanelistList(TreeNodeCollection tree)
        {
            panelistTreeView.BeginUpdate();
            UpdateTreeView(tree, "panelistID", "panelist");
            panelistTreeView.EndUpdate();
            panelistTreeView.Refresh();
        }
        public void RefreshPanelistClassScheds()
        {
            RefreshClassScheds(currPanelist, "panelistID");
        }
        public void RefreshPanelistEvents()
        {
            RefreshEvents(currPanelist, "panelistID", "PanelistEventRecord");
        }
    }
}
