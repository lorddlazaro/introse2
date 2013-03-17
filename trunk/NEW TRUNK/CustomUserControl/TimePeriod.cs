using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    public class TimePeriod : IComparable<TimePeriod>, IEquatable<TimePeriod>
    {
        //startTime and endTime represent time only. Date does not matter here. 
        private DateTime startTime;
        private DateTime endTime;

        public DateTime StartTime { get { return startTime; } }
        public DateTime EndTime { get { return endTime; } }


        public override String ToString()
        {
            return startTime.ToString("HH:mm") + "-" + endTime.ToString("HH:mm");
        }

        //Two time periods are equal if the startTime and endTime are the same. (Considering time only and ignoring the dates)
        public bool Equals(TimePeriod other)
        {
            if (this.startTime.Hour != other.startTime.Hour || this.startTime.Minute != other.startTime.Minute || this.startTime.Second != other.startTime.Second)
                return false;
            if (this.endTime.Hour != other.endTime.Hour || this.endTime.Minute != other.endTime.Minute || this.endTime.Second != other.endTime.Second)
                return false;
            return true;
            //return this.startTime.TimeOfDay.CompareTo(other.StartTime.TimeOfDay) == 0 && this.startTime.TimeOfDay.CompareTo(other.endTime.TimeOfDay) == 0;
        }

        public TimePeriod(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public int CompareTo(TimePeriod other)
        {
            //return startTime.CompareTo(other.startTime);
            return this.startTime.TimeOfDay.CompareTo(other.startTime.TimeOfDay);
        }

        public bool isWithin(TimePeriod other)
        {
            if (startTime.CompareTo(other.startTime) == 0 && endTime.CompareTo(other.endTime) == 0)
                return true;
            if (IsBetweenInclusive(other.startTime, other.endTime, startTime) && IsBetweenInclusive(other.startTime, other.endTime, endTime))
                return true;

            return false;
        }

        public bool IntersectsExclusive(TimePeriod other)
        {
            if (startTime.CompareTo(other.startTime) == 0 && endTime.CompareTo(other.endTime) == 0)
                return true;
            if (IsBetweenExclusive(startTime, endTime, other.startTime) || IsBetweenExclusive(startTime, endTime, other.endTime))
                return true;
            if (IsBetweenExclusive(other.startTime, other.endTime, startTime) || IsBetweenExclusive(other.startTime, other.endTime, endTime))
                return true;

            return false;
        }

        private bool IsBetweenExclusive(DateTime start, DateTime end, DateTime check)
        {
            if (check.TimeOfDay.CompareTo(start.TimeOfDay) > 0 && check.TimeOfDay.CompareTo(end.TimeOfDay) < 0)
                return true;

            return false;
        }

        public bool IntersectsInclusive(TimePeriod other)
        {
            if (startTime.CompareTo(other.startTime) == 0 && endTime.CompareTo(other.endTime) == 0)
                return true;
            if (IsBetweenInclusive(startTime, endTime, other.startTime) || IsBetweenInclusive(startTime, endTime, other.endTime))
                return true;
            if (IsBetweenInclusive(other.startTime, other.endTime, startTime) || IsBetweenInclusive(other.startTime, other.endTime, endTime))
                return true;

            return false;
        }

        private bool IsBetweenInclusive(DateTime start, DateTime end, DateTime check)
        {
            if (check.TimeOfDay.CompareTo(start.TimeOfDay) >= 0 && check.TimeOfDay.CompareTo(end.TimeOfDay) <= 0)
                return true;

            return false;
        }

    }
}
