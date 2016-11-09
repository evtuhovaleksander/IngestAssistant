namespace Ingest_Assistant
{
    partial class FilesCopy
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
            this.Cur_PrBar = new System.Windows.Forms.ProgressBar();
            this.Total_PrBar = new System.Windows.Forms.ProgressBar();
            this.cur_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.all_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cur_PrBar
            // 
            this.Cur_PrBar.Location = new System.Drawing.Point(12, 110);
            this.Cur_PrBar.Name = "Cur_PrBar";
            this.Cur_PrBar.Size = new System.Drawing.Size(1130, 37);
            this.Cur_PrBar.TabIndex = 0;
            // 
            // Total_PrBar
            // 
            this.Total_PrBar.Location = new System.Drawing.Point(12, 12);
            this.Total_PrBar.Name = "Total_PrBar";
            this.Total_PrBar.Size = new System.Drawing.Size(1130, 37);
            this.Total_PrBar.TabIndex = 1;
            // 
            // cur_label
            // 
            this.cur_label.AutoSize = true;
            this.cur_label.Location = new System.Drawing.Point(293, 61);
            this.cur_label.Name = "cur_label";
            this.cur_label.Size = new System.Drawing.Size(46, 17);
            this.cur_label.TabIndex = 2;
            this.cur_label.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // all_label
            // 
            this.all_label.AutoSize = true;
            this.all_label.Location = new System.Drawing.Point(471, 61);
            this.all_label.Name = "all_label";
            this.all_label.Size = new System.Drawing.Size(46, 17);
            this.all_label.TabIndex = 4;
            this.all_label.Text = "label3";
            // 
            // FilesCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 159);
            this.Controls.Add(this.all_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cur_label);
            this.Controls.Add(this.Total_PrBar);
            this.Controls.Add(this.Cur_PrBar);
            this.Name = "FilesCopy";
            this.Text = "FilesCopy";
            this.Load += new System.EventHandler(this.FilesCopy_Load);
            this.Shown += new System.EventHandler(this.FilesCopy_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Cur_PrBar;
        private System.Windows.Forms.ProgressBar Total_PrBar;
        private System.Windows.Forms.Label cur_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label all_label;
    }
}