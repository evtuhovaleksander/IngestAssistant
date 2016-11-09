using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HouseUpdate;


namespace Ingest_Assistant
{
    public partial class Real_Time_Log_Show : Form
    {
        public int constant = 50;
        public long CURENT_LAST_ID;
        private Queue<Log> Curent_Mass;

        public Real_Time_Log_Show()
        {
            InitializeComponent();

            init();
        }

        private void Load_One_Time_But_Click(object sender, EventArgs e)
        {
            recolect();
        }


        private DateTime Base_Last_Refresh;


        public void init()
        {
            users = new string[]{};
            Array.Resize(ref users,users.Length+1);
            users[users.Length - 1] = "----------";
           
            U_Filter_CmBox.DataSource = users;
            Wait_TBox.Text = Delay_TBox.Text;
            var len = Convert.ToInt32(Wait_TBox.Text);
            Wait_prBar.Maximum = len;
            Wait_prBar.Value = Wait_prBar.Maximum;
            Base_Last_Refresh = DateTime.Now;

            Curent_Mass = new Queue<Log>();
            var zapros = "SELECT MAX(ID) FROM Logs";
            var max = Convert.ToInt64(Log_SQL.ReadValue(zapros, Properties.Settings.Default.Log_Base_Path));
            var min = max - constant;
            if (min < 1) min = 1;


            Collect_PrBar.Maximum = Convert.ToInt32(max - min) + 1;
            Collect_PrBar.Value = 0;
            Refresh();
            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,
                "Real_Time_Log_Show-------init()");
            for (var i = min; i <= max; i++)
            {
                Log_SQL.ReadValues("Select Gr,Name,Fr,Dest,Info,VP,Stat from Logs where ID=" + i,ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var temp = new Log();
                temp.id = i;
                temp.group = sqlcon.SQL_DataReader.GetInt32(0).ToString();
                temp.name = sqlcon.SQL_DataReader.GetString(1);
                temp.from = sqlcon.SQL_DataReader.GetString(2);
                temp.to = sqlcon.SQL_DataReader.GetString(3);
                temp.user = sqlcon.SQL_DataReader.GetString(4);
                temp.vp = sqlcon.SQL_DataReader.GetString(5);
                temp.time = sqlcon.SQL_DataReader.GetString(6);
                Curent_Mass.Enqueue(temp);
                Collect_PrBar.Value++;
                if (!users.Contains(temp.user))
                {
                    Array.Resize(ref users, users.Length + 1);
                    users[users.Length - 1] = temp.user;
                }
               
                Refresh();

            }
            sqlcon.Manualy_Close_Connection();

            CURENT_LAST_ID = max;
            U_Filter_CmBox.DataSource = users;




           
        }

        private string[] users; 


