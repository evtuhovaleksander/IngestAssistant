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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            Visible = false;
            //if(Profile_Settings.Aplication_Start())Main_Form.Start_Programm();
            Close();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
