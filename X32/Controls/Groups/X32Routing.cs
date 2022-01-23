using MixingConsole.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behringer.X32.Controls
{
    public class X32Routing : ConsoleControlGroup
    {
        public X32IntDial In18 { get; set; }
        public X32IntDial In916 { get; set; }
        public X32IntDial In1724 { get; set; }
        public X32IntDial In2532 { get; set; }
        public X32IntDial InAux14 { get; set; }

        public X32IntDial AESA18 { get; set; }
        public X32IntDial AESA916 { get; set; }
        public X32IntDial AESA1724 { get; set; }
        public X32IntDial AESA2532 { get; set; }
        public X32IntDial AESA3340 { get; set; }
        public X32IntDial AESA4148 { get; set; }

        public X32IntDial AESB18 { get; set; }
        public X32IntDial AESB916 { get; set; }
        public X32IntDial AESB1724 { get; set; }
        public X32IntDial AESB2532 { get; set; }
        public X32IntDial AESB3340 { get; set; }
        public X32IntDial AESB4148 { get; set; }

        public X32IntDial Card18 { get; set; }
        public X32IntDial Card916 { get; set; }
        public X32IntDial Card1724 { get; set; }
        public X32IntDial Card2532 { get; set; }

        public X32Routing()
        {
            In18 = new X32IntDial();
            In916 = new X32IntDial();
            In1724 = new X32IntDial();
            In2532 = new X32IntDial();
            InAux14 = new X32IntDial();

            AESA18 = new X32IntDial();
            AESA916 = new X32IntDial();
            AESA1724 = new X32IntDial();
            AESA2532 = new X32IntDial();
            AESA3340 = new X32IntDial();
            AESA4148 = new X32IntDial();

            AESB18 = new X32IntDial();
            AESB916 = new X32IntDial();
            AESB1724 = new X32IntDial();
            AESB2532 = new X32IntDial();
            AESB3340 = new X32IntDial();
            AESB4148 = new X32IntDial();

            Card18 = new X32IntDial();
            Card916 = new X32IntDial();
            Card1724 = new X32IntDial();
            Card2532 = new X32IntDial();

            Address = "/config/routing";

            In18.Address = "/IN/1-8";
            In18.Parent = this;
            In916.Address = "/IN/9-16";
            In916.Parent = this;
            In1724.Address = "/IN/17-24";
            In1724.Parent = this;
            In2532.Address = "/IN/25-32";
            In2532.Parent = this;
            InAux14.Address = "/IN/AUX1-4";
            InAux14.Parent = this;

            AESA18.Address = "/AES50A/1-8";
            AESA18.Parent = this;
            AESA916.Address = "/AES50A/9-16";
            AESA916.Parent = this;
            AESA1724.Address = "/AES50A/17-24";
            AESA1724.Parent = this;
            AESA2532.Address = "/AES50A/25-32";
            AESA2532.Parent = this;
            AESA3340.Address = "/AES50A/33-40";
            AESA3340.Parent = this;
            AESA4148.Address = "/AES50A/41-48";
            AESA4148.Parent = this;

            AESB18.Address = "/AES50B/1-8";
            AESB18.Parent = this;
            AESB916.Address = "/AES50B/9-16";
            AESB916.Parent = this;
            AESB1724.Address = "/AES50B/17-24";
            AESB1724.Parent = this;
            AESB2532.Address = "/AES50B/25-32";
            AESB2532.Parent = this;
            AESB3340.Address = "/AES50B/33-40";
            AESB3340.Parent = this;
            AESB4148.Address = "/AES50B/41-48";
            AESB4148.Parent = this;

            Card18.Address = "/CARD/1-8";
            Card18.Parent = this;
            Card916.Address = "/CARD/9-16";
            Card916.Parent = this;
            Card1724.Address = "/CARD/17-24";
            Card1724.Parent = this;
            Card2532.Address = "/CARD/25-32";
            Card2532.Parent = this;
        }
       
        public override ConsoleControl FindControlByAddress(string address)
        {
            if (In18.Address == address)
                return In18;
            else if (In916.Address == address)
                return In916;
            else if (In1724.Address == address)
                return In1724;
            else if (In2532.Address == address)
                return In2532;
            else if (InAux14.Address == address)
                return InAux14;
            else if (AESA18.Address == address)
                return AESA18;
            else if (AESA916.Address == address)
                return AESA916;
            else if (AESA2532.Address == address)
                return AESA2532;
            else if (AESA3340.Address == address)
                return AESA3340;
            else if (AESA4148.Address == address)
                return AESA4148;
            else if (AESB18.Address == address)
                return AESB18;
            else if (AESB916.Address == address)
                return AESB916;
            else if (AESB2532.Address == address)
                return AESB2532;
            else if (AESB3340.Address == address)
                return AESB3340;
            else if (AESB4148.Address == address)
                return AESB4148;
            else if (Card18.Address == address)
                return Card18;
            else if (Card916.Address == address)
                return Card916;
            else if (Card2532.Address == address)
                return Card2532;
            else
                return null;                
        }
    }
}
