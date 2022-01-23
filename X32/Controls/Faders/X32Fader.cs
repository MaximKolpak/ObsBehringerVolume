using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSC;

namespace Behringer.X32.Controls
{
    public class X32Fader : ConsoleFader, IX32Control
    {      
        public const float X32Unity = ConsoleFader.FaderUnity;
        public const float X32Infinity = ConsoleFader.FaderInfinity;        

        public virtual OSCPacket ToOSCPacket()
        {
            return OSCConsoleConverter.ControlToOSCPacket(this, this.Value);
        }

    }
}
