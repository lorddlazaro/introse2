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

        private String selectedEventDGV;
        private String selectedTimeslotDGV;
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
            comboBox1.SelectedIndex = 0;
        }
        //Tree View
        private void InitStudentListBox() 
        {
            UpdateStudentList(studentTreeView.Nodes);
        }
        private void studentTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            studentTreeView.SelectedNode = e.Node;
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

        private void ClearEverything() 
        {
            currPanelist = "";
            currStudent = "";
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
            if (dataGridViewExistingEvent.DataSource != null)
                dataGridViewExistingEvent.Rows[0].Selected = true;
            if (dataGridViewExistingTimeslot.DataSource != null)
                dataGridViewExistingTimeslot.Rows[0].Selected = true;
            labelSelectedPersonEvent.Text = "";
            labelSelectedPersonTimeslot.Text = "";
            update_events();
            update_courses();

        }

        private void panelistTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            panelistTreeView.SelectedNode = e.Node;
            if (e.Node.Level == 0)
            {
                ClearEverything();
            }
            else if (e.Node.Level == 1)
            {
                SwitchToPanelistMode(e.Node);
            }
        }

        private void SwitchToPanelistMode(TreeNode selectedNode) 
        {
            //enable buttons
            buttonAddExistingEvent.Enabled = true;
            buttonAddExistingWeeklyTimeslot.Enabled = true;
            buttonDeleteWeeklyTimeslot.Enabled = true;
            buttondeleteEvent.Enabled = true;

            //updates tables
            labelSelectedPersonEvent.Text = selectedNode.Text + "'s Events";
            labelSelectedPersonTimeslot.Text = selectedNode.Text + "'s Class Schedule";
            currPanelist = selectedNode.Name;
            RefreshPanelistClassScheds();
            RefreshPanelistEvents();
            update_courses();
            update_events();
        }

        private void SwitchToStudentMode(TreeNode selectedNode) 
        {
            //enable buttons
            buttonAddExistingEvent.Enabled = true;
            buttonAddExistingWeeklyTimeslot.Enabled = true;
            buttonDeleteWeeklyTimeslot.Enabled = true;
            buttondeleteEvent.Enabled = true;
            //updates tables
            labelSelectedPersonEvent.Text = selectedNode.Text + "'s Events";
            labelSelectedPersonTimeslot.Text = selectedNode.Text + "'s Class Schedule";
            currStudent = selectedNode.Name;
            RefreshStudentClassScheds();
            RefreshStudentEvents();
            update_courses();
            update_events();
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

        private bool IsTreeViewSetToStudents() 
        {
            return comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1;
        }

        public void refreshAll()
        {
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
            update_courses();
            update_events();
            RefreshTreeView();
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
            if(dataGridViewExistingTimeslot.DataSource==null||dataGridViewExistingTimeslot.SelectedRows.Count==0)
            {
                return;
            }
            
            int rowIndex = dataGridViewExistingTimeslot.SelectedRows[0].Index;
            TimePeriod classTimePeriod = new TimePeriod(Convert.ToDateTime(existingTimeslots[4][rowIndex]), Convert.ToDateTime(existingTimeslots[5][rowIndex]));
            String dayOfWeek = existingTimeslots[3][rowIndex];

            if (IsTreeViewSetToStudents())
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
                
                //START: Check for conflicts with other classes
                if (!schedulingDM.IsNewClassTimePeriodConflictFreeStudent(currStudent, classTimePeriod, dayOfWeek)) 
                {
                    MessageBox.Show("The new class schedule conflicts with another.", "Conflict with Other Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                

                //START: Defense Schedule Validation

                query = "SELECT thesisGroupID FROM student where studentID = '" + currStudent + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ClassAssignmentConflictFreeWithDefScheds(thesisGroupID, rowIndex, classTimePeriod);
                
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
                //START: Check for conflicts with other classes
                if (!schedulingDM.IsNewClassTimePeriodConflictFreePanelist(currPanelist, classTimePeriod, dayOfWeek))
                {
                    MessageBox.Show("The new class schedule conflicts with another.", "Conflict with Other Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            
                
                String query;
                
                query = "SELECT thesisGroupID FROM panelAssignment where panelistID = '" + currPanelist + "';";
                String thesisGroupID = dbHandler.Select(query, 1)[0][0];
                bool shouldProceed = ClassAssignmentConflictFreeWithDefScheds(thesisGroupID, rowIndex, classTimePeriod);
                if (shouldProceed) 
                {
                    if (existingTimeslots[6][rowIndex] != null)
                    {
                        DialogResult response = MessageBox.Show("This Timeslot already has a Professor. Overwrite?", "Panelist Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (response == DialogResult.Yes)
                        {
                            query = "UPDATE Timeslot SET panelistID = '" + currPanelist + "' WHERE (courseName = '" + existingTimeslots[1][rowIndex] + "') AND ( section = '" + existingTimeslots[2][rowIndex] + "') AND (day ='" + existingTimeslots[3][rowIndex] + "');";
                            dbHandler.Update(query);
                            RefreshPanelistClassScheds();
                        }
                    }
                }

            }
            update_courses();
            RefreshTreeView();
        }
        
        private bool ClassAssignmentConflictFreeWithDefScheds(String thesisGroupID, int rowIndex, TimePeriod classTimePeriod) 
        {            
            DefenseSchedule defSched = schedulingDM.GetDefSched(thesisGroupID, Constants.DEFENSE_TYPE);
            DefenseSchedule redefSched = schedulingDM.GetDefSched(thesisGroupID, Constants.REDEFENSE_TYPE);

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

            if (dataGridViewWeeklyTimeslot.DataSource==null||dataGridViewWeeklyTimeslot.SelectedRows.Count==0) 
            {
                return;
            }
            //NO VALIDATION NEEDED

            

            String selectedRowIndex = dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString();
            Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currTimeslot = timeSlotTable[0][dataGridViewWeeklyTimeslot.SelectedRows[0].Index];
            if (IsTreeViewSetToStudents())
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
                String query = "UPDATE Timeslot SET panelistID = NULL WHERE timeslotID = " + currTimeslot + ";";
                dbHandler.Update(query);
                Console.WriteLine("***********HEREHERE"+query);
                RefreshPanelistClassScheds();
            }

            update_courses();
            RefreshTreeView();
            if (dataGridViewWeeklyTimeslot.Rows.Count > 0 && (dataGridViewWeeklyTimeslot.DataSource == null || dataGridViewWeeklyTimeslot.SelectedRows.Count == 0))
            {
                dataGridViewWeeklyTimeslot.Rows[0].Selected = true;
                dataGridViewExistingTimeslot.ClearSelection();
                return;
            }
            
        }
        private void buttonWeeklyTimeslotEdit_Click(object sender, EventArgs e)
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
                for (int i = 0; i < dataGridViewExistingTimeslot.Columns.Count; i++)
                {
                    timeslotAdder.forEditing.Add(dataGridViewWeeklyTimeslot[i, rowIndex].Value.ToString());

                }
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

            
            if (dataGridViewExistingEvent.DataSource==null|| dataGridViewExistingEvent.SelectedRows.Count==0)
            { 
                return;
            }
            int rowIndex = dataGridViewExistingEvent.SelectedRows[0].Index;
            //VALIDATION
            //-Conflict of Defense Checking
            if (IsTreeViewSetToStudents())
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
            RefreshTreeView();
            
        }
        private void buttondeleteEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.DataSource==null || dataGridViewEvent.SelectedRows.Count==0) 
            {
                return;
            }
            String selectedRowIndex = dataGridViewEvent.SelectedRows[0].Index.ToString();
            //Console.WriteLine("selected row index(string): " + dataGridViewWeeklyTimeslot.SelectedRows[0].Index.ToString());
            String currEvent = eventTable[0][dataGridViewEvent.SelectedRows[0].Index];
            if (IsTreeViewSetToStudents())
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
            RefreshTreeView();

            if (dataGridViewEvent.Rows.Count > 0 && (dataGridViewEvent.DataSource == null || dataGridViewEvent.SelectedRows.Count == 0))
            {
                dataGridViewEvent.Rows[0].Selected = true;
                dataGridViewExistingEvent.ClearSelection();
                return;
            } 
        }
        private void buttonEventEdit_Click(object sender, EventArgs e)
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
                for (int i = 0; i < dataGridViewExistingEvent.Columns.Count; i++)
                {
                    eventAdder.forEditing.Add(dataGridViewEvent[i, rowIndex].Value.ToString());
                }
            }




            eventAdder.initializeTextBoxes();
            containerParent.Enabled = false;
            eventAdder.Visible = true;
            
        }
        // Student's or Panelist's timeslots and events
        public void update_courses() 
        {

            String query = "";
            if (IsTreeViewSetToStudents())
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT  Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM StudentSchedule RIGHT OUTER JOIN Timeslot ON StudentSchedule.timeslotID = Timeslot.timeslotID LEFT OUTER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE (Timeslot.timeslotID NOT IN (SELECT        timeslotID FROM            StudentSchedule AS StudentSchedule_1 WHERE        (studentID = '"+currStudent+"'))) ORDER BY Timeslot.courseName, Timeslot.section";
                Console.WriteLine(query);
            }
            else 
            {
                Console.WriteLine(currPanelist);
                query = "SELECT        Timeslot.timeslotID, Timeslot.courseName, Timeslot.section, Timeslot.day, Timeslot.startTime, Timeslot.endTime,  Panelist.firstName + ' ' + Panelist.MI + '. ' + Panelist.lastName AS Professor FROM            Timeslot LEFT OUTER JOIN Panelist ON Timeslot.panelistID = Panelist.panelistID WHERE        (NOT (Timeslot.panelistID = '"+currPanelist+"')) OR (Timeslot.panelistID IS NULL) ORDER BY Timeslot.courseName, Timeslot.section";
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
            dataGridViewExistingTimeslot.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dataGridViewExistingTimeslot.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
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
            if (IsTreeViewSetToStudents()) 
            {
                Console.WriteLine(currStudent);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM StudentEventRecord WHERE studentID = '"+currStudent+"');";
                Console.WriteLine(query);
            }
            else
            {
                Console.WriteLine(currPanelist);
                query = "SELECT DISTINCT eventID, name,eventStart,eventEnd FROM Event WHERE eventID NOT IN ( SELECT eventID FROM PanelistEventRecord WHERE panelistID = '"+currPanelist+"');";
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
                if (numUnscheduled >0)
                    parent.BackColor = Color.LightPink;

                tree.Add(parent);
            }
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
                if(!isScheduled(studentTable[0].ElementAt(j),"student"))
                {
                    node.BackColor = Color.LightPink;

                }
                tree.Add(node);
            }
        }

        public bool isScheduled(String ID, String personType) 
        {
            String query="";
            String query2 = "";

            if (personType.Equals("student"))
            {
                query = "SELECT timeslotID FROM StudentSchedule WHERE studentID ='" + ID + "'";
                query2 = "SELECT eventID FROM StudentEventRecord WHERE studentID ='"+ID+"'";
            }
            else if (personType.Equals("panelist"))
            {
                query = "SELECT timeslotID FROM Timeslot WHERE panelistID ='" + ID + "'";
                query2 = "SELECT eventID FROM PanelistEventRecord WHERE panelistID ='" + ID + "'";
            }    
            
            if (dbHandler.Select(query, 1)[0].Count > 0 || dbHandler.Select(query2,1)[0].Count>0)
                return true;
            else
                return false;
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

        private void dataGridViewExistingEvent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewEvent.ClearSelection();
            selectedEventDGV = "existing";
        }

        private void dataGridViewEvent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewExistingEvent.ClearSelection();
            selectedEventDGV = "current";
        }

        private void dataGridViewExistingTimeslot_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWeeklyTimeslot.ClearSelection();
            selectedTimeslotDGV = "existing";
        }

        private void dataGridViewWeeklyTimeslot_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewExistingTimeslot.ClearSelection();
            selectedTimeslotDGV = "current";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearEverything();
            if (comboBox1.SelectedIndex != 4)
                buttonDeletePanelist.Hide();
            else
                buttonDeletePanelist.Show();

            if (comboBox1.SelectedIndex == 0) 
            {
                studentTreeView.Show();
                treeViewStudents.Hide();
                panelistTreeView.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();

                currPanelist = "";
                UpdateStudentList(studentTreeView.Nodes);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                studentTreeView.Hide();
                treeViewStudents.Show();
                panelistTreeView.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();
                UpdateStudentTreeView(treeViewStudents.Nodes);
                currPanelist = "";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                studentTreeView.Hide();
                treeViewStudents.Hide();
                panelistTreeView.Show();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Hide();
                currStudent = "";
                UpdatePanelistList(panelistTreeView.Nodes);     
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                studentTreeView.Hide();
                treeViewStudents.Hide();
                panelistTreeView.Hide();
                treeViewPanelists.Show();
                treeViewUngroupedPanelists.Hide();
                currStudent = "";
                UpdatePanelistTreeView(treeViewPanelists.Nodes);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                studentTreeView.Hide();
                treeViewStudents.Hide();
                panelistTreeView.Hide();
                treeViewPanelists.Hide();
                treeViewUngroupedPanelists.Show();
                UpdateUngroupedPanelistTreeView(treeViewUngroupedPanelists.Nodes);
                currStudent = "";
            }
        }

        public void RefreshAll() 
        {
            Refresh();
            Cursor.Current = Cursors.WaitCursor;
            int old = comboBox1.SelectedIndex;
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = old;
            Cursor.Current = Cursors.Arrow;
        }

        private void buttonDeletePanelist_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(currPanelist))
            {
                MessageBox.Show("No Panelist Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String query = "DELETE FROM panelist WHERE panelistID = '" + currPanelist + "';";
            dbHandler.Delete(query);
            query = "DELETE FROM panelAssignment WHERE panelistID = '" + currPanelist + "';";
            dbHandler.Delete(query);
            query = "UPDATE timeslot SET panelist = NULL WHERE panelistID = '" + currPanelist + "';";
            currPanelist = "";
            ClearEverything();
            UpdateUngroupedPanelistTreeView(treeViewUngroupedPanelists.Nodes);
        }

    }
}
