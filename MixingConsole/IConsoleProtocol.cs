using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole
{
    interface IConsoleProtocol
    {
        void ParseNetworkPacket(object Packet);
    }
}
