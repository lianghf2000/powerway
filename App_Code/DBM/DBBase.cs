using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.Common;
/// <summary>
///DBBase 的摘要说明
/// </summary>
public abstract class DBBase
{
    protected DbConnection conn;
    protected DbCommand cmd;
    protected DbDataAdapter ada;    
    protected string ConnectionString;

    protected abstract DbConnection initConnection();
    protected abstract DbCommand initCommand();
    protected abstract DbDataAdapter initDataAdapter();    
    protected abstract string initConnectionString();

    public DBBase()
    {
        this.ConnectionString = initConnectionString();
        this.conn = initConnection();
        this.conn.ConnectionString = this.ConnectionString;

        this.cmd = initCommand();
        this.cmd.Connection = conn;
        this.ada = initDataAdapter();       
    }

    public virtual string GetConnString()
    {
        return this.ConnectionString;
    }

    protected virtual void SetUpCMD(string sql,params DbParameter[] param)
    {
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        foreach (DbParameter p in param)
        {
            cmd.Parameters.Add(p);
        }
    }
    private void Open()
    {
        if (cmd.Connection.State != ConnectionState.Open)
        {
            cmd.Connection.Open();
        }
    }
    private void Close()
    {
        if (cmd.Connection.State != ConnectionState.Closed)
        {
            cmd.Connection.Close();
        }
    }

    /// <summary>
    /// 执行一条没有返回结果的sql语句
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <param name="param">参数数组</param>
    /// <returns>影响的行数</returns>
    public virtual int exe0(string sql, params DbParameter[] param)
    {
        SetUpCMD(sql, param);
        try
        {
            Open();
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //#if degug
            throw new Exception(ex.Message + sql);
            //#endif
        }
        finally
        {
            Close();
        }
    }

    public virtual string exe1(string sql, params DbParameter[] param)
    {
        SetUpCMD(sql, param);
        try
        {
            Open();
            try
            {
                string r = cmd.ExecuteScalar().ToString();
                return r;
            }
            catch (NullReferenceException exp)
            {
                return string.Empty;
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + sql);
        }
        finally
        {
            Close();
        }
    }

    public virtual DataSet exe2DS(string sql, string tabName, params DbParameter[] param)
    {
        SetUpCMD(sql, param);
        ada.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            Open();
            ada.Fill(ds, tabName);
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + sql);
        }
        finally
        {
            Close();
        }
    }

    public virtual DataTable exeTable(string sql, params DbParameter[] param)
    {
        DataSet ds=exe2DS(sql, "tempTable", param);
        if (ds.Tables.Count > 0)
        {
            return ds.Tables["tempTable"];
        }
        else
        {
            return null;
        }
    }
    public virtual DataRow exeRow(string sql, params DbParameter[] param)
    {
        DataTable tab = exeTable(sql, param);
        if (tab.Rows.Count > 0)
        {
            return tab.Rows[0];
        }
        else
        {
            return null;
        }
    }

    public virtual DbDataReader exeReader(CommandBehavior Behavior,string sql, params DbParameter[] param)
    {
        SetUpCMD(sql, param);
        try
        {
            Open();
            if (Behavior == null)
            {
                return cmd.ExecuteReader();
            }
            else
            {
                return cmd.ExecuteReader(Behavior);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + sql);
        }
        finally
        {
            Close();
        }
    }
}
