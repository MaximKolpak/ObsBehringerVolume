using System;

namespace MixingConsole.Transport
{ 
    public abstract class TransportLayer : ITransportLayer
    {
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract void SendPacket(object sender, byte[] packet);             
    }
}
