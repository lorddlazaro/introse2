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

        public FreeTimeViewer()
        {
            InitializeComponent();

            dayWidth = panelCalendar.DisplayRectangle.Width / Constants.DAYS_IN_DEF_WEEK;
            totalMinsInDay = Convert.ToDateTime(Constants.LIMIT_HOUR+":"+Constants.LIMIT_MIN).Subtract(Convert.ToDateTime(Constants.START_HOUR+":"+Constants.START_MIN)).TotalMinutes;

            currPanelistID = "";
            currGroupID = "";

            labelDates = new List<Label>();
            labelDates.Add(labelDate1);
            labelDates.Add(labelDate2);
            labelDates.Add(labelDate3);
            labelDates.Add(labelDate4);
            labelDates.Add(labelDate5);
            labelDates.Add(labelDate6);

            datePicker_ValueChanged(new Object(), new EventArgs());

            schedulingDM = new SchedulingDataManager();
            treeViewClusters.BeginUpdate();
            schedulingDM.AddPanelistsToTree(treeViewClusters.Nodes);
            treeViewClusters.EndUpdate();
            treeViewClusters.ExpandAll();
            treeViewClusters.Focus();
        }


        /****** START: Drawing Methods*******/
        private void panelCalendar_Paint(object sender, PaintEventArgs e)
        {
            DrawClusterDefScheds(e.Graphics, panelCalendar.DisplayRectangle);
            DrawFreeTimes(e.Graphics, panelCalendar.DisplayRectangle);
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

                DrawTimePeriod(g, Color.Red, panelRectangle, adjustedDayIndex, curr );
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
                Console.WriteLine("["+i+"] has "+size+" elements.");
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

            /* For Debugging Purposes*/
            Console.WriteLine(timePeriod.ToString());
            Console.WriteLine((leftX + dayIndex * dayWidth + margin)+", "+((int)(topY + yCoord))+", "+(dayWidth - margin * 2)+", "+schedHeight);
            Console.WriteLine();
            /* For Debugging Purposes*/

            Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            Rectangle rect = new Rectangle(leftX + dayIndex * dayWidth + margin, (int)(topY + yCoord), dayWidth - margin * 2, (int)schedHeight);
            g.FillRectangle(new SolidBrush(color), rect);
            g.DrawString(timePeriod.ToString(),font1, new SolidBrush(Color.Black),  rect, new StringFormat());
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
                MessageBox.Show("No school on Sundays.");
            }

            DateTime currDate = startOfTheWeek;
            
            int i;
            for (i = 0; i < labelDates.Count; i++)
            {
                labelDates[i].TextAlign = ContentAlignment.MiddleCenter;
                labelDates[i].Text = currDate.DayOfWeek + "\n" + currDate.ToString("d");

                currDate = currDate.AddDays(1);
                if (currDate.DayOfWeek.Equals(System.DayOfWeek.Sunday))
                    currDate = currDate.AddDays(1);
            }

            endOfTheWeek = Convert.ToDateTime(labelDates[i - 1].Text);

            if (!currPanelistID.Equals(""))
                schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
            if (!currGroupID.Equals(""))
                schedulingDM.RefreshSelectedGroupFreeTimes(startOfTheWeek, endOfTheWeek, currGroupID);
            
            panelCalendar.Refresh();
        }

        private void treeViewClusters_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                int numTasks = 3;
                int progressBarIncrement = progressBar1.Maximum / numTasks;

                //Task1: Refresh Cluster Defense Schedules
                currPanelistID = e.Node.Name;
                schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
                UpdateProgressBar(progressBar1, progressBarIncrement);

                /* For scheduling defenses
                if (form2 != null)
                    try { form2.Dispose(); }
                    catch (Exception ex) { }
                form2 = new DefenseScheduleForm(this, "");
                 * */

                //Task 2: Deselect the currently selected thesis group if any.
                if(!currGroupID.Equals(""))
                    ChangeSelectedGroup(startOfTheWeek, endOfTheWeek, "");
                UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 3: Refresh 
                if (schedulingDM.ClusterDefScheds.Count > 0)
                    panelCalendar.Refresh();
                UpdateProgressBar(progressBar1, progressBarIncrement);

                UpdateProgressBar(progressBar1, progressBar1.Maximum); //Just to make the progress bar reach its maximum.
            }
            else if (e.Node.Level == 1)
            {
                int numTasks = 3;
                int progressBarIncrement = progressBar1.Maximum / numTasks;

                //Task 1: Change panelists if user clicked on another cluster.
                if (!e.Node.Parent.Name.Equals(currPanelistID))
                {
                    currPanelistID = e.Node.Parent.Name;
                    schedulingDM.RefreshClusterDefSchedules(startOfTheWeek, endOfTheWeek, currPanelistID);
                }
                UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 2: Change selected group if user clicked on a different one.
                if (!currGroupID.Equals(e.Node.Name))
                {
                    ChangeSelectedGroup(startOfTheWeek, endOfTheWeek, e.Node.Name);
                }
                UpdateProgressBar(progressBar1, progressBarIncrement);

                //Task 3: Refresh
                panelCalendar.Refresh();
                UpdateProgressBar(progressBar1, progressBarIncrement);

                UpdateProgressBar(progressBar1, progressBar1.Maximum); //Just to make the progress bar reach its maximum.
            }
        }

        //Updates the progress bar until its maximum. The bar is reset to zero only during the next time it is made to update.
        private void UpdateProgressBar(ProgressBar progressBar1, int increment) 
        {
            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            else if (progressBar1.Value + increment < progressBar1.Maximum)
                progressBar1.Value += increment;
            else
                progressBar1.Value = progressBar1.Maximum;

            progressBar1.Refresh();
        }
        
        /****** END: EVENT LISTENERS*******/


        /******* OTHER METHODS******/

        //Changes the selectedGroupID to the new ID given in the parameter, then refreshes the list of free times in schedulingDM.
        public void ChangeSelectedGroup(DateTime start, DateTime end, String newThesisGroupID)
        {
            currGroupID = newThesisGroupID;
            if (newThesisGroupID.Equals(""))
                labelSelectedGroup.Text = "";
            else
                labelSelectedGroup.Text = "Selected Group: " + schedulingDM.GetGroupInfo(currGroupID);
            schedulingDM.RefreshSelectedGroupFreeTimes(start, end, currGroupID);

            /*For debugging purposes*/
            for (int currDay = 0; currDay < 6; currDay++)
            {
                Console.WriteLine("Day: " + currDay);
                for (int i = 0; i < schedulingDM.SelectedGroupFreeTimes[currDay].Count; i++)
                    Console.WriteLine(schedulingDM.SelectedGroupFreeTimes[currDay].ElementAt(i));
            }
            /*For debugging purposes*/
        }

    }
}
