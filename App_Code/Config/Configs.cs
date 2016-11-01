﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;
using System.Web.Hosting;

/// <summary>
///Configs 的摘要说明
/// </summary>
public class Configs
{
    public static string GetConfig(string xmlNodeName)
    {
        //string basePath = HttpContext.Current.Request.PhysicalApplicationPath;     

        string virtualPath = HttpContext.Current.Request.ApplicationPath;
        string basePath = HostingEnvironment.MapPath(virtualPath);

   
        string xmlPath = basePath + "config\\config.xml";
        if (File.Exists(xmlPath))
        {
            XmlReader reader = null;
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);
                XmlElement root = doc.DocumentElement;

                XmlNodeList NodeList = root.GetElementsByTagName(xmlNodeName);
                if (NodeList.Count > 0)
                {
                    XmlNode node = NodeList[0];
                    return node.InnerText;
                }
                else
                {
                    return string.Empty;
                }                
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        else
        {
            //文件短缺异常
            throw new FileNotFoundException("Config/Congif.xml文件未找到");
        }
    }

    public static XmlNodeList GetConfigNodeList(string xmlNodeName)
    {
        string basePath = HttpContext.Current.Request.PhysicalApplicationPath;        
        string xmlPath = basePath + "/config/config.xml";
        if (File.Exists(xmlPath))
        {
            XmlReader reader = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);
                XmlElement root = doc.DocumentElement;

                XmlNodeList nodelist = root.GetElementsByTagName(xmlNodeName);
                return nodelist;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        else
        {
            throw new FileNotFoundException("Config/Congif.xml文件未找到");
        }
    }

    public static XmlNode GetConfigNode(XmlNodeList NodeList, int i)
    {
        if (NodeList.Count > 0 && NodeList.Count>i)
        {
            XmlNode node = NodeList[i];
            return node;
        }
        else
        {
            throw new ArgumentOutOfRangeException("超出长度");
        }    
    }
}
