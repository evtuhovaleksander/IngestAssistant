using System;
using System.Drawing;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class ShowMetaDatesShablons : Form
    {
        private Meta_N_NR[] Fin_Meta = new Meta_N_NR[0];
        private string[] Fin_Meta_Name = new string[0];
        private Meta_N_NR[] Meta_all;
        private string[] Meta_all_Rus_Name;
        private Meta_S[] Shab;
        private string[] Shab_Name;
        private Meta_N_NR[] SS_Meta;
        private string[] SS_Meta_Name;

        public ShowMetaDatesShablons()
        {
            InitializeComponent();
            load_existing_shablons();
            load_all_dates_meta();
        }

        public void load_all_dates_meta()
        {
            Meta_all = new Meta_N_NR[0];
            Meta_all_Rus_Name = new string[0];
            var col = Log_SQL.ReadValueInt32("Select Count(*) from MetaDates",Settings.Default.MetaBase_Way);

            var sqlcl = Log_SQL.Create_class(Settings.Default.MetaBase_Way, "load_all_dates_meta()");
            for (var i = 1; i <= col; i++)
            {
                var zapros = "Select MDD_ID, MDD_Name, MDD_RusName, MDD_Deleted from MetaDates where MDD_ID=" + i;
                Log_SQL.ReadValues(zapros,ref sqlcl);
                sqlcl.SQL_DataReader.Read();

                if (!sqlcl.SQL_DataReader.GetBoolean(3))
                {
                    Array.Resize(ref Meta_all, Meta_all.Length + 1);
                    Array.Resize(ref Meta_all_Rus_Name, Meta_all_Rus_Name.Length + 1);
                    var temp = new Meta_N_NR();
                    temp.id = i;
                    temp.Name = sqlcl.SQL_DataReader.GetString(1);
                    temp.Name_Rus = sqlcl.SQL_DataReader.GetString(2);
                    Meta_all[Meta_all.Length - 1] = temp;
                    Meta_all_Rus_Name[Meta_all_Rus_Name.Length - 1] = sqlcl.SQL_DataReader.GetString(2);
                }
               
            }
            sqlcl.Manualy_Close_Connection();
        }

        public void load_existing_shablons()
        {
            Shab = new Meta_S[0];
            Shab_Name = new string[0];
            var col = SQL.ReadValueInt32("Select Count(*) from MetaDatesSettings");
            for (var i = 1; i <= col; i++)
            {
                var zapros = "Select MDS_ID, MDS_Name, MDS_Set from MetaDatesSettings where MDS_ID=" + i;
                var sqlcl = SQL.ReadValues(zapros);
                sqlcl.SQL_DataReader.Read();

                if (sqlcl.SQL_DataReader.GetString(1) != "Deleted")
                {
                    Array.Resize(ref Shab, Shab.Length + 1);
                    Array.Resize(ref Shab_Name, Shab_Name.Length + 1);
                    var temp = new Meta_S();
                    temp.id = i;
                    temp.Name = sqlcl.SQL_DataReader.GetString(1);
                    temp.Set = sqlcl.SQL_DataReader.GetString(2);
                    Shab[Shab.Length - 1] = temp;
                    Shab_Name[Shab_Name.Length - 1] = sqlcl.SQL_DataReader.GetString(1);
                }
                sqlcl.Manualy_Close_Connection();
            }


            Shab_CmBox.DataSource = Shab_Name;
        }

        private void ShowMetaDatesShablons_Load(object sender, EventArgs e)
        {
            load_all_dates_meta();
        }

        private void refresh_shab_but_Click(object sender, EventArgs e)
        {
        }

        private void Shab_CmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh_shab_gdv(Array.IndexOf(Shab_Name, Shab_CmBox.SelectedValue.ToString()));
        }

        private void refresh_shab_gdv(int id)
        {
            load_all_dates_meta();
            {
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

        private void shab_del_but_Click(object sender, EventArgs e)
        {
            var count = SQL.ReadValueInt32("Select Count(*) from MetaDatesSettings Where MDS_Name <> 'Deleted'"); // 
            if (count >= 2)
            {
                var id = Array.IndexOf(Shab_Name, Shab_CmBox.SelectedValue.ToString());
                var zapros = "UPDATE MetaDatesSettings SET MDS_Name ='Deleted' Where MDS_ID=" + (id + 1);
                SQL.Execute(zapros);
                load_existing_shablons();
            }
            else
            {
                MessageBox.Show("Удаление не возможно");
            }
        }

        private void create_new_shab()
        {
            Fin_Meta = new Meta_N_NR[0];
            Fin_Meta_Name = new string[0];
            fin_dgv.RowCount = 1;


            all_dgv.RowCount = Meta_all_Rus_Name.Length;
            for (var i = 0; i < Meta_all_Rus_Name.Length; i++)
            {
                all_dgv.Rows[i].Cells[0].Value = Meta_all_Rus_Name[i];
            }


            for (var i = 0; i < all_dgv.RowCount; i++)
            {
                all_dgv.Rows[i].Cells[0].Style.BackColor = Color.White;
            }


            for (var i = 0; i < fin_dgv.RowCount; i++)
            {
                fin_dgv.Rows[i].Cells[0].Style.BackColor = Color.White;
                fin_dgv.Rows[i].Cells[0].Value = "";
            }
        }

        private void InFin_Color_But_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == CD.ShowDialog())
            {
                InFin_Color_But.BackColor = CD.Color;
            }
        }

        private void go_to_step1_but_Click(object sender, EventArgs e)
        {
            TBC.SelectedTab = Create;
            create_new_shab();
        }

        private void all_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_to_fin(e.RowIndex, all_dgv);
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

        private void dgv_paint(DataGridView dgv, int id)
        {
            dgv.Rows[id].Cells[0].Style.BackColor = InFin_Color_But.BackColor;
        }

        private void check_all_dgv(string name)
        {
            var id = check_element(Meta_all_Rus_Name, name);
            if (id != -1) dgv_paint(all_dgv, id);
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
                fin_dgv.RowCount = Fin_Meta.Length;
                fin_dgv.Rows[fin_dgv.RowCount - 1].Cells[0].Value = name;
                check_all_dgv(name);
            }
            Refresh();
            all_dgv.Refresh();
        }

        private void ret_to_zero_step_Click(object sender, EventArgs e)
        {
            TBC.SelectedTab = Load;
        }

        private void go_to_second_step_but_Click(object sender, EventArgs e)
        {
            prepare_save_shab();
            TBC.SelectedTab = Save;
        }

        public void prepare_save_shab()
        {
            if (Fin_Meta.Length == 0)
            {
                MessageBox.Show(
                    "Не выбранны параметры для шаблона, Поэтому автоматически будут добавленны все настройки");

                Fin_Meta = Meta_all;
                Fin_Meta_Name = Meta_all_Rus_Name;
            }


            ss_dgv.RowCount = Fin_Meta.Length;
            for (var i = 0; i < ss_dgv.RowCount; i++)
            {
                ss_dgv.Rows[i].Cells[0].Value = Fin_Meta_Name[i];
            }
        }

        private void ret_to_step2_Click(object sender, EventArgs e)
        {
            TBC.SelectedTab = Create;
        }

        private void SS_but_Click(object sender, EventArgs e)
        {
            if (ss_TBox.Text != "")
            {
                var count =
                    SQL.ReadValueInt32("Select Count(*) from MetaDatesSettings Where MDS_Name='" + ss_TBox.Text + "'");
                if (count > 0)
                {
                    MessageBox.Show("Такая настройка уже есть");
                    ss_TBox.BackColor = Color.OrangeRed;
                }
                else
                {
                    var setting = "";
                    if (Fin_Meta.Length != 0)
                    {
                        setting += Fin_Meta[0].id;
                        for (var i = 1; i < Fin_Meta.Length; i++)
                        {
                            setting += "|" + SS_Meta[i].id;
                        }

                        MessageBox.Show(setting);
                        var zapros = "INSERT INTO MetaDatesSettings (MDS_Name, MDS_Set) VALUES ('" + ss_TBox.Text +
                                     "','" + setting + "') ";
                        MessageBox.Show(zapros);
                        SQL.Execute(zapros);
                        TBC.SelectedTab = Load;
                        load_existing_shablons();
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

        private void Shab_to_set_Click(object sender, EventArgs e)
        {
            Settings.Default.Meta_Dates_Settings = Array.IndexOf(Shab_Name,
                Shab_CmBox.SelectedValue.ToString());
        }

        private void ShowMetaDatesShablons_Load_1(object sender, EventArgs e)
        {
        }

        public static void Form_Lauch(Main_Form parent)
        {
            var form = new ShowMetaDatesShablons();
            form.StartPosition = FormStartPosition.Manual;
            // form.Location = new Point(0, parent.Height);
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.Show();
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