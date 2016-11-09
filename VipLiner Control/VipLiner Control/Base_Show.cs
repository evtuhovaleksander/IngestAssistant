using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Forms;

using Ingest_Assistant.Properties;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace Ingest_Assistant
{
    public partial class Base_Show : Form
    {
        private List<Search_Element> search_list;
        public Big_Element[] Base_Big_Data;
        public Big_Element[] Curent_Elements;
        public Big_Element[] Base_Big_Data1;
        public Big_Element[] Curent_Elements1;
        public int[] asms;
     //   private Browser Cur_Browser;
        private Main_Form Cur_Main;



        private DataTable tbl;//= new DataTable();

        public Base_Show(Main_Form inp2)
        {
           // Cur_Browser = inp;
            Cur_Main = inp2;
            InitializeComponent();
            asms = new int[1];
            asms[0] = 0;
            SQL_Class sql_cl = SQL_Class.Create_class(Properties.Settings.Default.Setting_Base_Path);
            string zapros = "select Name,ID from SN";
            SQL_Class.ReadValues(zapros, ref sql_cl);
            while (sql_cl.SQL_DataReader.Read())
            {
                if (sql_cl.SQL_DataReader.GetString(0).Contains("ASM"))
                {
                    Array.Resize(ref asms, asms.Length + 1);
                    asms[asms.Length - 1] = sql_cl.SQL_DataReader.GetInt32(1);
                }
            }
            prepare_variats();

            this.select_unselect_all.Checked=true;
            foreach (Search_Element el in search_list) 
            {
                if (!el.marked) this.select_unselect_all.Checked = false;
            }
        }

        public void prepare_variats()
        {
            search_list = new List<Search_Element>();

            string zapros =
                "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'metadataarchive' and table_schema = 'ingestassistantmainbase'";
            SQL_Class sqlcl = SQL_Class.Create_class(Properties.Settings.Default.MetaBase_Way);
            SQL_Class.ReadValues(zapros, ref sqlcl);
            while (sqlcl.SQL_DataReader.Read())
            {
                if (sqlcl.SQL_DataReader.GetString(0) != "ID" && sqlcl.SQL_DataReader.GetString(0) != "Deleted")
                    search_list.Add(new Search_Element(sqlcl.SQL_DataReader.GetString(0), sqlcl.SQL_DataReader.GetString(1)));
            }


            search_dgv.RowCount = search_list.Count;
            for (int i = 0; i < search_list.Count; i++)
            {
                search_dgv.Rows[i].Cells[0].Value = search_list[i].rusname;
                search_dgv.Rows[i].Cells[1].Value = search_list[i].marked;
            }
            search_dgv.Refresh();
            Refresh();
        }

        public void check_marked_variants()
        {
            for (int i = 0; i < search_list.Count; i++)
            {
                search_list[i].marked = Convert.ToBoolean(search_dgv.Rows[i].Cells[1].Value);
            }
        }

        public void invert_mark_by_id(int id)
        {
            search_list[id - 1].marked = !search_list[id - 1].marked;
            search_dgv.Rows[id].Cells[1].Value = search_list[id - 1].marked;

        }

        






        //public string get_concat_string()
        //{
        //    string str="";

        //    string zapros =
        //        "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'metadataarchive' and table_schema = 'ingestassistantmainbase'";
        //    SQL_Class sqlcl = SQL_Class.Create_class(Properties.Settings.Default.MetaBase_Way);
        //    SQL_Class.ReadValues(zapros, ref sqlcl);
        //    while (sqlcl.SQL_DataReader.Read())
        //    {
        //        if (sqlcl.SQL_DataReader.GetString(0) != "Deleted")
        //            str+=sqlcl.SQL_DataReader.GetString(0)+",";
        //    }
        //    if (str.Length != 0) str = str.Substring(0, str.Length - 1);
        //    return "";
        //}


        //public void prepare_select_part_prepare_dgv()
        //{
        //    string str = "";
        //    Queue<string> mas = new Queue<string>();
        //    //mas.Enqueue("ID");
        //    for (int i = 0; i < search_list.Count; i++)
        //    {
        //        if (search_list[i].marked)
        //        {
        //            mas.Enqueue(search_list[i].name);
        //            str += "," + search_list[i].name;

        //        }

        //    }

        //    //str = str.Substring(0, str.Length - 1);
        //    dgv.ColumnCount = mas.Count+2;
        //    dgv.Columns[0].HeaderText = "ID";
        //    dgv.Columns[0].Visible = false;
        //    dgv.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        //    dgv.Columns[0].ValueType = System.Type.GetType("System.Int32");
            

        //    dgv.Columns[1].HeaderText = "PrID";
        //    dgv.Columns[0].Visible = true;
        //    for (int i = 2; i < dgv.ColumnCount; i++)
        //    {
        //        string eng = mas.Dequeue();
        //        foreach (var el in search_list)
        //        {
        //            if (el.name == eng)
        //            {
        //                dgv.Columns[i].HeaderText = el.rusname;
        //                break;
        //            }
        //        }
                
        //    }




        //    Primary_Load_Info(str);

        //}


        public void color_row(int i, Color cl)
        {
            for (int k = 0; k < dgv.ColumnCount; k++)
            {
                dgv.Rows[i].Cells[k].Style.BackColor = cl;
            }

        }




        public string make_primary_zap(string agregate)
        {




            string pre_zapros = "";
                

            if (agregate.Contains("PrID"))
            {
                pre_zapros = "SELECT MDA.ID,PrID,MDA.ID  " + agregate.Replace("PrID", "St.Name") + " FROM     MetaDataArchive as MDA   left join ingestassistantsettingsbase.settings as St  on St.ID=PrID  where Deleted=0  ";
            }
            else 
            {
                pre_zapros = "SELECT DMA.ID,PrID,MDA.ID  " + agregate + " FROM     MetaDataArchive as MDA   where Deleted=0  ";
            }

            if (ViPlanner_ChBOX.Checked)
            {
                pre_zapros += "AND ViPlanner='" + Viplanner_TBox.Text + "'  ";
            }

            if (Reel_ID_ChBox.Checked)
            {
                pre_zapros += "AND Reel_ID='" + Reel_Id_TBox + "'  ";
            }


            if (Pr_Filter_ChBox.Checked)
            {
                pre_zapros += "AND PrID=" +
                              SQL_Class.ReadValueInt32(
                                  "select ID from settings where Name='" + Pr_Filter_CmBox.SelectedItem + "'",
                                  Properties.Settings.Default.Setting_Base_Path) + "  ";
            }

            if (D_Date_ChBox.Checked)
            {
                DateTime d1;
                DateTime d2;
                if (D_One_RBut.Checked)
                {
                    d1 = Date_Filter1.Value.Date;
                    d2 = d1.AddDays(1).Date;
                }
                else
                {
                    d1 = Date_Filter1.Value.Date;
                    d2 = Date_Filter2.Value.Date;
                }
                pre_zapros += "AND (Time_Of_Registration between '" + d1.ToString("yyyy.MM.dd HH:mm:ss") + "' and  '" +
                              d2.ToString("yyyy.MM.dd HH:mm:ss") + "'  )";
            }


            



            if (pre_zapros.Contains("UserID"))
            {
                pre_zapros = pre_zapros.Replace("UserID", "L.L_FullName");
                pre_zapros = pre_zapros.Replace("where",
                    "left join ingestassistantsettingsbase.login as L  on L_ID=UserId  where");
            }
            return pre_zapros;
        }

        //public string make_primary_zap_for_export()
        //{
        //    string pre_zapros =
        //        "SELECT  " + get_agregate_part_for_export() + " FROM     MetaDataArchive    where Deleted=0  ";


        //    if (ViPlanner_ChBOX.Checked)
        //    {
        //        pre_zapros += "AND ViPlanner='" + Viplanner_TBox.Text + "'  ";
        //    }

        //    if (Reel_ID_ChBox.Checked)
        //    {
        //        pre_zapros += "AND Reel_ID='" + Reel_Id_TBox + "'  ";
        //    }


        //    if (Pr_Filter_ChBox.Checked)
        //    {
        //        pre_zapros += "AND PrID=" +
        //                      SQL_Class.ReadValueInt32(
        //                          "select ID from settings where Name='" + Pr_Filter_CmBox.SelectedItem + "'",
        //                          Properties.Settings.Default.Setting_Base_Path) + "  ";
        //    }

        //    if (D_Date_ChBox.Checked)
        //    {
        //        DateTime d1;
        //        DateTime d2;
        //        if (D_One_RBut.Checked)
        //        {
        //            d1 = Date_Filter1.Value.Date;
        //            d2 = d1.AddDays(1).Date;
        //        }
        //        else
        //        {
        //            d1 = Date_Filter1.Value.Date;
        //            d2 = Date_Filter2.Value.Date;
        //        }
        //        pre_zapros += "AND (Time_Of_Registration between '" + d1.ToString("yyyy.MM.dd HH:mm:ss") + "' and  '" +
        //                      d2.ToString("yyyy.MM.dd HH:mm:ss") + "'  )";
        //    }







        //    if (pre_zapros.Contains("UserID"))
        //    {
        //        pre_zapros = pre_zapros.Replace("UserID", "L.L_FullName");
        //        pre_zapros = pre_zapros.Replace("where",
        //            "left join ingestassistantsettingsbase.login as L  on L_ID=UserId  where");
        //    }


        //    return pre_zapros;
        //}

        //public string get_agregate_part_for_export()
        //{
        //    string str = "";
        //    Queue<string> mas = new Queue<string>();
            
        //    for (int i = 0; i < search_list.Count; i++)
        //    {
        //        if (search_list[i].marked)
        //        {
        //            mas.Enqueue(search_list[i].name);
        //            str += search_list[i].name + ",";

        //        }

        //    }
        //    if (str.Length != 0) str = str.Substring(0, str.Length - 1);
        //    return str;
        //}


        

        //public void Primary_Load_Info(string str)
        //{
        //    string zapros = "select Count(*) from settings";
        //   List<Color> color_list=new List<Color>(SQL_Class.ReadValueInt32(zapros,Settings.Default.Setting_Base_Path));
        //    for (int i = 0; i < color_list.Count; i++)
        //    {
        //        zapros = "select Name from settings where ID=" + i;
        //        string prof_name = SQL_Class.ReadValueString(zapros, Settings.Default.Setting_Base_Path);
        //        if (prof_name.Contains("Ingest")) color_list[i] = ING_Color_But.BackColor;
        //        if (prof_name.Contains("ASM"))
        //        {
        //            if(prof_name.Contains("1"))color_list[i] = ASM1_Color_But.BackColor;
        //            if (prof_name.Contains("2")) color_list[i] = ASM2_Color_But.BackColor;
        //        }
        //    }
           
            
            






        //    string pre_zapros = make_primary_zap(str);
                

        //    string[] search_variants = All_Search_TBox.Text.Split('|');
        //    var sqlcon = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
        //    int rows_count = 0;
           

        //    //vk
        //    //MySqlDataAdapter mad=new MySqlDataAdapter(pre_zapros,sqlcon.SQL_Connection);
        //    //DataSet set = new DataSet();
        //    //DataTable tb = new DataTable();
        //    //mad.Fill(tb);
        //    //goto l1;
        //     SQL_Class.ReadValues(pre_zapros, ref sqlcon);
        //    while (sqlcon.SQL_DataReader.Read())
        //    {
        //        bool add = false;
        //        if (All_Search_chBox.Checked)
        //        {
        //            for (int i = 1; i < dgv.ColumnCount; i++)
        //            {
        //                if (contain(get_val(sqlcon.SQL_DataReader, i).ToString(), search_variants)) add = true;
        //            }
        //        }
        //        else
        //        {
        //            add = true;
        //        }
        //        if (add)
        //        {
        //            rows_count++;
        //        }

        //    }


        //    SQL_Class.ReadValues(pre_zapros, ref sqlcon);


        //    int row = 0;
        //    dgv.DataSource = null;
        //    if (rows_count != 0)
        //    {
        //        dgv.RowCount = rows_count;
        //        //dgv.Columns[0].Visible = false;
        //        //dgv.Columns[1].Visible = false;
        //        while (sqlcon.SQL_DataReader.Read() && row < rows_count)
        //        {
        //            bool add = false;
        //            if (All_Search_chBox.Checked)
        //            {
        //                for (int i = 1; i < dgv.ColumnCount; i++)
        //                {
        //                    if (contain(get_val(sqlcon.SQL_DataReader, i).ToString(), search_variants)) add = true;
        //                }
        //            }
        //            else
        //            {
        //                add = true;
        //            }
        //            if (add)
        //            {
        //                dgv.Rows[row].Cells[0].Value = get_val(sqlcon.SQL_DataReader, 0);
        //                dgv.Rows[row].Cells[0].ValueType = System.Type.GetType("System.Int32");
        //                dgv.Rows[row].Cells[1].Value = get_val(sqlcon.SQL_DataReader, 1);

        //                for (int i = 2; i < dgv.ColumnCount; i++)
        //                {
        //                    dgv.Rows[row].Cells[i].Value = get_val(sqlcon.SQL_DataReader, i);
        //                    Color col = Color.White;
        //                    int col_code = sqlcon.SQL_DataReader.GetInt32(1);
        //                    col = color_list[col_code];
        //                    //switch (col_code)
        //                    //{
        //                    //    case 1:
        //                    //        col = ING_Color_But.BackColor;
        //                    //        break;
        //                    //    case 2:
        //                    //        col = ASM1_Color_But.BackColor;
        //                    //        break;
        //                    //    case 3:
        //                    //        col = ASM2_Color_But.BackColor;
        //                    //        break;
        //                    //}
                            

        //                    color_row(row, col);
        //                }
        //                row++;
        //            }

        //        }
        //        sqlcon.SQL_DataReader.Close();
        //        sqlcon.Manualy_Close_Connection();
        //    }


        //  // l1: dgv.DataSource = tb;
        //}









        public string get_val(MySqlDataReader rd, int id)
        {
            
            if (rd.IsDBNull(id)) return "";
            //string iii = rd.GetDataTypeName(id);
            //if (rd.GetDataTypeName(id).ToLower() == "datetime") { return (DateTime) rd.GetDateTime(id); }
            //if (rd.GetDataTypeName(id).ToLower().Contains("int")) { return (int)rd.GetInt32(id); }

            try
            {
                return  rd.GetDateTime(id).ToString("G");
            }
            catch (Exception)
            {
                return rd.GetString(id);
            }

        }







        public Boolean contain(string big_el_parameter, string[] search)
        {
            Boolean res = false;
            for (int i = 0; i < search.Length; i++)
            {
                if (big_el_parameter != null)
                    if (big_el_parameter.Contains(search[i]))
                        res = true;
            }
            return res;
        }

      

        private void Base_Show_Load(object sender, EventArgs e)
        {
            Set_max_Tbox.Text = Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV.ToString();

            string[] mas = new string[0];

            SQL_Class sql = SQL_Class.Create_class(Properties.Settings.Default.Setting_Base_Path);
            SQL_Class.ReadValues("select Name from settings", ref sql);
            while (sql.SQL_DataReader.Read())
            {
                Array.Resize(ref mas, mas.Length + 1);
                mas[mas.Length - 1] = sql.SQL_DataReader.GetString(0);
            }
            Pr_Filter_CmBox.DataSource = mas;
            load_set_names();

        }




      

        private void Show_ALL_RBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_ALL_RBut.Checked)
            {
                dgv_full.Visible = true;
                dgv_short.Visible = false;
            }
            else
            {
                dgv_full.Visible = false;
                dgv_short.Visible = true;
            }
        }

        private void D_One_RBut_CheckedChanged(object sender, EventArgs e)
        {
            if (D_One_RBut.Checked)
            {
                Date_Filter2.Visible = false;
            }
            else
            {
                Date_Filter2.Visible = true;
            }
        }



       

        private void Main_Load_But_Click(object sender, EventArgs e)
        {          
           // prepare_select_part_prepare_dgv();
            Test_Load();
        }



        public DataTable get_Table(List<string> mas_eng,string str )
        {
            string[] or_like = new string[0];
            if (All_Search_chBox.Checked)
            {
                string[] sv = All_Search_TBox.Text.Split('|');
                or_like = new string[sv.Length];
                for (int i = 0; i < sv.Length; i++)
                {
                    string cur = "";
                    for (int j = 1; j < mas_eng.Count; j++)
                    {
                        if (!"Data_StartIngest_StartIngest_EndTime_Of_Registration".Contains(mas_eng[j]))
                        {
                            if (sv[i][0] == '@')
                            {
                                cur += "  or  " + mas_eng[j] + " like '" + sv[i].Replace("#", "").Replace("!", "") + "' ";
                            }
                            else
                            {
                                cur += "  or  " + mas_eng[j] + " like '%" + sv[i].Replace("#", "").Replace("!", "") + "%' ";
                            }
                            //cur += "  or  " + mas_eng[j] + " like "+ sv[i].Replace("#","").Replace("@","") + " ";
                           
                        }
                        
                    }

                    or_like[i] = " and ( false " + cur + " )";
                    if (sv[i][0] == '#')
                    {
                        or_like[i] = or_like[i].Replace(" and ("," and NOT (");
                    }

                    
                }
            }


            string agregate = str;

            string pre_zapros = "";


            if (agregate.Contains("PrID"))
            {
                pre_zapros = "SELECT MDA.ID,PrID,MDA.ID  " + agregate.Replace("PrID", "St.Name") + " FROM     MetaDataArchive as MDA   left join ingestassistantsettingsbase.settings as St  on St.ID=PrID  where( Deleted=0  ";
            }
            else
            {
                pre_zapros = "SELECT MDA.ID,PrID,MDA.ID  " + agregate + " FROM     MetaDataArchive as MDA   where (Deleted=0  ";
            }

            if (ViPlanner_ChBOX.Checked)
            {
                pre_zapros += "AND ViPlanner='" + Viplanner_TBox.Text + "'  ";
            }

            if (Reel_ID_ChBox.Checked)
            {
                pre_zapros += "AND Reel_ID='" + Reel_Id_TBox + "'  ";
            }


            if (Pr_Filter_ChBox.Checked)
            {
                pre_zapros += "AND PrID=" +
                              SQL_Class.ReadValueInt32(
                                  "select ID from settings where Name='" + Pr_Filter_CmBox.SelectedItem + "'",
                                  Properties.Settings.Default.Setting_Base_Path) + "  ";
            }

            if (D_Date_ChBox.Checked)
            {
                DateTime d1;
                DateTime d2;
                if (D_One_RBut.Checked)
                {
                    d1 = Date_Filter1.Value.Date;
                    d2 = d1.AddDays(1).Date;
                }
                else
                {
                    d1 = Date_Filter1.Value.Date;
                    d2 = Date_Filter2.Value.AddDays(1).Date;
                }
                pre_zapros += "AND (Time_Of_Registration between '" + d1.ToString("yyyy.MM.dd HH:mm:ss") + "' and  '" +
                              d2.ToString("yyyy.MM.dd HH:mm:ss") + "'  )";
            }

            if (All_Search_chBox.Checked)
            {
                string zapr = "";
                pre_zapros += "  ";
                for (int i = 0; i < or_like.Length; i++)
                {

                    zapr += pre_zapros + or_like[i] + ") union ";
                }
                if (or_like.Length != 0) zapr = zapr.Substring(0, zapr.Length - 7);
                else zapr = pre_zapros + " false)";

                pre_zapros = zapr;
            }
            else
            {
                pre_zapros += ")";
            }




            if (pre_zapros.Contains("UserID"))
            {
                pre_zapros = pre_zapros.Replace("UserID", "L.L_FullName");
                pre_zapros = pre_zapros.Replace("where",
                    "left join ingestassistantsettingsbase.login as L  on L.L_ID=UserID  where");
            }
            if (pre_zapros.Contains("RegisterID"))
            {
                pre_zapros = pre_zapros.Replace("RegisterID", "LL.L_FullName");
               // if (!pre_zapros.Contains("left join ingestassistantsettingsbase.login as L  on L_ID=UserId")) 
                { pre_zapros = pre_zapros.Replace("where",
                     "left join ingestassistantsettingsbase.login as LL  on LL.L_ID=RegisterID  where"); }
            }




            pre_zapros = pre_zapros.Replace(" ID", "MDA.ID");

            var sqlcon = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            int rows_count = 0;


            //vk
            MySqlDataAdapter mad = new MySqlDataAdapter(pre_zapros, sqlcon.SQL_Connection);
            //DataSet set = new DataSet();
            DataTable tb = new DataTable();
            mad.Fill(tb);
            return tb;
        }

        public void Test_Load()
        {


             string zapros = "select Count(*) from settings";
            int test = SQL_Class.ReadValueInt32(zapros, Settings.Default.Setting_Base_Path);
            
           List<Color> color_list=new List<Color>(test);
            for (int i = 0; i < test; i++)
            {
                zapros = "select Name from settings where ID=" + i;
                string prof_name = SQL_Class.ReadValueString(zapros, Settings.Default.Setting_Base_Path);
                if (prof_name.Contains("Ingest")) color_list.Add(ING_Color_But.BackColor);
                else
                {
                    if (prof_name.Contains("ASM"))
                    {
                        if (prof_name.Contains("1")) color_list.Add(ASM1_Color_But.BackColor);
                        else
                        {
                            if (prof_name.Contains("2")) color_list.Add(ASM2_Color_But.BackColor); else { color_list.Add(Color.White); }
                        }
                    }
                    else { color_list.Add(Color.White); }
                    
                }
            }
            string str = "";
            List<string> mas_eng = new List<string>();
            List<string> mas_rus = new List<string>();
            //mas.Enqueue("ID");
            mas_eng.Add("ID") ;
            mas_rus.Add("ID");

            for (int i = 0; i < search_list.Count; i++)
            {
                if (search_list[i].marked)
                {
                    mas_eng.Add(search_list[i].name);
                    mas_rus.Add(search_list[i].rusname);
                    str += "," + search_list[i].name;

                }

            }



           
            
            dgv.DataSource = get_Table(mas_eng,str);
            FoundLab.Text = "Найдено " + (dgv.RowCount - 1) + " записей";

            for (int i = 0; i < mas_rus.Count; i++)
            {
                //tb.Columns[i].ColumnName = mas_rus[i];
                dgv.Columns[i+2].HeaderText = mas_rus[i];
            }
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;

            for (int i = 0; i < dgv.RowCount; i++)
            {
                Color col = Color.White;
                int col_code = Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                col = color_list[col_code];
          
              
                    
                    color_row(i,col);
                
            }
            
            Refresh();
          
        }


        public struct Big_Element
        {
            public string Audio;
            public string Card_Marks;
            public string Data_Start;
            public string Deleted;
            public string Dolby;
            public string Edit_Line;
            public string Efir_Date_From_Request;
            public string Format_IN;
            public string Format_OUT;
            public string Harris_IN;
            public string Harris_OUT;
            public long ID;
            public string Info_Lost;
            public string Ingest_Duration;
            public string Ingest_End;
            public string Ingest_Line;
            public string Ingest_Operator;
            public string Ingest_Start;
            public string Media_Type;
            public string Notes;
            public string Operator;
            public string Reel_ID;
            public string Render_Time;
            public string Source_Duration;
            public string Time_Of_Registration;
            public string Title;
            public string Total_Time;
            public string Type_Of_Work;
            public string ViPlanner;
            public string Media_Info;
            public int PrID;
        }








        private void Export_To_Excell_But_Click(object sender, EventArgs e)
        {

            string filters = "";


            if (ViPlanner_ChBOX.Checked)
            {
                filters += "ID_ViPlanner=" + Viplanner_TBox.Text + "  |  ";
            }

            if (D_Date_ChBox.Checked)
            {
                if (D_Duraation_RBut.Checked)
                {
                    filters += "Промежуток времени между " + Date_Filter1.Value.ToString("G") + " и " +
                               Date_Filter2.Value.ToString("G") + "  |  ";
                }
                else
                {
                    filters += "За один день " + Date_Filter1.Value.ToString("G") + "  |  ";
                }
                filters += "ID_ViPlanner=" + Viplanner_TBox.Text + "  |  ";
            }



            if (Reel_ID_ChBox.Checked)
            {
                filters += "Reel_ID=" + Reel_Id_TBox.Text + "  |  ";
            }

            if (All_Search_chBox.Checked)
            {
                filters += "Сквозной поиск по значениям:" + All_Search_TBox.Text.Replace("|", " , ") + "  |  ";
            }







            string old_file = Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\ExportXLS.xls";
            string new_file = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory + "\\Export_File__" +
                              DateTime.Now.ToString("HH-MM-SS   dd-mm-yyyy") + " .xls";
            if (!Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory))
            {
                DirectoryM.CreateDirectory(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory);
            }

            FileM.Copy(old_file, new_file);




            Application xlApp = null;
            Workbook xlWorkBook = null;
            Worksheet xlWorkSheet = null;
            var old_excels = Process.GetProcessesByName("EXCEL");
            var old_excels_id = new Queue<string>();
            foreach (var Pr in old_excels)
            {
                old_excels_id.Enqueue(Pr.Id.ToString());
            }
            try
            {
                xlApp = new Application();

                xlApp.Workbooks.Open(new_file);
                xlWorkBook = xlApp.ActiveWorkbook;

                xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
            }
            catch (Exception ex)
            {

            }

            var m_workSheet = xlWorkSheet;

            xlWorkSheet.Cells[2, 2] = filters;
           

            int bas = 5;
            int k = 1;
           
                   
               

             string str = "";
            List<string> mas_eng = new List<string>();
            List<string> mas_rus = new List<string>();
            //mas.Enqueue("ID");
            mas_eng.Add("ID") ;
            mas_rus.Add("ID");

            for (int i = 0; i < search_list.Count; i++)
            {
                if (search_list[i].marked)
                {
                    mas_eng.Add(search_list[i].name);
                    mas_rus.Add(search_list[i].rusname);
                    str += "," + search_list[i].name;
                    m_workSheet.Cells[bas - 1, k] = search_list[i].rusname;
                    k++;
                }

            }

            DataTable tbl = get_Table(mas_eng, str);

            Export_prbar.Maximum = tbl.Rows.Count + 1;
            Export_prbar.Value = 0;
            Refresh();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                for (int q = 0; q < k; q++)
                {
                    m_workSheet.Cells[i + bas, q+1] = tbl.Rows[i][q+2].ToString();
                }
                draw_line(i + bas, m_workSheet, k);
                if (i%10 == 0)
                {
                    Export_prbar.Value = i;
                    Refresh();
                }
            }


            Export_prbar.Value = Export_prbar.Maximum;
            Refresh();





                    
                
                
            
            draw_line(bas - 1, m_workSheet, k);
        xlWorkBook.Save();
            xlWorkBook.Close(true);
            xlApp.Quit();
            var new_excels = Process.GetProcessesByName("EXCEL");
            foreach (var Pr in new_excels)
            {
                if (!old_excels_id.Contains(Pr.Id.ToString()))
                    Pr.Kill();
            }



            Process.Start(new_file);




        }



        public string get_excel_code(int i)
        {
            string[] mas =
            {
                "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
                "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK",
                "AL", "AM", "AN", "AO", "AP", "AQ"
            };
            return mas[i];
        }

        public void draw_line(int id, Worksheet Sheet,int len)
        {
            Sheet.get_Range("A" + id, get_excel_code(len) + id).Borders.ColorIndex = 0;
            Sheet.get_Range("A" + id, get_excel_code(len) + id).Borders.LineStyle = XlLineStyle.xlContinuous;
            Sheet.get_Range("A" + id, get_excel_code(len) + id).Borders.Weight = XlBorderWeight.xlThin;
        }


        private string last_clicked;
        private int row;
        private int column;





        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("open" + "row=" + row + "   col=" + column);
            int id = Convert.ToInt32(dgv.Rows[row].Cells[0].Value);
            string viplanner = SQL_Class.ReadValueString("select ViPlanner from metadataarchive where id=" + id,
                Settings.Default.MetaBase_Way);
            string path = Settings.Default.Work_Path + "\\" + viplanner;
            if (Directory.Exists(path)) Process.Start(path);
            else MessageBox.Show("no such a directory :" + path);
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Drawing.Point pCell = dgv.GetCellDisplayRectangle(column, row, true).Location;
            System.Drawing.Point pGrid = dgv.Location;
            ContextMenuStrip.Location = new System.Drawing.Point(pCell.X + pGrid.X,
                pCell.Y + pGrid.Y + dgv.CurrentRow.Height);
        }

        private void select_unselect_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < search_dgv.RowCount; i++)
            {
                if (select_unselect_all.Checked)
                {
                    search_dgv.Rows[i].Cells[1].Value = true;
                }
                else
                {
                    search_dgv.Rows[i].Cells[1].Value = false;
                }
            }
            check_marked_variants();
        }



        private void search_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //check_marked_variants();
        }

        private void Save_Search_Set_But_Click(object sender, EventArgs e)
        {
            save_marked_variants();
        }

        private void Load_Search_Set_But_Click(object sender, EventArgs e)
        {
            load_variants_from_setting();
          //  R_Help_But.Size=new Size(25,25);
           // Export_To_Excell_But_Click(null,null);
        }

        private void search_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            check_marked_variants();
        }

        private void search_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            column = e.ColumnIndex;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("open" + "row=" + row + "   col=" + column);
            int id = Convert.ToInt32(dgv.Rows[row].Cells[0].Value);
            string viplanner = SQL_Class.ReadValueString("select ViPlanner from metadataarchive where id=" + id,
                Settings.Default.MetaBase_Way);
            string path = Settings.Default.Archive_Path + "\\" + viplanner;
            if (Directory.Exists(path)) Process.Start(path);
            else MessageBox.Show("no such a directory :" + path);
        }



        public class Search_Element
        {
            public string name;
            public string rusname;
            public Boolean marked;
            public string type;
            

            public Search_Element(string name,string type)
            {
                this.type = type;
                this.name = name;
                marked = true;
                object reader = null;
                this.rusname = name;
                reader = SQL_Class.ReadValue(
                    "Select MD_Rus_Name from " + Properties.Settings.Default.MetaData + " where MD_Name='" + name + "'",
                    Properties.Settings.Default.MetaBase_Way);
                if (reader != null)
                {
                    try
                    {
                        this.rusname = reader.ToString();
                    }
                    catch (Exception)
                    {


                    }
                }



                reader = SQL_Class.ReadValue(
                    "Select MDD_RusName from " + Properties.Settings.Default.MetaDate + " where MDD_Name='" + name + "'",
                    Properties.Settings.Default.MetaBase_Way);
                if (reader != null)
                {
                    try
                    {
                        this.rusname = reader.ToString();
                    }
                    catch (Exception)
                    {


                    }
                }


                if (name == "Work_Status") rusname = "Статус работы";
                if (name == "PrID") rusname = "Код профиля настроек";
                if (name == "UserID") rusname = "Имя пользователя/группы пользователей";
                if (name == "RegisterID") rusname = "Имя зарегистрировавшего работу";
                if (name == "Deleted") rusname = "Метка удаления";

            }
        }

        private void отобразитьMediaInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Media_Info_Show.Form_Lauch(Convert.ToInt32(dgv.Rows[row].Cells[0].Value));
        }

        private void отправитьНаРедактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (column > 2)
            {
                List<Search_Element> mas = new List<Search_Element>();
                for (int i = 0; i < search_list.Count; i++)
                {
                    if (search_list[i].marked) mas.Add(search_list[i]);
                }
                string vp =
                    SQL_Class.ReadValueString(
                        "Select ViPlanner from metadataarchive where ID=" + dgv.Rows[row].Cells[0].Value,
                        Settings.Default.MetaBase_Way);
                Correction_Form.Correction_Lauch(Convert.ToInt64(dgv.Rows[row].Cells[0].Value), vp, mas[column - 3].name,
                    mas[column - 3].rusname, mas[column - 3].type, dgv.Rows[row].Cells[column].Value.ToString());
            }
        }

        private void R_Help_But_Click(object sender, EventArgs e)
        {
            if (R_Help_But.Size.Width == 25)
            {
                for (int i = 0; i < 400; i++)
                {
                    if (R_Help_But.Size.Height == 100)
                    {
                        R_Help_But.Size = new Size(R_Help_But.Size.Width + 1, R_Help_But.Size.Height);
                    }
                    else
                    {
                        R_Help_But.Size = new Size(R_Help_But.Size.Width + 1, R_Help_But.Size.Height + 1);
                    }
                   
                    R_Help_But.Refresh();
                }
                R_Help_But.Text =
                    "Для разделения слов при поиске используется символ '|' \n Для поиска по условию 'все кроме' перед словом ставим '#' \n Для поиска по условию 'строгое вхождение' перед словом ставим '@'";
            }
            else
            {
                for (int i = 0; i < 400; i++)
                {
                    if (R_Help_But.Size.Height == 25)
                    {
                        R_Help_But.Size = new Size(R_Help_But.Size.Width - 1, R_Help_But.Size.Height);
                    }
                    else
                    {
                        R_Help_But.Size = new Size(R_Help_But.Size.Width - 1, R_Help_But.Size.Height - 1);
                    }
                    R_Help_But.Refresh();
                }
                R_Help_But.Text ="?";
            }
        }

        private void ING_Color_But_Click(object sender, EventArgs e)
        {

        }

        private void загрузитьВРабочуюФормуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Browser.thisform == null)
            {
                MessageBox.Show("Сейчас будут запущенны рабочие формы");
                Browser.Browser_Primary_Start(Cur_Main);
                Thread.Sleep(3000);

            }
            
            {
               
                string vp =
                    SQL_Class.ReadValueString(
                        "Select ViPlanner from metadataarchive where ID=" + dgv.Rows[row].Cells[0].Value,
                        Settings.Default.MetaBase_Way);
                Browser.Browser_dautcher_File_Work_Form.Reload_With_Input(vp);

                this.WindowState = FormWindowState.Minimized;

                Cur_Main.WindowState = FormWindowState.Maximized;
            }
        }

        private void Date_Filter1_ValueChanged(object sender, EventArgs e)
        {
            if (Date_Filter1.Value > Date_Filter2.Value)
            {
                Date_Filter2.Value = Date_Filter1.Value;
            }
        }

        private void Date_Filter2_ValueChanged(object sender, EventArgs e)
        {
            if (Date_Filter1.Value > Date_Filter2.Value)
            {
                Date_Filter1.Value = Date_Filter2.Value;
            }
        }

        private void Show_Set_CmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Settings.Default.Base_Show_Setting_Set;


            string[] tek = str.Split('#')[Show_Set_CmBox.SelectedIndex].Split('|');
            string[]mas=new string[tek.Length-1];


            for (int i = 0; i < tek.Length-1; i++)
            {
                mas[i] = tek[i + 1];
            }




            for (int i = 0; i < search_list.Count; i++)
            {
                if (mas.Contains(i.ToString()))
                {
                    search_dgv.Rows[i].Cells[1].Value = true;
                    search_list[i].marked = true;
                }
                else
                {
                    search_dgv.Rows[i].Cells[1].Value = false;
                    search_list[i].marked = false;
                }
            }
            Cur_Show_Set_TBox.Text = tek[0];
        }


        public void save_marked_variants()
        {
            string str1 = Settings.Default.Base_Show_Setting_Set;


            string[] tek = str1.Split('#');
            string save = "";
            for (int i = 0; i < Show_Set_CmBox.SelectedIndex; i++)
            {
                save += tek[i] + "#";
            }

            string str = "";
            if (Cur_Show_Set_TBox.Text == "")
            {
                Cur_Show_Set_TBox.Text = " ";
            }
            str += Cur_Show_Set_TBox.Text + "|";
            for (int i = 0; i < search_list.Count; i++)
            {

                if (Convert.ToBoolean(search_dgv.Rows[i].Cells[1].Value))
                {
                    str += i + "|";
                }

            }
            save += str + "#";
            for (int i = Show_Set_CmBox.SelectedIndex+1; i < tek.Length-1; i++)
            {
                save += tek[i] + "#";
            }

            Properties.Settings.Default.Base_Show_Setting_Set = save;
            Properties.Settings.Default.Save();
            load_set_names();
        }

        public void load_variants_from_setting()
        {
            string str = Properties.Settings.Default.Base_Show_Setting;
            string[] mas = str.Split('|');
            for (int i = 0; i < search_list.Count; i++)
            {
                if (mas.Contains(i.ToString()))
                {
                    search_dgv.Rows[i].Cells[1].Value = true;
                    search_list[i].marked = true;
                }
                else
                {
                    search_dgv.Rows[i].Cells[1].Value = false;
                    search_list[i].marked = false;
                }
            }
        }



        public void load_set_names()
        {
            string str = Settings.Default.Base_Show_Setting_Set;

            string[] mas = str.Split('#');
            string[] names = new string[10];
            for (int i = 0; i < 10; i++)
            {
                names[i] = mas[i].Split('|')[0];
            }
            Show_Set_CmBox.DataSource = names;
        }






    }
}





