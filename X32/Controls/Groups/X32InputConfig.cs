using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32InputConfig : ConsoleControlGroup
    {
        public X32StringField Name { get; set; }
        public X32IntDial Icon { get; set; }
        public X32IntDial Color { get; set; }        

        public X32InputConfig()
        {
            Name = new X32StringField();
            Icon = new X32IntDial();
            Color = new X32IntDial();            
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Name.Address == address)
                return Name;
            else if (Icon.Address == address)
                return Icon;
            else if (Color.Address == address)
                return Color;            
            else
                return null;
        }

    }

}
