using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Insert : ConsoleControlGroup
    {
        public X32IntDial On { get; set; }
        public X32IntDial Position { get; set; }
        public X32IntDial Insert { get; set; }

        public X32Insert()
        {
            On = new X32IntDial();
            Position = new X32IntDial();
            Insert = new X32IntDial();
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (On.Address == address)
                return On;
            else if (Position.Address == address)
                return Position;
            else if (Insert.Address == address)
                return Insert;
            else
                return null;
        }
    }
}
