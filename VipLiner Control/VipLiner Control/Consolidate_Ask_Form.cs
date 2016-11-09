using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class Consolidate_Ask_Form : Form
    {
        public int result;
        private File_Work parent_form;
        public Consolidate_Ask_Form()
        {
            InitializeComponent();
        }

        private void Consolidate_Ask_Form_Load(object sender, EventArgs e)
        {

        }

        public static int Ask_Question(File_Work parent)
        {
            Consolidate_Ask_Form frm=new Consolidate_Ask_Form();
            frm.parent_form = parent;
            frm.ShowDialog();
            return frm.result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result= 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + parent_form.VL_TBox.Text);
            DialogResult res = DialogResult.Yes;
            if (files.Length != 0)
            {
                string message = "Внимание будут удалены следующие файлы:";
                for (int i = 0; i < files.Length; i++)
                {
                    message += "\n" + Path.GetFileName(files[i]);
                }
               res = MessageBox.Show(message, "Удалить файлы?", MessageBoxButtons.YesNo);
                
            }
            if (res == DialogResult.Yes)
            {
                result = 2;
                Close();
            }
            else
            {
                MessageBox.Show("Пересоздание рабочей папки отименено");
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = 3;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = 4;
            Close();
        }
    }
}
