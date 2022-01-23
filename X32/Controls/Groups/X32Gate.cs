using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Gate : ConsoleControlGroup
    {
        public X32IntDial On { get; set; }
        public X32IntDial Mode { get; set; }
        public X32FloatDial Threshold { get; set; }
        public X32FloatDial Range { get; set; }
        public X32FloatDial Attack { get; set; }
        public X32FloatDial Hold { get; set; }
        public X32FloatDial Release { get; set; }
        public X32IntDial KeySource { get; set; }
        public X32Filter Filter {get; set; }

        public X32Gate()
        {
            On = new X32IntDial();
            Mode = new X32IntDial();
            Threshold = new X32FloatDial();
            Range = new X32FloatDial();
            Attack = new X32FloatDial();
            Hold = new X32FloatDial();
            Release = new X32FloatDial();
            KeySource = new X32IntDial();
            Filter = new X32Filter();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (On.Address == address)
                return On;
            else if (Mode.Address == address)
                return Mode;
            else if (Threshold.Address == address)
                return Threshold;
            else if (Range.Address == address)
                return Range;
            else if (Attack.Address == address)
                return Attack;
            else if (Hold.Address == address)
                return Hold;
            else if (Release.Address == address)
                return Release;
            else if (KeySource.Address == address)
                return KeySource;
            else
                return Filter.FindControlByAddress(address);
        }
    }
}
