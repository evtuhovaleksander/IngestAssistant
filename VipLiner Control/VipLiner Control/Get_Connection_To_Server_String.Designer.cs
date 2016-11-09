namespace Ingest_Assistant
{
    partial class Get_Connection_To_Server_String
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
            this.Connection_TBox = new System.Windows.Forms.TextBox();
            this.Confirm_But = new System.Windows.Forms.Button();
            this.Cancel_But = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Connection_TBox
            // 
            this.Connection_TBox.Location = new System.Drawing.Point(9, 10);
            this.Connection_TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Connection_TBox.Name = "Connection_TBox";
            this.Connection_TBox.Size = new System.Drawing.Size(1002, 20);
            this.Connection_TBox.TabIndex = 0;
            this.Connection_TBox.Text = "server=10.2.102.108;database=ingestassistantsettingsbase;user id=IA;password=QAz1" +
    "23456;";
            // 
            // Confirm_But
            // 
            this.Confirm_But.Location = new System.Drawing.Point(9, 32);
            this.Confirm_But.Margin = new System.Windows.Forms.Padding(2);
            this.Confirm_But.Name = "Confirm_But";
            this.Confirm_But.Size = new System.Drawing.Size(104, 47);
            this.Confirm_But.TabIndex = 1;
            this.Confirm_But.Text = "Подтвердить путь к БД";
            this.Confirm_But.UseVisualStyleBackColor = true;
            this.Confirm_But.Click += new System.EventHandler(this.Confirm_But_Click);
            // 
            // Cancel_But
            // 
            this.Cancel_But.Location = new System.Drawing.Point(117, 32);
            this.Cancel_But.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel_But.Name = "Cancel_But";
            this.Cancel_But.Size = new System.Drawing.Size(130, 23);
            this.Cancel_But.TabIndex = 2;
            this.Cancel_But.Text = "Закрыть программу";
            this.Cancel_But.UseVisualStyleBackColor = true;
            this.Cancel_But.Click += new System.EventHandler(this.Cancel_But_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(781, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Подключение к резервному серверу компании ТВ ЦЕНТР";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Location = new System.Drawing.Point(547, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Подключение к ОСНОВНОМУ серверу компании ТВ ЦЕНТР";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Get_Connection_To_Server_String
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 84);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cancel_But);
            this.Controls.Add(this.Confirm_But);
            this.Controls.Add(this.Connection_TBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Get_Connection_To_Server_String";
            this.Text = "Get_Connection_To_Server_String";
            this.Load += new System.EventHandler(this.Get_Connection_To_Server_String_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Connection_TBox;
        private System.Windows.Forms.Button Confirm_But;
        private System.Windows.Forms.Button Cancel_But;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}