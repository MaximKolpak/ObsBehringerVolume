using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole.Controls
{
    public class ConsoleFloatDial : ConsoleDial
    {
        public float Value { get; set; }

        public int ToInt()
        {
            return (int)(Value * 100);
        }

    }
}
