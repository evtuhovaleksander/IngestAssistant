namespace Ingest_Assistant
{
    partial class System_Settings_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Delete_Stop_File = new System.Windows.Forms.Button();
            this.Create_Stop_File = new System.Windows.Forms.Button();
            this.Stop_Marker = new System.Windows.Forms.Button();
            this.Settings_grBox = new System.Windows.Forms.GroupBox();
            this.set = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.Profiles_CmBox = new System.Windows.Forms.ComboBox();
            this.Save_Settings_But = new System.Windows.Forms.Button();
            this.Load_Settings_But = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Settings_grBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Delete_Stop_File);
            this.groupBox1.Controls.Add(this.Create_Stop_File);
            this.groupBox1.Controls.Add(this.Stop_Marker);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Стоп файл";
            // 
            // Delete_Stop_File
            // 
            this.Delete_Stop_File.Location = new System.Drawing.Point(193, 66);
            this.Delete_Stop_File.Name = "Delete_Stop_File";
            this.Delete_Stop_File.Size = new System.Drawing.Size(209, 23);
            this.Delete_Stop_File.TabIndex = 4;
            this.Delete_Stop_File.Text = "Удалить стоп файл";
            this.Delete_Stop_File.UseVisualStyleBackColor = true;
            this.Delete_Stop_File.Click += new System.EventHandler(this.Delete_Stop_File_Click);
            // 
            // Create_Stop_File
            // 
            this.Create_Stop_File.Location = new System.Drawing.Point(193, 19);
            this.Create_Stop_File.Name = "Create_Stop_File";
            this.Create_Stop_File.Size = new System.Drawing.Size(209, 23);
            this.Create_Stop_File.TabIndex = 3;
            this.Create_Stop_File.Text = "Создать стоп файл";
            this.Create_Stop_File.UseVisualStyleBackColor = true;
            this.Create_Stop_File.Click += new System.EventHandler(this.Create_Stop_File_Click);
            // 
            // Stop_Marker
            // 
            this.Stop_Marker.Location = new System.Drawing.Point(6, 19);
            this.Stop_Marker.Name = "Stop_Marker";
            this.Stop_Marker.Size = new System.Drawing.Size(181, 70);
            this.Stop_Marker.TabIndex = 2;
            this.Stop_Marker.UseVisualStyleBackColor = true;
            // 
            // Settings_grBox
            // 
            this.Settings_grBox.Controls.Add(this.set);
            this.Settings_grBox.Controls.Add(this.name);
            this.Settings_grBox.Controls.Add(this.Profiles_CmBox);
            this.Settings_grBox.Controls.Add(this.Save_Settings_But);
            this.Settings_grBox.Controls.Add(this.Load_Settings_But);
            this.Settings_grBox.Location = new System.Drawing.Point(3, -5);
            this.Settings_grBox.Name = "Settings_grBox";
            this.Settings_grBox.Size = new System.Drawing.Size(1509, 77);
            this.Settings_grBox.TabIndex = 2;
            this.Settings_grBox.TabStop = false;
            this.Settings_grBox.Text = "groupBox2";
            // 
            // set
            // 
            this.set.Location = new System.Drawing.Point(302, 86);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(686, 20);
            this.set.TabIndex = 6;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(47, 86);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(249, 20);
            this.name.TabIndex = 5;
            // 
            // Profiles_CmBox
            // 
            this.Profiles_CmBox.FormattingEnabled = true;
            this.Profiles_CmBox.Location = new System.Drawing.Point(6, 19);
            this.Profiles_CmBox.Name = "Profiles_CmBox";
            this.Profiles_CmBox.Size = new System.Drawing.Size(156, 21);
            this.Profiles_CmBox.TabIndex = 3;
            // 
            // Save_Settings_But
            // 
            this.Save_Settings_But.Location = new System.Drawing.Point(87, 46);
            this.Save_Settings_But.Name = "Save_Settings_But";
            this.Save_Settings_But.Size = new System.Drawing.Size(75, 23);
            this.Save_Settings_But.TabIndex = 2;
            this.Save_Settings_But.Text = "Save";
            this.Save_Settings_But.UseVisualStyleBackColor = true;
            this.Save_Settings_But.Click += new System.EventHandler(this.Save_Settings_But_Click);
            // 
            // Load_Settings_But
            // 
            this.Load_Settings_But.Location = new System.Drawing.Point(6, 46);
            this.Load_Settings_But.Name = "Load_Settings_But";
            this.Load_Settings_But.Size = new System.Drawing.Size(75, 23);
            this.Load_Settings_But.TabIndex = 1;
            this.Load_Settings_But.Text = "Load";
            this.Load_Settings_But.UseVisualStyleBackColor = true;
            this.Load_Settings_But.Click += new System.EventHandler(this.Load_Settings_But_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // System_Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 635);
            this.Controls.Add(this.Settings_grBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "System_Settings_Form";
            this.Text = "System_Settings_Form";
            this.Load += new System.EventHandler(this.System_Settings_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.Settings_grBox.ResumeLayout(false);
            this.Settings_grBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Delete_Stop_File;
        private System.Windows.Forms.Button Create_Stop_File;
        private System.Windows.Forms.Button Stop_Marker;
        private System.Windows.Forms.GroupBox Settings_grBox;
        private System.Windows.Forms.ComboBox Profiles_CmBox;
        private System.Windows.Forms.Button Save_Settings_But;
        private System.Windows.Forms.Button Load_Settings_But;
        private System.Windows.Forms.TextBox set;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
    }
}