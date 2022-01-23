using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32PreAmpDelay : ConsoleControlGroup
    {
        public X32IntDial On { get; set; }
        public X32FloatDial Time { get; set;}

        public X32PreAmpDelay()
        {
            On = new X32IntDial();
            Time = new X32FloatDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (On.Address == address)
                return On;
            else if (Time.Address == address)
                return Time;
            else
                return null;
        }
    }
}
