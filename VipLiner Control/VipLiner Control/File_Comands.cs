using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Ingest_Assistant.Properties;


//using Excel = Microsoft.Office.Interop.Excel;

namespace Ingest_Assistant
{
    public class File_Comands
    {
        public string[] xlss;

        public static string Find_From_TXT(string path, int pos)
        {
            try
            {
                
                string line;
                var lines = File.ReadAllLines(path);
                line = lines[6];
                line = '\t' + line;
                var ishod = line.Split('\t');
                var temp = new Queue();
                for (var i = 0; i < ishod.Length; i++) if (ishod[i] != "") temp.Enqueue(ishod[i]);
                var vihod1 = new string[temp.Count];
                for (var i = 0; i < vihod1.Length; i++) vihod1[i] = Convert.ToString(temp.Dequeue());


                if (lines.Length == 12 && (pos == 1 || pos == 18))
                {
                    line = lines[9];
                    line = '\t' + line;
                    ishod = line.Split('\t');
                    temp = new Queue();
                    for (var i = 0; i < ishod.Length; i++) if (ishod[i] != "") temp.Enqueue(ishod[i]);
                    var vihod2 = new string[temp.Count];
                    for (var i = 0; i < vihod2.Length; i++) vihod2[i] = Convert.ToString(temp.Dequeue());


                    if (pos == 18)
                    {
                        return vihod1[pos] + "," + vihod2[pos];
                    }
                    var Duration = new TimeSpan(0, 0, 0);
                    var cadrs = 0;
                    var dur1 = vihod1[pos];
                    var hours = Convert.ToInt32(dur1.Substring(0, 2));
                    var minutes = Convert.ToInt32(dur1.Substring(3, 2));
                    var seconds = Convert.ToInt32(dur1.Substring(6, 2));
                    cadrs += Convert.ToInt32(dur1.Substring(9, 2));
                    Duration = Duration.Add(new TimeSpan(hours, minutes, seconds));

                    var dur2 = vihod2[pos];
                    hours = Convert.ToInt32(dur2.Substring(0, 2));
                    minutes = Convert.ToInt32(dur2.Substring(3, 2));
                    seconds = Convert.ToInt32(dur2.Substring(6, 2));
                    cadrs += Convert.ToInt32(dur2.Substring(9, 2));
                    Duration = Duration.Add(new TimeSpan(hours, minutes, seconds));


                    if (cadrs > 25)
                    {
                        cadrs -= 25;
                        Duration = Duration.Add(new TimeSpan(0, 0, 1));
                    }
                    var outt = Duration.ToString();
                    if (cadrs >= 10)
                    {
                        outt += ":" + cadrs;
                    }
                    else
                    {
                        outt += ":0" + cadrs;
                    }
                    return outt;
                }
                return vihod1[pos];
            }
            catch (Exception)
            {

                MessageBox.Show("Eror during trying to read txt file \n" + path + "\n Trying to read position " + pos +
                                "\n Bad txt format");
                return "BAD TXT FILE EROR!!!!";
            }
           
        }

        public static string Find_From_XML(string path, string str)
        {
            var sr = new StreamReader(path);
            String line;
            var text = "";
            while ((line = sr.ReadLine()) != null)
            {
                text += line;
            }
            var search = str; //Created By
            var inn = text.IndexOf(search);
            inn += search.Length + 19;
            inn++;
            var buf = "";
            while (text[inn] != '<')
            {
                buf += text[inn];
                inn++;
            }
           
            return buf;
        }

        public static string Find_From_XLS(string path, string str)
        {
            return XML_Class.get_one_param(str, path);
            //Application xlApp;
            //Workbook xlWorkBook;
            //Worksheet xlWorkSheet;
            //object misValue = Missing.Value;
            //var old_excels = Process.GetProcessesByName("EXCEL");
            //var old_excels_id = new Queue<string>();
            //foreach (var Pr in old_excels)
            //{
            //    old_excels_id.Enqueue(Pr.Id.ToString());
            //}
            //xlApp = new Application();

            //var pvw = xlApp.ProtectedViewWindows.Open(path);
            //xlWorkBook = pvw.Workbook;

            //xlWorkSheet = (Worksheet) xlWorkBook.Worksheets.get_Item(1);
            //var ret = "";
            
            //try
            //{
            //    ret = xlWorkSheet.get_Range(str, str).Value2.ToString();
            //}
            //catch (Exception e)
            //{
           
            //}
            //xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);

            //var new_excels = Process.GetProcessesByName("EXCEL");
            //foreach (var Pr in new_excels)
            //{
            //    if (!old_excels_id.Contains(Pr.Id.ToString())) Pr.Kill();
            //}

            //return ret;
        }

