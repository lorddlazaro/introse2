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
    public partial class DefenseSchedulesViewer : UserControl
    {
        DBce dbHandler;

        public DefenseSchedulesViewer()
        {
            InitializeComponent();
            dbHandler = new DBce();
        }

        // Refreshers
        private void RefreshDataGridView(DateTime start, DateTime end)
        {
            String query;
            List<String>[] list;
            List<String>[] panelist;
            int rowIndex;

            //Course, Title, Date, Time, Venue, Adviser, Panels
            dataGridViewDefSchedInfo.Rows.Clear();
            rowIndex = 0;

            for (DateTime i = start; i.CompareTo(end) != 1; i = i.AddDays(1))
            {
                query = "select t.thesisgroupid, t.course, t.title, d.defensedatetime, d.place from defenseschedule d, thesisgroup t where d.thesisgroupid = t.thesisgroupid";
                query += " and datepart(yyyy,d.defensedatetime) =" + i.Year + " and datepart(mm,d.defensedatetime) =" + i.Month + " and datepart(dd,d.defensedatetime) =" + i.Day;
                
                if(checkBoxIncludeTHSST1.Checked && checkBoxIncludeTHSST3.Checked)
                    query += " order by t.course, t.section, d.defensedatetime;";
                else if(checkBoxIncludeTHSST1.Enabled)
                    query += " and t.course = 'THSST-1' order by t.course, t.section, d.defensedatetime;";
                else if (checkBoxIncludeTHSST3.Enabled)
                    query += " and t.course = 'THSST-3' order by t.course, t.section, d.defensedatetime;";
                else
                {
                    MessageBox.Show("No course included","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    labelNoSchedulesFound.Visible = true;
                    return;
                }

                list = dbHandler.Select(query, 5);

                for (int j = 0; j < list[0].Count(); j++, rowIndex++)
                {
                    dataGridViewDefSchedInfo.Rows.Add();
                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[0].Value = list[1].ElementAt(j);
                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[1].Value = list[2].ElementAt(j);

                    string dateTimeString = string.Format("{0:M/d/yyyy H:mm}", list[3].ElementAt(j));

                    int month = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[0]);
                    int day = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[1]);
                    int year = Convert.ToInt16(dateTimeString.Split(' ')[0].Split('/')[2]);
                    int hour = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[0]);
                    int minute = Convert.ToInt16(dateTimeString.Split(' ')[1].Split(':')[1]);

                    DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);

                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[2].Value = string.Format("{0:M/d/yyyy}", dateTime);

                    if (list[1].ElementAt(j).Equals("THSST-1"))
                        dataGridViewDefSchedInfo.Rows[rowIndex].Cells[3].Value = string.Format("{0:HHmm}", dateTime) + " - " + string.Format("{0:HHmm}", dateTime.AddHours(1));
                    else
                        dataGridViewDefSchedInfo.Rows[rowIndex].Cells[3].Value = string.Format("{0:HHmm}", dateTime) + " - " + string.Format("{0:HHmm}", dateTime.AddHours(2));

                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[4].Value = list[4].ElementAt(j);

                    // Advisor
                    query = "select  p.lastName, p.firstName, p.mi from panelist p, thesisgroup t where p.panelistid = t.advisorid and t.thesisgroupid = " + list[0].ElementAt(j) + ";";
                    List<String>[] advisor = dbHandler.Select(query, 3);
                    if(advisor[0].Count() != 0)
                        dataGridViewDefSchedInfo.Rows[rowIndex].Cells[5].Value = advisor[0].ElementAt(0) + ", " + advisor[1].ElementAt(0) + " " + advisor[2].ElementAt(0) + ".";

                    // Panelists
                    query = "select p.lastName, p.firstName, p.mi from panelist p, panelassignment pa where pa.panelistid = p.panelistid and pa.thesisgroupid = " + list[0].ElementAt(j) + " order by p.lastname ;";
                    panelist = dbHandler.Select(query, 3);

                    String panelistCellText = "";
                    for (int k = 0; k < panelist[0].Count(); k++)
                    {
                        panelistCellText += panelist[0].ElementAt(k) + ", " + panelist[1].ElementAt(k) + " " + panelist[2].ElementAt(k) + ".";
                        if (k < panelist[0].Count() - 1)
                            panelistCellText += "\n";
                    }

                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[6].Value = panelistCellText;
                }
            }

            if (dataGridViewDefSchedInfo.Rows.Count == 0)
            {
                labelNoSchedulesFound.Visible = true;
                //MessageBox.Show("There are no defense schedules within the selected range", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonSave.Enabled = false;
            }
            else
            {
                labelNoSchedulesFound.Visible = false;
                buttonSave.Enabled = true;
            }
        }
        
        // Event Listeners
        private void DefenseSchedulesViewer_Load(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Value = DateTime.Now;
            buttonSave.Enabled = false;
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }
        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEndDate.Value = dateTimePickerStartDate.Value.AddDays(6);
        }
        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value.CompareTo(dateTimePickerStartDate.Value) < 0)
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveToFile();
        }
        
	    // Other Methods
        private bool CheckIfFileIsBeingUsed(string fileName)
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
        private void SaveToFile()
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

            if (saveFileDialog.FilterIndex < 4)
                isCSVfile = true;

            switch (saveFileDialog.FilterIndex)
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

            if (File.Exists(saveFileDialog.FileName))
                if (CheckIfFileIsBeingUsed(saveFileDialog.FileName))
                {
                    MessageBox.Show("File is currently in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
            {
                // Column Headers
                lineToWrite = "";

                if (saveCourseColumn)
                {
                    lineToWrite += "Course";
                    if (isCSVfile)
                        lineToWrite += ",";
                    else
                        lineToWrite += "\t";
                }
                if (isCSVfile)
                    lineToWrite += "title,date,time,venue,advisor";
                else
                    lineToWrite += "title\tdate\ttime\tvenue\tadvisor";
                if (savePanelColumn)
                {
                    if (isCSVfile)
                        lineToWrite += ",";
                    else
                        lineToWrite += "\t";
                    lineToWrite += "Panelists";
                }

                sw.WriteLine(lineToWrite);

                // Rows
                for (int i = 0; i < dataGridViewDefSchedInfo.Rows.Count; i++)
                {
                    lineToWrite = "";

                    if (saveCourseColumn)
                    {
                        lineToWrite += dataGridViewDefSchedInfo.Rows[i].Cells[0].Value;

                        if (isCSVfile)
                            lineToWrite += ",";
                        else
                            lineToWrite += "\t";
                    }

                    // index column
                    //   1    title
                    //   2    date
                    //   3    time
                    //   4    venue
                    //   5    advisor
                    for (int j = 1; j <= 5; j++)
                    {
                        lineToWrite += dataGridViewDefSchedInfo.Rows[i].Cells[j].Value;

                        if (j < 5 || savePanelColumn)
                            if (isCSVfile)
                                lineToWrite += ",";
                            else
                                lineToWrite += "\t";
                    }

                    if (savePanelColumn)
                    {
                        string[] panels = dataGridViewDefSchedInfo.Rows[i].Cells[6].Value.ToString().Split('\n');

                        for (int j = 0; j < panels.Count(); j++)
                        {
                            lineToWrite += "\"" + panels[j] + "\"";

                            if (j < panels.Count() - 1)
                                if (isCSVfile)
                                    lineToWrite += ",";
                                else
                                    lineToWrite += "\t";
                        }
                    }
                    sw.WriteLine(lineToWrite);
                }
                sw.Flush();
                sw.Close();
            }
        }
        
    }
}