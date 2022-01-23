using System;
using MixingConsole.Controls;
using MixingConsole.Transport;
using MixingConsole.Brokering;
using OSC;

namespace MixingConsole.Protocol
{    
    public class OSCProtocol : ConsoleProtocol, IOSCProtocol
    {
        public IBroker Broker { get; set; }
        public IOSCConsumer Consumer { get; set; }

        public override void ParseNetworkPacket(byte[] packet)
        {
            switch (packet[0])
            {
                case (byte)'/':  
                  ParseOSCPacket(packet);
                  break;
         
                case (byte)'#':          
                  ParseOSCBundle(packet);
                  break;
            }
        }

        protected void ParseOSCBundle(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        protected void ParseOSCPacket(byte[] bytes)
        {
            OSCConverter c = new OSCConverter();
            OSCPacket oscPacket = c.GetOSCPacket(bytes);
            SendToConsumer(oscPacket);
            return;
        }        

        public void ReceiveFromBroker(object sender, byte[] bytes)
        {
            ParseNetworkPacket(bytes);
        }

        protected void SendToConsumer(OSCPacket packet)
        {
            if (Consumer != null)
                Consumer.ReceiveFromProtocol(this, packet);
        }

        public void ReceiveFromConsumer(object sender, OSCPacket packet)
        {
            if (Broker != null)            
                Broker.ReceiveFromProtocol(this, packet.GetBytes());            
        }

        public void ReceiveFromConsumer(object sender, byte[] bytes)
        {
            throw new NotImplementedException();
        }

    }

}
