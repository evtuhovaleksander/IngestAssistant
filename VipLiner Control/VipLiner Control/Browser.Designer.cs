namespace Ingest_Assistant
{
    partial class Browser
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
            Browser.File_Work_Close();
            Mainform_Parent.Height = Mainform_Parent.menuStrip1.Height+50;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.WB_date_picker = new System.Windows.Forms.DateTimePicker();
            this.WB_D_setd_Rbut = new System.Windows.Forms.RadioButton();
            this.WB_D_all_Rbut = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WB_S_D_Rbut = new System.Windows.Forms.RadioButton();
            this.WB_S_N_Rbut = new System.Windows.Forms.RadioButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.WB_archive_Rbut = new System.Windows.Forms.RadioButton();
            this.WB_work_Rbut = new System.Windows.Forms.RadioButton();
            this.Capacity_GrBox = new System.Windows.Forms.GroupBox();
            this.MegaBit_Label = new System.Windows.Forms.Label();
            this.Capacity_Calc = new System.Windows.Forms.Button();
            this.TeraBit_Label = new System.Windows.Forms.Label();
            this.B_Dir_Size_TBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.B_Dir_Count_TBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Browser_Refresh_But = new System.Windows.Forms.Button();
            this.Time_Count_GrBox = new System.Windows.Forms.GroupBox();
            this.Time_Count_L2_Lable = new System.Windows.Forms.Label();
            this.Time_Count_L1_Lable = new System.Windows.Forms.Label();
            this.Time_Count_PrBar = new System.Windows.Forms.ProgressBar();
            this.Time_Count_TBox = new System.Windows.Forms.TextBox();
            this.Time_Count_Refresh_Button = new System.Windows.Forms.Button();
            this.BGW = new System.ComponentModel.BackgroundWorker();
            this.Exit_But = new System.Windows.Forms.Button();
            this.data_Set_But = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.Capacity_GrBox.SuspendLayout();
            this.Time_Count_GrBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightGray;
            this.groupBox5.Controls.Add(this.data_Set_But);
            this.groupBox5.Controls.Add(this.WB_date_picker);
            this.groupBox5.Controls.Add(this.WB_D_setd_Rbut);
            this.groupBox5.Controls.Add(this.WB_D_all_Rbut);
            this.groupBox5.Location = new System.Drawing.Point(237, 11);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(242, 82);
            this.groupBox5.TabIndex = 99;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Сортировка по дате";
            // 
            // WB_date_picker
            // 
            this.WB_date_picker.Location = new System.Drawing.Point(2, 60);
            this.WB_date_picker.Margin = new System.Windows.Forms.Padding(2);
            this.WB_date_picker.Name = "WB_date_picker";
            this.WB_date_picker.Size = new System.Drawing.Size(161, 20);
            this.WB_date_picker.TabIndex = 3;
            this.WB_date_picker.ValueChanged += new System.EventHandler(this.WB_date_picker_ValueChanged_1);
            // 
            // WB_D_setd_Rbut
            // 
            this.WB_D_setd_Rbut.AutoSize = true;
            this.WB_D_setd_Rbut.Location = new System.Drawing.Point(4, 38);
            this.WB_D_setd_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_D_setd_Rbut.Name = "WB_D_setd_Rbut";
            this.WB_D_setd_Rbut.Size = new System.Drawing.Size(110, 17);
            this.WB_D_setd_Rbut.TabIndex = 2;
            this.WB_D_setd_Rbut.Text = "Указанный день";
            this.WB_D_setd_Rbut.UseVisualStyleBackColor = true;
            // 
            // WB_D_all_Rbut
            // 
            this.WB_D_all_Rbut.AutoSize = true;
            this.WB_D_all_Rbut.Checked = true;
            this.WB_D_all_Rbut.Location = new System.Drawing.Point(4, 17);
            this.WB_D_all_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_D_all_Rbut.Name = "WB_D_all_Rbut";
            this.WB_D_all_Rbut.Size = new System.Drawing.Size(80, 17);
            this.WB_D_all_Rbut.TabIndex = 0;
            this.WB_D_all_Rbut.TabStop = true;
            this.WB_D_all_Rbut.Text = "За все дни";
            this.WB_D_all_Rbut.UseVisualStyleBackColor = true;
            this.WB_D_all_Rbut.CheckedChanged += new System.EventHandler(this.WB_D_all_Rbut_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.WB_S_D_Rbut);
            this.groupBox1.Controls.Add(this.WB_S_N_Rbut);
            this.groupBox1.Location = new System.Drawing.Point(444, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(150, 59);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортировка";
            this.groupBox1.Visible = false;
            // 
            // WB_S_D_Rbut
            // 
            this.WB_S_D_Rbut.AutoSize = true;
            this.WB_S_D_Rbut.Checked = true;
            this.WB_S_D_Rbut.Location = new System.Drawing.Point(4, 38);
            this.WB_S_D_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_S_D_Rbut.Name = "WB_S_D_Rbut";
            this.WB_S_D_Rbut.Size = new System.Drawing.Size(115, 17);
            this.WB_S_D_Rbut.TabIndex = 5;
            this.WB_S_D_Rbut.TabStop = true;
            this.WB_S_D_Rbut.Text = "Сортировать дату";
            this.WB_S_D_Rbut.UseVisualStyleBackColor = true;
            // 
            // WB_S_N_Rbut
            // 
            this.WB_S_N_Rbut.AutoSize = true;
            this.WB_S_N_Rbut.Location = new System.Drawing.Point(4, 17);
            this.WB_S_N_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_S_N_Rbut.Name = "WB_S_N_Rbut";
            this.WB_S_N_Rbut.Size = new System.Drawing.Size(113, 17);
            this.WB_S_N_Rbut.TabIndex = 4;
            this.WB_S_N_Rbut.Text = "Сортировать имя";
            this.WB_S_N_Rbut.UseVisualStyleBackColor = true;
            this.WB_S_N_Rbut.CheckedChanged += new System.EventHandler(this.WB_S_N_Rbut_CheckedChanged);
            // 
            // dgv
            // 
            this.dgv.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(9, 217);
            this.dgv.Margin = new System.Windows.Forms.Padding(2);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(479, 261);
            this.dgv.TabIndex = 97;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick_1);
            this.dgv.Sorted += new System.EventHandler(this.dgv_Sorted);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox4.Controls.Add(this.WB_archive_Rbut);
            this.groupBox4.Controls.Add(this.WB_work_Rbut);
            this.groupBox4.Location = new System.Drawing.Point(10, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(150, 55);
            this.groupBox4.TabIndex = 95;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Управление браузером";
            // 
            // WB_archive_Rbut
            // 
            this.WB_archive_Rbut.AutoSize = true;
            this.WB_archive_Rbut.Location = new System.Drawing.Point(4, 38);
            this.WB_archive_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_archive_Rbut.Name = "WB_archive_Rbut";
            this.WB_archive_Rbut.Size = new System.Drawing.Size(145, 17);
            this.WB_archive_Rbut.TabIndex = 3;
            this.WB_archive_Rbut.Text = "Показать папку Archive";
            this.WB_archive_Rbut.UseVisualStyleBackColor = true;
            this.WB_archive_Rbut.CheckedChanged += new System.EventHandler(this.WB_archive_Rbut_CheckedChanged);
            // 
            // WB_work_Rbut
            // 
            this.WB_work_Rbut.AutoSize = true;
            this.WB_work_Rbut.Checked = true;
            this.WB_work_Rbut.Location = new System.Drawing.Point(4, 17);
            this.WB_work_Rbut.Margin = new System.Windows.Forms.Padding(2);
            this.WB_work_Rbut.Name = "WB_work_Rbut";
            this.WB_work_Rbut.Size = new System.Drawing.Size(135, 17);
            this.WB_work_Rbut.TabIndex = 2;
            this.WB_work_Rbut.TabStop = true;
            this.WB_work_Rbut.Text = "Показать папку Work";
            this.WB_work_Rbut.UseVisualStyleBackColor = true;
            // 
            // Capacity_GrBox
            // 
            this.Capacity_GrBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Capacity_GrBox.Controls.Add(this.MegaBit_Label);
            this.Capacity_GrBox.Controls.Add(this.Capacity_Calc);
            this.Capacity_GrBox.Controls.Add(this.TeraBit_Label);
            this.Capacity_GrBox.Controls.Add(this.B_Dir_Size_TBox);
            this.Capacity_GrBox.Controls.Add(this.label6);
            this.Capacity_GrBox.Controls.Add(this.B_Dir_Count_TBox);
            this.Capacity_GrBox.Controls.Add(this.label5);
            this.Capacity_GrBox.Location = new System.Drawing.Point(237, 98);
            this.Capacity_GrBox.Margin = new System.Windows.Forms.Padding(2);
            this.Capacity_GrBox.Name = "Capacity_GrBox";
            this.Capacity_GrBox.Padding = new System.Windows.Forms.Padding(2);
            this.Capacity_GrBox.Size = new System.Drawing.Size(237, 78);
            this.Capacity_GrBox.TabIndex = 100;
            this.Capacity_GrBox.TabStop = false;
            this.Capacity_GrBox.Text = "Информация о директории";
            // 
            // MegaBit_Label
            // 
            this.MegaBit_Label.AutoSize = true;
            this.MegaBit_Label.Location = new System.Drawing.Point(175, 37);
            this.MegaBit_Label.Name = "MegaBit_Label";
            this.MegaBit_Label.Size = new System.Drawing.Size(22, 13);
            this.MegaBit_Label.TabIndex = 106;
            this.MegaBit_Label.Text = "Mb";
            // 
            // Capacity_Calc
            // 
            this.Capacity_Calc.Location = new System.Drawing.Point(4, 56);
            this.Capacity_Calc.Margin = new System.Windows.Forms.Padding(2);
            this.Capacity_Calc.Name = "Capacity_Calc";
            this.Capacity_Calc.Size = new System.Drawing.Size(179, 20);
            this.Capacity_Calc.TabIndex = 105;
            this.Capacity_Calc.Text = "Подсчет квоты";
            this.Capacity_Calc.UseVisualStyleBackColor = true;
            this.Capacity_Calc.Click += new System.EventHandler(this.Capacity_Calc_Click);
            // 
            // TeraBit_Label
            // 
            this.TeraBit_Label.AutoSize = true;
            this.TeraBit_Label.Location = new System.Drawing.Point(177, 37);
            this.TeraBit_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TeraBit_Label.Name = "TeraBit_Label";
            this.TeraBit_Label.Size = new System.Drawing.Size(20, 13);
            this.TeraBit_Label.TabIndex = 104;
            this.TeraBit_Label.Text = "Tb";
            // 
            // B_Dir_Size_TBox
            // 
            this.B_Dir_Size_TBox.Location = new System.Drawing.Point(129, 34);
            this.B_Dir_Size_TBox.Margin = new System.Windows.Forms.Padding(2);
            this.B_Dir_Size_TBox.Name = "B_Dir_Size_TBox";
            this.B_Dir_Size_TBox.Size = new System.Drawing.Size(50, 20);
            this.B_Dir_Size_TBox.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "Общий объем папок";
            // 
            // B_Dir_Count_TBox
            // 
            this.B_Dir_Count_TBox.Location = new System.Drawing.Point(129, 14);
            this.B_Dir_Count_TBox.Margin = new System.Windows.Forms.Padding(2);
            this.B_Dir_Count_TBox.Name = "B_Dir_Count_TBox";
            this.B_Dir_Count_TBox.Size = new System.Drawing.Size(50, 20);
            this.B_Dir_Count_TBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Количество папок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Обновить браузер";
            // 
            // Browser_Refresh_But
            // 
            this.Browser_Refresh_But.BackColor = System.Drawing.SystemColors.Control;
            this.Browser_Refresh_But.BackgroundImage = global::Ingest_Assistant.Properties.Resources.refresh1;
            this.Browser_Refresh_But.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Browser_Refresh_But.Location = new System.Drawing.Point(10, 167);
            this.Browser_Refresh_But.Margin = new System.Windows.Forms.Padding(2);
            this.Browser_Refresh_But.Name = "Browser_Refresh_But";
            this.Browser_Refresh_But.Size = new System.Drawing.Size(48, 46);
            this.Browser_Refresh_But.TabIndex = 101;
            this.Browser_Refresh_But.UseVisualStyleBackColor = false;
            this.Browser_Refresh_But.Click += new System.EventHandler(this.Browser_Refresh_But_Click);
            // 
            // Time_Count_GrBox
            // 
            this.Time_Count_GrBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Time_Count_GrBox.Controls.Add(this.Time_Count_L2_Lable);
            this.Time_Count_GrBox.Controls.Add(this.Time_Count_L1_Lable);
            this.Time_Count_GrBox.Controls.Add(this.Time_Count_PrBar);
            this.Time_Count_GrBox.Controls.Add(this.Time_Count_TBox);
            this.Time_Count_GrBox.Controls.Add(this.Time_Count_Refresh_Button);
            this.Time_Count_GrBox.Location = new System.Drawing.Point(10, 71);
            this.Time_Count_GrBox.Name = "Time_Count_GrBox";
            this.Time_Count_GrBox.Size = new System.Drawing.Size(218, 91);
            this.Time_Count_GrBox.TabIndex = 104;
            this.Time_Count_GrBox.TabStop = false;
            this.Time_Count_GrBox.Text = "Загрузка аппаратной за указанный день";
            // 
            // Time_Count_L2_Lable
            // 
            this.Time_Count_L2_Lable.AutoSize = true;
            this.Time_Count_L2_Lable.Location = new System.Drawing.Point(6, 42);
            this.Time_Count_L2_Lable.Name = "Time_Count_L2_Lable";
            this.Time_Count_L2_Lable.Size = new System.Drawing.Size(109, 13);
            this.Time_Count_L2_Lable.TabIndex = 3;
            this.Time_Count_L2_Lable.Text = "                                  ";
            // 
            // Time_Count_L1_Lable
            // 
            this.Time_Count_L1_Lable.AutoSize = true;
            this.Time_Count_L1_Lable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Time_Count_L1_Lable.ForeColor = System.Drawing.Color.Black;
            this.Time_Count_L1_Lable.Location = new System.Drawing.Point(138, 24);
            this.Time_Count_L1_Lable.Name = "Time_Count_L1_Lable";
            this.Time_Count_L1_Lable.Size = new System.Drawing.Size(64, 13);
            this.Time_Count_L1_Lable.TabIndex = 0;
            this.Time_Count_L1_Lable.Text = "                   ";
            // 
            // Time_Count_PrBar
            // 
            this.Time_Count_PrBar.BackColor = System.Drawing.SystemColors.Control;
            this.Time_Count_PrBar.Location = new System.Drawing.Point(6, 18);
            this.Time_Count_PrBar.Name = "Time_Count_PrBar";
            this.Time_Count_PrBar.Size = new System.Drawing.Size(198, 20);
            this.Time_Count_PrBar.TabIndex = 2;
            // 
            // Time_Count_TBox
            // 
            this.Time_Count_TBox.Location = new System.Drawing.Point(6, 18);
            this.Time_Count_TBox.Name = "Time_Count_TBox";
            this.Time_Count_TBox.Size = new System.Drawing.Size(150, 20);
            this.Time_Count_TBox.TabIndex = 1;
            // 
            // Time_Count_Refresh_Button
            // 
            this.Time_Count_Refresh_Button.Location = new System.Drawing.Point(10, 57);
            this.Time_Count_Refresh_Button.Name = "Time_Count_Refresh_Button";
            this.Time_Count_Refresh_Button.Size = new System.Drawing.Size(195, 22);
            this.Time_Count_Refresh_Button.TabIndex = 0;
            this.Time_Count_Refresh_Button.Text = "Рассчитать загрузку аппаратной";
            this.Time_Count_Refresh_Button.UseVisualStyleBackColor = true;
            this.Time_Count_Refresh_Button.Click += new System.EventHandler(this.Time_Count_Refresh_Button_Click);
            // 
            // BGW
            // 
            this.BGW.WorkerSupportsCancellation = true;
            this.BGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_DoWork);
            this.BGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RunWorkerCompleted);
            // 
            // Exit_But
            // 
            this.Exit_But.Location = new System.Drawing.Point(237, 182);
            this.Exit_But.Name = "Exit_But";
            this.Exit_But.Size = new System.Drawing.Size(237, 24);
            this.Exit_But.TabIndex = 105;
            this.Exit_But.Text = "Закрыть Рабочие формы";
            this.Exit_But.UseVisualStyleBackColor = true;
            this.Exit_But.Click += new System.EventHandler(this.Exit_But_Click);
            // 
            // data_Set_But
            // 
            this.data_Set_But.Location = new System.Drawing.Point(166, 61);
            this.data_Set_But.Name = "data_Set_But";
            this.data_Set_But.Size = new System.Drawing.Size(71, 21);
            this.data_Set_But.TabIndex = 4;
            this.data_Set_But.Text = "Тек Дата";
            this.data_Set_But.UseVisualStyleBackColor = true;
            this.data_Set_But.Click += new System.EventHandler(this.data_Set_But_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(490, 549);
            this.Controls.Add(this.Exit_But);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.Time_Count_GrBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Browser_Refresh_But);
            this.Controls.Add(this.Capacity_GrBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Browser";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.SizeChanged += new System.EventHandler(this.Browser_SizeChanged);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Capacity_GrBox.ResumeLayout(false);
            this.Capacity_GrBox.PerformLayout();
            this.Time_Count_GrBox.ResumeLayout(false);
            this.Time_Count_GrBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker WB_date_picker;
        private System.Windows.Forms.RadioButton WB_D_setd_Rbut;
        private System.Windows.Forms.RadioButton WB_D_all_Rbut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton WB_S_D_Rbut;
        private System.Windows.Forms.RadioButton WB_S_N_Rbut;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton WB_archive_Rbut;
        private System.Windows.Forms.RadioButton WB_work_Rbut;
        private System.Windows.Forms.GroupBox Capacity_GrBox;
        private System.Windows.Forms.TextBox B_Dir_Size_TBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox B_Dir_Count_TBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TeraBit_Label;
        private System.Windows.Forms.Button Capacity_Calc;
        private System.Windows.Forms.Button Browser_Refresh_But;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Time_Count_TBox;
        public System.Windows.Forms.Button Time_Count_Refresh_Button;
        public System.Windows.Forms.Label Time_Count_L2_Lable;
        public System.Windows.Forms.Label Time_Count_L1_Lable;
        public System.Windows.Forms.ProgressBar Time_Count_PrBar;
        public System.Windows.Forms.GroupBox Time_Count_GrBox;
        public System.ComponentModel.BackgroundWorker BGW;
        private System.Windows.Forms.Button Exit_But;
        private System.Windows.Forms.Label MegaBit_Label;
        private System.Windows.Forms.Button data_Set_But;
    }
}