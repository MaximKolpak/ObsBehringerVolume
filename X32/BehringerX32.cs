using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MixingConsole;

namespace BehringerX32
{
    public delegate void MessageReceivedDelegate(string msg);

    public class X32 : NetworkedMixingConsole
    {
        public event MessageReceivedDelegate OnMessageReceived;

        public const int X32PORT = 10023;
        
        private UdpClient X32UDPClient; 
        private IPEndPoint X32RemoteEndPoint;
        private UdpState X32UDPUpdateState;
        public string outdata;

        public X32()
        {
            
            X32RemoteEndPoint = new IPEndPoint(IPAddress.Any, X32PORT);
            X32UDPClient = new UdpClient(X32PORT);
            Protocol = new X32OSCProtocol();
        }

        private void SendMessage(string msg)
        {
            msg = msg + "\0";
            while (msg.Length % 4 != 0)
                msg = msg + "\0";
            if (msg != null)
            {
                byte[] udpBuffer = Encoding.ASCII.GetBytes(msg);
                if (X32UDPClient != null && udpBuffer != null)
                    try
                    {
                        X32UDPClient.Send(udpBuffer, udpBuffer.Length);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

            }
        }

        private void ReceiveMessage(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

            Byte[] receiveBytes = u.EndReceive(ar, ref e);
            string data = Encoding.ASCII.GetString(receiveBytes);
            
            RaiseOnMessageReceived(data);

        }

        private void RaiseOnMessageReceived(string data)
        {
            if (OnMessageReceived != null && data != null)
                OnMessageReceived(data);
        }

        public override bool Connect()
        {
            X32UDPUpdateState = new UdpState();
            X32UDPUpdateState.e = X32RemoteEndPoint;
            X32UDPUpdateState.u = X32UDPClient;
            X32UDPClient.BeginReceive(new AsyncCallback(ReceiveMessage), X32UDPUpdateState);  

            X32UDPClient.Connect(ipAddress, port);            
            
            return true;
        }

        public bool Connect(IPAddress ipAddress, int Port)
        {
            // EXAMPLE:  IPAddress address = new IPAddress(new byte[] { 192, 168, 20, 11 });

            this.ipAddress = ipAddress;
            this.port = Port;
            return Connect();
        }

        public bool Connect(string ipAddress, int Port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = Port;
            return Connect();
        }

        public override bool Disconnect()
        {
            return true;
        }

        public void SendOSCMessage(string msg)
        {
            SendMessage(msg);   
        }
    }
}
