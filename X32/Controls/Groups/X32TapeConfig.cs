using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32TapeConfig : ConsoleControlGroup
    {
        X32FloatDial GainL { get; set; }
        X32FloatDial GainR { get; set; }
        X32IntDial AutoPlay { get; set; }

        public X32TapeConfig()
        {
            GainL = new X32FloatDial();
            GainR = new X32FloatDial();
            AutoPlay = new X32IntDial();

            Address = "/config/tape";

            GainL.Address = "/gainL";
            GainL.Parent = this;
            GainR.Address = "/gainR";
            GainR.Parent = this;
            AutoPlay.Address = "/autoplay";
            AutoPlay.Parent = this;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (GainL.Address == address)
                return GainL;
            else if (GainR.Address == address)
                return GainR;
            else if (AutoPlay.Address == address)
                return AutoPlay;
            else
                return null;                 
        }
    }
}
