using SqlSugar;
using System;

namespace SerialPortDebugTool.Entities
{
    /// <summary>
    /// 用户实体类（映射User1表）
    /// </summary>
    [SugarTable("User1")] // 指定数据库表名（若实体类名与表名一致，可省略）
    public class UserModel
    {
        /// <summary>
        /// 主键ID（自增）
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] // 标记主键+自增
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)] // 指定列名、长度、非空
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false)]
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime CreateTime { get; set; }
    }
}