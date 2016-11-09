using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Browser : Form
    {
        public static Main_Form Mainform_Parent;
        public static File_Work Browser_dautcher_File_Work_Form;
        public static Browser thisform;
        public int A_Dir_Count;
        public double A_Dir_Size;
        public Boolean dir_info_count;
        private Thread th;
        public int W_Dir_Count;
        public double W_Dir_Size;
        private DateTm browser = new DateTm();

        public Browser()
        {
            InitializeComponent();
            Browser_Refresh();
        }

        public static void Browser_Close()
        {
            thisform.Close();
            thisform = null;
        }

        public void Browser_Media_Info_load(string path)
        {
            if (Media_Info.permission())
            {
                Media_Info_Show.Form_Lauch(path);
            }
        }

        public static Browser Browser_Primary_Start(Main_Form parent)
        {
            Mainform_Parent = parent;
            thisform = new Browser();

            Mainform_Parent.Height = SystemInformation.PrimaryMonitorSize.Height - 30;
            thisform.TopLevel = false;
            thisform.Parent = Mainform_Parent.Browser_Form_PANEL;
            thisform.Width = Mainform_Parent.Browser_Form_PANEL.Width;
            thisform.Height = Mainform_Parent.Browser_Form_PANEL.Height;
            thisform.dgv.Height = Mainform_Parent.Browser_Form_PANEL.Height - thisform.dgv.Top - 100;
            

            
            thisform.Show();
            thisform.File_Work_Lauch();
            return thisform;
        }

        public void File_Work_Lauch()
        {
            Browser_dautcher_File_Work_Form = new File_Work(this);
            Browser_dautcher_File_Work_Form.TopLevel = false;
            Browser_dautcher_File_Work_Form.par = Mainform_Parent;
            Browser_dautcher_File_Work_Form.Parent = Mainform_Parent.File_Work_PANEL;
            Browser_dautcher_File_Work_Form.Width = Mainform_Parent.File_Work_PANEL.Width;
            Browser_dautcher_File_Work_Form.Height = Mainform_Parent.File_Work_PANEL.Height;
            Browser_dautcher_File_Work_Form.Show();
        }

        public void File_Work_Restart()
        {
            Browser_dautcher_File_Work_Form.Close();
            File_Work_Lauch();
        }

        public void File_Work_Restart_Special(string new_VL)
        {
            Browser_dautcher_File_Work_Form.Close();
            Browser_dautcher_File_Work_Form = new File_Work(this);

            Browser_dautcher_File_Work_Form.TopLevel = false;
            Browser_dautcher_File_Work_Form.par = Mainform_Parent;
            Browser_dautcher_File_Work_Form.Parent = Mainform_Parent.File_Work_PANEL;
            Browser_dautcher_File_Work_Form.Width = Mainform_Parent.File_Work_PANEL.Width;
            Browser_dautcher_File_Work_Form.Height = Mainform_Parent.File_Work_PANEL.Height;
           
           
            Browser_dautcher_File_Work_Form.VL_TBox.Text = new_VL;
            Browser_dautcher_File_Work_Form.load_info_without_browser_update();
           
            Browser_dautcher_File_Work_Form.Show();
        }

        public static void File_Work_Close()
        {
   
            Browser_dautcher_File_Work_Form.Close();
        }

        public void Fie_Form_Ask_To_Rebuild()
        {
            Browser_Refresh();
        }

        private void WB_S_N_Rbut_CheckedChanged(object sender, EventArgs e)
        {
            build_dgv();
        }

        private void WB_D_all_Rbut_CheckedChanged(object sender, EventArgs e)
        {
            Browser_Refresh();
        }

        private void build_dgv()
        {




            
            if (WB_work_Rbut.Checked)
            {
                long cons = 1;

                B_Dir_Count_TBox.Text = W_Dir_Count.ToString();
                B_Dir_Size_TBox.Text = (W_Dir_Size/cons).ToString("F");
                TeraBit_Label.Visible = true;
                MegaBit_Label.Visible = false;

                if (WB_D_all_Rbut.Checked)
                {
                    browser.get_table(browser.date_mas_work_ALL,ref dgv);
                }
                else
                {
                    browser.get_table(browser.date_mas_work, ref dgv);
                }
            }
            else
            {
                long cons = 1;
                cons = 1024 * 1024;
                B_Dir_Count_TBox.Text = A_Dir_Count.ToString();
                B_Dir_Size_TBox.Text = (A_Dir_Size*(cons)).ToString("F");
                TeraBit_Label.Visible = false;
                MegaBit_Label.Visible = true;

                if (WB_D_all_Rbut.Checked)
                {
                    browser.get_table(browser.date_mas_arch_ALL, ref dgv);
                }
                else
                {
                    browser.get_table(browser.date_mas_arch, ref dgv);
                }
            }




            


            dgv.Refresh();


            if (dir_info_count)
            {
                if (WB_work_Rbut.Checked)
                {
                    if (W_Dir_Size >= Ingest_Assistant.Properties.Settings.Default.Work_Max_Value)
                    {
                        Capacity_GrBox.BackColor = Color.Tomato;
                    }
                    else
                    {
                        Capacity_GrBox.BackColor = Color.LimeGreen;
                    }
                }
                else
                {
                    if (A_Dir_Size >= Ingest_Assistant.Properties.Settings.Default.Work_Max_Value)
                    {
                        Capacity_GrBox.BackColor = Color.Tomato;
                    }
                    else
                    {
                        Capacity_GrBox.BackColor = Color.LimeGreen;
                    }
                }
            }
            repaint();
            dgv.Refresh();
        }


        public void repaint()
        {
            dgv.Columns[4].Visible = false;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                Color cl = (Color)dgv.Rows[i].Cells[4].Value;
                for (int j = 0; j < 4; j++)
                {
                    dgv.Rows[i].Cells[j].Style.BackColor = cl;
                }
            }
        }

        public void Browser_Dir_Info_Collect()
        {
            var a = Directory.GetDirectories(Ingest_Assistant.Properties.Settings.Default.Archive_Path);
            A_Dir_Count = a.Length;
            double size = 0;
            foreach (var temp in a)
            {
                var in_dir = Directory.GetFiles(temp);
                foreach (var tm in in_dir)
                {
                    var cur = new FileInfo(tm);
                    size += Convert.ToDouble(cur.Length);
                }
            }
            A_Dir_Size = size;


            var w = Directory.GetDirectories(Ingest_Assistant.Properties.Settings.Default.Work_Path);
            W_Dir_Count = w.Length;
            size = 0;
            foreach (var temp in w)
            {
                var in_dir = Directory.GetFiles(temp);
                foreach (var tm in in_dir)
                {
                    var cur = new FileInfo(tm);
                    size += Convert.ToDouble(cur.Length);
                }
            }
            W_Dir_Size = size;

            long constt = 1024*1024;
            constt *= 1024*1024;
            W_Dir_Size /= constt;
            A_Dir_Size /= constt;

            dir_info_count = true;








            

        }









        









        public void Browser_Refresh()
        {
            long start = Log_Class.Action("Обновление браузера СТАРТ",3);
            browser.paint_dgv_to_white(dgv);
            br_build();
            build_dgv();
            
            long stop = Log_Class.Action("Обновление браузера СТОП",3);
            Log_Class.ReWrite_Start(start,stop);
            dgv.Sort(dgv.Columns[0],ListSortDirection.Descending);
        }

        public void br_build()
        {
            //Browser_Dir_Info_Collect();
            browser.init_all(Ingest_Assistant.Properties.Settings.Default.Work_Path, Ingest_Assistant.Properties.Settings.Default.Archive_Path, WB_date_picker.Value);
        }

        private void WB_archive_Rbut_CheckedChanged(object sender, EventArgs e)
        {
            build_dgv();
        }

        private void WB_date_picker_ValueChanged_1(object sender, EventArgs e)
        {
            if(WB_D_setd_Rbut.Checked) Browser_Refresh();
        }

        private void dgv_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            if (dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != null)
                Browser_dautcher_File_Work_Form.Reload_With_Input(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

       

        private void Capacity_Calc_Click(object sender, EventArgs e)
        {
            long start = Log_Class.Action("Подсчет обьема папок СТАРТ",5);
            //Thread th = ProgressForm.Prepare_Thread("Считаем обьемы папок");

            Browser_Dir_Info_Collect();
           // ProgressForm.StopForm();
            build_dgv();
           // th.Abort();
            long stop = Log_Class.Action("Подсчет обьема папок СТОП",5);
            Log_Class.ReWrite_Start(start,stop);
        }

        //private void Browser_Activated(object sender, EventArgs e)
        //{
        //    if(Browser_dautcher_File_Work_Form!=null) Browser_dautcher_File_Work_Form.WindowState=FormWindowState.Normal;
        //}

        private void Browser_SizeChanged(object sender, EventArgs e)
        {
            if (Browser_dautcher_File_Work_Form != null &&
                Browser_dautcher_File_Work_Form.WindowState == FormWindowState.Minimized &&
                WindowState != FormWindowState.Minimized)
            {
                Browser_dautcher_File_Work_Form.WindowState = FormWindowState.Normal;
                Mainform_Parent.WindowState = FormWindowState.Normal;
            }
        }

        public void Main_ReSize()
        {
            Mainform_Parent.WindowState = FormWindowState.Normal;
        }

        private void Browser_Refresh_But_Click(object sender, EventArgs e)
        {
          
            Browser_Refresh();
          
        }

        public void Time_Count_Fucnction()
        {
            var outt = new Queue<string>();
            var left = WB_date_picker.Value.Date;
            var right = left.AddDays(1);
            var sqlcon = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            var zapros = " SELECT Time_Of_Registration, Total_Time FROM     MetaDataArchive WHERE  (Time_Of_Registration Between '" + left.ToString("yyyy.MM.dd HH:mm:ss") + "'   and   '" + right.ToString("yyyy.MM.dd HH:mm:ss") + "')";
            SQL_Class.ReadValues(zapros, ref sqlcon);
            while (sqlcon.SQL_DataReader.Read())
            {
                var temp = "";
                temp = sqlcon.SQL_DataReader.GetString(1);
                outt.Enqueue(temp);
            }

            sqlcon.Manualy_Close_Connection();
            var time_mas = outt;

            

            var max = time_mas.Count;
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
            var mm = Total.Minutes;
            var ss = Total.Seconds;
            var norma = Convert.ToInt32(Ingest_Assistant.Properties.Settings.Default.Day_Work_Time);
            //var itogo = hh.ToString("##") + ":" + mm.ToString("##") + ":" + ss.ToString("##");

            //TimeSpan it = new TimeSpan(0, hh, mm, ss);




           

            Time_Count_PrBar.Maximum = norma;

            if (hh > norma)
            {
                Time_Count_L1_Lable.Text = hh + "/" + norma;
                Time_Count_L2_Lable.Text = "Аппаратная перегружена";
                Time_Count_PrBar.Value = Time_Count_PrBar.Maximum;
                Time_Count_GrBox.BackColor = Color.Yellow;
            }
            else
            {
                Time_Count_L1_Lable.Text = hh + "/" + norma;
                Time_Count_L2_Lable.Text = "Выполнение плана - долг! Перевыполнение - ЧЕСТЬ!!!";
                Time_Count_PrBar.Value = hh;
                Time_Count_GrBox.BackColor = Color.CornflowerBlue;
            }
            //th.Abort();
        }

        private void Time_Count_Refresh_Button_Click(object sender, EventArgs e)
        {
            if (WB_D_setd_Rbut.Checked)
            {
                long start = Log_Class.Action("Расчет загрузки аппаратной СТАРТ", 5);
                Time_Count_Fucnction();
                long stop = Log_Class.Action("Расчет загрузки аппаратной СТОП", 5);
                Log_Class.ReWrite_Start(start, stop);
            }
            else
            {
                MessageBox.Show("Установите переключатель времени в режим 'За указанный день' и выберите дату");
            }
        }

       

        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void Browser_Load(object sender, EventArgs e)
        {
                    }

        public static void RefreshForms()
        {Thread.Sleep(200);
            if (thisform != null)
            {
              //  thisform.Parent = Mainform_Parent.Browser_Form_PANEL;
                thisform.Size = Mainform_Parent.Browser_Form_PANEL.Size;
                thisform.Refresh();
            }
            if (Browser_dautcher_File_Work_Form != null)
            {
              //  Browser_dautcher_File_Work_Form.Parent = Mainform_Parent.File_Work_PANEL;
                Browser_dautcher_File_Work_Form.Size = Mainform_Parent.File_Work_PANEL.Size;
                Browser_dautcher_File_Work_Form.Refresh();
            }
        }

        private void Exit_But_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_Sorted(object sender, EventArgs e)
        {
            repaint();
        }

        private void data_Set_But_Click(object sender, EventArgs e)
        {
            WB_date_picker.Value=DateTime.Today;
        }
    }
}