using System;

namespace MixingConsole.Brokering
{
    public interface IBrokeredTransport
    {      
        void ReceiveFromBroker(object sender, byte[] bytes);        
    }
}
