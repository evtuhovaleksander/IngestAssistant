using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant //VipLiner_Control
{
    //internal class SQL
    //{
    //    // Запросы и обращания к БД
    //    private static SqlCeConnection sqlcon;
    //    public static SqlCeConnection SQL_Connection;
    //    public SqlCeDataReader SQL_DataReader;

    //    public void Manualy_Close_Connection()
    //    {
    //        if (SQL_Connection.State == ConnectionState.Open)
    //        {
    //            SQL_Connection.Close();
    //        }
    //    }

    //    private void Create_Connection()
    //    {
    //        if (SQL_Connection != null)
    //        {
    //            Manualy_Close_Connection();
    //        }
    //        if (!File.Exists(Settings.Default.MetaBase_Way))
    //        {
    //            MessageBox.Show("Не указан путь к базе данных", "Фатальная ошибка", MessageBoxButtons.OK,
    //                MessageBoxIcon.Error);
    //            var frm = new Emergensy_Way_To_Base();
    //            frm.ShowDialog();
    //        }
    //        var conString = "DataSource=" + Settings.Default.MetaBase_Way;
    //        // conString = conString.Replace("\\");
    //        SQL_Connection = new SqlCeConnection(conString);
    //    }

    //    private void Manualy_Open_Connection()
    //    {
    //        if (SQL_Connection.State == ConnectionState.Closed)
    //        {
    //            Manualy_Close_Connection();
    //            SQL_Connection.Open();
    //        }
    //    }

    //    public static int ReadValueInt32(string s)
    //    {
    //        return Convert.ToInt32(ReadValue(s));
    //    }

    //    public static Boolean ReadValueBoolean(string s)
    //    {
    //        return Convert.ToBoolean(ReadValue(s));
    //    }

    //    public static string ReadValueString(string s)
    //    {
    //        return Convert.ToString(ReadValue(s));
    //    }

    //    public static object ReadValue(string s)
    //    {
    //        try
    //        {
    //            var sql_class = new SQL();
    //            sql_class.Create_Connection();
    //            sql_class.Manualy_Open_Connection();
    //            var temp = new SqlCeCommand(s, SQL_Connection);
    //            var reader = temp.ExecuteReader();
    //            var ret = temp.ExecuteScalar();
    //            sql_class.Manualy_Close_Connection();
    //            return ret;
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(e.Message);
    //            MessageBox.Show(s);
    //            return null;
    //        }
    //    }

    //    public static SQL ReadValues(string s)
    //    {
    //        try
    //        {
    //            var sql_class = new SQL();
    //            sql_class.Create_Connection();
    //            sql_class.Manualy_Open_Connection();
    //            var temp = new SqlCeCommand(s, SQL_Connection);
    //            var ret = temp.ExecuteReader();
    //            sql_class.SQL_DataReader = ret;
    //            return sql_class;
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(e.Message);
    //            MessageBox.Show(s);

    //            return null;
    //        }
    //    }

    //    public static int Execute(string s)
    //    {
    //        try
    //        {
    //            var sql_class = new SQL();
    //            sql_class.Create_Connection();
    //            sql_class.Manualy_Open_Connection();
    //            var temp = new SqlCeCommand(s, SQL_Connection);

    //            var ret = temp.ExecuteNonQuery();
    //            sql_class.Manualy_Close_Connection();
    //            return ret;
    //        }
    //        catch (SqlCeException e)
    //        {
    //            MessageBox.Show(e.Message);
    //            return 0;
    //        }
    //    }

    //    public static void Make_Table(DataGridView dgv, string s)
    //    {
    //        try
    //        {
    //            var sql_class = new SQL();
    //            sql_class.Create_Connection();
    //            sql_class.Manualy_Open_Connection();
    //            var dadapter = new SqlCeDataAdapter(s, SQL_Connection);
    //            var table = new DataTable();
    //            dadapter.Fill(table);


    //            dgv.DataSource = table;


    //            sql_class.Manualy_Close_Connection();
    //        }
    //        catch (SqlCeException e)
    //        {
    //            MessageBox.Show(e.Message);
    //        }
    //    }
    //}


    //public class ComboboxItem
    //{
    //    public ComboboxItem(int i, string text)
    //    {
    //        Value = i;
    //        Text = text;
    //    }

    //    public string Text { get; set; }
    //    public object Value { get; set; }

    //    public override string ToString()
    //    {
    //        return Text;
    //    }
    //}
}