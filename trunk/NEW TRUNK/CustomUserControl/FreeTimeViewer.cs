using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace CustomUserControl
{
    public partial class FreeTimeViewer : UserControl
    {
        private DateTime startOfTheWeek;
        private DateTime endOfTheWeek;

        private SchedulingDataManager schedulingDM;

        private List<Label> labelDates;

        private String currPanelistID;
        private String currGroupID;

        private int dayWidth;
        private double totalMinsInDay;

        private const int VIEW_INDEX_CLUSTER = 0;
        private const int VIEW_INDEX_ISOLATED = 1;

        private const int TYPE_INDEX_DEFENSE = 0;
        private const int TYPE_INDEX_REDEFENSE = 1;

        private String currDefenseType;
        private bool isCheckingInProgram;

        //check
        bool isGroupBoxWidened;
        bool defenseRecordExistsInDatabase;
        DBce dbHandler;
        string currDefenseID;

        /****** START: Initializing Methods *******/
        public FreeTimeViewer()
        {
            InitializeComponent();

            isCheckingInProgram = false;

            //check
            dbHandler = new DBce();
            schedulingDM = new SchedulingDataManager();

            //Initialize some variables
            dayWidth = panelCalendar.DisplayRectangle.Width / Constants.DAYS_IN_DEF_WEEK;
            totalMinsInDay = Convert.ToDateTime(Constants.LIMIT_HOUR + ":" + Constants.LIMIT_MIN).Subtract(Convert.ToDateTime(Constants.START_HOUR + ":" + Constants.START_MIN)).TotalMinutes;

            currPanelistID = "";
            currGroupID = "";

            labelDates = new List<Label>();
            labelDates.Add(labelDate1);
            labelDates.Add(labelDate2);
            labelDates.Add(labelDate3);
            labelDates.Add(labelDate4);
            labelDates.Add(labelDate5);
            labelDates.Add(labelDate6);

            //Initialize ComboBoxes
            datePicker_ValueChanged(new Object(), new EventArgs());
            comboBoxView.SelectedIndex = VIEW_INDEX_ISOLATED;
            comboBox1.SelectedIndex = TYPE_INDEX_DEFENSE; //this will trigger a refresh all that will initialize the whole thing

            /*Initialize TreeViews
            treeViewClusters.BeginUpdate();
            schedulingDM.AddPanelistsToTree(treeViewClusters.Nodes, "eligibleFor" + currDefenseType);
            treeViewClusters.EndUpdate();
            treeViewClusters.ExpandAll();
            treeViewClusters.Focus();

            treeViewIsolatedGroups.BeginUpdate();
            schedulingDM.AddIsolatedGroupsToTree(treeViewIsolatedGroups.Nodes, "eligibleFor" + currDefenseType);
            treeViewIsolatedGroups.ExpandAll();
            treeViewIsolatedGroups.EndUpdate();
            */


            MarkAllScheduledGroups();

            //check
            isGroupBoxWidened = true;

        }
        /****** END: Initializing Methods *******/


        /****** START: Drawing Methods*******/
        private void panelCalendar_Paint(object sender, PaintEventArgs e)
        {
            //if(!currPanelistID.Equals(""))
                //DrawClusterDefScheds(e.Graphics, panelCalendar.DisplayRectangle);
            if (!currGroupID.Equals(""))
            {
                DrawFreeTimes(e.Graphics, panelCalendar.DisplayRectangle);
                DrawCurrGroupDefSched(e.Graphics, panelCalendar.DisplayRectangle);
            }

            DrawCalendarDivisions();
        }

        private void DrawCurrGroupDefSched(Graphics g, Rectangle panelRectangle) 
        {
            if (schedulingDM.CurrGroupDefSched != null)
            {
                /* The following two variables represent unadjusted day indices.
                * That is, Mon = 0, Tues = 1, Wed = 2, Thu = 3, Fri = 4, Sat = 5.
                * */
                int dayIndex;
                int startOfTheWeekDayIndex = GetDayIndex(startOfTheWeek.DayOfWeek);

                /* Represents the adjusted index depending on the starting day in the calendar. 
                 * Example, Monday, which is supposed to be 0, becomes 1 if the day starts with Saturday(which is the 0 in this case)),
                 * because Monday becomes the second day in the calendar.
                * */
                int adjustedDayIndex;

                dayIndex = GetDayIndex(schedulingDM.CurrGroupDefSched.StartTime.DayOfWeek);
                adjustedDayIndex = (dayIndex + (Constants.DAYS_IN_DEF_WEEK - startOfTheWeekDayIndex)) % Constants.DAYS_IN_DEF_WEEK;

                DrawTimePeriod(g, Color.Tomato, panelRectangle, adjustedDayIndex, schedulingDM.CurrGroupDefSched);
            }
        }

        private void DrawClusterDefScheds(Graphics g, Rectangle panelRectangle) 
        {
            int size = schedulingDM.ClusterDefScheds.Count;

            /* The following two variables represent unadjusted day indices.
             * That is, Mon = 0, Tues = 1, Wed = 2, Thu = 3, Fri = 4, Sat = 5.
             * */
            int dayIndex;
            int startOfTheWeekDayIndex = GetDayIndex(startOfTheWeek.DayOfWeek);

            /* Represents the adjusted index depending on the starting day in the calendar. 
             * Example, Monday, which is supposed to be 0, becomes 1 if the day starts with Saturday(which is the 0 in this case)),
             * because Monday becomes the second day in the calendar.
            * */
            int adjustedDayIndex; 

            DefenseSchedule curr;
            for (int i = 0; i < size; i++)
            {
                curr = schedulingDM.ClusterDefScheds[i];
                dayIndex = GetDayIndex(curr.StartTime.DayOfWeek);
                adjustedDayIndex = (dayIndex+(Constants.DAYS_IN_DEF_WEEK - startOfTheWeekDayIndex))%Constants.DAYS_IN_DEF_WEEK;

                DrawTimePeriod(g, Color.CadetBlue, panelRectangle, adjustedDayIndex, curr );
            }
        }

        private int GetDayIndex(DayOfWeek day) 
        {
            return (int)day - 1;
        }

        private void DrawFreeTimes(Graphics g, Rectangle panelRectangle) 
        {
            int size;
            List<TimePeriod> currDay;
            DateTime currDateTime;

            for (int i = 0; i < Constants.DAYS_IN_DEF_WEEK; i++) 
            {
                currDateTime = Convert.ToDateTime(labelDates[i].Text);
                currDay = schedulingDM.SelectedGroupFreeTimes[(int)currDateTime.DayOfWeek - 1];
                size = currDay.Count;
                //Console.WriteLine("["+i+"] has "+size+" elements.");
                for (int j = 0; j < size; j++) 
                    if(currDay[j].EndTime.TimeOfDay.Subtract(currDay[j].StartTime.TimeOfDay).TotalMinutes >= Constants.MIN_DURATION_MINS)
                        DrawTimePeriod(g, Color.LightGreen, panelRectangle, i, currDay[j]);
            }
        }

        private void DrawTimePeriod(Graphics g, Color color, Rectangle panelRectangle, int dayIndex, TimePeriod timePeriod)
        {
            int leftX = panelRectangle.Left;
            int topY = panelRectangle.Top;

            DateTime earliestTime = new DateTime(timePeriod.StartTime.Year, timePeriod.StartTime.Month, timePeriod.StartTime.Day, Constants.START_HOUR, Constants.START_MIN, 0);

            double yCoord = panelRectangle.Height * (timePeriod.StartTime.TimeOfDay.Subtract(earliestTime.TimeOfDay).TotalMinutes / totalMinsInDay);
            double schedHeight = panelRectangle.Height * (timePeriod.EndTime.TimeOfDay.Subtract(timePeriod.StartTime.TimeOfDay).TotalMinutes / totalMinsInDay);

            int margin = 2;

            /* For Debugging Purposes
            Console.WriteLine(timePeriod.ToString());
            Console.WriteLine((leftX + dayIndex * dayWidth + margin)+", "+((int)(topY + yCoord))+", "+(dayWidth - margin * 2)+", "+schedHeight);
            Console.WriteLine();
            /* For Debugging Purposes*/

            Font font1 = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Point);
            Rectangle rect = new Rectangle(leftX + dayIndex * dayWidth + margin, (int)(topY + yCoord), dayWidth - margin * 2, (int)schedHeight);
            g.FillRectangle(new SolidBrush(color), rect);
            g.DrawString(timePeriod.ToString(),font1, new SolidBrush(Color.Black),  rect, new StringFormat());
        }
        
        private void DrawCalendarDivisions()
        {
            Brush aSolidBrush = new SolidBrush(Color.Brown);  //Creates a black solid brush for the pen  
            Pen aSolidPen = new Pen(aSolidBrush);  //Assigns the SolidBrush to the Pen  
            Graphics graphics = panelCalendar.CreateGraphics();
            aSolidPen.DashStyle = DashStyle.Dash;

            int numHours = Constants.LIMIT_HOUR - Constants.START_HOUR;
            Rectangle displayRect = panelCalendar.DisplayRectangle;
            int hourHeight = (int) Math.Round(displayRect.Height * (60/totalMinsInDay));
           
            int yCoord;

            for (int i = 1; i < numHours; i++) 
            {
                yCoord = displayRect.Top+i*hourHeight;
                graphics.DrawLine(aSolidPen, new Point(displayRect.Left, yCoord), new Point(displayRect.Right, yCoord));
            }
           

        }
        /****** END: Drawing Methods*******/


        /****** START: EVENT LISTENERS*******/

        //This method updates the date labels when the selected startDate is changed.
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            startOfTheWeek = datePicker.Value;
            if (startOfTheWeek.DayOfWeek.Equals(System.DayOfWeek.Sunday))
            {
                startOfTheWeek = datePicker.Value.AddDays(1);
                datePicker.Value = startOfTheWeek;
                MessageBox.Show("No school on Sundays.", "Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            DateTime currDate = startOfTheWeek;
            
            int i;
            for (i = 0; i < labelDates.Count; i++)
            {
                labelDates[i].Text = currDate.DayOfWeek + "\n" + currDate.ToString("d");
                labelDates[i].TextAlign = ContentAlignment.MiddleCenter;
                
                currDate = currDate.AddDays(1);
                if (currDate.DayOfWeek.Equals(System.DayOfWeek.Sunday))
                    currDate = currDate.AddDays(1);
            }

            endOfTheWeek = Convert.ToDateTime(labelDates[i - 1].Text);

            if (!currPanelistID.Equals(""))
                schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
            if (!currGroupID.Equals(""))
                schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
            
            panelCalendar.Refresh();
        }

        //This method records the current thesisgroup and panelist selected in cluster view.
        private void treeViewClusters_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                /* Progress Bar 
                int numTasks = 3;
                int progressBarIncrement = progressBar1.Maximum / numTasks;
                /* Progress Bar */


                //Task1: Refresh Cluster Defense Schedules
                currPanelistID = e.Node.Name;
                schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
                //UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 2: Deselect the currently selected thesis group if any.
                if(!currGroupID.Equals(""))
                    ChangeSelectedGroup("");
                //UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 3: Refresh 
                panelCalendar.Refresh();
               // UpdateProgressBar(progressBar1, progressBarIncrement);

                //UpdateProgressBar(progressBar1, progressBar1.Maximum); //Just to make the progress bar reach its maximum.
            }
            else if (e.Node.Level == 1)
            {
                /* Progress Bar
                int numTasks = 3;
                int progressBarIncrement = progressBar1.Maximum / numTasks;
                /* Progress Bar */

                //Task 1: Change panelists if user clicked on another cluster.
                if (!e.Node.Parent.Name.Equals(currPanelistID))
                {
                    currPanelistID = e.Node.Parent.Name;
                    schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
                }
                //UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 2: Change selected group if user clicked on a different one.
                if (!currGroupID.Equals(e.Node.Name))
                {
                    ChangeSelectedGroup(e.Node.Name);
                } 
                //UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 3: Refresh
                panelCalendar.Refresh();
                //UpdateProgressBar(progressBar1, progressBarIncrement);

                //Just to make sure the progress bar reaches its maximum.
                //UpdateProgressBar(progressBar1, progressBar1.Maximum);             

                treeViewClusters.SelectedNode = e.Node;
            }
        }

        /*
        //Updates the progress bar until its maximum. The bar is reset to zero only during the next time it is made to update.
        private void UpdateProgressBar(ProgressBar progressBar1, int increment) 
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Minimum;
                progressBar1.Show();
            }
            else if (progressBar1.Value + increment < progressBar1.Maximum)
            {
                progressBar1.Value += increment;
                progressBar1.Show();
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Hide();
            }

            progressBar1.Refresh();
        }
         * */
        
        //Switches the view between cluster and isolated depending on the user's selected item in the combobox.
        private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxView.SelectedIndex == VIEW_INDEX_CLUSTER)
            {
                treeViewClusters.Show();
                treeViewIsolatedGroups.Hide();
                MarkAllScheduledGroups();
            }
            else if (comboBoxView.SelectedIndex == VIEW_INDEX_ISOLATED)
            {
                treeViewClusters.Hide();
                treeViewIsolatedGroups.Show();
                MarkAllScheduledGroups();
            }
        }

        private void treeViewIsolatedGroups_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            /*
            int numTasks = 3;
            int progressBarIncrement = progressBar1.Maximum / numTasks;
            */

            currPanelistID = "";

            //Task 1: Refresh the current free times.
            ChangeSelectedGroup(e.Node.Name);
            //UpdateProgressBar(progressBar1, progressBarIncrement);

            //Task 2: Refresh
            panelCalendar.Refresh();
            //UpdateProgressBar(progressBar1, progressBarIncrement);

            //Just to make sure the progress bar reaches its maximum.
            //UpdateProgressBar(progressBar1, progressBar1.Maximum); 
            treeViewIsolatedGroups.SelectedNode = e.Node;
        }

        /*This action listener prevents manual checking of checkboxes in the treeviews. 
        This method allows only the checks created by the method MarkAllScheduledGroups().
         * */
        private void treeViewClusters_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!isCheckingInProgram)
            {
                e.Cancel = true;
            }
            else
                isCheckingInProgram = false;
            
        }

        private void treeViewIsolatedGroups_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!isCheckingInProgram)
            {
                e.Cancel = true;
            }
            else
                isCheckingInProgram = false;
         
        }
        /****** END: EVENT LISTENERS*******/


        /******* OTHER METHODS******/

        //Changes the selectedGroupID to the new ID given in the parameter, then refreshes the list of free times in schedulingDM.
        public void ChangeSelectedGroup(String newThesisGroupID)
        {
            currGroupID = newThesisGroupID;
            if (newThesisGroupID.Equals(""))
            {
                labelGroupInfo.Text = "";
                labelPanelists.Text = "";
                HideGroupBox();
            }
            else
            {
                ShowGroupBox();

                labelGroupInfo.Text = "Selected Group: " + schedulingDM.GetGroupInfo(currGroupID);
                labelPanelists.Text = "Panelists:"+schedulingDM.GetPanelists(currGroupID);
                //check
                titleTextBox.Text = schedulingDM.GetGroupInfo(currGroupID).Split(':')[1];
                courseSectionTextBox.Text = schedulingDM.GetGroupInfo(currGroupID).Split(':')[0];

                string query = "select defenseid, place, defensedatetime from defenseschedule where thesisgroupid = '" + currGroupID + "' AND defenseType = '"+currDefenseType+"';";

                List<string>[] queryResult = dbHandler.Select(query, 3);
                
                if (queryResult[0].Count() == 0)
                    ChangeGroupBox(null);
                else
                    ChangeGroupBox(queryResult);
            }
            schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID,currDefenseType);
            schedulingDM.RefreshGroupDefSched(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);

            /*For debugging purposes
            for (int currDay = 0; currDay < 6; currDay++)
            {
                Console.WriteLine("Day: " + currDay);
                for (int i = 0; i < schedulingDM.SelectedGroupFreeTimes[currDay].Count; i++)
                    Console.WriteLine(schedulingDM.SelectedGroupFreeTimes[currDay].ElementAt(i));
            }
            /*For debugging purposes*/
        }

        //Check the checkboxes of groups that already have a defense schedule.
        private void MarkAllScheduledGroups() 
        {
            if (schedulingDM != null)
            {
                schedulingDM.RefreshScheduledGroupIDs(currDefenseType);
                TreeView currTreeView;

                if (comboBoxView.SelectedIndex == VIEW_INDEX_CLUSTER) 
                {
                    currTreeView = treeViewClusters;
                    //Console.WriteLine("currTreeView = clusters");
                }
                else// if (comboBoxView.SelectedIndex == VIEW_INDEX_ISOLATED) 
                {
                    currTreeView = treeViewIsolatedGroups;
                    
                    //Console.WriteLine("currTreeView = isolated");
                }
           
                currTreeView.BeginUpdate();
                if (currTreeView.Nodes.Count > 2) // If Cluster View
                {
                    foreach (TreeNode level1 in currTreeView.Nodes)
                    {
                        foreach (TreeNode group in level1.Nodes)
                        {
                            isCheckingInProgram = true;
                            if (schedulingDM.ScheduledGroupIDs.Contains(group.Name))
                                group.Checked = true;
                            else
                                group.Checked = false;
                        }
                    }
                }
                else 
                {
                    foreach (TreeNode course in currTreeView.Nodes)
                    {
                        foreach (TreeNode group in course.Nodes)
                        {
                            isCheckingInProgram = true;
                            if (schedulingDM.ScheduledGroupIDs.Contains(group.Name))
                                group.Checked = true;
                            else
                                group.Checked = false;
                        }
                    }
                }
              
                currTreeView.EndUpdate();
                currTreeView.Refresh();
            }
        }

        //check

        private void HideGroupBox()
        {
            int defaultWidth = 254;
            int longLength = 477;
            Size newSize = new Size(defaultWidth, longLength);

            treeViewClusters.Size = newSize;
            treeViewIsolatedGroups.Size = newSize;
            defenseInfoGroupBox.Visible = false;
        }

        private void ShowGroupBox() 
        {
            defenseInfoGroupBox.Visible = true;
        }

        private void WidenGroupBox() 
        {
            addDefenseButton.Visible = false;
            venueLabel.Visible = true;
            defenseDateTimePicker.Visible = true;
            dateTimeLabel.Visible = true;

            int defaultWidth = 254;
            int longLength = 153;
            defenseInfoGroupBox.Size = new Size(defaultWidth, longLength);

            int defaultX = 701;
            int longY = 433;
            defenseInfoGroupBox.Location = new Point(defaultX, longY);

            int treeViewDefaultWidth = 254;
            int treeViewShortLength = 318;
            Size newSize = new Size(treeViewDefaultWidth, treeViewShortLength);

            treeViewClusters.Size = newSize;
            treeViewIsolatedGroups.Size = newSize;
            this.Refresh();
            isGroupBoxWidened = true;
        }

        private void ShortenGroupBox() 
        {
            addDefenseButton.Visible = true;
            venueLabel.Visible = false;
            defenseDateTimePicker.Visible = false;
            dateTimeLabel.Visible = false;

            int defaultWidth = 254;
            int shortLength = 100;
            defenseInfoGroupBox.Size = new Size(defaultWidth, shortLength);

            int defaultX = 701;
            int shortY = 486;
            defenseInfoGroupBox.Location = new Point(defaultX, shortY);

            int treeViewDefaultWidth = 254;
            int treeViewShortLength = 371;
            Size newSize = new Size(treeViewDefaultWidth, treeViewShortLength);

            treeViewClusters.Size = newSize;
            treeViewIsolatedGroups.Size = newSize;

            this.Refresh();
            isGroupBoxWidened = false;
        }

        private void ChangeGroupBox(List<string>[] queryResult) 
        {
            if (queryResult != null)
            {
                defenseRecordExistsInDatabase = true;

                if(!isGroupBoxWidened)
                    WidenGroupBox();

                //if (isGroupBoxWidened)
                    //ShortenGroupBox();

                string date = queryResult[2].ElementAt(0).Split(' ')[0];
                string time = queryResult[2].ElementAt(0).Split(' ')[1] + " " + queryResult[2].ElementAt(0).Split(' ')[2];

                //Console.WriteLine(date + "|" + time);

                int year = Convert.ToInt16(date.Split('/')[2]);
                int day = Convert.ToInt16(date.Split('/')[1]);
                int month = Convert.ToInt16(date.Split('/')[0]);
                int hour = Convert.ToInt16(time.Split(':')[0]);
                int minute = Convert.ToInt16(time.Split(':')[1]);
                //if (time.Split(' ')[1].Equals("PM"))
                //    hour += 12;

                currDefenseID = queryResult[0].ElementAt(0);
                venueTextBox.Text = queryResult[1].ElementAt(0);
                defenseDateTimePicker.Value = new DateTime(year, month, day, hour, minute, 0, 0);
            }
            else 
            {
                defenseRecordExistsInDatabase = false;

                if (isGroupBoxWidened)
                    ShortenGroupBox();
            }
        }

        private void deleteDefenseButton_Click(object sender, EventArgs e)
        {
            string messageBoxText = "Are you sure you want to delete the current record?";
            string messageBoxCaption = "Delete current record?";

            if (defenseRecordExistsInDatabase)
            {
                if (MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = "delete from defenseschedule where defenseid ='" + currDefenseID + "';";
                    dbHandler.Delete(query);
                    ClearDefenseInfo();
                    ShortenGroupBox();

                    //Console.WriteLine("Deleting from database");
                    RefreshCalendar();
                    MarkAllScheduledGroups();
                    defenseRecordExistsInDatabase = false;
                }
            }
            else 
            {
                if (MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClearDefenseInfo();
                    ShortenGroupBox();

                    //Console.WriteLine("Clearing data");

                    RefreshCalendar();
                    MarkAllScheduledGroups();
                }
            }
        }

        private void ClearDefenseInfo() {
            venueTextBox.Clear();
            defenseDateTimePicker.ResetText();
        }

        private void saveDefenseButton_Click(object sender, EventArgs e)
        {
            string messageBoxText = "Are you sure you want to save changes made?";
            string messageBoxCaption = "Save Changes?";
            string query;

            if (defenseRecordExistsInDatabase)
            {
                if (IsDefenseInfoValid() && MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string dateTime = string.Format("{0:M/d/yyyy h:mm:ss tt}", defenseDateTimePicker.Value);
           
                    query = "update defenseschedule set defensedatetime = '" + dateTime + "', place = '" + venueTextBox.Text + "' where defenseid = '" + currDefenseID + "' AND defenseType ='"+currDefenseType+"';";
                    dbHandler.Update(query);

                   
                    //if (!currPanelistID.Equals(""))
                        //schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
                    if (!currGroupID.Equals(""))
                        schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);

                    RefreshCalendar();
                    Console.WriteLine("I'm here");
                    MarkAllScheduledGroups();
                }
            }
            else
            {
                if (IsDefenseInfoValid() && MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string dateTime = string.Format("{0:M/d/yyyy h:mm:ss tt}", defenseDateTimePicker.Value);
                    //Console.WriteLine(dateTime);

                    query = "insert into defenseschedule (defensedatetime,place,thesisgroupid, defenseType) values('" + dateTime + "','" + venueTextBox.Text + "','" + currGroupID + "','"+currDefenseType+"');";
                    dbHandler.Insert(query);

                    query = "select defenseid from defenseschedule where defensedatetime= '"+dateTime+"' and place='"+venueTextBox.Text+"' and thesisgroupid='"+currGroupID+"';";
                    currDefenseID = dbHandler.Select(query,1)[0].ElementAt(0);

                    //Console.WriteLine("Inserting into database");

                    RefreshCalendar();
                    MarkAllScheduledGroups();
                    defenseRecordExistsInDatabase = true;
                }
            }
        }

        private bool IsDefenseInfoValid() 
        {
            // note:    this is so that tbe cursor and focus will be moved away from the editable components
            //          reason being that without these or some other workaround, data changed in the 
            //          currently focused components will not be included in the checking. 
            //          Basically it's to resolve the bug that the software does not recognize the most recent
            //          input value if the focus is still on the component.
            titleTextBox.Focus();
            courseSectionTextBox.Focus();

            // preprocessing current time selected
            string dateTimeString = string.Format("{0:M/d/yyyy H:mm}", defenseDateTimePicker.Value);

            int month = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[0]);
            int day = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[1]);
            int year = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[2]);
            int hour = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[0]);
            int minute = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[1]);
                    
            TimeSpan time = new TimeSpan(hour, minute, 0);
            DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
            DateTime savedDateTime = DateTime.Today;
            TimePeriod timePeriod = new TimePeriod(DateTime.Today, DateTime.Today);
            TimePeriod currPeriod = new TimePeriod(DateTime.Today, DateTime.Today);

            if (defenseRecordExistsInDatabase)
            {
                string query = "select defensedatetime from defenseschedule where defenseid =" + currDefenseID;
                dateTimeString = string.Format("{0:M/d/yyyy H:mm}", dbHandler.Select(query,1)[0].ElementAt(0));

                month = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[0]);
                day = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[1]);
                year = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[2]);
                hour = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[0]);
                minute = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[1]);
                savedDateTime = new DateTime(year, month, day, hour, minute, 0);
            }

            // CASE 1: Time selected is set before 8:00AM
            if (time < new TimeSpan(8, 0, 0))
            {
                MessageBox.Show("Invalid Time: You can only schedule from 8:00AM to 7:00PM for THSST-1 and 8:00AM to 8:00PM for THSST-3", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // CASE 2: Time selected is set after 8:00PM (THSST-1) or 7:00PM (THSST-3)
            if (courseSectionTextBox.Text.Split(' ')[1].Equals("THSST-1"))
            {
                if(defenseRecordExistsInDatabase)
                    currPeriod = new TimePeriod(savedDateTime, savedDateTime.AddHours(1));
                timePeriod = new TimePeriod(dateTime, dateTime.AddHours(1));
                if (time > new TimeSpan(20, 0, 0))
                {
                    MessageBox.Show("Invalid Time: You can only schedule from 8:00AM to 8:00PM for THSST-1 and 8:00AM to 7:00PM for THSST-3", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if(defenseRecordExistsInDatabase)
                    currPeriod= new TimePeriod(savedDateTime, savedDateTime.AddHours(2));
                timePeriod = new TimePeriod(dateTime, dateTime.AddHours(2));
                if (time > new TimeSpan(19, 0, 0))
                {
                    MessageBox.Show("Invalid Time: You can only schedule from 8:00AM to 8:00PM for THSST-1 and 8:00AM to 7:00PM for THSST-3", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            /* Case 3: Time selected is not a multiple of 5 (in minutes)
            if (time.Minutes % 5 != 0)
            {
                MessageBox.Show("Invalid Time: Must be in 5 minute intevals", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            // Case 4: Date selected is a sunday
            if (defenseDateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Invalid Date: Defenses can't be scheduled on a sunday.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Case 5: Selected time doesn't fit the free time of those involved
            //if(defenseRecordExistsInDatabase)
            //    schedulingDM.AddToSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, Convert.ToInt16(defenseDateTimePicker.Value.DayOfWeek) - 1, timePeriod);
            

            bool found = false;
            
            bool upbool = false;
            bool downbool = false;
            bool foundOne = false;

            if (defenseRecordExistsInDatabase)
            {
                if (currPeriod.IsBetweenInclusive(currPeriod.StartTime, currPeriod.EndTime, timePeriod.StartTime))
                    upbool = true;

                if (currPeriod.IsBetweenInclusive(currPeriod.StartTime, currPeriod.EndTime, timePeriod.EndTime))
                    downbool = true;

                found = upbool && downbool;
                foundOne = upbool || downbool;
                //Console.WriteLine("   " + found + " " + foundOne+ "   "+ currPeriod.StartTime+" "+currPeriod.EndTime +"," + timePeriod.StartTime+" "+timePeriod.EndTime);
            }

            if(!found)
            {
                List<TimePeriod>[] list = schedulingDM.SelectedGroupFreeTimes;

                //Console.WriteLine("comparing " + timePeriod.StartTime + " " + timePeriod.EndTime + ".");
                foreach (TimePeriod freeTime in list[Convert.ToInt16(defenseDateTimePicker.Value.DayOfWeek) - 1])
                {
                    Console.WriteLine("   " + freeTime.StartTime + " " + freeTime.EndTime + ".");
                    if (timePeriod.isWithin(freeTime))
                    {
                        found = true;
                        break;
                    }
                    
                    if(foundOne)
                    {
                        //Console.WriteLine(upbool + " " + downbool);
                        if (!upbool)
                            upbool = timePeriod.IsBetweenInclusive(freeTime.StartTime, freeTime.EndTime, timePeriod.StartTime);
                        if(!downbool)
                            downbool =timePeriod.IsBetweenInclusive(freeTime.StartTime, freeTime.EndTime, timePeriod.EndTime);
                        found = upbool && downbool;
                        if(found)
                            break;
                    }
                }
            }


            if (!found)
            {
                MessageBox.Show("Error: Time conflict, please choose another time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Case 6: No venue specified (Could be accepted)
            if (venueTextBox.Text.Length == 0)
                if (MessageBox.Show("Warning: No venue specified, is this alright?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    return true;

            // Valid input
            return true;
        }

        private void addDefenseButton_Click(object sender, EventArgs e)
        {
            ClearDefenseInfo();
            WidenGroupBox();
        }

        private void RefreshCalendar() {
            //if (!currPanelistID.Equals(""))
                //schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
            if (!currGroupID.Equals(""))
            {
                schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
                schedulingDM.RefreshGroupDefSched(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
            }
            panelCalendar.Refresh();
        }

        public void RefreshAll() 
        {
            Invalidate();
            RefreshTreeViews();
            MarkAllScheduledGroups();
            RefreshCalendar();
            defenseInfoGroupBox.Refresh();
            Validate();
        }
        
        // refresh treeviews from form1
        public void RefreshTreeViews()
        {
            treeViewClusters.BeginUpdate();
            treeViewClusters.Nodes.Clear();
            schedulingDM.AddPanelistsToTree(treeViewClusters.Nodes, "eligibleFor"+currDefenseType);
            treeViewClusters.EndUpdate();
            treeViewClusters.ExpandAll();
            treeViewClusters.Focus();

            treeViewIsolatedGroups.BeginUpdate();
            treeViewIsolatedGroups.Nodes.Clear();
            schedulingDM.AddIsolatedGroupsToTree(treeViewIsolatedGroups.Nodes, "eligibleFor"+currDefenseType);
            treeViewIsolatedGroups.EndUpdate();
            treeViewIsolatedGroups.ExpandAll();

            MarkAllScheduledGroups();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == TYPE_INDEX_DEFENSE)
                currDefenseType = Constants.DEFENSE_TYPE;
            else
                currDefenseType = Constants.REDEFENSE_TYPE;
            ChangeSelectedGroup("");
            RefreshAll();
        }
    }
}