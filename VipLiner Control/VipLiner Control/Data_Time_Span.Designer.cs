namespace Ingest_Assistant
{
    partial class Data_Time_Span
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
            this.dt_picker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.time_only_but = new System.Windows.Forms.Button();
            this.Time_Tbox = new System.Windows.Forms.TextBox();
            this.end = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_picker
            // 
            this.dt_picker.Location = new System.Drawing.Point(6, 31);
            this.dt_picker.Name = "dt_picker";
            this.dt_picker.Size = new System.Drawing.Size(200, 22);
            this.dt_picker.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.time_only_but);
            this.groupBox2.Controls.Add(this.Time_Tbox);
            this.groupBox2.Controls.Add(this.end);
            this.groupBox2.Controls.Add(this.dt_picker);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 96);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата";
            // 
            // time_only_but
            // 
            this.time_only_but.Location = new System.Drawing.Point(212, 56);
            this.time_only_but.Name = "time_only_but";
            this.time_only_but.Size = new System.Drawing.Size(319, 25);
            this.time_only_but.TabIndex = 8;
            this.time_only_but.Text = "Внести время";
            this.time_only_but.UseVisualStyleBackColor = true;
            this.time_only_but.Click += new System.EventHandler(this.time_only_but_Click);
            // 
            // Time_Tbox
            // 
            this.Time_Tbox.Location = new System.Drawing.Point(6, 59);
            this.Time_Tbox.Name = "Time_Tbox";
            this.Time_Tbox.Size = new System.Drawing.Size(200, 22);
            this.Time_Tbox.TabIndex = 7;
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(212, 28);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(319, 25);
            this.end.TabIndex = 6;
            this.end.Text = "Внести дату и время";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // Data_Time_Span
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 121);
            this.Controls.Add(this.groupBox2);
            this.Name = "Data_Time_Span";
            this.Text = "Data_Time_Span";
            this.Load += new System.EventHandler(this.Data_Time_Span_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_picker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.TextBox Time_Tbox;
        private System.Windows.Forms.Button time_only_but;
    }
}