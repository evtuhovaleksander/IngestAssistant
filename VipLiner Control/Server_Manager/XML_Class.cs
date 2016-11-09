﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Win32;

namespace Server_Manager
{


    static class XML_Class
    {
        public static string get_one_param(string par_name, string path)
        {
            //string outt;
            //string fixedpath =
            //    "C:\\Users\\Aevtuhov\\Desktop\\qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq.xml";
            //path = fixedpath;




            if (par_name == "ID_ViPlanner")
            {
                par_name = "ID ViPlanner";
            }








            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement metadata = null;
            XmlElement FinalCutServer = xDoc.DocumentElement;

            foreach (XmlElement tek1 in FinalCutServer)
            {
                if (tek1.Name == "getMdReply")
                {
                    XmlElement getMdReply = tek1;

                    foreach (XmlElement tek2 in getMdReply)
                    {
                        if (tek2.Name == "entity")
                        {
                            XmlElement entity = tek2;

                            foreach (XmlElement tek3 in entity)
                            {
                                if (tek3.Name == "metadata")
                                {
                                    metadata = tek3;
                                }
                            }

                        }
                    }

                }
            }


            if (metadata != null)
            {
                foreach (XmlElement temp in metadata)
                {
                    if (temp.Attributes.Count > 0)
                    {
                        XmlNode fieldName = temp.Attributes.GetNamedItem("fieldName");
                        if (fieldName != null)
                        {
                            
                            if (fieldName.Value.ToString() == par_name)
                            {
                                return temp.InnerText;
                            }
                        }
                    }
                }

                
            }
            return "nothing found";
        }



        public static void set_one_param(string par_name, string path, string definition)
        {



            if (par_name == "ID_ViPlanner")
            {
                par_name = "ID ViPlanner";
            }

            //string fixedpath =
            //    "C:\\Users\\Aevtuhov\\Desktop\\qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq.xml";
            //path = fixedpath;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement metadata = null;
            XmlElement FinalCutServer = xDoc.DocumentElement;

            foreach (XmlElement tek1 in FinalCutServer)
            {
                if (tek1.Name == "getMdReply")
                {
                    XmlElement getMdReply = tek1;

                    foreach (XmlElement tek2 in getMdReply)
                    {
                        if (tek2.Name == "entity")
                        {
                            XmlElement entity = tek2;

                            foreach (XmlElement tek3 in entity)
                            {
                                if (tek3.Name == "metadata")
                                {
                                    metadata = tek3;
                                }
                            }

                        }
                    }

                }
            }


       ///     XmlElement elementToSet = null;

            if (metadata != null)
            {
                foreach (XmlNode temp in metadata)
                {
                    if (temp.Attributes.Count > 0)
                    {
                        XmlNode fieldName = temp.Attributes.GetNamedItem("fieldName");
                        if (fieldName != null)
                        {
                            if (fieldName.Value.ToString() == par_name)
                            {




                                XmlNode nd = temp;
                                if (nd.HasChildNodes)
                                {
                                    XmlText txt = (XmlText)nd.ChildNodes[0];
                                    txt.Value = definition;
                                    xDoc.Save(path);
                                    return;
                                }
                                else
                                {
                                    metadata.RemoveChild(temp);
                                }
                                
                            }
                        }
                    }
                }






                XmlNode mdval = xDoc.CreateElement("mdValue");
                XmlAttribute datatype = xDoc.CreateAttribute("dataType");
                XmlText datatypeText;
                if (par_name != "Дата эфира")
                {
                    datatypeText = xDoc.CreateTextNode("string");
                }
                else
                {
                    datatypeText = xDoc.CreateTextNode("dateTime");
                }

                datatype.AppendChild(datatypeText);

                XmlAttribute fieldNameel = xDoc.CreateAttribute("fieldName");
                XmlText fieldNameText = xDoc.CreateTextNode(par_name);
                fieldNameel.AppendChild(fieldNameText);

                XmlText newdef = xDoc.CreateTextNode(definition);

                mdval.Attributes.Append(datatype);
                mdval.Attributes.Append(fieldNameel);
                mdval.AppendChild(newdef);


                metadata.AppendChild(mdval);

                xDoc.Save(path);








            }
    
            

           



           



         

           

        }

    }








