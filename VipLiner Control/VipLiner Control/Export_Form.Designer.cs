namespace Ingest_Assistant
{
    partial class Export_Form
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
            this.ProgreeBar = new System.Windows.Forms.ProgressBar();
            this.Progress_Label = new System.Windows.Forms.Label();
            this.Break_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgreeBar
            // 
            this.ProgreeBar.Location = new System.Drawing.Point(12, 72);
            this.ProgreeBar.Name = "ProgreeBar";
            this.ProgreeBar.Size = new System.Drawing.Size(1011, 65);
            this.ProgreeBar.TabIndex = 0;
            // 
            // Progress_Label
            // 
            this.Progress_Label.AutoSize = true;
            this.Progress_Label.Location = new System.Drawing.Point(444, 96);
            this.Progress_Label.Name = "Progress_Label";
            this.Progress_Label.Size = new System.Drawing.Size(0, 17);
            this.Progress_Label.TabIndex = 1;
            // 
            // Break_Button
            // 
            this.Break_Button.Location = new System.Drawing.Point(450, 14);
            this.Break_Button.Name = "Break_Button";
            this.Break_Button.Size = new System.Drawing.Size(111, 46);
            this.Break_Button.TabIndex = 2;
            this.Break_Button.Text = "Прервать операцию";
            this.Break_Button.UseVisualStyleBackColor = true;
            this.Break_Button.Click += new System.EventHandler(this.Break_Button_Click);
            // 
            // Export_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 149);
            this.Controls.Add(this.Break_Button);
            this.Controls.Add(this.Progress_Label);
            this.Controls.Add(this.ProgreeBar);
            this.Name = "Export_Form";
            this.Text = "Export_Form";
            this.Load += new System.EventHandler(this.Export_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgreeBar;
        private System.Windows.Forms.Label Progress_Label;
        private System.Windows.Forms.Button Break_Button;
    }
}