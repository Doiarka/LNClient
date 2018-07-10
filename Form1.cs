using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.DirectoryServices;
using System.Timers;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections;

namespace LNClient
{
    public partial class Form1 : Form
    {
        //Переменные
        private NotifyIcon UserIcon = new NotifyIcon();
        public static string selectedmyip;
        public static bool secondLevel = false;

        static Thread myThread = null; //сервер
        static Thread myThreadScan = null; //скан
        static Thread myThreadPing = null; TcpListener server = null; //пинг
        public byte[] msg; //сообщение
        public string cl = null;
        static bool isScan = false;
        private static readonly List<Thread> ServerThreads = new List<Thread>(); //сервер
        private static readonly List<Thread> ScanThreads = new List<Thread>(); //скан
        private static readonly List<Thread> PingThreads = new List<Thread>(); //пинг

        static Ping myPing;
        static PingReply reply;
        static IPAddress addr;
        static IPHostEntry host;
        static int th2Count = 0;
        static List<string> ClientsIP = new List<string>();
        static List<string> ScansIP = new List<string>();
        public static List<String> MyIPs = new List<String>();
        static bool scanover = false;
        public static List<UserInfo> listUI;
        public static List<string> listScanIp = new List<string>();
        public static object _syncLock = new object();
        public static List<Task<PingReply>> pingTasks;


        static Task<PingReply> PingAsync(string address)
        {
            int maxCount = 100;
            lock (_syncLock)
            {
                var tcs = new TaskCompletionSource<PingReply>();
                if (pingTasks.Count < maxCount)
                {
                    ++maxCount;
                    Ping ping = new Ping();
                    ping.PingCompleted += (obj, sender) =>
                    {
                        tcs.SetResult(sender.Reply);
                    
                    };
                    ping.SendAsync(address, new object());
                }
                return tcs.Task;
            }
        }

        public void PingT()
        {
            pingTasks = new List<Task<PingReply>>();
            foreach (var address in listScanIp)
            {
                pingTasks.Add(PingAsync(address));
                
            }
            /*foreach (var item in pingTasks)
            {
                if (item.Result.Status == IPStatus.Success)
                {
                    MessageBox.Show("GOOD");
                }
            }*/
        }

        //Класс Пользователь
        public class UserInfo
        {
            public string ip;
            public string userName;
            public string pcName;
            public int status;
        };

        //Заполнение информации запущенным пользователем
        public static void FillUserInfo()
        {
            UserInfo fillUI = new UserInfo();
            fillUI.ip = selectedmyip;
            fillUI.userName = Environment.UserName.ToString();
            fillUI.pcName = Dns.GetHostName();
            fillUI.status = 2;
            listUI = new List<UserInfo>();
            listUI.Add(fillUI);
        }

        //Инициализация формы
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.ShowInTaskbar = false;
        }

        //Определение запущенного клиента
        public static void Work(string ip)
        {
            try
            {
                addr = IPAddress.Parse(ip);

                host = Dns.GetHostEntry(addr);
                if (host != null)
                {
                    ScansIP.Add(ip);
                    Connect(ip, selectedmyip); //GetLocalIPAddress()
                }
                /*foreach (Task item in pingTasks)
                {
                    MessageBox.Show(item.Status.ToString());
                }*/
                
                //pingTask.Dispose();

                //return;
            }
            catch (ThreadAbortException exc)
            {
                Thread.ResetAbort();
            }
            catch (System.Net.Sockets.SocketException e) { }
        }

        //Пинг сети (скан)
        public void Scan()
        {
            try
            {
                scanover = false;
                int _n2 = 0;
                int _n2c = 0;
                string n0 = selectedmyip.Split('.')[0];
                string n1 = selectedmyip.Split('.')[1];

                if (secondLevel == false)
                {
                    _n2 = Convert.ToInt32(selectedmyip.Split('.')[2]);
                    _n2c = _n2 + 1;
                }
                else
                {
                    _n2 = 0;
                    _n2c = 256;
                }

                for (int n2 = _n2; n2 < _n2c; n2++)
                {
                    for (int n3 = 1; n3 < 256; n3++)
                    {
                        //if (isScan)
                        //{
                            //host = null;
                            //myPing = new Ping();
                            string ip = n0 + "." + n1 + "." + n2 + "." + n3;
                            //reply = myPing.Send(ip, 1);

                            listScanIp.Add(ip);
                            /*
                            if (reply.Status == IPStatus.Success)
                            {
                                //pingTask = Task.Factory.StartNew(() => Work(ip));
                                pingTask = new Task(() => Work(ip));
                                pingTask.Start();
                                pingTasks.Add(pingTask);

                                var myThreadPing = new Thread(() => Work(ip));
                                myThreadPing.IsBackground = true;
                                myThreadPing.Start();
                                PingThreads.Add(myThreadPing);
                            }*/
                        //}
                    }
                }
                //MessageBox.Show("До PingT");
                PingT();
                //MessageBox.Show("После PingT");
                //isScan = false;
            }
            catch (ThreadAbortException exc)
            {
                Thread.ResetAbort();
            }
            /*finally
            {
                foreach (var item in collection)
                {

                }
                Work(ip);
            }*/
        }
        
