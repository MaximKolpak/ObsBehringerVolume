using System;
using System.Text;
using System.IO;
using MixingConsole.Protocol;
using MixingConsole.Controls;
using MixingConsole.Transport;
using OSC;

namespace Behringer.X32
{
    public class X32OSCProtocol : OSCProtocol
    {
        public ProtocolBuffer buffer { get; set; }

        public X32OSCProtocol()
        {
            buffer = new ProtocolBuffer();
        }

        public void Flush()
        {
            buffer.Flush();
        }

        public override void ParseNetworkPacket(byte[] packet)
        {
            base.ParseNetworkPacket(packet);
            
            switch (packet[0])
            {
                case (byte)'s':
                    ParseOSCPacket(packet);
                    break;
                case (byte)'h':
                    ParseOSCPacket(packet);
                    break;
            }
        }

        public static OSCPacket PackageInfoRequest()
        {
            OSCPacket p = new OSCPacket();
            p.Address = "/info";
            p.ArgList = "";
            return p;
        }

        public static OSCPacket PackageStatusRequest()
        {
            OSCPacket p = new OSCPacket();
            p.Address = "/status";
            p.ArgList = "";
            return p;
        }

        public static OSCPacket PackageFormatSubscribe()
        {
            OSCPacket p = new OSCPacket();

            p.Address = "/formatsubscribe";
            p.ArgList = ",ssssssssssssssssssiiissiii";

            p.Arguments.Add(new OSCStringArg("states/prefs"));
            p.Arguments.Add(new OSCStringArg("/-stat/tape/state"));
            p.Arguments.Add(new OSCStringArg("/-usb/path/"));
            p.Arguments.Add(new OSCStringArg("/-usb/title"));
            p.Arguments.Add(new OSCStringArg("/-stat/tape/etime"));
            p.Arguments.Add(new OSCStringArg("/-stat/tape/rtime"));
            p.Arguments.Add(new OSCStringArg("/-stat/aes50/state"));
            p.Arguments.Add(new OSCStringArg("/-stat/aes50/A"));
            p.Arguments.Add(new OSCStringArg("/-stat/aes50/B"));
            p.Arguments.Add(new OSCStringArg("/-prefs/clockrate"));
            p.Arguments.Add(new OSCStringArg("/-prefs/clocksource"));
            p.Arguments.Add(new OSCStringArg("/-show/prepos/current"));
            p.Arguments.Add(new OSCStringArg("/-stat/usbmounted"));
            p.Arguments.Add(new OSCStringArg("/-usb/dir/dirpos"));
            p.Arguments.Add(new OSCStringArg("/-usb/dir/maxpos"));
            p.Arguments.Add(new OSCStringArg("/-stat/xcardtype"));
            p.Arguments.Add(new OSCStringArg("/-prefs/card/UFifc"));
            p.Arguments.Add(new OSCStringArg("/-prefs/card/UFmode"));
            p.Arguments.Add(new OSCIntArg(0));
            p.Arguments.Add(new OSCIntArg(0));
            p.Arguments.Add(new OSCIntArg(0));
            p.Arguments.Add(new OSCStringArg("states/solo"));
            p.Arguments.Add(new OSCStringArg("/-stat/solosw/**"));
            p.Arguments.Add(new OSCIntArg(0));
            p.Arguments.Add(new OSCIntArg(0));
            p.Arguments.Add(new OSCIntArg(0));

            return p;
        }

        public static OSCPacket PackageXRemotePing()
        {
            OSCPacket p = new OSCPacket();
            p.Address = "/xremote";
            p.ArgList = "";
            return p;
        }

        public static OSCPacket RenewMeter(int meter)
        {
            OSCPacket p = new OSCPacket();
            p.Address = "/meters";
            p.ArgList = ",s";

            OSCStringArg s = new OSCStringArg();
            s.value = "/meters/" + meter.ToString();
            p.Arguments.Add(s);
            
            return p;
        }

        internal static OSCPacket PackageCopyright()
        {
            OSCPacket p = new OSCPacket();
            p.Address = "/copyright";
            p.ArgList = ",s";
            OSCStringArg a = new OSCStringArg();
            a.value = "X32.net Copyright (C) 2014 by Jason Grooms - All Rights Reserved";
            p.Arguments.Add(a);
            return p;
        }
    }
}
