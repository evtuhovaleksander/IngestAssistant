namespace Ingest_Assistant
{
    partial class ShowMetaDatesShablons
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TBC = new System.Windows.Forms.TabControl();
            this.Load = new System.Windows.Forms.TabPage();
            this.shab_del_but = new System.Windows.Forms.Button();
            this.Shab_CmBox = new System.Windows.Forms.ComboBox();
            this.refresh_shab_but = new System.Windows.Forms.Button();
            this.shab_dgv = new System.Windows.Forms.DataGridView();
            this.S_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.go_to_step1_but = new System.Windows.Forms.Button();
            this.Shab_to_set = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.TabPage();
            this.go_to_second_step_but = new System.Windows.Forms.Button();
            this.ret_to_zero_step = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InFin_Color_But = new System.Windows.Forms.Button();
            this.fin_dgv = new System.Windows.Forms.DataGridView();
            this.Finnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.all_dgv = new System.Windows.Forms.DataGridView();
            this.Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Save = new System.Windows.Forms.TabPage();
            this.ret_to_step2 = new System.Windows.Forms.Button();
            this.SaveShablon = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SS_but = new System.Windows.Forms.Button();
            this.ss_TBox = new System.Windows.Forms.TextBox();
            this.ss_dgv = new System.Windows.Forms.DataGridView();
            this.ssname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CD = new System.Windows.Forms.ColorDialog();
            this.TBC.SuspendLayout();
            this.Load.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shab_dgv)).BeginInit();
            this.Create.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fin_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_dgv)).BeginInit();
            this.Save.SuspendLayout();
            this.SaveShablon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ss_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // TBC
            // 
            this.TBC.Controls.Add(this.Load);
            this.TBC.Controls.Add(this.Create);
            this.TBC.Controls.Add(this.Save);
            this.TBC.Location = new System.Drawing.Point(12, 12);
            this.TBC.Name = "TBC";
            this.TBC.SelectedIndex = 0;
            this.TBC.Size = new System.Drawing.Size(1120, 522);
            this.TBC.TabIndex = 0;
            // 
            // Load
            // 
            this.Load.Controls.Add(this.shab_del_but);
            this.Load.Controls.Add(this.Shab_CmBox);
            this.Load.Controls.Add(this.refresh_shab_but);
            this.Load.Controls.Add(this.shab_dgv);
            this.Load.Controls.Add(this.go_to_step1_but);
            this.Load.Controls.Add(this.Shab_to_set);
            this.Load.Location = new System.Drawing.Point(4, 25);
            this.Load.Name = "Load";
            this.Load.Padding = new System.Windows.Forms.Padding(3);
            this.Load.Size = new System.Drawing.Size(1112, 493);
            this.Load.TabIndex = 0;
            this.Load.Text = "Существующие шаблоны";
            this.Load.UseVisualStyleBackColor = true;
            // 
            // shab_del_but
            // 
            this.shab_del_but.Location = new System.Drawing.Point(9, 40);
            this.shab_del_but.Name = "shab_del_but";
            this.shab_del_but.Size = new System.Drawing.Size(188, 27);
            this.shab_del_but.TabIndex = 12;
            this.shab_del_but.Text = "Удалить";
            this.shab_del_but.UseVisualStyleBackColor = true;
            this.shab_del_but.Click += new System.EventHandler(this.shab_del_but_Click);
            // 
            // Shab_CmBox
            // 
            this.Shab_CmBox.FormattingEnabled = true;
            this.Shab_CmBox.Location = new System.Drawing.Point(9, 5);
            this.Shab_CmBox.Name = "Shab_CmBox";
            this.Shab_CmBox.Size = new System.Drawing.Size(188, 24);
            this.Shab_CmBox.TabIndex = 6;
            this.Shab_CmBox.SelectedIndexChanged += new System.EventHandler(this.Shab_CmBox_SelectedIndexChanged);
            // 
            // refresh_shab_but
            // 
            this.refresh_shab_but.Location = new System.Drawing.Point(203, 6);
            this.refresh_shab_but.Name = "refresh_shab_but";
            this.refresh_shab_but.Size = new System.Drawing.Size(89, 23);
            this.refresh_shab_but.TabIndex = 11;
            this.refresh_shab_but.Text = "Обновить";
            this.refresh_shab_but.UseVisualStyleBackColor = true;
            this.refresh_shab_but.Click += new System.EventHandler(this.refresh_shab_but_Click);
            // 
            // shab_dgv
            // 
            this.shab_dgv.AllowUserToAddRows = false;
            this.shab_dgv.AllowUserToDeleteRows = false;
            this.shab_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shab_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Name});
            this.shab_dgv.Location = new System.Drawing.Point(9, 73);
            this.shab_dgv.Name = "shab_dgv";
            this.shab_dgv.ReadOnly = true;
            this.shab_dgv.RowTemplate.Height = 24;
            this.shab_dgv.Size = new System.Drawing.Size(237, 446);
            this.shab_dgv.TabIndex = 8;
            // 
            // S_Name
            // 
            this.S_Name.HeaderText = "Параметр";
            this.S_Name.Name = "S_Name";
            this.S_Name.ReadOnly = true;
            // 
            // go_to_step1_but
            // 
            this.go_to_step1_but.Location = new System.Drawing.Point(828, 6);
            this.go_to_step1_but.Name = "go_to_step1_but";
            this.go_to_step1_but.Size = new System.Drawing.Size(184, 50);
            this.go_to_step1_but.TabIndex = 10;
            this.go_to_step1_but.Text = "Создать новый шаблон";
            this.go_to_step1_but.UseVisualStyleBackColor = true;
            this.go_to_step1_but.Click += new System.EventHandler(this.go_to_step1_but_Click);
            // 
            // Shab_to_set
            // 
            this.Shab_to_set.Location = new System.Drawing.Point(252, 274);
            this.Shab_to_set.Name = "Shab_to_set";
            this.Shab_to_set.Size = new System.Drawing.Size(124, 51);
            this.Shab_to_set.TabIndex = 9;
            this.Shab_to_set.Text = "Выбрать шаблон";
            this.Shab_to_set.UseVisualStyleBackColor = true;
            this.Shab_to_set.Click += new System.EventHandler(this.Shab_to_set_Click);
            // 
            // Create
            // 
            this.Create.Controls.Add(this.go_to_second_step_but);
            this.Create.Controls.Add(this.ret_to_zero_step);
            this.Create.Controls.Add(this.groupBox1);
            this.Create.Controls.Add(this.fin_dgv);
            this.Create.Controls.Add(this.all_dgv);
            this.Create.Location = new System.Drawing.Point(4, 25);
            this.Create.Name = "Create";
            this.Create.Padding = new System.Windows.Forms.Padding(3);
            this.Create.Size = new System.Drawing.Size(1112, 493);
            this.Create.TabIndex = 1;
            this.Create.Text = "Создание шаблона";
            this.Create.UseVisualStyleBackColor = true;
            // 
            // go_to_second_step_but
            // 
            this.go_to_second_step_but.Location = new System.Drawing.Point(615, 13);
            this.go_to_second_step_but.Name = "go_to_second_step_but";
            this.go_to_second_step_but.Size = new System.Drawing.Size(303, 60);
            this.go_to_second_step_but.TabIndex = 30;
            this.go_to_second_step_but.Text = "Перейдти к сохранению";
            this.go_to_second_step_but.UseVisualStyleBackColor = true;
            this.go_to_second_step_but.Click += new System.EventHandler(this.go_to_second_step_but_Click);
            // 
            // ret_to_zero_step
            // 
            this.ret_to_zero_step.Location = new System.Drawing.Point(615, 84);
            this.ret_to_zero_step.Name = "ret_to_zero_step";
            this.ret_to_zero_step.Size = new System.Drawing.Size(303, 60);
            this.ret_to_zero_step.TabIndex = 31;
            this.ret_to_zero_step.Text = "Отменить создание шаблона";
            this.ret_to_zero_step.UseVisualStyleBackColor = true;
            this.ret_to_zero_step.Click += new System.EventHandler(this.ret_to_zero_step_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.InFin_Color_But);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 67);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Цвет добавленого в базу";
            // 
            // InFin_Color_But
            // 
            this.InFin_Color_But.BackColor = System.Drawing.Color.Lime;
            this.InFin_Color_But.Location = new System.Drawing.Point(186, 7);
            this.InFin_Color_But.Name = "InFin_Color_But";
            this.InFin_Color_But.Size = new System.Drawing.Size(96, 51);
            this.InFin_Color_But.TabIndex = 19;
            this.InFin_Color_But.Text = "выбрать цвет";
            this.InFin_Color_But.UseVisualStyleBackColor = false;
            this.InFin_Color_But.Click += new System.EventHandler(this.InFin_Color_But_Click);
            // 
            // fin_dgv
            // 
            this.fin_dgv.AllowUserToAddRows = false;
            this.fin_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fin_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fin_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fin_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Finnam});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fin_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.fin_dgv.Location = new System.Drawing.Point(650, 236);
            this.fin_dgv.Name = "fin_dgv";
            this.fin_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fin_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.fin_dgv.RowTemplate.Height = 24;
            this.fin_dgv.Size = new System.Drawing.Size(199, 251);
            this.fin_dgv.TabIndex = 25;
            // 
            // Finnam
            // 
            this.Finnam.HeaderText = "par";
            this.Finnam.Name = "Finnam";
            this.Finnam.ReadOnly = true;
            // 
            // all_dgv
            // 
            this.all_dgv.AllowUserToAddRows = false;
            this.all_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.all_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.all_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.all_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nm});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.all_dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.all_dgv.Location = new System.Drawing.Point(66, 236);
            this.all_dgv.Name = "all_dgv";
            this.all_dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.all_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.all_dgv.RowTemplate.Height = 24;
            this.all_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.all_dgv.Size = new System.Drawing.Size(199, 251);
            this.all_dgv.TabIndex = 23;
            this.all_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.all_dgv_CellDoubleClick);
            // 
            // Nm
            // 
            this.Nm.HeaderText = "Параметр";
            this.Nm.Name = "Nm";
            this.Nm.ReadOnly = true;
            // 
            // Save
            // 
            this.Save.Controls.Add(this.ret_to_step2);
            this.Save.Controls.Add(this.SaveShablon);
            this.Save.Controls.Add(this.ss_dgv);
            this.Save.Location = new System.Drawing.Point(4, 25);
            this.Save.Name = "Save";
            this.Save.Padding = new System.Windows.Forms.Padding(3);
            this.Save.Size = new System.Drawing.Size(1112, 493);
            this.Save.TabIndex = 2;
            this.Save.Text = "Сохранение";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // ret_to_step2
            // 
            this.ret_to_step2.Location = new System.Drawing.Point(931, 65);
            this.ret_to_step2.Name = "ret_to_step2";
            this.ret_to_step2.Size = new System.Drawing.Size(75, 47);
            this.ret_to_step2.TabIndex = 6;
            this.ret_to_step2.Text = "На шаг назад";
            this.ret_to_step2.UseVisualStyleBackColor = true;
            this.ret_to_step2.Click += new System.EventHandler(this.ret_to_step2_Click);
            // 
            // SaveShablon
            // 
            this.SaveShablon.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveShablon.Controls.Add(this.label2);
            this.SaveShablon.Controls.Add(this.SS_but);
            this.SaveShablon.Controls.Add(this.ss_TBox);
            this.SaveShablon.Location = new System.Drawing.Point(328, 6);
            this.SaveShablon.Name = "SaveShablon";
            this.SaveShablon.Size = new System.Drawing.Size(581, 106);
            this.SaveShablon.TabIndex = 5;
            this.SaveShablon.TabStop = false;
            this.SaveShablon.Text = "Сохранение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название шаблона";
            // 
            // SS_but
            // 
            this.SS_but.Location = new System.Drawing.Point(335, 21);
            this.SS_but.Name = "SS_but";
            this.SS_but.Size = new System.Drawing.Size(227, 70);
            this.SS_but.TabIndex = 2;
            this.SS_but.Text = "Сохранить";
            this.SS_but.UseVisualStyleBackColor = true;
            this.SS_but.Click += new System.EventHandler(this.SS_but_Click);
            // 
            // ss_TBox
            // 
            this.ss_TBox.Location = new System.Drawing.Point(18, 45);
            this.ss_TBox.Name = "ss_TBox";
            this.ss_TBox.Size = new System.Drawing.Size(311, 22);
            this.ss_TBox.TabIndex = 1;
            // 
            // ss_dgv
            // 
            this.ss_dgv.AllowUserToAddRows = false;
            this.ss_dgv.AllowUserToDeleteRows = false;
            this.ss_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ss_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ssname});
            this.ss_dgv.Location = new System.Drawing.Point(3, 6);
            this.ss_dgv.Name = "ss_dgv";
            this.ss_dgv.ReadOnly = true;
            this.ss_dgv.RowTemplate.Height = 24;
            this.ss_dgv.Size = new System.Drawing.Size(305, 527);
            this.ss_dgv.TabIndex = 4;
            // 
            // ssname
            // 
            this.ssname.HeaderText = "Параметр";
            this.ssname.Name = "ssname";
            this.ssname.ReadOnly = true;
            // 
            // ShowMetaDatesShablons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 546);
            this.Controls.Add(this.TBC);
            this.Name = "ShowMetaDatesShablons";
            this.Text = "ShowMetaDatesShablons";
          
            this.TBC.ResumeLayout(false);
            this.Load.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shab_dgv)).EndInit();
            this.Create.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fin_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_dgv)).EndInit();
            this.Save.ResumeLayout(false);
            this.SaveShablon.ResumeLayout(false);
            this.SaveShablon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ss_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TBC;
        private System.Windows.Forms.TabPage Load;
        private System.Windows.Forms.TabPage Create;
        private System.Windows.Forms.Button shab_del_but;
        private System.Windows.Forms.ComboBox Shab_CmBox;
        private System.Windows.Forms.Button refresh_shab_but;
        private System.Windows.Forms.DataGridView shab_dgv;
        private System.Windows.Forms.Button go_to_step1_but;
        private System.Windows.Forms.Button Shab_to_set;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Name;
        private System.Windows.Forms.Button go_to_second_step_but;
        private System.Windows.Forms.Button ret_to_zero_step;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InFin_Color_But;
        private System.Windows.Forms.DataGridView fin_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finnam;
        private System.Windows.Forms.DataGridView all_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm;
        private System.Windows.Forms.ColorDialog CD;
        private System.Windows.Forms.TabPage Save;
        private System.Windows.Forms.Button ret_to_step2;
        private System.Windows.Forms.GroupBox SaveShablon;
        private System.Windows.Forms.Button SS_but;
        private System.Windows.Forms.TextBox ss_TBox;
        private System.Windows.Forms.DataGridView ss_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssname;
        private System.Windows.Forms.Label label2;
    }
}