        //Таймер каждую секунду
        public void Timer1_Tick(object Sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            ThreadCountLabel.Text = "Потоков: " + Process.GetCurrentProcess().Threads.Count.ToString();
            CountListviewLabel.Text = "Клиентов: " + listView1.Items.Count.ToString();
            ScanIpLabel.Text = "Пингов: " + listScanIp.Count.ToString();

            try
            {
                if (listScanIp.Count > 0)
                {
                    label2.Text = listScanIp.Last().ToString();
                }
            }
            catch (Exception) {}
        }

        //Поток для сканирования
        public void Scanning()
        {
            Scan();
            /*scanTask = new Task(() => Scan());
            scanTask.Start();
            scanTasks.Add(scanTask);
            */
            /*var myThreadScan = new Thread(() => Scan());
            myThreadScan.IsBackground = true;
            myThreadScan.Start();
            ScanThreads.Add(myThreadScan);*/
        }

        //Загрузка главной формы
        public void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            ColumnHeader h = new ColumnHeader();
            h.Width = listView1.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            listView1.Columns.Add(h);
            SearchMyIPs();

            var myThread = new Thread(Listen);
            myThread.IsBackground = true;
            myThread.Start();
            ServerThreads.Add(myThread);
            Scanning();
        }

        //Сервер приема пакетов от других клиентов
        public void Listen()
        {
            try
            {
                // Определим нужное максимальное количество потоков
                // Пусть будет по 4 на каждый процессор
                int MaxThreadsCount = Environment.ProcessorCount * 4;
                // Установим максимальное количество рабочих потоков
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
                // Установим минимальное количество рабочих потоков
                ThreadPool.SetMinThreads(2, 2);
                // Устанавливаем порт для TcpListener = 9595.
                Int32 port = 80;
                IPAddress localAddr = IPAddress.Parse(selectedmyip); //GetLocalIPAddress()
                int counter = 0;
                server = new TcpListener(localAddr, port);
                // Запускаем TcpListener и начинаем слушать клиентов.
                server.Start();
                // Принимаем клиентов в бесконечном цикле.
                while (true)
                {
                    // При появлении клиента добавляем в очередь потоков его обработку.
                    ThreadPool.QueueUserWorkItem(ObrabotkaZaprosa, server.AcceptTcpClient());
                    counter++;
                }
            }
            catch (SocketException e) { }
            catch (ThreadAbortException exc)
            {
                Thread.ResetAbort();
            }
            finally
            {
                server.Stop();
            }
        }

        //Добавление найденного клиента на форму
        public void AddClient(string clnt)
        {
            string pcname = Dns.GetHostEntry(IPAddress.Parse(clnt)).HostName.ToString().Split('.')[0];
            foreach (UserInfo item in listUI)
            {
                listView1.Items.Add(item.userName); 
            }
            ClientsIP.Add(clnt);
        }

        //Определение ип адресов клиента если несколько сетей
        public void SearchMyIPs()
        {
            var DNSes = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in DNSes)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    MyIPs.Add(item.ToString());
                }
            }
            if (MyIPs.Count == 1)
            {
                selectedmyip = MyIPs[0];
            }
            
            //временно статика
            //selectedmyip = "192.168.1.47";
            if (String.IsNullOrEmpty(selectedmyip))
            {
                SelectLan selectLan = new SelectLan();
                selectLan.ShowDialog();
                Show();
                this.Hide();
            }

        }

        //Отправка пакета
        static void Connect(String server, String message)
        {
            try
            {
                int port = 80;
                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                stream.Close();
                client.Close();
            }
            catch { }
        }

        //Обработка пакета сервером
        public void ObrabotkaZaprosa(object client_obj)
        {
            try
            {
                // Буфер для принимаемых данных.
                Byte[] bytes = new Byte[256];
                String data = null;
                TcpClient client = client_obj as TcpClient;
                data = null;

                // Получаем информацию от клиента
                NetworkStream stream = client.GetStream();
                int i;
                // Принимаем данные от клиента в цикле пока не дойдём до конца.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Преобразуем данные в ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    // Преобразуем строку к верхнему регистру.
                    data = data.ToUpper();
                    // Преобразуем полученную строку в массив Байт.
                    msg = System.Text.Encoding.ASCII.GetBytes(data);
                    // Отправляем данные обратно клиенту (ответ).
                    stream.Write(msg, 0, msg.Length);
                }
                AddClient(client.Client.LocalEndPoint.ToString().Split(':')[0]);
                client.Close();
            }
            catch (ThreadAbortException exc)
            {
                Thread.ResetAbort();
            }
        }

        //При закрытии формы
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            foreach (var thread in PingThreads)
                thread.Abort();
            foreach (var thread in ScanThreads)
                thread.Abort();
            foreach (var thread in ServerThreads)
                thread.Abort();
        }
        

        public static void BeginScan()
        {
            FillUserInfo();
            if (isScan)
            {
                isScan = false;
                try
                {
                    foreach (var thread in PingThreads)
                    {
                        return;
                        //thread.Abort();
                    }
                }
                catch (ThreadAbortException exc)
                {
                    Thread.ResetAbort();
                }
            }
            else
            {
                isScan = true;
                //Thread.Sleep(1000);
                //Scanning();
            }
        }
        
        //Нажатие на главноу иконку
        private void MainNotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        //Не показывать в панеле задач при сворачивании в трей и показывать при нормальном отображении
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                ShowInTaskbar = true;
            }
            else
            {
                ShowInTaskbar = false;
            }
        }
    }
}