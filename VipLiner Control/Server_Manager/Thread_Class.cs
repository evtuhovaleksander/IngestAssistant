using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaInfoNET;

namespace Server_Manager
{
    public class Media_Info_Low_Thread_Class
    {
        
        private string file_path;
        public string info;
        public bool finished;
        private int counter;
        public bool sucsess;
        
        public string message;




        public  Media_Info_Low_Thread_Class(string fp)
        {
            
            file_path = fp;
            counter = 10;
            finished = false;
        }

        public void Start_Asinc_Work()
        {

            while(counter>0&&!sucsess)
            try
            {
                info = Media_Info.get_all_info(file_path);//get_info_complex(file_path);
                string zapros="select Count(*) from media_info where Path='"+file_path.Replace("\\","\\\\")+"'";
                if (SQL_Class.ReadValueInt32(zapros,Properties.Settings.Default.Base) != 0)
                {
                    zapros = "update media_info set  MediaInfo='" + info + "', Datee=NOW()   where Path='" + file_path + "'";
                }
                else
                {
                    zapros = "insert into media_info ( MediaInfo,Path,Datee) values('" + info + "','" + file_path.Replace("\\", "\\\\") + "',NOW())";
                }
                info = zapros;
                SQL_Class.Execute(zapros,Properties.Settings.Default.Base);
                sucsess = true;
                message = file_path + "  OK!!!--" + counter;
            }
            catch (Exception ex)
            {
                sucsess = false;
                message = file_path + "   " + ex.ToString();
                counter--;
            }

            finished = true;
        }

        public string calc_info()
        {
            MediaFile fl=new MediaFile(file_path);
            return fl.MediaInfo_Text;
        }

    }

 
}
