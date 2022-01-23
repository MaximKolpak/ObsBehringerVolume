
using System;
using System.Collections.Generic;
using Behringer.X32.Controls;
using OSC;

namespace Behringer.X32
{
    public delegate void X32OSCDelegate(object sender, OSCPacket packet);

    public class X32Console : X32
    {
        #region [Events]
        public event X32OSCDelegate OnPreAmpTrim;
        public event X32OSCDelegate OnPreAmpInvert;
        public event X32OSCDelegate OnPreAmpHPF;
        public event X32OSCDelegate OnPreAmpHPFSlope;
        public event X32OSCDelegate OnPreAmpHPFFreq;
        public event X32OSCDelegate OnChannelFade;
        public event X32OSCDelegate OnChannelMute;
        public event X32OSCDelegate OnChannelLink;
        public event X32OSCDelegate OnChannelPan;
        public event X32OSCDelegate OnChannelSendToMono;
        public event X32OSCDelegate OnChannelMonoLevel;
        public event X32OSCDelegate OnChannelSendMute;
        public event X32OSCDelegate OnChannelSendLevel;
        public event X32OSCDelegate OnChannelSendPan;
        public event X32OSCDelegate OnChannelSendType;
        public event X32OSCDelegate OnChannelName;
        public event X32OSCDelegate OnChannelIcon;
        public event X32OSCDelegate OnChannelColor;
        public event X32OSCDelegate OnChannelSource;
        public event X32OSCDelegate OnChannelDelay;
        public event X32OSCDelegate OnChannelDelayTime;        
        public event X32OSCDelegate OnChannelGate;
        public event X32OSCDelegate OnChannelGateMode;
        public event X32OSCDelegate OnChannelGateThreshold;
        public event X32OSCDelegate OnChannelGateRange;
        public event X32OSCDelegate OnChannelGateAttack;
        public event X32OSCDelegate OnChannelGateHold;
        public event X32OSCDelegate OnChannelGateRelease;
        public event X32OSCDelegate OnChannelGateKeySource;
        public event X32OSCDelegate OnChannelGateFilter;
        public event X32OSCDelegate OnChannelGateFilterType;
        public event X32OSCDelegate OnChannelGateFilterFreq;
        public event X32OSCDelegate OnChannelComp;
        public event X32OSCDelegate OnChannelCompMode;
        public event X32OSCDelegate OnChannelCompDetect;
        public event X32OSCDelegate OnChannelCompEnvelope;
        public event X32OSCDelegate OnChannelCompThreshold;
        public event X32OSCDelegate OnChannelCompRatio;
        public event X32OSCDelegate OnChannelCompKnee;
        public event X32OSCDelegate OnChannelCompGain;
        public event X32OSCDelegate OnChannelCompAttack;
        public event X32OSCDelegate OnChannelCompHold;
        public event X32OSCDelegate OnChannelCompRelease;
        public event X32OSCDelegate OnChannelCompPosition;
        public event X32OSCDelegate OnChannelCompKeySource;
        public event X32OSCDelegate OnChannelCompFilter;
        public event X32OSCDelegate OnChannelCompFilterType;
        public event X32OSCDelegate OnChannelCompFilterFreq;
        public event X32OSCDelegate OnChannelInsert;
        public event X32OSCDelegate OnChannelInsertPosition;
        public event X32OSCDelegate OnChannelInsertInsert;
        public event X32OSCDelegate OnChannelEQ;
        public event X32OSCDelegate OnChannelEQType;
        public event X32OSCDelegate OnChannelEQFreq;
        public event X32OSCDelegate OnChannelEQGain;
        public event X32OSCDelegate OnChannelEQQ;
        public event X32OSCDelegate OnChannelDCA;
        public event X32OSCDelegate OnChannelMuteGroup;

        public event X32OSCDelegate OnAuxPreAmpTrim;
        public event X32OSCDelegate OnAuxPreAmpInvert;
        public event X32OSCDelegate OnAuxFade;
        public event X32OSCDelegate OnAuxMute;
        public event X32OSCDelegate OnAuxLink;
        public event X32OSCDelegate OnAuxPan;
        public event X32OSCDelegate OnAuxSendToMono;
        public event X32OSCDelegate OnAuxMonoLevel;
        public event X32OSCDelegate OnAuxSendMute;
        public event X32OSCDelegate OnAuxSendLevel;
        public event X32OSCDelegate OnAuxSendPan;
        public event X32OSCDelegate OnAuxSendType;
        public event X32OSCDelegate OnAuxName;
        public event X32OSCDelegate OnAuxIcon;
        public event X32OSCDelegate OnAuxColor;
        public event X32OSCDelegate OnAuxSource;
        public event X32OSCDelegate OnAuxEQ;
        public event X32OSCDelegate OnAuxEQType;
        public event X32OSCDelegate OnAuxEQFreq;
        public event X32OSCDelegate OnAuxEQGain;
        public event X32OSCDelegate OnAuxEQQ;
        public event X32OSCDelegate OnAuxDCA;
        public event X32OSCDelegate OnAuxMuteGroup;

        public event X32OSCDelegate OnFxRtnFade;
        public event X32OSCDelegate OnFxRtnMute;
        public event X32OSCDelegate OnFxRtnLink;
        public event X32OSCDelegate OnFxRtnPan;
        public event X32OSCDelegate OnFxRtnSendToMono;
        public event X32OSCDelegate OnFxRtnMonoLevel;
        public event X32OSCDelegate OnFxRtnSendMute;
        public event X32OSCDelegate OnFxRtnSendLevel;
        public event X32OSCDelegate OnFxRtnSendPan;
        public event X32OSCDelegate OnFxRtnSendType;
        public event X32OSCDelegate OnFxRtnName;
        public event X32OSCDelegate OnFxRtnIcon;
        public event X32OSCDelegate OnFxRtnColor;
        public event X32OSCDelegate OnFxRtnDCA;
        public event X32OSCDelegate OnFxRtnMuteGroup;

