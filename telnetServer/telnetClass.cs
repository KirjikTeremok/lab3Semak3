using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace telnetServer
{
    public class telnetClass
    {
       
        
        
        private TcpListener _tcpListener;
        private bool _isRunning;

        public void Start(string ipAdress, int port)
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(ipAdress), port);
                _tcpListener.Start();
                _isRunning = true;
                MessageBox.Show($@"start: ip {ipAdress} port {port}");

                while (_isRunning)
                {
                    TcpClient _tcpClient = _tcpListener.AcceptTcpClient();
                    Thread _thread = new Thread(HandleClient); // вернусться!!!
                    _thread.Start(_tcpClient);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($@"хуйня {ex}");
            }

        }

        public void Stop() // остановка
        {
            if (_isRunning)
            {
                _tcpListener.Stop();
                _isRunning = false;
                MessageBox.Show("Stop хуйня");
            }
        }

        private void HandleClient(object objCkient)
        {
            TcpClient client = (TcpClient)objCkient;

            try
            {
                string clientAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                NetworkStream stream = client.GetStream();
                
                string welcomeMessage = "Welcome to the Telnet server! Type 'quit' to exit.";
                byte[] welcomeMessageBytes = Encoding.ASCII.GetBytes(welcomeMessage);
                stream.Write(welcomeMessageBytes, 0, welcomeMessageBytes.Length);

                while (_isRunning)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0 ,buffer.Length);
                    string command = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    
                    if (command.Trim().ToLower() == "quit")
                    {
                        // If the client sends the 'quit' command, close the connection.
                        break;
                    }
                    else
                    {
                        // Handle the received command (e.g., execute a specific action).
                        // Replace this with your own logic.
                        MessageBox.Show($@"Received command from {clientAddress}:{clientPort}: {command}");
                    }
                }
                client.Close();
                MessageBox.Show($"Client disconnected: {clientAddress}:{clientPort}");
            }
            catch (SocketException  e)
            {
                MessageBox.Show($"Error handling client connection: {e.Message}");

            }
        }
        
        
        
    }

}