using MixingConsole.Controls;
using MixingConsole.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public enum X32TapType { InputLC = 0, PreEq = 1, PostEq = 2, PreFader = 3, PostFader = 4, Subgroup = 5 };

    public class X32TapPoint : X32IntDial, IX32Control
    {
        public new X32TapType Value = X32TapType.PreEq;

    }
}
