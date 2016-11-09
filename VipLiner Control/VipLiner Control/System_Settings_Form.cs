using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class System_Settings_Form : Form
    {
        public string[] Profiles_Mas;
        public System_Settings_Form()
        {
            InitializeComponent();
            Queue<string> mas = new Queue<string>();
            int col = SQL_Class.ReadValueInt32("Select Count(*) from Settings", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
            // SQL_Class sql_cl = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path, "");
            for (int i = 1; i <= col; i++)
            {
                mas.Enqueue(SQL_Class.ReadValueString("Select Name from Settings where (ID=" + i + ")", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path));
            }

            Profiles_Mas = new string[mas.Count];

            for (int i = 0; i < Profiles_Mas.Length; i++)
            {
                Profiles_Mas[i] = mas.Dequeue();
            }
            Profiles_CmBox.DataSource = Profiles_Mas;
        }

        public void check_stop_file()
        {
            string stop_file = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory + "\\STOP.iastopfile";
            if (File.Exists(stop_file))
            {
                Stop_Marker.BackColor = Color.Red;
                Stop_Marker.Text = "Стоп файл создан";
                Settings_grBox.Enabled = true;
            }
            else
            {
                Stop_Marker.BackColor = Color.GreenYellow;
                Stop_Marker.Text = "Стоп файла нет";
                Settings_grBox.Enabled = false;
            }
        }


        private void System_Settings_Form_Load(object sender, EventArgs e)
        {
           // check_stop_file();
        }

        private void Create_Stop_File_Click(object sender, EventArgs e)
        {
            string stop_file = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory + "\\STOP.iastopfile";
            if (!Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory))
            {
                DirectoryM.CreateDirectory(Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory);
            }
            if (!File.Exists(stop_file))
            {
                FileM.Create(stop_file);
            }
            check_stop_file();
        }

        private void Delete_Stop_File_Click(object sender, EventArgs e)
        {
            string stop_file = Ingest_Assistant.Properties.Settings.Default.Temp_Files_Directory + "\\STOP.iastopfile";
            if (File.Exists(stop_file))
            {
                FileM.Delete(stop_file);
            }
            check_stop_file();
        }



        public void delete_interface()
        {
            for (int i = 0; i < InterFace_Masive.Length; i++)
            {
                Controls.Remove(InterFace_Masive[i].nm);
                Controls.Remove(InterFace_Masive[i].set);
            }
        }


        private void Load_Settings_But_Click(object sender, EventArgs e)
        {
            load_setings();
            create_interface();
        }

        public struct FE
        {
            public string sname;
            public string setings;
            public TextBox nm;
            public TextBox set;
        }

        private FE[] InterFace_Masive;


        public void load_setings()
        {
            if(InterFace_Masive!=null) delete_interface();

            int col = SQL_Class.ReadValueInt32("Select Count(*) from SN", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
            InterFace_Masive=new FE[col];
            
            for (int i = 0; i < col; i++)
            {
                InterFace_Masive[i].sname=SQL_Class.ReadValueString( "Select Name from SN where ID=" +(i+1),Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                
                InterFace_Masive[i].setings =
                    SQL_Class.ReadValueString(
                        "Select " + InterFace_Masive[i].sname + "  from Settings where Name='" +
                        Profiles_CmBox.SelectedItem.ToString()+"'", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                
            }
        }

        public void create_interface()
        {
            int heigth = this.Height;
            int grb_height = this.Settings_grBox.Height;
            int x=label1.Location.X;
            int y = label1.Location.Y;
            
            for (int i = 0; i < InterFace_Masive.Length; i++)
            {
    
                TextBox nm=new TextBox();
                TextBox set=new TextBox();
                nm.Parent = Settings_grBox;
                nm.Left = x;
                nm.Top = y;
                nm.Size =new Size(249, 20);
                nm.Text = InterFace_Masive[i].sname + " | " + SQL_Class.ReadValueString("Select Name_Rus from SN where Name='" + InterFace_Masive[i].sname+"'", Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                nm.Show();

                set.Parent = Settings_grBox;
                set.Left = x+260;
                set.Top = y;
                set.Size = new Size(690, 20);
                set.Text = InterFace_Masive[i].setings;
                set.Show();
                y += 20;
                Controls.Add(nm);
                Controls.Add(set);
                InterFace_Masive[i].nm = nm;
                InterFace_Masive[i].set = set;
                this.Height += 40*InterFace_Masive.Length;
                Refresh();
            }
        }

        private void Save_Settings_But_Click(object sender, EventArgs e)
        {
            string zapros = "Update Settings SET ";

                 string name = InterFace_Masive[0].sname;
                string setting = InterFace_Masive[0].set.Text;
            zapros += "  " + name + " = '" + setting + "' ";


            for (int i = 1; i <  InterFace_Masive.Length; i++)
            {
                 name = InterFace_Masive[i].sname;
                setting = InterFace_Masive[i].set.Text.Replace("\\",("\\\\"));
                zapros += ",  " + name + " = '" + setting + "' ";
            }

            zapros += "  where Name ='" + Profiles_CmBox.SelectedItem.ToString() + "' ";


            MessageBox.Show(zapros);
        SQL_Class.Execute(zapros, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
        }
    }
}
