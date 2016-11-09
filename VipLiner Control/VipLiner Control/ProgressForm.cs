using System;
using System.Threading;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class ProgressForm : Form
    {
        public static ProgressForm curForm;

        public ProgressForm(string stext)
        {
            InitializeComponent();
            label.Text = stext;
        }

        public static Thread Prepare_Thread(string text)
        {
            var frm = new ForForm();
            // frm.panel = panel;
            frm.text = text;

            // frm.frm.Left = panel.Left;
            //frm.frm.Top = panel.Top;
            //frm.frm.Width = panel.Width;
            //  frm.frm.Height = panel.Height;
            // var th = new Thread(StartForm_for_Panel);
            var th = new Thread(ProgressForm.StartForm);
            th.Start(frm);
            return th;
        }

        public static void SetText(string stext)
        {
            curForm.BeginInvoke((MethodInvoker) delegate
            {
                if (curForm != null) curForm.label.Text = stext;
                curForm.Refresh();
            });
            Application.DoEvents();
        }

        public static void StartForm(object stext)
        {
            Application.DoEvents();
        }

        //public static void StartForm_for_Panel(object obj)
        //{
        //    var ps = (ForForm) obj;

        //    ps.frm = new ProgressForm(ps.text);
        //    ps.frm.ShowDialog();

        //    Application.DoEvents();
        //}

        public static void StopForm()
        {
            if (curForm != null)
            {
                curForm.Close();
                curForm = null;
            }
        }

        public static void Pause()
        {
            if (curForm != null)
            {
                curForm.Visible = false;
            }
        }

        public static void Resume()
        {
            if (curForm != null)
            {
                curForm.Visible = true;
            }
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Progress_Timer.Stop();
        }

        private void Progress_Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }

        public struct ForForm
        {
            public ProgressForm frm;
            public Panel panel;
            public string text;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}