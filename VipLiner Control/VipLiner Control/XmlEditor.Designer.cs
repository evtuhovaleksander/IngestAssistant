namespace Ingest_Assistant
{
    partial class XmlEditor
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
            this.Path_TBox = new System.Windows.Forms.TextBox();
            this.Open_But = new System.Windows.Forms.Button();
            this.Save_But = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Path_TBox
            // 
            this.Path_TBox.Location = new System.Drawing.Point(12, 12);
            this.Path_TBox.Name = "Path_TBox";
            this.Path_TBox.Size = new System.Drawing.Size(679, 22);
            this.Path_TBox.TabIndex = 0;
            // 
            // Open_But
            // 
            this.Open_But.Location = new System.Drawing.Point(697, 11);
            this.Open_But.Name = "Open_But";
            this.Open_But.Size = new System.Drawing.Size(166, 31);
            this.Open_But.TabIndex = 1;
            this.Open_But.Text = "Open";
            this.Open_But.UseVisualStyleBackColor = true;
            this.Open_But.Click += new System.EventHandler(this.Open_But_Click);
            // 
            // Save_But
            // 
            this.Save_But.Location = new System.Drawing.Point(869, 12);
            this.Save_But.Name = "Save_But";
            this.Save_But.Size = new System.Drawing.Size(166, 30);
            this.Save_But.TabIndex = 2;
            this.Save_But.Text = "Save";
            this.Save_But.UseVisualStyleBackColor = true;
            this.Save_But.Click += new System.EventHandler(this.Save_But_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 40);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(679, 23);
            this.progressBar.TabIndex = 4;
            // 
            // XmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 67);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save_But);
            this.Controls.Add(this.Open_But);
            this.Controls.Add(this.Path_TBox);
            this.Name = "XmlEditor";
            this.Text = "XmlEditor";
            this.Load += new System.EventHandler(this.XmlEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Path_TBox;
        private System.Windows.Forms.Button Open_But;
        private System.Windows.Forms.Button Save_But;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}