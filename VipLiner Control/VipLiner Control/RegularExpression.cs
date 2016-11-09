using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ingest_Assistant
{
    class RegularExpression
    {
        public static Boolean is_DataTime(string str)
        {
            Regex newReg = new Regex(@"[0-3][0-9][.][0-1][0-9].[2][0][1][5-6][ ][0-2][0-9][:][0-6][0-9][:][0-6][0-9]");
            if (newReg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean is_Time_Span(string str)
        {
            TimeSpan sp=new TimeSpan();
            Regex newReg = new Regex(@"[0-2][0-9][:][0-6][0-9][:][0-6][0-9]");
            if (newReg.IsMatch(str) && str.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static Boolean is_Duration(string str)
        {
            TimeSpan sp = new TimeSpan();
            Regex newReg = new Regex(@"[0-6][0-9][:][0-6][0-9][:][0-6][0-9][:][0-2][0-9]");
            if (newReg.IsMatch(str) && str.Length == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean is_ReelID(string str)
        {
            TimeSpan sp = new TimeSpan();
            Regex newReg = new Regex(@"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9][0-9]");
            if (str.Length>=4)
            {
                if (".mov.avi.mxf".Contains(str.Substring(str.Length - 4))) return true;
            }
            if ((newReg.IsMatch(str)&&str.Length==10))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
