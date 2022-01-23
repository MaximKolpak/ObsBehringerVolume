using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32MainOutput : X32Output
    {
        public X32PreAmpDelay Delay { get; set; }

        public X32MainOutput()
        {
            Delay = new X32PreAmpDelay();

            Source.Address = "/src";
            Source.Parent = this;
            
            Position.Address = "/pos";
            Position.Parent = this;
            
            Delay.Address = "/delay";
            Delay.Parent = this;
            
            Delay.On.Address = "/on";
            Delay.On.Parent = Delay;
            
            Delay.Time.Address = "/time";
            Delay.Time.Parent = Delay;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Delay.Address == address)
                return Delay;
            else
                return base.FindControlByAddress(address);
        }
    }
}
