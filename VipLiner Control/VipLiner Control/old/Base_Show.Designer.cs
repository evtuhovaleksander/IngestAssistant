namespace Ingest_Assistant
{
    partial class Base_Show
    {
         ///<summary>
         ///Required designer variable.
         ///</summary>
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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viplan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qwe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info_Load = new System.Windows.Forms.Button();
            this.dgv_short = new System.Windows.Forms.DataGridView();
            this.sID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sViplanner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDatastart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTimeofreg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sReel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Date_Filter2 = new System.Windows.Forms.DateTimePicker();
            this.D_Duraation_RBut = new System.Windows.Forms.RadioButton();
            this.D_One_RBut = new System.Windows.Forms.RadioButton();
            this.Date_Filter1 = new System.Windows.Forms.DateTimePicker();
            this.D_Date_ChBox = new System.Windows.Forms.CheckBox();
            this.Viplanner_TBox = new System.Windows.Forms.TextBox();
            this.ViPlanner_ChBOX = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Show_SHORT_RBut = new System.Windows.Forms.RadioButton();
            this.Show_ALL_RBut = new System.Windows.Forms.RadioButton();
            this.Main_Load_But = new System.Windows.Forms.Button();
            this.Apply_Filter_But = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Reel_ID_ChBox = new System.Windows.Forms.CheckBox();
            this.Reel_Id_TBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_short)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Viplan,
            this.T,
            this.Column1,
            this.qw,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.qwe,
            this.Column6,
            this.Column7,
            this.Column8,
            this.asd,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23});
            this.dgv.Location = new System.Drawing.Point(9, 172);
            this.dgv.Margin = new System.Windows.Forms.Padding(2);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1869, 660);
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // Viplan
            // 
            this.Viplan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Viplan.HeaderText = "ViPlanner";
            this.Viplan.Name = "Viplan";
            this.Viplan.ReadOnly = true;
            this.Viplan.Width = 77;
            // 
            // T
            // 
            this.T.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.T.HeaderText = "Title";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            this.T.Width = 52;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Data Start";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 74;
            // 
            // qw
            // 
            this.qw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qw.HeaderText = "Ingest Start";
            this.qw.Name = "qw";
            this.qw.ReadOnly = true;
            this.qw.Width = 79;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Ingest End";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 77;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Ingest Duration";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 96;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Render Time";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 86;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Time of Registration";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 115;
            // 
            // qwe
            // 
            this.qwe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qwe.HeaderText = "Total Time";
            this.qwe.Name = "qwe";
            this.qwe.ReadOnly = true;
            this.qwe.Width = 76;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "Source Duration";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Media Type";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 81;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.HeaderText = "Reel ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 63;
            // 
            // asd
            // 
            this.asd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.asd.HeaderText = "Efir Date";
            this.asd.Name = "asd";
            this.asd.ReadOnly = true;
            this.asd.Width = 68;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column9.HeaderText = "Ingest Line";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 78;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column10.HeaderText = "Ingest Operator";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 96;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column11.HeaderText = "Format IN";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 72;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column12.HeaderText = "Harris IN";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 68;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column13.HeaderText = "Audio";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 59;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column14.HeaderText = "Dolby";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 59;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column15.HeaderText = "Edit Line";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 68;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column16.HeaderText = "Operator";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 73;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column17.HeaderText = "Type of Work";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 89;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column18.HeaderText = "Harris OUT";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 78;
            // 
            // Column19
            // 
            this.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column19.HeaderText = "Format OUT";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Width = 83;
            // 
            // Column20
            // 
            this.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column20.HeaderText = "Card Marks";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 79;
            // 
            // Column21
            // 
            this.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column21.HeaderText = "Info Lost";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Width = 68;
            // 
            // Column22
            // 
            this.Column22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column22.HeaderText = "Notes";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Width = 60;
            // 
            // Column23
            // 
            this.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column23.HeaderText = "Deleted";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 69;
            // 
            // Info_Load
            // 
            this.Info_Load.Location = new System.Drawing.Point(1002, 11);
            this.Info_Load.Margin = new System.Windows.Forms.Padding(2);
            this.Info_Load.Name = "Info_Load";
            this.Info_Load.Size = new System.Drawing.Size(218, 29);
            this.Info_Load.TabIndex = 1;
            this.Info_Load.Text = "Загрузить информацию";
            this.Info_Load.UseVisualStyleBackColor = true;
            this.Info_Load.Visible = false;
            this.Info_Load.Click += new System.EventHandler(this.Info_Load_Click);
            // 
            // dgv_short
            // 
            this.dgv_short.AllowUserToAddRows = false;
            this.dgv_short.AllowUserToDeleteRows = false;
            this.dgv_short.AllowUserToOrderColumns = true;
            this.dgv_short.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_short.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sID,
            this.sViplanner,
            this.sTitle,
            this.sDatastart,
            this.sTimeofreg,
            this.sTT,
            this.sMDT,
            this.sReel,
            this.sTW});
            this.dgv_short.Location = new System.Drawing.Point(9, 172);
            this.dgv_short.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_short.Name = "dgv_short";
            this.dgv_short.ReadOnly = true;
            this.dgv_short.RowTemplate.Height = 24;
            this.dgv_short.Size = new System.Drawing.Size(1869, 670);
            this.dgv_short.TabIndex = 2;
            this.dgv_short.Visible = false;
            this.dgv_short.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_short_CellDoubleClick);
            // 
            // sID
            // 
            this.sID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sID.HeaderText = "ID";
            this.sID.Name = "sID";
            this.sID.ReadOnly = true;
            this.sID.Width = 43;
            // 
            // sViplanner
            // 
            this.sViplanner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sViplanner.HeaderText = "ViPlanner";
            this.sViplanner.Name = "sViplanner";
            this.sViplanner.ReadOnly = true;
            this.sViplanner.Width = 77;
            // 
            // sTitle
            // 
            this.sTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTitle.HeaderText = "Заголовок";
            this.sTitle.Name = "sTitle";
            this.sTitle.ReadOnly = true;
            this.sTitle.Width = 86;
            // 
            // sDatastart
            // 
            this.sDatastart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sDatastart.HeaderText = "Data_Start";
            this.sDatastart.Name = "sDatastart";
            this.sDatastart.ReadOnly = true;
            this.sDatastart.Width = 83;
            // 
            // sTimeofreg
            // 
            this.sTimeofreg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTimeofreg.HeaderText = "Time of reg";
            this.sTimeofreg.Name = "sTimeofreg";
            this.sTimeofreg.ReadOnly = true;
            this.sTimeofreg.Width = 85;
            // 
            // sTT
            // 
            this.sTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTT.HeaderText = "Total time";
            this.sTT.Name = "sTT";
            this.sTT.ReadOnly = true;
            this.sTT.Width = 78;
            // 
            // sMDT
            // 
            this.sMDT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sMDT.HeaderText = "Media Type";
            this.sMDT.Name = "sMDT";
            this.sMDT.ReadOnly = true;
            this.sMDT.Width = 88;
            // 
            // sReel
            // 
            this.sReel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sReel.HeaderText = "Reel ID";
            this.sReel.Name = "sReel";
            this.sReel.ReadOnly = true;
            this.sReel.Width = 68;
            // 
            // sTW
            // 
            this.sTW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTW.HeaderText = "Type of work";
            this.sTW.Name = "sTW";
            this.sTW.ReadOnly = true;
            this.sTW.Width = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.Info_Load);
            this.groupBox1.Location = new System.Drawing.Point(256, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1277, 155);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки отображения";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Date_Filter2);
            this.groupBox3.Controls.Add(this.D_Duraation_RBut);
            this.groupBox3.Controls.Add(this.D_One_RBut);
            this.groupBox3.Controls.Add(this.Date_Filter1);
            this.groupBox3.Controls.Add(this.D_Date_ChBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 61);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(215, 94);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фильтр дат";
            // 
            // Date_Filter2
            // 
            this.Date_Filter2.Location = new System.Drawing.Point(4, 72);
            this.Date_Filter2.Margin = new System.Windows.Forms.Padding(2);
            this.Date_Filter2.Name = "Date_Filter2";
            this.Date_Filter2.Size = new System.Drawing.Size(151, 20);
            this.Date_Filter2.TabIndex = 4;
            this.Date_Filter2.Visible = false;
            // 
            // D_Duraation_RBut
            // 
            this.D_Duraation_RBut.AutoSize = true;
            this.D_Duraation_RBut.Location = new System.Drawing.Point(98, 25);
            this.D_Duraation_RBut.Margin = new System.Windows.Forms.Padding(2);
            this.D_Duraation_RBut.Name = "D_Duraation_RBut";
            this.D_Duraation_RBut.Size = new System.Drawing.Size(89, 17);
            this.D_Duraation_RBut.TabIndex = 3;
            this.D_Duraation_RBut.Text = "Промежуток";
            this.D_Duraation_RBut.UseVisualStyleBackColor = true;
            // 
            // D_One_RBut
            // 
            this.D_One_RBut.AutoSize = true;
            this.D_One_RBut.Checked = true;
            this.D_One_RBut.Location = new System.Drawing.Point(98, 9);
            this.D_One_RBut.Margin = new System.Windows.Forms.Padding(2);
            this.D_One_RBut.Name = "D_One_RBut";
            this.D_One_RBut.Size = new System.Drawing.Size(52, 17);
            this.D_One_RBut.TabIndex = 2;
            this.D_One_RBut.TabStop = true;
            this.D_One_RBut.Text = "День";
            this.D_One_RBut.UseVisualStyleBackColor = true;
            this.D_One_RBut.CheckedChanged += new System.EventHandler(this.D_One_RBut_CheckedChanged);
            // 
            // Date_Filter1
            // 
            this.Date_Filter1.Location = new System.Drawing.Point(4, 49);
            this.Date_Filter1.Margin = new System.Windows.Forms.Padding(2);
            this.Date_Filter1.Name = "Date_Filter1";
            this.Date_Filter1.Size = new System.Drawing.Size(151, 20);
            this.Date_Filter1.TabIndex = 1;
            // 
            // D_Date_ChBox
            // 
            this.D_Date_ChBox.AutoSize = true;
            this.D_Date_ChBox.Location = new System.Drawing.Point(4, 17);
            this.D_Date_ChBox.Margin = new System.Windows.Forms.Padding(2);
            this.D_Date_ChBox.Name = "D_Date_ChBox";
            this.D_Date_ChBox.Size = new System.Drawing.Size(86, 17);
            this.D_Date_ChBox.TabIndex = 0;
            this.D_Date_ChBox.Text = "Фильтр дат";
            this.D_Date_ChBox.UseVisualStyleBackColor = true;
            // 
            // Viplanner_TBox
            // 
            this.Viplanner_TBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Viplanner_TBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Viplanner_TBox.Location = new System.Drawing.Point(96, 17);
            this.Viplanner_TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Viplanner_TBox.Name = "Viplanner_TBox";
            this.Viplanner_TBox.Size = new System.Drawing.Size(104, 20);
            this.Viplanner_TBox.TabIndex = 2;
            // 
            // ViPlanner_ChBOX
            // 
            this.ViPlanner_ChBOX.AutoSize = true;
            this.ViPlanner_ChBOX.Location = new System.Drawing.Point(5, 18);
            this.ViPlanner_ChBOX.Margin = new System.Windows.Forms.Padding(2);
            this.ViPlanner_ChBOX.Name = "ViPlanner_ChBOX";
            this.ViPlanner_ChBOX.Size = new System.Drawing.Size(95, 17);
            this.ViPlanner_ChBOX.TabIndex = 1;
            this.ViPlanner_ChBOX.Text = "Фильтр по ID";
            this.ViPlanner_ChBOX.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.Show_SHORT_RBut);
            this.groupBox2.Controls.Add(this.Show_ALL_RBut);
            this.groupBox2.Location = new System.Drawing.Point(21, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 61);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отображение";
            // 
            // Show_SHORT_RBut
            // 
            this.Show_SHORT_RBut.AutoSize = true;
            this.Show_SHORT_RBut.Location = new System.Drawing.Point(6, 42);
            this.Show_SHORT_RBut.Name = "Show_SHORT_RBut";
            this.Show_SHORT_RBut.Size = new System.Drawing.Size(95, 17);
            this.Show_SHORT_RBut.TabIndex = 1;
            this.Show_SHORT_RBut.Text = "Сокращенное";
            this.Show_SHORT_RBut.UseVisualStyleBackColor = true;
            // 
            // Show_ALL_RBut
            // 
            this.Show_ALL_RBut.AutoSize = true;
            this.Show_ALL_RBut.Checked = true;
            this.Show_ALL_RBut.Location = new System.Drawing.Point(6, 19);
            this.Show_ALL_RBut.Name = "Show_ALL_RBut";
            this.Show_ALL_RBut.Size = new System.Drawing.Size(63, 17);
            this.Show_ALL_RBut.TabIndex = 0;
            this.Show_ALL_RBut.TabStop = true;
            this.Show_ALL_RBut.Text = "Полное";
            this.Show_ALL_RBut.UseVisualStyleBackColor = true;
            this.Show_ALL_RBut.CheckedChanged += new System.EventHandler(this.Show_ALL_RBut_CheckedChanged);
            // 
            // Main_Load_But
            // 
            this.Main_Load_But.Location = new System.Drawing.Point(129, 19);
            this.Main_Load_But.Name = "Main_Load_But";
            this.Main_Load_But.Size = new System.Drawing.Size(127, 61);
            this.Main_Load_But.TabIndex = 4;
            this.Main_Load_But.Text = "Загрузить данные";
            this.Main_Load_But.UseVisualStyleBackColor = true;
            this.Main_Load_But.Click += new System.EventHandler(this.Main_Load_But_Click);
            // 
            // Apply_Filter_But
            // 
            this.Apply_Filter_But.Enabled = false;
            this.Apply_Filter_But.Location = new System.Drawing.Point(21, 84);
            this.Apply_Filter_But.Name = "Apply_Filter_But";
            this.Apply_Filter_But.Size = new System.Drawing.Size(235, 58);
            this.Apply_Filter_But.TabIndex = 5;
            this.Apply_Filter_But.Text = "Применить фильтры";
            this.Apply_Filter_But.UseVisualStyleBackColor = true;
            this.Apply_Filter_But.Click += new System.EventHandler(this.Apply_Filter_But_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ViPlanner_ChBOX);
            this.groupBox4.Controls.Add(this.Viplanner_TBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 41);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Фильтр ViPlanner ID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Reel_ID_ChBox);
            this.groupBox5.Controls.Add(this.Reel_Id_TBox);
            this.groupBox5.Location = new System.Drawing.Point(238, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(374, 41);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Фильтр ViPlanner ID";
            // 
            // Reel_ID_ChBox
            // 
            this.Reel_ID_ChBox.AutoSize = true;
            this.Reel_ID_ChBox.Location = new System.Drawing.Point(5, 18);
            this.Reel_ID_ChBox.Margin = new System.Windows.Forms.Padding(2);
            this.Reel_ID_ChBox.Name = "Reel_ID_ChBox";
            this.Reel_ID_ChBox.Size = new System.Drawing.Size(123, 17);
            this.Reel_ID_ChBox.TabIndex = 1;
            this.Reel_ID_ChBox.Text = "Фильтр по Reel_ID";
            this.Reel_ID_ChBox.UseVisualStyleBackColor = true;
            // 
            // Reel_Id_TBox
            // 
            this.Reel_Id_TBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Reel_Id_TBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Reel_Id_TBox.Location = new System.Drawing.Point(132, 16);
            this.Reel_Id_TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Reel_Id_TBox.Name = "Reel_Id_TBox";
            this.Reel_Id_TBox.Size = new System.Drawing.Size(237, 20);
            this.Reel_Id_TBox.TabIndex = 2;
            // 
            // Base_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1889, 843);
            this.Controls.Add(this.Apply_Filter_But);
            this.Controls.Add(this.Main_Load_But);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_short);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Base_Show";
            this.Text = "Base_Show";
            this.Load += new System.EventHandler(this.Base_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_short)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button Info_Load;
        private System.Windows.Forms.DataGridView dgv_short;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Show_SHORT_RBut;
        private System.Windows.Forms.RadioButton Show_ALL_RBut;
        private System.Windows.Forms.TextBox Viplanner_TBox;
        private System.Windows.Forms.CheckBox ViPlanner_ChBOX;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker Date_Filter2;
        private System.Windows.Forms.RadioButton D_Duraation_RBut;
        private System.Windows.Forms.RadioButton D_One_RBut;
        private System.Windows.Forms.DateTimePicker Date_Filter1;
        private System.Windows.Forms.CheckBox D_Date_ChBox;
        private System.Windows.Forms.Button Main_Load_But;
        private System.Windows.Forms.Button Apply_Filter_But;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viplan;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn qwe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn asd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn sID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sViplanner;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDatastart;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTimeofreg;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn sReel;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTW;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox Reel_ID_ChBox;
        private System.Windows.Forms.TextBox Reel_Id_TBox;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}