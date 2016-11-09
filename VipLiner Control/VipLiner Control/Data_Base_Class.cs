using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.IO;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    class Data_Base_Class
    {
        private string Base_Path;
        private string Temp_Dir;


        private Boolean Copy_File(string from, string to)
        {
            try
            {
                File.Copy(from, to);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

       




        public object readvalue(string zapros)
        {
            int count = 0;
            object result = null;

            for (int i = 0; i < Settings.Default.Tries; i++)
            {
                if(Copy_File(Base_Path,Temp_Dir)) break;
            }

            if (!File.Exists(Temp_Dir)) return null;


            for (int i = 0; i < Settings.Default.Tries; i++)
            {
                if (Copy_File(Base_Path, Temp_Dir)) break;
            }
            return null;
        }
    }
}
