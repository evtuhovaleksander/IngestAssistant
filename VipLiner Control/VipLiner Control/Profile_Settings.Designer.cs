namespace Ingest_Assistant
{
    partial class Profile_Settings
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
            this.Curent_Profile_TBox = new System.Windows.Forms.TextBox();
            this.Profiles_CmBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Load_Profile_But = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Confirm_Selected_Profile = new System.Windows.Forms.Button();
            this.Change_Unlock_But = new System.Windows.Forms.Button();
            this.System_Settings_Change_Button = new System.Windows.Forms.Button();
            this.Emergensy_Import = new System.Windows.Forms.Button();
            this.Hand_Emergensy = new System.Windows.Forms.Button();
            this.BP = new System.Windows.Forms.TextBox();
            this.Loged_as = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Curent_Profile_TBox
            // 
            this.Curent_Profile_TBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Curent_Profile_TBox.Location = new System.Drawing.Point(8, 22);
            this.Curent_Profile_TBox.Margin = new System.Windows.Forms.Padding(5);
            this.Curent_Profile_TBox.Name = "Curent_Profile_TBox";
            this.Curent_Profile_TBox.Size = new System.Drawing.Size(354, 22);
            this.Curent_Profile_TBox.TabIndex = 0;
            // 
            // Profiles_CmBox
            // 
            this.Profiles_CmBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Profiles_CmBox.FormattingEnabled = true;
            this.Profiles_CmBox.Location = new System.Drawing.Point(9, 22);
            this.Profiles_CmBox.Margin = new System.Windows.Forms.Padding(5);
            this.Profiles_CmBox.Name = "Profiles_CmBox";
            this.Profiles_CmBox.Size = new System.Drawing.Size(324, 24);
            this.Profiles_CmBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Load_Profile_But);
            this.groupBox1.Controls.Add(this.Profiles_CmBox);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(18, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(359, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор  профиля";
            // 
            // Load_Profile_But
            // 
            this.Load_Profile_But.Enabled = false;
            this.Load_Profile_But.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Load_Profile_But.Location = new System.Drawing.Point(10, 43);
            this.Load_Profile_But.Margin = new System.Windows.Forms.Padding(5);
            this.Load_Profile_But.Name = "Load_Profile_But";
            this.Load_Profile_But.Size = new System.Drawing.Size(323, 24);
            this.Load_Profile_But.TabIndex = 4;
            this.Load_Profile_But.Text = "Выбрать профиль";
            this.Load_Profile_But.UseVisualStyleBackColor = true;
            this.Load_Profile_But.Click += new System.EventHandler(this.Load_Profile_But_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Confirm_Selected_Profile);
            this.groupBox2.Controls.Add(this.Curent_Profile_TBox);
            this.groupBox2.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(477, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(26, 0);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Текущий профиль";
            // 
            // Confirm_Selected_Profile
            // 
            this.Confirm_Selected_Profile.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Confirm_Selected_Profile.Location = new System.Drawing.Point(22, 41);
            this.Confirm_Selected_Profile.Margin = new System.Windows.Forms.Padding(5);
            this.Confirm_Selected_Profile.Name = "Confirm_Selected_Profile";
            this.Confirm_Selected_Profile.Size = new System.Drawing.Size(235, 32);
            this.Confirm_Selected_Profile.TabIndex = 1;
            this.Confirm_Selected_Profile.Text = "Подтвердить текущий профиль";
            this.Confirm_Selected_Profile.UseVisualStyleBackColor = true;
            // 
            // Change_Unlock_But
            // 
            this.Change_Unlock_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Change_Unlock_But.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Change_Unlock_But.Location = new System.Drawing.Point(429, 100);
            this.Change_Unlock_But.Margin = new System.Windows.Forms.Padding(5);
            this.Change_Unlock_But.Name = "Change_Unlock_But";
            this.Change_Unlock_But.Size = new System.Drawing.Size(29, 0);
            this.Change_Unlock_But.TabIndex = 4;
            this.Change_Unlock_But.Text = "Сменить профиль";
            this.Change_Unlock_But.UseVisualStyleBackColor = true;
            // 
            // System_Settings_Change_Button
            // 
            this.System_Settings_Change_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.System_Settings_Change_Button.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.System_Settings_Change_Button.Location = new System.Drawing.Point(18, 175);
            this.System_Settings_Change_Button.Margin = new System.Windows.Forms.Padding(5);
            this.System_Settings_Change_Button.Name = "System_Settings_Change_Button";
            this.System_Settings_Change_Button.Size = new System.Drawing.Size(509, 27);
            this.System_Settings_Change_Button.TabIndex = 5;
            this.System_Settings_Change_Button.Text = "Редактировать настройки";
            this.System_Settings_Change_Button.UseVisualStyleBackColor = false;
            this.System_Settings_Change_Button.Visible = false;
            this.System_Settings_Change_Button.Click += new System.EventHandler(this.System_Settings_Change_Button_Click);
            // 
            // Emergensy_Import
            // 
            this.Emergensy_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Emergensy_Import.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Emergensy_Import.Location = new System.Drawing.Point(4, 3);
            this.Emergensy_Import.Margin = new System.Windows.Forms.Padding(5);
            this.Emergensy_Import.Name = "Emergensy_Import";
            this.Emergensy_Import.Size = new System.Drawing.Size(535, 199);
            this.Emergensy_Import.TabIndex = 7;
            this.Emergensy_Import.Text = "Аварийный импорт базы данных настроек";
            this.Emergensy_Import.UseVisualStyleBackColor = true;
            this.Emergensy_Import.Visible = false;
            this.Emergensy_Import.Click += new System.EventHandler(this.Emergensy_Import_Click);
            // 
            // Hand_Emergensy
            // 
            this.Hand_Emergensy.BackColor = System.Drawing.Color.Red;
            this.Hand_Emergensy.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hand_Emergensy.Location = new System.Drawing.Point(385, 12);
            this.Hand_Emergensy.Margin = new System.Windows.Forms.Padding(5);
            this.Hand_Emergensy.Name = "Hand_Emergensy";
            this.Hand_Emergensy.Size = new System.Drawing.Size(49, 34);
            this.Hand_Emergensy.TabIndex = 8;
            this.Hand_Emergensy.Text = "E";
            this.Hand_Emergensy.UseVisualStyleBackColor = false;
            this.Hand_Emergensy.Click += new System.EventHandler(this.Hand_Emergensy_Click);
            // 
            // BP
            // 
            this.BP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BP.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BP.Location = new System.Drawing.Point(18, 150);
            this.BP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.BP.Name = "BP";
            this.BP.Size = new System.Drawing.Size(509, 22);
            this.BP.TabIndex = 9;
            // 
            // Loged_as
            // 
            this.Loged_as.Location = new System.Drawing.Point(18, 12);
            this.Loged_as.Name = "Loged_as";
            this.Loged_as.Size = new System.Drawing.Size(359, 39);
            this.Loged_as.TabIndex = 10;
            this.Loged_as.UseVisualStyleBackColor = true;
            // 
            // Profile_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 206);
            this.Controls.Add(this.Emergensy_Import);
            this.Controls.Add(this.Loged_as);
            this.Controls.Add(this.BP);
            this.Controls.Add(this.Hand_Emergensy);
            this.Controls.Add(this.System_Settings_Change_Button);
            this.Controls.Add(this.Change_Unlock_But);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Profile_Settings";
            this.Text = "Необходимо выбрать профиль";
            this.Load += new System.EventHandler(this.Profile_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Curent_Profile_TBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Load_Profile_But;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Confirm_Selected_Profile;
        private System.Windows.Forms.Button Change_Unlock_But;
        public System.Windows.Forms.ComboBox Profiles_CmBox;
        private System.Windows.Forms.Button System_Settings_Change_Button;
        private System.Windows.Forms.Button Emergensy_Import;
        private System.Windows.Forms.Button Hand_Emergensy;
        private System.Windows.Forms.TextBox BP;
        private System.Windows.Forms.Button Loged_as;
    }
}