        public event X32OSCDelegate OnBusFade;
        public event X32OSCDelegate OnBusMute;
        public event X32OSCDelegate OnBusLink;
        public event X32OSCDelegate OnBusPan;
        public event X32OSCDelegate OnBusSendToMono;
        public event X32OSCDelegate OnBusMonoLevel;
        public event X32OSCDelegate OnBusSendMute;
        public event X32OSCDelegate OnBusSendLevel;
        public event X32OSCDelegate OnBusSendPan;
        public event X32OSCDelegate OnBusName;
        public event X32OSCDelegate OnBusIcon;
        public event X32OSCDelegate OnBusColor;
        public event X32OSCDelegate OnBusComp;
        public event X32OSCDelegate OnBusCompMode;
        public event X32OSCDelegate OnBusCompDetect;
        public event X32OSCDelegate OnBusCompEnvelope;
        public event X32OSCDelegate OnBusCompThreshold;
        public event X32OSCDelegate OnBusCompRatio;
        public event X32OSCDelegate OnBusCompKnee;
        public event X32OSCDelegate OnBusCompGain;
        public event X32OSCDelegate OnBusCompAttack;
        public event X32OSCDelegate OnBusCompHold;
        public event X32OSCDelegate OnBusCompRelease;
        public event X32OSCDelegate OnBusCompPosition;
        public event X32OSCDelegate OnBusCompKeySource;
        public event X32OSCDelegate OnBusCompFilter;
        public event X32OSCDelegate OnBusCompFilterType;
        public event X32OSCDelegate OnBusCompFilterFreq;
        public event X32OSCDelegate OnBusInsert;
        public event X32OSCDelegate OnBusInsertPosition;
        public event X32OSCDelegate OnBusInsertInsert;
        public event X32OSCDelegate OnBusEQ;
        public event X32OSCDelegate OnBusEQType;
        public event X32OSCDelegate OnBusEQFreq;
        public event X32OSCDelegate OnBusEQGain;
        public event X32OSCDelegate OnBusEQQ;
        public event X32OSCDelegate OnBusDCA;
        public event X32OSCDelegate OnBusMuteGroup;

        public event X32OSCDelegate OnMatrixFade;
        public event X32OSCDelegate OnMatrixMute;
        public event X32OSCDelegate OnMatrixName;
        public event X32OSCDelegate OnMatrixIcon;
        public event X32OSCDelegate OnMatrixColor;
        public event X32OSCDelegate OnMatrixComp;
        public event X32OSCDelegate OnMatrixCompMode;
        public event X32OSCDelegate OnMatrixCompDetect;
        public event X32OSCDelegate OnMatrixCompEnvelope;
        public event X32OSCDelegate OnMatrixCompThreshold;
        public event X32OSCDelegate OnMatrixCompRatio;
        public event X32OSCDelegate OnMatrixCompKnee;
        public event X32OSCDelegate OnMatrixCompGain;
        public event X32OSCDelegate OnMatrixCompAttack;
        public event X32OSCDelegate OnMatrixCompHold;
        public event X32OSCDelegate OnMatrixCompRelease;
        public event X32OSCDelegate OnMatrixCompPosition;
        public event X32OSCDelegate OnMatrixCompKeySource;
        public event X32OSCDelegate OnMatrixCompFilter;
        public event X32OSCDelegate OnMatrixCompFilterType;
        public event X32OSCDelegate OnMatrixCompFilterFreq;
        public event X32OSCDelegate OnMatrixInsert;
        public event X32OSCDelegate OnMatrixInsertPosition;
        public event X32OSCDelegate OnMatrixInsertInsert;
        public event X32OSCDelegate OnMatrixEQ;
        public event X32OSCDelegate OnMatrixEQType;
        public event X32OSCDelegate OnMatrixEQFreq;
        public event X32OSCDelegate OnMatrixEQGain;
        public event X32OSCDelegate OnMatrixEQQ;

        public event X32OSCDelegate OnMainFade;
        public event X32OSCDelegate OnMainMute;
        public event X32OSCDelegate OnMainPan;
        public event X32OSCDelegate OnMainSendMute;
        public event X32OSCDelegate OnMainSendLevel;
        public event X32OSCDelegate OnMainSendPan;
        public event X32OSCDelegate OnMainName;
        public event X32OSCDelegate OnMainIcon;
        public event X32OSCDelegate OnMainColor;
        public event X32OSCDelegate OnMainComp;
        public event X32OSCDelegate OnMainCompMode;
        public event X32OSCDelegate OnMainCompDetect;
        public event X32OSCDelegate OnMainCompEnvelope;
        public event X32OSCDelegate OnMainCompThreshold;
        public event X32OSCDelegate OnMainCompRatio;
        public event X32OSCDelegate OnMainCompKnee;
        public event X32OSCDelegate OnMainCompGain;
        public event X32OSCDelegate OnMainCompAttack;
        public event X32OSCDelegate OnMainCompHold;
        public event X32OSCDelegate OnMainCompRelease;
        public event X32OSCDelegate OnMainCompPosition;
        public event X32OSCDelegate OnMainCompKeySource;
        public event X32OSCDelegate OnMainCompFilter;
        public event X32OSCDelegate OnMainCompFilterType;
        public event X32OSCDelegate OnMainCompFilterFreq;
        public event X32OSCDelegate OnMainInsert;
        public event X32OSCDelegate OnMainInsertPosition;
        public event X32OSCDelegate OnMainInsertInsert;
        public event X32OSCDelegate OnMainEQ;
        public event X32OSCDelegate OnMainEQType;
        public event X32OSCDelegate OnMainEQFreq;
        public event X32OSCDelegate OnMainEQGain;
        public event X32OSCDelegate OnMainEQQ;

        public event X32OSCDelegate OnMonoFade;
        public event X32OSCDelegate OnMonoMute;
        public event X32OSCDelegate OnMonoPan;
        public event X32OSCDelegate OnMonoSendMute;
        public event X32OSCDelegate OnMonoSendLevel;
        public event X32OSCDelegate OnMonoSendPan;
        public event X32OSCDelegate OnMonoName;
        public event X32OSCDelegate OnMonoIcon;
        public event X32OSCDelegate OnMonoColor;
        public event X32OSCDelegate OnMonoComp;
        public event X32OSCDelegate OnMonoCompMode;
        public event X32OSCDelegate OnMonoCompDetect;
        public event X32OSCDelegate OnMonoCompEnvelope;
        public event X32OSCDelegate OnMonoCompThreshold;
        public event X32OSCDelegate OnMonoCompRatio;
        public event X32OSCDelegate OnMonoCompKnee;
        public event X32OSCDelegate OnMonoCompGain;
        public event X32OSCDelegate OnMonoCompAttack;
        public event X32OSCDelegate OnMonoCompHold;
        public event X32OSCDelegate OnMonoCompRelease;
        public event X32OSCDelegate OnMonoCompPosition;
        public event X32OSCDelegate OnMonoCompKeySource;
        public event X32OSCDelegate OnMonoCompFilter;
        public event X32OSCDelegate OnMonoCompFilterType;
        public event X32OSCDelegate OnMonoCompFilterFreq;
        public event X32OSCDelegate OnMonoInsert;
        public event X32OSCDelegate OnMonoInsertPosition;
        public event X32OSCDelegate OnMonoInsertInsert;
        public event X32OSCDelegate OnMonoEQ;
        public event X32OSCDelegate OnMonoEQType;
        public event X32OSCDelegate OnMonoEQFreq;
        public event X32OSCDelegate OnMonoEQGain;
        public event X32OSCDelegate OnMonoEQQ;

