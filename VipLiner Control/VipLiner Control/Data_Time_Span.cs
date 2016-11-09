using System;
using System.Linq;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class Data_Time_Span : Form
    {
        public string outt;
        
        public Data_Time_Span()
        {
            InitializeComponent();
        }

        public static string Data_ask()
        {
            var frm = new Data_Time_Span();
            frm.outt = "#";
            frm.ShowDialog();
          
            return frm.outt;
        }

        private void Data_Time_Span_Load(object sender, EventArgs e)
        {
        }

        private void end_Click(object sender, EventArgs e)
        {
            if (Time_Tbox.Text.Contains(':'))
            {
                outt = dt_picker.Value.ToString("yyyy.MM.dd") + " " + Time_Tbox.Text;
            }
            else
            {
                outt = dt_picker.Value.ToString("yyyy.MM.dd") + " " + remake_string(Time_Tbox.Text);
            }


            Close();
        }

        public string remake_string(string inn)
        {
            if (inn.Length < 5)
            {
                return inn;
            }
            var t1 = inn.Substring(inn.Length - 2);
            var t2 = inn.Substring(inn.Length - 5, 2);
            var t3 = "";
            if (inn.Length == 5)
            {
                t3 = inn[0].ToString();
            }
            else
            {
                t3 = inn.Substring(0, 2);
            }
            return t3 + ":" + t2 + ":" + t1;
            //return t3+":"+;
        }

        private void time_only_but_Click(object sender, EventArgs e)
        {
            if (Time_Tbox.Text.Contains(':'))
            {
                outt = Time_Tbox.Text;
            }
            else
            {
                outt = remake_string(Time_Tbox.Text);
            }


            Close();
        }
    }
}