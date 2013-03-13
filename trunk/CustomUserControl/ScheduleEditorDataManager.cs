using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    public class ScheduleEditorDataManager
    {
        const int DEFWEEK_DAYS = 6;

        private DBce dbHandler;
        private List<ClassTimePeriod> classSchedList;
        private List<Event> eventList;

        private String textClassScheds;
        private String textEvents;

        public String TextClassScheds { get { return textClassScheds; } }
        public String TextEvents { get { return textEvents; } }

        public ScheduleEditorDataManager()
        {
            dbHandler = new DBce();
            textClassScheds = "";
            textEvents = "";
            classSchedList = new List<ClassTimePeriod>();
            eventList = new List<Event>();
        }

        //STUDENTS
        public void UpdateStudentList(TreeNodeCollection tree)
        {
            UpdateTreeView(tree, "studentID", "student");
        }
       
        public void RefreshStudentClassScheds(String studentID) 
        {
            textClassScheds = "********CLASS SCHEDULES********\n";

            String query = "SELECT timeslotID from studentSchedule where studentID = '" + studentID + "';";
            List<String> timeSlots = dbHandler.Select(query, 1)[0];
            if (timeSlots.Count == 0)
            {
                textClassScheds += "\n No class schedules for this student.";
                return;
            }

            
            query = "SELECT timeslotID, section, courseName, day, startTime, endTime FROM timeslot WHERE ";
            for (int i = 0; i < timeSlots.Count; i++) 
            {
                query += " timeslotID = " + timeSlots.ElementAt(i)+" ";
                if (i == timeSlots.Count - 1)
                    query += " ORDER BY startTime;";
                else
                    query += " OR "; 
            }

          
            List<ClassTimePeriod>[] schedules = new List<ClassTimePeriod>[DEFWEEK_DAYS];
            for(int i=0;i<DEFWEEK_DAYS;i++)
            {
                schedules[i] = new List<ClassTimePeriod>();
            }

            List<String>[] timeSlotTable = dbHandler.Select(query, 6);
            int dayIndex;

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
                dayIndex = DateTimeHelper.ConvertToInt(day);

                schedules[dayIndex].Add(new ClassTimePeriod(id, section, course, day, startTime, endTime));
            }

            int j;
            for (int i = 0; i < DEFWEEK_DAYS; i++) 
            {
                for (j = 0; j < schedules[i].Count; j++) 
                {
                    textClassScheds += schedules[i][j].ToString() + "\n";
                }
                if(j>0)
                    textClassScheds += "\n";
            }

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

        //Actual ALGO for both
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
            textClassScheds = "***********CLASS SCHEDULES***********\n";

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
                textClassScheds += "\n No class schedules for this student.";
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


            List<ClassTimePeriod>[] schedules = new List<ClassTimePeriod>[DEFWEEK_DAYS];
            for (int i = 0; i < DEFWEEK_DAYS; i++)
            {
                schedules[i] = new List<ClassTimePeriod>();
            }

            List<String>[] timeSlotTable = dbHandler.Select(query, 6);
            int dayIndex;

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
                dayIndex = DateTimeHelper.ConvertToInt(day);

                schedules[dayIndex].Add(new ClassTimePeriod(id, section, course, day, startTime, endTime));
            }

            int j;
            for (int i = 0; i < DEFWEEK_DAYS; i++)
            {
                for (j = 0; j < schedules[i].Count; j++)
                {
                    textClassScheds += schedules[i][j].ToString() + "\n";
                }
                if (j > 0)
                    textClassScheds += "\n";
            }
        }

        private void RefreshEvents(String ID, String columnName, String tableName ) 
        {
            textEvents = "***********EVENTS***********\n\n";
            eventList.Clear();

            String query = "SELECT e.eventID, name, eventStart, eventEnd from Event e, "+tableName+" WHERE "+columnName+" = '" + ID + "' ORDER BY eventStart, eventEnd;";
            List<String>[] eventTable = dbHandler.Select(query, 4);

            int id;
            String name;
            DateTime eventStart;
            DateTime eventEnd;
            Event currEvent;

            for (int i = 0; i < eventTable[0].Count; i++)
            {
                id = Convert.ToInt32(eventTable[0][i]);
                name = eventTable[1][i];
                eventStart = Convert.ToDateTime(eventTable[2][i]);
                eventEnd = Convert.ToDateTime(eventTable[3][i]);
                currEvent = new Event(id, name, eventStart, eventEnd);

                textEvents += currEvent.ToString();
                eventList.Add(currEvent);
            }
        
        }

    }
}
