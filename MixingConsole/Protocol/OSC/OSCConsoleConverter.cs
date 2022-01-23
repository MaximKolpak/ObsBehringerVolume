using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using MixingConsole.Controls;
using OSC;

namespace MixingConsole.Protocol
{
    public class OSCConsoleConverter : OSCConverter
    {
        public static OSCPacket Inquire(ConsoleControl control)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = control.Address;
            packet.Nodes = control.Address.Split(d);
            return packet;
        }

        public static OSCPacket ControlToOSCPacket(ConsoleControl control, int value)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = control.Address;
            packet.Nodes = control.Address.Split(d);
            packet.ArgList = ",i";
            OSCIntArg intArg = new OSCIntArg();
            intArg.value = value;
            packet.Arguments.Add(intArg);
            return packet;
        }

        public static OSCPacket ControlToOSCPacket(ConsoleControl control, string address, int value)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = address;
            packet.Nodes = control.Address.Split(d);
            packet.ArgList = ",i";
            OSCIntArg intArg = new OSCIntArg();
            intArg.value = value;
            packet.Arguments.Add(intArg);
            return packet;
        }

        public static OSCPacket ControlToOSCPacket(ConsoleControl control, string value)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = control.Address;
            packet.Nodes = control.Address.Split(d);
            packet.ArgList = ",s";
            OSCStringArg stringArg = new OSCStringArg();
            stringArg.value = value;
            packet.Arguments.Add(stringArg);
            return packet;
        }

        public static OSCPacket ControlToOSCPacket(ConsoleControl control, float value)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = control.Address;
            packet.Nodes = control.Address.Split(d);
            packet.ArgList = ",f";
            OSCFloatArg floatArg = new OSCFloatArg();
            floatArg.value = value;
            packet.Arguments.Add(floatArg);
            return packet;
        }
               
    }
}
