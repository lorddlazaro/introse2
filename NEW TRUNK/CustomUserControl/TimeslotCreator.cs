using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomUserControl
{
    public partial class TimeslotCreator : Form
    {
        private Form parent;
        private ScheduleEditor subParent;
        private DBce dbHandler = new DBce();
        private List<String>[] panelTable;
        private BindingList<Panelist> panelList = new BindingList<Panelist>();
        public List<String> forEditing = new List<String>();
        public bool isEditMode = false;
        private ListViewItem lastItemChecked;

        public String panelistID;

        public TimeslotCreator(bool editMode,Form p,ScheduleEditor sp)
        {
            parent = p;
            subParent = sp;
            this.isEditMode = editMode;
            InitializeComponent();
            initializePanel();
                
        }
        public void initializeTextBoxes() 
        {
            listViewWeeklyTimeslotDay.MultiSelect = false;
            textBoxWeeklyTimeslotCourse.Text = forEditing[1];
            textBoxWeeklyTimeslotSection.Text = forEditing[2];
            switch (forEditing[3]) 
            {
                case "M": listViewWeeklyTimeslotDay.Items[0].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[0]; 
                    break;
                case "T": listViewWeeklyTimeslotDay.Items[1].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[1]; 
                    break;
                case "W": listViewWeeklyTimeslotDay.Items[2].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[2]; 
                    break;
                case "H": listViewWeeklyTimeslotDay.Items[3].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[3]; 
                    break;
                case "F": listViewWeeklyTimeslotDay.Items[4].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[4]; 
                    break;
                case "S": listViewWeeklyTimeslotDay.Items[5].Checked = true; 
                    lastItemChecked = listViewWeeklyTimeslotDay.Items[5]; 
                    break;
            }
            for(int i =0;i<7;i++)
                Console.WriteLine(forEditing[i]);
            dateTimePickerWeeklyTimeslotStartTime.Value = Convert.ToDateTime(forEditing[5]);
            dateTimePickerWeeklyTimeslotEndTime.Value = Convert.ToDateTime(forEditing[6]);
            /*int panelIndex=0;
            for(int i=0;i<comboBoxPanelist.Items.Count;i++)
            {
                if(comboBoxPanelist.Items[i].ToString().Equals(forEditing[6]))
                    panelIndex = i;
            }*/
            comboBoxPanelist.SelectedIndex = comboBoxPanelist.FindStringExact(forEditing[4]);
            Console.WriteLine(forEditing[6] + "==");
            //Console.WriteLine(comboBoxPanelist.Items[].ToString());
            //Console.WriteLine(comboBoxPanelist.Items[comboBoxPanelist.FindStringExact(forEditing[6])].ToString());

        }
        public void initializePanel()
        {
            String query = "SELECT panelistID, firstName, MI, lastName FROM Panelist;";
            panelTable = dbHandler.Select(query, 4);

            if (panelTable[0].Count == 0)
            {
                return;
            }

            //Convert from 2D list to list of events
            int id;
            String firstName;
            String MI;
            String lastName;
            for (int i = 0; i < panelTable[0].Count; i++)
            {
                id = Convert.ToInt32(panelTable[0][i]);
                firstName = panelTable[1][i];
                MI = panelTable[2][i];
                lastName = panelTable[3][i];
                panelList.Add(new Panelist(id, firstName, MI, lastName));
            }

            comboBoxPanelist.DataSource = panelList;
            //comboBoxEvent.DataSource = panelList;
            //comboBoxEvent.Items.Remove("eventStart");
            
        }



        private void buttonCancelTimeslot_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Dispose();
        }

        private void buttonSaveTimeslot_Click(object r, EventArgs e)
        {
            if (textBoxWeeklyTimeslotCourse.Text.Length > 7 || textBoxWeeklyTimeslotCourse.Text == "") 
            {
                MessageBox.Show("Course should be less than 7 characters and shouldn't be null", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxWeeklyTimeslotSection.Text.Length > 3 || textBoxWeeklyTimeslotSection.Text =="") 
            {
                MessageBox.Show("section should be less than 3 characters and shouldn't be null", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int j=0;
            for (int i = 0; i < listViewWeeklyTimeslotDay.Items.Count; i++) 
            {

                
                if (listViewWeeklyTimeslotDay.Items[i].Checked) 
                {
                    j++;
                }
            }
            if (j == 0) 
            {
                MessageBox.Show("select at least one checkbox", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateTimePickerWeeklyTimeslotStartTime.Value.CompareTo(dateTimePickerWeeklyTimeslotEndTime.Value) >= 0)
            {
                Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.CompareTo(dateTimePickerWeeklyTimeslotEndTime.Value));
                MessageBox.Show("Time is invalid", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxPanelist.FindStringExact(comboBoxPanelist.Text)==-1) 
            {
                MessageBox.Show("Panelist doesn't exist", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (isEditMode)
            {
                
                String query;
                String day = "";
                for (int i = 0; i < 6; i++)
                {
                    if (listViewWeeklyTimeslotDay.Items[i].Checked == true)
                    {
                        switch (listViewWeeklyTimeslotDay.Items[i].Index)
                        {
                            case 0:
                                Console.WriteLine("Monday");
                                day = "M";
                                break;
                            case 1:
                                Console.WriteLine("Tuesday");
                                day = "T";
                                break;
                            case 2: Console.WriteLine("Wednesday");
                                day = "W";
                                break;
                            case 3: Console.WriteLine("Thursday");
                                day = "H";
                                break;
                            case 4: Console.WriteLine("Friday");
                                day = "F";
                                break;
                            case 5: Console.WriteLine("Saturday");
                                day = "S";
                                break;
                            default: break;
                        }
                    }
                }
                panelistID = panelTable[0][comboBoxPanelist.SelectedIndex];
                query = "UPDATE Timeslot SET section = N'" + textBoxWeeklyTimeslotSection.Text + "', courseName = N'" + textBoxWeeklyTimeslotCourse.Text + "', day = N'" + day + "', startTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), endTime = CONVERT(DATETIME,'" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString("MM/dd/yyy hh:mm tt") + "',102), panelistID = N'" + panelistID + "' WHERE timeslotID = '" + forEditing[0] + "';";
                Console.WriteLine(query);
                dbHandler.Update(query);
            }
            else
            {
                String query;
                String day = "";
                for (int i = 0; i < 6; i++)
                {
                    if (listViewWeeklyTimeslotDay.Items[i].Checked == true)
                    {
                        switch (listViewWeeklyTimeslotDay.Items[i].Index)
                        {
                            case 0:
                                Console.WriteLine("Monday");
                                day = "M";
                                break;
                            case 1:
                                Console.WriteLine("Tuesday");
                                day = "T";
                                break;
                            case 2: Console.WriteLine("Wednesday");
                                day = "W";
                                break;
                            case 3: Console.WriteLine("Thursday");
                                day = "H";
                                break;
                            case 4: Console.WriteLine("Friday");
                                day = "F";
                                break;
                            case 5: Console.WriteLine("Saturday");
                                day = "S";
                                break;
                            default: break;

                        }
                        
                       
                        if (comboBoxPanelist.Text == "")
                        {
                            Console.WriteLine("comboboxpanelist = null");
                            query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), NULL)";
                        }
                        else
                        {
                            panelistID = panelTable[0][comboBoxPanelist.SelectedIndex];
                            Console.WriteLine("panelistID: " + panelistID);
                            query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES('" + textBoxWeeklyTimeslotCourse.Text + "', '" + textBoxWeeklyTimeslotSection.Text + "', '" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), N'" + panelistID + "')";
                        }
                        
                       
                        
                        try
                        {
                            dbHandler.Insert(query);
                            Console.WriteLine(query);
                            Console.WriteLine("ADD NEW-INSERT SUCCESS");
                        }
                        catch (SqlException sqlEx)
                        {
                            if (sqlEx.Source != null)
                                Console.WriteLine("IOException source: {0}", sqlEx.Source);
                            Console.WriteLine("query= " + query);
                            //if(textBoxWeeklyTimeslotCourse.Text == null)
                        }
                            

                    }
                }
            }
            subParent.refreshAll();
            parent.Enabled = true;
            this.Dispose();
        }

        private void listViewWeeklyTimeslotDay_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // if we have the lastItem set as checked, and it is different
            // item than the one that fired the event, uncheck it
            if (isEditMode)
            {
                if (lastItemChecked != null && lastItemChecked.Checked && lastItemChecked != listViewWeeklyTimeslotDay.Items[e.Item.Index])
                {
                    // uncheck the last item and store the new one
                    lastItemChecked.Checked = false;
                }

                // store current item
                lastItemChecked = listViewWeeklyTimeslotDay.Items[e.Item.Index];
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Enabled = true;
        }

    }
}
