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

        public String DefenseID { get { return defenseID; } }
        public String GroupTitle{ get{ return groupTitle;} }
        public String Place { get { return place; } }
        public String ThesisGroupID { get { return thesisGroupID; } }

        public DefenseSchedule(String defenseID, DateTime startTime, DateTime endTime, String place, String groupTitle)
            :base(startTime, endTime)
        {
            this.defenseID = defenseID;
            this.place = place;
            this.groupTitle = groupTitle;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + place + "\n" + groupTitle;
        }

    }
}
