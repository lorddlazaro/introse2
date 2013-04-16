using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    public class DefenseSchedule : TimePeriod
    {
        
        private String place;
        private String groupTitle;
        private String defenseID;
        private DateTime defenseDateTime;
        private String thesisGroupID;

        public String Place { get { return place; } }
        public String GroupTitle{ get{ return groupTitle;} }
        public String DefenseID { get { return defenseID; } }
        public DateTime DefenseDateTime { get { return defenseDateTime; } }
        public String ThesisGroupID { get { return thesisGroupID; } }

        public DefenseSchedule(String defenseID,DateTime startTime, DateTime endTime, String place, String groupTitle)
            :base(startTime, endTime)
        {
            this.defenseID= defenseID;
            this.place = place;
            this.groupTitle = groupTitle;
        }
        public DefenseSchedule(String defenseID, String thesisGroupID, DateTime defenseDateTime)
            : base(DateTime.Now,DateTime.Now )
        {
            this.defenseID = defenseID;
            this.thesisGroupID = thesisGroupID;
            this.defenseDateTime = defenseDateTime;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + place + "\n" + groupTitle;
        }


    }
}
