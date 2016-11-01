using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;

/// <summary>
///TableHelper 的摘要说明
/// </summary>
public class TableHelper
{
    public static string GetTableName(string language,string TableName)
    {
        string basePath = HttpContext.Current.Request.PhysicalApplicationPath;
        string xmlPath = basePath + "config\\"+language+".xml";

        if (File.Exists(xmlPath))
        {
            XmlReader reader = null;
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);
                XmlElement root = doc.DocumentElement;

                XmlNodeList NodeList = root.GetElementsByTagName(TableName);
                if (NodeList.Count > 0)
                {
                    XmlNode node = NodeList[0];
                    return node.InnerText;
                }
                else
                {
                    throw new ArgumentException("未找到表" + TableName + ",请注意大小写");
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
            throw new FileNotFoundException("未找到Congif/" + language + ".xml"+xmlPath);
        }
    }
}
