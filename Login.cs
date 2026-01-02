using System;
using System.Windows.Forms;
using SerialPortDebugAssistant;
using SerialPortDebugTool.DAL;
using SerialPortDebugTool.Entities;

namespace SerialPortDebugTool
{
    public partial class Login : Form
    {
        private UserDAL _userDAL = new UserDAL();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            // 1. 获取用户输入的账号密码（去除前后空格，避免无效输入）
            string UserName = textBox1.Text.Trim();
            string Password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("账号或密码不能为空");
                return;
            }

            try
            {
                // 调用UserDAL的GetUserByUserName方法，查询数据库中是否存在该用户名
                // 这个方法会根据输入的用户名，去数据库的User1表中查询对应的用户信息
                UserModel dbUser = _userDAL.GetUserByUserName(UserName);

                // 4. 分情况判断比对结果
                if (dbUser == null)
                {
                    // 情况1：数据库中没有这个用户名（查询结果为null）
                    MessageBox.Show("该用户名不存在！");
                    return;
                }
                else if (dbUser.Password != Password)
                {
                    // 情况2：用户名存在，但密码和数据库中的不一致
                    MessageBox.Show("密码错误！");
                    return;
                }
                else
                {
                    // 情况3：用户名和密码都匹配（登录成功），再执行窗体跳转
                    MessageBox.Show("登录成功！");

                    // 1. 创建串口助手窗体实例（原Form1）
                    Form1 serialPortForm = new Form1();

                    serialPortForm.FormClosed += (s, args) =>
                    {
                        this.Close();
                    };
                    serialPortForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                // 捕获异常（比如数据库连接失败、表不存在等），给出友好提示
                MessageBox.Show($"登录异常：{ex.Message}");
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 隐藏当前登录窗口
            this.Hide();
            // 实例化注册窗口
            RegisterForm registerForm = new RegisterForm();
            // 注册窗口关闭时，显示登录窗口（无论注册成功与否都返回登录页）
            registerForm.FormClosed += (s, args) => this.Show();
            // 以对话框模式打开注册窗口
            registerForm.ShowDialog();
        }
    }
}