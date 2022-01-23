using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixingConsole.Controls;
using MixingConsole.Transport;

namespace MixingConsole.Protocol
{
    public abstract class ConsoleProtocol : IConsoleProtocol
    {
        public abstract void ParseNetworkPacket(byte[] packet);        
    }
}
