using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ingest_Assistant.Properties;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Ingest_Assistant
{
   

    public partial class Raport_Form : Form
    {
        public Boolean ADITIONAL_WORK;
        private Process[] old_excels;
        private Queue<Rap_Element> rap_mas;
        ASM_Time_Reservation_Form frm;

       

        public Raport_Form()
        {
            InitializeComponent();
            frm = null;
            if (SQL_Class.ReadValueInt32("Select L_Priority from login where L_ID=" + Settings.Default.User_ID, Settings.Default.Setting_Base_Path)==3)
            {
                
                List<string> mas=new List<string>();
                string zap = "select Name from settings where Avalible =1";
                SQL_Class cl= SQL_Class.Create_class(Settings.Default.Setting_Base_Path);
                SQL_Class.ReadValues(zap, ref cl);
                while (cl.SQL_DataReader.Read())
                {
                    mas.Add(cl.SQL_DataReader.GetString(0));
                }
                string[] datasourse = new string[mas.Count];
                for (int i = 0; i < datasourse.Length; i++)
                {
                    datasourse[i] = mas[i];
                }
                ProfileSelection_CmBox.DataSource = datasourse;
                ProfileSelection_CmBox.Enabled = true;
            }
            else
            {
                string[] datasourse = new string[1];
                datasourse[0] = Settings.Default.Setting_Profile;
                ProfileSelection_CmBox.DataSource = datasourse;
                ProfileSelection_CmBox.Enabled = false;
            }
        }

        private void generate_raport_But_Click(object sender, EventArgs e)
        {
            int i = dgv.RowCount;
            if (ADITIONAL_WORK && i == 0)
            {
                refresh_add_work();
            }
            make_raport();
        }

        public static void Form_Lauch()
        {
            var frm = new Raport_Form();
            frm.Show();
        }

        public void draw_line(int id, Worksheet Sheet)
        {
            Sheet.get_Range("A" + id, "G" + id).Borders.ColorIndex = 0;
            Sheet.get_Range("A" + id, "G" + id).Borders.LineStyle = XlLineStyle.xlContinuous;
            Sheet.get_Range("A" + id, "G" + id).Borders.Weight = XlBorderWeight.xlThin;
        }

        public void make_raport()
        {
            collect_info();
            var cur_rap = prepare_file();


            old_excels = Process.GetProcessesByName("EXCEL");
            var old_excels_id = new Queue<string>();
            foreach (var Pr in old_excels)
            {
                old_excels_id.Enqueue(Pr.Id.ToString());
            }


            var ExcelAppR = new Application();
            Workbook ObjWorkBook;

            ObjWorkBook = ExcelAppR.Workbooks.Open(cur_rap);
            Worksheet m_workSheet = null;
            m_workSheet = ExcelAppR.ActiveSheet;

            // ExcelAppR.Visible = true;
            m_workSheet.Unprotect();

            m_workSheet.Cells[3, 3] = dateTimePicker.Value.ToString("yyyy.MM.dd");
            var max = 0;

            max = rap_mas.Count;


            var Total = new TimeSpan(0, 0, 0);


            for (var i = 1; i <= max; i++)
            {
                var temp = rap_mas.Dequeue();
                draw_line(4 + i, m_workSheet);
                m_workSheet.Cells[4 + i, 1] = i;
                m_workSheet.Cells[4 + i, 2] = temp.ViPlanner;
                m_workSheet.Cells[4 + i, 3] = temp.Title;
                m_workSheet.Cells[4 + i, 4] = temp.Media_Type;
                m_workSheet.Cells[4 + i, 5] = temp.Type_Of_Work;
                m_workSheet.Cells[4 + i, 6] = temp.Line;
                m_workSheet.Cells[4 + i, 7] = temp.Total_Time;

                try
                {
                    var h = Convert.ToInt32(temp.Total_Time.Substring(0, 2));
                    var m = Convert.ToInt32(temp.Total_Time.Substring(3, 2));
                    var s = Convert.ToInt32(temp.Total_Time.Substring(6, 2));
                    Total += new TimeSpan(h, m, s);
                }
                catch (Exception)
                {
                }
            }

            max++;
            if (ADITIONAL_WORK)
            {
                var j = max;
                var end = j + dgv.RowCount;
                max = end;
                var index = 0;
                for (var i = j; i < end; i++)
                {
                    draw_line(4 + i, m_workSheet);
                    m_workSheet.Cells[4 + i, 1] = i;
                    m_workSheet.Cells[4 + i, 2] = "------";
                    m_workSheet.Cells[4 + i, 3] = "Дополнительные работы";
                    m_workSheet.Cells[4 + i, 4] = "-------";
                    m_workSheet.Cells[4 + i, 5] = dgv.Rows[index].Cells[0].Value.ToString();
                    m_workSheet.Cells[4 + i, 6] = dgv.Rows[index].Cells[1].Value.ToString();
                    m_workSheet.Cells[4 + i, 7] = dgv.Rows[index].Cells[2].Value.ToString();

                    try
                    {
                        var h = Convert.ToInt32(dgv.Rows[index].Cells[2].Value.ToString().Substring(0, 2));
                        var m = Convert.ToInt32(dgv.Rows[index].Cells[2].Value.ToString().Substring(3, 2));
                        var s = Convert.ToInt32(dgv.Rows[index].Cells[2].Value.ToString().Substring(6, 2));
                        Total += new TimeSpan(h, m, s);
                    }
                    catch (Exception)
                    {
                    }
                    index++;
                }
            }


            draw_line(4 + max, m_workSheet);


            var hh = 0;
            max++;
            hh = Total.Hours + Total.Days*24;
            string hhh;

            if (hh.ToString().Length == 1)
            {
                hhh = "0" + hh.ToString();
            }
            else
            {
                hhh = hh.ToString();
            }

            string mm;
            if (Total.Minutes.ToString().Length == 1)
            {
                mm = "0" + Total.Minutes.ToString();
            }
            else
            {
                mm = Total.Minutes.ToString();
            }

            string ss;
            if (Total.Seconds.ToString().Length == 1)
            {
                ss = "0" + Total.Seconds.ToString();
            }
            else
            {
                ss = Total.Seconds.ToString();
            }
         


            //TimeSpan it=new TimeSpan(0,hh,mm,ss);




            var itogo = "Итого:  " + hh + ":" + mm + ":" +ss;
           // var itogo = "Итого:  " +it.ToString("HH:mm:ss");
            draw_line(4 + max, m_workSheet);
            m_workSheet.Cells[4 + max, 7] = itogo;
            ObjWorkBook.Save();
            ObjWorkBook.Close(null, null, null);
            ExcelAppR.Quit();
            Marshal.ReleaseComObject(ExcelAppR);
            ExcelAppR = null;
            ObjWorkBook = null;
            m_workSheet = null;
            GC.Collect();
            var new_excels = Process.GetProcessesByName("EXCEL");
            foreach (var Pr in new_excels)
            {
                if (!old_excels_id.Contains(Pr.Id.ToString())) Pr.Kill();
            }
            Process.Start(cur_rap);

            Close();
        }

        public void collect_info()
        {
            rap_mas = new Queue<Rap_Element>();
            var left = dateTimePicker.Value.Date;
            var right = left.AddDays(1);
            //var col = SQL_Class.ReadValueInt32("Select Count(*) from MetaDataArchive",Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            var sqlcon = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
           
            
                var zapros =
                    " SELECT Time_Of_Registration,Ingest_Line, Total_Time, Title, Media_Type, Type_Of_Work, ViPlanner,Reel_ID, Source_Duration, Edit_Line FROM     MetaDataArchive WHERE PrID="+SQL_Class.ReadValueInt32("select ID from settings where Name ='"+ProfileSelection_CmBox.SelectedItem.ToString()+"'",Settings.Default.Setting_Base_Path)
                    +" AND (Time_Of_Registration Between '" + left.ToString("yyyy.MM.dd HH:mm:ss") + "'   and   '" + right.ToString("yyyy.MM.dd HH:mm:ss") + "')";
                SQL_Class.ReadValues(zapros,ref sqlcon);
                while (sqlcon.SQL_DataReader.Read())
                {
                    var temp = new Rap_Element();
                    temp.Line = sqlcon.SQL_DataReader.GetString(1) + ", " + sqlcon.SQL_DataReader.GetString(9);
                    temp.Total_Time = sqlcon.SQL_DataReader.GetString(2);
                    temp.Title = sqlcon.SQL_DataReader.GetString(3) + "  " + sqlcon.SQL_DataReader.GetString(8);
                    temp.Media_Type = sqlcon.SQL_DataReader.GetString(4) + "  " + sqlcon.SQL_DataReader.GetString(7);
                    temp.Type_Of_Work = sqlcon.SQL_DataReader.GetString(5);
                    temp.ViPlanner = sqlcon.SQL_DataReader.GetString(6);
                    rap_mas.Enqueue(temp);
                
              
               }
            sqlcon.Manualy_Close_Connection();
        }

        public string prepare_file()
        {
            var pat = Ingest_Assistant.Properties.Settings.Default.Work_Path;
            pat += "\\Raport";
            if (!Directory.Exists(pat))
            {
                DirectoryM.CreateDirectory(pat);
                Log_Class.Create_Dir("Raport", pat);
            }
            var raport_name = "Raport#" + dateTimePicker.Value.ToString("d-M-yyyy") + "#" +
                              DateTime.Now.ToString("d-M-yyyy HH-MM-ss") + ".xls";
            var dest = pat + "\\" + raport_name;
            var from = Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\Raport.xls";
            FileM.Copy(from, dest);
            Log_Class.Copy("Raport", from, dest);
            return dest;
        }

        private void Raport_Form_Load(object sender, EventArgs e)
        {
            ADITIONAL_WORK = false;
            var work_types = Ingest_Assistant.Properties.Settings.Default.Additional_Work_Types.Split('|');
            Type_cmBox.DataSource = work_types;
            Refresh();
            refresh_add_work();
            if (Properties.Settings.Default.Setting_Profile.Contains("ASM"))
            {
                frm = new ASM_Time_Reservation_Form();
                frm.TopLevel = false;
                frm.Parent = Panel;
                frm.DT_Picker_Inside = dateTimePicker;
                frm.Show();
                frm.load_to_DGV();
            }
            else
            {
                Size=new Size(AD_Start_But.Width+100,Size.Height-Panel.Height);
            }
            Refresh();

        }

       
        public struct Rap_Element
        {
            public string Line;
            public string Media_Type;
            public string Title;
            public string Total_Time;
            public string Type_Of_Work;
            public string ViPlanner;
        }


        private void AD_Start_But_Click(object sender, EventArgs e)
        {
            ADITIONAL_WORK = true;
            AD_Start_But.Visible = false;
        }

        private void AD_Cancel_But_Click(object sender, EventArgs e)
        {
            AD_Start_But.Visible = true;
            ADITIONAL_WORK = false;
        }

       


        public void refresh_add_work()
        {
            DateTime start = dateTimePicker.Value.Date;
            DateTime stop = dateTimePicker.Value.AddDays(1).Date;
           
            string zapros = "Select ID,Date,Type,Line,Duration from AddWork where (Date between '" +
                            start.ToString("yyyy.MM.dd HH:mm:ss") + "'   and '" + stop.ToString("yyyy.MM.dd HH:mm:ss") +
                            "') and PrID=" + SQL_Class.ReadValueInt32("select ID from settings where Name ='"+ProfileSelection_CmBox.SelectedItem.ToString()+"'",Settings.Default.Setting_Base_Path);

            SQL_Class sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            SQL_Class.ReadValues(zapros, ref sqlcl);
            int i = 0;
            dgv.RowCount = i + 1;
            while (sqlcl.SQL_DataReader.Read())
            {
                dgv.Rows[i].Cells[0].Value = sqlcl.SQL_DataReader.GetString(2);
                dgv.Rows[i].Cells[1].Value = sqlcl.SQL_DataReader.GetString(3);
                dgv.Rows[i].Cells[2].Value = sqlcl.SQL_DataReader.GetString(4);
                dgv.Rows[i].Cells[3].Value = sqlcl.SQL_DataReader.GetInt64(0).ToString();
                
                i++;
                dgv.RowCount = i + 1;
            }

            dgv.RowCount = i;
            sqlcl.Manualy_Close_Connection();
            if (i == 0)
            {
                ADITIONAL_WORK = false;
                AD_Start_But.Visible = true;
            }
            else
            {
                ADITIONAL_WORK = true;
                AD_Start_But.Visible = false;
            }
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
           
        }

        private void Refresh_But_Click(object sender, EventArgs e)
        {
           refresh_add_work();
        }

        private void AD_Add_Line_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var col = dgv.RowCount;
                dgv.RowCount++;
                dgv.Rows[col].Cells[0].Value = Type_cmBox.SelectedItem.ToString();
                dgv.Rows[col].Cells[1].Value = Line_cmBox.SelectedItem.ToString();
                dgv.Rows[col].Cells[2].Value = Time_cmBox.SelectedItem.ToString();

                DateTime cur_date = dateTimePicker.Value.Date.AddHours(1).AddMinutes(1).AddSeconds(1);

                string zapros = "insert into AddWork (Date,Type,Line,Duration,PrID) values ('" +
                                cur_date.ToString("yyyy.MM.dd HH:mm:ss") + "','" +
                                dgv.Rows[col].Cells[0].Value.ToString() + "','" + dgv.Rows[col].Cells[1].Value.ToString() +
                                "','" + dgv.Rows[col].Cells[2].Value.ToString() + "'," + SQL_Class.ReadValueInt32("select ID from settings where Name ='" + ProfileSelection_CmBox.SelectedItem.ToString() + "'", Settings.Default.Setting_Base_Path) + ")";
                SQL_Class.Execute(zapros, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
                refresh_add_work();
            }
            catch (Exception)
            {
               refresh_add_work(); 
            }
           
        }

        private void Del_Work_But_Click(object sender, EventArgs e)
        {

            if (dgv.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow VARIABLE in dgv.SelectedRows)
                {
                    long id = Convert.ToInt64(VARIABLE.Cells[3].Value);
                    string zapros = "delete from AddWork where ID=" + id;
                    SQL_Class.Execute(zapros, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
                }
            }
           
                refresh_add_work();
            
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            refresh_add_work();
            if (frm != null)
            {
                frm.load_to_DGV();
            }
        }

        private void ProfileSelection_CmBox_SelectedValueChanged(object sender, EventArgs e)
        {
            refresh_add_work();
        }
    }





    public class Profile
    {
        public Profile(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id;
        public string name;
    }

}