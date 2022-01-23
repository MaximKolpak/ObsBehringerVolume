using System;
using System.Net;
using System.Collections.Generic;
using System.Timers;
using Behringer.X32.Controls;
using MixingConsole;
using MixingConsole.Protocol;
using MixingConsole.Controls;
using MixingConsole.Transport;
using MixingConsole.Brokering;
using OSC;

namespace Behringer.X32
{
    #region [Enumerations]
    public enum X32UpdateContext { LocalUpdate, RemoteUpdate };
    public enum X32SendType { InLC = 0, PreEQ = 1, PostEQ = 2, PreFader = 3, PostFader = 4, Subgroup = 5 };
    public enum X32OnOff { Off = 0, On = 1, No = 0, Yes = 1, UnMute = 0, Mute = 1 };
    #endregion

    #region [Delegates]
    public delegate void OnConnectDelegate();
    public delegate void OnPacketReceivedDelegate (object sender, OSCPacket packet);
    public delegate void OnPacketSendDelegate(object sender, OSCPacket packet);        
    #endregion

    public class X32 : NetworkedMixingConsole, IOSCConsumer
    {
        #region [Constants]
        public const int X32Port = 10023;
        public const int X32MaxChannels = 32;
        public const int X32MaxAux = 8;
        public const int X32MaxFxRtn = 8;
        public const int X32MaxMixBuss = 16;
        public const int X32MaxBus = 16;
        public const int X32MaxMatrix = 6;
        public const int X32EqBandsMatrix = 6;
        public const int X32EqBandsBus = 4;
        public const int X32EqBandsMain = 6;
        public const int X32MaxDCA = 8;
        public const int X32MaxFxUnits = 8;
        public const int X32MaxFxParams = 64;
        public const int X32MaxHeadAmp = 128;
        public const int X32MaxMeters = 96;
        public const int X32MaxRenewMeters = 15;
        public const int X32MaxSolos = 80;
        public const float X320db = 0.4f;
        #endregion

        #region [Properties]       
        private new X32OSCProtocol Protocol;
        private new UDPTransportLayer Transport ;
        private Broker X32Broker;
        public RemoteConsole RemoteConsole;
        public RemoteOSCServer RemoteOSCServer ;
        public new IPAddress IPAddress
        {
            get 
            {
                return Transport.IPAddress;
            }

            set
            {
                Transport.IPAddress = value;
            }
        }
        public new int Port
        {
            get
            {
                return Transport.Port;
            }

            set
            {
                Transport.Port = value;
            }
        }
        public bool Connected = false ;
        public List<X32Channel> Channel;
        public List<X32Aux> Aux ;
        public List<X32FxRtn> FxRtn ;
        public List<X32Bus> Bus;
        public List<X32Matrix> Matrix ;
        public X32Main Main ;
        public X32Main Mono ;
        public List<X32Dca> Dca ;
        public List<X32FxUnit> Fx ;
        public List<X32MainOutput> OutputMain ;
        public List<X32Output> OutputAux ;
        public List<X32Output> OutputP16 ;
        public List<X32Output> OutputAes;
        public List<X32Output> OutputRec ;
        public List<X32HeadAmp> HeadAmp;
        public List<X32Meter> Meters;
        public X32MixerConfig Config;        
        public X32Routing Routing;
        public X32Status Status;
        public List<bool> RenewMeters;
        #endregion
        
        public event OnConnectDelegate OnConnect;
        public event OnPacketReceivedDelegate OnPacketReceived;
        public event OnPacketSendDelegate OnPacketSend;    

        #region [Construction]
        public X32()
        {
            EstablishBroker();                      
            CreateChannels(X32MaxChannels);
            CreateAux(X32MaxAux);
            CreateFxRtn(X32MaxFxRtn);
            CreateBus(X32MaxBus);
            CreateMatrix(X32MaxMatrix);
            CreateMain();
            CreateDca();
            CreateEfx();
            CreateMainOutputs();
            CreateOutput(ref OutputAux, "/aux", 6);
            CreateOutput(ref OutputP16, "/p16", 16);
            CreateOutput(ref OutputAes, "/aes", 2);
            CreateOutput(ref OutputRec, "/rec", 2);
            Config = new X32MixerConfig();
            CreateHeadAmp();
            CreateMeters();
            CreateRouting();
            CreateStatus();
            CreateRenewMeters();
            ActivatePing();
            AttachEvents();       
     
            Port = X32Port;                  
        }

