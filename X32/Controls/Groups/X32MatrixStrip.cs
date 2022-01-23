using System;
using Behringer.X32.Controls;
using MixingConsole.Controls;

namespace Behringer.X32.Controls
{
    public class X32MatrixStrip : ConsoleControlGroup
    {
        public X32Fader Fader { get; set; }
        public X32MuteButton Mute { get; set; }
        //public X32StereoLink Link { get; set; }
        //public X32PanDial Pan { get; set; }
        //public X32MonoButton MonoSend { get; set; }
        //public X32MonoFader MonoFader { get; set; }
        //public X32BusMix[] MixBuss { get; set; }
        public X32Eq Eq { get; set; }
        public X32Compressor Comp { get; set; }
        //public X32Gate Gate { get; set; }
        public X32Insert Insert { get; set; }
        //public X32PreAmp Pre { get; set; }
        //public X32PreAmpDelay Delay { get; set; }
        public X32InputConfig Config { get; set; }
        //public X32DcaGroup Dca { get; set; }

        public X32MatrixStrip()
        {
            Fader = new X32Fader();
            Mute = new X32MuteButton();
            //Link = new X32StereoLink();
            //Pan = new X32PanDial();
            //MonoSend = new X32MonoButton();
            //MonoFader = new X32MonoFader();
            Eq = new X32Eq(X32.X32EqBandsMatrix);
            Comp = new X32Compressor();
            //Gate = new X32Gate();
            Insert = new X32Insert();
            //Pre = new X32ChannelPreAmp();
            //Delay = new X32PreAmpDelay();
            //MixBuss = new X32BusMix[X32.X32MaxMixBuss];
            Config = new X32ChannelConfig();
            //Dca = new X32DcaGroup();
            //for (int i = 0; i < X32.X32MaxMixBuss; i++)
            //{
            //    MixBuss[i] = new X32BusMix();
            //}
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Fader.Address == address)
                return Fader;
            else if (Mute.Address == address)
                return Mute;         
            else if (Eq.Address == address)
                return Eq;
            else
            {
                ConsoleControl c;
                c = Comp.FindControlByAddress(address);
                if (c == null)
                {
                    c = Insert.FindControlByAddress(address);
                    if (c == null)
                    {
                        c = null; // Gate.FindControlByAddress(address);
                        if (c == null)
                        {
                            c = null;// Pre.FindControlByAddress(address);
                            if (c == null)
                            {
                                c = null; // Delay.FindControlByAddress(address);
                                if (c == null)
                                {
                                    c = Config.FindControlByAddress(address);
                                    if (c == null)
                                    {
                                        c = null; // Dca.FindControlByAddress(address);
                                        if (c == null)
                                        {

                                        }
                                        else
                                            return c;
                                    }
                                    else
                                        return c;
                                }
                                else
                                    return c;
                            }
                            else
                                return c;
                        }
                        else
                            return c;
                    }
                    else
                        return c;
                }
                else
                    return c;
            }

            //foreach (var Buss in MixBuss)
            //{
            //    if (Buss.Address == address)
            //        return Buss;
            //}
            return null;
        }
    }
}
