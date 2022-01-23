using System;
using System.Collections.Generic;

namespace OSC
{  
    public delegate void ThreadSafeOSC(OSCPacket packet);

    public interface IOSCArgument 
    {
        string ToString();
        int ToInt();
        float ToFloat();
    }
    
    public class OSCStringArg : IOSCArgument
    {
        public string value { get; set; }

        public OSCStringArg()
        {

        }

        public OSCStringArg(string s)
        {
            value = s;
        }

        public new string ToString()
        {
            return value;
        }

        public virtual int ToInt()
        {
            return Convert.ToInt32(value);
        }

        public virtual float ToFloat()
        {
            return Convert.ToSingle(value);
        }
    }

    public class OSCIntArg : IOSCArgument
    {
        public int value { get; set; }

        public OSCIntArg()
        {

        }

        public OSCIntArg(int i)
        {
            value = i;
        }

        public new string ToString()
        {
            return value.ToString();
        }

        public virtual int ToInt()
        {
            return value;
        }

        public virtual float ToFloat()
        {
            return Convert.ToSingle(value);
        }
    }

    public class OSCFloatArg : IOSCArgument
    {
        public float value { get; set; }

        public new string ToString()
        {
            return value.ToString();
        }

        public virtual int ToInt()
        {
            return Convert.ToInt32(value);
        }

        public virtual float ToFloat()
        {
            return value;
        }
    }

    public class OSCBlobArg : IOSCArgument
    {
        public byte[] value { get; set; }

        public new string ToString()
        {
            return System.Text.Encoding.UTF8.GetString(value);
        }

        public virtual int ToInt()
        {
            return value.Length;
        }

        public virtual float ToFloat()
        {
            return value.Length;
        }
    }

    public class OSCPacket : IProtocolPacket
    {
        public const int OSCByteAlign = sizeof(Int32);
        public const int OSCFloatSize = sizeof(float);
        public const int OSCIntSize = sizeof(Int32);
        public const int OSCInt16Size = sizeof(Int16);   

        public string Address { get; set; }
        public string[] Nodes { get; set; }
        public string ArgList { get; set; }
        public List<IOSCArgument> Arguments { get; set; }
        public object Tag;
        public bool Process;

        public OSCPacket()
        {
            Arguments = new List<IOSCArgument>();
            Process = true;
        }
        
        public virtual byte[] GetBytes()
        {
            OSCConverter c = new OSCConverter();
            return c.GetBytes(this);
        }

        public virtual object[] ToParams()
        {
            object[] p = new object[1];
            p[0] = this;
            return p;
        }

        public virtual object ToParam()
        {
            object p = this;
            return p;
        }

        public virtual int[] ArgToIntArray(int argument)
        {
            int[] ints = null;

            if (Arguments[argument] is OSCBlobArg)
            {                
                OSCBlobArg a = (OSCBlobArg)Arguments[argument];

                int numInts = a.value.Length / OSCFloatSize;
                ints = new int[numInts];
                int intIndex = 0;

                for (int i = 0; i < a.value.Length; i += OSCFloatSize)
                {
                    ints[intIndex++] = (int)(BitConverter.ToSingle(new byte[] { a.value[i], a.value[i + 1], a.value[i + 2], a.value[i + 3] }, 0) * 100);
                }
            }
            return ints;
        }

        public virtual float[] ArgToFloatArray(int argument)
        {
            float[] floats = null;

            if (Arguments[argument] is OSCBlobArg)
            {                
                OSCBlobArg a = (OSCBlobArg)Arguments[argument];

                int numfloats = a.value.Length / OSCFloatSize;
                floats = new float[numfloats];
                int floatIndex = 0;

                for (int i = 0; i < a.value.Length; i += OSCFloatSize)
                {
                    floats[floatIndex++] = BitConverter.ToSingle(new byte[] { a.value[i], a.value[i + 1], a.value[i + 2], a.value[i + 3] }, 0);
                }
            }
            return floats;
        }

        public virtual float BlobElementToFloat(int argument, int element)
        {
            float f = 0;

            if (Arguments[argument] is OSCBlobArg && element >= 0)
            {
                OSCBlobArg a = (OSCBlobArg)Arguments[argument];

                int offset = element * OSCFloatSize;
                if (offset <= a.value.Length-OSCFloatSize)
                    f = BitConverter.ToSingle(new byte[] { a.value[offset], a.value[offset + 1], a.value[offset + 2], a.value[offset + 3] }, 0);
            }
            return f;
        }

        public virtual int BlobElementToInt(int argument, int element)
        {
            int i = 0;

            if (Arguments[argument] is OSCBlobArg && element >= 0)
            {
                OSCBlobArg a = (OSCBlobArg)Arguments[argument];

                int offset = element * OSCIntSize;
                if (offset <= a.value.Length-OSCIntSize)
                    i = (int)(BitConverter.ToSingle(new byte[] { a.value[offset], a.value[offset + 1], a.value[offset + 2], a.value[offset + 3] }, 0) * 100);
            }
            return i;
        }

        public virtual Int16 BlobElementToInt16(int argument, int element)
        {
            Int16 i = 0;

            if (Arguments[argument] is OSCBlobArg && element >= 0)
            {
                OSCBlobArg a = (OSCBlobArg)Arguments[argument];

                int offset = element * OSCInt16Size;
                if (offset <= a.value.Length - OSCInt16Size)
                    i = (Int16)(BitConverter.ToInt16(new byte[] { a.value[offset], a.value[offset + 1] }, 0));
            }
            return i;
        }

    }
    
}