        private void CreateRenewMeters()
        {
            RenewMeters = new List<bool>();
            for (int i = 0; i < X32MaxRenewMeters; i++)
            {                
                RenewMeters.Add(new bool());                
            }
        }

        private void CreateStatus()
        {
            Status = new X32Status();
        }

        private void CreateRouting()
        {
            Routing = new X32Routing();
        }

        private void CreateMeters()
        {
            Meters = new List<X32Meter>();
            
            for (int i = 0; i < X32.X32MaxMeters; i++)
            {
                X32Meter m = new X32Meter();
                m.Address = "/meter/" + (i + 1).ToString("D2");
                m.Id = i + 1;
                Meters.Add(m);
            }
        }

        private void CreateHeadAmp()
        {
            HeadAmp = new List<X32HeadAmp>();

            for (int i = 0; i < X32MaxHeadAmp; i++)
            {
                X32HeadAmp h = new X32HeadAmp();
                h.Address = "/headamp/" + (i+1).ToString("D2");
                h.Id = i + 1;
                HeadAmp.Add(h);
            }
        }

        private void CreateOutput(ref List<X32Output> o, string name, int count)
        {
            o = new List<X32Output>();

            for (int i = 0; i < count; i++)
            {
                X32Output m = new X32Output();
                m.Address = "/outputs/" + name + "/" + (i + 1).ToString("D2");
                m.Id = i + 1;  
                o.Add(m);
            }
        }

        private void CreateMainOutputs()
        {
            OutputMain = new List<X32MainOutput>();            

            for (int i = 0; i < 16; i++)
            {
                X32MainOutput m = new X32MainOutput();
                m.Address = "/outputs/main/" + (i + 1).ToString("D2");
                m.Id = i + 1;                
                OutputMain.Add(m);
            }
        }

        private void CreateEfx()
        {
            Fx = new List<X32FxUnit>();

            for (int i = 0; i < X32MaxFxUnits; i++)
            {
                X32FxUnit fx = new X32FxUnit();
                fx.Address = "/fx/" + (i + 1).ToString();
                fx.Id = i;
                Fx.Add(fx);
            }
        }

        private void CreateDca()
        {
            Dca = new List<X32Dca>();
            for (int i = 0; i < X32MaxDCA; i++)
            {
                X32Dca dca = new X32Dca();
                dca.Address = "/dca/" + (i + 1).ToString();
                dca.Id = i + 1;
                Dca.Add(dca);
            }
        }

        private void CreateMain()
        {
            Main = new X32Main();
            Main.Address = "/main/st";
            Main.Id = 0;

            Mono = new X32Main();
            Mono.Address = "/main/m";
            Mono.Id = 0;
        }

        private void CreateMatrix(int count)
        {
            Matrix = new List<X32Matrix>();
            for (int i = 0; i < count; i++)
            {
                X32Matrix matrix = new X32Matrix();
                matrix.Address = "/mtx/" + (i + 1).ToString("D2");
                matrix.Id = i + 1;
                Matrix.Add(matrix);
            }
        }

        private void CreateBus(int count)
        {
            Bus = new List<X32Bus>();
            for (int i = 0; i < count; i++)
            {
                X32Bus bus = new X32Bus();
                bus.Address = "/bus/" + (i + 1).ToString("D2");
                bus.Id = i + 1;
                Bus.Add(bus);
            }
        }

        private void CreateFxRtn(int count)
        {
            FxRtn = new List<X32FxRtn>();
            for (int i = 0; i < count; i++)
            {
                X32FxRtn fx = new X32FxRtn();
                fx.Address = "/fxrtn/" + (i + 1).ToString("D2");
                fx.Id = i + 1;
                FxRtn.Add(fx);
            }
        }

