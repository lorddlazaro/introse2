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
        private const int TYPE_INDEX_DEFENSE = 0;
        private const int TYPE_INDEX_REDEFENSE = 1;
        private const int VIEW_INDEX_CLUSTER = 0;
        private const int VIEW_INDEX_REGULAR = 1;

        private bool isCheckingInProgram;
        private bool isGroupBoxWidened;

        private double totalMinsInDay;

        private DateTime startOfTheWeek;
        private DateTime endOfTheWeek;

        private int dayWidth;

        private List<Label> labelDates;

        private SchedulingDataManager schedulingDM;

        private String currDefenseType;
        private String currGroupID;

        /****** START: Initializing Methods *******/
        public FreeTimeViewer()
        {
            InitializeComponent();

            isCheckingInProgram = false;
            isGroupBoxWidened = true;

            //check
            schedulingDM = new SchedulingDataManager();

            //Initialize some variables
            dayWidth = panelCalendar.DisplayRectangle.Width / Constants.DAYS_IN_DEF_WEEK;
            totalMinsInDay = Convert.ToDateTime(Constants.LIMIT_HOUR + ":" + Constants.LIMIT_MIN).Subtract(Convert.ToDateTime(Constants.START_HOUR + ":" + Constants.START_MIN)).TotalMinutes;

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
            comboBoxView.SelectedIndex = VIEW_INDEX_REGULAR;
            comboBoxDefenseType.SelectedIndex = TYPE_INDEX_DEFENSE; //this will trigger a refresh all that will initialize the whole thing            
        }
        /****** END: Initializing Methods *******/

        /********START: Refresh Methods*********/
        public void RefreshAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            Refresh();
            ChangeSelectedGroup(currGroupID);
            RefreshTreeViews();
            MarkAllScheduledGroups();
            RefreshCalendar();
            groupBoxDefenseInfo.Refresh();
            Cursor.Current = Cursors.Arrow;
        }

        private void RefreshCalendar()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!currGroupID.Equals(""))
            {
                schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
                schedulingDM.RefreshGroupDefSched(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
            }
            panelCalendar.Refresh();
            Cursor.Current = Cursors.Arrow;
        }

        public void RefreshTreeViews()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeViewClusters.BeginUpdate();
            treeViewClusters.Nodes.Clear();
            schedulingDM.AddPanelistsToTree(treeViewClusters.Nodes, "eligibleFor" + currDefenseType);
            treeViewClusters.EndUpdate();
            treeViewClusters.ExpandAll();
            treeViewClusters.Focus();

            treeViewIsolatedGroups.BeginUpdate();
            treeViewIsolatedGroups.Nodes.Clear();
            schedulingDM.AddIsolatedGroupsToTree(treeViewIsolatedGroups.Nodes, "eligibleFor" + currDefenseType);
            treeViewIsolatedGroups.EndUpdate();
            treeViewIsolatedGroups.ExpandAll();

            MarkAllScheduledGroups();

            Cursor.Current = Cursors.Arrow;
        }
        /********END: Refresh Methods**********/


        /****** START: EVENT LISTENERS*******/

        //Facilitates the GUI changes to facilitate addition of defenses. E.g., make the form for addition visible.
        private void addDefenseButton_Click(object sender, EventArgs e)
        {
            ClearDefenseInfo();
            WidenGroupBox();
        }

        //Refreshes screen accordingly when the defense type is changed. 
        private void comboBoxDefenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDefenseType.SelectedIndex == TYPE_INDEX_DEFENSE)
                currDefenseType = Constants.DEFENSE_TYPE;
            else
                currDefenseType = Constants.REDEFENSE_TYPE;
            ChangeSelectedGroup("");
            RefreshAll();
        }

        //Switches the view between cluster and isolated depending on the user's selected item in the combobox.
        private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxView.SelectedIndex == VIEW_INDEX_CLUSTER)
            {
                treeViewClusters.Show();
                treeViewIsolatedGroups.Hide();
                MarkAllScheduledGroups();
            }
            else if (comboBoxView.SelectedIndex == VIEW_INDEX_REGULAR)
            {
                treeViewClusters.Hide();
                treeViewIsolatedGroups.Show();
                MarkAllScheduledGroups();
            }
            ChangeSelectedGroup("");
            RefreshCalendar();
        }

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

            if (!currGroupID.Equals(""))
                schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
            
            panelCalendar.Refresh();
        }

        //Facilitates the deletion of defense schedules.
        private void deleteDefenseButton_Click(object sender, EventArgs e)
        {
            string messageBoxText = "Are you sure you want to delete the current record?";
            string messageBoxCaption = "Delete current record?";

            if (schedulingDM.CurrGroupDefSched!=null)
            {
                if (MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    schedulingDM.DeleteSelectedGroupDefense();
                    ClearDefenseInfo();
                    ShortenGroupBox();

                    ChangeSelectedGroup(currGroupID);
                    MarkAllScheduledGroups();
                    RefreshCalendar();
                    groupBoxDefenseInfo.Refresh();
                }
            }
            else //Cancel edit/add
            {
                ClearDefenseInfo();
                ShortenGroupBox();

                ChangeSelectedGroup(currGroupID);
                MarkAllScheduledGroups();
                RefreshCalendar();
                groupBoxDefenseInfo.Refresh();
            }
        }

        //Facilitates the saving of defense schedules into the database. 
        private void saveDefenseButton_Click(object sender, EventArgs e)
        {
            String messageBoxText = "Are you sure you want to save changes made?";
            String messageBoxCaption = "Save Changes?";
            String query;
            String dateTime = String.Format("{0:M/d/yyyy h:mm:ss tt}", defenseDateTimePicker.Value);


            if (IsDefenseInfoValid() && MessageBox.Show(messageBoxText, messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
            {
                Refresh();
                schedulingDM.InsertNewDefenseIntoDB(currGroupID, dateTime, venueTextBox.Text, currDefenseType);
                
                //Refresh Part
                if (!currGroupID.Equals(""))
                    schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);

                RefreshCalendar();
                MarkAllScheduledGroups();
                
            }

            
        }

        //This method records the current thesisgroup and panelist selected in cluster view.
        private void treeViewClusters_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                if(!currGroupID.Equals(""))
                    ChangeSelectedGroup("");
             
                panelCalendar.Refresh();
            }
            else if (e.Node.Level == 1)
            {
                //Change selected group if user clicked on a different one.
                if (!currGroupID.Equals(e.Node.Name))
                {
                    ChangeSelectedGroup(e.Node.Name);
                } 
                
                panelCalendar.Refresh();
                treeViewClusters.SelectedNode = e.Node;
            }
        }

        //Handles the selection of thesis groups in the tree view.
        private void treeViewIsolatedGroups_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            //Task 1: Refresh the current free times.
            ChangeSelectedGroup(e.Node.Name);
          
            //Task 2: Refresh
            panelCalendar.Refresh();
            
            //Selects the node even when the checkbox is clicked (because normally it does not).
            treeViewIsolatedGroups.SelectedNode = e.Node;
        }

        /*Thse two action listeners prevents manual checking of checkboxes in the treeviews. 
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

        /****** START: GUI Methods For Changing Defense Addition/Editing Forms *******/
        //GroupBox here refers to the form for adding/editing defense schedules.

        //Changes the group info in the form for adding/editing form
        private void ChangeGroupBox(DefenseSchedule defSchedule)
        {
            if (defSchedule != null)
            {
                WidenGroupBox();
                
                String date = defSchedule.StartTime.Date.ToString();
                String time = defSchedule.StartTime.TimeOfDay.ToString();

                int year = defSchedule.StartTime.Year;

                int day = defSchedule.StartTime.Day;
                int month = defSchedule.StartTime.Month;
                int hour = defSchedule.StartTime.Hour;
                int minute = defSchedule.StartTime.Minute;
               
                venueTextBox.Text = defSchedule.Place;
                 
                defenseDateTimePicker.Value = new DateTime(year, month, day, hour, minute, 0, 0);
            }
            else
            {
                ShortenGroupBox();
            }
        }

        private void ClearDefenseInfo()
        {
            venueTextBox.Clear();
            defenseDateTimePicker.ResetText();
        }

        private void HideGroupBox()
        {
            int defaultWidth = 254;
            int longLength = 477;
            Size newSize = new Size(defaultWidth, longLength);

            treeViewClusters.Size = newSize;
            treeViewIsolatedGroups.Size = newSize;
            groupBoxDefenseInfo.Visible = false;
        }

        private void WidenGroupBox()
        {
            addDefenseButton.Visible = false;
            labelVenue.Visible = true;
            defenseDateTimePicker.Visible = true;
            labelDateTime.Visible = true;

            int defaultWidth = 254;
            int longLength = 153;
            groupBoxDefenseInfo.Size = new Size(defaultWidth, longLength);

            int defaultX = 701;
            int longY = 433;
            groupBoxDefenseInfo.Location = new Point(defaultX, longY);

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
            labelVenue.Visible = false;
            defenseDateTimePicker.Visible = false;
            labelDateTime.Visible = false;

            int defaultWidth = 254;
            int shortLength = 100;
            groupBoxDefenseInfo.Size = new Size(defaultWidth, shortLength);

            int defaultX = 701;
            int shortY = 486;
            groupBoxDefenseInfo.Location = new Point(defaultX, shortY);

            int treeViewDefaultWidth = 254;
            int treeViewShortLength = 371;
            Size newSize = new Size(treeViewDefaultWidth, treeViewShortLength);

            treeViewClusters.Size = newSize;
            treeViewIsolatedGroups.Size = newSize;

            this.Refresh();
            isGroupBoxWidened = false;
        }

        private void ShowGroupBox()
        {
            groupBoxDefenseInfo.Visible = true;
        }

        private bool IsDefenseInfoValid()
        {
            /*New Implementation*/
            String dateTimeString = String.Format("{0:M/d/yyyy H:mm:tt}", defenseDateTimePicker.Value);
            String course = courseSectionTextBox.Text.Split(' ')[1]; 
            String errorMsg = schedulingDM.GetErrorWithThisDefenseInfo(dateTimeString, course, defenseDateTimePicker.Value.DayOfWeek);

            if (!errorMsg.Equals(""))
            {
                MessageBox.Show(errorMsg, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (venueTextBox.Text.Length == 0)
                if (MessageBox.Show("Warning: No venue specified, is this alright?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    return true;
                else
                    return false;

            return true;
            /*New Implementation*/


        }
        
        /****** END:   GUI Methods For Changing Defense Addition/Editing Forms *******/

        /****** START: Drawing Methods For The Calendar*******/
        private void panelCalendar_Paint(object sender, PaintEventArgs e)
        {
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
                if (DateTimeHelper.IsBetweenInclusive(schedulingDM.CurrGroupDefSched.StartTime.Date, startOfTheWeek, endOfTheWeek))
                {
                    /* The following two variables represent unadjusted day indices.
                    * That is, Mon = 0, Tues = 1, Wed = 2, Thu = 3, Fri = 4, Sat = 5.
                    * */
                    int dayIndex;
                    int startOfTheWeekDayIndex = schedulingDM.GetDayIndex(startOfTheWeek.DayOfWeek);

                    /* Represents the adjusted index depending on the starting day in the calendar. 
                     * Example, Monday, which is supposed to be 0, becomes 1 if the day starts with Saturday(which is the 0 in this case)),
                     * because Monday becomes the second day in the calendar.
                    * */
                    int adjustedDayIndex;

                    dayIndex = schedulingDM.GetDayIndex(schedulingDM.CurrGroupDefSched.StartTime.DayOfWeek);
                    adjustedDayIndex = (dayIndex + (Constants.DAYS_IN_DEF_WEEK - startOfTheWeekDayIndex)) % Constants.DAYS_IN_DEF_WEEK;

                    int totalMinutes = (int) schedulingDM.CurrGroupDefSched.EndTime.TimeOfDay.Subtract(schedulingDM.CurrGroupDefSched.StartTime.TimeOfDay).TotalMinutes;

                    DrawTimePeriod(g, Color.Tomato, panelRectangle, adjustedDayIndex, schedulingDM.CurrGroupDefSched, totalMinutes);
                }
            }
        }

        private void DrawFreeTimes(Graphics g, Rectangle panelRectangle)
        {
            int size;
            List<TimePeriod> currDay;
            DateTime currDateTime;
            int totalMinutes;
            for (int i = 0; i < Constants.DAYS_IN_DEF_WEEK; i++)
            {
                currDateTime = Convert.ToDateTime(labelDates[i].Text);
                currDay = schedulingDM.SelectedGroupFreeTimes[schedulingDM.GetDayIndex(currDateTime.DayOfWeek)];
                size = currDay.Count;
                
                for (int j = 0; j < size; j++)
                {
                    totalMinutes = (int) currDay[j].EndTime.TimeOfDay.Subtract(currDay[j].StartTime.TimeOfDay).TotalMinutes;
                    DrawTimePeriod(g, Color.LightGreen, panelRectangle, i, currDay[j], totalMinutes);
                }
            }
        }

        //Does the actual drawing of those boxes that appear on-screen.
        private void DrawTimePeriod(Graphics g, Color color, Rectangle panelRectangle, int dayIndex, TimePeriod timePeriod, int totalMinutes)
        {
            int leftX = panelRectangle.Left;
            int topY = panelRectangle.Top;

            DateTime earliestTime = new DateTime(timePeriod.StartTime.Year, timePeriod.StartTime.Month, timePeriod.StartTime.Day, Constants.START_HOUR, Constants.START_MIN, 0);

            double yCoord = panelRectangle.Height * (timePeriod.StartTime.TimeOfDay.Subtract(earliestTime.TimeOfDay).TotalMinutes / totalMinsInDay);
            double schedHeight = panelRectangle.Height * (timePeriod.EndTime.TimeOfDay.Subtract(timePeriod.StartTime.TimeOfDay).TotalMinutes / totalMinsInDay);

            int margin = 2;

            Font font1 = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Point);
            Rectangle rect = new Rectangle(leftX + dayIndex * dayWidth + margin, (int)(topY + yCoord), dayWidth - margin * 2, (int)schedHeight);
            g.FillRectangle(new SolidBrush(color), rect);
            if (totalMinutes >= Constants.MIN_DURATION_MINS)
                g.DrawString(timePeriod.ToString(), font1, new SolidBrush(Color.Black), rect, new StringFormat());
        }

        //Draws the horizontal lines in the calendar.
        private void DrawCalendarDivisions()
        {
            Brush aSolidBrush = new SolidBrush(Color.Brown);  //Creates a black solid brush for the pen  
            Pen aSolidPen = new Pen(aSolidBrush);  //Assigns the SolidBrush to the Pen  
            Graphics graphics = panelCalendar.CreateGraphics();
            aSolidPen.DashStyle = DashStyle.Dash;

            int numHours = Constants.LIMIT_HOUR - Constants.START_HOUR;
            Rectangle displayRect = panelCalendar.DisplayRectangle;
            int hourHeight = (int)Math.Round(displayRect.Height * (60 / totalMinsInDay));

            int yCoord;

            for (int i = 1; i < numHours; i++)
            {
                yCoord = displayRect.Top + i * hourHeight;
                graphics.DrawLine(aSolidPen, new Point(displayRect.Left, yCoord), new Point(displayRect.Right, yCoord));
            }


        }

        /****** END: Drawing Methods For The Calendar*******/
        
        /****** START: OTHER METHODS******/
        
        //Changes the selectedGroupID to the new ID given in the parameter, then refreshes the list of free times in schedulingDM.
        private void ChangeSelectedGroup(String newThesisGroupID)
        {
            currGroupID = newThesisGroupID;
            if (newThesisGroupID.Equals(""))
            {
                labelGroupInfo.Text = "";
                labelDefDuration.Text = "";
                HideGroupBox();
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowGroupBox();
                labelGroupInfo.Text = "Selected Group:    " + schedulingDM.GetGroupInfo(currGroupID) + Environment.NewLine + "Panelists:                " + schedulingDM.GetPanelists(currGroupID);
                
                titleTextBox.Text = schedulingDM.GetGroupInfo(currGroupID).Split(':')[1];
                courseSectionTextBox.Text = schedulingDM.GetGroupInfo(currGroupID).Split(':')[0];
                
               
                String course = courseSectionTextBox.Text.Split(' ')[1];
                if (course.Equals("THSST-1"))
                    labelDefDuration.Text = "THSST-1 Defense Duration: " + (Constants.THSST1_DEFDURATION_MINS / 60) + " hour.";
                else if (course.Equals("THSST-3"))
                    labelDefDuration.Text = "THSST-3 Defense Duration: " + (Constants.THSST3_DEFDURATION_MINS / 60) + " hours.";
               
                /*The difference between this defenseSchedule and the one in schedulingDM (currGroupDefSched)
                 * is that currGroupDefSched only refers to the defense schedule that fits within the current
                 * calendar.
                 */
                DefenseSchedule defenseSchedule = schedulingDM.GetDefSched(currGroupID, currDefenseType);
                ChangeGroupBox(defenseSchedule);
            }
            schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID,currDefenseType);
            schedulingDM.RefreshGroupDefSched(startOfTheWeek, endOfTheWeek, currGroupID, currDefenseType);
            Cursor.Current = Cursors.Arrow;
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
                }
                else// if (comboBoxView.SelectedIndex == VIEW_INDEX_ISOLATED) 
                {
                    currTreeView = treeViewIsolatedGroups;
                }
           
                currTreeView.BeginUpdate();
                if (currTreeView.Nodes.Count > 2) // If Cluster View
                {
                    bool allChildrenAreMarked;
                    foreach (TreeNode panelist in currTreeView.Nodes)
                    {
                        allChildrenAreMarked = true; 
                    
                        foreach (TreeNode group in panelist.Nodes)
                        {
                            isCheckingInProgram = true;
                            if (schedulingDM.ScheduledGroupIDs.Contains(group.Name))
                                group.Checked = true;
                            else
                            {
                                group.Checked = false;
                                allChildrenAreMarked = false;
                            }
                        }
                        isCheckingInProgram = true;
                        if (allChildrenAreMarked)
                            panelist.Checked = true;
                        else
                            panelist.Checked = false;
                    }
                }
                else 
                {
                    bool allChildrenAreMarked; 
                    foreach (TreeNode course in currTreeView.Nodes)
                    {
                        allChildrenAreMarked = true;
                        foreach (TreeNode group in course.Nodes)
                        {
                            isCheckingInProgram = true;
                            if (schedulingDM.ScheduledGroupIDs.Contains(group.Name))
                                group.Checked = true;
                            else
                            {
                                group.Checked = false;
                                allChildrenAreMarked = false;
                            }
                        }
                        isCheckingInProgram = true;
                        if (allChildrenAreMarked)
                            course.Checked = true;
                        else
                            course.Checked = false;
                    }
                }
              
                currTreeView.EndUpdate();
                currTreeView.Refresh();
            }
        }
        
        /****** END:   OTHER METHODS******/        
    }
}