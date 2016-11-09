using System;
using System.IO;
using Ingest_Assistant.Properties;

namespace Ingest_Assistant
{
    internal class MetaDatesClass
    {
        private Boolean bvid;
        private DateTime cdir;
        private DateTime cfcp;
        private DateTime cmov;
        private DateTime cref;
        private DateTime ctxt;
        private DateTime cxls;
        private DateTime cxml;
        private Boolean efcp;
        private Boolean emov;
        private Boolean eref;
        private Boolean etxt;
        private Boolean exls;
        private Boolean exml;
        private DateTime mfcp;
        private DateTime mmov;
        private DateTime mref;
        private DateTime mtxt;
        private DateTime mvid;
        private DateTime mxls;
        private DateTime mxml;
        private DateTime ofcp;
        private DateTime omov;
        private DateTime oref;
        private DateTime otxt;
        private DateTime oxls;
        private DateTime oxml;
        private Boolean ready;
        private readonly string dir;
        private readonly string fcp;
        private readonly string mov;
        private readonly string reff;
        private readonly string txt;
        private readonly string ViPlanner;
        private readonly string xls;
        private readonly string xml;

        public MetaDatesClass(string Viplanner, string itxt, string ixml, string ixls, string imov, string ifcp,
            string iref, string idir)
        {
            txt = itxt;
            xml = ixml;
            xls = ixls;
            fcp = ifcp;
            mov = imov;
            reff = iref;
            dir = idir;
            ViPlanner = Viplanner;
            load_dates();
            ready = true;
        }

        private void load_dates()
        {
            if (dir != "")
            {
                cdir = Directory.GetCreationTime(dir);
            }

            if (txt != "")
            {
                etxt = true;
                ctxt = File.GetCreationTime(txt);
                otxt = File.GetLastAccessTime(txt);
                mtxt = File.GetLastWriteTime(txt);
            }

            if (xml != "")
            {
                exml = true;
                cxml = File.GetCreationTime(xml);
                oxml = File.GetLastAccessTime(xml);
                mxml = File.GetLastWriteTime(xml);
            }

            if (xls != "")
            {
                exls = true;
                cxls = File.GetCreationTime(xls);
                oxls = File.GetLastAccessTime(xls);
                mxls = File.GetLastWriteTime(xls);
            }


            if (fcp != "")
            {
                efcp = true;
                cfcp = File.GetCreationTime(fcp);
                ofcp = File.GetLastAccessTime(fcp);
                mfcp = File.GetLastWriteTime(fcp);
            }


            if (mov != "")
            {
                emov = true;
                cmov = File.GetCreationTime(mov);
                omov = File.GetLastAccessTime(mov);
                mmov = File.GetLastWriteTime(mov);
            }

            if (reff != "")
            {
                eref = true;
                cref = File.GetCreationTime(reff);
                oref = File.GetLastAccessTime(reff);
                mref = File.GetLastWriteTime(reff);
            }

            var vid = "";

            var filess = Directory.GetFiles(Ingest_Assistant.Properties.Settings.Default.Work_Path + "\\" + ViPlanner);
            for (var i = 0; i < filess.Length; i++)
            {
                if (Path.GetExtension(filess[i]) == ".vid")
                {
                    bvid = true;
                    mvid = File.GetLastWriteTime(filess[i]);
                }
            }
        }

