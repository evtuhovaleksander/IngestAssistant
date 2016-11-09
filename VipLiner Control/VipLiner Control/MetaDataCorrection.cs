using System;
using System.Drawing;
using System.Windows.Forms;



namespace Ingest_Assistant
{
    public partial class MetaDataCorrection : Form
    {
        public MetaDataCorrection()
        {
            InitializeComponent();
        }

        private void rebuild_dgv_with_chBox_Options()
        {
            var count = SQL_Class.ReadValueInt32("SELECT Count(*) From " + Properties.Settings.Default.MetaData, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            dgv.RowCount = count;
            var shown = 0;
            var sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            for (var i = 0; i < count; i++)
            {
                SQL_Class.ReadValues("SELECT MD_Name, MD_Rus_Name, MD_XML, " +
                                           "MD_TXT, MD_XLS, MD_Show_Key, MD_Fullness_Key, MD_InWork_Key FROM     "+Properties.Settings.Default.MetaData+" Where MD_ID=" +
                                           (i + 1),ref sqlcl);
                while (sqlcl.SQL_DataReader.Read())
                {
                    var okey = false;
                    if (B_All.Checked)
                    {
                        okey = true;
                    }
                    else
                    {
                        if (B_XML.Checked && sqlcl.SQL_DataReader.GetString(2) != "") okey = true;
                        if (B_TXT.Checked && sqlcl.SQL_DataReader.GetInt32(3).ToString() != "0") okey = true;
                        if (B_XLS.Checked && sqlcl.SQL_DataReader.GetString(4) != "") okey = true;
                        if (B_Visible.Checked && sqlcl.SQL_DataReader.GetBoolean(5)) okey = true;
                        if (B_Fullness.Checked && sqlcl.SQL_DataReader.GetBoolean(6)) okey = true;
                        if (B_Inwork.Checked && sqlcl.SQL_DataReader.GetBoolean(7)) okey = true;
                    }


                    if (okey)
                    {
                        dgv.Rows[shown].Cells[0].Value = sqlcl.SQL_DataReader.GetString(0);
                        dgv.Rows[shown].Cells[1].Value = sqlcl.SQL_DataReader.GetString(1);
                        dgv.Rows[shown].Cells[2].Value = sqlcl.SQL_DataReader.GetString(2);
                        dgv.Rows[shown].Cells[3].Value = sqlcl.SQL_DataReader.GetInt32(3).ToString();
                        dgv.Rows[shown].Cells[4].Value = sqlcl.SQL_DataReader.GetString(4);
                        dgv.Rows[shown].Cells[5].Value = sqlcl.SQL_DataReader.GetBoolean(5);
                        dgv.Rows[shown].Cells[6].Value = sqlcl.SQL_DataReader.GetBoolean(6);
                        dgv.Rows[shown].Cells[7].Value = sqlcl.SQL_DataReader.GetBoolean(7);
                        dgv.Rows[shown].Cells[8].Value = i + 1;
                        shown++;
                    }
                }
            }
            sqlcl.Manualy_Close_Connection();
            dgv.RowCount = shown;
            Refresh();
        }

      private void Refresh_But_Click(object sender, EventArgs e)
        {
            rebuild_dgv_with_chBox_Options();
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


            if (TXT_TBox.Text == "")
            {
                eror = true;
                TXT_TBox.BackColor = Color.OrangeRed;
            }
            else
            {
                TXT_TBox.BackColor = Color.LawnGreen;
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
                    "INSERT INTO "+Properties.Settings.Default.MetaData+" (MD_Name, MD_Rus_Name, MD_TXT, MD_XML, MD_XLS, MD_Fullness_Key, MD_Show_Key, MD_InWork_Key)" +
                    "VALUES ('" + Name_TBox.Text + "','" + Name_Rus_TBox.Text + "'," + TXT_TBox.Text + ",'" +
                    XML_TBox.Text + "','" + XLS_TBox.Text + "','" + Fullness_ChBox.Checked + "','" +
                    Visible_ChBox.Checked + "','" + InWork_ChBox.Checked + "')";
                SQL_Class.Execute(zapros,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);

                TXT_TBox.BackColor = Color.White;
                TXT_TBox.Text = "";

                XML_TBox.BackColor = Color.White;
                XML_TBox.Text = "";
                XLS_TBox.BackColor = Color.White;
                XLS_TBox.Text = "";
                Name_TBox.BackColor = Color.White;
                Name_TBox.Text = "";
                Name_Rus_TBox.BackColor = Color.White;
                Name_Rus_TBox.Text = "";
                rebuild_dgv_with_chBox_Options();
            }
        }

        private void C_Show_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_Show_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void paint_all_to_white()
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

        private void C_All_To_White_Click(object sender, EventArgs e)
        {
            paint_all_to_white();
        }

        private void paint_line(int id, Color col)
        {
            dgv.Rows[id].Cells[0].Style.BackColor = col;
            dgv.Rows[id].Cells[1].Style.BackColor = col;
            dgv.Rows[id].Cells[2].Style.BackColor = col;
            dgv.Rows[id].Cells[3].Style.BackColor = col;
            dgv.Rows[id].Cells[4].Style.BackColor = col;
            dgv.Rows[id].Cells[5].Style.BackColor = col;
            dgv.Rows[id].Cells[6].Style.BackColor = col;
            dgv.Rows[id].Cells[7].Style.BackColor = col;
        }

        private void C_Repaint_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                if (C_All_Line_ChBox.Checked)
                {
                    if (C_Show_ChBox.Checked && dgv.Rows[i].Cells[5].Value.ToString() == "True")
                        paint_line(i, C_Show_Choose_Color_But.BackColor);
                    if (C_Fullness_ChBox.Checked && dgv.Rows[i].Cells[6].Value.ToString() == "True")
                        paint_line(i, C_Fullness_Choose_Color_But.BackColor);
                    if (C_InWork_ChBox.Checked && dgv.Rows[i].Cells[7].Value.ToString() == "True")
                        paint_line(i, C_InWork_Choose_Color_But.BackColor);
                    if (C_TXT_ChBox.Checked && dgv.Rows[i].Cells[3].Value.ToString() != "0")
                        paint_line(i, C_TXT_Choose_Color_But.BackColor);
                    if (C_XML_ChBox.Checked && dgv.Rows[i].Cells[2].Value.ToString() != "")
                        paint_line(i, C_XML_Choose_Color_But.BackColor);
                    if (C_XLS_ChBox.Checked && dgv.Rows[i].Cells[4].Value.ToString() != "")
                        paint_line(i, C_XLS_Choose_Color_But.BackColor);
                }
                else
                {
                    if (C_Show_ChBox.Checked && dgv.Rows[i].Cells[5].Value.ToString() == "True")
                        dgv.Rows[i].Cells[5].Style.BackColor = C_Show_Choose_Color_But.BackColor;
                    if (C_Fullness_ChBox.Checked && dgv.Rows[i].Cells[6].Value.ToString() == "True")
                        dgv.Rows[i].Cells[6].Style.BackColor = C_Fullness_Choose_Color_But.BackColor;
                    if (C_InWork_ChBox.Checked && dgv.Rows[i].Cells[7].Value.ToString() == "True")
                        dgv.Rows[i].Cells[7].Style.BackColor = C_InWork_Choose_Color_But.BackColor;
                    if (C_TXT_ChBox.Checked && dgv.Rows[i].Cells[3].Value.ToString() != "0")
                        dgv.Rows[i].Cells[3].Style.BackColor = C_TXT_Choose_Color_But.BackColor;
                    if (C_XML_ChBox.Checked && dgv.Rows[i].Cells[2].Value.ToString() != "")
                        dgv.Rows[i].Cells[2].Style.BackColor = C_XML_Choose_Color_But.BackColor;
                    if (C_XLS_ChBox.Checked && dgv.Rows[i].Cells[4].Value.ToString() != "")
                        dgv.Rows[i].Cells[4].Style.BackColor = C_XLS_Choose_Color_But.BackColor;
                }
            }
        }

