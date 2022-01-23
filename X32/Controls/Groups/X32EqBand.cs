using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public enum X32EQType { LowCut = 0, LowShelf = 1, PEQ = 2, VEQ = 3, HiShelf = 4, HiCut = 5 };

    public class X32EQBand : ConsoleEQBand
    {
        public X32EQType Type { get; set; }
        public X32EqFreqDial Freq { get; set; }
        public X32EqGainDial Gain { get; set; }
        public X32EqQDial Q { get; set; }

        public X32EQBand()
        {
            Type = X32EQType.PEQ;
            Freq = new X32EqFreqDial();
            Gain = new X32EqGainDial();
            Q = new X32EqQDial();

        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Freq.Address == address)
                return Freq;
            else if (Gain.Address == address)
                return Gain;
            else if (Q.Address == address)
                return Q;
            return null;
        }
    }
}
