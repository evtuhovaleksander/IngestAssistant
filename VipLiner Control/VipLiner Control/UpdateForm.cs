using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        public static Boolean run;

        public static Boolean Run_form()
        {
            run = false;
            UpdateForm frm = new UpdateForm();
            frm.ShowDialog();
            return run;
        }

        private void SF_Load(object sender, EventArgs e)
        {
            switch ( Update_Class.update_request())
            {
                case 1:
                    But.BackColor = Color.Yellow;
                    But.Text = "Желательно обновление";
                    Lauch_But.BackColor = Color.Yellow;
                    Update_But.BackColor = Color.Green;
                    break;
                case 2:
                    But.BackColor = Color.Red;
                    But.Text = "Обязательно обновление";
                    Lauch_But.BackColor = Color.Red;
                    Lauch_But.Enabled = false; 
                    Update_But.BackColor = Color.Green;
                break;
                case 0:
                But.BackColor = Color.Green;
                    run = true;
                    Close();
                break;
            }
           
        }

        private void But_Click(object sender, EventArgs e)
        {

        }

        private void Lauch_But_Click(object sender, EventArgs e)
        {
            run = true;
            Close();
            
        }

        private void Update_But_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory;
            string source = Properties.Settings.Default.Shablon_Path + "/Ingest Updater NG.exe";
            string dest = path + "/Ingest Updater NG.exe";
            if (File.Exists(Properties.Settings.Default.Shablon_Path + "/Ingest Updater NG.exe"))
            {
                if (!(File.Exists(dest)))
                {
                    File.Copy(source, dest);                   
                }
                
                Process.Start(dest);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                run = false;
            Close();
            }
           // File.Copy(Properties.Settings.Default.Shablon_Path + "/Ingest Updater NG.exe", path + "/Ingest Updater NG.exe");
           
            
        }

        


    }
}
