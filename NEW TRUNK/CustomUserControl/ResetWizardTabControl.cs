﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CustomUserControl
{
    class ResetWizardTabControl : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // Hide tabs
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

        protected override void OnKeyDown(KeyEventArgs ke)
        {
            // Blocks Ctrl+Tab and Ctrl+Shift+Tab hotkeys
            if (ke.Control && ke.KeyCode == Keys.Tab)
                return;
            base.OnKeyDown(ke);
        }
    }
}
