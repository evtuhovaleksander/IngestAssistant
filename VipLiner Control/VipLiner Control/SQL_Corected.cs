using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Ingest_Assistant.Properties;

namespace Ingest_Assistant 
{
    

    internal class Log_SQL
    {

        public SqlCeConnection SQL_Connection;
        public SqlCeDataReader SQL_DataReader;

        public void Manualy_Close_Connection()
        {
            if (SQL_Connection.State == ConnectionState.Open)
            {
                SQL_Connection.Close();
            }
        }

        public void Create_Connection(string base_path)
        {

            if (!File.Exists(base_path))
            {
                MessageBox.Show("Не указан путь к базе данных", "Фатальная ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                var frm = new Emergensy_Way_To_Base();
                frm.ShowDialog();
            }

            var conString = "DataSource=" + base_path;
            SQL_Connection = new SqlCeConnection(conString);
        }

        private Boolean Open_Connection()
        {
            try
            {
                if (SQL_Connection.State == ConnectionState.Closed)
                {
                   
                    SQL_Connection.Open();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static int ReadValueInt32(string s, string base_path)
        {
            return Convert.ToInt32(ReadValue(s, base_path));
        }

        public static Boolean ReadValueBoolean(string s, string base_path)
        {
            return Convert.ToBoolean(ReadValue(s, base_path));
        }

        public static string ReadValueString(string s, string base_path)
        {
            return Convert.ToString(ReadValue(s, base_path));
        }



        public static Boolean ReadValueMain(string s, string base_path, ref object obj, ref Log_SQL Log_SQL)
        {
            try
            {
              
                if (!Log_SQL.Open_Connection()) return false;
                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return false;
                var temp = new SqlCeCommand(s, Log_SQL.SQL_Connection);
                var reader = temp.ExecuteReader();
                obj = temp.ExecuteScalar();
                Log_SQL.Manualy_Close_Connection();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static object ReadValue(string s, string base_path)
        {
            DateTime st = DateTime.Now;
            string dir = Path.GetDirectoryName(base_path) + "\\" + Environment.UserName;
            string new_bp = "";
            if (Path.GetFileName(base_path) == "IngestAssistant.sdf")
            {
                new_bp = dir + "\\IABase.sdf";
            }
            else
            {
                new_bp = dir + "\\LogBase.sdf";
            }

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!Copy_Operation(base_path, new_bp)) return null;



            Log_SQL sql_c = new Log_SQL();
            sql_c.Create_Connection(base_path);



            object Ret = new object();
            int i = 0;
            Boolean executed = false;







            while (!executed && (i < Settings.Default.Tries))
            {
                if (ReadValueMain(s, base_path, ref Ret, ref sql_c)) executed = true;
                i++;
                Thread.Sleep(100);
            }

            if (executed == false)
            {
                sql_c.Manualy_Close_Connection();
                TimeSpan dl = st - DateTime.Now;
                MessageBox.Show("Log wasn't readen : " + s + "\n    After tries " + Settings.Default.Tries + "\n Time spent " + dl.ToString("c"));
                return null;
            }
            return Ret;

        }





        public static Boolean Copy_Operation(string from, string to)
        {
            int i = 0;
            Boolean executed = false;





            while (!executed && (i < Settings.Default.Tries))
            {
                if (Copy_Try(from, to)) executed = true;
                i++;
                Thread.Sleep(100);
            }

            if (executed == false)
            {
                MessageBox.Show("Cant recopy base for REading : " + "\n    After tries " + Settings.Default.Tries);
                return false;
            }
            return true;
        }

        public static Boolean Copy_Try(string fr, string to)
        {
            try
            {
                if (File.Exists(to)) File.Delete(to);
                File.Copy(fr, to);
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }

        public static Log_SQL Create_class(string base_path, string s)
        {
            DateTime st = DateTime.Now;


            string dir = Path.GetDirectoryName(base_path) + "\\" + Environment.UserName;
            string new_bp = "";
            if (Path.GetFileName(base_path) == "IngestAssistant.sdf")
            {
                new_bp = dir + "\\IABase.sdf";
            }
            else
            {
                new_bp = dir + "\\LogBase.sdf";
            }
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);



            if (!Copy_Operation(base_path, new_bp))
            {
                TimeSpan dl = st - DateTime.Now;

                MessageBox.Show("Cant complete base coping operations" + "\n" + base_path + "\n Time spent " + dl.ToString("c"));
            }
            ;

            try
            {
                Log_SQL Log_SQL = new Log_SQL();
                Log_SQL.Create_Connection(base_path);

                for (int i = 0; i < Settings.Default.Tries; i++)
                {
                    if (Log_SQL.Open_Connection()) break;
                    Thread.Sleep(100);
                }

                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return null;

                return Log_SQL;
            }
            catch (Exception e)
            {
                TimeSpan dl = st - DateTime.Now;

                MessageBox.Show("Cant create an instance of READ SQL class" + "\n" + e.ToString() + "\n Time spent " + dl.ToString("c"));
                return null;
            }
        }

        public static Boolean ReadValues(string s, ref Log_SQL sqlclass)
        {

            try
            {
                var temp = new SqlCeCommand(s, sqlclass.SQL_Connection);
                var ret = temp.ExecuteReader();
                sqlclass.SQL_DataReader = ret;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }


       
        public static Boolean Execute_Main(string s, string base_path, ref Log_SQL Log_SQL)
        {
            
            try
            {
               if (!Log_SQL.Open_Connection()) return false;
                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return false;
                var temp = new SqlCeCommand(s, Log_SQL.SQL_Connection);
                 temp.ExecuteNonQuery();
                Log_SQL.Manualy_Close_Connection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean Execute(string s, string base_path)
        {
            Thread th = null;
            DateTime start = DateTime.Now;
            int i = 0;
            Boolean executed = false;

            Log_SQL sql_c = new Log_SQL();
            sql_c.Create_Connection(base_path);


            if (!Execute_Main(s, base_path, ref sql_c))
            {
                MessageBox.Show("Проблема с записью данных в базу " + Path.GetFileName(base_path) + "\n Система повторит попытку записи \n",
                    "Внимание");
                 th = ProgressForm.Prepare_Thread("Попытка повторной записи в базу");
            }
            else
            {
                return true;
            }

            TimeSpan crit=new TimeSpan(0,0,30);
            while (!executed && (i < Settings.Default.Tries) && ((start - DateTime.Now)<=crit))
            {
                executed = Execute_Main(s, base_path, ref sql_c);
                i++;
                Thread.Sleep(100);
            }

            if (!executed)
            {
                sql_c.Manualy_Close_Connection();
                TimeSpan ts = start - DateTime.Now;
                if (th != null) th.Abort(); 
                MessageBox.Show("Log wasn't writeen : " + s + "\n    After tries " + i + "\n Time spent: " + ts.ToString("c"));
                return false;
            }
            
            return true;

        }

        public static void Copy(string Viplanner, string from, string to)
        {
            string zapros;

            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла c переименованием','Копирование файла c переименованием из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "','True',0)";
            }
            else
            {
                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла','Копирование файла из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "','True',0)";
            }


            if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }



      


        public static void Move(string Viplanner, string from, string to)
        {
            string zapros = "";
            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
                {
                 

                    zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование Файла','Переименование Файла  из " +
                             Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                             "','" + Path.GetDirectoryName(from) + "','" +
                             Path.GetDirectoryName(to) + "','True',0)";
                }
                else
                {
                   

                    zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла c переименованием','Перемещение файла c переименованием из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "','True',0)";
                }
            }
            else
            {
               

                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла','Перемещение файла из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "','True',0)";


            }

         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
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
                    //           DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

                    zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование папки','Переименование папки  из " +
                             Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                             "','" + Path.GetDirectoryName(from) + "','" +
                             Path.GetDirectoryName(to) + "','True',0)";
                }
                else
                {
                    //zapros =
                    //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла c переименованием из " +
                    //    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                    //    "','" + Path.GetDirectoryName(from) + "','" +
                    //    Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
                    //    DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

                    zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки c переименованием','Перемещение папки c переименованием из " +
                        Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                        "','" + Path.GetDirectoryName(from) + "','" +
                            Path.GetDirectoryName(to) + "','True',0)";
                }
            }
            else
            {
                //zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла " +
                //         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','" +
                //         Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
                //         DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки','Перемещение папки из " +
                       Path.GetFileName(from) + " в " + Path.GetFileName(to) +
                       "','" + Path.GetDirectoryName(from) + "','" +
                           Path.GetDirectoryName(to) + "','True',0)";


            }

         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static void Create(string Viplanner, string to)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание файла " +
            //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";



           var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание файла','Создание файла " +
                                
                             Path.GetFileName(to)+ "','','" +
                             Path.GetDirectoryName(to) + "','True',0)";

//
         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static void Create_Dir(string Viplanner, string to)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание директории " +
            //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

           var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание папки','Создание папки " +

                            Path.GetFileName(to) + "','','" +
                            Path.GetDirectoryName(to) + "','True',0)";
           if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static void Delete(string Viplanner, string from)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление файла " +
            //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";



            var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

                             Path.GetFileName(from) + "','"+
                             Path.GetDirectoryName(from) +"','','True',0)";
         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static void Delete_Dir(string Viplanner, string from)
        {
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление директории " +
            //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
            //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";


            var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

                             Path.GetFileName(from) + "','" +
                             Path.GetDirectoryName(from) + "','','True',0)";

         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static void Login()
        {
            //var zapros =
            //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь зашел в систему','','','" +
            //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

            var zapros =
                "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('','" +
                DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" +
                Environment.UserName + "','" + Environment.MachineName + "',1,'Login (" + Settings.Default.Setting_Profile + ")','Login (" + Settings.Default.Setting_Profile + ")" +
                Environment.UserDomainName + "__" + Environment.UserName + "','','','True',0)";




            Execute(zapros, Settings.Default.Log_Base_Path);




        }

        public static void Logout()
        {
            //var zapros =
            //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь вышел из системы','','','" +
            //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";


            var zapros =
               "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('','" +
               DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" +
               Environment.UserName + "','" + Environment.MachineName + "',1,'Logout','Logout  " +
               Environment.UserDomainName + "__" + Environment.UserName + "','','','True',0)";



         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
          //  if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static long VAction(string Viplanner, string info,int group)
        {
            string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'" + info + "','','','" +
            //             Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" + time +
            //             "')";

            var zapros =
                           "INSERT INTO Logs (VP,Time,[User],PC,[Group],Name,Description,[From],[To],Finished,F_ID) VALUES ('"+Viplanner+"','" +
                           time + "','" + Environment.UserDomainName + "__" +
                           Environment.UserName + "','" + Environment.MachineName + "',"+group+",'"+info+"','','','','False',0)";




         if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);

           // zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
            return 5; // Convert.ToInt64(Log_SQL.ReadValue(zapros, Settings.Default.Log_Base_Path));

        }

        public static void ReWrite_Start(long start, long stop)
        {
            //string ishod = Log_SQL.ReadValue("Select Name from Logs Where ID=" + start, Properties.Settings.Default.Log_Base_Path).ToString();
          //  ishod += " (" + stop + ")";
            string zapros = "Update Logs SET Finished ='True',F_ID="+stop+" where ID=" + start;
            if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
        }

        public static long Action(string info,int group)
        {
            string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
            //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'" + info + "','','','" +
            //             Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" + time +
            //             "')";

            var zapros =
                           "INSERT INTO Logs (VP,Time,[User],PC,[Group],Name,Description,[From],[To],Finished,F_ID) VALUES ('','" +
                           time + "','" + Environment.UserDomainName + "__" +
                           Environment.UserName + "','" + Environment.MachineName + "'," + group + ",'" + info + "','' ,'','','False',0)";




            if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);

          //  zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
            return 5; //Convert.ToInt64(Log_SQL.ReadValue(zapros, Settings.Default.Log_Base_Path));
        }

    }



//    internal class SQL1
//    {
//        public SqlCeConnection SQL_Connection;
//        public SqlCeDataReader SQL_DataReader;

//        public void Manualy_Close_Connection()
//        {
//            if (SQL_Connection.State == ConnectionState.Open)
//            {
//                SQL_Connection.Close();
//            }
//        }

//        public void Create_Connection(string base_path)
//        {

//            if (!File.Exists(base_path))
//            {
//                MessageBox.Show("Не указан путь к базе данных", "Фатальная ошибка", MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//                var frm = new Emergensy_Way_To_Base();
//                frm.ShowDialog();
//            }

//            var conString = "DataSource=" + base_path;
//            SQL_Connection = new SqlCeConnection(conString);
//        }

//        private Boolean Open_Connection()
//        {
//            try
//            {
//                if (SQL_Connection.State == ConnectionState.Closed)
//                {

//                    SQL_Connection.Open();
//                }
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//            return true;
//        }

//        public static int ReadValueInt32(string s, string base_path)
//        {
//            return Convert.ToInt32(ReadValue(s, base_path));
//        }

//        public static Boolean ReadValueBoolean(string s, string base_path)
//        {
//            return Convert.ToBoolean(ReadValue(s, base_path));
//        }

//        public static string ReadValueString(string s, string base_path)
//        {
//            return Convert.ToString(ReadValue(s, base_path));
//        }



//        public static Boolean ReadValueMain(string s, string base_path, ref object obj, ref Log_SQL Log_SQL)
//        {
//            try
//            {

//                if (!Log_SQL.Open_Connection()) return false;
//                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return false;
//                var temp = new SqlCeCommand(s, Log_SQL.SQL_Connection);
//                var reader = temp.ExecuteReader();
//                obj = temp.ExecuteScalar();
//                Log_SQL.Manualy_Close_Connection();
//                return true;
//            }
//            catch (Exception e)
//            {
//                return false;
//            }
//        }

//        public static object ReadValue(string s, string base_path)
//        {
//            DateTime st = DateTime.Now;
//            string dir = Path.GetDirectoryName(base_path) + "\\" + Environment.UserName;
//            string new_bp = "";
//            if (Path.GetFileName(base_path) == "IngestAssistant.sdf")
//            {
//                new_bp = dir + "\\IABase.sdf";
//            }
//            else
//            {
//                new_bp = dir + "\\LogBase.sdf";
//            }

//            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
//            if (!Copy_Operation(base_path, new_bp)) return null;



//            SQL sql_c = new SQL();
//            sql_c.Create_Connection(base_path);



//            object Ret = new object();
//            int i = 0;
//            Boolean executed = false;







//            while (!executed && (i < Settings.Default.Tries))
//            {
//                if (ReadValueMain(s, base_path, ref Ret, ref sql_c)) executed = true;
//                i++;
//                Thread.Sleep(100);
//            }

//            if (executed == false)
//            {
//                sql_c.Manualy_Close_Connection();
//                TimeSpan dl = st - DateTime.Now;
//                MessageBox.Show("Log wasn't readen : " + s + "\n    After tries " + Settings.Default.Tries + "\n Time spent " + dl.ToString("c"));
//                return null;
//            }
//            return Ret;

//        }





//        public static Boolean Copy_Operation(string from, string to)
//        {
//            int i = 0;
//            Boolean executed = false;





//            while (!executed && (i < Settings.Default.Tries))
//            {
//                if (Copy_Try(from, to)) executed = true;
//                i++;
//                Thread.Sleep(100);
//            }

//            if (executed == false)
//            {
//                MessageBox.Show("Cant recopy base for REading : " + "\n    After tries " + Settings.Default.Tries);
//                return false;
//            }
//            return true;
//        }

//        public static Boolean Copy_Try(string fr, string to)
//        {
//            try
//            {
//                if (File.Exists(to)) File.Delete(to);
//                File.Copy(fr, to);
//            }
//            catch (Exception)
//            {

//                return false;
//            }
//            return true;

//        }

//        public static SQL Create_class(string base_path, string s)
//        {
//            DateTime st = DateTime.Now;


//            string dir = Path.GetDirectoryName(base_path) + "\\" + Environment.UserName;
//            string new_bp = "";
//            if (Path.GetFileName(base_path) == "IngestAssistant.sdf")
//            {
//                new_bp = dir + "\\IABase.sdf";
//            }
//            else
//            {
//                new_bp = dir + "\\LogBase.sdf";
//            }
//            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);



//            if (!Copy_Operation(base_path, new_bp))
//            {
//                TimeSpan dl = st - DateTime.Now;

//                MessageBox.Show("Cant complete base coping operations" + "\n" + base_path + "\n Time spent " + dl.ToString("c"));
//            }
//            ;

//            try
//            {
//                SQL Log_SQL = new SQL();
//                Log_SQL.Create_Connection(base_path);

//                for (int i = 0; i < Settings.Default.Tries; i++)
//                {
//                    if (Log_SQL.Open_Connection()) break;
//                    Thread.Sleep(100);
//                }

//                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return null;

//                return Log_SQL;
//            }
//            catch (Exception e)
//            {
//                TimeSpan dl = st - DateTime.Now;

//                MessageBox.Show("Cant create an instance of READ SQL class" + "\n" + e.ToString() + "\n Time spent " + dl.ToString("c"));
//                return null;
//            }
//        }

//        public static Boolean ReadValues(string s, ref SQL sqlclass)
//        {

//            try
//            {
//                var temp = new SqlCeCommand(s, sqlclass.SQL_Connection);
//                var ret = temp.ExecuteReader();
//                sqlclass.SQL_DataReader = ret;
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//                throw;
//            }

//        }



//        public static Boolean Execute_Main(string s, string base_path, ref SQL Log_SQL)
//        {

//            try
//            {
//                if (!Log_SQL.Open_Connection()) return false;
//                if (Log_SQL.SQL_Connection.State != ConnectionState.Open) return false;
//                var temp = new SqlCeCommand(s, Log_SQL.SQL_Connection);
//                temp.ExecuteNonQuery();
//                Log_SQL.Manualy_Close_Connection();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public static Boolean Execute(string s, string base_path)
//        {
//            Thread th = null;
//            DateTime start = DateTime.Now;
//            int i = 0;
//            Boolean executed = false;

//            SQL sql_c = new SQL();
//            sql_c.Create_Connection(base_path);


//            if (!Execute_Main(s, base_path, ref sql_c))
//            {
//                MessageBox.Show("Проблема с записью данных в базу " + Path.GetFileName(base_path) + "\n Система повторит попытку записи \n",
//                    "Внимание");
//                th = ProgressForm.Prepare_Thread("Попытка повторной записи в базу");
//            }
//            else
//            {
//                return true;
//            }

//            TimeSpan crit = new TimeSpan(0, 0, 30);
//            while (!executed && (i < Settings.Default.Tries) && ((start - DateTime.Now) <= crit))
//            {
//                executed = Execute_Main(s, base_path, ref sql_c);
//                i++;
//                Thread.Sleep(100);
//            }

//            if (!executed)
//            {
//                sql_c.Manualy_Close_Connection();
//                TimeSpan ts = start - DateTime.Now;
//                if (th != null) th.Abort();
//                MessageBox.Show("Log wasn't writeen : " + s + "\n    After tries " + i + "\n Time spent: " + ts.ToString("c"));
//                return false;
//            }

//            return true;

//        }
//    }
//    internal class Log1 :SQL1
//{
//    public static void Copy(string Viplanner, string from, string to)
//    {
//        string zapros;

//        if (Path.GetFileName(from) != Path.GetFileName(to))
//        {
//            zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла c переименованием','Копирование файла c переименованием из " +
//                   Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                   "','" + Path.GetDirectoryName(from) + "','" +
//                       Path.GetDirectoryName(to) + "','True',0)";
//        }
//        else
//        {
//            zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Копирование файла','Копирование файла из " +
//                    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                    "','" + Path.GetDirectoryName(from) + "','" +
//                        Path.GetDirectoryName(to) + "','True',0)";
//        }


//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }






//    public static void Move(string Viplanner, string from, string to)
//    {
//        string zapros = "";
//        if (Path.GetFileName(from) != Path.GetFileName(to))
//        {
//            if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
//            {


//                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование Файла','Переименование Файла  из " +
//                         Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                         "','" + Path.GetDirectoryName(from) + "','" +
//                         Path.GetDirectoryName(to) + "','True',0)";
//            }
//            else
//            {


//                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла c переименованием','Перемещение файла c переименованием из " +
//                    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                    "','" + Path.GetDirectoryName(from) + "','" +
//                        Path.GetDirectoryName(to) + "','True',0)";
//            }
//        }
//        else
//        {


//            zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение файла','Перемещение файла из " +
//                   Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                   "','" + Path.GetDirectoryName(from) + "','" +
//                       Path.GetDirectoryName(to) + "','True',0)";


//        }

//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Move_Dir(string Viplanner, string from, string to)
//    {
//        string zapros = "";
//        if (Path.GetDirectoryName(from) != Path.GetDirectoryName(to))
//        {
//            if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
//            {
//                ////  zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Переименование Файла  из " +
//                //           Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                //           "','" + Path.GetDirectoryName(from) + "','" +
//                //           Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
//                //           DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

//                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Переименование папки','Переименование папки  из " +
//                         Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                         "','" + Path.GetDirectoryName(from) + "','" +
//                         Path.GetDirectoryName(to) + "','True',0)";
//            }
//            else
//            {
//                //zapros =
//                //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла c переименованием из " +
//                //    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                //    "','" + Path.GetDirectoryName(from) + "','" +
//                //    Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
//                //    DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

//                zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки c переименованием','Перемещение папки c переименованием из " +
//                    Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                    "','" + Path.GetDirectoryName(from) + "','" +
//                        Path.GetDirectoryName(to) + "','True',0)";
//            }
//        }
//        else
//        {
//            //zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла " +
//            //         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','" +
//            //         Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" +
//            //         DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

//            zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Перемещение папки','Перемещение папки из " +
//                   Path.GetFileName(from) + " в " + Path.GetFileName(to) +
//                   "','" + Path.GetDirectoryName(from) + "','" +
//                       Path.GetDirectoryName(to) + "','True',0)";


//        }

//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Create(string Viplanner, string to)
//    {
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание файла " +
//        //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
//        //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";



//        var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание файла','Создание файла " +

//                          Path.GetFileName(to) + "','','" +
//                          Path.GetDirectoryName(to) + "','True',0)";

//        //
//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Create_Dir(string Viplanner, string to)
//    {
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание директории " +
//        //             Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
//        //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

//        var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Создание папки','Создание папки " +

//                         Path.GetFileName(to) + "','','" +
//                         Path.GetDirectoryName(to) + "','True',0)";
//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Delete(string Viplanner, string from)
//    {
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление файла " +
//        //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
//        //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";



//        var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

//                         Path.GetFileName(from) + "','" +
//                         Path.GetDirectoryName(from) + "','','True',0)";
//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Delete_Dir(string Viplanner, string from)
//    {
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление директории " +
//        //             Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName +
//        //             "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";


//        var zapros = "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" + Environment.UserName + "','" + Environment.MachineName + "',2,'Удаление файла','Удаление файла " +

//                         Path.GetFileName(from) + "','" +
//                         Path.GetDirectoryName(from) + "','','True',0)";

//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static void Login()
//    {
//        //var zapros =
//        //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь зашел в систему','','','" +
//        //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";

//        var zapros =
//            "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('','" +
//            DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" +
//            Environment.UserName + "','" + Environment.MachineName + "',1,'Login (" + Settings.Default.Setting_Profile + ")','Login (" + Settings.Default.Setting_Profile + ")" +
//            Environment.UserDomainName + "__" + Environment.UserName + "','','','True',0)";




//        Execute(zapros, Settings.Default.Log_Base_Path);




//    }

//    public static void Logout()
//    {
//        //var zapros =
//        //    "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Пользователь вышел из системы','','','" +
//        //    Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";


//        var zapros =
//           "INSERT INTO Logs (VP,Time,[User],PC,[Group],Description,Name,[From],[To],Finished,F_ID) VALUES ('','" +
//           DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "','" + Environment.UserDomainName + "__" +
//           Environment.UserName + "','" + Environment.MachineName + "',1,'Logout','Logout  " +
//           Environment.UserDomainName + "__" + Environment.UserName + "','','','True',0)";



//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//        //  if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static long VAction(string Viplanner, string info, int group)
//    {
//        string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'" + info + "','','','" +
//        //             Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" + time +
//        //             "')";

//        var zapros =
//                       "INSERT INTO Logs (VP,Time,[User],PC,[Group],Name,Description,[From],[To],Finished,F_ID) VALUES ('" + Viplanner + "','" +
//                       time + "','" + Environment.UserDomainName + "__" +
//                       Environment.UserName + "','" + Environment.MachineName + "'," + group + ",'" + info + "','','','','False',0)";




//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);

//        // zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
//        return 5; // Convert.ToInt64(Log_SQL.ReadValue(zapros, Settings.Default.Log_Base_Path));

//    }

//    public static void ReWrite_Start(long start, long stop)
//    {
//        //string ishod = Log_SQL.ReadValue("Select Name from Logs Where ID=" + start, Properties.Settings.Default.Log_Base_Path).ToString();
//        //  ishod += " (" + stop + ")";
//        string zapros = "Update Logs SET Finished ='True',F_ID=" + stop + " where ID=" + start;
//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);
//    }

//    public static long Action(string info, int group)
//    {
//        string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
//        //var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'" + info + "','','','" +
//        //             Environment.UserDomainName + "__" + Environment.UserName + "__" + Environment.MachineName + "','" + Viplanner + "','" + time +
//        //             "')";

//        var zapros =
//                       "INSERT INTO Logs (VP,Time,[User],PC,[Group],Name,Description,[From],[To],Finished,F_ID) VALUES ('','" +
//                       time + "','" + Environment.UserDomainName + "__" +
//                       Environment.UserName + "','" + Environment.MachineName + "'," + group + ",'" + info + "','' ,'','','False',0)";




//        if (Settings.Default.Alow_Logging) Execute(zapros, Settings.Default.Log_Base_Path);

//        //  zapros = "Select MAX(ID) from Logs where (Time='" + time + "')";
//        return 5; //Convert.ToInt64(Log_SQL.ReadValue(zapros, Settings.Default.Log_Base_Path));
//    }
//}

}