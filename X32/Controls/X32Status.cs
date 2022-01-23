using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Status : ConsoleControlGroup
    {
        public X32IntDial ChannelLayer { get; set; }
        public X32IntDial GroupLayer { get; set; }
        public X32ToggleButton SendsOnFader { get; set; }
        public X32Screen LCD { get; set; }
        public X32IntDial EqBand { get; set; }
        public X32IntDial RTAEqPre { get; set;}
        public X32IntDial RTAModeEq { get; set; }
        public X32IntDial RTASource { get; set; }
        public X32IntDial Solo { get; set; }
        public List<X32IntDial> Solos { get; set; }

        public X32Status()
        {
            ChannelLayer = new X32IntDial();
            GroupLayer = new X32IntDial();
            SendsOnFader = new X32ToggleButton();
            EqBand = new X32IntDial();
            RTAEqPre = new X32IntDial();
            RTAModeEq = new X32IntDial();
            RTASource = new X32IntDial();
            Solo = new X32IntDial();
            Solos = new List<X32IntDial>();

            LCD = new X32Screen();

            Address = "/~stat";

            ChannelLayer.Address = "/chfaderbank";
            ChannelLayer.Parent = this;

            GroupLayer.Address = "/grpfaderbank";
            GroupLayer.Parent = this;

            SendsOnFader.Address = "/sendsonfader";
            SendsOnFader.Parent = this;

            LCD.Address = "/screen";
            LCD.Parent = this;

            EqBand.Address = "/eqband";
            EqBand.Parent = this;

            RTAEqPre.Address = "/rtaeqpre";
            RTAEqPre.Parent = this;

            RTAModeEq.Address = "/rtamodeeq";
            RTAModeEq.Parent = this;

            RTASource.Address = "/rtasource";
            RTASource.Parent = this;

            Solo.Address = "/solo";
            Solo.Parent = this;
                        
            for (int i = 0; i < X32.X32MaxSolos; i++)
            {
                X32IntDial s = new X32IntDial();
                s.Address = "/solosw/" + (i + 1).ToString("D2");
                s.Parent = this;
                Solos.Add(s);
            }
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (ChannelLayer.Address == address)
                return ChannelLayer;
            else if (GroupLayer.Address == address)
                return GroupLayer;
            else if (SendsOnFader.Address == address)
                return SendsOnFader;
            else if (LCD.Address == address)
                return LCD;
            else if (EqBand.Address == address)
                return EqBand;
            else if (RTAEqPre.Address == address)
                return RTAEqPre;
            else if (RTAModeEq.Address == address)
                return RTAModeEq;
            else if (RTASource.Address == address)
                return RTASource;
            else if (Solo.Address == address)
                return Solo;
            else
                return LCD.FindControlByAddress(address);
        }
    }
}
