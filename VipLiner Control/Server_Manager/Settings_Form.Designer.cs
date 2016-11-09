namespace Server_Manager
{
    partial class Settings_Form
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
            this.work = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.arch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.master = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.basse = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // work
            // 
            this.work.Location = new System.Drawing.Point(60, 12);
            this.work.Name = "work";
            this.work.Size = new System.Drawing.Size(1085, 20);
            this.work.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Work";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Arch";
            // 
            // arch
            // 
            this.arch.Location = new System.Drawing.Point(60, 38);
            this.arch.Name = "arch";
            this.arch.Size = new System.Drawing.Size(1085, 20);
            this.arch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stock";
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(60, 64);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(1085, 20);
            this.stock.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Master";
            // 
            // master
            // 
            this.master.Location = new System.Drawing.Point(60, 90);
            this.master.Name = "master";
            this.master.Size = new System.Drawing.Size(1085, 20);
            this.master.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Base";
            // 
            // basse
            // 
            this.basse.Location = new System.Drawing.Point(60, 116);
            this.basse.Name = "basse";
            this.basse.Size = new System.Drawing.Size(1085, 20);
            this.basse.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 402);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1085, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = " server=10.2.102.86;database=ingestassistantmainbase;user id=tus;password=QAz1234" +
    "56;";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 376);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1085, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = " \\\\10.2.68.19\\Inbox\\_MASTER_Prep";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(60, 350);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1085, 20);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "\\\\10.2.68.19\\Inbox\\Stock";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(60, 324);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(1085, 20);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "\\\\10.2.68.19\\Work\\Ingest_2_16\\WorkARCHIVE";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(60, 298);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(1085, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "\\\\10.2.68.19\\Work\\Ingest_2_16";
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 529);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.basse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.master);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.work);
            this.Name = "Settings_Form";
            this.Text = "Settings_Form";
            this.Load += new System.EventHandler(this.Settings_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox work;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox arch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox master;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox basse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}