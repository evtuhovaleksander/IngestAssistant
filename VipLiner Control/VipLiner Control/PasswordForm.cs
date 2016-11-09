using System;
using System.Diagnostics;
using System.Windows.Forms;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    public partial class PasswordForm : Form
    {
        public Boolean ask;
        public Boolean user_ID;
        public bool admin;
        public int Registrator;
        public PasswordForm()
        {
            
            InitializeComponent();
            ask = false;
            admin = false;
            Registrator = 0;


            SQL_Class cl = SQL_Class.Create_class(Settings.Default.Setting_Base_Path);
            SQL_Class.ReadValues("select L_Login from login where L_Priority>1", ref cl);
            var src = new AutoCompleteStringCollection();
            //src.AddRange(files);
            while (cl.SQL_DataReader.Read())
            {
                src.Add(cl.SQL_DataReader.GetString(0));
            }
            login.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
          
            login.AutoCompleteCustomSource = src;


        }

       
     


      


        public static Boolean getAdminRights()
        {
            var frm = new PasswordForm();
            frm.ask = false;
            frm.ShowDialog();
            Application.DoEvents();
            return frm.admin;
        }

        public static Boolean getPermition(ref int reg)
        {
            var frm = new PasswordForm();
            frm.ask = false;
            frm.ShowDialog();
            Application.DoEvents();
            reg = frm.Registrator;
            return frm.ask;
        }


        private void login_but_Click(object sender, EventArgs e)
        {
            
                log_operation();
            }
        

        private void PasswordForm_Load(object sender, EventArgs e)
        {
           
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.ToString() == "\r")
            {
                password.Focus();
            }
        }



        public void log_operation()
        {
            if (login.Text != "" && password.Text != "")
            {
                var zap = "SELECT Count(*) FROM     Login Where (L_Login = N'" + login.Text + "') AND (L_Password = N'" +
                          password.Text + "')";
                var count = SQL_Class.ReadValueInt32(zap, Ingest_Assistant.Properties.Settings.Default.Setting_Base_Path);
                                   

                if (count > 0)
                {
                    if (SQL_Class.ReadValueInt32(
                        "SELECT L_Priority FROM     Login Where (L_Login = N'" + login.Text + "') AND (L_Password = N'" +
                        password.Text + "')", Properties.Settings.Default.Setting_Base_Path) == 3) admin = true;
                    else admin = false;

                    if (SQL_Class.ReadValueInt32(
                        "SELECT L_Priority FROM     Login Where (L_Login = N'" + login.Text + "') AND (L_Password = N'" +
                        password.Text + "')", Properties.Settings.Default.Setting_Base_Path) >= 2)
                    {
                        ask = true;
                        Registrator=SQL_Class.ReadValueInt32(
                        "SELECT L_ID FROM     Login Where (L_Login = N'" + login.Text + "') AND (L_Password = N'" +
                        password.Text + "')", Properties.Settings.Default.Setting_Base_Path);
                    }
                    else ask = false;

                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }

            }
            else
            {
                MessageBox.Show("Неполные данные");
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar.ToString() == "\r")
            {
               log_operation();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Request_But_Click(object sender, EventArgs e)
        {
            log_operation();
        }
    }
}