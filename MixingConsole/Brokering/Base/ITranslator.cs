using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole.Brokering
{
    public interface ITranslator
    {
        void ReceiveFromBroker(object sender, byte[] bytes);
    }
}
