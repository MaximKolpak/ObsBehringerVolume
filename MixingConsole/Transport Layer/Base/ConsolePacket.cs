using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MixingConsole.Transport
{
    public class ConsolePacket
    {
        public byte[] Contents;

        public static ConsolePacket Package(byte[] packet)
        {
            ConsolePacket p = new ConsolePacket();
            p.Contents = packet;
            return p;
        }

        public static ConsolePacket Package(MemoryStream memStream)
        {
            ConsolePacket p = new ConsolePacket();
            p.Contents = memStream.ToArray();
            return p;
        }
    }
}
