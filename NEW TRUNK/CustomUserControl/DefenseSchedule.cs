using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    public class DefenseSchedule : TimePeriod
    {
        private String defenseID;
        private String groupTitle;
        private String place;
        private String thesisGroupID;
        private String course;
        private DateTime defenseDateTime;

        public DateTime DefenseDateTime { get { return defenseDateTime; } }
        public String DefenseID { get { return defenseID; } }
        public String GroupTitle{ get{ return groupTitle;} }
        public String Place { get { return place; } }
        public String ThesisGroupID { get { return thesisGroupID; } }
        public String Course { get { return course; } }

        public DefenseSchedule(String defenseID, DateTime startTime, DateTime endTime, String place, String groupTitle)
            :base(startTime, endTime)
        {
            this.defenseID = defenseID;
            this.place = place;
            this.groupTitle = groupTitle;
        }
        public DefenseSchedule(DateTime startTime, DateTime endTime, DateTime defenseDateTime, String defenseID, String thesisGroupID, String course)
            : base(startTime, endTime)
        {

            this.defenseDateTime = defenseDateTime; 
            this.defenseID = defenseID;
            this.thesisGroupID = thesisGroupID;
            this.course = course;

        }

        public override String ToString()
        {
            return base.ToString() + "\n" + groupTitle;
        }
    }
}
