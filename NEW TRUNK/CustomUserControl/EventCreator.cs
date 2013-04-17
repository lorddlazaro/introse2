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
        public String type = "";
        public bool isEditMode = false;
        public List<String> forEditing = new List<String>();
        private SchedulingDataManager schedulingDM;
        public EventCreator(bool editMode, Form p, ScheduleEditor sp)
        {
            parent = p;
            subParent = sp;
            this.isEditMode = editMode;
            InitializeComponent();
            dateTimePickerEventEndTime.Value = DateTime.Today;
            dateTimePickerEventStartTime.Value = DateTime.Today;
            labelWarning.Text = "";
            schedulingDM = new SchedulingDataManager();
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
            if (String.IsNullOrWhiteSpace(textBoxEventName.Text))
            {
                textBoxEventName.BackColor = Color.LightPink;

                labelWarning.Text = "Name cannot be empty";
                return;
            }
            //-Date and Time Check
            //if (dateTimePickerEventStartTime.Value.CompareTo(dateTimePickerEventEndTime.Value) >= 0)
            if (dateTimePickerEventStartTime.Value >= dateTimePickerEventEndTime.Value)
            {
                labelWarning.Text = "Start time should come" + System.Environment.NewLine + "first before endtime.";
                return;
            }
            //-Duplication Check
            String query;
            query = "SELECT name FROM Event WHERE name ='" + textBoxEventName.Text + "' AND eventStart = CONVERT(DATETIME,'" + dateTimePickerEventStartTime.Value.ToString() + "',102) AND eventEnd = CONVERT(DATETIME,'" + dateTimePickerEventEndTime.Value.ToString() + "',102);";
            
            List<String> duplicateEvents = dbHandler.Select(query, 1)[0];
            
            if (duplicateEvents.Count > 0)
            {
                if (isEditMode)
                {
                    if (!duplicateEvents[0].Equals(forEditing[1]))
                    {
                        MessageBox.Show("This event already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("This event already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            
            //START: Conflict with defense checking
            if (isEditMode)
            {
                query = "SELECT        Student.thesisGroupID FROM            StudentEventRecord INNER JOIN Student ON StudentEventRecord.studentID = Student.studentID WHERE StudentEventRecord.eventID = " + forEditing[0] + "";
                
                HashSet<int> thesisGroupSet = new HashSet<int>();
                List<String> thesisGroupsWithDuplicates = dbHandler.Select(query, 1)[0];
                //List<String> thesisGroupsNoDuplicates = new List<String>();
                for (int i = 0; i < thesisGroupsWithDuplicates.Count; i++)
                    thesisGroupSet.Add(Convert.ToInt32(thesisGroupsWithDuplicates[i]));

                query = "SELECT        PanelAssignment.thesisGroupID FROM            PanelistEventRecord INNER JOIN Panelist ON PanelistEventRecord.panelistID = Panelist.panelistID INNER JOIN PanelAssignment ON Panelist.panelistID = PanelAssignment.panelistID WHERE PanelistEventRecord.eventID =" + forEditing[0] + " ";
                
                thesisGroupsWithDuplicates = dbHandler.Select(query, 1)[0];
                for (int i = 0; i < thesisGroupsWithDuplicates.Count; i++)
                    thesisGroupSet.Add(Convert.ToInt32(thesisGroupsWithDuplicates[i]));

                List<DefenseSchedule> allDefenses = new List<DefenseSchedule>();
                foreach (int thesisGroupID in thesisGroupSet)
                {
                    query = "SELECT        DefenseSchedule.defenseDateTime, DefenseSchedule.defenseID,  DefenseSchedule.thesisGroupID, ThesisGroup.course FROM            DefenseSchedule INNER JOIN ThesisGroup ON DefenseSchedule.thesisGroupID = ThesisGroup.thesisGroupID WHERE        (DefenseSchedule.thesisGroupID = " + thesisGroupID + ")";
                    
                    List<String>[] defensesOfThesisGroup = dbHandler.Select(query, 4);
                    
                    if (defensesOfThesisGroup[0].Count > 0)
                        for (int i = 0; i < defensesOfThesisGroup[0].Count; i++)
                            allDefenses.Add(new DefenseSchedule(DateTime.Now, DateTime.Now, Convert.ToDateTime(defensesOfThesisGroup[0][i]), defensesOfThesisGroup[1][i], defensesOfThesisGroup[2][i], defensesOfThesisGroup[3][i]));
                }

                if (allDefenses.Count > 0)
                {
                    for (int i = 0; i < allDefenses.Count; i++)
                    {
                        DateTime maxStart;
                        DateTime minEnd;
                        DateTime defenseEndtime;
                        //get start of conflict
                        if (allDefenses[i].DefenseDateTime > dateTimePickerEventStartTime.Value)
                            maxStart = allDefenses[i].DefenseDateTime;
                        else
                            maxStart = dateTimePickerEventStartTime.Value;

                        //GET endtime of defense
                        if (allDefenses[i].Course.Equals("THSST-1"))
                            defenseEndtime = allDefenses[i].DefenseDateTime.AddMinutes(Constants.THSST1_DEFDURATION_MINS);
                        else
                            defenseEndtime = allDefenses[i].DefenseDateTime.AddMinutes(Constants.THSST3_DEFDURATION_MINS);
                        
                        //get end of conflict
                        if (defenseEndtime > dateTimePickerEventEndTime.Value)
                            minEnd = dateTimePickerEventEndTime.Value;
                        else
                            minEnd = defenseEndtime;

                        if (maxStart < minEnd)
                        {
                            DialogResult result = MessageBox.Show("Event conflicts with defense schedule of student/panelist assigned to it." + System.Environment.NewLine + "Unschedule conflicting defense?", "Conflict with Defense", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                query = "DELETE FROM DefenseSchedule WHERE defenseID = " + Convert.ToInt32(allDefenses[i].DefenseID) + "";
                                dbHandler.Delete(query);

                            }
                            else
                                return;

                            MessageBox.Show("Conflicting defense removed", "Conflict with Defense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            //END: Conflict with defense checking
            //END of VALIDATION

            //EDIT
            if (isEditMode)
            {
                query = "UPDATE Event SET name = '" + textBoxEventName.Text + "',eventStart = CONVERT(DATETIME,'" + dateTimePickerEventStartTime.Value.ToString() + "',102) ,eventEnd=CONVERT(DATETIME,'" + dateTimePickerEventEndTime.Value.ToString() + "',102) WHERE eventID =" + Convert.ToInt32(forEditing[0]) + "";
                dbHandler.Update(query);
            }
            //ADD
            else
            {
                query = "INSERT INTO Event(name,eventStart,eventEnd) VALUES('" + textBoxEventName.Text + "',CONVERT(DATETIME,'" + dateTimePickerEventStartTime.Value.ToString() + "',102),CONVERT(DATETIME,'" + dateTimePickerEventEndTime.Value.ToString() + "',102));";
                dbHandler.Insert(query);
            }
            subParent.RefreshAll();
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
