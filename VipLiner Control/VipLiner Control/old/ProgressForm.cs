using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Label = System.Reflection.Emit.Label;

namespace HouseUpdate
{
    public partial class ProgressForm : Form
    {
        public static ProgressForm curForm;
        public Thread th;
        public ProgressForm(string stext)
        {
            InitializeComponent();
            label.Text = stext;
          //  Progress_Timer.Start();
            Application.DoEvents();
            
            Application.DoEvents();
        }

        public static void SetText(string stext)
        {
            curForm.BeginInvoke((MethodInvoker) delegate {
            if (curForm != null)  curForm.label.Text = stext;
            curForm.Refresh();
            });
            Application.DoEvents();
        }

        public static void StartForm(string stext)
        {
            StartFunc(stext);
            curForm.ShowDialog();
            End:
            Application.DoEvents();
        }



        public static void StartFunc(object obj)
        {
            if (curForm == null)
            {
                curForm = new ProgressForm(obj.ToString());
               
            }
            else
            {
                curForm.label.Text = obj.ToString();
                curForm.Refresh();
            }
       
        }

        public static void StopForm()
        {
            if (curForm != null)
            {
                curForm.Close();
                curForm = null;
            }
        }
      
     
        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Progress_Timer.Stop();
        }

       

        private void Progress_Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Progress_Timer.Stop();
            Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            
        }

       

       
    }
}
