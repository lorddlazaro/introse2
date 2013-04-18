using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    class ThesisGroupDataManager
    {
        DBce dbHandler;

        public ThesisGroupDataManager()
        {
            dbHandler = new DBce();
        }

        // ran at start of thread; just replaces all NULLs in the eligibleforredefense field with 'false'
        public void FixRedefenseCol() 
        {
            String query = "update thesisgroup set eligibleforredefense = 'false' where eligibleforredefense IS NULL";
            dbHandler.Update(query);
        }

        // given group ID, get title, section, course, startSY, startTerm, eligiblefordefense and eligibleforredefense
        public List<String>[] GetGroupInfo(String thesisGroupID)
        {
            String query = "select title, course, section, startSY, startTerm, eligiblefordefense from thesisgroup where thesisgroupid = " + thesisGroupID + ";";
            return dbHandler.Select(query, 5);
        }
        // check if another thesis group already has this this title
        public Boolean CheckIfTitleAlreadyExists(String thesisGroupID, String title)
        {
            String query = "select count(*) from thesisgroup where title = '" + title + "' and thesisgroupid != '" + thesisGroupID + "';";
            int count = Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));

            return count > 0;
        }

        public void UpdateGroupDetails(String thesisGroupID, String title, String section, String startSY, String course, String startTerm)
        {
            String query = "update thesisgroup set title = '" + title + "', course = '" + course + "', section = '" + section + "', startSY = '" + startSY + "', startTerm = '" + startTerm + "', eligiblefordefense = '" + false + "', eligibleforredefense = '" + false + "' ";
            query += "where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(query);
        }
        public void InsertNewGroup(String title, String course, String section, String startSY, String startTerm)
        {
            String insert = "('" + title + "', '" + course + "', '" + section + "', '" + startSY + "', '" + startTerm + "', '" + false + "', '" + false + "')";
            String query = "insert into thesisgroup (title, course, section, startsy, startterm, eligiblefordefense, eligibleforredefense) values" + insert + ";";
            dbHandler.Insert(query);
        }
        public void DeleteGroup(String thesisGroupID)
        {
            String query;

            query = "delete from panelassignment where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Delete(query);

            query = "delete from defenseschedule where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Delete(query);

            query = "delete from studenteventrecord where studentid in (select studentid from student where thesisgroupid = " + thesisGroupID + ");";
            dbHandler.Delete(query);

            query = "delete from studentschedule where studentid in (select studentid from student where thesisgroupid = " + thesisGroupID + ");";
            dbHandler.Delete(query);

            query = "delete from student where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Delete(query);

            query = "delete from thesisgroup where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Delete(query);
        }
        public String GetGroupIDFromTitle(String title)
        {
            String query = "select thesisgroupid from thesisgroup where title = '" + title + "';";
            return dbHandler.Select(query, 1)[0].ElementAt(0);
        }

        public void DeleteDefenseSchedule(String thesisGroupID)
        {
            String query = "delete from defenseschedule where thesisgroupID = " + thesisGroupID + ";";
            dbHandler.Delete(query);
        }
        public Boolean HasDefenseSchedule(String thesisGroupID)
        {
            String query = "select count(*) from defenseschedule where thesisgroupID = " + thesisGroupID + ";";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0)) > 0;
        }

        // returns a Boolean[2], index 0 contains eligiblefordefense and index 1 contains eligibleforredefense
        public Boolean[] GetEligibilities(String thesisGroupID)
        {
            Boolean[] eligible = new Boolean[2]; // 0 - defense, 1 - redef
            String query = "select eligiblefordefense, eligibleforredefense from thesisgroup where thesisgroupid = " + thesisGroupID + ";";
            List<String>[] result = dbHandler.Select(query, 2);

            eligible[0] = Convert.ToBoolean(dbHandler.Select(query, 2)[0].ElementAt(0));
            eligible[1] = Convert.ToBoolean(dbHandler.Select(query, 2)[1].ElementAt(0));

            return eligible;
        }
        // updates eligiblefordefense/redefense given a defenseType, either "Defense" or "Redefense"
        public void FalseEligible(String thesisGroupID, String defenseType)
        {
            if (defenseType.Equals("Defense"))
            {
                String update = "update thesisgroup set eligiblefordefense = 'false' where thesisgroupid = " + thesisGroupID + ";";
                dbHandler.Update(update);
            }
            else if (defenseType.Equals("Redefense"))
            {
                String update = "update thesisgroup set eligibleforerdefense = 'false' where thesisgroupid = " + thesisGroupID + ";";
                dbHandler.Update(update);
            }
        }
        public void UpdateEligible(String thesisGroupID, String eligiblefordefense, String eligibleforredefense) 
        {
            String query = "update thesisgroup set eligiblefordefense = '" + eligiblefordefense + "', eligibleforredefense = '" + eligibleforredefense + "' where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(query);
        }

        public List<String>[] GetGroupPanelists(String thesisGroupID)
        {
            String query = "select panelistID from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ") order by lastname;";
            return dbHandler.Select(query, 1);
        }
        public List<String>[] GetGroupMembers(String thesisGroupID)
        {
            String query = "select studentID, firstname, lastname, mi from student where thesisgroupid = " + thesisGroupID + ";";
            return dbHandler.Select(query, 4);
        }
        // returns v containing panelistID, firstname, middleinitial, and lastname of the panelists
        public List<String>[] GetGroupPanelistNames(String thesisGroupID)
        {
            String query = "select panelistID, firstname, lastname, MI from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ") order by lastname;";
            return dbHandler.Select(query, 4);
        }
        // used in the swapPanelists method
        public List<String>[] GetPanelistsNotInGroup(String thesisGroupID)
        {
            String query = "select panelistid, firstname, MI, lastname from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ");";
            return dbHandler.Select(query, 4);
        }
        // used for the treeview
        public List<String>[] GetCourses()
        {
            String query = "select distinct course from thesisgroup where course IS NOT NULL and course != 'THSST-2';";
            return dbHandler.Select(query, 1);
        }

        public List<String>[] GetAllPanelists()
        {
            String query = "select panelistID from panelist;";
            return dbHandler.Select(query, 1);
        }
        public List<String>[] GetAllStudents()
        {
            String query = "select studentid from student;";
            return dbHandler.Select(query, 1);
        }

        // students
        public List<String>[] GetStudentInfo(String studentID)
        {
            String query = "select studentid, firstname, mi, lastname from student where studentid = " + studentID + ";";
            return dbHandler.Select(query, 4);
        }
        public void InsertNewStudent(String thesisGroupID, String studentID, String firstName, String MI, String lastName)
        {
            String query = "insert into student values(" + studentID + ", '" + firstName + "', '" + MI + "', '";
            query += lastName + "', " + thesisGroupID + ");";
            dbHandler.Insert(query);
        }
        public void DeleteStudent(String studentID)
        {
            String query;

            query = "delete from studenteventrecord where studentid =" + studentID + ";";
            dbHandler.Delete(query);

            query = "delete from student where studentid = " + studentID + ";";
            dbHandler.Delete(query);
        }
        public void UpdateStudent(String studentID, String firstName, String MI, String lastName)
        {
            String query = "update student set firstname = '" + firstName + "', lastname = '" + lastName + "', MI = '" + MI + "' ";
            query += "where studentid = " + studentID + ";";

            dbHandler.Update(query);
        }

        // panelists
        public List<String>[] GetPanelistInfo(String panelistID)
        {
            String query = "select firstname, MI, lastname from panelist where panelistid = '" + panelistID + "';";
            return dbHandler.Select(query, 3);
        }
        public String GetPanelistName(String panelistID)
        {
            if (panelistID == "")
                return "";

            List<String>[] panelName = GetPanelistInfo(panelistID);
            return panelName[0].ElementAt(0) + " " + panelName[1].ElementAt(0) + ". " + panelName[2].ElementAt(0);
        }
        public String GetPanelistIDFromName(String firstName, String MI, String lastName)
        {
            String query = "select panelistid from panelist where firstname = '" + firstName + "' and MI = '" + MI + "' and lastname = '" + lastName + "';";
            return dbHandler.Select(query, 1)[0].ElementAt(0);
        }
        public String GetPanelistIDFromName(String fullName)
        {
            String[] name = fullName.Split(' ');

            int middleIndex = 0;
            while (name[middleIndex].Length != 2)
                middleIndex++;

            String newFirstName = "";
            String newMI = "";
            String newLastName = "";
            for (int i = 0; i < middleIndex; i++)
            {
                newFirstName += name[i];
                if (i != middleIndex - 1)
                    newFirstName += " ";
            }

            newMI = name[middleIndex];
            newMI = newMI.Substring(0, newMI.Length - 1);
            for (int i = middleIndex + 1; i <= name.GetUpperBound(0); i++)
            {
                newLastName += name[i];
                if (i != name.GetUpperBound(0))
                    newLastName += " ";
            }

            return GetPanelistIDFromName(newFirstName, newMI, newLastName);
        }
        public void InsertNewPanelist(String panelistID, String firstName, String MI, String lastName)
        {
            String query = "insert into panelist values(" + panelistID + ", '" + firstName + "', '" + MI + "', '";
            query += lastName + "');";
            dbHandler.Insert(query);
        }
        public void InsertNewPanelist(String panelistID, String fullName)
        {
            String[] name = fullName.Split(' ');

            int middleIndex = 0;
            while (name[middleIndex].Length != 2)
                middleIndex++;

            String newFirstName = "";
            String newMI = "";
            String newLastName = "";
            for (int i = 0; i < middleIndex; i++)
            {
                newFirstName += name[i];
                if (i != middleIndex - 1)
                    newFirstName += " ";
            }

            newMI = name[middleIndex];
            newMI = newMI.Substring(0, newMI.Length - 1);
            for (int i = middleIndex + 1; i <= name.GetUpperBound(0); i++)
            {
                newLastName += name[i];
                if (i != name.GetUpperBound(0))
                    newLastName += " ";
            }

            InsertNewPanelist(panelistID, newFirstName, newMI, newLastName);
        }
        public void UpdatePanelist(String panelistID, String firstName, String MI, String lastName)
        {
            String query = "update panelist set firstname = '" + firstName + "', lastname = '" + lastName + "', MI = '" + MI + "' ";
            query += "where panelistid = " + panelistID + ";";

            dbHandler.Update(query);
        }
        public void AssignPanelistToGroup(String thesisGroupID, String panelistID)
        {
            String query = "insert into panelassignment values(" + thesisGroupID + ", " + panelistID + ");";
            dbHandler.Insert(query);
        }
        public void RemoveAssignedPanelistFromGroup(String thesisGroupID, String panelistID)
        {
            String query = "delete from panelassignment where thesisgroupid = " + thesisGroupID + " and panelistid = " + panelistID + ";";
            dbHandler.Delete(query);
        }

        // adviseeeer
        public String GetAdviserID(String thesisGroupID)
        {
            String query = "select advisorid from thesisgroup where thesisgroupid = " + thesisGroupID + ";";
            return dbHandler.Select(query, 1)[0].ElementAt(0);
        }
        public void UpdateAdviser(String thesisGroupID, String adviserID)
        {
            String update = "update thesisgroup set advisorID = " + adviserID + " where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(update);
        }
        public void RemoveAdviser(String thesisGroupID)
        {
            String query = "update thesisgroup set advisorID = NULL where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(query);
        }

        // how many panelists/students does the thesis group have?
        public int PanelistCount(String thesisGroupID)
        {
            String query = "select count(*) from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid =  " + thesisGroupID + ");";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }
        public int PanelistNotInGroupCount(String thesisGroupID)
        {
            String query = "select count(*) from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ");";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }
        public int StudentCount(String thesisGroupID)
        {
            String query = "select count(*) from student where thesisgroupid = " + thesisGroupID + ";";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }

        // given a treeview, add groups sorted by section ordered alphabetically
        public void ShowGroups(TreeNodeCollection tree)
        {
            String query = "select distinct course from thesisgroup where course IS NOT NULL;";
            List<String>[] parentList = dbHandler.Select(query, 1);
            //List<String>[] parentInfo;
            List<String>[] childList;
            TreeNode parent;
            TreeNode[] child;
            TreeNodeCollection children;

            for (int i = 0; i < parentList[0].Count; i++)
            {
                query = "select thesisgroupid, title, section from thesisGroup where course = '" + parentList[0].ElementAt(i) + "' and course IS NOT NULL order by title;";
                childList = dbHandler.Select(query, 3);

                parent = new TreeNode();
                child = new TreeNode[childList[0].Count()];
                children = parent.Nodes;

                parent.Name = parent.Text = parentList[0].ElementAt(i);

                for (int j = 0; j < childList[0].Count(); j++)
                {
                    child[j] = new TreeNode();
                    child[j].Name = childList[0].ElementAt(j);
                    child[j].Text = childList[1].ElementAt(j) + " - " + childList[2].ElementAt(j);
                    children.Add(child[j]);
                }
                tree.Add(parent);
            }
        }
    }
}
