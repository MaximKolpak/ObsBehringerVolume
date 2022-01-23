using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32SoloConfig : ConsoleControlGroup
    {
        public X32FloatDial Level { get; set; }
        public X32IntDial Source { get; set; }
        public X32FloatDial SourceTrim { get; set; }
        public X32IntDial  ChannelMode { get; set; }
        public X32IntDial BusMode { get; set; }
        public X32IntDial DcaMode { get; set; }
        public X32IntDial Exclusive { get; set; }
        public X32IntDial FollowSelect { get; set; }
        public X32IntDial FollowSolo { get; set; }
        public X32FloatDial DimAtten { get; set; }
        public X32IntDial Dim { get; set; }
        public X32IntDial Mono { get; set; }
        public X32IntDial Delay { get; set; }
        public X32FloatDial DelayTime { get; set; }
        public X32IntDial MasterControl { get; set; }
        public X32IntDial Mute { get; set; }
        public X32IntDial DimPFL { get; set; }
        
        public X32SoloConfig ()
	    {
            Level = new X32FloatDial();
            Source = new X32IntDial();
            SourceTrim = new X32FloatDial();
            ChannelMode = new X32IntDial();
            BusMode = new X32IntDial();
            DcaMode = new X32IntDial();
            Exclusive = new X32IntDial();
            FollowSelect = new X32IntDial();
            FollowSolo = new X32IntDial();
            DimAtten = new X32FloatDial();
            Dim = new X32IntDial();
            Mono = new X32IntDial();
            Delay = new X32IntDial();
            DelayTime = new X32FloatDial();
            MasterControl = new X32IntDial();
            Mute = new X32IntDial();
            DimPFL = new X32IntDial();

            Address = "/config/solo";

            Level.Address = "/level";
            Level.Parent = this;
            Source.Address = "/source";
            Source.Parent = this;
            SourceTrim.Address = "/sourcetrm";
            SourceTrim.Parent = this;
            ChannelMode.Address = "/chmode";
            ChannelMode.Parent = this;
            BusMode.Address = "/busmode";
            BusMode.Parent = this;
            DcaMode.Address = "/dcamode";
            DcaMode.Parent = this;
            Exclusive.Address = "/exclusive";
            Exclusive.Parent = this;
            FollowSelect.Address = "/followsel";
            FollowSelect.Parent = this;
            FollowSolo.Address = "/followsolo";
            FollowSolo.Parent = this;
            DimAtten.Address = "/dimatt";
            DimAtten.Parent = this;
            Dim.Address = "/dim";
            Dim.Parent = this;
            Mono.Address = "/mono";
            Mono.Parent = this;
            Delay.Address = "/delay";
            Delay.Parent = this;
            DelayTime.Address = "/delaytime";
            DelayTime.Parent = this;
            MasterControl.Address = "/masterctrl";
            MasterControl.Parent = this;
            Mute.Address = "/mute";
            Mute.Parent = this;
            DimPFL.Address = "/dimpfl";
            DimPFL.Parent = this;
	    }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Level.Address == address)
                return Level;
            else if (Source.Address == address)
                return Source;
            else if (SourceTrim.Address == address)
                return SourceTrim;
            else if (ChannelMode.Address == address)
                return ChannelMode;
            else if (BusMode.Address == address)
                return BusMode;
            else if (DcaMode.Address == address)
                return DcaMode;
            else if (Exclusive.Address == address)
                return Exclusive;
            else if (FollowSelect.Address == address)
                return FollowSelect;
            else if (FollowSolo.Address == address)
                return FollowSolo;
            else if (DimAtten.Address == address)
                return DimAtten;
            else if (Dim.Address == address)
                return Dim;
            else if (Mono.Address == address)
                return Dim;
            else if (Delay.Address == address)
                return Delay;
            else if (DelayTime.Address == address)
                return DelayTime;
            else if (MasterControl.Address == address)
                return MasterControl;
            else if (Mute.Address == address)
                return Mute;
            else if (DimPFL.Address == address)
                return DimPFL;
            else
                return null;
        }
    }
}
