using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace OSC
{
    public class OSCConverter
    {
        public const char OSCString = 's';
        public const char OSCInt = 'i';
        public const char OSCFloat = 'f';
        public const char OSCBlob = 'b';

        private ProtocolBuffer buffer { get; set; }

        public static byte[] HostToNetworkOrder(byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] NetworkOrderToHost(byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }

        public OSCPacket GetOSCPacket(byte[] bytes)
        {
            OSCPacket outPacket = new OSCPacket();
            int offset = 0;

            outPacket.Address = PacketParseAddress(outPacket, ref offset, bytes);
            outPacket.ArgList = PacketParseArgumentList(outPacket, ref offset, bytes);
            outPacket.Arguments = PacketParseArguments(outPacket, ref offset, bytes);

            return outPacket;
        }

        public OSCPacket GetOSCPacket(string bytes)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return GetOSCPacket(encoding.GetBytes(bytes));
        }

        public byte[] GetBytes(OSCPacket packet)
        {            
            if (buffer == null)
                buffer = new ProtocolBuffer();
            else 
              buffer.Flush();

            PacketAdd(packet.Address);
            if (packet.ArgList != "")
            {
                PacketAdd(packet.ArgList);
                foreach (var arg in packet.Arguments)
                {
                    if (arg is OSCStringArg)
                        PacketAdd(((OSCStringArg)arg).value);
                    if (arg is OSCIntArg)
                        PacketAdd(((OSCIntArg)arg).value);
                    if (arg is OSCFloatArg)
                        PacketAdd(((OSCFloatArg)arg).value);
                    if (arg is OSCBlobArg)
                        PacketAdd(((OSCBlobArg)arg).value);
                }
            }

            return buffer.ToArray();
        }

        public float[] GetFloats(OSCPacket packet, int argument)
        {
            byte[] b = ((OSCBlobArg)packet.Arguments[argument]).value;
            int size = b.Length / OSCPacket.OSCFloatSize;
            float[] floats = new float[size];
            int f = 0;
            for (int i = OSCPacket.OSCFloatSize; i < b.Length; i += OSCPacket.OSCFloatSize)
            {
                floats[f++] = BitConverter.ToSingle(new byte[] { b[i-4], b[i-3], b[i-2], b[i-1] }, 0);
            }
            return floats;
        }

        public static OSCPacket Inquire(string address)
        {
            OSCPacket packet = new OSCPacket();
            char[] d = { '/' };

            packet.Address = address;
            packet.Nodes = address.Split(d);
            return packet;
        }

        private void Pad(int originalLength)
        {
            if (originalLength % OSCPacket.OSCByteAlign != 0)
            {
                byte[] bytes = new byte[OSCPacket.OSCByteAlign - (originalLength % OSCPacket.OSCByteAlign)];
                for (int i = 0; i < bytes.Length; i++)
                    bytes[i] = 0;
                buffer.Add(bytes);
            }
        }

        private void PacketAdd(byte[] bytes)
        {
            buffer.Add(bytes);
            Pad(bytes.Length);
        }

        private void PacketAdd(string msg)
        {
            if (msg != null)
            {
                msg += "\0";
                byte[] bytes = Encoding.ASCII.GetBytes(msg);
                PacketAdd(bytes);
            }
        }

        private void PacketAdd(float f)
        {
            byte[] bytes = BitConverter.GetBytes(f);         
            PacketAdd(HostToNetworkOrder(bytes));
        }

        private void PacketAdd(int i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            PacketAdd(HostToNetworkOrder(bytes));
        }        

        private string PacketParseAddress(OSCPacket packet, ref int offset, byte[] bytes)
        {
            char[] delimeters = { '/', ' ' };
            string a;
            a = PacketParseString(ref offset, bytes);
            packet.Nodes = a.Split(delimeters);
            return a;
        }

        private List<IOSCArgument> PacketParseArguments(OSCPacket packet, ref int offset, byte[] bytes)
        {
            int arg_offset = 1; // skip comma
            List<IOSCArgument> args = new List<IOSCArgument>();

            if (packet.ArgList != null)
                while (arg_offset < packet.ArgList.Length)
                {
                    switch (packet.ArgList[arg_offset])
                    {
                        case OSCString:
                            args.Add(AddStringArgument(ref offset, bytes));
                            break;
                        case OSCInt:
                            args.Add(AddIntArgument(ref offset, bytes));
                            break;
                        case OSCFloat:
                            args.Add(AddFloatArgument(ref offset, bytes));
                            break;
                        case OSCBlob:
                            args.Add(AddBlobArgument(ref offset, bytes));
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    arg_offset++;
                }

            return args;
        }

        private string PacketParseArgumentList(OSCPacket packet, ref int offset, byte[] bytes)
        {
            string arg_list = null;
            if (offset < bytes.Length)
              if (bytes[offset] == (byte)',')
                  arg_list = PacketParseString(ref offset, bytes);

            return arg_list;
        }

        private string PacketParseString(ref int offset, byte[] bytes)
        {
            string s = null;

            while (offset < bytes.Length && bytes[offset] != 0)
                s += (char)bytes[offset++];

            RemoveNULCharacters(ref offset, s);

            return s;
        }

        private void RemoveNULCharacters(ref int offset, string s)
        {
            if (s != null)
              for (int i = 0; i < (OSCPacket.OSCByteAlign - (s.Length % OSCPacket.OSCByteAlign)); i++)
                  offset++;
        }

        private IOSCArgument AddBlobArgument(ref int offset, byte[] bytes)
        {            
            byte[] int_bytes = { bytes[offset + 3], bytes[offset + 2], bytes[offset + 1], bytes[offset] };
            long size = BitConverter.ToInt32(int_bytes, 0) - OSCPacket.OSCFloatSize;
            offset += OSCPacket.OSCIntSize * 2; // why 8 and not 4?

            OSCBlobArg blob = new OSCBlobArg();
            blob.value = new byte[size];
            for (int i = 0; i < size; i++)
                blob.value[i] = bytes[offset++];

            offset += (int)(OSCPacket.OSCByteAlign - (size % OSCPacket.OSCByteAlign));
            return blob;
        }

        private IOSCArgument AddFloatArgument(ref int offset, byte[] bytes)
        {
            OSCFloatArg argument = new OSCFloatArg();
            byte[] float_bytes = { bytes[offset + 3], bytes[offset + 2], bytes[offset + 1], bytes[offset] };
            offset += OSCPacket.OSCFloatSize;
            argument.value = BitConverter.ToSingle(float_bytes, 0);

            return argument;
        }

        private IOSCArgument AddIntArgument(ref int offset, byte[] bytes)
        {
            byte[] int_bytes = { bytes[offset + 3], bytes[offset + 2], bytes[offset + 1], bytes[offset] };

            offset += OSCPacket.OSCIntSize;

            OSCIntArg argument = new OSCIntArg();
            argument.value = BitConverter.ToInt32(int_bytes, 0);

            return argument;
        }

        private IOSCArgument AddStringArgument(ref int offset, byte[] bytes)
        {
            OSCStringArg argument = new OSCStringArg();
            argument.value = PacketParseString(ref offset, bytes);

            return argument;
        }

    }

}
