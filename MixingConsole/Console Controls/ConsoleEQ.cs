using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole.Controls
{
    public class ConsoleEQ : ConsoleControlGroup
    {
        public List<ConsoleEQBand> Band { get; set; }

        public override ConsoleControl FindControlByAddress(string address)
        {
            ConsoleControl c = null;

            foreach (var band in Band)
            {
                if (band.Address == address)
                {
                    c = band;
                    break;
                }
            }

            return c;
        }

    }

}
