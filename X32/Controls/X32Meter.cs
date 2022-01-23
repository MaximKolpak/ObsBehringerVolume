using OSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Meter : X32FloatDial
    {

        public float ValueFromMeter1(OSCPacket p)
        {
            byte[] bytes = ((OSCBlobArg)p.Arguments[0]).value;
            int offset = (Id - 1) * 4;
            Value = BitConverter.ToSingle(new byte[] { bytes[offset], bytes[offset + 1], bytes[offset + 2], bytes[offset + 3] }, 0);
            return Value;
        }
    }
}
