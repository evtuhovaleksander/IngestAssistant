namespace Ingest_Administrator
{
    partial class Update_Prepare
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
            this.label1 = new System.Windows.Forms.Label();
            this.Browse_But = new System.Windows.Forms.Button();
            this.Important_ChBox = new System.Windows.Forms.CheckBox();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.Prepare_But = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Path_TBox
            // 
            this.Path_TBox.Enabled = false;
            this.Path_TBox.Location = new System.Drawing.Point(64, 12);
            this.Path_TBox.Name = "Path_TBox";
            this.Path_TBox.Size = new System.Drawing.Size(498, 22);
            this.Path_TBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Browse_But
            // 
            this.Browse_But.Location = new System.Drawing.Point(568, 0);
            this.Browse_But.Name = "Browse_But";
            this.Browse_But.Size = new System.Drawing.Size(75, 50);
            this.Browse_But.TabIndex = 2;
            this.Browse_But.Text = "указать путь";
            this.Browse_But.UseVisualStyleBackColor = true;
            this.Browse_But.Click += new System.EventHandler(this.Browse_But_Click);
            // 
            // Important_ChBox
            // 
            this.Important_ChBox.AutoSize = true;
            this.Important_ChBox.Location = new System.Drawing.Point(15, 40);
            this.Important_ChBox.Name = "Important_ChBox";
            this.Important_ChBox.Size = new System.Drawing.Size(139, 21);
            this.Important_ChBox.TabIndex = 3;
            this.Important_ChBox.Text = "Обязательность";
            this.Important_ChBox.UseVisualStyleBackColor = true;
            // 
            // Prepare_But
            // 
            this.Prepare_But.Location = new System.Drawing.Point(207, 84);
            this.Prepare_But.Name = "Prepare_But";
            this.Prepare_But.Size = new System.Drawing.Size(158, 23);
            this.Prepare_But.TabIndex = 7;
            this.Prepare_But.Text = "Подготовить";
            this.Prepare_But.UseVisualStyleBackColor = true;
            this.Prepare_But.Click += new System.EventHandler(this.Prepare_But_Click);
            // 
            // Update_Prepare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 126);
            this.Controls.Add(this.Prepare_But);
            this.Controls.Add(this.Important_ChBox);
            this.Controls.Add(this.Browse_But);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Path_TBox);
            this.Name = "Update_Prepare";
            this.Text = "Update_Prepare";
            this.Load += new System.EventHandler(this.Update_Prepare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Path_TBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Browse_But;
        private System.Windows.Forms.CheckBox Important_ChBox;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Button Prepare_But;
    }
}