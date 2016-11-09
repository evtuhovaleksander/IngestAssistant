using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    class Consolidate_Options
    {
        public Consolidate_Options(ref DataGridView dgvr)
        {
            this.dgv = dgvr;
            string str = Ingest_Assistant.Properties.Settings.Default.Consolidate_Directories;
            string[] strmas = str.Split('|');
            Directory_Masive = new DirectoryC[strmas.Length];
            SQL_Class sqlcl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
            for (int i = 0; i < Directory_Masive.Length; i++)
            {
                string zapros = "select Name,RusName,Path,Main from directorytable where ID=" + (strmas[i]);
                SQL_Class.ReadValues(zapros,ref sqlcl);
                while (sqlcl.SQL_DataReader.Read())
                {
                    Directory_Masive[i] = new DirectoryC(sqlcl.SQL_DataReader.GetString(2),
                      sqlcl.SQL_DataReader.GetString(1), true, Convert.ToBoolean(sqlcl.SQL_DataReader.GetInt32(3)));
                }
               

            }
            
            //Directory_Masive[0] = new DirectoryC("master", "masetr", true, true);
            //Directory_Masive[1] = new DirectoryC("work", "work", true, true);
            //Directory_Masive[2] = new DirectoryC("stock", "stock", true, true);
            //Directory_Masive[3] = new DirectoryC("F:\\IA\\Archive", "ing archive", true, false);
            //Directory_Masive[4] = new DirectoryC("F:\\IA\\Work", "ing work", true, false);
        }

        public void Load_To_DGV()
        {
            dgv.RowCount = Directory_Masive.Length;
            for (int i = 0; i < Directory_Masive.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = i;
                dgv.Rows[i].Cells[1].Value = Directory_Masive[i].Name;
                dgv.Rows[i].Cells[2].Value = Directory_Masive[i].Selected;
            }
        }

        public void Rewrite_One_Selection(int x, int y)
        {
            Directory_Masive[Convert.ToInt32(dgv.Rows[y].Cells[0].Value)].Selected = !Convert.ToBoolean(dgv.Rows[y].Cells[2].Value);
            dgv.Rows[y].Cells[2].Value = !Convert.ToBoolean(dgv.Rows[y].Cells[2].Value);
        }

        private DataGridView dgv;
        public DirectoryC[] Directory_Masive;

        public void Load_Not_Main_Directories(string ID_ViPlanner, ref DirectoryM_Container cntr, ref ComboBox cmb, ref DataGridView dgvv)
        {
            string[] notBase_Directory_Paths = new string[0];
            string[] notBase_Directory_Names = new string[0];
            foreach (var VARIABLE in Directory_Masive)
            {
                if (VARIABLE.Selected)
                {
                    if (!VARIABLE.Base_Dir)
                    {
                        Array.Resize(ref notBase_Directory_Paths, notBase_Directory_Paths.Length + 1);
                        notBase_Directory_Paths[notBase_Directory_Paths.Length - 1] = VARIABLE.Path;
                        Array.Resize(ref notBase_Directory_Names, notBase_Directory_Names.Length + 1);
                        notBase_Directory_Names[notBase_Directory_Names.Length - 1] = VARIABLE.Name;
                    }
                }
            }
            if (notBase_Directory_Names != null)
            {
                if (notBase_Directory_Names.Length != 0)
                {
                    cntr = new DirectoryM_Container(ID_ViPlanner, notBase_Directory_Paths, notBase_Directory_Names, cmb, dgvv);
                }
            }
        }
    }



    public class DirectoryC
    {
        public DirectoryC(string path, string name, bool selected, bool base_dir)
        {
            Path = path;
            Name = name;
            Selected = selected;
            Base_Dir = base_dir;
        }

        public string Path;
        public string Name;
        public Boolean Selected;
        public Boolean Base_Dir;
    }
}
