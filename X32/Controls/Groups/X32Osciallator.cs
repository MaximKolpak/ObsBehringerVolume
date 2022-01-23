using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Osciallator : ConsoleControlGroup
    {
        X32FloatDial Level { get; set; }
        X32FloatDial Freq1 { get; set; }
        X32FloatDial Freq2 { get; set; }
        X32IntDial Select { get; set; }
        X32IntDial Type { get; set; }
        X32IntDial Destination { get; set; }

        public X32Osciallator()
        {
            Level = new X32FloatDial();
            Freq1 = new X32FloatDial();
            Freq2 = new X32FloatDial();
            Select = new X32IntDial();
            Type = new X32IntDial();
            Destination = new X32IntDial();

            Address = "/config/osd";

            Level.Address = "/level";
            Level.Parent = this;
            Freq1.Address = "/f1";
            Freq1.Parent = this;
            Freq2.Address = "/f2";
            Freq2.Parent = this;
            Select.Address = "/fsel";
            Select.Parent = this;
            Type.Address = "/type";
            Type.Parent = this;
            Destination.Address = "/dest";
            Destination.Parent = this;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Level.Address == address)
                return Level;
            else if (Freq1.Address == address)
                return Freq1;
            else if (Freq2.Address == address)
                return Freq2;
            else if (Select.Address == address)
                return Select;
            else if (Type.Address == address)
                return Type;
            else if (Destination.Address == address)
                return Destination;
            else
                return null;
        }
    }
}
