using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace introse
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            scheduleEditor2.containerParent = this;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("change tab to :" + tabControl1.TabIndex);
            //if (tabControl1.TabPages. .TabIndex == 0)
                freeTimeViewer.RefreshAll();
            //else if (tabControl1.TabIndex == 2)
                scheduleEditor2.RefreshTreeView();
        }

        private void freeTimeViewer_Load(object sender, EventArgs e)
        {

        }
    }
}