using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ingest_Assistant.Properties;
using MySql.Data.MySqlClient;

namespace Ingest_Assistant
{
    public partial class conversion_form : Form
    {
        public conversion_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zap = "select MAX(ID) from MetaDataArchive";
string read_str="select "+
            "Data_Start," +
            "Ingest_Start," +
            "Ingest_End," +
            "Ingest_Duration," +
            "Time_Of_Registration," +
            "Total_Time," +
            "Title," +
            "Source_Duration," +
            "Media_Type," +
            "Reel_ID," +
            "Efir_Date_From_Request," +
            "Ingest_Line," +
            "Ingest_Operator," +
            "Format_IN," +
            "Harris_IN," +
            "Audio," +
            "Dolby," +
            "Edit_Line," +
            "Operator," +
            "Type_Of_Work," +
            "Harris_OUT," +
            "Format_OUT," +
            "Card_Marks," +
            "Info_Lost," +
            "Notes," +
            "Deleted," +
            "ViPlanner," +
            "Media_Info   " 
             + "from MetaDataArchive   order by ID";

            string old_server = textBox1.Text;//"Server = A9110101802\\MSQL2008AC;Database=IngestAssistantMainBase; User Id = sa; Password = Qaz123456;";
SqlConnection mscon=new SqlConnection(old_server);
            mscon.Open();
SqlCommand mscomand = new SqlCommand(zap, mscon);
            object ii = mscomand.ExecuteScalar();
            MessageBox.Show(ii.ToString());
            mscomand = new SqlCommand(read_str, mscon);
            SqlDataReader md = mscomand.ExecuteReader();



            while (md.Read())
            {






                string zapros = "INSERT INTO metadataarchive (" +
                                "Data_Start," +
                                "Ingest_Start," +
                                "Ingest_End," +
                                "Ingest_Duration," +
                                "Time_Of_Registration," +
                                "Total_Time," +
                                "Title," +
                                "Source_Duration," +
                                "Media_Type," +
                                "Reel_ID," +
                                "Efir_Date_From_Request," +
                                "Ingest_Line," +
                                "Ingest_Operator," +
                                "Format_IN," +
                                "Harris_IN," +
                                "Audio," +
                                "Dolby," +
                                "Edit_Line," +
                                "Operator," +
                                "Type_Of_Work," +
                                "Harris_OUT," +
                                "Format_OUT," +
                                "Card_Marks," +
                                "Info_Lost," +
                                "Notes," +
                                "Deleted," +
                                "ViPlanner," +
                                "Media_Info," +
                                "PrID," +
                                "Work_Status,UserID)" +
                                "VALUES (";
                int i = md.FieldCount;
                for (int j = 0; j < i; j++)
                {
                    zapros += " " + r(md, j) + ", ";
                }
                zapros += "1,2,0";
                zapros += ")";
                MySqlConnection mycon=new MySqlConnection(Settings.Default.MetaBase_Way);
                mycon.Open();
                MySqlCommand mycomand=new MySqlCommand(zapros,mycon);
                mycomand.ExecuteNonQuery();
                mycon.Close();
            }

        }

        public string r(SqlDataReader reader, int id)
        {
            if (!reader.IsDBNull(id))
            {
                string type = reader.GetDataTypeName(id);
                if (reader.GetDataTypeName(id) == "datetime")
                {
                    return "'" + reader.GetDateTime(id).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
                else
                {
                    if (reader.GetDataTypeName(id) == "nvarchar")
                    {
                        return "'" + reader.GetValue(id).ToString().Replace("'","\"") + "'";
                        //
                    }
                    else
                    {
                        if (reader.GetDataTypeName(id) == "bit")
                        {
                            return "" + reader.GetValue(id).ToString().Replace("True","1").Replace("False","0") + "";
                            //
                        }
                        else
                        {
                            return "" + reader.GetInt64(id) + "";
                        }
                    }
                }
            }
            else return "NULL";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void conversion_form_Load(object sender, EventArgs e)
        {

        }
    }
}
