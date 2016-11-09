using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Data;
using System.Windows.Forms;

using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class AddToBase : Form
    {
        public bool mediaEror;
        public Boolean auto_arch;
        public string FCP_File;
        public File_Comands.XLS[] m_xls;
        private MetaData[] Mas_Of_Hiden_Date_Meta;
        private MetaData[] Mas_Of_Hiden_Meta;
        private MetaData[] Mas_Of_Showm_Meta;
        private MetaData[] Mas_Of_Shown_Date_Meta;
        public Queue<File_Comands.XLS> mas_of_xls;
        private MetaData[] MasOfMeta;
        private MetaDatesClass MDC;
        private string Media_To_Base_Params;
        public string MOV_File;
        // private Main_Form parent;
        private File_Work parentt;
        public string REF_File;
        public string TXT_File;
        public string Vipliner;
        public string XLS_File;
        public string XML_File;
        public int Registrator;
        public AddToBase()
        {
            InitializeComponent();
            mediaEror = true;
        }

        private long start;
        public static void Form_Lauch(int Main_form_Height, string ViPlanner, File_Work parent)
        {
           
            var form = new AddToBase();
            form.start = Log_Class.VAction(ViPlanner, "Регистрация работы СТАРТ",4);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(0, Main_form_Height);
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.parentt = parent;
            form.Vipliner = ViPlanner;
            //  ProgressForm.StartForm("");


           
            form.calc_all_meta();
           
            form.Web_show();
            form.Show();
        }

        public string get_path_from_cmBox(ComboBox cmb, string[] names, string[] paths)
        {
            var selected_name = cmb.SelectedValue.ToString();
            for (var i = 0; i < names.Length; i++)
            {
                if (names[i] == selected_name)
                {
                    return paths[i];
                }
            }
            return "";
        }

        private string Make_Zapros_For_Addition(int work_status)
        {
            for (var i = 0; i < data_dgv.RowCount; i++)
            {
                if (data_dgv.Rows[i].Cells[2].Value == null || data_dgv.Rows[i].Cells[2].Value == ""|| data_dgv.Rows[i].Cells[2].Value == " ")
                {
                    Mas_Of_Showm_Meta[i].Data = "";
                }
                else
                {
                    Mas_Of_Showm_Meta[i].Data = data_dgv.Rows[i].Cells[2].Value.ToString();
                }
            }

            for (var i = 0; i < date_dgv.RowCount; i++)
            {
                if (date_dgv.Rows[i].Cells[2].Value == null || date_dgv.Rows[i].Cells[2].Value == "" || date_dgv.Rows[i].Cells[2].Value == " ")
                {
                    Mas_Of_Shown_Date_Meta[i].Data = "NULL";
                }
                else
                {
                    Mas_Of_Shown_Date_Meta[i].Data = date_dgv.Rows[i].Cells[2].Value.ToString();
                }
            }

            MasOfMeta =
                new MetaData[
                    Mas_Of_Hiden_Meta.Length + Mas_Of_Showm_Meta.Length + Mas_Of_Shown_Date_Meta.Length +
                    Mas_Of_Hiden_Date_Meta.Length];
            var cnst = 0;
            for (var i = cnst; i < Mas_Of_Showm_Meta.Length; i++)
            {
                MasOfMeta[i] = Mas_Of_Showm_Meta[i];
            }
            cnst += Mas_Of_Showm_Meta.Length;
            for (var i = 0; i < Mas_Of_Hiden_Meta.Length; i++)
            {
                MasOfMeta[i + cnst] = Mas_Of_Hiden_Meta[i];
            }

            cnst += Mas_Of_Hiden_Meta.Length;
            for (var i = 0; i < Mas_Of_Shown_Date_Meta.Length; i++)
            {
                MasOfMeta[i + cnst] = Mas_Of_Shown_Date_Meta[i];
            }

            cnst += Mas_Of_Shown_Date_Meta.Length;
            for (var i = 0; i < Mas_Of_Hiden_Date_Meta.Length; i++)
            {
                MasOfMeta[i + cnst] = Mas_Of_Hiden_Date_Meta[i];
            }


            for (int i = 0; i < MasOfMeta.Length; i++)
            {
                if ("  *  * * ** - _     ".Contains(MasOfMeta[i].Data) || MasOfMeta[i].Data == "")
                {
                    if (MasOfMeta[i].type == "bool") 
                        MasOfMeta[i].Data = "false";
                    if (MasOfMeta[i].type == "double") 
                        MasOfMeta[i].Data = "0";
                }
            }


            









            var MetaCount = MasOfMeta.Length;





           
            var zapros = "";
            zapros += "INSERT INTO MetaDataArchive";

            zapros += "(";

            zapros += MasOfMeta[0].Name;


            for (var i = 1; i < MetaCount; i++)
            {
                zapros += ',' + MasOfMeta[i].Name;
            }
            zapros += " , Deleted, Media_Info,PrID,Work_Status,RegisterID,UserID ";
            zapros += ") VALUES ";


            zapros += "(";

            zapros += "'" + MasOfMeta[0].Data + "'";
            for (var i = 1; i < MetaCount; i++)
            {
                if ("True_Peak Momentary_Loudness Short_Term_Loudness Progr_Loudness Loudness_Range".Contains(MasOfMeta[i].Name))
                {
                    zapros += ',' + "'" + MasOfMeta[i].Data.Replace(",",".") + "'";
                }
                else
                {
                    zapros += ',' + "'" + MasOfMeta[i].Data + "'";
                }
                
            }
            zapros += " , 0  ,' " + Media_To_Base_Params + "', "+Properties.Settings.Default.Profile_ID;
            zapros += "  , "+work_status+","+Registrator+","+Properties.Settings.Default.User_ID+")";



            zapros = zapros.Replace("'NULL'", "NULL");
            zapros = zapros.Replace("'true'", "1");
            zapros = zapros.Replace("'True'", "1");
zapros = zapros.Replace("'false'", "0");
zapros = zapros.Replace("'False'", "0");
            return zapros;
        }


        //public bool  Make_Zapros_For_Search(ref long ID,int work_status,string idviplaner)
        //{
        //    for (var i = 0; i < data_dgv.RowCount; i++)
        //    {
        //        if (data_dgv.Rows[i].Cells[2].Value == null || data_dgv.Rows[i].Cells[2].Value == "" || data_dgv.Rows[i].Cells[2].Value == " ")
        //        {
        //            Mas_Of_Showm_Meta[i].Data = "  ";
        //        }
        //        else
        //        {
        //            Mas_Of_Showm_Meta[i].Data = data_dgv.Rows[i].Cells[2].Value.ToString();
        //        }
        //    }

        //    for (var i = 0; i < date_dgv.RowCount; i++)
        //    {
        //        if (date_dgv.Rows[i].Cells[2].Value == null || date_dgv.Rows[i].Cells[2].Value == "" || date_dgv.Rows[i].Cells[2].Value == " ")
        //        {
        //            Mas_Of_Shown_Date_Meta[i].Data = "NULL";
        //        }
        //        else
        //        {
        //            Mas_Of_Shown_Date_Meta[i].Data = date_dgv.Rows[i].Cells[2].Value.ToString();
        //        }
        //    }

        //    MasOfMeta =
        //        new MetaData[
        //            Mas_Of_Hiden_Meta.Length + Mas_Of_Showm_Meta.Length + Mas_Of_Shown_Date_Meta.Length +
        //            Mas_Of_Hiden_Date_Meta.Length];
        //    var cnst = 0;
        //    for (var i = cnst; i < Mas_Of_Showm_Meta.Length; i++)
        //    {
        //        MasOfMeta[i] = Mas_Of_Showm_Meta[i];
        //    }
        //    cnst += Mas_Of_Showm_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Hiden_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Hiden_Meta[i];
        //    }

        //    cnst += Mas_Of_Hiden_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Shown_Date_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Shown_Date_Meta[i];
        //    }

        //    cnst += Mas_Of_Shown_Date_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Hiden_Date_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Hiden_Date_Meta[i];
        //    }


        //    var MetaCount = MasOfMeta.Length;
        //    var zapros = "";
        //    zapros += "Select ID from metadataarchive where ";
        //    zapros += "((" + MasOfMeta[0].Name + " = '" + MasOfMeta[0].Data+"' )";
        //    for (var i = 1; i < MetaCount; i++)
        //    {
        //        if (MasOfMeta[i].Data != "NULL")
        //        {
        //            zapros += " AND (" + MasOfMeta[i].Name + " = '" + MasOfMeta[i].Data + "' )";
        //        }
        //        else
        //        {
        //            zapros += " AND (" + MasOfMeta[i].Name + " IS NULL )";
        //        }

        //    }

        //   zapros+=" "+
        //    " AND (Work_Status= " + work_status + ") AND (Deleted=0))";

        //    zapros = zapros.Replace("'NULL'", "NULL");
        

        //    object readd = null;
        //    readd = SQL_Class.ReadValue(zapros, Properties.Settings.Default.MetaBase_Way);
        //    if (readd != null)
        //    {
        //        try
        //        {
        //            ID = Convert.ToInt64(readd);
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //private void  Make_Zapros_For_Update( long ID,int work_status,int deleted)
        //{
        //    for (var i = 0; i < data_dgv.RowCount; i++)
        //    {
        //        if (data_dgv.Rows[i].Cells[2].Value == null || data_dgv.Rows[i].Cells[2].Value == "" || data_dgv.Rows[i].Cells[2].Value == " ")
        //        {
        //            Mas_Of_Showm_Meta[i].Data = "  ";
        //        }
        //        else
        //        {
        //            Mas_Of_Showm_Meta[i].Data = data_dgv.Rows[i].Cells[2].Value.ToString();
        //        }
        //    }

        //    for (var i = 0; i < date_dgv.RowCount; i++)
        //    {
        //        if (date_dgv.Rows[i].Cells[2].Value == null || date_dgv.Rows[i].Cells[2].Value == "" || date_dgv.Rows[i].Cells[2].Value == " ")
        //        {
        //            Mas_Of_Shown_Date_Meta[i].Data = "NULL";
        //        }
        //        else
        //        {
        //            Mas_Of_Shown_Date_Meta[i].Data = date_dgv.Rows[i].Cells[2].Value.ToString();
        //        }
        //    }

        //    MasOfMeta =
        //        new MetaData[
        //            Mas_Of_Hiden_Meta.Length + Mas_Of_Showm_Meta.Length + Mas_Of_Shown_Date_Meta.Length +
        //            Mas_Of_Hiden_Date_Meta.Length];
        //    var cnst = 0;
        //    for (var i = cnst; i < Mas_Of_Showm_Meta.Length; i++)
        //    {
        //        MasOfMeta[i] = Mas_Of_Showm_Meta[i];
        //    }
        //    cnst += Mas_Of_Showm_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Hiden_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Hiden_Meta[i];
        //    }

        //    cnst += Mas_Of_Hiden_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Shown_Date_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Shown_Date_Meta[i];
        //    }

        //    cnst += Mas_Of_Shown_Date_Meta.Length;
        //    for (var i = 0; i < Mas_Of_Hiden_Date_Meta.Length; i++)
        //    {
        //        MasOfMeta[i + cnst] = Mas_Of_Hiden_Date_Meta[i];
        //    }


        //    var MetaCount = MasOfMeta.Length;
        //    var zapros = "";
        //    zapros += "update  metadataarchive set ";
        //    zapros += "" + MasOfMeta[0].Name + " = '" + MasOfMeta[0].Data+"' ";
        //    for (var i = 1; i < MetaCount; i++)
        //    {
        //        zapros += " , " + MasOfMeta[i].Name + " = '" + MasOfMeta[i].Data + "' ";
        //    }

        //    zapros += " , Deleted=" + deleted + ", Media_Info='" + Media_To_Base_Params + "',PrID=" + Properties.Settings.Default.Profile_ID + ",Work_Status= "+work_status+", UserID="+Properties.Settings.Default.User_ID+"   where ID="+ID;

        //    zapros = zapros.Replace("'NULL'", "NULL");




        //    SQL_Class.Execute(zapros,Properties.Settings.Default.MetaBase_Way);

        //}






        private Boolean check_all()
        {
            var returnn = true;

            var erorstring = "";
            data_dgv.ClearSelection();
            for (var i = 0; i < data_dgv.RowCount; i++)
            {
                var fullness = Convert.ToBoolean(data_dgv.Rows[i].Cells[3].Value);
                if ((data_dgv.Rows[i].Cells[2].Value == "" || data_dgv.Rows[i].Cells[2].Value == null) && fullness)
                {
                    returnn = false;
                    erorstring += "Field -" + '"' + data_dgv.Rows[i].Cells[1].Value + '"' + " is empty" + '\n';
                    data_dgv.Rows[i].Cells[2].Style.BackColor = Color.OrangeRed;
                }
                else
                {
                    data_dgv.Rows[i].Cells[2].Style.BackColor = Color.GreenYellow;
                }
            }


            erorstring += '\n';

            date_dgv.ClearSelection();
            for (var i = 0; i < date_dgv.RowCount; i++)
            {
                var fullness = Convert.ToBoolean(date_dgv.Rows[i].Cells[3].Value);
                if ((date_dgv.Rows[i].Cells[2].Value == "" || date_dgv.Rows[i].Cells[2].Value == null) && fullness)
                {
                    returnn = false;
                    erorstring += "Field -" + '"' + date_dgv.Rows[i].Cells[1].Value + '"' + " is empty" + '\n';
                    date_dgv.Rows[i].Cells[2].Style.BackColor = Color.OrangeRed;
                }
                else
                {
                  
                    date_dgv.Rows[i].Cells[2].Style.BackColor = Color.GreenYellow;
                }
            }

            if (!returnn)
            {
                MessageBox.Show(erorstring);
                
                Check_But.BackColor = Color.OrangeRed;
                AddToBase_But.Enabled = false;
            }
            else
            {
                Check_But.BackColor = Color.LawnGreen;
                AddToBase_But.Enabled = true;
            }

            return returnn;
        }

        public void XLS_ReCollect()
        {
            string erors = "";
            for (var i = 0; i < m_xls.Length; i++)
            {
                for (var j = 0; j < data_dgv.RowCount; j++)
                {
                    if (data_dgv.Rows[j].Cells[0].Value == m_xls[i].name)
                    {
                        if (data_dgv.Rows[j].Cells[2].Value != null)
                        {
                                m_xls[i].data = data_dgv.Rows[j].Cells[2].Value.ToString();
                        }
                        else
                        {
                            m_xls[i].data = "";
                        }
                    }
                }
            }

            for (var i = 0; i < m_xls.Length; i++)
            {
                if (m_xls[i].type == "double")
                {
                    if (m_xls[i].data!="NULL")
                    try
                    {
                        double tr = Convert.ToDouble(m_xls[i].data);
                    }
                    catch (Exception)
                    {

                        erors += "\n Поле " + m_xls[i].name + "имеющее тип число заполненно некоректными данными (" + m_xls[i].data+")";
                        m_xls[i].data = "NULL";
                    }
                    
                }
            }
         if(erors!="")   MessageBox.Show(erors);
        }

        private void AddToBase_But_Click(object sender, EventArgs e)
        {
            bool allow = false;
            if (mediaEror)
            {
                if (
                    Ask_MessageBOX.Ask_Question(
                        "ВНИМАНИЕ!!!!\nВ полях MediaInfo есть ошибки!\nПродолжить регистрацию файла, игнорируя ошибки?"))
                {
                    allow = true;
                }
                else
                {
                    allow = false;
                }


            }
            else
            {
                allow = true;
            }


            allow = PasswordForm.getPermition(ref Registrator);



            if (allow)
            {

                XLS_ReCollect();
                File_Comands.Write_To_XLS_many_files_with_recopy(
                    get_path_from_cmBox(parentt.W_xlsName_CmBox, parentt.W_XLS_Names, parentt.W_XLS_Paths), m_xls,
                    Vipliner);
                SQL_Class.Execute(Make_Zapros_For_Addition(2), Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);

                if (parentt.W_MOV_Names != null)
                {
                    if (parentt.W_MOV_Names.Length != 0)
                    {
                        if (Ask_MessageBOX.Ask_Question(
                            "Вы хотите перенести файл: " +
                            Path.GetFileName(get_path_from_cmBox(parentt.W_movName_CmBox, parentt.W_MOV_Names,
                                parentt.W_MOV_Paths)) + "  в папку Complete"))
                        {
                            if (Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Complete_Path))
                            {
                                var from = get_path_from_cmBox(parentt.W_movName_CmBox, parentt.W_MOV_Names,
                                    parentt.W_MOV_Paths);
                                var dest = Ingest_Assistant.Properties.Settings.Default.Complete_Path +
                                           "\\" +
                                           Path.GetFileName(from);
                                dest = (dest);

                                if (File.Exists(dest))
                                {
                                    MessageBox.Show("В папке Complete уже существует такой файл");
                                }
                                else
                                {

                                    FileM.Move(from, dest);
                                    Log_Class.Move(Vipliner, from, dest);

                                }
                            }
                        }
                    }
                    parentt.psi_arch_but_click();
                }
                Close();
                long stop = Log_Class.VAction(Vipliner, "Регистрация работы СТОП", 4);
                Log_Class.ReWrite_Start(start, stop);
            }
        }

        private void calc_all_meta()
        {
            
            calculate_Dates();
           
            load_Dates();
            
            display_Dates();
           
            load_Data();
           
            display_Data();
            
            TBC.SelectedTab = Calculate_AllMeta;

            if (!Media_Info_Collect_And_Check())
            {
                mediaEror = true;
                MessageBox.Show("Ошибки в Мета данных видео файла!!!!!");
            }
            else
            {
                mediaEror = false;
            }
            check_all();
        }

        private void calculate_Dates()
        {
            string txt;
            if (parentt.W_TXT_Names.Length != 0)
            {
                txt = get_path_from_cmBox(parentt.W_txtName_CmBox, parentt.W_TXT_Names, parentt.W_TXT_Paths);
            }
            else
            {
                txt = "";
            }


            string xml;
            if (parentt.W_XML_Names.Length != 0)
            {
                xml = get_path_from_cmBox(parentt.W_xmlName_CmBox, parentt.W_XML_Names, parentt.W_XML_Paths);
            }
            else
            {
                xml = "";
            }

            string xls;
            if (parentt.W_XLS_Names.Length != 0)
            {
                xls = get_path_from_cmBox(parentt.W_xlsName_CmBox, parentt.W_XLS_Names, parentt.W_XLS_Paths);
            }
            else
            {
                xls = "";
            }

            string fcp;
            if (parentt.W_FCP_Names.Length != 0)
            {
                fcp = get_path_from_cmBox(parentt.W_fcpName_CmBox, parentt.W_FCP_Names, parentt.W_FCP_Paths);
            }
            else
            {
                fcp = "";
            }

            string mov;
            if (parentt.W_MOV_Names.Length != 0)
            {
                mov = get_path_from_cmBox(parentt.W_movName_CmBox, parentt.W_MOV_Names, parentt.W_MOV_Paths);
            }
            else
            {
                mov = "";
            }


            string reff;
            if (parentt.W_RTF_Names.Length != 0)
            {
                reff = get_path_from_cmBox(parentt.W_refName_CmBox, parentt.W_RTF_Names, parentt.W_RTF_Paths);
            }
            else
            {
                reff = "";
            }


            MDC = new MetaDatesClass(parentt.VL_TBox.Text, txt, xml, xls, mov, fcp, reff,
                 (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + parentt.VL_TBox.Text));
        }

        private void load_Dates()
        {
            Mas_Of_Hiden_Date_Meta = new MetaData[0];
            Mas_Of_Shown_Date_Meta = new MetaData[0];


            var count = SQL_Class.ReadValueInt32("Select Count(*) from " + Properties.Settings.Default.MetaDate, Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            var sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            for (var i = 1; i <= count; i++)
            {
                var zapros =
                    "Select MDD_Name, MDD_RusName, MDD_Visible, MDD_Fullness, MDD_InWork, MDD_A, MDD_B, MDD_C, MDD_Deleted from " + Properties.Settings.Default.MetaDate + " Where MDD_ID=" +
                    i;
                SQL_Class.ReadValues(zapros,ref sqlcl);
                sqlcl.SQL_DataReader.Read();
                if (sqlcl.getBoolean(8))
                {
                }
                else
                {
                    if (sqlcl.getBoolean(4))
                    {
                        var temp = new MetaData();
                        temp.Name = sqlcl.SQL_DataReader.GetString(0);
                        temp.Name_RUS = sqlcl.SQL_DataReader.GetString(1);
                        temp.Shown = sqlcl.getBoolean(2);
                        temp.Fullness = sqlcl.getBoolean(3);
                        temp.InWork = sqlcl.getBoolean(4);

                        var a = sqlcl.SQL_DataReader.GetInt32(5);
                        var b = sqlcl.SQL_DataReader.GetInt32(6);
                        var c = sqlcl.SQL_DataReader.GetInt32(7);
                        if (b == 0)
                        {
                            if (a == 0)
                            {
                                temp.Data = "";
                            }
                            else
                            {
                                temp.Data = MDC.calc_date(a, c);
                            }
                        }
                        else
                        {
                            if (a == 0)
                            {
                                temp.Data = "";
                            }
                            else
                            {
                                temp.Data = MDC.calc_time_span(a, b, c);
                            }
                        }


                        if (sqlcl.getBoolean(2))
                        {
                            Array.Resize(ref Mas_Of_Shown_Date_Meta, Mas_Of_Shown_Date_Meta.Length + 1);
                            Mas_Of_Shown_Date_Meta[Mas_Of_Shown_Date_Meta.Length - 1] = temp;
                        }
                        else
                        {
                            Array.Resize(ref Mas_Of_Hiden_Date_Meta, Mas_Of_Hiden_Date_Meta.Length + 1);
                            Mas_Of_Hiden_Date_Meta[Mas_Of_Hiden_Date_Meta.Length - 1] = temp;
                        }
                    }
                }

                
            }
            sqlcl.Manualy_Close_Connection();
            MDC = null;
        }

        private void display_Dates()
        {
            fill_dgv(date_dgv, Mas_Of_Shown_Date_Meta);
        }

        private void fill_dgv(DataGridView dgv, MetaData[] mas)
        {
            dgv.RowCount = mas.Length;
            for (var i = 0; i < mas.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = mas[i].Name;
                dgv.Rows[i].Cells[1].Value = mas[i].Name_RUS;
                dgv.Rows[i].Cells[2].Value = mas[i].Data;
                if (dgv.Rows[i].Cells[2].Value.ToString() == "" || dgv.Rows[i].Cells[2].Value.ToString() == " ")
                    dgv.Rows[i].Cells[2].Value = null;
                dgv.Rows[i].Cells[3].Value = mas[i].Fullness;


                dgv.Rows[i].Cells[0].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[2].Style.BackColor = Color.White;
            }
        }

        private void load_Data()
        {
           
            mas_of_xls = new Queue<File_Comands.XLS>();
            Mas_Of_Hiden_Meta = new MetaData[0];
            Mas_Of_Showm_Meta = new MetaData[0];

            
            var count = SQL_Class.ReadValueInt32("Select Count(*) from "+Properties.Settings.Default.MetaData,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);

            var sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            for (var i = 1; i <= count; i++)
            {
                var zapros =
                    "Select MD_Name, MD_Rus_Name, MD_Show_Key, MD_Fullness_Key, MD_InWork_Key, MD_TXT, MD_XML, MD_XLS, MD_Type from "+Properties.Settings.Default.MetaData+" Where MD_ID=" +
                    i;
               SQL_Class.ReadValues(zapros,ref sqlcl);
                sqlcl.SQL_DataReader.Read();
                if (sqlcl.getBoolean(4))
                {
                    var temp = new MetaData();
                    temp.Name = sqlcl.SQL_DataReader.GetString(0);
                    temp.Name_RUS = sqlcl.SQL_DataReader.GetString(1);
                    temp.Shown = sqlcl.getBoolean(2);
                    temp.Fullness = sqlcl.getBoolean(3);
                    temp.InWork = sqlcl.getBoolean(4);
                    temp.type = sqlcl.SQL_DataReader.GetString(8);
                    int txt = sqlcl.SQL_DataReader.GetInt32(5);
                    var xml = sqlcl.SQL_DataReader.GetString(6);
                    var xls = sqlcl.SQL_DataReader.GetString(7);


                    if (parentt.W_TXT_Names.Length != 0 && txt != 0)
                    {
                        temp.Data =
                            File_Comands.Find_From_TXT(
                                get_path_from_cmBox(parentt.W_txtName_CmBox, parentt.W_TXT_Names, parentt.W_TXT_Paths),
                                txt);
                    }
                    else
                    {
                        if (parentt.W_XML_Names.Length != 0 && xml != "")
                        {
                            temp.Data =
                                File_Comands.Find_From_XML(
                                    get_path_from_cmBox(parentt.W_xmlName_CmBox, parentt.W_XML_Names,
                                        parentt.W_XML_Paths), xml);
                        }
                        else
                        {


                            if (parentt.W_XLS_Names.Length != 0 && xls != "")
                            {
                                var tmp = new File_Comands.XLS();
                                tmp.name = temp.Name;
                                tmp.block = xls;
                                tmp.type = temp.type;
                                mas_of_xls.Enqueue(tmp);
                                temp.Data = "";
                            }
                            else
                            {
                                temp.Data = "";
                            }
                        }

                    }


                    if (sqlcl.getBoolean(2))
                    {
                        Array.Resize(ref Mas_Of_Showm_Meta, Mas_Of_Showm_Meta.Length + 1);
                        Mas_Of_Showm_Meta[Mas_Of_Showm_Meta.Length - 1] = temp;
                    }
                    else
                    {
                        Array.Resize(ref Mas_Of_Hiden_Meta, Mas_Of_Hiden_Meta.Length + 1);
                        Mas_Of_Hiden_Meta[Mas_Of_Hiden_Meta.Length - 1] = temp;
                    }
                }


                
            }
            sqlcl.Manualy_Close_Connection();

           
            if (mas_of_xls.Count != 0)
            {
                mas_of_xls =
                    File_Comands.Read_From_XLS_many_files_with_recopy(
                        get_path_from_cmBox(parentt.W_xlsName_CmBox, parentt.W_XLS_Names, parentt.W_XLS_Paths),
                        mas_of_xls, Vipliner);


                m_xls = new File_Comands.XLS[mas_of_xls.Count];
                var index = 0;
                foreach (var curent in mas_of_xls)
                {
                    m_xls[index] = curent;
                    index++;
                }


                foreach (var curent in mas_of_xls)
                {
                    for (var i = 0; i < Mas_Of_Showm_Meta.Length; i++)
                    {
                        if (Mas_Of_Showm_Meta[i].Name == curent.name)
                        {
                            Mas_Of_Showm_Meta[i].Data = curent.data;
                            break;
                        }
                    }
                    for (var i = 0; i < Mas_Of_Hiden_Meta.Length; i++)
                    {
                        if (Mas_Of_Hiden_Meta[i].Name == curent.name)
                        {
                            Mas_Of_Hiden_Meta[i].Data = curent.data;
                            break;
                        }
                    }
                }
            }
        }

        private void display_Data()
        {
            fill_dgv(data_dgv, Mas_Of_Showm_Meta);
        }

        public void calc_duration()
        {
            var d1 = false;
            var s1 = "";
            DateTime dt1;
            var d2 = false;
            var s2 = "";
            DateTime dt2;
            var d3 = false;
            var index = 0;
            for (var i = 0; i < date_dgv.RowCount; i++)
            {
                if (date_dgv.Rows[i].Cells[0].Value.ToString().Contains("Data_Start"))
                {
                    d1 = true;
                    s1 = date_dgv.Rows[i].Cells[2].Value.ToString();
                }
                if (date_dgv.Rows[i].Cells[0].Value.ToString().Contains("Time_Of_Registration"))
                {
                    d2 = true;
                    s2 = date_dgv.Rows[i].Cells[2].Value.ToString();
                }
                if (date_dgv.Rows[i].Cells[0].Value.ToString().Contains("Total_Time"))
                {
                    d3 = true;
                    index = i;
                }
            }

            if (d1 && d2 && d3)
            {
                try
                {
                    dt1 = Convert.ToDateTime(s1);
                    dt2 = Convert.ToDateTime(s2);
                    var tmp = dt2 - dt1;
                    var write = tmp.ToString("c");
                    date_dgv.Rows[index].Cells[2].Value = write;
                    date_dgv.Refresh();
                }
                catch (Exception)
                {
                }
            }
        }

        private void Check_But_Click(object sender, EventArgs e)
        {
            string erors = "";
            calc_duration();
            check_all();
            for (var i = 0; i < m_xls.Length; i++)
            {
                for (var j = 0; j < data_dgv.RowCount; j++)
                {
                    if (data_dgv.Rows[j].Cells[0].Value == m_xls[i].name)
                    {
                        string dt;
                        if (data_dgv.Rows[j].Cells[2].Value != null)
                        {
                           dt = data_dgv.Rows[j].Cells[2].Value.ToString();
                        }
                        else
                        {
                           dt = "";
                        }
                        if (m_xls[i].type == "double")
                        {
                            if (m_xls[i].data != "NULL")
                            try
                            {
                                double tr = Convert.ToDouble(dt);
                            }
                            catch (Exception)
                            {

                                erors += "\n Поле " + m_xls[i].name + "  имеющее тип число заполненно некоректными данными (" + dt + ")";
                                m_xls[i].data = "NULL";
                            }
                            }
                    }
                }
            }
            if (erors != "") MessageBox.Show(erors);
        }

        private void Meta_Recollect_Click(object sender, EventArgs e)
        {
            calc_all_meta();
        }

        private void date_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                date_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data_Time_Span.Data_ask();
                date_dgv.Refresh();
            }
        }

        private void open_xls_but_Click(object sender, EventArgs e)
        {
            if (parentt.W_XLS_Names != null)
                if (parentt.W_XLS_Names.Length > 0)
                    XML_Class.Open_XML_Editor(get_path_from_cmBox(parentt.W_xlsName_CmBox, parentt.W_XLS_Names, parentt.W_XLS_Paths));
        }

        private void Calculate_AllMeta_Click(object sender, EventArgs e)
        {
        }

        public void Web_show()
        {
            Web_delay.Start();
        }

        private void Web_delay_Tick(object sender, EventArgs e)
        {
            Web_delay.Stop();
            var frm = new Web_Form();
            Web_Form.Form_Start_With_Parent_Panel(frm, parentt.VL_TBox.Text,Web_Panel);
        }

        public string format(string nam, string par)
        {
            var con = 30;

            var len = nam.Length;

            for (var i = len; i <= con; i++)
            {
                nam += ".";
            }
            nam += ": ";
            return nam + par + "\n";
        }

        public Boolean Media_Info_Collect_And_Check()
        {
            Media_To_Base_Params = "";
            if (parentt.W_MOV_Names != null)
            {
                if (parentt.W_MOV_Names.Length != 0)
                {
                    var erors_ocured = false;
                    var MI_class =
                        new Media_Info(get_path_from_cmBox(parentt.W_movName_CmBox, parentt.W_MOV_Names,
                            parentt.W_MOV_Paths));
                    var parameter_name = "";
                    var parameter = "";


                    parameter_name = "Commercial name";
                    parameter = MI_class.get_one_param("General", parameter_name);
                    Commercial_Name_TBox.Text = parameter;
                    if (parameter == " DVCPRO 50" || parameter == " DVCPRO" || parameter == " DVCPRO HD")
                    {
                        Commercial_Name_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Commercial_Name_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }


                    Media_To_Base_Params += format(parameter_name, parameter);


                    parameter_name = "Scan order";
                    var sp = MI_class.get_one_param("Video", parameter_name);
                    Scan_order_TBox.BackColor = Color.LawnGreen;
                    Scan_order_TBox.Text = sp;

                    if (parameter == " DVCPRO 50" || parameter == " DVCPRO")
                    {
                        if (sp != " Bottom Field First")
                        {
                            Scan_order_TBox.BackColor = Color.Tomato;
                            erors_ocured = true;
                        }
                    }
                    else
                    {
                        if (parameter == " DVCPRO HD")
                        {
                            if (sp != " Top Field First")
                            {
                                Scan_order_TBox.BackColor = Color.Tomato;
                                erors_ocured = true;
                            }
                        }
                        else
                        {
                            Scan_order_TBox.BackColor = Color.Yellow;
                            //  erors_ocured = true;
                        }
                    }

                    Media_To_Base_Params += format(parameter_name, parameter);


                    parameter_name = "Complete name";
                    parameter = MI_class.get_one_param("General", parameter_name);
                    Complete_Name_TBox.Text = parameter;
                    File_Name_TBox.Text = Path.GetFileName(parameter);

                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Format profile";
                    parameter = MI_class.get_one_param("General", parameter_name);
                    Format_Profile_TBox.Text = parameter;
                    if (parameter == " QuickTime")
                    {
                        Format_Profile_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Format_Profile_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }
                    Media_To_Base_Params += format(parameter_name, parameter);


                    parameter_name = "Codec ID";
                    parameter = MI_class.get_one_param("General", parameter_name);
                    Codec_ID_TBox.Text = parameter;
                    if (parameter == " qt" || parameter == " qt " || parameter == " qt  ")
                    {
                        Codec_ID_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Codec_ID_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }

                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Duration";
                    parameter = MI_class.get_one_param("Video", parameter_name);
                    Duration_TBox.Text = parameter;

                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Display aspect ratio";
                    parameter = MI_class.get_one_param("Video", parameter_name);
                    Display_Aspect_TBox.Text = parameter;
                    if (parameter == " 16:9" || parameter == " 4:3")
                    {
                        Display_Aspect_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Display_Aspect_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }
                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Frame rate";
                    parameter = MI_class.get_one_param("Video", parameter_name);
                    Frame_Rate_TBox.Text = parameter;
                    if (parameter == " 25.000 fps")
                    {
                        Frame_Rate_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Frame_Rate_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }
                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Scan type";
                    parameter = MI_class.get_one_param("Video", parameter_name);
                    Scan_Type_TBox.Text = parameter;
                    if (parameter == " Interlaced")
                    {
                        Scan_Type_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Scan_Type_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }
                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Time code of first frame";
                    parameter = MI_class.get_one_param("Video", parameter_name);
                    Time_Code_First_VIDEO_TBox.Text = parameter;
                    if (parameter == " 00:00:00:00")
                    {
                        Time_Code_First_VIDEO_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Time_Code_First_VIDEO_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }
                    Media_To_Base_Params += format(parameter_name, parameter);

                    parameter_name = "Channel count";
                    parameter = MI_class.get_one_param("Audio", parameter_name);
                    Channel_TBox.Text = parameter;
                    if (parameter == " 2 channels")
                    {
                        Channel_TBox.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        Channel_TBox.BackColor = Color.Tomato;
                        erors_ocured = true;
                    }

                    Media_To_Base_Params += format(parameter_name, parameter);


                    parameter_name = "Channel positions";
                    erors_ocured = Media_Info_One_Param(parameter_name, "Audio", " Front: L R", Chanel_Positions_TBox,
                        MI_class, erors_ocured);
                    parameter = MI_class.get_one_param("Audio", parameter_name);
                    Media_To_Base_Params += format(parameter_name, parameter);





                    parameter_name = "Sampling rate";
                    erors_ocured = Media_Info_One_Param(parameter_name, "Audio", " 48.0 KHz", Sampling_Rate_Tbox,
                        MI_class, erors_ocured);
                    Media_To_Base_Params += format(parameter_name, Sampling_Rate_Tbox.Text);

                    parameter_name = "Bit depth";
                    erors_ocured = Media_Info_One_Param(parameter_name, "Audio", " 16 bits", Bit_Depth_TBox, MI_class, erors_ocured);
                    Media_To_Base_Params += format(parameter_name, Bit_Depth_TBox.Text);

                    parameter_name = "Time code of first frame";
                    erors_ocured = Media_Info_One_Param(parameter_name, "Other", " 00:00:00:00",
                        Time_Code_Of_First_OTHER_TBox, MI_class, erors_ocured);
                    Media_To_Base_Params += format(parameter_name, Time_Code_Of_First_OTHER_TBox.Text);

                    parameter_name = "Time code settings";
                    erors_ocured = Media_Info_One_Param(parameter_name, "Other", " Striped", Time_Code_Stripted_TBox,
                        MI_class, erors_ocured);
                    Media_To_Base_Params += format(parameter_name, Time_Code_Stripted_TBox.Text);
                    //Media_Info_Show.Form_Lauch_Test(Media_To_Base_Params);
                    return !erors_ocured;
                }
                return false;
            }
            return false;
        }

        public Boolean Media_Info_One_Param(string parameter_name, string block, string check, TextBox tb, Media_Info Md,Boolean oldv)
        {
            var parameter = Md.get_one_param(block, parameter_name);
            tb.Text = parameter;
            if (check != "")
            {
                if (parameter == check)
                {
                    tb.BackColor = Color.LawnGreen;
                    return (oldv||false);
                }
                tb.BackColor = Color.Tomato;
                return true;
            }
            tb.BackColor = Color.LawnGreen;
            return oldv;
        }

        private void AddToBase_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(
          //      "ВНИМАНИЕ!!!!! \n Временно отключена возможность вносить изменения в файл документации путем редактирования данных на форме оформления работы!!!! \n Для изменения документации используй кнопку 'Открыть файл документации для внесения изменений' а после внесения изменений используй кнопку 'Пересобрать метаданные' для пересбора информации.");
        }

        public struct MetaData
        {
            public string Data;
            public Boolean Fullness;
            public Boolean InWork;
            public string Name;
            public string Name_RUS;
            public Boolean Shown;
            public string type;
        }

        private void date_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string ret = Data_Time_Span.Data_ask();
                if (ret != "#")
                {
                     date_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ret;
                date_dgv.Refresh();
                }
               
            }
        }

        private void abort_registration_but_Click(object sender, EventArgs e)
        {
            long stop = Log_Class.VAction(Vipliner, "Регистрация работы Ручное прерывание СТОП",4);
            Log_Class.ReWrite_Start(start, stop);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allow = false;
            if (mediaEror)
            {
                if (
                    Ask_MessageBOX.Ask_Question(
                        "ВНИМАНИЕ!!!!\nВ полях MediaInfo есть ошибки!\nПродолжить регистрацию файла, игнорируя ошибки?"))
                {
                    allow = true;
                }
                else
                {
                    allow = false;
                }


            }
            else
            {
                allow = true;
            }


            if (allow)
            {
                XLS_ReCollect();




                File_Comands.Write_To_XLS_many_files_with_recopy(
                    get_path_from_cmBox(parentt.W_xlsName_CmBox, parentt.W_XLS_Names, parentt.W_XLS_Paths), m_xls,
                    Vipliner);




                SQL_Class.Execute(Make_Zapros_For_Addition(1), Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);









                Close();

                long stop = Log_Class.VAction(Vipliner, "Регистрация работы СТОП", 4);
                Log_Class.ReWrite_Start(start, stop);
            }
        }

        private void Web_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}