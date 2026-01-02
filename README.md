# 串口助手工具
基于C# WinForm开发的串口调试助手，支持串口通信、用户登录注册及数据本地存储功能。


## 📋 功能介绍
1. **串口通信**：支持串口参数配置（波特率、数据位等）、数据收发、实时显示；
2. **用户管理**：实现用户注册、登录功能，记录用户操作信息；
3. **数据存储**：通过数据库保存串口通信记录及用户信息，支持数据持久化查询。
4. **双模式数据收集**：既支持硬件温湿度传感器数据采集，也支持虚拟串口模拟温湿度数据收集，适配开发与实际使用场景。

## 🛠️ 技术栈
- 开发框架：.NET Framework 4.7.2（WinForm）
- 数据库操作：SqlSugar（轻量级ORM框架）
- 其他依赖：Newtonsoft.Json（JSON序列化）
- 数据库类型：SQL Server（可兼容MySQL，修改配置即可）


## 🚀 使用说明
1. 下载项目后，用Visual Studio 2022及以上版本打开`SerialPort.csproj`；
2. 按照「数据库配置说明」配置数据库连接信息；
3. 执行「表结构示例」中的SQL脚本，创建对应的数据库表；
4. 编译运行项目，即可进入串口助手界面使用。

## 🔧 本地配置说明
- 在本地项目中创建`App.config`文件，填入自己的数据库连接字符串；
- 连接字符串格式参考：`Server=你的数据库服务器;Database=你的数据库名;Uid=用户名;Pwd=密码;`
- `App.config`已被`.gitignore`过滤，不会提交到GitHub，保护敏感信息不泄露。


## 🗄️ 数据库配置说明
### 1. 表结构示例（SQL脚本，直接在数据库执行即可）
用户表（User）
```sql
CREATE TABLE User (
    Id INT PRIMARY KEY IDENTITY(1,1), -- 自增主键
    UserName NVARCHAR(50) NOT NULL UNIQUE, -- 用户名（唯一，不可重复）
    Password NVARCHAR(50) NOT NULL, -- 用户密码（建议加密存储）
    CreateTime DATETIME DEFAULT GETDATE() -- 账号创建时间，默认当前时间
);
