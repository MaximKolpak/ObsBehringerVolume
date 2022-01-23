using System;

namespace MixingConsole.Brokering
{
    public class Broker : IBroker
    {
        public IBrokeredTransport Transport { get; set; }
        public IBrokeredProtocol Protocol { get; set;}
        public ITranslator Translator { get; set; }

        public void ReceiveFromTransport(object sender, byte[] bytes)
        {
            if (Protocol != null)                                
              Protocol.ReceiveFromBroker(sender, bytes);
        }

        public void ReceiveFromProtocol(object sender, byte[] bytes)
        {
            if (Transport != null)
                Transport.ReceiveFromBroker(sender, bytes);
        }

        public void ReceiveFromTranslator(object sender, byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