        public string calc_time_span(int a, int b, int c)
        {
            var A_Date = new DateTime(2000, 1, 1);
            var B_Date = new DateTime(2000, 1, 1);
            var eror = false;

            switch (a)
            {
                case 1: //1 -создание папки Work
                    A_Date = cdir;
                    break;
                case 2: //2 -создание файла txt
                    if (etxt)
                    {
                        A_Date = ctxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 3: //3 -последняя редакция файла txt
                    if (etxt)
                    {
                        A_Date = mtxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 4: //4 -последнее открытие файла txt
                    if (etxt)
                    {
                        A_Date = otxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 5: //5 -создание файла xml
                    if (exml)
                    {
                        A_Date = cxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 6: //6 -последняя редакция файла xml
                    if (exml)
                    {
                        A_Date = mxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 7: //7 -последнее открытие файла xml
                    if (exml)
                    {
                        A_Date = oxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 8: //8 -создание файла xls
                    if (exls)
                    {
                        A_Date = cxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 9: //9 -последняя редакция файла xls
                    if (exls)
                    {
                        A_Date = mxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 10: //10-последнее открытие файла xls
                    if (exls)
                    {
                        A_Date = oxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 11: //11-создание файла mov
                    if (emov)
                    {
                        A_Date = cmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 12: //12-последняя редакция файла mov
                    if (emov)
                    {
                        A_Date = mmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 13: //13-последнее открытие файла mov
                    if (emov)
                    {
                        A_Date = omov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 14: //14-создание файла fcp
                    if (efcp)
                    {
                        A_Date = cfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 15: //15-последняя редакция файла fcp
                    if (efcp)
                    {
                        A_Date = mfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 16: //16-последнее открытие файла fcp
                    if (efcp)
                    {
                        A_Date = ofcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 17: //17-создание файла ref
                    if (eref)
                    {
                        A_Date = cref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 18: //18-последняя редакция файла ref
                    if (eref)
                    {
                        A_Date = mref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 19: //19-последнее открытие файла ref  
                    if (eref)
                    {
                        A_Date = oref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 20: //19-последнее открытие файла ref  
                {
                    A_Date = DateTime.Now;
                }

                    break;

                case 21: //19-последнее открытие файла ref  
                    if (bvid)
                    {
                        A_Date = mvid;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
            }


            if (A_Date == new DateTime(2000, 1, 1)) eror = true;

            switch (b)
            {
                case 1: //1 -создание папки Work
                    B_Date = cdir;
                    break;
                case 2: //2 -создание файла txt
                    if (etxt)
                    {
                        B_Date = ctxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 3: //3 -последняя редакция файла txt
                    if (etxt)
                    {
                        B_Date = mtxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 4: //4 -последнее открытие файла txt
                    if (etxt)
                    {
                        B_Date = otxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 5: //5 -создание файла xml
                    if (exml)
                    {
                        B_Date = cxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 6: //6 -последняя редакция файла xml
                    if (exml)
                    {
                        B_Date = mxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 7: //7 -последнее открытие файла xml
                    if (exml)
                    {
                        B_Date = oxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 8: //8 -создание файла xls
                    if (exls)
                    {
                        B_Date = cxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 9: //9 -последняя редакция файла xls
                    if (exls)
                    {
                        B_Date = mxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 10: //10-последнее открытие файла xls
                    if (exls)
                    {
                        B_Date = oxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 11: //11-создание файла mov
                    if (emov)
                    {
                        B_Date = cmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 12: //12-последняя редакция файла mov
                    if (emov)
                    {
                        B_Date = mmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 13: //13-последнее открытие файла mov
                    if (emov)
                    {
                        B_Date = omov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 14: //14-создание файла fcp
                    if (efcp)
                    {
                        B_Date = cfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 15: //15-последняя редакция файла fcp
                    if (efcp)
                    {
                        B_Date = mfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 16: //16-последнее открытие файла fcp
                    if (efcp)
                    {
                        B_Date = ofcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 17: //17-создание файла ref
                    if (eref)
                    {
                        B_Date = cref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 18: //18-последняя редакция файла ref
                    if (eref)
                    {
                        B_Date = mref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 19: //19-последнее открытие файла ref  
                    if (eref)
                    {
                        B_Date = oref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 20: //19-последнее открытие файла ref  
                {
                    B_Date = DateTime.Now;
                }

                    break;
                case 21: //19-последнее открытие файла ref  
                    if (bvid)
                    {
                        B_Date = mvid;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
            }


            if (B_Date == new DateTime(2000, 1, 1)) eror = true;


            if (eror)
            {
                return "";
            }
            var result = A_Date - B_Date + new TimeSpan(0, c, 0);
            return result.ToString("c").Substring(0, result.ToString("c").Substring(5).IndexOf('.') + 5);
          
        }

        public string calc_date(int a, int c)
        {
            var A_Date = new DateTime(2000, 1, 1);
            var eror = false;

            switch (a)
            {
                case 1: //1 -создание папки Work
                    A_Date = cdir;
                    break;
                case 2: //2 -создание файла txt
                    if (etxt)
                    {
                        A_Date = ctxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 3: //3 -последняя редакция файла txt
                    if (etxt)
                    {
                        A_Date = mtxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 4: //4 -последнее открытие файла txt
                    if (etxt)
                    {
                        A_Date = otxt;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;

                case 5: //5 -создание файла xml
                    if (exml)
                    {
                        A_Date = cxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 6: //6 -последняя редакция файла xml
                    if (exml)
                    {
                        A_Date = mxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 7: //7 -последнее открытие файла xml
                    if (exml)
                    {
                        A_Date = oxml;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 8: //8 -создание файла xls
                    if (exls)
                    {
                        A_Date = cxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 9: //9 -последняя редакция файла xls
                    if (exls)
                    {
                        A_Date = mxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 10: //10-последнее открытие файла xls
                    if (exls)
                    {
                        A_Date = oxls;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 11: //11-создание файла mov
                    if (emov)
                    {
                        A_Date = cmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 12: //12-последняя редакция файла mov
                    if (emov)
                    {
                        A_Date = mmov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 13: //13-последнее открытие файла mov
                    if (emov)
                    {
                        A_Date = omov;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 14: //14-создание файла fcp
                    if (efcp)
                    {
                        A_Date = cfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 15: //15-последняя редакция файла fcp
                    if (efcp)
                    {
                        A_Date = mfcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 16: //16-последнее открытие файла fcp
                    if (efcp)
                    {
                        A_Date = ofcp;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 17: //17-создание файла ref
                    if (eref)
                    {
                        A_Date = cref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 18: //18-последняя редакция файла ref
                    if (eref)
                    {
                        A_Date = mref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 19: //19-последнее открытие файла ref  
                    if (eref)
                    {
                        A_Date = oref;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
                case 20: //19-последнее открытие файла ref  
                {
                    A_Date = DateTime.Now;
                }

                    break;
                case 21: //19-последнее открытие файла ref  
                    if (bvid)
                    {
                        A_Date = mvid;
                    }
                    else
                    {
                        eror = true;
                    }
                    break;
            }


            if (A_Date == new DateTime(2000, 1, 1)) eror = true;

            if (eror)
            {
                return "";
            }
            var result = A_Date + new TimeSpan(0, c, 0);
            return result.ToString("yyyy.MM.dd HH:mm:ss");
        }
    }
}