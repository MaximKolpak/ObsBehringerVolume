using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using OSC;


namespace Behringer.X32.Controls
{
    public abstract class X32Control : ConsoleControl, IX32Control
    {
        public abstract OSCPacket ToOSCPacket();        
    }
}
