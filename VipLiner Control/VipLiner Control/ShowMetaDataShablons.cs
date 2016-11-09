using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Show_Meta_Dates_Shablons : Form
    {
        private Meta_S[] Del;
        private string[] Del_Name;
        private Meta_N_NR[] Fin_Meta = new Meta_N_NR[0];
        private string[] Fin_Meta_Name = new string[0];
        private Meta_N_NR[] Meta_all;
        private string[] Meta_all_Rus_Name;
        private Meta_N_NR[] Meta_Invisible;
        private string[] Meta_Invisible_Rus_Name;
        private Meta_N_NR[] Meta_TXT;
        private string[] Meta_TXT_Rus_Name;
        private Meta_N_NR[] Meta_Visible;
        private string[] Meta_Visible_Rus_Name;
        private Meta_N_NR[] Meta_XLS;
        private string[] Meta_XLS_Rus_Name;
        private Meta_N_NR[] Meta_XML;
        private string[] Meta_XML_Rus_Name;
        private Meta_S[] Shab;
        private string[] Shab_Name;
        private Meta_N_NR[] SS_Meta;
        private string[] SS_Meta_Name;
        private Meta_N_NR[] Xchg_Name;
        private string[] Xchg_NameRus;

        public Show_Meta_Dates_Shablons()
        {
            InitializeComponent();
            all_dgv_fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all_dgv_fill();
        }

        public static void Form_Lauch(Main_Form parent)
        {
            var form = new Show_Meta_Dates_Shablons();
            form.StartPosition = FormStartPosition.Manual;
            // form.Location = new Point(0, parent.Height);
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.Show();
        }

        private void all_dgv_fill()
        {
            Meta_Visible_Rus_Name = new string[0];
            Meta_Invisible_Rus_Name = new string[0];
            Meta_TXT_Rus_Name = new string[0];
            Meta_XML_Rus_Name = new string[0];
            Meta_XLS_Rus_Name = new string[0];
            Meta_all_Rus_Name = new string[0];

            Meta_Visible = new Meta_N_NR[0];
            Meta_all = new Meta_N_NR[0];
            Meta_Invisible = new Meta_N_NR[0];
            Meta_TXT = new Meta_N_NR[0];
            Meta_XML = new Meta_N_NR[0];
            Meta_XLS = new Meta_N_NR[0];


            //Array.Resize(ref Meta_Visible,Meta_Visible.Length+1);
            var sql_count = SQL.ReadValueInt32("Select Count(*) From MetaData");
            var v = 0;
            var inv = 0;
            var txt = 0;
            var xml = 0;
            var xls = 0;

            for (var i = 1; i <= sql_count; i++)
            {
                var zapros =
                    "Select MD_Name, MD_Rus_Name, MD_Show_Key, MD_TXT, MD_XML, MD_XLS from MetaData Where MD_ID=" + i;
                var sqlcl = SQL.ReadValues(zapros);
                sqlcl.SQL_DataReader.Read();

                if (sqlcl.SQL_DataReader.GetBoolean(2))
                {
                    Array.Resize(ref Meta_Visible_Rus_Name, Meta_Visible_Rus_Name.Length + 1);
                    Array.Resize(ref Meta_Visible, Meta_Visible.Length + 1);
                    Meta_Visible[v].Name = sqlcl.SQL_DataReader.GetString(0);
                    Meta_Visible[v].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                    Meta_Visible[v].id = i;
                    Meta_Visible_Rus_Name[v] = sqlcl.SQL_DataReader.GetString(1);
                    v++;
                }
                else
                {
                    Array.Resize(ref Meta_Invisible, Meta_Invisible.Length + 1);
                    Array.Resize(ref Meta_Invisible_Rus_Name, Meta_Invisible_Rus_Name.Length + 1);
                    Meta_Invisible[inv].Name = sqlcl.SQL_DataReader.GetString(0);
                    Meta_Invisible[inv].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                    Meta_Invisible[inv].id = i;
                    Meta_Invisible_Rus_Name[inv] = sqlcl.SQL_DataReader.GetString(1);
                    inv++;
                }

                if (sqlcl.SQL_DataReader.GetInt32(3) != 0)
                {
                    Array.Resize(ref Meta_TXT, Meta_TXT.Length + 1);
                    Array.Resize(ref Meta_TXT_Rus_Name, Meta_TXT_Rus_Name.Length + 1);
                    Meta_TXT[txt].Name = sqlcl.SQL_DataReader.GetString(0);
                    Meta_TXT[txt].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                    Meta_TXT[txt].id = i;
                    Meta_TXT_Rus_Name[txt] = sqlcl.SQL_DataReader.GetString(1);
                    txt++;
                }

                if (sqlcl.SQL_DataReader.GetString(4) != "")
                {
                    Array.Resize(ref Meta_XML, Meta_XML.Length + 1);
                    Array.Resize(ref Meta_XML_Rus_Name, Meta_XML_Rus_Name.Length + 1);
                    Meta_XML[xml].Name = sqlcl.SQL_DataReader.GetString(0);
                    Meta_XML[xml].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                    Meta_XML[xml].id = i;
                    Meta_XML_Rus_Name[xml] = sqlcl.SQL_DataReader.GetString(1);
                    xml++;
                }
                if (sqlcl.SQL_DataReader.GetString(5) != "")
                {
                    //xls
                    Array.Resize(ref Meta_XLS, Meta_XLS.Length + 1);
                    Array.Resize(ref Meta_XLS_Rus_Name, Meta_XLS_Rus_Name.Length + 1);
                    Meta_XLS[xls].Name = sqlcl.SQL_DataReader.GetString(0);
                    Meta_XLS[xls].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                    Meta_XLS[xls].id = i;
                    Meta_XLS_Rus_Name[xls] = sqlcl.SQL_DataReader.GetString(1);
                    xls++;
                }


                i--;
                Array.Resize(ref Meta_all, Meta_all.Length + 1);
                Array.Resize(ref Meta_all_Rus_Name, Meta_all_Rus_Name.Length + 1);
                Meta_all[i].Name = sqlcl.SQL_DataReader.GetString(0);
                Meta_all[i].Name_Rus = sqlcl.SQL_DataReader.GetString(1);
                Meta_all[i].id = i + 1;
                Meta_all_Rus_Name[i] = sqlcl.SQL_DataReader.GetString(1);
                i++;


                sqlcl.Manualy_Close_Connection();
            }


            dgv_fill(v_dgv, Meta_Visible_Rus_Name);
            dgv_fill(unv_dgv, Meta_Invisible_Rus_Name);
            dgv_fill(txt_dgv, Meta_TXT_Rus_Name);
            dgv_fill(xml_dgv, Meta_XML_Rus_Name);
            dgv_fill(xls_dgv, Meta_XLS_Rus_Name);
        }

        private void dgv_fill(DataGridView dgv, string[] mas)
        {
            dgv.RowCount = mas.Length;
            for (var i = 0; i < mas.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = mas[i];
            }
        }

        private void dgv_paint_full(DataGridView dgv, Color col)
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[0].Style.BackColor = col;
            }
        }

        private void dgv_paint_all(Color col)
        {
            dgv_paint_full(v_dgv, col);
            dgv_paint_full(unv_dgv, col);
            dgv_paint_full(txt_dgv, col);
            dgv_paint_full(xml_dgv, col);
            dgv_paint_full(xls_dgv, col);
        }

        private void dgv_paint(DataGridView dgv, int id)
        {
            dgv.Rows[id].Cells[0].Style.BackColor = InFin_Color_But.BackColor;
        }

        private void check_all_dgv(string name)
        {
            var id = check_element(Meta_Visible_Rus_Name, name);
            if (id != -1) dgv_paint(v_dgv, id);
            id = check_element(Meta_Invisible_Rus_Name, name);
            if (id != -1) dgv_paint(unv_dgv, id);
            id = check_element(Meta_TXT_Rus_Name, name);
            if (id != -1) dgv_paint(txt_dgv, id);
            id = check_element(Meta_XML_Rus_Name, name);
            if (id != -1) dgv_paint(xml_dgv, id);
            id = check_element(Meta_XLS_Rus_Name, name);
            if (id != -1) dgv_paint(xls_dgv, id);
        }

        private int check_element(string[] mas, string name)
        {
            object value = name;
            return Array.IndexOf(mas, value);
        }

        private int check_element_meta(Meta_N_NR[] mas, string name)
        {
            var id = -1;
            for (var i = 0; i < mas.Length; i++)
            {
                if (mas[i].Name_Rus == name) id = i;
            }
            return id;
        }

        private void add_to_fin(int id, DataGridView par)
        {
            var name = par.Rows[id].Cells[0].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show(name, "Add?", MessageBoxButtons.YesNo))
            {
                Array.Resize(ref Fin_Meta_Name, Fin_Meta_Name.Length + 1);
                Fin_Meta_Name[Fin_Meta_Name.Length - 1] = name;
                Array.Resize(ref Fin_Meta, Fin_Meta.Length + 1);
                Fin_Meta[Fin_Meta.Length - 1] = Meta_all[check_element_meta(Meta_all, name)];
                fin_dgv.RowCount++;
                fin_dgv.Rows[fin_dgv.RowCount - 1].Cells[0].Value = name;
                check_all_dgv(name);
            }
            Refresh();
            dgv_refresh();
        }

        private void dgv_clear_selection(DataGridView dgv)
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[0].Selected = false;
            }
        }

        private void dgv_clear_selection_all()
        {
            dgv_clear_selection(v_dgv);
            dgv_clear_selection(unv_dgv);
            dgv_clear_selection(txt_dgv);
            dgv_clear_selection(xml_dgv);
            dgv_clear_selection(xls_dgv);
        }

        private void dgv_refresh()
        {
            v_dgv.Refresh();
            unv_dgv.Refresh();
            txt_dgv.Refresh();
            xml_dgv.Refresh();
            xls_dgv.Refresh();
            fin_dgv.Refresh();
        }

        private void v_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, v_dgv);
        }

        private void v_dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_clear_selection_all();
        }

        private void unv_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, unv_dgv);
        }

        private void txt_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, txt_dgv);
        }

        private void xml_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, xml_dgv);
        }

        private void xls_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, xls_dgv);
        }

        private void unv_dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_clear_selection_all();
        }

        private void txt_dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_clear_selection_all();
        }

        private void xml_dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_clear_selection_all();
        }

        private void xls_dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_clear_selection_all();
        }

        private void C_All_to_White_Click(object sender, EventArgs e)
        {
            dgv_paint_all(Color.White);
        }

        private void Show_Meta_Info_Load(object sender, EventArgs e)
        {
            refresh_shab();
        }

        private void Xchg_Start(string[] nr, Meta_N_NR[] n)
        {
            Xchg_NameRus = nr;
            Xchg_Name = n;
            xchg_dgv_fill(xchg_dgv, Xchg_NameRus);
            xchg_dgv.Refresh();
            Refresh();
        }

        private void xchg_dgv_fill(DataGridView dgv, string[] mas)
        {
            dgv.RowCount = mas.Length;
            for (var i = 0; i < mas.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = mas[i];
                dgv.Rows[i].Cells[1].Value = "False";
            }
        }

        private void xchg_dgv_paint(int id, Color col)
        {
            xchg_dgv.Rows[id].Cells[0].Style.BackColor = col;
            xchg_dgv.Rows[id].Cells[1].Style.BackColor = col;
        }

        private void go_to_second_step_but_Click(object sender, EventArgs e)
        {
            if (Fin_Meta_Name.Length == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Заполнить Всем?", "", MessageBoxButtons.YesNo))
                {
                    Xchg_Start(Meta_all_Rus_Name, Meta_all);
                    TAB.SelectedTab = step2;
                }
            }
            else
            {
                TAB.SelectedTab = step2;
                Xchg_Start(Fin_Meta_Name, Fin_Meta);
            }
        }

        private void Xchg_Button_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < xchg_dgv.RowCount; i++)
            {
                xchg_dgv_paint(i, Color.White);
            }

            var change = 0;
            for (var i = 0; i < xchg_dgv.RowCount; i++)
            {
                if (xchg_dgv.Rows[i].Cells[1].Value.ToString() == "True") change++;
            }


            switch (change)
            {
                case 0:
                    MessageBox.Show("Выберите два элемента для перестановки");
                    break;
                case 1:
                    MessageBox.Show("Выберите второй элемент для перестановки");
                    for (var i = 0; i < xchg_dgv.RowCount; i++)
                    {
                        if (xchg_dgv.Rows[i].Cells[1].Value.ToString() == "True") xchg_dgv_paint(i, Color.Orange);
                    }
                    break;
                case 2:
                    MessageBox.Show("OK");
                    var dva = new Queue<int>();
                    for (var i = 0; i < xchg_dgv.RowCount; i++)
                    {
                        if (xchg_dgv.Rows[i].Cells[1].Value.ToString() == "True")
                        {
                            xchg_dgv_paint(i, Color.LawnGreen);
                            dva.Enqueue(i);
                        }
                    }
                    var first = dva.Dequeue();
                    var second = dva.Dequeue();

                    string tm;
                    Meta_N_NR tmm;

                    tmm = Xchg_Name[first];
                    tm = Xchg_NameRus[first];
                    Xchg_NameRus[first] = Xchg_NameRus[second];
                    Xchg_Name[first] = Xchg_Name[second];
                    Xchg_NameRus[second] = tm;
                    Xchg_Name[second] = tmm;
                    xchg_dgv.Rows[first].Cells[0].Value = Xchg_NameRus[first];
                    xchg_dgv.Rows[second].Cells[0].Value = Xchg_NameRus[second];
                    xchg_dgv.Refresh();
                    Refresh();


                    break;
            }
            if (change >= 3)
            {
                MessageBox.Show("Выбрано более 2х элементов для перестановки");
                for (var i = 0; i < xchg_dgv.RowCount; i++)
                {
                    if (xchg_dgv.Rows[i].Cells[1].Value.ToString() == "True") xchg_dgv_paint(i, Color.Red);
                }
            }
        }

        private void xchg_all_to_white_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < xchg_dgv.RowCount; i++)
            {
                xchg_dgv_paint(i, Color.White);
            }
        }

        private void xchg_dgv_SelectionChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < xchg_dgv.RowCount; i++)
            {
                xchg_dgv.Rows[i].Cells[0].Selected = false;
                xchg_dgv.Rows[i].Cells[1].Selected = false;
            }
        }

        private void go_to_third_step_Click(object sender, EventArgs e)
        {
            SS_Meta = Xchg_Name;
            SS_Meta_Name = Xchg_NameRus;
            ss_dgv.RowCount = SS_Meta.Length;
            for (var i = 0; i < SS_Meta.Length; i++)
            {
                ss_dgv.Rows[i].Cells[0].Value = SS_Meta_Name[i];
            }
            ss_dgv.Refresh();
            Refresh();
            TAB.SelectedTab = step3;
        }

        private void SS_but_Click(object sender, EventArgs e)
        {
            if (ss_TBox.Text != "")
            {
                var count = SQL.ReadValueInt32("Select Count(*) from MetaSettings Where MS_Name='" + ss_TBox.Text + "'");
                if (count > 0)
                {
                    MessageBox.Show("Такая настройка уже есть");
                    ss_TBox.BackColor = Color.OrangeRed;
                }
                else
                {
                    var setting = "";
                    if (SS_Meta.Length != 0)
                    {
                        setting += SS_Meta[0].id;
                        for (var i = 1; i < SS_Meta.Length; i++)
                        {
                            setting += "|" + SS_Meta[i].id;
                        }

                        MessageBox.Show(setting);
                        var zapros = "INSERT INTO MetaSettings (MS_Name, MS_Set) VALUES ('" + ss_TBox.Text + "','" +
                                     setting + "') ";
                        MessageBox.Show(zapros);
                        SQL.Execute(zapros);
                        TAB.SelectedTab = step0;
                        refresh_shab();
                    }
                    else
                    {
                        MessageBox.Show("Пустая настройка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пустое имя");
                ss_TBox.BackColor = Color.OrangeRed;
            }
        }

        private void go_to_step1_but_Click(object sender, EventArgs e)
        {
            TAB.SelectedTab = step1;
        }

        private void ret_to_zero_step_Click(object sender, EventArgs e)
        {
            TAB.SelectedTab = step0;
        }

        private void ret_to_second_step_Click(object sender, EventArgs e)
        {
            TAB.SelectedTab = step1;
        }

        private void ret_to_step2_Click(object sender, EventArgs e)
        {
            TAB.SelectedTab = step2;
        }

        private void refresh_shab_but_Click(object sender, EventArgs e)
        {
            refresh_shab();
        }

        private void refresh_shab()
        {
            Shab = new Meta_S[0];
            Shab_Name = new string[0];

            var count = SQL.ReadValueInt32("Select Count(*) from MetaSettings"); // Where MS_Name <> '-'
            for (var i = 1; i <= count; i++)
            {
                if (
                    SQL.ReadValueInt32("Select Count(*) from MetaSettings Where MS_ID=" + i +
                                       " AND MS_Name<>'-'") > 0)
                {
                    var zapros = "Select MS_ID, MS_Name, MS_Set from MetaSettings Where MS_ID=" + i +
                                 " AND MS_Name<>'-'";
                    var sqlcl = SQL.ReadValues(zapros);
                    sqlcl.SQL_DataReader.Read();

                    Array.Resize(ref Shab, Shab.Length + 1);
                    Array.Resize(ref Shab_Name, Shab_Name.Length + 1);

                    var t = new Meta_S();
                    t.id = sqlcl.SQL_DataReader.GetInt32(0);
                    t.Name = sqlcl.SQL_DataReader.GetString(1);
                    t.Set = sqlcl.SQL_DataReader.GetString(2);
                    Shab[Shab.Length - 1] = t;
                    Shab_Name[Shab_Name.Length - 1] = sqlcl.SQL_DataReader.GetString(1);
                    sqlcl.Manualy_Close_Connection();
                }
            }

            Shab_CmBox.DataSource = Shab_Name;
        }

        private void refresh_shab_gdv(int id)
        {
            // if (id != 0)
            {
                all_dgv_fill();


                var set = Shab[id].Set;


                var mas_id = set.Split('|');


                shab_dgv.RowCount = 1;
                shab_dgv.RowCount = mas_id.Length;
                for (var i = 0; i < mas_id.Length; i++)
                {
                    var idd = Convert.ToInt32(mas_id[i]);
                    shab_dgv.Rows[i].Cells[0].Value = Meta_all_Rus_Name[idd - 1];
                }
                shab_dgv.Refresh();
                Refresh();
            }
        }

        private void Shab_CmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Shab_CmBox.SelectedValue.ToString());
            refresh_shab_gdv(Array.IndexOf(Shab_Name, Shab_CmBox.SelectedValue.ToString()));
        }

        private void Shab_to_set_Click(object sender, EventArgs e)
        {
            Settings.Default.Meta_Setting = Array.IndexOf(Shab_Name, Shab_CmBox.SelectedValue.ToString());
        }

        private void prepare_del_mas()
        {
            Del = new Meta_S[0];
            Del_Name = new string[0];

            var count = SQL.ReadValueInt32("Select Count(*) from MetaSettings"); // Where MS_Name <> '-'
            for (var i = 1; i <= count; i++)
            {
                if (
                    SQL.ReadValueInt32("Select Count(*) from MetaSettings Where MS_ID=" + i +
                                       " AND MS_Name='-'") > 0)
                {
                    var zapros = "Select MS_ID, MS_Name, MS_Set from MetaSettings Where MS_ID=" + i +
                                 " ";
                    var sqlcl = SQL.ReadValues(zapros);
                    sqlcl.SQL_DataReader.Read();

                    Array.Resize(ref Del, Del.Length + 1);
                    Array.Resize(ref Del_Name, Del_Name.Length + 1);

                    var t = new Meta_S();
                    t.id = sqlcl.SQL_DataReader.GetInt32(0);
                    t.Name = sqlcl.SQL_DataReader.GetString(1);
                    t.Set = sqlcl.SQL_DataReader.GetString(2);
                    Del[Del.Length - 1] = t;
                    Del_Name[Del_Name.Length - 1] = sqlcl.SQL_DataReader.GetString(1);
                    sqlcl.Manualy_Close_Connection();
                }
            }

            Shab_CmBox.DataSource = Shab_Name;


            stand_dgv.RowCount = Del_Name.Length;
            for (var i = 0; i < Del_Name.Length; i++)
            {
                stand_dgv.Rows[i].Cells[0].Value = Del[i].id;
                stand_dgv.Rows[i].Cells[1].Value = Del[i].Name;
            }
        }

        private void shab_del_but_Click(object sender, EventArgs e)
        {
            var count = SQL.ReadValueInt32("Select Count(*) from MetaSettings Where MS_Name <> '-'"); // 
            if (count >= 2)
            {
                var id = Array.IndexOf(Shab_Name, Shab_CmBox.SelectedValue.ToString());
                var zapros = "UPDATE MetaSettings SET MS_Name ='-' Where MS_ID=" + (id + 1);
                SQL.Execute(zapros);
                refresh_shab();
            }
            else
            {
                MessageBox.Show("Удаление не возможно");
            }
        }

        ////private void stand_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        ////{

        ////}

        private void back_to_0_Click(object sender, EventArgs e)
        {
            TAB.SelectedTab = step0;
            refresh_shab();
        }

        private void go_to_stand_Click(object sender, EventArgs e)
        {
            prepare_del_mas();
            TAB.SelectedTab = standup;
        }

        private void stand_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id_str = stand_dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            var id = Convert.ToInt32(id_str);
            all_dgv_fill();

            var set = "";
            for (var i = 0; i < Del.Length; i++)
            {
                if (Del[i].id == id) set = Del[i].Set;
            }


            var mas_id = set.Split('|');


            stand_set_dgv.RowCount = 1;
            stand_set_dgv.RowCount = mas_id.Length;
            for (var i = 0; i < mas_id.Length; i++)
            {
                stand_set_dgv.Rows[i].Cells[0].Value = Meta_all_Rus_Name[Convert.ToInt32(mas_id[i])];
            }
            stand_set_dgv.Refresh();
            Refresh();
        }

        private void stand_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (stand_dgv.Rows[e.RowIndex].Cells[1].Value.ToString() != "-")
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("переименованный в" + stand_dgv.Rows[e.RowIndex].Cells[1].Value,
                        "Востановить параметр", MessageBoxButtons.YesNo))
                {
                    var id = Del[e.RowIndex].id;
                    stand_shab(id, stand_dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

        private void stand_shab(int id, string nm)
        {
            var zapros = "UPDATE MetaSettings SET  MS_Name='" + nm + "' WHERE  (MetaSettings.MS_ID = " + id + ")";
            SQL.Execute(zapros);
            prepare_del_mas();
        }

        private struct Meta_N_NR
        {
            public int id;
            public string Name;
            public string Name_Rus;
        }

        private struct Meta_S
        {
            public int id;
            public string Name;
            public string Set;
        }
    }
}