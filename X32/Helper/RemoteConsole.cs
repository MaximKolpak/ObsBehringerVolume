using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixingConsole.Protocol;
using OSC;

namespace Behringer.X32
{
    public class RemoteConsole
    {
        public string ServerVersion { get; set; }
        public string ServerName { get; set; }
        public string ConsoleModel { get; set; }
        public string ConsoleVersion { get; set; }

        public RemoteConsole()
        {

        }

        public RemoteConsole(OSCPacket packet)
        {
            ServerVersion = ((OSCStringArg)(packet).Arguments[0]).value;
            ServerName = ((OSCStringArg)(packet).Arguments[1]).value;
            ConsoleModel = ((OSCStringArg)(packet).Arguments[2]).value;
            ConsoleVersion = ((OSCStringArg)(packet).Arguments[3]).value;
        }
    }
}
