namespace Ingest_Assistant
{
    partial class Ask_MessageBOX
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
            this.Message_TBox = new System.Windows.Forms.TextBox();
            this.YES_But = new System.Windows.Forms.Button();
            this.NO_But = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message_TBox
            // 
            this.Message_TBox.Location = new System.Drawing.Point(12, 12);
            this.Message_TBox.Multiline = true;
            this.Message_TBox.Name = "Message_TBox";
            this.Message_TBox.Size = new System.Drawing.Size(1072, 159);
            this.Message_TBox.TabIndex = 0;
            // 
            // YES_But
            // 
            this.YES_But.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.YES_But.Location = new System.Drawing.Point(12, 177);
            this.YES_But.Name = "YES_But";
            this.YES_But.Size = new System.Drawing.Size(533, 58);
            this.YES_But.TabIndex = 1;
            this.YES_But.Text = "Yes";
            this.YES_But.UseVisualStyleBackColor = false;
            this.YES_But.Click += new System.EventHandler(this.YES_But_Click);
            // 
            // NO_But
            // 
            this.NO_But.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NO_But.Location = new System.Drawing.Point(551, 177);
            this.NO_But.Name = "NO_But";
            this.NO_But.Size = new System.Drawing.Size(533, 58);
            this.NO_But.TabIndex = 2;
            this.NO_But.Text = "No";
            this.NO_But.UseVisualStyleBackColor = false;
            this.NO_But.Click += new System.EventHandler(this.NO_But_Click);
            // 
            // Ask_MessageBOX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 236);
            this.Controls.Add(this.NO_But);
            this.Controls.Add(this.YES_But);
            this.Controls.Add(this.Message_TBox);
            this.Name = "Ask_MessageBOX";
            this.Text = "Ask_MessageBOX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Message_TBox;
        private System.Windows.Forms.Button YES_But;
        private System.Windows.Forms.Button NO_But;
    }
}