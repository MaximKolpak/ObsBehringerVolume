
using System;
using MixingConsole.Controls;


namespace Behringer.X32.Controls
{
    public class X32Compressor : ConsoleControlGroup
    {
        public X32ToggleButton Active;
        public X32IntDial Mode;
        public X32IntDial Detect;
        public X32IntDial Envelope;
        public X32FloatDial Threshhold;
        public X32IntDial Ratio;
        public X32FloatDial Knee;
        public X32FloatDial Gain;
        public X32FloatDial Attack;
        public X32FloatDial Hold;
        public X32FloatDial Release;
        public X32FloatDial Position;
        public X32IntDial KeySource;
        public X32Filter Filter;

        public X32Compressor()
        {
            Active = new X32ToggleButton();
            Mode = new X32IntDial();
            Detect = new X32IntDial();
            Envelope = new X32IntDial();
            Threshhold = new X32FloatDial();
            Ratio = new X32IntDial();
            Knee = new X32FloatDial();
            Gain = new X32FloatDial();
            Attack = new X32FloatDial();
            Hold = new X32FloatDial();
            Release = new X32FloatDial();
            Position = new X32FloatDial();
            KeySource = new X32IntDial();
            Filter = new X32Filter();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Active.Address == address)
                return Active;
            else if (Mode.Address == address)
                return Mode;
            else if (Detect.Address == address)
                return Detect;
            else if (Envelope.Address == address)
                return Envelope;
            else if (Threshhold.Address == address)
                return Threshhold;
            else if (Ratio.Address == address)
                return Ratio;
            else if (Knee.Address == address)
                return Knee;
            else if (Gain.Address == address)
                return Gain;
            else if (Attack.Address == address)
                return Attack;
            else if (Hold.Address == address)
                return Hold;
            else if (Release.Address == address)
                return Release;
            else if (Position.Address == address)
                return Position;
            else if (KeySource.Address == address)
                return KeySource;
            else
                return Filter.FindControlByAddress(address);
        }
    }
}