        private void C_Fullness_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_Fullness_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void C_InWork_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_InWork_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void C_TXT_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_TXT_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void C_XML_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_XML_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void C_XLS_Choose_Color_But_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                C_XLS_Choose_Color_But.BackColor = CD.Color;
            }
        }

        private void save_all()
        {
            var count = dgv.RowCount;

            for (var i = 0; i < count; i++)
            {
                var zapros =
                    "UPDATE " + Properties.Settings.Default.MetaData +
                    "   SET MD_TXT =" + dgv.Rows[i].Cells[3].Value + ", MD_XML ='" + dgv.Rows[i].Cells[2].Value +
                    "', MD_XLS ='" + dgv.Rows[i].Cells[4].Value + "'," +
                    "MD_Show_Key ='" + dgv.Rows[i].Cells[5].Value + "', MD_Fullness_Key ='" + dgv.Rows[i].Cells[6].Value +
                    "', " +
                    "MD_InWork_Key ='" + dgv.Rows[i].Cells[7].Value + "', MD_Name ='" + dgv.Rows[i].Cells[0].Value +
                    "', MD_Rus_Name ='" + dgv.Rows[i].Cells[1].Value + "'" +
                    "   WHERE  (MD_ID = " + dgv.Rows[i].Cells[8].Value + ")";
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

        private void ttest()
        {
            dgv.Columns[0].HeaderText = "название столбца";
            dgv.Columns[1].HeaderText = "название столбца1";
        }

        private void Save_Start_But_Click(object sender, EventArgs e)
        {
            Paint_GrBox.Enabled = false;
            Build_GrBox.Enabled = false;
            Add_GrBox.Enabled = false;
            Refresh_But.Enabled = false;

            Save_Start_But.Enabled = false;
            Cancel_But.Enabled = true;
            Check_but.Enabled = true;
            Save_Fin_But.Enabled = false;
            check();
        }

        private void Cancel_But_Click(object sender, EventArgs e)
        {
            Paint_GrBox.Enabled = true;
            Build_GrBox.Enabled = true;
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
            Paint_GrBox.Enabled = true;
            Build_GrBox.Enabled = true;
            Add_GrBox.Enabled = true;
            Refresh_But.Enabled = true;

            Save_Start_But.Enabled = true;
            Cancel_But.Enabled = false;
            Check_but.Enabled = false;
            Save_Fin_But.Enabled = false;
            save_all();
        }

      

        private void MetaDataCorrection_Load(object sender, EventArgs e)
        {
            rebuild_dgv_with_chBox_Options();
        }

        public static void Form_Lauch(Main_Form parent)
        {
            var form = new MetaDataCorrection();
            form.StartPosition = FormStartPosition.Manual;
            //form.Location = new Point(0, parent.Height);
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.Show();
        }
    }
}