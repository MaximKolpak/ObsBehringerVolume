using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32MatrixMix : ConsoleControlGroup
    {
        public X32MuteButton Mute { get; set; }
        public X32Fader Fader { get; set; }
        public X32PanDial Pan { get; set; }
        //public X32TapPoint TapPoint { get; set; }

        public X32MatrixMix()
        {
            Mute = new X32MuteButton();
            Fader = new X32Fader();
            Pan = new X32PanDial();
            //TapPoint = new X32TapPoint();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Mute.Address == address)
                return Mute;
            else if (Fader.Address == address)
                return Fader;
            else if (Pan.Address == address)
                return Pan;
            else
                return null;
        }
    }
}
