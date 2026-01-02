using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace SerialPortDebugAssistant
{
    public partial class Form1 : Form
    {
        // 串口核心对象：负责与硬件（232/485设备）建立通信连接，所有串口操作都依赖它
        private SerialPort serialPort = new SerialPort();
        // 全局接收缓冲区：解决串口通信"粘包/半包"问题，临时存储所有接收的字节数据
        // 新手理解：串口接收数据可能不完整（半包）或多个数据粘在一起（粘包），需要缓冲区暂存再拆分
        private byte[] _receiveBuffer = new byte[1024];
        // 缓冲区索引：标记当前接收的数据存到了缓冲区的哪个位置，相当于"数据指针"
        private int _bufferIndex = 0;
        // 定时发送定时器：负责周期性自动发送数据，无需手动重复点击发送按钮
        private Timer sendTimer;

        public Form1()
        {
            InitializeComponent(); // WinForm必备：自动初始化窗体上的所有控件（下拉框、按钮等）
            InitSerialPort();      // 调用串口初始化方法，配置串口默认参数
            this.FormClosing += Form1_FormClosing; // 绑定窗体关闭事件，防止程序关闭后串口仍被占用
        }

        /// <summary>
        /// 串口+定时器初始化：一次性配置好串口默认参数和定时发送功能
        /// </summary>
        private void InitSerialPort()
        {
            // 1. 自动检测电脑上所有可用的串口（如COM1、COM3），并填充到串口下拉框
            string[] ports = SerialPort.GetPortNames();
            comboBox_SerialPort.Items.Clear(); // 先清空下拉框，避免重复添加
            if (ports.Length > 0)
            {
                comboBox_SerialPort.Items.AddRange(ports); // 把可用串口添加到下拉框
                comboBox_SerialPort.SelectedIndex = 0; // 默认选中第一个串口
            }
            else
            {
                AppendLog("未检测到可用串口！"); // 没有串口时给出提示
            }

            // 2. 设置串口默认参数（工业常用9600 8N1：波特率9600、数据位8、无校验、停止位1）
            // 新手注意：这些参数必须和硬件设备的参数一致，否则无法正常通信
            comboBox_BaudRate.Text = "9600"; // 波特率：通信速率，相当于"数据传输的快慢"
            comboBox_DataBits.Text = "8";     // 数据位：每个字节的数据长度，固定8位
            comboBox_Parity.Text = Parity.None.ToString(); // 校验位：无校验，用于验证数据传输是否出错
            comboBox_StopBits.Text = StopBits.One.ToString(); // 停止位：标记一个字节传输结束，固定1位
            textBox_Send.Text = "GetTemp"; // 默认发送指令：给硬件的查询指令（查询温湿度）

            // 3. 初始化定时发送定时器
            sendTimer = new Timer();
            sendTimer.Interval = 2000; // 定时间隔：2000毫秒=2秒，每2秒发送一次数据
            // 匿名委托：定时器触发时，自动调用SendData方法发送文本框中的内容
            // 新手理解：相当于给定时器绑定一个"自动执行的任务"，时间到了就执行
            sendTimer.Tick += (s, e) => SendData(textBox_Send.Text);
        }

        /// <summary>
        /// 打开/关闭串口按钮点击事件：一个按钮实现两种功能（切换串口状态）
        /// </summary>
        private void button_OpenSerial_Click(object sender, EventArgs e)
        {
            // 判断串口是否未打开：未打开则执行打开操作
            if (!serialPort.IsOpen)
            {
                try
                {
                    // 配置串口核心参数（端口名从下拉框选择，其他参数固定9600 8N1）
                    serialPort.PortName = comboBox_SerialPort.SelectedItem.ToString(); // 串口名（如COM3）
                    serialPort.BaudRate = 9600;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Encoding = Encoding.UTF8; // 字符编码：用于将字符串转换为字节传输

                    // 打开串口：这一步是建立硬件通信的关键，失败会抛出异常（如串口被占用）
                    serialPort.Open();
                    // 绑定数据接收事件：当串口有数据传入时，自动触发DataReceivedHandler方法
                    // 新手理解：相当于给串口设置一个"数据监听器"，有数据就自动处理
                    serialPort.DataReceived += DataReceivedHandler;
                    // 绑定串口错误事件：串口通信出错时（如帧错误），自动输出错误信息
                    serialPort.ErrorReceived += (s, err) => AppendLog($"串口错误：{err.EventType}");
                    serialPort.DiscardInBuffer(); // 打开串口后清空接收缓冲区，避免残留旧数据

                    AppendLog($"成功打开串口：{serialPort.PortName}");
                    SendData(textBox_Send.Text); // 打开串口后立即发送一次默认指令
                    sendTimer.Start(); // 启动定时发送
                    button_OpenSerial.Text = "关闭串口"; // 按钮文字切换为"关闭串口"
                }
                catch (Exception ex)
                {
                    // 捕获打开串口的异常（如串口被其他程序占用、端口不存在等），避免程序崩溃
                    AppendLog($"打开串口失败：{ex.Message}");
                }
            }
            else
            {
                // 串口已打开：执行关闭操作
                if (serialPort != null && serialPort.IsOpen)
                {
                    try
                    {
                        serialPort.Close(); // 关闭串口，释放硬件资源
                        AppendLog("串口已关闭");
                    }
                    catch (Exception ex)
                    {
                        // 捕获关闭串口的异常，避免程序崩溃
                        AppendLog($"关闭串口失败：{ex.Message}");
                    }
                }

                sendTimer.Stop(); // 停止定时发送
                button_OpenSerial.Text = "打开串口"; // 按钮文字切换为"打开串口"
            }
        }

        /// <summary>
        /// 手动发送数据按钮点击事件：点击后发送文本框中的内容
        /// </summary>
        private void button_SendData_Click(object sender, EventArgs e)
        {
            SendData(textBox_Send.Text); // 调用发送数据方法，传入文本框内容
        }

        /// <summary>
        /// 核心发送方法：负责将字符串转换为固定8字节格式，并通过串口发送
        /// </summary>
        /// <param name="data">要发送的原始字符串</param>
        private void SendData(string data)
        {
            // 发送前先判断串口是否已打开，未打开则提示
            if (serialPort.IsOpen)
            {
                try
                {
                    // 固定8字节格式处理：不足8个字符补空格，超过8个字符截断
                    // 新手理解：工业通信常用固定长度数据，避免数据格式混乱
                    string fixedData = data.PadRight(8).Substring(0, 8);
                    serialPort.Write(fixedData); // 发送处理后的字符串
                    AppendLog($"发送：{fixedData}"); // 记录发送日志
                }
                catch (Exception ex)
                {
                    // 捕获发送异常（如串口突然断开），避免程序崩溃
                    AppendLog($"发送失败：{ex.Message}");
                }
            }
            else
            {
                AppendLog("串口未打开，发送失败"); // 串口未打开时给出提示
            }
        }

        /// <summary>
        /// 串口数据接收事件（自动触发）：负责读取串口接收到的字节数据
        /// 新手难点：该方法运行在"串口线程"，不是"UI线程"，不能直接操作UI控件（如下拉框、文本框）
        /// </summary>
        /// <param name="sender">触发事件的串口对象</param>
        /// <param name="e">接收事件参数</param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender; // 转换为串口对象，方便后续操作
            try
            {
                int byteCount = sp.BytesToRead; // 获取当前串口缓冲区中待读取的字节数
                byte[] buffer = new byte[byteCount]; // 创建临时缓冲区，存储本次读取的字节
                sp.Read(buffer, 0, byteCount); // 读取串口数据到临时缓冲区
                ProcessReceivedData(buffer, byteCount); // 调用粘包处理方法，拆分完整数据帧
            }
            catch (Exception ex)
            {
                // 捕获读取数据异常，避免程序崩溃
                AppendLog($"读取数据失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 新手核心难点：处理串口粘包/半包问题，拆分8字节完整数据帧
        /// 原理：将每次接收的零散数据存入全局缓冲区，当缓冲区数据≥8字节时，拆分出一个完整帧
        /// </summary>
        /// <param name="data">本次接收的零散字节数据</param>
        /// <param name="length">本次接收的字节长度</param>
        private void ProcessReceivedData(byte[] data, int length)
        {
            // 1. 将本次接收的零散数据存入全局缓冲区
            // 循环遍历每个字节，依次存入全局缓冲区，同时更新缓冲区索引
            for (int i = 0; i < length; i++)
            {
                _receiveBuffer[_bufferIndex++] = data[i];
            }

            // 2. 循环拆分完整帧：只要缓冲区数据≥8字节，就拆分出一个8字节完整帧
            while (_bufferIndex >= 8)
            {
                ProcessTempFrame(_receiveBuffer); // 解析拆分后的8字节温湿度数据

                // 3. 缓冲区剩余数据前移：处理完一个帧后，将剩余数据移到缓冲区开头
                // 新手理解：比如缓冲区有10字节，拆分8字节后还剩2字节，这2字节需要移到缓冲区最前面，等待后续数据补充
                int remaining = _bufferIndex - 8; // 计算剩余字节数
                // 数组复制：将索引8之后的剩余数据，复制到缓冲区索引0的位置
                Array.Copy(_receiveBuffer, 8, _receiveBuffer, 0, remaining);
                _bufferIndex = remaining; // 更新缓冲区索引为剩余字节数
            }
        }

        /// <summary>
        /// 解析8字节温湿度数据帧，转换为易读的温度和湿度格式
        /// </summary>
        /// <param name="frame">8字节完整数据帧</param>
        private void ProcessTempFrame(byte[] frame)
        {
            // 将8字节数据转换为16进制字符串（便于调试查看原始数据）
            string frameHex = BitConverter.ToString(frame, 0, 8).Replace("-", " ");
            // 将8字节数据转换为UTF8文本字符串（去除首尾空格）
            string frameStr = Encoding.UTF8.GetString(frame, 0, 8).Trim();

            // 输出解析日志，便于查看原始数据
            AppendLog("------------------------");
            AppendLog($"接收帧（16进制）：{frameHex}");
            AppendLog($"接收帧（文本）：{frameStr}");

            try
            {
                // 查找小数点位置，用于拆分温度和湿度
                int dotIndex = frameStr.IndexOf('.');
                // 多条件判断：确保数据格式有效（长度8、包含小数点、无错误标识）
                if (dotIndex + 2 < frameStr.Length && frameStr.Length == 8 && !frameStr.Contains("ERROR"))
                {
                    // 拆分温度字符串（包含小数点后1位，如"25.5"）
                    string tempStr = frameStr.Substring(0, dotIndex + 2);
                    // 拆分湿度字符串（小数点后2位，如"60"）
                    string humiStr = frameStr.Substring(dotIndex + 2, 2);

                    // 尝试将字符串转换为数值类型（温度float、湿度int）
                    // 新手理解：TryParse可以避免转换失败导致程序崩溃，转换成功返回true，失败返回false
                    if (float.TryParse(tempStr, out float temp) && int.TryParse(humiStr, out int humi))
                    {
                        // 过滤合理的温湿度范围（温度：-20~60℃，湿度：0~100%）
                        if (temp >= -20 && temp <= 60 && humi >= 0 && humi <= 100)
                        {
                            AppendLog($"温度：{temp} ℃ | 湿度：{humi} %");
                        }
                        else
                        {
                            AppendLog("数据超出合理范围");
                        }
                    }
                    else
                    {
                        AppendLog("数据解析失败");
                    }
                }
                else
                {
                    AppendLog("非有效数据帧");
                }
            }
            catch
            {
                // 捕获解析异常（如数据格式混乱），避免程序崩溃
                AppendLog("非有效温湿度数据");
            }
            AppendLog("------------------------");
        }

        /// <summary>
        /// 新手核心难点：跨线程更新UI日志（解决WinForm跨线程访问异常）
        /// 原理：串口接收事件运行在串口线程，不能直接操作UI控件，需通过Invoke委托切换到UI线程
        /// </summary>
        /// <param name="log">要显示的日志内容</param>
        private void AppendLog(string log)
        {
            // InvokeRequired：判断当前线程是否为UI线程，返回true表示不是UI线程
            if (textBox_Receive.InvokeRequired)
            {
                // 委托调用：将AppendLog方法切换到UI线程执行，避免跨线程异常
                // 新手理解：相当于给UI线程发一个"消息"，让UI线程自己去更新文本框
                textBox_Receive.Invoke(new Action<string>(AppendLog), log);
            }
            else
            {
                // 当前是UI线程：直接更新文本框，追加日志并换行
                textBox_Receive.AppendText(log + Environment.NewLine);
                textBox_Receive.ScrollToCaret(); // 自动滚动到文本框最下方，查看最新日志
            }
        }

        /// <summary>
        /// 窗体关闭事件：程序关闭时释放资源，防止串口占用和内存泄露
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭串口：程序关闭时确保串口被释放，否则下次无法打开
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            // 释放定时器资源：?. 是空值判断简化写法，避免sendTimer为null时抛出异常
            // 新手理解：相当于"如果sendTimer不为null，就执行Dispose释放资源"
            sendTimer?.Dispose();
        }

        private void button_OpenSerial_Click_1(object sender, EventArgs e)
        {

        }
    }
}