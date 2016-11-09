using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ingest_Assistant;
using VipLiner_Control;

namespace Ingest_Administrator
{
    public partial class Update_Prepare : Form
    {
        public Update_Prepare()
        {
            InitializeComponent();
        }

        private void Browse_But_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                Path_TBox.Text = FBD.SelectedPath;
            }
        }

        private void Prepare_But_Click(object sender, EventArgs e)
        {
            if (Path_TBox.Text != "")
            {
                FileVersionInfo Version_Info = FileVersionInfo.GetVersionInfo(Path_TBox.Text + "/Ingest Assistant.exe");
                //MessageBox.Show(Version_Info.FileVersion);
                string cur_ver = Version_Info.FileVersion;
                    
                string zapros = " SELECT MAX(U_ID) AS Expr1 FROM     UpdaterTable ";
                int last_id = SQL.ReadValueInt32(zapros);

                int count = SQL.ReadValueInt32("SELECT Count(*)  FROM     UpdaterTable Where (U_Ver='" + cur_ver+"')");
                
                if (count!=0)
                {
                    MessageBox.Show("Данная версия уже зарегестрированна");
                }
                else
                {
                    string dir_path = SQL.ReadValueString("SELECT U_Path  FROM     UpdaterTable Where U_ID=0");
                    Directory.CreateDirectory(dir_path  + cur_ver);
                    string cur_work_path = dir_path + cur_ver;

                    string[] files =Directory.GetFiles(Path_TBox.Text);
                    foreach (string temp in files)
                    {
                        File.Copy(temp,cur_work_path+"/"+Path.GetFileName(temp));
                    }
                    int key = 0;
                    if (Important_ChBox.Checked)
                    {
                        key = 1;
                    }
                    else
                    {
                        key = 0;
                    }
                    string zapros_insert = "INSERT INTO UpdaterTable (U_ID, U_Ver, U_Path, U_Important, U_Time) VALUES ("+(last_id+1).ToString()+",'"+cur_ver+"','"+cur_work_path+"/"+"',"+key+",'"+DateTime.Now.ToString()+"')";
                    SQL.Execute(zapros_insert);
                    MessageBox.Show("ok");
                    Close();
                }
                    
                }

            }


        public static void Form_Lauch(Main_Form parent)
        {
            Update_Prepare form = new Update_Prepare();
            form.StartPosition = FormStartPosition.Manual;
           
            form.Width = SystemInformation.PrimaryMonitorSize.Width;
            form.ShowDialog();
        }


        private void Update_Prepare_Load(object sender, EventArgs e)
        {

        }
        }
    }

