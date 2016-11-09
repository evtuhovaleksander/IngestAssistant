using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    internal class DateTm
    {
       // public tm[] a_s_d = new tm[0];
       // public tm[] a_s_n = new tm[0];
        public List<tm> date_mas_arch = new List<tm>();
        public List<tm> date_mas_arch_ALL = new List<tm>();
        public List<tm> date_mas_work = new List<tm>();
        public List<tm> date_mas_work_ALL = new List<tm>();
        //public tm[] w_s_d = new tm[0];
        //public tm[] w_s_n = new tm[0];

        //public tm[] am = new tm[0];
        //public tm[] wm = new tm[0];

        private void clear()
        {
            date_mas_work = new List<tm>();
            date_mas_arch = new List<tm>();
            date_mas_work_ALL = new List<tm>();
            date_mas_arch_ALL = new List<tm>();


            //w_s_n = new tm[0];
            //w_s_d = new tm[0];

            //a_s_n = new tm[0];
            //a_s_d = new tm[0];
        }

        public string[] string_mas_clean_from_trash(string[] mas)
        {
            var outt = new string[0];
            for (var i = 0; i < mas.Length; i++)
            {
                if (Path.GetFileName(mas[i]).Length == 8)
                {
                    Array.Resize(ref outt, outt.Length + 1);
                    outt[outt.Length - 1] = mas[i];
                }
            }
            return outt;
        }

        public void init_all(string work, string arch, DateTime setday)
        {
            clear();

            setday = setday.Date;
            var nextday = setday.AddDays(1);

            var str_w_mas = Directory.GetDirectories(work);
            str_w_mas = string_mas_clean_from_trash(str_w_mas);
            for (var i = 0; i < str_w_mas.Length; i++)
            {
                var temp = new tm();
                temp.way = str_w_mas[i];
                temp.vp = Path.GetFileNameWithoutExtension(temp.way);
                string name = find_name(temp.vp,temp.way);
                temp.name = name;
                temp.date_full = new DirectoryInfo(str_w_mas[i]).CreationTime;
                temp.date_day = temp.date_full.ToString("d");
                temp.date_time = temp.date_full.ToString("T");
                
                if ((Path.GetFileNameWithoutExtension(temp.way).Length == 8))
                {
                    date_mas_work_ALL.Add(temp);
                    
                }
            }


            var str_a_mas = Directory.GetDirectories(arch);
            for (var i = 0; i < str_a_mas.Length; i++)
            {
                var temp = new tm();
                temp.way = str_a_mas[i];
                temp.vp = Path.GetFileNameWithoutExtension(temp.way);
                string name = find_name(temp.vp,temp.way);
                temp.name = name;
                temp.date_full = new DirectoryInfo(str_a_mas[i]).CreationTime;
                temp.date_day = temp.date_full.ToString("d");
                temp.date_time = temp.date_full.ToString("T");

                if ((Path.GetFileNameWithoutExtension(temp.way).Length == 8))
                {
                    date_mas_arch_ALL.Add(temp);
                    if ((temp.date_full >= setday) && (temp.date_full <= nextday)) date_mas_arch.Add(temp);
                }
            }

            List<tm> nnew=new List<tm>();
            for (int i = 0; i < date_mas_work_ALL.Count; i++)
            {
                tm tmp = date_mas_work_ALL[i];
                //date_mas_work_ALL.Remove(tmp);
                tmp.paint = Get_Color_For_Paint_Work_Dirs(date_mas_arch_ALL, tmp);
                //date_mas_work_ALL.Add(tmp);
                nnew.Add(tmp);
                if ((tmp.date_full >= setday) && (tmp.date_full <= nextday)) date_mas_work.Add(tmp);
            }
            date_mas_work_ALL = nnew;


            nnew = new List<tm>();
            for (int i = 0; i < date_mas_arch_ALL.Count; i++)
            {
                tm tmp = date_mas_arch_ALL[i];
                //date_mas_arch_ALL.Remove(tmp);
                tmp.paint = Get_Color_For_Paint_Arch_Dirs(date_mas_work_ALL, tmp);
                //date_mas_arch_ALL.Add(tmp);
                nnew.Add(tmp);
                if ((tmp.date_full >= setday) && (tmp.date_full <= nextday)) date_mas_arch.Add(tmp);
            }
            date_mas_arch_ALL = nnew;
        }


        //public void find_all_names()
        //{
        //    date_mas_arch_ALL = find_names(a_s_n);
        //    a_s_d = find_names(a_s_d);
        //    w_s_n = find_names(w_s_n);
        //    w_s_d = find_names(w_s_d);
        //}

        public static string find_name(string vp,string path)
        {
            string str="";
               
                SQL_Class cl = SQL_Class.Create_class(Settings.Default.MetaBase_Way);
            try
            {
               
                string zapros = "Select Title from metadataarchive where ViPlanner='" + vp + "'" + "  Limit 10";
                //return SQL_Class.ReadValueString(zapros, Properties.Settings.Default.MetaBase_Way);
                SQL_Class.ReadValues(zapros, ref cl);
                while (cl.SQL_DataReader.Read())
                {
                    if (!cl.SQL_DataReader.IsDBNull(0))
                    {
                        if (str == "" || str == " " || str == "  ") str = cl.SQL_DataReader.GetString(0);
                    }
                }
                cl.Manualy_Close_Connection();
            }
            catch (Exception ex)
            {
                cl.Manualy_Close_Connection();
            }
            finally
            {
                cl.Manualy_Close_Connection();
            }

            if (!(str == "" || str == " " || str == "  "))
            {
                return str;
            }

            if (path != "")
            {
                try
                {
                    if (File.Exists(path))
                    {
                        
                    }
                    else
                    {
                        path = path + "\\" + vp + ".xml";
                    }
                    
                    if (File.Exists(path))
                    {
                        return XML_Class.get_one_param("Title", path);
                    }
                }
                catch (Exception)
                {

                }

                return "";
            
            }
            return "";
        }





        public void get_table(List<tm> list, ref DataGridView dgv)
        {
            DataTable t=new DataTable();
            t.Columns.Add("ID Viplanner", " ".GetType());
            t.Columns.Add("Название программы", " ".GetType());
            t.Columns.Add("Дата",DateTime.Now.GetType());
            t.Columns.Add("Время", " ".GetType());
           t.Columns.Add("Color", Color.AliceBlue.GetType());

            for (int i = 0; i < list.Count; i++)
            {
                tm VARIABLE = list[i];
                object[] mas = {VARIABLE.vp, VARIABLE.name, VARIABLE.date_full, VARIABLE.date_time,VARIABLE.paint};
                t.Rows.Add(mas);
            }
           //=t.Columns[4].
            dgv.DataSource = t;
           //gv.Columns[4].Visible = false;
        }


        //public void init_set_day(string work, string arch, DateTime setday)
        //{
        //    clear();
        //    setday = setday.Date;
        //    var nextday = setday.AddDays(1);
        //    var str_w_mas = Directory.GetDirectories(work);

        //    str_w_mas = string_mas_clean_from_trash(str_w_mas);

        //    for (var i = 0; i < str_w_mas.Length; i++)
        //    {
        //        var temp = new tm();
        //        temp.way = str_w_mas[i];
        //        temp.date_full = new DirectoryInfo(str_w_mas[i]).CreationTime;
        //        temp.date_day = temp.date_full.ToString("d");
        //        temp.date_time = temp.date_full.ToString("T");

        //        Array.Resize(ref date_mas_work_ALL, date_mas_work_ALL.Length + 1);
        //        date_mas_work_ALL[date_mas_work_ALL.Length - 1] = temp;


        //        if ((temp.date_full >= setday) && (temp.date_full <= nextday) &&
        //            (Path.GetFileNameWithoutExtension(temp.way).Length == 8))
        //        {
        //            Array.Resize(ref date_mas_work, date_mas_work.Length + 1);
        //            date_mas_work[date_mas_work.Length - 1] = temp;
        //        }
        //    }

        //    var str_a_mas = Directory.GetDirectories(arch);
        //    for (var i = 0; i < str_a_mas.Length; i++)
        //    {
        //        var temp = new tm();
        //        temp.way = str_a_mas[i];
        //        temp.date_full = new DirectoryInfo(str_a_mas[i]).CreationTime;
        //        temp.date_day = temp.date_full.ToString("d");
        //        temp.date_time = temp.date_full.ToString("T");

        //        Array.Resize(ref date_mas_arch_ALL, date_mas_arch_ALL.Length + 1);
        //        date_mas_arch_ALL[date_mas_arch_ALL.Length - 1] = temp;


        //        if ((temp.date_full >= setday) && (temp.date_full <= nextday) &&
        //            (Path.GetFileNameWithoutExtension(temp.way).Length == 8))
        //        {
        //            Array.Resize(ref date_mas_arch, date_mas_arch.Length + 1);
        //            date_mas_arch[date_mas_arch.Length - 1] = temp;
        //        }
        //    }
        //    sort_by_name();
        //    sort_by_date();
        //    find_all_names();
        //}

        public Color Get_Color_For_Paint_Work_Dirs(List<tm> ish, tm sr)
        {
            
            var outt = Color.White;
            for (var i = 0; i < ish.Count; i++)
            {
                if (Path.GetFileName(ish[i].way) == Path.GetFileName(sr.way))
                {
                   
                    var d1 = Directory.GetCreationTime(ish[i].way);

                    var d2 = Directory.GetCreationTime(sr.way);

                    TimeSpan diference = d2 - d1;
                    TimeSpan allow=new TimeSpan(0,1,0);

                    if (d2 > d1)
                    {
                        if (diference > allow)
                        {
                            return  Color.Gold;
                        }
                        else
                        {
                            return  Color.LawnGreen;
                        }
                    }
                    else
                    {
                        return  Color.LawnGreen;
                    }
                }
                else
                {
                    
                }
            }
            return outt;
        }

        public Color Get_Color_For_Paint_Arch_Dirs(List<tm> ish, tm sr)
        {
            var outt = Color.Red;
            for (var i = 0; i < ish.Count; i++)
            {
                if (Path.GetFileName(ish[i].way) == Path.GetFileName(sr.way))
                {
                    return  Color.White;
                }
            }
            return outt;
        }

        public void paint_dgv_to_white(DataGridView dgv)
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[0].Style.BackColor = Color.WhiteSmoke;
                dgv.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                dgv.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                dgv.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
            }
        }

        //public void fill_with_work_sort_by_name(DataGridView dgv)
        //{
        //    paint_dgv_to_white(dgv);
        //    dgv.RowCount = w_s_n.Length;
        //    for (var i = 0; i < w_s_n.Length; i++)
        //    {
        //        dgv.Rows[i].Cells[0].Value = Path.GetFileName(w_s_n[i].way);
        //        dgv.Rows[i].Cells[1].Value = w_s_n[i].name;
        //        dgv.Rows[i].Cells[2].Value = w_s_n[i].date_day;
        //        dgv.Rows[i].Cells[3].Value = w_s_n[i].date_time;

        //        var tekCol = Get_Color_For_Paint_Work_Dirs(date_mas_arch_ALL, w_s_n[i]);


        //        dgv.Rows[i].Cells[0].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[1].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[2].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[3].Style.BackColor = tekCol;
        //    }
        //}

        //public void fill_with_work_sort_by_date(DataGridView dgv)
        //{
        //    paint_dgv_to_white(dgv);
        //    dgv.RowCount = w_s_d.Length;
        //    for (var i = 0; i < w_s_d.Length; i++)
        //    {
        //        dgv.Rows[i].Cells[0].Value = Path.GetFileName(w_s_d[i].way);
        //        dgv.Rows[i].Cells[1].Value = w_s_d[i].name;
        //        dgv.Rows[i].Cells[2].Value = w_s_d[i].date_day;
        //        dgv.Rows[i].Cells[3].Value = w_s_d[i].date_time;

        //        var tekCol = Get_Color_For_Paint_Work_Dirs(date_mas_arch_ALL, w_s_d[i]);

        //        dgv.Rows[i].Cells[0].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[1].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[2].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[3].Style.BackColor = tekCol;
        //    }
        //}

        //public void fill_with_arch_sort_by_name(DataGridView dgv)
        //{
        //    paint_dgv_to_white(dgv);
        //    dgv.RowCount = a_s_n.Length;
        //    for (var i = 0; i < a_s_n.Length; i++)
        //    {
        //        dgv.Rows[i].Cells[0].Value = Path.GetFileName(a_s_n[i].way);
        //        dgv.Rows[i].Cells[1].Value = a_s_n[i].name;
        //        dgv.Rows[i].Cells[2].Value = a_s_n[i].date_day;
        //        dgv.Rows[i].Cells[3].Value = a_s_n[i].date_time;

        //        var tekCol = Get_Color_For_Paint_Arch_Dirs(date_mas_work_ALL, a_s_n[i]);

        //        dgv.Rows[i].Cells[0].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[1].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[2].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[3].Style.BackColor = tekCol;
        //    }
        //}

        //public void fill_with_arch_sort_by_date(DataGridView dgv)
        //{
        //    paint_dgv_to_white(dgv);
        //    dgv.RowCount = a_s_d.Length;
        //    for (var i = 0; i < a_s_d.Length; i++)
        //    {
        //        dgv.Rows[i].Cells[0].Value = Path.GetFileName(a_s_d[i].way);
        //        dgv.Rows[i].Cells[1].Value = a_s_d[i].name;
        //        dgv.Rows[i].Cells[2].Value = a_s_d[i].date_day;
        //        dgv.Rows[i].Cells[3].Value = a_s_d[i].date_time;


        //        var tekCol = Get_Color_For_Paint_Arch_Dirs(date_mas_work_ALL, a_s_d[i]);
        //        dgv.Rows[i].Cells[0].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[1].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[2].Style.BackColor = tekCol;
        //        dgv.Rows[i].Cells[3].Style.BackColor = tekCol;
        //    }
        //}

        //private void sort_date_mas(ref tm[] mas)
        //{
        //    var count = mas.Length;
        //    for (var i = 0; i < count; i++)
        //    {
        //        for (var j = 0; j < count - 1; j++)
        //        {
        //            var cmp = (mas[j].date_full - mas[j + 1].date_full).TotalSeconds;
        //            if (mas[j].date_full <= mas[j + 1].date_full)
        //            {
        //                var tm = mas[j + 1];
        //                mas[j + 1] = mas[j];
        //                mas[j] = tm;
        //            }
        //        }
        //    }
        //}

        //private void sort_by_name()
        //{
        //    var count = date_mas_work.Length;
        //    Array.Resize(ref w_s_n, count);
        //    string[] w_n;
        //    w_n = new string[count];
        //    for (var i = 0; i < w_n.Length; i++)
        //    {
        //        w_n[i] = Path.GetFileName(date_mas_work[i].way);
        //    }
        //    Array.Sort(w_n);
        //    int pos;
        //    for (var i = 0; i < count; i++)
        //    {
        //        pos = Array.IndexOf(w_n, Path.GetFileName(date_mas_work[i].way));
        //        w_s_n[pos] = date_mas_work[i];
        //    }


        //    count = date_mas_arch.Length;
        //    Array.Resize(ref a_s_n, count);
        //    string[] w_a;
        //    w_a = new string[count];
        //    for (var i = 0; i < w_a.Length; i++)
        //    {
        //        w_a[i] = Path.GetFileName(date_mas_arch[i].way);
        //    }
        //    Array.Sort(w_a);

        //    for (var i = 0; i < count; i++)
        //    {
        //        pos = Array.IndexOf(w_a, Path.GetFileName(date_mas_arch[i].way));
        //        a_s_n[pos] = date_mas_arch[i];
        //    }
        //}

        //private void sort_by_date()
        //{
        //    var count = date_mas_work.Length;
        //    Array.Resize(ref w_s_d, count);
        //    w_s_d = date_mas_work;
        //    sort_date_mas(ref w_s_d);


        //    count = date_mas_arch.Length;
        //    Array.Resize(ref a_s_d, count);
        //    a_s_d = date_mas_arch;
        //    sort_date_mas(ref a_s_d);
        //}

        public struct tm
        {
            public string vp;
            public string date_day;
            public DateTime date_full;
            public string date_time;
            public string way;
            public string name;
            public Color paint;
        }
    }
}