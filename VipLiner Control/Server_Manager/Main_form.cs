using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server_Manager.Properties;

namespace Server_Manager
{
    public partial class Main_form : Form
    {

        private Queue<element> Thread_LIST;
        private Queue<element> CURRENT_Thread_LIST;
        private Queue<element> FINALIZED_Thread_LIST; 

        public struct element
        {
            public Media_Info_Low_Thread_Class cl;
            public Thread th;
        }

        public Main_form()
        {
            InitializeComponent();
        }
        
        private void Progress_But_Click(object sender, EventArgs e)
        {
            if (true)
            {
                if (Media_Info_Ch.Checked)
                {
                    ////string[] work_dir_paths = Directory.GetDirectories(Properties.Settings.Default.Work_Path);
                    ////string[] arch_dir_paths = Directory.GetDirectories(Properties.Settings.Default.Work_Path);
                    ////List<string> all_VP=new List<string>();

                    ////foreach (var VARIABLE in work_dir_paths)
                    ////{
                    ////    if (Directory.Exists(VARIABLE))
                    ////    {
                    ////        string vp = Path.GetFileName(VARIABLE);
                    ////        if(!all_VP.Contains(vp)) all_VP.Add(vp);
                    ////    }
                        
                    ////}

                    ////foreach (var VARIABLE in arch_dir_paths)
                    ////{
                    ////    if (Directory.Exists(VARIABLE))
                    ////    {
                    ////        string vp = Path.GetFileName(VARIABLE);
                    ////        if (!all_VP.Contains(vp)) all_VP.Add(vp);
                    ////    }

                    ////}




                    ////foreach (var VARIABLE in all_VP)
                    ////{
                        
                    ////}
                    //lab.Text = "calc work";
                    //Refresh();
                    //List<string> mov_files=new List<string>();
                    ////string[] work_dir_paths = Directory.GetDirectories(Properties.Settings.Default.Work_Path);
                    ////foreach (string VARIABLE in work_dir_paths)
                    ////{
                    ////    mov_files = get_movies(VARIABLE,mov_files);
                    ////}
                    ////lab.Text = "calc arch";
                    ////Refresh();
                    ////string[] arch_dir_paths = Directory.GetDirectories(Properties.Settings.Default.Arch_Path);
                    ////foreach (string VARIABLE in arch_dir_paths)
                    ////{
                    ////    mov_files = get_movies(VARIABLE, mov_files);
                    ////}
                    ////lab.Text = "calc stock";
                    ////Refresh();
                    ////mov_files = get_movies(Properties.Settings.Default.Stock_Path, mov_files);
                    //lab.Text = "calc master";
                    //Refresh();
                    //mov_files = get_movies(Properties.Settings.Default.Master_Path, mov_files);
                    //mov_files.AddRange( get_movies(Properties.Settings.Default.Stock_Path, mov_files));
                    //mov_files.AddRange(get_movies(Properties.Settings.Default.Work_Path, mov_files));
                    //mov_files.AddRange(get_movies(Properties.Settings.Default.Arch_Path, mov_files));

                    //Thread_LIST=new Queue<element>();
                    //FINALIZED_Thread_LIST=new Queue<element>();
                    //foreach (var VARIABLE in mov_files)
                    //{
                    //    element temp = new element();
                    //    temp.cl=new Media_Info_Low_Thread_Class(VARIABLE);
                    //    //temp.th=new Thread(temp.cl.Start_Asinc_Work);
                    //    //temp.th.Start();
                    //    //temp.cl.Start_Asinc_Work();
                    //    Thread_LIST.Enqueue(temp);
                    //}




                    //while (Thread_LIST.Count != 0)
                    //{
                    //    get_and_work();
                    //}
                    ////bool working = true;
                    ////int wr = 0;
                    ////while (working)
                    ////{
                    ////    wr = 0;
                    ////    working = false;
                    ////    foreach (element VARIABLE in Thread_LIST)
                    ////    {
                    ////        if (VARIABLE.th.IsAlive) {working = true;
                    ////            wr ++;
                    ////        }
                    ////    }
                    ////    lab.Text = wr.ToString();
                    ////    Refresh();
                    ////}


                    //rtb.Text = "";
                    //foreach (element VARIABLE in FINALIZED_Thread_LIST)
                    //{

                    //    rtb.Text += VARIABLE.cl.message + "\n";
                    //}
                    calk_MI();
                }

                if (Space_Count_Ch.Checked)
                {
                    string[] paths = {Settings.Default.Arch_Path, Settings.Default.Work_Path};
                    
                    
                    foreach (var path in paths)
                    {
                        try
                        {
                            double bytes = get_space(path);
                            string zap="insert into spacetable (Path,Bytes,Date) values ('"+path+"',"+Convert.ToInt64(bytes)+",'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')";
                            zap = zap.Replace("\\", "\\\\");
                            SQL_Class.Execute(zap,Settings.Default.Base);
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                    }
                    
                    
                }


            }


            
        }


        public void get_and_work()
        {
            CURRENT_Thread_LIST=new Queue<element>();
            
            while (CURRENT_Thread_LIST.Count<10&&Thread_LIST.Count!=0)
            {
                element el = Thread_LIST.Dequeue();
                el.th=new Thread(el.cl.Start_Asinc_Work);
                CURRENT_Thread_LIST.Enqueue(el);
            }

            foreach (element temp in CURRENT_Thread_LIST)
            {
                temp.cl.Start_Asinc_Work();
            // temp.th.Start();
                lab.Text = Thread_LIST.Count.ToString();
            }

            //bool working = true;
            //int wr = 0;
            //while (working)
            //{
            //    wr = 0;
            //    working = false;
            //    foreach (element VARIABLE in CURRENT_Thread_LIST)
            //    {
            //        if (VARIABLE.th.IsAlive)
            //        {
            //            working = true;
            //            wr++;
            //        }

            //        if (VARIABLE.cl.finished) { VARIABLE.th.Abort(); }
            //    }
            //    lab.Text = wr.ToString() + "     /    " + Thread_LIST.Count;
            //    Refresh();
            //}


            foreach (var VARIABLE in CURRENT_Thread_LIST)
            {
                FINALIZED_Thread_LIST.Enqueue(VARIABLE);
            }

        }

        public List<string> get_movies(string dir_path,List<string> ishod )
        {
            string[] files = Directory.GetFiles(dir_path);
            foreach (var VARIABLE in files)
            {
                if (File.Exists(VARIABLE))
                {
                    if (Path.GetFileName(VARIABLE)[0] != '.')
                    {
                        string ext = Path.GetExtension(VARIABLE);
                        if (".mov|.avi".Contains(ext))
                        {
                            ishod.Add(VARIABLE);
                        }
                    }
                    
                }
            }
            return ishod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings_Form frm = new Settings_Form();
            frm.ShowDialog();
        }


        public double  get_space(string start_path)
        {
            double bytes = 0;
            Queue<string> directories=new Queue<string>();
            List<string> files=new List<string>();
            directories.Enqueue(start_path);
            string[] curent;

            while (directories.Count != 0)
            {
                string dir = directories.Dequeue();
                curent = Directory.GetDirectories(dir);
                foreach (var VARIABLE in curent)
                {
                    directories.Enqueue(VARIABLE);
                }

                curent = Directory.GetFiles(dir);
                foreach (var VARIABLE in curent)
                {
                    files.Add(VARIABLE);
                }
                    
                
            }
            
            foreach (string cur in files)
            {
                var fi = new FileInfo(cur);
                bytes += Convert.ToDouble(fi.Length);
            }
            return bytes;
        }


        public List<String> get_files(string start_path)
        {
            
            Queue<string> directories = new Queue<string>();
            List<string> files = new List<string>();
            directories.Enqueue(start_path);
            string[] curent;

            while (directories.Count != 0)
            {
                string dir = directories.Dequeue();
                curent = Directory.GetDirectories(dir);
                foreach (var VARIABLE in curent)
                {
                  if(Directory.Exists(VARIABLE))   directories.Enqueue(VARIABLE);
                }

                curent = Directory.GetFiles(dir);
                foreach (var VARIABLE in curent)
                {
                   if((".mov  .avi  ".Contains(Path.GetExtension(VARIABLE)))&&Path.GetFileNameWithoutExtension(VARIABLE)[0]!='.') files.Add(VARIABLE);
                }


            }

            
            return files;
        }


        public void calk_MI()
        {
            List<String> paths=new List<string>();
            rtb.Text += "\n start get from work";
            Refresh();
            paths.AddRange(get_files(Settings.Default.Work_Path));
            rtb.Text += "\n finish get from work";
            Refresh();
            rtb.Text += "\n start get from stok";
            paths.AddRange(get_files(Settings.Default.Stock_Path));
            rtb.Text += "\n finish get from stok";
            Refresh();
            rtb.Text += "\n start get from master";
            paths.AddRange(get_files(Settings.Default.Master_Path));
            rtb.Text += "\n finish get from master";
            Refresh();
            rtb.Text += "\n ALL IN ALL " + paths.Count + " files";
            Refresh();

            int i = 0;


            Refresh();
            foreach (var tmp in paths)
            {
                i++;
                lab.Text = i + "\\" + paths.Count;
                
                Refresh();
                try
                {
                    Refresh();
                    textBox1.Text = " now Start to work with =";
                    textBox1.Text += tmp + "\n\n";
                    Refresh();
                    Refresh();
                    Media_Info_Low_Thread_Class cl =  new Media_Info_Low_Thread_Class(tmp);
                    cl.Start_Asinc_Work();
                    rtb2.Text = "WORK FINISHED\n\n";
                    rtb2.Text += tmp + "\n\n";
                    rtb2.Text += "status = " + cl.sucsess;
                    rtb2.Text += "\n\n" + cl.info;
                    Refresh();
                    Refresh();

                }
                catch (Exception)
                {
                    
                }
                Refresh();


            }

        }
    }
}
