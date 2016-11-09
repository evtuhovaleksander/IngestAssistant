using System;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class UpdateLog : Form
    {
        public UpdateLog()
        {
            InitializeComponent();
        }

        private void UpdateLog_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
    }
}