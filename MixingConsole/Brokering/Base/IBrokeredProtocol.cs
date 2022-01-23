using System;

namespace MixingConsole.Brokering
{
    public interface IBrokeredProtocol
    {
        void ReceiveFromBroker(object sender, byte[] bytes);
        void ReceiveFromConsumer(object sender, byte[] bytes);
    }
}
