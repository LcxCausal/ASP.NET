using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Test1.SystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class SysConfig
    {
        private static string _strSqlConn = string.Empty;

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>数据库连接 SqlConnection</returns>
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetSqlConnectionString());
        }
        
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>数据库连接字符串(SQL)</returns>
        public static string GetSqlConnectionString()
        {
            if (_strSqlConn == "")
            {
                //读取 web.config中  ConnectionStrings 下：SqlClientConnectionString 的值
                _strSqlConn = ConfigurationManager.ConnectionStrings["SqlClientConnectionString"].ToString();
            }
            return _strSqlConn;
        }
    }
}