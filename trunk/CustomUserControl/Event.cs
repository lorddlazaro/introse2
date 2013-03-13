using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    class Event : TimePeriod
    {
        //Although timeperiod does not take the date into account, for this class, the date matters.

        private int id;
        private String name;

        public Event(int id, String name, DateTime start, DateTime end) 
            :base(start, end)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return StartTime + " - " + EndTime + " \n\t" + name;
        }


    }
}
