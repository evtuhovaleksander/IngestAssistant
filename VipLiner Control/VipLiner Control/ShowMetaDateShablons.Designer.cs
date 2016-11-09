namespace Ingest_Assistant
{
    partial class Show_Meta_Dates_Shablons
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
            this.TAB = new System.Windows.Forms.TabControl();
            this.step0 = new System.Windows.Forms.TabPage();
            this.shab_del_but = new System.Windows.Forms.Button();
            this.refresh_shab_but = new System.Windows.Forms.Button();
            this.go_to_step1_but = new System.Windows.Forms.Button();
            this.Shab_to_set = new System.Windows.Forms.Button();
            this.shab_dgv = new System.Windows.Forms.DataGridView();
            this.Shab_CmBox = new System.Windows.Forms.ComboBox();
            this.step1 = new System.Windows.Forms.TabPage();
            this.ret_to_zero_step = new System.Windows.Forms.Button();
            this.go_to_second_step_but = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.C_All_to_White = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InFin_Color_But = new System.Windows.Forms.Button();
            this.fin_dgv = new System.Windows.Forms.DataGridView();
            this.Finnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_dgv = new System.Windows.Forms.DataGridView();
            this.Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step3 = new System.Windows.Forms.TabPage();
            this.ret_to_step2 = new System.Windows.Forms.Button();
            this.SaveShablon = new System.Windows.Forms.GroupBox();
            this.SS_but = new System.Windows.Forms.Button();
            this.ss_TBox = new System.Windows.Forms.TextBox();
            this.ss_dgv = new System.Windows.Forms.DataGridView();
            this.ssname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAB.SuspendLayout();
            this.step0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shab_dgv)).BeginInit();
            this.step1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fin_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_dgv)).BeginInit();
            this.step3.SuspendLayout();
            this.SaveShablon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ss_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // TAB
            // 
            this.TAB.Controls.Add(this.step0);
            this.TAB.Controls.Add(this.step1);
            this.TAB.Controls.Add(this.step3);
            this.TAB.Location = new System.Drawing.Point(12, 12);
            this.TAB.Name = "TAB";
            this.TAB.SelectedIndex = 0;
            this.TAB.Size = new System.Drawing.Size(1702, 767);
            this.TAB.TabIndex = 0;
            // 
            // step0
            // 
            this.step0.Controls.Add(this.shab_del_but);
            this.step0.Controls.Add(this.refresh_shab_but);
            this.step0.Controls.Add(this.go_to_step1_but);
            this.step0.Controls.Add(this.Shab_to_set);
            this.step0.Controls.Add(this.shab_dgv);
            this.step0.Controls.Add(this.Shab_CmBox);
            this.step0.Location = new System.Drawing.Point(4, 25);
            this.step0.Name = "step0";
            this.step0.Padding = new System.Windows.Forms.Padding(3);
            this.step0.Size = new System.Drawing.Size(1694, 738);
            this.step0.TabIndex = 3;
            this.step0.Text = "Просмотр Шаблонов";
            this.step0.UseVisualStyleBackColor = true;
            // 
            // shab_del_but
            // 
            this.shab_del_but.Location = new System.Drawing.Point(6, 41);
            this.shab_del_but.Name = "shab_del_but";
            this.shab_del_but.Size = new System.Drawing.Size(188, 27);
            this.shab_del_but.TabIndex = 5;
            this.shab_del_but.Text = "Удалить";
            this.shab_del_but.UseVisualStyleBackColor = true;
            this.shab_del_but.Click += new System.EventHandler(this.shab_del_but_Click);
            // 
            // refresh_shab_but
            // 
            this.refresh_shab_but.Location = new System.Drawing.Point(200, 7);
            this.refresh_shab_but.Name = "refresh_shab_but";
            this.refresh_shab_but.Size = new System.Drawing.Size(89, 23);
            this.refresh_shab_but.TabIndex = 4;
            this.refresh_shab_but.Text = "Обновить";
            this.refresh_shab_but.UseVisualStyleBackColor = true;
            this.refresh_shab_but.Click += new System.EventHandler(this.refresh_shab_but_Click);
            // 
            // go_to_step1_but
            // 
            this.go_to_step1_but.Location = new System.Drawing.Point(843, 7);
            this.go_to_step1_but.Name = "go_to_step1_but";
            this.go_to_step1_but.Size = new System.Drawing.Size(184, 50);
            this.go_to_step1_but.TabIndex = 3;
            this.go_to_step1_but.Text = "Создать новый шаблон";
            this.go_to_step1_but.UseVisualStyleBackColor = true;
            this.go_to_step1_but.Click += new System.EventHandler(this.go_to_step1_but_Click);
            // 
            // Shab_to_set
            // 
            this.Shab_to_set.Location = new System.Drawing.Point(249, 275);
            this.Shab_to_set.Name = "Shab_to_set";
            this.Shab_to_set.Size = new System.Drawing.Size(124, 51);
            this.Shab_to_set.TabIndex = 2;
            this.Shab_to_set.Text = "Выбрать шаблон";
            this.Shab_to_set.UseVisualStyleBackColor = true;
            this.Shab_to_set.Click += new System.EventHandler(this.Shab_to_set_Click);
            // 
            // shab_dgv
            // 
            this.shab_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shab_dgv.Location = new System.Drawing.Point(6, 74);
            this.shab_dgv.Name = "shab_dgv";
            this.shab_dgv.RowTemplate.Height = 24;
            this.shab_dgv.Size = new System.Drawing.Size(237, 446);
            this.shab_dgv.TabIndex = 1;
            // 
            // Shab_CmBox
            // 
            this.Shab_CmBox.FormattingEnabled = true;
            this.Shab_CmBox.Location = new System.Drawing.Point(6, 6);
            this.Shab_CmBox.Name = "Shab_CmBox";
            this.Shab_CmBox.Size = new System.Drawing.Size(188, 24);
            this.Shab_CmBox.TabIndex = 0;
            this.Shab_CmBox.SelectedIndexChanged += new System.EventHandler(this.Shab_CmBox_SelectedIndexChanged);
            // 
            // step1
            // 
            this.step1.Controls.Add(this.ret_to_zero_step);
            this.step1.Controls.Add(this.go_to_second_step_but);
            this.step1.Controls.Add(this.groupBox1);
            this.step1.Controls.Add(this.fin_dgv);
            this.step1.Controls.Add(this.v_dgv);
            this.step1.Location = new System.Drawing.Point(4, 25);
            this.step1.Name = "step1";
            this.step1.Padding = new System.Windows.Forms.Padding(3);
            this.step1.Size = new System.Drawing.Size(1694, 738);
            this.step1.TabIndex = 0;
            this.step1.Text = "Выбор параметров";
            this.step1.UseVisualStyleBackColor = true;
            // 
            // ret_to_zero_step
            // 
            this.ret_to_zero_step.Location = new System.Drawing.Point(621, 70);
            this.ret_to_zero_step.Name = "ret_to_zero_step";
            this.ret_to_zero_step.Size = new System.Drawing.Size(303, 60);
            this.ret_to_zero_step.TabIndex = 22;
            this.ret_to_zero_step.Text = "Перейдти к нулевому этапу";
            this.ret_to_zero_step.UseVisualStyleBackColor = true;
            this.ret_to_zero_step.Click += new System.EventHandler(this.ret_to_zero_step_Click);
            // 
            // go_to_second_step_but
            // 
            this.go_to_second_step_but.Location = new System.Drawing.Point(621, 6);
            this.go_to_second_step_but.Name = "go_to_second_step_but";
            this.go_to_second_step_but.Size = new System.Drawing.Size(303, 60);
            this.go_to_second_step_but.TabIndex = 21;
            this.go_to_second_step_but.Text = "Перейдти ко второму этапу";
            this.go_to_second_step_but.UseVisualStyleBackColor = true;
            this.go_to_second_step_but.Click += new System.EventHandler(this.go_to_second_step_but_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.C_All_to_White);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.InFin_Color_But);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 116);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // C_All_to_White
            // 
            this.C_All_to_White.Location = new System.Drawing.Point(6, 78);
            this.C_All_to_White.Name = "C_All_to_White";
            this.C_All_to_White.Size = new System.Drawing.Size(135, 32);
            this.C_All_to_White.TabIndex = 21;
            this.C_All_to_White.Text = "Забелить все";
            this.C_All_to_White.UseVisualStyleBackColor = true;
            this.C_All_to_White.Click += new System.EventHandler(this.C_All_to_White_Click);
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
            this.fin_dgv.Location = new System.Drawing.Point(416, 6);
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
            this.fin_dgv.TabIndex = 15;
            // 
            // Finnam
            // 
            this.Finnam.HeaderText = "par";
            this.Finnam.Name = "Finnam";
            this.Finnam.ReadOnly = true;
            // 
            // v_dgv
            // 
            this.v_dgv.AllowUserToAddRows = false;
            this.v_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.v_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.v_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.v_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nm});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.v_dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.v_dgv.Location = new System.Drawing.Point(6, 269);
            this.v_dgv.Name = "v_dgv";
            this.v_dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.v_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.v_dgv.RowTemplate.Height = 24;
            this.v_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.v_dgv.Size = new System.Drawing.Size(1102, 251);
            this.v_dgv.TabIndex = 13;
            this.v_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.v_dgv_CellDoubleClick);
            this.v_dgv.SelectionChanged += new System.EventHandler(this.v_dgv_SelectionChanged);
            // 
            // Nm
            // 
            this.Nm.HeaderText = "Параметр";
            this.Nm.Name = "Nm";
            this.Nm.ReadOnly = true;
            // 
            // step3
            // 
            this.step3.Controls.Add(this.ret_to_step2);
            this.step3.Controls.Add(this.SaveShablon);
            this.step3.Controls.Add(this.ss_dgv);
            this.step3.Location = new System.Drawing.Point(4, 25);
            this.step3.Name = "step3";
            this.step3.Padding = new System.Windows.Forms.Padding(3);
            this.step3.Size = new System.Drawing.Size(1694, 738);
            this.step3.TabIndex = 2;
            this.step3.Text = "Сохранение шаблона";
            this.step3.UseVisualStyleBackColor = true;
            // 
            // ret_to_step2
            // 
            this.ret_to_step2.Location = new System.Drawing.Point(1069, 17);
            this.ret_to_step2.Name = "ret_to_step2";
            this.ret_to_step2.Size = new System.Drawing.Size(75, 47);
            this.ret_to_step2.TabIndex = 3;
            this.ret_to_step2.Text = "На шаг назад";
            this.ret_to_step2.UseVisualStyleBackColor = true;
            this.ret_to_step2.Click += new System.EventHandler(this.ret_to_step2_Click);
            // 
            // SaveShablon
            // 
            this.SaveShablon.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveShablon.Controls.Add(this.SS_but);
            this.SaveShablon.Controls.Add(this.ss_TBox);
            this.SaveShablon.Location = new System.Drawing.Point(328, 6);
            this.SaveShablon.Name = "SaveShablon";
            this.SaveShablon.Size = new System.Drawing.Size(581, 106);
            this.SaveShablon.TabIndex = 2;
            this.SaveShablon.TabStop = false;
            this.SaveShablon.Text = "groupBox2";
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
            this.ss_dgv.TabIndex = 0;
            // 
            // ssname
            // 
            this.ssname.HeaderText = "Параметр";
            this.ssname.Name = "ssname";
            this.ssname.ReadOnly = true;
            // 
            // Show_Meta_Dates_Shablons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 569);
            this.Controls.Add(this.TAB);
            this.MinimizeBox = false;
            this.Name = "Show_Meta_Dates_Shablons";
            this.Text = "Show_Meta_Dates_Shablons";
            this.Load += new System.EventHandler(this.Show_Meta_Info_Load);
            this.TAB.ResumeLayout(false);
            this.step0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shab_dgv)).EndInit();
            this.step1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fin_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_dgv)).EndInit();
            this.step3.ResumeLayout(false);
            this.SaveShablon.ResumeLayout(false);
            this.SaveShablon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ss_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TAB;
        private System.Windows.Forms.TabPage step1;
        private System.Windows.Forms.DataGridView fin_dgv;
        private System.Windows.Forms.DataGridView v_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm;
        private System.Windows.Forms.Button InFin_Color_But;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finnam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button C_All_to_White;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button go_to_second_step_but;
        private System.Windows.Forms.TabPage step3;
        private System.Windows.Forms.TabPage step0;
        private System.Windows.Forms.Button ret_to_zero_step;
        private System.Windows.Forms.GroupBox SaveShablon;
        private System.Windows.Forms.Button SS_but;
        private System.Windows.Forms.TextBox ss_TBox;
        private System.Windows.Forms.DataGridView ss_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssname;
        private System.Windows.Forms.Button go_to_step1_but;
        private System.Windows.Forms.Button Shab_to_set;
        private System.Windows.Forms.DataGridView shab_dgv;
        private System.Windows.Forms.ComboBox Shab_CmBox;
        private System.Windows.Forms.Button ret_to_step2;
        private System.Windows.Forms.Button refresh_shab_but;
        private System.Windows.Forms.Button shab_del_but;

    }
}