using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compiler_T3
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void picSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.Azerbaycan.ir");
            System.Diagnostics.Process.Start("www.Unixe.co.cc");
        }

        private void picEmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:Behzadkh@Hotmail.com");
        }

        private void About_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