//private void Make_Pre_Choise()
//{
//    var queue = new Queue<string>();
//    var files = new string[Base_Big_Data.Length];
//    AutoCompleteStringCollection src;


//    for (var i = 0; i < files.Length; i++)
//    {
//        files[i] = Base_Big_Data[i].ViPlanner;
//    }
//    src = new AutoCompleteStringCollection();
//    src.AddRange(files);
//    Viplanner_TBox.AutoCompleteCustomSource = src;


//    for (var i = 0; i < files.Length; i++)
//    {
//        files[i] = Base_Big_Data[i].Reel_ID;
//    }
//    src = new AutoCompleteStringCollection();
//    src.AddRange(files);
//    Reel_Id_TBox.AutoCompleteCustomSource = src;
//}


//public struct MyStruct
//{
//    public string name;
//    public string rusname;
//    public Boolean marked;

//    // public Search_Element(string name)
//    // {
//    //     this.name = name;
//    //     marked = true;
//    //     object reader = null;
//    //     reader = SQL_Class.ReadValue(
//    //         "Select MD_Rus_Name from " + Properties.Settings.Default.MetaData + " where MD_Name=" + name,
//    //         Properties.Settings.Default.MetaData);
//    //     if (reader!=null)
//    //     {
//    //         try
//    //         {
//    //             this.rusname = reader.ToString();
//    //         }
//    //         catch (Exception)
//    //         {


