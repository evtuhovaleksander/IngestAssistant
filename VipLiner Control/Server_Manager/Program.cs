using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = Directory.GetCurrentDirectory();
            byte[] bytemas = Properties.Resources.MediaInfo;
            path += "\\MediaInfo.dll";
            if(File.Exists(path))File.Delete(path);
            FileStream fstream = new FileStream(path, FileMode.OpenOrCreate);
            fstream.Write(bytemas,0,bytemas.Length);
            fstream.Close();
            fstream.Dispose();




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_form());
        }
    }
}
