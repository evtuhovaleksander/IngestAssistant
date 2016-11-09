using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VipLiner_Control
{
    public partial class Form4 : Form
    {

        public struct tblab
        {
            public Label labl;
            public TextBox txt;
        }


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] a=new string[3];
            a[0] ="0000";
            a[1] = "11111";
            a[2] = "22222";
            build(a);
            ///
            /// 
            a[0] = "";
            this.Refresh();

        }



        private void build(string[] a)
        {
            tblab[] tb=new tblab[a.Length];
            
            int x = label1.Location.X;
            int y = label1.Location.Y;
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].labl=new Label();
                tb[i].txt=new TextBox();
                tb[i].labl.Text = a[i];
                tb[i].txt.Text = a[i];
                tb[i].labl.Location= new Point(x,y);
                tb[i].txt.Location = new Point(x+100, y);
                this.Controls.Add(tb[i].labl);
                this.Controls.Add(tb[i].txt);
                y += 30;

            }
        }
    }
}
