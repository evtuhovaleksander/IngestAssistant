namespace Ingest_Assistant
{
    partial class SpeedTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.dddr = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(536, 1);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(849, 495);
            this.rtb.TabIndex = 1;
            this.rtb.Text = "";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(356, 312);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(100, 20);
            this.tb.TabIndex = 2;
            // 
            // dddr
            // 
            this.dddr.Location = new System.Drawing.Point(175, 33);
            this.dddr.Name = "dddr";
            this.dddr.Size = new System.Drawing.Size(326, 241);
            this.dddr.TabIndex = 3;
            this.dddr.Text = "";
            // 
            // SpeedTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 524);
            this.Controls.Add(this.dddr);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.button1);
            this.Name = "SpeedTest";
            this.Text = "SpeedTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.RichTextBox dddr;
    }
}