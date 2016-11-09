namespace Ingest_Assistant
{
    partial class Raport_Form
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.generate_raport_But = new System.Windows.Forms.Button();
            this.AD_GrBox = new System.Windows.Forms.GroupBox();
            this.AD_Start_But = new System.Windows.Forms.Button();
            this.Del_Work_But = new System.Windows.Forms.Button();
            this.Time_cmBox = new System.Windows.Forms.ComboBox();
            this.Line_cmBox = new System.Windows.Forms.ComboBox();
            this.Type_cmBox = new System.Windows.Forms.ComboBox();
            this.AD_Add_Line_Button = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AD_Cancel_But = new System.Windows.Forms.Button();
            this.Refresh_But = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProfileSelection_CmBox = new System.Windows.Forms.ComboBox();
            this.AD_GrBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(298, 8);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // generate_raport_But
            // 
            this.generate_raport_But.Location = new System.Drawing.Point(598, 7);
            this.generate_raport_But.Margin = new System.Windows.Forms.Padding(2);
            this.generate_raport_But.Name = "generate_raport_But";
            this.generate_raport_But.Size = new System.Drawing.Size(191, 21);
            this.generate_raport_But.TabIndex = 1;
            this.generate_raport_But.Text = "Собрать рапорт за указанную дату";
            this.generate_raport_But.UseVisualStyleBackColor = true;
            this.generate_raport_But.Click += new System.EventHandler(this.generate_raport_But_Click);
            // 
            // AD_GrBox
            // 
            this.AD_GrBox.Controls.Add(this.AD_Start_But);
            this.AD_GrBox.Controls.Add(this.Del_Work_But);
            this.AD_GrBox.Controls.Add(this.Time_cmBox);
            this.AD_GrBox.Controls.Add(this.Line_cmBox);
            this.AD_GrBox.Controls.Add(this.Type_cmBox);
            this.AD_GrBox.Controls.Add(this.AD_Add_Line_Button);
            this.AD_GrBox.Controls.Add(this.dgv);
            this.AD_GrBox.Controls.Add(this.AD_Cancel_But);
            this.AD_GrBox.Location = new System.Drawing.Point(9, 35);
            this.AD_GrBox.Name = "AD_GrBox";
            this.AD_GrBox.Size = new System.Drawing.Size(777, 330);
            this.AD_GrBox.TabIndex = 3;
            this.AD_GrBox.TabStop = false;
            this.AD_GrBox.Text = "Дополнительные работы";
            // 
            // AD_Start_But
            // 
            this.AD_Start_But.Location = new System.Drawing.Point(1, 0);
            this.AD_Start_But.Name = "AD_Start_But";
            this.AD_Start_But.Size = new System.Drawing.Size(770, 330);
            this.AD_Start_But.TabIndex = 4;
            this.AD_Start_But.Text = "Оформить дополнительные работы";
            this.AD_Start_But.UseVisualStyleBackColor = true;
            this.AD_Start_But.Click += new System.EventHandler(this.AD_Start_But_Click);
            // 
            // Del_Work_But
            // 
            this.Del_Work_But.Location = new System.Drawing.Point(668, 48);
            this.Del_Work_But.Name = "Del_Work_But";
            this.Del_Work_But.Size = new System.Drawing.Size(103, 23);
            this.Del_Work_But.TabIndex = 8;
            this.Del_Work_But.Text = "Удалить работу";
            this.Del_Work_But.UseVisualStyleBackColor = true;
            this.Del_Work_But.Click += new System.EventHandler(this.Del_Work_But_Click);
            // 
            // Time_cmBox
            // 
            this.Time_cmBox.FormattingEnabled = true;
            this.Time_cmBox.Items.AddRange(new object[] {
            "00:30:00",
            "01:00:00",
            "01:30:00",
            "02:00:00",
            "02:30:00",
            "03:00:00",
            "04:30:00",
            "05:00:00",
            "06:00:00",
            "07:00:00",
            "08:00:00",
            "09:00:00",
            "10:00:00"});
            this.Time_cmBox.Location = new System.Drawing.Point(549, 21);
            this.Time_cmBox.Name = "Time_cmBox";
            this.Time_cmBox.Size = new System.Drawing.Size(106, 21);
            this.Time_cmBox.TabIndex = 7;
            // 
            // Line_cmBox
            // 
            this.Line_cmBox.FormattingEnabled = true;
            this.Line_cmBox.Items.AddRange(new object[] {
            "Линия 1",
            "Линия 2",
            "Линия 3",
            "Линия 4 (PC)"});
            this.Line_cmBox.Location = new System.Drawing.Point(449, 21);
            this.Line_cmBox.Name = "Line_cmBox";
            this.Line_cmBox.Size = new System.Drawing.Size(94, 21);
            this.Line_cmBox.TabIndex = 6;
            // 
            // Type_cmBox
            // 
            this.Type_cmBox.FormattingEnabled = true;
            this.Type_cmBox.Location = new System.Drawing.Point(48, 21);
            this.Type_cmBox.Name = "Type_cmBox";
            this.Type_cmBox.Size = new System.Drawing.Size(395, 21);
            this.Type_cmBox.TabIndex = 5;
            // 
            // AD_Add_Line_Button
            // 
            this.AD_Add_Line_Button.Location = new System.Drawing.Point(668, 18);
            this.AD_Add_Line_Button.Name = "AD_Add_Line_Button";
            this.AD_Add_Line_Button.Size = new System.Drawing.Size(103, 23);
            this.AD_Add_Line_Button.TabIndex = 2;
            this.AD_Add_Line_Button.Text = "Добавить работу";
            this.AD_Add_Line_Button.UseVisualStyleBackColor = true;
            this.AD_Add_Line_Button.Click += new System.EventHandler(this.AD_Add_Line_Button_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.Line,
            this.Time,
            this.ID});
            this.dgv.Location = new System.Drawing.Point(6, 48);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(649, 247);
            this.dgv.TabIndex = 1;
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            // 
            // type
            // 
            this.type.HeaderText = "Тип работ";
            this.type.Name = "type";
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.Width = 400;
            // 
            // Line
            // 
            this.Line.HeaderText = "Линия";
            this.Line.Name = "Line";
            this.Line.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Time
            // 
            this.Time.HeaderText = "Длительность";
            this.Time.Name = "Time";
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // AD_Cancel_But
            // 
            this.AD_Cancel_But.Location = new System.Drawing.Point(661, 272);
            this.AD_Cancel_But.Name = "AD_Cancel_But";
            this.AD_Cancel_But.Size = new System.Drawing.Size(66, 23);
            this.AD_Cancel_But.TabIndex = 0;
            this.AD_Cancel_But.Text = "Отмена";
            this.AD_Cancel_But.UseVisualStyleBackColor = true;
            this.AD_Cancel_But.Click += new System.EventHandler(this.AD_Cancel_But_Click);
            // 
            // Refresh_But
            // 
            this.Refresh_But.Location = new System.Drawing.Point(482, 7);
            this.Refresh_But.Margin = new System.Windows.Forms.Padding(2);
            this.Refresh_But.Name = "Refresh_But";
            this.Refresh_But.Size = new System.Drawing.Size(112, 21);
            this.Refresh_But.TabIndex = 4;
            this.Refresh_But.Text = "Обновить вручную";
            this.Refresh_But.UseVisualStyleBackColor = true;
            this.Refresh_But.Click += new System.EventHandler(this.Refresh_But_Click);
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Controls.Add(this.pictureBox1);
            this.Panel.Location = new System.Drawing.Point(10, 370);
            this.Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1253, 385);
            this.Panel.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ingest_Assistant.Properties.Resources.LOCKED_BLOCK;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1254, 385);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Профиль";
            // 
            // ProfileSelection_CmBox
            // 
            this.ProfileSelection_CmBox.FormattingEnabled = true;
            this.ProfileSelection_CmBox.Location = new System.Drawing.Point(69, 7);
            this.ProfileSelection_CmBox.Name = "ProfileSelection_CmBox";
            this.ProfileSelection_CmBox.Size = new System.Drawing.Size(224, 21);
            this.ProfileSelection_CmBox.TabIndex = 7;
            this.ProfileSelection_CmBox.SelectedValueChanged += new System.EventHandler(this.ProfileSelection_CmBox_SelectedValueChanged);
            // 
            // Raport_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 765);
            this.Controls.Add(this.ProfileSelection_CmBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Refresh_But);
            this.Controls.Add(this.AD_GrBox);
            this.Controls.Add(this.generate_raport_But);
            this.Controls.Add(this.dateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Raport_Form";
            this.Text = "Raport_Form";
            this.Load += new System.EventHandler(this.Raport_Form_Load);
            this.AD_GrBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate_raport_But;
        private System.Windows.Forms.GroupBox AD_GrBox;
        private System.Windows.Forms.Button AD_Add_Line_Button;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button AD_Cancel_But;
        private System.Windows.Forms.Button AD_Start_But;
        private System.Windows.Forms.ComboBox Time_cmBox;
        private System.Windows.Forms.ComboBox Line_cmBox;
        private System.Windows.Forms.ComboBox Type_cmBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.Button Refresh_But;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Button Del_Work_But;
        private System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProfileSelection_CmBox;
    }
}