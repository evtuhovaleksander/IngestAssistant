namespace Ingest_Assistant
{
    partial class SQL_Wait_Form
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
            this.Info_Label = new System.Windows.Forms.Label();
            this.Pr_Label = new System.Windows.Forms.Label();
            this.Progress_Bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Info_Label
            // 
            this.Info_Label.AutoSize = true;
            this.Info_Label.Location = new System.Drawing.Point(12, 9);
            this.Info_Label.Name = "Info_Label";
            this.Info_Label.Size = new System.Drawing.Size(12, 17);
            this.Info_Label.TabIndex = 0;
            this.Info_Label.Text = " ";
            // 
            // Pr_Label
            // 
            this.Pr_Label.AutoSize = true;
            this.Pr_Label.Location = new System.Drawing.Point(181, 58);
            this.Pr_Label.Name = "Pr_Label";
            this.Pr_Label.Size = new System.Drawing.Size(12, 17);
            this.Pr_Label.TabIndex = 1;
            this.Pr_Label.Text = " ";
            // 
            // Progress_Bar
            // 
            this.Progress_Bar.Location = new System.Drawing.Point(3, 32);
            this.Progress_Bar.Name = "Progress_Bar";
            this.Progress_Bar.Size = new System.Drawing.Size(419, 23);
            this.Progress_Bar.TabIndex = 2;
            // 
            // SQL_Wait_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 87);
            this.Controls.Add(this.Pr_Label);
            this.Controls.Add(this.Info_Label);
            this.Controls.Add(this.Progress_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SQL_Wait_Form";
            this.Text = "Ожидание ответа базы данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info_Label;
        private System.Windows.Forms.Label Pr_Label;
        private System.Windows.Forms.ProgressBar Progress_Bar;
    }
}