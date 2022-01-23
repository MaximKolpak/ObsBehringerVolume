using System;

namespace MixingConsole.Brokering
{
    public interface IBroker
    {
        void ReceiveFromTransport(object sender, byte[] bytes);
        void ReceiveFromProtocol(object sender, byte[] bytes);
        void ReceiveFromTranslator(object sender, byte[] bytes);
    }
}