//    //         }
//    //     }



//    //     reader = SQL_Class.ReadValue(
//    //         "Select MDD_RusName from " + Properties.Settings.Default.MetaData + " where MDD_Name=" + name,
//    //         Properties.Settings.Default.MetaData);
//    //     if (reader != null)
//    //     {
//    //         try
//    //         {
//    //             this.rusname = reader.ToString();
//    //         }
//    //         catch (Exception)
//    //         {


//    //         }
//    //     }


//    //}

//}


//private void Export_To_Excell_But_Click(object sender, EventArgs e)
//{
//    Export();
//}

//private void Count_El_trBar_ValueChanged(object sender, EventArgs e)
//{
//    track_label.Text = Count_El_trBar.Value.ToString();
//    if (Count_El_trBar.Value > Curent_Elements.Length) Count_El_trBar.Value = Curent_Elements.Length;

//}

//private void Start_El_TBox_TextChanged(object sender, EventArgs e)
//{


//    int start = 0;
//    int stop = 0;
//    int count = 0;
//    try
//    {
//        start = Convert.ToInt32(Start_El_TBox.Text);
//        stop = Convert.ToInt32(Stop_El_TBox.Text);
//        count = Curent_Elements.Length;
//    }
//    catch (Exception)
//    {

//    }

//    if (start > count) Start_El_TBox.Text = "0";
//    Special_Count_label.Text = (stop - start).ToString();
//}

