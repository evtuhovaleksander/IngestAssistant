﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Ingest_Assistant
{
    public partial class Get_Connection_To_Server_String : Form
    {
        private string output;
        public Get_Connection_To_Server_String()
        {
            InitializeComponent();
        
        }

        private void Cancel_But_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        public static string get_conection_string()
        {
            Get_Connection_To_Server_String frm=new Get_Connection_To_Server_String();
            frm.ShowDialog();
            return frm.output;
        }

        private void Confirm_But_Click(object sender, EventArgs e)
        {
            output = Connection_TBox.Text;
            Close();
        }

        private void Get_Connection_To_Server_String_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection_TBox.Text = "server=10.2.102.86;database=ingestassistantsettingsbase;user id=tus;password=QAz123456;";
            output = Connection_TBox.Text;
          //  Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection_TBox.Text = "server=10.2.102.108;database=ingestassistantsettingsbase;user id=IA;password=QAz123456;";
            output = Connection_TBox.Text;
        }

       
    }
}
