using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32DcaStrip : ConsoleControlGroup
    {
        public X32MuteButton Mute { get; set; }
        public X32Fader Fader { get; set; }
        public X32InputConfig Config { get; set; }

        public X32DcaStrip()
        {
            Mute = new X32MuteButton();
            Fader = new X32Fader();
            Config = new X32InputConfig();
        }
        
        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Mute.Address == address)
                return Mute;
            else if (Fader.Address == address)
                return Fader;
            else if (Config.Address == address)
                return Config;
            else
                return null;
        }
    }
}
