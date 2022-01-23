using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32MonoButton : X32ToggleButton, IX32Control
    {
      public X32MonoButton()
        {
            Address = "/mix/mono";
        }
      
    }
}
