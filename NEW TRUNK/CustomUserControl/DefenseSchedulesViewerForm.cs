﻿using System;
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
    public partial class DefenseSchedulesViewerForm : Form
    {
        DBce dbHandler;

        public DefenseSchedulesViewerForm()
        {
            InitializeComponent();
            dbHandler = new DBce();
            Show();
        }

        // Refreshers
        private void RefreshDataGridView()
        {
            String query;
            List<String>[] list;
            List<String>[] panelist;
            int rowIndex;

            //Course, Title, Date, Time, Venue, Adviser, Panels
            dataGridViewDefSchedInfo.Rows.Clear();
            rowIndex = 0;

            // Building the query string
            query = "select t.thesisgroupid, t.course, t.title, d.defensedatetime, d.place, d.defensetype from defenseschedule d, thesisgroup t where d.thesisgroupid = t.thesisgroupid";
            
            if (checkBoxTHSST1.Checked && checkBoxTHSST3.Checked);
            else if (checkBoxTHSST1.Checked)
                query += " and t.course = 'THSST-1'";
            else if (checkBoxTHSST3.Checked)
                query += " and t.course = 'THSST-3'";
            else
            {
                labelNotice.Text = "No Course Included";
                return;
            }
            if (checkBoxDefense.Checked && checkBoxRedefense.Checked);
            else if (checkBoxDefense.Checked)
                query += " and d.defensetype = 'Defense'";
            else if (checkBoxRedefense.Checked)
                query += " and d.defensetype = 'Redefense'";
            else
            {
                labelNotice.Text = "No Defense Type Included";
                return;
            }

            query += " order by t.course, t.section, d.defensedatetime;";

                
                list = dbHandler.Select(query, 6);

                for (int j = 0; j < list[0].Count(); j++, rowIndex++)
                {
                    dataGridViewDefSchedInfo.Rows.Add();
                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[0].Value = list[1].ElementAt(j);
                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[1].Value = list[2].ElementAt(j);

                    DateTime dateTime = Convert.ToDateTime(list[3].ElementAt(j));

                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[2].Value = String.Format("{0:M/d/yyyy}", dateTime);

                    if (list[1].ElementAt(j).Equals("THSST-1"))
                        dataGridViewDefSchedInfo.Rows[rowIndex].Cells[3].Value = String.Format("{0:HHmm}", dateTime) + " - " + String.Format("{0:HHmm}", dateTime.AddHours(1));
                    else
                        dataGridViewDefSchedInfo.Rows[rowIndex].Cells[3].Value = String.Format("{0:HHmm}", dateTime) + " - " + String.Format("{0:HHmm}", dateTime.AddHours(2));

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
                    dataGridViewDefSchedInfo.Rows[rowIndex].Cells[7].Value = list[5].ElementAt(j);
            }

            if (dataGridViewDefSchedInfo.Rows.Count == 0)
            {
                labelNotice.Text = "No Defense Schedules found";
                buttonSave.Enabled = false;
            }
            else
            {
                labelNotice.Text = "";
                buttonSave.Enabled = true;
            }
        }
        
        // Event Listeners
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveToFile();
        }
        
	    // Other Methods
        private bool CheckIfFileIsBeingUsed(String fileName)
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

            String lineToWrite;

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
                    lineToWrite += "Title,Date,Time,Venue";
                else
                    lineToWrite += "Title\tDate\tTime\tVenue";
                if (savePanelColumn)
                {
                    if (isCSVfile)
                        lineToWrite += ",Advisor,Panelist 1,Panelist 2,Panelist 3,Panelist 4";
                    else
                        lineToWrite += ",Advisor\tPanelist 1\tPanelist 2\tPanelist 3,\tPanelist 4";
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
                    for (int j = 1; j <= 4; j++)
                    {
                        lineToWrite += dataGridViewDefSchedInfo.Rows[i].Cells[j].Value;

                        if (j < 4 || savePanelColumn)
                            if (isCSVfile)
                                lineToWrite += ",";
                            else
                                lineToWrite += "\t";
                    }

                    if (savePanelColumn)
                    {
                        if(isCSVfile)
                            lineToWrite += "\""+dataGridViewDefSchedInfo.Rows[i].Cells[5].Value + "\",";
                        else
                            lineToWrite += "\""+dataGridViewDefSchedInfo.Rows[i].Cells[5].Value + "\"\t";
                        
                        String[] panels = dataGridViewDefSchedInfo.Rows[i].Cells[6].Value.ToString().Split('\n');

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

        private void DefenseSchedulesViewerForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
    }
}