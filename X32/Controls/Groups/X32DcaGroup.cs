using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32DcaGroup : ConsoleControlGroup
    {
        public X32IntDial Dca { get; set; }
        public X32IntDial Mute { get; set; }

        public X32DcaGroup ()
        {
            Dca = new X32IntDial();
            Mute = new X32IntDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Dca.Address == address)
                return Dca;
            else if (Mute.Address == address)
                return Mute;
            else
                return null;
        }

    }

}
