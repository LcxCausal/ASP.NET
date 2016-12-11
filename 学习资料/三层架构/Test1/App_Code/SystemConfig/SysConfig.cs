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
        /// ���ݿ�����
        /// </summary>
        /// <returns>���ݿ����� SqlConnection</returns>
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetSqlConnectionString());
        }
        
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        /// <returns>���ݿ������ַ���(SQL)</returns>
        public static string GetSqlConnectionString()
        {
            if (_strSqlConn == "")
            {
                //��ȡ web.config��  ConnectionStrings �£�SqlClientConnectionString ��ֵ
                _strSqlConn = ConfigurationManager.ConnectionStrings["SqlClientConnectionString"].ToString();
            }
            return _strSqlConn;
        }
    }
}