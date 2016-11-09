namespace Ingest_Assistant
{
    partial class UpdateForm
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
            this.But = new System.Windows.Forms.Button();
            this.Lauch_But = new System.Windows.Forms.Button();
            this.Update_But = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // But
            // 
            this.But.Location = new System.Drawing.Point(12, 37);
            this.But.Name = "But";
            this.But.Size = new System.Drawing.Size(312, 69);
            this.But.TabIndex = 0;
            this.But.UseVisualStyleBackColor = true;
            this.But.Click += new System.EventHandler(this.But_Click);
            // 
            // Lauch_But
            // 
            this.Lauch_But.Location = new System.Drawing.Point(12, 131);
            this.Lauch_But.Name = "Lauch_But";
            this.Lauch_But.Size = new System.Drawing.Size(148, 60);
            this.Lauch_But.TabIndex = 2;
            this.Lauch_But.Text = "Запустить";
            this.Lauch_But.UseVisualStyleBackColor = true;
            this.Lauch_But.Click += new System.EventHandler(this.Lauch_But_Click);
            // 
            // Update_But
            // 
            this.Update_But.Location = new System.Drawing.Point(176, 131);
            this.Update_But.Name = "Update_But";
            this.Update_But.Size = new System.Drawing.Size(148, 60);
            this.Update_But.TabIndex = 3;
            this.Update_But.Text = "Обновить";
            this.Update_But.UseVisualStyleBackColor = true;
            this.Update_But.Click += new System.EventHandler(this.Update_But_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 214);
            this.Controls.Add(this.Update_But);
            this.Controls.Add(this.Lauch_But);
            this.Controls.Add(this.But);
            this.Name = "UpdateForm";
            this.Text = "Update";
            this.Load += new System.EventHandler(this.SF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button But;
        private System.Windows.Forms.Button Lauch_But;
        private System.Windows.Forms.Button Update_But;
    }
}