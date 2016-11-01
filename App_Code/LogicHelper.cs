using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///LogicHelper 的摘要说明
/// </summary>
public class LogicHelper
{
	public LogicHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private static string GetRealID(string id)
    {
        string[] ids = id.Split(',');
        string RealId = string.Empty;
        foreach (string str in ids)
        {
            if (string.IsNullOrEmpty(RealId))
            {
                int temp = 0;
                if (int.TryParse(str, out temp))
                {
                    RealId = temp.ToString();
                }
                else
                {
                    RealId = "'" + str + "'";
                }
            }
            else
            {
                int temp = 0;
                if (int.TryParse(str, out temp))
                {
                    RealId += "," + temp.ToString();
                }
                else
                {
                    RealId += ",'" + str + "'";
                }
            }
        }
        return RealId;
    }

    public static void DeleteMore(string table, string id)
    {
        Table t = new Table(table);

        string RealId = GetRealID(id);        

        string sql = "delete from " + t.TableName + " where " + t.PKFiled + " in (" + RealId + ")";
        DBFactory.GetConn().exe0(sql);
    }

    public static void SetBoolMore(string table, string id, string column,int value)
    {
        Table t = new Table(table);
        string realid = GetRealID(id);

        string savedatesql = "select count(*) from information_schema.columns where table_name = N'" + t.TableName + "' and column_name='"+column+"_date'";
        string cnt = DBFactory.GetConn().exe1(savedatesql);
        string setdate = string.Empty;
        if (Convert.ToInt32(cnt) > 0)
        {
            setdate = "," + column + "_date='" + ((value==0)?"null":DateTime.Now.ToString()) + "'";
        }
        string sql = "update " + t.TableName + " set " + column + "="+value+setdate+ " where " + t.PKFiled + " in (" + realid + ")";

        //throw new Exception(sql);
        DBFactory.GetConn().exe0(sql);
    }
}
