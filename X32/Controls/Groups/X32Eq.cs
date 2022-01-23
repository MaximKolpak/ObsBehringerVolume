using MixingConsole.Controls;
using System;
using System.Collections;


namespace Behringer.X32.Controls
{
    public class X32Eq : ConsoleControlGroup
    {
        public X32ToggleButton Active { get; set; }
        public X32EQBand[] Band { get; set; }

        public X32Eq(int numBands)
        {
            Active = new X32ToggleButton();
            Band = new X32EQBand[numBands];

            for (int i = 0; i < numBands; i++)
            {
                Band[i] = new X32EQBand();
            }
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