    //static class XML_Class2
    //{
    //    public static string get_one_param(string par_name, string path)
    //    {

    //        XmlDocument xDoc = new XmlDocument();
    //        xDoc.Load(path);
    //        XmlElement xRoot = xDoc.DocumentElement;

    //        foreach (XmlNode VARIABLE in xRoot)
    //        {
    //            if (VARIABLE.Attributes.Count > 0)
    //            {
    //                XmlNode name = VARIABLE.Attributes.GetNamedItem("name");
    //                if (name != null)
    //                {
    //                    if (name.InnerText == par_name)
    //                    {
    //                        foreach (XmlNode childnode in VARIABLE.ChildNodes)
    //                        {
    //                            if (childnode.Name == "definition")
    //                            {
    //                                if (childnode != null)
    //                                {
    //                                    return childnode.InnerText;
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        return "nothing found";
    //    }

    //    public static void set_one_param(string par_name, string path, string definition)
    //    {

    //        XmlDocument xDoc = new XmlDocument();
    //        xDoc.Load(path);
    //        XmlElement xRoot = xDoc.DocumentElement;
    //        XmlNode delnode = null;
    //        string namerus = "";
    //        foreach (XmlNode VARIABLE in xRoot)
    //        {
    //            if (VARIABLE.Attributes.Count > 0)
    //            {
    //                XmlNode name = VARIABLE.Attributes.GetNamedItem("name");
    //                if (name != null)
    //                {
    //                    if (name.InnerText == par_name)
    //                    {
    //                        delnode = VARIABLE;
    //                        foreach (XmlNode childnode in VARIABLE.ChildNodes)
    //                        {
    //                            if (childnode.Name == "namerus")
    //                            {
    //                                if (childnode != null)
    //                                {
    //                                    namerus = childnode.InnerText;
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        xRoot.RemoveChild(delnode);

    //        XmlElement paramElem = xDoc.CreateElement("parameter");
    //        XmlAttribute nameAttr = xDoc.CreateAttribute("name");
    //        XmlElement namerusElem = xDoc.CreateElement("namerus");
    //        XmlElement definitionElem = xDoc.CreateElement("definition");
    //        XmlText nameText = xDoc.CreateTextNode(par_name);
    //        XmlText namerusText = xDoc.CreateTextNode(namerus);
    //        XmlText definitionText = xDoc.CreateTextNode(definition);

    //        nameAttr.AppendChild(nameText);
    //        namerusElem.AppendChild(namerusText);
    //        definitionElem.AppendChild(definitionText);
    //        paramElem.Attributes.Append(nameAttr);
    //        paramElem.AppendChild(namerusElem);
    //        paramElem.AppendChild(definitionElem);
    //        xRoot.AppendChild(paramElem);

    //        xDoc.Save(path);

    //    }

    //    public static string[] get_name_mas(string path)
    //    {
    //        string[] mas = new string[0];
    //        XmlDocument xDoc = new XmlDocument();
    //        xDoc.Load(path);
    //        XmlElement xRoot = xDoc.DocumentElement;

    //        foreach (XmlNode VARIABLE in xRoot)
    //        {
    //            if (VARIABLE.Attributes.Count > 0)
    //            {
    //                XmlNode name = VARIABLE.Attributes.GetNamedItem("name");
    //                if (name != null)
    //                {
    //                    Array.Resize(ref mas, mas.Length + 1);
    //                    mas[mas.Length - 1] = name.InnerText;
    //                }
    //            }
    //        }
    //        return mas;
    //    }
    //}
}