//private void Stop_El_TBox_TextChanged(object sender, EventArgs e)
//{
//    int start = 0;
//    int stop = 0;
//    int count = 0;
//    try
//    {
//        start = Convert.ToInt32(Start_El_TBox.Text);
//        stop = Convert.ToInt32(Stop_El_TBox.Text);
//        count = Curent_Elements.Length;
//    }
//    catch (Exception)
//    {

//    }



//    if (stop > count) Stop_El_TBox.Text = count.ToString();
//    Special_Count_label.Text = (stop - start).ToString();
//}


//private void Show_Last_RBut_CheckedChanged(object sender, EventArgs e)
//{
//    if (Show_Last_RBut.Checked)
//    {
//        Show_Last_grBox.Enabled = true;
//        Show_Special_grBox.Enabled = false;
//    }
//    else
//    {
//        Show_Last_grBox.Enabled = false;
//        Show_Special_grBox.Enabled = true;
//    }
//}

//private void Draw_Special_But_Click(object sender, EventArgs e)
//{
//    DGV_Fill();
//}

//private void Special_Count_label_TextChanged(object sender, EventArgs e)
//{
//    int start = 0;
//    int stop = 0;
//    int count = 0;
//    try
//    {
//        start = Convert.ToInt32(Start_El_TBox.Text);
//        stop = Convert.ToInt32(Stop_El_TBox.Text);

