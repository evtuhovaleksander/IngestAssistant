using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Ingest_Assistant
{
    public partial class XmlEditor : Form
    {
        public string[] param_mas;
        public XML_Object[] object_mas;
        public XmlEditor()
        {
            InitializeComponent();
            param_mas=XML_Class.get_name_mas(Ingest_Assistant.Properties.Settings.Default.Shablon_Path+Ingest_Assistant.Properties.Settings.Default.Path_Separator+"xls.xml");
        }

        private void XmlEditor_Load(object sender, EventArgs e)
        {

        }

        public static void Lauch_Editor(string path)
        {
            XmlEditor editor= new XmlEditor();
            editor.Path_TBox.Text = path;
            editor.prepare_form();
            editor.ShowDialog();
        }

        private void Open_But_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd=new OpenFileDialog();
            fd.ShowDialog();
            if (File.Exists(fd.FileName))
            {
                Path_TBox.Text = fd.FileName;
                prepare_form();
            }
        }


        public void prepare_form()
        {
            int y = label1.Location.Y;
            int l1=180;
            int l2=507;
            int x1 = label1.Location.X;
            int x2 = x1 + l1;
            int d = 23;





            object_mas=new XML_Object[param_mas.Length];
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path_TBox.Text);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode VARIABLE in xRoot)
            {
                if (VARIABLE.Attributes.Count > 0)
                {
                    XmlNode name = VARIABLE.Attributes.GetNamedItem("name");
                    if (name != null)
                    {
                        XML_Object tmp=new XML_Object();
                        tmp.name = name.InnerText;
                        foreach (XmlNode childnode in VARIABLE.ChildNodes)
                            {
                                if (childnode.Name == "definition")
                                {
                                    if (childnode != null)
                                    {
                                        tmp.definition = childnode.InnerText;
                                    }
                                }

                            if (childnode.Name == "namerus")
                            {
                                if (childnode != null)
                                {
                                    tmp.namerus = childnode.InnerText;
                                }
                            }
                             }

                        int j = 0;
                        for (int k = 0; k < param_mas.Length; k++)
                        {
                            if (param_mas[k] == tmp.name)
                            {
                                j = k;
                                break;
                            }
                        }
                        int ny = d*j + y;

                        tmp.nameTbox=new TextBox();
                        tmp.nameTbox.Parent = this;
                        tmp.nameTbox.Location=new Point(x1,ny);
                        tmp.nameTbox.Width = l1;
                        tmp.nameTbox.Text = tmp.namerus;

                        tmp.definitionTbox = new TextBox();
                        tmp.definitionTbox.Parent = this;
                        tmp.definitionTbox.Location = new Point(x2, ny);
                        tmp.definitionTbox.Width = l2;
                        tmp.definitionTbox.Text = tmp.definition;
                        
                        object_mas[j] = tmp;

                    }
                }
            }
            this.Height = y +(param_mas.Length+3)*d+ 10;
            progressBar.Value = progressBar.Maximum;
            Refresh();
            
        }

        private void Save_But_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = object_mas.Length+1;
            progressBar.Value = 1;
            for (int i = 0; i < object_mas.Length; i++)
            {
                progressBar.Value++;
                Refresh();
                if (object_mas[i].definitionTbox.Text != object_mas[i].definition)
                {
                    XML_Class.set_one_param(object_mas[i].name,Path_TBox.Text,object_mas[i].definitionTbox.Text);
                }
                
            }
        }
    }




    public class XML_Object
    {
        public string name;
        public string namerus;
        public string definition;
        public TextBox nameTbox;
        public TextBox definitionTbox;
    }
}
