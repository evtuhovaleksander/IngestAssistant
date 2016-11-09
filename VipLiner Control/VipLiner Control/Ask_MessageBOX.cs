using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class Ask_MessageBOX : Form
    {
       public Boolean ret;
        public Ask_MessageBOX()
        {
            InitializeComponent();
        }

        private void YES_But_Click(object sender, EventArgs e)
        {
            ret = true;
            Close();
        }

        private void NO_But_Click(object sender, EventArgs e)
        {
            ret = false;
            Close();
        }

        public static Boolean Ask_Question(string text)
        {
            Ask_MessageBOX frm = new Ask_MessageBOX();
            frm.Message_TBox.Text = text;
            frm.ShowDialog();
            return frm.ret;
        }
    }
}
