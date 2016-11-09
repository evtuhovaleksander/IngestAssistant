using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using System.IO;
using System.Linq;
using Ingest_Assistant.Properties;
using VipLiner_Control.Properties;

namespace Ingest_Assistant 
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.Base_Show_Setting_Set == "")
            {
                Properties.Settings.Default.Base_Show_Setting_Set = "t1|#t2|#t3|#t4|#t5|#t6|#t7|#t8|#t9|#t10|#"; Properties.Settings.Default.Save();
            }
            var proceses = Process.GetProcessesByName("Ingest Assistant");

            if (proceses.Length <2)
            {
             Ingest_Assistant.Properties.Settings.Default.Setting_Profile = "";
              if (Profile_Settings.Aplication_Start(SQL_Class.check_connection(Settings.Default.Setting_Base_Path)))///(Pre_Lauch_Form.Check_Server_Show_Pre_Form()))
                {

                    string path = Directory.GetCurrentDirectory();
                    byte[] bytemas = Properties.Resources.MediaInfo;
                    path += "\\MediaInfo.dll";
                    if (File.Exists(path)) FileM.Delete(path);
                    FileStream fstream = new FileStream(path, FileMode.OpenOrCreate);
                    fstream.Write(bytemas, 0, bytemas.Length);
                    fstream.Close();
                    fstream.Dispose();

                   // Settings.Default.WorkFormLoaded = false;
                    Application.Run(new Main_Form());
                    goto restart;
                }
                

            }
            else
            {
                MessageBox.Show("Одна копия программы уже запущенна");
            }

            goto end;
            restart:
            if (Profile_Settings.Aplication_Start(true))
            {
                
                Application.Run(new Main_Form());
                goto restart;
            }

          

            end:
            ;

        }
    }
}