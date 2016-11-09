namespace Ingest_Assistant
{
    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_but = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Request_But = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.login.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.login.Location = new System.Drawing.Point(62, 10);
            this.login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(175, 20);
            this.login.TabIndex = 0;
            this.login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_KeyPress);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(62, 32);
            this.password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(175, 20);
            this.password.TabIndex = 1;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // login_but
            // 
            this.login_but.Location = new System.Drawing.Point(86, 55);
            this.login_but.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.login_but.Name = "login_but";
            this.login_but.Size = new System.Drawing.Size(70, 29);
            this.login_but.TabIndex = 4;
            this.login_but.Text = "Login";
            this.login_but.UseVisualStyleBackColor = true;
            this.login_but.Click += new System.EventHandler(this.login_but_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Request_But
            // 
            this.Request_But.Location = new System.Drawing.Point(62, 55);
            this.Request_But.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Request_But.Name = "Request_But";
            this.Request_But.Size = new System.Drawing.Size(172, 39);
            this.Request_But.TabIndex = 6;
            this.Request_But.Text = "Подтвердить выполнение операции";
            this.Request_But.UseVisualStyleBackColor = true;
            this.Request_But.Click += new System.EventHandler(this.Request_But_Click);
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 99);
            this.Controls.Add(this.Request_But);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.login_but);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PasswordForm";
            this.Text = "Введите логин и пароль";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login_but;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Request_But;
    }
}