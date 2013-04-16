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
        private Form parent;
        private ScheduleEditor subParent;
        public String type="";
        public bool isEditMode = false;
        public List<String> forEditing = new List<String>();
        public EventCreator(bool editMode, Form p,ScheduleEditor sp)
        {
            parent = p;
            subParent = sp;
            this.isEditMode = editMode;
            InitializeComponent();
            dateTimePickerEventEndTime.Value = DateTime.Today;
            dateTimePickerEventStartTime.Value = DateTime.Today;
            labelWarning.Text = "";
            //MessageBox.Show(dateTimePickerEventEndTime.Value.ToString());
            
        }

        public void initializeTextBoxes() 
        {
                textBoxEventName.Text = forEditing[1];
                dateTimePickerEventStartTime.Value = Convert.ToDateTime(forEditing[2]);
                dateTimePickerEventEndTime.Value = Convert.ToDateTime(forEditing[3]);
        }


        private void buttonSaveEvent_Click(object sender, EventArgs e)
        {   
            //VALIDATION
            labelWarning.Text = "";
            textBoxEventName.BackColor = Color.White;
            //-Event null check
            if (textBoxEventName.Text == "")
            {
                textBoxEventName.BackColor = Color.LightPink;
                
                labelWarning.Text = "*Name is empty";
                //MessageBox.Show("name shouldn't be null", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //-Date and Time Check
            //if (dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventEndTime.Value) >= 0)
            if (dateTimePickerEventStartTime.Value >= dateTimePickerEventEndTime.Value)
            {
                labelWarning.Text = "Time error";
                Console.WriteLine(dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventEndTime.Value));
                //MessageBox.Show("Time is invalid", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //-Duplication Check
            String query;
            query = "SELECT name FROM Event WHERE name ='"+textBoxEventName.Text+"' AND eventStart = CONVERT(DATETIME,'"+dateTimePickerEventStartTime.Value.ToString()+"',102) AND eventEnd = CONVERT(DATETIME,'"+dateTimePickerEventEndTime.Value.ToString()+"',102);";
            Console.WriteLine(query);
            Console.WriteLine(dateTimePickerEventStartTime.Value.ToString() + dateTimePickerEventEndTime.Value.ToString());
            List<String> duplicateEvents = dbHandler.Select(query,1)[0];
            Console.WriteLine("check success");
            if(duplicateEvents.Count>0)
            {
                if(!duplicateEvents[0].Equals(forEditing[1]))
                {
                    MessageBox.Show("This event already exists","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                
            }
            //-Conflict with defense check for edit
            if (isEditMode) 
            {
                query = "SELECT defenseID,thesisGroupID, defenseDateTime FROM DefenseSchedule";
                List<String>[] defenseList = dbHandler.Select(query, 3);
                List<int> numConflicts = new List<int>();
                for (int i = 0; i < defenseList[0].Count; i++)
                {
                    Console.WriteLine("Conflict Check start---------");
                    Console.WriteLine(dateTimePickerEventStartTime.Value.ToString());
                    Console.WriteLine(Convert.ToDateTime(defenseList[2][i]).ToString());
                    Console.WriteLine(dateTimePickerEventEndTime.Value.ToString());
                    Console.WriteLine("Conflict Check end  ---------");
                    if (dateTimePickerEventStartTime.Value < Convert.ToDateTime(defenseList[2][i]) && Convert.ToDateTime(defenseList[2][i]) < dateTimePickerEventEndTime.Value)
                    {
                        Console.WriteLine("Conflict!");
                        numConflicts.Add(i);
                    }
                }
                
                if (numConflicts.Count > 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("There are " + numConflicts.Count + " conflicting defense schedule/s with this event. " + System.Environment.NewLine + "Do you want to unschedule all conflicting defenses?", "Conflicting with Defense", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        for (int i = 0; i < numConflicts.Count; i++)
                        {
                            query = "DELETE FROM DefenseSchedule WHERE defenseID = " + Convert.ToInt32(numConflicts[i]) + "";
                            dbHandler.Delete(query);
                            MessageBox.Show("All conflicting defenses removed", "Conflict with Defense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                        return;
                }
            }
            

            
            //END of VALIDATION

            //EDIT
            if(isEditMode)
            {
                query = "UPDATE Event SET name = '" + textBoxEventName.Text + "',eventStart = CONVERT(DATETIME,'" + dateTimePickerEventStartTime.Value.ToString() + "',102) ,eventEnd=CONVERT(DATETIME,'" + dateTimePickerEventEndTime.Value.ToString() + "',102) WHERE eventID =" + Convert.ToInt32(forEditing[0]) + "";
                Console.WriteLine(query);
                dbHandler.Update(query);
            }
            //ADD
            else
            {   
                query = "INSERT INTO Event(name,eventStart,eventEnd) VALUES('"+textBoxEventName.Text+"',CONVERT(DATETIME,'"+dateTimePickerEventStartTime.Value.ToString()+"',102),CONVERT(DATETIME,'"+dateTimePickerEventEndTime.Value.ToString()+"',102));";
                Console.WriteLine(query);
                dbHandler.Insert(query);
            }
            subParent.refreshAll();
            parent.Enabled = true;
            this.Dispose();
        }

        private void buttonCancelEvent_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Dispose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Enabled = true;
        }
    }
}
