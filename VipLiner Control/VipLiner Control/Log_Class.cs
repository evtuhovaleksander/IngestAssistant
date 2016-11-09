using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ingest_Assistant.Properties;
using System.IO;
namespace Ingest_Assistant
{
    abstract class Log_Class :SQL_Class
    {
        public static void Copy(string Viplanner, string from, string to)
        {
            string zapros;

            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла c переименованием','Копирование файла c переименованием из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "',1,0)";
            }
            else
            {
                zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла','Копирование файла из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "',1,0)";
            }


            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }






        public static void Move(string Viplanner, string from, string to)
        {
            string zapros = "";
            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
                {


                    zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование Файла','Переименование Файла  из " +
                             Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                             "','" + Path.GetDirectoryName(from) + "','" +
                             Path.GetDirectoryName(to) + "',1,0)";
                }
                else
                {


                    zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла c переименованием','Перемещение файла c переименованием из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "',1,0)";
                }
            }
            else
            {


                zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла','Перемещение файла из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "',1,0)";


            }

            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Move_Dir(string Viplanner, string from, string to)
        {
            string zapros = "";
            if (Path.GetDirectoryName(from) != Path.GetDirectoryName(to))
            {
                if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
                {
                    ////  zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Переименование Файла  из " +
                    //           Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                    //           "','" + Path.GetDirectoryName(from) + "','" +
                    //           Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
                    //           DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";

                    zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование папки','Переименование папки  из " +
                             Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                             "','" + Path.GetDirectoryName(from) + "','" +
                             Path.GetDirectoryName(to) + "',1,0)";
                }
                else
                {
                    //zapros =
                    //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла c переименованием из " +
                    //    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                    //    "','" + Path.GetDirectoryName(from) + "','" +
                    //    Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
                    //    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";

                    zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки c переименованием','Перемещение папки c переименованием из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "',1,0)";
                }
            }
            else
            {
                //zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла " +
                //         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','" +
                //         Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
                //         DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";

                zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки','Перемещение папки из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "',1,0)";


            }

            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Create(string Viplanner, string to)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание файла " +
            //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";



            var zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание файла','Создание файла " +

                              Path.GetFileName(to) + "','','" +
                              Path.GetDirectoryName(to) + "',1,0)";

            //
            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Create_Dir(string Viplanner, string to)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание директории " +
            //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";

            var zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание папки','Создание папки " +

                             Path.GetFileName(to) + "','','" +
                             Path.GetDirectoryName(to) + "',1,0)";
            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Delete(string Viplanner, string from)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление файла " +
            //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";



            var zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

                             Path.GetFileName(from) + "','" +
                             Path.GetDirectoryName(from) + "','',1,0)";
            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Delete_Dir(string Viplanner, string from)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление директории " +
            //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";


            var zapros = "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

                             Path.GetFileName(from) + "','" +
                             Path.GetDirectoryName(from) + "','',1,0)";

            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static void Login()
        {
            //var zapros =
            //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь зашел в систему','','','" +
            //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";

            var zapros =
                "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('','" +
                DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" +
                Environment.UserName + "','" + Environment.MachineName + "',1,'Login (" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + ")','Login (" + Ingest_Assistant.Properties.Settings.Default.Setting_Profile + ")" +
                Environment.UserDomainName + "__" + Environment.UserName + "','','',1,0)";



            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
            Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);




        }

        public static void Logout()
        {
            //var zapros =
            //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь вышел из системы','','','" +
            //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')";


            var zapros =
               "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Description,Name,Fromm,Too,Finished,F_ID) VALUES ('','" +
               DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "','" + Environment.UserDomainName + "__" +
               Environment.UserName + "','" + Environment.MachineName + "',1,'Logout','Logout  " +
               Environment.UserDomainName + "__" + Environment.UserName + "','','',1,0)";



            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
            //  if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static long VAction(string Viplanner, string info, int group)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
           

            var zapros =
                           "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Name,Description,Fromm,Too,Finished,F_ID) VALUES ('" + Viplanner + "','" +
                           time + "','" + Environment.UserDomainName + "__" +
                           Environment.UserName + "','" + Environment.MachineName + "'," + group + ",'" + info + "','','','',0,0)";




            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);

            zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
            return  Convert.ToInt64(SQL_Class.ReadValue(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));

        }

        public static void ReWrite_Start(long start, long stop)
        {
            //string ishod = SQL_Class.ReadValue("Select Name from Logs Where ID=" + start, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path).ToString();
            //  ishod += " (" + stop + ")";
            string zapros = "Update Logs SET Finished =1,F_ID=" + stop + " where ID=" + start;
            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
        }

        public static long Action(string info, int group)
        {
            string time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'" + info + "','','','" +
            //             Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" + time +
            //             "')";

            var zapros =
                           "INSERT INTO Logs (VP,Time,Userr,PC,Groupp,Name,Description,Fromm,Too,Finished,F_ID) VALUES ('','" +
                           time + "','" + Environment.UserDomainName + "__" +
                           Environment.UserName + "','" + Environment.MachineName + "'," + group + ",'" + info + "','' ,'','',0,0)";




            if (Ingest_Assistant.Properties.Settings.Default.Alow_Logging) Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);

             zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
            return Convert.ToInt64(SQL_Class.ReadValue(zapros, Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));
        }
    }
}
