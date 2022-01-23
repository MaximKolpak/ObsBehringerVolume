using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls 
{
    public class X32MixerConfig : ConsoleControlGroup
    {
        public List<X32ToggleButton> ChannelLink { get; set; }
        public List<X32ToggleButton> AuxLink { get; set; }
        public List<X32ToggleButton> FxLink { get; set; }
        public List<X32ToggleButton> BusLink { get; set; }
        public List<X32ToggleButton> MatrixLink { get; set; }
        public List<X32ToggleButton> Mute { get; set; }
        public X32LinkConfig LinkConfig { get; set; }
        public X32MonoConfig MonoConfig { get; set; }
        public X32SoloConfig SoloConfig { get; set; }
        public X32TalkbackConfig Talkback { get; set; }
        public X32Osciallator Osc { get; set; }
        public X32TapeConfig TapeConfig { get; set; }

        public X32MixerConfig()
        {
            ChannelLink = new List<X32ToggleButton>();
            AuxLink = new List<X32ToggleButton>();
            FxLink = new List<X32ToggleButton>();
            BusLink = new List<X32ToggleButton>();
            MatrixLink = new List<X32ToggleButton>();
            Mute = new List<X32ToggleButton>();
            LinkConfig = new X32LinkConfig();
            MonoConfig = new X32MonoConfig();
            SoloConfig = new X32SoloConfig();
            Talkback = new X32TalkbackConfig();
            Osc = new X32Osciallator();
            TapeConfig = new X32TapeConfig();
            CreateLinks(ChannelLink, "chlink", X32.X32MaxChannels);
            CreateLinks(AuxLink, "auxlink", X32.X32MaxAux);
            CreateLinks(FxLink, "fxlink", X32.X32MaxFxRtn);
            CreateLinks(BusLink, "buslink", X32.X32MaxBus);
            CreateLinks(MatrixLink, "mtxlink", X32.X32MaxMatrix);
            CreateMute(Mute, "mute", 6);
        }

        private void CreateMute(List<X32ToggleButton> list, string name, int num)
        {
            for (int i = 0; i < num; i++)
            {
                X32ToggleButton b = new X32ToggleButton();
                b.Address = "/config/" + name + "/" + (i + 1).ToString();
                b.Id = i;
                list.Add(b);
            }
        }

        private void CreateLinks(List<X32ToggleButton> list, string name, int num)
        {            
            for (int i = 0; i < num; i += 2)
            {
                X32ToggleButton b = new X32ToggleButton();                
                b.Address = "/config/" + name + "/" + (i + 1).ToString() + "-" + (i + 2).ToString();
                b.Id = i;
                list.Add(b);                
            }
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            ConsoleControl c;

            c = FindAddressFromList(ChannelLink, address);
            if (c == null)
            {
                c = FindAddressFromList(AuxLink, address);
                if (c == null)
                {
                    c = FindAddressFromList(FxLink, address);
                    if (c == null)
                    {
                        c = FindAddressFromList(BusLink, address);
                        if (c == null)
                        {
                            c = FindAddressFromList(MatrixLink, address);
                            if (c == null)
                            {
                                c = LinkConfig.FindControlByAddress(Address);
                                if (c == null)
                                {
                                    c = MonoConfig.FindControlByAddress(Address);
                                    if (c == null)
                                    {
                                        c = SoloConfig.FindControlByAddress(Address);
                                        if ( c == null)
                                        {
                                            c = Talkback.FindControlByAddress(Address);
                                            if (c == null)
                                            {
                                                c = TapeConfig.FindControlByAddress(address);
                                                if (c == null)
                                                {

                                                }
                                            }
                                        }                                            
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return c;
        }

        private ConsoleControl FindAddressFromList(List<X32ToggleButton> list, string address)
        {
            for (int i = 0; i < list.Count; i++)
              if (list[i].Address == address)
                return list[i];

            return null;
        }
    }
}
