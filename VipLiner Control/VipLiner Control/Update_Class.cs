using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ingest_Assistant
{
    static  class Update_Class
    {
        public static string last_ver;
        public static string cur_ver;
        public static Boolean must_update;
        public static int status;

        public static  void latest_ver()
        {
            string zapros = " SELECT MAX(U_ID) AS Expr1 FROM     UpdaterTable ";
            int last_id = SQL.ReadValueInt32(zapros);

            string ver = SQL.ReadValueString("SELECT U_Ver  FROM     UpdaterTable Where U_ID="+last_id);
            last_ver = ver;
            must_update = SQL.ReadValueBoolean("SELECT U_Important  FROM     UpdaterTable Where U_ID=" + last_id);
        }
        public static void curent_ver()
        {
            string verr = "";
            
              //  Assembly assem = Assembly.GetEntryAssembly();
      //AssemblyName assemName = assem.GetName();
     // Version ver = assemName.Version;
            //ver += Convert.ToString(assemName.Name) + "   " + ver.ToString();
      verr += Assembly.GetExecutingAssembly().GetName().Version;
          //  MessageBox.Show(verr);
            cur_ver= verr;
        }

        public static int update_request()
        {
            latest_ver();
            curent_ver();
            if (last_ver == cur_ver)
            {
                status = 0;
                return 0;
            }
            else
            {
                if (must_update)
                {
                    status = 2;
                    return 2;

                }
                else
                {
                    status = 1;
                    return 1;
                }
            }
        }
    }
}
