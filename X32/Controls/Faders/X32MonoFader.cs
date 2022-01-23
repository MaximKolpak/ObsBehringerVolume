using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32MonoFader : X32Fader, IX32Control
    {
        public X32MonoFader()
        {
            Address = "/mix/mlevel";
        }        
    }
}
