using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
///Sql2000 的摘要说明
/// </summary>
public class Sql2000:DBBase
{

    protected override System.Data.Common.DbConnection initConnection()
    {
        return new SqlConnection();
    }

    protected override System.Data.Common.DbCommand initCommand()
    {
        return new SqlCommand();
    }

    protected override System.Data.Common.DbDataAdapter initDataAdapter()
    {
        return new SqlDataAdapter();
    }    

    protected override string initConnectionString()
    {
        return ConfigurationManager.ConnectionStrings[Configs.GetConfig("connstrname")].ToString();
    }

    public Sql2000(string connstr):this()
    {
        this.ConnectionString = connstr;
        this.conn.ConnectionString = ConnectionString;
    }
    public Sql2000()
        : base()
    { }
}
