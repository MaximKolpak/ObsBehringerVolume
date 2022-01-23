using MixingConsole.Controls;
using System;

namespace Behringer.X32.Controls
{
    public class X32HeadAmp : ConsoleControlGroup
    {
        public X32FloatDial Gain { get; set; }
        public X32IntDial Phantom { get; set; }

        public X32HeadAmp ()
	    {
            Gain = new X32FloatDial();
            Phantom = new X32IntDial();

            Gain.Address = "/gain";
            Gain.Parent = this;
            
            Phantom.Address = "/phantom";
            Phantom.Parent = this;            
	    }
        
        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Gain.Address == address)
                return Gain;
            else if (Phantom.Address == address)
                return Phantom;
            else
                return null;

        }
    }
}
