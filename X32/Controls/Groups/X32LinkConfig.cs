using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32LinkConfig : ConsoleControlGroup
    {
        public X32IntDial HeadAmpDelay { get; set; }
        public X32IntDial Eq { get; set; }
        public X32IntDial Dynamics { get; set; }
        public X32IntDial FaderMute { get; set; }

        public X32LinkConfig ()
	    {
            HeadAmpDelay = new X32IntDial();
            Eq = new X32IntDial();
            Dynamics = new X32IntDial();
            FaderMute = new X32IntDial();

            Address = "/config/linkcfg";
            
            HeadAmpDelay.Address = "/hadly";
            HeadAmpDelay.Parent = this;
            Eq.Address = "/eq";
            Eq.Parent = this;
            Dynamics.Address = "/dyn";
            Dynamics.Parent = this;
            FaderMute.Address = "/fdrmute";
            FaderMute.Parent = this;
	    }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (HeadAmpDelay.Address == address)
                return HeadAmpDelay;
            else if (Eq.Address == address)
                return Eq;
            else if (Dynamics.Address == address)
                return Dynamics;
            else if (FaderMute.Address == address)
                return FaderMute;
            else
                return null;
        }
    }
}
