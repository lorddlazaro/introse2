using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    public partial class EventCreator : Form
    {
        DBce dbHandler = new DBce();
        String type="";
        public EventCreator(String type)
        {
            this.type = type;
            InitializeComponent();
            this.Visible = true;
        }

        private void buttonSaveEvent_Click(object sender, EventArgs e)
        {   
            
            String query;
            query = "SELECT name FROM Event WHERE name ='"+textBoxEventName.Text+"' AND eventStart = CONVERT(DATETIME,'"+dateTimePickerEventStartTime.Value.ToString()+"',102) AND eventEnd = CONVERT(DATETIME,'"+dateTimePickerEventEndTime.Value.ToString()+"',102);";
            Console.WriteLine(query);
            List<String> duplicateEvents = dbHandler.Select(query,1)[0];
            Console.WriteLine("check success");
            if(duplicateEvents.Count>0)
            {
                MessageBox.Show("This event already exists","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventStartTime.Value) <= 0) 
            {
                MessageBox.Show("Time is invalid", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(type.Equals("panelist"))
            {
               
            }
            else if(type.Equals("student"))
            {
            }
            else
            {   //VALIDATION
                    //Check for duplicates
                query = "INSERT INTO Event(name,eventStart,eventEnd) VALUES('"+textBoxEventName.Text+"',CONVERT(DATETIME,'"+dateTimePickerEventStartTime.Value.ToString()+"',102),CONVERT(DATETIME,'"+dateTimePickerEventEndTime.Value.ToString()+"',102));";
                Console.WriteLine(query);
                dbHandler.Insert(query);
                
            }
            this.Dispose();
        }

        private void buttonCancelEvent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
