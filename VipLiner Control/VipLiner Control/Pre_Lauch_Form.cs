using System;
using System.Windows.Forms;
using System.IO;

namespace Ingest_Assistant
{
    public partial class Pre_Lauch_Form : Form
    {
        
        public Boolean OK;

       
        public Pre_Lauch_Form()
        {
            InitializeComponent();
            Timerr.Start();
        }

        public static Boolean Check_Server_Show_Pre_Form()
        {
            var frm = new Pre_Lauch_Form();
            frm.ShowDialog();
            return frm.OK;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            if (prBar.Value != prBar.Maximum)
            {
                prBar.Value += 1;


                Timerr.Stop();
                if (Environment.UserName.ToString() == "Александр")
                {
                    OK = SQL_Class.check_connection(Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path);
                }
                else
                {
                    OK = SQL_Class.check_connection(Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path);

                }

                Close();





            }
            else
            {
                Timerr.Stop();
                if (Environment.UserName.ToString() == "Александр")
                {
                    OK = false;
                }
                else
                {
                    OK = SQL_Class.check_connection(Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path);

                }
                
                Close();
            }
        }

        private void p_box_Click(object sender, EventArgs e)
        {
        }

        private void Pre_Lauch_Form_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            if (Environment.UserName.ToString() == "aevtuhov")
            {
                OK = false;//SQL_Class.check_connection(Ingest_Assistant.Properties.Settings.Default.Main_Settings_Base_Path);
                Close();
            }
        }
    }
}