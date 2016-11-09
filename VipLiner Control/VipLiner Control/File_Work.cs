using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Ingest_Assistant.Properties;


namespace Ingest_Assistant
{
    public partial class File_Work : Form
    {
        public string[] A_FCP_Names;
        public string A_FCP_Path;
        public string[] A_FCP_Paths;
        public string[] A_XLS_Names;
        public string A_XLS_Path;
        public string[] A_XLS_Paths;
        public string[] A_XML_Names;
        public string A_XML_Path;
        public string[] A_XML_Paths;
        //   private DateTm browser=new DateTm();


        public Browser Browser_Parent;
        private FileCopyForm cpy;
        public string[] M_MOV_Names;
        public string M_MOV_Path;
        public string[] M_MOV_Paths;
        public Main_Form par;
        public int parent_height;
        public Boolean restart;
        public string[] S_MOV_Names;
        public string S_MOV_Path;
        public string[] S_MOV_Paths;
        public string VL_Num;
        public string VL_old;
        public string VL_Perfix;
        public string[] W_FCP_Names;
        public string W_FCP_Path;
        public string[] W_FCP_Paths;
        public string[] W_MOV_Names;
        public string W_MOV_Path;
        public string[] W_MOV_Paths;
        public string W_REF_Path;
        public string[] W_RTF_Names;
        public string[] W_RTF_Paths;
        public string[] W_TXT_Names;
        public string W_TXT_Path;
        public string[] W_TXT_Paths;
        public string[] W_XLS_Names;
        public string W_XLS_Path;
        public string[] W_XLS_Paths;
        public string[] W_XML_Names;
        public string W_XML_Path;
        public string[] W_XML_Paths;
        public Web_Form Web_frm;
       
        public string[] W_OTHER_Paths;
        public string[] W_OTHER_Names;

        public string[] W_TEKOM_Paths;
        public string[] W_TEKOM_Names;

        public string[] SRC_Full;
        public string[] SRC_Short;
        
        

        private Consolidate_Options co;
        private DirectoryM_Container cntr;




        public File_Work(Browser parent)
        {
            InitializeComponent();


            if (SQL_Class.ReadValueString("Select Name from settings where ID="+Settings.Default.Profile_ID,Settings.Default.Setting_Base_Path).Contains("ASM"))
            {
                asm1.Visible = true;
                asm2.Visible = true;
                asm3.Visible = true;
            }
            else
            {
                asm1.Visible = false;
                asm2.Visible = false;
                asm3.Visible = false;

            }



            co = new Consolidate_Options(ref Consolidate_DGV);
            co.Load_To_DGV();

            Browser_Parent = parent;
            restart = false;
            clean_temp();
        }

        private void Form_restart_but_Click(object sender, EventArgs e)
        {
            restart = true;
            Browser_Parent.File_Work_Restart();
        }

        public void Reload_With_Input(string input)
        {
            VL_TBox.Text = input;
            if (Web_frm != null)
            {
                try
                {
                    Web_frm.Close();
                }
                catch (Exception)
                {
                }
            }
            load_info_without_browser_update();
        }

        private void archive_element_unlock()
        {
            A_xmlName_CmBox.Enabled = true;
            A_xml_ChBox.Enabled = true;
            A_xml_indic.Enabled = true;
            A_xml_RBut.Enabled = true;

            A_fcpName_CmBox.Enabled = true;
            A_fcp_ChBox.Enabled = true;
            A_fcp_indic.Enabled = true;
            A_fcp_RBut.Enabled = true;


            A_xlsName_CmBox.Enabled = true;
            A_xls_ChBox.Enabled = true;
            A_xls_indic.Enabled = true;
            A_xls_RBut.Enabled = true;
        }

        public void clean_temp()
        {
            if (!Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory)) DirectoryM.CreateDirectory(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory);
            var filess = Directory.GetFiles(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory);
            for (var i = 0; i < filess.Length; i++)
            {
                if (Path.GetExtension(filess[i]) != ".dll")
                {
                    try
                    {
                        FileM.Delete(filess[i]);
                        Log_Class.Delete(VL_TBox.Text, filess[i]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка удаления файла из временной папки:  " + Path.GetFileName(filess[i]) +
                                        "  Проверьте открытость этого файла в других программах и удалите его вручную.");
                    }
                }
            }
        }

        public void load_info_without_browser_update()
        {
            long START =Log_Class.VAction(VL_TBox.Text, "Сбор информации СТАРТ",3);
            var Full_VipLiner = VL_TBox.Text;
            VL_Perfix = Full_VipLiner.Substring(0, 2);
            VL_Num = Full_VipLiner.Substring(2, 6);
          
            clean_temp();
            To_Base_grBox.Enabled = true;
            AdditionalFunctions_GrBox.Enabled = true;
            archive_element_unlock();
            var path =  (Ingest_Assistant.Properties.Settings.Default.Shablon_Path +"\\"+ "SPF-search.jpg");
            path =  (path);
            try
            {
                Indicator_PicBox.Image = Image.FromFile(path);
            }
            catch
            {
                Indicator_PicBox.Image = Resources.error;
            }
            Indicator_PicBox.Visible = true;
            Refresh();


            Delete_GrBox.Enabled = true;
            Work_GrBox.Enabled = false;
            Stock_GrBox.Enabled = false;
            Archive_GrBox.Enabled = false;
            Master_GrBox.Enabled = false;
            VL_TBox.Enabled = false;

            W_panel.Visible = true;
            W_panel2.Visible = true;
            A_panel.Visible = true;
            A_panel2.Visible = true;

            W_FolderExists_ChBox.Checked = false;
            A_FolderExists_ChBox.Checked = false;
            ChBox_Clear();




            for (int i = 0; i < co.Directory_Masive.Length; i++)
            {
               if( co.Directory_Masive[i].Selected&& co.Directory_Masive[i].Path==Ingest_Assistant.Properties.Settings.Default.Work_Path) prepare_work();
                if (co.Directory_Masive[i].Selected && co.Directory_Masive[i].Path == Ingest_Assistant.Properties.Settings.Default.Archive_Path) prepare_archive();
                if (co.Directory_Masive[i].Selected && co.Directory_Masive[i].Path == Ingest_Assistant.Properties.Settings.Default.Master_Path) prepare_master();
                if (co.Directory_Masive[i].Selected && co.Directory_Masive[i].Path == Ingest_Assistant.Properties.Settings.Default.Stock_Path) prepare_stock();
            }
            co.Load_Not_Main_Directories(VL_Num,ref cntr,ref Other_Consolidate_CmBox,ref Other_Consolidate_DGV);





            //if (AllFolder_ChBox.Checked)
            //{
            //    prepare_work();
            //    prepare_archive();
            //    prepare_master();
            //    prepare_stock();
            //}
            //else
            //{
            //    if (WorkFolder_ChBox.Checked) prepare_work();
            //    if (ArchiveFolder_ChBox.Checked) prepare_archive();
            //    if (MasterFolder_ChBox.Checked) prepare_master();
            //    if (StockFolder_ChBox.Checked) prepare_stock();
            //}

            Consolidate_GrBox.Enabled = true;
            Indicator_PicBox.Visible = false;

           long STOP= Log_Class.VAction(VL_TBox.Text, "Сбор информации СТОП",3);
            Log_Class.ReWrite_Start(START,STOP);
        }

        private void load_info()
        {
            Browser_Parent.Browser_Refresh();
            load_info_without_browser_update();
        }

        private void VLNum_Click(object sender, EventArgs e)
        {
            load_info_without_browser_update();
        }

        public void prepare_archive()
        {
            Archive_GrBox.Enabled = true;


            var xml = new Queue();
            var xls = new Queue();
            var fcp = new Queue();

            var ViPlaner = VL_Perfix + VL_Num;
            var Dir_Path =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + ViPlaner);

            Dir_Path =  (Dir_Path);

