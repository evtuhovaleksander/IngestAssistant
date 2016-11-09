namespace TestFileCopy
{
    partial class CopyFormOLD
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
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.prMain = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.Label();
            this.pr_ALL = new System.Windows.Forms.ProgressBar();
            this.total_progress = new System.Windows.Forms.Label();
            this.Delay = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(12, 99);
            this.prMain.Margin = new System.Windows.Forms.Padding(4);
            this.prMain.Name = "prMain";
            this.prMain.Size = new System.Drawing.Size(806, 28);
            this.prMain.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 213);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            this.lblInfo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Прервать копирование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(413, 141);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(28, 17);
            this.progress.TabIndex = 7;
            this.progress.Text = "     ";
            // 
            // pr_ALL
            // 
            this.pr_ALL.Location = new System.Drawing.Point(12, 12);
            this.pr_ALL.Name = "pr_ALL";
            this.pr_ALL.Size = new System.Drawing.Size(807, 25);
            this.pr_ALL.TabIndex = 8;
            // 
            // total_progress
            // 
            this.total_progress.AutoSize = true;
            this.total_progress.Location = new System.Drawing.Point(373, 40);
            this.total_progress.Name = "total_progress";
            this.total_progress.Size = new System.Drawing.Size(68, 17);
            this.total_progress.TabIndex = 9;
            this.total_progress.Text = "               ";
            // 
            // Delay
            // 
            this.Delay.Tick += new System.EventHandler(this.Delay_Tick);
            // 
            // CopyFormOLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 201);
            this.Controls.Add(this.total_progress);
            this.Controls.Add(this.pr_ALL);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyFormOLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подготовка к копированию";
            this.Load += new System.EventHandler(this.CopyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar prMain;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label progress;
        private System.Windows.Forms.ProgressBar pr_ALL;
        private System.Windows.Forms.Label total_progress;
        private System.Windows.Forms.Timer Delay;
    }
}