        private void CreateAux(int count)
        {
            Aux = new List<X32Aux>();
            for (int i = 0; i < count; i++)
            {
                X32Aux aux = new X32Aux();
                aux.Address = "/auxin/" + (i + 1).ToString("D2");
                aux.Id = i + 1;
                Aux.Add(aux);
            }
        }

        private void ActivatePing()
        {
            _Timer = new Timer();
            _Timer.Interval = 5000;
        }

        private void EstablishBroker()
        {
            X32Broker = new Broker();
            Protocol = new X32OSCProtocol();
            Transport = new UDPTransportLayer();
            X32Broker.Transport = Transport;
            X32Broker.Protocol = Protocol;
            Protocol.Broker = X32Broker;
            Protocol.Consumer = this;
            Transport.Broker = X32Broker;
        }

        private void CreateChannels(int count)
        {
            Channel = new List<X32Channel>();  
            for (int i = 0; i < count; i++)
            {
                X32Channel channel = new X32Channel();                
                channel.Address = "/ch/" + (i + 1).ToString("D2");
                channel.Id = i + 1;              
                Channel.Add(channel);
            }
        }

        private void AttachEvents()
        {            
            _Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
        #endregion

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Protocol.ReceiveFromConsumer(this, X32OSCProtocol.PackageXRemotePing());
            for (int i = 0; i < X32MaxRenewMeters; i++)
            {
                if (RenewMeters[i])
                    Protocol.ReceiveFromConsumer(this, X32OSCProtocol.RenewMeter(i+1));
            }
            
        }
 
        public override void Connect()
        {
            Transport.Connect();
            SendToProtocol(this, X32OSCProtocol.PackageCopyright());
            SendToProtocol(this, X32OSCProtocol.PackageInfoRequest());

            return;
        }
        public virtual void Connect(string ipAddress)
        {
            IPAddress = IPAddress.Parse(ipAddress);
            Connect();
        }
        public override void Disconnect()
        {
            if (Connected)
            {
                _Timer.Enabled = false;
                Transport.Disconnect();
                Connected = false;
            }
            return;            
        }      

        #region [Brokering]
        protected virtual void SendToProtocol(object sender, OSCPacket packet)
        {
            RaiseOnPacketSend(packet);
            if (Protocol != null)
            {
                Protocol.ReceiveFromConsumer(this, packet);
                Protocol.Flush();
            }
        }

        public void ReceiveFromProtocol(object sender, object packet)
        {            
            throw new NotImplementedException();
        }

        public void ReceiveFromProtocol(object sender, OSCPacket packet)
        {            
            ParseOSCPacket(sender, packet);            
        }

        protected virtual void ParseOSCPacket(object sender, OSCPacket packet)
        {
            return;
        }

        public virtual void SendParameter(IX32Control param)
        {
            if (param is X32StereoLink)
                SendToProtocol(this, ((X32StereoLink)param).LinkChannels());
            else
                SendToProtocol(this, param.ToOSCPacket());
        }

        public virtual void ControlRequest(IX32Control param)
        {
            SendToProtocol(this, OSCConsoleConverter.Inquire((ConsoleControl)param));
        }

        public virtual void ControlRequest(string address)
        {
            SendToProtocol(this, OSCConverter.Inquire(address));
        }
        #endregion               

        #region [Event Raise Methods]

        protected virtual void RaiseOnConnect()
        {
            if (OnConnect != null)
                OnConnect();
        }

        protected virtual void RaiseOnPacketSend(OSCPacket packet)
        {
            if (OnPacketSend != null)
                OnPacketSend(this, packet);
        }

        protected virtual void RaiseOnPacketReceived(object sender, OSCPacket packet)
        {
            if (OnPacketReceived != null)
                OnPacketReceived(sender, packet);
        }
        #endregion

        private ConsoleControl FindControlByAddress(string address)
        {
            ConsoleControl control = null;

            foreach (var channel in Channel)
            {
                control = channel.FindControlByAddress(address);
                if (control != null)
                    break;
            }
            return control;
        }
   
    }

}