        public void main_recolect()
        {

            var zapros = "SELECT MAX(ID) FROM Logs";
            var max = Convert.ToInt64(Log_SQL.ReadValue(zapros, Properties.Settings.Default.Log_Base_Path));
            var old_max = Curent_Mass.Last().id;


            Collect_PrBar.Maximum = Convert.ToInt32(max - (old_max + 1)) + 1;
            Collect_PrBar.Value = 0;
            Refresh();
            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,
                "Real_Time_Log_Show-------main_recollect()");
            for (var i = old_max + 1; i <= max; i++)
            {
                Log_SQL.ReadValues("Select Gr,Name,Fr,Dest,Info,VP,Stat from Logs where ID=" + i, ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var temp = new Log();
                temp.id = i;
                temp.group = sqlcon.SQL_DataReader.GetInt32(0).ToString();
                temp.name = sqlcon.SQL_DataReader.GetString(1);
                temp.from = sqlcon.SQL_DataReader.GetString(2);
                temp.to = sqlcon.SQL_DataReader.GetString(3);
                temp.user = sqlcon.SQL_DataReader.GetString(4);
                temp.vp = sqlcon.SQL_DataReader.GetString(5);
                temp.time = sqlcon.SQL_DataReader.GetString(6);
                Curent_Mass.Enqueue(temp);
                Collect_PrBar.Value++;
                if (!users.Contains(temp.user))
                {
                    Array.Resize(ref users, users.Length + 1);
                    users[users.Length - 1] = temp.user;
                }
                Refresh();
                
            }
            sqlcon.Manualy_Close_Connection();
            U_Filter_CmBox.DataSource = users;
            long diference = Curent_Mass.Count - constant;
            Collect_PrBar.Maximum = Convert.ToInt32(diference) + 1;
            Collect_PrBar.Value = 0;

            for (var i = 0; i < diference; i++)
            {
                Curent_Mass.Dequeue();
                Collect_PrBar.Value++;
                Refresh();
            }


           
        }
        public Boolean recolect()
        {

            DateTime tekBase = File.GetLastAccessTime(Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);

            if (tekBase != Base_Last_Refresh)
            {
                Console.Beep(1000, 1000);
               main_recolect();
               Base_Last_Refresh = File.GetLastAccessTime(Ingest_Assistant.Properties.Settings.Default.Log_Base_Path);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void dgv_load()
        {
         //   all_to_white();
            Stack<Log> dgv_stak;
          
            Dgv_PrBar.Maximum = Curent_Mass.Count;
            Dgv_PrBar.Value = 0;
            dgv_stak=new Stack<Log>();

            
            foreach (var temp in Curent_Mass)
            {
                if (!U_Show_All_RBut.Checked)
                {

                    if (temp.user == U_Filter_CmBox.SelectedItem.ToString())
                    {
                        dgv_stak.Push(temp);
                    }
                }
                else
                {
                    dgv_stak.Push(temp);
                }
                
            }

            dgv.RowCount = dgv_stak.Count;
            Dgv_PrBar.Maximum = dgv_stak.Count;
            Dgv_PrBar.Value = 0;
            int count = dgv_stak.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                Log temp = dgv_stak.Pop();
                dgv.Rows[i].Cells[7].Value = temp.id;
                dgv.Rows[i].Cells[2].Value = temp.group;
                dgv.Rows[i].Cells[3].Value = temp.name;
                dgv.Rows[i].Cells[4].Value = temp.from;
                dgv.Rows[i].Cells[5].Value = temp.to;
                dgv.Rows[i].Cells[1].Value = temp.user;
                dgv.Rows[i].Cells[6].Value = temp.vp;
                dgv.Rows[i].Cells[0].Value = temp.time;
                Dgv_PrBar.Value++;
                for (int j = 0; j < 8; j++)
                {
                    dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
                if (temp.name.Contains("СТАРТ"))
                {
                    for (int j = 0; j < 8; j++)
                    {
                        dgv.Rows[i].Cells[j].Style.BackColor = Color.LawnGreen;
                    }
                }
                Refresh();
            }

            Refresh();
        }
        public void dgv_load_special()
        {
            dgv.RowCount = 1;
            Refresh();
            Stack<Log> dgv_stak;

            Dgv_PrBar.Maximum = Dgv_PrBar.Value;
            
            dgv_stak = new Stack<Log>();


            foreach (var temp in Curent_Mass)
            {
                if (!U_Show_All_RBut.Checked)
                {

                    if (temp.user == U_Filter_CmBox.SelectedItem.ToString())
                    {
                        dgv_stak.Push(temp);
                    }
                }
                else
                {
                    dgv_stak.Push(temp);
                }

            }

            dgv.RowCount = dgv_stak.Count;
            
            int count = dgv_stak.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                Log temp = dgv_stak.Pop();
                dgv.Rows[i].Cells[7].Value = temp.id;
                dgv.Rows[i].Cells[2].Value = temp.group;
                dgv.Rows[i].Cells[3].Value = temp.name;
                dgv.Rows[i].Cells[4].Value = temp.from;
                dgv.Rows[i].Cells[5].Value = temp.to;
                dgv.Rows[i].Cells[1].Value = temp.user;
                dgv.Rows[i].Cells[6].Value = temp.vp;
                dgv.Rows[i].Cells[0].Value = temp.time;
              ////  Dgv_PrBar.Value++;
              //  for (int j = 0; j < 8; j++)
              //  {
              //      dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
              //  }
              //  if (temp.name.Contains("СТАРТ"))
              //  {
              //      for (int j = 0; j < 8; j++)
              //      {
              //          dgv.Rows[i].Cells[j].Style.BackColor = Color.LawnGreen;
              //      }
              //  }
                
            }

            Refresh();
        }

        private void Show_But_Click(object sender, EventArgs e)
        {
            dgv_load();
        }

        private void Real_Time_Log_Show_Load(object sender, EventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            var cur = Convert.ToInt32(Wait_TBox.Text);
            if (cur == 1)
            {
                Timer.Stop();
                Wait_TBox.Text = "Запущено обновление";
                Wait_prBar.Value = 0;
                if (recolect()) dgv_load();
               // dgv_load();

                Wait_TBox.Text = Delay_TBox.Text;
                Wait_prBar.Maximum = Convert.ToInt32(Delay_TBox.Text);
                Wait_prBar.Value = 0;
                Timer.Start();
            }
            else
            {
                cur--;
                Wait_prBar.Value = cur;
                Wait_TBox.Text = cur.ToString();
            }
        }

        private void Timer_Start_Click(object sender, EventArgs e)
        {
            Timer.Start();
        }

        private void Timer_Stop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void Show_All_But_Click(object sender, EventArgs e)
        {
            Thread th = ProgressForm.Prepare_Thread("");
            var zapros = "SELECT MAX(ID) FROM Logs";
            var max = Convert.ToInt64(Log_SQL.ReadValue(zapros, Properties.Settings.Default.Log_Base_Path));


            Curent_Mass = new Queue<Log>();

            Collect_PrBar.Value = Collect_PrBar.Maximum;
            
            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,
                "Real_Time_Log_Show-------Show_All()");
            for (long i = 1; i <= max; i++)
            {
                Log_SQL.ReadValues("Select Gr,Name,Fr,Dest,Info,VP,Stat from Logs where ID=" + i, ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var temp = new Log();
                temp.id = i;
                temp.group = sqlcon.SQL_DataReader.GetInt32(0).ToString();
                temp.name = sqlcon.SQL_DataReader.GetString(1);
                temp.from = sqlcon.SQL_DataReader.GetString(2);
                temp.to = sqlcon.SQL_DataReader.GetString(3);
                temp.user = sqlcon.SQL_DataReader.GetString(4);
                temp.vp = sqlcon.SQL_DataReader.GetString(5);
                temp.time = sqlcon.SQL_DataReader.GetString(6);
                Curent_Mass.Enqueue(temp);
               // Collect_PrBar.Value++;
                
            }
            sqlcon.Manualy_Close_Connection();
            dgv_load_special();
            th.Abort();
        }

        public struct Log
        {
            public string from;
            public string group;
            public long id;
            public string name;
            public string time;
            public string to;
            public string user;
            public string vp;
        }



        public void all_to_white()
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                Color col;
                if (dgv.Rows[i].Cells[3].Value != null)
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString().Contains("СТАРТ"))
                    {
                        if (dgv.Rows[i].Cells[3].Value.ToString().Contains(" работы СТАРТ"))
                        {
                            col = Color.Purple;
                        }
                        else
                        {
                            col = Color.LawnGreen;
                        }

                        
                    }
                    else
                    {
                       
                        
                           col = Color.White;
                        
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        dgv.Rows[i].Cells[j].Style.BackColor = col;



                    }
                }






               
                }
            
            Refresh();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Timer.Stop();
            all_to_white();
            string str = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
         //  string  str = "fishefiohsiofehsohf СТАРТ (145)";
            if (str.Contains("СТАРТ"))
            {
                if (str.Contains("(")&&str.Contains(")"))
                {
                    int open = str.IndexOf('(') + 1;
                    int length = str.IndexOf(')') - open;
                    string lg = str.Substring(str.IndexOf('(') + 1, length);
                    long id = Convert.ToInt64(lg);

                    Boolean paint = true;
                    for (int i = e.RowIndex; i >= 0; i--)
                    {
                        if (paint)
                        {
                           for (int j = 0; j < 8; j++)
                                {
                                    dgv.Rows[i].Cells[j].Style.BackColor = Color.Turquoise;
                                }
                            if (dgv.Rows[i].Cells[7].Value.ToString() == id.ToString())
                            {
                                paint = false;
                            }
                            Refresh();
                        }
                       
                    }
                }
            }

            
        }

        private void all_to_white_but_Click(object sender, EventArgs e)
        {
            all_to_white();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            constant = trackBar1.Value;
            init();
            dgv_load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Curent_Mass = new Queue<Log>();
            long first = Convert.ToInt64(textBox1.Text);
            long second = Convert.ToInt64(textBox2.Text);
            Collect_PrBar.Maximum = Convert.ToInt32(second - first)+5;
            Collect_PrBar.Value = 0;
            Refresh();
            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,
                "Real_Time_Log_Show-------main_recollect()");
            for (var i = first; i <= second; i++)
            {
                Log_SQL.ReadValues("Select Gr,Name,Fr,Dest,Info,VP,Stat from Logs where ID=" + i, ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var temp = new Log();
                temp.id = i;
                temp.group = sqlcon.SQL_DataReader.GetInt32(0).ToString();
                temp.name = sqlcon.SQL_DataReader.GetString(1);
                temp.from = sqlcon.SQL_DataReader.GetString(2);
                temp.to = sqlcon.SQL_DataReader.GetString(3);
                temp.user = sqlcon.SQL_DataReader.GetString(4);
                temp.vp = sqlcon.SQL_DataReader.GetString(5);
                temp.time = sqlcon.SQL_DataReader.GetString(6);
                Curent_Mass.Enqueue(temp);
              //  Collect_PrBar.Value++;
                if (!users.Contains(temp.user))
                {
                    Array.Resize(ref users, users.Length + 1);
                    users[users.Length - 1] = temp.user;
                }
                Refresh();

            }
            sqlcon.Manualy_Close_Connection();
            U_Filter_CmBox.DataSource = users;
           
            dgv_load();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = ProgressForm.Prepare_Thread("");
            var zapros = "SELECT MAX(ID) FROM Logs";
            var max = Convert.ToInt64(Log_SQL.ReadValue(zapros, Properties.Settings.Default.Log_Base_Path));


            Curent_Mass = new Queue<Log>();

            Collect_PrBar.Value = Collect_PrBar.Maximum;

            var sqlcon = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,
                "Real_Time_Log_Show-------Show_All()");
            for (long i = 1; i <= max; i++)
            {
                Log_SQL.ReadValues("Select Gr,Name,Fr,Dest,Info,VP,Stat from Logs where ID=" + i, ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var temp = new Log();
                temp.id = i;
                temp.group = sqlcon.SQL_DataReader.GetInt32(0).ToString();
                temp.name = sqlcon.SQL_DataReader.GetString(1);
                temp.from = sqlcon.SQL_DataReader.GetString(2);
                temp.to = sqlcon.SQL_DataReader.GetString(3);
                temp.user = sqlcon.SQL_DataReader.GetString(4);
                temp.vp = sqlcon.SQL_DataReader.GetString(5);
                temp.time = sqlcon.SQL_DataReader.GetString(6);
                if(temp.vp==textBox3.Text)Curent_Mass.Enqueue(temp);
                // Collect_PrBar.Value++;

            }
            sqlcon.Manualy_Close_Connection();
            dgv_load_special();
            th.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

       
    }
}