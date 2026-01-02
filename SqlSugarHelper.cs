using System;
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
                ConnectionString= "Server=localhost;Database=PracticalCommunication;Uid=ze;Pwd=hz15317122499",
                DbType=DbType.SqlServer,
                IsAutoCloseConnection=true,
                InitKeyType=InitKeyType.Attribute
            };

            return new SqlSugarClient(connectionConfig);
        }
    }
}