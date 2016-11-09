using System.IO;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    partial class Main_Form
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
            Log_Class.Logout();

            //if (Directory.Exists(Ingest_Assistant.Properties.Settings.Default.Base_Archive))
            //{
            //    Base_Administration frm=new Base_Administration();
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("База не была архивированна из-за недоступности папки архива");
            //}


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileWorkFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеРапортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.служебныеФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрБазыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.прямойДоступКРабочимПапкамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаWORKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаARCHIVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаSTOCKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаMASTERPREPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаTEMPFILESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаSHABLONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаCOMPLETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metaSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.datesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datesSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Work_PANEL = new System.Windows.Forms.Panel();
            this.Browser_Form_PANEL = new System.Windows.Forms.Panel();
            this.Admin_Button = new System.Windows.Forms.Button();
            this.setting_params = new System.Windows.Forms.Button();
            this.Version_But = new System.Windows.Forms.Button();
            this.RTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFormToolStripMenuItem,
            this.служебныеФункцииToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1268, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startFormToolStripMenuItem
            // 
            this.startFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileWorkFormToolStripMenuItem,
            this.созданиеРапортаToolStripMenuItem});
            this.startFormToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startFormToolStripMenuItem.Name = "startFormToolStripMenuItem";
            this.startFormToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.startFormToolStripMenuItem.Text = "Рабочие формы";
            // 
            // fileWorkFormToolStripMenuItem
            // 
            this.fileWorkFormToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileWorkFormToolStripMenuItem.Name = "fileWorkFormToolStripMenuItem";
            this.fileWorkFormToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.fileWorkFormToolStripMenuItem.Text = "Стартовая форма";
            this.fileWorkFormToolStripMenuItem.Click += new System.EventHandler(this.fileWorkFormToolStripMenuItem_Click);
            // 
            // созданиеРапортаToolStripMenuItem
            // 
            this.созданиеРапортаToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.созданиеРапортаToolStripMenuItem.Name = "созданиеРапортаToolStripMenuItem";
            this.созданиеРапортаToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.созданиеРапортаToolStripMenuItem.Text = "Создание Рапорта";
            this.созданиеРапортаToolStripMenuItem.Click += new System.EventHandler(this.созданиеРапортаToolStripMenuItem_Click);
            // 
            // служебныеФункцииToolStripMenuItem
            // 
            this.служебныеФункцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрБазыToolStripMenuItem1,
            this.прямойДоступКРабочимПапкамToolStripMenuItem});
            this.служебныеФункцииToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.служебныеФункцииToolStripMenuItem.Name = "служебныеФункцииToolStripMenuItem";
            this.служебныеФункцииToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.служебныеФункцииToolStripMenuItem.Text = "Служебные функции";
            // 
            // просмотрБазыToolStripMenuItem1
            // 
            this.просмотрБазыToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.просмотрБазыToolStripMenuItem1.Name = "просмотрБазыToolStripMenuItem1";
            this.просмотрБазыToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.просмотрБазыToolStripMenuItem1.Text = "Просмотр Базы";
            this.просмотрБазыToolStripMenuItem1.Click += new System.EventHandler(this.просмотрБазыToolStripMenuItem1_Click);
            // 
            // прямойДоступКРабочимПапкамToolStripMenuItem
            // 
            this.прямойДоступКРабочимПапкамToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.папкаWORKToolStripMenuItem,
            this.папкаARCHIVEToolStripMenuItem,
            this.папкаSTOCKToolStripMenuItem,
            this.папкаMASTERPREPToolStripMenuItem,
            this.папкаToolStripMenuItem,
            this.папкаTEMPFILESToolStripMenuItem,
            this.папкаSHABLONToolStripMenuItem,
            this.папкаCOMPLETEToolStripMenuItem});
            this.прямойДоступКРабочимПапкамToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.прямойДоступКРабочимПапкамToolStripMenuItem.Name = "прямойДоступКРабочимПапкамToolStripMenuItem";
            this.прямойДоступКРабочимПапкамToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.прямойДоступКРабочимПапкамToolStripMenuItem.Text = "Прямой доступ к рабочим папкам";
            // 
            // папкаWORKToolStripMenuItem
            // 
            this.папкаWORKToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаWORKToolStripMenuItem.Name = "папкаWORKToolStripMenuItem";
            this.папкаWORKToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаWORKToolStripMenuItem.Text = "Папка WORK";
            this.папкаWORKToolStripMenuItem.Click += new System.EventHandler(this.папкаWORKToolStripMenuItem_Click);
            // 
            // папкаARCHIVEToolStripMenuItem
            // 
            this.папкаARCHIVEToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаARCHIVEToolStripMenuItem.Name = "папкаARCHIVEToolStripMenuItem";
            this.папкаARCHIVEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаARCHIVEToolStripMenuItem.Text = "Папка ARCHIVE";
            this.папкаARCHIVEToolStripMenuItem.Click += new System.EventHandler(this.папкаARCHIVEToolStripMenuItem_Click);
            // 
            // папкаSTOCKToolStripMenuItem
            // 
            this.папкаSTOCKToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаSTOCKToolStripMenuItem.Name = "папкаSTOCKToolStripMenuItem";
            this.папкаSTOCKToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаSTOCKToolStripMenuItem.Text = "Папка STOCK";
            this.папкаSTOCKToolStripMenuItem.Click += new System.EventHandler(this.папкаSTOCKToolStripMenuItem_Click);
            // 
            // папкаMASTERPREPToolStripMenuItem
            // 
            this.папкаMASTERPREPToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаMASTERPREPToolStripMenuItem.Name = "папкаMASTERPREPToolStripMenuItem";
            this.папкаMASTERPREPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаMASTERPREPToolStripMenuItem.Text = "Папка MASTER_PREP";
            this.папкаMASTERPREPToolStripMenuItem.Click += new System.EventHandler(this.папкаMASTERPREPToolStripMenuItem_Click);
            // 
            // папкаToolStripMenuItem
            // 
            this.папкаToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаToolStripMenuItem.Name = "папкаToolStripMenuItem";
            this.папкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаToolStripMenuItem.Text = "Папка RAPORT";
            this.папкаToolStripMenuItem.Click += new System.EventHandler(this.папкаToolStripMenuItem_Click);
            // 
            // папкаTEMPFILESToolStripMenuItem
            // 
            this.папкаTEMPFILESToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаTEMPFILESToolStripMenuItem.Name = "папкаTEMPFILESToolStripMenuItem";
            this.папкаTEMPFILESToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаTEMPFILESToolStripMenuItem.Text = "Папка TEMP_FILES";
            this.папкаTEMPFILESToolStripMenuItem.Click += new System.EventHandler(this.папкаTEMPFILESToolStripMenuItem_Click);
            // 
            // папкаSHABLONToolStripMenuItem
            // 
            this.папкаSHABLONToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.папкаSHABLONToolStripMenuItem.Name = "папкаSHABLONToolStripMenuItem";
            this.папкаSHABLONToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаSHABLONToolStripMenuItem.Text = "Папка SHABLON";
            this.папкаSHABLONToolStripMenuItem.Click += new System.EventHandler(this.папкаSHABLONToolStripMenuItem_Click);
            // 
            // папкаCOMPLETEToolStripMenuItem
            // 
            this.папкаCOMPLETEToolStripMenuItem.Name = "папкаCOMPLETEToolStripMenuItem";
            this.папкаCOMPLETEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.папкаCOMPLETEToolStripMenuItem.Text = "Папка COMPLETE";
            this.папкаCOMPLETEToolStripMenuItem.Click += new System.EventHandler(this.папкаCOMPLETEToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsFormToolStripMenuItem,
            this.metaSettingsToolStripMenuItem1,
            this.logToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // settingsFormToolStripMenuItem
            // 
            this.settingsFormToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsFormToolStripMenuItem.Name = "settingsFormToolStripMenuItem";
            this.settingsFormToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.settingsFormToolStripMenuItem.Text = "Программные настройки";
            this.settingsFormToolStripMenuItem.Click += new System.EventHandler(this.settingsFormToolStripMenuItem_Click);
            // 
            // metaSettingsToolStripMenuItem1
            // 
            this.metaSettingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSettingsToolStripMenuItem,
            this.datesToolStripMenuItem});
            this.metaSettingsToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metaSettingsToolStripMenuItem1.Name = "metaSettingsToolStripMenuItem1";
            this.metaSettingsToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.metaSettingsToolStripMenuItem1.Text = "Настройки МетаДанных";
            // 
            // dataSettingsToolStripMenuItem
            // 
            this.dataSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSettingsToolStripMenuItem1});
            this.dataSettingsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSettingsToolStripMenuItem.Name = "dataSettingsToolStripMenuItem";
            this.dataSettingsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.dataSettingsToolStripMenuItem.Text = "Данные";
            // 
            // dataSettingsToolStripMenuItem1
            // 
            this.dataSettingsToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSettingsToolStripMenuItem1.Name = "dataSettingsToolStripMenuItem1";
            this.dataSettingsToolStripMenuItem1.Size = new System.Drawing.Size(265, 22);
            this.dataSettingsToolStripMenuItem1.Text = "Добавление/редактирование данных";
            this.dataSettingsToolStripMenuItem1.Click += new System.EventHandler(this.dataSettingsToolStripMenuItem1_Click);
            // 
            // datesToolStripMenuItem
            // 
            this.datesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datesSettingsToolStripMenuItem});
            this.datesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datesToolStripMenuItem.Name = "datesToolStripMenuItem";
            this.datesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.datesToolStripMenuItem.Text = "Даты";
            // 
            // datesSettingsToolStripMenuItem
            // 
            this.datesSettingsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datesSettingsToolStripMenuItem.Name = "datesSettingsToolStripMenuItem";
            this.datesSettingsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.datesSettingsToolStripMenuItem.Text = "Добавление/редактирование дат";
            this.datesSettingsToolStripMenuItem.Click += new System.EventHandler(this.datesSettingsToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.quitToolStripMenuItem.Text = "Выход";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // File_Work_PANEL
            // 
            this.File_Work_PANEL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.File_Work_PANEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.File_Work_PANEL.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File_Work_PANEL.Location = new System.Drawing.Point(12, 40);
            this.File_Work_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.File_Work_PANEL.Name = "File_Work_PANEL";
            this.File_Work_PANEL.Size = new System.Drawing.Size(671, 556);
            this.File_Work_PANEL.TabIndex = 2;
            // 
            // Browser_Form_PANEL
            // 
            this.Browser_Form_PANEL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Browser_Form_PANEL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Browser_Form_PANEL.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browser_Form_PANEL.Location = new System.Drawing.Point(683, 40);
            this.Browser_Form_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.Browser_Form_PANEL.Name = "Browser_Form_PANEL";
            this.Browser_Form_PANEL.Size = new System.Drawing.Size(575, 556);
            this.Browser_Form_PANEL.TabIndex = 3;
            // 
            // Admin_Button
            // 
            this.Admin_Button.BackColor = System.Drawing.SystemColors.Control;
            this.Admin_Button.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Button.Location = new System.Drawing.Point(349, 2);
            this.Admin_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Admin_Button.Name = "Admin_Button";
            this.Admin_Button.Size = new System.Drawing.Size(154, 30);
            this.Admin_Button.TabIndex = 5;
            this.Admin_Button.Text = "User Mode";
            this.Admin_Button.UseVisualStyleBackColor = false;
            this.Admin_Button.Click += new System.EventHandler(this.Admin_Button_Click);
            // 
            // setting_params
            // 
            this.setting_params.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_params.Location = new System.Drawing.Point(938, 0);
            this.setting_params.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.setting_params.Name = "setting_params";
            this.setting_params.Size = new System.Drawing.Size(721, 35);
            this.setting_params.TabIndex = 7;
            this.setting_params.UseVisualStyleBackColor = true;
            this.setting_params.Click += new System.EventHandler(this.setting_params_Click);
            // 
            // Version_But
            // 
            this.Version_But.Location = new System.Drawing.Point(507, 2);
            this.Version_But.Name = "Version_But";
            this.Version_But.Size = new System.Drawing.Size(421, 23);
            this.Version_But.TabIndex = 8;
            this.Version_But.UseVisualStyleBackColor = true;
            this.Version_But.Click += new System.EventHandler(this.Version_But_Click);
            // 
            // RTimer
            // 
            this.RTimer.Enabled = true;
            this.RTimer.Interval = 1000;
            this.RTimer.Tick += new System.EventHandler(this.RTimer_Tick);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1268, 605);
            this.Controls.Add(this.Version_But);
            this.Controls.Add(this.Browser_Form_PANEL);
            this.Controls.Add(this.setting_params);
            this.Controls.Add(this.Admin_Button);
            this.Controls.Add(this.File_Work_PANEL);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ingest Assistant";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.SizeChanged += new System.EventHandler(this.Main_Form_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem startFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileWorkFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metaSettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem datesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datesSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеРапортаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem служебныеФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрБазыToolStripMenuItem1;
        public System.Windows.Forms.Panel File_Work_PANEL;
        public System.Windows.Forms.Panel Browser_Form_PANEL;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button Admin_Button;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямойДоступКРабочимПапкамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаWORKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаARCHIVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаSTOCKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаMASTERPREPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаTEMPFILESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаSHABLONToolStripMenuItem;
        private System.Windows.Forms.Button setting_params;
        private ToolStripMenuItem папкаCOMPLETEToolStripMenuItem;
        private Button Version_But;
        private Timer RTimer;
    }
}