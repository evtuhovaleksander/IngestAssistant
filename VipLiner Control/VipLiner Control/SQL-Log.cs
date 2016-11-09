using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant 
{
    internal class Log_SQL1
    {
        // Запросы и обращания к БД
        private static SqlCeConnection sqlcon;
        public static SqlCeConnection SQL_Connection;
        public SqlCeDataReader SQL_DataReader;

        public void Manualy_Close_Connection()
        {
            if (SQL_Connection.State == ConnectionState.Open)
            {
                SQL_Connection.Close();
            }
        }

        private void Create_Connection()
        {
            if (SQL_Connection != null)
            {
                Manualy_Close_Connection();
            }
            if (!File.Exists(Settings.Default.Log_Base_Path))
            {
                MessageBox.Show("Не указан путь к базе данных логов", "Фатальная ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            var conString = "DataSource=" + Settings.Default.Log_Base_Path;
            SQL_Connection = new SqlCeConnection(conString);
        }

        private void Manualy_Open_Connection()
        {
            if (SQL_Connection.State == ConnectionState.Closed)
            {
                SQL_Connection.Open();
            }
        }

       

        public static object ReadValue(string s, int count)
        {
            try
            {
                var sql_class = new Log_SQL();
                sql_class.Create_Connection();
                sql_class.Manualy_Open_Connection();
                var temp = new SqlCeCommand(s, SQL_Connection);
                var reader = temp.ExecuteReader();
                var ret = temp.ExecuteScalar();
                sql_class.Manualy_Close_Connection();
                return ret;
            }
            catch (Exception e)
            {
                if (count < Settings.Default.Tries)
                {
                    Thread.Sleep(100);
                    count++;
                    return ReadValue(s, count);
                }
              //  MessageBox.Show(e.Message);
              //  MessageBox.Show(s);
                return null;
            }
        }

        public static Log_SQL ReadValues(string s, int count)
        {
            try
            {
                var sql_class = new Log_SQL();
                sql_class.Create_Connection();
                sql_class.Manualy_Open_Connection();
                var temp = new SqlCeCommand(s, SQL_Connection);
                var ret = temp.ExecuteReader();
                sql_class.SQL_DataReader = ret;
                return sql_class;
            }
            catch (Exception e)
            {
                if (count < Settings.Default.Tries)
                {
                    count++;
                    return ReadValues(s, count);
                }
             //   MessageBox.Show(e.Message);
            //    MessageBox.Show(s);

                return null;
            }
        }

        public static int Execute(string s, int count)
        {
            try
            {
                var sql_class = new Log_SQL();
                sql_class.Create_Connection();
                sql_class.Manualy_Open_Connection();
                var temp = new SqlCeCommand(s, SQL_Connection);

                var ret = temp.ExecuteNonQuery();
                sql_class.Manualy_Close_Connection();
                return ret;
            }
            catch (SqlCeException e)
            {
                if (count < Settings.Default.Tries*2)
                {
                    Execute(s, count + 1);
                }
            //    MessageBox.Show(e.Message);
                return 0;
            }
        }

        public static void Copy(string Viplanner, string from, string to)
        {
            string zapros;
            
            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Копирование файла c переименованием из "+Path.GetFileName(from)+" в "+Path.GetFileName(to) +
                          "','" + Path.GetDirectoryName(from) + "','" +
                        Path.GetDirectoryName(to) + "','" + Environment.UserName + "','" + Viplanner + "','" +
                        DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            }
            else
            {
                zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Копирование файла " +
                       Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','" +
                       Path.GetDirectoryName(to) + "','" + Environment.UserName + "','" + Viplanner + "','" +
                       DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            }
            

            Execute(zapros, 0);
        }




    // c переименованием из "+Path.GetFileName(from)+" в "+Path.GetFileName(to) +

        public static void Move(string Viplanner, string from, string to)
        {
            string zapros = "";
            if (Path.GetFileName(from) != Path.GetFileName(to))
            {
                if (Path.GetDirectoryName(from) == Path.GetDirectoryName(to))
                {
                      zapros= "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Переименование Файла  из "+Path.GetFileName(from)+" в "+Path.GetFileName(to) +
                          "','" + Path.GetDirectoryName(from) + "','" +
                         Path.GetDirectoryName(to) + "','" + Environment.UserName + "','" + Viplanner + "','" +
                         DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
                }
                else
                {
                     zapros= "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла c переименованием из "+Path.GetFileName(from)+" в "+Path.GetFileName(to)  +
                         "','" + Path.GetDirectoryName(from) + "','" +
                         Path.GetDirectoryName(to) + "','" + Environment.UserName + "','" + Viplanner + "','" +
                         DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
                }
            }
            else
            {
                zapros= "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Перемещение файла " +
                         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','" +
                         Path.GetDirectoryName(to) + "','" + Environment.UserName + "','" + Viplanner + "','" +
                         DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            }
            
            Execute(zapros, 0);
        }

        public static void Create(string Viplanner, string to)
        {
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание файла " +
                         Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserName +
                         "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static void Create_Dir(string Viplanner, string to)
        {
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Создание директории " +
                         Path.GetFileName(to) + "','','" + Path.GetDirectoryName(to) + "','" + Environment.UserName +
                         "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static void Delete(string Viplanner, string from)
        {
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление файла " +
                         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserName +
                         "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static void Delete_Dir(string Viplanner, string from)
        {
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (1,'Удаление директории " +
                         Path.GetFileName(from) + "','" + Path.GetDirectoryName(from) + "','','" + Environment.UserName +
                         "','" + Viplanner + "','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static void Login()
        {
            var zapros =
                "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (2,'Пользователь зашел в систему','','','" +
                Environment.UserName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static void Logout()
        {
            var zapros =
                "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (2,'Пользователь вышел из системы','','','" +
                Environment.UserName + "','','" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + "')";
            Execute(zapros, 0);
        }

        public static long VAction(string Viplanner, string info)
        {
            string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (2,'" + info + "','','','" +
                         Environment.UserName + "','" + Viplanner + "','" + time +
                         "')";
            Execute(zapros, 0);

            zapros = "Select MAX(ID) from Logs where (Stat='" + time + "')";
            return Convert.ToInt64(Log_SQL.ReadValue(zapros,0));
            
        }

        public static void ReWrite_Start(long start, long stop)
        {
            string ishod = Log_SQL.ReadValue("Select Name from Logs Where ID=" + start, 0).ToString();
            ishod += " (" + stop + ")";
            string zapros = "Update Logs SET Name ='" + ishod + "' where ID=" + start;
            Log_SQL.Execute(zapros,0);
        }

        public static long Action(string info)
        {
            string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (2,'" + info + "','','','" +
                         Environment.UserName + "','" + "" + "','" + time +
                         "')";
            Execute(zapros, 0);

            zapros = "Select MAX(ID) from Logs where (Stat='" + time + "')";
            return Convert.ToInt64(Log_SQL.ReadValue(zapros, 0));
        }
    }


    
}