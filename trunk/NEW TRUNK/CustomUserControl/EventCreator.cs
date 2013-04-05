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
        private DBce dbHandler = new DBce();
        public String type="";
        public bool isEditMode = false;
        public List<String> forEditing = new List<String>();
        public EventCreator(bool editMode)
        {
            this.isEditMode = editMode;
            InitializeComponent();
        }

        public void initializeTextBoxes() 
        {
                textBoxEventName.Text = forEditing[1];
                dateTimePickerEventStartTime.Value = Convert.ToDateTime(forEditing[2]);
                dateTimePickerEventEndTime.Value = Convert.ToDateTime(forEditing[3]);
            
        }


        private void buttonSaveEvent_Click(object sender, EventArgs e)
        {   
            //CHECKING
                //Duplicate
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
                //time alignment
            if (dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventEndTime.Value) >= 0) 
            {
                Console.WriteLine(dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventEndTime.Value));
                MessageBox.Show("Time is invalid", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //ADD & EDIT
            if(isEditMode)
            {
                query = "UPDATE Event SET name = '" + textBoxEventName.Text + "',eventStart = CONVERT(DATETIME,'" + dateTimePickerEventStartTime.Value.ToString() + "',102) ,eventEnd=CONVERT(DATETIME,'" + dateTimePickerEventEndTime.Value.ToString() + "',102) WHERE eventID =" + Convert.ToInt32(forEditing[0]) + "";
                Console.WriteLine(query);
                dbHandler.Update(query);


               
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
