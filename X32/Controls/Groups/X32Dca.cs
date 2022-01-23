using MixingConsole.Controls;
using System;

namespace Behringer.X32.Controls
{
    public class X32Dca : ConsoleInput
    {
        public X32DcaStrip Strip { get; set; }

        public X32Dca()
        {
            Strip = new X32DcaStrip();
            Strip.Parent = this;
            CreateConfig();
            CreateFader();
            CreateMute();

        }

        private void CreateMute()
        {
            Strip.Mute.Parent = this;
            Strip.Mute.Address = "/on";
            Strip.Mute.Id = Id;
        }

        private void CreateFader()
        {
            Strip.Fader.Parent = this;
            Strip.Fader.Address = "/fader";
            Strip.Fader.Id = Id;
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

        public override ConsoleControl FindControlByAddress(string address)
        {
            return Strip.FindControlByAddress(address);
        }
    }
}
