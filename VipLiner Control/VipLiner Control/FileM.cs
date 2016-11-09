using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public  class FileM 
    {
       
        public static void Copy(string from, string to)
        {
            if (true)
            {
                try
                {
                    File.Copy(from, to);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("COPY \n" + "Win mode" + "\n" + "from=" + from + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }

            }
            else
            {
                string too = Convert_Path(to);
                from = Convert_Path(from);

                try
                {
                    File.Copy(from, too);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("COPY \n" + "MAC mode" + "\n" + "from=" + from + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }
            }
        }

        public static void Move(string from, string to)
        {
            if (true)
            {
                try
                {
                    File.Move(from, to);
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
                    File.Move(from, too);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Move \n" + "MAC mode" + "\n" + "from=" + from + "\n" + "to=" + to + "\n" +
                                    ex.ToString());
                }
            }
        }

        public static void Create(string to)
        {
            
                try
                {
                    File.Create( to);
                    Log_Class.Create("",to);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create \n" + "Win mode" + "\n"  + "to=" + to + "\n" +
                                    ex.ToString());
                }

            
           
        }

        public static void Delete(string to)
        {
            
                try
                {
                    File.Delete(to);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Delete \n" + "Win mode" + "\n" + "to=" + to + "\n" +
                     //               ex.ToString());
                }

             try
                {
                    Directory.Delete(to);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Delete \n" + "Win mode" + "\n" + "to=" + to + "\n" +
                       //             ex.ToString());
                }
            
        }

        public static string Convert_Path(string input)
        {
            //if (!Ingest_Assistant.Properties.Settings.Default.WINDOWS)
            //{
            //    string outt = "";
            //    outt = input.Replace("\\", "/");
            //    MessageBox.Show("in=" + input + "\n out=" + outt);
            //    return outt;
            //}
            //else
            //{
            //    return input;
            //}
            return input;
        }





        public FileM(string filePath)
        {
            File_Path = filePath;
            Selected = false;
        }

        public Boolean Is_Selected()
        {
            return Selected;
        }

        public string file_path()
        {
            return File_Path;
        }

        public void Selected_Setter(Boolean input)
        {
            Selected = input;
        }



        public string get_Name()
        {
            return Path.GetFileName(File_Path);
        }
        public string get_Extention()
        {
            return Path.GetExtension(File_Path);
        }
        private string File_Path;
        private Boolean Selected;
    }


}