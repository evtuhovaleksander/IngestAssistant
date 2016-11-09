using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class Show_Full_Process : Form
    {
        public long STA;
        public long STO;
        public Log_Show parent;
        public Show_Full_Process()
        {
            InitializeComponent();
        }

        private void Show_Full_Process_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        public static void Form_Show(Log_Show pfrm,long start, long stop)
        {
            Show_Full_Process frm=new Show_Full_Process();
            frm.STA = start;
            frm.STO = stop;
            frm.parent = pfrm;
            frm.Show();

        }
        
        public void All_Elements_Load()
        {
            long max_ID = Convert.ToInt64(SQL_Class.ReadValue("Select Max(ID) from Logs",Ingest_Assistant.Properties.Settings.Default.Log_Base_Path));

  
            string zapros = "";


           


            long start =STA ;
            long stop = STO+1;

           

            Queue<Log_Show.Element> temp_mas=new Queue<Log_Show.Element>();
            SQL_Class readerSql = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
            for (long i = start; i < stop; i++)
            {
                zapros =
               "SELECT        VP, Time, Userr, PC, Groupp, Name, Description, Fromm, Too, Finished, F_ID FROM            Logs  Where  ID= " +i+" ";

              
                try
                {
                    SQL_Class.ReadValues(zapros, ref readerSql);
                    readerSql.SQL_DataReader.Read();
                    Log_Show.Element temp=new Log_Show.Element();
                    temp.ID = i;
                    temp.VP = readerSql.SQL_DataReader.GetString(0);
                    temp.sTime = readerSql.SQL_DataReader.GetString(1);

                    string tmp = temp.sTime.Substring(temp.sTime.Length - 10)+" "+temp.sTime.Substring(0,temp.sTime.Length-11).Replace('.',':');
                    temp.Time = Convert.ToDateTime(tmp);
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
                catch (Exception)
                {
                }
            }
            readerSql.Manualy_Close_Connection();
           All_Elements=new Log_Show.Element[0];
                foreach (Log_Show.Element temp in temp_mas)
                {
                    
                            Array.Resize(ref All_Elements, All_Elements.Length + 1);
                            All_Elements[All_Elements.Length - 1] = temp;
                        
                    
                }
           
            

            DGV_Fill();
        }

        private Log_Show.Element[] All_Elements;



        public void DGV_Fill()
        {
            int start=0;
            int stop=0;
            if (All_Elements.Length > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
            {
                Log_Col_Ask.Ask_Diapason(All_Elements.Length,ref start,ref stop);
                DGV.RowCount = Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
            }
            else
            {
                start = 0;
                stop = All_Elements.Length;
                DGV.RowCount = All_Elements.Length;
            }
            
            for (int i = start; i < stop; i++)
            {
                DGV.Rows[i-start].Cells[0].Value = All_Elements[i].ID;
                 DGV.Rows[i-start].Cells[1].Value = All_Elements[i].VP;
                 DGV.Rows[i-start].Cells[2].Value = All_Elements[i].sTime;
                 DGV.Rows[i-start].Cells[3].Value = All_Elements[i].User;
                 DGV.Rows[i-start].Cells[4].Value = All_Elements[i].PC;
               // DGV.Rows[i-start].Cells[5].Value = All_Elements[i].PC;
                 DGV.Rows[i-start].Cells[6].Value = All_Elements[i].Name;
                 DGV.Rows[i-start].Cells[7].Value = All_Elements[i].Description;
                 DGV.Rows[i-start].Cells[8].Value = All_Elements[i].From;
                 DGV.Rows[i-start].Cells[9].Value = All_Elements[i].To;
                 DGV.Rows[i-start].Cells[10].Value = All_Elements[i].Fineshed;
                 DGV.Rows[i-start].Cells[11].Value = All_Elements[i].F_ID;
                switch (All_Elements[i].Group)
                {
                    case 1:
                    {
                        DGV.Rows[i-start].Cells[5].Value = parent.Group_Filter_1_chBox.Text;
                        draw_line(i-start,parent.Group_Filter_1_Color_But.BackColor);
                        break;
                    }
                         case 2:
                    {
                        DGV.Rows[i-start].Cells[5].Value = parent.Group_Filter_2_chBox.Text;
                       draw_line(i-start,parent.Group_Filter_2_Color_But.BackColor);
                        break;
                    }
                         case 3:
                    {
                        DGV.Rows[i-start].Cells[5].Value = parent.Group_Filter_3_chBox.Text;
                        draw_line(i-start,parent.Group_Filter_3_Color_But.BackColor);
                        break;
                    }
                         case 4:
                    {
                        DGV.Rows[i-start].Cells[5].Value = parent.Group_Filter_4_chBox.Text;
                        draw_line(i-start,parent.Group_Filter_4_Color_But.BackColor);
                        break;
                    }
                         case 5:
                    {
                        DGV.Rows[i-start].Cells[5].Value = parent.Group_Filter_5_chBox.Text;
                      draw_line(i-start,parent.Group_Filter_5_Color_But.BackColor);
                        break;
                    }
                }
                Refresh();
            }
            
        }
        public void draw_line(int id, Color color)
        {
            for (int i = 0; i <= 11; i++)
            {
                DGV.Rows[id].Cells[i].Style.BackColor = color;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            All_Elements_Load();
        }
    }
}
