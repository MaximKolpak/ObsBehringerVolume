using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32ChannelConfig : X32InputConfig
    {
        public X32IntDial Source { get; set; }

        public X32ChannelConfig()
        {
            Source = new X32IntDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Source.Address == address)
                return Source;
            else
                return base.FindControlByAddress(address);
        }

    }

}
