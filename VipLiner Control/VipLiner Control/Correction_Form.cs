using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class Correction_Form : Form
    {
        public long id;
        public string VP;
        public string Name;
        public string NameRus;
        public string Type;
        public string Old;


        public Correction_Form(long id, string vp, string name, string nameRus, string type, string old)
        {
            InitializeComponent();
            this.id = id;
            VP = vp;
            Name = name;
            NameRus = nameRus;
            Type = type;
            Old = old;

            this.ID_TBox.Text = id.ToString();
            VP_TBox.Text = vp;
            Name_TBox.Text = name;
            NameRus_TBox.Text = nameRus;
            Type_TBox.Text = type;
            Old_TBox.Text = old;

            if (type == "datetime")
            {
                try
                {
                    New_TBox.Text = Convert.ToDateTime(old).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {
                    New_TBox.Text = old;
                    
                }
            }
            else
            {
                New_TBox.Text = old;
            }


             

            if ("int long ".Contains(Type))
            {
                Shablon_TBox.Text = "Любое целое число";
            }

            if ("datetime ".Contains(Type))
            {
               Shablon_TBox.Text = "YYYY-MM-DD hh:mm:ss";
            }

            if ("int(11)".Contains(Type))
            {
                Shablon_TBox.Text = "Любое целое число";
            }


            if ("double".Contains(Type))
            {
                Shablon_TBox.Text = "Любое вещественное число";
            }

            if ("varchar longtext".Contains(Type))
            {


                Shablon_TBox.Text = "Любой текст";
                if ("Ingest_Duration Render_Time Total_Time".Contains(Name))
                {
                    Shablon_TBox.Text = "hh:mm:ss";
                }

                if ("Source_Duration".Contains(Name))
                {
                    Shablon_TBox.Text = "hh:mm:ss:ff";
                }


                if ("Reel_ID".Contains(Name))
                {
                    Shablon_TBox.Text = "####-##### или имя файла";
                }


            }









        }


        public static void Correction_Lauch(long id, string vp, string name, string nameRus, string type, string old)
        {
            Correction_Form frm = new Correction_Form(id, vp, name, nameRus, type, old);
            frm.ShowDialog();
        }


        public Correction_Form()
        {
            InitializeComponent();
        }

        private void Cancel_but_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Correction_Form_Load(object sender, EventArgs e)
        {

        }

        private void New_TBox_TextChanged(object sender, EventArgs e)
        {
            bool conv = false;

            if ("int long ".Contains(Type))
            {
                try
                {
                    long e1 = Convert.ToInt64(New_TBox.Text);
                    conv = true;
                }
                catch (Exception)
                {

                }
            }

            if ("datetime ".Contains(Type))
            {
                try
                {
                    DateTime e1 = Convert.ToDateTime(New_TBox.Text);
                    if (New_TBox.Text == e1.ToString("yyyy-MM-dd HH:mm:ss")) conv = true;
                }
                catch (Exception)
                {

                }
            }

            if ("int(11)".Contains(Type))
            {
                try
                {
                    long e1 = Convert.ToInt64(New_TBox.Text);
                    conv = true;
                }
                catch (Exception)
                {

                }
            }


            if ("double".Contains(Type))
            {
                try
                {
                    double e1 = Convert.ToDouble(New_TBox.Text);
                    conv = true;
                }
                catch (Exception)
                {

                }
            }

            if ("varchar longtext".Contains(Type))
            {
                try
                {
                    conv = true;

                    if ("Ingest_Duration Render_Time Total_Time".Contains(Name))
                    {
                        if (!RegularExpression.is_Time_Span(New_TBox.Text))
                        {
                            conv = false;
                        }
                    }

                    if ("Source_Duration".Contains(Name))
                    {
                        if (!RegularExpression.is_Duration(New_TBox.Text))
                        {
                            conv = false;
                        }
                    }
                   

                    if ("Reel_ID".Contains(Name))
                    {
                        if (!RegularExpression.is_ReelID(New_TBox.Text))
                        {
                            conv = false;
                        }
                    }
                   

                 //   Source_Duration '00:24:57:00'

                     //   Reel_ID '5026-00170'
                }
                catch (Exception)
                {

                }
            }


            if (conv) Save_but.Enabled = true;
            else
            {
                Save_but.Enabled = false;
            }
        }

        private void Save_but_Click(object sender, EventArgs e)
        {


            int rg = 0;
            if (PasswordForm.getPermition(ref rg))
            {
                string zap = "UPDATE metadataarchive set " + Name + "=";
                if ("INT(11)INT(1)INT()".Contains(Type))
                {
                    zap += New_TBox.Text;
                }
                else
                {
                    zap += "'" + New_TBox.Text + "'";
                }

                zap += "  where ID=" + id;
                if (SQL_Class.Execute(zap, Settings.Default.MetaBase_Way))
                {
                   string rg_str= SQL_Class.ReadValueString("SELECT L_FullName FROM login where L_ID=" + rg,
                        Properties.Settings.Default.Setting_Base_Path);
                   Log_Class.VAction(VP, "Коррекция базы пользователем: " + rg_str + " \n Произведенна коррекция поля: " + Name + "  \n Расшифровка абривеатуры: " + NameRus + "  \n Старое значение: " + Old_TBox.Text + "  \n Новое значение: " + New_TBox.Text, 4);
                    Close();
                }
            }
        }
    }
}
