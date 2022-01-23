using System;
using MixingConsole.Controls;


namespace Behringer.X32.Controls
{
    public class X32PreAmp : ConsoleControlGroup
    {
        public X32FloatDial Trim { get; set; }
        public X32IntDial Invert { get; set; }

        public X32PreAmp()
        {
            Trim = new X32FloatDial();
            Invert = new X32IntDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Trim.Address == address)
                return Trim;
            else if (Invert.Address == address)
                return Invert;            
            else
                return null;
        }
    }
}
