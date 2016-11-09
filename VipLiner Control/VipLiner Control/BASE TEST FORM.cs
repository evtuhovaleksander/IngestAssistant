using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class BASE_TEST_FORM : Form
    {
        public BASE_TEST_FORM()
        {
            InitializeComponent();
        }



        private Log_SQL clas_for_con;



        private void button1_Click(object sender, EventArgs e)
        {
            clas_for_con = Log_SQL.Create_class(Properties.Settings.Default.Log_Base_Path,"TEST");
            Log_SQL.ReadValues("Select Count(*) from Logs", ref clas_for_con);
            clas_for_con.SQL_Connection.State.ToString();
            MessageBox.Show("OPENED");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clas_for_con.Manualy_Close_Connection();
            MessageBox.Show("Closed by man close");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string info = "try to log";
            string time = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy");
            var zapros = "INSERT INTO Logs (Gr,Name,Fr,Dest,Info,VP,Stat) VALUES (2,'" + info + "','','','" +
                         Environment.UserName + "','" + "" + "','" + time +
                         "')";

            if (!Log_SQL.Execute_Main(zapros, Properties.Settings.Default.Log_Base_Path))
            {
                MessageBox.Show("ERROROROR");
            }
            else
            {
                MessageBox.Show("SUCSESSSS");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           //SqlConnection.ClearPool(clas_for_con.SQL_Connection);
         //   sql 
            int i = Convert.ToInt32(textBox1.Text);
            Thread.Sleep(i);
            MessageBox.Show("fsrfdfs     " + i);
        }
    }
}
