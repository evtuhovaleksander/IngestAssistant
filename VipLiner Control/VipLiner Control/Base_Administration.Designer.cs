namespace Ingest_Assistant
{
    partial class Base_Administration
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
            this.Col = new System.Windows.Forms.TextBox();
            this.Collect_Info_But = new System.Windows.Forms.Button();
            this.Base_Ave_GrBox = new System.Windows.Forms.GroupBox();
            this.Base_Arch_But = new System.Windows.Forms.Button();
            this.Admin_GrBox = new System.Windows.Forms.GroupBox();
            this.Base_Del_But = new System.Windows.Forms.Button();
            this.Base_Wake_But = new System.Windows.Forms.Button();
            this.Base_Colection_CmBox = new System.Windows.Forms.ComboBox();
            this.Unlock_Admin_But = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Size = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Last = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Refresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Base_Ave_GrBox.SuspendLayout();
            this.Admin_GrBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Col
            // 
            this.Col.Location = new System.Drawing.Point(92, 20);
            this.Col.Margin = new System.Windows.Forms.Padding(2);
            this.Col.Name = "Col";
            this.Col.Size = new System.Drawing.Size(85, 20);
            this.Col.TabIndex = 0;
            // 
            // Collect_Info_But
            // 
            this.Collect_Info_But.Location = new System.Drawing.Point(368, 15);
            this.Collect_Info_But.Margin = new System.Windows.Forms.Padding(2);
            this.Collect_Info_But.Name = "Collect_Info_But";
            this.Collect_Info_But.Size = new System.Drawing.Size(81, 53);
            this.Collect_Info_But.TabIndex = 1;
            this.Collect_Info_But.Text = "Собрать информацию";
            this.Collect_Info_But.UseVisualStyleBackColor = true;
            this.Collect_Info_But.Click += new System.EventHandler(this.Collect_Info_But_Click);
            // 
            // Base_Ave_GrBox
            // 
            this.Base_Ave_GrBox.Controls.Add(this.Base_Arch_But);
            this.Base_Ave_GrBox.Location = new System.Drawing.Point(9, 10);
            this.Base_Ave_GrBox.Margin = new System.Windows.Forms.Padding(2);
            this.Base_Ave_GrBox.Name = "Base_Ave_GrBox";
            this.Base_Ave_GrBox.Padding = new System.Windows.Forms.Padding(2);
            this.Base_Ave_GrBox.Size = new System.Drawing.Size(260, 80);
            this.Base_Ave_GrBox.TabIndex = 2;
            this.Base_Ave_GrBox.TabStop = false;
            this.Base_Ave_GrBox.Text = "Архивирование Базы";
            // 
            // Base_Arch_But
            // 
            this.Base_Arch_But.Location = new System.Drawing.Point(9, 26);
            this.Base_Arch_But.Margin = new System.Windows.Forms.Padding(2);
            this.Base_Arch_But.Name = "Base_Arch_But";
            this.Base_Arch_But.Size = new System.Drawing.Size(236, 42);
            this.Base_Arch_But.TabIndex = 0;
            this.Base_Arch_But.Text = "Архивировать базу";
            this.Base_Arch_But.UseVisualStyleBackColor = true;
            this.Base_Arch_But.Click += new System.EventHandler(this.Base_Arch_But_Click);
            // 
            // Admin_GrBox
            // 
            this.Admin_GrBox.Controls.Add(this.Base_Del_But);
            this.Admin_GrBox.Controls.Add(this.Base_Wake_But);
            this.Admin_GrBox.Controls.Add(this.Base_Colection_CmBox);
            this.Admin_GrBox.Enabled = false;
            this.Admin_GrBox.Location = new System.Drawing.Point(9, 128);
            this.Admin_GrBox.Margin = new System.Windows.Forms.Padding(2);
            this.Admin_GrBox.Name = "Admin_GrBox";
            this.Admin_GrBox.Padding = new System.Windows.Forms.Padding(2);
            this.Admin_GrBox.Size = new System.Drawing.Size(260, 118);
            this.Admin_GrBox.TabIndex = 3;
            this.Admin_GrBox.TabStop = false;
            this.Admin_GrBox.Text = "Расширенное Администрирование";
            // 
            // Base_Del_But
            // 
            this.Base_Del_But.Location = new System.Drawing.Point(4, 78);
            this.Base_Del_But.Margin = new System.Windows.Forms.Padding(2);
            this.Base_Del_But.Name = "Base_Del_But";
            this.Base_Del_But.Size = new System.Drawing.Size(241, 24);
            this.Base_Del_But.TabIndex = 2;
            this.Base_Del_But.Text = "Удалить базу";
            this.Base_Del_But.UseVisualStyleBackColor = true;
            this.Base_Del_But.Click += new System.EventHandler(this.Base_Del_But_Click);
            // 
            // Base_Wake_But
            // 
            this.Base_Wake_But.Location = new System.Drawing.Point(4, 41);
            this.Base_Wake_But.Margin = new System.Windows.Forms.Padding(2);
            this.Base_Wake_But.Name = "Base_Wake_But";
            this.Base_Wake_But.Size = new System.Drawing.Size(240, 27);
            this.Base_Wake_But.TabIndex = 1;
            this.Base_Wake_But.Text = "Востановить базу";
            this.Base_Wake_But.UseVisualStyleBackColor = true;
            this.Base_Wake_But.Click += new System.EventHandler(this.Base_Wake_But_Click);
            // 
            // Base_Colection_CmBox
            // 
            this.Base_Colection_CmBox.FormattingEnabled = true;
            this.Base_Colection_CmBox.Location = new System.Drawing.Point(4, 17);
            this.Base_Colection_CmBox.Margin = new System.Windows.Forms.Padding(2);
            this.Base_Colection_CmBox.Name = "Base_Colection_CmBox";
            this.Base_Colection_CmBox.Size = new System.Drawing.Size(241, 21);
            this.Base_Colection_CmBox.TabIndex = 0;
            // 
            // Unlock_Admin_But
            // 
            this.Unlock_Admin_But.Location = new System.Drawing.Point(9, 102);
            this.Unlock_Admin_But.Margin = new System.Windows.Forms.Padding(2);
            this.Unlock_Admin_But.Name = "Unlock_Admin_But";
            this.Unlock_Admin_But.Size = new System.Drawing.Size(187, 21);
            this.Unlock_Admin_But.TabIndex = 4;
            this.Unlock_Admin_But.Text = "Разблокировать";
            this.Unlock_Admin_But.UseVisualStyleBackColor = true;
            this.Unlock_Admin_But.Click += new System.EventHandler(this.Unlock_Admin_But_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Size);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Last);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Col);
            this.groupBox1.Controls.Add(this.Collect_Info_But);
            this.groupBox1.Location = new System.Drawing.Point(275, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(453, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // Size
            // 
            this.Size.Location = new System.Drawing.Point(92, 71);
            this.Size.Margin = new System.Windows.Forms.Padding(2);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(85, 20);
            this.Size.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Обьем";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Последняя за";
            // 
            // Last
            // 
            this.Last.Location = new System.Drawing.Point(92, 42);
            this.Last.Margin = new System.Windows.Forms.Padding(2);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(262, 20);
            this.Last.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Копий базы";
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(200, 102);
            this.Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(68, 25);
            this.Refresh.TabIndex = 6;
            this.Refresh.Text = "Обновить";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "mB";
            // 
            // Base_Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 256);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Unlock_Admin_But);
            this.Controls.Add(this.Admin_GrBox);
            this.Controls.Add(this.Base_Ave_GrBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Base_Administration";
            this.Text = "Base_Administration";
            this.Load += new System.EventHandler(this.Base_Administration_Load);
            this.Base_Ave_GrBox.ResumeLayout(false);
            this.Admin_GrBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Col;
        private System.Windows.Forms.Button Collect_Info_But;
        private System.Windows.Forms.GroupBox Base_Ave_GrBox;
        private System.Windows.Forms.Button Base_Arch_But;
        private System.Windows.Forms.GroupBox Admin_GrBox;
        private System.Windows.Forms.Button Base_Wake_But;
        private System.Windows.Forms.ComboBox Base_Colection_CmBox;
        private System.Windows.Forms.Button Unlock_Admin_But;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Last;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Base_Del_But;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.TextBox Size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}