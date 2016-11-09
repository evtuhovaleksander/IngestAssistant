using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace Ingest_Assistant
{
    public partial class FilesCopy : Form
    {
        public struct FileCPY
        {
            public string from;
            public string to_dir;
        }

        public Queue<FileCPY> in_files;
        public string from_path;
        public string to_dir_path;

        public void cpy()
        {
            File.Copy(from_path, to_dir_path);
        }

        public FilesCopy()
        {
            InitializeComponent();
            in_files=new Queue<FileCPY>();
        }

        private void FilesCopy_Load(object sender, EventArgs e)
        {
            
        }

        public void Add_New_File(string ishod,string kuda)
        {
            FileCPY temp=new FileCPY();
            temp.from = ishod;
            temp.to_dir = kuda;
            in_files.Enqueue(temp);
        }

        public void Files_Copy()
        {
            Total_PrBar.Maximum = in_files.Count + 1;
            Total_PrBar.Value = 0;
            ShowDialog();
            
            
        }




        public void copy_file(FileCPY file)
        {
           if(File.Exists(file.to_dir))File.Delete(file.to_dir);
            FileInfo info=new FileInfo(file.from);
            double nominal = info.Length;
            double filesize =info.Length;
            filesize /= 1024;
            filesize /= 1024;
            if (filesize/1024 > 1)
            {
                filesize /= 1024;
            }
            int size = Convert.ToInt32(filesize);
            Cur_PrBar.Maximum = size;
            Cur_PrBar.Value = 0;

            from_path = file.from;
            to_dir_path = file.to_dir;
           Thread Copy_Thread=new Thread(cpy);
            Copy_Thread.Start();
            while (!File.Exists(file.to_dir))
            {

            }
            FileInfo copy = new FileInfo(file.to_dir);
            while (copy.Length!=nominal)
            {
                copy = new FileInfo(file.to_dir);
                double nominal_copy = info.Length;
                double filesize_copy = info.Length;
                filesize_copy /= 1024;
                filesize_copy /= 1024;
                if (filesize_copy / 1024 > 1)
                {
                    filesize_copy /= 1024;
                }
                int size_copy = Convert.ToInt32(filesize);
                Cur_PrBar.Value = size_copy;
            }
        }

        public static void copyone(string path, string path1)
        {
            FilesCopy frm=new FilesCopy();
            frm.Add_New_File(path,path1);
            frm.Files_Copy();
        }

        private void FilesCopy_Shown(object sender, EventArgs e)
        {
            foreach (FileCPY tmp in in_files)
            {
                copy_file(tmp);
            }
        }

    }
}
