using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ingest_Assistant;
using Ingest_Assistant.Properties;


namespace VipLiner_Control.Properties
{
    public partial class Settings_Form : Form
    {
        private Base_Setting[] Loaded_From_Base;

        public Settings_Form()
        {
            InitializeComponent();


            tbp1_prepeare();
            Data_Base_Path_TBox.Text = Ingest_Assistant.Properties.Settings.Default.MetaBase_Way;
        }

        public static void Form_Lauch(Main_Form parent)
        {
            var form = new Settings_Form();
            form.StartPosition = FormStartPosition.Manual;

            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.Show();
        }

    



      
        private void Settings_Form_Load(object sender, EventArgs e)
        {
        }

        private void tbp1_prepeare()
        {
            MasterWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Master_Path;
            WorkWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Work_Path;
            StockWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Stock_Path;
          
            ArchiveWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Archive_Path;
       
            ShablonWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Shablon_Path;
            logs.Text = Ingest_Assistant.Properties.Settings.Default.Log_Base_Path;
            settings.Text = Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path;

            Data_Base_Path_TBox.Text = Ingest_Assistant.Properties.Settings.Default.MetaBase_Way;
         //   DefaultSetFile_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Setting_File_Path;
            W_Limit_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Work_Max_Value.ToString();
            A_Limit_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Arch_Max_Value.ToString();
        }

        public void settings_show()
        {
            MasterWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Master_Path;
            WorkWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Work_Path;
            StockWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Stock_Path;
            ArchiveWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Archive_Path;
            ShablonWay_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Shablon_Path;
            Data_Base_Path_TBox.Text = Ingest_Assistant.Properties.Settings.Default.MetaBase_Way;
          //  DefaultSetFile_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Setting_File_Path;
            W_Limit_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Work_Max_Value.ToString();
            A_Limit_TBox.Text = Ingest_Assistant.Properties.Settings.Default.Arch_Max_Value.ToString();
        }

    
     

      
        

      

      

        public static string cut(string inn)
        {
            var pos = 0;
            var leng = inn.Length;
            for (var i = leng - 1; i > -1; i--)
            {
                if (inn[i] != ' ')
                {
                    pos = i;
                    break;
                }
            }

            var outt = "";

            for (var i = 0; i <= pos; i++)
            {
                outt += inn[i];
            }

            return outt;
        }

        public static void Import_settings()
        {
            string zapros;

           

            zapros = "Select Archive_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Archive_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Shablon_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Shablon_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));



            zapros = "Select Work_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Work_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));


            zapros = "Select Stock_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Stock_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Master_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Master_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));



            zapros = "Select Work_Max_Value from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Work_Max_Value = Convert.ToInt32(cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path)));

            zapros = "Select Arch_Max_Value from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Arch_Max_Value = Convert.ToInt32(cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path)));

            zapros = "Select Temp_Files_Directory from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Base_Archive from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Base_Archive = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Complete_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Complete_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Day_Work_Time from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Day_Work_Time = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Additional_Work_Types from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Additional_Work_Types = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));


          

            zapros = "Select Log_Base_Way from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Log_Base_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Direct_Show_Adress from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Direct_Show_Adress = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Main_Base_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.MetaBase_Way = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));



            


            zapros = "Select Consolidate_Directories from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Consolidate_Directories = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select MetaData from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.MetaData = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));
            
            
            zapros = "Select MetaDate from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.MetaDate = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select Reservations from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Reservations = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));


            zapros = "Select OtherWorkFileTypes from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.Other_Work_File_Types = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));

            zapros = "Select XML_Editor_Path from Settings where Name=" + "'" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + "'";
            Ingest_Assistant.Properties.Settings.Default.XML_Editor_Path = cut(SQL_Class.ReadValueString(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));
            
            
            Ingest_Assistant.Properties.Settings.Default.Save();
            


       
        }

       
        public struct Base_Setting
        {
            public Boolean add;
            public Boolean correct;
            public Boolean delete;
            public int id;
            public string name;
            public string name_rus;
            public string seting;
        }

      
    }
}