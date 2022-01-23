using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Output : ConsoleControlGroup
    {
        public X32IntDial Source { get; set; }
        public X32IntDial Position { get; set; }

        public X32Output()
        {
            Source = new X32IntDial();
            Position = new X32IntDial();

            Source.Address = "/src";
            Source.Parent = this;
            
            Position.Address = "/pos";
            Position.Parent = this;
            
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Source.Address == address)
                return Source;
            else if (Position.Address == address)
                return Position;
            else
                return null;	    
        }
    }
}
