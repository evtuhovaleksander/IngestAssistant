using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class MessageBOX : Form
    {
        public MessageBOX()
        {
            InitializeComponent();
        }

        private void MessageBOX_Load(object sender, EventArgs e)
        {

        }
        
        public  static void Show_Message (string message)
        {
            MessageBOX frm = new MessageBOX();
            frm.Message_TBox.Text = message;
            frm.ShowDialog();
        }

        private void Close_But_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
