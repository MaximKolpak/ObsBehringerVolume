using System;
using MixingConsole.Controls;
using MixingConsole.Protocol;
using Behringer.X32;

namespace Behringer.X32.Controls
{
    public class X32Main : ConsoleInput
    {
        public X32MainStrip Strip;

        public X32Main()
        {
            Strip = new X32MainStrip();
            Strip.Parent = this;
            CreateMuteButton();
            CreateFader();
            //CreateStereoLink();
            CreatePan();
            //CreateMonoSend();
            //CreateMonoFader();
            CreateMixBuss();
            CreateEq();
            CreateCompressor();
            //CreateGate();
            CreateInsert();
            //CreatePre();
            CreateConfig();
            //CreateDca();
        }

        private void CreateDca()
        {
            //Strip.Dca.Address = "/grp";
            //Strip.Dca.Parent = this;
            //Strip.Dca.Id = Id;

            //Strip.Dca.Dca.Address = "/dca";
            //Strip.Dca.Dca.Parent = Strip.Dca;
            //Strip.Dca.Dca.Id = Id;

            //Strip.Dca.Mute.Address = "/mute";
            //Strip.Dca.Mute.Parent = Strip.Dca;
            //Strip.Dca.Mute.Id = Id;
        }

        private void CreateConfig()
        {
            Strip.Config.Address = "/config";
            Strip.Config.Parent = this;
            Strip.Config.Id = Id;

            Strip.Config.Name.Address = "/name";
            Strip.Config.Name.Parent = Strip.Config;
            Strip.Config.Name.Id = Id;

            Strip.Config.Icon.Address = "/icon";
            Strip.Config.Icon.Parent = Strip.Config;
            Strip.Config.Icon.Id = Id;

            Strip.Config.Color.Address = "/color";
            Strip.Config.Color.Parent = Strip.Config;
            Strip.Config.Color.Id = Id;

            //Strip.Config.Source.Address = "/source";
            //Strip.Config.Source.Parent = Strip.Config;
            //Strip.Config.Source.Id = Id;

        }

        private void CreatePre()
        {
            //Strip.Pre.Address = "/preamp";
            //Strip.Pre.Parent = this;
            //Strip.Pre.Id = Id;

            //Strip.Pre.Trim.Address = "/trim";
            //Strip.Pre.Trim.Parent = Strip.Pre;
            //Strip.Pre.Trim.Id = Id;

            //Strip.Pre.Invert.Address = "/invert";
            //Strip.Pre.Invert.Parent = Strip.Pre;
            //Strip.Pre.Invert.Id = Id;

            //Strip.Pre.Hpf.Address = "/hpon";
            //Strip.Pre.Hpf.Parent = Strip.Pre;
            //Strip.Pre.Hpf.Id = Id;

            //Strip.Pre.Slope.Address = "/hpslope";
            //Strip.Pre.Slope.Parent = Strip.Pre;
            //Strip.Pre.Slope.Id = Id;

            //Strip.Pre.HpfFreq.Address = "/hpf";
            //Strip.Pre.HpfFreq.Parent = Strip.Pre;
            //Strip.Pre.HpfFreq.Id = Id;
        }

        private void CreateGate()
        {
            //Strip.Gate.Address = "/gate";
            //Strip.Gate.Parent = this;
            //Strip.Gate.Id = Id;

            //Strip.Gate.On.Address = "/on";
            //Strip.Gate.On.Parent = Strip.Gate;
            //Strip.Gate.On.Id = Id;

            //Strip.Gate.Mode.Address = "/mode";
            //Strip.Gate.Mode.Parent = Strip.Gate;
            //Strip.Gate.Mode.Id = Id;

            //Strip.Gate.Threshold.Address = "/thr";
            //Strip.Gate.Threshold.Parent = Strip.Gate;
            //Strip.Gate.Threshold.Id = Id;

            //Strip.Gate.Range.Address = "/range";
            //Strip.Gate.Range.Parent = Strip.Gate;
            //Strip.Gate.Range.Id = Id;

            //Strip.Gate.Attack.Address = "/attack";
            //Strip.Gate.Attack.Parent = Strip.Gate;
            //Strip.Gate.Attack.Id = Id;

            //Strip.Gate.Hold.Address = "/hold";
            //Strip.Gate.Hold.Parent = Strip.Gate;
            //Strip.Gate.Hold.Id = Id;

            //Strip.Gate.Release.Address = "/release";
            //Strip.Gate.Release.Parent = Strip.Gate;
            //Strip.Gate.Release.Id = Id;

            //Strip.Gate.KeySource.Address = "/keysrc";
            //Strip.Gate.KeySource.Parent = Strip.Gate;
            //Strip.Gate.KeySource.Id = Id;

            //Strip.Gate.Filter.Address = "/filter";
            //Strip.Gate.Filter.Parent = Strip.Gate;
            //Strip.Gate.Filter.Id = Id;

            //Strip.Gate.Filter.On.Address = "/on";
            //Strip.Gate.Filter.On.Parent = Strip.Gate.Filter;
            //Strip.Gate.Filter.On.Id = Id;

            //Strip.Gate.Filter.Type.Address = "/type";
            //Strip.Gate.Filter.Type.Parent = Strip.Gate.Filter;
            //Strip.Gate.Filter.Type.Id = Id;

            //Strip.Gate.Filter.Freq.Address = "/f";
            //Strip.Gate.Filter.Freq.Parent = Strip.Gate.Filter;
            //Strip.Gate.Filter.Freq.Id = Id;

        }

