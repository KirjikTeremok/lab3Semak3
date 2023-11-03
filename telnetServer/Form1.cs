﻿using System;
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
        private Socket tcpSocket;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        { }
        void Listener()
        {
            int answerBool;
            string reply;
            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _port);
            tcpSocket = new Socket(tcpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
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
                    answerBool = Paintt(Encoding.UTF8.GetString(data, 0, size ));
                } while (listener.Available > 0);

                if (answerBool == 1)
                    reply = "Сообщение получено";
                
                else
                    reply = "Команда не распознана";
                byte[] answer = Encoding.UTF8.GetBytes(reply);
                listener.Send(answer);
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
            if (RemotePort.Text != "")
            {
                _thread = new Thread(new ThreadStart(Listener));
                _thread.Start();
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            
            tcpSocket?.Close();
            // if (_thread.IsAlive)
            _thread?.Abort();    

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Paintt(testCommandTextBox.Text);
            testCommandTextBox.Text = "";
        }
        
        int Paintt(string command)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            string[] v = command.Split(' ');
            int answer = 1;
            switch (v[0])
            {
                case "Line":
                    graphics.DrawLine(pen, int.Parse(v[1]), int.Parse(v[2]), int.Parse(v[3]), int.Parse(v[4]));
                    break;
                case "line":
                    graphics.DrawLine(pen, int.Parse(v[1]), int.Parse(v[2]), int.Parse(v[3]), int.Parse(v[4]));
                    break;
                case "Text":
                    graphics.DrawString(v[1], new Font("Times New Roman", int.Parse("14"),
                        FontStyle.Regular), new SolidBrush(Color.FromName(v[4])), new PointF(int.Parse(v[2]), int.Parse(v[3])));
                    break;
                case "text":
                    graphics.DrawString(v[1], new Font("Times New Roman", int.Parse("14"),
                        FontStyle.Regular), new SolidBrush(Color.FromName(v[4])), new PointF(int.Parse(v[2]), int.Parse(v[3])));
                    break;
                case "Circle":
                    Rectangle rectangle = new Rectangle(int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[3]));
                    graphics.DrawEllipse(pen, rectangle);
                    break;
                case "circle":
                    Rectangle rectangle1 = new Rectangle(int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[3]));
                    graphics.DrawEllipse(pen, rectangle1);
                    break;
                case "Rectangle":
                    graphics.DrawRectangle(pen, int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[4]));
                    break;
                case "rectangle":
                    graphics.DrawRectangle(pen, int.Parse(v[1]),
                        int.Parse(v[2]),int.Parse(v[3]),int.Parse(v[4]));
                    break;
                case "Clear":
                    graphics.Clear(Color.WhiteSmoke);
                    break;
                case "clear":
                    graphics.Clear(Color.WhiteSmoke);
                    break;
                default:
                    MessageBox.Show("команда не найдена");
                    answer = 0;
                    break;
            }
            return answer;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Paintt("Clear");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpSocket?.Close();
            _thread?.Abort();
        }

        private void telnetServerBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
