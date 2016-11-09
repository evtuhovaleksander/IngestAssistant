using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ingest_Assistant
{
    class DirectoryM_Container
    {
        public Boolean loaded;
        public DirectoryM_Container(string idViPlanner, string[] directoryPaths, string[] directorynames, ComboBox cmBox, DataGridView dgv)
        {
            loaded = false;
            this.ID_ViPlanner = idViPlanner;
            this.cmBox = cmBox;
            this.dgv = dgv;
            Directories = new DirectoryM[directoryPaths.Length];
            for (int i = 0; i < Directories.Length; i++)
            {
                Directories[i] = new DirectoryM(idViPlanner, directoryPaths[i]);
            }
            cmBox.DataSource = directorynames;
            loaded = true;
            Load_Files_To_DGV(cmBox.SelectedIndex);
        }

        public void Open_File(int x, int y)
        {
            Process.Start(Directories[curent_loaded_index].Files[Convert.ToInt32(dgv.Rows[y].Cells[0].Value)].file_path());
        }

        public void ReWrite_One_Selection(int x, int y)
        {
            FileM[] files_mas = Directories[curent_loaded_index].Files;
            Boolean old = Convert.ToBoolean(dgv.Rows[y].Cells[3].Value);



            files_mas[Convert.ToInt32(dgv.Rows[y].Cells[0].Value)].Selected_Setter(!old);
            dgv.Rows[y].Cells[3].Value = files_mas[Convert.ToInt32(dgv.Rows[y].Cells[0].Value)].Is_Selected();

        }


        private void Load_Files_To_DGV(int directory_index)
        {
            FileM[] files_mas = Directories[directory_index].Files;
            dgv.RowCount = files_mas.Length;
            for (int i = 0; i < files_mas.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = i;
                dgv.Rows[i].Cells[1].Value = files_mas[i].get_Extention();
                dgv.Rows[i].Cells[2].Value = files_mas[i].get_Name();
                dgv.Rows[i].Cells[3].Value = files_mas[i].Is_Selected();
            }
            curent_loaded_index = directory_index;
        }

        public void Change_Loaded_To_DGV_Files(int new_index)
        {
            if (loaded)
            {
                Load_Files_To_DGV(new_index);
            }

        }



        public string[] get_selected_files_paths()
        {
            Queue<FileM> selected=new Queue<FileM>();
            foreach (DirectoryM dir in Directories)
            {
                foreach (FileM VARIABLE in dir.Get_Selected_Files())
                {
                    selected.Enqueue(VARIABLE);
                }
            }
            string[] ret = new string[selected.Count];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = selected.Dequeue().file_path();
            }
            return ret;
        }


        private int curent_loaded_index;
        private string ID_ViPlanner;
        public ComboBox cmBox;
        public DataGridView dgv;
        private DirectoryM[] Directories;
    }
}
