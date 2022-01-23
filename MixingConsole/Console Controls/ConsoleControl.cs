using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingConsole.Controls
{
    public class ConsoleControl : IConsoleControl
    {
        private string _Address;

        public ConsoleControl Parent;
        public string Address 
        {
            get
            {
                if (Parent != null && Parent is ConsoleControl)
                    return Parent.Address + _Address;
                else
                    return _Address;
            }

            set
            {
                _Address = value;
            }
        }
        public int Id { get; set; }
        public object Tag { get; set; }

        public ConsoleControl()
        {
            Parent = null;
            Address = this.ToString();
            Id = 0;
            Tag = null;
        }

    }
}
