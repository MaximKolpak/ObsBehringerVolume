using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Screen : ConsoleControlGroup
    {
        public X32IntDial Screen { get; set; }
        public X32IntDial HomePage { get; set; }
        public X32IntDial MetersPage { get; set; }
        public X32IntDial RoutingPage { get; set; }
        public X32IntDial LibraryPage { get; set; }
        public X32IntDial EffectsPage { get; set; }
        public X32IntDial SetupPage { get; set; }
        public X32IntDial MonitorPage { get; set; }
        public X32IntDial ScenesPage { get; set; }
        public X32IntDial MuteGroupPage { get; set; }
        public X32IntDial UtilityPage { get; set; }
        public X32IntDial AssignPage { get; set; }
        public X32IntDial USBPage { get; set; }


        public X32Screen()
        {
            Screen = new X32IntDial();
            HomePage = new X32IntDial();
            MetersPage = new X32IntDial();
            RoutingPage = new X32IntDial();
            LibraryPage = new X32IntDial();
            EffectsPage = new X32IntDial();
            SetupPage = new X32IntDial();
            MonitorPage = new X32IntDial();
            ScenesPage = new X32IntDial();
            MuteGroupPage = new X32IntDial();
            UtilityPage = new X32IntDial();
            AssignPage = new X32IntDial();
            USBPage = new X32IntDial();

            Address = "/screen";

            Screen.Address = "/screen";
            Screen.Parent = this;

            HomePage.Address = "/CHAN/page";
            HomePage.Parent = this;

            MetersPage.Address = "/METER/page";
            MetersPage.Parent = this;

            RoutingPage.Address = "/ROUTE/page";
            RoutingPage.Parent = this;

            LibraryPage.Address = "/LIB/page";
            LibraryPage.Parent = this;

            EffectsPage.Address = "/FX/page";
            EffectsPage.Parent = this;

            SetupPage.Address = "/SETUP/page";
            SetupPage.Parent = this;

            MonitorPage.Address = "/MON/page";
            MonitorPage.Parent = this;

            ScenesPage.Address = "/SCENE/page";
            ScenesPage.Parent = this;

            MuteGroupPage.Address = "/mutegrp";
            MuteGroupPage.Parent = this;

            UtilityPage.Address = "/utils";
            UtilityPage.Parent = this;

            AssignPage.Address = "/ASSIGN/page";
            AssignPage.Parent = this;

            USBPage.Address = "/USB/page";
            USBPage.Parent = this;
        }

        public override ConsoleControl FindControlByAddress(string address)
        {
            if (Screen.Address == address)
                return Screen;
            else if (HomePage.Address == address)
                return HomePage;
            else if (MetersPage.Address == address)
                return MetersPage;
            else if (RoutingPage.Address == address)
                return MetersPage;
            else if (LibraryPage.Address == address)
                return LibraryPage;
            else if (EffectsPage.Address == address)
                return EffectsPage;
            else if (SetupPage.Address == address)
                return SetupPage;
            else if (MonitorPage.Address == address)
                return MonitorPage;
            else if (ScenesPage.Address == address)
                return ScenesPage;
            else if (MuteGroupPage.Address == address)
                return MuteGroupPage;
            else if (UtilityPage.Address == address)
                return UtilityPage;
            else if (AssignPage.Address == address)
                return AssignPage;
            else if (USBPage.Address == address)
                return USBPage;
            else
                return null;
        }
    }
}
