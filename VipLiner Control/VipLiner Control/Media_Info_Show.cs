using System;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class Media_Info_Show : Form
    {
        public Media_Info_Show()
        {
            InitializeComponent();
        }

        private void Media_Info_Show_Load(object sender, EventArgs e)
        {
        }

        public static void Form_Lauch(int id)
        {
            var md = SQL_Class.ReadValueString("Select Media_Info from MetaDataArchive where ID=" + id,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            var frm = new Media_Info_Show();
            frm.rtb.Text = md;
            frm.Show();
        }


        public static void Show_Other_Info(string str)
        {
            var md = str;
            var frm = new Media_Info_Show();
            frm.Text = "Process Info";
            frm.rtb.Text = md;
            frm.Show();
        }


        public static void Form_Lauch(string path)
        {
            
            var frm = new Media_Info_Show();
            Media_Info.fill_rich_text_box(path, frm.rtb);
            frm.Show();
        }



        public static void Form_Lauch_Test(string input)
        {
            var md = input;
            var frm = new Media_Info_Show();
            frm.rtb.Text = md;
            frm.Show();
        }
    }
}