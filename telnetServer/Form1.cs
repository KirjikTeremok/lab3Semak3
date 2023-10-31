using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace telnetServer
{
    public partial class Form1 : Form
    {
        private string _ip = "127.0.0.1";
        private int _port;
        private Thread _thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        void Listener()
        {
            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _port);
            Socket tcpSocket = new Socket(tcpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(10);
            for (;;)
            {
                Socket listener = tcpSocket.Accept();
                byte[] data = new byte[256];
                int size;
                do
                {
                    size = listener.Receive(data);
                    Paintt(Encoding.UTF8.GetString(data, 0, size ));
                } while (listener.Available > 0);
                
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
            
            

        }

        private void RemotePort_TextChanged(object sender, EventArgs e)
        {
            _port = int.Parse(RemotePort.Text);
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            _thread = new Thread(new ThreadStart(Listener));
            _thread.Start();
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _thread.Abort();    

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Paintt(testCommandTextBox.Text);
        }
        
        void Paintt(string command)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            string[] v = command.Split(' ');
            switch (v[0])
            {
                case "Line":
                    graphics.DrawLine(pen, int.Parse(v[1]), int.Parse(v[2]), int.Parse(v[3]), int.Parse(v[4]));
                    break;
                case "Text":
                    graphics.DrawString(v[1], new Font("Times New Roman", int.Parse("14"),
                        FontStyle.Regular), new SolidBrush(Color.FromName(v[4])), new PointF(int.Parse(v[2]), int.Parse(v[3])));
                    break;
                case "Circle":
                    Rectangle rectangle = new Rectangle(int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[3]));
                    graphics.DrawEllipse(pen, rectangle);
                    break;
                case "Rectangle":
                    graphics.DrawRectangle(pen, int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[4]));
                    break;
                default:
                    MessageBox.Show("команда не найдена");
                    break;
                        
            }
        }
    }
}