using MixingConsole.Protocol;
using System;

namespace MixingConsole.Brokering
{
    public interface IBrokeredConsumer
    {
        void ReceiveFromProtocol(object sender, object packet);        
    }

}
