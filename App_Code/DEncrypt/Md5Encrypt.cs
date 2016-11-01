using System;
using System.Collections.Generic;
using System.Text;
using  System.Web.Security;
namespace Camnpr.Common.DEncrypt
{
    /// <summary>
    /// Md5加密类
    /// </summary>
   public  class Md5Encrypt
    {
       /// <summary>
       /// MD5构造函数
       /// </summary>
       public Md5Encrypt() { }
       /// <summary>
       /// 获得MD5加密过后的字符串
       /// </summary>
       /// <param name="strValue"></param>
       /// <returns></returns>
       public static string GetMd5Encrypt(string strValue)
       {
            return  FormsAuthentication.HashPasswordForStoringInConfigFile(strValue, "MD5");          
       }
    }
}