        public event X32OSCDelegate OnDcaFade;
        public event X32OSCDelegate OnDcaMute;
        public event X32OSCDelegate OnDcaName;
        public event X32OSCDelegate OnDcaIcon;
        public event X32OSCDelegate OnDcaColor;

        public event X32OSCDelegate OnFxType;
        public event X32OSCDelegate OnFxSourceLeft;
        public event X32OSCDelegate OnFxSourceRight;
        public event X32OSCDelegate OnFxParam;

        public event X32OSCDelegate OnOutputSource;
        public event X32OSCDelegate OnOutputPosition;
        public event X32OSCDelegate OnOutputDelay;
        public event X32OSCDelegate OnOutputDelayTime;
        
        public event X32OSCDelegate OnHeadAmpGain;
        public event X32OSCDelegate OnHeadAmpPhantom;

        public event X32OSCDelegate OnMeter;
        #endregion

        protected void RaiseOSCEvent(X32OSCDelegate del, OSCPacket packet)
        {
            if (del != null)
                del(this, packet);
        }    

        protected override void ParseOSCPacket(object sender, OSCPacket packet)
        {
            base.ParseOSCPacket(sender, packet);

            RaiseOnPacketReceived(sender, packet);
            if (packet.Process == true)
            {
                if (packet.Address != null && packet.Address[0] == '/')
                {
                    if (packet.Address == "/info")
                    {
                        RemoteConsole = new RemoteConsole(packet);
                        SendToProtocol(sender, X32OSCProtocol.PackageStatusRequest());
                    }
                    else if (packet.Address == "/status")
                    {
                        RemoteOSCServer = new RemoteOSCServer(packet);
                        SendToProtocol(sender, X32OSCProtocol.PackageXRemotePing());
                        _Timer.Enabled = true;
                        Connected = true;
                        RaiseOnConnect();
                    }
                    else if (packet.Address.Substring(0,8) == "/meters/")                    
                        RaiseOSCEvent(OnMeter, packet);
                    DetermineConsoleFunction(packet);
                }
                
            }            

        }

        protected void DetermineConsoleFunction(OSCPacket packet)
        {
            string command = packet.Nodes[1];

            if (command == "ch")
                PerformChannelActions(packet);
            else if (command == "auxin")
                PerformAuxActions(packet);
            else if (command == "fxrtn")
                PerformFxRtnActions(packet);
            else if (command == "bus")
                PerformBusActions(packet);
            else if (command == "mtx")
                PerformMatrixActions(packet);
            else if (command == "main")
            {
                if (packet.Nodes[2] == "st")
                    PerformMainActions(packet);
                else if (packet.Nodes[2] == "m")
                    PerformMonoActions(packet);
            }
            else if (command == "dca")
                PerformDcaActions(packet);
            else if (command == "fx")
                PerformFxActions(packet);
            else if (command == "outputs")
                PerformOutputActions(packet);
            else if (command == "headamp")
                PerformHeadAmpActions(packet);
        }

