using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    public class DateTimeHelper
    {

   

        public static bool DatesIntersectInclusive(DateTime sDate1, DateTime eDate1, DateTime sDate2, DateTime eDate2) 
        {
            if (sDate1.Date.CompareTo(sDate2.Date) == 0 && eDate1.Date.CompareTo(eDate2.Date) == 0)
                return true;
            if (IsBetweenInclusive(sDate1, sDate2, eDate2) || IsBetweenInclusive(eDate1, sDate2, eDate2))
                return true;
            if (IsBetweenInclusive(sDate2, sDate1, eDate1) || IsBetweenInclusive(eDate2, sDate1, eDate1))
                return true;

            return false;
        }

        public static bool IsBetweenInclusive(DateTime test, DateTime start, DateTime end) 
        {
            int startComparison = test.Date.CompareTo(start.Date);
            int endComparison = test.Date.CompareTo(end.Date);

            if (startComparison == 0 || endComparison == 0)
                return true;
            if (startComparison > 0 && endComparison < 0)
                return true;

            return false;
        }

        public static int ConvertToInt(String day)
        {
            if (day.Equals("M"))
                return 0;
            if (day.Equals("T"))
                return 1;
            if (day.Equals("W"))
                return 2;
            if (day.Equals("H"))
                return 3;
            if (day.Equals("F"))
                return 4;
            if (day.Equals("S"))
                return 5;

            return -1;
        }


        public static int SubtractTime(DateTime dt1, DateTime dt2) 
        {
            return 0;
        }

        //Just for debugging purposes
        public static void PrintTimePeriods(List<TimePeriod> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.ElementAt(i).StartTime + "-" + list.ElementAt(i).EndTime);
            }
        }

    }
}
