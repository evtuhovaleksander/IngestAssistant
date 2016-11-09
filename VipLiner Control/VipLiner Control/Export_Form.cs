using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ingest_Assistant.Properties;
using Microsoft.Office.Interop.Excel;

namespace Ingest_Assistant
{
    public partial class Export_Form : Form
    {

        private Boolean Allow_Work;
        public Export_Form()
        {
            InitializeComponent();
            Allow_Work = true;
        }

        private void Export_Form_Load(object sender, EventArgs e)
        {

        }

        public string Export(Base_Show.Big_Element[] Curent_Elements, string filters)
        {
            var new_file = "";
            ///  try
            {
                var temp_dir = Settings.Default.Temp_Files_Directory;
                if (!Directory.Exists(temp_dir))
                {
                    DirectoryM.CreateDirectory(temp_dir);
                    Log_Class.Create_Dir("Export Base", temp_dir);
                }

                new_file = temp_dir + "\\" + "Base-Export-" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".xls";
                string path = Settings.Default.Shablon_Path + "\\ExportXLS.xls";
                if (File.Exists(new_file))
                {
                    FileM.Delete(new_file);
                    Log_Class.Delete("Export Base", new_file);
                }
                FileM.Copy(path, new_file);
                Log_Class.Copy("Export Base", path, new_file);

                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Workbook xlWorkBook = null;
                Worksheet xlWorkSheet = null;

                var old_excels = Process.GetProcessesByName("EXCEL");
                var old_excels_id = new Queue<string>();
                foreach (var Pr in old_excels)
                {
                    old_excels_id.Enqueue(Pr.Id.ToString());
                }


                xlWorkSheet = null;
                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();

                    xlApp.Workbooks.Open(new_file);
                    xlWorkBook = xlApp.ActiveWorkbook;

                    xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    MessageBox.Show("Ошибка открытия Файла  " + new_file);
                }





                ProgreeBar.Value = 1;
                ProgreeBar.Maximum = Curent_Elements.Length + 2;
                Progress_Label.Text =( ProgreeBar.Value + "/" + Curent_Elements.Length);
                    Allow_Work = true;
                xlWorkSheet.Cells[2, 2].Value = filters;
                for (int i = 5; i < 5 + Curent_Elements.Length; i++)
                {
                    if (!Allow_Work) break;
                    Base_Show.Big_Element bt = Curent_Elements[i - 5];
                    draw_line(i, xlWorkSheet);
                    xlWorkSheet.Cells[i, 1].Value = bt.ID;
                    xlWorkSheet.Cells[i, 2].Value = bt.ViPlanner;
                    xlWorkSheet.Cells[i, 3].Value = bt.Title;
                    xlWorkSheet.Cells[i, 4].Value = bt.Data_Start;
                    xlWorkSheet.Cells[i, 5].Value = bt.Ingest_Start;
                    xlWorkSheet.Cells[i, 6].Value = bt.Ingest_End;
                    xlWorkSheet.Cells[i, 7].Value = bt.Ingest_Duration;
                    xlWorkSheet.Cells[i, 8].Value = bt.Render_Time;
                    xlWorkSheet.Cells[i, 9].Value = bt.Time_Of_Registration;
                    xlWorkSheet.Cells[i, 10].Value = bt.Total_Time;
                    xlWorkSheet.Cells[i, 11].Value = bt.Source_Duration;
                    xlWorkSheet.Cells[i, 12].Value = bt.Media_Type;
                    xlWorkSheet.Cells[i, 13].Value = bt.Reel_ID;
                    xlWorkSheet.Cells[i, 14].Value = bt.Efir_Date_From_Request;
                    xlWorkSheet.Cells[i, 15].Value = bt.Ingest_Line;
                    xlWorkSheet.Cells[i, 16].Value = bt.Ingest_Operator;
                    xlWorkSheet.Cells[i, 17].Value = bt.Format_IN;
                    xlWorkSheet.Cells[i, 18].Value = bt.Harris_IN;
                    xlWorkSheet.Cells[i, 19].Value = bt.Audio;
                    xlWorkSheet.Cells[i, 20].Value = bt.Dolby;
                    xlWorkSheet.Cells[i, 21].Value = bt.Edit_Line;
                    xlWorkSheet.Cells[i, 22].Value = bt.Operator;
                    xlWorkSheet.Cells[i, 23].Value = bt.Type_Of_Work;
                    xlWorkSheet.Cells[i, 24].Value = bt.Harris_OUT;
                    xlWorkSheet.Cells[i, 25].Value = bt.Format_OUT;
                    xlWorkSheet.Cells[i, 26].Value = bt.Card_Marks;
                    xlWorkSheet.Cells[i, 27].Value = bt.Info_Lost;
                    xlWorkSheet.Cells[i, 28].Value = bt.Notes;
                    xlWorkSheet.Cells[i, 29].Value = bt.Deleted;

                    string all_string = bt.Media_Info;
                    if (all_string.Length != 0)
                    {
                        string[] splited_info = all_string.Split(';');
                        for (int j = 0; j < splited_info.Length; j++)
                        {
                            if (splited_info[j].Length > 3)
                            {
                                string head = splited_info[j].Substring(0, splited_info[j].IndexOf('.'));
                                string body = splited_info[j].Substring(splited_info[j].IndexOf(':') + 2);
                                xlWorkSheet.Cells[i, 29 + 1 + j].Value = body;
                                xlWorkSheet.Cells[4, 29 + 1 + j].Value = head;
                            }
                        }
                    }




                    ProgreeBar.Value++;
                    Progress_Label.Text = (ProgreeBar.Value + "/" + Curent_Elements.Length);
                    Refresh();
                }











                xlWorkBook.Save();


                var new_excels = Process.GetProcessesByName("EXCEL");
                foreach (var Pr in new_excels)
                {
                    if (!old_excels_id.Contains(Pr.Id.ToString()))
                        Pr.Kill();
                }



                return new_file;


            }
           
        }

        public static void Main_Export(Base_Show.Big_Element[] Curent_Elements, string filters)
        {
            Export_Form frm= new Export_Form();
            string file_to_open = frm.Export(Curent_Elements, filters);
            frm.Close();
            try
            {
                if (File.Exists(file_to_open)) Process.Start(file_to_open);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }




        public  void draw_line(int id, Worksheet Sheet)
        {
            Sheet.get_Range("A" + id, "AJ" + id).Borders.ColorIndex = 0;
            Sheet.get_Range("A" + id, "AJ" + id).Borders.LineStyle = XlLineStyle.xlContinuous;
            Sheet.get_Range("A" + id, "AJ" + id).Borders.Weight = XlBorderWeight.xlThin;
        }

        private void Break_Button_Click(object sender, EventArgs e)
        {
            Allow_Work=false;
        }
    }
}
