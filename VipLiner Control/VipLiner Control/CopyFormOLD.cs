using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Ingest_Assistant;

namespace TestFileCopy
{
    public partial class CopyFormOLD : Form
    {
        FileCopy fc = new FileCopy();
        

        public struct FileCPY
        {
            public string to;
            public string from;
        }

        private Queue<FileCPY> in_files;
        private int Files_count;
        public FileCPY curent_file;
       
        public int i = 0;
        public CopyFormOLD()
        {
            InitializeComponent();
            fc.OnComplete += new Complet(fc_OnComplete);
            fc.OnProgress += new Progress(fc_OnProgress);
        }
        public int old_percent=0;
        private Thread thread;
        void fc_OnProgress(string message, int procent)
        {

            BeginInvoke(new MethodInvoker(delegate
            {
                
                i++;
                if (i > 1000000)
                {
                   // progress.Text = procent + " / 100";
                    prMain.Value = procent;
                    progress.Text = message;
                    i = 0;
                }
                
            }));
        }

        void fc_OnComplete(bool ifComplete)
        {
            if (!ifComplete)
             //   MessageBox.Show("Копирование файла успешно завершено", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
               // Close();
           
                MessageBox.Show("Копирование файла завершено с ошибкой", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static CopyFormOLD Copy_Form_Init()
        {
            CopyFormOLD frm = new CopyFormOLD();
            frm.i = 0;
            frm.in_files=new Queue<FileCPY>();
            
            return frm;
        }

        public void Copy_New_File_Add(string ishod, string direct)
        {
            FileCPY tmp = new FileCPY();
            tmp.from = ishod;
            tmp.to = direct;
            in_files.Enqueue(tmp);
            Files_count = in_files.Count;
        }

       

        public void Start_Copy_Operation()
        {
            pr_ALL.Maximum = in_files.Count;
            pr_ALL.Value = 0;
            ShowDialog();
        }
        public  void Copy_Operation()
        {
            FileCPY tek = in_files.Dequeue();
               curent_file = tek;
              pr_ALL.Value++;
              Text = "Копирование файла: " + Path.GetFileName(tek.from);
            total_progress.Text = pr_ALL.Value + " / " + Files_count;
             Copy_One_File(tek);
            
        }

        public void Copy_One_File(FileCPY tek)
        {
            bgWorker.RunWorkerAsync();
        }
        

       

       

        private void button1_Click(object sender, EventArgs e)
        {
           // thread.Abort();
            bgWorker.CancelAsync();
            MessageBox.Show("Копирование было аварийно прерванно!");
            Close();
        }

        private void CopyForm_Load(object sender, EventArgs e)
        {
          Delay.Start();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            fc.CopyFile(curent_file.from, curent_file.to);
            
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          //  Close();
            if (in_files.Count != 0)
            {
                Copy_Operation();
            }
            else
            {
              //  MessageBox.Show("");
                Close();
            }
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            Delay.Stop();
            Copy_Operation();
        }

     

      
    }
}
