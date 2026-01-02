using System;
using System.Collections.Generic;
using SqlSugar;
using SerialPortDebugTool.Entities;
using SerialPortDebugTool.Utils;

namespace SerialPortDebugTool.DAL
{
    /// <summary>
    /// 用户数据访问层（处理User表核心CRUD操作）
    /// </summary>
    public class UserDAL
    {
        // 增：单条新增（核心，注册功能使用，必须保留）
        /// <summary>
        /// 单条新增用户
        /// </summary>
        /// <param name="userModel">用户实体</param>
        /// <returns>自增主键ID</returns>
        public int AddSingleUser(UserModel userModel)
        {
            if (userModel == null)
                throw new ArgumentNullException(nameof(userModel), "用户实体不能为空");

            return SqlSugarHelper.Instance.Insertable(userModel).ExecuteReturnIdentity();
        }

        // 删：主键删除（当前无对应UI，注释备用）
        /*
        /// <summary>
        /// 根据主键删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "用户ID必须大于0");

            return SqlSugarHelper.Instance.Deleteable<User>().In(id).ExecuteCommand();
        }
        */

        // 改：全字段修改（当前无对应UI，注释备用）
        /*
        /// <summary>
        /// 根据主键全字段修改用户
        /// </summary>
        /// <param name="userModel">用户实体（含主键）</param>
        /// <returns>受影响行数</returns>
        public int UpdateUser(User userModel)
        {
            if (userModel == null || userModel.Id <= 0)
                throw new ArgumentNullException(nameof(userModel), "用户实体不能为空且主键ID有效");

            return SqlSugarHelper.Instance.Updateable(userModel).ExecuteCommand();
        }
        */

        // 查：核心查询（仅保留 GetUserByUserName，其余注释备用）
        /*
        /// <summary>
        /// 根据主键查询用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户实体</returns>
        public User GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "用户ID必须大于0");

            return SqlSugarHelper.Instance.Queryable<User>().InSingle(id);
        }
        */

        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户实体</returns>
        public UserModel GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName), "用户名不能为空");

            return SqlSugarHelper.Instance.Queryable<UserModel>()
                .Where(u => u.UserName == userName)
                .First();
        }

        /*
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        public List<User> GetAllUserList()
        {
            return SqlSugarHelper.Instance.Queryable<User>().ToList();
        }
        */

        /*
        /// <summary>
        /// 分页查询用户（核心分页逻辑）
        /// </summary>
        /// <param name="pageIndex">当前页码（从1开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns>分页结果</returns>
        public PageResult<User> GetUserPageList(int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "页码必须大于等于1");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "每页条数必须大于等于1");

            int totalCount = 0;
            var pageList = SqlSugarHelper.Instance.Queryable<User>()
                .OrderBy(u => u.Id, OrderByType.Desc)
                .ToPageList(pageIndex, pageSize, ref totalCount);

            return new PageResult<User>
            {
                DataList = pageList,
                TotalCount = totalCount,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        */
    }
}