using System;
using System.Windows.Forms;
using SerialPortDebugTool.DAL;    // 引用UserDAL（和Login窗体统一）
using SerialPortDebugTool.Entities; // 引用User实体

namespace SerialPortDebugTool
{
    public partial class RegisterForm : Form
    {
        // 【简化点1：统一使用UserDAL，替换直接调用SqlSugarHelper】
        // 好处：和Login窗体逻辑一致，不直接操作数据库，更规范、易维护
        private UserDAL _userDAL = new UserDAL();

        public RegisterForm()
        {
            InitializeComponent();
        }

        // 注册按钮点击事件
        private void btnRegSubmit_Click(object sender, EventArgs e)
        {
            // 1. 输入合法性校验（保留核心功能，代码格式微调更清爽）
            string regName = txtRegName.Text.Trim();
            string regPwd = txtRegPwd.Text.Trim();
            string regConfirmPwd = txtRegConfirmPwd.Text.Trim();

            // 用户名非空校验
            if (string.IsNullOrEmpty(regName))
            {
                MessageBox.Show("用户名不能为空！");
                txtRegName.Focus(); // 光标定位到用户名输入框，提升用户体验
                return;
            }
            // 密码非空校验
            if (string.IsNullOrEmpty(regPwd))
            {
                MessageBox.Show("密码不能为空！");
                txtRegPwd.Focus(); // 光标定位到密码输入框
                return;
            }
            // 两次密码一致性校验
            if (regPwd != regConfirmPwd)
            {
                MessageBox.Show("两次密码输入不一致！");
                txtRegConfirmPwd.Focus();
                txtRegConfirmPwd.SelectAll(); // 选中错误输入，方便用户直接修改
                return;
            }

            try
            {
                // 【简化点2：使用UserDAL查重，替换直接调用db.Queryable()】
                // 好处：代码更简洁，查重逻辑封装在UserDAL中，后续修改只需改DAL
                UserModel existUser = _userDAL.GetUserByUserName(regName);
                if (existUser != null) // 查询到用户，说明用户名已注册
                {
                    MessageBox.Show("该用户名已被注册！");
                    txtRegName.Focus();
                    txtRegName.SelectAll();
                    return;
                }

                // 【简化点3：使用UserDAL新增用户，省略冗余中间变量】
                // 1. 构造User实体对象
                UserModel newUser = new UserModel
                {
                    UserName = regName,
                    Password = regPwd, // 备注：实际项目务必加密（如MD5+盐值），此处为演示保留明文
                    CreateTime = DateTime.Now // 自动填充当前注册时间
                };

                // 2. 调用UserDAL的AddSingleUser方法新增，直接判断返回值
                // 无需定义insertCount中间变量，直接将方法返回值放入判断条件，简化代码
                int newUserId = _userDAL.AddSingleUser(newUser);
                if (newUserId > 0) // 主键自增，返回值>0说明新增成功
                {
                    MessageBox.Show("注册成功！");
                    this.DialogResult = DialogResult.OK; // 设置对话框结果，供登录窗体判断
                    this.Close(); // 关闭注册窗体
                }
                else
                {
                    MessageBox.Show("注册失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                // 异常捕获：给出友好提示，方便排查问题（如数据库连接失败、表不存在等）
                MessageBox.Show($"注册异常：{ex.Message}", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 关闭注册窗体按钮事件（保留核心功能，无需简化）
        private void btnRegClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}