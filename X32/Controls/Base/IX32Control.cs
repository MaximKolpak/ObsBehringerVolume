using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSC;

namespace Behringer.X32.Controls
{
    public interface IX32Control
    {
        OSCPacket ToOSCPacket();
    }
}