//    }
//    catch (Exception)
//    {

//    }


//    Special_Count_label.Text = (stop - start).ToString();
//}

//private void Set_new_Max_But_Click(object sender, EventArgs e)
//{
//    Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV = Convert.ToInt32(Set_max_Tbox.Text);
//    Ingest_Assistant.Properties.Settings.Default.Save();
//}


//public void prepare_show_grBox()
//{
//    Count_El_trBar.Maximum = Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
//    All_Count_TBox.Text = Curent_Elements.Length.ToString();
//    if (Curent_Elements.Length > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
//    {
//        Count_El_trBar.Value = Count_El_trBar.Maximum;
//    }
//    else
//    {
//        Count_El_trBar.Value = Curent_Elements.Length;
//    }

//    Start_El_TBox.Text = "0";
//    Stop_El_TBox.Text = "0";

//}







//private void Apply_Filter_But_Click(object sender, EventArgs e)
//{
//    //Make_Curent_Element_Base();
//    DGV_Fill();
//}

//private void dgv_short_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//{
//    dgv_cell_double_click(dgv_short, e);
//    //Ingest_Assistant.Media_Info_Show.Form_Lauch(Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value));
//}


//private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//{
//    dgv_cell_double_click(dgv_full, e);
//    //Ingest_Assistant.Media_Info_Show.Form_Lauch(Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value));
//}

