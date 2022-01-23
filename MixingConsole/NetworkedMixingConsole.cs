using System;
using System.Net;
using MixingConsole.Protocol;
using MixingConsole.Transport;
using System.Timers;

namespace MixingConsole
{
    public abstract class NetworkedMixingConsole : MixingConsole
    {
        protected IConsoleProtocol Protocol { get; set; }
        protected ITransportLayer Transport { get; set; }
        protected Timer _Timer;

        public IPAddress IPAddress { get; set; }       
        public int Port;
        public double Interval
        {
            get
            {
                return _Timer.Interval;
            }

            set
            {
                _Timer.Interval = value;
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();

    }
}
