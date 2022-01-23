using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32MonoConfig : ConsoleControlGroup
    {
        public X32IntDial Mode { get; set; }
        public X32IntDial Link { get; set; }

        public X32MonoConfig()
        {
            Mode = new X32IntDial();
            Link = new X32IntDial();

            Address = "/config/mono";

            Mode.Address = "/mode";
            Mode.Parent = this;
            Link.Address = "/link";
            Link.Parent = this;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Mode.Address == address)
                return Mode;
            else if (Link.Address == address)
                return Link;
            else
                return null;

        }
    }
}
