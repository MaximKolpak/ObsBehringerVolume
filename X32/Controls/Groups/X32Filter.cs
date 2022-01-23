using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32Filter : ConsoleControlGroup
    {
        public X32IntDial On;
        public X32IntDial Type;
        public X32FloatDial Freq;

        public X32Filter()
        {
            On = new X32IntDial();
            Type = new X32IntDial();
            Freq = new X32FloatDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            return null;
        }
    }
}
