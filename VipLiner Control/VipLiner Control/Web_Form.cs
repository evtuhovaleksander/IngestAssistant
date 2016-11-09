using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace Ingest_Assistant
{
    public partial class Web_Form : Form
    {
        public Thread thread;
        public string vp;
        public Web_Form cur_form;

        public Web_Form()
        {
            InitializeComponent();
        }

        private void Web_Form_Load(object sender, EventArgs e)
        {
        }

        public void Send_Key(string viplanner)
        {
            SendKeys.Send(viplanner);
            SendKeys.Send("{ENTER}");
            SendKeys.Send("{ENTER}");
        }

        //public static void Tread_Send(object obj)
        //{
        //    SendKeys.Send(obj.ToString());
        //    SendKeys.Send("{ENTER}");
        //    SendKeys.Send("{ENTER}");
        //}

        //public static void Form_Start(string viplanner)
        //{
        //    var frm = new Web_Form();
        //    frm.WB.Url = new Uri(Ingest_Assistant.Properties.Settings.Default.Direct_Show_Adress);
        //    frm.vp = viplanner;
        //    frm.Timer_Delay.Start();
        //    frm.Show();
        //}
        //"//http://10.2.77.31/ishows/ById.aspx"

        public static void Form_Start_With_Parent(Web_Form frm, string viplanner)
        {
           // frm.TopLevel = false;
          //  frm.Parent = Parent_panel;
          //  frm.Height = Parent_panel.Height;
          //  frm.Width = Parent_panel.Width;
            string uri = Ingest_Assistant.Properties.Settings.Default.Direct_Show_Adress;
            frm.WB.Url = new Uri(uri);
            
            frm.vp = viplanner;
            frm.cur_form = frm;
            frm.Timer_Delay.Start();
            frm.Show();
        }

        public static void Form_Start_With_Parent_Panel(Web_Form frm, string viplanner,Panel pnl)
        {
            frm.TopLevel = false;
            frm.Parent = pnl;
           frm.Height = pnl.Height;
            frm.Width = pnl.Width;
            string uri = Ingest_Assistant.Properties.Settings.Default.Direct_Show_Adress;
            frm.WB.Url = new Uri(uri);
            frm.vp = viplanner;
            frm.cur_form = frm;
            frm.Timer_Delay.Start();
            frm.Show();
        }

        //public static void Form_Start_With_Parent_Old(string viplanner, Panel Parent_panel)
        //{
        //    var frm = new Web_Form();
        //    frm.TopLevel = false;
        //    frm.Parent = Parent_panel;

        //    frm.WB.Url = new Uri("http://10.2.77.31/ishows/ById.aspx");
        //    frm.vp = viplanner;
        //    object send = viplanner;
        //    //   frm.Timer_Delay.Start();
        //    //   frm.thread=new Thread(Tread_Send(send));
        //    frm.Show();
        //}

        private void Timer_Delay_Tick(object sender, EventArgs e)
        {
            Timer_Delay.Stop();
            Send_Key(vp);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
            cur_form = null;
        }
    }
}