        private void CreateInsert()
        {
            Strip.Insert.Address = "/insert";
            Strip.Insert.Parent = this;
            Strip.Insert.Id = Id;

            Strip.Insert.On.Address = "/on";
            Strip.Insert.On.Parent = Strip.Insert;
            Strip.Insert.On.Id = Id;

            Strip.Insert.Position.Address = "/pos";
            Strip.Insert.Position.Parent = Strip.Insert;
            Strip.Insert.Position.Id = Id;

            Strip.Insert.Insert.Address = "/sel";
            Strip.Insert.Insert.Parent = Strip.Insert;
            Strip.Insert.Insert.Id = Id;
        }

        private void CreateCompressor()
        {
            Strip.Comp.Address = "/dyn";
            Strip.Comp.Parent = this;
            Strip.Comp.Id = Id;

            Strip.Comp.Active.Address = "/on";
            Strip.Comp.Active.Parent = Strip.Comp;
            Strip.Comp.Active.Id = Id;

            Strip.Comp.Mode.Address = "/mode";
            Strip.Comp.Mode.Parent = Strip.Comp;
            Strip.Comp.Mode.Id = Id;

            Strip.Comp.Detect.Address = "det";
            Strip.Comp.Detect.Parent = Strip.Comp;
            Strip.Comp.Detect.Id = Id;

            Strip.Comp.Envelope.Address = "/env";
            Strip.Comp.Envelope.Parent = Strip.Comp;
            Strip.Comp.Envelope.Id = Id;

            Strip.Comp.Threshhold.Address = "/thr";
            Strip.Comp.Threshhold.Parent = Strip.Comp;
            Strip.Comp.Threshhold.Id = Id;

            Strip.Comp.Ratio.Address = "/ratio";
            Strip.Comp.Ratio.Parent = Strip.Comp;
            Strip.Comp.Ratio.Id = Id;

            Strip.Comp.Knee.Address = "/knee";
            Strip.Comp.Knee.Parent = Strip.Comp;
            Strip.Comp.Knee.Id = Id;

            Strip.Comp.Gain.Address = "/mgain";
            Strip.Comp.Gain.Parent = Strip.Comp;
            Strip.Comp.Gain.Id = Id;

            Strip.Comp.Attack.Address = "/attack";
            Strip.Comp.Attack.Parent = Strip.Comp;
            Strip.Comp.Attack.Id = Id;

            Strip.Comp.Hold.Address = "/hold";
            Strip.Comp.Hold.Parent = Strip.Comp;
            Strip.Comp.Hold.Id = Id;

            Strip.Comp.Release.Address = "/release";
            Strip.Comp.Release.Parent = Strip.Comp;
            Strip.Comp.Release.Id = Id;

            Strip.Comp.Position.Address = "/pos";
            Strip.Comp.Position.Parent = Strip.Comp;
            Strip.Comp.Position.Id = Id;

            Strip.Comp.KeySource.Address = "/keysrc";
            Strip.Comp.KeySource.Parent = Strip.Comp;
            Strip.Comp.KeySource.Id = Id;

            Strip.Comp.Filter.Address = "/filter";
            Strip.Comp.Filter.Parent = Strip.Comp;
            Strip.Comp.Filter.Id = Id;

            Strip.Comp.Filter.On.Address = "/on";
            Strip.Comp.Filter.On.Parent = Strip.Comp.Filter;
            Strip.Comp.Filter.On.Id = Id;

            Strip.Comp.Filter.Type.Address = "/type";
            Strip.Comp.Filter.Type.Parent = Strip.Comp.Filter;
            Strip.Comp.Filter.Type.Id = Id;

            Strip.Comp.Filter.Freq.Address = "/f";
            Strip.Comp.Filter.Freq.Parent = Strip.Comp.Filter;
            Strip.Comp.Filter.Freq.Id = Id;

        }

