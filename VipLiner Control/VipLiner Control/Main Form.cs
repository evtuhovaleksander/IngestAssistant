using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Deployment.Application;
using Ingest_Assistant.Properties;
using VipLiner_Control.Properties;

namespace Ingest_Assistant
{
    public partial class Main_Form : Form
    {
        


        private SQL_Class cl2;
        private SQL_Class cl3;
     //   private Browser Cur_Browser =null;

        public Main_Form()
        {
          //  if (!Profile_Settings.Aplication_Start()) Process.GetCurrentProcess().Kill();
            InitializeComponent();

            if (Settings.Default.AdminMode)
            {
               
                Admin_Button.BackColor = Color.Red;
                Admin_Button.Text = "Admin Mode";
                
            }
        }

        public void Activate_admin()
        {
            if (
                SQL_Class.ReadValueInt32("select L_Priority from login where L_ID=" + Settings.Default.User_ID,
                    Settings.Default.Setting_Base_Path) == 3)
            {
                Admin_Button.BackColor = Color.Red;
                Admin_Button.Text = "Admin Mode";
                Settings.Default.AdminMode = true;
                Settings.Default.Save();
            }
            else
            {

                if (PasswordForm.getAdminRights())
                {
                    Admin_Button.BackColor = Color.Red;
                    Admin_Button.Text = "Admin Mode";
                    Settings.Default.AdminMode = true;
                    Settings.Default.Save();
                }
                else
                {
                    Deactivate_admin();
                }
            }
        }

        public void Deactivate_admin()
        {
            Admin_Button.BackColor = Color.Gainsboro;
            Admin_Button.Text = "User Mode";
            Settings.Default.AdminMode = false;
            Settings.Default.Save();
        }



        public Version AssemblyVersion()
        {
            Version version=null;
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                version = ad.CurrentVersion;
                
            }
            return version;
        }








        private void Main_Form_Load(object sender, EventArgs e)
        {




            if (Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path.ToLower().Replace(" ", "") != Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path.ToLower().Replace(" ", ""))
            {
                setting_params.BackColor = Color.OrangeRed;
                setting_params.Text = "Идет работа с неосновной таблицей настроек!!!  Профиль:"+Ingest_Assistant.Properties.Settings.Default.Setting_Profile;
            }
            else
            {
                 setting_params.BackColor = Color.Green;
                 setting_params.Text = "Идет работа с основной таблицей настроек.  Профиль:" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile;
            }
           
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Width = SystemInformation.PrimaryMonitorSize.Width;
            Height = menuStrip1.Height + 50;
            Browser_Form_PANEL.Width = Width - File_Work_PANEL.Width;
         


       
            Log_Class.Login();

            try
            {
                Version_But.Text = "Ingest Assistant V " + AssemblyVersion().ToString(4); // 1.0.3.4 - get only major, minor, build, revision
            }
            catch (Exception)
            {

                throw;
            }
            RTimer.Start();
        }

