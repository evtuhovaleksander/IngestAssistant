namespace Server_Manager
{
    partial class Main_form
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
            this.Work_Rbut = new System.Windows.Forms.RadioButton();
            this.Space_Count_RBut = new System.Windows.Forms.RadioButton();
            this.Progress_But = new System.Windows.Forms.Button();
            this.Media_Info_Ch = new System.Windows.Forms.CheckBox();
            this.Space_Count_Ch = new System.Windows.Forms.CheckBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lab = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Work_Rbut
            // 
            this.Work_Rbut.AutoSize = true;
            this.Work_Rbut.Location = new System.Drawing.Point(12, 12);
            this.Work_Rbut.Name = "Work_Rbut";
            this.Work_Rbut.Size = new System.Drawing.Size(51, 17);
            this.Work_Rbut.TabIndex = 0;
            this.Work_Rbut.TabStop = true;
            this.Work_Rbut.Text = "Work";
            this.Work_Rbut.UseVisualStyleBackColor = true;
            // 
            // Space_Count_RBut
            // 
            this.Space_Count_RBut.AutoSize = true;
            this.Space_Count_RBut.Location = new System.Drawing.Point(12, 35);
            this.Space_Count_RBut.Name = "Space_Count_RBut";
            this.Space_Count_RBut.Size = new System.Drawing.Size(90, 17);
            this.Space_Count_RBut.TabIndex = 1;
            this.Space_Count_RBut.TabStop = true;
            this.Space_Count_RBut.Text = "Space_Count";
            this.Space_Count_RBut.UseVisualStyleBackColor = true;
            this.Space_Count_RBut.Visible = false;
            // 
            // Progress_But
            // 
            this.Progress_But.Location = new System.Drawing.Point(117, 6);
            this.Progress_But.Name = "Progress_But";
            this.Progress_But.Size = new System.Drawing.Size(254, 46);
            this.Progress_But.TabIndex = 2;
            this.Progress_But.Text = "Start";
            this.Progress_But.UseVisualStyleBackColor = true;
            this.Progress_But.Click += new System.EventHandler(this.Progress_But_Click);
            // 
            // Media_Info_Ch
            // 
            this.Media_Info_Ch.AutoSize = true;
            this.Media_Info_Ch.Location = new System.Drawing.Point(469, 6);
            this.Media_Info_Ch.Name = "Media_Info_Ch";
            this.Media_Info_Ch.Size = new System.Drawing.Size(79, 17);
            this.Media_Info_Ch.TabIndex = 3;
            this.Media_Info_Ch.Text = "Media_Info";
            this.Media_Info_Ch.UseVisualStyleBackColor = true;
            // 
            // Space_Count_Ch
            // 
            this.Space_Count_Ch.AutoSize = true;
            this.Space_Count_Ch.Location = new System.Drawing.Point(469, 29);
            this.Space_Count_Ch.Name = "Space_Count_Ch";
            this.Space_Count_Ch.Size = new System.Drawing.Size(91, 17);
            this.Space_Count_Ch.TabIndex = 4;
            this.Space_Count_Ch.Text = "Space_Count";
            this.Space_Count_Ch.UseVisualStyleBackColor = true;
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(12, 150);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(536, 112);
            this.rtb.TabIndex = 5;
            this.rtb.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1012, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lab
            // 
            this.lab.Location = new System.Drawing.Point(12, 58);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(1160, 26);
            this.lab.TabIndex = 7;
            this.lab.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1160, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1160, 20);
            this.textBox1.TabIndex = 9;
            // 
            // rtb2
            // 
            this.rtb2.Font = new System.Drawing.Font("Arial Narrow", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb2.Location = new System.Drawing.Point(12, 271);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(872, 576);
            this.rtb2.TabIndex = 10;
            this.rtb2.Text = "";
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 849);
            this.Controls.Add(this.rtb2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.Space_Count_Ch);
            this.Controls.Add(this.Media_Info_Ch);
            this.Controls.Add(this.Progress_But);
            this.Controls.Add(this.Space_Count_RBut);
            this.Controls.Add(this.Work_Rbut);
            this.Name = "Main_form";
            this.Text = "Main_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Work_Rbut;
        private System.Windows.Forms.RadioButton Space_Count_RBut;
        private System.Windows.Forms.Button Progress_But;
        private System.Windows.Forms.CheckBox Media_Info_Ch;
        private System.Windows.Forms.CheckBox Space_Count_Ch;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button lab;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox rtb2;
    }
}