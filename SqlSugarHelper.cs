using System;
using System.Configuration; 
using System.Dynamic;
using SqlSugar;

namespace SerialPortDebugTool.Utils
{
    /// <summary>
    /// SqlSugar工具类（单例模式，简化版）
    /// </summary>
    public class SqlSugarHelper
    {
        private static readonly SqlSugarClient _instance = CreateInstance();

        public static SqlSugarClient Instance => _instance;
        private static SqlSugarClient CreateInstance()
        {
            var connectionConfig = new ConnectionConfig
            {
                // 直接在ConnectionConfig内拼接连接字符串
                ConnectionString = $"Server={ConfigurationManager.AppSettings["DbServer"]};Database={ConfigurationManager.AppSettings["DbName"]};Uid={ConfigurationManager.AppSettings["DbUser"]};Pwd={ConfigurationManager.AppSettings["DbPwd"]};",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            };

            return new SqlSugarClient(connectionConfig);
        }
    }
}