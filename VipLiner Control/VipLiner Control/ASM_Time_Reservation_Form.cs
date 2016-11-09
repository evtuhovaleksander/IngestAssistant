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
    public partial class ASM_Time_Reservation_Form : Form
    {
        public ASM_Time_Reservation_Form()
        {
            InitializeComponent();
        }

        private void ASM_Time_Reservation_Form_Load(object sender, EventArgs e)
        {
            string[] mas = Properties.Settings.Default.Reservations.Split('|');
            Description_CmBox.DataSource = mas;
        }

        public DateTimePicker DT_Picker_Inside;

        public static void Lauch_Form(Panel parent)
        {
            ASM_Time_Reservation_Form frm = new ASM_Time_Reservation_Form();
            frm.TopLevel = false;
            frm.Parent = parent;
            frm.Show();
            frm.Picker.Visible = false;
            frm.load_to_DGV();
        }



        public void load_to_DGV()
        {
            DateTime start = DT_Picker_Inside.Value.Date;
            DateTime stop = DT_Picker_Inside.Value.AddDays(1).Date;

            string zapros = "Select ID,Start,Stop,Description from reservations where (Start between '" +
                            start.ToString("yyyy.MM.dd HH:mm:ss") + "'   and '" + stop.ToString("yyyy.MM.dd HH:mm:ss") +
                            "')  and PrID="+Properties.Settings.Default.Profile_ID;

            SQL_Class sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            SQL_Class.ReadValues(zapros, ref sqlcl);
            int i = 0;
            dgv.RowCount = i + 1;
            while (sqlcl.SQL_DataReader.Read())
            {
                dgv.Rows[i].Cells[0].Value = sqlcl.SQL_DataReader.GetInt32(0);
                dgv.Rows[i].Cells[1].Value = sqlcl.SQL_DataReader.GetDateTime(1).ToString("T");
                dgv.Rows[i].Cells[2].Value = sqlcl.SQL_DataReader.GetDateTime(2).ToString("T");
                dgv.Rows[i].Cells[4].Value = sqlcl.SQL_DataReader.GetString(3);
                TimeSpan dur = (sqlcl.SQL_DataReader.GetDateTime(2) - sqlcl.SQL_DataReader.GetDateTime(1));
                dgv.Rows[i].Cells[3].Value = dur.ToString("g");
                i++;
                dgv.RowCount = i + 1;
            }

            dgv.RowCount = i;
            sqlcl.Manualy_Close_Connection();
        }

        private void Check_But_Click(object sender, EventArgs e)
        {
            check();
            
        }

        public void check()
        {
            try
            {
                if (Convert.ToDateTime(Time_Stop_TBox.Text) > Convert.ToDateTime(Time_Start_TBox.Text))
                {
                    Add_But.Enabled = true;
                    Check_But.BackColor = Color.GreenYellow;
                }
                else
                {
                    Check_But.BackColor = Color.Red;
                    Add_But.Enabled = false;
                }
            }
            catch (Exception)
            {
                Check_But.BackColor = Color.Red;
                Add_But.Enabled = false;
            //    throw;
            }
        }

        private void Time_Start_TBox_TextChanged(object sender, EventArgs e)
        {
            check();
        }

        private void Time_Stop_TBox_TextChanged(object sender, EventArgs e)
        {
            check();
        }

        private void Add_But_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(DT_Picker_Inside.Value.Year, DT_Picker_Inside.Value.Month, DT_Picker_Inside.Value.Day, Convert.ToDateTime(Time_Start_TBox.Text).Hour, Convert.ToDateTime(Time_Start_TBox.Text).Minute, Convert.ToDateTime(Time_Start_TBox.Text).Second);
            DateTime stop = new DateTime(DT_Picker_Inside.Value.Year, DT_Picker_Inside.Value.Month, DT_Picker_Inside.Value.Day, Convert.ToDateTime(Time_Stop_TBox.Text).Hour, Convert.ToDateTime(Time_Stop_TBox.Text).Minute, Convert.ToDateTime(Time_Stop_TBox.Text).Second);
                                                    
            string zapros = "insert into reservations (Start,Stop,Description,PrID) values ('"+start.ToString("yyyy.MM.dd HH:mm:ss")+ "','"+stop.ToString("yyyy.MM.dd HH:mm:ss")+"','"+Description_CmBox.SelectedItem+"'," + Properties.Settings.Default.Profile_ID+")";
            SQL_Class.Execute(zapros,Properties.Settings.Default.MetaBase_Way);
            load_to_DGV();
        }

        private void Del_But_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow VARIABLE in dgv.SelectedRows)
                {
                    long id = Convert.ToInt64(VARIABLE.Cells[0].Value);
                    string zapros = "delete from reservations where ID=" + id;
                    SQL_Class.Execute(zapros, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
                }
            }
            load_to_DGV();
        }

        private void DT_Picker_ValueChanged(object sender, EventArgs e)
        {
            load_to_DGV();
        }

        private void Picker_ValueChanged(object sender, EventArgs e)
        {
            load_to_DGV();
        }

        private void Time_Start_TBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                format(ref Time_Start_TBox);
            }
        }

        public void format(ref TextBox tb)
        {
            string outt;
            if (!tb.Text.Contains(':'))
            {
                outt = "";
                if (tb.Text.Length == 4)
                {
                    outt = tb.Text.Substring(0, 2) + ":" + tb.Text.Substring(2, 2)+":00";
                }
                if (tb.Text.Length == 6)
                {
                    outt = tb.Text.Substring(0, 2) + ":" + tb.Text.Substring(2, 2) + ":" + tb.Text.Substring(4, 2);
                }
                tb.Text = outt;
            }
            

        }

        private void Time_Stop_TBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                format(ref Time_Stop_TBox);
            }
        }

      
    }
}
