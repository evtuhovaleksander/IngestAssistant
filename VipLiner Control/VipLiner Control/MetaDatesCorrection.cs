using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class MetaDatesCorrection : Form
    {
        public MetaDatesCorrection()
        {
            InitializeComponent();
            load_info();
        }

        public void all_to_white()
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[0].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[2].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[3].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[4].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[5].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[6].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[7].Style.BackColor = Color.White;
            }
        }

        public void load_info()
        {
            all_to_white();
            dgv.RowCount = 1;
            var count = SQL_Class.ReadValueInt32("Select Count(*) from " + Properties.Settings.Default.MetaDate, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            var sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            for (var i = 1; i <= count; i++)
            {
                
                    SQL_Class.ReadValues("SELECT MDD_A, MDD_B, MDD_C, MDD_Name, MDD_Deleted, MDD_InWork, " +
                                   "MDD_Fullness, MDD_Visible, MDD_RusName " +
                                   "FROM     " + Properties.Settings.Default.MetaDate + " WHERE  (MDD_ID = " + i + ")", ref sqlcl);
                sqlcl.SQL_DataReader.Read();
                if (!sqlcl.SQL_DataReader.GetBoolean(4))
                {
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = sqlcl.SQL_DataReader.GetString(3);
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = sqlcl.SQL_DataReader.GetString(8);
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = sqlcl.SQL_DataReader.GetInt32(0);
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = sqlcl.SQL_DataReader.GetInt32(1);
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = sqlcl.SQL_DataReader.GetInt32(2);
                    dgv.Rows[dgv.RowCount - 1].Cells[5].Value = sqlcl.SQL_DataReader.GetBoolean(7);
                    dgv.Rows[dgv.RowCount - 1].Cells[6].Value = sqlcl.SQL_DataReader.GetBoolean(6);
                    dgv.Rows[dgv.RowCount - 1].Cells[7].Value = sqlcl.SQL_DataReader.GetBoolean(5);
                    dgv.Rows[dgv.RowCount - 1].Cells[8].Value = i;
                    dgv.RowCount++;
                   
                }
            }
            sqlcl.Manualy_Close_Connection();
            if (dgv.RowCount != 1) dgv.RowCount--;
        }

        private void Refresh_But_Click(object sender, EventArgs e)
        {
            load_info();
        }

        private void save_all()
        {
            var count = dgv.RowCount;

            for (var i = 0; i < count; i++)
            {
                var zapros =
                    "UPDATE   " + Properties.Settings.Default.MetaDate +
                    "SET MDD_A ='" + dgv.Rows[i].Cells[2].Value + "', MDD_B ='" + dgv.Rows[i].Cells[3].Value +
                    "', MDD_C =" + dgv.Rows[i].Cells[4].Value + "," +
                    "MDD_Visible ='" + dgv.Rows[i].Cells[5].Value + "', MDD_Fullness ='" + dgv.Rows[i].Cells[6].Value +
                    "', " +
                    "MDD_InWork ='" + dgv.Rows[i].Cells[7].Value + "', MDD_Name ='" + dgv.Rows[i].Cells[0].Value +
                    "', MDD_RusName ='" + dgv.Rows[i].Cells[1].Value + "'" +
                    "WHERE  (MDD_ID = " + dgv.Rows[i].Cells[8].Value + ")";
                SQL_Class.Execute(zapros,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
                // MessageBox.Show(zapros);
            }
        }

        private void check()
        {
            var eror = false;
            var count = dgv.RowCount;
            for (var i = 0; i < count; i++)
            {
                if (dgv.Rows[i].Cells[0].Value == null)
                {
                    dgv.Rows[i].Cells[0].Style.BackColor = Color.OrangeRed;
                    eror = true;
                }
                else
                {
                    dgv.Rows[i].Cells[0].Style.BackColor = Color.LawnGreen;
                }
                if (dgv.Rows[i].Cells[1].Value == null)
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.OrangeRed;
                    eror = true;
                }
                else
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.LawnGreen;
                }
                if (dgv.Rows[i].Cells[3].Value == null)
                {
                    dgv.Rows[i].Cells[3].Style.BackColor = Color.OrangeRed;
                    eror = true;
                }
                else
                {
                    dgv.Rows[i].Cells[3].Style.BackColor = Color.LawnGreen;
                }
                if (!Convert.ToBoolean(dgv.Rows[i].Cells[5].Value) && Convert.ToBoolean(dgv.Rows[i].Cells[6].Value))
                {
                    dgv.Rows[i].Cells[5].Style.BackColor = Color.OrangeRed;
                    dgv.Rows[i].Cells[6].Style.BackColor = Color.OrangeRed;
                    eror = true;
                }
                else
                {
                    dgv.Rows[i].Cells[5].Style.BackColor = Color.LawnGreen;
                    dgv.Rows[i].Cells[6].Style.BackColor = Color.LawnGreen;
                }

                dgv.Rows[i].Cells[2].Style.BackColor = Color.LawnGreen;
                dgv.Rows[i].Cells[4].Style.BackColor = Color.LawnGreen;
                dgv.Rows[i].Cells[7].Style.BackColor = Color.LawnGreen;
            }


            if (!eror)
            {
                Save_Fin_But.Enabled = true;
            }
        }

        private void Save_Start_But_Click(object sender, EventArgs e)
        {
            {
                Add_GrBox.Enabled = false;
                Refresh_But.Enabled = false;

                Save_Start_But.Enabled = false;
                Cancel_But.Enabled = true;
                Check_but.Enabled = true;
                Save_Fin_But.Enabled = false;
                check();
            }
        }

        private void Cancel_But_Click(object sender, EventArgs e)
        {
            Add_GrBox.Enabled = true;
            Refresh_But.Enabled = true;

            Save_Start_But.Enabled = true;
            Cancel_But.Enabled = false;
            Check_but.Enabled = false;
            Save_Fin_But.Enabled = false;
        }

        private void Check_but_Click(object sender, EventArgs e)
        {
            check();
        }

        private void Save_Fin_But_Click(object sender, EventArgs e)
        {
            Add_GrBox.Enabled = true;
            Refresh_But.Enabled = true;

            Save_Start_But.Enabled = true;
            Cancel_But.Enabled = false;
            Check_but.Enabled = false;
            Save_Fin_But.Enabled = false;
            save_all();
        }

        private void Add_New_But_Click(object sender, EventArgs e)
        {
            var eror = false;

            if ((!Visible_ChBox.Checked) && (Fullness_ChBox.Checked))
            {
                Visible_ChBox.BackColor = Color.OrangeRed;
                Fullness_ChBox.BackColor = Color.OrangeRed;
                eror = true;
            }
            else
            {
                Visible_ChBox.BackColor = Color.LawnGreen;
                Fullness_ChBox.BackColor = Color.LawnGreen;
            }


            if (A_TBox.Text == "")
            {
                eror = true;
                A_TBox.BackColor = Color.OrangeRed;
            }
            else
            {
                A_TBox.BackColor = Color.LawnGreen;
            }


            if (Name_TBox.Text == "")
            {
                eror = true;
                Name_TBox.BackColor = Color.OrangeRed;
            }
            else
            {
                Name_TBox.BackColor = Color.LawnGreen;
            }


            if (Name_Rus_TBox.Text == "")
            {
                eror = true;
                Name_Rus_TBox.BackColor = Color.OrangeRed;
            }
            else
            {
                Name_Rus_TBox.BackColor = Color.LawnGreen;
            }


            if (!eror)
            {
                var zapros =
                    "INSERT INTO " + Properties.Settings.Default.MetaDate + " (MDD_Name, MDD_RusName, MDD_A, MDD_B, MDD_C, MDD_Fullness, MDD_Visible, MDD_InWork,MDD_Deleted)" +
                    "VALUES ('" + Name_TBox.Text + "','" + Name_Rus_TBox.Text + "','" + A_TBox.Text + "','" +
                    B_TBox.Text + "'," + C_TBox.Text + ",'" + Fullness_ChBox.Checked + "','" + Visible_ChBox.Checked +
                    "','" + InWork_ChBox.Checked + "',0)";
                SQL_Class.Execute(zapros,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);

                B_TBox.BackColor = Color.White;
                B_TBox.Text = "";

                A_TBox.BackColor = Color.White;
                A_TBox.Text = "";
                B_TBox.BackColor = Color.White;
                B_TBox.Text = "";
                Name_TBox.BackColor = Color.White;
                Name_TBox.Text = "";
                Name_Rus_TBox.BackColor = Color.White;
                Name_Rus_TBox.Text = "";
                load_info();
            }
        }

        private void MetaDatesCorrection_Load(object sender, EventArgs e)
        {
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Удалить данную запись", "", MessageBoxButtons.YesNo))
            {
                var zapros =
                    "UPDATE " + Properties.Settings.Default.MetaDate + "  " +
                    "SET MDD_Deleted=1  " + "WHERE  (MDD_ID = " + dgv.Rows[e.RowIndex].Cells[8].Value +
                    ")";
                SQL_Class.Execute(zapros,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
                load_info();
            }
        }

        public static void Form_Lauch(Main_Form parent)
        {
            var form = new MetaDatesCorrection();
            form.StartPosition = FormStartPosition.Manual;
            // form.Location = new Point(0, parent.Height);
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.Show();
        }
    }
}