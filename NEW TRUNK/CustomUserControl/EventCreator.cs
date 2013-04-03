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
        DBce dbHandler = new DBce();

        public EventCreator()
        {
            InitializeComponent();
        }
    }
}
