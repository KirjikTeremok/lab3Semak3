using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpClient
{
    public partial class Form1 : Form
    {
        private IPEndPoint tcpEndPoint;
        private int _localPort = 0;
        private int _remotePort = 0;
        private string ip = "127.0.0.1";
        private Socket tcpSocket;
        public Form1()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Listener));
                thread.Start();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"{exception}");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            
        }

        void Listener()
        {
            tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), _localPort);
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(3);

            for (;;)
            {
                Socket listener = tcpSocket.Accept();
                byte[] data = new byte[256];
                int size = 0;
                
                

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
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), _remotePort);
            Socket remoteTcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            throw new System.NotImplementedException();
        }

        private void RemotePort_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}