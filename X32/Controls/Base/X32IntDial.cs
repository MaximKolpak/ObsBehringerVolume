using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using OSC;

namespace Behringer.X32.Controls
{
    public class X32IntDial : ConsoleIntDial, IX32Control
    {
        public virtual OSCPacket ToOSCPacket()
        {
            return OSCConsoleConverter.ControlToOSCPacket(this, Value);
        }
    }
}
