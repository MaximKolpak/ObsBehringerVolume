using System;
using MixingConsole.Controls;


namespace Behringer.X32.Controls
{
    public class X32ChannelPreAmp : X32PreAmp
    {
        public X32IntDial Hpf { get; set; }
        public X32IntDial Slope { get; set; }
        public X32FloatDial HpfFreq { get; set; }

        public X32ChannelPreAmp()
        {
            Hpf = new X32IntDial();
            Slope = new X32IntDial();
            HpfFreq = new X32FloatDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Hpf.Address == address)
                return Hpf;
            else if (Slope.Address == address)
                return Slope;
            else if (HpfFreq.Address == address)
                return HpfFreq;
            else
                return base.FindControlByAddress(address);
        }
    }

}
