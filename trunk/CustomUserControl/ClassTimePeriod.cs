using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    class ClassTimePeriod : TimePeriod
    {
        private int id;
        private String section;
        private String course;
        private String day;
        
        public ClassTimePeriod(int id, String section, String course, String day, DateTime startTime, DateTime endTime) 
            :base(startTime, endTime)
        {
            this.id = id;
            this.section = section;
            this.course = course;
            this.day = day;
        }

        public override String ToString() 
        {
            return day+"\t"+section + "\t" + course + "\t" + base.ToString();
        }

    }
}
