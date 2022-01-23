using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MixingConsole.Protocol;
using OSC;

namespace Behringer.X32
{
    public class RemoteOSCServer
    {
        public string Status { get; set; }
        public IPAddress IPAddress { get; set; }
        public string Name { get; set; }

        public RemoteOSCServer()
        {
            
        }

        public RemoteOSCServer(OSCPacket packet)
        {
            Status = ((OSCStringArg)(packet).Arguments[0]).value;
            IPAddress = IPAddress.Parse(((OSCStringArg)(packet).Arguments[1]).value);
            Name = ((OSCStringArg)(packet).Arguments[2]).value; 
        }
    }
}
