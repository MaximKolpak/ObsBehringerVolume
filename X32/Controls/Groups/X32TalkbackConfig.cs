using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32TalkbackConfig : ConsoleControlGroup
    {
        public X32IntDial Enable { get; set; }
        public X32IntDial Source { get; set; }
        public X32FloatDial LevelA { get; set; }
        public X32IntDial DimA { get; set; }
        public X32IntDial LatchA { get; set; }
        public X32IntDial DestinationA { get; set; }
        public X32FloatDial LevelB { get; set; }
        public X32IntDial DimB { get; set; }
        public X32IntDial LatchB { get; set; }
        public X32IntDial DestinationB { get; set; }

        public X32TalkbackConfig()
        {
            Enable = new X32IntDial();
            Source = new X32IntDial();
            LevelA = new X32FloatDial();
            DimA = new X32IntDial();
            LatchA = new X32IntDial();
            DestinationA = new X32IntDial();
            LevelB = new X32FloatDial();
            DimB = new X32IntDial();
            LatchB = new X32IntDial();
            DestinationB = new X32IntDial();

            Address = "/config/talk";

            Enable.Address = "/enable";
            Enable.Parent = this;
            Source.Address = "/address";
            Source.Parent = this;
            LevelA.Address = "/A/level";
            LevelA.Parent = this;
            DimA.Address = "/A/dim";
            DimA.Parent = this;
            LatchA.Address = "/A/latch";
            LatchA.Parent = this;
            DestinationA.Address = "/A/destmap";
            DestinationA.Parent = this;
            LevelB.Address = "/B/level";
            LevelB.Parent = this;
            DimB.Address = "/B/dim";
            DimB.Parent = this;
            LatchB.Address = "/B/latch";
            LatchB.Parent = this;
            DestinationB.Address = "/B/destmap";
            DestinationB.Parent = this;
        }


        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Enable.Address == address)
                return Enable;
            else if (Source.Address == address)
                return Source;
            else if (LevelA.Address == address)
                return LevelA;
            else if (DimA.Address == address)
                return DimA;
            else if (LatchA.Address == address)
                return LatchA;
            else if (DestinationA.Address == address)
                return DestinationA;
            else if (LevelB.Address == address)
                return LevelB;
            else if (DimB.Address == address)
                return DimB;
            else if (LatchB.Address == address)
                return LatchB;
            else if (DestinationB.Address == address)
                return DestinationB;
            else
                return null;
        }
    }
}
