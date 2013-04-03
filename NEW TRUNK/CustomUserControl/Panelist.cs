using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomUserControl
{
    class Panelist
    {
        
        private int panelistID;
        private String firstName;
        private String mI;
        private String lastName;

        public int PanelistID { get { return panelistID; } }
        public String FirstName { get { return firstName; } }
        public String MI { get { return mI; } }
        public String LastName { get { return lastName; } }

        public Panelist(int ID, String first, String MI, String last) 
        {
            panelistID = ID;
            firstName = first;
            mI = MI;
            lastName = last;
        }

        public override String ToString()
        {
            return firstName + " " + mI + ". " + lastName;
        }
    }
}
