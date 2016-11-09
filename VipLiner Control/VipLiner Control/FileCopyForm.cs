using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class FileCopyForm : Form
    {
        public string from;
        public Queue<FileCPY> in_files;
        private Thread tek;
        public string to;
        public Boolean to_right;
        public string Viplanner;

        public FileCopyForm()
        {
            InitializeComponent();
        }

        private void FileCopyForm_Load(object sender, EventArgs e)
        {
        }

        public static FileCopyForm Form_init(string VP)
        {
            var frm = new FileCopyForm();
            frm.Viplanner = VP;
            frm.in_files = new Queue<FileCPY>();

            return frm;
        }

        public void Add_File(string st1, string st2)
        {
            var inn = new FileCPY();
            inn.from = st1;
            inn.to = st2;
            in_files.Enqueue(inn);
        }

        public void Start_Copy()
        {
            if (in_files.Count == 0)
            {
            }
            else
            {
                Copy_Delay.Start();
                ShowDialog();
            }
        }

        public void Copy_One()
        {
            var tek = in_files.Dequeue();
            total_prBar.Value ++;
            label1.Text = total_prBar.Value + "/" + total_prBar.Maximum;
            from = tek.from;
            to = tek.to;
            label2.Text = "Копируется: " + Path.GetFileName(from);
            do_copy();
        }

        public void Copy_Operation()
        {
            var total_files = in_files.Count;
            total_prBar.Maximum = total_files;
            total_prBar.Value = 0;
            Copy_One();
        }

        private void Copy_Delay_Tick(object sender, EventArgs e)
        {
            Copy_Delay.Stop();
            Copy_Operation();
        }

        private void do_copy()
        {
            Progress_timer.Start();
            var s2 = new object();
            s2 = from + "@" + to;

            var temp = new ways();
            temp.from = from;
            temp.to = to;
            temp.VP = Viplanner;


            tek = new Thread(copy);
            tek.Start(temp);
        }

        public static void copy(object obj)
        {
            var cur = (ways) obj;


            FileM.Copy(cur.from, cur.to);
            Log_Class.Copy(cur.VP, cur.from, cur.to);
        }

        private void Progress_timer_Tick(object sender, EventArgs e)
        {
            if (cur_prBar.Value > 98)
            {
                to_right = false;
            }
            if (cur_prBar.Value < 2)
            {
                to_right = true;
            }

            if (to_right)
            {
                cur_prBar.Value++;
            }
            else
            {
                cur_prBar.Value--;
            }
            Refresh();


            if (!tek.IsAlive)
            {
                copy_done();
            }
        }

        private void copy_done()
        {
            Progress_timer.Stop();
            if (in_files.Count > 0)
            {
                Copy_One();
            }
            else
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tek.Abort();

            Close();
        }

        public struct FileCPY
        {
            public string from;
            public string to;
        }

        private struct ways
        {
            public string from;
            public string to;
            public string VP;
        }
    }
}