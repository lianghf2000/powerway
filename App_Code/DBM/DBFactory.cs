using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
/// <summary>
///DBFactory 的摘要说明
/// </summary>
public class DBFactory
{
    public static DBBase GetConn()
    {
        //return (DBBase)Assembly.Load("App_Code").CreateInstance(Configs.GetConfig("dbtype"));
        string sql2000= "Sql2000";
        return (DBBase)Assembly.Load("App_Code").CreateInstance(sql2000);
    }
}
