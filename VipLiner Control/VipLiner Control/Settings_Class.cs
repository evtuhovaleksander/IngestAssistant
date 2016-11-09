using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Ingest_Assistant
{
    internal class SC2
    {
        // Настройки статические
        public Color Browser_Is_In_Archive_Dir;
        public Color Browser_Isnt_In_Work_Dir;
        public double Work_Max_Value;
        public double Arch_Max_Value;
        public Color Browser_Is_In_Archive_Dir_NOT_TODAY;
        public Color Browser_Isnt_In_Work_Dir_NOT_TODAY;
        public string Day_Work_Time;
        public string Admins;
        public int Max_Elements_For_DGV;


        public Color Group1Color;
        public Color Group2Color;
        public Color Group3Color;
        public Color Group4Color;
        public Color Group5Color;

        public string Main_Settings_Base_Path;
        public bool Alow_Logging;


        //Настройки динамические
        public string Work_Path;
        public string Stock_Path;
        public string Master_Path;
        public string Archive_Path;
        public string Shablon_Path;
        public string MetaBase_Way;
        public string Temp_Files_Directory;
        public string Base_Archive;
        public string Complete_Path;
        public string Additional_Work_Types;
        public string Log_Base_Path;
        public string Setting_Profile;
        public string Setting_Base_Path;
        public string Direct_Show_Adress;
        public Boolean WINDOWS;
        public string Path_Separator;
        public string Consolidate_Directories;

        public string cut(string inn)
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

        public SC2()
        {
            Browser_Is_In_Archive_Dir = Color.Green;
            Browser_Isnt_In_Work_Dir = Color.Red;
            Work_Max_Value = 3;
            Arch_Max_Value = 1;
            Browser_Is_In_Archive_Dir_NOT_TODAY = Color.Turquoise;
            Browser_Isnt_In_Work_Dir_NOT_TODAY = Color.Turquoise;
            Day_Work_Time = "30";
            Admins = "aevtuhov|ssavin|Александр|";
            Max_Elements_For_DGV = 500;


            Group1Color = Color.Gray;
            Group2Color = Color.Gray;
            Group3Color = Color.Gray;
            Group4Color = Color.Gray;
            Group5Color = Color.Gray;

            Main_Settings_Base_Path =
                "server = 127.0.0.1; database = ingestassistantsettingsbase; user id = root; password = root";
            Alow_Logging = true;
        }


        public void Load_settings(string base_path, string set_prof)
        {
            Setting_Profile = set_prof;
            string zapros = "";
            zapros = "Select Archive_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Archive_Path = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Shablon_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Shablon_Path = cut(SQL_Class.ReadValueString(zapros, base_path));



            zapros = "Select Work_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Work_Path = cut(SQL_Class.ReadValueString(zapros, base_path));


            zapros = "Select Stock_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Stock_Path = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Master_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Master_Path = cut(SQL_Class.ReadValueString(zapros, base_path));



            zapros = "Select Work_Max_Value from Settings where Name=" + "'" + Setting_Profile + "'";
            Work_Max_Value = Convert.ToInt32(cut(SQL_Class.ReadValueString(zapros, base_path)));

            zapros = "Select Arch_Max_Value from Settings where Name=" + "'" + Setting_Profile + "'";
            Arch_Max_Value = Convert.ToInt32(cut(SQL_Class.ReadValueString(zapros, base_path)));

            zapros = "Select Temp_Files_Directory from Settings where Name=" + "'" + Setting_Profile + "'";
            Temp_Files_Directory = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Base_Archive from Settings where Name=" + "'" + Setting_Profile + "'";
            Base_Archive = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Complete_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            Complete_Path = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Day_Work_Time from Settings where Name=" + "'" + Setting_Profile + "'";
            Day_Work_Time = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Additional_Work_Types from Settings where Name=" + "'" + Setting_Profile + "'";
            Additional_Work_Types = cut(SQL_Class.ReadValueString(zapros, base_path));


            zapros = "Select Log_Base_Way from Settings where Name=" + "'" + Setting_Profile + "'";
            Log_Base_Path = cut(SQL_Class.ReadValueString(zapros, base_path));

           

            zapros = "Select Direct_Show_Adress from Settings where Name=" + "'" + Setting_Profile + "'";
            Direct_Show_Adress = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Main_Base_Path from Settings where Name=" + "'" + Setting_Profile + "'";
            MetaBase_Way = cut(SQL_Class.ReadValueString(zapros, base_path));

            zapros = "Select Consolidate_Directories from Settings where Name=" + "'" + Setting_Profile + "'";
            Consolidate_Directories = cut(SQL_Class.ReadValueString(zapros, base_path));

      
        }

        public static void Init()
        {
            if (I == null) I = new SC2();
            I.Setting_Profile = "";
        }

        public static SC2 I;
        

    }
}
