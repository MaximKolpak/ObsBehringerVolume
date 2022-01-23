using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSC;

namespace Behringer.X32
{
    public class X32Packet : OSCPacket
    {
        /// <summary>
        /// Assign the values of an OSC packet to this packet. Internal values can be assigned/adjusted based on OSC packet information
        /// </summary>
        /// <param name="packet"></param>
        public virtual void Assign(OSCPacket packet)
        {
            return;
        }
    }
}
