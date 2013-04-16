using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CustomUserControl
{
    public partial class DefenseSchedulesViewercs : UserControl
    {
        DBce dbHandler;

        public DefenseSchedulesViewercs()
        {
            InitializeComponent();
            dbHandler = new DBce();
        }

        private void buttonViewDefScheds_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;
            if (start.Date.CompareTo(end.Date) <= 0)
            {
                printSchedule(dateTimePickerStart.Value, end);
                labelDisplayMsg.Text = "Viewing Schedules from " + start.ToString("D") + " to " + end.ToString("D");
            }
            else
            {
                labelDisplayMsg.Text = "Invalid range. Make sure the first date is before or the same as the second.";
            }
        }

        private void printSchedule(DateTime start, DateTime end)
        {
            String query;
            List<String>[] list;
            List<String>[] panelist;
            int rowIndex;

            //Course, Title, Date, Time, Venue, Adviser, Panels
            dataGridView1.Rows.Clear();
            rowIndex = 0;

            for (DateTime i = start; i.CompareTo(end) != 1; i = i.AddDays(1)) 
            {
                query = "select t.thesisgroupid, t.course, t.title, d.defensedatetime, d.place from defenseschedule d, thesisgroup t where d.thesisgroupid = t.thesisgroupid";
                query += " and datepart(yyyy,d.defensedatetime) =" + i.Year + " and datepart(mm,d.defensedatetime) =" + i.Month + " and datepart(dd,d.defensedatetime) =" + i.Day + " order by t.course, t.section, d.defensedatetime;";

                list = dbHandler.Select(query, 5);

                for (int j = 0; j < list[0].Count(); j++, rowIndex++) 
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = list[1].ElementAt(j);
                    dataGridView1.Rows[rowIndex].Cells[1].Value = list[2].ElementAt(j);

                    string dateTimeString = string.Format("{0:M/d/yyyy H:mm}", list[3].ElementAt(j));

                    int month = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[0]);
                    int day = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[1]);
                    int year = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[2]);
                    int hour = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[0]);
                    int minute = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[1]);

                    DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);

                    dataGridView1.Rows[rowIndex].Cells[2].Value = string.Format("{0:M/d/yyyy}",dateTime);

                    if(list[1].ElementAt(j).Equals("THSST-1"))
                        dataGridView1.Rows[rowIndex].Cells[3].Value = string.Format("{0:HHmm}", dateTime) + " - " + string.Format("{0:HHmm}", dateTime.AddHours(1));
                    else
                        dataGridView1.Rows[rowIndex].Cells[3].Value = string.Format("{0:HHmm}", dateTime) + " - " + string.Format("{0:HHmm}", dateTime.AddHours(2));

                    dataGridView1.Rows[rowIndex].Cells[4].Value = list[4].ElementAt(j);

                    // panelists
                    query = "select p.lastName, p.firstName, p.mi from panelist p, panelassignment pa where pa.panelistid = p.panelistid and pa.thesisgroupid = " + list[0].ElementAt(j) + " order by p.lastname ;";
                    panelist = dbHandler.Select(query, 3);

                    String panelistCellText = "";
                    for (int k = 0; k < panelist[0].Count(); k++) 
                    {
                        panelistCellText += panelist[0].ElementAt(k) + ", " + panelist[1].ElementAt(k) + " " + panelist[2].ElementAt(k) + ".";
                        if (k < panelist[0].Count() - 1)
                            panelistCellText += "\n";
                    } 

                    dataGridView1.Rows[rowIndex].Cells[6].Value = panelistCellText;
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There are no defense schedules within the selected range", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.Value = dateTimePickerStart.Value.AddDays(6);
        }

        private void DefenseSchedulesViewercs_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = DateTime.Now;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //  FilterIndex
            //  1 - CSV file - for Thesis Groups
            //  2 - CSV file - for Panelists
            //  3 - CSV file - general format
            //  4 - TXT file - for Thesis Groups
            //  5 - TXT file - for Panelists
            //  6 - TXT file - general format
            //
            //  Formats:
            //  for Thesis Groups:  includes title, date, time, venue
            //  for Panelists:      includes title, date, time, venue, panel
            //  general format:     includes all (course, title, date, time, venue, panel)

            Boolean isCSVfile = false;
            Boolean saveCourseColumn = false;
            Boolean savePanelColumn = false;

            if (saveFileDialog1.FilterIndex < 4)
                isCSVfile = true;

            switch (saveFileDialog1.FilterIndex) 
            { 
                case 2:
                case 5: savePanelColumn = true;      
                    break;

                case 3:
                case 6: savePanelColumn = true;      
                        saveCourseColumn = true;     
                    break;
            }

            string lineToWrite;

            if(File.Exists(saveFileDialog1.FileName))
                if (CheckIfFileIsBeingUsed(saveFileDialog1.FileName))
                {
                    MessageBox.Show("File is currently in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        lineToWrite = "";
                        
                        if (saveCourseColumn)
                        {
                            lineToWrite += dataGridView1.Rows[i].Cells[0].Value;

                            if (isCSVfile)
                                lineToWrite += ",";
                            else
                                lineToWrite += " ";
                        }

                        // index column
                        //   1    title
                        //   2    date
                        //   3    time
                        //   4    venue
                        for (int j = 1; j <= 4; j++)
                        {
                            lineToWrite += dataGridView1.Rows[i].Cells[j].Value;

                            if (j < 4 || savePanelColumn)
                                if (isCSVfile)
                                    lineToWrite += ",";
                                else
                                    lineToWrite += " ";
                         }

                         if (savePanelColumn)
                         {
                            string[] panels = dataGridView1.Rows[i].Cells[6].Value.ToString().Split('\n');

                            for (int j = 0; j < panels.Count(); j++)
                            {
                                lineToWrite += "\"" + panels[j] + "\"";

                                if (j < panels.Count() - 1)
                                    if (isCSVfile)
                                        lineToWrite += ",";
                                    else
                                        lineToWrite += " ";
                            }
                        }
                        sw.WriteLine(lineToWrite);
                    }
                    sw.Flush();
                    sw.Close();
                }
        }
    
        public bool CheckIfFileIsBeingUsed(string fileName)
        {
            FileStream fs;

            try
            {
                fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (System.IO.IOException exp)
            {
                return true;
            }

            fs.Close();
            return false;

        }

    }
}