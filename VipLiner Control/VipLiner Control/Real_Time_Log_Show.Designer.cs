namespace Ingest_Assistant
{
    partial class Real_Time_Log_Show
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
            this.components = new System.ComponentModel.Container();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Delay_TBox = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Wait_TBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remain = new System.Windows.Forms.Label();
            this.Load_One_Time_But = new System.Windows.Forms.Button();
            this.Timer_Start = new System.Windows.Forms.Button();
            this.Timer_Stop = new System.Windows.Forms.Button();
            this.Show_But = new System.Windows.Forms.Button();
            this.Collect_PrBar = new System.Windows.Forms.ProgressBar();
            this.Dgv_PrBar = new System.Windows.Forms.ProgressBar();
            this.Wait_prBar = new System.Windows.Forms.ProgressBar();
            this.Show_All_But = new System.Windows.Forms.Button();
            this.all_to_white_but = new System.Windows.Forms.Button();
            this.U_Filter_CmBox = new System.Windows.Forms.ComboBox();
            this.U_Show_All_RBut = new System.Windows.Forms.RadioButton();
            this.U_Show_Only_RBut = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C2,
            this.C5,
            this.C3,
            this.C4,
            this.C6,
            this.C7,
            this.C8,
            this.C1});
            this.dgv.Location = new System.Drawing.Point(16, 158);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(2536, 630);
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // Delay_TBox
            // 
            this.Delay_TBox.Location = new System.Drawing.Point(1891, 15);
            this.Delay_TBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Delay_TBox.Name = "Delay_TBox";
            this.Delay_TBox.Size = new System.Drawing.Size(132, 22);
            this.Delay_TBox.TabIndex = 1;
            this.Delay_TBox.Text = "10";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Wait_TBox
            // 
            this.Wait_TBox.Location = new System.Drawing.Point(887, 14);
            this.Wait_TBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Wait_TBox.Name = "Wait_TBox";
            this.Wait_TBox.Size = new System.Drawing.Size(132, 22);
            this.Wait_TBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1836, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // remain
            // 
            this.remain.AutoSize = true;
            this.remain.Location = new System.Drawing.Point(828, 22);
            this.remain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.remain.Name = "remain";
            this.remain.Size = new System.Drawing.Size(46, 17);
            this.remain.TabIndex = 4;
            this.remain.Text = "label2";
            // 
            // Load_One_Time_But
            // 
            this.Load_One_Time_But.Location = new System.Drawing.Point(16, 9);
            this.Load_One_Time_But.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Load_One_Time_But.Name = "Load_One_Time_But";
            this.Load_One_Time_But.Size = new System.Drawing.Size(100, 28);
            this.Load_One_Time_But.TabIndex = 5;
            this.Load_One_Time_But.Text = "recolect";
            this.Load_One_Time_But.UseVisualStyleBackColor = true;
            this.Load_One_Time_But.Click += new System.EventHandler(this.Load_One_Time_But_Click);
            // 
            // Timer_Start
            // 
            this.Timer_Start.Location = new System.Drawing.Point(124, 9);
            this.Timer_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Timer_Start.Name = "Timer_Start";
            this.Timer_Start.Size = new System.Drawing.Size(100, 28);
            this.Timer_Start.TabIndex = 6;
            this.Timer_Start.Text = "start";
            this.Timer_Start.UseVisualStyleBackColor = true;
            this.Timer_Start.Click += new System.EventHandler(this.Timer_Start_Click);
            // 
            // Timer_Stop
            // 
            this.Timer_Stop.Location = new System.Drawing.Point(124, 44);
            this.Timer_Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Timer_Stop.Name = "Timer_Stop";
            this.Timer_Stop.Size = new System.Drawing.Size(100, 28);
            this.Timer_Stop.TabIndex = 7;
            this.Timer_Stop.Text = "stop";
            this.Timer_Stop.UseVisualStyleBackColor = true;
            this.Timer_Stop.Click += new System.EventHandler(this.Timer_Stop_Click);
            // 
            // Show_But
            // 
            this.Show_But.Location = new System.Drawing.Point(16, 44);
            this.Show_But.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Show_But.Name = "Show_But";
            this.Show_But.Size = new System.Drawing.Size(100, 28);
            this.Show_But.TabIndex = 8;
            this.Show_But.Text = "show";
            this.Show_But.UseVisualStyleBackColor = true;
            this.Show_But.Click += new System.EventHandler(this.Show_But_Click);
            // 
            // Collect_PrBar
            // 
            this.Collect_PrBar.Location = new System.Drawing.Point(1025, 11);
            this.Collect_PrBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Collect_PrBar.Name = "Collect_PrBar";
            this.Collect_PrBar.Size = new System.Drawing.Size(803, 28);
            this.Collect_PrBar.TabIndex = 9;
            // 
            // Dgv_PrBar
            // 
            this.Dgv_PrBar.Location = new System.Drawing.Point(1025, 47);
            this.Dgv_PrBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_PrBar.Name = "Dgv_PrBar";
            this.Dgv_PrBar.Size = new System.Drawing.Size(803, 28);
            this.Dgv_PrBar.TabIndex = 10;
            // 
            // Wait_prBar
            // 
            this.Wait_prBar.Location = new System.Drawing.Point(832, 42);
            this.Wait_prBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Wait_prBar.Name = "Wait_prBar";
            this.Wait_prBar.Size = new System.Drawing.Size(188, 31);
            this.Wait_prBar.TabIndex = 11;
            // 
            // Show_All_But
            // 
            this.Show_All_But.Enabled = false;
            this.Show_All_But.Location = new System.Drawing.Point(232, 9);
            this.Show_All_But.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Show_All_But.Name = "Show_All_But";
            this.Show_All_But.Size = new System.Drawing.Size(100, 28);
            this.Show_All_But.TabIndex = 12;
            this.Show_All_But.Text = "Show_All";
            this.Show_All_But.UseVisualStyleBackColor = true;
            this.Show_All_But.Click += new System.EventHandler(this.Show_All_But_Click);
            // 
            // all_to_white_but
            // 
            this.all_to_white_but.Location = new System.Drawing.Point(232, 46);
            this.all_to_white_but.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.all_to_white_but.Name = "all_to_white_but";
            this.all_to_white_but.Size = new System.Drawing.Size(100, 28);
            this.all_to_white_but.TabIndex = 13;
            this.all_to_white_but.Text = "Clear_color";
            this.all_to_white_but.UseVisualStyleBackColor = true;
            this.all_to_white_but.Click += new System.EventHandler(this.all_to_white_but_Click);
            // 
            // U_Filter_CmBox
            // 
            this.U_Filter_CmBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.U_Filter_CmBox.FormattingEnabled = true;
            this.U_Filter_CmBox.Location = new System.Drawing.Point(123, 44);
            this.U_Filter_CmBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Filter_CmBox.Name = "U_Filter_CmBox";
            this.U_Filter_CmBox.Size = new System.Drawing.Size(191, 24);
            this.U_Filter_CmBox.TabIndex = 14;
            // 
            // U_Show_All_RBut
            // 
            this.U_Show_All_RBut.AutoSize = true;
            this.U_Show_All_RBut.Checked = true;
            this.U_Show_All_RBut.Location = new System.Drawing.Point(5, 18);
            this.U_Show_All_RBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Show_All_RBut.Name = "U_Show_All_RBut";
            this.U_Show_All_RBut.Size = new System.Drawing.Size(53, 21);
            this.U_Show_All_RBut.TabIndex = 16;
            this.U_Show_All_RBut.TabStop = true;
            this.U_Show_All_RBut.Text = "Все";
            this.U_Show_All_RBut.UseVisualStyleBackColor = true;
            // 
            // U_Show_Only_RBut
            // 
            this.U_Show_Only_RBut.AutoSize = true;
            this.U_Show_Only_RBut.Location = new System.Drawing.Point(5, 46);
            this.U_Show_Only_RBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Show_Only_RBut.Name = "U_Show_Only_RBut";
            this.U_Show_Only_RBut.Size = new System.Drawing.Size(110, 21);
            this.U_Show_Only_RBut.TabIndex = 17;
            this.U_Show_Only_RBut.Text = "Конкретный";
            this.U_Show_Only_RBut.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.U_Show_Only_RBut);
            this.groupBox1.Controls.Add(this.U_Filter_CmBox);
            this.groupBox1.Controls.Add(this.U_Show_All_RBut);
            this.groupBox1.Location = new System.Drawing.Point(503, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(319, 71);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователь";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(16, 86);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(405, 53);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Записей";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(125, 9);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar1.Maximum = 250;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(272, 56);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 50;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 21);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 21;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(257, 23);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(431, 91);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(444, 59);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Промежуток между ID";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Location = new System.Drawing.Point(903, 85);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(261, 64);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "История по ID";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 23;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 28);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(340, 9);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 26;
            this.button4.Text = "Show_All_Fast";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "50";
            // 
            // C2
            // 
            this.C2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C2.HeaderText = "Time";
            this.C2.Name = "C2";
            this.C2.ReadOnly = true;
            this.C2.Width = 64;
            // 
            // C5
            // 
            this.C5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C5.HeaderText = "User";
            this.C5.Name = "C5";
            this.C5.ReadOnly = true;
            this.C5.Width = 63;
            // 
            // C3
            // 
            this.C3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C3.HeaderText = "Group";
            this.C3.Name = "C3";
            this.C3.ReadOnly = true;
            this.C3.Width = 73;
            // 
            // C4
            // 
            this.C4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C4.HeaderText = "Name";
            this.C4.Name = "C4";
            this.C4.ReadOnly = true;
            this.C4.Width = 70;
            // 
            // C6
            // 
            this.C6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C6.HeaderText = "From";
            this.C6.Name = "C6";
            this.C6.ReadOnly = true;
            this.C6.Width = 65;
            // 
            // C7
            // 
            this.C7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C7.HeaderText = "To";
            this.C7.Name = "C7";
            this.C7.ReadOnly = true;
            this.C7.Width = 50;
            // 
            // C8
            // 
            this.C8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.C8.HeaderText = "Viplanner";
            this.C8.Name = "C8";
            this.C8.ReadOnly = true;
            this.C8.Width = 93;
            // 
            // C1
            // 
            this.C1.HeaderText = "ID";
            this.C1.Name = "C1";
            this.C1.ReadOnly = true;
            // 
            // Real_Time_Log_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2568, 802);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.all_to_white_but);
            this.Controls.Add(this.Show_All_But);
            this.Controls.Add(this.Wait_prBar);
            this.Controls.Add(this.Dgv_PrBar);
            this.Controls.Add(this.Collect_PrBar);
            this.Controls.Add(this.Show_But);
            this.Controls.Add(this.Timer_Stop);
            this.Controls.Add(this.Timer_Start);
            this.Controls.Add(this.Load_One_Time_But);
            this.Controls.Add(this.remain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Wait_TBox);
            this.Controls.Add(this.Delay_TBox);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Real_Time_Log_Show";
            this.Text = "Real_Time_Log_Show";
            this.Load += new System.EventHandler(this.Real_Time_Log_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox Delay_TBox;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox Wait_TBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label remain;
        private System.Windows.Forms.Button Load_One_Time_But;
        private System.Windows.Forms.Button Timer_Start;
        private System.Windows.Forms.Button Timer_Stop;
        private System.Windows.Forms.Button Show_But;
        private System.Windows.Forms.ProgressBar Collect_PrBar;
        private System.Windows.Forms.ProgressBar Dgv_PrBar;
        private System.Windows.Forms.ProgressBar Wait_prBar;
        private System.Windows.Forms.Button Show_All_But;
        private System.Windows.Forms.Button all_to_white_but;
        private System.Windows.Forms.ComboBox U_Filter_CmBox;
        private System.Windows.Forms.RadioButton U_Show_All_RBut;
        private System.Windows.Forms.RadioButton U_Show_Only_RBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C5;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3;
        private System.Windows.Forms.DataGridViewTextBoxColumn C4;
        private System.Windows.Forms.DataGridViewTextBoxColumn C6;
        private System.Windows.Forms.DataGridViewTextBoxColumn C7;
        private System.Windows.Forms.DataGridViewTextBoxColumn C8;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1;
    }
}