            if (Directory.Exists(Dir_Path))
            {
                var dr = new DirectoryInfo(Dir_Path);
                A_Date_Creation.Text = dr.CreationTime.ToString("dd-MM-yyyy  HH-mm-ss");


                A_FolderExists_ChBox.Checked = true;
                A_panel.Visible = false;
                A_panel2.Visible = false;
                var path = Dir_Path;

                var all_files = Directory.GetFiles(path);
                var count = all_files.Length;
                var temp = "";

                for (var i = 0; i < count; i++)
                {
                    temp = all_files[i];
                    if (Path.GetFileName(temp)[0] != '.' && Path.GetFileName(temp).Substring(0, 8).Contains(VL_Num))
                    {
                        if (Path.GetExtension(temp) == ".xml"&& !temp.Contains("_s"))
                        {
                            xls.Enqueue(temp);
                        }
                        else
                        {
                            if (Path.GetExtension(temp) == ".xml")
                            {
                                xml.Enqueue(temp);
                            }
                            else
                            {
                                if (Path.GetExtension(temp) == ".fcp")
                                {
                                    fcp.Enqueue(temp);
                                }
                            }
                        }
                    }
                }


                A_XML_Paths = make_paths_from_queue(xml);
                A_XML_Names = make_names_from_paths(A_XML_Paths);
                if (A_XML_Names.Length == 1)
                {
                    A_xml_indic.BackColor = Color.Green;
                    A_xml_ChBox.Enabled = true;
                    A_xml_RBut.Enabled = true;
                    A_xmlName_CmBox.DataSource = A_XML_Names;
                    A_xmlName_CmBox.BackColor = Color.PaleTurquoise;
                    A_xml_Panel.Visible = true;
                }
                else
                {
                    if (A_XML_Names.Length != 0)
                    {
                        A_xml_indic.BackColor = Color.Green;
                        A_xml_ChBox.Enabled = true;
                        A_xml_RBut.Enabled = true;
                        A_xmlName_CmBox.DataSource = A_XML_Names;
                        A_xmlName_CmBox.BackColor = Color.Yellow;
                        A_xmlName_CmBox.Enabled = true;
                        A_xml_Panel.Visible = false;
                    }
                    else
                    {
                        A_xml_indic.BackColor = Color.Red;
                        A_xml_ChBox.Enabled = false;
                        A_xml_RBut.Enabled = false;
                        A_xmlName_CmBox.DataSource = null;
                        A_xmlName_CmBox.BackColor = Color.Red;
                        A_xmlName_CmBox.Enabled = false;
                        A_xml_Panel.Visible = false;
                    }
                }


                A_XLS_Paths = make_paths_from_queue(xls);
                A_XLS_Names = make_names_from_paths(A_XLS_Paths);
                if (A_XLS_Names.Length == 1)
                {
                    A_xls_indic.BackColor = Color.Green;
                    A_xls_ChBox.Enabled = true;
                    A_xls_RBut.Enabled = true;
                    A_xlsName_CmBox.DataSource = A_XLS_Names;
                    A_xlsName_CmBox.BackColor = Color.PaleTurquoise;
                    A_xls_Panel.Visible = true;
                }
                else
                {
                    if (A_XLS_Names.Length != 0)
                    {
                        A_xls_indic.BackColor = Color.Green;
                        A_xls_ChBox.Enabled = true;
                        A_xls_RBut.Enabled = true;
                        A_xlsName_CmBox.DataSource = A_XLS_Names;
                        A_xlsName_CmBox.BackColor = Color.Yellow;
                        A_xlsName_CmBox.Enabled = true;
                        A_xls_Panel.Visible = false;
                    }
                    else
                    {
                        A_xls_indic.BackColor = Color.Red;
                        A_xls_ChBox.Enabled = false;
                        A_xls_RBut.Enabled = false;
                        A_xlsName_CmBox.DataSource = null;
                        A_xlsName_CmBox.BackColor = Color.Red;
                        A_xlsName_CmBox.Enabled = false;
                        A_xls_Panel.Visible = false;
                    }
                }


                A_FCP_Paths = make_paths_from_queue(fcp);
                A_FCP_Names = make_names_from_paths(A_FCP_Paths);
                if (A_FCP_Names.Length == 1)
                {
                    A_fcp_indic.BackColor = Color.Green;
                    A_fcp_ChBox.Enabled = true;
                    A_fcp_RBut.Enabled = true;
                    A_fcpName_CmBox.DataSource = A_FCP_Names;
                    A_fcpName_CmBox.BackColor = Color.PaleTurquoise;
                    A_fcp_Panel.Visible = true;
                }
                else
                {
                    if (A_FCP_Names.Length != 0)
                    {
                        A_fcp_indic.BackColor = Color.Green;
                        A_fcp_ChBox.Enabled = true;
                        A_fcp_RBut.Enabled = true;
                        A_fcpName_CmBox.DataSource = A_FCP_Names;
                        A_fcpName_CmBox.BackColor = Color.Yellow;
                        A_fcpName_CmBox.Enabled = true;
                        A_fcp_Panel.Visible = false;
                    }
                    else
                    {
                        A_fcp_indic.BackColor = Color.Red;
                        A_fcp_ChBox.Enabled = false;
                        A_fcp_RBut.Enabled = false;
                        A_fcpName_CmBox.DataSource = null;
                        A_fcpName_CmBox.BackColor = Color.Red;
                        A_fcpName_CmBox.Enabled = false;
                        A_fcp_Panel.Visible = false;
                    }
                }
            }
        }

        public string[] make_paths_from_queue(Queue queue)
        {
            string[] paths;
            var count = 0;
            count = queue.Count;

            paths = new string[count];
            var temp = "";
            for (var i = 0; i < count; i++)
            {
                temp = queue.Dequeue().ToString();

                paths[i] = temp;
            }
            return paths;
        }

        public string[] make_names_from_paths(string[] paths)
        {
            string[] names;
            var count = 0;
            count = paths.Length;

            names = new string[count];
            var temp = "";
            for (var i = 0; i < count; i++)
            {
                names[i] = Path.GetFileName(paths[i]);
            }
            return names;
        }

        public void prepare_work()
        {
            Work_GrBox.Enabled = true;
            var txt = new Queue();
            var xml = new Queue();
            var xls = new Queue();
            var fcp = new Queue();
            var mov = new Queue();
            var rtf = new Queue();
            var TEKOM = new Queue();
            var other = new Queue();

            var ViPlaner = VL_Perfix + VL_Num;
            var Dir_Path =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + ViPlaner);
            Dir_Path =  (Dir_Path);
            if (Directory.Exists(Dir_Path))
            {
                var dr = new DirectoryInfo(Dir_Path);
                W_Date_Creation.Text = dr.CreationTime.ToString("dd-MM-yyyy  HH-mm-ss");
                W_FolderExists_ChBox.Checked = true;
                W_panel.Visible = false;
                W_panel2.Visible = false;
                var path = Dir_Path;

                var all_files = Directory.GetFiles(path);
                var count = all_files.Length;
                var temp = "";
                string[] other_types = Properties.Settings.Default.Other_Work_File_Types.Split('|');

                for (var i = 0; i < count; i++)
                {
                    temp = all_files[i];
                    if (Path.GetFileName(temp)[0] != '.')
                    {
                        if (Path.GetExtension(temp) == ".mov" || Path.GetExtension(temp) == ".avi" || Path.GetExtension(temp) == ".mxf")
                        {
                            mov.Enqueue(temp);
                        }
                        else
                        {
                            if (Path.GetFileName(temp).Contains(ViPlaner))
                            {
                                if (Path.GetExtension(temp) == ".txt")
                                {
                                    txt.Enqueue(temp);
                                }
                                else
                                {
                                    if (Path.GetExtension(temp) == ".xml"&&((temp.Contains("_s"))))
                                    {
                                        xml.Enqueue(temp);
                                    }
                                    else
                                    {
                                        if (Path.GetExtension(temp) == ".xml"&&(!(temp.Contains("_s"))))
                                        {
                                            xls.Enqueue(temp);
                                        }
                                        else
                                        {
                                            if (Path.GetExtension(temp) == ".fcp")
                                            {
                                                fcp.Enqueue(temp);
                                            }
                                            else
                                            {
                                                if (Path.GetExtension(temp) == ".ref")
                                                {
                                                    rtf.Enqueue(temp);
                                                }
                                                else
                                                {
                                                    if (Path.GetExtension(temp) == ".xlsx")
                                                    {
                                                        TEKOM.Enqueue(temp);
                                                    }
                                                    else
                                                    {
                                                        if (other_types.Contains(Path.GetExtension(temp)))
                                                        {
                                                            other.Enqueue(temp);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                W_TXT_Paths = make_paths_from_queue(txt);
                W_TXT_Names = make_names_from_paths(W_TXT_Paths);
                if (W_TXT_Names.Length == 1)
                {
                    W_txt_indic.BackColor = Color.Green;
                    //   W_txt_indic.Text = "Открыть";
                    W_txt_ChBox.Enabled = true;
                    W_txt_RBut.Enabled = true;
                    W_txtName_CmBox.DataSource = W_TXT_Names;
                    W_txtName_CmBox.BackColor = Color.PaleTurquoise;
                    W_txtName_CmBox.Enabled = true;
                    W_txt_Panel.Visible = true;
                }
                else
                {
                    if (W_TXT_Names.Length != 0)
                    {
                        //  W_txt_indic.Text = "Открыть";
                        W_txt_indic.BackColor = Color.Green;
                        W_txt_ChBox.Enabled = true;
                        W_txt_RBut.Enabled = true;
                        W_txtName_CmBox.DataSource = W_TXT_Names;
                        W_txtName_CmBox.BackColor = Color.Yellow;
                        W_txtName_CmBox.Enabled = true;
                        W_txt_Panel.Visible = false;
                    }
                    else
                    {
                        //  W_txt_indic.Text = "";
                        W_txt_indic.BackColor = Color.Red;
                        W_txt_ChBox.Enabled = false;
                        W_txt_RBut.Enabled = false;
                        W_txtName_CmBox.DataSource = null;
                        W_txtName_CmBox.BackColor = Color.Red;
                        W_txtName_CmBox.Enabled = false;
                        W_txt_Panel.Visible = false;
                    }
                }




                W_TEKOM_Paths = make_paths_from_queue(TEKOM);
                W_TEKOM_Names = make_names_from_paths(W_TEKOM_Paths);
                if (W_TEKOM_Names.Length == 1)
                {
                    W_TEKOM_indic.BackColor = Color.Green;
                    
                   // W_TEKOM_ChBox.Enabled = true;
                   
                    W_TEKOMName_CmBox.DataSource = W_TEKOM_Names;
                    W_TEKOMName_CmBox.BackColor = Color.PaleTurquoise;
                    W_TEKOMName_CmBox.Enabled = true;
                    W_TEKOM_Panel.Visible = true;
                }
                else
                {
                    if (W_TEKOM_Names.Length != 0)
                    {
                        
                        W_TEKOM_indic.BackColor = Color.Green;
                       // W_TEKOM_ChBox.Enabled = true;
                       
                        W_TEKOMName_CmBox.DataSource = W_TEKOM_Names;
                        W_TEKOMName_CmBox.BackColor = Color.Yellow;
                        W_TEKOMName_CmBox.Enabled = true;
                        W_TEKOM_Panel.Visible = false;
                    }
                    else
                    {
                        
                        W_TEKOM_indic.BackColor = Color.Red;
                       // W_TEKOM_ChBox.Enabled = false;
                        
                        W_TEKOMName_CmBox.DataSource = null;
                        W_TEKOMName_CmBox.BackColor = Color.Red;
                        W_TEKOMName_CmBox.Enabled = false;
                        W_TEKOM_Panel.Visible = false;
                    }
                }






                W_XML_Paths = make_paths_from_queue(xml);
                W_XML_Names = make_names_from_paths(W_XML_Paths);
                if (W_XML_Names.Length == 1)
                {
                    //  W_xml_indic.Text = "Открыть";
                    W_xml_indic.BackColor = Color.Green;
                    W_xml_ChBox.Enabled = true;
                    W_xml_RBut.Enabled = true;
                    W_xmlName_CmBox.Enabled = true;
                    W_xmlName_CmBox.DataSource = W_XML_Names;
                    W_xmlName_CmBox.BackColor = Color.PaleTurquoise;
                    W_xml_Panel.Visible = true;
                }
                else
                {
                    if (W_XML_Names.Length != 0)
                    {
                        // W_xml_indic.Text = "Открыть";
                        W_xml_indic.BackColor = Color.Green;
                        W_xml_ChBox.Enabled = true;
                        W_xml_RBut.Enabled = true;
                        W_xmlName_CmBox.DataSource = W_XML_Names;
                        W_xmlName_CmBox.BackColor = Color.Yellow;
                        W_xmlName_CmBox.Enabled = true;
                        W_xml_Panel.Visible = false;
                    }
                    else
                    {
                        //  W_xml_indic.Text = "";
                        W_xml_indic.BackColor = Color.Red;
                        W_xml_ChBox.Enabled = false;
                        W_xml_RBut.Enabled = false;
                        W_xmlName_CmBox.DataSource = null;
                        W_xmlName_CmBox.BackColor = Color.Red;
                        W_xmlName_CmBox.Enabled = false;
                        W_xml_Panel.Visible = false;
                    }
                }


                W_XLS_Paths = make_paths_from_queue(xls);
                W_XLS_Names = make_names_from_paths(W_XLS_Paths);
                if (W_XLS_Names.Length == 1)
                {
                    W_xls_indic.BackColor = Color.Green;
                    W_xls_ChBox.Enabled = true;
                    W_xls_RBut.Enabled = true;
                    W_xlsName_CmBox.Enabled = true;
                    W_xlsName_CmBox.DataSource = W_XLS_Names;
                    W_xlsName_CmBox.BackColor = Color.PaleTurquoise;
                    W_xls_Panel.Visible = true;
                }
                else
                {
                    if (W_XLS_Names.Length != 0)
                    {
                        W_xls_indic.BackColor = Color.Green;
                        W_xls_ChBox.Enabled = true;
                        W_xls_RBut.Enabled = true;
                        W_xlsName_CmBox.DataSource = W_XLS_Names;
                        W_xlsName_CmBox.BackColor = Color.Yellow;
                        W_xlsName_CmBox.Enabled = true;
                        W_xls_Panel.Visible = false;
                    }
                    else
                    {
                        W_xls_indic.BackColor = Color.Red;
                        W_xls_ChBox.Enabled = false;
                        W_xls_RBut.Enabled = false;
                        W_xlsName_CmBox.DataSource = null;
                        W_xlsName_CmBox.BackColor = Color.Red;
                        W_xlsName_CmBox.Enabled = false;
                        W_xls_Panel.Visible = false;
                    }
                }


                W_FCP_Paths = make_paths_from_queue(fcp);
                W_FCP_Names = make_names_from_paths(W_FCP_Paths);
                if (W_FCP_Names.Length == 1)
                {
                    W_fcp_indic.BackColor = Color.Green;
                    W_fcp_ChBox.Enabled = true;
                    W_fcp_RBut.Enabled = true;
                    W_fcpName_CmBox.Enabled = true;
                    W_fcpName_CmBox.DataSource = W_FCP_Names;
                    W_fcpName_CmBox.BackColor = Color.PaleTurquoise;
                    W_fcp_Panel.Visible = true;
                }
                else
                {
                    if (W_FCP_Names.Length != 0)
                    {
                        W_fcp_indic.BackColor = Color.Green;
                        W_fcp_ChBox.Enabled = true;
                        W_fcp_RBut.Enabled = true;
                        W_fcpName_CmBox.DataSource = W_FCP_Names;
                        W_fcpName_CmBox.BackColor = Color.Yellow;
                        W_fcpName_CmBox.Enabled = true;
                        W_fcp_Panel.Visible = false;
                    }
                    else
                    {
                        W_fcp_indic.BackColor = Color.Red;
                        W_fcp_ChBox.Enabled = false;
                        W_fcp_RBut.Enabled = false;
                        W_fcpName_CmBox.DataSource = null;
                        W_fcpName_CmBox.BackColor = Color.Red;
                        W_fcpName_CmBox.Enabled = false;
                        W_fcp_Panel.Visible = false;
                    }
                }

                W_MOV_Paths = make_paths_from_queue(mov);
                W_MOV_Names = make_names_from_paths(W_MOV_Paths);
                if (W_MOV_Names.Length == 1)
                {
                    W_mov_indic.BackColor = Color.Green;
                    W_mov_ChBox.Enabled = true;
                    W_mov_RBut.Enabled = true;
                    W_movName_CmBox.DataSource = W_MOV_Names;
                    var selection = W_movName_CmBox.SelectedValue.ToString();
                    /// W_movName_CmBox.BackColor = Color.PaleTurquoise;
                    W_movName_CmBox.Enabled = true;
                    W_mov_Panel.Visible = true;
                    if (selection.Substring(selection.Length - 4) == ".avi")
                    {
                        W_movName_CmBox.BackColor = Color.DeepPink;
                    }
                    else
                    {
                        if (W_MOV_Names.Length == 1)
                        {
                            W_movName_CmBox.BackColor = Color.PaleTurquoise;
                        }
                        else
                        {
                            W_movName_CmBox.BackColor = Color.Yellow;
                        }
                    }
                }
                else
                {
                    if (W_MOV_Names.Length != 0)
                    {
                        W_mov_indic.BackColor = Color.Green;
                        W_mov_ChBox.Enabled = true;
                        W_mov_RBut.Enabled = true;
                        W_movName_CmBox.DataSource = W_MOV_Names;
                        //  W_movName_CmBox.BackColor = Color.Yellow;
                        W_movName_CmBox.Enabled = true;
                        W_mov_Panel.Visible = false;

                        var selection = W_movName_CmBox.SelectedValue.ToString();
                        if (selection.Substring(selection.Length - 4) == ".avi")
                        {
                            W_movName_CmBox.BackColor = Color.DeepPink;
                        }
                        else
                        {
                            if (W_MOV_Names.Length == 1)
                            {
                                W_movName_CmBox.BackColor = Color.PaleTurquoise;
                            }
                            else
                            {
                                W_movName_CmBox.BackColor = Color.Yellow;
                            }
                        }
                    }
                    else
                    {
                        W_mov_indic.BackColor = Color.Red;
                        W_mov_ChBox.Enabled = false;
                        W_mov_RBut.Enabled = false;
                        W_movName_CmBox.DataSource = null;
                        W_movName_CmBox.BackColor = Color.Red;
                        W_movName_CmBox.Enabled = false;
                        W_mov_Panel.Visible = false;
                    }
                }


                W_RTF_Paths = make_paths_from_queue(rtf);
                W_RTF_Names = make_names_from_paths(W_RTF_Paths);
                if (W_RTF_Names.Length == 1)
                {
                    W_ref_indic.BackColor = Color.Green;
                    W_ref_ChBox.Enabled = true;
                    W_ref_RBut.Enabled = true;
                    W_refName_CmBox.DataSource = W_RTF_Names;
                    W_refName_CmBox.BackColor = Color.PaleTurquoise;
                    W_ref_Panel.Visible = true;
                    W_refName_CmBox.Enabled = true;
                }
                else
                {
                    if (W_RTF_Names.Length != 0)
                    {
                        W_ref_indic.BackColor = Color.Green;
                        W_ref_ChBox.Enabled = true;
                        W_ref_RBut.Enabled = true;
                        W_refName_CmBox.DataSource = W_RTF_Names;
                        W_refName_CmBox.BackColor = Color.Yellow;
                        W_refName_CmBox.Enabled = true;
                        W_ref_Panel.Visible = false;
                    }
                    else
                    {
                        W_ref_indic.BackColor = Color.Red;
                        W_ref_ChBox.Enabled = false;
                        W_ref_RBut.Enabled = false;
                        W_refName_CmBox.DataSource = null;
                        W_refName_CmBox.BackColor = Color.Red;
                        W_refName_CmBox.Enabled = false;
                        W_ref_Panel.Visible = false;
                    }
                }




                W_OTHER_Paths = make_paths_from_queue(other);
                W_OTHER_Names = make_names_from_paths(W_OTHER_Paths);
                if (W_OTHER_Names.Length == 1)
                {
                    W_other_indic.BackColor = Color.Green;
                   W_otherName_CmBox.DataSource = W_OTHER_Names;
                    W_otherName_CmBox.BackColor = Color.PaleTurquoise;
                    W_other_Panel.Visible = true;
                    W_otherName_CmBox.Enabled = true;
                }
                else
                {
                    if (W_OTHER_Names.Length != 0)
                    {
                        W_other_indic.BackColor = Color.Green;
                        W_otherName_CmBox.DataSource = W_OTHER_Names;
                        W_otherName_CmBox.BackColor = Color.Yellow;
                        W_otherName_CmBox.Enabled = true;
                        W_other_Panel.Visible = false;
                    }
                    else
                    {
                        W_other_indic.BackColor = Color.Red;
                        W_otherName_CmBox.DataSource = null;
                        W_otherName_CmBox.BackColor = Color.Red;
                        W_otherName_CmBox.Enabled = false;
                        W_other_Panel.Visible = false;
                    }
                }



                ProgrammName_TBox.Text = "";


                string cp = "";
                if (W_XLS_Names != null)
                {
                    if (W_XLS_Names.Length > 0)
                    {
                       cp= get_path_from_cmBox(W_xlsName_CmBox, W_XLS_Names, W_XLS_Paths);
                    }

                }

                string name = DateTm.find_name(VL_TBox.Text,cp);
                if (name != "" && name != " " && name != "  ")
                {
                    ProgrammName_TBox.Text = name;
                }

                //if (W_XLS_Paths != null)
                //{
                //    if (W_XLS_Paths.Length != 0)
                //    {
                //        foreach (var document_path in W_XLS_Paths)
                //        {
                //            string name = DateTm.find_name( document_path);
                //            if (name != ""&&name != " "&&name != "  ")
                //            {
                //                ProgrammName_TBox.Text = name;
                //            }
                //        }
                //    }
                //}














            }
            else
            {
                WorkFolder_ChBox.Checked = false;
            }
        }

        public void prepare_stock()
        {
            Stock_GrBox.Enabled = true;
            var found_key = false;
            var Stock_All_Files_Paths = Directory.GetFiles(Ingest_Assistant.Properties.Settings.Default.Stock_Path, "*" + VL_TBox.Text.Substring(2) + "*");
            var files = new Queue();
            foreach (var  temp in Stock_All_Files_Paths)
            {
                if (Path.GetFileName(temp).Substring(0, 8).Contains(VL_Num) && Path.GetFileName(temp)[0] != '.' &&
                    (Path.GetExtension(temp) == ".mov" || Path.GetExtension(temp) == ".avi" || Path.GetExtension(temp) == ".mxf"))
                {
                    files.Enqueue(temp);
                    found_key = true;
                }
            }


            if (found_key)
            {
                S_MOV_Paths = new String[files.Count];
                S_MOV_Names = new String[files.Count];
                for (var i = 0; i < S_MOV_Paths.Length; i++)
                {
                    var temp = files.Dequeue().ToString();
                    S_MOV_Paths[i] = temp;
                    S_MOV_Names[i] = Path.GetFileName(temp);
                }
                S_openFile_But.Enabled = true;
                S_movName_CmBox.DataSource = S_MOV_Names;
                S_mov_indic.BackColor = Color.Green;
                S_mov_ChBox.Enabled = true;
                if (S_MOV_Paths.Length > 1)
                {
                    S_movName_CmBox.BackColor = Color.Yellow;
                }
                else
                {
                    S_movName_CmBox.BackColor = Color.PaleTurquoise;
                }
            }
            else
            {
                S_MOV_Path = "";
                S_openFile_But.Enabled = false;
                var noa = new string[1];
                noa[0] = "no files avalible";
                ;
                S_movName_CmBox.DataSource = noa;
                // S_movName_CmBox.BackColor = Color.Red;
                S_mov_indic.BackColor = Color.Red;
                S_mov_ChBox.Enabled = false;
            }
        }

        public void prepare_master()
        {
            Master_GrBox.Enabled = true;
            var found_key = false;
            var Master_All_Files_Paths = Directory.GetFiles(Ingest_Assistant.Properties.Settings.Default.Master_Path,"*"+VL_TBox.Text.Substring(2)+"*");
            var files = new Queue();
            foreach (var temp in Master_All_Files_Paths)
            {
                if (Path.GetFileName(temp).Substring(0, 6).Contains(VL_Num) && Path.GetFileName(temp)[0] != '.' &&
                    (Path.GetExtension(temp) == ".mov" || Path.GetExtension(temp) == ".avi" || Path.GetExtension(temp) == ".mxf"))
                {
                    files.Enqueue(temp);
                    found_key = true;
                }
            }


            if (found_key)
            {
                M_MOV_Paths = new String[files.Count];
                M_MOV_Names = new String[files.Count];
                for (var i = 0; i < M_MOV_Paths.Length; i++)
                {
                    var temp = files.Dequeue().ToString();
                    M_MOV_Paths[i] = temp;
                    M_MOV_Names[i] = Path.GetFileName(temp);
                }
                M_openFile_But.Enabled = true;
                M_movName_CmBox.DataSource = M_MOV_Names;
                M_mov_indic.BackColor = Color.Green;
                M_mov_ChBox.Enabled = true;
                if (M_MOV_Paths.Length > 1)
                {
                    M_movName_CmBox.BackColor = Color.Yellow;
                }
                else
                {
                    M_movName_CmBox.BackColor = Color.PaleTurquoise;
                }
            }
            else
            {
                M_MOV_Path = "";
                M_openFile_But.Enabled = false;
                var noa = new string[1];
                noa[0] = "no files avalible";
                ;
                M_movName_CmBox.DataSource = noa;
                // S_movName_CmBox.BackColor = Color.Red;
                M_mov_indic.BackColor = Color.Red;
                M_mov_ChBox.Enabled = false;
            }
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

        

        private void W_openFile_But_Click(object sender, EventArgs e)
        {
            if (W_txt_RBut.Checked) Process.Start(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths));
            if (W_xml_RBut.Checked) Process.Start(get_path_from_cmBox(W_xmlName_CmBox, W_XML_Names, W_XML_Paths));
            if (W_xls_RBut.Checked) Process.Start(get_path_from_cmBox(W_xlsName_CmBox, W_XLS_Names, W_XLS_Paths));
            if (W_fcp_RBut.Checked) Process.Start(get_path_from_cmBox(W_fcpName_CmBox, W_FCP_Names, W_FCP_Paths));
            if (W_mov_RBut.Checked) Process.Start(get_path_from_cmBox(W_movName_CmBox, W_MOV_Names, W_MOV_Paths));
            if (W_ref_RBut.Checked) Process.Start(get_path_from_cmBox(W_refName_CmBox, W_RTF_Names, W_RTF_Paths));
        }

        private void A_openFile_But_Click(object sender, EventArgs e)
        {
            if (A_xml_RBut.Checked) Process.Start(get_path_from_cmBox(A_xmlName_CmBox, A_XML_Names, A_XML_Paths));
            if (A_xls_RBut.Checked) Process.Start(get_path_from_cmBox(A_xlsName_CmBox, A_XLS_Names, A_XLS_Paths));
            if (A_fcp_RBut.Checked) Process.Start(get_path_from_cmBox(A_fcpName_CmBox, A_FCP_Names, A_FCP_Paths));
        }

        private void M_openFile_But_Click(object sender, EventArgs e)
        {
            Process.Start(M_MOV_Path);
        }

        private void S_openFile_But_Click(object sender, EventArgs e)
        {
            Process.Start(get_path_from_cmBox(S_movName_CmBox, S_MOV_Names, S_MOV_Paths));
           // "\\"
        }

        private void Consolidate_But_Click(object sender, EventArgs e)
        {
            long ST=Log_Class.VAction(VL_TBox.Text, "Консолидация файлов СТАРТ",4);
            if (Directory.Exists( (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text)))
            {
                int variant = Consolidate_Ask_Form.Ask_Question(this);
                if (variant == 4) goto END;

                if (variant==1||variant==2)
                {
                    var way =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
                    var indexed_old_name = way + "-old";
                    



                    if (Directory.Exists(indexed_old_name))
                    {
                        Log_Class.VAction(VL_TBox.Text, "Обнаружена папка с индексом old. Производим удление даной папки. СТАРТ",3);
                      
                        string[] fls = Directory.GetFiles(indexed_old_name);
                        foreach (string tmp in fls)
                        {
                            FileM.Delete(tmp);
                            Log_Class.Delete(VL_TBox.Text,tmp);
                        }
                        try
                        {
                            DirectoryM.Delete(indexed_old_name);
                            Log_Class.Delete_Dir(VL_TBox.Text, indexed_old_name);
                        }
                        catch (Exception)
                        {

                        }
                        
                        Log_Class.VAction(VL_TBox.Text, "Обнаружена папка с индексом old. Производим удление даной папки. СТОП",3);
                    }



                    DirectoryM.Move(way, indexed_old_name);
                    Log_Class.Move(VL_TBox.Text, way, indexed_old_name);
                    
                    var mas = Directory.GetFiles(indexed_old_name);

                    DirectoryM.CreateDirectory(way);
                    Log_Class.Create_Dir(VL_TBox.Text, way);
                    
                    
                    if (variant==1)
                    {
                        foreach (var tm in mas)
                        {
                            try
                            {
                                FileM.Move(tm,  (way + "\\" + Path.GetFileName(tm)));
                                Log_Class.Move(VL_TBox.Text, tm,  (way + "\\" + Path.GetFileName(tm)));
                            }
                            catch (Exception moveException)
                            {
                                MessageBox.Show(moveException.ToString());
                            }
                        }
                    }
                    else
                    {
                        foreach (var tm in mas)
                        {
                            try
                            {
                                FileM.Delete(tm);
                                Log_Class.Delete(VL_TBox.Text, tm);
                            }
                            catch (Exception delException)
                            {
                                MessageBox.Show(delException.ToString());
                            }
                        }
                    }

                    try
                    {
                        DirectoryM.Delete(indexed_old_name);
                        Log_Class.Delete_Dir(VL_TBox.Text, indexed_old_name);
                    }
                    catch (Exception)
                    {

                    }

                    
                    Log_Class.Delete_Dir(VL_TBox.Text, indexed_old_name);
                    var dotfile =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + "._" + VL_TBox.Text);
                    if (File.Exists(dotfile))
                    {
                        FileM.Delete(dotfile);
                        Log_Class.Delete(VL_TBox.Text, dotfile);
                    }
                    
                }
            }
            else
            {
                DirectoryM.CreateDirectory( (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text));
                Log_Class.Create_Dir(VL_TBox.Text,  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text));
            }


            try
            {
                Indicator_PicBox.Image = Image.FromFile( (Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\"+"SPF-move.jpg"));
            }
            catch
            {
                Indicator_PicBox.Image = Resources.error;
            }
            Indicator_PicBox.Visible = true;
            Refresh();


            if (W_FolderExists_ChBox.Checked)
            {
                Consolidate_Files();
            }
            else
            {
                DirectoryM.CreateDirectory( (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text));
                Log_Class.Create_Dir(VL_TBox.Text,  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text));
                Consolidate_Files();
            }
            Indicator_PicBox.Visible = false;


            if (!AllFolder_ChBox.Checked && !WorkFolder_ChBox.Checked)
            {
                WorkFolder_ChBox.Checked = true;
            }
            ChBox_Clear();
            load_info();

            END:
           long STOP= Log_Class.VAction(VL_TBox.Text, "Консолидация файлов СТОП",4);
            Log_Class.ReWrite_Start(ST,STOP);
        }

        private void Consolidate_Files()
        {
            prepare_work();
            var change_all = false;
            cpy = FileCopyForm.Form_init(VL_TBox.Text);
            if (A_xls_ChBox.Checked)
            {
                transport_Files_A_to_W(get_path_from_cmBox(A_xlsName_CmBox, A_XLS_Names, A_XLS_Paths));
            }
            else
            {
                if (C_xls_ChBOx.Checked)
                {
                    var ready_sxls_path = prepare_Shablon( (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text));
                    transport_Shablon(ready_sxls_path);
                }
            }

            if (A_fcp_ChBox.Checked)
            {
                transport_Files_A_to_W(get_path_from_cmBox(A_fcpName_CmBox, A_FCP_Names, A_FCP_Paths));
            }
            else
            {
                if (C_fcp_ChBox.Checked)
                {
                    var dest_path =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text + "\\" + VL_TBox.Text +
                                    ".fcp");
                    var way =  (Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\" + "FCP.fcp");
                    if (File.Exists(way))
                    {
                        if (File.Exists(dest_path))
                        {
                            dest_path =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text + "\\" + VL_TBox.Text +
                                        "-shablon" +
                                        ".fcp");
                            if (File.Exists(dest_path))
                            {
                                FileM.Delete(dest_path);
                                Log_Class.Delete(VL_TBox.Text, dest_path);
                            }

                            cpy.Add_File(way, dest_path);
                        }
                        else
                        {
                            cpy.Add_File(way, dest_path);
                        }
                    }
                }
            }


            if (S_mov_ChBox.Checked)
            {
                
                transport_Files(get_path_from_cmBox(S_movName_CmBox, S_MOV_Names, S_MOV_Paths), "stock");
            }
            if (M_mov_ChBox.Checked)
            {
              
                transport_Files(M_MOV_Path, "master");
            }
            if (A_xml_ChBox.Checked)
            {
                
                transport_Files_A_to_W(get_path_from_cmBox(A_xmlName_CmBox, A_XML_Names, A_XML_Paths));
            }


            if (cntr != null)
            {
                string[] files = cntr.get_selected_files_paths();
                for (int i = 0; i < files.Length; i++)
                {
                    string dest = Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]);
                    string full_dest = dest + Path.GetExtension(files[i]);

                    if (!File.Exists(full_dest))
                    {
                        cpy.Add_File(files[i], full_dest);
                    }
                    else
                    {
                        for (int j = 2; j < 10; j++)
                        {
                            full_dest = dest + "_" + j + Path.GetExtension(files[i]);
                            if (!File.Exists(full_dest))
                            {
                                cpy.Add_File(files[i], full_dest);
                                break;
                            }

                        }
                    }
                }
            }
            


            cpy.Start_Copy();
            cpy = null;
        }

        private string prepare_Shablon(string destination_path)
        {
            pre_copy:
            try
            {
                if (File.Exists( (destination_path + "\\" + "xls.xml")))
                {
                    FileM.Delete( (destination_path + "\\" + "xls.xml"));
                    Log_Class.Delete(VL_TBox.Text,  (destination_path + "\\" + "xls.xml"));
                }

                FileM.Copy( (Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\" + "xls.xml"),
                    (destination_path + "\\" + "xls.xml"));
                Log_Class.Copy(VL_TBox.Text,  (Ingest_Assistant.Properties.Settings.Default.Shablon_Path + "\\" + "xls.xml"),
                    (destination_path + "\\" + "xls.xml"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
               
                 //   "Сохраните все жокументы открытые программой XML Editor. \n После нажатия на ОК программа аварийно закроет все копии программы Xml Editor на данном компьютере. Если вы видите эту ошибку два и более раза, то рекомендуется перезапустить компьютер.");
               goto pre_copy;
            }
         
            
            string cur_path =  (destination_path + "\\" + "xls.xml");
            XML_Class.set_one_param("ID_ViPlanner", cur_path, VL_TBox.Text,"string");

            if (S_mov_ChBox.Checked && M_mov_ChBox.Checked)
            {
                XML_Class.set_one_param("Reel ID", cur_path, "", "string");
            }
            else
            {
                if (S_mov_ChBox.Checked)
                {
                   // m_workSheet.Cells[7, 2] = "Point Master STOCK";
                    XML_Class.set_one_param("I_Carier", cur_path, "Файл из Stock", "string");
                    XML_Class.set_one_param("Reel ID", cur_path, S_movName_CmBox.SelectedValue.ToString(), "string");
                   
                }
                if (M_mov_ChBox.Checked)

                {


                    XML_Class.set_one_param("I_Carier", cur_path, "Файл из MasterPrep", "string");
                    XML_Class.set_one_param("Reel ID", cur_path, M_movName_CmBox.SelectedValue.ToString(), "string");
                }
            }


            if (A_xml_ChBox.Checked)
            {
                var xml_way = get_path_from_cmBox(A_xmlName_CmBox, A_XML_Names, A_XML_Paths);
                var Description = File_Comands.Find_From_XML(xml_way, "Description");
                if (Description != "" || Description != " ") XML_Class.set_one_param("Title", cur_path, Description, "string");
            }










            if (W_TXT_Names != null)
            {
                if (W_TXT_Names.Length != 0)
                {
                    if (File.Exists(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths)))
                    {
                        var name =
                            File_Comands.Find_From_TXT(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths), 6);
                        var duration =
                            File_Comands.Find_From_TXT(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths), 1);
                        var reel_id =
                            File_Comands.Find_From_TXT(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths),
                                18);
                        XML_Class.set_one_param("Duration", cur_path, duration, "string");
                        XML_Class.set_one_param("Title", cur_path, name, "string");
                        XML_Class.set_one_param("Reel ID", cur_path, reel_id, "string");
                    }
                }
            }

          
            return cur_path;
        }

       
        private void transport_Shablon(string file_path)
        {
            var wp =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
            var dest_path = ""; 

            dest_path =  (wp + "\\" + VL_TBox.Text +""+
                        Path.GetExtension(file_path));
            if (File.Exists(dest_path))
            {
                dest_path =  (wp + "\\" + VL_TBox.Text+ "" + '-' + "shablon" +
                            Path.GetExtension(file_path));
                if (File.Exists(dest_path))
                {
                    FileM.Delete(dest_path);
                    Log_Class.Delete(VL_TBox.Text, dest_path);
                }
                FileM.Move(file_path, dest_path);
                Log_Class.Move(VL_TBox.Text, file_path, dest_path);
            }
            else
            {
                FileM.Move(file_path, dest_path);
                Log_Class.Move(VL_TBox.Text, file_path, dest_path);
            }
        }

        private void transport_Files(string file_path, string postfix)
        {
            var wp =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
            var dest_path =  (wp + "\\" + Path.GetFileName(file_path));
            dest_path =  (wp + "\\" + Path.GetFileNameWithoutExtension(file_path) + '-' + postfix +
                        Path.GetExtension(file_path));
            if (File.Exists(dest_path))
            {
                
                if (Ask_MessageBOX.Ask_Question("Заменить файл:" + Path.GetFileName(dest_path)))
                {
                   
                    FileM.Delete(dest_path);
                    Log_Class.Delete(VL_TBox.Text, dest_path);
                    cpy.Add_File(file_path, dest_path);
                }
            }
            else
            {
                cpy.Add_File(file_path, dest_path);
            }
        }

        private void transport_Files_A_to_W(string file_path)
        {

            var wp =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
            var ext = Path.GetExtension(file_path);
            var dest_path = "";


            if (Path.GetFileName(file_path).Contains("#"))
            {
                if (true)
                {
                    var pos = Path.GetFileName(file_path).IndexOf('#');
                    var temp = Path.GetFileName(file_path).Substring(0, pos);
                  
                     dest_path = wp + "\\" + temp + ext;
                }
                
            }
            else
            {
                dest_path = wp + "\\" + Path.GetFileNameWithoutExtension(file_path)
                            + ext;
            }


            if (File.Exists(dest_path))
            {
                var DRes =Ask_MessageBOX.Ask_Question("Заменить файл:" + Path.GetFileName(dest_path));
                if (DRes )
                {
                    try
                    {
                        FileM.Delete(dest_path);
                        Log_Class.Delete(VL_TBox.Text, dest_path);
                        cpy.Add_File(file_path, dest_path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка прав доступа к файлу: " + Path.GetFileName(file_path));
                    }
                }
            }
            else
            {
                try
                {
                    cpy.Add_File(file_path, dest_path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка прав доступа к файлу: " + Path.GetFileName(file_path));
                }
            }
        }

        private void transport_Files_ToArchive(string file_path)
        {
            var wp =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text);
            var ext = Path.GetExtension(file_path);
            var dest_path = "";
            if (Path.GetFileName(file_path).Contains("#"))
            {
                var pos = Path.GetFileName(file_path).IndexOf('#');
                var temp = Path.GetFileName(file_path).Substring(0, pos + 1);
               
                dest_path =  (wp + "\\" + temp  + DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss") + " " + ext);
            }
            else
            {
                dest_path =  (wp + "\\" + Path.GetFileNameWithoutExtension(file_path) + "#" +
                            DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss") + "" + ext);
            }


            if (File.Exists(dest_path))
            {
                var DRes = Ask_MessageBOX.Ask_Question("Заменить файл:" + Path.GetFileName(dest_path));
                if (DRes )
                {
                    var er = false;
                    try
                    {
                        FileM.Delete(dest_path);
                        Log_Class.Delete(VL_TBox.Text, dest_path);
                        FileM.Move(file_path, dest_path);
                        Log_Class.Move(VL_TBox.Text, file_path, dest_path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка прав доступа к файлу: " + Path.GetFileName(file_path) + '\n' +
                                        "Вместо перемещения будет выполнена операция копирования");

                        er = true;
                    }

                    if (er)
                    {
                        FileM.Copy(file_path, dest_path);
                        Log_Class.Copy(VL_TBox.Text, file_path, dest_path);
                    }
                }
            }
            else
            {
                var er = false;
                try
                {
                    FileM.Move(file_path, dest_path);
                    Log_Class.Move(VL_TBox.Text, file_path, dest_path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка прав доступа к файлу: " + Path.GetFileName(file_path) + '\n' +
                                    "Вместо перемещения будет выполнена операция копирования");
                    er = true;
                }


                if (er)
                {
                    FileM.Copy(file_path, dest_path);
                    Log_Class.Copy(VL_TBox.Text, file_path, dest_path);
                }
            }
        }

        private void check_format()
        {
           // string cur = VL_TBox.Text;
            //for (int i = 0; i < SRC_Short.Length; i++)
            //{
            //    if (cur == SRC_Short[i])
            //    {
            //        VL_TBox.Text = SRC_Full[i];
            //    }
            //}
            
            
            
            
            
            var erors = false;

            for (var i = 0; i < 2; i++)
            {
                int cur_ansi = VL_TBox.Text[i];
                if (!(cur_ansi < 91 && cur_ansi > 64))
                {
                    erors = true;
                }
            }
            for (var i = 2; i < 8; i++)
            {
                int cur_ansi = VL_TBox.Text[i];
                if (!(cur_ansi < 58 && cur_ansi > 47))
                {
                    erors = true;
                }
            }








            if (erors)
            {
                VLNum.Enabled = false;
                Confirm_Spec_Restart.Enabled = false;
            }
            else
            {
                VLNum.Enabled = true;
                Confirm_Spec_Restart.Enabled = true;
            }

            
        }

       

        private void VL_TBox_TextChanged_1(object sender, EventArgs e)
        {
            var temp = VL_TBox.Text;
            temp = temp.ToUpper();
            VL_TBox.Text = temp;
            VL_TBox.SelectionStart = VL_TBox.Text.Length;
            //if (VL_TBox.Text.Length == 6 &&last_pressed == '\n')
            //{
            //    string cur = VL_TBox.Text;
            //    for (int i = 0; i < SRC_Short.Length; i++)
            //    {
            //        if (cur == SRC_Short[i])
            //        {
            //            VL_TBox.Text = SRC_Full[i];
            //        }
            //    }
            //}
            if (VL_TBox.Text.Length == 8)
            {
                check_format();
            }
            else
            {
                VLNum.Enabled = false;
                Confirm_Spec_Restart.Enabled = false;
            }
        }

      


        private void AllFolder_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllFolder_ChBox.Checked)
            {
                WorkFolder_ChBox.Checked = false;
                ArchiveFolder_ChBox.Checked = false;
                StockFolder_ChBox.Checked = false;
                MasterFolder_ChBox.Checked = false;
            }
        }

        private void WorkFolder_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WorkFolder_ChBox.Checked)
            {
                AllFolder_ChBox.Checked = false;
            }
        }

        private void ArchiveFolder_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ArchiveFolder_ChBox.Checked)
            {
                AllFolder_ChBox.Checked = false;
            }
        }

        private void MasterFolder_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MasterFolder_ChBox.Checked)
            {
                AllFolder_ChBox.Checked = false;
            }
        }

        private void StockFolder_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StockFolder_ChBox.Checked)
            {
                AllFolder_ChBox.Checked = false;
            }



            SQL_Class cl=new SQL_Class();
       


        }





        




        private void File_Work_Load(object sender, EventArgs e)
        {
           long START = Log_Class.Action("Запуск стартовой формы. СТАРТ",3);
            var queue = new Queue<string>();
            var files = Directory.GetDirectories(Ingest_Assistant.Properties.Settings.Default.Work_Path);
            for (var i = 0; i < files.Count(); i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            var src = new AutoCompleteStringCollection();
            src.AddRange(files);

            files = Directory.GetDirectories(Ingest_Assistant.Properties.Settings.Default.Archive_Path);
            for (var i = 0; i < files.Count(); i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            src.AddRange(files);

            SRC_Full = new string[src.Count];
            SRC_Short = new string[src.Count];
            for (int i = 0; i <SRC_Full.Length; i++)
            {
                SRC_Full[i] = src[i];
                if (src[i].Length >= 8) SRC_Short[i] = src[i].Substring(2);
                else SRC_Short[i] = src[i];
            }
            
            src.AddRange(SRC_Short);
            VL_TBox.AutoCompleteCustomSource = src;


            Work_GrBox.Text="Рабочая директория  "+SQL_Class.ReadValueString("Select Name from settings where ID=" + Properties.Settings.Default.Profile_ID,
                Properties.Settings.Default.Setting_Base_Path);


            long stop=Log_Class.Action("Запуск стартовой формы. СТОП",3);
            Log_Class.ReWrite_Start(START,stop);
        }

        public void psi_arch_but_click()
        {
            long start =Log_Class.VAction(VL_TBox.Text, "Архивирование файлов СТАРТ",3);
            Indicator_PicBox.Image = Image.FromFile( (Ingest_Assistant.Properties.Settings.Default.Shablon_Path +"\\" +"SPF-move.jpg"));
            Indicator_PicBox.Visible = true;
            Refresh();

            var ViPlanner = VL_Perfix + VL_Num;
            var Dir_Path =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + ViPlanner);
            if (Directory.Exists(Dir_Path))
            {
                var old_path = Dir_Path + "-old";
                DirectoryM.Move(Dir_Path, old_path);
                Log_Class.Move(VL_TBox.Text, Dir_Path, old_path);
                DirectoryM.CreateDirectory(Dir_Path);
                Log_Class.Create_Dir(VL_TBox.Text, Dir_Path);
                var files = Directory.GetFiles(old_path);

                foreach (var temp in files)
                {
                    FileM.Move(temp,  (Dir_Path + "\\" + Path.GetFileName(temp)));
                    Log_Class.Move(VL_TBox.Text, temp,  (Dir_Path + "\\" + Path.GetFileName(temp)));
                }

                DirectoryM.Delete(old_path);
                Log_Class.Delete_Dir(VL_TBox.Text, old_path);
            }
            else
            {
                DirectoryM.CreateDirectory(Dir_Path);
                Log_Class.Create_Dir(VL_TBox.Text, Dir_Path);
            }
            if (W_XML_Names != null)
            {
                if (W_XML_Names.Length != 0)
                    transport_Files_ToArchive(get_path_from_cmBox(W_xmlName_CmBox, W_XML_Names, W_XML_Paths));
            }
            if (W_XLS_Names != null)
            {
                if (W_XLS_Names.Length != 0)
                    transport_Files_ToArchive(get_path_from_cmBox(W_xlsName_CmBox, W_XLS_Names, W_XLS_Paths));
            }
            if (W_FCP_Names != null)
            {
                if (W_FCP_Names.Length != 0)
                {
                    transport_Files_ToArchive(get_path_from_cmBox(W_fcpName_CmBox, W_FCP_Names, W_FCP_Paths));
                }
            }
            Indicator_PicBox.Visible = false;
            if (!AllFolder_ChBox.Checked && !ArchiveFolder_ChBox.Checked)
            {
                ArchiveFolder_ChBox.Checked = true;
            }
           long stop= Log_Class.VAction(VL_TBox.Text, "Архивирование файлов СТОП",3);
            Log_Class.ReWrite_Start(start,stop);
            load_info();
        }

        private void Archive_But_Click(object sender, EventArgs e)
        {
            long start=Log_Class.VAction(VL_TBox.Text, "Ручное архивирование СТАРТ",4);
            psi_arch_but_click();
           
            long stop=Log_Class.VAction(VL_TBox.Text, "Ручное архивирование СТОП",4);
            Log_Class.ReWrite_Start(start, stop);
            load_info();
        }

        private void del_start()
        {
            VLNum.Enabled = false;
            W_consolidate_panel.Visible = false;
            Master_GrBox.Enabled = false;
            Stock_GrBox.Enabled = false;
            Consolidate_GrBox.Enabled = false;
            Form_restart_but.Enabled = false;

            Del_Start_But.Visible = false;
            Del_Fin_But.Visible = true;
            Del_Cancel_But.Visible = true;
            w_c_label.Visible = false;
            w_d_label.Visible = true;
            a_c_label.Visible = false;
            a_d_label.Visible = true;
        }

        private void del_fin()
        {
            VLNum.Enabled = true;
            W_consolidate_panel.Visible = true;
            Master_GrBox.Enabled = true;
            Stock_GrBox.Enabled = true;
            Consolidate_GrBox.Enabled = true;
            Form_restart_but.Enabled = true;

            Del_Start_But.Visible = true;
            Del_Fin_But.Visible = false;
            Del_Cancel_But.Visible = false;

            w_c_label.Visible = true;
            w_d_label.Visible = false;
            a_c_label.Visible = true;
            a_d_label.Visible = false;
        }

        private void ChBox_Clear()
        {
            W_txt_ChBox.Checked = false;
            W_xml_ChBox.Checked = false;
            W_xls_ChBox.Checked = false;
            W_fcp_ChBox.Checked = false;
            W_mov_ChBox.Checked = false;
            W_ref_ChBox.Checked = false;
            A_fcp_ChBox.Checked = false;
            A_xml_ChBox.Checked = false;
            A_xls_ChBox.Checked = false;
            M_mov_ChBox.Checked = false;
            S_mov_ChBox.Checked = false;
        }

        private void Del_Start_But_Click(object sender, EventArgs e)
        {
            del_start();
        }

        private void Del_Cancel_But_Click(object sender, EventArgs e)
        {
            del_fin();
        }

        private void Del_Fin_But_Click(object sender, EventArgs e)
        {
            if ( Ask_MessageBOX.Ask_Question("Delete?"))
            {
                Delete_Files();
                del_fin();
                ChBox_Clear();
                load_info();
            }
        }

        private void Delete_Files()
        {
            long start=Log_Class.VAction(VL_TBox.Text, "Ручное удаление файлов СТАРТ",4);

            var del_stack = new Queue<string>();
            var del_info = "Будут удалены следующие файлы:" + '\n';
            if (W_txt_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths));
            if (W_xml_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_xmlName_CmBox, W_XML_Names, W_XML_Paths));
            if (W_xls_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_xlsName_CmBox, W_XLS_Names, W_XLS_Paths));
            if (W_fcp_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_fcpName_CmBox, W_FCP_Names, W_FCP_Paths));
            if (W_mov_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_movName_CmBox, W_MOV_Names, W_MOV_Paths));
            if (W_ref_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_refName_CmBox, W_RTF_Names, W_RTF_Paths));
            if (A_xml_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(A_xmlName_CmBox, A_XML_Names, A_XML_Paths));
            if (A_xls_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(A_xlsName_CmBox, A_XLS_Names, A_XLS_Paths));
            if (A_fcp_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(A_fcpName_CmBox, A_FCP_Names, A_FCP_Paths));
            if (W_TEKOM_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_TEKOMName_CmBox, W_TEKOM_Names, W_TEKOM_Paths));
            if (W_other_ChBox.Checked) del_stack.Enqueue(get_path_from_cmBox(W_otherName_CmBox, W_OTHER_Names, W_OTHER_Paths));


            foreach (var temp in del_stack)
            {
                del_info += Path.GetFileName(temp) + '\n';
            }

            if (Ask_MessageBOX.Ask_Question(del_info))
            {
                foreach (var temp in del_stack)
                {
                    try
                    {
                        if (File.Exists(temp))
                        {
                            FileM.Delete(temp);
                            Log_Class.Delete(VL_TBox.Text, temp);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка прав доступа к файлу: " + Path.GetFileName(temp));
                    }
                }
            }
           long stop= Log_Class.VAction(VL_TBox.Text, "Ручное удаление файлов СТОП",4);
           Log_Class.ReWrite_Start(start, stop);
        }

        private void work_folder_del_but_Click(object sender, EventArgs e)
        {
            long start=Log_Class.VAction(VL_TBox.Text, "Ручное удаление рабочей папки СТАРТ",4);
            if ( Ask_MessageBOX.Ask_Question("Delete?"))
            {
                var way =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
                var mas = Directory.GetFiles(way);
                foreach (var tm in mas)
                {
                    FileM.Delete(tm);
                    Log_Class.Delete(VL_TBox.Text, tm);
                }
                DirectoryM.Delete(way);
                Log_Class.Delete_Dir(VL_TBox.Text, way);

                var dotfile =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + "._" + VL_TBox.Text);
                if (File.Exists(dotfile))
                {
                    FileM.Delete(dotfile);
                    Log_Class.Delete(VL_TBox.Text, dotfile);
                }


                del_fin();
                ChBox_Clear();
               long stop= Log_Class.VAction(VL_TBox.Text, "Ручное удаление рабочей папки СТОП",4);
               Log_Class.ReWrite_Start(start, stop);
                load_info();
            }
        }

        private void archive_folder_del_but_Click(object sender, EventArgs e)
        {
           long start= Log_Class.VAction(VL_TBox.Text, "Ручное удаление архивной папки СТАРТ",4);
            if (Ask_MessageBOX.Ask_Question("Delete?"))
            {
                var way =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text);
                var mas = Directory.GetFiles(way);
                foreach (var tm in mas)
                {
                    FileM.Delete(tm);
                    Log_Class.Delete(VL_TBox.Text, tm);
                }
                DirectoryM.Delete(way);
                Log_Class.Delete_Dir(VL_TBox.Text, way);
                var dotfile =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + "._" + VL_TBox.Text);
                if (File.Exists(dotfile))
                {
                    FileM.Delete(dotfile);
                    Log_Class.Delete(VL_TBox.Text, dotfile);
                }

                del_fin();
                ChBox_Clear();
             long stop=   Log_Class.VAction(VL_TBox.Text, "Ручное удаление архивной папки СТОП",4);
             Log_Class.ReWrite_Start(start, stop);
                load_info();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Browser_Form=new Browser(this);
            // Browser_Form.Show();
            // Browser.Browser_Files_Form_Lauch(this,parent_height);
        }

        private void dust_cleaner_but_Click(object sender, EventArgs e)
        {
            var cur_dust = dust_collecter();
            if (dust_messanger(cur_dust)) dust_cleaner(cur_dust);
        }

        private string[] dust_collecter()
        {
            var dust = new string[0];

            var way = "";
            string[] temp;
            //work

            if (Directory.Exists( (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text)))
            {
                way =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
                temp = Directory.GetFiles(way);
                for (var i = 0; i < temp.Length; i++)
                {
                    if (Path.GetFileName(temp[i])[0] == '.')
                    {
                        Array.Resize(ref dust, dust.Length + 1);
                        dust[dust.Length - 1] = temp[i];
                    }
                }
            }
            //archive
            if (Directory.Exists( (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text)))
            {
                way =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text);
                temp = Directory.GetFiles(way);
                for (var i = 0; i < temp.Length; i++)
                {
                    if (Path.GetFileName(temp[i])[0] == '.')
                    {
                        Array.Resize(ref dust, dust.Length + 1);
                        dust[dust.Length - 1] = temp[i];
                    }
                }
            }


            return dust;
        }

        private Boolean dust_messanger(string[] dust)
        {
            var dst = "Будут удалены" + '\n';
            for (var i = 0; i < dust.Length; i++)
            {
                dst += Path.GetFileName(dust[i]) + '\n';
            }

            if (Ask_MessageBOX.Ask_Question(dst))
            {
                return true;
            }
            return false;
        }

        private void dust_cleaner(string[] dust)
        {
            for (var i = 0; i < dust.Length; i++)
            {
                try
                {
                    FileM.Delete(dust[i]);
                    Log_Class.Delete(VL_TBox.Text, dust[i]);
                }
                catch (Exception)
                {
                }
            }
        }

        private void File_Work_SizeChanged(object sender, EventArgs e)
        {
            if (Browser_Parent != null && Browser_Parent.WindowState == FormWindowState.Minimized &&
                WindowState != FormWindowState.Minimized)
            {
                Browser_Parent.WindowState = FormWindowState.Normal;
                Browser_Parent.Main_ReSize();
            }
        }

        private void W_movName_CmBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (W_movName_CmBox.SelectedValue != null)
            {
                var selection = W_movName_CmBox.SelectedValue.ToString();
                if (selection.Substring(selection.Length - 4) == ".avi")
                {
                    W_movName_CmBox.BackColor = Color.DeepPink;
                }
                else
                {
                    if (W_MOV_Names.Length == 1)
                    {
                        W_movName_CmBox.BackColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        W_movName_CmBox.BackColor = Color.Yellow;
                    }
                }
              
            }
        }

        private void Add_to_base_but_Click(object sender, EventArgs e)
        {
            Add_to_base_but.Enabled = false;
            if (W_XLS_Names != null)
            {
                if (W_XLS_Names.Length != 0)
                {
                    AddToBase.Form_Lauch(parent_height, VL_TBox.Text, this);
                    Thread.Sleep(3000);

                }
                else
                {
                    MessageBox.Show("Невозможно оформить работу, так как отсутствует файл документации");
                }
            }
            Add_to_base_but.Enabled = true;
            
        }

        private void W_txt_indic_Click(object sender, EventArgs e)
        {
            if (W_TXT_Names != null)
            {
                if (W_TXT_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_txtName_CmBox, W_TXT_Names, W_TXT_Paths));
            }
        }

        private void W_xml_indic_Click(object sender, EventArgs e)
        {
            if (W_XML_Names != null)
            {
                if (W_XML_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_xmlName_CmBox, W_XML_Names, W_XML_Paths));
            }
        }

        private void W_xls_indic_Click(object sender, EventArgs e)
        {
            
            if (W_XLS_Names != null)
            {
                if (W_XLS_Names.Length > 0)
                {
                    XML_Class.Open_XML_Editor(get_path_from_cmBox(W_xlsName_CmBox, W_XLS_Names, W_XLS_Paths));
                }

            }
        }

        private void W_fcp_indic_Click(object sender, EventArgs e)
        {
            if (A_FCP_Names != null)
            {
                if (W_FCP_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_fcpName_CmBox, W_FCP_Names, W_FCP_Paths));
            }
        }

        private void W_mov_indic_Click(object sender, EventArgs e)
        {
            if (W_MOV_Names != null)
            {
                if (W_MOV_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_movName_CmBox, W_MOV_Names, W_MOV_Paths));
            }
        }

        private void W_ref_indic_Click(object sender, EventArgs e)
        {
            if (W_RTF_Names != null)
            {
                if (W_RTF_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_refName_CmBox, W_RTF_Names, W_RTF_Paths));
            }
        }

        private void Restart_but_correection_Click(object sender, EventArgs e)
        {
            Confirm_Spec_Restart.Visible = true;
            Cancel_Spec_Relauch.Visible = true;
            VL_TBox.Enabled = true;
            Block_gr_Box.Enabled = false;
            Restart_but_correection.Visible = false;
        }

        private void Confirm_Spec_Restart_Click(object sender, EventArgs e)
        {
            Form_restart_but.Visible = true;
            Browser_Parent.File_Work_Restart_Special(VL_TBox.Text);
            Restart_but_correection.Visible = true;
        }

        private void Cancel_Spec_Relauch_Click(object sender, EventArgs e)
        {
            VL_TBox.Text = VL_Perfix + VL_Num;
            Confirm_Spec_Restart.Visible = false;
            Block_gr_Box.Enabled = true;
            Cancel_Spec_Relauch.Visible = false;
            Restart_but_correection.Visible = true;
        }

        private void A_xls_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (A_xls_ChBox.Checked)
            {
                C_xls_ChBOx.Checked = false;
            }
        }

        private void A_fcp_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (A_fcp_ChBox.Checked) C_fcp_ChBox.Checked = false;
        }

        private void C_xls_ChBOx_CheckedChanged(object sender, EventArgs e)
        {
            if (A_xls_ChBox.Checked)
            {
                C_xls_ChBOx.Checked = false;
            }
        }

        private void C_fcp_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (A_fcp_ChBox.Checked) C_fcp_ChBox.Checked = false;
        }

        private void M_movName_CmBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (M_MOV_Names != null && M_MOV_Names.Length != 0)
            {
                M_MOV_Path = get_path_from_cmBox(M_movName_CmBox, M_MOV_Names, M_MOV_Paths);
            }
        }

        private void Web_Form_Button_Click(object sender, EventArgs e)
        {
            if (Web_frm != null)
            {
                if (Web_frm.IsDisposed)
                {
                    Web_frm = null;
                    Web_Form_Button_Click(null,null);
                }
                else
                {
                    Console.Beep(4000, 100);
                    MessageBox.Show("Одна копия IShow уже запущена");
                }
              
                
            }
            else
            {
                Web_frm = new Web_Form();
                Web_Form.Form_Start_With_Parent(Web_frm, VL_TBox.Text);
                
            }
           
        }

        private void W_movName_CmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Media_Info_ChBox.Checked)
            {
                if (W_MOV_Names != null)
                {
                    if (W_MOV_Names.Length != 0)
                    {
                        Browser_Parent.Browser_Media_Info_load(get_path_from_cmBox(W_movName_CmBox, W_MOV_Names,
                            W_MOV_Paths));
                    }
                }
            }
        }

        private void Media_Info_ChBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Media_Info_ChBox.Checked)
            {
                if (W_MOV_Names != null)
                {
                    if (W_MOV_Names.Length != 0)
                    {
                        // ProgressForm.StartForm("Сбор информации");
                        var path = get_path_from_cmBox(W_movName_CmBox, W_MOV_Names, W_MOV_Paths);

                        Browser_Parent.Browser_Media_Info_load(path);
                        // ProgressForm.StopForm();
                    }
                }
            }
        }

        private void A_xml_indic_Click(object sender, EventArgs e)
        {
            if (A_XML_Names != null)
                if (A_XLS_Names.Length != 0)
                    Process.Start(get_path_from_cmBox(A_xmlName_CmBox, A_XML_Names, A_XML_Paths));
        }

        private void A_xls_indic_Click(object sender, EventArgs e)
        {
            if (A_XLS_Names != null)
            {
                if (A_XLS_Names.Length > 0)
                {
                    XML_Class.Open_XML_Editor(get_path_from_cmBox(A_xlsName_CmBox, A_XLS_Names, A_XLS_Paths));
                }

            } 
        }

        private void A_fcp_indic_Click(object sender, EventArgs e)
        {
            if (A_FCP_Names != null)
                if (A_FCP_Names.Length != 0)
                    Process.Start(get_path_from_cmBox(A_fcpName_CmBox, A_FCP_Names, A_FCP_Paths));
        }

        private void M_mov_indic_Click(object sender, EventArgs e)
        {
            if (M_MOV_Names != null)
                if (M_MOV_Names.Length != 0) Process.Start(M_MOV_Path);
        }

        private void S_mov_indic_Click(object sender, EventArgs e)
        {
            if (S_MOV_Names != null)
                if (S_MOV_Names.Length != 0)
                    Process.Start(get_path_from_cmBox(S_movName_CmBox, S_MOV_Names, S_MOV_Paths));
        }

        private void Open_W_Folder_But_Click(object sender, EventArgs e)
        {
            string path =  (Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        private void Open_A_Folder_But_Click(object sender, EventArgs e)
        {
            string path =  (Ingest_Assistant.Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text);
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        private void Move_To_Complete_But_Click(object sender, EventArgs e)
        {
            
            if (W_MOV_Names != null)
            {
                if (W_MOV_Names.Length != 0)
                {
                    if (Ask_MessageBOX.Ask_Question(
                            "Вы хотите перенести файл: " +
                            Path.GetFileName(get_path_from_cmBox(W_movName_CmBox, W_MOV_Names,
                                W_MOV_Paths)) + "  в папку Complete"))
                    {
                        if (Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Complete_Path))
                        {
                            var from = get_path_from_cmBox(W_movName_CmBox, W_MOV_Names,
                                W_MOV_Paths);
                            var dest =  (Ingest_Assistant.Properties.Settings.Default.Complete_Path + "\\" +
                                       Path.GetFileName(from));
                            if (File.Exists(dest))
                            {
                                MessageBox.Show("В папке Complete уже существует такой файл");
                            }
                            else
                            {
                                //ProgressForm.StartForm("");

                                FileM.Move(from, dest);
                                Log_Class.Move(VL_TBox.Text, from, dest);

                            }
                        }
                    }
                }
            }

            Browser_Parent.File_Work_Restart_Special(VL_TBox.Text);
        }

        private void Block_gr_Box_Enter(object sender, EventArgs e)
        {

        }

        private void Consolidate_DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Other_Consolidate_DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != -1 && cntr != null)
            {
                cntr.ReWrite_One_Selection(e.ColumnIndex, e.RowIndex);
            }

            if (e.ColumnIndex == 4 && e.RowIndex != -1 && cntr != null)
            {
                cntr.Open_File(e.ColumnIndex, e.RowIndex);
            }
        }

        private void Other_Consolidate_CmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Other_Consolidate_CmBox.DataSource != null && cntr != null) cntr.Change_Loaded_To_DGV_Files(Other_Consolidate_CmBox.SelectedIndex);
        }

        private void W_other_indic_Click(object sender, EventArgs e)
        {
            if (W_OTHER_Names != null)
            {
                if (W_OTHER_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_otherName_CmBox, W_OTHER_Names, W_OTHER_Paths));
            }
        }

        private void Open_Archive_Dir_But_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.Archive_Path + "\\" + VL_TBox.Text);
        }

        private void Open_Work_Dir_but_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.Work_Path + "\\" + VL_TBox.Text);
        }

        private void Consolidate_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1 && co != null)
            {
                co.Rewrite_One_Selection(e.ColumnIndex, e.RowIndex);
            }
            if (e.ColumnIndex == 3 && e.RowIndex != -1 && co != null)
            {
                Process.Start(co.Directory_Masive[e.RowIndex].Path);
            }
        }

        private void AllResult_GrBox_Enter(object sender, EventArgs e)
        {

        }

        private void W_TEKOM_indic_Click(object sender, EventArgs e)
        {
            if (W_TEKOM_Names != null)
            {
                if (W_TEKOM_Names.Length > 0)
                    Process.Start(get_path_from_cmBox(W_TEKOMName_CmBox, W_TEKOM_Names, W_TEKOM_Paths));
            }
        }

        private char last_pressed = '1';

        private void VL_TBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            //last_pressed = e.KeyChar;
            //if (VL_TBox.Text.Length == 6 && last_pressed == '\n')
            //{
            //    string cur = VL_TBox.Text;
            //    for (int i = 0; i < SRC_Short.Length; i++)
            //    {
            //        if (cur == SRC_Short[i])
            //        {
            //            VL_TBox.Text = SRC_Full[i];
            //        }
            //    }
            //}
        }

        private void VL_TBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (VL_TBox.Text.Length == 6 && e.KeyValue == 13)
            {
                string cur = VL_TBox.Text;
                for (int i = 0; i < SRC_Short.Length; i++)
                {
                    if (cur == SRC_Short[i])
                    {
                        VL_TBox.Text = SRC_Full[i];
                    }
                }
            }
        }

      
    }
}