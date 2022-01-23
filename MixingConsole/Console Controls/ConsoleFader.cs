using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole.Controls
{
    public class ConsoleFader : ConsoleFloatDial
    {
        public const float FaderUnity = 0.75f;
        public const float FaderInfinity = 0.00f;        

        public virtual void Unity()
        {
            Value = FaderUnity;
        }

        public virtual void Infinity()
        {
            Value = 0;
        }
        
        public virtual void Assign(byte[] values)
        {
            this.Value = BitConverter.ToSingle(values, 0);
        }

        public virtual void Assign(int value)
        {
            this.Value = value;
        }

        public virtual void Assign(long value)
        {
            this.Value = value;
        }    }
}
