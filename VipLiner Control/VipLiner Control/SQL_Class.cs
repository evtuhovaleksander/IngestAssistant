using System;
using System.Data;

using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql;

using Ingest_Assistant.Properties;
using MySql.Data.MySqlClient;

namespace Ingest_Assistant
{
   
    internal class SQL_Class
    {
        
        public MySqlConnection SQL_Connection;
        public MySqlDataReader SQL_DataReader;

        public static Boolean check_connection(string con_string)
        {
            try
            {
                var conString = @"" + con_string;
                MySqlConnection Test_SQL_Connection = new MySqlConnection(conString);
                Test_SQL_Connection.Open();
                Test_SQL_Connection.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        public void Manualy_Close_Connection()
        {
            if (SQL_Connection.State == ConnectionState.Open)
            {
                SQL_Connection.Close();
            }
        }

        public void Create_Connection(string base_path)
        {
            // Server = ALEXPC\MSQLS2008;Database=IngestAssistantSettingsBase; User Id = sa; Password = sa;
            // Server = ALEXPC\MSQLS2008;Database=IngestAssistantMainBase; User Id = sa; Password = sa;
            // Server = ALEXPC\MSQLS2008;Database=IngestAssistantLogBase; User Id = sa; Password = sa;
          //  SQL_Connection = new SqlConnection(base_path);





         //   DataTable dt = new DataTable();

            //MySqlConnectionStringBuilder mysqlCSB;
            //mysqlCSB = new MySqlConnectionStringBuilder();
            //mysqlCSB.Server = "127.0.0.1";
            //mysqlCSB.Database = "db1";
            //mysqlCSB.UserID = "root";
            //mysqlCSB.Password = "root";

            //string queryString = @"SELECT Count(*)              
            //              FROM   table1 
            //            ";

           SQL_Connection=new MySqlConnection(base_path);
             //   con.ConnectionString = mysqlCSB.ConnectionString;

                //MySqlCommand com = new MySqlCommand(queryString, con);

                
                //    con.Open();

                //    using (MySqlDataReader dr = com.ExecuteReader())
                //    {
                //        if (dr.HasRows)
                //        {
                //            dt.Load(dr);
                //        }
                //    }


                //    object obj = com.ExecuteScalar();
               
              
            






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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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



        public static object ReadValue(string s, string base_path)
        {
            
            SQL_Class sql = new SQL_Class();
            sql.Create_Connection(base_path);
            sql.Open_Connection();
            MySqlCommand comand = new MySqlCommand(s, sql.SQL_Connection);
            object obj = comand.ExecuteScalar();
            sql.Manualy_Close_Connection();
            return obj;
           
        }



        public static SQL_Class Create_class(string base_path)
        {
           
            SQL_Class sql_class = new SQL_Class();
            sql_class.Create_Connection(base_path);
            sql_class.Open_Connection();
            if (sql_class.SQL_Connection.State != ConnectionState.Open) return null;
            return sql_class;
         
        }

        public static void ReadValues(string s, ref SQL_Class sqlclass)
        {

            try
            {
                if (sqlclass.SQL_DataReader != null)
                {

                    if (!sqlclass.SQL_DataReader.IsClosed) sqlclass.SQL_DataReader.Close();
                }
                MySqlCommand temp = new MySqlCommand(s, sqlclass.SQL_Connection);
                MySqlDataReader ret = temp.ExecuteReader();
                sqlclass.SQL_DataReader = ret;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        public  Boolean getBoolean(int i)
        {
            if (SQL_DataReader.GetInt32(i) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Execute(string s, string base_path)
        {
            s = s.Replace("'True'", "1");
            s = s.Replace("'False'", "0");
            SQL_Class sql_c = new SQL_Class();
            sql_c.Create_Connection(base_path);
            sql_c.Open_Connection();

            var temp = new MySqlCommand(s, sql_c.SQL_Connection);

            try
            {
                temp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                sql_c.Manualy_Close_Connection();
                return false;
            }

            
            sql_c.Manualy_Close_Connection();
            return true;
        }

      

        public static string get_Data_asString(SQL_Class sqlcl, int index)
        {
        
            if (sqlcl.SQL_DataReader.GetValue(index).ToString() == "")
            {
                return "";
            }
            else
            {
                return sqlcl.SQL_DataReader.GetDateTime(index).ToString("g");
            }
        }

        public static string wr_data(string str)
        {
            if (str != "")
            {
                return "'" + str + "'";
            }
            else
            {
                return "NULL";
            }
        }

        public static string wr_data(object obj)
        {
            if (obj != null)
            {
                return wr_data(obj.ToString());
            }
            else
            {
                return "NULL";
            }

        }
    }
}