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
using Ingest_Assistant.Properties;
using VipLiner_Control.Properties;

namespace Ingest_Assistant
{
    public partial class Profile_Settings : Form
    {
        private string[] Profiles_Mas;
        public Boolean alow_work;


      

        public static Boolean Aplication_Start(Boolean Server_Test)
        {
           
            Profile_Settings frm = new Profile_Settings();
         
           

            if (!Server_Test)
            {
                MessageBox.Show("Проблемы с сетью. Необходимо вручную указать путь к серверу");
                frm.Emergensy_Import.BackColor = Color.Red;
                frm.Emergensy_Import.Visible = true;
            }
            else
            {
                frm.newGetProfiles();
                Ingest_Assistant.Properties.Settings.Default.Setting_Profile = "";
                Properties.Settings.Default.Save();
               
            }
        
           frm.ShowDialog();
            return frm.alow_work;
        }

        public void newGetProfiles()
        {

            string zap = "Select L_ID, L_AvalibleProfiles,  L_FullName,L_Priority  from login where(L_Priority!=2 AND L_UserNames like '%" + Environment.UserName + "%')";
            SQL_Class cl=SQL_Class.Create_class(Settings.Default.Setting_Base_Path);
            SQL_Class.ReadValues(zap,ref cl);
            //object obj = SQL_Class.ReadValue(zap, Settings.Default.Setting_Base_Path);
            if (!cl.SQL_DataReader.HasRows)
            {
                MessageBox.Show("Login table doesn't contain user name :" + Environment.UserName);
                Load_Profile_But.Enabled = false;
            }
            else
            {
                cl.SQL_DataReader.Read();
                Loged_as.Text = cl.SQL_DataReader.GetString(2);
                if ( cl.SQL_DataReader.GetInt32(3)== 3)
                {
                    System_Settings_Change_Button.Visible = true;
                    Settings.Default.AdminMode = true;
                }
                BP.Text = Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path;
                string who_can_use = cl.SQL_DataReader.GetString(1);
                Queue<string> mas = new Queue<string>();
                int col = SQL_Class.ReadValueInt32("Select Count(*) from Settings", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                for (int i = 0; i <= col; i++)
                {
                    if (who_can_use.Contains(i.ToString()))
                    {
                        string reader =
                                            SQL_Class.ReadValueString("Select Name from Settings where (ID=" + i + "  and Avalible=1)",
                                                Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                        if (reader != "") mas.Enqueue(reader);
                    }


                }

                Profiles_Mas = new string[mas.Count];

                for (int i = 0; i < Profiles_Mas.Length; i++)
                {
                    Profiles_Mas[i] = mas.Dequeue();
                }
                Profiles_CmBox.DataSource = Profiles_Mas;
                alow_work = false;
                Load_Profile_But.Enabled = true;
                Settings.Default.User_ID = cl.SQL_DataReader.GetInt32(0);
                Settings.Default.Save();
                cl.Manualy_Close_Connection();
                
            }
        }

        //public void Constructor()
        //{

        //    while (!PasswordForm.LOGIN())
        //    {

        //    }

        //    Loged_as.Text =
        //        SQL_Class.ReadValueString(
        //            "Select L_FullName from login where L_ID=" + Properties.Settings.Default.User_ID,
        //            Properties.Settings.Default.Setting_Base_Path);




        //    if (SQL_Class.ReadValueInt32("select L_Priority from login where L_ID=" + Properties.Settings.Default.User_ID, Settings.Default.Setting_Base_Path)==3)
        //    {
        //        System_Settings_Change_Button.Visible = true;
        //    }

        //    BP.Text = Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path;
        //    if (BP.Text != Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path)
        //    {
        //        BP.BackColor = Color.OrangeRed;
        //    }
        //    else
        //    {
        //        BP.BackColor = Color.LawnGreen;
        //    }





        //    string who_can_use =
        //            SQL_Class.ReadValueString("Select L_AvalibleProfiles from login where (L_ID=" + Properties.Settings.Default.User_ID + ")",
        //                Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);



        //    Queue<string> mas = new Queue<string>();
        //    int col = SQL_Class.ReadValueInt32("Select Count(*) from Settings", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
        //    for (int i = 0; i <= col; i++)
        //    {
        //        if (who_can_use.Contains(i.ToString()))
        //        {
        //            string reader =
        //                                SQL_Class.ReadValueString("Select Name from Settings where (ID=" + i + "  and Avalible=1)",
        //                                    Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
        //            if (reader != "") mas.Enqueue(reader);
        //        }
                

        //    }

        //    Profiles_Mas = new string[mas.Count];

        //    for (int i = 0; i < Profiles_Mas.Length; i++)
        //    {
        //        Profiles_Mas[i] = mas.Dequeue();
        //    }
        //    Profiles_CmBox.DataSource = Profiles_Mas;
        //    alow_work = false;
        //}

        public Profile_Settings()
        {
           
            InitializeComponent();
        }

        //private void Change_Unlock_But_Click(object sender, EventArgs e)
        //{
        //    Change_Unlock_But.Visible = false;
        //}

        private void Profile_Settings_Load(object sender, EventArgs e)
        {
            
            if (!SQL_Class.check_connection(Settings.Default.Setting_Base_Path))
            {

                if (SQL_Class.check_connection(Settings.Default.Main_Settings_Base_Path))
                {
                    Settings.Default.Setting_Base_Path = Settings.Default.Main_Settings_Base_Path;
                    Settings.Default.Save();
                }
            }

        }

      

        //public string cut(string inn)
        //{
        //    var pos = 0;
        //    var leng = inn.Length;
        //    for (var i = leng - 1; i > -1; i--)
        //    {
        //        if (inn[i] != ' ')
        //        {
        //            pos = i;
        //            break;
        //        }
        //    }

        //    var outt = "";

        //    for (var i = 0; i <= pos; i++)
        //    {
        //        outt += inn[i];
        //    }

        //    return outt;
        //}

     
        //private void Load_Profile_But_Click(object sender, EventArgs e)
        //{
        //    Curent_Profile_TBox.Text = Profiles_CmBox.SelectedItem.ToString();
        //    Profile_Check();


        //    try
        //    {

        //        Ingest_Assistant.Properties.Settings.Default.Setting_Profile = Curent_Profile_TBox.Text;
        //        Ingest_Assistant.Properties.Settings.Default.Profile_ID = SQL_Class.ReadValueInt32("select ID from settings where name ='" + Curent_Profile_TBox.Text + "'", Properties.Settings.Default.Setting_Base_Path);
        //        Settings.Default.Save();
        //        Settings_Form.Import_settings();
        //        // Ingest_Assistant.Properties.Settings.Default.Load_settings(Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path,Ingest_Assistant.Properties.Settings.Default.Setting_Profile);

        //        alow_work = true;
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.ToString());
        //        alow_work = false;
        //    }
        //    Close();


        //}

      
        private void System_Settings_Change_Button_Click(object sender, EventArgs e)
        {
            System_Settings_Form frm=new System_Settings_Form();
            frm.ShowDialog();
        }

        private void Emergensy_Import_Click(object sender, EventArgs e)
        {
            string con_string = Get_Connection_To_Server_String.get_conection_string();
            if(SQL_Class.check_connection(con_string))
            
                    {
                        Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path = con_string;
                       Ingest_Assistant.Properties.Settings.Default.Save();
                        Emergensy_Import.Visible = false;
                        newGetProfiles();
                    }
        }

        private void Hand_Emergensy_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Проблемы с сетью. Необходимо вручную указать путь к серверу");
                  Emergensy_Import.BackColor = Color.Red;
                  Emergensy_Import.Visible = true;
                    
          
        }

        private void Load_Profile_But_Click(object sender, EventArgs e)
        {
            try
            {
                Ingest_Assistant.Properties.Settings.Default.Setting_Profile = Profiles_CmBox.SelectedItem.ToString();
                Ingest_Assistant.Properties.Settings.Default.Profile_ID = SQL_Class.ReadValueInt32("select ID from settings where name ='" + Profiles_CmBox.SelectedItem.ToString() + "'", Properties.Settings.Default.Setting_Base_Path);
                // Ingest_Assistant.Properties.Settings.Default.Profile_ID = SQL_Class.ReadValueInt32("select ID from settings where name ='" + Curent_Profile_TBox.Text + "'", Properties.Settings.Default.Setting_Base_Path);
                Settings.Default.Save();
                Settings_Form.Import_settings();
                alow_work = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                alow_work = false;
            }
            Close();
        }

      

      



       
    }
}
