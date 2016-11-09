using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VipLiner_Control
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        public Bitmap b;
        private void button2_Click(object sender, EventArgs e)
        {
            b = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            this.DrawToBitmap(b, this.ClientRectangle);

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
           // if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
               // printDocument1.Print();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            b = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            this.DrawToBitmap(b, this.ClientRectangle);
            pictureBox1.Image = b;
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect;
            int pbWidth = e.MarginBounds.Width;
            int pbHeight = e.MarginBounds.Height;
            int ImageWidth = b.Width; int ImageHeight = b.Height;

            SizeF sizef = new SizeF(ImageWidth / b.HorizontalResolution, ImageHeight / b.VerticalResolution);
            float fSeale = Math.Min(pbWidth / sizef.Width, pbHeight / sizef.Height);
            sizef.Width *= fSeale;
            sizef.Height *= fSeale;
            Size size = Size.Ceiling(sizef);
            rect = new Rectangle(e.MarginBounds.Location.X, e.MarginBounds.Location.Y, size.Width, size.Height);
            g.DrawImage(b, rect);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
