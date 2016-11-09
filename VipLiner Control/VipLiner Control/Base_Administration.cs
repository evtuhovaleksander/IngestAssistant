using System;
using System.IO;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Base_Administration : Form
    {
        public string[] Names;
        public string[] Paths;

        public Base_Administration()
        {
            InitializeComponent();
            Collect_info();
        }

        private void Base_Arch_But_Click(object sender, EventArgs e)
        {
            var cur_base = Settings.Default.MetaBase_Way;
            var destination = Settings.Default.Base_Archive;
            if (!Directory.Exists(destination))
            {
                DirectoryM.CreateDirectory(destination);
            }
            destination += "\\" + Path.GetFileName(cur_base) + "@" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") +
                           ".base";
            FileM.Copy(cur_base, destination);
            Log_Class.Copy("Base Arch", cur_base, destination);
            MessageBOX.Show_Message("База успешно сохраненна");
            Collect_info();
        }

        private void Collect_Info_But_Click(object sender, EventArgs e)
        {
            Collect_info();
        }

        public void Collect_info()
        {
            var destination = Settings.Default.Base_Archive;
            var paths = Directory.GetFiles(destination);
            Col.Text = paths.Length.ToString();

            var now = DateTime.Now;
            var last = new DateTime(2000, 1, 1);

            foreach (var temp in paths)
            {
                var temp_date =
                    Path.GetFileNameWithoutExtension(temp)
                        .Substring(Path.GetFileNameWithoutExtension(temp).IndexOf("@") + 1);


                var nd = "";

                for (var i = 0; i < 8; i++)
                {
                    if (temp_date[i] != '-')
                    {
                        nd += temp_date[i];
                    }
                    else
                    {
                        nd += '.';
                    }
                }

                for (var i = 8; i < temp_date.Length; i++)
                {
                    if (temp_date[i] != '-')
                    {
                        nd += temp_date[i];
                    }
                    else
                    {
                        nd += ':';
                    }
                }


                var cur = Convert.ToDateTime(nd);
                if ((now - cur) < (now - last)) last = cur;
            }
            Last.Text = last.ToString("F");


            double size = 0;
            foreach (var temp in paths)
            {
                var cur = new FileInfo(temp);
                size += Convert.ToDouble(cur.Length);
            }

            size /= 1024;
            size /= 1024;
            Size.Text = size.ToString("F");
        }

        private void load_admin()
        {
            Paths = Directory.GetFiles(Settings.Default.Base_Archive);
            Names = new string[Paths.Length];
            for (var i = 0; i < Paths.Length; i++)
            {
                Names[i] = Path.GetFileName(Paths[i]).Substring(Path.GetFileName(Paths[i]).IndexOf("@"));
            }

            Base_Colection_CmBox.DataSource = Names;
        }

        private void Unlock_Admin_But_Click(object sender, EventArgs e)
        {
            if (PasswordForm.Ask_Permission())
            {
                load_admin();
                Admin_GrBox.Enabled = true;
            }
        }

        private void Base_Wake_But_Click(object sender, EventArgs e)
        {
            if (Base_Colection_CmBox.SelectedValue != null)
            {
                var index = 0;
                for (var i = 0; i < Names.Length; i++)
                {
                    if (Names[i] == Base_Colection_CmBox.SelectedValue.ToString()) index = i;
                }

                var from = Paths[index];
                var to = Settings.Default.MetaBase_Way;
                try
                {
                    if (File.Exists(to))
                    {
                        FileM.Delete(to);
                        Log_Class.Delete("Base Administration", to);
                    }
                    FileM.Copy(from, to);
                    Log_Class.Copy("Base administration", from, to);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка востановления");
                }
            }
        }

        private void Base_Del_But_Click(object sender, EventArgs e)
        {
            if (Base_Colection_CmBox.SelectedValue != null)
            {
                var index = 0;
                for (var i = 0; i < Names.Length; i++)
                {
                    if (Names[i] == Base_Colection_CmBox.SelectedValue.ToString()) index = i;
                }

                var from = Paths[index];
                try
                {
                    if (File.Exists(from))
                    {
                        FileM.Delete(from);
                        Log_Class.Delete("Base administration", from);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления");
                }


                load_admin();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            load_admin();
        }

        private void Base_Administration_Load(object sender, EventArgs e)
        {
        }
    }
}