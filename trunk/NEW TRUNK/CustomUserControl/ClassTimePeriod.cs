using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    class ClassTimePeriod : TimePeriod
    {
        private int id;
        
        private String course;
        private String section;
        private String day;
        private String panelist;

        //Not in the uml
        public String Course { get { return course; } }
        public String Section { get { return section; } }
        public String Day { get { return day; } }
        public String Panelist { get { return panelist; } }
        //end
        
        public ClassTimePeriod(int id, String section, String course, String day, DateTime startTime, DateTime endTime, String panelistID) 
            :base(startTime, endTime)
        {
            this.id = id;
            this.section = section;
            this.course = course;
            this.day = day;
            this.panelist = panelistID;
        }

        public override String ToString() 
        {
            return day+"\t"+section + "\t" + course + "\t" + base.ToString();
        }

    }
}
