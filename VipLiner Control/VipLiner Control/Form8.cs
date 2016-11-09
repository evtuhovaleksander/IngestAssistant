using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TestFileCopy;

namespace Ingest_Assistant
{
    public partial class Form8 : Form
    {
        private CopyFormOLD cpy;
        public Form8()
        {
            InitializeComponent();
             cpy= CopyFormOLD.Copy_Form_Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            button1.Text = openFileDialog1.FileName;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cpy.Copy_New_File_Add(button1.Text, button2.Text + Path.GetFileName(button1.Text));
        }

     
        private void button5_Click(object sender, EventArgs e)
        {
            cpy.Start_Copy_Operation();
        }
    }
}
