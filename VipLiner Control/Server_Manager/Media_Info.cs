using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MediaInfoNET;

namespace Server_Manager{
    public class Media_Info
    {
        public MediaFile mdf;
        private string path;
        private readonly string all_info;

        public Media_Info(string path)
        {
            mdf = new MediaFile(path);
            all_info = mdf.MediaInfo_Text;
        }

        public static Boolean permission()
        {
            var allow = false;
            var paths = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (var tmp in paths)
            {
                if (Path.GetFileName(tmp) == "MediaInfo.dll") allow = true;
            }
            return allow;
        }

        public static void fill_rich_text_box(string path,ref RichTextBox rtb)
        {
            var tm_clas = new Media_Info(path);

            tm_clas.mdf = new MediaFile(path);
            rtb.Text = tm_clas.mdf.MediaInfo_Text;
        }

        public static string get_all_info(string path)
        {
            var mdff = new MediaFile(path);
            return mdff.MediaInfo_Text;
        }

        public string get_one_param(string block, string srch)
        {
            try
            {
                var block_info = all_info.Substring(all_info.IndexOf(block));
                var curent = block_info.Substring(block_info.IndexOf(srch + "      "));
                curent = curent.Substring(0, curent.IndexOf('\r') + 1);

                //string curent = get_one_param_full(block, srch);
                curent = curent.Substring(curent.IndexOf(':') + 1);
                curent = curent.Substring(0, curent.Length - 1);
                return curent;
            }
            catch (Exception)
            {
                return " ";
            }
        }

        public string get_formated_param(string block, string srch)
        {
            var consta = 30;
            var znach = get_one_param(block, srch);
            var format = srch;
            while (format.Length != consta)
            {
                format += '.';
            }
            format += znach;

            return format;
        }

        public string get_one_param_full(string block, string srch)
        {
            string all_info = mdf.MediaInfo_Text;
            var block_info = all_info.Substring(all_info.IndexOf(block));
            var curent = block_info.Substring(block_info.IndexOf(srch + "      "));
            curent = curent.Substring(0, curent.IndexOf('\r') + 1);
            return curent;
        }

        public static string get_info_complex(string path)
        {
            var tm_clas = new Media_Info(path);
            var outt = "";
            tm_clas.mdf = new MediaFile(path);
            outt += tm_clas.get_formated_param("Video", "Bit rate");
            outt += tm_clas.get_formated_param("Video", "Bit rate mode");
            return outt;
        }
    }
}