//public void dgv_cell_double_click(DataGridView cdgv, DataGridViewCellEventArgs e)
//{
//    if (MI_RBut.Checked)
//        Ingest_Assistant.Media_Info_Show.Form_Lauch(Convert.ToInt32(cdgv.Rows[e.RowIndex].Cells[0].Value));
//    if (Correction_RBut.Checked)
//        Base_Show_Pro.Correct_One_Element(cdgv.Rows[e.RowIndex].Cells[0].Value.ToString());
//}

//var bt = new Big_Element();
//bt.ID = sqlcon.SQL_DataReader.GetInt64(0);
//bt.ViPlanner = sqlcon.SQL_DataReader.GetString(1);
//bt.Title = sqlcon.SQL_DataReader.GetString(2);

//if (!sqlcon.SQL_DataReader.IsDBNull(3))
//    bt.Data_Start = sqlcon.SQL_DataReader.GetDateTime(3).ToString("HH:mm:ss yyyy.MM.dd");
//if (!sqlcon.SQL_DataReader.IsDBNull(4))
//    bt.Ingest_Start = sqlcon.SQL_DataReader.GetDateTime(4).ToString("HH:mm:ss yyyy.MM.dd");
//if (!sqlcon.SQL_DataReader.IsDBNull(5))
//    bt.Ingest_End = sqlcon.SQL_DataReader.GetDateTime(5).ToString("HH:mm:ss yyyy.MM.dd");

//if (!sqlcon.SQL_DataReader.IsDBNull(6)) bt.Ingest_Duration = sqlcon.SQL_DataReader.GetString(6);
//if (!sqlcon.SQL_DataReader.IsDBNull(7)) bt.Render_Time = sqlcon.SQL_DataReader.GetString(7);

//if (!sqlcon.SQL_DataReader.IsDBNull(8))
//    bt.Time_Of_Registration = sqlcon.SQL_DataReader.GetDateTime(8).ToString("HH:mm:ss yyyy.MM.dd");



