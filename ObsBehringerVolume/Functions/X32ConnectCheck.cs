using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObsBehringerVolume.Functions
{
    internal class X32ConnectCheck
    {
        public event EventHandler<bool> Connect;

        private byte[] _buffer = new byte[256]; //Buffer
        private Byte[] _sendBytes;
        private int _sleep;

        private Socket _socket;

        public X32ConnectCheck(string ipAdress, int Port, int Timeout = 1000, int Sleep = 3000)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                ReceiveTimeout = Timeout
            };
            _sleep = Sleep;

            IPAddress mixerAddr = IPAddress.Parse(ipAdress);
            IPEndPoint endPoint = new IPEndPoint(mixerAddr, Port);
            _sendBytes = Encoding.ASCII.GetBytes("/status");
            Task.Run(() => { CheckConnectMixer(endPoint); });
        }

        private void CheckConnectMixer(IPEndPoint endPoint)
        {
            while (true)
            {
                _socket.SendTo(_sendBytes, endPoint);
                try
                {
                    _socket.Receive(_buffer);
                    Connect?.Invoke(this, true);
                    string recive = Encoding.UTF8.GetString(_buffer);
                }
                catch(Exception ex)
                {
                    Connect?.Invoke(this, false);
                    Console.WriteLine($"Error : {ex.Message}");
                }
                Thread.Sleep(_sleep);
            }
        }
    }
}
