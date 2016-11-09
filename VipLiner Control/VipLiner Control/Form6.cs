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
    public partial class Form6 : Form
    {
        public Form6()
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
                    textBox1.Text = sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    textBox2.Text = sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    textBox3.Text = sr.ReadLine();
                    MessageBox.Show(textBox3.Text[9].GetType().ToString());
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