//if (!sqlcon.SQL_DataReader.IsDBNull(9)) bt.Total_Time = sqlcon.SQL_DataReader.GetString(9);
//bt.Source_Duration = sqlcon.SQL_DataReader.GetString(10);
//bt.Media_Type = sqlcon.SQL_DataReader.GetString(11);
//bt.Reel_ID = sqlcon.SQL_DataReader.GetString(12);
//bt.Efir_Date_From_Request = sqlcon.SQL_DataReader.GetString(13);
//bt.Ingest_Line = sqlcon.SQL_DataReader.GetString(14);
//bt.Ingest_Operator = sqlcon.SQL_DataReader.GetString(15);
//bt.Format_IN = sqlcon.SQL_DataReader.GetString(16);
//bt.Harris_IN = sqlcon.SQL_DataReader.GetString(17);
//bt.Audio = sqlcon.SQL_DataReader.GetString(18);
//bt.Dolby = sqlcon.SQL_DataReader.GetString(19);
//bt.Edit_Line = sqlcon.SQL_DataReader.GetString(20);
//bt.Operator = sqlcon.SQL_DataReader.GetString(21);
//bt.Type_Of_Work = sqlcon.SQL_DataReader.GetString(22);
//bt.Harris_OUT = sqlcon.SQL_DataReader.GetString(23);
//bt.Format_OUT = sqlcon.SQL_DataReader.GetString(24);
//bt.Card_Marks = sqlcon.SQL_DataReader.GetString(25);
//bt.Info_Lost = sqlcon.SQL_DataReader.GetString(26);
//bt.Notes = sqlcon.SQL_DataReader.GetString(27);
//bt.Deleted = sqlcon.SQL_DataReader.GetInt32(28).ToString();
//bt.Media_Info = sqlcon.SQL_DataReader.GetString(29).Replace("\n", " ; ");
//bt.PrID = sqlcon.SQL_DataReader.GetInt32(30);
//Array.Resize(ref Base_Big_Data, Base_Big_Data.Length + 1);
//Base_Big_Data[Base_Big_Data.Length - 1] = bt;


//public void Apply_Through_Filter()
//{
//    Base_Big_Data = Base_Big_Data1;
//    if (!All_Search_chBox.Checked)
//    {
//        Curent_Elements = Base_Big_Data;
//    }
//    else
//    {
//        string[] search_variants = All_Search_TBox.Text.Split('|');

//        Big_Element[] nf = new Big_Element[0];


//        All_Search_prBar.Maximum = Base_Big_Data.Length + 1;
//        All_Search_prBar.Value = 0;
//        foreach (var cur in Base_Big_Data)
//        {
//            All_Search_prBar.Value++;
//            if ((contain(cur.Audio, search_variants)) || (contain(cur.Card_Marks, search_variants)) ||
//                (contain(cur.Data_Start, search_variants)) || (contain(cur.Deleted, search_variants)) ||
//                (contain(cur.Dolby, search_variants)) || (contain(cur.Edit_Line, search_variants)) ||
//                (contain(cur.Efir_Date_From_Request, search_variants)) ||
//                (contain(cur.Format_IN, search_variants)) || (contain(cur.Format_OUT, search_variants)) ||
//                (contain(cur.Harris_IN, search_variants)) || (contain(cur.Harris_OUT, search_variants)) ||
//                (contain(cur.Info_Lost, search_variants)) || (contain(cur.Ingest_Duration, search_variants)) ||
//                (contain(cur.Ingest_End, search_variants)) || (contain(cur.Ingest_Line, search_variants)) ||
//                (contain(cur.Ingest_Operator, search_variants)) ||
//                (contain(cur.Ingest_Start, search_variants)) || (contain(cur.Media_Info, search_variants)) ||
//                (contain(cur.Media_Type, search_variants)) || (contain(cur.Notes, search_variants)) ||
//                (contain(cur.Operator, search_variants)) || (contain(cur.Reel_ID, search_variants)) ||
//                (contain(cur.Render_Time, search_variants)) ||
//                (contain(cur.Source_Duration, search_variants)) ||
//                (contain(cur.Time_Of_Registration, search_variants)) ||
//                (contain(cur.Title, search_variants)) || (contain(cur.Total_Time, search_variants)) ||
//                (contain(cur.Type_Of_Work, search_variants)) || (contain(cur.ViPlanner, search_variants)) ||
//                (contain(cur.ID.ToString(), search_variants)))
//            {
//                Array.Resize(ref nf, nf.Length + 1);
//                nf[nf.Length - 1] = (cur);
//            }
//            if (All_Search_prBar.Value%5 == 0) Refresh();
//        }
//        All_Search_prBar.Value = All_Search_prBar.Maximum;
//        Curent_Elements = nf;

//    }
//}

//public void Prepare_counting()
//{
//    All_Count_TBox.Text = Curent_Elements.Length.ToString();
//    Count_El_trBar.Maximum = Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV;
//    if (Curent_Elements.Length > Count_El_trBar.Maximum)
//    {
//        Count_El_trBar.Value = Count_El_trBar.Maximum;

//    }
//    else
//    {
//        Count_El_trBar.Value = Curent_Elements.Length;
//    }
//}




//public void Make_Curent_Element_Base()
//{
//    var filtering = new Queue<Big_Element>();
//    var nf = new Queue<Big_Element>();
//    for (var i = 0; i < Base_Big_Data.Length; i++)
//    {
//        filtering.Enqueue(Base_Big_Data[i]);
//    }


//    nf = new Queue<Big_Element>();
//    if (ViPlanner_ChBOX.Checked)
//    {
//        foreach (var cur in filtering)
//        {
//            if (cur.ViPlanner == Viplanner_TBox.Text) nf.Enqueue(cur);
//        }
//        filtering = nf;
//    }


//    if (D_Date_ChBox.Checked)
//    {
//        DateTime start;
//        DateTime end;

//        if (D_One_RBut.Checked)
//        {
//            start = Date_Filter1.Value.Date;
//            end = start.AddDays(1).Date;
//        }
//        else
//        {
//            start = Date_Filter1.Value.Date;
//            end = Date_Filter2.Value.Date.AddDays(1).Date;
//        }


//        nf = new Queue<Big_Element>();
//        foreach (var cur in filtering)
//        {
//            if (start < Convert.ToDateTime(cur.Time_Of_Registration) &&
//                Convert.ToDateTime(cur.Time_Of_Registration) < end) nf.Enqueue(cur);
//        }
//        filtering = nf;
//    }


//    nf = new Queue<Big_Element>();
//    if (Reel_ID_ChBox.Checked)
//    {
//        foreach (var cur in filtering)
//        {
//            if (cur.Reel_ID == Reel_Id_TBox.Text) nf.Enqueue(cur);
//        }
//        filtering = nf;
//    }





//    string[] search_variants = All_Search_TBox.Text.Split('|');

//    nf = new Queue<Big_Element>();
//    if (All_Search_chBox.Checked)
//    {