        private void fileWorkFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browser.Browser_Primary_Start(this);
        }

        private void settingsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                Settings_Form.Form_Lauch(this);
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Process.GetCurrentProcess().Kill();
        }

      
        private void dataSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                MetaDataCorrection.Form_Lauch(this);
            }
            else
            {
                if (PasswordForm.getAdminRights()) MetaDataCorrection.Form_Lauch(this);
            }
            //
        }

      
        private void datesSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                MetaDatesCorrection.Form_Lauch(this);
            }
            else
            {
                if (PasswordForm.getAdminRights()) MetaDatesCorrection.Form_Lauch(this);
            }
            // if (!AdminMOD) if (PasswordForm.Ask_Permission() || AdminMOD) MetaDatesCorrection.Form_Lauch(this);
        }

       

        private void Main_Form_SizeChanged(object sender, EventArgs e)
        {
            Browser.RefreshForms();
        }

        private void созданиеРапортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
      Raport_Form.Form_Lauch();
        }

        private void просмотрБазыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new Base_Show(this);
            frm.Show();
        }

        private void Admin_Button_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                Deactivate_admin();
            }
            else
            {
                Activate_admin();
            }
        }

        private void резервноеАрхивированиеБазыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Base_Administration();
            //frm.Show();
        }

        private void редактированиеБазыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                var frm = new Base_Show_Pro();
                frm.Show();
            }
            else
            {
                if (PasswordForm.getAdminRights())
                {
                    var frm = new Base_Show_Pro();
                    frm.Show();
                }
            }
        }

      
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                var frm = new Log_Show();
                frm.Show();
            }
            else
            {
                if (PasswordForm.getAdminRights())
                {
                    var frm = new Log_Show();
                    frm.Show();
                }
            }
        }

        private void папкаWORKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Ingest_Assistant.Properties.Settings.Default.Work_Path);
        }

        private void папкаARCHIVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Ingest_Assistant.Properties.Settings.Default.Archive_Path);
        }

        private void папкаSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Ingest_Assistant.Properties.Settings.Default.Stock_Path);
        }

        private void папкаMASTERPREPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Ingest_Assistant.Properties.Settings.Default.Master_Path);
        }

        private void папкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start( (Ingest_Assistant.Properties.Settings.Default.Work_Path+ "\\Raport"));
        }

        private void папкаTEMPFILESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory);
        }

        private void папкаSHABLONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AdminMode)
            {
                Process.Start(Ingest_Assistant.Properties.Settings.Default.Shablon_Path);
            }
            else
            {
                if (PasswordForm.getAdminRights())
                {
                    Process.Start(Ingest_Assistant.Properties.Settings.Default.Shablon_Path);
                }
            }
        }

       

        private void setting_params_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path + "\n" + "Profile:" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile);
        }

       

        private void conversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conversion_form frm = new conversion_form();
            frm.ShowDialog();
        }

        private void папкаCOMPLETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Complete_Path);
        }

        private void Version_But_Click(object sender, EventArgs e)
        {
            Version_But.Text = "Ingest Assistant V " + AssemblyVersion().ToString(4); // 1.0.3.4 - get only major, minor, build, revision

            string str = AssemblyVersion().ToString(4);
            string path = "\\\\10.2.68.19\\Work\\Assistant Complex Instalation Pack\\Ingest Assistant\\Application Files";
            string[] mas = Directory.GetDirectories(path);
            string cur = str.Substring(6);
            int c = Convert.ToInt32(cur);
            int max = 0;
            foreach (var tmp in mas)
            {
                string pr=Path.GetFileName(tmp);
                pr = pr.Substring(23);
                int p = Convert.ToInt32(pr);
                if (p >= max) max = p;
            }


            if (max > c)
                MessageBox.Show(
                    "ВНИМАНИЕ!!!!! \n ОБНАРУЖЕННА НОВАЯ ВЕРСИЯ ПРОГРАММЫ !!!! \n ТРЕБУЕТСЯ ЗАКРЫТЬ ТЕКУЩИЙ ЭКЗЕМПЛЯР ПРОГРАММЫ И ПРОВЕСТИ ОБНОВЛЕНИЕ!!!!!!!!! ");
        }


        private int i = 0;

        private void RTimer_Tick(object sender, EventArgs e)
        {
            if (i < 60)
            {
                Version_But.Text = i + "/60";
                i++;
                Refresh();
            }
            else
            {
                try
                {
                    Version_But.Text = "Ingest Assistant V " + AssemblyVersion().ToString(4);
                    // 1.0.3.4 - get only major, minor, build, revision

                    string str = AssemblyVersion().ToString(4);
                    string path =
                        "\\\\10.2.68.19\\Work\\Assistant Complex Instalation Pack\\Ingest Assistant\\Application Files";
                    string[] mas = Directory.GetDirectories(path);
                    string cur = str.Substring(6);
                    int c = Convert.ToInt32(cur);
                    int max = 0;
                    foreach (var tmp in mas)
                    {
                        string pr = Path.GetFileName(tmp);
                        pr = pr.Substring(23);
                        int p = Convert.ToInt32(pr);
                        if (p >= max) max = p;
                    }


                    if (max > c)
                        MessageBox.Show(
                            "ВНИМАНИЕ!!!!! \n ОБНАРУЖЕННА НОВАЯ ВЕРСИЯ ПРОГРАММЫ !!!! \n ТРЕБУЕТСЯ ЗАКРЫТЬ ТЕКУЩИЙ ЭКЗЕМПЛЯР ПРОГРАММЫ И ПРОВЕСТИ ОБНОВЛЕНИЕ!!!!!!!!! ");
                    Refresh();
                }
                catch (Exception)
                {
                    
                    
                }
                i = 0;

                
            }

        }

        bool alert = false;
    }
}