using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomUserControl
{
    public partial class TimeslotCreator : Form
    {
        private Form parent;
        private ScheduleEditor subParent;
        private DBce dbHandler = new DBce();
        private List<String>[] panelTable;
        private BindingList<Panelist> panelList = new BindingList<Panelist>();
        public List<String> forEditing = new List<String>();
        public bool isEditMode = false;
        private ListViewItem lastItemChecked;

        public String panelistID;
        private SchedulingDataManager schedulingDM;

        public TimeslotCreator(bool editMode,Form p,ScheduleEditor sp)
        {
            parent = p;
            subParent = sp;
            this.isEditMode = editMode;
            InitializeComponent();
            initializePanel();
            comboBoxPanelist.SelectedIndex = comboBoxPanelist.FindStringExact(" None. ");
            //dateTimePickerWeeklyTimeslotStartTime.Value = DateTime.MinValue;
            //dateTimePickerWeeklyTimeslotEndTime.Value = DateTime.MinValue;
            Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value);
            Console.WriteLine(dateTimePickerWeeklyTimeslotEndTime.Value);
                
            schedulingDM = new SchedulingDataManager();
        }
        public void initializeTextBoxes() 
        {
            listViewWeeklyTimeslotDay.MultiSelect = false;
            textBoxWeeklyTimeslotCourse.Text = forEditing[1];
            textBoxWeeklyTimeslotSection.Text = forEditing[2];
            switch (forEditing[3]) 
            {
                case "M": listViewWeeklyTimeslotDay.Items[0].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[0]; 
                    break;
                case "T": listViewWeeklyTimeslotDay.Items[1].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[1]; 
                    break;
                case "W": listViewWeeklyTimeslotDay.Items[2].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[2]; 
                    break;
                case "H": listViewWeeklyTimeslotDay.Items[3].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[3]; 
                    break;
                case "F": listViewWeeklyTimeslotDay.Items[4].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[4]; 
                    break;
                case "S": listViewWeeklyTimeslotDay.Items[5].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[5]; 
                    break;
            }
            for(int i =0;i<7;i++)
                Console.WriteLine(forEditing[i]);
            dateTimePickerWeeklyTimeslotStartTime.Value = Convert.ToDateTime(forEditing[5]);
            dateTimePickerWeeklyTimeslotEndTime.Value = Convert.ToDateTime(forEditing[6]);
            /*int panelIndex=0;
            for(int i=0;i<comboBoxPanelist.Items.Count;i++)
            {
                if(comboBoxPanelist.Items[i].ToString().Equals(forEditing[6]))
                    panelIndex = i;
            }*/
            comboBoxPanelist.SelectedIndex = comboBoxPanelist.FindStringExact(forEditing[4]);
            Console.WriteLine(forEditing[6] + "==");
            //Console.WriteLine(comboBoxPanelist.Items[].ToString());
            //Console.WriteLine(comboBoxPanelist.Items[comboBoxPanelist.FindStringExact(forEditing[6])].ToString());

        }
        public void initializePanel()
        {
            String query = "SELECT panelistID, firstName, MI, lastName FROM Panelist;";
            panelTable = dbHandler.Select(query, 4);

            if (panelTable[0].Count == 0)
            {
                return;
            }

            //Convert from 2D list to list of events
            int id;
            String firstName;
            String MI;
            String lastName;
            for (int i = 0; i < panelTable[0].Count; i++)
            {
                id = Convert.ToInt32(panelTable[0][i]);
                firstName = panelTable[1][i];
                MI = panelTable[2][i];
                lastName = panelTable[3][i];
                panelList.Add(new Panelist(id, firstName, MI, lastName));
            }
            panelList.Add(new Panelist(0, "", "None", ""));
            

            comboBoxPanelist.DataSource = panelList;
            //comboBoxEvent.DataSource = panelList;
            //comboBoxEvent.Items.Remove("eventStart");
            
        }

        private void buttonCancelTimeslot_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Dispose();
        }

        private void buttonSaveTimeslot_Click(object r, EventArgs e)
        {
            labelWarning.Text = "";
            textBoxWeeklyTimeslotCourse.BackColor = Color.White;
            textBoxWeeklyTimeslotSection.BackColor = Color.White;
            listViewWeeklyTimeslotDay.BackColor = Color.White;
            if (textBoxWeeklyTimeslotCourse.Text.Length > 7 || textBoxWeeklyTimeslotCourse.Text == "") 
            {
                labelWarning.Text = "Course should be 7 characters.";
                textBoxWeeklyTimeslotCourse.BackColor = Color.LightPink;
                //MessageBox.Show("Course should be less than 7 characters and shouldn't be null", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxWeeklyTimeslotSection.Text.Length > 3 || textBoxWeeklyTimeslotSection.Text =="") 
            {
                labelWarning.Text = "Section should be 3 characters.";
                textBoxWeeklyTimeslotSection.BackColor = Color.LightPink;
                //MessageBox.Show("section should be less than 3 characters and shouldn't be null", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int j=0;
            for (int i = 0; i < listViewWeeklyTimeslotDay.Items.Count; i++) 
            {
                if (listViewWeeklyTimeslotDay.Items[i].Checked) 
                {
                    j++;
                }
            }
            if (j == 0) 
            {
                labelWarning.Text = "Select at least one checkbox.";
                listViewWeeklyTimeslotDay.BackColor = Color.LightPink;
                //MessageBox.Show("select at least one checkbox", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateTimePickerWeeklyTimeslotStartTime.Value.TimeOfDay >= dateTimePickerWeeklyTimeslotEndTime.Value.TimeOfDay)
            {
                labelWarning.Text = "Time is invalid";
                dateTimePickerWeeklyTimeslotStartTime.CalendarTitleForeColor = Color.LightPink;
                Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.CompareTo(dateTimePickerWeeklyTimeslotEndTime.Value));
                //MessageBox.Show("Time is invalid", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // START: Duplicate Checking

            String query;

            // END: Duplicate Checking


            if (isEditMode)
            {
                
                
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
                        }
                    }
                }
                query = "SELECT timeslotID FROM Timeslot WHERE courseName = '" + textBoxWeeklyTimeslotCourse.Text + "' AND section ='" + textBoxWeeklyTimeslotSection.Text + "' AND day ='" + day + "'";
                Console.WriteLine("duplicate check start----"+query);
                List<String> duplicate = dbHandler.Select(query, 1)[0];
                
                if (duplicate.Count > 0)
                {
                    Console.WriteLine("Count: "+duplicate[0]);
                    if(!duplicate[0].Equals(forEditing[0]))
                    {
                        MessageBox.Show("The timeslot already exists", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (comboBoxPanelist.Text.Equals(" None. "))
                    panelistID = "NULL";
                else
                    panelistID =panelTable[0][comboBoxPanelist.SelectedIndex];
               
                

                //Validation
                
                //Case 1: Change panel. Must check defense and class for this panel only.
                 //Case 2: Change starttime or endtime. Must check defense and class for all students and panel having this.

                String panelistName = "";
                String panelistNameConflictDef = "";

                List<String>[] studentTable;
                List<String>[] timeslotTable;
                TimePeriod currTimePeriod;
                List<String> studentNamesWithClassConflict = new List<String>();
                List<String> studentIDsWithClassConflict = new List<String>();

                TimePeriod classTimePeriod = new TimePeriod(dateTimePickerWeeklyTimeslotStartTime.Value, dateTimePickerWeeklyTimeslotEndTime.Value);
             
                String timeSlotID = forEditing[0];
                List<DefenseSchedule> defSchedsWithConflict = new List<DefenseSchedule>();
                List<String> conflictedDefSchedIDs = new List<String>();

                String thesisGroupID;
                String thesisGroupTitle;
                List<String>[] thesisGroupTable;

                //START: Check for conflicts with other classes

                if(!panelistID.Equals("NULL"))
                {
                    query = "SELECT startTime, endTime FROM timeslot WHERE day = '" + day + "' AND timeslot.timeslotID <> " + timeSlotID + " AND panelistID = '" + panelistID + "';";
                    timeslotTable = dbHandler.Select(query, 2);

                    for (int k = 0; k < timeslotTable[0].Count; k++)
                    {
                        currTimePeriod = new TimePeriod(Convert.ToDateTime(timeslotTable[0][k]), Convert.ToDateTime(timeslotTable[1][k]));
                        if (currTimePeriod.IntersectsExclusive(classTimePeriod))
                        {
                            query = "SELECT firstName+' '+MI+'. '+lastName from PANELIST WHERE panelistID = '" + panelistID + "';";
                            panelistName = dbHandler.Select(query, 1)[0][0];
                            break;
                        }
                    }
                 

                    query = "SELECT thesisgroupID from panelAssignment WHERE panelistID = '"+panelistID+"';";
                    thesisGroupID = dbHandler.Select(query, 1)[0][0];
                    defSchedsWithConflict = schedulingDM.GetDefenseConflictsWithClassTimePeriod(thesisGroupID, classTimePeriod, day);
                    if(defSchedsWithConflict.Count>0)
                    {
                        panelistNameConflictDef = panelistName;
                        for (int k = 0; k < defSchedsWithConflict.Count; k++) 
                        {
                            conflictedDefSchedIDs.Add(defSchedsWithConflict[k].DefenseID);
                        }
                    }
                }


                query = "SELECT distinct student.studentID, firstName+' '+MI+'. '+lastName FROM student INNER JOIN studentSchedule on student.studentID = studentSchedule.studentID WHERE timeslotID = " + timeSlotID + ";";
                studentTable = dbHandler.Select(query, 2);
                int rows = studentTable[0].Count;
                String currStudentID;
                String currStudentName;
                List<String> thesisGroupNamesWithDefConflict = new List<String>();
                List<String> thesisGroupIDsWithDefConflict = new List<String>();
                
                for (int i = 0; i < rows; i++)
                {
                    currStudentID = studentTable[0][i];
                    currStudentName = studentTable[1][i];
                    query = "SELECT startTime, endTime FROM timeslot INNER JOIN studentSchedule ON timeslot.timeslotID = studentSchedule.timeslotID WHERE day = '" + day + "' AND timeslot.timeslotID <> " + timeSlotID + " AND studentID = '" + currStudentID + "';";
                    timeslotTable = dbHandler.Select(query, 2);
                   
                    for (int k = 0; k < timeslotTable[0].Count; k++)
                    {
                        currTimePeriod = new TimePeriod(Convert.ToDateTime(timeslotTable[0][k]), Convert.ToDateTime(timeslotTable[1][k]));
                        if (currTimePeriod.IntersectsExclusive(classTimePeriod))
                        {
                            studentIDsWithClassConflict.Add(currStudentID);
                            studentNamesWithClassConflict.Add(currStudentName);
                            break;
                        }
                    }
                }
                
                
                if (rows >= 0)  // if there are students who have this schedule being edited
                {

                    query = "SELECT distinct thesisgroup.thesisGroupID, title FROM student INNER JOIN thesisGroup ON student.thesisGroupID = thesisGroup.thesisGroupID WHERE ";

                    for (int i = 0; i < rows; i++)
                    {
                        currStudentID = studentTable[0][i];
                        currStudentName = studentTable[1][i];
                        query += " studentID = '" + currStudentID + "' ";
                        if (i == rows - 1)
                            query += ";";
                        else
                            query += " OR ";
                    }


                    thesisGroupTable = dbHandler.Select(query, 2);
                    rows = thesisGroupTable[0].Count;
                    for (int i = 0; i < rows; i++)
                    {
                        thesisGroupID = thesisGroupTable[0][i];
                        thesisGroupTitle = thesisGroupTable[1][i];
                        
                        defSchedsWithConflict = schedulingDM.GetDefenseConflictsWithClassTimePeriod(thesisGroupID, classTimePeriod, day);
                        if (defSchedsWithConflict.Count > 0) 
                        {
                            thesisGroupIDsWithDefConflict.Add(thesisGroupID);
                            thesisGroupNamesWithDefConflict.Add(thesisGroupTitle);
                        }

                        for (int k = 0; k < defSchedsWithConflict.Count; k++) 
                        {
                            conflictedDefSchedIDs.Add(defSchedsWithConflict[k].DefenseID);
                        }

                    }
                }
                
                
                String warningMsg = "";

                if (studentNamesWithClassConflict.Count > 0)
                {
                    warningMsg += "The new class time period conflicts with the current class schedule for :";
                    if (!String.IsNullOrEmpty(panelistName))
                        warningMsg += Environment.NewLine+"(Panelist) " + panelistName;
                    for (int i = 0; i < studentNamesWithClassConflict.Count; i++)
                        warningMsg += Environment.NewLine+studentNamesWithClassConflict[i];

                    warningMsg += Environment.NewLine + Environment.NewLine + "Please make sure there is no conflict first, then try your changes again.";
                    
                    MessageBox.Show(warningMsg, "Conflict with Class Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if ( conflictedDefSchedIDs.Count > 0)
                {
                    warningMsg += "Defense Schedule Conflicts with:";
                   
                    if (!String.IsNullOrEmpty(panelistNameConflictDef))
                        warningMsg += Environment.NewLine + "Panelist: " + panelistNameConflictDef;
                    for (int i = 0; i < thesisGroupNamesWithDefConflict.Count; i++)
                    {
                        warningMsg += Environment.NewLine + thesisGroupNamesWithDefConflict[i];
                        
                    }
                    warningMsg += Environment.NewLine + "Continuing will delete defense schedules for all the groups above.";

                    if (DialogResult.Cancel == MessageBox.Show(warningMsg, "Conflict with Defense Schedules", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)) 
                        return;

                    query = "DELETE FROM defenseSchedule WHERE ";
                    for (int i = 0; i < conflictedDefSchedIDs.Count; i++)
                    {
                        query += "defenseID = " + conflictedDefSchedIDs[i];
                        if (i < thesisGroupNamesWithDefConflict.Count - 1)
                            query += " OR ";
                        else
                            query += ";";
                    }
                    Console.WriteLine("********DELETING ******\n" + query+"\n\n\n\n");
                    dbHandler.Delete(query);
                }

                Console.WriteLine("*******TEST UPDATE********");
                if (panelistID.Equals("NULL"))
                    query = "UPDATE Timeslot SET section = N'" + textBoxWeeklyTimeslotSection.Text + "', courseName = N'" + textBoxWeeklyTimeslotCourse.Text + "', day = N'" + day + "', startTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), endTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), panelistID = " + panelistID + " WHERE timeslotID = '" + forEditing[0] + "';";
                else
                    query = "UPDATE Timeslot SET section = N'" + textBoxWeeklyTimeslotSection.Text + "', courseName = N'" + textBoxWeeklyTimeslotCourse.Text + "', day = N'" + day + "', startTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), endTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), panelistID = '" + panelistID + "' WHERE timeslotID = '" + forEditing[0] + "';";
             
                Console.WriteLine(query);
                Console.WriteLine("*******TEST UPDATE********");
                
                dbHandler.Update(query);
            }
            else
            {
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

                        }
                        query = "SELECT timeslotID FROM Timeslot WHERE courseName = '" + textBoxWeeklyTimeslotCourse.Text + "' AND section ='" + textBoxWeeklyTimeslotSection.Text + "' AND day ='" + day + "'";
                        Console.WriteLine("duplicate check start----" + query);
                        List<String> duplicate = dbHandler.Select(query, 1)[0];

                        if (duplicate.Count > 0)
                        {
                        
                            MessageBox.Show("The timeslot on day "+ day+" already exists", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                            
                        }
                    }
                }




                day = "";
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

                        }

                   
                        if (comboBoxPanelist.Text.Equals(" None. "))
                        {
                            //Console.WriteLine("comboboxpanelist = null");
                            //query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), NULL)";
                            query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), NULL)";
                        }
                        else
                        {
                            panelistID = panelTable[0][comboBoxPanelist.SelectedIndex];
                            //Console.WriteLine("panelistID: " + panelistID);
                            //query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), N'" + panelistID + "')";
                            query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), N'" + panelistID + "')";
                        }

                        
                        
                        try
                        {
                            dbHandler.Insert(query);
                            Console.WriteLine(query);
                            Console.WriteLine("ADD NEW-INSERT SUCCESS");
                        }
                        catch (SqlException sqlEx)
                        {
                            if (sqlEx.Source != null)
                                Console.WriteLine("IOException source: {0}", sqlEx.Source);
                            Console.WriteLine("query= " + query);
                            //if(textBoxWeeklyTimeslotCourse.Text == null)
                        }
                            

                    }
                }
            }
            subParent.refreshAll();
            parent.Enabled = true;
            Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value);
            Console.WriteLine(dateTimePickerWeeklyTimeslotEndTime.Value);
            this.Dispose();
        }

        private void listViewWeeklyTimeslotDay_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // if we have the lastItem set as checked, and it is different
            // item than the one that fired the event, uncheck it
            if (isEditMode)
            {
                if (lastItemChecked != null && lastItemChecked.Checked && lastItemChecked != listViewWeeklyTimeslotDay.Items[e.Item.Index])
                {
                    // uncheck the last item and store the new one
                    lastItemChecked.Checked = false;
                }

                // store current item
                lastItemChecked = listViewWeeklyTimeslotDay.Items[e.Item.Index];
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Enabled = true;
        }

    }
}
