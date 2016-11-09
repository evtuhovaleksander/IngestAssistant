using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VipLiner_Control
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            int i = 1;
            textBox1.Text = "";
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        textBox1.Text+=line;
                       // richTextBox1.Lines[i] = line;
                        i++;
                    }
                }
            }



            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zap = "Description";//Created By
            string xml = textBox1.Text;
            int inn = xml.IndexOf(zap);
            inn += zap.Length+ 19;
            inn++;
            string buf = "";
            while (xml[inn] != '<')
            {
                buf += xml[inn];
                inn++;
            }
            MessageBox.Show(buf);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
