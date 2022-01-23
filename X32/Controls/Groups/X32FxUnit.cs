using System;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32FxUnit : ConsoleControlGroup
    {
        public X32IntDial Type { get; set; }
        public X32IntDial SourceLeft { get; set; }
        public X32IntDial SourceRight { get; set; }
        public X32FloatDial[] Params { get; set; }

        public X32FxUnit()
        {
            Type = new X32IntDial();
            SourceLeft = new X32IntDial();
            SourceRight = new X32IntDial();
            Params = new X32FloatDial[X32.X32MaxFxParams];

            Address = "/fx";
            
            Type.Address = "/type";
            Type.Parent = this;
            
            SourceLeft.Address = "/source/l";
            SourceLeft.Parent = this;            

            SourceRight.Address = "/source/r";
            SourceRight.Parent = this;            

            for (int p = 0; p < X32.X32MaxFxParams; p++)
            {
                X32FloatDial param = new X32FloatDial();
                param.Address = "/par/" + (p + 1).ToString("D2");
                param.Parent = this;
                
                Params[p] = param;
            }            
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Type.Address == address)
                return Type;
            else if (SourceLeft.Address == address)
                return SourceLeft;
            else if (SourceRight.Address == address)
                return SourceRight;

            for (int i = 0; i < Params.Length; i++)
              if (Params[i].Address == address)
                  return Params[i];

            return null;
        }
    }
}
