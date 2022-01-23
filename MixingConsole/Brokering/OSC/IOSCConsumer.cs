using MixingConsole.Protocol;
using System;
using OSC;


namespace MixingConsole.Brokering
{
    public interface IOSCConsumer : IBrokeredConsumer
    {
        void ReceiveFromProtocol(object sender, OSCPacket packet); 
    }
}
