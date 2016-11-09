using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public  class DirectoryM
    {
        
        public static void Move(string from, string to)
        {
            if (true)
            {
                try
                {
                    Directory.Move(from, to);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Move \n" + "Win mode" + "\n" + "from=" + from + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }

            }
            else
            {
                string too = Convert_Path(to);
                from = Convert_Path(from);

                try
                {
                    Directory.Move(from, too);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Move \n" + "MAC mode" + "\n" + "from=" + from + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }
            }
        }

        public static void CreateDirectory(string to)
        {
            if (true)
            {
                try
                {
                    
                    Directory.CreateDirectory(to);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create \n" + "Win mode" + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }

            }
            else
            {
                string too = Convert_Path(to);


                try
                {
                    Directory.CreateDirectory(too);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create \n" + "MAC mode" + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }
            }
        }

        public static void Delete(string to)
        {
            Directory.Delete(to);
            //if (true)
            //{
            //    try
            //    {
            //        Directory.Delete(to);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Delete \n" + "Win mode" + "\n" + "to=" + to + "\n" +
            //                        ex.ToString());
            //    }

            //}
            //else
            //{
            //    string too = Convert_Path(to);


            //    try
            //    {
            //        Directory.Delete(too);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Delete \n" + "MAC mode" + "\n" + "to=" + to + "\n" +
            //                        ex.ToString());
            //    }
            //}
        }

        public static string Convert_Path(string input)
        {
            return  FileM.Convert_Path(input);
        }




        private string ID_ViPlanner;
        private string Directory_Path;
        public FileM[] Files;
        //  private string[] Files_Names;

        public DirectoryM(string idViPlanner, string directoryPath)
        {
            ID_ViPlanner = idViPlanner;
            Directory_Path = directoryPath;
            string[] directories = Directory.GetDirectories(Directory_Path);
            Queue<string> directories_with_files_to_collect = new Queue<string>();

            foreach (var cur in directories)
            {
                if (Path.GetFileName(cur).Contains(ID_ViPlanner))
                    directories_with_files_to_collect.Enqueue(cur);
            }

            directories_with_files_to_collect.Enqueue(Directory_Path);

            Queue<string> files = new Queue<string>();

            foreach (var cur in directories_with_files_to_collect)
            {
                string[] cur_files = Directory.GetFiles(cur);
                foreach (var cur_file in cur_files)
                {
                    if (Path.GetFileName(cur_file).Contains(ID_ViPlanner)) files.Enqueue(cur_file);
                }
            }

            Files = new FileM[files.Count];
            //      Files_Names=new string[files.Count];
            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = new FileM(files.Dequeue());
                //        Files_Names[i] = Files[i].get_Name();
            }

        }


        public Queue<FileM> Get_Selected_Files()
        {
            Queue<FileM> mas = new Queue<FileM>();

            foreach (var VARIABLE in Files)
            {
                if (VARIABLE.Is_Selected()) mas.Enqueue(VARIABLE);
            }

            return mas;
        }
    }
}
