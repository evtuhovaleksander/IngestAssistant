using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Log_Show : Form
    {
        public Log_Show()
        {

            ArchiveOldLogs();

            InitializeComponent();
            LAST_UPDATE = new DateTime(1990,1,1);
            Filter_Aplied = true;





             Group_Filter_1_Color_But.BackColor =Ingest_Assistant.Properties.Settings.Default.Group1Color ;
             Group_Filter_2_Color_But.BackColor= Ingest_Assistant.Properties.Settings.Default.Group2Color ;
            Group_Filter_3_Color_But.BackColor  =Ingest_Assistant.Properties.Settings.Default.Group3Color ;
            Group_Filter_4_Color_But.BackColor  =Ingest_Assistant.Properties.Settings.Default.Group4Color ;
             Group_Filter_5_Color_But.BackColor=Ingest_Assistant.Properties.Settings.Default.Group5Color;










        }

        public Element[] All_Elements;
        public Element[] Curent_Elements;



        private void Load_info_But_Click(object sender, EventArgs e)
        {
            All_Elements_Load();
            DGV_Fill();
        }

        public class Element
        {
            public long ID;
            public string VP;
            public string sTime;
            public DateTime Time;
            public string User;
            public string PC;
            public int Group;
            public string Name;
            public string Description;
            public string From;
            public string To;
            public Boolean Fineshed;
            public long F_ID;
         }

        public void All_Elements_Load()
        {
            long max_ID = Convert.ToInt64(SQL_Class.ReadValue("Select Max(ID) from Logs",Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));

            Picting_Progress_Bar.Maximum = 100;
            Picting_Progress_Bar.Value = 50;
            Refresh();

            string zapros = "";


           


            long start = 0;
            long stop = 0;

            if (Col_Last_RBut.Checked)
            {
                stop = max_ID;
                if (Col_trBar.Value > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV && Out_Timer_RBut.Checked)
                {
                    start = max_ID - Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
                }
                else
                {
                    start = max_ID - Col_trBar.Value; 
                }
               
            }
            else
            {
               // start = Convert.ToInt64(Col_Start_Tbox.Text); stop=Convert.ToInt64( Col_Stop_Tbox.Text );
                start = 1; stop = max_ID;
            }
            if (start == 0) start++;
            Queue<Element> temp_mas=new Queue<Element>();
            SQL_Class readerSql = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
            for (long i = start; i <= stop; i++)
            {
                zapros =
               "SELECT        VP, Time, Userr, PC, Groupp, Name, Description, Fromm, Too, Finished, F_ID FROM            Logs  Where  ID= " +i+" ";

                if (User_Filter_chBox.Checked)
                {
                    zapros += "AND Userr='" + User_Filter_cmBox.SelectedItem.ToString() + "'  ";
                }

                if (VP_Filter_chBox.Checked)
                {
                    zapros += "AND VP='" + VP_Filter_TBox.Text + "'  ";
                }

                if (Group_Filter_chBox.Checked)
                {
                    zapros += " AND(";
                    if (Group_Filter_1_chBox.Checked)
                    {
                        zapros += "Groupp=1 OR ";
                    }

                    if (Group_Filter_2_chBox.Checked)
                    {
                        zapros += "Groupp=2 OR ";
                    }
                    if (Group_Filter_3_chBox.Checked)
                    {
                        zapros += "Groupp=3 OR ";
                    }
                    if (Group_Filter_4_chBox.Checked)
                    {
                        zapros += "Groupp=4 OR ";
                    }
                    if (Group_Filter_5_chBox.Checked)
                    {
                        zapros += "Groupp=5 OR ";
                    }
                    zapros += "Groupp=0 ) ";
                }


                if (Time_Filter_ChBox.Checked)
                {
                    DateTime d1;
                    DateTime d2;
                    if (Time_Filter_Cur_Day_rBut.Checked)
                    {
                        d1 = Time_Filter_Date1_DatePicker.Value.Date;
                        d2 = d1.AddDays(1);
                    }
                    else
                    {
                        d1 = Time_Filter_Date1_DatePicker.Value.Date;
                        d2 = Time_Filter_Date2_DatePicker.Value.Date;
                    }
                    zapros += "AND ([Time] between '" + d1.ToString("yyyy.MM.dd HH:mm:ss") + "' and  '" +
                              d2.ToString("yyyy.MM.dd HH:mm:ss") + "'  )";

                }



                try
                {
                    SQL_Class.ReadValues(zapros, ref readerSql);
                   // readerSql.SQL_DataReader.Read();
                    while (readerSql.SQL_DataReader.Read())
                    {

                        Element temp = new Element();
                        temp.ID = i;
                        temp.VP = readerSql.SQL_DataReader.GetString(0);
                        temp.sTime = readerSql.SQL_DataReader.GetDateTime(1).ToString("O");
                        temp.Time = readerSql.SQL_DataReader.GetDateTime(1);
                        temp.User = readerSql.SQL_DataReader.GetString(2);
                        temp.PC = readerSql.SQL_DataReader.GetString(3);
                        temp.Group = readerSql.SQL_DataReader.GetInt32(4);
                        temp.Name = readerSql.SQL_DataReader.GetString(5);
                        temp.Description = readerSql.SQL_DataReader.GetString(6);
                        temp.From = readerSql.SQL_DataReader.GetString(7);
                        temp.To = readerSql.SQL_DataReader.GetString(8);
                        temp.Fineshed = readerSql.SQL_DataReader.GetBoolean(9);
                        temp.F_ID = readerSql.SQL_DataReader.GetInt64(10);
                        temp_mas.Enqueue(temp);
                    }
                    if(!readerSql.SQL_DataReader.IsClosed)readerSql.SQL_DataReader.Close();
                }
                catch (Exception ex)
                {

                }
            }
            readerSql.Manualy_Close_Connection();
            All_Elements=new Element[0];
            if (Time_Filter_ChBox.Checked)
            {
                DateTime d1;
                DateTime d2;
                if (Time_Filter_Cur_Day_rBut.Checked)
                {
                    d1 = Time_Filter_Date1_DatePicker.Value.Date;
                    d2 = d1.AddDays(1);
                }
                else
                {
                    d1 = Time_Filter_Date1_DatePicker.Value.Date;
                    d2 = Time_Filter_Date2_DatePicker.Value.Date;
                }
                foreach (Element temp in temp_mas)
                {
                    if (temp.Name.Contains("СТОП") && Stop_Marks_Show_rBut.Checked)
                    {
                        if (temp.Time > d1 && temp.Time < d2)
                        {
                            Array.Resize(ref All_Elements, All_Elements.Length + 1);
                            All_Elements[All_Elements.Length - 1] = temp;
                        }
                    }
                }
            }
            
                 
                 foreach (Element temp in temp_mas)
                {
                    if (!(temp.Name.Contains("СТОП") && Stop_Marks_DONTShow_rBut.Checked))
                    {
                        
                        Element rewrite = temp;
                        if (Stop_Marks_DONTShow_rBut.Checked&&rewrite.Name.Contains("СТАРТ"))
                        {
                            string str = rewrite.Name.Substring(0,rewrite.Name.Length-5);
                        
                            rewrite.Name = str;
                        }
                      
                        Array.Resize(ref All_Elements, All_Elements.Length + 1);
                        All_Elements[All_Elements.Length - 1] = rewrite;
                    }
                 

                }
            

          
        }





        public void DGV_Fill()
        {
            int start=0;
            int stop=0;
            if (All_Elements.Length > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
            {
                Log_Col_Ask.Ask_Diapason(All_Elements.Length,ref start,ref stop);
                DGV.RowCount = stop-start+1;
            }
            else
            {
                start = 0;
                stop = All_Elements.Length;
                DGV.RowCount = All_Elements.Length;
            }
            
            Picting_Progress_Bar.Maximum = stop - start + 1;
            Picting_Progress_Bar.Value = 0;
            for (int i = start; i < stop; i++)
            {
                int El_ID = stop -(i-start)-1;
                Picting_Progress_Bar.Value++;
                DGV.Rows[i-start].Cells[0].Value = All_Elements[El_ID].ID;
                 DGV.Rows[i-start].Cells[1].Value = All_Elements[El_ID].VP;
                 DGV.Rows[i-start].Cells[2].Value = All_Elements[El_ID].sTime;
                 DGV.Rows[i-start].Cells[3].Value = All_Elements[El_ID].User;
                 DGV.Rows[i-start].Cells[4].Value = All_Elements[El_ID].PC;
               
                 DGV.Rows[i-start].Cells[6].Value = All_Elements[El_ID].Name;
                 DGV.Rows[i-start].Cells[7].Value = All_Elements[El_ID].Description;
                 DGV.Rows[i-start].Cells[8].Value = All_Elements[El_ID].From;
                 DGV.Rows[i-start].Cells[9].Value = All_Elements[El_ID].To;
                 DGV.Rows[i-start].Cells[10].Value = All_Elements[El_ID].Fineshed;
                 DGV.Rows[i-start].Cells[11].Value = All_Elements[El_ID].F_ID;
                switch (All_Elements[El_ID].Group)
                {
                    case 1:
                    {
                        DGV.Rows[i-start].Cells[5].Value = Group_Filter_1_chBox.Text;
                        draw_line(i-start,Group_Filter_1_Color_But.BackColor);
                        break;
                    }
                         case 2:
                    {
                        DGV.Rows[i-start].Cells[5].Value = Group_Filter_2_chBox.Text;
                        draw_line(i-start,Group_Filter_2_Color_But.BackColor);
                        break;
                    }
                         case 3:
                    {
                        DGV.Rows[i-start].Cells[5].Value = Group_Filter_3_chBox.Text;
                        draw_line(i-start,Group_Filter_3_Color_But.BackColor);
                        break;
                    }
                         case 4:
                    {
                        DGV.Rows[i-start].Cells[5].Value = Group_Filter_4_chBox.Text;
                        draw_line(i-start,Group_Filter_4_Color_But.BackColor);
                        break;
                    }
                         case 5:
                    {
                        DGV.Rows[i-start].Cells[5].Value = Group_Filter_5_chBox.Text;
                        draw_line(i-start,Group_Filter_5_Color_But.BackColor);
                        break;
                    }
                       
                }
                if (i <= start + 50) Refresh();
                int y = Math.DivRem(i, 50, out y);
                if (y == 0) Picting_Progress_Bar.Refresh();
               
                //Refresh();
            }
            Picting_Progress_Bar.Value = Picting_Progress_Bar.Maximum;
            Refresh();
            
        }

        public void draw_line(int id, Color color)
        {
            for (int i = 0; i <=11; i++)
            {
                DGV.Rows[id].Cells[i].Style.BackColor = color;
            }
        }

        private void Col_track_Refresh_Click(object sender, EventArgs e)
        {
            Col_trBar.Maximum =
                Convert.ToInt32(SQL_Class.ReadValue("Select COUNT(*) AS Expr1 from Logs",
                    Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));
            Col_trBar_Label.Text = Col_trBar.Value.ToString() + "/" + Col_trBar.Maximum;
        }

        private void Group_Filter_1_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Group_Filter_1_Color_But.BackColor=CD.Color;
            }
            Filter_Aplied = true;
        }

        private void Group_Filter_2_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Group_Filter_2_Color_But.BackColor = CD.Color;
            }
            Filter_Aplied = true;
        }

        private void Group_Filter_3_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Group_Filter_3_Color_But.BackColor = CD.Color;
            }
            Filter_Aplied = true;
        }

        private void Group_Filter_4_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Group_Filter_4_Color_But.BackColor = CD.Color;
            }
            Filter_Aplied = true;
        }

        private void Group_Filter_5_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Group_Filter_5_Color_But.BackColor = CD.Color;
            }
            Filter_Aplied = true;
        }

        private void User_Filter_Update_But_Click(object sender, EventArgs e)
        {
            Queue<string> names=new Queue<string>();
            long stop =Convert.ToInt64(SQL_Class.ReadValue("Select COUNT(*) AS Expr1 from Logs", Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));
            SQL_Class reader = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
            for (long i = stop-Col_trBar.Value; i < stop; i++)
            {
                SQL_Class.ReadValues("Select Userr from Logs Where ID=" + i, ref reader);
                reader.SQL_DataReader.Read();
                if (!names.Contains(reader.SQL_DataReader.GetString(0)))names.Enqueue(reader.SQL_DataReader.GetString(0));
            }
            reader.Manualy_Close_Connection();

            string[] names_mas=new string[names.Count];
            for (int i = 0; i < names_mas.Length; i++)
            {
                names_mas[i] = names.Dequeue();
            }

            User_Filter_cmBox.DataSource = names_mas;
        }

        private void Col_trBar_ValueChanged(object sender, EventArgs e)
        {
            Col_trBar_Label.Text = Col_trBar.Value.ToString() + "/" + Col_trBar.Maximum;
            if (Col_trBar.Value > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV&&Out_Timer_RBut.Checked)
                Col_trBar.Value = Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV - 1;
        }

        private void Time_Filter_Cur_Day_rBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Time_Filter_Cur_Day_rBut.Checked)
            {
                Time_Filter_Date2_DatePicker.Enabled = false;
            }
            else
            {
                Time_Filter_Date2_DatePicker.Enabled = true;
            }
        }

        private void Col_Last_RBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Out_Timer_RBut.Checked && Col_All_Rbut.Checked) Col_Last_RBut.Checked = true;
            
        }

        private void Out_Manual_RBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Out_Timer_RBut.Checked)
            {
                Timer_grBox.Enabled = true;
                Load_info_But.Enabled = false;
                Timer.Stop();
                if (Col_trBar.Maximum > 50)
                {
                    Col_trBar.Value = 50;
                }
                else
                {
                    Col_trBar.Value = Col_trBar.Maximum;
                }
              
                Col_grBox.Enabled = false;


            }
            else
            {
                Col_grBox.Enabled = true;
                Timer_grBox.Enabled = false;
                Load_info_But.Enabled = true;
                Timer.Stop();
            }
        }

        private void Timer_Start_But_Click(object sender, EventArgs e)
        {
            Timer.Start();
        }

        private void Timer_Stop_But_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Timer_prBar.Value > 1)
            {
                Timer_prBar.Value--;
                Timer_Label.Text = Timer_prBar.Value + "/" + Timer_prBar.Maximum;
            }
            else
            {
                Timer.Stop();
                Timer_prBar.Value = 0;
                Timer_Label.Text = "0/" + Timer_prBar.Maximum;
                Timer_prBar.Maximum = Convert.ToInt32(Timer_Delay_Tbox.Text);
                pre_auto_update();
                Timer_prBar.Value = Timer_prBar.Maximum;
                Timer.Start();
            }

        }

        private void Log_Show_Load(object sender, EventArgs e)
        {
            Col_track_Refresh_Click(null,null);
            User_Filter_Update_But_Click(null,null);
        }


        public DateTime LAST_UPDATE;
        public Boolean Filter_Aplied ;

        public void pre_auto_update()
        {
            
               if(SoundON_RBut.Checked) Console.Beep(1000, 1000);
                
                Col_track_Refresh_Click(null, null);
            Element[] Old_All_Elements = All_Elements;
            //Element[] Old_Curent_Elements = Curent_Elements;
            All_Elements_Load();

            if (Old_All_Elements != All_Elements)
            {
                Filter_Aplied = false;
                DGV_Fill();
            }
            
        }

        private void Stop_Marks_Show_rBut_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_1_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_2_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_3_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_4_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Group_Filter_5_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void User_Filter_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void VP_Filter_chBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void Time_Filter_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            Filter_Aplied = true;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DGV.Rows[e.RowIndex].Cells[11].Value.ToString() == "0")
            //{

            //}
            //else
            //{


            //    Show_Full_Process.Form_Show(this, Convert.ToInt64(DGV.Rows[e.RowIndex].Cells[0].Value),
            //        Convert.ToInt64(DGV.Rows[e.RowIndex].Cells[11].Value));
            //}
            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex != -1)
                {
                    if (DGV.Rows[e.RowIndex].Cells[6].Value != "")
                    {
                        Media_Info_Show.Show_Other_Info(DGV.Rows[e.RowIndex].Cells[6].Value.ToString());
                    }
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Color_save_Click(object sender, EventArgs e)
        {
            Ingest_Assistant.Properties.Settings.Default.Group1Color = Group_Filter_1_Color_But.BackColor;
            Ingest_Assistant.Properties.Settings.Default.Group2Color = Group_Filter_2_Color_But.BackColor;
            Ingest_Assistant.Properties.Settings.Default.Group3Color = Group_Filter_3_Color_But.BackColor;
            Ingest_Assistant.Properties.Settings.Default.Group4Color = Group_Filter_4_Color_But.BackColor;
            Ingest_Assistant.Properties.Settings.Default.Group5Color = Group_Filter_5_Color_But.BackColor;
            Ingest_Assistant.Properties.Settings.Default.Save();
        }

        private void Out_Timer_RBut_CheckedChanged(object sender, EventArgs e)
        {

        }



        public void ArchiveOldLogs()
        {
            int col = SQL_Class.ReadValueInt32("select count(*) from logs", Settings.Default.Log_Base_Path);
            if (col > 6000)
            {
                long id =
                    Convert.ToInt64(SQL_Class.ReadValue("select min(ID) from logs", Settings.Default.Log_Base_Path));
                string zap = "insert into logs_old () values ()";




            }
        }

    }
    }

