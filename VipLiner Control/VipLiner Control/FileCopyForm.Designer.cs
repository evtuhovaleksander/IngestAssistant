namespace Ingest_Assistant
{
    partial class FileCopyForm
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
            this.components = new System.ComponentModel.Container();
            this.total_prBar = new System.Windows.Forms.ProgressBar();
            this.cur_prBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Copy_Delay = new System.Windows.Forms.Timer(this.components);
            this.bg_Worker = new System.ComponentModel.BackgroundWorker();
            this.Progress_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // total_prBar
            // 
            this.total_prBar.Location = new System.Drawing.Point(12, 12);
            this.total_prBar.Name = "total_prBar";
            this.total_prBar.Size = new System.Drawing.Size(1109, 23);
            this.total_prBar.TabIndex = 0;
            // 
            // cur_prBar
            // 
            this.cur_prBar.Location = new System.Drawing.Point(12, 67);
            this.cur_prBar.Name = "cur_prBar";
            this.cur_prBar.Size = new System.Drawing.Size(1109, 23);
            this.cur_prBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Прервать копирование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Copy_Delay
            // 
            this.Copy_Delay.Tick += new System.EventHandler(this.Copy_Delay_Tick);
            // 
            // bg_Worker
            // 
            this.bg_Worker.WorkerReportsProgress = true;
            this.bg_Worker.WorkerSupportsCancellation = true;
            
            // Progress_timer
            // 
            this.Progress_timer.Tick += new System.EventHandler(this.Progress_timer_Tick);
            // 
            // FileCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 181);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cur_prBar);
            this.Controls.Add(this.total_prBar);
            this.Name = "FileCopyForm";
            this.Text = "FileCopyForm";
            this.Load += new System.EventHandler(this.FileCopyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar total_prBar;
        private System.Windows.Forms.ProgressBar cur_prBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Copy_Delay;
        public System.ComponentModel.BackgroundWorker bg_Worker;
        private System.Windows.Forms.Timer Progress_timer;
    }
}