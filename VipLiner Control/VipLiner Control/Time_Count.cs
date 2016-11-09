using System;
using System.Collections.Generic;
using System.Drawing;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    internal class Time_Count
    {
        public int Hours;
        public Browser parent_form;

        public static void Time_Func(Time_Count cl)
        {
            //ProgressForm.StartForm("Идет подсчет");
            var time_mas = cl.collect_times();

            var max = 0;

            max = time_mas.Count;
            var Total = new TimeSpan(0, 0, 0);
            for (var i = 1; i <= max; i++)
            {
                var temp = time_mas.Dequeue();

                try
                {
                    var h = Convert.ToInt32(temp.Substring(0, 2));
                    var m = Convert.ToInt32(temp.Substring(3, 2));
                    var s = Convert.ToInt32(temp.Substring(6, 2));
                    Total += new TimeSpan(h, m, s);
                }
                catch (Exception)
                {
                }
            }
            var hh = 0;
            hh = Total.Hours + Total.Days*24;
            cl.Hours = hh;

            var norma = Convert.ToInt32(Settings.Default.Day_Work_Time);

            cl.parent_form.Time_Count_PrBar.Maximum = norma;

            if (hh > norma)
            {
                cl.parent_form.Time_Count_L1_Lable.Text = hh + "/" + norma;
                cl.parent_form.Time_Count_L2_Lable.Text = "Аппаратная перегружена";
                cl.parent_form.Time_Count_PrBar.Value = cl.parent_form.Time_Count_PrBar.Maximum;
                cl.parent_form.Time_Count_GrBox.BackColor = Color.Yellow;
            }
            else
            {
                cl.parent_form.Time_Count_L1_Lable.Text = hh + "/" + norma;
                cl.parent_form.Time_Count_L2_Lable.Text = "Выполнение плана - долг! Перевыполнение - ЧЕСТЬ!!!";
                cl.parent_form.Time_Count_PrBar.Value = hh;
                cl.parent_form.Time_Count_GrBox.BackColor = Color.CornflowerBlue;
            }
            //  ProgressForm.StopForm();
        }

        public Queue<string> collect_times()
        {
            var outt = new Queue<string>();


            var left = DateTime.Now.Date;
            var right = left.AddDays(1);
            var col = Log_SQL.ReadValueInt32("Select Count(*) from MetaDataArchive",Properties.Settings.Default.MetaBase_Way);
            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.MetaBase_Way,
                "public Queue<string> collect_times()");
            for (var i = 1; i <= col; i++)
            {
                var zapros =
                    " SELECT Time_Of_Registration, Total_Time FROM     MetaDataArchive WHERE  (ID = " + i + ")";
                Log_SQL.ReadValues(zapros,ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var cur = Convert.ToDateTime(sqlcon.SQL_DataReader.GetString(0));
                if (cur > left && cur < right)
                {
                    var temp = "";
                    temp = sqlcon.SQL_DataReader.GetString(1);
                    outt.Enqueue(temp);
                }
               
            }
            sqlcon.Manualy_Close_Connection();
            return outt;
        }
    }
}