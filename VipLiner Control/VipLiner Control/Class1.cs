using System;
using System.Diagnostics;

namespace Ingest_Assistant
{
    internal class Class1
    {
        public void Update_IA()
        {
            var zapros = " SELECT MAX(U_ID) AS Expr1 FROM     UpdaterTable ";
            var last_id = SQL.ReadValueInt32(zapros);
            zapros = "SELECT U_ID, U_Path FROM     UpdaterTable";
        }

        public void kill_IA_process()
        {
            Array ar = Process.GetProcessesByName("Ingest Assistant");
            if (ar.Length != 0)
            {
                foreach (Process proc in ar)
                {
                    proc.Kill();
                }
            }
        }
    }
}