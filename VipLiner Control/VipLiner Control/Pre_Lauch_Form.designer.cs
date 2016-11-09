namespace Ingest_Assistant
{
    partial class Pre_Lauch_Form
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
            this.Timerr = new System.Windows.Forms.Timer(this.components);
            this.prBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.p_box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.p_box)).BeginInit();
            this.SuspendLayout();
            // 
            // Timerr
            // 
            this.Timerr.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // prBar
            // 
            this.prBar.Location = new System.Drawing.Point(0, 708);
            this.prBar.Name = "prBar";
            this.prBar.Size = new System.Drawing.Size(283, 41);
            this.prBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 728);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ЗАГРУЗКА ИНФОРМАЦИИ";
            // 
            // p_box
            // 
            this.p_box.Image = global::Ingest_Assistant.Properties.Resources.alpha_4;
            this.p_box.Location = new System.Drawing.Point(0, -2);
            this.p_box.Name = "p_box";
            this.p_box.Size = new System.Drawing.Size(975, 751);
            this.p_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_box.TabIndex = 0;
            this.p_box.TabStop = false;
            this.p_box.Click += new System.EventHandler(this.p_box_Click);
            // 
            // Pre_Lauch_Form
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(973, 750);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prBar);
            this.Controls.Add(this.p_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Pre_Lauch_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ingest Assistant";
            this.Load += new System.EventHandler(this.Pre_Lauch_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox p_box;
        private System.Windows.Forms.Timer Timerr;
        private System.Windows.Forms.ProgressBar prBar;
        private System.Windows.Forms.Label label1;
    }
}