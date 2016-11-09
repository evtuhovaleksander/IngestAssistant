namespace Ingest_Assistant
{
    partial class Emergensy_Way_To_Base
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Emergensy_Way_To_Base));
            this.Way_text_box = new System.Windows.Forms.TextBox();
            this.Browse_But = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Continue_But = new System.Windows.Forms.Button();
            this.Kill_Process_But = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Way_text_box
            // 
            this.Way_text_box.Location = new System.Drawing.Point(12, 12);
            this.Way_text_box.Name = "Way_text_box";
            this.Way_text_box.Size = new System.Drawing.Size(630, 22);
            this.Way_text_box.TabIndex = 0;
            // 
            // Browse_But
            // 
            this.Browse_But.Location = new System.Drawing.Point(648, 5);
            this.Browse_But.Name = "Browse_But";
            this.Browse_But.Size = new System.Drawing.Size(243, 29);
            this.Browse_But.TabIndex = 1;
            this.Browse_But.Text = "указать путь";
            this.Browse_But.UseVisualStyleBackColor = true;
            this.Browse_But.Click += new System.EventHandler(this.Browse_But_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(630, 128);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Continue_But
            // 
            this.Continue_But.Enabled = false;
            this.Continue_But.Location = new System.Drawing.Point(648, 40);
            this.Continue_But.Name = "Continue_But";
            this.Continue_But.Size = new System.Drawing.Size(239, 44);
            this.Continue_But.TabIndex = 3;
            this.Continue_But.Text = "продолжить работу";
            this.Continue_But.UseVisualStyleBackColor = true;
            this.Continue_But.Click += new System.EventHandler(this.Continue_But_Click);
            // 
            // Kill_Process_But
            // 
            this.Kill_Process_But.Location = new System.Drawing.Point(648, 90);
            this.Kill_Process_But.Name = "Kill_Process_But";
            this.Kill_Process_But.Size = new System.Drawing.Size(239, 44);
            this.Kill_Process_But.TabIndex = 4;
            this.Kill_Process_But.Text = "Выйти из программы";
            this.Kill_Process_But.UseVisualStyleBackColor = true;
            this.Kill_Process_But.Click += new System.EventHandler(this.Kill_Process_But_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // Emergensy_Way_To_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 189);
            this.Controls.Add(this.Kill_Process_But);
            this.Controls.Add(this.Continue_But);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Browse_But);
            this.Controls.Add(this.Way_text_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Emergensy_Way_To_Base";
            this.Text = "Emergensy_Way_To_Base";
            this.Load += new System.EventHandler(this.Emergensy_Way_To_Base_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Way_text_box;
        private System.Windows.Forms.Button Browse_But;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Continue_But;
        private System.Windows.Forms.Button Kill_Process_But;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}