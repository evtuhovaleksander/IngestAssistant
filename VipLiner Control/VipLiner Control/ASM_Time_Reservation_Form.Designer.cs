namespace Ingest_Assistant
{
    partial class ASM_Time_Reservation_Form
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time_Start_TBox = new System.Windows.Forms.TextBox();
            this.Time_Stop_TBox = new System.Windows.Forms.TextBox();
            this.Description_CmBox = new System.Windows.Forms.ComboBox();
            this.Add_But = new System.Windows.Forms.Button();
            this.Del_But = new System.Windows.Forms.Button();
            this.Check_But = new System.Windows.Forms.Button();
            this.Picker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Description});
            this.dgv.Location = new System.Drawing.Point(12, 99);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1022, 319);
            this.dgv.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Start";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Stop";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Duration";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Time_Start_TBox
            // 
            this.Time_Start_TBox.Location = new System.Drawing.Point(12, 71);
            this.Time_Start_TBox.Name = "Time_Start_TBox";
            this.Time_Start_TBox.Size = new System.Drawing.Size(174, 22);
            this.Time_Start_TBox.TabIndex = 2;
            this.Time_Start_TBox.TextChanged += new System.EventHandler(this.Time_Start_TBox_TextChanged);
            this.Time_Start_TBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Time_Start_TBox_KeyPress);
            // 
            // Time_Stop_TBox
            // 
            this.Time_Stop_TBox.Location = new System.Drawing.Point(192, 71);
            this.Time_Stop_TBox.Name = "Time_Stop_TBox";
            this.Time_Stop_TBox.Size = new System.Drawing.Size(174, 22);
            this.Time_Stop_TBox.TabIndex = 3;
            this.Time_Stop_TBox.TextChanged += new System.EventHandler(this.Time_Stop_TBox_TextChanged);
            this.Time_Stop_TBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Time_Stop_TBox_KeyPress);
            // 
            // Description_CmBox
            // 
            this.Description_CmBox.FormattingEnabled = true;
            this.Description_CmBox.Location = new System.Drawing.Point(372, 71);
            this.Description_CmBox.Name = "Description_CmBox";
            this.Description_CmBox.Size = new System.Drawing.Size(349, 24);
            this.Description_CmBox.TabIndex = 4;
            // 
            // Add_But
            // 
            this.Add_But.Enabled = false;
            this.Add_But.Location = new System.Drawing.Point(853, 69);
            this.Add_But.Name = "Add_But";
            this.Add_But.Size = new System.Drawing.Size(181, 26);
            this.Add_But.TabIndex = 5;
            this.Add_But.Text = "Добавление резерации";
            this.Add_But.UseVisualStyleBackColor = true;
            this.Add_But.Click += new System.EventHandler(this.Add_But_Click);
            // 
            // Del_But
            // 
            this.Del_But.Location = new System.Drawing.Point(1040, 99);
            this.Del_But.Name = "Del_But";
            this.Del_But.Size = new System.Drawing.Size(89, 77);
            this.Del_But.TabIndex = 6;
            this.Del_But.Text = "Удалить выбранное";
            this.Del_But.UseVisualStyleBackColor = true;
            this.Del_But.Click += new System.EventHandler(this.Del_But_Click);
            // 
            // Check_But
            // 
            this.Check_But.Location = new System.Drawing.Point(727, 69);
            this.Check_But.Name = "Check_But";
            this.Check_But.Size = new System.Drawing.Size(120, 26);
            this.Check_But.TabIndex = 7;
            this.Check_But.Text = "Проверка";
            this.Check_But.UseVisualStyleBackColor = true;
            this.Check_But.Click += new System.EventHandler(this.Check_But_Click);
            // 
            // Picker
            // 
            this.Picker.Location = new System.Drawing.Point(12, 12);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(200, 22);
            this.Picker.TabIndex = 8;
            this.Picker.Visible = false;
            this.Picker.ValueChanged += new System.EventHandler(this.Picker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Время начала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Время начала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Описание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Время окончания";
            // 
            // ASM_Time_Reservation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1141, 469);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Picker);
            this.Controls.Add(this.Check_But);
            this.Controls.Add(this.Del_But);
            this.Controls.Add(this.Add_But);
            this.Controls.Add(this.Description_CmBox);
            this.Controls.Add(this.Time_Stop_TBox);
            this.Controls.Add(this.Time_Start_TBox);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ASM_Time_Reservation_Form";
            this.Text = "ASM_Time_Reservation_Form";
            this.Load += new System.EventHandler(this.ASM_Time_Reservation_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker DT_Picker;
        private System.Windows.Forms.TextBox Time_Start_TBox;
        private System.Windows.Forms.TextBox Time_Stop_TBox;
        private System.Windows.Forms.ComboBox Description_CmBox;
        private System.Windows.Forms.Button Add_But;
        private System.Windows.Forms.Button Del_But;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button Check_But;
        private System.Windows.Forms.DateTimePicker Picker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}