        public static Queue<XLS> Read_From_XLS_many_files(string path, Queue<XLS> mas_of_xls)
        {
            var out_mas = new Queue<XLS>();

            foreach (var curent in mas_of_xls)
            {
                var tmp = new XLS();
                tmp.name = curent.name;
                tmp.block = curent.block;
                try
                {
                    tmp.data =  XML_Class.get_one_param(tmp.block, path);
                }
                catch (Exception e)
                {
                    tmp.data = "";
                   
                }
                out_mas.Enqueue(tmp);
            }
            return out_mas;



            //Application xlApp;
            //Workbook xlWorkBook;
            //Worksheet xlWorkSheet;
            //object misValue = Missing.Value;


           
            //var old_excels = Process.GetProcessesByName("EXCEL");
            //var old_excels_id = new Queue<string>();
            //foreach (var Pr in old_excels)
            //{
            //    old_excels_id.Enqueue(Pr.Id.ToString());
            //}


            //try
            //{
          
            //    xlApp = new Application();
           
            //    var pvw = xlApp.ProtectedViewWindows.Open(path);
            //    xlWorkBook = pvw.Workbook;

            //    xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
            //}
            //catch (Exception e)
            //{
            
            //    goto EmerEmergensy_Skip;
            //}

            //foreach (var curent in mas_of_xls)
            //{
            //    var tmp = new XLS();
            //    tmp.name = curent.name;
            //    tmp.block = curent.block;
            //    try
            //    {
            //        tmp.data = xlWorkSheet.get_Range(curent.block, curent.block).Value2.ToString();
            //    }
            //    catch (Exception e)
            //    {
            //        tmp.data = "";
            
            //    }
            //    out_mas.Enqueue(tmp);
            //}


           
            //var new_excels = Process.GetProcessesByName("EXCEL");
            //foreach (var Pr in new_excels)
            //{
            //    if (!old_excels_id.Contains(Pr.Id.ToString()))
            //        Pr.Kill();
            //}

            ////xlWorkBook.Close(true);
            ////xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);


            //return out_mas;
            //EmerEmergensy_Skip:
            //out_mas = mas_of_xls;
            //return out_mas;
        }

