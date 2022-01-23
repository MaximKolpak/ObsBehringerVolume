using System;
using System.Net;
using System.Net.Sockets;
using MixingConsole.Brokering;

namespace MixingConsole.Transport
{    
    public class UDPTransportLayer : TransportLayer, IBrokeredTransport
    {        
        private IPEndPoint Endpoint;
        private UdpClient Client;
        public IBroker Broker { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        
        public override void Connect()
        {
            Client = new UdpClient();
            Endpoint = new IPEndPoint(IPAddress, Port);            

            Client.Connect(Endpoint);
            Client.BeginReceive(new AsyncCallback(UDPPacketReceived), null); 
        }        

        public override void Disconnect()
        {
            return;
        }
        
        public override void SendPacket(object sender, byte[] packet)
        {
            if (Client != null && packet != null)
            {
                if (packet.Length > 0)
                {
                    Client.Send(packet, packet.Length);
                }
            }
        }

        public void ReceiveFromBroker(object sender, byte[] bytes)
        {
            SendPacket(sender, bytes);
        }

        private void SendToBroker(byte[] receivedBytes)
        {
            if (Broker != null)
                Broker.ReceiveFromTransport(this, receivedBytes);
        }

        private void UDPPacketReceived(IAsyncResult ar)
        {
            try
            {
                byte[] receivedBytes = Client.EndReceive(ar, ref Endpoint);
                SendToBroker(receivedBytes);
                Client.BeginReceive(new AsyncCallback(UDPPacketReceived), null);
            }
            catch
            {
            }
            
        }
                
        private void UDPPacketSent(IAsyncResult ar)
        {
            Client.EndSend(ar);
        }        
        
    }

}
