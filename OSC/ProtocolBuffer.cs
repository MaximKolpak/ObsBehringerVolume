using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSC
{
    public class ProtocolBuffer
    {
        private long _size = 512;
        private long _offset = 0;
        public byte[] buffer;

        public ProtocolBuffer()
        {
            buffer = new byte[_size];
        }

        public ProtocolBuffer(long size)
        {
            _size = size;
            buffer = new byte[_size];
        }

        public void Flush()
        {
            _offset = 0;
        }

        public void Add(byte value)
        {
            CheckSize(sizeof(byte));
            buffer[_offset++] = value;
        }

        public void Add(string value)
        {
            CheckSize(value.Length);
            for (int i = 0; i < value.Length; i++)
			{
			    buffer[_offset++] = (byte)value[i];
			}
        }
    
        public void Add(int value)
        {
            CheckSize(sizeof(int));
            byte[] bytes = BitConverter.GetBytes(value);
            for (int i = 0; i < bytes.Length; i++)
			{
			    buffer[_offset++] = bytes[i];
			}
        }

        public void Add(float value)
        {
            CheckSize(sizeof(float));
            byte[] bytes = BitConverter.GetBytes(value);
            for (int i = 0; i < bytes.Length; i++)
            {
                buffer[_offset++] = bytes[i];
            }
        }

        public void Add(byte[] value)
        {
            CheckSize(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                buffer[_offset++] = value[i];
            }
        }

        public byte[] ToArray()
        {
            byte[] retArray = new byte[_offset];
            for (int i = 0; i < _offset; i++)
                retArray[i] = buffer[i];

            return retArray;
        }

        protected virtual void CheckSize(long growth)
        {
            growth += _offset;
            if (growth > buffer.Length)
            {
                long capacity = buffer.Length * 2;
                while (capacity < growth)
                    capacity *= 2;
                
                byte[] growthBuffer = new byte[capacity];
                buffer.CopyTo(growthBuffer, 0);
                buffer = growthBuffer;
                Console.WriteLine("Protocol buffer needed to be extended {0} bytes.  New Size is {1} bytes.", growth, capacity);
            }
        }
    }
}
