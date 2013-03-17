using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                richTextBox1.Text = "";
                labelDisplayMsg.Text = "Invalid range. Make sure the first date is before or the same as the second.";
            }
        }

        private void printSchedule(DateTime start, DateTime end)
        {
            String query;
            List<String>[] list;
            List<String>[] panelist;

            richTextBox1.Text = "";
            String text;

            for (DateTime i = start; i.CompareTo(end) != 1; i = i.AddDays(1))
            {
                text = "";
                if (!i.DayOfWeek.ToString().Equals("Sunday"))
                {
                    query = "select t.thesisgroupid, t.course, t.section, t.title, d.defensedatetime, d.place from defenseschedule d, thesisgroup t where d.thesisgroupid = t.thesisgroupid";
                    query += " and datepart(yyyy,d.defensedatetime) =" + i.Year + " and datepart(mm,d.defensedatetime) =" + i.Month + " and datepart(dd,d.defensedatetime) =" + i.Day + " order by t.course, t.section, d.defensedatetime;";

                    list = dbHandler.Select(query, 6);

                    if (list[0].Count != 0)
                    {

                        text += i.Date + " (" + i.DayOfWeek + ")\n";
                        for (int j = 0; j < list[0].Count; j++)
                        {
                            //Console.WriteLine(list[3].ElementAt(j));
                            text += "\t" + list[3].ElementAt(j) + "\n\t";
                            text += list[1].ElementAt(j) + " " + list[2].ElementAt(j) + "\n\t";
                            text += list[4].ElementAt(j) + " " + list[5].ElementAt(j) + "\n\t\t";
                            query = "select p.firstName, p.MI, p.lastName from panelist p, panelassignment pa where pa.panelistid = p.panelistid and pa.thesisgroupid = " + list[0].ElementAt(j) + ";";
                            panelist = dbHandler.Select(query, 3);
                            //Console.WriteLine(2);
                            text += panelist[0].ElementAt(0) + " " + panelist[1].ElementAt(0) + ". " + panelist[2].ElementAt(0) + "\n\t\t";
                            text += panelist[0].ElementAt(1) + " " + panelist[1].ElementAt(1) + ". " + panelist[2].ElementAt(1) + "\n\t\t";
                            text += panelist[0].ElementAt(2) + " " + panelist[1].ElementAt(2) + ". " + panelist[2].ElementAt(2) + "\n";
                        }
                    }
                    richTextBox1.Text += text;
                }
            }

            if (richTextBox1.Text.Equals(""))
                richTextBox1.Text = "There are no defense schedules within this range.";

        }

      
    }
}
