namespace Ingest_Assistant
{
    partial class Log_Col_Ask
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
            this.start_bar = new System.Windows.Forms.TrackBar();
            this.stop_bar = new System.Windows.Forms.TrackBar();
            this.Accept = new System.Windows.Forms.Button();
            this.start_label = new System.Windows.Forms.Label();
            this.stop_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Limited_RBut = new System.Windows.Forms.RadioButton();
            this.Unlimited_RBut = new System.Windows.Forms.RadioButton();
            this.All_RBut = new System.Windows.Forms.RadioButton();
            this.col_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.start_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_bar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_bar
            // 
            this.start_bar.Location = new System.Drawing.Point(12, 63);
            this.start_bar.Name = "start_bar";
            this.start_bar.Size = new System.Drawing.Size(1015, 45);
            this.start_bar.TabIndex = 0;
            this.start_bar.Scroll += new System.EventHandler(this.start_bar_Scroll);
            this.start_bar.ValueChanged += new System.EventHandler(this.start_bar_ValueChanged);
            // 
            // stop_bar
            // 
            this.stop_bar.Location = new System.Drawing.Point(12, 12);
            this.stop_bar.Name = "stop_bar";
            this.stop_bar.Size = new System.Drawing.Size(1015, 45);
            this.stop_bar.TabIndex = 1;
            this.stop_bar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.stop_bar.ValueChanged += new System.EventHandler(this.stop_bar_ValueChanged);
            this.stop_bar.VisibleChanged += new System.EventHandler(this.stop_bar_VisibleChanged);
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(226, 114);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(578, 23);
            this.Accept.TabIndex = 2;
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Location = new System.Drawing.Point(12, 44);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(35, 13);
            this.start_label.TabIndex = 3;
            this.start_label.Text = "label1";
            // 
            // stop_label
            // 
            this.stop_label.AutoSize = true;
            this.stop_label.Location = new System.Drawing.Point(999, 44);
            this.stop_label.Name = "stop_label";
            this.stop_label.Size = new System.Drawing.Size(35, 13);
            this.stop_label.TabIndex = 4;
            this.stop_label.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.All_RBut);
            this.groupBox1.Controls.Add(this.Unlimited_RBut);
            this.groupBox1.Controls.Add(this.Limited_RBut);
            this.groupBox1.Location = new System.Drawing.Point(15, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Опции отображения";
            // 
            // Limited_RBut
            // 
            this.Limited_RBut.AutoSize = true;
            this.Limited_RBut.Checked = true;
            this.Limited_RBut.Location = new System.Drawing.Point(7, 20);
            this.Limited_RBut.Name = "Limited_RBut";
            this.Limited_RBut.Size = new System.Drawing.Size(150, 17);
            this.Limited_RBut.TabIndex = 0;
            this.Limited_RBut.TabStop = true;
            this.Limited_RBut.Text = "Ограниченный диапазон";
            this.Limited_RBut.UseVisualStyleBackColor = true;
            this.Limited_RBut.CheckedChanged += new System.EventHandler(this.Limited_RBut_CheckedChanged);
            // 
            // Unlimited_RBut
            // 
            this.Unlimited_RBut.AutoSize = true;
            this.Unlimited_RBut.Location = new System.Drawing.Point(7, 43);
            this.Unlimited_RBut.Name = "Unlimited_RBut";
            this.Unlimited_RBut.Size = new System.Drawing.Size(162, 17);
            this.Unlimited_RBut.TabIndex = 1;
            this.Unlimited_RBut.Text = "Неограниченный диапазон";
            this.Unlimited_RBut.UseVisualStyleBackColor = true;
            // 
            // All_RBut
            // 
            this.All_RBut.AutoSize = true;
            this.All_RBut.Location = new System.Drawing.Point(7, 66);
            this.All_RBut.Name = "All_RBut";
            this.All_RBut.Size = new System.Drawing.Size(83, 17);
            this.All_RBut.TabIndex = 2;
            this.All_RBut.Text = "Все записи";
            this.All_RBut.UseVisualStyleBackColor = true;
            this.All_RBut.CheckedChanged += new System.EventHandler(this.All_RBut_CheckedChanged);
            // 
            // col_label
            // 
            this.col_label.AutoSize = true;
            this.col_label.Location = new System.Drawing.Point(504, 3);
            this.col_label.Name = "col_label";
            this.col_label.Size = new System.Drawing.Size(37, 13);
            this.col_label.TabIndex = 6;
            this.col_label.Text = "_____";
            // 
            // Log_Col_Ask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 248);
            this.Controls.Add(this.col_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stop_label);
            this.Controls.Add(this.start_label);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.stop_bar);
            this.Controls.Add(this.start_bar);
            this.Name = "Log_Col_Ask";
            this.Text = "Log_Col_Ask";
            this.Load += new System.EventHandler(this.Log_Col_Ask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.start_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_bar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar start_bar;
        private System.Windows.Forms.TrackBar stop_bar;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label stop_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton All_RBut;
        private System.Windows.Forms.RadioButton Unlimited_RBut;
        private System.Windows.Forms.RadioButton Limited_RBut;
        private System.Windows.Forms.Label col_label;
    }
}