        public static void Write_To_XLS_many_files_with_recopy(string path, XLS[] mas_of_xls, string VP)
        {
            var new_file = "";
            try
            {
                var temp_dir = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory;
                if (!Directory.Exists(temp_dir))
                {
                    DirectoryM.CreateDirectory(temp_dir);
                    Log_Class.Create_Dir(VP, temp_dir);
                }

                new_file = temp_dir + "\\" + Path.GetFileName(path);
                if (File.Exists(new_file))
                {
                    FileM.Delete(new_file);
                    Log_Class.Delete(VP, new_file);
                }
                FileM.Copy(path, new_file);
                Log_Class.Copy(VP, path, new_file);



                foreach (var curent in mas_of_xls)
                {
                    XML_Class.set_one_param(curent.block,new_file,curent.data,curent.type);
                }




                //Application xlApp = null;
                //Workbook xlWorkBook = null;
                //Worksheet xlWorkSheet = null;
                //object misValue = Missing.Value;


                //var old_excels = Process.GetProcessesByName("EXCEL");
                //var old_excels_id = new Queue<string>();
                //foreach (var Pr in old_excels)
                //{
                //    old_excels_id.Enqueue(Pr.Id.ToString());
                //}


                //xlWorkSheet = null;
                //try
                //{
                //    xlApp = new Application();

                //    xlApp.Workbooks.Open(new_file);
                //    xlWorkBook = xlApp.ActiveWorkbook;

                //    xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
                //}
                //catch (Exception e)
                //{
               
                //}

                //foreach (var curent in mas_of_xls)
                //{
                //    var row = 0;
                //    var col = 0;

                //    if (curent.block[0] == 'A') row = 1;
                //    if (curent.block[0] == 'B') row = 2;
                //    if (curent.block[0] == 'C') row = 3;
                //    if (curent.block[0] == 'D') row = 4;
                //    if (curent.block[0] == 'E') row = 5;
                //    col = Convert.ToInt32(curent.block.Substring(1));
                //    xlWorkSheet.Cells[col, row] = curent.data;
                //}

                //xlWorkBook.Save();


                //var new_excels = Process.GetProcessesByName("EXCEL");
                //foreach (var Pr in new_excels)
                //{
                //    if (!old_excels_id.Contains(Pr.Id.ToString()))
                //        Pr.Kill();
                //}


                //releaseObject(xlWorkSheet);
                //releaseObject(xlWorkBook);
                //releaseObject(xlApp);


                FileM.Delete(path);
                Log_Class.Delete(VP, path);
                FileM.Copy(new_file, path);
                Log_Class.Copy(VP, new_file, path);
                FileM.Delete(new_file);
                Log_Class.Delete(VP, new_file);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static Queue<XLS> Read_From_XLS_many_files_with_recopy(string path, Queue<XLS> mas_of_xls, string VP)
        {
            Queue<XLS> out_mas = null;
            var new_file = "";
            try
            {
                var temp_dir = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory;
                if (!Directory.Exists(temp_dir))
                {
                    DirectoryM.CreateDirectory(temp_dir);
                    Log_Class.Create_Dir(VP, temp_dir);
                }

                new_file = temp_dir + "\\" + Path.GetFileName(path);
                if (File.Exists(new_file))
                {
                    FileM.Delete(new_file);
                    Log_Class.Delete(VP, new_file);
                }

                FileM.Copy(path, new_file);
                Log_Class.Copy(VP, path, new_file);
                out_mas = new Queue<XLS>();



                foreach (var curent in mas_of_xls)
                {
                    var tmp = new XLS();
                    tmp.name = curent.name;
                    tmp.block = curent.block;
                    tmp.type = curent.type;
                    try
                    {
                        tmp.data = XML_Class.get_one_param(tmp.block, new_file);
                    }
                    catch (Exception e)
                    {
                        tmp.data = "";
                    }
                    out_mas.Enqueue(tmp);
                }




                //Application xlApp = null;
                //Workbook xlWorkBook = null;
                //Worksheet xlWorkSheet = null;
                //object misValue = Missing.Value;


                //var old_excels = Process.GetProcessesByName("EXCEL");
                //var old_excels_id = new Queue<string>();
                //foreach (var Pr in old_excels)
                //{
                //    old_excels_id.Enqueue(Pr.Id.ToString());
                //}


                //xlWorkSheet = null;
                //try
                //{
                //    xlApp = new Application();

                //    xlApp.Workbooks.Open(new_file);
                //    xlWorkBook = xlApp.ActiveWorkbook;

                //    xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
                //}
                //catch (Exception e)
                //{
               
                //}

                //foreach (var curent in mas_of_xls)
                //{
                //    var tmp = new XLS();
                //    tmp.name = curent.name;
                //    tmp.block = curent.block;
                //    try
                //    {
                //        tmp.data = xlWorkSheet.get_Range(curent.block, curent.block).Value2.ToString();
                //    }
                //    catch (Exception e)
                //    {
                //        tmp.data = "";
                
                //    }
                //    out_mas.Enqueue(tmp);
                //}


               
                //var new_excels = Process.GetProcessesByName("EXCEL");
                //foreach (var Pr in new_excels)
                //{
                //    if (!old_excels_id.Contains(Pr.Id.ToString()))
                //        Pr.Kill();
                //}

                ////xlWorkBook.Close(true);
                ////xlApp.Quit();

                //releaseObject(xlWorkSheet);
                //releaseObject(xlWorkBook);
                //releaseObject(xlApp);


                FileM.Delete(new_file);
                Log_Class.Delete(VP, new_file);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            return out_mas;
        }

       

        public struct XLS
        {
            public string block;
            public string data;
            public string name;
            public string type;
        }


    }
}