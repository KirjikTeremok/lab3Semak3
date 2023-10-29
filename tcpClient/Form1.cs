using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace tcpClient
{
    public partial class Form1 : Form
    {
        private IPEndPoint _tcpEndPoint;
        private int _localPort;
        private int _remotePort ;
        private string _ip;
        private Socket _tcpSocket;
        private Thread _thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            try
            {
                _thread = new Thread(new ThreadStart(Listener));
                _thread.Start();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"{exception}");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            
            _tcpSocket?.Close();
            if (_thread.IsAlive) 
                _thread.Abort();
        }

        private void Listener()
        {
            _tcpEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _localPort);
            _tcpSocket = new Socket(_tcpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _tcpSocket.Bind(_tcpEndPoint);
            _tcpSocket.Listen(10);

            for (;;)
            {
                Socket listener = _tcpSocket.Accept();
                byte[] data = new byte[256];
                int size;
                
                do
                {
                    size = listener.Receive(data);
                    richTextBox1.AppendText(Encoding.UTF8.GetString(data, 0, size )+ "\n");
                    

                } while (listener.Available > 0);

                listener.Send(Encoding.UTF8.GetBytes("сообщение получено"));
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _remotePort);
            Socket remoteTcpSocket = new Socket(remoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            remoteTcpSocket.Bind(remoteEndPoint);
            if (textBox1.Text != "")
            {
                remoteTcpSocket.Connect(remoteEndPoint);
                remoteTcpSocket.Send(Encoding.UTF8.GetBytes(textBox1.Text));
            }
            
            remoteTcpSocket.Shutdown(SocketShutdown.Both);
            remoteTcpSocket.Close();
        }

        private void LocalPort_TextChanged(object sender, EventArgs e)
        {
            _localPort = int.Parse(LocalPort.Text);
        }

        private void RemotePort_TextChanged(object sender, EventArgs e)
        {
            _remotePort = int.Parse(RemotePort.Text);
        }


        private void ipTextBox_TextChanged(object sender, EventArgs e)
        {
            _ip = ipTextBox.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ip = "127.0.0.1";
            ipTextBox.Text = _ip;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tcpSocket?.Close();
            if (_thread.IsAlive) 
                _thread.Abort();
        }
    }
}