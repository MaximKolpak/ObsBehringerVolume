using Behringer.X32.Controls;
using MixingConsole.Console_Controls;
using MixingConsole.Protocol;
using System;
using OSC;

namespace Behringer.X32.Controls
{
    public class X32StringField : ConsoleStringField, IX32Control
    {
        public OSCPacket ToOSCPacket()
        {
            return OSCConsoleConverter.ControlToOSCPacket(this, Value);
        }
    }
}
