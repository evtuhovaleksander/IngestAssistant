using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace Ingest_Assistant
{
    public partial class Base_Show_Pro : Form
    {

        public static void Correct_One_Element(string id)
        {
            Base_Show_Pro frm = new Base_Show_Pro();
            frm.Search_TBox.Text = id;
            frm.Base_Load_Click(null,null);
            frm.ShowDialog();
        }

        public Base_Show_Pro()
        {
            InitializeComponent();
        }

        private void Base_Load_Click(object sender, EventArgs e)
        {
           
         //   var th = ProgressForm.Prepare_Thread("Считываем данные");
            Primary_Load_Info();
         
            DGV_Fill();
       //     th.Abort();
        //    th = null;
        }

        public void DGV_Fill()
        {
         dgvo.RowCount = Curent_Elements.Length;
            for (var i = 0; i < Curent_Elements.Length; i++)
            {
                var bt = Curent_Elements[i];
                dgvo.Rows[i].Cells[0].Value = bt.ID;
                dgvo.Rows[i].Cells[1].Value = bt.ViPlanner;
                dgvo.Rows[i].Cells[2].Value = bt.Title;//
                dgvo.Rows[i].Cells[3].Value = bt.Data_Start;//
                dgvo.Rows[i].Cells[4].Value = bt.Ingest_Start;//
                dgvo.Rows[i].Cells[5].Value = bt.Ingest_End;//
                dgvo.Rows[i].Cells[6].Value = bt.Ingest_Duration;//
                dgvo.Rows[i].Cells[7].Value = bt.Render_Time;
                dgvo.Rows[i].Cells[8].Value = bt.Time_Of_Registration;
                dgvo.Rows[i].Cells[9].Value = bt.Total_Time;
                dgvo.Rows[i].Cells[10].Value = bt.Source_Duration;
                dgvo.Rows[i].Cells[11].Value = bt.Media_Type;
                dgvo.Rows[i].Cells[12].Value = bt.Reel_ID;
                dgvo.Rows[i].Cells[13].Value = bt.Efir_Date_From_Request;
                dgvo.Rows[i].Cells[14].Value = bt.Ingest_Line;
                dgvo.Rows[i].Cells[15].Value = bt.Ingest_Operator;
                dgvo.Rows[i].Cells[16].Value = bt.Format_IN;
                dgvo.Rows[i].Cells[17].Value = bt.Harris_IN;
                dgvo.Rows[i].Cells[18].Value = bt.Audio;
                dgvo.Rows[i].Cells[19].Value = bt.Dolby;
                dgvo.Rows[i].Cells[20].Value = bt.Edit_Line;
                dgvo.Rows[i].Cells[21].Value = bt.Operator;
                dgvo.Rows[i].Cells[22].Value = bt.Type_Of_Work;
                dgvo.Rows[i].Cells[23].Value = bt.Harris_OUT;
                dgvo.Rows[i].Cells[24].Value = bt.Format_OUT;
                dgvo.Rows[i].Cells[25].Value = bt.Card_Marks;
                dgvo.Rows[i].Cells[26].Value = bt.Info_Lost;
                dgvo.Rows[i].Cells[27].Value = bt.Notes;
                dgvo.Rows[i].Cells[28].Value = bt.Deleted;
            

           
        }
            Refresh();
        }

        private void Base_ReWrite_Click(object sender, EventArgs e)
        {
          //  Thread th = ProgressForm.Prepare_Thread("Обновляем значения базы");
         //   th.Start();
            var count = dgvo.RowCount;
            //  '"+ dgv.Rows[i].Cells[1].Value.ToString()+"'
            for (var i = 0; i < count; i++)
            {
               
                var zapros = "UPDATE MetaDataArchive     " +
                             "SET          ViPlanner ='" + dgvo.Rows[i].Cells[1].Value + "', Title ='" +
                             dgvo.Rows[i].Cells[2].Value + "', Data_Start =" + SQL_Class.wr_data(dgvo.Rows[i].Cells[3].Value) + "," +
                             "Ingest_Start =" + SQL_Class.wr_data(dgvo.Rows[i].Cells[4].Value) + ", Ingest_End =" +
                             SQL_Class.wr_data(dgvo.Rows[i].Cells[5].Value) + ", Ingest_Duration ='" + dgvo.Rows[i].Cells[6].Value + "', " +
                             "Render_Time ='" + dgvo.Rows[i].Cells[7].Value + "', Time_Of_Registration =" +
                             SQL_Class.wr_data(dgvo.Rows[i].Cells[8].Value) + ", Total_Time ='" + dgvo.Rows[i].Cells[9].Value + "', " +
                             "Source_Duration ='" + dgvo.Rows[i].Cells[10].Value + "', Media_Type ='" +
                             dgvo.Rows[i].Cells[11].Value + "', " +
                             "Reel_ID ='" + dgvo.Rows[i].Cells[12].Value + "', Efir_Date_From_Request ='" +
                             dgvo.Rows[i].Cells[13].Value + "'," +
                             "Ingest_Line ='" + dgvo.Rows[i].Cells[14].Value + "', Ingest_Operator ='" +
                             dgvo.Rows[i].Cells[15].Value + "', Format_IN ='" + dgvo.Rows[i].Cells[16].Value + "'," +
                             "Harris_IN ='" + dgvo.Rows[i].Cells[17].Value + "', Audio ='" + dgvo.Rows[i].Cells[18].Value +
                             "', Dolby ='" + dgvo.Rows[i].Cells[19].Value + "', Edit_Line ='" +
                             dgvo.Rows[i].Cells[20].Value + "'," +
                             "Operator ='" + dgvo.Rows[i].Cells[21].Value + "', Type_Of_Work ='" +
                             dgvo.Rows[i].Cells[22].Value + "', Harris_OUT ='" + dgvo.Rows[i].Cells[23].Value + "'," +
                             "Format_OUT ='" + dgvo.Rows[i].Cells[24].Value + "', Card_Marks ='" +
                             dgvo.Rows[i].Cells[25].Value + "', Info_Lost ='" + dgvo.Rows[i].Cells[26].Value +
                             "', Notes ='" + dgvo.Rows[i].Cells[27].Value + "'  " +
                             "      WHERE  (MetaDataArchive.ID = " + dgvo.Rows[i].Cells[0].Value +
                             ")";
                SQL_Class.Execute(zapros,Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            }
            MessageBox.Show("Операция выполнена");
            //   th.Abort();
        }


         public Base_Show.Big_Element[] Base_Big_Data;
        public Base_Show.Big_Element[] Curent_Elements;

        private void Base_Show_Pro_Load(object sender, EventArgs e)
        {
        }

        public void Primary_Load_Info()

        {
         //   var count = SQL_Class.ReadValueInt32("Select Count(*) From MetaDataArchive",Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);

            string str_for_split = Search_TBox.Text;
            string[] splited_mas_str = str_for_split.Split('|');
            Queue<int> ID_Mas=new Queue<int>();
            foreach (string VARIABLE in splited_mas_str)
            {
                try
                {
                    if (VARIABLE != "") ID_Mas.Enqueue(Convert.ToInt32(VARIABLE));
                }
                catch (Exception)
                {
                    
                   
                }
               
            }
            var Base_Big_Data = new Base_Show.Big_Element[ID_Mas.Count];
            var sqlcon = SQL_Class.Create_class(Ingest_Assistant.Properties.Settings.Default.MetaBase_Way);
            int i = 0;
            foreach (int ID in ID_Mas)
            {
                
            
                    SQL_Class.ReadValues(
                        "SELECT ID, ViPlanner, Title, Data_Start, Ingest_Start, Ingest_End, Ingest_Duration, Render_Time, Time_Of_Registration, Total_Time, Source_Duration, Media_Type, Reel_ID, Efir_Date_From_Request, Ingest_Line, Ingest_Operator, Format_IN, Harris_IN, Audio, Dolby, Edit_Line, Operator, Type_Of_Work, Harris_OUT, Format_OUT, Card_Marks, Info_Lost, Notes, Deleted FROM     MetaDataArchive    Where ID=" +
                        ID,ref sqlcon);
                sqlcon.SQL_DataReader.Read();
                var bt = new Base_Show.Big_Element();


                bt.ID = ID;
                bt.ViPlanner = r(sqlcon.SQL_DataReader,1);
                bt.Title = r(sqlcon.SQL_DataReader,2);
                bt.Data_Start = SQL_Class.get_Data_asString(sqlcon, 3);// sqlcon.SQL_DataReader.GetDateTime(3).ToString("g");
                bt.Ingest_Start = SQL_Class.get_Data_asString(sqlcon, 4);
                bt.Ingest_End = SQL_Class.get_Data_asString(sqlcon, 5);
                bt.Ingest_Duration = r(sqlcon.SQL_DataReader,6);
                bt.Render_Time = r(sqlcon.SQL_DataReader,7);
                bt.Time_Of_Registration = SQL_Class.get_Data_asString(sqlcon, 8);
                bt.Total_Time = r(sqlcon.SQL_DataReader,9);
                bt.Source_Duration = r(sqlcon.SQL_DataReader,10);
                bt.Media_Type = r(sqlcon.SQL_DataReader,11);
                bt.Reel_ID = r(sqlcon.SQL_DataReader,12);
                bt.Efir_Date_From_Request = r(sqlcon.SQL_DataReader,13);
                bt.Ingest_Line = r(sqlcon.SQL_DataReader,14);
                bt.Ingest_Operator = r(sqlcon.SQL_DataReader,15);
                bt.Format_IN = r(sqlcon.SQL_DataReader,16);
                bt.Harris_IN = r(sqlcon.SQL_DataReader,17);
                bt.Audio = r(sqlcon.SQL_DataReader,18);
                bt.Dolby = r(sqlcon.SQL_DataReader,19);
                bt.Edit_Line = r(sqlcon.SQL_DataReader,20);
                bt.Operator = r(sqlcon.SQL_DataReader,21);
                bt.Type_Of_Work = r(sqlcon.SQL_DataReader,22);
                bt.Harris_OUT = r(sqlcon.SQL_DataReader,23);
                bt.Format_OUT = r(sqlcon.SQL_DataReader,24);
                bt.Card_Marks = r(sqlcon.SQL_DataReader,25);
                bt.Info_Lost = r(sqlcon.SQL_DataReader,26);
                bt.Notes = r(sqlcon.SQL_DataReader,27);
                bt.Deleted = sqlcon.SQL_DataReader.GetBoolean(28).ToString();


                Base_Big_Data[i] = bt;
                i++;
            }
             sqlcon.Manualy_Close_Connection();
            Curent_Elements = Base_Big_Data;
        }
        public string r(MySql.Data.MySqlClient.MySqlDataReader rd, int id) {
            if (rd.IsDBNull(id)) return " ";
            return rd.GetString(id);
        }
    }
}