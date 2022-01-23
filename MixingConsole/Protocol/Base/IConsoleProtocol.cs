using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixingConsole.Controls;
using MixingConsole.Transport;

namespace MixingConsole.Protocol
{
    public interface IConsoleProtocol
    {
        void ParseNetworkPacket(byte[] packet);        
    }
}
