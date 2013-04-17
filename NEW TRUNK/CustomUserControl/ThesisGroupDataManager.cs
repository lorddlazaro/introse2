using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    // DO I EVEN NEED TO DOCUMENT THIS
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

        public void UpdateGroupDetails(String thesisGroupID, String title, String section, String startSY, String course, String startTerm, String eligiblefordefense, String eligibleforredef)
        {
            String query = "update thesisgroup set title = '" + title + "', course = '" + course + "', section = '" + section + "', startSY = '" + startSY + "', startTerm = '" + startTerm + "', eligiblefordefense = '" + eligiblefordefense + "', eligibleforredefense = '" + eligibleforredef + "' ";
            query += "where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(query);
        }
        public void InsertNewGroup(String title, String course, String section, String startSY, String startTerm, String eligiblefordefense, String eligibleforredef)
        {
            String insert = "('" + title + "', '" + course + "', '" + section + "', '" + startSY + "', '" + startTerm + "', '" + eligiblefordefense + "', '" + eligibleforredef + "')";
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
        public void UpdateEligible(String thesisGroupID, String defenseType)
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

        public List<String>[] getGroupPanelists(String thesisGroupID)
        {
            String query = "select panelistID from panelassignment where thesisgroupid = " + thesisGroupID + " order by panelistID;";
            return dbHandler.Select(query, 1);
        }
        public List<String>[] getGroupMembers(String thesisGroupID)
        {
            String query = "select studentID, firstname, lastname, mi from student where thesisgroupid = " + thesisGroupID + ";";
            return dbHandler.Select(query, 4);
        }
        // returns v containing panelistID, firstname, middleinitial, and lastname of the panelists
        public List<String>[] getGroupPanelistNames(String thesisGroupID)
        {
            String query = "select panelistID, firstname, lastname, MI from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ") order by lastname;";
            return dbHandler.Select(query, 4);
        }
        // used in the swapPanelists method
        public List<String>[] getPanelistsNotInGroup(String thesisGroupID)
        {
            String query = "select firstname, MI, lastname from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ");";
            return dbHandler.Select(query, 3);
        }
        // used for the treeview
        public List<String>[] getCourses()
        {
            String query = "select distinct course from thesisgroup where course IS NOT NULL and course != 'THSST-2';";
            return dbHandler.Select(query, 1);
        }

        public List<String>[] getAllPanelists()
        {
            String query = "select panelistID from panelist;";
            return dbHandler.Select(query, 1);
        }
        public List<String>[] getAllStudents()
        {
            String query = "select studentid from student;";
            return dbHandler.Select(query, 1);
        }

        // students
        public List<String>[] getStudentInfo(String studentID)
        {
            String query = "select studentid, firstname, mi, lastname from student where studentid = " + studentID + ";";
            return dbHandler.Select(query, 4);
        }
        public void insertNewStudent(String thesisGroupID, String studentID, String firstName, String MI, String lastName)
        {
            String query = "insert into student values(" + studentID + ", '" + firstName + "', '" + MI + "', '";
            query += lastName + "', " + thesisGroupID + ");";
            dbHandler.Insert(query);
        }
        public void deleteStudent(String studentID, String thesisGroupID)
        {
            String query;

            query = "delete from studenteventrecord where studentid =" + studentID + ";";
            dbHandler.Delete(query);

            query = "delete from student where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Delete(query);
        }
        public void updateStudent(String studentID, String firstName, String MI, String lastName)
        {
            String query = "update student set firstname = '" + firstName + "', lastname = '" + lastName + "', MI = '" + MI + "' ";
            query += "where studentid = " + studentID + ";";

            dbHandler.Update(query);
        }

        // panelists
        public List<String>[] getPanelistInfo(String panelistID)
        {
            String query = "select firstname, MI, lastname from panelist where panelistid = '" + panelistID + "';";
            return dbHandler.Select(query, 3);
        }
        public String getPanelistName(String panelistID)
        {
            if (panelistID == "")
                return "";

            List<String>[] panelName = getPanelistInfo(panelistID);
            return panelName[0].ElementAt(0) + " " + panelName[1].ElementAt(0) + ". " + panelName[2].ElementAt(0);
        }
        public String getPanelistIDFromName(String firstName, String MI, String lastName)
        {
            String query = "select panelistid from panelist where firstname = '" + firstName + "' and MI = '" + MI + "' and lastname = '" + lastName + "';";
            return dbHandler.Select(query, 1)[0].ElementAt(0);
        }
        public String getPanelistIDFromName(String fullName)
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

            return getPanelistIDFromName(newFirstName, newMI, newLastName);
        }
        public void insertNewPanelist(String panelistID, String firstName, String MI, String lastName)
        {
            String query = "insert into panelist values(" + panelistID + ", '" + firstName + "', '" + MI + "', '";
            query += lastName + "');";
            dbHandler.Insert(query);
        }
        public void insertNewPanelist(String panelistID, String fullName)
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

            insertNewPanelist(panelistID, newFirstName, newMI, newLastName);
        }
        public void updatePanelist(String panelistID, String firstName, String MI, String lastName)
        {
            String query = "update panelist set firstname = '" + firstName + "', lastname = '" + lastName + "', MI = '" + MI + "' ";
            query += "where panelistid = " + panelistID + ";";

            dbHandler.Update(query);
        }
        public void assignPanelistToGroup(String thesisGroupID, String panelistID)
        {
            String query = "insert into panelassignment values(" + thesisGroupID + ", " + panelistID + ");";
            dbHandler.Insert(query);
        }
        public void removeAssignedPanelistFromGroup(String thesisGroupID, String panelistID)
        {
            String query = "delete from panelassignment where thesisgroupid = " + thesisGroupID + " and panelistid = " + panelistID + ";";
            dbHandler.Delete(query);
        }

        // adviseeeer
        public String getAdviserID(String thesisGroupID)
        {
            String query = "select advisorid from thesisgroup where thesisgroupid = " + thesisGroupID + ";";
            return dbHandler.Select(query, 1)[0].ElementAt(0);
        }
        public void updateAdviser(String thesisGroupID, String adviserID)
        {
            String update = "update thesisgroup set advisorID = " + adviserID + " where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(update);
        }
        public void removeAdviser(String thesisGroupID)
        {
            String query = "update thesisgroup set advisorID = NULL where thesisgroupid = " + thesisGroupID + ";";
            dbHandler.Update(query);
        }

        // how many panelists/students does the thesis group have?
        public int panelistCount(String thesisGroupID)
        {
            String query = "select count(*) from panelist where panelistid in (select panelistid from panelassignment where thesisgroupid =  " + thesisGroupID + ");";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }
        public int panelistNotInGroupCount(String thesisGroupID)
        {
            String query = "select count(*) from panelist where panelistid not in (select panelistid from panelassignment where thesisgroupid = " + thesisGroupID + ");";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }
        public int studentCount(String thesisGroupID)
        {
            String query = "select count(*) from student where thesisgroupid = " + thesisGroupID + ";";
            return Convert.ToInt32(dbHandler.Select(query, 1)[0].ElementAt(0));
        }

        // given a treeview, add groups sorted by section ordered alphabetically
        public void showGroups(TreeNodeCollection tree)
        {
            String query = "select distinct course from thesisgroup where course IS NOT NULL and course != 'THSST-2';";
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
