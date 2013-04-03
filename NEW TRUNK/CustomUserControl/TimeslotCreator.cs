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
        DBce dbHandler = new DBce();
        List<String>[] panelTable;
        BindingList<Panelist> panelList = new BindingList<Panelist>();

        public String panelistID;

        public TimeslotCreator()
        {
            InitializeComponent();
            initializePanel();
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
            this.Visible = false;
        }

        private void buttonSaveTimeslot_Click(object sender, EventArgs e)
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
                    /*
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToLongTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortDateString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToShortTimeString());
                    Console.WriteLine(dateTimePickerWeeklyTimeslotStartTime.Value.ToString());*/
                    panelistID = panelTable[0][comboBoxPanelist.SelectedIndex];
                    Console.WriteLine("panelistID: "+panelistID);
                    query = "INSERT INTO Timeslot(courseName, section, day,startTime,endTime,panelistID) VALUES(N'" + textBoxWeeklyTimeslotCourse.Text + "', N'" + textBoxWeeklyTimeslotSection.Text + "', N'" + day + "',CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotStartTime.Value.ToString() + "', 102), CONVERT(DATETIME, '" + dateTimePickerWeeklyTimeslotEndTime.Value.ToString() + "', 102), N'" + panelistID + "')";
                    try
                    {
                        dbHandler.Insert(query);
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
            this.Visible = false;
        }

    }
}
