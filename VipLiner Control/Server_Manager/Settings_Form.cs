using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Manager
{
    public partial class Settings_Form : Form
    {
        public Settings_Form()
        {
            InitializeComponent();
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            work.Text = Properties.Settings.Default.Work_Path;
            arch.Text = Properties.Settings.Default.Arch_Path;
            stock.Text = Properties.Settings.Default.Stock_Path;
            master.Text = Properties.Settings.Default.Master_Path;
            basse.Text = Properties.Settings.Default.Base;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Properties.Settings.Default.Work_Path=work.Text;
             Properties.Settings.Default.Arch_Path=arch.Text;
            Properties.Settings.Default.Stock_Path=stock.Text;
            Properties.Settings.Default.Master_Path=master.Text;
            Properties.Settings.Default.Base=basse.Text;
            Properties.Settings.Default.Save();
        }
    }
}
