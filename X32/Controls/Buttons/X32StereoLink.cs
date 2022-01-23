using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSC;

namespace Behringer.X32.Controls
{
    public class X32StereoLink : X32ToggleButton, IX32Control
    {
      public X32StereoLink()
        {
            Address = "/mix/st";
        }

        private string FindAddressPair()
        {
            string pair = "/";

            if (Parent.Id % 2 != 0)
                pair += Parent.Id + "-" + (int)(Parent.Id + 1);
            else
                pair += (int)(Parent.Id - 1) + "-" + Parent.Id;

            return pair;
        }

        public virtual OSCPacket LinkChannels()
        {
            string linkAddress = "/config/chlink" + FindAddressPair();
            return OSCConsoleConverter.ControlToOSCPacket(this, linkAddress, (int)this.Value);
        }

    }
}
