namespace Ingest_Assistant
{
    partial class MessageBOX
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
            this.Close_But = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message_TBox
            // 
            this.Message_TBox.Location = new System.Drawing.Point(12, 12);
            this.Message_TBox.Multiline = true;
            this.Message_TBox.Name = "Message_TBox";
            this.Message_TBox.Size = new System.Drawing.Size(461, 289);
            this.Message_TBox.TabIndex = 0;
            // 
            // Close_But
            // 
            this.Close_But.Location = new System.Drawing.Point(55, 320);
            this.Close_But.Name = "Close_But";
            this.Close_But.Size = new System.Drawing.Size(347, 31);
            this.Close_But.TabIndex = 1;
            this.Close_But.Text = "OK";
            this.Close_But.UseVisualStyleBackColor = true;
            this.Close_But.Click += new System.EventHandler(this.Close_But_Click);
            // 
            // MessageBOX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 363);
            this.Controls.Add(this.Close_But);
            this.Controls.Add(this.Message_TBox);
            this.Name = "MessageBOX";
            this.Text = "MessageBOX";
            this.Load += new System.EventHandler(this.MessageBOX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Message_TBox;
        private System.Windows.Forms.Button Close_But;
    }
}