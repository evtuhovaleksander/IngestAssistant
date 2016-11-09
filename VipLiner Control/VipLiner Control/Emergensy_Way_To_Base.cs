using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Emergensy_Way_To_Base : Form
    {
        public Emergensy_Way_To_Base()
        {
            InitializeComponent();
        }

        private void Browse_But_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == OFD.ShowDialog())
            {
                if (File.Exists(OFD.FileName) && Path.GetExtension(OFD.FileName) == ".sdf")
                {
                    Way_text_box.Text = OFD.FileName;
                    Settings.Default.MetaBase_Way = OFD.FileName;
                    Settings.Default.Save();
                    Continue_But.Enabled = true;
                }
            }
        }

        private void Kill_Process_But_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Emergensy_Way_To_Base_Load(object sender, EventArgs e)
        {
            OFD.DefaultExt = ".sdf";
            OFD.FileName = Settings.Default.MetaBase_Way;
        }

        private void Continue_But_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}