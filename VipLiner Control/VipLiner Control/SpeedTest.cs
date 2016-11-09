using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    public partial class SpeedTest : Form
    {
        public SpeedTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime s1;
            DateTime s2;
            DateTime s3;
            DateTime s4;
            DateTime s5;
            DateTime s6;
            DateTime f1;
            DateTime f2;
            DateTime f3;
            DateTime f4;
            DateTime f5;
            TimeSpan p1;
            TimeSpan p2;
            TimeSpan p3;
            TimeSpan p4;
            TimeSpan p5;
            TimeSpan p6;

            ofd.ShowDialog();
            s1 = DateTime.Now;
            Media_Info clas=new Media_Info(ofd.FileName);
            f1 = DateTime.Now;
            p1 = f1 - s1;



            s2=DateTime.Now;
            string res = clas.mdf.MediaInfo_Text;
            f2 = DateTime.Now;
            p2 = f2 - s2;


            s3 = DateTime.Now;
            rtb.Text = res;
            f3 = DateTime.Now;
            p3 = f3 - s3;


            s4 = DateTime.Now;
            rtb.Text+="\n\n\n\n\n"+clas.mdf.Info_Text;
            f4 = DateTime.Now;
            p4 = f4 - s4;



            s5=DateTime.Now;
            string one = clas.get_one_param("Video", "Duration");
            f5 = DateTime.Now;
            p5 = f5 - s5;




            dddr.Text = p1.ToString("g") + "\n" + p2.ToString("g") + "\n" + p3.ToString("g") + "\n" + p4.ToString("g") +
                        "\n" + p5.ToString("g") + "\n";
        }
    }
}
