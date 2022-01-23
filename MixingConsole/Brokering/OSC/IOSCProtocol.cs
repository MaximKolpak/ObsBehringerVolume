using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSC;

namespace MixingConsole.Brokering
{
    interface IOSCProtocol : IBrokeredProtocol
    {
        void ReceiveFromConsumer(object sender, OSCPacket bytes);
    }
}
