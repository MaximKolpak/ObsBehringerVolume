using System;

namespace MixingConsole.Transport
{
    public interface ITransportLayer
    {
        void Connect();
        void Disconnect();
        void SendPacket(object sender, byte[] packet);
    }
}