//        All_Search_prBar.Maximum = filtering.Count + 1;
//        All_Search_prBar.Value = 0;
//        foreach (var cur in filtering)
//        {
//            All_Search_prBar.Value++;
//            if ((contain(cur.Audio, search_variants)) || (contain(cur.Card_Marks, search_variants)) ||
//                (contain(cur.Data_Start, search_variants)) || (contain(cur.Deleted, search_variants)) ||
//                (contain(cur.Dolby, search_variants)) || (contain(cur.Edit_Line, search_variants)) ||
//                (contain(cur.Efir_Date_From_Request, search_variants)) ||
//                (contain(cur.Format_IN, search_variants)) || (contain(cur.Format_OUT, search_variants)) ||
//                (contain(cur.Harris_IN, search_variants)) || (contain(cur.Harris_OUT, search_variants)) ||
//                (contain(cur.Info_Lost, search_variants)) || (contain(cur.Ingest_Duration, search_variants)) ||
//                (contain(cur.Ingest_End, search_variants)) || (contain(cur.Ingest_Line, search_variants)) ||
//                (contain(cur.Ingest_Operator, search_variants)) || (contain(cur.Ingest_Start, search_variants)) ||
//                (contain(cur.Media_Info, search_variants)) || (contain(cur.Media_Type, search_variants)) ||
//                (contain(cur.Notes, search_variants)) || (contain(cur.Operator, search_variants)) ||
//                (contain(cur.Reel_ID, search_variants)) || (contain(cur.Render_Time, search_variants)) ||
//                (contain(cur.Source_Duration, search_variants)) ||
//                (contain(cur.Time_Of_Registration, search_variants)) || (contain(cur.Title, search_variants)) ||
//                (contain(cur.Total_Time, search_variants)) || (contain(cur.Type_Of_Work, search_variants)) ||
//                (contain(cur.ViPlanner, search_variants)) || (contain(cur.ID.ToString(), search_variants)))
//            {
//                nf.Enqueue(cur);
//            }
//            Refresh();
//        }
//        All_Search_prBar.Value = All_Search_prBar.Maximum;
//        filtering = nf;
//    }


//    Curent_Elements = new Big_Element[filtering.Count];
//    for (var i = 0; i < Curent_Elements.Length; i++)
//    {
//        Curent_Elements[i] = filtering.Dequeue();
//    }


//    prepare_show_grBox();
//}



//public void DGV_Fill()
//{
//    int start = 0;
//    int stop = 0;
//    if (Curent_Elements.Length > Ingest_Assistant.Properties.Settings.Default.Max_Elements_For_DGV)
//    {
//        Log_Col_Ask.Ask_Diapason(Curent_Elements.Length, ref start, ref stop);
//    }
//    else
//    {
//        stop = 0 + Curent_Elements.Length;
//        start = 0; //stop - Count_El_trBar.Value;
//    }

//    dgv_full.RowCount = stop - start + 1;
//    dgv_short.RowCount = stop - start + 1;
//    int j = 0;
//    for (var i = start; i < stop; i++)
//    {
//        var bt = Curent_Elements[i];
//        dgv_full.Rows[j].Cells[0].Value = bt.ID;
//        dgv_full.Rows[j].Cells[1].Value = bt.ViPlanner;
//        dgv_full.Rows[j].Cells[2].Value = bt.Title;
//        dgv_full.Rows[j].Cells[3].Value = bt.Data_Start;
//        dgv_full.Rows[j].Cells[4].Value = bt.Ingest_Start;
//        dgv_full.Rows[j].Cells[5].Value = bt.Ingest_End;
//        dgv_full.Rows[j].Cells[6].Value = bt.Ingest_Duration;
//        dgv_full.Rows[j].Cells[7].Value = bt.Render_Time;
//        dgv_full.Rows[j].Cells[8].Value = bt.Time_Of_Registration;
//        dgv_full.Rows[j].Cells[9].Value = bt.Total_Time;
//        dgv_full.Rows[j].Cells[10].Value = bt.Source_Duration;
//        dgv_full.Rows[j].Cells[11].Value = bt.Media_Type;
//        dgv_full.Rows[j].Cells[12].Value = bt.Reel_ID;
//        dgv_full.Rows[j].Cells[13].Value = bt.Efir_Date_From_Request;
//        dgv_full.Rows[j].Cells[14].Value = bt.Ingest_Line;
//        dgv_full.Rows[j].Cells[15].Value = bt.Ingest_Operator;
//        dgv_full.Rows[j].Cells[16].Value = bt.Format_IN;
//        dgv_full.Rows[j].Cells[17].Value = bt.Harris_IN;
//        dgv_full.Rows[j].Cells[18].Value = bt.Audio;
//        dgv_full.Rows[j].Cells[19].Value = bt.Dolby;
//        dgv_full.Rows[j].Cells[20].Value = bt.Edit_Line;
//        dgv_full.Rows[j].Cells[21].Value = bt.Operator;
//        dgv_full.Rows[j].Cells[22].Value = bt.Type_Of_Work;
//        dgv_full.Rows[j].Cells[23].Value = bt.Harris_OUT;
//        dgv_full.Rows[j].Cells[24].Value = bt.Format_OUT;
//        dgv_full.Rows[j].Cells[25].Value = bt.Card_Marks;
//        dgv_full.Rows[j].Cells[26].Value = bt.Info_Lost;
//        dgv_full.Rows[j].Cells[27].Value = bt.Notes;
//        dgv_full.Rows[j].Cells[28].Value = bt.Deleted;


//        dgv_short.Rows[j].Cells[0].Value = bt.ID;
//        dgv_short.Rows[j].Cells[1].Value = bt.ViPlanner;
//        dgv_short.Rows[j].Cells[2].Value = bt.Title;
//        dgv_short.Rows[j].Cells[3].Value = bt.Data_Start;

//        dgv_short.Rows[j].Cells[4].Value = bt.Time_Of_Registration;
//        dgv_short.Rows[j].Cells[5].Value = bt.Total_Time;

//        dgv_short.Rows[j].Cells[6].Value = bt.Media_Type;
//        dgv_short.Rows[j].Cells[7].Value = bt.Reel_ID;

//        dgv_short.Rows[j].Cells[8].Value = bt.Type_Of_Work;
//        dgv_short.Rows[j].Cells[9].Value = bt.Media_Info;

//        if (bt.PrID == 1)
//        {
//            color_row(j, ING_Color_But.BackColor);
//        }
//        if (bt.PrID == 2)
//        {
//            color_row(j, ASM1_Color_But.BackColor);
//        }
//        if (bt.PrID == 3)
//        {
//            color_row(j, ASM2_Color_But.BackColor);
//        }


//        if (j < 30) Refresh();
//        j++;
//    }
//}


//public void color_row(int i, Color cl)
//{
//    for (int k = 0; k < 29; k++)
//    {
//        dgv_full.Rows[i].Cells[k].Style.BackColor = cl;
//    }
//    for (int k = 0; k < 10; k++)
//    {
//        dgv_full.Rows[i].Cells[k].Style.BackColor = cl;
//    }
//}


//public void prepare_variats2()
//{
//    search_list = new List<Search_Element>();

//    string zapros =
//        "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'metadataarchive' and table_schema = 'ingestassistantmainbase'";
//    SQL_Class sqlcl = SQL_Class.Create_class(Properties.Settings.Default.MetaBase_Way);
//    SQL_Class.ReadValues(zapros, ref sqlcl);
//    while (sqlcl.SQL_DataReader.Read())
//    {
//        if (sqlcl.SQL_DataReader.GetString(0) != "ID" && sqlcl.SQL_DataReader.GetString(0) != "Deleted") search_list.Add(new Search_Element(sqlcl.SQL_DataReader.GetString(0)));
//    }


//    search_dgv.RowCount = search_list.Count;
//    for (int i = 0; i < search_list.Count; i++)
//    {
//        search_dgv.Rows[i].Cells[0].Value = search_list[i].rusname;
//        search_dgv.Rows[i].Cells[1].Value = search_list[i].marked;
//    }
//    search_dgv.Refresh();
//    Refresh();
//}