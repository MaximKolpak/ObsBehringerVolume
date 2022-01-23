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
    public class X32ToggleButton : ConsoleButton, IX32Control
    {
        public new X32OnOff Value = X32OnOff.Off;

        public override void Toggle()
        {
            if (Value == X32OnOff.Off)
                Value = X32OnOff.On;
            else
                Value = X32OnOff.Off;
        }

        public virtual OSCPacket ToOSCPacket()
        {
            return OSCConsoleConverter.ControlToOSCPacket(this, (int)this.Value);
        }
    }
}
