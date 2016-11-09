using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class SQL_Wait_Form : Form
    {
        private int max_try;
        public SQL_Wait_Form(int max)
        {
            InitializeComponent();
            max_try = max;
        }

        public static SQL_Wait_Form Get_Prepared_Form(int max)
        {
            SQL_Wait_Form frm = new SQL_Wait_Form(max);
            frm.Progress_Bar.Maximum = max + 1;
            frm.Progress_Bar.Value = 0;
            frm.Info_Label.Text = "Попытка 1/" + max + "  Время затрачено: "+new TimeSpan(0,0,0).ToString("g");
            frm.Pr_Label.Text = "1/" + max;
            frm.Show();
            return frm;
        }

        public void increase_step(DateTime start)
        {
            Progress_Bar.Value++;
            Info_Label.Text = "Попытка "+Progress_Bar.Value+"/" + max_try + "  Время затрачено: " + (DateTime.Now-start).ToString("g");
            Pr_Label.Text = Progress_Bar.Value+"/" + max_try;
            Refresh();
        }
    }
}