        #region [HeadAmp Actions]
        private void PerformHeadAmpActions(OSCPacket packet)
        {
            int channel = Convert.ToInt32(packet.Nodes[2]);
            string command = packet.Nodes[3];

            if (command == "gain")
            {
                HeadAmp[channel].Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnHeadAmpGain, packet);
            }
            else if (command == "phantom")
            {
                HeadAmp[channel].Phantom.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnHeadAmpPhantom, packet);
            }
        }
        #endregion

        #region [Output Actions]
        private void PerformOutputActions(OSCPacket packet)
        {
            List<X32Output> output = null;
            List<X32MainOutput> mainOutput = null;
            string outputName = packet.Nodes[2];

            if (outputName == "main")
                mainOutput = OutputMain;
            else if (outputName == "aux")
                output = OutputAux;
            else if (outputName == "p16")
                output = OutputP16;
            else if (outputName == "aes")
                output = OutputAes;
            else if (outputName == "rec")
                output = OutputRec;

            if (output != null)
            {
                int channel = Convert.ToInt32(packet.Nodes[3]);
                string command = packet.Nodes[4];
                channel--;

                if (command == "src")
                {
                    output[channel].Source.Value = packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnOutputSource, packet);
                }
                else if (command == "pos")
                {
                    output[channel].Position.Value = packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnOutputPosition, packet);
                }
                else if (command == "delay")
                {
                    string subcommand = packet.Nodes[5];
                    if (subcommand == "on")
                    {
                        mainOutput[channel].Delay.On.Value = packet.Arguments[0].ToInt();
                        RaiseOSCEvent(OnOutputDelay, packet);
                    }
                    else if (subcommand == "time")
                    {
                        mainOutput[channel].Delay.Time.Value = packet.Arguments[0].ToFloat();
                        RaiseOSCEvent(OnOutputDelayTime, packet);
                    }
                    
                }
                
            }
            
        }
        # endregion

        #region [FX Actions]
        private void PerformFxActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "type")
            {
                Fx[channel].Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxType, packet);
            }
            else if (command == "source")
            {
                if (packet.Nodes[4] == "l")
                {
                    Fx[channel].SourceLeft.Value = packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnFxSourceLeft, packet);

                }
                else if (packet.Nodes[4] == "r")
                {
                    Fx[channel].SourceRight.Value = packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnFxSourceRight, packet);
                }
           
            }
            else if (command == "par")
            {
                int param = Convert.ToInt32(packet.Nodes[4]);
                Fx[channel].Params[param].Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnFxParam, packet);
            }              

        }
        #endregion

        #region [DCA Actions]
        private void PerformDcaConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                Dca[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnDcaName, packet);
            }
            else if (command == "icon")
            {
                Dca[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnDcaIcon, packet);
            }
            else if (command == "color")
            {
                Dca[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnDcaColor, packet);
            }
        }

        private void PerformDcaActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "fader")
            {
                Dca[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnDcaFade, packet);
            }
            else if (command == "on")
            {
                Dca[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnDcaMute, packet);
            }
            else if (command == "config")
                PerformDcaConfigActions(packet);

        }
        #endregion

        #region [Mono Actions]
        private void PerformMonoEQActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            if (command == "on")
            {
                Mono.Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoEQ, packet);
            }
            else
            {
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--; 

                if (command == "type")
                {
                    Mono.Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnMonoEQType, packet);
                }
                else if (command == "f")
                {
                    Mono.Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMonoEQFreq, packet);
                }
                else if (command == "g")
                {
                    Mono.Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMonoEQGain, packet);
                }
                else if (command == "q")
                {
                    Mono.Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMonoEQQ, packet);
                }
            }
        }

        private void PerformMonoInsertActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "on")
            {
                Mono.Strip.Insert.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoInsert, packet);
            }
            else if (command == "pos")
            {
                Mono.Strip.Insert.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoInsertPosition, packet);
            }
            else if (command == "set")
            {
                Mono.Strip.Insert.Insert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoInsertInsert, packet);
            }
        }

        protected void PerformMonoDynamicsAction(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "on")
            {
                Mono.Strip.Comp.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoComp, packet);
            }
            else if (command == "mode")
            {
                Mono.Strip.Comp.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompMode, packet);
            }
            else if (command == "det")
            {
                Mono.Strip.Comp.Detect.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompDetect, packet);
            }
            else if (command == "env")
            {
                Mono.Strip.Comp.Envelope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompEnvelope, packet);
            }
            else if (command == "thr")
            {
                Mono.Strip.Comp.Threshhold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompThreshold, packet);
            }
            else if (command == "ratio")
            {
                Mono.Strip.Comp.Ratio.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompRatio, packet);
            }
            else if (command == "knee")
            {
                Mono.Strip.Comp.Knee.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompKnee, packet);
            }
            else if (command == "mgain")
            {
                Mono.Strip.Comp.Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompGain, packet);
            }
            else if (command == "attack")
            {
                Mono.Strip.Comp.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompAttack, packet);
            }
            else if (command == "hold")
            {
                Mono.Strip.Comp.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompHold, packet);
            }
            else if (command == "release")
            {
                Mono.Strip.Comp.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompRelease, packet);
            }
            else if (command == "pos")
            {
                Mono.Strip.Comp.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompPosition, packet);
            }
            else if (command == "keysrc")
            {
                Mono.Strip.Comp.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompKeySource, packet);
            }
            else if (command == "filter")
                PerformMonoCompFilterActions(packet);
        }

        protected void PerformMonoCompFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];

            if (command == "on")
            {
                Mono.Strip.Comp.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompFilter, packet);
            }
            else if (command == "type")
            {
                Mono.Strip.Comp.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoCompFilterType, packet);
            }
            else if (command == "f")
            {
                Mono.Strip.Comp.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoCompFilterFreq, packet);
            }
        }

        protected void PerformMonoConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "name")
            {
                Mono.Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnMonoName, packet);
            }
            else if (command == "icon")
            {
                Mono.Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoIcon, packet);
            }
            else if (command == "color")
            {
                Mono.Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoColor, packet);
            }

        }

        protected void PerformMonoMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformMonoSendActions(packet);
            else
            {
                string command = packet.Nodes[4];

                if (command == "fader")
                {
                    Mono.Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMonoFade, packet);
                }
                else if (command == "on")
                {
                    Mono.Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnMonoMute, packet);
                }
                else if (command == "pan")
                {
                    Mono.Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMonoPan, packet);
                }

            }
        }

        protected void PerformMonoSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);

            if (command == "on")
            {
                Mono.Strip.Matrix[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMonoSendMute, packet);
            }
            else if (command == "level")
            {
                Mono.Strip.Matrix[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoSendLevel, packet);
            }
            else if (command == "pan")
            {
                Mono.Strip.Matrix[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMonoSendPan, packet);
            }
        }

        protected void PerformMonoActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformMonoMixActions(packet);
            else if (command == "config")
                PerformMonoConfigActions(packet);
            else if (command == "dyn")
                PerformMonoDynamicsAction(packet);
            else if (command == "insert")
                PerformMonoInsertActions(packet);
            else if (command == "eq")
                PerformMonoEQActions(packet);

        }
        #endregion

        #region [Main Actions]
        private void PerformMainEQActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            if (command == "on")
            {   
                Main.Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainEQ, packet);
            }
            else
            {
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--;

                if (command == "type")
                {
                    Main.Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnMainEQType, packet);
                }
                else if (command == "f")
                {
                    Main.Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMainEQFreq, packet);
                }
                else if (command == "g")
                {
                    Main.Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMainEQGain, packet);
                }
                else if (command == "q")
                {
                    Main.Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMainEQQ, packet);
                }
            }
        }

        private void PerformMainInsertActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "on")
            {
                Main.Strip.Insert.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainInsert, packet);
            }
            else if (command == "pos")
            {
                Main.Strip.Insert.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainInsertPosition, packet);
            }
            else if (command == "set")
            {
                Main.Strip.Insert.Insert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainInsertInsert, packet);
            }
        }

        protected void PerformMainDynamicsAction(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "on")
            {
                Main.Strip.Comp.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainComp, packet);
            }
            else if (command == "mode")
            {
                Main.Strip.Comp.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompMode, packet);
            }
            else if (command == "det")
            {
                Main.Strip.Comp.Detect.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompDetect, packet);
            }
            else if (command == "env")
            {
                Main.Strip.Comp.Envelope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompEnvelope, packet);
            }
            else if (command == "thr")
            {
                Main.Strip.Comp.Threshhold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompThreshold, packet);
            }
            else if (command == "ratio")
            {
                Main.Strip.Comp.Ratio.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompRatio, packet);
            }
            else if (command == "knee")
            {
                Main.Strip.Comp.Knee.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompKnee, packet);
            }
            else if (command == "mgain")
            {
                Main.Strip.Comp.Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompGain, packet);
            }
            else if (command == "attack")
            {
                Main.Strip.Comp.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompAttack, packet);
            }
            else if (command == "hold")
            {
                Main.Strip.Comp.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompHold, packet);
            }
            else if (command == "release")
            {
                Main.Strip.Comp.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompRelease, packet);
            }
            else if (command == "pos")
            {
                Main.Strip.Comp.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompPosition, packet);
            }
            else if (command == "keysrc")
            {
                Main.Strip.Comp.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompKeySource, packet);
            }
            else if (command == "filter")
                PerformMainCompFilterActions(packet);
        }

        protected void PerformMainCompFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];

            if (command == "on")
            {
                Main.Strip.Comp.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompFilter, packet);
            }
            else if (command == "type")
            {
                Main.Strip.Comp.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainCompFilterType, packet);
            }
            else if (command == "f")
            {
                Main.Strip.Comp.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainCompFilterFreq, packet);
            }
        }

        protected void PerformMainConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];

            if (command == "name")
            {
                Main.Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnMainName, packet);
            }
            else if (command == "icon")
            {
                Main.Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainIcon, packet);
            }
            else if (command == "color")
            {
                Main.Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainColor, packet);
            }

        }

        protected void PerformMainMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformMainSendActions(packet);
            else
            {
                string command = packet.Nodes[4];

                if (command == "fader")
                {
                    Main.Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMainFade, packet);
                }
                else if (command == "on")
                {
                    Main.Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnMainMute, packet);
                }
                else if (command == "pan")
                {
                    Main.Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMainPan, packet);
                }

            }
        }

        protected void PerformMainSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);
            mix--;


            if (command == "on")
            {
                Main.Strip.Matrix[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMainSendMute, packet);
            }
            else if (command == "level")
            {
                Main.Strip.Matrix[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainSendLevel, packet);
            }
            else if (command == "pan")
            {
                Main.Strip.Matrix[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMainSendPan, packet);
            }
        }

        protected void PerformMainActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformMainMixActions(packet);
            else if (command == "config")
                PerformMainConfigActions(packet);
            else if (command == "dyn")
                PerformMainDynamicsAction(packet);
            else if (command == "insert")
                PerformMainInsertActions(packet);
            else if (command == "eq")
                PerformMainEQActions(packet);

        }
        #endregion

        #region [Matrix Actions]
        private void PerformMatrixEQActions(OSCPacket packet)
        {
            int channel = Convert.ToInt32(packet.Nodes[2]);
            string command = packet.Nodes[4];
            if (command == "on")
            {
                Matrix[channel].Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixEQ, packet);
            }
            else
            {
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--; channel--;

                if (command == "type")
                {
                    Matrix[channel].Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnMatrixEQType, packet);
                }
                else if (command == "f")
                {
                    Matrix[channel].Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMatrixEQFreq, packet);
                }
                else if (command == "g")
                {
                    Matrix[channel].Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMatrixEQGain, packet);
                }
                else if (command == "q")
                {
                    Matrix[channel].Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnMatrixEQQ, packet);
                }
            }
        }

        private void PerformMatrixInsertActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Matrix[channel].Strip.Insert.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixInsert, packet);
            }
            else if (command == "pos")
            {
                Matrix[channel].Strip.Insert.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixInsertPosition, packet);
            }
            else if (command == "set")
            {
                Matrix[channel].Strip.Insert.Insert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixInsertInsert, packet);
            }
        }

        protected void PerformMatrixDynamicsAction(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Matrix[channel].Strip.Comp.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixComp, packet);
            }
            else if (command == "mode")
            {
                Matrix[channel].Strip.Comp.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompMode, packet);
            }
            else if (command == "det")
            {
                Matrix[channel].Strip.Comp.Detect.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompDetect, packet);
            }
            else if (command == "env")
            {
                Matrix[channel].Strip.Comp.Envelope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompEnvelope, packet);
            }
            else if (command == "thr")
            {
                Matrix[channel].Strip.Comp.Threshhold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompThreshold, packet);
            }
            else if (command == "ratio")
            {
                Matrix[channel].Strip.Comp.Ratio.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompRatio, packet);
            }
            else if (command == "knee")
            {
                Matrix[channel].Strip.Comp.Knee.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompKnee, packet);
            }
            else if (command == "mgain")
            {
                Matrix[channel].Strip.Comp.Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompGain, packet);
            }
            else if (command == "attack")
            {
                Matrix[channel].Strip.Comp.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompAttack, packet);
            }
            else if (command == "hold")
            {
                Matrix[channel].Strip.Comp.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompHold, packet);
            }
            else if (command == "release")
            {
                Matrix[channel].Strip.Comp.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompRelease, packet);
            }
            else if (command == "pos")
            {
                Matrix[channel].Strip.Comp.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompPosition, packet);
            }
            else if (command == "keysrc")
            {
                Matrix[channel].Strip.Comp.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompKeySource, packet);
            }
            else if (command == "filter")
                PerformMatrixCompFilterActions(packet);
        }

        protected void PerformMatrixCompFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Matrix[channel].Strip.Comp.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompFilter, packet);
            }
            else if (command == "type")
            {
                Matrix[channel].Strip.Comp.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixCompFilterType, packet);
            }
            else if (command == "f")
            {
                Matrix[channel].Strip.Comp.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixCompFilterFreq, packet);
            }
        }

        protected void PerformMatrixConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                Matrix[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnMatrixName, packet);
            }
            else if (command == "icon")
            {
                Matrix[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixIcon, packet);
            }
            else if (command == "color")
            {
                Matrix[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixColor, packet);
            }

        }

        protected void PerformMatrixMixActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "fader")
            {
                Matrix[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnMatrixFade, packet);
            }
            else if (command == "on")
            {
                Matrix[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnMatrixMute, packet);
            }

        }

        protected void PerformMatrixActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformMatrixMixActions(packet);
            else if (command == "config")
                PerformMatrixConfigActions(packet);
            else if (command == "dyn")
                PerformMatrixDynamicsAction(packet);
            else if (command == "insert")
                PerformMatrixInsertActions(packet);
            else if (command == "eq")
                PerformMatrixEQActions(packet);
        }
        #endregion

        #region [Bus Actions]
        private void PerformBusGroupActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "dca")
            {
                Bus[channel].Strip.Dca.Dca.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusDCA, packet);
            }
            else if (command == "mute")
            {
                Bus[channel].Strip.Dca.Mute.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusMuteGroup, packet);
            }
        }

        private void PerformBusEQActions(OSCPacket packet)
        {            
            int channel = Convert.ToInt32(packet.Nodes[2]);
            string command = packet.Nodes[4];
            if (command == "on")
            {
                Bus[channel].Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusEQ, packet);
            }
            else
            {
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--; channel--;

                if (command == "type")
                {
                    Bus[channel].Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnBusEQType, packet);
                }
                else if (command == "f")
                {
                    Bus[channel].Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusEQFreq, packet);
                }
                else if (command == "g")
                {
                    Bus[channel].Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusEQGain, packet);
                }
                else if (command == "q")
                {
                    Bus[channel].Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusEQQ, packet);
                }
            }
        }

        private void PerformBusInsertActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Bus[channel].Strip.Insert.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusInsert, packet);
            }
            else if (command == "pos")
            {
                Bus[channel].Strip.Insert.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusInsertPosition, packet);
            }
            else if (command == "set")
            {
                Bus[channel].Strip.Insert.Insert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusInsertInsert, packet);
            }
        }

        protected void PerformBusDynamicsAction(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Bus[channel].Strip.Comp.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusComp, packet);
            }
            else if (command == "mode")
            {
                Bus[channel].Strip.Comp.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompMode, packet);
            }
            else if (command == "det")
            {
                Bus[channel].Strip.Comp.Detect.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompDetect, packet);
            }
            else if (command == "env")
            {
                Bus[channel].Strip.Comp.Envelope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompEnvelope, packet);
            }
            else if (command == "thr")
            {
                Bus[channel].Strip.Comp.Threshhold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompThreshold, packet);
            }
            else if (command == "ratio")
            {
                Bus[channel].Strip.Comp.Ratio.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompRatio, packet);
            }
            else if (command == "knee")
            {
                Bus[channel].Strip.Comp.Knee.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompKnee, packet);
            }
            else if (command == "mgain")
            {
                Bus[channel].Strip.Comp.Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompGain, packet);
            }
            else if (command == "attack")
            {
                Bus[channel].Strip.Comp.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompAttack, packet);
            }
            else if (command == "hold")
            {
                Bus[channel].Strip.Comp.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompHold, packet);
            }
            else if (command == "release")
            {
                Bus[channel].Strip.Comp.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompRelease, packet);
            }
            else if (command == "pos")
            {
                Bus[channel].Strip.Comp.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompPosition, packet);
            }
            else if (command == "keysrc")
            {
                Bus[channel].Strip.Comp.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompKeySource, packet);
            }
            else if (command == "filter")
                PerformBusCompFilterActions(packet);
        }

        protected void PerformBusCompFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Bus[channel].Strip.Comp.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompFilter, packet);
            }
            else if (command == "type")
            {
                Bus[channel].Strip.Comp.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusCompFilterType, packet);
            }
            else if (command == "f")
            {
                Bus[channel].Strip.Comp.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusCompFilterFreq, packet);
            }
        }

        protected void PerformBusConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                Bus[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnBusName, packet);
            }
            else if (command == "icon")
            {
                Bus[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusIcon, packet);
            }
            else if (command == "color")
            {
                Bus[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusColor, packet);
            }

        }

        protected void PerformBusMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformBusSendActions(packet);
            else
            {
                string command = packet.Nodes[4];
                int channel = Convert.ToInt32(packet.Nodes[2]);
                channel--;

                if (command == "fader")
                {
                    Bus[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusFade, packet);
                }
                else if (command == "on")
                {
                    Bus[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnBusMute, packet);
                }
                else if (command == "st")
                {
                    Bus[channel].Strip.Link.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnBusLink, packet);
                }
                else if (command == "pan")
                {
                    Bus[channel].Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusPan, packet);
                }
                else if (command == "mono")
                {
                    Bus[channel].Strip.MonoSend.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnBusSendToMono, packet);
                }
                else if (command == "mlevel")
                {
                    Bus[channel].Strip.MonoFader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnBusMonoLevel, packet);
                }
            }
        }

        protected void PerformBusSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--; mix--;

            if (command == "on")
            {
                Bus[channel].Strip.Matrix[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnBusSendMute, packet);
            }
            else if (command == "level")
            {
                Bus[channel].Strip.Matrix[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusSendLevel, packet);
            }
            else if (command == "pan")
            {
                Bus[channel].Strip.Matrix[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnBusSendPan, packet);
            }
        }

        protected void PerformBusActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformBusMixActions(packet);
            else if (command == "config")
                PerformBusConfigActions(packet);
            else if (command == "dyn")
                PerformBusDynamicsAction(packet);
            else if (command == "insert")
                PerformBusInsertActions(packet);
            else if (command == "eq")
                PerformBusEQActions(packet);
            else if (command == "grp")
                PerformBusGroupActions(packet);
        }
        #endregion

        #region [FxRtn Actions]
        private void PerformFxRtnActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformFxRtnMixActions(packet);
            else if (command == "config")
                PerformFxRtnConfigActions(packet);
            else if (command == "grp")
                PerformFxRtnGroupActions(packet);
        }

        private void PerformFxRtnGroupActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "dca")
            {
                FxRtn[channel].Strip.Dca.Dca.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnDCA, packet);
            }
            else if (command == "mute")
            {
                FxRtn[channel].Strip.Dca.Mute.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnMuteGroup, packet);
            }
        }

        private void PerformFxRtnConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                FxRtn[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnFxRtnName, packet);
            }
            else if (command == "icon")
            {
                FxRtn[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnIcon, packet);
            }
            else if (command == "color")
            {
                FxRtn[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnColor, packet);
            }
        }

        protected void PerformFxRtnSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--; mix--;

            if (command == "on")
            {
                FxRtn[channel].Strip.MixBuss[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnSendMute, packet);
            }
            else if (command == "level")
            {
                FxRtn[channel].Strip.MixBuss[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnFxRtnSendLevel, packet);
            }
            else if (command == "pan")
            {
                FxRtn[channel].Strip.MixBuss[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnFxRtnSendPan, packet);
            }
            else if (command == "type")
            {
                FxRtn[channel].Strip.MixBuss[mix].TapPoint.Value = (X32TapType)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnFxRtnSendType, packet);
            }
        }

        protected void PerformFxRtnMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformFxRtnSendActions(packet);
            else
            {
                string command = packet.Nodes[4];
                int channel = Convert.ToInt32(packet.Nodes[2]);
                channel--;

                if (command == "fader")
                {
                    FxRtn[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnFxRtnFade, packet);
                }
                else if (command == "on")
                {
                    FxRtn[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnFxRtnMute, packet);
                }
                else if (command == "st")
                {
                    FxRtn[channel].Strip.Link.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnFxRtnLink, packet);
                }
                else if (command == "pan")
                {
                    FxRtn[channel].Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnFxRtnPan, packet);
                }
                else if (command == "mono")
                {
                    FxRtn[channel].Strip.MonoSend.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnFxRtnSendToMono, packet);
                }
                else if (command == "mlevel")
                {
                    FxRtn[channel].Strip.MonoFader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnFxRtnMonoLevel, packet);
                }
            }
        }
        #endregion

        #region [Aux Actions]
        private void PerformAuxActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformAuxMixActions(packet);
            else if (command == "config")
                PerformAuxConfigActions(packet);
            else if (command == "preamp")
                PerformAuxPreAmpActions(packet);
            else if (command == "eq")
                PerformAuxEQActions(packet);
            else if (command == "grp")
                PerformAuxGroupActions(packet);

        }

        private void PerformAuxGroupActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "dca")
            {
                Aux[channel].Strip.Dca.Dca.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxDCA, packet);
            }
            else if (command == "mute")
            {
                Aux[channel].Strip.Dca.Mute.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxMuteGroup, packet);
            }
        }

        private void PerformAuxEQActions(OSCPacket packet)
        {
            int channel = Convert.ToInt32(packet.Nodes[2]);
            string command = packet.Nodes[4];
            if (command == "on")
            {
                Aux[channel].Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxEQ, packet);
            }
            else
            {
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--; channel--;

                if (command == "type")
                {
                    Aux[channel].Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnAuxEQType, packet);
                }
                else if (command == "f")
                {
                    Aux[channel].Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxEQFreq, packet);
                }
                else if (command == "g")
                {
                    Aux[channel].Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxEQGain, packet);
                }
                else if (command == "q")
                {
                    Aux[channel].Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxEQQ, packet);
                }
            }
        }

        private void PerformAuxPreAmpActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "trim")
            {
                Aux[channel].Strip.Pre.Trim.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnAuxPreAmpTrim, packet);
            }
            else if (command == "invert")
            {
                Aux[channel].Strip.Pre.Invert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxPreAmpInvert, packet);
            }
        }

        private void PerformAuxConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                Aux[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnAuxName, packet);
            }
            else if (command == "icon")
            {
                Aux[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxIcon, packet);
            }
            else if (command == "color")
            {
                Aux[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxColor, packet);
            }
            else if (command == "source")
            {
                Aux[channel].Strip.Config.Source.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxSource, packet);
            }
        }

        protected void PerformAuxSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--; mix--;

            if (command == "on")
            {
                Aux[channel].Strip.MixBuss[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxSendMute, packet);
            }
            else if (command == "level")
            {
                Aux[channel].Strip.MixBuss[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnAuxSendLevel, packet);
            }
            else if (command == "pan")
            {
                Aux[channel].Strip.MixBuss[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnAuxSendPan, packet);
            }
            else if (command == "type")
            {
                Aux[channel].Strip.MixBuss[mix].TapPoint.Value = (X32TapType)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnAuxSendType, packet);
            }
        }

        protected void PerformAuxMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformAuxSendActions(packet);
            else
            {
                string command = packet.Nodes[4];
                int channel = Convert.ToInt32(packet.Nodes[2]);
                channel--;

                if (command == "fader")
                {
                    Aux[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxFade, packet);
                }
                else if (command == "on")
                {
                    Aux[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnAuxMute, packet);
                }
                else if (command == "st")
                {
                    Aux[channel].Strip.Link.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnAuxLink, packet);
                }
                else if (command == "pan")
                {
                    Aux[channel].Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxPan, packet);
                }
                else if (command == "mono")
                {
                    Aux[channel].Strip.MonoSend.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnAuxSendToMono, packet);
                }
                else if (command == "mlevel")
                {
                    Aux[channel].Strip.MonoFader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnAuxMonoLevel, packet);
                }
            }
        }
        #endregion

        #region [Channel Actions]
        private void PerformChannelGroupActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "dca")
            {
                Channel[channel].Strip.Dca.Dca.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelDCA, packet);
            }
            else if (command == "mute")
            {
                Channel[channel].Strip.Dca.Mute.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelMuteGroup, packet);
            }
        }

        private void PerformChannelEQActions(OSCPacket packet)
        {
            int channel = Convert.ToInt32(packet.Nodes[2]);
            string command = packet.Nodes[4];
            if (command == "on")
            {
                Channel[channel].Strip.Eq.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelEQ, packet);
            }
            else
            {                
                command = packet.Nodes[5];
                int band = Convert.ToInt32(packet.Nodes[4]);
                band--; channel--;

                if (command == "type")
                {
                    Channel[channel].Strip.Eq.Band[band].Type = (X32EQType)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnChannelEQType, packet);
                }
                else if (command == "f")
                {
                    Channel[channel].Strip.Eq.Band[band].Freq.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelEQFreq, packet);
                }
                else if (command == "g")
                {
                    Channel[channel].Strip.Eq.Band[band].Gain.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelEQGain, packet);
                }
                else if (command == "q")
                {
                    Channel[channel].Strip.Eq.Band[band].Q.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelEQQ, packet);
                }
            }
        }

        private void PerformChannelInsertActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Insert.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelInsert, packet);
            }
            else if (command == "pos")
            {
                Channel[channel].Strip.Insert.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelInsertPosition, packet);
            }
            else if (command == "set")
            {
                Channel[channel].Strip.Insert.Insert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelInsertInsert, packet);
            }
        }

        protected void PerformChannelDynamicsAction(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Comp.Active.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelComp, packet);
            }
            else if (command == "mode")
            {
                Channel[channel].Strip.Comp.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompMode, packet);
            }
            else if (command == "det")
            {
                Channel[channel].Strip.Comp.Detect.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompDetect, packet);
            }
            else if (command == "env")
            {
                Channel[channel].Strip.Comp.Envelope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompEnvelope, packet);
            }
            else if (command == "thr")
            {
                Channel[channel].Strip.Comp.Threshhold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompThreshold, packet);
            }
            else if (command == "ratio")
            {
                Channel[channel].Strip.Comp.Ratio.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompRatio, packet);
            }
            else if (command == "knee")
            {
                Channel[channel].Strip.Comp.Knee.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompKnee, packet);
            }
            else if (command == "mgain")
            {
                Channel[channel].Strip.Comp.Gain.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompGain, packet);
            }
            else if (command == "attack")
            {
                Channel[channel].Strip.Comp.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompAttack, packet);
            }
            else if (command == "hold")
            {
                Channel[channel].Strip.Comp.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompHold, packet);
            }
            else if (command == "release")
            {
                Channel[channel].Strip.Comp.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompRelease, packet);
            }
            else if (command == "pos")
            {
                Channel[channel].Strip.Comp.Position.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompPosition, packet);
            }
            else if (command == "keysrc")
            {
                Channel[channel].Strip.Comp.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompKeySource, packet);
            }
            else if (command == "filter")
                PerformChannelCompFilterActions(packet);
        }

        protected void PerformChannelCompFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Comp.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompFilter, packet);
            }
            else if (command == "type")
            {
                Channel[channel].Strip.Comp.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelCompFilterType, packet);
            }
            else if (command == "f")
            {
                Channel[channel].Strip.Comp.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelCompFilterFreq, packet);
            }
        }

        protected void PerformChannelGateActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Gate.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelGate, packet);
            }
            else if (command == "mode")
            {
                Channel[channel].Strip.Gate.Mode.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelGateMode, packet);
            }
            else if (command == "thr")
            {
                Channel[channel].Strip.Gate.Threshold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateThreshold, packet);
            }
            else if (command == "range")
            {
                Channel[channel].Strip.Gate.Range.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateRange, packet);
            }
            else if (command == "attack")
            {
                Channel[channel].Strip.Gate.Attack.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateAttack, packet);
            }
            else if (command == "hold")
            {
                Channel[channel].Strip.Gate.Hold.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateHold, packet);
            }
            else if (command == "release")
            {
                Channel[channel].Strip.Gate.Release.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateRelease, packet);
            }
            else if (command == "keysrc")
            {
                Channel[channel].Strip.Gate.KeySource.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelGateKeySource, packet);
            }
            else if (command == "filter")
                PerformGateFilterActions(packet);
        }

        protected void PerformGateFilterActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Gate.Filter.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelGateFilter, packet);
            }
            else if (command == "type")
            {
                Channel[channel].Strip.Gate.Filter.Type.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelGateFilterType, packet);
            }
            else if (command == "f")
            {
                Channel[channel].Strip.Gate.Filter.Freq.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelGateFilterFreq, packet);
            }
        }

        protected void PerformChannelPreAmpActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "trim")
            {
                Channel[channel].Strip.Pre.Trim.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnPreAmpTrim, packet);
            }
            else if (command == "invert")
            {
                Channel[channel].Strip.Pre.Invert.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnPreAmpInvert, packet);
            }
            else if (command == "hpon")
            {
                Channel[channel].Strip.Pre.Hpf.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnPreAmpHPF, packet);
            }
            else if (command == "hpslope")
            {
                Channel[channel].Strip.Pre.Slope.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnPreAmpHPFSlope, packet);
            }
            else if (command == "hpf")
            {
                Channel[channel].Strip.Pre.HpfFreq.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnPreAmpHPFFreq, packet);
            }
        }

        protected void PerformChannelDelayActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "on")
            {
                Channel[channel].Strip.Delay.On.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelDelay, packet);
            }
            else if (command == "time")
            {
                Channel[channel].Strip.Delay.Time.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelDelayTime, packet);
            }

        }

        protected void PerformChannelConfigActions(OSCPacket packet)
        {
            string command = packet.Nodes[4];
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--;

            if (command == "name")
            {
                Channel[channel].Strip.Config.Name.Value = packet.Arguments[0].ToString();
                RaiseOSCEvent(OnChannelName, packet);
            }
            else if (command == "icon")
            {
                Channel[channel].Strip.Config.Icon.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelIcon, packet);
            }
            else if (command == "color")
            {
                Channel[channel].Strip.Config.Color.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelColor, packet);
            }
            else if (command == "source")
            {
                Channel[channel].Strip.Config.Source.Value = packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelSource, packet);
            }
        }

        protected void PerformChannelMixActions(OSCPacket packet)
        {
            if (packet.Nodes.Length > 5)
                PerformChannelSendActions(packet);
            else
            {
                string command = packet.Nodes[4];
                int channel = Convert.ToInt32(packet.Nodes[2]);
                channel--;

                if (command == "fader")
                {
                    Channel[channel].Strip.Fader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelFade, packet);                    
                }
                else if (command == "on")
                {
                    Channel[channel].Strip.Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnChannelMute, packet);                    
                }
                else if (command == "st")
                {
                    Channel[channel].Strip.Link.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnChannelLink, packet);                    
                }
                else if (command == "pan")
                {
                    Channel[channel].Strip.Pan.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelPan, packet);                    
                }
                else if (command == "mono")
                {
                    Channel[channel].Strip.MonoSend.Value = (X32OnOff)packet.Arguments[0].ToInt();
                    RaiseOSCEvent(OnChannelSendToMono, packet);                    
                }
                else if (command == "mlevel")
                {
                    Channel[channel].Strip.MonoFader.Value = packet.Arguments[0].ToFloat();
                    RaiseOSCEvent(OnChannelMonoLevel, packet);                    
                }
            }
        }

        protected void PerformChannelSendActions(OSCPacket packet)
        {
            string command = packet.Nodes[5];
            int mix = Convert.ToInt32(packet.Nodes[4]);
            int channel = Convert.ToInt32(packet.Nodes[2]);
            channel--; mix--;

            if (command == "on")
            {
                Channel[channel].Strip.MixBuss[mix].Mute.Value = (X32OnOff)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelSendMute, packet);                
            }
            else if (command == "level")
            {
                Channel[channel].Strip.MixBuss[mix].Fader.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelSendLevel, packet);                
            }
            else if (command == "pan")
            {
                Channel[channel].Strip.MixBuss[mix].Pan.Value = packet.Arguments[0].ToFloat();
                RaiseOSCEvent(OnChannelSendPan, packet);                
            }
            else if (command == "type")
            {
                Channel[channel].Strip.MixBuss[mix].TapPoint.Value = (X32TapType)packet.Arguments[0].ToInt();
                RaiseOSCEvent(OnChannelSendType, packet);                
            }
        }

        protected void PerformChannelActions(OSCPacket packet)
        {
            string command = packet.Nodes[3];

            if (command == "mix")
                PerformChannelMixActions(packet);
            else if (command == "config")
                PerformChannelConfigActions(packet);
            else if (command == "delay")
                PerformChannelDelayActions(packet);
            else if (command == "preamp")
                PerformChannelPreAmpActions(packet);
            else if (command == "gate")
                PerformChannelGateActions(packet);
            else if (command == "dyn")
                PerformChannelDynamicsAction(packet);
            else if (command == "insert")
                PerformChannelInsertActions(packet);
            else if (command == "eq")
                PerformChannelEQActions(packet);
            else if (command == "grp")
                PerformChannelGroupActions(packet);
        }
        #endregion

    }

}
