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
    public partial class Log_Col_Ask : Form
    {
        public Log_Col_Ask()
        {
            InitializeComponent();
        }

        private int all_elements_count;

        private void Log_Col_Ask_Load(object sender, EventArgs e)
        {
            Limited_RBut.Text += " (" + Properties.Settings.Default.Max_Elements_For_DGV + "записей)";
        }

        public static void Ask_Diapason(int all_elements_count, ref int start, ref int stop)
        {
            Log_Col_Ask frm = new Log_Col_Ask();
            frm.col_label.Text = "Всего найдено " + all_elements_count + " записей";
            frm.all_elements_count = all_elements_count;
            frm.start_bar.Maximum = all_elements_count - 1;
            frm.stop_bar.Maximum = all_elements_count - 1;
            frm.start_bar.Value = all_elements_count - Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
            frm.stop_bar.Value = all_elements_count - 1;
            frm.start_label.Text = "0";
            frm.stop_label.Text = all_elements_count.ToString();
            frm.Accept.Text = "Вывод с " + frm.start_bar.Value + " по " + frm.stop_bar.Value + "  Итого:" + (frm.stop_bar.Value - frm.start_bar.Value) + " записей";
            frm.ShowDialog();
            start = frm.start_bar.Value;
            stop = frm.stop_bar.Value;
        }

        private void stop_bar_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void start_bar_ValueChanged(object sender, EventArgs e)
        {
            if (Limited_RBut.Checked)
            {
                if ((stop_bar.Value - start_bar.Value) >
                    Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
                {
                    stop_bar.Value = start_bar.Value + Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
                }
                if (start_bar.Value >= stop_bar.Value) stop_bar.Value = start_bar.Value;
                
            }
            Accept.Text = "Вывод с " + start_bar.Value + " по " + stop_bar.Value + "  Итого:" +
                              (stop_bar.Value - start_bar.Value) + " записей";
        }

        private void stop_bar_ValueChanged(object sender, EventArgs e)
        {
            if (Limited_RBut.Checked)
            {
                if ((stop_bar.Value - start_bar.Value) >
                    Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
                {
                    start_bar.Value = stop_bar.Value - Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
                }
                if (start_bar.Value >= stop_bar.Value) start_bar.Value = stop_bar.Value;
                
            }
            Accept.Text = "Вывод с " + start_bar.Value + " по " + stop_bar.Value + "  Итого:" +
                              (stop_bar.Value - start_bar.Value) + " записей";
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void start_bar_Scroll(object sender, EventArgs e)
        {

        }

        private void Limited_RBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Limited_RBut.Checked)
            {
                start_bar_ValueChanged(null,null);
            }
        }

        private void All_RBut_CheckedChanged(object sender, EventArgs e)
        {
            start_bar.Value = 0;
            stop_bar.Value = stop_bar.Maximum;
            Accept.Text = "Вывод с " + start_bar.Value + " по " + stop_bar.Value + "  Итого:" +
                              (stop_bar.Value - start_bar.Value) + " записей";
        }


    }
}
