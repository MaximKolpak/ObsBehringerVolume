using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixingConsole.Protocol;

namespace Behringer.X32.Controls
{ 
    public class X32MuteButton : X32ToggleButton, IX32Control
    {
        public X32MuteButton()
        {
            Address = "/mix/on";
            Value = X32OnOff.On;
        }

    }
}
