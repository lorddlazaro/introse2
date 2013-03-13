using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    public class SchedulingDataManager
    {
        private const int DEFWEEK_DAYS = 6;
        private const int THSST1_DEF_DURATION_MINS = 60;
        private const int THSST3_DEF_DURATION_MINS = 120;
        private const int START_HOUR = 8;
        private const int START_MIN = 0;
        private const int LIMIT_HOUR = 21;
        private const int LIMIT_MIN = 0;

        private DBce dbHandler;

        /*This will be used to draw the rectangles representing the defense schedules of
         * the currently selected thesis group. 
         * */
        private List<DefenseSchedule> clusterDefScheds;

        //This will be used to store the free times of the selected thesis group
        private List<TimePeriod>[] selectedGroupFreeTimes;

        //This will be used to draw the rectangles representing the free slots of the selected thesis group.
        //private List<TimePeriod> selectedGroupFreeSlots;

        //Getters

        public List<DefenseSchedule> ClusterDefScheds { get { return clusterDefScheds; } }
        public List<TimePeriod>[] SelectedGroupFreeTimes { get { return selectedGroupFreeTimes; } }

        public SchedulingDataManager()
        {
            clusterDefScheds = new List<DefenseSchedule>();
            selectedGroupFreeTimes = new List<TimePeriod>[DEFWEEK_DAYS];
            InitListTimePeriodArray(selectedGroupFreeTimes);
            dbHandler = new DBce();
        }

        /* This method will be called by the GUI to add multigrouped panelists to the tree.
         * */
        public void AddPanelistsToTree(TreeNodeCollection tree)
        {
            String query = "select panelistID from panelassignment group by panelistID having count(*) > 1;";
            List<String>[] parentList = dbHandler.Select(query, 1);
            List<String>[] parentInfo;
            List<String>[] childList;
            TreeNode parent;
            TreeNode[] child;
            TreeNodeCollection children;

            for (int i = 0; i < parentList[0].Count(); i++)
            {
                query = "Select firstName, MI, lastName from panelist where panelistid = " + parentList[0].ElementAt(i) + ";";
                parentInfo = dbHandler.Select(query, 3);

                //query = "Select t.thesisgroupID,t.title from thesisgroup t, panelassignment p where t.thesisgroupid = p.thesisgroupid and p.panelistID =" + parentList[0].ElementAt(i) + ";";
                query = "Select thesisgroupID, title from thesisgroup where thesisgroupid in( select thesisgroupid from panelassignment where panelistID =" + parentList[0].ElementAt(i) + ");";
                childList = dbHandler.Select(query, 2);

                parent = new TreeNode();
                child = new TreeNode[childList[0].Count()];
                children = parent.Nodes;

                parent.Name = parentList[0].ElementAt(i);
                parent.Text = parentInfo[0].ElementAt(0) + " " + parentInfo[1].ElementAt(0) + " " + parentInfo[2].ElementAt(0);

                for (int j = 0; j < childList[0].Count(); j++)
                {
                    child[j] = new TreeNode();
                    child[j].Name = childList[0].ElementAt(j);
                    child[j].Text = childList[1].ElementAt(j);
                    children.Add(child[j]);

                }
                tree.Add(parent);
            }
        }

        public void AddIsolatedGroupsToTree(TreeNodeCollection tree)
        {
            String query = "select thesisgroupID,title from thesisgroup where thesisgroupID not in (select thesisgroupID from panelassignment where panelistID in (select panelistID from panelassignment group by panelistID having count(*) > 1));";
            List<String>[] list = dbHandler.Select(query, 2);
            TreeNode node;
            for (int i = 0; i < list[0].Count(); i++)
            {
                node = new TreeNode();

                node.Name = list[0].ElementAt(i);
                node.Text = list[1].ElementAt(i);

                tree.Add(node);
            }
        }

        /*The following two methods are the important ones for initializing the lists 
         * to be used for drawing the available times and defense schedules.
         * */

        /* This method will be called by the UI to refresh clusterDefSchedules when a cluster is selected.
         * Note: this was previously named initDefenseSchedules()
         * */
        public void RefreshClusterDefSchedules(DateTime startDate, DateTime endDate, String panelistID)
        {
            clusterDefScheds.Clear();
            if (!panelistID.Equals(""))
            {
                List<String> groupIDs = new List<String>();
                String query = "select thesisGroupID from panelassignment where panelistID = '" + panelistID + "';";

                groupIDs = (dbHandler.Select(query, 1))[0];

                int size = groupIDs.Count;
                DefenseSchedule defSched;

                for (int i = 0; i < size; i++)
                {
                    defSched = GetDefSched(startDate, endDate, groupIDs.ElementAt(i));
                    if (defSched != null)
                        clusterDefScheds.Add(defSched);
                }
            }   
        }

        /* This method returns a DefenseSchedule object within the specified startDate and endDDate 
         * for the specified thesis group. If there is none, the method returns null.
         */
        private DefenseSchedule GetDefSched(DateTime startDate, DateTime endDate, String thesisGroupID)
        {
            String query = "SELECT defenseDateTime, place FROM defenseSchedule WHERE thesisGroupID = " + thesisGroupID + " AND defenseDateTime >='" + startDate.Date + "' AND defenseDateTime <='" + endDate.AddDays(1).Date + "';";
           
            List<String>[] columns = dbHandler.Select(query, 2);

            if (columns[0].Count == 0)//If the query result is an empty set.
                return null;

            int defDuration = GetMinsDuration(thesisGroupID);
            if (defDuration == -1) //If course is neither THSST-1 nor THSST-3. There must be some input error.
                return null;

            DateTime startTime = Convert.ToDateTime(columns[0].ElementAt(0));
            DateTime endTime = startTime.AddMinutes(defDuration);
            String place = columns[1].ElementAt(0);
            String groupTitle;
            query = "SELECT title from thesisGroup WHERE thesisGroupID = " + thesisGroupID + ";";
            groupTitle = dbHandler.Select(query, 1)[0].ElementAt(0);

            return new DefenseSchedule(startTime, endTime, place, groupTitle);
        }

        /* This method returns the defense schedule duration in minutes depending on the thesis group's course (THSST-1 or THSST-3)
         * This method is used in GetDefSched().
         */
        private int GetMinsDuration(String thesisGroupID)
        {
            String query = "SELECT course from thesisGroup where thesisGroupID = " + thesisGroupID + ";";
            String course = dbHandler.Select(query, 1)[0].ElementAt(0);
            if (course.Equals("THSST-1"))
                return THSST1_DEF_DURATION_MINS;
            else if (course.Equals("THSST-3"))
                return THSST3_DEF_DURATION_MINS;

            return -1;
        }

        private void InitListTimePeriodArray(List<TimePeriod>[] list)
        {
            for (int i = 0; i < DEFWEEK_DAYS; i++)
                list[i] = new List<TimePeriod>();
        }

        /* This method will be called by the UI to refresh selectedGroupFreeSlots when
         * a thesis group is selected, whether in tree view (for clusters) or listbox (for isolated groups).
         * The parameters are still to be changed.
         * */
        public void RefreshSelectedGroupFreeTimes(DateTime startDate, DateTime endDate, String thesisGroupID)
        {
            if (thesisGroupID.Equals(""))
            {
                for (int i = 0; i < selectedGroupFreeTimes.Length; i++)
                    selectedGroupFreeTimes[i].Clear();
                return;
            }

            List<TimePeriod>[] days = new List<TimePeriod>[DEFWEEK_DAYS];
            InitListTimePeriodArray(days);
            AddBusyTimePeriods(thesisGroupID, startDate, endDate, days);

            for (int i = 0; i < DEFWEEK_DAYS; i++)
            {
                //Console.WriteLine("Day " + i);
                List<TimePeriod> mergedPeriods = new List<TimePeriod>();
                List<TimePeriod> currDay = days[i];
                int size = currDay.Count;
                //Console.WriteLine("Before merging: Day" + i);
                //DateTimeHelper.PrintTimePeriods(currDay);
                if (size > 0)
                {
                    //Console.WriteLine("Going to merge day:" + i);
                    TimePeriod curr = currDay.ElementAt(0);
                    bool isNewSet = false;
                    for (int j = 1; j < size; j++)
                    {
                        //Console.Write("j: "+j+" ==== ");

                        if (curr.IntersectsInclusive(currDay.ElementAt(j)))
                        {
                            //Console.WriteLine(curr+" intersects with " + currDay.ElementAt(j));
                            curr = MergeTimePeriods(curr, currDay.ElementAt(j));
                        }
                        else
                        {
                            //Console.WriteLine("here with "+curr);
                            mergedPeriods.Add(curr);
                            curr = currDay.ElementAt(j);
                        }

                    }

                    if (!isNewSet)
                        mergedPeriods.Add(curr);

                    //DateTimeHelper.PrintTimePeriods(mergedPeriods);
                }

                //Console.WriteLine("After merging: Day" + i);
                //DateTimeHelper.PrintTimePeriods(mergedPeriods);

                DateTime currStart = new DateTime(2013, 1, 1, START_HOUR, START_MIN, 0);
                DateTime currEnd;
                size = mergedPeriods.Count;
                List<TimePeriod> currDayFreeSlots = new List<TimePeriod>();
                for (int j = 0; j < size; j++)
                {
                    currEnd = mergedPeriods.ElementAt(j).StartTime;

                    //if (currStart != currEnd in terms of time only).
                    if (currStart.TimeOfDay.CompareTo(currEnd.TimeOfDay) != 0)
                        currDayFreeSlots.Add(new TimePeriod(currStart, currEnd));

                    currStart = mergedPeriods.ElementAt(j).EndTime;
                }

                //The following makes sure the free times end at 9pm.


                if (currStart.Hour < LIMIT_HOUR || currStart.Hour == LIMIT_HOUR && currStart.Minute < LIMIT_MIN)
                {
                    currDayFreeSlots.Add(new TimePeriod(currStart, new DateTime(currStart.Year, currStart.Month, currStart.Day, LIMIT_HOUR, LIMIT_MIN, 0)));
                }

                selectedGroupFreeTimes[i] = currDayFreeSlots;
            }
        }

        //This method adds the busy time periods to the List<TimePeriod>[] representing the days in a def week.
        private void AddBusyTimePeriods(String thesisGroupID, DateTime startDate, DateTime endDate, List<TimePeriod>[] days)
        {
            List<String> timeSlotIDs = new List<String>(); //Stored as string instead of int because when included in the select statement, it will become a string anyway.
            List<String> eventIDs = new List<String>();
            List<String>studentIDs;
            List<String> panelistIDs;

            String query;
            int size;

            /*Start: 
             * Initialize the distinct timeslotIDs of students' class schedules.
             * */

            query = "SELECT studentID FROM Student WHERE thesisGroupID = " + thesisGroupID + ";";
            studentIDs = dbHandler.Select(query, 1)[0];
            size = studentIDs.Count;
            
            if (size == 0)
                return;

            query = "SELECT distinct timeslotID FROM  studentSchedule  WHERE ";
            for (int i = 0; i < size; i++) 
            {
                query += " studentID = '" + studentIDs.ElementAt(i) + "'";

                if (i < size - 1)
                    query += " OR ";
                else
                    query += ";";
            }
       
            
            AddUniqueTimeSlots(timeSlotIDs, dbHandler.Select(query, 1)[0]);

            query = "SELECT distinct eventID FROM studentEventRecord WHERE ";
            for (int i = 0; i < size; i++)
            {
                query += " studentID = '" + studentIDs.ElementAt(i) + "'";

                if (i < size - 1)
                    query += " OR ";
                else
                    query += ";";
            }
            Console.WriteLine(query);//debugging
            AddUniqueTimeSlots(eventIDs, dbHandler.Select(query, 1)[0]);

            /*End*/

            /*Start: Initialize panelists' class shcedules' timeslotIDs*/ 

            query = "SELECT panelistID FROM PanelAssignment WHERE thesisGroupID = " + thesisGroupID + ";";
            panelistIDs = dbHandler.Select(query, 1)[0];
            size = panelistIDs.Count;
            if (size == 0)
                return;

            query = "SELECT distinct timeslotID FROM timeslot WHERE ";

            for (int i = 0; i < size; i++) 
            {
                query += " panelistID = '" + panelistIDs.ElementAt(i) + "' ";

                if (i < size - 1)
                    query += " OR ";
                else
                    query += ";";
            }

            AddUniqueTimeSlots(timeSlotIDs, dbHandler.Select(query, 1)[0]);

            query = "SELECT distinct eventID from PanelistEventRecord WHERE ";

            for (int i = 0; i < size; i++) 
            {
                query += " panelistID = '" + panelistIDs.ElementAt(i) + "' ";

                if (i < size - 1)
                    query += " OR ";
                else
                    query += ";";
            }
            AddUniqueTimeSlots(eventIDs, dbHandler.Select(query, 1)[0]);
            /* End */

            /*Start: 
             * 
             * */
            List<TimePeriod>[] classSlots = GetUniqueClassTimeSlots(timeSlotIDs);
            List<TimePeriod>[] eventSlots = GetUniqueEventSlots(eventIDs, startDate, endDate);
            List<TimePeriod>[] defSlots = GetUniqueDefSlots(panelistIDs);

            for (int i = 0; i < 6; i++)
            {
                if (classSlots[i] != null)
                    days[i].AddRange(classSlots[i]);

                if (eventSlots[i] != null)
                    days[i].AddRange(eventSlots[i]);

                if (defSlots[i] != null)
                    days[i].AddRange(defSlots[i]);

                days[i].Sort();
                //Console.WriteLine("after sorting: " + i);
                //DateTimeHelper.PrintTimePeriods(days[i]);
            }
            /* End */
        }

   
        //This method merges two intersecting timeperiods into one timeperiod to represent both.
        private TimePeriod MergeTimePeriods(TimePeriod tp1, TimePeriod tp2)
        {
            DateTime minStart;
            DateTime maxEnd;

            if (tp1.StartTime.TimeOfDay.CompareTo(tp2.StartTime.TimeOfDay) <= 0)
                //if (DateTimeHelper.CompareTimes(tp1.StartTime, tp2.StartTime) <= 0)
                minStart = tp1.StartTime;
            else
                minStart = tp2.StartTime;

            if (tp1.EndTime.TimeOfDay.CompareTo(tp2.EndTime.TimeOfDay) >= 0)
                //if (DateTimeHelper.CompareTimes(tp1.EndTime, tp2.EndTime) >= 0)
                maxEnd = tp1.EndTime;
            else
                maxEnd = tp2.EndTime;

            return new TimePeriod(minStart, maxEnd);
        }

        private List<TimePeriod>[] GetUniqueEventSlots(List<String> eventIDs, DateTime startDate, DateTime endDate)
        {
            int size = eventIDs.Count;
            String query;
            List<String>[] columns;

            List<TimePeriod>[] busySlots = new List<TimePeriod>[DEFWEEK_DAYS];
            InitListTimePeriodArray(busySlots);

            int currDay;
            TimePeriod newTimePeriod;

            DateTime earliestTime = new DateTime(2013, 1, 1, START_HOUR, START_MIN, 0);
            DateTime latestTime = new DateTime(2013, 1, 1, LIMIT_HOUR, LIMIT_MIN, 0);
            /*For Debugging Purposes
            Console.WriteLine("EventIDs size:"+size);
            /*For Debugging Purposes*/
            for (int i = 0; i < size; i++)
            {
                query = "SELECT eventStart, eventEnd FROM Event WHERE eventID = " + eventIDs.ElementAt(i) + ";";
                columns = dbHandler.Select(query, 2);
                DateTime eventStart = Convert.ToDateTime(columns[0].ElementAt(0));
                DateTime eventEnd = Convert.ToDateTime(columns[1].ElementAt(0));
               
                if (DateTimeHelper.DatesIntersectInclusive(eventStart, eventEnd, startDate, endDate)) 
                {
                    for (DateTime curr = eventStart; curr.Date.CompareTo(eventEnd.Date) <= 0; curr = curr.AddDays(1))
                    {
                        currDay = (int)curr.DayOfWeek - 1;

                        if (DateTimeHelper.IsBetweenInclusive(curr, startDate, endDate) && currDay >= 0) //If not sunday, because sunday is never included.
                        {
                            newTimePeriod = null;

                            int comparisonToStart = curr.Date.CompareTo(eventStart.Date);
                            int comparisonToEnd = curr.Date.CompareTo(eventEnd.Date);

                            if (comparisonToStart == 0 && comparisonToEnd == 0)
                                newTimePeriod = new TimePeriod(eventStart, eventEnd);
                            else if (comparisonToStart == 0)
                            {
                                if (eventStart.TimeOfDay.CompareTo(latestTime.TimeOfDay) < 0)
                                    newTimePeriod = new TimePeriod(eventStart, latestTime);
                            }
                            else if (comparisonToEnd == 0)
                            {
                                int comparisonToLatest = eventEnd.TimeOfDay.CompareTo(latestTime.TimeOfDay);
                                int comparisonToEarliest = eventEnd.TimeOfDay.CompareTo(earliestTime.TimeOfDay);
                                if (comparisonToLatest < 0 && comparisonToEarliest > 0)
                                    newTimePeriod = new TimePeriod(earliestTime, eventEnd);
                                else if (comparisonToLatest >= 0)
                                    newTimePeriod = new TimePeriod(earliestTime, latestTime);
                            }
                            else
                                newTimePeriod = new TimePeriod(earliestTime, latestTime);

                            if (newTimePeriod != null)
                            {
                                if (!busySlots[currDay].Contains(newTimePeriod))
                                    busySlots[currDay].Add(newTimePeriod);
                            }
                        }
                    }
                }
            }

            /*For debugging purposes
            Console.WriteLine("Event busy slots:");
            for (int i = 0; i < DEFWEEK_DAYS; i++) 
            {
                Console.WriteLine("Day:" + i);
                DateTimeHelper.PrintTimePeriods(busySlots[i]);
            }
            Console.WriteLine();
            /*For debugging purposes*/

            return busySlots;
        }

        private List<TimePeriod>[] GetUniqueClassTimeSlots(List<String> timeSlotIDs)
        {
            String query;
            List<String>[] columns;
            List<TimePeriod>[] busySlots = new List<TimePeriod>[DEFWEEK_DAYS];

            InitListTimePeriodArray(busySlots);

            DateTime startTime;
            DateTime endTime;
            TimePeriod newSlot;
            int currDay;
            int size = timeSlotIDs.Count;
            if (size == 0)
                return busySlots;

            query = "SELECT distinct day, startTime, endtime FROM timeslot WHERE ";

            for (int i = 0; i < size; i++) 
            {
                query += "timeSlotID = " + timeSlotIDs.ElementAt(i)+" ";
                if (i < size - 1)
                    query += " OR ";
                else
                    query += ";";
            }

            columns = dbHandler.Select(query, 3);
            size = columns[0].Count;
            for (int i = 0; i < size; i++) 
            {
                currDay = DateTimeHelper.ConvertToInt(columns[0].ElementAt(i));
                startTime = Convert.ToDateTime(columns[1].ElementAt(i));
                endTime = Convert.ToDateTime(columns[2].ElementAt(i));
                newSlot = new TimePeriod(startTime, endTime);
                if (!busySlots[currDay].Contains(newSlot))
                {
                    /*
                    Console.WriteLine("Added for "+day+": "+newSlot.StartTime+"-"+newSlot.EndTime);
                    Console.WriteLine("The current list");
                    DateTimeHelper.PrintTimePeriods(busyTimeSlots);
                    */
                    busySlots[currDay].Add(newSlot);
                }
            }

            return busySlots;
        }

        private List<TimePeriod>[] GetUniqueDefSlots(List<String> panelistIDs)
        {
            String query = "SELECT defenseDateTime";
            int size = panelistIDs.Count;
            List<String> defDateTimes;
            List<String> courses;
            List<String> groupIDs;
            List<TimePeriod>[] busySlots = new List<TimePeriod>[DEFWEEK_DAYS];
            InitListTimePeriodArray(busySlots);

            if(size == 0)
                return busySlots;

            /*Select all distinct thesis group ID's having the panelists in the list*/
            query = "SELECT distinct thesisGroupID from PanelAssignment WHERE ";
            for (int i = 0; i < size; i++) 
            {
               query+= " panelistId='" + panelistIDs.ElementAt(i) + "' ";
                
                if(i == size-1)
                    query+=";";
                else
                    query+=" OR ";
            }
        
            groupIDs = dbHandler.Select(query, 1)[0];
            size = groupIDs.Count;
            if(size == 0)
                return busySlots;
            /*end*/

            /*Select all distinct defenseId's that these thesis groups have*/

            query = "Select distinct defenseDateTime, course FROM DefenseSchedule ds, ThesisGroup tg WHERE ds.thesisGroupID = tg.thesisGroupID AND ( ";
            for (int j = 0; j < size; j++) 
            {
                query += " tg.thesisGroupID = " + groupIDs.ElementAt(j);

                if (j == groupIDs.Count - 1)
                    query += ");";
                else
                    query += " OR ";
            }
      
            List<String>[] columns = dbHandler.Select(query, 2);
            defDateTimes = columns[0];
            courses = columns[1];

            size = defDateTimes.Count;
            DateTime start;
            DateTime end;
            String course;
            for (int i = 0; i < size; i++) 
            {
                start= Convert.ToDateTime(defDateTimes.ElementAt(i));
                course = courses.ElementAt(i);
                if (course.Equals("THSST-1"))
                    end = start.AddMinutes(THSST1_DEF_DURATION_MINS);
                else
                    end = start.AddMinutes(THSST3_DEF_DURATION_MINS);
                //end = start.AddMinutes(GetMinsDuration(courses.ElementAt(i)));
                if(start.DayOfWeek > 0)
                    busySlots[(int)start.DayOfWeek - 1].Add(new TimePeriod(start, end));
            }

            return busySlots;
        }

        /* This method is called by RefreshSelectedGroupFreeTimes() to add new distinct timeslots to the list. 
         * It is only a support method for RefreshSelectedGroupFreeTimes(). This is used both for class timeslots
         * and event timeslots.
         * */
        private void AddUniqueTimeSlots(List<String> timeslotIDs, List<String> newSlots)
        {
            int numTimeslots = newSlots.Count;
            for (int j = 0; j < numTimeslots; j++)
            {
                if (!timeslotIDs.Contains(newSlots.ElementAt(j))) //potentially not needed since all calls to this pass slots with distinct members
                    timeslotIDs.Add(newSlots.ElementAt(j));
            }
        }

        public String GetGroupInfo(String thesisGroupID) 
        {
            String query = "SELECT section, course, title from ThesisGroup WHERE thesisGroupID = '" + thesisGroupID + "';";
            List<String>[] columns = dbHandler.Select(query, 3);
            if(columns[0].Count > 0)
                return columns[0].ElementAt(0) + "-" + columns[1].ElementAt(0) + ": " + columns[2].ElementAt(0);
            return "";
        }

     

    }
}