        private void CreateEq()
        {
            Strip.Eq.Address = "/eq";
            Strip.Eq.Parent = this;
            Strip.Eq.Id = Id;

            Strip.Eq.Active.Address = "/on";
            Strip.Eq.Active.Parent = Strip.Eq;
            Strip.Eq.Active.Id = Id;

            for (int i = 0; i < X32.X32EqBandsMain; i++)
            {
                Strip.Eq.Band[i].Type = X32EQType.PEQ;
                Strip.Eq.Band[i].Address = "/" + (i + 1).ToString();
                Strip.Eq.Band[i].Parent = Strip.Eq;
                Strip.Eq.Band[i].Id = Id;

                Strip.Eq.Band[i].Freq = new X32EqFreqDial();
                Strip.Eq.Band[i].Freq.Address = "/f";
                Strip.Eq.Band[i].Freq.Parent = Strip.Eq.Band[i];
                Strip.Eq.Band[i].Freq.Id = Id;

                Strip.Eq.Band[i].Gain = new X32EqGainDial();
                Strip.Eq.Band[i].Gain.Address = "/g";
                Strip.Eq.Band[i].Gain.Parent = Strip.Eq.Band[i];
                Strip.Eq.Band[i].Gain.Id = Id;

                Strip.Eq.Band[i].Q = new X32EqQDial();
                Strip.Eq.Band[i].Q.Address = "/q";
                Strip.Eq.Band[i].Q.Parent = Strip.Eq.Band[i];
                Strip.Eq.Band[i].Q.Id = Id;
            }
        }

        protected virtual void CreateMixBuss()
        {
            //Strip.MixBuss = new X32MixBuss[X32Console.X32MaxMixBuss];

            //for (int i = 0; i < X32.X32MaxMixBuss - 1; i++)
            //{
            //    Strip.MixBuss[i].Address = "/mix/" + (i + 1).ToString("D2");
            //    Strip.MixBuss[i].Parent = this;
            //    Strip.MixBuss[i].Id = Id;

            //    Strip.MixBuss[i].Fader = new X32Fader();
            //    Strip.MixBuss[i].Fader.Address = "/level";
            //    Strip.MixBuss[i].Fader.Parent = Strip.MixBuss[i];
            //    Strip.MixBuss[i].Fader.Id = Id;

            //    Strip.MixBuss[i].Pan = new X32PanDial();
            //    Strip.MixBuss[i].Pan.Address = "/pan";
            //    Strip.MixBuss[i].Pan.Parent = Strip.MixBuss[i];
            //    Strip.MixBuss[i].Pan.Id = Id;

            //    Strip.MixBuss[i].Mute = new X32MuteButton();
            //    Strip.MixBuss[i].Mute.Address = "/on";
            //    Strip.MixBuss[i].Mute.Parent = Strip.MixBuss[i];
            //    Strip.MixBuss[i].Mute.Id = Id;

            //    Strip.MixBuss[i].TapPoint = new X32TapPoint();
            //    Strip.MixBuss[i].TapPoint.Address = "/type";
            //    Strip.MixBuss[i].TapPoint.Parent = Strip.MixBuss[i];
            //    Strip.MixBuss[i].TapPoint.Id = Id;
            //}
        }

        protected virtual void CreateMonoFader()
        {
            //Strip.MonoFader.Parent = this;
            //Strip.MonoFader.Address = "/mix/mlevel";
            //Strip.MonoFader.Id = Id;

        }

        protected virtual void CreateMonoSend()
        {
            //Strip.MonoSend.Parent = this;
            //Strip.MonoSend.Address = "/mix/mono";
            //Strip.MonoSend.Id = Id;
        }

        protected virtual void CreateStereoLink()
        {
            //Strip.Link.Parent = this;
            //Strip.Link.Address = "/mix/st";
            //Strip.Link.Id = Id;

        }

        protected virtual void CreateMuteButton()
        {
            Strip.Mute.Parent = this;
            Strip.Mute.Address = "/mix/on";
            Strip.Mute.Id = Id;
        }

        protected virtual void CreateFader()
        {
            Strip.Fader.Parent = this;
            Strip.Fader.Address = "/mix/fader";
            Strip.Fader.Id = Id;
        }

        protected virtual void CreatePan()
        {
            //Strip.Pan.Parent = this;
            //Strip.Pan.Address = "/mix/pan";
            //Strip.Pan.Id = Id;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            return Strip.FindControlByAddress(address);
        }

    }
}
