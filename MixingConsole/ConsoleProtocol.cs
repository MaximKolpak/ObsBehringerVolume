using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole
{
    public abstract class ConsoleProtocol : IConsoleProtocol
    {
        public abstract void ParseNetworkPacket(object Packet);
    }
}
